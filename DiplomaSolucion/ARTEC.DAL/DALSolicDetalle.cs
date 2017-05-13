using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;

namespace ARTEC.DAL
{
    public class DALSolicDetalle
    {

        public List<SolicDetalle> SolicDetallesTraerPorNroSolicitud(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NroSolicitud", NroSolic)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicDetallesTraerPorNroSolicitud", parameters))
                {
                    List<SolicDetalle> unaListaSolicDetalles = new List<SolicDetalle>();
                    unaListaSolicDetalles = FRAMEWORK.Persistencia.Mapeador.Mapear<SolicDetalle>(ds);
                    return unaListaSolicDetalles;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
