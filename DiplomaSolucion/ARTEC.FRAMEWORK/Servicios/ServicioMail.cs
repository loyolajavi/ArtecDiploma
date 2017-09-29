using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security;


namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioMail
    {


        public static int Puerto { get; set; }
        public static string Host { get; set; }
        public static bool ssl { get; set; }


        /// <summary>
        /// Enviars the correo.
        /// </summary>
        /// <param name="remitente">The remitente.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="telefono">The telefono.</param>
        /// <param name="destinatario">The destinatario.</param>
        /// <param name="nombreEmpresa">The nombre empresa.</param>
        /// <param name="asunto">The asunto.</param>
        /// <param name="cuerpoCorreo">The cuerpo correo.</param>
        /// <returns></returns>
        public static bool EnviarCorreo
            (
                string remitente,
                string pass,
                string nombre,
                string telefono,
                string destinatario,
                string nombreEmpresa,
                string asunto,
                string cuerpoCorreo
            )
        {
            var serverSMTP = new SmtpClient();
            NetworkCredential credencial = new NetworkCredential();
            credencial.UserName = remitente;
            credencial.SecurePassword = SecurizarMailPass(pass);
            serverSMTP.Credentials = credencial;
            serverSMTP.Port = Puerto;
            serverSMTP.Host = Host;
            var correo = new MailMessage();
            correo.From = new MailAddress(remitente, nombreEmpresa);
            correo.To.Add(destinatario);
            correo.Subject = asunto;
            correo.Body = cuerpoCorreo;
            serverSMTP.EnableSsl = ssl;

            try
            {
                serverSMTP.Send(correo);
                return true;
            }
            catch (Exception ex)
            {
                //VER:Excepción log
                return false;
            }
            finally
            {
                correo.Dispose();
            }
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
