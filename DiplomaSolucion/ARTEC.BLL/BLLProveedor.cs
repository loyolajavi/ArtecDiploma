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
    public class BLLProveedor
    {

        DALProveedor GestorProveedor = new DALProveedor();

        public List<Proveedor> ProveedorTraerTodos()
        {
            return GestorProveedor.ProveedorTraerTodos();
        }


        public List<Proveedor> ProveedorTraerTodosActivos()
        {
            return GestorProveedor.ProveedorTraerTodosActivos();
        }


        public List<Categoria> ProveedorTraerCategorias(int IdProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorTraerCategorias(IdProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Telefono> ProveedorTraerTelefonos(int IdProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorTraerTelefonos(IdProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Direccion> ProveedorTraerDirecciones(int IdProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorTraerDirecciones(IdProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public Proveedor ProveedorBuscar(string NomProveedor)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Proveedor Buscar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                return GestorProveedor.ProveedorBuscar(NomProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool ProveedorCrear(Proveedor nuevoProveedor)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Proveedor Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorProveedor.ProveedorCrear(nuevoProveedor))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool ProveedorModificar(Proveedor unProvBuscar, List<Categoria> CatQuitarMod, List<Categoria> CatAgregarMod, List<Telefono> TelQuitarMod, List<Telefono> TelAgregarMod, List<Direccion> DirQuitarMod, List<Direccion> DirAgregarMod)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Proveedor Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorProveedor.ProveedorModificar(unProvBuscar, CatQuitarMod, CatAgregarMod, TelQuitarMod, TelAgregarMod, DirQuitarMod, DirAgregarMod))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public bool ProveedorEliminar(Proveedor unProvBuscar)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Proveedor Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorProveedor.ProveedorEliminar(unProvBuscar.IdProveedor))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool ProveedorReactivar(int IdProveedor)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Proveedor Reactivar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorProveedor.ProveedorReactivar(IdProveedor))
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
