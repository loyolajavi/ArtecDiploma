using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Cotizacion
    {

        public int IdCotizacion { get; set; }
        public Decimal MontoCotizado { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public Proveedor unProveedor { get; set; }

        public SolicDetalle unDetalleAsociado { get; set; }



    }
}
