using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class TipoTelefono
    {

        public int IdTipoTelefono { get; set; }
        public string DescripTipoTel { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.DescripTipoTel))
            {
                return this.DescripTipoTel;
            }
            return "";
        }
    }
}
