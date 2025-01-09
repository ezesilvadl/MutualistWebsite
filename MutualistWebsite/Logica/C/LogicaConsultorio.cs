using EntidadesCompartidas;
using Logica.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaConsultorio:ILogicaConsultorio
    {
        private static LogicaConsultorio _instancia = null;
        private LogicaConsultorio() { }
        public static LogicaConsultorio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaConsultorio();
            return _instancia;
        }

        public void AltaConsultorio(Consultorio unConsultorio)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().AltaConsultorio(unConsultorio);
        }

        public void Modificar(Consultorio unConsultorio)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().Modificar(unConsultorio); 
        }

        public void Eliminar(Consultorio unConsultorio)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().Eliminar(unConsultorio);
        }

        public EntidadesCompartidas.Consultorio BuscarConsultorioActivo(int CodigoID, Policlinica unaP)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().BuscarConsultorioActivo(CodigoID, unaP);
        }
    }
}
