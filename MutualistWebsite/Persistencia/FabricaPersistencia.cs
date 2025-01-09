using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FabricaPersistencia
    {
       public static IPersistenciaEmpleado GetPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.GetInstancia());
        }

        public static IPersistenciaConsulta GetPersistenciaConsulta()
        {
            return (PersistenciaConsulta.GetInstancia());
        }

        public static IPersistenciaPaciente GetPersistenciaPaciente()
        {
            return (PersistenciaPaciente.GetInstancia());
        }

        public static IPersistenciaPoliclinica GetPersistenciaPoliclinica()
        {
            return (PersistenciaPoliclinica.GetInstancia());
        }

        public static IPersistenciaConsultorio GetPersistenciaConsultorio()
        {
            return (PersistenciaConsultorio.GetInstancia());
        }

        public static IPersistenciaSolicitud GetPersistenciaSolicitud()
        {
            return (PersistenciaSolicitud.GetInstancia());
        }

    }
}
