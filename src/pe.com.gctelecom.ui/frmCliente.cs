using pe.com.gctelecom.bal; 
using pe.com.gctelecom.bo;  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pe.com.gctelecom.ui
{
    public partial class frmCliente : Form
    {
        // Instancia de la capa de lógica de negocio para clientes
        private ClienteBAL clienteBAL = new ClienteBAL();
        // Instancia de la capa de lógica de negocio para fuentes (necesaria para el ComboBox)
        private FuenteBAL fuenteBAL = new FuenteBAL(); // Asumiendo que tienes una FuenteBAL

        // Variable para almacenar el ID del cliente seleccionado
        private int clienteSeleccionadoId = 0;

        public frmCliente()
        {
            InitializeComponent();
            // Cargar datos al iniciar el formulario
            CargarClientesEnDataGridView();
            CargarFuentesEnComboBox();
            LimpiarCampos(); // Limpiar campos al inicio
        }

        // Método para cargar los clientes en el DataGridView
        private void CargarClientesEnDataGridView()
        {
            try
            {
                // Obtener todos los clientes (visibles e invisibles)
                List<ClienteBO> listaClientes = clienteBAL.ObtenerTodosClientes();
                dgvClientes.DataSource = listaClientes;

                // Ocultar columnas que no son relevantes para la visualización directa
                dgvClientes.Columns["FuenteId"].Visible = false;
                dgvClientes.Columns["FechaRegistro"].Visible = false; // Puedes mostrarla si lo deseas
                dgvClientes.Columns["EsVisible"].Visible = false; // La usaremos para la lógica de habilitar/deshabilitar

                // Renombrar columnas para una mejor lectura en la UI
                dgvClientes.Columns["ClienteId"].HeaderText = "ID Cliente";
                dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
                dgvClientes.Columns["Correo"].HeaderText = "Correo Electrónico";
                dgvClientes.Columns["Celular"].HeaderText = "Celular";
                dgvClientes.Columns["Direccion"].HeaderText = "Dirección";

                // Ajustar el tamaño de las columnas
                dgvClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las fuentes en el ComboBox
        private void CargarFuentesEnComboBox()
        {
            try
            {
                List<FuenteBO> listaFuentes = fuenteBAL.ObtenerFuentesHabilitados();
                cboFuente.DataSource = listaFuentes;
                cboFuente.DisplayMember = "Nombre";
                cboFuente.ValueMember = "FuenteId";
            }
            catch (Exception ex)
            {
                // ¡ESTA LÍNEA ES CLAVE PARA VER EL ERROR!
                MessageBox.Show("Error al cargar fuentes en el ComboBox: " + ex.Message + "\n\n" + ex.StackTrace, "Error de Carga de Fuentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            clienteSeleccionadoId = 0; // Reiniciar el ID del cliente seleccionado
            txtNombre.Clear();
            txtCorreo.Clear();
            txtCelular.Clear();
            txtDireccion.Clear();
            cboFuente.SelectedIndex = -1; // Deseleccionar cualquier elemento en el ComboBox
            chkEstado.Checked = true; // Por defecto, un nuevo cliente está habilitado
            btnEliminar.Enabled = false; // Deshabilitar botón eliminar para nuevo registro
            btnGuardar.Text = "Guardar cliente"; // Texto por defecto para guardar
            txtNombre.Focus(); // Poner el foco en el primer campo
        }

        // Método para validar los campos del formulario
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El correo electrónico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }
            // Validación básica de formato de correo electrónico
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("El número de celular es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCelular.Focus();
                return false;
            }
            // Validación de que el celular tenga 9 dígitos (ajusta según tu necesidad)
            if (txtCelular.Text.Length != 9 || !txtCelular.Text.All(char.IsDigit))
            {
                MessageBox.Show("El número de celular debe tener 9 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCelular.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }
            if (cboFuente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una fuente de origen.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFuente.Focus();
                return false;
            }
            return true;
        }

        // Evento Click del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return; // Si la validación falla, no continuar
            }

            ClienteBO cliente = new ClienteBO
            {
                FuenteId = Convert.ToInt32(cboFuente.SelectedValue),
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Celular = txtCelular.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EsVisible = chkEstado.Checked
            };

            bool exito = false;

            if (clienteSeleccionadoId == 0)
            {
                // Es un nuevo cliente
                exito = clienteBAL.CrearCliente(cliente);
                if (exito)
                {
                    MessageBox.Show("Cliente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Es una actualización de un cliente existente
                cliente.ClienteId = clienteSeleccionadoId;
                exito = clienteBAL.ActualizarCliente(cliente);
                if (exito)
                {
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exito)
            {
                CargarClientesEnDataGridView(); // Recargar el DataGridView para ver los cambios
                LimpiarCampos(); // Limpiar los campos después de guardar
            }
        }

        // Evento Click del botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento Click del botón Eliminar (desactivar)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar (deshabilitar) este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool exito = clienteBAL.BorrarCliente(clienteSeleccionadoId); // Llama al método BorrarCliente (desactivar)
                if (exito)
                {
                    MessageBox.Show("Cliente deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientesEnDataGridView(); // Recargar el DataGridView
                    LimpiarCampos(); // Limpiar los campos
                }
                else
                {
                    MessageBox.Show("Error al deshabilitar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento Click del botón Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }

        // Evento CellMouseClick del DataGridView para cargar datos al seleccionar una fila
        private void dgvClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Asegurarse de que se hizo clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // Obtener el ClienteId de la fila seleccionada
                clienteSeleccionadoId = Convert.ToInt32(fila.Cells["ClienteId"].Value);

                // Cargar los datos de la fila en los controles del formulario
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtCelular.Text = fila.Cells["Celular"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();

                // Seleccionar la fuente de origen en el ComboBox
                // Asegúrate de que el ValueMember del ComboBox sea "FuenteId"
                if (fila.Cells["FuenteId"].Value != DBNull.Value)
                {
                    cboFuente.SelectedValue = Convert.ToInt32(fila.Cells["FuenteId"].Value);
                }
                else
                {
                    cboFuente.SelectedIndex = -1; // Si no hay fuente, deseleccionar
                }

                // Establecer el estado de visibilidad (habilitado/deshabilitado)
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["EsVisible"].Value);

                // Habilitar el botón de eliminar cuando se selecciona un cliente
                btnEliminar.Enabled = true;
                btnGuardar.Text = "Actualizar cliente"; // Cambiar texto del botón para indicar actualización
            }
        }

        // Evento para manejar el cambio de estado del CheckBox Habilitado
        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            // Si se selecciona un cliente existente y se desmarca el checkbox "Habilitado"
            // y el botón "Guardar" no dice "Actualizar cliente", significa que se está
            // intentando deshabilitar un cliente sin haberlo seleccionado previamente.
            // Esta lógica es para asegurar que el botón "Eliminar" (deshabilitar)
            // se use para deshabilitar, o que el checkbox refleje el estado al actualizar.

            // Si el ID del cliente seleccionado es 0 (nuevo registro) y el checkbox se desmarca,
            // no hay nada que hacer con la visibilidad en la base de datos aún.
            if (clienteSeleccionadoId == 0)
            {
                return;
            }

            // Si el checkbox se desmarca y el cliente ya existe, se considera "eliminar" (deshabilitar)
            if (!chkEstado.Checked)
            {
                // Si el botón de guardar todavía dice "Guardar cliente", significa que no se ha
                // cargado un cliente existente, por lo que no se debería permitir deshabilitar desde aquí.
                if (btnGuardar.Text == "Guardar cliente")
                {
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Desea deshabilitar este cliente?", "Confirmar Deshabilitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    bool exito = clienteBAL.BorrarCliente(clienteSeleccionadoId);
                    if (exito)
                    {
                        MessageBox.Show("Cliente deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientesEnDataGridView();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al deshabilitar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkEstado.Checked = true; // Revertir el estado si hay un error
                    }
                }
                else
                {
                    chkEstado.Checked = true; // Si el usuario cancela, revertir el estado del checkbox
                }
            }
            else // Si el checkbox se marca y el cliente ya existe, se considera "habilitar"
            {
                // Si el botón de guardar todavía dice "Guardar cliente", significa que no se ha
                // cargado un cliente existente, por lo que no se debería permitir habilitar desde aquí.
                if (btnGuardar.Text == "Guardar cliente")
                {
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Desea habilitar este cliente?", "Confirmar Habilitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    bool exito = clienteBAL.HabilitarCliente(clienteSeleccionadoId);
                    if (exito)
                    {
                        MessageBox.Show("Cliente habilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientesEnDataGridView();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al habilitar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkEstado.Checked = false; // Revertir el estado si hay un error
                    }
                }
                else
                {
                    chkEstado.Checked = false; // Si el usuario cancela, revertir el estado del checkbox
                }
            }
        }
    }
}
