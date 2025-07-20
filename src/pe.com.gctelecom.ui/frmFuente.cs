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
    public partial class frmFuente : Form
    {
        // Instancia de la capa de lógica de negocio para fuentes
        private FuenteBAL fuenteBAL = new FuenteBAL();

        // Variable para almacenar el ID de la fuente seleccionada
        private int fuenteSeleccionadaId = 0;

        public frmFuente()
        {
            InitializeComponent();
            // Cargar datos al iniciar el formulario
            CargarFuentesEnDataGridView();
            LimpiarCampos(); // Limpiar campos al inicio
        }

        // Método para cargar las fuentes en el DataGridView
        private void CargarFuentesEnDataGridView()
        {
            try
            {
                // Obtener todas las fuentes (visibles e invisibles)
                List<FuenteBO> listaFuentes = fuenteBAL.ObtenerFuentesHabilitados(); // Asumiendo este método en FuenteBAL
                dgvFuentes.DataSource = listaFuentes;

                // Ocultar columnas que no son relevantes para la visualización directa
                dgvFuentes.Columns["EsVisible"].Visible = false; // La usaremos para la lógica de habilitar/deshabilitar

                // Renombrar columnas para una mejor lectura en la UI
                dgvFuentes.Columns["FuenteId"].HeaderText = "ID Fuente";
                dgvFuentes.Columns["Nombre"].HeaderText = "Nombre de la Fuente";

                // Ajustar el tamaño de las columnas
                dgvFuentes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar fuentes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            fuenteSeleccionadaId = 0; // Reiniciar el ID de la fuente seleccionada
            txtNombre.Clear();
            chkEstado.Checked = true; // Por defecto, una nueva fuente está habilitada
            btnActualizar.Enabled = false; // Deshabilitar botón actualizar para nuevo registro
            btnRegistrar.Enabled = true; // Habilitar botón registrar
            txtNombre.Focus(); // Poner el foco en el primer campo
        }

        // Método para validar los campos del formulario
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la fuente es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        // Evento Click del botón Registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return; // Si la validación falla, no continuar
            }

            FuenteBO fuente = new FuenteBO
            {
                Nombre = txtNombre.Text.Trim(),
                EsVisible = chkEstado.Checked // Se guarda el estado del checkbox
            };

            bool exito = false;

            // Siempre es un nuevo registro si fuenteSeleccionadaId es 0
            exito = fuenteBAL.CrearFuente(fuente); // Asumiendo este método en FuenteBAL

            if (exito)
            {
                MessageBox.Show("Fuente registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFuentesEnDataGridView(); // Recargar el DataGridView para ver los cambios
                LimpiarCampos(); // Limpiar los campos después de guardar
            }
            else
            {
                MessageBox.Show("Error al registrar la fuente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click del botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (fuenteSeleccionadaId == 0)
            {
                MessageBox.Show("Debe seleccionar una fuente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
            {
                return; // Si la validación falla, no continuar
            }

            FuenteBO fuente = new FuenteBO
            {
                FuenteId = fuenteSeleccionadaId,
                Nombre = txtNombre.Text.Trim(),
                EsVisible = chkEstado.Checked // Se guarda el estado del checkbox
            };

            bool exito = fuenteBAL.ActualizarFuente(fuente); // Asumiendo este método en FuenteBAL

            if (exito)
            {
                MessageBox.Show("Fuente actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFuentesEnDataGridView(); // Recargar el DataGridView para ver los cambios
                LimpiarCampos(); // Limpiar los campos después de guardar
            }
            else
            {
                MessageBox.Show("Error al actualizar la fuente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click del botón Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento CellMouseClick del DataGridView para cargar datos al seleccionar una fila
        private void dgvFuentes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Asegurarse de que se hizo clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvFuentes.Rows[e.RowIndex];

                // Obtener el FuenteId de la fila seleccionada
                fuenteSeleccionadaId = Convert.ToInt32(fila.Cells["FuenteId"].Value);

                // Cargar los datos de la fila en los controles del formulario
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["EsVisible"].Value);

                // Habilitar el botón de actualizar y deshabilitar el de registrar
                btnActualizar.Enabled = true;
                btnRegistrar.Enabled = false;
            }
        }

        // Evento para manejar el cambio de estado del CheckBox Habilitado
        // Este evento se usará para activar/desactivar directamente desde el checkbox
        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            // Solo aplicar lógica si se ha seleccionado una fuente existente
            if (fuenteSeleccionadaId == 0)
            {
                return; // No hacer nada si es un nuevo registro
            }

            // Si el checkbox se desmarca y el botón de registrar está habilitado,
            // significa que no se ha cargado una fuente existente, por lo que no se debería
            // permitir deshabilitar desde aquí.
            if (!chkEstado.Checked && btnRegistrar.Enabled)
            {
                return;
            }

            // Si el estado del checkbox cambia, preguntar al usuario si desea cambiar la visibilidad
            DialogResult resultado = MessageBox.Show(
                (chkEstado.Checked ? "¿Desea habilitar esta fuente?" : "¿Desea deshabilitar esta fuente?"),
                "Confirmar Cambio de Visibilidad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                if (chkEstado.Checked)
                {
                    exito = fuenteBAL.HabilitarFuente(fuenteSeleccionadaId); // Asumiendo este método en FuenteBAL
                }
                else
                {
                    exito = fuenteBAL.BorrarFuente(fuenteSeleccionadaId); // Asumiendo este método en FuenteBAL
                }

                if (exito)
                {
                    MessageBox.Show("Estado de visibilidad actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarFuentesEnDataGridView(); // Recargar el DataGridView
                    // No limpiar campos aquí para permitir ver el estado actualizado
                }
                else
                {
                    MessageBox.Show("Error al actualizar el estado de visibilidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Revertir el estado del checkbox si hubo un error
                    chkEstado.Checked = !chkEstado.Checked;
                }
            }
            else
            {
                // Si el usuario cancela, revertir el estado del checkbox
                chkEstado.Checked = !chkEstado.Checked;
            }
        }
    }
}
