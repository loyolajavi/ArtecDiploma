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
    public class DALCotizacion
    {

        public List<Cotizacion> CotizacionTraerPorSolicitudYDetalle(int NroDetalleSolic, int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitudDetalle", NroDetalleSolic),
                new SqlParameter("@IdSolicitud", NroSolic)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CotizacionTraerPorSolicitudYDetalle", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Cotizacion>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }



        public List<Cotizacion> CotizacionTraerPorSolicitud(int NroSolic)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdSolicitud", NroSolic)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CotizacionTraerPorSolicitud", parameters))
                {
                    List<Cotizacion> unaLista = new List<Cotizacion>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Cotizacion>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        public int CotizacionCrear(Cotizacion laCotizacion)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
			    {
                    new SqlParameter("@MontoCotizado", laCotizacion.MontoCotizado),
                    new SqlParameter("@FechaCotizacion", laCotizacion.FechaCotizacion),
                    new SqlParameter("@IdProveedor", laCotizacion.unProveedor.IdProveedor)
			    };

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //Tabla de relacion
                SqlParameter[] parametersRelCotizSolicDetalle = new SqlParameter[]
			    {
                    new SqlParameter("@IdSolicitudDetalle", laCotizacion.unDetalleAsociado.IdSolicitudDetalle),
                    new SqlParameter("@IdSolicitud", laCotizacion.unDetalleAsociado.IdSolicitud),
                    new SqlParameter("@IdCotizacion", IDDevuelto)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CotizacionCrearRelSolicDetalle", parametersRelCotizSolicDetalle);
              
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



    }
}
