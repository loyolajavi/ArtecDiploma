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








    }
}
