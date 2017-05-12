using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.FRAMEWORK.Persistencia
{
    public static class MotorBD
    {
        //public static string connectionStringName
        //{
        //    get { return _connectionStringName; }
        //    internal set { }
        //}//NO LO USO PORQUE EL CONNSTRINGNAME ES SOLAMENTE PARA USO INTERNO DE ESTA CLASE PORQ LO BUSCO DIRECTO DEL APP.CONFIG ACA ADENTRO

        private static string _connectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["BDArtec"].ConnectionString;
        private static SqlTransaction Transaccion;
        private static SqlCommand Comando;
        private static SqlConnection Conexion;


        public static void ConexionIniciar()
        {
            Conexion = new SqlConnection(_connectionStringName);
            if (Conexion != null && Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
        }

        public static void TransaccionIniciar()
        {
            Transaccion = Conexion.BeginTransaction();
        }

        public static void TransaccionAceptar()
        {
            Transaccion.Commit();
        }

        public static void ConexionFinalizar()
        {
            Conexion.Close();
        }

        public static void TransaccionCancelar()
        {
            Transaccion.Rollback();
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
            catch (Exception ex)
            {
                TransaccionCancelar();
                throw;
            }

            finally
            {
                ConexionFinalizar();
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
                TransaccionCancelar();
                throw;
            }

            finally
            {
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
                TransaccionCancelar();
                throw;
            }

            finally
            {
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



        public static void EjecutarNonQuery(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            try
            {
                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Comando.ExecuteNonQuery();
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }




    }
}
