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
                new SqlParameter("@FechaCompra ", unaAdquisicion.FechaCompra),
                new SqlParameter("@NroFactura", unaAdquisicion.NroFactura),
                new SqlParameter("@MontoCompra", unaAdquisicion.MontoCompra),
                new SqlParameter("@IdProveedor", unaAdquisicion.ProveedorAdquisicion.IdProveedor)
			};

            try
            {
                //SAQUE LO DE TRANSACCIOENS PORQUE LO HAGO EN LA BD PARA TODO LO QUE IMPLICA CREAR LA ADQUISICION Y LOS INVENTARIOS
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AdquisicionCrear", parametersAdq);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //foreach (SolicDetalle item in laSolicitud.unosDetallesSolicitud)
                //{

                //    SqlParameter[] parametersSolicitudDetalles = new SqlParameter[]
                //    {
                //        new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                //        new SqlParameter("@IdSolicitud", IDDevuelto),
                //        new SqlParameter("@IdCategoria", item.unaCategoria.IdCategoria),
                //        new SqlParameter("@Cantidad", item.Cantidad),
                //        new SqlParameter("@IdEstadoSolDetalle", item.unEstado.IdEstadoSolicDetalle)
                //    };

                //    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudDetalleCrear", parametersSolicitudDetalles);
                //}

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

            


    }
}
