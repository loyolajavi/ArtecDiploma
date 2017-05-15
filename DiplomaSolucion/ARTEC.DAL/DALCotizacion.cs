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
    public class DALCotizacion
    {

        public List<Cotizacion> CotizacionTraerPorSolicitudYDetalle(int NroDetalleSolic, int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitudDetalle", NroDetalleSolic),
                new SqlParameter("@IdSolicitud", NroSolic),
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CotizacionTraerPorSolicitudYDetalle", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Cotizacion>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
