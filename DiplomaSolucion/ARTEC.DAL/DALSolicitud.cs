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

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudCrear", parameters);
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

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "SolicitudDetalleCrear", parametersSolicitudDetalles);
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
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public List<Solicitud> SolicitudBuscar(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@NroSolicitud", NroSolic)
			};

            try
            {
                //*********SEGUIR MAPEANDO Y FIJARME QUE EL STORE PROCEDURE ESTE COMPLETO
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerPorNroSolicitud", parameters))
                {
                    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                    unaListaSolicitudes = FRAMEWORK.Persistencia.Mapeador.Mapear<Solicitud>(ds);

                    List<Prioridad> unaListaPrioridades = new List<Prioridad>();
                    unaListaPrioridades = FRAMEWORK.Persistencia.Mapeador.Mapear<Prioridad>(ds);
                    foreach (Solicitud laSolicitud in unaListaSolicitudes)
                    {
                        foreach (Prioridad laPrioridad in unaListaPrioridades)
                        {
                            laSolicitud.UnaPrioridad = laPrioridad;
                        }
                    }

                    List<EstadoSolicitud> unaListaEstadoSolicitud = new List<EstadoSolicitud>();
                    unaListaEstadoSolicitud = FRAMEWORK.Persistencia.Mapeador.Mapear<EstadoSolicitud>(ds);
                    foreach (Solicitud laSolicitud in unaListaSolicitudes)
                    {
                        foreach (EstadoSolicitud elEstadoSolicitud in unaListaEstadoSolicitud)
                        {
                            laSolicitud.UnEstado = elEstadoSolicitud;
                        }
                    }


                    List<Dependencia> unaListaDependencias = new List<Dependencia>();
                    unaListaDependencias = FRAMEWORK.Persistencia.Mapeador.Mapear<Dependencia>(ds);
                     foreach (Solicitud laSolicitud in unaListaSolicitudes)
                    {
                        foreach (Dependencia unaDependencia in unaListaDependencias)
                        {
                            laSolicitud.laDependencia = unaDependencia;
                        }
                    }

                    return unaListaSolicitudes;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}
