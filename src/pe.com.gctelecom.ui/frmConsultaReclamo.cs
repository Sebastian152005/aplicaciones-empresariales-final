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
    public partial class frmConsultaReclamo : Form
    {
        // Instancia de la capa de lógica de negocio para reclamos
        private ReclamoBAL reclamoBAL = new ReclamoBAL();
        private ProductoBAL productoBAL = new ProductoBAL(); // Para obtener nombres de productos si es necesario

        public frmConsultaReclamo()
        {
            InitializeComponent();
            // Configurar el DataGridView
            ConfigurarDataGridViewReclamos();
            // Cargar ComboBox de estados al iniciar
            CargarEstadosReclamoEnComboBox();
            // Cargar reclamos al iniciar el formulario
            CargarReclamosEnDataGridView();
            LimpiarFiltros(); // Limpiar filtros al inicio
        }

        // Configuración inicial del DataGridView de reclamos
        private void ConfigurarDataGridViewReclamos()
        {
            dgvReclamos.AutoGenerateColumns = false; // Deshabilitar auto-generación para definir columnas manualmente

            // Definir columnas (asegúrate de que los DataPropertyName coincidan con las propiedades de ReclamoBO)
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ReclamoId", HeaderText = "ID Reclamo", Visible = false });
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ProductoId", HeaderText = "ID Producto", Visible = false });
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "NombreProducto", HeaderText = "Producto", ReadOnly = true }); // Asumiendo que ReclamoBO tendrá esta propiedad o la obtendremos por JOIN
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Descripcion", HeaderText = "Descripción", ReadOnly = true });
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Fecha", HeaderText = "Fecha Reclamo", ReadOnly = true, DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" } });
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Estado", HeaderText = "Estado", ReadOnly = true });
            dgvReclamos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EsVisible", HeaderText = "Habilitado", ReadOnly = true });

            dgvReclamos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Método para cargar los estados de reclamo en el ComboBox de filtro
        private void CargarEstadosReclamoEnComboBox()
        {
            // Puedes obtener estos estados de una tabla de configuración, un enum, o definirlos aquí
            cboEstado.Items.Add("Todos los Estados");
            cboEstado.Items.Add("Pendiente");
            cboEstado.Items.Add("En Proceso");
            cboEstado.Items.Add("Resuelto");
            cboEstado.Items.Add("Cerrado");
            cboEstado.SelectedIndex = 0; // Seleccionar "Todos los Estados" por defecto
        }

        // Método para cargar los reclamos en el DataGridView con filtros
        private void CargarReclamosEnDataGridView()
        {
            try
            {
                // Obtener todos los reclamos (o solo habilitados, dependiendo de tu ReclamoBAL)
                // Para una consulta robusta, ReclamoBAL debería tener un método ObtenerReclamos(string estado, DateTime? fechaDesde, DateTime? fechaHasta, bool? esVisible)
                List<ReclamoBO> listaReclamos = reclamoBAL.ObtenerTodosReclamos(); // Asumiendo este método existe en ReclamoBAL

                // Aplicar filtros en memoria
                string? filtroEstado = (cboEstado.SelectedItem != null && cboEstado.SelectedItem.ToString() != "Todos los Estados") ? cboEstado.SelectedItem.ToString() : null;
                DateTime? fechaDesde = dtpInicio.Value.Date; // Solo la fecha, sin hora
                DateTime? fechaHasta = dtpFin.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del día

                var reclamosFiltrados = listaReclamos.AsQueryable();

                if (!string.IsNullOrEmpty(filtroEstado))
                {
                    reclamosFiltrados = reclamosFiltrados.Where(r => r.Estado.Equals(filtroEstado, StringComparison.OrdinalIgnoreCase));
                }

                // Filtrar por rango de fechas
                reclamosFiltrados = reclamosFiltrados.Where(r => r.Fecha >= fechaDesde && r.Fecha <= fechaHasta);

                dgvReclamos.DataSource = reclamosFiltrados.ToList();

                dgvReclamos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reclamos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de filtro
        private void LimpiarFiltros()
        {
            cboEstado.SelectedIndex = 0; // "Todos los Estados"
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            CargarReclamosEnDataGridView(); // Recargar el DataGridView con los filtros limpios
        }

        // Evento Click del botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReclamosEnDataGridView(); // Recargar el DataGridView con los filtros aplicados
        }

        // Evento CellClick del DataGridView (útil si necesitas seleccionar un reclamo para otra operación)
        private void dgvReclamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReclamos.Rows[e.RowIndex];
                int reclamoId = Convert.ToInt32(fila.Cells["ReclamoId"].Value);
                string estadoReclamo = fila.Cells["Estado"].Value.ToString();

                MessageBox.Show($"Reclamo seleccionado: ID {reclamoId}, Estado: {estadoReclamo}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ejemplo: Si este formulario se usa para seleccionar un reclamo para otra ventana,
                // podrías guardar el reclamo seleccionado en una propiedad pública y cerrar el formulario.
                // this.DialogResult = DialogResult.OK;
                // this.SelectedReclamoId = reclamoId;
                // this.Close();
            }
        }

        // Opcional: Eventos para recargar al cambiar filtros (si no hay botón Limpiar/Buscar)
        private void cboEstadoReclamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // CargarReclamosEnDataGridView(); // Descomentar para búsqueda en tiempo real
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            // CargarReclamosEnDataGridView(); // Descomentar para búsqueda en tiempo real
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            // CargarReclamosEnDataGridView(); // Descomentar para búsqueda en tiempo real
        }
    }
}
