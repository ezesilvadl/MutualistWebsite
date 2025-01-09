using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Solicitud
    {
        private int numeroInterno;
        private int numSeleccionado;
        private bool asistioONo;

        private Consulta codigoC;
        private Paciente cedula;
        private Empleado nomUsuario;
        public bool AsistioONo
        {
            get { return asistioONo; }
            set
            {
                asistioONo = value;
            }
        }
        public int NumeroInterno
        {
            get { return numeroInterno; }
            set
            {
                numeroInterno = value;
            }
        }

        public int NumSeleccionado
        {
            get { return numSeleccionado; }
            set {
                if (value <= 0)
                    throw new Exception("Numero seleccionado no valido");
                numSeleccionado = value;
            }
        }

        public Consulta CodigoC
        {
            get { return codigoC; }
            set {
                if (value == null)
                    throw new Exception("Debe tener codigo");

                codigoC = value;
            }
        }

        public Paciente Cedula
        {
            get { return cedula; }
            set {
                if (value == null)
                    throw new Exception("Debe tener cedula");

                cedula = value;
            }
        }

        public Empleado NomUsuario
        {
            get { return nomUsuario; }
            set {
                if (value == null)
                    throw new Exception("Debe tener nombre de usuario");

                nomUsuario = value;
            }
        }

        public Solicitud(int pNumeroInterno, int pNumSeleccionado, bool pAsistioONo,  Consulta pCodigoC, 
            Paciente pCedula, Empleado pNomUsuario)
        {
            NumeroInterno = pNumeroInterno;
            NumSeleccionado = pNumSeleccionado;
            CodigoC = pCodigoC;
            Cedula = pCedula;
            NomUsuario = pNomUsuario;
            AsistioONo = pAsistioONo;
        }

        public override string ToString()
        {
            return ("Numero interno: " + numeroInterno + "Numero seleccionado: " + numSeleccionado + "Asistio o no: " + asistioONo + "CodigoC: " + codigoC
                + "Cedula: " + cedula + "Nombre usuario: " + nomUsuario);
        }
    }
}
