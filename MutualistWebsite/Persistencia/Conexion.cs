using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        private static string MiConexion = "Data Source = EZESILVADL\\SQLEXPRESS; Initial Catalog = MutualistWebsite; Integrated Security = True; Encrypt=False";

        public static string Cnn
        {
            get { return MiConexion; }
        }
    }
}

