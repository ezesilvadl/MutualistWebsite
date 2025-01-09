using EntidadesCompartidas;
using Logica.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaSolicitud:ILogicaSolicitud
    {
        private static LogicaSolicitud _instancia = null;
        private LogicaSolicitud() { }
        public static LogicaSolicitud GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaSolicitud();
            return _instancia;
        }

        public void AltaSolicitud(EntidadesCompartidas.Solicitud unaSolicitud)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().AltaSolicitud(unaSolicitud);
        }

        public List<EntidadesCompartidas.Solicitud> ListarTodasLasSolicitudes()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().ListarTodasLasSolicitudes();
        }

        public List<EntidadesCompartidas.Solicitud> ListarSolicitudesConsulta(Consulta unaC)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().ListarSolicitudesConsulta(unaC);
        }

        public List<EntidadesCompartidas.Solicitud> ListarSinAsistirHoy()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().ListarSinAsistirHoy();
        }

        public void MarcarAsistencia(EntidadesCompartidas.Solicitud unaSolicitud)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().MarcarAsistencia(unaSolicitud);
        }
    }
}
