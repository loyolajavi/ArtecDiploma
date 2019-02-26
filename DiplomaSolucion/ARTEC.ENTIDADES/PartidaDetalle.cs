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

        private List<Cotizacion> _unasCotizacionesBKP = new List<Cotizacion>();

        public List<Cotizacion> unasCotizacionesBKP
        {
            get { return _unasCotizacionesBKP; }
            set { _unasCotizacionesBKP = value; }
        }

        //Para agregar nuevas cotizaciones en PartidaDetalle
        private List<Cotizacion> _unasCotizacionesEnSolic = new List<Cotizacion>();
        public List<Cotizacion> unasCotizacionesEnSolic
        {
            get { return _unasCotizacionesEnSolic; }
            set { _unasCotizacionesEnSolic = value; }
        }
        

    }
}
