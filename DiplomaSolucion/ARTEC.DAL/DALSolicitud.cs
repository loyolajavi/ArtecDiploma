using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL.MotorBD;

namespace ARTEC.DAL
{
    public class DALSolicitud
    {

        public int SolicitudCrear(Solicitud laSolicitud)
        {


            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaInicio", laSolicitud.FechaInicio),
                new SqlParameter("@IdDependencia", laSolicitud.laDependencia.IdDependencia),
                new SqlParameter("@IdPrioridad", laSolicitud.UnaPrioridad.IdPrioridad),
                new SqlParameter("@IdEstado", laSolicitud.UnEstado.IdEstadoSolicitud),
                new SqlParameter("@IdUsuario", laSolicitud.Asignado.IdUsuario)
			};

            try
            {

                MotorBD.MotorBD.ConexionIniciar();
                MotorBD.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)MotorBD.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                foreach (SolicDetalle item in laSolicitud.unosDetallesSolicitud)
                {

                    SqlParameter[] parametersSolicitudDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdSolicitudDetalle", item.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", IDDevuelto),
                        new SqlParameter("@IdCategoria", item.unaCategoria.IdCategoria),
                        new SqlParameter("@Cantidad", item.Cantidad),
                        new SqlParameter("@IdEstadoSolDetalle", item.unEstado.IdEstadoSolDetalle)
			        };

                    MotorBD.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudDetalleCrear", parametersSolicitudDetalles); 
                }

                MotorBD.MotorBD.TransaccionAceptar();
                return IDDevuelto;
            }
            catch (Exception es)
            {
                MotorBD.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                MotorBD.MotorBD.ConexionFinalizar();
            }


        }

    }
}
