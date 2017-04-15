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
                MotorBD.MotorBD.TransaccionAceptar();
                return Decimal.ToInt32(Resultado);
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
