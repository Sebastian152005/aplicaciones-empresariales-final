using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;

namespace pe.com.gctelecom.bal
{
    public class ReclamoBAL
    {
        private ReclamoDAL ReclamoDAL = new ReclamoDAL();

        public List<ReclamoBO> ObtenerReclamosHabilitados()
        {
            return ReclamoDAL.ObtenerReclamos(true);
        }

        public List<ReclamoBO> ObtenerTodosReclamos()
        {
            return ReclamoDAL.ObtenerReclamos();
        }

        public bool CrearReclamo(ReclamoBO Reclamo)
        {
            return ReclamoDAL.CrearReclamo(Reclamo);
        }

        public bool ActualizarReclamo(ReclamoBO Reclamo)
        {
            return ReclamoDAL.ActualizarReclamo(Reclamo);
        }

        public bool BorrarReclamo(int ReclamoId)
        {
            return ReclamoDAL.ActivarDesactivarReclamo(ReclamoId, false);
        }

        public bool HabilitarReclamo(int ReclamoId)
        {
            return ReclamoDAL.ActivarDesactivarReclamo(ReclamoId, true);
        }

        public int ObtenerSiguienteReclamoId()
        {
            return ReclamoDAL.ObtenerSiguienteReclamoId();
        }
    }
}
