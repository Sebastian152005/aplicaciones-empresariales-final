using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;

namespace pe.com.gctelecom.bal
{
    public class VendedorBAL
    {
        private VendedorDAL VendedorDAL = new VendedorDAL();

        public List<VendedorBO> ObtenerVendedorsHabilitados()
        {
            return VendedorDAL.ObtenerVendedores(true);
        }

        public List<VendedorBO> ObtenerTodosVendedors()
        {
            return VendedorDAL.ObtenerVendedores();
        }

        public bool CrearVendedor(VendedorBO Vendedor)
        {
            return VendedorDAL.CrearVendedor(Vendedor);
        }

        public bool ActualizarVendedor(VendedorBO Vendedor)
        {
            return VendedorDAL.ActualizarVendedor(Vendedor);
        }

        public bool BorrarVendedor(int VendedorId)
        {
            return VendedorDAL.ActivarDesactivarVendedor(VendedorId, false);
        }

        public bool HabilitarVendedor(int VendedorId)
        {
            return VendedorDAL.ActivarDesactivarVendedor(VendedorId, true);
        }

        public int ObtenerSiguienteVendedorId()
        {
            return VendedorDAL.ObtenerSiguienteVendedorId();
        }
    }
}
