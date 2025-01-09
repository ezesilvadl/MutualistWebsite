using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.I
{
    public interface ILogicaPoliclinica
    {
        void AltaPoliclinica(EntidadesCompartidas.Policlinica unaPoliclinica);
        EntidadesCompartidas.Policlinica BuscarPoliclinica(string CodigoID);
    }
}
