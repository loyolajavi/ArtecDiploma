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

        ////**********PRUEBA
        //public Solicitud SolicitudBuscar(int NroSolic)
        //{
        //    return GestorSolicitud.SolicitudBuscar(NroSolic);
        //}
        ////**********FINPRUEBA***********

    }
}
