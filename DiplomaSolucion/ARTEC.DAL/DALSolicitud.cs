using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Diagnostics;

namespace ARTEC.DAL
{
    public class DALSolicitud
    {

        public int SolicitudCrear(Solicitud laSolicitud)
        {


            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaInicio", laSolicitud.FechaInicio),
                new SqlParameter("@IdDependencia", laSolicitud.laDependencia.IdDependencia),
                new SqlParameter("@IdPrioridad", laSolicitud.UnaPrioridad.IdPrioridad),
                new SqlParameter("@IdEstado", laSolicitud.UnEstado.IdEstadoSolicitud),
                new SqlParameter("@IdUsuario", laSolicitud.Asignado.IdUsuario),
                new SqlParameter("@IdAgente", laSolicitud.AgenteResp.IdAgente)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //Guarda los detalles 
                foreach (SolicDetalle item in laSolicitud.unosDetallesSolicitud)
                {

                    SqlParameter[] parametersSolicitudDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", IDDevuelto),
                        new SqlParameter("@IdCategoria", item.unaCategoria.IdCategoria),
                        new SqlParameter("@Cantidad", item.Cantidad),
                        new SqlParameter("@IdEstadoSolDetalle", item.unEstado.IdEstadoSolicDetalle)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudDetalleCrear", parametersSolicitudDetalles);

                    //Guarda los Agentes por cada Detalle
                    foreach (Agente unAgente in item.unosAgentes)
                    {
                        SqlParameter[] parametersAgentes = new SqlParameter[]
			            {
                            new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                            new SqlParameter("@IdSolicitud", IDDevuelto),
                            new SqlParameter("@IdAgente", unAgente.IdAgente)
			            };
                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelSolDetalleAgenteAgregar", parametersAgentes);
                    }
                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return IDDevuelto;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                //VER:EXCepciones
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public List<Solicitud> SolicitudBuscar(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NroSolicitud", NroSolic)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerPorNroSolicitud", parameters))
                {
                    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                    unaListaSolicitudes = MapearSolicitud(ds);
                    return unaListaSolicitudes;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }




        public Solicitud SolicitudTraerIdsolNomdepPorIdPartida(int IdPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", IdPartida)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerIdsolNomdepPorIdPartida", parameters))
                {
                    Solicitud unaSolic = new Solicitud();
                    unaSolic = MapearSolicitudIdSolNomDep(ds);
                    
                    return unaSolic;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }




        public static List<Solicitud> MapearSolicitud(DataSet ds)
        {
            List<Solicitud> ResSolicitudes = new List<Solicitud>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Solicitud unaSolic = new Solicitud();

                    unaSolic.IdSolicitud = (int)row["IdSolicitud"];
                    unaSolic.laDependencia = new Dependencia();
                    unaSolic.laDependencia.IdDependencia = (int)row["IdDependencia"];
                    unaSolic.laDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    unaSolic.FechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                    if (row["FechaFin"].ToString() != "")
                    {
                        unaSolic.FechaFin = DateTime.Parse(row["FechaFin"].ToString());
                    }
                    unaSolic.UnaPrioridad = new Prioridad();
                    unaSolic.UnaPrioridad.IdPrioridad = (int)row["IdPrioridad"];
                    unaSolic.UnaPrioridad.DescripPrioridad = row["DescripPrioridad"].ToString();
                    unaSolic.UnEstado = new EstadoSolicitud();
                    unaSolic.UnEstado.IdEstadoSolicitud = (int)row["IdEstadoSolicitud"];
                    unaSolic.UnEstado.DescripEstadoSolic = row["DescripEstadoSolic"].ToString();
                    unaSolic.Asignado = new Usuario();
                    unaSolic.Asignado.IdUsuario = (int)row["IdUsuario"];
                    unaSolic.Asignado.NombreUsuario = row["NombreUsuario"].ToString();
                    unaSolic.AgenteResp = new Agente();
                    unaSolic.AgenteResp.IdAgente = (row["IdAgente"].ToString() != "") ? (int)row["IdAgente"] : (int?)null;
                    unaSolic.AgenteResp.ApellidoAgente = row["ApellidoAgente"].ToString();

                    ResSolicitudes.Add(unaSolic);
                }
                return ResSolicitudes;
            }
            catch (Exception es)
            {
                
                throw;
            }
        }



        public static Solicitud MapearSolicitudIdSolNomDep(DataSet ds)
        {
            try
            {
                Solicitud unaSolic = new Solicitud();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    unaSolic.IdSolicitud = (int)row["IdSolicitud"];
                    unaSolic.laDependencia = new Dependencia();
                    unaSolic.laDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                }
                return unaSolic;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public List<Solicitud> SolicitudBuscar(string NombreDep = null, string EstadoSolic = null, string bien = null, string priori = null, string usasig = null)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(NombreDep))
                parameters.Add(new SqlParameter("@NombreDep", NombreDep));
            if (!string.IsNullOrEmpty(EstadoSolic))
                parameters.Add(new SqlParameter("@EstadoSolic", EstadoSolic));
            if (!string.IsNullOrEmpty(bien))
                parameters.Add(new SqlParameter("@bien", bien));
            if (!string.IsNullOrEmpty(priori))
                parameters.Add(new SqlParameter("@priori", priori));
            if (!string.IsNullOrEmpty(usasig))
                parameters.Add(new SqlParameter("@usasig", usasig));

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudBuscar", parameters.ToArray()))
                {
                    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                    unaListaSolicitudes = MapearSolicitud(ds);
                    return unaListaSolicitudes;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public bool SolicitudModificar(Solicitud laSolicitud)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaInicio", laSolicitud.FechaInicio),
                new SqlParameter("@IdDependencia", laSolicitud.laDependencia.IdDependencia),
                new SqlParameter("@IdPrioridad", laSolicitud.UnaPrioridad.IdPrioridad),
                new SqlParameter("@IdEstado", laSolicitud.UnEstado.IdEstadoSolicitud),
                new SqlParameter("@IdUsuario", laSolicitud.Asignado.IdUsuario),
                new SqlParameter("@IdAgente", laSolicitud.AgenteResp.IdAgente),
                new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud)
			};
            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicitudModificar", parameters);
                
                //Guarda los detalles 
                foreach (SolicDetalle item in laSolicitud.unosDetallesSolicitud)
                {
                    SqlParameter[] parametersSolicitudDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud),
                        new SqlParameter("@IdCategoria", item.unaCategoria.IdCategoria),
                        new SqlParameter("@Cantidad", item.Cantidad),
                        new SqlParameter("@IdEstadoSolDetalle", item.unEstado.IdEstadoSolicDetalle)
			        };
                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicitudDetalleModificar", parametersSolicitudDetalles);
                    
                    //Guarda los Agentes por cada Detalle
                    DALTipoBien GestorCategoria = new DALTipoBien();
                    if (GestorCategoria.TipoBienTraerTipoBienPorIdCategoria(item.unaCategoria.IdCategoria).IdTipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        foreach (Agente unAgente in item.unosAgentes)
                        {
                            SqlParameter[] parametersAgentes = new SqlParameter[]
			                {
                                new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                                new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud),
                                new SqlParameter("@IdAgente", unAgente.IdAgente)
			                };
                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "RelSolDetalleAgenteModificar", parametersAgentes);
                        }
                    } 
                }
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                //VER:EXCepciones
                return false;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public bool SolicitudModificarConDetallesEliminados(Solicitud laSolicitud)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaInicio", laSolicitud.FechaInicio),
                new SqlParameter("@IdDependencia", laSolicitud.laDependencia.IdDependencia),
                new SqlParameter("@IdPrioridad", laSolicitud.UnaPrioridad.IdPrioridad),
                new SqlParameter("@IdEstado", laSolicitud.UnEstado.IdEstadoSolicitud),
                new SqlParameter("@IdUsuario", laSolicitud.Asignado.IdUsuario),
                new SqlParameter("@IdAgente", laSolicitud.AgenteResp.IdAgente),
                new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud)
			};
            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicitudModificar", parameters);

                //Limpia los detalles en la BD
                //DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();
                //GestorSolicDetalle.SolicDetalleDeletePorSolicitud(laSolicitud.IdSolicitud);
                SqlParameter[] parametersDetalles = new SqlParameter[]
                {
                    new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud)
                };

                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleDeletePorSolicitud", parametersDetalles);

                //Limpia la relacion entre SolDet y Cotiz, y además el mismo store elimina las cotizaciones
                SqlParameter[] parametersSolDetCotiz = new SqlParameter[]
                {
                    new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud)
                };
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "RelCotSolDetalleDeletePorIdSolicitud", parametersSolDetCotiz);

                //Limpia la relacion entre SolDet y Agente (por detalles de software)
                SqlParameter[] parametersSolDetAgenteRel = new SqlParameter[]
                {
                    new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud)
                };
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "RelSolDetalleAgenteEliminar", parametersSolDetAgenteRel);

                //Regenera los detalles en la BD
                foreach (SolicDetalle item in laSolicitud.unosDetallesSolicitud)
                {
                    SqlParameter[] parametersSolicitudDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud),
                        new SqlParameter("@IdCategoria", item.unaCategoria.IdCategoria),
                        new SqlParameter("@Cantidad", item.Cantidad),
                        new SqlParameter("@IdEstadoSolDetalle", item.unEstado.IdEstadoSolicDetalle)
			        };
                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicitudDetalleCrear", parametersSolicitudDetalles);

                    //Guarda Las cotizaciones
                    foreach (Cotizacion unaCotiza in item.unasCotizaciones)
                    {
                        SqlParameter[] parametersCotizaciones = new SqlParameter[]
			            {
                            new SqlParameter("@MontoCotizado", unaCotiza.MontoCotizado),
                            new SqlParameter("@FechaCotizacion", unaCotiza.FechaCotizacion),
                            new SqlParameter("@IdProveedor", unaCotiza.unProveedor.IdProveedor)
			            };

                        var ResCotiz = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrear", parametersCotizaciones);
                        int IDDevCotiz = Decimal.ToInt32(ResCotiz);

                        //Tabla de relacion
                        SqlParameter[] parametersRelCotizSolicDetalle = new SqlParameter[]
			            {
                            new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                            new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud),
                            new SqlParameter("@IdCotizacion", IDDevCotiz)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrearRelSolicDetalle", parametersRelCotizSolicDetalle);
                    }


                    //Guarda los Agentes por cada Detalle
                    DALTipoBien GestorCategoria = new DALTipoBien();
                    SqlParameter[] parametersTipoBien = new SqlParameter[]
			        {
                        new SqlParameter("@IdCategoria", item.unaCategoria.IdCategoria)
			        };
                    int IdTipoBienAUX = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "TipoBienTraerIDTipoBienPorIdCategoria", parametersTipoBien);
                    if (IdTipoBienAUX == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        foreach (Agente unAgente in item.unosAgentes)
                        {
                            SqlParameter[] parametersAgentes = new SqlParameter[]
			                {
                                new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                                new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud),
                                new SqlParameter("@IdAgente", unAgente.IdAgente)
			                };
                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "RelSolDetalleAgenteAgregar", parametersAgentes);
                        }
                    }
                }
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                //VER:EXCepciones
                return false;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



    }
}
