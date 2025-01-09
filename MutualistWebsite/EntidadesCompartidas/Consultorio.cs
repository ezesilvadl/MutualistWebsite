using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Consultorio
    {
        private int numConsultorio;
        private string descripcion;

        private Policlinica codigoID;

        public int NumConsultorio
        {
            get { return numConsultorio; }
            set {
                if (value < 0)
                    throw new Exception("El numero de consultorio no puede ser negativo.");
                else
                    numConsultorio = value;
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^[a-zA-Z]{1,100}$"))
                    descripcion = value;
                else
                    throw new Exception("Descripcion no valida");
            }
        }

        public Policlinica CodigoID
        {
            set {
                if (value == null)
                    throw new Exception("Debe tener codigoID");

                codigoID = value;
            }
            get { return codigoID; }
        }

        public Consultorio(int pNumConsultorio, string pDescripcion, Policlinica pCodigoID)
        {
            NumConsultorio = pNumConsultorio;
            Descripcion = pDescripcion;
            CodigoID = pCodigoID;
        }

        public override string ToString()
        {
            return ("Numero consultorio: " + numConsultorio + "Descripcion: " + descripcion);
        }
    }
}
