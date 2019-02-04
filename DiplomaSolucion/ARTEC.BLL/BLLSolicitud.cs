using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.BLL
{
    public class BLLSolicitud
    {

        DALSolicitud GestorSolicitud = new DALSolicitud();

        public int SolicitudCrear(Solicitud laSolicitud, string ExtAdjunto)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (laSolicitud.unosDetallesSolicitud.Count == 0)
                    throw new InvalidOperationException("Por favor revisar que la Solicitud posea al menos un detalle");
                return GestorSolicitud.SolicitudCrear(laSolicitud, ExtAdjunto);
            }
            catch (Exception es)
            {
                throw;
            }
            
        }



        public List<Solicitud> SolicitudBuscar(int NroSolic)
        {
            if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Buscar" }))
                throw new InvalidOperationException("No posee los permisos suficientes");
            return GestorSolicitud.SolicitudBuscar(NroSolic);
        }

        public List<Solicitud> SolicitudBuscarConCanceladas(int NroSolic)
        {
            if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Buscar" }))
                throw new InvalidOperationException("No posee los permisos suficientes");
            return GestorSolicitud.SolicitudBuscarConCanceladas(NroSolic);
        }


        public List<Solicitud> SolicitudBuscar(string Dep = null, int? estado = null, string bien = null, int? priori = null, int? usasig = null, DateTime? fechaInicio = null, DateTime? fechaInicio2 = null, DateTime? fechaFin = null, DateTime? fechaFin2 = null)
        {
            if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Buscar" }))
                throw new InvalidOperationException("No posee los permisos suficientes");
            return GestorSolicitud.SolicitudBuscar(Dep, estado, bien, priori, usasig, fechaInicio, fechaInicio2, fechaFin, fechaFin2);
        }

        public List<Solicitud> SolicitudBuscarConCanceladas(string Dep = null, int? estado = null, string bien = null, int? priori = null, int? usasig = null, DateTime? fechaInicio = null, DateTime? fechaInicio2 = null, DateTime? fechaFin = null, DateTime? fechaFin2 = null)
        {
            if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Buscar" }))
                throw new InvalidOperationException("No posee los permisos suficientes");
            return GestorSolicitud.SolicitudBuscarConCanceladas(Dep, estado, bien, priori, usasig, fechaInicio, fechaInicio2, fechaFin, fechaFin2);
        }


        public Solicitud SolicitudTraerDetalles(int IdSolic)
        {
            Solicitud unaSolic = new Solicitud();
            unaSolic.IdSolicitud = IdSolic;
            BLLSolicDetalle GestorSolicDetalle = new BLLSolicDetalle();

            unaSolic.unosDetallesSolicitud = GestorSolicDetalle.SolicDetallesTraerPorNroSolicitud(IdSolic).ToList();
            return unaSolic;
        }

     
   
        public Solicitud SolicitudTraerIdsolNomdepPorIdPartida(int IdPartida)
        {
            try
            {
                return GestorSolicitud.SolicitudTraerIdsolNomdepPorIdPartida(IdPartida);
            }
            catch (Exception es)
            {
                throw;
            }
            
        }



        public bool SolicitudModificar(Solicitud laSolicitud, List<SolicDetalle> unosSolDetQuitarMod, List<SolicDetalle> unosSolDetAgregarMod, List<SolicDetalle> unosSolDetModifMod, List<SolicDetalle> unosSolicDetAgregarBKP, string unAdjuntoRutaCompleta)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                int DetallesCant = unosSolicDetAgregarBKP.Count + unosSolDetAgregarMod.Count - unosSolDetQuitarMod.Count;
                if (DetallesCant < 1)
                    throw new InvalidOperationException("La solicitud debe quedar con al menos un detalle");

                if (GestorSolicitud.SolicitudModificar(laSolicitud, unosSolDetQuitarMod, unosSolDetAgregarMod, unosSolDetModifMod, unosSolicDetAgregarBKP, unAdjuntoRutaCompleta))
                        return true;
                return false;
            }
            catch (InvalidOperationException es1)
            {
                string IdError = ServicioLog.CrearLog(es1, "BLL - SolicitudModificar");
                es1.Data.Add("IdLog", IdError);
                throw;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        //public bool SolicitudModificarConDetallesEliminados(Solicitud laSolicitud)
        //{
        //    try
        //    {
        //        if (GestorSolicitud.SolicitudModificarConDetallesEliminados(laSolicitud))
        //            return true;
        //        return false;
        //    }
        //    catch (Exception es)
        //    {
        //        throw;
        //    }
            
            
        //}




        public bool SolicitudCancelar(Solicitud unaSolicitud)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Solicitud Cancelar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                //Coloca en "Cancelada" la Solicitud y además sus SolicDetalles
                if (GestorSolicitud.SolicitudCancelar(unaSolicitud))
                    return true;
                return false;
            }
            catch (InvalidOperationException es1)
            {
                string IdError = ServicioLog.CrearLog(es1, "BLL - SolicitudCancelar");
                es1.Data.Add("IdLog", IdError);
                throw;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public List<Nota> SolicitudTraerNotas(int IdSolic)
        {
            try
            {
                return GestorSolicitud.SolicitudTraerNotas(IdSolic);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public string ObtenerNombreAdjuntoSolic(int IdSolicitud)
        {
            try
            {
                return GestorSolicitud.ObtenerNombreAdjuntoSolic(IdSolicitud);
            }
            catch (Exception es)
            {
                throw;
            }
            
        }
    }
}
