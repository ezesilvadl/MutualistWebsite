using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;
using System.Runtime.InteropServices;

namespace Persistencia
{
    internal class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        private static PersistenciaEmpleado _instancia;
        private PersistenciaEmpleado() { }
        public static PersistenciaEmpleado GetInstancia()
        { 
            if (_instancia == null ) 
                _instancia = new PersistenciaEmpleado();
            return _instancia;
        }

        public void AltaEmpleado(EntidadesCompartidas.Empleado unUsuario)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaEmpleado", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomUsuario", unUsuario.NomUsuario);
            _comando.Parameters.AddWithValue("@PassUsuario", unUsuario.PassUsuario);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _CodRetorno = Convert.ToInt32(_ParmRetorno.Value);

                if (_CodRetorno == -1)
                    throw new Exception("Empleado ya existente");
                else if (_CodRetorno == 0)
                    throw new Exception("Error no especificado");

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

        public Empleado Logueo(string nombreUsuario, string contraseña)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("Logueo", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Empleado unEmpleado = null;

            _comando.Parameters.AddWithValue("@NomUsuario", nombreUsuario);
            _comando.Parameters.AddWithValue("@PassUsuario", contraseña);

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    
                        string _nombreUsuario = (string)_lector["NomUsuario"];
                        string _contraseña = (string)_lector["PassUsuario"];

                        unEmpleado = new Empleado(_nombreUsuario, _contraseña);

                        _lector.Close();
                    
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
            return unEmpleado;
        }

        internal EntidadesCompartidas.Empleado BuscarEmpleado(string NomUsuario)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BuscarEmpleado", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomUsuario", NomUsuario);

            EntidadesCompartidas.Empleado _unEmpleado = null;

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    
                        string _nombreUsuario = (string)_lector["NomUsuario"];
                        string _contraseña = (string)_lector["PassUsuario"];
                        _unEmpleado = new EntidadesCompartidas.Empleado(_nombreUsuario, _contraseña);
                    
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
            return _unEmpleado;
        }
    }
}
