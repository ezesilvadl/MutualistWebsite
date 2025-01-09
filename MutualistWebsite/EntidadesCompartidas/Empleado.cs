using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Empleado
    {
        private string nomUsuario;
        private string passUsuario;

        public string NomUsuario
        {
            get { return nomUsuario; }
            set {
                if (value.Length != 8)
                    throw new Exception("Debe tener 8 caracteres");

                nomUsuario = value;
            }
        }

        public string PassUsuario
        {   
            get { return passUsuario; } 
            set {
                if (value != null && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^(?=.*[a-zA-Z].*[a-zA-Z].*[a-zA-Z])(?=.*[0-9].*[0-9].*[0-9])[a-zA-Z0-9]{6}$"))
                   passUsuario = value;
                else
                 throw new Exception("Contraseña no valida");
            }
        }

        public Empleado(string pNomUsuario, string pPassUsuario) 
        {
            NomUsuario = pNomUsuario;
            PassUsuario = pPassUsuario;
        }

        public override string ToString()
        {
            return ("Nombre usuario: " + nomUsuario);
        }
    }
}
