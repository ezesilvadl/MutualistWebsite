using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.I
{
    public interface ILogicaEmpleado
    {
        void AltaEmpleado(EntidadesCompartidas.Empleado unUsuario);
        EntidadesCompartidas.Empleado Logueo(string nombreUsuario, string contraseña);
    }
}
