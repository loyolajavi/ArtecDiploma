using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Telefono
    {

        public int IdTelefono { get; set; }
        public int CodArea { get; set; }
        public int NroTelefono { get; set; }
        public TipoTelefono unTipoTelefono { get; set; }

    }
}
