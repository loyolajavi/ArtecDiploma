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

        public List<Cotizacion> CotizacionTraerPorSolicitud(int NroSolicitud)
        {
            return GestorCotizacion.CotizacionTraerPorSolicitud(NroSolicitud);
        }

        public int CotizacionCrear(Cotizacion laCotizacion)
        {
            int IdDevuelto;
            IdDevuelto = GestorCotizacion.CotizacionCrear(laCotizacion);
            if (IdDevuelto > 0)
            {
                return IdDevuelto;
            }

            return 0;
        }


        public List<Cotizacion> CotizacionTraerPorUIDPartidaDetalle(int UIDPartidaDetalle, int IdPartida)
        {
            return GestorCotizacion.CotizacionTraerPorUIDPartidaDetalle(UIDPartidaDetalle, IdPartida);
        }


        public bool CotizacionAsociarConPartidaDetalle(int IdCotizacion, int UIDPartDetalle, int IdPartida)
        {
            return GestorCotizacion.CotizacionAsociarConPartidaDetalle(IdCotizacion, UIDPartDetalle, IdPartida);
        }


        //public bool CotizacionModifEnSolic(SolicDetalle unDetSolic, List<Cotizacion> CotiQuitarMod, List<Cotizacion> CotiAgregarMod)
        //{
        //    try
        //    {
        //        if (GestorCotizacion.CotizacionModifEnSolic(unDetSolic, CotiQuitarMod, CotiAgregarMod))
        //            return true;
        //        return false;
        //    }
        //    catch (Exception es)
        //    {
        //        throw;
        //    }
        //}


        public string ObtenerNombreAdjuntoCotiz(int IdCotizacion)
        {
            try
            {
                return GestorCotizacion.ObtenerNombreAdjuntoCotiz(IdCotizacion);
            }
            catch (Exception es)
            {
                throw;
            }

        }


    }
}
