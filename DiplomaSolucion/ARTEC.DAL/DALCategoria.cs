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
    public class DALCategoria
    {

        public List<Categoria> CategoriaTraerTodosHard()
        {
            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodosHard"))
            {
                List<Categoria> unasCategorias = new List<Categoria>();
                unasCategorias = Mapeador.Mapear<Categoria>(ds);
                return unasCategorias;
            }
        }

    }
}
