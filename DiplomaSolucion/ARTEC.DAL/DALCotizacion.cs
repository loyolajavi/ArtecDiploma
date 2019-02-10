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

        public List<Cotizacion> CotizacionTraerPorSolicitudYDetalle(int NroDetalleSolic, int NroSolic, int UIDSolicDetalle)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitudDetalle", NroDetalleSolic),
                new SqlParameter("@IdSolicitud", NroSolic),
                new SqlParameter("@UIDSolicDetalle", UIDSolicDetalle)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSetPrueba(CommandType.StoredProcedure, "CotizacionTraerPorSolicitudYDetalle", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    //unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Cotizacion>(ds);
                    unaLista = MapearCotizaciones(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }



        public List<Cotizacion> CotizacionTraerPorSolicitud(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitud", NroSolic)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CotizacionTraerPorSolicitud", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    //unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Cotizacion>(ds);
                    unaLista = MapearCotizaciones(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }


        public int CotizacionCrear(Cotizacion laCotizacion)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
			    {
                    new SqlParameter("@MontoCotizado", laCotizacion.MontoCotizado),
                    new SqlParameter("@FechaCotizacion", laCotizacion.FechaCotizacion),
                    new SqlParameter("@IdProveedor", laCotizacion.unProveedor.IdProveedor)
			    };

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //Tabla de relacion
                SqlParameter[] parametersRelCotizSolicDetalle = new SqlParameter[]
			    {
                    new SqlParameter("@IdSolicitudDetalle", laCotizacion.unDetalleAsociado.IdSolicitudDetalle),
                    new SqlParameter("@IdSolicitud", laCotizacion.unDetalleAsociado.IdSolicitud),
                    new SqlParameter("@IdCotizacion", IDDevuelto),
                    new SqlParameter("@UIDSolicDetalle", laCotizacion.unDetalleAsociado.UIDSolicDetalle)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrearRelSolicDetalle", parametersRelCotizSolicDetalle);

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
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public static List<Cotizacion> MapearCotizaciones(DataSet ds)
        {
            List<Cotizacion> ResCotizaciones = new List<Cotizacion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Cotizacion unaCotizacion = new Cotizacion();

                    unaCotizacion.IdCotizacion = (int)row["IdCotizacion"];
                    if (row["FechaCotizacion"].ToString() != "")
                    {
                        unaCotizacion.FechaCotizacion = DateTime.Parse(row["FechaCotizacion"].ToString());
                    }
                    unaCotizacion.MontoCotizado = (decimal)row["MontoCotizado"];
                    //unaCotizacion.unDetalleAsociado = DALSolicDetalle.MapearSolicDetalles
                    unaCotizacion.unProveedor = new Proveedor();
                    unaCotizacion.unProveedor.IdProveedor = (int)row["IdProveedor"];
                    unaCotizacion.unProveedor.AliasProv = row["AliasProv"].ToString();
                    unaCotizacion.unDetalleAsociado = new SolicDetalle();
                    unaCotizacion.unDetalleAsociado.IdSolicitudDetalle = (int)row["IdSolicitudDetalle"];
                    unaCotizacion.unDetalleAsociado.IdSolicitud = (int)row["IdSolicitud"];
                    unaCotizacion.unDetalleAsociado.UIDSolicDetalle = (int)row["UIDSolicDetalle"];


                    ResCotizaciones.Add(unaCotizacion);
                }
                return ResCotizaciones;
            }
            catch (Exception es)
            {

                throw;
            }
        }


        public static List<Cotizacion> MapearCotizacionesConIdPartida(DataSet ds)
        {
            List<Cotizacion> ResCotizaciones = new List<Cotizacion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Cotizacion unaCotizacion = new Cotizacion();

                    unaCotizacion.IdCotizacion = (int)row["IdCotizacion"];
                    if (row["FechaCotizacion"].ToString() != "")
                    {
                        unaCotizacion.FechaCotizacion = DateTime.Parse(row["FechaCotizacion"].ToString());
                    }
                    unaCotizacion.MontoCotizado = (decimal)row["MontoCotizado"];
                    //unaCotizacion.unDetalleAsociado = DALSolicDetalle.MapearSolicDetalles
                    unaCotizacion.unProveedor = new Proveedor();
                    unaCotizacion.unProveedor.IdProveedor = (int)row["IdProveedor"];
                    unaCotizacion.unProveedor.AliasProv = row["AliasProv"].ToString();
                    unaCotizacion.unaPartidaDetalleIDs = new PartidaDetalle();
                    unaCotizacion.unaPartidaDetalleIDs.IdPartidaDetalle = (int)row["IdPartidaDetalle"];
                    unaCotizacion.unaPartidaDetalleIDs.IdPartida = (int)row["IdPartida"];
                    unaCotizacion.unaPartidaDetalleIDs.UIDPartidaDetalle = (int)row["UIDPartidaDetalle"];


                    ResCotizaciones.Add(unaCotizacion);
                }
                return ResCotizaciones;
            }
            catch (Exception es)
            {

                throw;
            }
        }


        public List<Cotizacion> CotizacionTraerPorUIDPartidaDetalle(int UIDPartidaDetalle, int IdPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UIDPartidaDetalle", UIDPartidaDetalle),
                new SqlParameter("@IdPartida", IdPartida)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CotizacionTraerPorUIDPartidaDetalle", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    unaLista = MapearCotizacionesConIdPartida(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }


        public bool CotizacionAsociarConPartidaDetalle(int IdCotizacion, int UIDPartDetalle, int IdPartida)
        {
            try
            {

                SqlParameter[] parametersRelCotizSolicDetalle = new SqlParameter[]
			    {
                    new SqlParameter("@IdCotizacion", IdCotizacion),
                    new SqlParameter("@IdPartida", IdPartida),
                    new SqlParameter("@UIDPartidaDetalle", UIDPartDetalle)
			    };

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelCotizPartDetalleCrear", parametersRelCotizSolicDetalle);

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
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }





        //public bool CotizacionModifEnSolic(SolicDetalle unDetSolic, List<Cotizacion> CotiQuitarMod, List<Cotizacion> CotiAgregarMod)
        //{
        //    try
        //    {
        //        FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();

        //        if (CotiQuitarMod.Count > 0)
        //        {
        //            foreach (Cotizacion unaCoti in CotiQuitarMod)
        //            {
        //                //Elimina las relaciones entre cotiz y SolicDetalle
        //                SqlParameter[] parametersRelCotiDesasociar = new SqlParameter[]
        //                {
        //                    new SqlParameter("@IdSolicitudDetalle", unDetSolic.IdSolicitudDetalle),
        //                    new SqlParameter("@IdSolicitud", unDetSolic.IdSolicitud),
        //                    new SqlParameter("@IdCotizacion", unaCoti.IdCotizacion)
        //                };

        //                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CotiSolicDetDesasociar", parametersRelCotiDesasociar);

        //                //Elimina la cotizacion
        //                SqlParameter[] parametersCotiEliminar = new SqlParameter[]
        //                {
        //                    new SqlParameter("@IdCotizacion", unaCoti.IdCotizacion)
        //                };

        //                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CotizacionEliminar", parametersCotiEliminar);
        //            }
        //        }

        //        if (CotiAgregarMod.Count > 0)
        //        {
        //            foreach (Cotizacion unaCoti in CotiAgregarMod)
        //            {
        //                SqlParameter[] parametersCotiCrear = new SqlParameter[]
        //                {
        //                    new SqlParameter("@MontoCotizado", unaCoti.MontoCotizado),
        //                    new SqlParameter("@FechaCotizacion", unaCoti.FechaCotizacion),
        //                    new SqlParameter("@IdProveedor", unaCoti.unProveedor.IdProveedor)
        //                };

        //                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrear", parametersCotiCrear);
        //                int IdCotiRes = Decimal.ToInt32(Resultado);

        //                //Tabla de relacion
        //                SqlParameter[] parametersRelCotizSolicDetalle = new SqlParameter[]
        //                {
        //                    new SqlParameter("@IdSolicitudDetalle", unaCoti.unDetalleAsociado.IdSolicitudDetalle),
        //                    new SqlParameter("@IdSolicitud", unaCoti.unDetalleAsociado.IdSolicitud),
        //                    new SqlParameter("@IdCotizacion", IdCotiRes)
        //                };

        //                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrearRelSolicDetalle", parametersRelCotizSolicDetalle);
        //            }
        //        }
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
        //        return true;
        //    }
        //    catch (Exception es)
        //    {
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
        //        throw;
        //    }
        //    finally
        //    {
        //        if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
        //            FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
        //    }
        //}


        public int? CotizTraerRelPartDet(int IdCotizacion)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdCotizacion", IdCotizacion)
            };

            try
            {
                int? Resultado = (int?)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizTraerRelPartDet", parameters);
                return Resultado;
            }
            catch (Exception es)
            {
                throw;
            }
        }




        public List<Cotizacion> CotizacionTraerPorUIDSolicDetalle(int UIDSDet)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UIDSolicDetalle", UIDSDet)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSetPrueba(CommandType.StoredProcedure, "CotizacionTraerPorUIDSolicDetalle", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    unaLista = MapearCotizaciones(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ObtenerNombreAdjuntoCotiz(int IdCotizacion)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdCotizacion", IdCotizacion)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                string ResRuta = FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "ObtenerNombreAdjuntoCotiz", parameters).ToString();
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return ResRuta;
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
