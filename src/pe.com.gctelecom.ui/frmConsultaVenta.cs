using Microsoft.Data.SqlClient;
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
    public partial class frmConsultaVenta : Form
    {
        // Define tu cadena de conexión a SQL Server aquí.
        // IMPORTANTE: Reemplaza "YOUR_SERVER_NAME" con el nombre real de tu instancia de SQL Server.
        // Si usas autenticación de SQL Server, modifica para incluir User ID y Password.
        private string connectionString = "Data Source=localhost; Initial Catalog=gctelecomdb; Integrated Security=true; TrustServerCertificate=True;";

        public frmConsultaVenta()
        {
            InitializeComponent();
            // Asocia el evento Load del formulario al método frmConsultaVenta_Load
            this.Load += new EventHandler(frmConsultaVenta_Load);
        }

        // Evento que se dispara cuando el formulario se carga
        private void frmConsultaVenta_Load(object sender, EventArgs e)
        {
            CargarVentas(); // Llama al método para cargar todas las ventas al iniciar el formulario
        }

        // Método para cargar todas las ventas en el DataGridView dgvVentas
        private void CargarVentas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_OBTENER_VENTAS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Indica que es un procedimiento almacenado
                        connection.Open(); // Abre la conexión a la base de datos

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dtVentas = new DataTable();
                        adapter.Fill(dtVentas); // Llena el DataTable con los resultados del procedimiento

                        dgvVentas.DataSource = dtVentas; // Asigna el DataTable como origen de datos del DataGridView

                        // Opcional: Ajusta automáticamente el tamaño de las columnas para una mejor visualización
                        dgvVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si algo sale mal al cargar las ventas
                MessageBox.Show("Error al cargar las ventas: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se dispara cuando se hace clic en una celda del DataGridView dgvVentas
        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se hizo clic en una fila válida (no en la fila de encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvVentas.Rows[e.RowIndex];

                // Obtén el venta_id de la fila seleccionada
                // Asegúrate de que la columna 'venta_id' exista y contenga valores enteros
                if (selectedRow.Cells["venta_id"].Value != null)
                {
                    int ventaId = Convert.ToInt32(selectedRow.Cells["venta_id"].Value);
                    CargarDetalleVenta(ventaId); // Llama al método para cargar los detalles de la venta seleccionada
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID de la venta seleccionada.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Método para cargar los detalles de una venta específica en el DataGridView dgvDetalleVentaConsulta
        private void CargarDetalleVenta(int ventaId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_OBTENER_DETALLES_VENTA_POR_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Indica que es un procedimiento almacenado
                        command.Parameters.AddWithValue("@venta_id", ventaId); // Pasa el ID de la venta como parámetro
                        connection.Open(); // Abre la conexión a la base de datos

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dtDetalleVenta = new DataTable();
                        adapter.Fill(dtDetalleVenta); // Llena el DataTable con los resultados

                        dgvDetalleVentaConsulta.DataSource = dtDetalleVenta; // Asigna el DataTable como origen de datos

                        // Opcional: Ajusta automáticamente el tamaño de las columnas
                        dgvDetalleVentaConsulta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si algo sale mal al cargar los detalles de la venta
                MessageBox.Show("Error al cargar el detalle de la venta: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este evento dgvDetalleVentaConsulta_CellClick no es necesario para la funcionalidad actual,
        // pero se mantiene aquí como estaba en tu fragmento original.
        private void dgvDetalleVentaConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // No se necesita ninguna acción específica aquí por ahora.
        }
    }
}
