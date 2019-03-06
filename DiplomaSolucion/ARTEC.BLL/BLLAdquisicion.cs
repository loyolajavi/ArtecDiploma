﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.BLL.Servicios;

namespace ARTEC.BLL
{
    public class BLLAdquisicion
    {

        DALAdquisicion GestorAdquisicion = new DALAdquisicion();
        BLLInventarioHard ManagerInventarioHard = new BLLInventarioHard();
        BLLInventarioSoft ManagerInventarioSoft = new BLLInventarioSoft();

        public int AdquisicionCrear(Adquisicion unaAdquisicion)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Adquisicion Registrar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorAdquisicion.ComenzarAdquisicion();
                int IdAdq = GestorAdquisicion.AdquisicionCrear(unaAdquisicion);
                foreach (Bien unBien in unaAdquisicion.BienesInventarioAsociados)
                {
                    if (unBien is Hardware)
                    {
                        ManagerInventarioHard.InventarioHardCrear(unBien as Hardware, IdAdq);
                    }
                    else
                    {
                        ManagerInventarioSoft.InventarioSoftCrear(unBien as Software, IdAdq);
                    }
                }
                GestorAdquisicion.ConfirmarAdquisicion();
                return IdAdq;
            }
            catch (Exception)
            {
                GestorAdquisicion.CancelarAdquisicion();
                throw;
            }
            finally
            {
                GestorAdquisicion.TerminarAdquisicion();
            }


            
            
        }


        public List<Adquisicion> AdquisicionBuscar(string IdAdquisicion, string IdPartida, string NombreDependencia, DateTime? unaFecha, DateTime? unaFechaCompra, string NroFactura, string IdSolicitud)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Adquisicion Buscar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                return GestorAdquisicion.AdquisicionBuscar(IdAdquisicion, IdPartida, NombreDependencia, unaFecha, unaFechaCompra, NroFactura, IdSolicitud);
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public List<Inventario> AdquisicionInventariosAsoc(string IdPartida, string IdAdquisicion)
        {
            try
            {
                return GestorAdquisicion.AdquisicionInventariosAsoc(IdPartida, IdAdquisicion);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool AdquisicionModificar(Adquisicion unaAdqModif, List<Inventario> InvQuitarMod, List<Inventario> InvAgregarMod)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Adquisicion Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (InvAgregarMod.Count>0)
                    if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Inventario Agregar" }))
                        throw new InvalidOperationException("No posee los permisos suficientes");
                if (InvQuitarMod.Count > 0)
                    if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Inventario Eliminar" }))
                        throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorAdquisicion.AdquisicionModificar(unaAdqModif, InvQuitarMod, InvAgregarMod))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool AdquisicionEliminar(Adquisicion unaAdqModif)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Adquisicion Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorAdquisicion.AdquisicionEliminar(unaAdqModif))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
