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
    public class DALTipoDependencia
    {

        public TipoDependencia TipoDependenciaTraerPorDependencia(int idDependencia)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", idDependencia),
                new SqlParameter("@IdIdioma", ENTIDADES.Servicios.Idioma.unIdiomaActual)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "TipoDependenciaTraerPorDependencia", parameters))
            {
                TipoDependencia unaLista = new TipoDependencia();
                unaLista = FRAMEWORK.Persistencia.Mapeador.MapearUno<TipoDependencia>(ds);
                return unaLista;
            }
        }

    }
}
