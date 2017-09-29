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
                        FRAMEWORK.Servicios.ServicioMail.ssl = (bool)row["ssl"];
                    }
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



    }
}
