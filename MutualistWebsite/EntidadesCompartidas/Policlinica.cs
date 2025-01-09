using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Policlinica
    {
        private string codigoID;
        private string nombre;
        private string direccion;

        public string CodigoID
        { 
            get { return codigoID; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^[a-zA-Z]{6}$"))
                    codigoID = value;
                else
                    throw new Exception("CodigoID no valido");
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^[a-zA-Z ]{1,50}$"))
                    nombre = value;
                else
                    throw new Exception("Nombre no valido");
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"^[a-zA-Z0-9\s,.'-]{1,100}$"))
                    direccion = value;
                else
                    throw new Exception("Direccion no valida");
            }
        }

        public Policlinica(string pCodigoID, string pNombre, string pDireccion) 
        {
            CodigoID = pCodigoID;
            Nombre = pNombre;
            Direccion = pDireccion;
        }

        public override string ToString()
        {
            return ("CodigoID: " + codigoID + "Nombre: " + nombre + "Direccion: " + direccion);
        }
    }
}
