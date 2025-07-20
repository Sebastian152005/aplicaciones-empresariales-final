using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;

namespace pe.com.gctelecom.bal
{
    public class EventoBAL
    {
        private EventoDAL EventoDAL = new EventoDAL();

        public List<EventoBO> ObtenerEventosHabilitados()
        {
            return EventoDAL.ObtenerEventos(true);
        }

        public List<EventoBO> ObtenerTodosEventos()
        {
            return EventoDAL.ObtenerEventos();
        }

        public bool CrearEvento(EventoBO Evento)
        {
            return EventoDAL.CrearEvento(Evento);
        }

        public bool ActualizarEvento(EventoBO Evento)
        {
            return EventoDAL.ActualizarEvento(Evento);
        }

        public bool BorrarEvento(int EventoId)
        {
            return EventoDAL.ActivarDesactivarEvento(EventoId, false);
        }

        public bool HabilitarEvento(int EventoId)
        {
            return EventoDAL.ActivarDesactivarEvento(EventoId, true);
        }

        public int ObtenerSiguienteEventoId()
        {
            return EventoDAL.ObtenerSiguienteEventoId();
        }
    }
}
