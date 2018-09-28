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
    public class DALAdquisicion
    {

        public int AdquisicionCrear(Adquisicion unaAdquisicion)
        {
            SqlParameter[] parametersAdq = new SqlParameter[]
			{
                new SqlParameter("@FechaAdq", unaAdquisicion.FechaAdq),
                new SqlParameter("@FechaCompra", unaAdquisicion.FechaCompra),
                new SqlParameter("@NroFactura", unaAdquisicion.NroFactura),
                new SqlParameter("@MontoCompra", unaAdquisicion.MontoCompra),
                new SqlParameter("@IdProveedor", unaAdquisicion.ProveedorAdquisicion.IdProveedor)
			};

            try
            {
                //SAQUE LO DE TRANSACCIOENS PORQUE LO HAGO EN LA BLL de Adquisición TODO LO QUE IMPLICA CREAR LA ADQUISICION Y LOS INVENTARIOS
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AdquisicionCrear", parametersAdq);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return IDDevuelto;
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    //FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}


        }

        public void ComenzarAdquisicion()
        {
            FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
            FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
        }

        public void ConfirmarAdquisicion(){
            FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
        }
            

        public void CancelarAdquisicion(){
            FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
        }

        public void TerminarAdquisicion(){
            FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
        }





        public List<Adquisicion> AdquisicionBuscar(string IdAdquisicion, string IdPartida, string NombreDependencia, DateTime? unaFecha, DateTime? unaFechaCompra, string NroFactura, string IdSolicitud)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(IdAdquisicion))
                parameters.Add(new SqlParameter("@IdAdquisicion", Int32.Parse(IdAdquisicion)));
            if (!string.IsNullOrEmpty(IdPartida))
                parameters.Add(new SqlParameter("@IdPartida", Int32.Parse(IdPartida)));
            if (!string.IsNullOrEmpty(NombreDependencia))
                parameters.Add(new SqlParameter("@NombreDependencia", NombreDependencia));
            if (unaFecha != DateTime.MinValue)
                parameters.Add(new SqlParameter("@unaFecha", unaFecha));
            if (unaFechaCompra != DateTime.MinValue)
                parameters.Add(new SqlParameter("@unaFechaCompra", unaFechaCompra));
            if (!string.IsNullOrEmpty(NroFactura))
                parameters.Add(new SqlParameter("@NroFactura", NroFactura));
            if (!string.IsNullOrEmpty(IdSolicitud))
                parameters.Add(new SqlParameter("@IdSolicitud", Int32.Parse(IdSolicitud)));
            
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AdquisicionBuscar", parameters.ToArray()))
                {
                    List<Adquisicion> unaLis = new List<Adquisicion>();
                    unaLis = MapearUnasAdquisiciones(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static List<Adquisicion> MapearUnasAdquisiciones(DataSet ds)
        {
            List<Adquisicion> unasAdquisiciones = new List<Adquisicion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Adquisicion ResAdquisicion = new Adquisicion();
                    ResAdquisicion.IdAdquisicion = (int)row["IdAdquisicion"];
                    ResAdquisicion.FechaAdq = DateTime.Parse(row["FechaAdq"].ToString());
                    ResAdquisicion.FechaCompra = DateTime.Parse(row["FechaCompra"].ToString());
                    ResAdquisicion.NroFactura = row["NroFactura"].ToString();
                    ResAdquisicion.MontoCompra = (decimal)row["MontoCompra"];
                    ResAdquisicion.ProveedorAdquisicion = new Proveedor();
                    ResAdquisicion.ProveedorAdquisicion.IdProveedor = (int)row["IdProveedor"];
                    ResAdquisicion.ProveedorAdquisicion.AliasProv = row["AliasProv"].ToString();
                    ResAdquisicion.unaDependencia = new Dependencia();
                    ResAdquisicion.unaDependencia.IdDependencia = (int)row["IdDependencia"];
                    ResAdquisicion.unaDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    ResAdquisicion.unIdPartida = (int)row["IdPartida"];
                    ResAdquisicion.unIdSolicitud = (int)row["IdSolicitud"];

                    unasAdquisiciones.Add(ResAdquisicion);
                }
                return unasAdquisiciones;
            }

            catch (Exception es)
            {
                throw;
            }
        }

        public List<Inventario> AdquisicionInventariosAsoc(string IdPartida, string IdAdquisicion)
        {
            SqlParameter[] parametersAdqInvAsoc = new SqlParameter[]
			{
                new SqlParameter("@IdPartida", Int32.Parse(IdPartida)),
                new SqlParameter("@IdAdquisicion", Int32.Parse(IdAdquisicion))
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AdquisicionInventariosAsoc", parametersAdqInvAsoc))
                {
                    List<Inventario> unaLis = new List<Inventario>();
                    unaLis = MapearUnosInventarios(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        private List<Inventario> MapearUnosInventarios(DataSet ds)
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
                        uno.deBien = new Hardware();
                    }
                    else
                    {
                        uno = new XInventarioSoft();
                        uno.deBien = new Software();
                    }
                    uno.IdInventario = (int)row["IdInventario"];
                    uno.IdBienEspecif = (int)row["IdBien"];
                    uno.deBien.IdBien = (int)row["IdBien"];
                    uno.deBien.DescripBien = row["DescripCategoria"].ToString();
                    uno.deBien.unaMarca = new Marca();
                    uno.deBien.unaMarca.IdMarca = (int)row["IdMarca"];
                    uno.deBien.unaMarca.DescripMarca = row["DescripMarca"].ToString();
                    uno.deBien.unModelo = new ModeloVersion();
                    uno.deBien.unModelo.IdModeloVersion = (int)row["IdModeloVersion"];
                    uno.deBien.unModelo.DescripModeloVersion = row["DescripModeloVersion"].ToString();
                    uno.unTipoBien = (int)row["IdTipoBien"];
                    if (uno.unTipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        (uno as XInventarioSoft).SerialMaster = row["SerialMaster"].ToString();
                    }
                    uno.unEstado = new EstadoInventario();
                    //uno.unEstado.IdEstadoInventario = (int)row["IdEstadoInventario"];
                    uno.SerieKey = row["SerieKey"].ToString();
                    uno.PartidaDetalleAsoc = new PartidaDetalle();
                    uno.PartidaDetalleAsoc.IdPartida = (int)row["IdPartida"];
                    uno.PartidaDetalleAsoc.UIDPartidaDetalle = (int)row["UIDPartidaDetalle"];
                    if (uno.unTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        (uno as XInventarioHard).unDeposito = new Deposito();
                        (uno as XInventarioHard).unDeposito.IdDeposito = (int)row["IdDeposito"];
                    }
                    uno.unaAdquisicion = new Adquisicion();
                    uno.unaAdquisicion.IdAdquisicion = (int)row["IdAdquisicion"];

                    uno.Costo = (decimal)row["Costo"];

                    ResInventarios.Add(uno);
                }

            }
            catch (Exception es)
            {
                throw;
            }
            return ResInventarios;
        }





        public bool AdquisicionModificar(Adquisicion unaAdqModif, List<Inventario> InvQuitarMod, List<Inventario> InvAgregarMod)
        {
            DALEstadoInventario GestorEstadoInventario = new DALEstadoInventario();
            DALInventario GestorInventario = new DALInventario();
            DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();

            SqlParameter[] parametersAdqModif = new SqlParameter[]
			{
                new SqlParameter("@IdAdquisicion", unaAdqModif.IdAdquisicion),
                new SqlParameter("@FechaAdq", unaAdqModif.FechaAdq),
                new SqlParameter("@FechaCompra", unaAdqModif.FechaCompra),
                new SqlParameter("@NroFactura", unaAdqModif.NroFactura),
                new SqlParameter("@MontoCompra", unaAdqModif.MontoCompra),
                new SqlParameter("@IdProveedor", unaAdqModif.ProveedorAdquisicion.IdProveedor)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "AdquisicionModificar", parametersAdqModif);


                if (InvQuitarMod.Count > 0)
                {
                    foreach (Inventario unInv in InvQuitarMod)
                    {
                        //Actualizar SolicDetalle a "Comprar" (Revierto desde Adquirido)
                        SqlParameter[] parametersEstadoSolicDetRevertir = new SqlParameter[]
                            {
                                new SqlParameter("@IdSolicitud", unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud),
                                new SqlParameter("@IdSolicDetalle", unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle),
                                new SqlParameter("@NuevoEstado", (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar)
                            };
                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parametersEstadoSolicDetRevertir);

                        //Eliminar el RelPDetAdq
                        SqlParameter[] parametersRelPDetAdqEliminar = new SqlParameter[]
			            {
                            new SqlParameter("@IdAdquisicion", unaAdqModif.IdAdquisicion),
                            new SqlParameter("@IdInventario", unInv.IdInventario)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelPdetAdqEliminar", parametersRelPDetAdqEliminar);

                        //Eliminar el Inventario
                        SqlParameter[] parametersInventarioEliminar = new SqlParameter[]
                            {
                                new SqlParameter("@IdInventario", unInv.IdInventario)
                            };
                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "InventarioEliminar", parametersInventarioEliminar);


                    }
                }

                if (InvAgregarMod.Count > 0)
                {
                    foreach (Inventario unInv in InvAgregarMod)
                    {
                        int IDDevuelto;
                        if (unInv.unTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                        {
                            SqlParameter[] parametersInvHard = new SqlParameter[]
			                {
                                new SqlParameter("@IdBienEspecif", unInv.IdBienEspecif),
                                new SqlParameter("@SerieKey", unInv.SerieKey),
                                new SqlParameter("@IdDeposito", unInv.unDeposito.IdDeposito),
                                new SqlParameter("@IdEstadoInventario", unInv.unEstado.IdEstadoInventario),
                                new SqlParameter("@Costo", unInv.Costo)
			                };
                            //Guarda Inventario
                            var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioHardCrear", parametersInvHard);
                            IDDevuelto = Decimal.ToInt32(Resultado);
                        }
                        else
                        {
                            SqlParameter[] parametersInvSoft = new SqlParameter[]
			                {
                                new SqlParameter("@IdBienEspecif", unInv.IdBienEspecif),
                                new SqlParameter("@SerieKey ", unInv.SerieKey),
                                new SqlParameter("@SerialMaster", ""),
                                new SqlParameter("@IdEstadoInventario", unInv.unEstado.IdEstadoInventario),
                                new SqlParameter("@Costo", unInv.Costo)
			                };
                            //Guarda Inventario
                            var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioSoftCrear", parametersInvSoft);
                            IDDevuelto = Decimal.ToInt32(Resultado);

                        }

                        //Guarda asociación en tabla RelPdetAdq entre Inventario, PartidaDetalle y Adquisicion
                        SqlParameter[] parametersRelPdetAdq = new SqlParameter[]
			            {
                            new SqlParameter("@IdInventario", IDDevuelto),
                            new SqlParameter("@IdPartida", unaAdqModif.unIdPartida),
                            new SqlParameter("@UIDPartidaDetalle", unInv.PartidaDetalleAsoc.UIDPartidaDetalle),
                            new SqlParameter("@IdAdquisicion", unaAdqModif.IdAdquisicion)
			            };
                        FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelPDetAdqCrear", parametersRelPdetAdq);
                        
                        //Actualizar EstadoSolicDetalle si es que todos los inv fueron adquiridos
                            //Busco Cantidad, IdSolicitud y IdSolicDetalle
                            SqlParameter[] parametersCantUIDSolicDetalle = new SqlParameter[]
                                {
                                    new SqlParameter("@IdSolicitud", unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud),
                                    new SqlParameter("@IdSolicitudDetalle", unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle)
                                };
                            int ResCantidad = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicDetalleCantidadPorUIDSolicDetalle", parametersCantUIDSolicDetalle);
                        
                            //Busco Cantidad de Inventarios adquiridos asociados al SolicDetalle
                            SqlParameter[] parametersCantInvCompradoPorUIDPartidaDetalle = new SqlParameter[]
                                {
                                    new SqlParameter("@UIDPartidaDetalle", unInv.PartidaDetalleAsoc.UIDPartidaDetalle)
                                };
                            int CantComprada = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InvAdquiridosPorUIDPartidaDetalle", parametersCantInvCompradoPorUIDPartidaDetalle);
                        
                        //La comprobación
                        if (ResCantidad == CantComprada)
                        {
                            SqlParameter[] parametersEstadoSolicDetModif = new SqlParameter[]
                            {
                                new SqlParameter("@IdSolicitud", unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud),
                                new SqlParameter("@IdSolicDetalle", unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle),
                                new SqlParameter("@NuevoEstado", (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido)
                            };
                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parametersEstadoSolicDetModif);
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

        public bool AdquisicionEliminar(Adquisicion unaAdqModif)
        {
            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();

                //Colocar todos los SolicDetalle en "Comprar" (Revierto desde Adquirido)
                foreach (Inventario unInven in unaAdqModif.unosInventariosAsoc)
                {
                    SqlParameter[] parametersEstadoSolicDetRevertir = new SqlParameter[]
                            {
                                new SqlParameter("@IdSolicitud", unInven.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud),
                                new SqlParameter("@IdSolicDetalle", unInven.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle),
                                new SqlParameter("@NuevoEstado", (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar)
                            };
                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetalleUpdateEstado", parametersEstadoSolicDetRevertir);
                }
                
                //Eliminar todos los RelPDetAdq
                SqlParameter[] parametersRelPDetAdqEliminar = new SqlParameter[]
			            {
                            new SqlParameter("@IdAdquisicion", unaAdqModif.IdAdquisicion)
			            };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelPdetAdqEliminarTodosPorIdAdq", parametersRelPDetAdqEliminar);

                //Eliminar todos los Inventarios
                foreach (Inventario unInven in unaAdqModif.unosInventariosAsoc)
                {
                    SqlParameter[] parametersInventarioEliminar = new SqlParameter[]
                            {
                                new SqlParameter("@IdInventario", unInven.IdInventario)
                            };
                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "InventarioEliminar", parametersInventarioEliminar);
                }
               
                //Eliminar la adquisicion
                SqlParameter[] parametersAdqEliminar = new SqlParameter[]
                            {
                                new SqlParameter("@IdAdquisicion", unaAdqModif.IdAdquisicion)
                            };
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "AdquisicionEliminar", parametersAdqEliminar);
                
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (FilasAfectadas > 0)
                    return true;
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
