using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.FRAMEWORK;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioBackup
    {

        public static bool Respaldar(string Nombre, string Destino, string Obser)
        {

            
            Destino = Destino + "\\" + Nombre + ".bak";

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Destino", Destino),
                new SqlParameter("@Obser", Obser)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "BaseDatosRespaldar", parameters);
            }
            catch (Exception es)
            {
                return false;
                //ACA TIENE QUE IR UN THROW
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

            return true;

        }




        public static bool Restaurar(string Nombre, string Ubicacion)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Ubicacion", Ubicacion)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "BaseDatosRestaurar", parameters);//CINT FALTA EL STORE PROCEDURE
            }
            catch (Exception es)
            {
                return false;
                //ACA TIENE QUE IR UN THROW
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

            return true;
        }




        
    }
}
