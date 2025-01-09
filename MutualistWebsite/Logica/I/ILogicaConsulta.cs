using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.I
{
    public interface ILogicaConsulta
    {
        void AltaConsulta(EntidadesCompartidas.Consulta unaConsulta);
        EntidadesCompartidas.Consulta BuscarConsulta(int NumConsultorio);
        List<EntidadesCompartidas.Consulta> ListarTodasLasConsultas();
        List<EntidadesCompartidas.Consulta> ListarConsultasPendientes();
    }
}
