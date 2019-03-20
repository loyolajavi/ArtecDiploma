using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK;

namespace ARTEC.DAL.Servicios
{
    public class DALServicioMail
    {

        public static void CargarMailConfig()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ConfigMailHostTraer"))
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        FRAMEWORK.Servicios.ServicioMail.Puerto = (int)row["Puerto"];
                        FRAMEWORK.Servicios.ServicioMail.Host = row["Host"].ToString();
                        FRAMEWORK.Servicios.ServicioMail.ssl = (bool)row["Ssl"];
                        FRAMEWORK.Servicios.ServicioMail.remitente = row["Remitente"].ToString();
                        FRAMEWORK.Servicios.ServicioMail.remps = row["Remps"].ToString();
                        FRAMEWORK.Servicios.ServicioMail.remps = FRAMEWORK.Servicios.ServicioSecurizacion.Desencriptar(FRAMEWORK.Servicios.ServicioMail.remps);
                        if (string.IsNullOrEmpty(FRAMEWORK.Servicios.ServicioMail.remitente = row["Remitente"].ToString()))
                            throw new Exception("Se debe registrar la dirección del remitente");
                    }
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }




        public void ModificarMailConfig(string unMail, string unPass, int unPuerto, string unHost, bool unSSL)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@unMail", unMail),
                new SqlParameter("@unPass", unPass),
                new SqlParameter("@unPuerto", unPuerto),
                new SqlParameter("@unHost", unHost),
                new SqlParameter("@unSSL", unSSL)

			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "ModificarMailConfig", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }
    }
}
