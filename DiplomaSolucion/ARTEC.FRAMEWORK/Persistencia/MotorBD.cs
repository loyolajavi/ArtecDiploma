using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.FRAMEWORK.Servicios;
using System.IO;

namespace ARTEC.FRAMEWORK.Persistencia
{
    public static class MotorBD
    {
        //public static string connectionStringName
        //{
        //    get { return _connectionStringName; }
        //    internal set { }
        //}//NO LO USO PORQUE EL CONNSTRINGNAME ES SOLAMENTE PARA USO INTERNO DE ESTA CLASE PORQ LO BUSCO DIRECTO DEL APP.CONFIG ACA ADENTRO

        //private static string _connectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["BDArtec"].ConnectionString; Deje de usarlo al serializar
        private static string RutaArchivoXML = System.Configuration.ConfigurationManager.ConnectionStrings["BDArtec"].ConnectionString;//Para obtener ruta del xml con el connectionString
        private static string _connectionStringName = "";
        private static SqlTransaction Transaccion;
        private static SqlCommand Comando;
        private static SqlConnection Conexion;
        private static List<ConfiguracionConexion> ConfiguracionBase = new List<ConfiguracionConexion>();//Objeto en donde se deserializan los connectionString (Artec y Restore(master))

        public static void ConexionIniciar()
        {
            try
            {
                //Solo la primera vez deserializo y obtengo el connectionstring de Artec
                if(string.IsNullOrEmpty(_connectionStringName))
                {
                    using (StreamReader sr = new StreamReader(RutaArchivoXML))
                    {
                        MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(sr.ReadToEnd()));
                        ConfiguracionBase = ServicioSerializadorXML.DeSerializar<List<ConfiguracionConexion>>(ms);
                    }
                    DesencriptarConfigBDXML();
                    if (ConfiguracionBase[0].UsuarioBD != null && !string.IsNullOrEmpty(ConfiguracionBase[0].UsuarioBD))
                        _connectionStringName = ConfiguracionBase[0].DataSourceBD + ConfiguracionBase[0].InitialCatalogBD + ConfiguracionBase[0].UsuarioBD + ConfiguracionBase[0].PasswordBD;
                    else
                        _connectionStringName = ConfiguracionBase[0].DataSourceBD + ConfiguracionBase[0].InitialCatalogBD + ConfiguracionBase[0].SSPI;
                }
                Conexion = new SqlConnection(_connectionStringName);
                if (Conexion != null && Conexion.State == ConnectionState.Closed)
                {
                    Conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public static void ConexionIniciarParaRestauracion()
        {
            try
            {
                //string connectionStringNameRest = System.Configuration.ConfigurationManager.ConnectionStrings["Restaurar"].ConnectionString; Ya no lo uso mas porque lo saco del archivo xml
                string connectionStringNameRest;
                if (ConfiguracionBase[1].UsuarioBD != null && !string.IsNullOrEmpty(ConfiguracionBase[1].UsuarioBD))
                    connectionStringNameRest = ConfiguracionBase[1].DataSourceBD + ConfiguracionBase[1].InitialCatalogBD + ConfiguracionBase[1].UsuarioBD + ConfiguracionBase[1].PasswordBD;
                else
                    connectionStringNameRest = ConfiguracionBase[1].DataSourceBD + ConfiguracionBase[1].InitialCatalogBD + ConfiguracionBase[1].SSPI;

                Conexion = new SqlConnection(connectionStringNameRest);
                if (Conexion != null && Conexion.State == ConnectionState.Closed)
                {
                    Conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public static void TransaccionIniciar()
        {
            try
            {
                Transaccion = Conexion.BeginTransaction();
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static void TransaccionAceptar()
        {
            try
            {
                Transaccion.Commit();
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static void ConexionFinalizar()
        {
            try
            {
                Conexion.Close();
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static void TransaccionCancelar()
        {
            try
            {
                Transaccion.Rollback();
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static DataSet EjecutarDataSet(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            DataSet Resultado;

            try
            {
                ConexionIniciar();
                TransaccionIniciar();

                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Resultado = CrearDataSet(Comando);
                    TransaccionAceptar();
                    return Resultado;
                }
            }
            catch (Exception ex2)
            {
                if (ConexionGetEstado())
                    TransaccionCancelar();
                throw;
            }

            finally
            {
                if (ConexionGetEstado())
                    ConexionFinalizar();
            }

        }

        public static DataSet EjecutarDataSetPrueba(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            DataSet Resultado;

            try
            {
                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Resultado = CrearDataSet(Comando);
                    return Resultado;
                }
            }
            catch (Exception ex2)
            {
                throw;
            }
        }

        public static DataTable EjecutarDataTable(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            DataTable Resultado;

            try
            {
                ConexionIniciar();
                TransaccionIniciar();

                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Resultado = CrearDataTable(Comando);
                    TransaccionAceptar();
                    return Resultado;
                }
            }
            catch (Exception ex)
            {
                if (ConexionGetEstado())
                    TransaccionCancelar();
                throw;
            }

            finally
            {
                if (ConexionGetEstado())
                    ConexionFinalizar();
            }

        }

        public static IDataReader EjecutarDataReader(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            IDataReader Resultado;

            try
            {
                ConexionIniciar();
                TransaccionIniciar();

                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Resultado = Comando.ExecuteReader();
                    TransaccionAceptar();
                    return Resultado;
                }
            }
            catch (Exception ex)
            {
                if(ConexionGetEstado())
                    TransaccionCancelar();
                throw;
            }

            finally
            {
                if (ConexionGetEstado())
                    ConexionFinalizar();
            }

        }


        private static SqlCommand CrearComando(SqlConnection Conexion, CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            SqlCommand unComando = new SqlCommand();
            unComando.Connection = Conexion;
            unComando.CommandText = ComandoString;
            unComando.CommandType = ComandoTipo;
            unComando.Transaction = Transaccion;

            if (Parametros.Length != 0)
            {
                for (int i = 0; i < Parametros.Length; i++)
                {
                    SqlParameter unParametro = Parametros[i];
                    unParametro.Value = ChequearNulo(unParametro.Value);
                    unComando.Parameters.Add(unParametro);
                }
            }
            return unComando;
        }


        private static object ChequearNulo(object value)
        {
            object result;
            if (value == null)
            {
                result = DBNull.Value;
            }
            else
            {
                result = value;
            }
            return result;
        }

        private static DataTable CrearDataTable(SqlCommand command)
        {
            DataTable result;
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                result = dataTable;
            }
            return result;
        }


        private static DataSet CrearDataSet(SqlCommand unComando)
        {
            DataSet ResultadoDataSet;
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(unComando))
            {
                DataSet unDataSet = new DataSet();
                dataAdapter.Fill(unDataSet);
                unDataSet.Tables[0].TableName = "tResultado";
                ResultadoDataSet = unDataSet;
            }
            return ResultadoDataSet;
        }


        public static object EjecutarScalar(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            object Resultado;

            try
            {
                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Resultado = Comando.ExecuteScalar();
                    return Resultado;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }



        public static int EjecutarNonQuery(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            try
            {
                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    return Comando.ExecuteNonQuery();
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public static bool ConexionGetEstado()
        {
            if (Conexion != null && Conexion.State == ConnectionState.Open)
                return true;
            return false;
        }


        private static void DesencriptarConfigBDXML()
        {
            if (ConfiguracionBase[0].UsuarioBD != null && !string.IsNullOrEmpty(ConfiguracionBase[0].UsuarioBD))
            {
                //Esquema Artec
                ConfiguracionBase[0].DataSourceBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].DataSourceBD);
                ConfiguracionBase[0].InitialCatalogBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].InitialCatalogBD);
                ConfiguracionBase[0].UsuarioBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].UsuarioBD);
                ConfiguracionBase[0].PasswordBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].PasswordBD);

                //Esquema master
                ConfiguracionBase[1].DataSourceBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].DataSourceBD);
                ConfiguracionBase[1].InitialCatalogBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].InitialCatalogBD);
                ConfiguracionBase[1].UsuarioBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].UsuarioBD);
                ConfiguracionBase[1].PasswordBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].PasswordBD);
            }
            else
            {
                //Esquema Artec
                ConfiguracionBase[0].DataSourceBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].DataSourceBD);
                ConfiguracionBase[0].InitialCatalogBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].InitialCatalogBD);
                ConfiguracionBase[0].SSPI = ServicioSecurizacion.Desencriptar(ConfiguracionBase[0].SSPI);

                //Esquema master
                ConfiguracionBase[1].DataSourceBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].DataSourceBD);
                ConfiguracionBase[1].InitialCatalogBD = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].InitialCatalogBD);
                ConfiguracionBase[1].SSPI = ServicioSecurizacion.Desencriptar(ConfiguracionBase[1].SSPI);
            }
        }


    }
}
