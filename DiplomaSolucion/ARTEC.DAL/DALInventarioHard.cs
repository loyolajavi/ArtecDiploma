using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Data.SqlClient;

namespace ARTEC.DAL
{
    public class DALInventarioHard
    {

        public void InventarioHardCrear(Hardware unBien)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdBienEspecif", unBien.IdBien),
                new SqlParameter("@SerieKey ", unBien.unInventarioAlta.SerieKey),
                //REVISAR
                new SqlParameter("@IdAdquisicion ", 1),
                new SqlParameter("@IdDeposito", unBien.unInventarioAlta.unDeposito.IdDeposito),
                new SqlParameter("@IdEstadoInventario ", unBien.unInventarioAlta.unEstado.IdEstadoInventario),
			};


        }




    }
}
