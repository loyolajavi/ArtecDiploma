using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Data.SqlClient;

namespace ARTEC.DAL
{
    public class DALInventarioSoft
    {
        public void InventarioSoftCrear(Software unBien, int IdAdq)
        {
            SqlParameter[] parametersInvSoft = new SqlParameter[]
			{
                new SqlParameter("@IdBienEspecif", unBien.IdBien),
                new SqlParameter("@SerieKey ", unBien.unInventarioAlta.SerieKey),
                new SqlParameter("@IdAdquisicion", IdAdq),
                new SqlParameter("@SerialMaster", (unBien.unInventarioAlta as XInventarioSoft).SerialMaster),
                new SqlParameter("@IdEstadoInventario", unBien.unInventarioAlta.unEstado.IdEstadoInventario),
                new SqlParameter("@IdPartidaDetalle", unBien.unInventarioAlta.PartidaDetalleAsoc.IdPartidaDetalle),
                new SqlParameter("@IdPartida", unBien.unInventarioAlta.PartidaDetalleAsoc.IdPartida)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioSoftCrear", parametersInvSoft);

                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public List<Software> InventarioSoftTraerListosParaAsignar(SolicDetalle unSolicDetalle)
        {
            SqlParameter[] parametersInvSoft = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", unSolicDetalle.IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", unSolicDetalle.IdSolicitudDetalle)//,
                //new SqlParameter("@IdEstadoSolicDetalle", unSolicDetalle.unEstado.IdEstadoSolicDetalle)
			};

            try
            {

                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "InventariosTraerListosParaAsignarPorSolicDetalle", parametersInvSoft))
                {
                    List<Software> unaLista = new List<Software>();
                    unaLista = MapearInventariosSoft(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public List<Software> MapearInventariosSoft(DataSet ds)
        {
            List<Software> ResInventariosSoft = new List<Software>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Software unInven = new Software();

                    unInven.unInventarioAlta = new XInventarioSoft();
                    unInven.unInventarioAlta.IdInventario = (int)row["IdInventario"];
                    unInven.unInventarioAlta.SerieKey = row["SerieKey"].ToString();
                    unInven.unaMarca = new Marca();
                    unInven.unaMarca.DescripMarca = row["DescripMarca"].ToString();
                    unInven.unModelo = new ModeloVersion();
                    unInven.unModelo.DescripModeloVersion = row["DescripModeloVersion"].ToString();

                    ResInventariosSoft.Add(unInven);
                }
                return ResInventariosSoft;
            }
            catch (Exception es)
            {
                throw;
            }
        }



    }
}
