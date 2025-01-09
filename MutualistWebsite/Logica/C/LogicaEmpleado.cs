using EntidadesCompartidas;
using Logica.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaEmpleado:ILogicaEmpleado
    {
        private static LogicaEmpleado _instancia = null;
        private LogicaEmpleado() { }
        public static LogicaEmpleado GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaEmpleado();
            return _instancia;
        }

        public void AltaEmpleado(EntidadesCompartidas.Empleado unUsuario)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaEmpleado().AltaEmpleado(unUsuario);
        }

        public EntidadesCompartidas.Empleado Logueo(string nombreUsuario, string contraseña)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaEmpleado().Logueo(nombreUsuario, contraseña);
        }
    }
}
