using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EntidadesCompartidas;
using System.Collections;

namespace Persistencia
{
    internal class PersistenciaConsulta : IPersistenciaConsulta
    {
        private static PersistenciaConsulta _instancia;
        private PersistenciaConsulta() { }
        public static PersistenciaConsulta GetInstancia()
        {
            if(_instancia == null)
                _instancia = new PersistenciaConsulta();
            return _instancia;
        }

        public void AltaConsulta(EntidadesCompartidas.Consulta unaConsulta)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaConsulta", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@Fecha", unaConsulta.Fecha);
            _comando.Parameters.AddWithValue("@Medico", unaConsulta.Medico);
            _comando.Parameters.AddWithValue("@Especialidad", unaConsulta.Especialidad);
            _comando.Parameters.AddWithValue("@CantNumConsulta", unaConsulta.CantNumConsulta);
            _comando.Parameters.AddWithValue("@NumConsultorio", unaConsulta.NumConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@CodigoID", unaConsulta.NumConsultorio.CodigoID.CodigoID);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                int _CodRetorno = Convert.ToInt32(_ParmRetorno.Value);

                if (_CodRetorno == -1)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                {
                    _cnn.Close();
                }
            }
        }


        public EntidadesCompartidas.Consulta BuscarConsulta(int NumConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BuscarConsulta", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoC", NumConsultorio);

            EntidadesCompartidas.Consulta _unaConsulta = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _codigoC = (int)_lector["CodigoC"];
                        DateTime _fechaHora = (DateTime)_lector["Fecha"];
                        string _medico = (string)_lector["Medico"];
                        string _especialidad = (string)_lector["Especialidad"];
                        int _cantNumerosDeLaConsulta = (int)_lector["CantNumConsulta"];
                        int _numConsultorio = (int)_lector["NumConsultorio"];
                        string codigoID = (string)_lector["CodigoID"];

                        EntidadesCompartidas.Policlinica policlinica = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(codigoID);
                        EntidadesCompartidas.Consultorio consultorio = PersistenciaConsultorio.GetInstancia().BuscarConsultorio(_numConsultorio, policlinica);
                        _unaConsulta = new EntidadesCompartidas.Consulta(_codigoC, _fechaHora, _medico, _especialidad, _cantNumerosDeLaConsulta, consultorio);
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

            return _unaConsulta;
        }

        public List<EntidadesCompartidas.Consulta> ListarTodasLasConsultas()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarTodasLasConsultas", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Consulta> _lista = new List<EntidadesCompartidas.Consulta>();
            EntidadesCompartidas.Consulta _unaConsulta = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _codigoC = (int)_lector["CodigoC"];
                        DateTime _fechaHora = (DateTime)_lector["Fecha"];
                        string _medico = (string)_lector["Medico"];
                        string _especialidad = (string)_lector["Especialidad"];
                        int _cantNumerosDeLaConsulta = (int)_lector["CantNumConsulta"];
                        int _numConsultorio = (int)_lector["NumConsultorio"];
                        string codigoID = (string)_lector["CodigoID"];

                        EntidadesCompartidas.Policlinica policlinica = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(codigoID);
                        EntidadesCompartidas.Consultorio consultorio = PersistenciaConsultorio.GetInstancia().BuscarConsultorio(_numConsultorio, policlinica);
                        _unaConsulta = new EntidadesCompartidas.Consulta(_codigoC, _fechaHora, _medico, _especialidad, _cantNumerosDeLaConsulta, consultorio);
                        _lista.Add(_unaConsulta);
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

            return _lista;
        }

        public List<EntidadesCompartidas.Consulta> ListarConsultasPendientes()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarConsultasPendientes", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Consulta> _lista = new List<EntidadesCompartidas.Consulta>();
            EntidadesCompartidas.Consulta _unaConsulta = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _codigoC = (int)_lector["CodigoC"];
                        DateTime _fechaHora = (DateTime)_lector["Fecha"];
                        string _medico = (string)_lector["Medico"];
                        string _especialidad = (string)_lector["Especialidad"];
                        int _cantNumerosDeLaConsulta = (int)_lector["CantNumConsulta"];
                        string codigoID = (string)_lector["CodigoID"];
                        int _numConsultorio = (int)_lector["NumConsultorio"];
                        

                        EntidadesCompartidas.Policlinica policlinica = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(codigoID);
                        EntidadesCompartidas.Consultorio consultorio = PersistenciaConsultorio.GetInstancia().BuscarConsultorio(_numConsultorio, policlinica);
                        _unaConsulta = new EntidadesCompartidas.Consulta(_codigoC, _fechaHora, _medico, _especialidad, _cantNumerosDeLaConsulta, consultorio);
                        _lista.Add(_unaConsulta);
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

            return _lista;
        }
    }
}
