using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class PartidaDetalle
    {

        public int UIDPartidaDetalle { get; set; }
        public int IdPartidaDetalle { get; set; }
        public int IdPartida { get; set; }
        public SolicDetalle SolicDetalleAsociado { get; set; }
        
        private List<Cotizacion> _unasCotizaciones = new List<Cotizacion>();

        public List<Cotizacion> unasCotizaciones
        {
            get { return _unasCotizaciones; }
            set { _unasCotizaciones = value; }
        }

        

    }
}
