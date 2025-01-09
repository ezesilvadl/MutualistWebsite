using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface IPersistenciaConsultorio
    {
        void AltaConsultorio(Consultorio unConsultorio);
        void Modificar(Consultorio unConsultorio);
        void Eliminar(Consultorio unConsultorio);
        EntidadesCompartidas.Consultorio BuscarConsultorioActivo(int CodigoID, Policlinica unaP);
    }
}
