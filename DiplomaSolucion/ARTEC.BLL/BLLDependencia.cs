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
    public class BLLDependencia
    {

        DALDependencia GestorDependencia = new DALDependencia();

        /// <summary>
        /// Traer todas las dependencias.
        /// </summary>
        /// <returns>List<Dependencia></returns>
        public List<Dependencia> TraerTodos()
        {

            return GestorDependencia.TraerTodos();

        }


        public List<Agente> TraerAgentesDependencia(int idDependencia)
        {
            return GestorDependencia.TraerAgentesDependencia(idDependencia);
        }

        public List<Agente> TraerAgentesResp(int idDependencia)
        {
            return GestorDependencia.TraerAgentesResp(idDependencia);
        }


        public List<Dependencia> DependenciaTraerNombrePorIDSolicitud(int IdSolicitud)
        {
            return GestorDependencia.DependenciaTraerNombrePorIDSolicitud(IdSolicitud);
        }


        public List<TipoDependencia> TipoDepTraerTodos()
        {
            return GestorDependencia.TipoDepTraerTodos();
        }

        public void DependenciaModifTipoDep(int IdDep, TipoDependencia TipoDep)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorDependencia.DependenciaModifTipoDep(IdDep, TipoDep);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public void DependenciaAgenteAgregar(List<Agente> AgentesNuevos, int IdDep)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorDependencia.DependenciaAgenteAgregar(AgentesNuevos, IdDep);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        

        public void DependenciaModifNombre(string NombreDep, int IdDep)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorDependencia.DependenciaModifNombre(NombreDep, IdDep);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public void DependenciaAgentesQuitarLista(List<int> AgentesAQuitar, int IdDep)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorDependencia.DependenciaAgentesQuitarLista(AgentesAQuitar, IdDep);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public Dependencia DependenciaBuscar(string NomDependencia)
        {
            try
            {
                return GestorDependencia.DependenciaBuscar(NomDependencia);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool DependenciaCrear(Dependencia nuevaDependencia)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorDependencia.DependenciaCrear(nuevaDependencia))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool DependenciaEliminar(Dependencia unaDependencia)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                unaDependencia.Activo = 0;
                if (GestorDependencia.DependenciaEliminar(unaDependencia.IdDependencia))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool DependenciaReactivar(Dependencia unaDependencia)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Dependencia Reactivar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                unaDependencia.Activo = 1;
                if (GestorDependencia.DependenciaReactivar(unaDependencia.IdDependencia))
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
