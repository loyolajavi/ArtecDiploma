using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL.MotorBD;

namespace ARTEC.DAL
{
    public class DALDependencia
    {


        public List<Dependencia> TraerTodos()
        {
            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerTodos"))
            {
                List<Dependencia> unaLista = new List<Dependencia>();
                unaLista = Mapeador.Mapear<Dependencia>(ds);

                return unaLista;
            }
        }


        public List<Agente> TraerAgentesDependencia(int idDependencia)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", idDependencia)
			};

            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerAgentesPorIdDependencia", parameters))
            {
                List<Agente> unaLista = new List<Agente>();
                unaLista = Mapeador.Mapear<Agente>(ds);
                return unaLista;
            }
        }
        

    }
}
