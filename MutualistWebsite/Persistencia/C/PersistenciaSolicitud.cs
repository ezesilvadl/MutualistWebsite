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
    internal class PersistenciaSolicitud:IPersistenciaSolicitud
    {
        private static PersistenciaSolicitud _instancia;
        private PersistenciaSolicitud() { }
        public static PersistenciaSolicitud GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaSolicitud();
            return _instancia;
        }
        public void AltaSolicitud(EntidadesCompartidas.Solicitud unaSolicitud)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaSolicitud", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumSeleccionado", unaSolicitud.NumSeleccionado);
            _comando.Parameters.AddWithValue("@CodigoC", unaSolicitud.CodigoC.CodigoC);
            _comando.Parameters.AddWithValue("@Cedula", unaSolicitud.Cedula.Cedula);
            _comando.Parameters.AddWithValue("@NomUsuario", unaSolicitud.NomUsuario.NomUsuario);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);


            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _CodRetorno = Convert.ToInt32(_ParmRetorno.Value);

                if (_CodRetorno == -2)
                    throw new Exception("NO EXISTE LA CONSULTA");
                else if (_CodRetorno == -3)
                    throw new Exception("NO EXISTE EL PACIENTE");
                else if(_CodRetorno == -4)
                    throw new Exception("NO EXISTE EL EMPLEADO");
                else if(_CodRetorno == -6)
                    throw new Exception("ESE NUMERO SELECCIONADO PARA ESA CONSULTA YA NO ESTÁ");
                else if(_CodRetorno == -7)
                    throw new Exception("ESE PACIENTE PARA ESA CONSULTA YA TIENE UN NUMERO");
                else if (_CodRetorno == -5)
                    throw new Exception("NO SE DIO DE ALTA");
                else if (_CodRetorno == 0)
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

        public List<EntidadesCompartidas.Solicitud> ListarTodasLasSolicitudes()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarTodasSolicitudes", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Solicitud> _lista = new List<EntidadesCompartidas.Solicitud>();
            EntidadesCompartidas.Solicitud _unaSolicitud = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while(_lector.Read())
                    {
                        int _numeroInterno = (int)_lector["NumeroInterno"];
                        DateTime _fechaHora = (DateTime)_lector["FechaHora"];
                        int _numSeleccionado = (int)_lector["NumSeleccionado"];
                        bool _asistioONo = (bool)_lector["AsistioONo"];
                        int _codigoC = (int)_lector["CodigoC"];
                        int _cedula = (int)_lector["Cedula"];
                        string _nomUsuario = (string)_lector["NomUsuario"];

                        EntidadesCompartidas.Consulta consulta = PersistenciaConsulta.GetInstancia().BuscarConsulta(_codigoC);
                        EntidadesCompartidas.Paciente cedula = PersistenciaPaciente.GetInstancia().BuscarPaciente(_cedula);
                        EntidadesCompartidas.Empleado nombreUsuario = PersistenciaEmpleado.GetInstancia().BuscarEmpleado(_nomUsuario);
                        _unaSolicitud = new EntidadesCompartidas.Solicitud(_numeroInterno, _numSeleccionado, _asistioONo, consulta, cedula, nombreUsuario);
                        _lista.Add(_unaSolicitud);
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

        public List<EntidadesCompartidas.Solicitud> ListarSolicitudesConsulta(Consulta unaC)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarSolicitudesConsulta", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoC", unaC.CodigoC);

            List<EntidadesCompartidas.Solicitud> _lista = new List<EntidadesCompartidas.Solicitud>();
            EntidadesCompartidas.Solicitud _unaSolicitud;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _numeroInterno = (int)_lector["NumeroInterno"];
                        DateTime _fechaHora = (DateTime)_lector["FechaHora"];
                        int _numSeleccionado = (int)_lector["NumSeleccionado"];
                        bool _asistioONo = (bool)_lector["AsistioONo"];
                        int _codigoC = (int)_lector["CodigoC"];
                        int _cedula = (int)_lector["Cedula"];
                        string _nomUsuario = (string)_lector["NomUsuario"];

                        EntidadesCompartidas.Consulta consulta = PersistenciaConsulta.GetInstancia().BuscarConsulta(_codigoC);
                        EntidadesCompartidas.Paciente cedula = PersistenciaPaciente.GetInstancia().BuscarPaciente(_cedula);
                        EntidadesCompartidas.Empleado nombreUsuario = PersistenciaEmpleado.GetInstancia().BuscarEmpleado(_nomUsuario);
                        _unaSolicitud = new EntidadesCompartidas.Solicitud(_numeroInterno, _numSeleccionado, _asistioONo, consulta, cedula, nombreUsuario);
                        _lista.Add(_unaSolicitud);
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

        public List<EntidadesCompartidas.Solicitud> ListarSinAsistirHoy()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarConsultasSinAsistirHoy", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Solicitud> _lista = new List<EntidadesCompartidas.Solicitud>();
            EntidadesCompartidas.Solicitud _unaSolicitud = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _numeroInterno = (int)_lector["NumeroInterno"];
                        int _numSeleccionado = (int)_lector["NumSeleccionado"];
                        bool _asistioONo = (bool)_lector["AsistioONo"];
                        int _codigoC = (int)_lector["CodigoC"];
                        int _cedula = (int)_lector["Cedula"];
                        string _nomUsuario = (string)_lector["NomUsuario"];

                        EntidadesCompartidas.Consulta consulta = PersistenciaConsulta.GetInstancia().BuscarConsulta(_codigoC);
                        EntidadesCompartidas.Paciente cedula = PersistenciaPaciente.GetInstancia().BuscarPaciente(_cedula);
                        EntidadesCompartidas.Empleado nombreUsuario = PersistenciaEmpleado.GetInstancia().BuscarEmpleado(_nomUsuario);
                        _unaSolicitud = new EntidadesCompartidas.Solicitud(_numeroInterno, _numSeleccionado, _asistioONo, consulta, cedula, nombreUsuario);
                        _lista.Add(_unaSolicitud);
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

        public void MarcarAsistencia(EntidadesCompartidas.Solicitud unaSolicitud)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("MarcarAsistencia", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumeroInterno", unaSolicitud.NumeroInterno);
            SqlParameter _parmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _parmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_parmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                int _codRetorno = Convert.ToInt32(_parmRetorno.Value);

                if (_codRetorno == -1)
                    throw new Exception("Error");
                if (_codRetorno == -2)
                    throw new Exception("Error al marcar la asistencia.");

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
    }
}
