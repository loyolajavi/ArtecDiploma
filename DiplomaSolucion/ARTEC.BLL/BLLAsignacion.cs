using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.BLL.Servicios;

namespace ARTEC.BLL
{
    public class BLLAsignacion
    {

        DALAsignacion GestorAsignacion = new DALAsignacion();
        DALInventario GestorInventario = new DALInventario();
        DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();

        public bool AsignacionCrear(Asignacion unaAsig, Solicitud unaSolic)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Asignacion Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorAsignacion.AsignacionCrear(unaAsig, unaSolic) > 0)
                {
                    //foreach (AsigDetalle item in unaAsig.unosAsigDetalles)
                    //{
                    //    if (item.SolicDetalleAsoc.Cantidad == GestorInventario.InventarioEntregadoPorSolicDetalle(item.SolicDetalleAsoc.IdSolicitudDetalle, item.SolicDetalleAsoc.IdSolicitud, item.SolicDetalleAsoc.UIDSolicDetalle))
                    //    {
                    //        GestorSolicDetalle.SolicDetalleUpdateEstado(item.SolicDetalleAsoc.IdSolicitud, item.SolicDetalleAsoc.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado, item.SolicDetalleAsoc.UIDSolicDetalle);
                    //    }
                    //}
                }
                return true;
            }
            catch (Exception es)
            {
                throw;
            }
            
               
            
        }


        public List<Asignacion> AsignacionBuscar(string IdAsignacion, string NombreDependencia, string IdSolicitud, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Asignacion Buscar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                return GestorAsignacion.AsignacionBuscar(IdAsignacion, NombreDependencia, IdSolicitud, fechaDesde, fechaHasta);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Inventario> AsignacionTraerBienesAsignados(int IdAsignacion)
        {
            try
            {
                return GestorAsignacion.AsignacionTraerBienesAsignados(IdAsignacion);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void AsignacionModificar(Asignacion unaAsignacionModif, List<Inventario> InvQuitarMod, List<Inventario> InvAgregarMod)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Asignacion Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorAsignacion.AsignacionModificar(unaAsignacionModif, InvQuitarMod, InvAgregarMod);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<AsigDetalle> AsigDetallesTraer(int IdAsignacion)
        {
            try
            {
                return GestorAsignacion.AsigDetallesTraer(IdAsignacion);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void AsignacionEliminar(Asignacion unaAsignacionModif)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Asignacion Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorAsignacion.AsignacionEliminar(unaAsignacionModif);
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
