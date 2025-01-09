using Logica.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaConsulta:ILogicaConsulta
    {
        private static LogicaConsulta _instancia = null;
        private LogicaConsulta() { }
        public static LogicaConsulta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaConsulta();
            return _instancia;
        }

        public void AltaConsulta(EntidadesCompartidas.Consulta unaConsulta)
        {
            if(unaConsulta.Fecha < DateTime.Today)
            {
                throw new Exception("La fecha de la consulta no puede ser en el pasado");
            }
            
            Persistencia.FabricaPersistencia.GetPersistenciaConsulta().AltaConsulta(unaConsulta);
        }

        public EntidadesCompartidas.Consulta BuscarConsulta(int NumConsultorio)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaConsulta().BuscarConsulta(NumConsultorio);
        }

        public List<EntidadesCompartidas.Consulta> ListarTodasLasConsultas()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaConsulta().ListarTodasLasConsultas();
        }

        public List<EntidadesCompartidas.Consulta> ListarConsultasPendientes()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaConsulta().ListarConsultasPendientes();
        }
    }
}
