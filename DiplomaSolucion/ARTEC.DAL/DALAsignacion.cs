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
    public class DALAsignacion
    {

        public int AsignacionCrear(Asignacion unaAsig)
        {
            DALEstadoInventario GestorEstadoInventario = new DALEstadoInventario();

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Fecha", unaAsig.Fecha),
                new SqlParameter("@IdDependencia", unaAsig.unaDependencia.IdDependencia)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsignacionCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                foreach (AsigDetalle item in unaAsig.unosAsigDetalles)
                {

                    SqlParameter[] parametersAsigDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdAsigDetalle", item.IdAsigDetalle),
                        new SqlParameter("@IdAsignacion", IDDevuelto),
                        new SqlParameter("@IdInventario", item.unInventario.IdInventario),
                        new SqlParameter("@IdSolicitudDetalle", item.SolicDetalleAsoc.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", item.SolicDetalleAsoc.IdSolicitud)
                        //VER TEMA DE HARD SOFT POR LO DEL AGENTE
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsigDetalleCrear", parametersAsigDetalles);
                    
                    //Actualizar Estado Inventario
                    GestorEstadoInventario.InventarioEstadoUpdate(item.unInventario.IdInventario, EstadoInventario.EnumEstadoInventario.Entregado);

                    //PRUEBA DE PONER ESTO EN BLLAsignacion; SI ANDA QUITAR
                    //DALInventario GestorInventario = new DALInventario();
                    //if (item.SolicDetalleAsoc.Cantidad == GestorInventario.InventarioEntregadoPorSolicDetalle(item.SolicDetalleAsoc.IdSolicitudDetalle, item.SolicDetalleAsoc.IdSolicitud))
                    //{
                    //    DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();
                    //    //EN ESTE METODO CIERRO LA CONEXION A LA BD Y DPS EN LA SEGUNDA VUELTA DEL FOR EACH PINCHA PORQ ESTA CERRADA LA BD
                    //    GestorSolicDetalle.SolicDetalleUpdateEstado(item.SolicDetalleAsoc.IdSolicitud, item.SolicDetalleAsoc.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado);
                    //}

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
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }


        public List<Asignacion> AsignacionBuscar(string IdAsignacion, string NombreDependencia, string IdSolicitud, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(IdAsignacion))
                parameters.Add(new SqlParameter("@IdAsignacion", Int32.Parse(IdAsignacion)));
            if (!string.IsNullOrEmpty(NombreDependencia))
                parameters.Add(new SqlParameter("@NombreDependencia", NombreDependencia));
            if (!string.IsNullOrEmpty(IdSolicitud))
                parameters.Add(new SqlParameter("@IdSolicitud", Int32.Parse(IdSolicitud)));
            if (fechaDesde != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaDesde", fechaDesde));
            if (fechaHasta != DateTime.MinValue)
                parameters.Add(new SqlParameter("@fechaHasta", fechaHasta));
     

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AsignacionBuscar", parameters.ToArray()))
                {
                    List<Asignacion> unaLis = new List<Asignacion>();
                    unaLis = MapearUnasAsignaciones(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<Asignacion> MapearUnasAsignaciones(DataSet ds)
        {
            List<Asignacion> unasAsignaciones = new List<Asignacion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Asignacion ResAsignacion = new Asignacion();
                    ResAsignacion.IdAsignacion = (int)row["IdAsignacion"];
                    ResAsignacion.Fecha = DateTime.Parse(row["Fecha"].ToString());
                    ResAsignacion.unaDependencia = new Dependencia();
                    ResAsignacion.unaDependencia.IdDependencia = (int)row["IdDependencia"];
                    ResAsignacion.unaDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    ResAsignacion.unosAsigDetalles = new List<AsigDetalle>();
                    AsigDetalle unAsigDet = new AsigDetalle();
                    unAsigDet.SolicDetalleAsoc = new SolicDetalle();
                    unAsigDet.SolicDetalleAsoc.IdSolicitud = (int)row["IdSolicitud"];
                    ResAsignacion.unosAsigDetalles.Add(unAsigDet);

                    unasAsignaciones.Add(ResAsignacion);
                }
                return unasAsignaciones;
            }

            catch (Exception es)
            {
                throw;
            }
        }




        public List<Inventario> AsignacionTraerBienesAsignados(int IdAsignacion)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdAsignacion", IdAsignacion)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AsignacionTraerBienesAsignados", parameters))
                {
                    List<Inventario> unaLis = new List<Inventario>();
                    unaLis = MapearInventario(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        private List<Inventario> MapearInventario(DataSet ds)
        {
            List<Inventario> ResInventarios = new List<Inventario>();
            Inventario uno;

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    int IdTipoAUX = (int)row["IdTipoBien"];
                    if (IdTipoAUX == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        uno = new XInventarioHard();
                    }
                    else
                    {
                        uno = new XInventarioSoft();
                    }
                    uno.IdInventario = (int)row["IdInventario"];
                    uno.IdBienEspecif = (int)row["IdBien"];
                    uno.unTipoBien = (int)row["IdTipoBien"];
                    //if (uno.TipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    //{
                    //    (uno as XInventarioSoft).SerialMaster = row["SerialMaster"].ToString();
                    //}
                    //uno.unEstado = new EstadoInventario();
                    //uno.unEstado.IdEstadoInventario = (int)row["IdEstadoInventario"];
                    uno.SerieKey = row["SerieKey"].ToString();
                    //uno.PartidaDetalleAsoc = new PartidaDetalle();
                    //uno.PartidaDetalleAsoc.IdPartida = (int)row["IdPartida"];
                    //uno.PartidaDetalleAsoc.UIDPartidaDetalle = (int)row["UIDPartidaDetalle"];
                    //if (uno.TipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    //{
                    //    (uno as XInventarioHard).unDeposito = new Deposito();
                    //    (uno as XInventarioHard).unDeposito.IdDeposito = (int)row["IdDeposito"];
                    //}
                    //uno.unaAdquisicion = new Adquisicion();
                    //uno.unaAdquisicion.IdAdquisicion = (int)row["IdAdquisicion"];
                    uno.deBien = new Hardware();
                    uno.deBien.DescripBien = row["DescripCategoria"].ToString(); ;

                    ResInventarios.Add(uno);
                }

            }
            catch (Exception es)
            {
                throw;
            }
            return ResInventarios;
        }




        public bool AsignacionModificar(Asignacion unaAsignacionModif, List<Inventario> InvQuitarMod, List<Inventario> InvAgregarMod)
        {
            DALEstadoInventario GestorEstadoInventario = new DALEstadoInventario();
            DALInventario GestorInventario = new DALInventario();
            DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();
            int ConteoDetalles = unaAsignacionModif.unosAsigDetalles.Count;
            
            SqlParameter[] parametersAsigModif = new SqlParameter[]
			{
                new SqlParameter("@Fecha", unaAsignacionModif.Fecha),
                new SqlParameter("@IdAsignacion", unaAsignacionModif.IdAsignacion)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "AsignacionModificar", parametersAsigModif);


                if (InvQuitarMod.Count > 0)
                {
                    foreach (Inventario unInv in InvQuitarMod)
                    {
                        int IdSolicDetalleAUX = unaAsignacionModif.unosAsigDetalles.Where(x => x.unInventario != null && x.unInventario.IdInventario == unInv.IdInventario).First().SolicDetalleAsoc.IdSolicitudDetalle;
                        int IdSolicitudAUX = unaAsignacionModif.unosAsigDetalles.First().SolicDetalleAsoc.IdSolicitud;
                        int IdAsigDetalleAUX = unaAsignacionModif.unosAsigDetalles.Where(x => x.unInventario != null && x.unInventario.IdInventario == unInv.IdInventario).First().IdAsigDetalle;

                        //Eliminar el AsigDetalle
                        SqlParameter[] parametersAsigDetallesEliminar = new SqlParameter[]
			            {
                            new SqlParameter("@IdAsigDetalle", IdAsigDetalleAUX),
                            new SqlParameter("@IdAsignacion", unaAsignacionModif.IdAsignacion)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsigDetalleEliminar", parametersAsigDetallesEliminar);
                        unaAsignacionModif.unosAsigDetalles.RemoveAll(x => x.IdAsigDetalle == IdAsigDetalleAUX);

                        //Reordenar los IdAsigDetalles
                        if (unaAsignacionModif.unosAsigDetalles.Count > 0 && IdAsigDetalleAUX < unaAsignacionModif.unosAsigDetalles.Last().IdAsigDetalle)
                        {
                            foreach (AsigDetalle unAsigDet in unaAsignacionModif.unosAsigDetalles)
                            {
                                if (unAsigDet.IdAsigDetalle > IdAsigDetalleAUX)
                                {
                                    SqlParameter[] parametersAsigDetallesReordenar = new SqlParameter[]
			                        {
                                        new SqlParameter("@IdAsigDetalle", unAsigDet.IdAsigDetalle),
                                        new SqlParameter("@IdAsignacion", unaAsignacionModif.IdAsignacion)
			                        };
                                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "AsigDetalleReordenar", parametersAsigDetallesReordenar);
                                    unAsigDet.IdAsigDetalle--;
                                }
                            }
                        }

                        //Actualizar Estado Inventario
                        GestorEstadoInventario.InventarioEstadoUpdate(unInv.IdInventario, EstadoInventario.EnumEstadoInventario.Disponible);

                        //Actualizar EstadoSolicDetalle a "Adquirido"
                        SqlParameter[] parametersEstadoSolicDetRevertir = new SqlParameter[]
                            {
                                new SqlParameter("@IdSolicitud", IdSolicitudAUX),
                                new SqlParameter("@IdSolicDetalle", IdSolicDetalleAUX),
                                new SqlParameter("@NuevoEstado", (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido)
                            };
                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parametersEstadoSolicDetRevertir);
                    }
                }

                if (InvAgregarMod.Count > 0)
                {
                    foreach (Inventario unInv in InvAgregarMod)
                    {

                        int IdSolicDetalleAUX = unaAsignacionModif.unosAsigDetalles.Where(x => x.unInventario != null && x.unInventario.IdInventario == unInv.IdInventario).First().SolicDetalleAsoc.IdSolicitudDetalle;
                        int IdSolicitudAUX = unaAsignacionModif.unosAsigDetalles.First().SolicDetalleAsoc.IdSolicitud;

                        SqlParameter[] parametersAsigDetalles = new SqlParameter[]
			            {
                            new SqlParameter("@IdAsigDetalle", ConteoDetalles),
                            new SqlParameter("@IdAsignacion", unaAsignacionModif.IdAsignacion),
                            new SqlParameter("@IdInventario", unInv.IdInventario),
                            new SqlParameter("@IdSolicitudDetalle", IdSolicDetalleAUX),
                            new SqlParameter("@IdSolicitud", IdSolicitudAUX)
                            //VER TEMA DE HARD SOFT POR LO DEL AGENTE
			             };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsigDetalleCrear", parametersAsigDetalles);
                        ConteoDetalles++;

                        //Actualizar Estado Inventario
                        GestorEstadoInventario.InventarioEstadoUpdate(unInv.IdInventario, EstadoInventario.EnumEstadoInventario.Entregado);

                        //Actualizar EstadoSolicDetalle si es que todos los inv fueron entregados
                        if (unaAsignacionModif.unosAsigDetalles.Where(x => x.unInventario != null && x.unInventario.IdInventario == unInv.IdInventario).First().SolicDetalleAsoc.Cantidad == GestorInventario.InventarioEntregadoPorSolicDetalle2(IdSolicDetalleAUX, IdSolicitudAUX))
                        {
                            SqlParameter[] parametersEstadoSolicDet = new SqlParameter[]
                            {
                                new SqlParameter("@IdSolicitud", IdSolicitudAUX),
                                new SqlParameter("@IdSolicDetalle", IdSolicDetalleAUX),
                                new SqlParameter("@NuevoEstado", (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado)
                            };
                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parametersEstadoSolicDet);
                        }
                    }
                }
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
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

        public List<AsigDetalle> AsigDetallesTraer(int IdAsignacion)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdAsignacion", IdAsignacion)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AsigDetallesTraer", parameters))
                {
                    List<AsigDetalle> unaLis = new List<AsigDetalle>();
                    unaLis = MapearAsigDetalles(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        private List<AsigDetalle> MapearAsigDetalles(DataSet ds)
        {
            List<AsigDetalle> unosAsigDetalles = new List<AsigDetalle>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    AsigDetalle ResAsigDetalle = new AsigDetalle();
                    ResAsigDetalle.IdAsignacion = (int)row["IdAsignacion"];
                    ResAsigDetalle.IdAsigDetalle = (int)row["IdAsigDetalle"];
                    ResAsigDetalle.SolicDetalleAsoc = new SolicDetalle();
                    ResAsigDetalle.SolicDetalleAsoc.IdSolicitud = (int)row["IdSolicitud"];
                    ResAsigDetalle.SolicDetalleAsoc.IdSolicitudDetalle = (int)row["IdSolicitudDetalle"];
                    unosAsigDetalles.Add(ResAsigDetalle);
                }
                return unosAsigDetalles;
            }

            catch (Exception es)
            {
                throw;
            }
        }
    }
}
