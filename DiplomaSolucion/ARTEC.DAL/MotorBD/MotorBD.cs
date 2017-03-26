using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.DAL.MotorBD
{
    internal static class MotorBD
    {
        public static string connectionStringName
        {
            get { return _connectionStringName; }
            internal set { }
        }

        private static string _connectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["BDArtec"].ConnectionString;
        private static SqlTransaction Transaccion;
        private static SqlCommand Comando;
        private static SqlConnection Conexion;


        public static DataSet EjecutarDataSet(CommandType ComandoTipo, string ComandoString, params SqlParameter[] Parametros)
        {
            DataSet Resultado;


            try
            {
                Conexion = new SqlConnection(connectionStringName);

                if (Conexion != null && Conexion.State == ConnectionState.Closed)
                {
                    Conexion.Open();
                }

                Transaccion = Conexion.BeginTransaction();

                using (Comando = CrearComando(Conexion, ComandoTipo, ComandoString, Parametros))
                {
                    Resultado = CrearDataSet(Comando);
                    Transaccion.Commit();
                    return Resultado;
                }


            }
            catch (Exception ex)
            {
                Transaccion.Rollback();   
                throw;
            }

            finally
            {
                Conexion.Close();
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




        public static void prueba(){
            try
                {
                    Conexion = new SqlConnection(connectionStringName);

                    if (Conexion != null && Conexion.State == ConnectionState.Closed)
                    {
                        Conexion.Open();
                    }

                    string hola = Conexion.ServerVersion; 

                    Transaccion = Conexion.BeginTransaction();
                    
                }
            catch (Exception es)
            {
                Transaccion.Rollback();
                throw;
            }
            finally
            {
                Conexion.Close();
            }
        }

    }
}
