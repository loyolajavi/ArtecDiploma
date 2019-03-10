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

        public void CategoriaCrear(Categoria nuevaCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorCategoria.CategoriaCrear(nuevaCategoria);
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

        public void CategoriaModificar(Categoria unaCategoria, List<Proveedor> ProvQuitarMod, List<Proveedor> ProvAgregarMod)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorCategoria.CategoriaModificar(unaCategoria, ProvQuitarMod, ProvAgregarMod);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void CategoriaEliminar(Categoria unaCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                unaCategoria.Activo = 0;
                GestorCategoria.CategoriaEliminar(unaCategoria.IdCategoria);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void CategoriaReactivar(Categoria unaCategoria)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Categoria Reactivar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                unaCategoria.Activo = 1;
                GestorCategoria.CategoriaReactivar(unaCategoria.IdCategoria);
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
