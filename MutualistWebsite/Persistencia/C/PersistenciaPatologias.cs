using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaPatologias
    {
        private static PersistenciaPatologias _instancia;
        private PersistenciaPatologias() { }
        public static PersistenciaPatologias GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPatologias();
            return _instancia;
        }
        internal void AltaPatologia(string unaPatologia, EntidadesCompartidas.Paciente unPaciente, SqlTransaction _pTransaccion)
        {
            SqlCommand _comando = new SqlCommand("AltaPatologia", _pTransaccion.Connection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Cedula", unPaciente.Cedula);
            _comando.Parameters.AddWithValue("@Patologias", unaPatologia);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _comando.Transaction = _pTransaccion;
                _comando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(_ParmRetorno.Value);
                if (retorno == -1)
                    throw new Exception("NO EXISTE EL PACIENTE O TIENE BAJA LOGICA");
                else if (retorno == -2)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void EliminarPatologiasDePaciente(int cedula, SqlTransaction _pTransaccion)
        {
            {
                SqlCommand _comando = new SqlCommand("EliminarPatologiasDePaciente", _pTransaccion.Connection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@Cedula", cedula);
                SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
                _ParmRetorno.Direction = ParameterDirection.ReturnValue;
                _comando.Parameters.Add(_ParmRetorno);

                try
                {
                    _comando.Transaction = _pTransaccion;
                    _comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        internal List<string> PatologiasDeUnPaciente(int cedula)
        {
            List<string> _listaPatologias = new List<string>();

            using (SqlConnection _cnn = new SqlConnection(Conexion.Cnn))
            {
                using (SqlCommand _comando = new SqlCommand("PatologiasDeUnPaciente", _cnn))
                {
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@Cedula", cedula);

                    try
                    {
                        _cnn.Open();

                        using (SqlDataReader _lector = _comando.ExecuteReader())
                        {
                            if (_lector.HasRows)
                            {
                                while (_lector.Read())
                                {
                                    _listaPatologias.Add((string)_lector["Patologias"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return _listaPatologias;
        }


    }
}
