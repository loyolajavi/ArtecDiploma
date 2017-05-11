using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.NombreUsuario))
            {
                return this.NombreUsuario.ToString();
            }
            return "";
        }
    }
}
