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
                    //unaListaSolicDetalles = MapearSolicDetalles(ds);
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
                    //unDet.IdSolicitud = (int)row["IdSolicitud"];
                    //unDet.IdSolicitud = (row["IdSolicitud"].ToString() != "") ? (int)row["IdSolicitud"] : 0;
                    unDet.unaCategoria = DALCategoria.MapearCategoriaUno(ds);
                    
                    
                    //unaSolic.laDependencia = new Dependencia();
                    //unaSolic.laDependencia.IdDependencia = (int)row["IdDependencia"];
                    //unaSolic.laDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    //unaSolic.FechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                    //if (row["FechaFin"].ToString() != "")
                    //{
                    //    unaSolic.FechaFin = DateTime.Parse(row["FechaFin"].ToString());
                    //}
                    //unaSolic.UnaPrioridad = new Prioridad();
                    //unaSolic.UnaPrioridad.IdPrioridad = (int)row["IdPrioridad"];
                    //unaSolic.UnaPrioridad.DescripPrioridad = row["DescripPrioridad"].ToString();
                    //unaSolic.UnEstado = new EstadoSolicitud();
                    //unaSolic.UnEstado.IdEstadoSolicitud = (int)row["IdEstadoSolicitud"];
                    //unaSolic.UnEstado.DescripEstadoSolic = row["DescripEstadoSolic"].ToString();
                    //unaSolic.Asignado = new Usuario();
                    //unaSolic.Asignado.IdUsuario = (int)row["IdUsuario"];
                    //unaSolic.Asignado.NombreUsuario = row["NombreUsuario"].ToString();
                    //unaSolic.AgenteResp = new Agente();
                    //unaSolic.AgenteResp.IdAgente = (row["IdAgente"].ToString() != "") ? (int)row["IdAgente"] : (int?)null;
                    //unaSolic.AgenteResp.ApellidoAgente = row["ApellidoAgente"].ToString();

                    ResSolicDetalles.Add(unDet);
                }
                return ResSolicDetalles;
            }
            catch (Exception es)
            {

                throw;
            }
        }



    }
}
