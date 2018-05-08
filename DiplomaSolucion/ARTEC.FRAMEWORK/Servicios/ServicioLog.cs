using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.FRAMEWORK.Servicios
{
    public static class ServicioLog
    {

        public static string CrearLog(Exception exc, EventLogEntryType tipo_entrada, string usuario)
        {
            EventLog Elog = new EventLog();
            string NombreCarpeta = "ArtecLogs";
            string NombreAplicacion = "Artec1";
            try
            {
                if (!EventLog.SourceExists(NombreAplicacion))
                    EventLog.CreateEventSource(NombreAplicacion, NombreCarpeta);
                Elog.Source = NombreAplicacion;
                try
                {
                    if (Elog.Log != NombreCarpeta)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new Exception("El Source está siendo usado por otra aplicación (Modifique este campo)", ex);
                }

                Elog.WriteEntry("Usuario: " + usuario + " - " + ObtenerMsjExcepciones(exc), tipo_entrada, 1);
                return ObtenerUltimoIdLog(NombreCarpeta);
            }
            catch (Exception ErrorEscribirLog)
            {
                throw new Exception("Error al guardar un evento en el log, intente nuevamente", ErrorEscribirLog);
            }
            finally
            {
                Elog.Close();
                Elog.Dispose();
            }
        }


        public static string ObtenerMsjExcepciones(Exception unaEx)
        {
            string LaCadena = "";
            Exception elError = unaEx;
            while (elError != null)
            {
                LaCadena = LaCadena + Environment.NewLine + elError.Message;
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


    }
}
