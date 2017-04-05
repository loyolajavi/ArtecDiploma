using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class DTOCategoria
    {

        public Categoria unaCategoria { get; set; }
        public Bien unBien { get; set; }
        public TipoBien unTipoBien { get; set; }

    }
}
