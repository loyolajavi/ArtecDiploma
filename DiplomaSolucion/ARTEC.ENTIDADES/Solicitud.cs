using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Solicitud
    {


        public Dependencia laDependencia { get; set; }
        private List<SolicDetalle> _unosDetallesSolicitud = new List<SolicDetalle>();
        public List<SolicDetalle> unosDetallesSolicitud
        {
            get { return _unosDetallesSolicitud; }
            set { _unosDetallesSolicitud = value; }
        }
        

    }
}
