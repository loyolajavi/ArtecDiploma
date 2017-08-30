using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLSolicitud
    {

        DALSolicitud GestorSolicitud = new DALSolicitud();

        public bool SolicitudCrear(Solicitud laSolicitud)
        {
            if (GestorSolicitud.SolicitudCrear(laSolicitud) > 0)
            {
                return true;
            }

            return false;
        }

        //ANTIGUO
        //public List<Solicitud> SolicitudBuscar(int NroSolic)
        //{
        //    return GestorSolicitud.SolicitudBuscar(NroSolic);
        //}
        public List<Solicitud> SolicitudBuscar(string Dep = null, string estado = null)
        {
            return GestorSolicitud.SolicitudBuscar(Dep, estado);
        }


        public Solicitud SolicitudTraerDetalles(Solicitud unaSolic)
        {

            BLLSolicDetalle GestorSolicDetalle = new BLLSolicDetalle();

            unaSolic.unosDetallesSolicitud = GestorSolicDetalle.SolicDetallesTraerPorNroSolicitud(unaSolic.IdSolicitud).ToList();
            return unaSolic;
        }

     
   
        public Solicitud SolicitudTraerIdsolNomdepPorIdPartida(int IdPartida)
        {
            return GestorSolicitud.SolicitudTraerIdsolNomdepPorIdPartida(IdPartida);
        }





    }
}
