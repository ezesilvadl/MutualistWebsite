using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Paciente
    {
        private int cedula;
        private string nombre;
        private DateTime fechaNac;

        List<string> patologias;

        public int Cedula
        {
            get { return cedula; }
            set {
                if (value < 10000000 || value > 99999999)
                    throw new Exception("La cedula debe contener exactamente 8 numeros");

                cedula = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^[a-zA-Z]{1,50}$"))
                    nombre = value;
                else
                    throw new Exception("Nombre no valido");
            }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set {
                if (fechaNac > DateTime.Now)
                    throw new Exception("La fecha es incorrecta");

                fechaNac = value;
            }
        }

        public List<string> Patologias
        {
            get { return patologias; }
            set
            {
                if (value == null)
                    throw new Exception("No puede ser nula");
                patologias = value;
            }
        }

        public Paciente(int pCedula, string pNombre, DateTime pFechaNac, List<string> pPatologias) 
        {
            Cedula = pCedula;
            Nombre = pNombre;
            FechaNac = pFechaNac;
            Patologias = pPatologias;   
        }

        public override string ToString()
        {
            return ("Cedula: " + cedula + "Nombre: " + nombre + "Fecha nacimiento: " + fechaNac +"Patologias: " + patologias);
        }
    }
}
