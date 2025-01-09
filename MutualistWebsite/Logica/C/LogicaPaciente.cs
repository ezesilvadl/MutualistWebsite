using EntidadesCompartidas;
using Logica.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaPaciente:ILogicaPaciente
    {
        private static LogicaPaciente _instancia = null;
        private LogicaPaciente() { }
        public static LogicaPaciente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPaciente();
            return _instancia;
        }

        public void AltaPaciente(EntidadesCompartidas.Paciente unPaciente)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPaciente().AltaPaciente(unPaciente);
        }

        public void Modificar(Paciente unPaciente)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPaciente().Modificar(unPaciente);
        }

        public void Eliminar(Paciente unPaciente)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPaciente().Eliminar(unPaciente);
        }

        public EntidadesCompartidas.Paciente BuscarPacienteActivo(int cedula)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaPaciente().BuscarPacienteActivo(cedula);
        }
    }
}
