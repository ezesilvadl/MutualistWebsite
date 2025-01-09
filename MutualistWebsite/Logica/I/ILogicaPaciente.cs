using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.I
{
    public interface ILogicaPaciente
    {
        void AltaPaciente(EntidadesCompartidas.Paciente unPaciente);
        void Modificar(Paciente unPaciente);
        void Eliminar(Paciente unPaciente);
        EntidadesCompartidas.Paciente BuscarPacienteActivo(int cedula);
    }
}
