using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;

namespace pe.com.gctelecom.bal
{
    public class FuenteBAL
    {
        private FuenteDAL FuenteDAL = new FuenteDAL();

        public List<FuenteBO> ObtenerFuentesHabilitados()
        {
            return FuenteDAL.ObtenerFuentes(true);
        }

        public List<FuenteBO> ObtenerTodosFuentes()
        {
            return FuenteDAL.ObtenerFuentes();
        }

        public bool CrearFuente(FuenteBO Fuente)
        {
            return FuenteDAL.CrearFuente(Fuente);
        }

        public bool ActualizarFuente(FuenteBO Fuente)
        {
            return FuenteDAL.ActualizarFuente(Fuente);
        }

        public bool BorrarFuente(int FuenteId)
        {
            return FuenteDAL.ActivarDesactivarFuente(FuenteId, false);
        }

        public bool HabilitarFuente(int FuenteId)
        {
            return FuenteDAL.ActivarDesactivarFuente(FuenteId, true);
        }

        public int ObtenerSiguienteFuenteId()
        {
            return FuenteDAL.ObtenerSiguienteFuenteId();
        }
    }
}
