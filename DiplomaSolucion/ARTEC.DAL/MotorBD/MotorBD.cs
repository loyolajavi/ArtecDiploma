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

        private static string _connectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        private static SqlTransaction tr;
        private static SqlCommand command;
        private static SqlConnection connection;


        public static void prueba(){
            try
                {
                    connection = new SqlConnection(connectionStringName);

                    if (connection != null && connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string hola = connection.ServerVersion; 

                    tr = connection.BeginTransaction();
                    
                }
            catch (Exception es)
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
