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
                new SqlParameter("@NroSolicitud", NroSolic),
                new SqlParameter("@IdIdioma", ENTIDADES.Servicios.Idioma.unIdiomaActual)
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
                    unDet.unaCategoria = new Categoria();
                    unDet.unaCategoria.IdCategoria = (int)row["IdCategoria"];
                    unDet.unaCategoria.DescripCategoria = row["DescripCategoria"].ToString();
                    //unDet.unaCategoria = DALCategoria.MapearCategoriaUno(ds);
                    unDet.Cantidad = (int)row["Cantidad"];
                    unDet.unEstado = new EstadoSolicDetalle();
                    unDet.unEstado.IdEstadoSolicDetalle = (int)row["IdEstadoSolicDetalle"];
                    unDet.unEstado.DescripEstadoSolicDetalle = row["DescripEstadoSolicDetalle"].ToString();
                    //unDet.unEstado = DALEstadoSolicDetalle.MapearEstadoUno(ds);
                    unDet.IdSolicitud = (int)row["IdSolicitud"];
                    //unDet.unosAgentes = DALAgente.MapearAgentes(ds);
                    //unDet.unasCotizaciones = DALCotizacion.MapearCotizaciones(ds);
                    unDet.UIDSolicDetalle = (int)row["UIDSolicDetalle"];

                    ResSolicDetalles.Add(unDet);
                }
                
            }
            catch (Exception es)
            {
            }
            return ResSolicDetalles;
        }



        public void SolicDetalleUpdateEstado(int IdSolic, int IdSolicDetalle, int nuevoEstado)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitud", IdSolic),
                new SqlParameter("@IdSolicDetalle", IdSolicDetalle),
                new SqlParameter("@NuevoEstado", nuevoEstado)
            };

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.GetConexionBDUnica().TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parameters);
                //FRAMEWORK.Persistencia.MotorBD.GetConexionBDUnica().TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.GetConexionBDUnica().TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }



        public List<Agente> SolicDetallesTraerAgentesAsociados(int IdSolicDetalle, int IdSolicitud)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicDetalle", IdSolicDetalle),
                new SqlParameter("@IdSolicitud", IdSolicitud)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicDetallesTraerAgentesAsociados", parameters))
                {
                    List<Agente> unaLista = new List<Agente>();
                    unaLista = DALAgente.MapearAgentes(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                //VER:Excepciones
                throw;
            }

        }


        public bool SolicDetalleDeletePorSolicitud(int IdSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitud", IdSolic)
            };

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.GetConexionBDUnica().TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleDeletePorSolicitud", parameters);
                //FRAMEWORK.Persistencia.MotorBD.GetConexionBDUnica().TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.GetConexionBDUnica().TransaccionCancelar();
                return false; //VER:Msj
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }




    }
}
