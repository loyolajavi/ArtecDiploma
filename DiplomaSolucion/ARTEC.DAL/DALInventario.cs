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

        public int InventarioEntregadoPorSolicDetalle(int IdSolicitudDetalle, int IdSolicitud)
        {
            SqlParameter[] parametersInvCantEntregado = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", IdSolicitudDetalle)
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
                    uno.TipoBien = (int)row["IdTipoBien"];
                    if(uno.TipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        (uno as XInventarioSoft).SerialMaster = row["SerialMaster"].ToString();
                    }
                    uno.unEstado = new EstadoInventario();
                    uno.unEstado.IdEstadoInventario = (int)row["IdEstadoInventario"];
                    uno.SerieKey = row["SerieKey"].ToString();
                    uno.PartidaDetalleAsoc = new PartidaDetalle();
                    uno.PartidaDetalleAsoc.IdPartida = (int)row["IdPartida"];
                    uno.PartidaDetalleAsoc.UIDPartidaDetalle = (int)row["UIDPartidaDetalle"];
                    if (uno.TipoBien == (int)TipoBien.EnumTipoBien.Hard)
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




    }
}
