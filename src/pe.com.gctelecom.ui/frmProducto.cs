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
    public partial class frmProducto : Form
    {
        // Instancia de la capa de lógica de negocio para productos
        private ProductoBAL productoBAL = new ProductoBAL();

        // Variable para almacenar el ID del producto seleccionado
        private int productoSeleccionadoId = 0;

        public frmProducto()
        {
            InitializeComponent();
            // Cargar datos al iniciar el formulario
            CargarProductosEnDataGridView();
            CargarMonedasEnComboBox(); // Cargar las opciones de moneda
            LimpiarCampos(); // Limpiar campos al inicio
        }

        // Método para cargar los productos en el DataGridView
        private void CargarProductosEnDataGridView()
        {
            try
            {
                // CAMBIO AQUÍ: Obtener solo productos habilitados para que los eliminados no se muestren
                List<ProductoBO> listaProductos = productoBAL.ObtenerProductosHabilitados();
                dgvProducto.DataSource = listaProductos; // Usando dgvProducto

                // Ocultar columnas que no son relevantes para la visualización directa
                // dgvProducto.Columns["EsVisible"].Visible = false; // Ya no es tan crítico ocultarla si solo mostramos habilitados

                // Renombrar columnas para una mejor lectura en la UI
                dgvProducto.Columns["ProductoId"].HeaderText = "ID Producto";
                dgvProducto.Columns["Nombre"].HeaderText = "Nombre";
                dgvProducto.Columns["Descripcion"].HeaderText = "Descripción";
                dgvProducto.Columns["Precio"].HeaderText = "Precio";
                dgvProducto.Columns["Moneda"].HeaderText = "Moneda";
                dgvProducto.Columns["EsVisible"].HeaderText = "Habilitado"; // Mostrar el estado de habilitado

                // Formatear la columna de Precio como moneda
                dgvProducto.Columns["Precio"].DefaultCellStyle.Format = "C2"; // C2 para formato de moneda con 2 decimales
                dgvProducto.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                // Ajustar el tamaño de las columnas
                dgvProducto.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las opciones de moneda en el ComboBox
        private void CargarMonedasEnComboBox()
        {
            // Puedes cargar esto desde una tabla si tienes una, o de forma estática
            cboMoneda.Items.Add("PEN"); // Soles Peruanos // Usando cboMoneda
            cboMoneda.Items.Add("USD"); // Dólares Americanos
            cboMoneda.SelectedIndex = 0; // Seleccionar PEN por defecto
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            productoSeleccionadoId = 0; // Reiniciar el ID del producto seleccionado
            txtNombre.Clear(); // Usando txtNombre
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cboMoneda.SelectedIndex = 0; // Restablecer a PEN // Usando cboMoneda
            chkHabilitado.Checked = true; // Por defecto, un nuevo producto está habilitado

            btnEditar.Enabled = false;   // Deshabilitar botón editar
            btnEliminar.Enabled = false; // Deshabilitar botón eliminar
            btnGuardar.Text = "Guardar"; // Texto por defecto para guardar
            btnNuevo.Enabled = true;     // Habilitar botón nuevo

            txtNombre.Focus(); // Poner el foco en el primer campo // Usando txtNombre
        }

        // Método para validar los campos del formulario
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) // Usando txtNombre
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus(); // Usando txtNombre
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción del producto es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("El precio del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un valor numérico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            if (cboMoneda.SelectedItem == null) // Usando cboMoneda
            {
                MessageBox.Show("Debe seleccionar una moneda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMoneda.Focus(); // Usando cboMoneda
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

            ProductoBO producto = new ProductoBO
            {
                Nombre = txtNombre.Text.Trim(), // Usando txtNombre
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = Convert.ToDecimal(txtPrecio.Text),
                Moneda = cboMoneda.SelectedItem.ToString(), // Usando cboMoneda
                EsVisible = chkHabilitado.Checked
            };

            bool exito = false;

            if (productoSeleccionadoId == 0)
            {
                // Es un nuevo producto
                exito = productoBAL.CrearProducto(producto); // Asumiendo este método en ProductoBAL
                if (exito)
                {
                    MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Es una actualización de un producto existente
                producto.ProductoId = productoSeleccionadoId;
                exito = productoBAL.ActualizarProducto(producto); // Asumiendo este método en ProductoBAL
                if (exito)
                {
                    MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exito)
            {
                CargarProductosEnDataGridView(); // Recargar el DataGridView para ver los cambios
                LimpiarCampos(); // Limpiar los campos después de guardar
            }
        }

        // Evento Click del botón Editar (este botón no es necesario si el guardado maneja ambos)
        // Pero si lo quieres para forzar el modo edición, aquí está la lógica:
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Al hacer clic en editar, simplemente nos aseguramos de que el modo sea de actualización
            btnGuardar.Text = "Actualizar";
            btnEditar.Enabled = false; // Deshabilitar editar una vez que estamos en modo edición
            btnNuevo.Enabled = false;  // Deshabilitar nuevo para evitar confusiones
        }

        // Evento Click del botón Eliminar (desactivar)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoId == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar (deshabilitar) este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool exito = productoBAL.BorrarProducto(productoSeleccionadoId); // Asumiendo este método en ProductoBAL
                if (exito)
                {
                    MessageBox.Show("Producto deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductosEnDataGridView(); // Recargar el DataGridView
                    LimpiarCampos(); // Limpiar los campos
                }
                else
                {
                    MessageBox.Show("Error al deshabilitar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento CellMouseClick del DataGridView para cargar datos al seleccionar una fila
        private void dgvProducto_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Asegurarse de que se hizo clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProducto.Rows[e.RowIndex]; // Usando dgvProducto

                // Obtener el ProductoId de la fila seleccionada
                productoSeleccionadoId = Convert.ToInt32(fila.Cells["ProductoId"].Value);

                // Cargar los datos de la fila en los controles del formulario
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString(); // Usando txtNombre
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();

                // Seleccionar la moneda en el ComboBox
                if (fila.Cells["Moneda"].Value != DBNull.Value)
                {
                    cboMoneda.SelectedItem = fila.Cells["Moneda"].Value.ToString(); // Usando cboMoneda
                }
                else
                {
                    cboMoneda.SelectedIndex = 0; // Por defecto a PEN si no hay moneda // Usando cboMoneda
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
            // Solo aplicar lógica si se ha seleccionado un producto existente
            if (productoSeleccionadoId == 0)
            {
                return; // No hacer nada si es un nuevo registro
            }

            // Si el checkbox se desmarca y el botón de guardar no dice "Actualizar",
            // significa que no se ha cargado un producto existente, por lo que no se debería
            // permitir deshabilitar desde aquí.
            if (!chkHabilitado.Checked && btnGuardar.Text != "Actualizar")
            {
                return;
            }

            // Si el estado del checkbox cambia, preguntar al usuario si desea cambiar la visibilidad
            DialogResult resultado = MessageBox.Show(
                (chkHabilitado.Checked ? "¿Desea habilitar este producto?" : "¿Desea deshabilitar este producto?"),
                "Confirmar Cambio de Visibilidad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                if (chkHabilitado.Checked)
                {
                    exito = productoBAL.HabilitarProducto(productoSeleccionadoId); // Asumiendo este método en ProductoBAL
                }
                else
                {
                    exito = productoBAL.BorrarProducto(productoSeleccionadoId); // Asumiendo este método en ProductoBAL
                }

                if (exito)
                {
                    MessageBox.Show("Estado de visibilidad actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductosEnDataGridView(); // Recargar el DataGridView
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
