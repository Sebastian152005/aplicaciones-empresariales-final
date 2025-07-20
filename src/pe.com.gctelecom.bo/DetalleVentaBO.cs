namespace pe.com.gctelecom.bo
{
    public class DetalleVentaBO
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; } // Clave foránea a Venta
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; } // Cantidad * PrecioUnitario
    }
}
