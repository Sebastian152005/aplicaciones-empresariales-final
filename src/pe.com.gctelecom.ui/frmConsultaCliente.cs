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
    public partial class frmConsultaCliente : Form
    {
        // Instancia de la capa de lógica de negocio para clientes
        private ClienteBAL clienteBAL = new ClienteBAL();

        public frmConsultaCliente()
        {
            InitializeComponent();
            // Cargar todos los clientes al iniciar el formulario (o solo los habilitados por defecto)
            CargarClientesEnDataGridView();
        }

        // Método para cargar los clientes en el DataGridView con filtros
        private void CargarClientesEnDataGridView()
        {
            try
            {
                // Obtener todos los clientes (habilitados o no) para aplicar filtros en memoria
                // Opcionalmente, podrías crear un método en ClienteBAL.ObtenerClientes(string nombre, string correo, bool? esVisible)
                List<ClienteBO> listaClientes = clienteBAL.ObtenerTodosClientes(); // Asumiendo este método existe en ClienteBAL

                // Aplicar filtros en memoria
                string filtroNombre = txtNombreFiltro.Text.Trim().ToLower();
                string filtroCorreo = txtFiltroCorreo.Text.Trim().ToLower();
                bool soloHabilitados = chkSoloHabilitados.Checked;

                var clientesFiltrados = listaClientes.AsQueryable();

                if (!string.IsNullOrEmpty(filtroNombre))
                {
                    clientesFiltrados = clientesFiltrados.Where(c => c.Nombre.ToLower().Contains(filtroNombre));
                }

                if (!string.IsNullOrEmpty(filtroCorreo))
                {
                    clientesFiltrados = clientesFiltrados.Where(c => c.Correo.ToLower().Contains(filtroCorreo));
                }

                if (soloHabilitados)
                {
                    clientesFiltrados = clientesFiltrados.Where(c => c.EsVisible);
                }

                dgvConsultaClientes.DataSource = clientesFiltrados.ToList();

                // Renombrar columnas para una mejor lectura en la UI
                dgvConsultaClientes.Columns["ClienteId"].HeaderText = "ID Cliente";
                dgvConsultaClientes.Columns["FuenteId"].HeaderText = "ID Fuente"; // Opcional, si lo ocultas
                dgvConsultaClientes.Columns["Nombre"].HeaderText = "Nombre";
                dgvConsultaClientes.Columns["Correo"].HeaderText = "Correo Electrónico";
                dgvConsultaClientes.Columns["Celular"].HeaderText = "Celular";
                dgvConsultaClientes.Columns["Direccion"].HeaderText = "Dirección";
                dgvConsultaClientes.Columns["EsVisible"].HeaderText = "Habilitado"; // Mostrar el estado de habilitado

                // Ocultar columnas que no son relevantes para la visualización directa si lo deseas
                // dgvConsultaClientes.Columns["FuenteId"].Visible = false;

                // Ajustar el tamaño de las columnas
                dgvConsultaClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click del botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientesEnDataGridView(); // Recargar el DataGridView con los filtros aplicados
        }

      
        private void dgvConsultaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvConsultaClientes.Rows[e.RowIndex];
                int clienteId = Convert.ToInt32(fila.Cells["ClienteId"].Value);
                string nombreCliente = fila.Cells["Nombre"].Value.ToString();

                MessageBox.Show($"Cliente seleccionado: ID {clienteId}, Nombre: {nombreCliente}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            }
        }

        // Opcional: Evento TextChanged para buscar en tiempo real
        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            CargarClientesEnDataGridView(); 
        }

        private void txtFiltroCorreo_TextChanged(object sender, EventArgs e)
        {
            // CargarClientesEnDataGridView(); // Descomentar para búsqueda en tiempo real
        }

        private void chkSoloHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            CargarClientesEnDataGridView(); // Recargar al cambiar el estado del checkbox
        }
    }
}
