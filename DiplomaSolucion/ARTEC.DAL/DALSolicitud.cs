using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Diagnostics;

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
                new SqlParameter("@IdUsuario", laSolicitud.Asignado.IdUsuario),
                new SqlParameter("@IdAgente", laSolicitud.AgenteResp.IdAgente)
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
                        new SqlParameter("@IdEstadoSolDetalle", item.unEstado.IdEstadoSolicDetalle)
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
                //using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerPorNroSolicitud", parameters))
                //{
                //    //Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                    
                //    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                //    //unaListaSolicitudes = FRAMEWORK.Persistencia.Mapeador.Mapear<Solicitud>(ds);
                //    unaListaSolicitudes = FRAMEWORK.Persistencia.Mapeador.Mapear<Solicitud>(ds);

                //    //System.Threading.Thread.Sleep(500);
                //    //stopwatch.Stop();
                //    //System.Windows.Forms.MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + " Hola");
                
                //    return unaListaSolicitudes;
                //}

                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerPorNroSolicitud", parameters))
                {
                    //Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch

                    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                    //unaListaSolicitudes = FRAMEWORK.Persistencia.Mapeador.Mapear<Solicitud>(ds);
                    //unaListaSolicitudes = FRAMEWORK.Persistencia.Mapeador.Mapear<Solicitud>(ds);
                    unaListaSolicitudes = MapearSolicitud(ds);
                    //unaListaSolicitudes = FRAMEWORK.Persistencia.Mapeador.MapearDataReaderListaObjetos<Solicitud>(ds);
                    

                    //System.Threading.Thread.Sleep(500);
                    //stopwatch.Stop();
                    //System.Windows.Forms.MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + " Hola");

                    return unaListaSolicitudes;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }




        public Solicitud SolicitudTraerIdsolNomdepPorIdPartida(int IdPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", IdPartida)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerIdsolNomdepPorIdPartida", parameters))
                {
                    Solicitud unaSolic = new Solicitud();
                    unaSolic = MapearSolicitudIdSolNomDep(ds);
                    
                    return unaSolic;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }




        public static List<Solicitud> MapearSolicitud(DataSet ds)
        {
            List<Solicitud> ResSolicitudes = new List<Solicitud>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Solicitud unaSolic = new Solicitud();

                    unaSolic.IdSolicitud = (int)row["IdSolicitud"];
                    unaSolic.laDependencia = new Dependencia();
                    unaSolic.laDependencia.IdDependencia = (int)row["IdDependencia"];
                    unaSolic.laDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    unaSolic.FechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                    if (row["FechaFin"].ToString() != "")
                    {
                        unaSolic.FechaFin = DateTime.Parse(row["FechaFin"].ToString());
                    }
                    unaSolic.UnaPrioridad = new Prioridad();
                    unaSolic.UnaPrioridad.IdPrioridad = (int)row["IdPrioridad"];
                    unaSolic.UnaPrioridad.DescripPrioridad = row["DescripPrioridad"].ToString();
                    unaSolic.UnEstado = new EstadoSolicitud();
                    unaSolic.UnEstado.IdEstadoSolicitud = (int)row["IdEstadoSolicitud"];
                    unaSolic.UnEstado.DescripEstadoSolic = row["DescripEstadoSolic"].ToString();
                    unaSolic.Asignado = new Usuario();
                    unaSolic.Asignado.IdUsuario = (int)row["IdUsuario"];
                    unaSolic.Asignado.NombreUsuario = row["NombreUsuario"].ToString();
                    unaSolic.AgenteResp = new Agente();
                    unaSolic.AgenteResp.IdAgente = (row["IdAgente"].ToString() != "") ? (int)row["IdAgente"] : (int?)null;
                    unaSolic.AgenteResp.ApellidoAgente = row["ApellidoAgente"].ToString();

                    ResSolicitudes.Add(unaSolic);
                }
                return ResSolicitudes;
            }
            catch (Exception es)
            {
                
                throw;
            }
        }



        public static Solicitud MapearSolicitudIdSolNomDep(DataSet ds)
        {
            try
            {
                Solicitud unaSolic = new Solicitud();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    unaSolic.IdSolicitud = (int)row["IdSolicitud"];
                    unaSolic.laDependencia = new Dependencia();
                    unaSolic.laDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                }
                return unaSolic;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public List<Solicitud> SolicitudBuscar(string NombreDep = null, string EstadoSolic = null)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(NombreDep))
                parameters.Add(new SqlParameter("@NombreDep", NombreDep));
            if (!string.IsNullOrEmpty(EstadoSolic))
                parameters.Add(new SqlParameter("@EstadoSolic", EstadoSolic));

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudBuscar", parameters.ToArray()))
                {
                    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                    unaListaSolicitudes = MapearSolicitud(ds);
                    return unaListaSolicitudes;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



    }
}
