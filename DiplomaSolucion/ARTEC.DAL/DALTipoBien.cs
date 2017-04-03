using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL.MotorBD;
using System.Data;
using System.Data.Sql;

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

    }
}
