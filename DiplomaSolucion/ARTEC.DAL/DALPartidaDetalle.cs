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
    public class DALPartidaDetalle
    {

        public List<PartidaDetalle> PartidaDetalleTraerTodosPorNroPart(int NroPart)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", NroPart)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PartidaDetalleTraerTodosPorNroPart", parameters))
                {
                    List<PartidaDetalle> unaListaPartidaDetalles = new List<PartidaDetalle>();
                    unaListaPartidaDetalles = MapearPartidaDetalles(ds);
                    return unaListaPartidaDetalles;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }


        
        private List<PartidaDetalle> MapearPartidaDetalles(DataSet ds)
        {
            List<PartidaDetalle> ResPartidaDetalles = new List<PartidaDetalle>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    PartidaDetalle unDet = new PartidaDetalle();
                    unDet.IdPartida = (int)row["IdPartida"];
                    unDet.IdPartidaDetalle = (int)row["IdPartidaDetalle"];
                    unDet.SolicDetalleAsociado = new SolicDetalle();
                    unDet.SolicDetalleAsociado.IdSolicitud = (int)row["IdSolicitud"];
                    unDet.SolicDetalleAsociado.IdSolicitudDetalle = (int)row["IdSolicitudDetalle"];
                    unDet.SolicDetalleAsociado.unaCategoria.DescripCategoria = row["DescripCategoria"].ToString();
                    unDet.SolicDetalleAsociado.Cantidad = (int)row["Cantidad"];

                    ResPartidaDetalles.Add(unDet);
                }

            }
            catch (Exception es)
            {
            }
            return ResPartidaDetalles;
        }



        private PartidaDetalle MapearPartidaDetalleUNO(DataSet ds)
        {
            PartidaDetalle unDet = new PartidaDetalle();
            
            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    
                    unDet.IdPartida = (int)row["IdPartida"];
                    unDet.IdPartidaDetalle = (int)row["IdPartidaDetalle"];
                    unDet.SolicDetalleAsociado = new SolicDetalle();
                    unDet.SolicDetalleAsociado.IdSolicitud = (int)row["IdSolicitud"];
                    unDet.SolicDetalleAsociado.IdSolicitudDetalle = (int)row["IdSolicitudDetalle"];
                    //unDet.SolicDetalleAsociado.unaCategoria.DescripCategoria = row["DescripCategoria"].ToString();
                    //unDet.SolicDetalleAsociado.Cantidad = (int)row["Cantidad"];
                }

            }
            catch (Exception es)
            {
                throw; //VER
            }
            return unDet;
        }



        public List<SolicDetalle> CategoriaDetBienesTraerPorIdPartida(int IdPartida)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", IdPartida)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaDetBienesTraerPorIdPartida", parameters))
                {
                    List<SolicDetalle> unaLista = new List<SolicDetalle>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<SolicDetalle>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }


        }



        public List<ENTIDADES.Helpers.HLPDetallesAdquisicion> InventarioAdquiridoCantPorPartDetalle(int IdPartida)
        {

            SqlParameter[] parameters2 = new SqlParameter[]
            {
                new SqlParameter("@IdPartida2", IdPartida)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "InventarioAdquiridoCantPorPartDetalle", parameters2))
                {
                    List<ENTIDADES.Helpers.HLPDetallesAdquisicion> unaLista = new List<ENTIDADES.Helpers.HLPDetallesAdquisicion>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<ENTIDADES.Helpers.HLPDetallesAdquisicion>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }






        public int PartidaDetallePorIdCategoriaIdPartida(int NroPart, int IdCat)
        {

            SqlParameter[] parametersPartDet = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", NroPart),
                new SqlParameter("@IdCategoria", IdCat)
            };


            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int Resultado = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "PartidaDetallePorIdCategoriaIdPartida", parametersPartDet);
                //int IDDevuelto = Decimal.ToInt32(Resultado);

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return Resultado;
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



        public PartidaDetalle SolicDetallePartidaDetalleAsociacionTraer(int IdSolic, int IdSolicDetalle)
        {

            SqlParameter[] parametersPartDet = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitud", IdSolic),
                new SqlParameter("@IdSolicDetalle", IdSolicDetalle)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicDetallePartidaDetalleAsociacionTraer", parametersPartDet))
                {
                    PartidaDetalle unaPartidaDetalle = new PartidaDetalle();
                    unaPartidaDetalle = MapearPartidaDetalleUNO(ds);
                    return unaPartidaDetalle;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



    }
}
