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
using System.Globalization; // Necesario para CultureInfo

namespace pe.com.gctelecom.ui
{
    public partial class frmVenta : Form
    {
        // Instancias de las capas de lógica de negocio
        private ClienteBAL clienteBAL = new ClienteBAL();
        private VendedorBAL vendedorBAL = new VendedorBAL();
        private ProductoBAL productoBAL = new ProductoBAL();
        private VentaBAL ventaBAL = new VentaBAL(); // Instancia de VentaBAL para guardar la venta

        // Lista para mantener los productos agregados al detalle de la venta en el DataGridView
        private BindingList<DetalleVentaTempBO> listaDetalleVenta = new BindingList<DetalleVentaTempBO>();

        // Clase temporal para el detalle de venta en el UI
        public class DetalleVentaTempBO
        {
            public int ProductoId { get; set; }
            public string NombreProducto { get; set; }
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal { get; set; }
        }

        public frmVenta()
        {
            InitializeComponent();
            // Configurar el DataGridView del detalle de venta
            ConfigurarDataGridViewDetalle();
            // Cargar datos al iniciar el formulario
            CargarClientesEnComboBox();
            CargarVendedoresEnComboBox();
            CargarMonedasEnComboBox();
            CargarProductosEnComboBox();
            LimpiarCampos(); // Limpiar campos al inicio
        }

        // Configuración inicial del DataGridView del detalle de venta
        private void ConfigurarDataGridViewDetalle()
        {
            dgvDetalleVenta.AutoGenerateColumns = false; // Deshabilitar auto-generación para definir columnas manualmente

            // Definir columnas
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ProductoId", HeaderText = "ID Prod.", Visible = false });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "NombreProducto", HeaderText = "Producto", ReadOnly = true });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PrecioUnitario", HeaderText = "Precio Unit.", ReadOnly = true, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Cantidad", HeaderText = "Cantidad", ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Subtotal", HeaderText = "Subtotal", ReadOnly = true, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });

            // Añadir un botón para eliminar filas del detalle
            DataGridViewButtonColumn btnEliminarFila = new DataGridViewButtonColumn();
            btnEliminarFila.HeaderText = "Acción";
            btnEliminarFila.Text = "X";
            btnEliminarFila.UseColumnTextForButtonValue = true;
            btnEliminarFila.Name = "btnEliminarFila";
            dgvDetalleVenta.Columns.Add(btnEliminarFila);

            dgvDetalleVenta.DataSource = listaDetalleVenta; // Enlazar el BindingList al DataGridView
            dgvDetalleVenta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Método para cargar los clientes en el ComboBox
        private void CargarClientesEnComboBox()
        {
            try
            {
                List<ClienteBO> listaClientes = clienteBAL.ObtenerClientesHabilitados();
                cboCliente.DataSource = listaClientes; // Usando cboCliente
                cboCliente.DisplayMember = "Nombre";
                cboCliente.ValueMember = "ClienteId";
                cboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los vendedores en el ComboBox
        private void CargarVendedoresEnComboBox()
        {
            try
            {
                List<VendedorBO> listaVendedores = vendedorBAL.ObtenerVendedorsHabilitados();
                cboVendedor.DataSource = listaVendedores; // Usando cboVendedor
                cboVendedor.DisplayMember = "Nombre";
                cboVendedor.ValueMember = "VendedorId";
                cboVendedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las opciones de moneda en el ComboBox
        private void CargarMonedasEnComboBox()
        {
            cboMoneda.Items.Add("PEN"); // Soles Peruanos // Usando cboMoneda
            cboMoneda.Items.Add("USD"); // Dólares Americanos
            cboMoneda.SelectedIndex = 0; // Seleccionar PEN por defecto
        }

        // Método para cargar los productos en el ComboBox de "Agregar Producto"
        private void CargarProductosEnComboBox()
        {
            try
            {
                List<ProductoBO> listaProductos = productoBAL.ObtenerProductosHabilitados();
                cboProducto.DataSource = listaProductos; // Usando cboProducto
                cboProducto.DisplayMember = "Nombre";
                cboProducto.ValueMember = "ProductoId";
                cboProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos para agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar todos los campos del formulario y el detalle de venta
        private void LimpiarCampos()
        {
            cboCliente.SelectedIndex = -1; // Usando cboCliente
            cboVendedor.SelectedIndex = -1; // Usando cboVendedor
            dtpFecha.Value = DateTime.Now; // Usando dtpFecha
            cboMoneda.SelectedIndex = 0; // PEN por defecto // Usando cboMoneda

            cboProducto.SelectedIndex = -1; // Usando cboProducto
            nudCantidad.Value = 0;
            txtMontoTotal.Text = "0.00";

            listaDetalleVenta.Clear(); // Limpiar el detalle de venta
            ActualizarMontoTotal(); // Recalcular el monto total (será 0)

            btnGuardarVenta.Enabled = false; // Deshabilitar guardar hasta que haya productos
            cboCliente.Focus(); // Usando cboCliente
        }

        // Método para validar los campos de la cabecera de la venta
        private bool ValidarCabeceraVenta()
        {
            if (cboCliente.SelectedValue == null) // Usando cboCliente
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus(); // Usando cboCliente
                return false;
            }
            if (cboVendedor.SelectedValue == null) // Usando cboVendedor
            {
                MessageBox.Show("Debe seleccionar un vendedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVendedor.Focus(); // Usando cboVendedor
                return false;
            }
            if (cboMoneda.SelectedItem == null) // Usando cboMoneda
            {
                MessageBox.Show("Debe seleccionar una moneda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMoneda.Focus(); // Usando cboMoneda
                return false;
            }
            if (listaDetalleVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al detalle de la venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProducto.Focus(); // Usando cboProducto
                return false;
            }
            return true;
        }

        // Método para validar los campos al agregar un producto
        private bool ValidarAgregarProducto()
        {
            if (cboProducto.SelectedValue == null) // Usando cboProducto
            {
                MessageBox.Show("Debe seleccionar un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProducto.Focus(); // Usando cboProducto
                return false;
            }
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return false;
            }
            return true;
        }

        // Calcula y actualiza el monto total
        private void ActualizarMontoTotal()
        {
            decimal total = listaDetalleVenta.Sum(item => item.Subtotal);
            txtMontoTotal.Text = total.ToString("C2"); // Formato de moneda
            btnGuardarVenta.Enabled = listaDetalleVenta.Count > 0; // Habilitar/deshabilitar botón Guardar
        }

        // Evento Click del botón Agregar Producto
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarAgregarProducto())
            {
                return;
            }

            ProductoBO productoSeleccionado = (ProductoBO)cboProducto.SelectedItem; // Usando cboProducto
            int cantidad = Convert.ToInt32(nudCantidad.Value);

            // Verificar si el producto ya está en la lista para actualizar la cantidad
            DetalleVentaTempBO itemExistente = listaDetalleVenta.FirstOrDefault(item => item.ProductoId == productoSeleccionado.ProductoId);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
                itemExistente.Subtotal = itemExistente.Cantidad * itemExistente.PrecioUnitario;
            }
            else
            {
                DetalleVentaTempBO nuevoItem = new DetalleVentaTempBO
                {
                    ProductoId = productoSeleccionado.ProductoId,
                    NombreProducto = productoSeleccionado.Nombre,
                    PrecioUnitario = productoSeleccionado.Precio,
                    Cantidad = cantidad,
                    Subtotal = productoSeleccionado.Precio * cantidad
                };
                listaDetalleVenta.Add(nuevoItem);
            }

            // Refrescar el DataGridView (BindingList lo hace automáticamente, pero a veces es bueno forzar)
            dgvDetalleVenta.Refresh();
            ActualizarMontoTotal();

            // Limpiar campos de agregar producto
            cboProducto.SelectedIndex = -1; // Usando cboProducto
            nudCantidad.Value = 0;
            cboProducto.Focus(); // Usando cboProducto
        }

        // Evento Click del botón Guardar Venta
        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (!ValidarCabeceraVenta())
            {
                return;
            }

            // Limpiar el texto del monto total antes de convertirlo
            string montoTotalTextoLimpio = txtMontoTotal.Text.Replace("S/.", "").Replace("$", "").Replace("€", "").Trim();

            VentaBO nuevaVenta = new VentaBO
            {
                ClienteId = Convert.ToInt32(cboCliente.SelectedValue), // Usando cboCliente
                VendedorId = Convert.ToInt32(cboVendedor.SelectedValue), // Usando cboVendedor
                FechaVenta = dtpFecha.Value, // Usando dtpFecha
                Moneda = cboMoneda.SelectedItem.ToString(), // Usando cboMoneda
                // Convertir usando CultureInfo.CurrentCulture para manejar el formato de número local
                MontoTotal = decimal.Parse(montoTotalTextoLimpio, CultureInfo.CurrentCulture),
                EsVisible = true // O el estado que desees
            };

            List<DetalleVentaBO> detallesParaGuardar = new List<DetalleVentaBO>();
            foreach (var item in listaDetalleVenta)
            {
                detallesParaGuardar.Add(new DetalleVentaBO
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario, // Asegúrate que DetalleVentaBO tiene esta propiedad
                    Subtotal = item.Subtotal // Asegúrate que DetalleVentaBO tiene esta propiedad
                });
            }

            try
            {
                bool ventaGuardada = ventaBAL.CrearVenta(nuevaVenta, detallesParaGuardar); // Llamar a VentaBAL

                if (ventaGuardada)
                {
                    MessageBox.Show("Venta guardada exitosamente. ID de Venta: " + nuevaVenta.VentaId, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Este MessageBox mostrará el mensaje de error completo, incluyendo la pila de llamadas
                // Esto es CRÍTICO para diagnosticar el problema.
                MessageBox.Show("Ocurrió un error al intentar guardar la venta: \n\n" + ex.ToString(), "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click del botón Cancelar Venta
        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }

        // Evento CellContentClick para manejar el botón de eliminar fila en el DataGridView
        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que se hizo clic en el botón "X" de eliminar
            if (e.ColumnIndex == dgvDetalleVenta.Columns["btnEliminarFila"].Index && e.RowIndex >= 0)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este producto del detalle?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    listaDetalleVenta.RemoveAt(e.RowIndex);
                    ActualizarMontoTotal(); // Recalcular el total
                }
            }
        }
    }
}
