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
    public class DALMarca
    {

        public List<Marca> MarcaTraerPorIdCategoria(int IdCat, int TipoBien)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", IdCat),
                new SqlParameter("@IdTipoBien", TipoBien)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "MarcaTraerPorIdCategoria", parameters))
            {
                List<Marca> unaLista = new List<Marca>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Marca>(ds);
                return unaLista;
            }
        }

    }
}
