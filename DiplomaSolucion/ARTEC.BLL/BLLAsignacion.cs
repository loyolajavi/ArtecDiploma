﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLAsignacion
    {

        DALAsignacion GestorAsignacion = new DALAsignacion();
        DALInventario GestorInventario = new DALInventario();
        DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();

        public bool AsignacionCrear(Asignacion unaAsig)
        {
            try
            {
                if (GestorAsignacion.AsignacionCrear(unaAsig) > 0)
                {
                    foreach (AsigDetalle item in unaAsig.unosAsigDetalles)
                    {
                        if (item.SolicDetalleAsoc.Cantidad == GestorInventario.InventarioEntregadoPorSolicDetalle(item.SolicDetalleAsoc.IdSolicitudDetalle, item.SolicDetalleAsoc.IdSolicitud))
                        {
                            GestorSolicDetalle.SolicDetalleUpdateEstado(item.SolicDetalleAsoc.IdSolicitud, item.SolicDetalleAsoc.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado);
                        }
                    }
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

        public bool AsignacionModificar(Asignacion unaAsignacionModif, List<Inventario> InvQuitarMod, List<Inventario> InvAgregarMod)
        {
            try
            {
                if (GestorAsignacion.AsignacionModificar(unaAsignacionModif, InvQuitarMod, InvAgregarMod))
                    return true;
                return false;
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
    }
}
