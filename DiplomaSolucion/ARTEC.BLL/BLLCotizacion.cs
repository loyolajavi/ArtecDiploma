using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLCotizacion
    {

        DALCotizacion GestorCotizacion = new DALCotizacion();

        public List<Cotizacion> CotizacionTraerPorSolicitudYDetalle(int NroDetalleSolicitud, int NroSolicitud)
        {
            return GestorCotizacion.CotizacionTraerPorSolicitudYDetalle(NroDetalleSolicitud, NroSolicitud);
        }

    }
}
