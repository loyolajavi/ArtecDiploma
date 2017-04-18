using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL.MotorBD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ARTEC.DAL
{
    public class DALTipoBien
    {

        public List<TipoBien> TraerTodos()
        {
            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "TipoBienTraerTodos"))
            {

                List<TipoBien> unaLista = new List<TipoBien>();
                unaLista = Mapeador.Mapear<TipoBien>(ds);
                return unaLista;

            }
        }


        public TipoBien TipoBienTraerTipoBienPorIdCategoria(int idCategoria)
        {


            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "TipoBienTraerTipoBienPorIdCategoria", parameters))
            {

                TipoBien unaLista = new TipoBien();
                unaLista = Mapeador.MapearUno<TipoBien>(ds);
                return unaLista;

            }
        }

    }
}
