using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersistenciaPoliclinica:IPersistenciaPoliclinica
    {
        private static PersistenciaPoliclinica _instancia;
        private PersistenciaPoliclinica() { }
        public static PersistenciaPoliclinica GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPoliclinica();

            return _instancia;
        }

        public void AltaPoliclinica(EntidadesCompartidas.Policlinica unaPoliclinica)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaPoliclinica", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoID", unaPoliclinica.CodigoID);
            _comando.Parameters.AddWithValue("@Nombre", unaPoliclinica.Nombre);
            _comando.Parameters.AddWithValue("@Direccion", unaPoliclinica.Direccion);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                int _CodRetorno = Convert.ToInt32(_ParmRetorno.Value);

                if (_CodRetorno == -1)
                    throw new Exception("EXISTE LA POLICLINCIA");
                else if (_CodRetorno == -2)
                    throw new Exception("NO SE DIO DE ALTA");



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }

        public EntidadesCompartidas.Policlinica BuscarPoliclinica(string CodigoID)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BuscarPoliclinica", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoID", CodigoID);

            EntidadesCompartidas.Policlinica _unaPoliclinica = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {

                        string _codigoID = (string)_lector["CodigoID"];
                        string _nombre = (string)_lector["Nombre"];
                        string _direccion = (string)_lector["Direccion"];
                        _unaPoliclinica = new EntidadesCompartidas.Policlinica(_codigoID, _nombre, _direccion);
                    }
                }

                _lector.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            
            return _unaPoliclinica;
        }
    }
}
