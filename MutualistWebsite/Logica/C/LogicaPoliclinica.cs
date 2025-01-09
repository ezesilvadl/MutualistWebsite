using Logica.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaPoliclinica:ILogicaPoliclinica
    {
        private static LogicaPoliclinica _instancia = null;
        private LogicaPoliclinica() { }
        public static LogicaPoliclinica GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPoliclinica();
            return _instancia;
        }

        public void AltaPoliclinica(EntidadesCompartidas.Policlinica unaPoliclinica)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPoliclinica().AltaPoliclinica(unaPoliclinica);
        }

        public EntidadesCompartidas.Policlinica BuscarPoliclinica(string CodigoID)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaPoliclinica().BuscarPoliclinica(CodigoID);
        }
    }
}
