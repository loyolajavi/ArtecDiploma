﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLSolicDetalle
    {

        DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();

        public List<SolicDetalle> SolicDetallesTraerPorNroSolicitud(int NroSolic)
        {
            List<SolicDetalle> ListaDetalles = new List<SolicDetalle>();
            ListaDetalles = GestorSolicDetalle.SolicDetallesTraerPorNroSolicitud(NroSolic);
            //********************ME DEVUELVE IDSOLICITUD = 0**************************VER
            BLLCotizacion unManagerCotizacion = new BLLCotizacion();


            List<Cotizacion> unasCotizaciones = new List<Cotizacion>();
            unasCotizaciones = unManagerCotizacion.CotizacionTraerPorSolicitud(NroSolic);

            foreach (SolicDetalle det in ListaDetalles)
            {
                det.unasCotizaciones = unasCotizaciones.Where(x => x.unDetalleAsociado.IdSolicitudDetalle == det.IdSolicitudDetalle).ToList();
            }
            return ListaDetalles;
        }

    }
}
