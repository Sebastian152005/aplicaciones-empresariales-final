using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pe.com.gctelecom.bal; // Importa la capa BAL
using pe.com.gctelecom.bo;  // Importa la capa BO

namespace pe.com.gctelecom.ui
{
    public partial class frmVendedor : Form
    {
        // Instancia de la capa de lógica de negocio para vendedores
        private VendedorBAL vendedorBAL = new VendedorBAL();

        // Variable para almacenar el ID del vendedor seleccionado
        private int vendedorSeleccionadoId = 0;

        public frmVendedor()
        {
            InitializeComponent();
            // Cargar datos al iniciar el formulario
            CargarVendedoresEnDataGridView();
            LimpiarCampos(); // Limpiar campos al inicio
        }

        // Método para cargar los vendedores en el DataGridView
        private void CargarVendedoresEnDataGridView()
        {
            try
            {
                // Obtener solo los vendedores habilitados para que los eliminados no se muestren
                List<VendedorBO> listaVendedores = vendedorBAL.ObtenerVendedorsHabilitados(); // Asumiendo este método en VendedorBAL
                dgvVendedor.DataSource = listaVendedores;

                // Renombrar columnas para una mejor lectura en la UI
                dgvVendedor.Columns["VendedorId"].HeaderText = "ID Vendedor";
                dgvVendedor.Columns["Nombre"].HeaderText = "Nombre";
                dgvVendedor.Columns["Correo"].HeaderText = "Correo Electrónico";
                dgvVendedor.Columns["Celular"].HeaderText = "Celular";
                dgvVendedor.Columns["Direccion"].HeaderText = "Dirección";
                dgvVendedor.Columns["EsVisible"].HeaderText = "Habilitado"; // Mostrar el estado de habilitado

                // Ajustar el tamaño de las columnas
                dgvVendedor.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            vendedorSeleccionadoId = 0; // Reiniciar el ID del vendedor seleccionado
            txtNombre.Clear();
            txtCorreo.Clear();
            txtCelular.Clear();
            txtDireccion.Clear();
            chkHabilitado.Checked = true; // Por defecto, un nuevo vendedor está habilitado

            btnEditar.Enabled = false;   // Deshabilitar botón editar
            btnEliminar.Enabled = false; // Deshabilitar botón eliminar
            btnGuardar.Text = "Guardar"; // Texto por defecto para guardar
            btnNuevo.Enabled = true;     // Habilitar botón nuevo

            txtNombre.Focus(); // Poner el foco en el primer campo
        }

        // Método para validar los campos del formulario
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del vendedor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            return true;
        }

        // Evento Click del botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento Click del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return; // Si la validación falla, no continuar
            }

            VendedorBO vendedor = new VendedorBO
            {
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Celular = txtCelular.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EsVisible = chkHabilitado.Checked
            };

            bool exito = false;

            if (vendedorSeleccionadoId == 0)
            {
                // Es un nuevo vendedor
                exito = vendedorBAL.CrearVendedor(vendedor); // Asumiendo este método en VendedorBAL
                if (exito)
                {
                    MessageBox.Show("Vendedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear el vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Es una actualización de un vendedor existente
                vendedor.VendedorId = vendedorSeleccionadoId;
                exito = vendedorBAL.ActualizarVendedor(vendedor); // Asumiendo este método en VendedorBAL
                if (exito)
                {
                    MessageBox.Show("Vendedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exito)
            {
                CargarVendedoresEnDataGridView(); // Recargar el DataGridView para ver los cambios
                LimpiarCampos(); // Limpiar los campos después de guardar
            }
        }

        // Evento Click del botón Editar (este botón no es necesario si el guardado maneja ambos)
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (vendedorSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un vendedor para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Al hacer clic en editar, simplemente nos aseguramos de que el modo sea de actualización
            btnGuardar.Text = "Actualizar";
            btnEditar.Enabled = false;   // Deshabilitar editar una vez que estamos en modo edición
            btnNuevo.Enabled = false;    // Deshabilitar nuevo para evitar confusiones
        }

        // Evento Click del botón Eliminar (desactivar)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (vendedorSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un vendedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar (deshabilitar) este vendedor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool exito = vendedorBAL.BorrarVendedor(vendedorSeleccionadoId); // Asumiendo este método en VendedorBAL
                if (exito)
                {
                    MessageBox.Show("Vendedor deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVendedoresEnDataGridView(); // Recargar el DataGridView
                    LimpiarCampos(); // Limpiar los campos
                }
                else
                {
                    MessageBox.Show("Error al deshabilitar el vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento CellClick del DataGridView para cargar datos al seleccionar una fila
        private void dgvVendedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que se hizo clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvVendedor.Rows[e.RowIndex];

                // Obtener el VendedorId de la fila seleccionada
                vendedorSeleccionadoId = Convert.ToInt32(fila.Cells["VendedorId"].Value);

                // Cargar los datos de la fila en los controles del formulario
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtCelular.Text = fila.Cells["Celular"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();

                // Establecer el estado de visibilidad (habilitado/deshabilitado)
                chkHabilitado.Checked = Convert.ToBoolean(fila.Cells["EsVisible"].Value);

                // Habilitar botones de editar y eliminar
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnGuardar.Text = "Actualizar"; // Cambiar texto del botón para indicar actualización
                btnNuevo.Enabled = true; // Asegurarse de que Nuevo esté habilitado para iniciar un nuevo registro
            }
        }

        // Evento para manejar el cambio de estado del CheckBox Habilitado
        // Este evento se usará para activar/desactivar directamente desde el checkbox
        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            // Solo aplicar lógica si se ha seleccionado un vendedor existente
            if (vendedorSeleccionadoId == 0)
            {
                return; // No hacer nada si es un nuevo registro
            }

            // Si el checkbox se desmarca y el botón de guardar no dice "Actualizar",
            // significa que no se ha cargado un vendedor existente, por lo que no se debería
            // permitir deshabilitar desde aquí.
            if (!chkHabilitado.Checked && btnGuardar.Text != "Actualizar")
            {
                return;
            }

            // Si el estado del checkbox cambia, preguntar al usuario si desea cambiar la visibilidad
            DialogResult resultado = MessageBox.Show(
                (chkHabilitado.Checked ? "¿Desea habilitar este vendedor?" : "¿Desea deshabilitar este vendedor?"),
                "Confirmar Cambio de Visibilidad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                if (chkHabilitado.Checked)
                {
                    exito = vendedorBAL.HabilitarVendedor(vendedorSeleccionadoId); // Asumiendo este método en VendedorBAL
                }
                else
                {
                    exito = vendedorBAL.BorrarVendedor(vendedorSeleccionadoId); // Asumiendo este método en VendedorBAL
                }

                if (exito)
                {
                    MessageBox.Show("Estado de visibilidad actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVendedoresEnDataGridView(); // Recargar el DataGridView
                    // No limpiar campos aquí para permitir ver el estado actualizado
                }
                else
                {
                    MessageBox.Show("Error al actualizar el estado de visibilidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Revertir el estado del checkbox si hubo un error
                    chkHabilitado.Checked = !chkHabilitado.Checked;
                }
            }
            else
            {
                // Si el usuario cancela, revertir el estado del checkbox
                chkHabilitado.Checked = !chkHabilitado.Checked;
            }
        }
    }
}
