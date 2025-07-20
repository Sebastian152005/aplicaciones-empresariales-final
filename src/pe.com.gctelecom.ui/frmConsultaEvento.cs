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
    public partial class frmConsultaEvento : Form
    {
        // Instancias de las capas de lógica de negocio
        private EventoBAL eventoBAL = new EventoBAL();
        private ClienteBAL clienteBAL = new ClienteBAL(); // Para cargar el ComboBox de clientes

        public frmConsultaEvento()
        {
            InitializeComponent();
            // Configurar el DataGridView
            ConfigurarDataGridViewEventos();
            // Cargar ComboBoxes al iniciar
            CargarClientesEnComboBox();
            CargarTiposEventoEnComboBox();
            // Cargar eventos al iniciar el formulario
            CargarEventosEnDataGridView();
            LimpiarFiltros(); // Limpiar filtros al inicio
        }

        // Configuración inicial del DataGridView de eventos
        private void ConfigurarDataGridViewEventos()
        {
            dgvEventos.AutoGenerateColumns = false; // Deshabilitar auto-generación para definir columnas manualmente

            // Definir columnas (asegúrate de que los DataPropertyName coincidan con las propiedades de EventoBO)
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EventoId", HeaderText = "ID Evento", Visible = false });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ClienteId", HeaderText = "ID Cliente", Visible = false });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "NombreCliente", HeaderText = "Cliente", ReadOnly = true }); // Asumiendo que EventoBO tendrá esta propiedad o la obtendremos por JOIN
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "VendedorId", HeaderText = "ID Vendedor", Visible = false });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "NombreVendedor", HeaderText = "Vendedor", ReadOnly = true }); // Asumiendo que EventoBO tendrá esta propiedad o la obtendremos por JOIN
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Tipo", HeaderText = "Tipo Evento", ReadOnly = true });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Descripcion", HeaderText = "Descripción", ReadOnly = true });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "FechaInicio", HeaderText = "Fecha Inicio", ReadOnly = true, DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" } });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Duracion", HeaderText = "Duración (horas)", ReadOnly = true });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EsVisible", HeaderText = "Habilitado", ReadOnly = true });

            dgvEventos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Método para cargar los clientes en el ComboBox de filtro
        private void CargarClientesEnComboBox()
        {
            try
            {
                List<ClienteBO> listaClientes = clienteBAL.ObtenerClientesHabilitados();
                // Añadir una opción "Todos" al inicio
                listaClientes.Insert(0, new ClienteBO { ClienteId = 0, Nombre = "Todos los Clientes" });
                cboCliente.DataSource = listaClientes;
                cboCliente.DisplayMember = "Nombre";
                cboCliente.ValueMember = "ClienteId";
                cboCliente.SelectedIndex = 0; // Seleccionar "Todos" por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes para filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los tipos de evento en el ComboBox de filtro
        private void CargarTiposEventoEnComboBox()
        {
            // Puedes obtener estos tipos de una tabla de configuración, un enum, o definirlos aquí
            cboTipoEvento.Items.Add("Todos los Tipos");
            cboTipoEvento.Items.Add("Reunión");
            cboTipoEvento.Items.Add("Capacitación");
            cboTipoEvento.Items.Add("Visita Técnica");
            cboTipoEvento.Items.Add("Instalación");
            cboTipoEvento.Items.Add("Mantenimiento");
            cboTipoEvento.SelectedIndex = 0; // Seleccionar "Todos los Tipos" por defecto
        }

        // Método para cargar los eventos en el DataGridView con filtros
        private void CargarEventosEnDataGridView()
        {
            try
            {
                // Obtener todos los eventos (o solo habilitados, dependiendo de tu EventoBAL)
                // Para una consulta robusta, EventoBAL debería tener un método ObtenerEventos(int? clienteId, string tipoEvento, DateTime? fechaDesde, DateTime? fechaHasta, bool? esVisible)
                List<EventoBO> listaEventos = eventoBAL.ObtenerTodosEventos(); // Asumiendo este método existe en EventoBAL

                // Aplicar filtros en memoria
                int? filtroClienteId = (cboCliente.SelectedValue != null && (int)cboCliente.SelectedValue != 0) ? (int?)cboCliente.SelectedValue : null;
                string? filtroTipoEvento = (cboTipoEvento.SelectedItem != null && cboTipoEvento.SelectedItem.ToString() != "Todos los Tipos") ? cboTipoEvento.SelectedItem.ToString() : null;
                DateTime? fechaDesde = dtpInicio.Value.Date; // Solo la fecha, sin hora
                DateTime? fechaHasta = dtpFin.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del día

                var eventosFiltrados = listaEventos.AsQueryable();

                if (filtroClienteId.HasValue)
                {
                    eventosFiltrados = eventosFiltrados.Where(e => e.ClienteId == filtroClienteId.Value);
                }

                if (!string.IsNullOrEmpty(filtroTipoEvento))
                {
                    eventosFiltrados = eventosFiltrados.Where(e => e.Tipo.Equals(filtroTipoEvento, StringComparison.OrdinalIgnoreCase));
                }

                // Filtrar por rango de fechas
                eventosFiltrados = eventosFiltrados.Where(e => e.FechaInicio >= fechaDesde && e.FechaInicio <= fechaHasta);

                dgvEventos.DataSource = eventosFiltrados.ToList();

                dgvEventos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar eventos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de filtro
        private void LimpiarFiltros()
        {
            cboCliente.SelectedIndex = 0; // "Todos los Clientes"
            cboTipoEvento.SelectedIndex = 0; // "Todos los Tipos"
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            CargarEventosEnDataGridView(); // Recargar el DataGridView con los filtros limpios
        }

        // Evento Click del botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEventosEnDataGridView(); // Recargar el DataGridView con los filtros aplicados
        }

        // Evento Click del botón Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        // Evento Click del botón Volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Simplemente cierra el formulario
        }

        // Evento Click del botón Cerrar (puede ser lo mismo que Volver o con alguna confirmación)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }

        // Evento CellClick del DataGridView (útil si necesitas seleccionar un evento para otra operación)
        private void dgvEventos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvEventos.Rows[e.RowIndex];
                int eventoId = Convert.ToInt32(fila.Cells["EventoId"].Value);
                string tipoEvento = fila.Cells["Tipo"].Value.ToString();

                MessageBox.Show($"Evento seleccionado: ID {eventoId}, Tipo: {tipoEvento}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
