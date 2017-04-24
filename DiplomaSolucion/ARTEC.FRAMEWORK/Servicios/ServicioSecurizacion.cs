using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioSecurizacion
    {

        public static string AplicarHash(string Pass)
        {
            if (string.IsNullOrEmpty(Pass))
                return "";

            var Provider = new SHA1CryptoServiceProvider();
            var Encoding = new UnicodeEncoding();
            return Convert.ToBase64String(Provider.ComputeHash(Encoding.GetBytes(Pass)));
        }

    }
}
