using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;


namespace ARTEC.BLL
{
    public class BLLPrioridad
    {

        DALPrioridad GestorPrioridad = new DALPrioridad();

        public List<Prioridad> PrioridadTraerTodos()
        {
            return GestorPrioridad.PrioridadTraerTodos();
        }

    }
}
