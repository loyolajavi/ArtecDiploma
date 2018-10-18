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
    public class BLLCategoria
    {

        DALCategoria GestorCategoria = new DALCategoria();

        public List<Categoria> CategoriaTraerTodosHard()
        {
            return GestorCategoria.CategoriaTraerTodosHard();
        }

        public List<Categoria> CategoriaTraerTodosSoft()
        {
            return GestorCategoria.CategoriaTraerTodosSoft();
        }

        public List<Categoria> CategoriaTraerTodosHardActivos()
        {
            return GestorCategoria.CategoriaTraerTodosHardActivos();
        }

        public List<Categoria> CategoriaTraerTodosSoftActivos()
        {
            return GestorCategoria.CategoriaTraerTodosSoftActivos();
        }

        public List<Categoria> CategoriaTraerTodos()
        {
            return GestorCategoria.CategoriaTraerTodos();
        }

        public List<Categoria> CategoriaTraerTodosActivos()
        {
            return GestorCategoria.CategoriaTraerTodosActivos();
        }

        public bool CategoriaCrear(Categoria nuevaCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorCategoria.CategoriaCrear(nuevaCategoria))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
            
        }

        public Categoria CategoriaBuscar(string NomCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Buscar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                return GestorCategoria.CategoriaBuscar(NomCategoria);
            }
            catch (Exception es)
            {
                throw;
            }
            
        }

        public List<Proveedor> CategoriaTraerProveedores(int IdCategoria)
        {
            try
            {
                return GestorCategoria.CategoriaTraerProveedores(IdCategoria);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool CategoriaModificar(Categoria unaCategoria, List<Proveedor> ProvQuitarMod, List<Proveedor> ProvAgregarMod)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if(GestorCategoria.CategoriaModificar(unaCategoria, ProvQuitarMod, ProvAgregarMod))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool CategoriaEliminar(Categoria unaCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                unaCategoria.Activo = 0;
                if (GestorCategoria.CategoriaEliminar(unaCategoria.IdCategoria))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool CategoriaReactivar(Categoria unaCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Reactivar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                unaCategoria.Activo = 1;
                if (GestorCategoria.CategoriaReactivar(unaCategoria.IdCategoria))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public int CategoriaTraerIdCatPorIdBien(int IdBien)
        {
            try
            {
                return GestorCategoria.CategoriaTraerIdCatPorIdBien(IdBien);
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
