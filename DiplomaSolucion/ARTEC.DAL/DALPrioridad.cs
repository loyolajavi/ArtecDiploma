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
    public class DALPrioridad
    {

        public List<Prioridad> PrioridadTraerTodos()
        {
            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PrioridadTraerTodos"))
            {
                List<Prioridad> unaLista = new List<Prioridad>();
                unaLista = Mapeador.Mapear<Prioridad>(ds);
                return unaLista;
            }
        } 

    }
}
