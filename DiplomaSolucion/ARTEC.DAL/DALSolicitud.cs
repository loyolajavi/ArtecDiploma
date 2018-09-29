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
using ARTEC.FRAMEWORK.Servicios;

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
                laSolicitud.IdSolicitud = IDDevuelto;

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

                long ResAcum = ServicioDV.DVCalcularDVH(laSolicitud);
                if (ResAcum > 0)
                {
                    if (ServicioDV.DVActualizarDVH(laSolicitud.IdSolicitud, ResAcum, laSolicitud.GetType().Name, "IdSolicitud"))
                    {
                        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                        return IDDevuelto;
                    }
                }
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                return 0;
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



        public List<Solicitud> SolicitudBuscar(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NroSolicitud", NroSolic),
                new SqlParameter("@IdIdioma", ENTIDADES.Servicios.Idioma.unIdiomaActual)
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


        public List<Solicitud> SolicitudBuscarConCanceladas(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NroSolicitud", NroSolic),
                new SqlParameter("@IdIdioma", ENTIDADES.Servicios.Idioma.unIdiomaActual)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerPorNroSolicitudConCanceladas", parameters))
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



        public List<Solicitud> SolicitudBuscar(string NombreDep = null, int? EstadoSolic = null, string bien = null, int? priori = null, int? usasig = null, DateTime? fechaInicio = null, DateTime? fechaInicio2 = null, DateTime? fechaFin = null, DateTime? fechaFin2 = null)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(NombreDep))
                parameters.Add(new SqlParameter("@NombreDep", NombreDep));
            if (EstadoSolic != null)
                parameters.Add(new SqlParameter("@EstadoSolic", EstadoSolic));
            if (!string.IsNullOrEmpty(bien))
                parameters.Add(new SqlParameter("@bien", bien));
            if (priori != null)
                parameters.Add(new SqlParameter("@priori", priori));
            if (usasig != null)
                parameters.Add(new SqlParameter("@usasig", usasig));
            parameters.Add(new SqlParameter("@ididioma", ENTIDADES.Servicios.Idioma.unIdiomaActual));
            if (fechaInicio != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            if (fechaInicio2 != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaInicio2", fechaInicio2));
            if (fechaFin != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            if (fechaFin2 != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaFin2", fechaFin2));

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


        public List<Solicitud> SolicitudBuscarConCanceladas(string NombreDep = null, int? EstadoSolic = null, string bien = null, int? priori = null, int? usasig = null, DateTime? fechaInicio = null, DateTime? fechaInicio2 = null, DateTime? fechaFin = null, DateTime? fechaFin2 = null)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(NombreDep))
                parameters.Add(new SqlParameter("@NombreDep", NombreDep));
            if (EstadoSolic != null)
                parameters.Add(new SqlParameter("@EstadoSolic", EstadoSolic));
            if (!string.IsNullOrEmpty(bien))
                parameters.Add(new SqlParameter("@bien", bien));
            if (priori != null)
                parameters.Add(new SqlParameter("@priori", priori));
            if (usasig != null)
                parameters.Add(new SqlParameter("@usasig", usasig));
            parameters.Add(new SqlParameter("@ididioma", ENTIDADES.Servicios.Idioma.unIdiomaActual));
            if (fechaInicio != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            if (fechaInicio2 != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaInicio2", fechaInicio2));
            if (fechaFin != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            if (fechaFin2 != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaFin2", fechaFin2));

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudBuscarConCanceladas", parameters.ToArray()))
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
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
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
                new SqlParameter("@IdSolicitud", laSolicitud.IdSolicitud),
                new SqlParameter("@FechaFin", laSolicitud.FechaFin)

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

                long ResAcum = ServicioDV.DVCalcularDVH(laSolicitud);
                if (ResAcum > 0)
                {
                    if (ServicioDV.DVActualizarDVH(laSolicitud.IdSolicitud, ResAcum, laSolicitud.GetType().Name, "IdSolicitud"))
                    {
                        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                        return true;
                    }
                }
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                return false;
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




        public bool SolicitudCancelar(Solicitud unaSolicitud)
        {


            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();

                foreach (SolicDetalle unDetSolic in unaSolicitud.unosDetallesSolicitud)
                {
                    SqlParameter[] parametersDetSolicCancelar = new SqlParameter[]
			        {
                        new SqlParameter("@UIDSolicDetalle", unDetSolic.UIDSolicDetalle),
                        new SqlParameter("@NuevoEstado", EstadoSolicDetalle.EnumEstadoSolicDetalle.Cancelado)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetallePorUIDUpdateEstado", parametersDetSolicCancelar);
                    unDetSolic.unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cancelado;
                }

                SqlParameter[] parametersSolicCancelar = new SqlParameter[]
		        {
                    new SqlParameter("@IdSolicitud", unaSolicitud.IdSolicitud),
                    new SqlParameter("@NuevoEstado", EstadoSolicitud.EnumEstadoSolicitud.Cancelada)
		        };

                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicitudUpdateEstado", parametersSolicCancelar);
                unaSolicitud.UnEstado.IdEstadoSolicitud = (int)EstadoSolicitud.EnumEstadoSolicitud.Cancelada;

                long ResAcum = ServicioDV.DVCalcularDVH(unaSolicitud);
                if (ResAcum > 0)
                {
                    if (ServicioDV.DVActualizarDVH(unaSolicitud.IdSolicitud, ResAcum, unaSolicitud.GetType().Name, "IdSolicitud"))
                    {
                        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                        return true;
                    }
                }
                return false;
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
