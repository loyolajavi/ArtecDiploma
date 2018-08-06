using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;



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
            GestorDependencia.DependenciaModifTipoDep(IdDep, TipoDep);
        }

        public void DependenciaAgenteAgregar(List<Agente> AgentesNuevos, int IdDep)
        {
            GestorDependencia.DependenciaAgenteAgregar(AgentesNuevos, IdDep);
        }
        

        public void DependenciaModifNombre(string NombreDep, int IdDep)
        {
            GestorDependencia.DependenciaModifNombre(NombreDep, IdDep);
        }

        public void DependenciaAgentesQuitarLista(List<int> AgentesAQuitar, int IdDep)
        {
            GestorDependencia.DependenciaAgentesQuitarLista(AgentesAQuitar, IdDep);
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
