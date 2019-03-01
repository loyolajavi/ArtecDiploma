using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security;
using System.Threading;


namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioMail
    {


        public static int Puerto { get; set; }
        public static string Host { get; set; }
        public static bool ssl { get; set; }
        public static string remitente { get; set; }
        public static string remps { get; set; }

        private static bool EnvioExitoso;

        public static bool EnviarCorreo
            (
            //string remitente,
            //string pass,
            //string nombre,
            //string telefono,
                string destinatario,
                string nombreEmpresa,
                string asunto,
                string cuerpoCorreo
            )
        {
            var serverSMTP = new SmtpClient();
            NetworkCredential credencial = new NetworkCredential();
            credencial.UserName = remitente;
            credencial.SecurePassword = SecurizarMailPass(remps);
            serverSMTP.Credentials = credencial;
            serverSMTP.Port = Puerto;
            serverSMTP.Host = Host;
            var correo = new MailMessage();
            correo.From = new MailAddress(remitente, nombreEmpresa);
            correo.To.Add(destinatario);
            correo.Subject = asunto;
            correo.Body = cuerpoCorreo;
            serverSMTP.EnableSsl = ssl;

            Thread ProcesoMailEnviar = new Thread
                (delegate()
                {
                    try
                    {
                        serverSMTP.Send(correo);
                        EnvioExitoso = true;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        correo.Dispose();
                    }
                }
                );

            ProcesoMailEnviar.Start();

            return EnvioExitoso;
        }



        private static SecureString SecurizarMailPass(string pass)
        {
            if (pass == null)
                throw new ArgumentNullException("password");
            //VER: Corregir excepción
            var secPass = new SecureString();

            foreach (char c in pass)
                secPass.AppendChar(c);

            secPass.MakeReadOnly();
            return secPass;
        }




    }
}
