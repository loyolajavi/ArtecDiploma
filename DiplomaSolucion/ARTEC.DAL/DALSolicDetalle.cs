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
                    //unaListaSolicDetalles = FRAMEWORK.Persistencia.Mapeador.Mapear<SolicDetalle>(ds);
                    unaListaSolicDetalles = MapearSolicDetalles(ds);
                    return unaListaSolicDetalles;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }



        public static List<SolicDetalle> MapearSolicDetalles(DataSet ds)
        {
            List<SolicDetalle> ResSolicDetalles = new List<SolicDetalle>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    SolicDetalle unDet = new SolicDetalle();
                    unDet.IdSolicitudDetalle = (int)row["IdSolicitudDetalle"];
                    
                    //try
                    //{
                    //    unDet.IdSolicitud = (int)row["IdSolicitud"];
                    //}
                    //catch (Exception es)
                    //{
                    //}
                    
                    
                    unDet.unaCategoria = DALCategoria.MapearCategoriaUno(ds);
                    unDet.Cantidad = (int)row["Cantidad"];
                    unDet.unEstado = DALEstadoSolicDetalle.MapearEstadoUno(ds);
                    unDet.IdSolicitud = (int)row["IdSolicitud"];
                    //unDet.unosAgentes = DALAgente.MapearAgentes(ds);
                    //unDet.unasCotizaciones = DALCotizacion.MapearCotizaciones(ds);

                    ResSolicDetalles.Add(unDet);
                }
                
            }
            catch (Exception es)
            {
            }
            return ResSolicDetalles;
        }



    }
}
