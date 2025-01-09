using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.I
{
    public interface ILogicaSolicitud
    {
        void AltaSolicitud(EntidadesCompartidas.Solicitud unaSolicitud);
        List<EntidadesCompartidas.Solicitud> ListarTodasLasSolicitudes();
        List<EntidadesCompartidas.Solicitud> ListarSolicitudesConsulta(Consulta unaC);
        List<EntidadesCompartidas.Solicitud> ListarSinAsistirHoy();
        void MarcarAsistencia(EntidadesCompartidas.Solicitud unaSolicitud);
    }
}
