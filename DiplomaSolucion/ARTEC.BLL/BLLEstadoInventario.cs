using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLEstadoInventario
    {
        DALEstadoInventario GestorEstadoInventario = new DALEstadoInventario();

        public List<EstadoInventario> EstadoInvTraerTodos()
        {
            return GestorEstadoInventario.EstadoInvTraerTodos();
        }


    }
}
