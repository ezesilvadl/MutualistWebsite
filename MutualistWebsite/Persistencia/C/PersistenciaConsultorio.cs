using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersistenciaConsultorio : IPersistenciaConsultorio
    {
        private static PersistenciaConsultorio _instancia;
        private PersistenciaConsultorio() { }
        public static PersistenciaConsultorio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaConsultorio();
            return _instancia;
        }

        public void AltaConsultorio(Consultorio unConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaConsultorio", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumConsultorio", unConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@Descripcion", unConsultorio.Descripcion);
            _comando.Parameters.AddWithValue("@CodigoID", unConsultorio.CodigoID.CodigoID);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _CodRetorno = Convert.ToInt32(_ParmRetorno.Value);

                if (_CodRetorno == -1)
                    throw new Exception("EXISTE EL CONSULTORIO");
                else if (_CodRetorno == -2)
                    throw new Exception("ERROR");
                else if (_CodRetorno == 0)
                    throw new Exception("Error no especificado");
                else if (_CodRetorno == -3)
                    throw new Exception("NO EXISTE LA POLICLINICA");


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

        public void Modificar(Consultorio unConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ModificarConsultorio", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumConsultorio", unConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@Descripcion", unConsultorio.Descripcion);
            _comando.Parameters.AddWithValue("@CodigoID", unConsultorio.CodigoID.CodigoID);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                int _error = (int)_ParmRetorno.Value;
                if (_error == -1)
                    throw new Exception("NO EXISTE EL CONSULTORIO");
                else if (_error == -2)
                    throw new Exception("ERROR AL MODIFICAR");

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

        public void Eliminar(Consultorio unConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BajaLogicaConsultorio", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoID", unConsultorio.CodigoID.CodigoID);
            _comando.Parameters.AddWithValue("@NumConsultorio", unConsultorio.NumConsultorio);
            
            SqlParameter _retorno = new SqlParameter("@retorno", SqlDbType.Int);

            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);


            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _errores = (int)_retorno.Value;
                if (_errores == -1)
                    throw new Exception("NO EXISTE EL CONSULTORIO");
                else if (_errores == -2)
                    throw new Exception("ERROR AL DAR DE BAJA");
                else if (_errores == -3)
                    throw new Exception("ERROR AL DAR DE BAJA");
                else if (_errores == 0)
                    throw new Exception("ERROR");

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

        internal EntidadesCompartidas.Consultorio BuscarConsultorio(int CodigoID, Policlinica unaP)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BuscarConsultorio", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumConsultorio", CodigoID);
            _comando.Parameters.AddWithValue("@CodigoID", unaP.CodigoID);

            EntidadesCompartidas.Consultorio _unConsultorio = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    
                        int _numConsultorio = (int)_lector["NumConsultorio"];
                        string _descripcion = (string)_lector["Descripcion"];
                        string _codigoID = (string)_lector["CodigoID"];

                        EntidadesCompartidas.Policlinica policlinica = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(_codigoID);
                        _unConsultorio = new EntidadesCompartidas.Consultorio(_numConsultorio, _descripcion, policlinica);
                    
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

            return _unConsultorio;
        }

        public EntidadesCompartidas.Consultorio BuscarConsultorioActivo(int CodigoID, Policlinica unaP)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BuscarConsultorioActivo", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumConsultorio", CodigoID);
            _comando.Parameters.AddWithValue("@CodigoID", unaP.CodigoID);

            EntidadesCompartidas.Consultorio _unConsultorio = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    
                        int _numConsultorio = (int)_lector["NumConsultorio"];
                        string _descripcion = (string)_lector["Descripcion"];
                        string _codigoID = (string)_lector["CodigoID"];

                        EntidadesCompartidas.Policlinica policlinica = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(_codigoID);
                        _unConsultorio = new EntidadesCompartidas.Consultorio(_numConsultorio, _descripcion, policlinica);
                    
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

            return _unConsultorio;
        }
    }
}
