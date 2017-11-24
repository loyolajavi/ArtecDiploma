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
    public class DALPartida
    {
        public decimal TraerLimitePartida()
        {
            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                decimal Res = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "TraerLimitePartida");
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return Res;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public int PartidaCrear(Partida laPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaEnvio", laPartida.FechaEnvio),
                new SqlParameter("@MontoSolicitado", laPartida.MontoSolicitado),
                new SqlParameter("@Caja", laPartida.Caja)
                //new SqlParameter("@MontoOtorgado", laPartida.MontoOtorgado),
                //new SqlParameter("@FechaAcreditacion", laPartida.FechaAcreditacion),
                //new SqlParameter("@NroPartida", laPartida.NroPartida)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "PartidaCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                foreach (PartidaDetalle item in laPartida.unasPartidasDetalles)
                {

                    SqlParameter[] parametersPartidaDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdPartidaDetalle", item.IdPartidaDetalle),
                        new SqlParameter("@IdPartida", IDDevuelto),
                        //*********************GUARDA CON IDSOLICITUD****************************//
                        new SqlParameter("@IdSolicitud", item.SolicDetalleAsociado.IdSolicitud),
                        new SqlParameter("@IdSolicitudDetalle", item.SolicDetalleAsociado.IdSolicitudDetalle)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "PartidaDetalleCrearSinCotiz", parametersPartidaDetalles);

                    foreach (Cotizacion cotiz in item.unasCotizaciones)
                    {
                        SqlParameter[] parametersRelCotizPartidaDetalle = new SqlParameter[]
			            {
                            new SqlParameter("@IdCotizacion", cotiz.IdCotizacion),
                            new SqlParameter("@IdPartida", IDDevuelto),
                            new SqlParameter("@IdPartidaDetalle", item.IdPartidaDetalle)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelCotizPartDetalleCrear", parametersRelCotizPartidaDetalle);
                        
                    }

                    SqlParameter[] parametersSolicDetEstadoUpdate = new SqlParameter[]
			        {
                        new SqlParameter("@IdSolicitud", item.SolicDetalleAsociado.IdSolicitud),
                        new SqlParameter("@IdSolicDetalle", item.SolicDetalleAsociado.IdSolicitudDetalle),
                         new SqlParameter("@NuevoEstado", EstadoSolicDetalle.EnumEstadoSolicDetalle.EnPartida)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parametersSolicDetEstadoUpdate);

                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return IDDevuelto;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public List<Partida> PartidaTraerPorNroPart(int NroPart)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", NroPart)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PartidaTraerPorNroPart", parameters))
                {
                    List<Partida> unaPartida = new List<Partida>();
                    unaPartida = MapearPartidas(ds);
                    DALPartidaDetalle GestorPartidaDetalle = new DALPartidaDetalle();
                    if (unaPartida.Count() > 0)
                        unaPartida[0].unasPartidasDetalles = GestorPartidaDetalle.PartidaDetalleTraerTodosPorNroPart(NroPart);
                    return unaPartida;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }



        public bool PartidaAsociar(Partida laPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", laPartida.IdPartida),
                new SqlParameter("@FechaAcreditacion", laPartida.FechaAcreditacion),
                new SqlParameter("@MontoOtorgado", laPartida.MontoOtorgado),
                new SqlParameter("@NroPartida", laPartida.NroPartida)
            };

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "PartidaAsociar", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                return false;
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }



        public static Partida MapearPartidaUno(DataSet ds)
        {
            Partida unaParti = new Partida();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    

                    unaParti.IdPartida = (int)row["IdPartida"];
                    unaParti.MontoSolicitado = (decimal)row["MontoSolicitado"];
                    if (row["MontoOtorgado"].ToString() != "")
                        unaParti.MontoOtorgado = (decimal)row["MontoOtorgado"];
                    if (row["NroPartida"].ToString() != "")
                        unaParti.NroPartida = row["NroPartida"].ToString();
                    unaParti.FechaEnvio = DateTime.Parse(row["FechaEnvio"].ToString());
                    if (row["FechaAcreditacion"].ToString() != "")
                        unaParti.FechaAcreditacion = DateTime.Parse(row["FechaAcreditacion"].ToString());
                    unaParti.Caja = (bool)row["Caja"];
                }
                return unaParti;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public List<Partida> PartidasBuscarPorIdSolicitud(int NroPart)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitud", NroPart)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PartidasBuscarPorIdSolicitud", parameters))
                {
                    List<Partida> ListaPartidas = new List<Partida>();
                    ListaPartidas = MapearPartidas(ds);
                    return ListaPartidas;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }



        public List<Partida> MapearPartidas(DataSet ds)
        {
            List<Partida> LisResPartidas = new List<Partida>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Partida unaParti = new Partida();

                    unaParti.IdPartida = (int)row["IdPartida"];
                    unaParti.MontoSolicitado = (decimal)row["MontoSolicitado"];
                    if (row["MontoOtorgado"].ToString() != "")
                        unaParti.MontoOtorgado = (decimal)row["MontoOtorgado"];
                    if (row["NroPartida"].ToString() != "")
                        unaParti.NroPartida = row["NroPartida"].ToString();
                    unaParti.FechaEnvio = DateTime.Parse(row["FechaEnvio"].ToString());
                    if (row["FechaAcreditacion"].ToString() != "")
                        unaParti.FechaAcreditacion = DateTime.Parse(row["FechaAcreditacion"].ToString());
                    unaParti.Caja = (bool)row["Caja"];
                    LisResPartidas.Add(unaParti);
                }
                return LisResPartidas;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public int? RelPDetAdqPartidaTieneAdq(int IdPart)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", IdPart)
            };

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int? Res = (int?)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelPDetAdqPartidaTieneAdq", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return Res;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }




        public int PartidaModificar(Partida laPartida)
        {
            laPartida.IdPartida = PartidasBuscarPorIdSolicitud(laPartida.unasPartidasDetalles[0].SolicDetalleAsociado.IdSolicitud).FirstOrDefault().IdPartida;

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdPartida", laPartida.IdPartida),
                new SqlParameter("@FechaEnvio", laPartida.FechaEnvio),
                new SqlParameter("@MontoSolicitado", laPartida.MontoSolicitado),
                new SqlParameter("@Caja", laPartida.Caja)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "PartidaModificar", parameters);

                foreach (PartidaDetalle item in laPartida.unasPartidasDetalles)
                {

                    SqlParameter[] parametersPartidaDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdPartidaDetalle", item.IdPartidaDetalle),
                        new SqlParameter("@IdPartida", laPartida.IdPartida),
                        //*********************GUARDA CON IDSOLICITUD****************************//
                        new SqlParameter("@IdSolicitud", item.SolicDetalleAsociado.IdSolicitud),
                        new SqlParameter("@IdSolicitudDetalle", item.SolicDetalleAsociado.IdSolicitudDetalle)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "PartidaDetalleCrearSinCotiz", parametersPartidaDetalles);

                    foreach (Cotizacion cotiz in item.unasCotizaciones)
                    {
                        SqlParameter[] parametersRelCotizPartidaDetalle = new SqlParameter[]
			            {
                            new SqlParameter("@IdCotizacion", cotiz.IdCotizacion),
                            new SqlParameter("@IdPartida", laPartida.IdPartida),
                            new SqlParameter("@IdPartidaDetalle", item.IdPartidaDetalle)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelCotizPartDetalleCrear", parametersRelCotizPartidaDetalle);

                    }

                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return laPartida.IdPartida;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public bool PartidaModifMontoSolic(int IdPartida, decimal MontoSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", IdPartida),
                new SqlParameter("@MontoSolicitado", MontoSolic)
            };

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "PartidaModifMontoSolic", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                return false;
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }




    }
}
