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
    public class DALInventarioHard
    {

        public void InventarioHardCrear(Hardware unBien, int IdAdq)
        {
            SqlParameter[] parametersInvHard = new SqlParameter[]
			{
                new SqlParameter("@IdBienEspecif", unBien.IdBien),
                new SqlParameter("@SerieKey", unBien.unInventarioAlta.SerieKey),
                new SqlParameter("@IdDeposito", (unBien.unInventarioAlta as XInventarioHard).unDeposito.IdDeposito),
                new SqlParameter("@IdEstadoInventario", unBien.unInventarioAlta.unEstado.IdEstadoInventario),
                new SqlParameter("@Costo", unBien.unInventarioAlta.Costo)
			};



            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                //Guarda Inventario
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioHardCrear", parametersInvHard);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //Guarda asociación en tabla RelPdetAdq entre Inventario, PartidaDetalle y Adquisicion
                SqlParameter[] parametersRelPdetAdq = new SqlParameter[]
			    {
                    new SqlParameter("@IdInventario", IDDevuelto),
                    new SqlParameter("@IdPartida", unBien.unInventarioAlta.PartidaDetalleAsoc.PartidaAsociada.IdPartida),
                    new SqlParameter("@UIDPartidaDetalle", unBien.unInventarioAlta.PartidaDetalleAsoc.UIDPartidaDetalle),
                    new SqlParameter("@IdAdquisicion", IdAdq)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelPDetAdqCrear", parametersRelPdetAdq);

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





        public List<Hardware> InventarioHardTraerListosParaAsignar(SolicDetalle unSolicDetalle)
        {
            SqlParameter[] parametersInvHard = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", unSolicDetalle.SolicitudAsociada.IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", unSolicDetalle.IdSolicitudDetalle),
                new SqlParameter("@UIDSolicDetalle", unSolicDetalle.UIDSolicDetalle)
                //,
                //new SqlParameter("@IdEstadoSolicDetalle", unSolicDetalle.unEstado.IdEstadoSolicDetalle)
			};

            try
            {

                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "InventarioHardTraerListosParaAsignar", parametersInvHard))
                {
                    List<Hardware> unaLista = new List<Hardware>();
                    unaLista = MapearInventarioHard(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public List<Hardware> MapearInventarioHard(DataSet ds)
        {
            List<Hardware> ResInventariosHard = new List<Hardware>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Hardware unInven = new Hardware();

                    unInven.unInventarioAlta = new XInventarioHard();
                    unInven.unInventarioAlta.IdInventario = (int)row["IdInventario"];
                    unInven.unInventarioAlta.SerieKey = row["SerieKey"].ToString();
                    unInven.unInventarioAlta.deBien = new Hardware();
                    unInven.unInventarioAlta.deBien.IdBien = (int)row["IdBien"];
                    unInven.unInventarioAlta.deBien.DescripBien = row["DescripCategoria"].ToString();
                    unInven.unaMarca = new Marca();
                    unInven.unaMarca.DescripMarca = row["DescripMarca"].ToString();
                    unInven.unModelo = new ModeloVersion();
                    unInven.unModelo.DescripModeloVersion = row["DescripModeloVersion"].ToString();

                    ResInventariosHard.Add(unInven);
                }
                return ResInventariosHard;
            }
            catch (Exception es)
            {
                throw;
            }
        }




    }
}
