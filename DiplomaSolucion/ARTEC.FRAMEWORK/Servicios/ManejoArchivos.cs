using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ARTEC.FRAMEWORK.Servicios
{
    public class ManejoArchivos
    {

        public static void CopiarArchivo(string Origen, string Destino)
        {
            try
            {
                // Copiar el archivo si existe lo sobreescribe  
                File.Copy(Origen, Destino, true);

            }
            catch (Exception ex)
            {
                throw;
            }

        }



        /// <summary>
        /// Valida si la extesión del adjunto es correcta
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool ValidarAdjunto(string RutaCompletaArchivo)
        {
            string ext = Path.GetExtension(RutaCompletaArchivo).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".pdf") || (ext == ".txt"))
            {
                return true;
            }
            return false;
        }

    }
}
