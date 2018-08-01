using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Categoria
    {


        public int IdCategoria { get; set; }
        public string DescripCategoria { get; set; }

        public override String ToString()
        {
            return this.DescripCategoria;
        } 

    }
}
