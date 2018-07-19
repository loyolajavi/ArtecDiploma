using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using System.Data;
using System.Data.SqlClient;

namespace ARTEC.DAL.Servicios
{
    public class DALBitacora
    {
        public List<Bitacora> BitacoraVerLogs(string unTipoLog, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TipoLog", unTipoLog));
            if (fechaInicio != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            if (fechaFin != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaFin", fechaFin));


            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "BitacoraVerLogs", parameters.ToArray()))
            {
                List<Bitacora> unaLista = new List<Bitacora>();
                unaLista = MapearBitacoraLogs(ds);
                return unaLista;
            }
        }


        public List<Bitacora> MapearBitacoraLogs(DataSet ds)
        {
            List<Bitacora> ResLogs = new List<Bitacora>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Bitacora unLog = new Bitacora();

                    unLog.IdBitacora = (int)row["IdBitacora"];
                    unLog.IdUsuario = (int)row["IdUsuario"];
                    unLog.NombreUsuario = row["NombreUsuario"].ToString();
                    unLog.Fecha = DateTime.Parse(row["Fecha"].ToString());
                    unLog.TipoLog = row["TipoLog"].ToString();
                    unLog.Accion = row["Accion"].ToString();
                    unLog.Mensaje = row["Mensaje"].ToString();
                    ResLogs.Add(unLog);
                }
                return ResLogs;
            }
            catch (Exception es)
            {
                throw;
            }
        }


    }
}
