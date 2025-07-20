using System;

namespace pe.com.gctelecom.bo
{
    public class VentaBO
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Moneda { get; set; }
        public decimal MontoTotal { get; set; }
        public bool EsVisible { get; set; } // Para borrado lógico
    }
}
