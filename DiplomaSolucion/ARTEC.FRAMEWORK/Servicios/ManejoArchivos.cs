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

    }
}
