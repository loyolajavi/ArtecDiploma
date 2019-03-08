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
    public class DALInventario
    {

        public int InventarioEntregadoPorSolicDetalle(int IdSolicitudDetalle, int IdSolicitud, int UIDSolicDetalle)
        {
            SqlParameter[] parametersInvCantEntregado = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", IdSolicitudDetalle),
                new SqlParameter("@UIDSolicDetalle", UIDSolicDetalle)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                int CantInv = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioEntregadoPorSolicDetalle", parametersInvCantEntregado);
                return CantInv;
            }
            catch (Exception es)
            {
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }



        public int InventarioEntregadoPorSolicDetalle2(int IdSolicitudDetalle, int IdSolicitud, int UIDSolicDetalle)
        {
            SqlParameter[] parametersInvCantEntregado = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", IdSolicitudDetalle),
                new SqlParameter("@UIDSolicDetalle", UIDSolicDetalle)
			};

            try
            {
                int CantInv = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioEntregadoPorSolicDetalle", parametersInvCantEntregado);
                return CantInv;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public List<Inventario> InventariosTraerListosParaAsignar(int IdSolicitud)
        {
             SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", IdSolicitud)
			};

             try
             {
                 using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "InventariosTraerListosParaAsignar", parameters))
                 {
                     List<Inventario> unaLista = new List<Inventario>();
                     unaLista = MapearInventario(ds);
                     return unaLista;
                 }
             }
             catch (Exception es)
             {
                 //VER:
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
                    if(uno.unTipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        (uno as XInventarioSoft).SerialMaster = row["SerialMaster"].ToString();
                    }
                    uno.unEstado = new EstadoInventario();
                    uno.unEstado.IdEstadoInventario = (int)row["IdEstadoInventario"];
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
                    
                    ResInventarios.Add(uno);
                }

            }
            catch (Exception es)
            {
                //VER:
                throw;
            }
            return ResInventarios;
        }


        //NO LO USO BORRAR DPS DDEL 27/10/2017
        //public List<Inventario> InventariosTraerListosParaAsignarPorSolicDetalle(int IdSolicitud, int IdSolDetalle)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@IdSolicitud", IdSolicitud),
        //        new SqlParameter("@IdSolicDetalle", IdSolDetalle),
        //    };

        //    try
        //    {
        //        using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "InventariosTraerListosParaAsignarPorSolicDetalle", parameters))
        //        {
        //            List<Inventario> unaLista = new List<Inventario>();
        //            unaLista = MapearInventario(ds);
        //            return unaLista;
        //        }
        //    }
        //    catch (Exception es)
        //    {
        //        //VER:
        //        throw;
        //    }
        //}





        public EstadoInventario InventarioTraerEstadoPorIdInventario(int IdInventario)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdInventario", IdInventario)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "InventarioTraerEstadoPorIdInventario", parameters))
                {
                    EstadoInventario unEstInv = new EstadoInventario();
                    unEstInv = MapearEstadoInventario(ds);
                    return unEstInv;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        private EstadoInventario MapearEstadoInventario(DataSet ds)
        {
            EstadoInventario ResEstInventarios = new EstadoInventario();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ResEstInventarios.IdEstadoInventario = (int)row["IdEstadoInventario"];
                    ResEstInventarios.DescripEstadoInv = row["DescripEstadoInv"].ToString();
                }
            }
            catch (Exception es)
            {
                throw;
            }
            return ResEstInventarios;
        }



        public void InventarioModificar(Inventario unInvModif)
        {
            SqlParameter[] parametersInvModif = new SqlParameter[]
			{
                new SqlParameter("@IdInventario", unInvModif.IdInventario),
                new SqlParameter("@IdBien", unInvModif.IdBienEspecif),
                new SqlParameter("@SerieKey", unInvModif.SerieKey),
                new SqlParameter("@Costo", unInvModif.Costo),
                new SqlParameter("@MontoCompra", unInvModif.unaAdquisicion.MontoCompra),
                new SqlParameter("@IdAdquisicion", unInvModif.unaAdquisicion.IdAdquisicion)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "InventarioModificar", parametersInvModif);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
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
