using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Consulta
    {
        private int codigoC;
        private DateTime fecha;
        private string medico;
        private string especialidad;
        private int cantNumConsulta;

        private Consultorio numConsultorio;

        public int CodigoC
        {
            get { return codigoC; }
            set
            {
                if (value < 0)
                    throw new Exception("No puede ser negativo");

                codigoC = value;
            }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set {
                fecha = value;
            }
        }

        public string Medico
        {
            get { return medico; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"^[a-zA-Z\s]{1,50}$"))
                    medico = value;
                else
                    throw new Exception("Medico no valido");
            }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"^[a-zA-Z\s]{1,50}$"))
                    especialidad = value; 
                else
                    throw new Exception("Especialidad no valida");
            }
        }

        public int CantNumConsulta
        {
            get { return cantNumConsulta; }
            set {
                if (cantNumConsulta < 0)
                    throw new Exception("La cantidad de numeros no puede ser negativa.");
                else
                    cantNumConsulta = value;
            }
        }


        public Consultorio NumConsultorio
        {
            set {
                if (value == null)
                    throw new Exception("Debe tener NumConsultorio");
                else
                    numConsultorio = value;
            }
            get { return numConsultorio; }
        }

        public Consulta(int pCodigoC, DateTime pFechaHora, string pMedico, string pEspecialidad, 
            int pCantNumerosDeLaConsulta, Consultorio pNumConsultorio)
        {
            Fecha = pFechaHora;
            Medico = pMedico;
            Especialidad = pEspecialidad;
            CantNumConsulta = pCantNumerosDeLaConsulta;
            NumConsultorio = pNumConsultorio;
            CodigoC = pCodigoC;
        }

        public override string ToString()
        {
            return ("Codigo Consulta" + codigoC + "Fecha: " + fecha + "Medico: " + medico + "Especialidad: " + especialidad + "Cantidad numeros consulta: " + cantNumConsulta
                 + "Numero consultorio: " + numConsultorio);
        }

    }
}
