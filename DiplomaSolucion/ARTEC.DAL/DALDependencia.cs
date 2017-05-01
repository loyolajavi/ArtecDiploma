using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;

namespace ARTEC.DAL
{
    public class DALDependencia
    {


        public List<Dependencia> TraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerTodos"))
            {
                List<Dependencia> unaLista = new List<Dependencia>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Dependencia>(ds);

                foreach (Dependencia Dep in unaLista)
                {
                    DALTipoDependencia GestorTipoDep = new DALTipoDependencia();
                    Dep.unTipoDep = GestorTipoDep.TipoDependenciaTraerPorDependencia(Dep.IdDependencia);
                }


                return unaLista;
            }
        }


        public List<Agente> TraerAgentesDependencia(int idDependencia)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", idDependencia)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerAgentesPorIdDependencia", parameters))
            {
                List<Agente> unaLista = new List<Agente>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Agente>(ds);
                return unaLista;
            }
        }

        public List<Agente> TraerAgentesResp(int idDependencia)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", idDependencia)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerAgentesResp", parameters))
            {
                List<Agente> unaLista = new List<Agente>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Agente>(ds);
                return unaLista;
            }
        }


    }
}
