using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaPaciente:IPersistenciaPaciente
    {
        private static PersistenciaPaciente _instancia;
        private PersistenciaPaciente() { }
        public static PersistenciaPaciente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPaciente();
            return _instancia;
        }

        public void AltaPaciente(EntidadesCompartidas.Paciente unPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            
            SqlCommand _comando = new SqlCommand("AltaPaciente", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Cedula", unPaciente.Cedula);
            _comando.Parameters.AddWithValue("@Nombre", unPaciente.Nombre);
            _comando.Parameters.AddWithValue("@FechaNac", unPaciente.FechaNac);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

                SqlTransaction _transaccion = null;

            try
            {
                _cnn.Open();

                _transaccion = _cnn.BeginTransaction();
                _comando.Transaction = _transaccion;

                _comando.ExecuteNonQuery();

                int _CodRetorno = Convert.ToInt32(_ParmRetorno.Value);

                if (_CodRetorno == -1)
                    throw new Exception("EL PACIENTE EXISTE");
              
                else if (_CodRetorno == -2)
                    throw new Exception("ERROR");
                
                else if (_CodRetorno == 0)
                    throw new Exception("Error");

                foreach (string patologias in unPaciente.Patologias)
                {
                    PersistenciaPatologias.GetInstancia().AltaPatologia(patologias, unPaciente, _transaccion);
                }


                _transaccion.Commit();
            }
            catch (Exception ex)
            {
                _transaccion?.Rollback();
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
            
        }


        public void Modificar(Paciente unPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ModificarPaciente", _cnn);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@Cedula", unPaciente.Cedula);
                _comando.Parameters.AddWithValue("@Nombre", unPaciente.Nombre);
                _comando.Parameters.AddWithValue("@FechaNac", unPaciente.FechaNac);
                SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
                _ParmRetorno.Direction = ParameterDirection.ReturnValue;
                _comando.Parameters.Add(_ParmRetorno);

                SqlTransaction _transaccion = null;

                try
                {
                    _cnn.Open();

                    _transaccion = _cnn.BeginTransaction();
                    _comando.Transaction = _transaccion;

                    _comando.ExecuteNonQuery();

                    int _error = Convert.ToInt32(_ParmRetorno.Value);

                    if (_error == -1)
                        throw new Exception("NO EXISTE EL PACIENTE");
                    
                    else if (_error == -2)
                        throw new Exception("ERROR AL MODIFICAR");
                    
                    else if (_error == 0)
                        throw new Exception("ERROR");

                foreach (string patologias in unPaciente.Patologias)
                {
                    PersistenciaPatologias.GetInstancia().AltaPatologia(patologias, unPaciente, _transaccion);
                }

                _transaccion.Commit();
                }
                catch (Exception ex)
                {
                    _transaccion?.Rollback();
                    throw ex;
                }
                finally
                {
                    _cnn.Close();
                }
            
        }


        public void Eliminar(Paciente unPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BajaLogicaPaciente", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Cedula", unPaciente.Cedula);
            SqlParameter _retorno = new SqlParameter("@retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _errores = (int)_retorno.Value;
                if (_errores == -1)
                {
                    throw new Exception("NO EXISTE EL PACIENTE");
                }
                else if (_errores == -2)
                {
                    throw new Exception("ERROR");
                }
                else if (_errores == 0)
                {
                    throw new Exception("ERROR");
                }

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


        internal EntidadesCompartidas.Paciente BuscarPaciente(int cedula)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            
                SqlCommand _comando = new SqlCommand("BuscarPaciente", _cnn);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@Cedula", cedula);

                EntidadesCompartidas.Paciente _unPaciente = null;

                SqlTransaction _transaccion = null;

                try
                {
                    _cnn.Open();

                    _transaccion = _cnn.BeginTransaction(IsolationLevel.ReadCommitted);
                    _comando.Transaction = _transaccion;

                    SqlDataReader _lector = _comando.ExecuteReader();

                    if (_lector.HasRows)
                    {
                        _lector.Read();

                        int _cedula = (int)_lector["Cedula"];
                        string _nombre = (string)_lector["Nombre"];
                        DateTime _fechaNac = (DateTime)_lector["FechaNac"];

                        _lector.Close();

                    List<string> _patologias = PersistenciaPatologias.GetInstancia().PatologiasDeUnPaciente(_cedula);
                     _unPaciente = new EntidadesCompartidas.Paciente(_cedula, _nombre, _fechaNac, _patologias);
                }
                else
                    {
                        _lector.Close();
                    }

                    _transaccion.Commit();
                }
                catch (Exception ex)
                {
                    _transaccion?.Rollback();
                    throw ex;
                }
                finally
                {
                    _cnn.Close();
                }

                return _unPaciente;
            
        }


        public EntidadesCompartidas.Paciente BuscarPacienteActivo(int cedula)
        {
            using (SqlConnection _cnn = new SqlConnection(Conexion.Cnn))
            {
                SqlCommand _comando = new SqlCommand("BuscarPacienteActivo", _cnn);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@Cedula", cedula);

                EntidadesCompartidas.Paciente _unPaciente = null;

                SqlTransaction _transaccion = null;

                try
                {
                    _cnn.Open();

                    _transaccion = _cnn.BeginTransaction(IsolationLevel.ReadCommitted);
                    _comando.Transaction = _transaccion;

                    SqlDataReader _lector = _comando.ExecuteReader();

                    if (_lector.HasRows)
                    {
                        _lector.Read();

                        int _cedula = (int)_lector["Cedula"];
                        string _nombre = (string)_lector["Nombre"];
                        DateTime _fechaNac = (DateTime)_lector["FechaNac"];

                        _lector.Close();

                        List<string> _patologias = PersistenciaPatologias.GetInstancia().PatologiasDeUnPaciente(_cedula);
                        _unPaciente = new EntidadesCompartidas.Paciente(_cedula, _nombre, _fechaNac, _patologias);
                    }
                    else
                    {
                        _lector.Close();
                    }

                    _transaccion.Commit();
                }
                catch (Exception ex)
                {
                    _transaccion?.Rollback();
                    throw ex;
                }
                finally
                {
                    _cnn.Close();
                }

                return _unPaciente;
            }
        }

    }
}
