using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ARTEC.FRAMEWORK.Servicios
{
    public static class ServicioLog
    {

        public enum TipoLog
        {
            Accion = 1, Error = 2
        }


        public static string CrearLog(Exception exc, string AccionExcepcion) //Bitacora Errores
        {
            System.Diagnostics.EventLogEntryType tipo_entrada = EventLogEntryType.Error;
            EventLog Elog = new EventLog();
            string NombreCarpeta = "ArtecLogs";
            string NombreAplicacion = "Artec1";
            string NombreUsuario = null;
            //try
            //{

            string MsjExcepciones = ObtenerMsjExcepciones(exc);

                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                {
                    if (ServicioLogin.GetLoginUnico().UsuarioLogueado != null)
                    {
                        GrabarLogBD(ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario, ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario, DateTime.Now, "Error", AccionExcepcion, MsjExcepciones);
                        NombreUsuario = ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario;
                    }
                    else
                    {
                        GrabarLogBD(0, "SIN_USUARIO", DateTime.Now, "Error", AccionExcepcion, MsjExcepciones);
                        NombreUsuario = "SIN_USUARIO";
                    }
                        
                }
                else
                {
                    try 
	                {
                        if (ServicioLogin.GetLoginUnico().UsuarioLogueado != null && ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario > 0)
                        {
                            GrabarLogBD(ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario, ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario, DateTime.Now, "Error", AccionExcepcion, MsjExcepciones);
                            NombreUsuario = ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario;
                        }
                        else
                        {
                            GrabarLogBD(0, "SIN_USUARIO", DateTime.Now, "Error", AccionExcepcion, MsjExcepciones);
                            NombreUsuario = "SIN_USUARIO";
                        }
	                }
	                catch (Exception es)
	                {
                        System.Windows.Forms.MessageBox.Show("Error crítico y general de conexión a la base de datos");
                        Application.Exit();

	                }
                }


                if (!EventLog.SourceExists(NombreAplicacion))
                    EventLog.CreateEventSource(NombreAplicacion, NombreCarpeta);
                Elog.Source = NombreAplicacion;
                //try
                //{
                //    if (Elog.Log != NombreCarpeta)
                //        throw new Exception();
                //}
                //catch (Exception ex)
                //{
                //    throw new Exception("El Source está siendo usado por otra aplicación (Modifique este campo)", ex);
                //}

                Elog.WriteEntry("Usuario: " + NombreUsuario + " - " + MsjExcepciones, tipo_entrada, 1);
                Elog.Close();
                Elog.Dispose();
                return ObtenerUltimoIdLog(NombreCarpeta);
            //}
            //catch (Exception ErrorEscribirLog)
            //{
            //    throw new Exception("Error al guardar un evento en el log, intente nuevamente", ErrorEscribirLog);
            //}
            //finally
            //{

            //}
        }


        public static void CrearLog(string Accion, string Mensaje)//Bitacora Eventos
        {
            if (ServicioLogin.GetLoginUnico().UsuarioLogueado != null && ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario != null)
                GrabarLogBD(ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario, ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario, DateTime.Now, "Evento", Accion, Mensaje);
            else
                GrabarLogBD(0, "SIN_USUARIO", DateTime.Now, "Evento", Accion, Mensaje);
        }


        public static string ObtenerMsjExcepciones(Exception unaEx)
        {
            string LaCadena = "";
            Exception elError = unaEx;
            while (elError != null)
            {
                StackTrace trace = new StackTrace(elError, true);
                string NomArchivo = trace.GetFrame(0).GetFileName();
                int NroLinea = trace.GetFrame(0).GetFileLineNumber();
                LaCadena = LaCadena + Environment.NewLine + elError.Message + Environment.NewLine + "Archivo: " + NomArchivo + Environment.NewLine + "Linea: " + NroLinea + Environment.NewLine + elError.StackTrace.ToString();
                elError = elError.InnerException;
            }
            return LaCadena;
        }

        public static string ObtenerUltimoIdLog(string NomCarpeta)
        {
            string resultado;
            System.Diagnostics.EventLog EventLogApp = new System.Diagnostics.EventLog(NomCarpeta);
            int eventCntr = EventLogApp.Entries.Count - 1;

            resultado = (EventLogApp.Entries[eventCntr].Index).ToString();
            try
            {
                return resultado;
            }
            catch (Exception ErrorLeerLog)
            {
                throw new Exception("Hubo un error al leer, compruebe que escribió correctamente la carpeta", ErrorLeerLog);
            }
        }




        private static void GrabarLogBD(int idusuario, string NombreUs, DateTime fecha, string tipo, string accionrealizada, string msj)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
			    {
                    new SqlParameter("@IdUsuario", idusuario),
                    new SqlParameter("@NombreUsuario", NombreUs),
                    new SqlParameter("@Fecha", fecha),
                    new SqlParameter("@TipoLog", tipo),
                    new SqlParameter("@Accion", accionrealizada),
                    new SqlParameter("@Mensaje", msj)
			    };

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "BitacoraLogCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);
                         
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                //return IDDevuelto;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }




    }
}
