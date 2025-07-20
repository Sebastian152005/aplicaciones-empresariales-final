using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;

namespace pe.com.gctelecom.bal
{
    public class ClienteBAL
    {
        private ClienteDAL ClienteDAL = new ClienteDAL();

        public List<ClienteBO> ObtenerClientesHabilitados() {
            return ClienteDAL.ObtenerClientes(true);
        }

        public List<ClienteBO> ObtenerTodosClientes()
        {
            return ClienteDAL.ObtenerClientes();
        }

        public bool CrearCliente(ClienteBO Cliente)
        {
            return ClienteDAL.CrearCliente(Cliente);
        }

        public bool ActualizarCliente(ClienteBO Cliente)
        {
            return ClienteDAL.ActualizarCliente(Cliente);
        }

        public bool BorrarCliente(int ClienteId)
        {
            return ClienteDAL.ActivarDesactivarCliente(ClienteId, false);
        }

        public bool HabilitarCliente(int ClienteId)
        {
            return ClienteDAL.ActivarDesactivarCliente(ClienteId, true);
        }
 
        public int ObtenerSiguienteClienteId()
        {
            return ClienteDAL.ObtenerSiguienteClienteId();
        }
    }
}
