using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Provincia
    {

        public int IdProvincia{ get; set; }
        public string NombreProvincia { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.NombreProvincia))
            {
                return this.NombreProvincia;
            }
            return "";
        }

    }
}
