using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Cargo
    {

        public int IdCargo { get; set; }
        public string DescripCargo { get; set; }

        public override string ToString()
        {
            return this.DescripCargo;
        }

    }
}
