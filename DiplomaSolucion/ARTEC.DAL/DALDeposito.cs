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
    public class DALDeposito
    {

        public List<Deposito> DepositoTraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DepositoTraerTodos"))
            {
                List<Deposito> unaLista = new List<Deposito>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Deposito>(ds);
                return unaLista;
            }
        }

    }
}
