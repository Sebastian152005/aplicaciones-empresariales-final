using Microsoft.VisualBasic.Logging;
using pe.com.gctelecom.bal; // Importa la capa BAL
using pe.com.gctelecom.bo;  // Importa la capa BO
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
    public partial class frmReclamo : Form
    {
        // Instancias de las capas de lógica de negocio
        private ReclamoBAL reclamoBAL = new ReclamoBAL();
        private ProductoBAL productoBAL = new ProductoBAL(); // Necesario para el ComboBox de Producto

        // Variable para almacenar el ID del reclamo seleccionado
        private int reclamoSeleccionadoId = 0;

        public frmReclamo()
        {
            InitializeComponent();
            // Cargar datos al iniciar el formulario
            CargarProductosEnComboBox();
            CargarEstadosEnComboBox();
            CargarReclamosEnDataGridView();
            LimpiarCampos(); // Limpiar campos al inicio
        }

        // Método para cargar los productos en el ComboBox (asumiendo "Venta relacionada" es Producto)
        private void CargarProductosEnComboBox()
        {
            try
            {
                // Obtener solo los productos habilitados para el ComboBox
                // Esta llamada es crucial para que solo aparezcan los productos activos
                List<ProductoBO> listaProductos = productoBAL.ObtenerProductosHabilitados();
                cboVenta.DataSource = listaProductos; // Usando cboVenta
                cboVenta.DisplayMember = "Nombre";    // Propiedad a mostrar en el ComboBox
                cboVenta.ValueMember = "ProductoId";  // Propiedad que representa el valor (ID)
                cboVenta.SelectedIndex = -1; // Deseleccionar por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos en el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los estados del reclamo en el ComboBox
        private void CargarEstadosEnComboBox()
        {
            // Los estados son fijos según la tabla reclamo: 'Pendiente', 'En Progreso', 'Cerrado'
            cboEstado.Items.Add("Pendiente"); // Usando cboEstado
            cboEstado.Items.Add("En Progreso");
            cboEstado.Items.Add("Cerrado");
            cboEstado.SelectedIndex = 0; // Por defecto a "Pendiente"
        }

        // Método para cargar los reclamos en el DataGridView
        private void CargarReclamosEnDataGridView()
        {
            try
            {
                // Obtener solo los reclamos habilitados
                List<ReclamoBO> listaReclamos = reclamoBAL.ObtenerReclamosHabilitados(); // Asumiendo este método en ReclamoBAL
                dgvReclamos.DataSource = listaReclamos;

                // Ocultar columnas que no son relevantes para la visualización directa
                // dgvReclamos.Columns["EsVisible"].Visible = false; // Ya no es tan crítico ocultarla si solo mostramos habilitados
                // dgvReclamos.Columns["ProductoId"].Visible = false; // Puedes mostrarla si quieres el ID del producto

                // Renombrar columnas para una mejor lectura en la UI
                dgvReclamos.Columns["ReclamoId"].HeaderText = "ID Reclamo";
                dgvReclamos.Columns["ProductoId"].HeaderText = "ID Producto"; // Opcional, si lo ocultaste arriba
                dgvReclamos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvReclamos.Columns["Fecha"].HeaderText = "Fecha Reclamo";
                dgvReclamos.Columns["Estado"].HeaderText = "Estado";
                dgvReclamos.Columns["EsVisible"].HeaderText = "Habilitado"; // Mostrar el estado de habilitado

                // Formatear la columna de Fecha
                dgvReclamos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Ajustar el tamaño de las columnas
                dgvReclamos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reclamos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            reclamoSeleccionadoId = 0; // Reiniciar el ID del reclamo seleccionado
            cboVenta.SelectedIndex = -1; // Deseleccionar producto // Usando cboVenta
            dtpFecha.Value = DateTime.Now; // Fecha actual // Usando dtpFechaReclamo
            cboEstado.SelectedIndex = 0; // Estado por defecto a "Pendiente" // Usando cboEstado
            txtDescripcion.Clear();
            chkHabilitado.Checked = true; // Por defecto, un nuevo reclamo está habilitado

            btnEditar.Enabled = false;   // Deshabilitar botón editar
            btnEliminar.Enabled = false; // Deshabilitar botón eliminar
            btnGuardar.Text = "Guardar"; // Texto por defecto para guardar
            btnNuevo.Enabled = true;     // Habilitar botón nuevo

            cboVenta.Focus(); // Poner el foco en el primer campo // Usando cboVenta
        }

        // Método para validar los campos del formulario
        private bool ValidarCampos()
        {
            if (cboVenta.SelectedValue == null) // Usando cboVenta
            {
                MessageBox.Show("Debe seleccionar un producto relacionado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVenta.Focus(); // Usando cboVenta
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción del reclamo es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            if (cboEstado.SelectedItem == null) // Usando cboEstado
            {
                MessageBox.Show("Debe seleccionar un estado para el reclamo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEstado.Focus(); // Usando cboEstado
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

            ReclamoBO reclamo = new ReclamoBO
            {
                ProductoId = Convert.ToInt32(cboVenta.SelectedValue), // Usando cboVenta
                Descripcion = txtDescripcion.Text.Trim(),
                Fecha = dtpFecha.Value, // Usando dtpFechaReclamo
                Estado = cboEstado.SelectedItem.ToString(), // Usando cboEstado
                EsVisible = chkHabilitado.Checked
            };

            bool exito = false;

            if (reclamoSeleccionadoId == 0)
            {
                // Es un nuevo reclamo
                exito = reclamoBAL.CrearReclamo(reclamo); // Asumiendo este método en ReclamoBAL
                if (exito)
                {
                    MessageBox.Show("Reclamo creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear el reclamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Es una actualización de un reclamo existente
                reclamo.ReclamoId = reclamoSeleccionadoId;
                exito = reclamoBAL.ActualizarReclamo(reclamo); // Asumiendo este método en ReclamoBAL
                if (exito)
                {
                    MessageBox.Show("Reclamo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el reclamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exito)
            {
                CargarReclamosEnDataGridView(); // Recargar el DataGridView para ver los cambios
                LimpiarCampos(); // Limpiar los campos después de guardar
            }
        }

        // Evento Click del botón Editar (este botón no es necesario si el guardado maneja ambos)
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (reclamoSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un reclamo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (reclamoSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un reclamo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar (deshabilitar) este reclamo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool exito = reclamoBAL.BorrarReclamo(reclamoSeleccionadoId); // Asumiendo este método en ReclamoBAL
                if (exito)
                {
                    MessageBox.Show("Reclamo deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarReclamosEnDataGridView(); // Recargar el DataGridView
                    LimpiarCampos(); // Limpiar los campos
                }
                else
                {
                    MessageBox.Show("Error al deshabilitar el reclamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento CellClick del DataGridView para cargar datos al seleccionar una fila
        private void dgvReclamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que se hizo clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReclamos.Rows[e.RowIndex];

                // Obtener el ReclamoId de la fila seleccionada
                reclamoSeleccionadoId = Convert.ToInt32(fila.Cells["ReclamoId"].Value);

                // Cargar los datos de la fila en los controles del formulario

                // Seleccionar el producto en el ComboBox
                if (fila.Cells["ProductoId"].Value != DBNull.Value)
                {
                    cboVenta.SelectedValue = Convert.ToInt32(fila.Cells["ProductoId"].Value); // Usando cboVenta
                }
                else
                {
                    cboVenta.SelectedIndex = -1; // Si no hay producto, deseleccionar // Usando cboVenta
                }

                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value); // Usando dtpFechaReclamo
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();

                // Seleccionar el estado en el ComboBox
                if (fila.Cells["Estado"].Value != DBNull.Value)
                {
                    cboEstado.SelectedItem = fila.Cells["Estado"].Value.ToString(); // Usando cboEstado
                }
                else
                {
                    cboEstado.SelectedIndex = 0; // Por defecto a "Pendiente" // Usando cboEstado
                }

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
            // Solo aplicar lógica si se ha seleccionado un reclamo existente
            if (reclamoSeleccionadoId == 0)
            {
                return; // No hacer nada si es un nuevo registro
            }

            // Si el checkbox se desmarca y el botón de guardar no dice "Actualizar",
            // significa que no se ha cargado un reclamo existente, por lo que no se debería
            // permitir deshabilitar desde aquí.
            if (!chkHabilitado.Checked && btnGuardar.Text != "Actualizar")
            {
                return;
            }

            // Si el estado del checkbox cambia, preguntar al usuario si desea cambiar la visibilidad
            DialogResult resultado = MessageBox.Show(
                (chkHabilitado.Checked ? "¿Desea habilitar este reclamo?" : "¿Desea deshabilitar este reclamo?"),
                "Confirmar Cambio de Visibilidad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                if (chkHabilitado.Checked)
                {
                    exito = reclamoBAL.HabilitarReclamo(reclamoSeleccionadoId); // Asumiendo este método en ReclamoBAL
                }
                else
                {
                    exito = reclamoBAL.BorrarReclamo(reclamoSeleccionadoId); // Asumiendo este método en ReclamoBAL
                }

                if (exito)
                {
                    MessageBox.Show("Estado de visibilidad actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarReclamosEnDataGridView(); // Recargar el DataGridView
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
