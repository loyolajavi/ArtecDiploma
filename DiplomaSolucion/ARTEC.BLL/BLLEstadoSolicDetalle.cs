using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLEstadoSolicDetalle
    {

        DALEstadoSolicDetalle GestorEstadoSolDetalles = new DALEstadoSolicDetalle();

        public List<EstadoSolicDetalle> EstadoSolDetallesTraerTodos()
        {
            return GestorEstadoSolDetalles.EstadoSolDetallesTraerTodos();
        }


    }
}
