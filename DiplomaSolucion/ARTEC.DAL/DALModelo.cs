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
    public class DALModelo
    {
        public List<ModeloVersion> ModeloTraerPorMarcaCategoria(int IdCat, int laMarca)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", IdCat),
                new SqlParameter("@IdMarca", laMarca)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ModeloTraerPorMarcaCategoria", parameters))
            {
                List<ModeloVersion> unaLista = new List<ModeloVersion>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<ModeloVersion>(ds);
                return unaLista;
            }
        }

    }
}
