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



        public List<Solicitud> SolicitudBuscar(int NroSolic)
        {
            return GestorSolicitud.SolicitudBuscar(NroSolic);
        }



        public List<Solicitud> SolicitudBuscar(string Dep = null, int? estado = null, string bien = null, int? priori = null, int? usasig = null)
        {
            return GestorSolicitud.SolicitudBuscar(Dep, estado, bien, priori, usasig);
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



        public bool SolicitudModificar(Solicitud laSolicitud)
        {
            if (GestorSolicitud.SolicitudModificar(laSolicitud))
                return true;
            return false;
        }



        public bool SolicitudModificarConDetallesEliminados(Solicitud laSolicitud)
        {
            if (GestorSolicitud.SolicitudModificarConDetallesEliminados(laSolicitud))
                return true;
            return false;
        }



    }
}
