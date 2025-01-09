using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        void AltaEmpleado(EntidadesCompartidas.Empleado unUsuario);
        Empleado Logueo(string nombreUsuario, string contraseña);
    }
}
