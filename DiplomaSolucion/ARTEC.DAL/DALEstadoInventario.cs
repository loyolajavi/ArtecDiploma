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
    public class DALEstadoInventario
    {
        public List<EstadoInventario> EstadoInvTraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EstadoInvTraerTodos"))
            {
                List<EstadoInventario> unaLista = new List<EstadoInventario>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<EstadoInventario>(ds);
                return unaLista;
            }
        }



        public bool InventarioEstadoUpdate(int IdInv)
        {
            SqlParameter[] parametersEstInv = new SqlParameter[]
			{
                new SqlParameter("@IdInventario", IdInv)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "InventarioEstadoUpdate", parametersEstInv);
                return true;
            }
            catch (Exception es)
            {
                return false;
                throw;
            }

        }

    }
}
