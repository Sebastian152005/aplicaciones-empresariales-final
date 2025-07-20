
namespace pe.com.gctelecom.bo
{
    public class EventoBO
    {
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public int VendedorId { get; set; }
        public string NombreVendedor { get; set; } 
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int Duracion { get; set; } 
        public bool EsVisible { get; set; } 
    }
}
