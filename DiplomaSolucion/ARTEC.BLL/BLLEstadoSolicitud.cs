using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;



namespace ARTEC.BLL
{
    public class BLLEstadoSolicitud
    {

        DALEstadoSolicitud GestorEstadoSolicitud = new DALEstadoSolicitud();

        public List<EstadoSolicitud> EstadoSolicitudTraerTodos()
        {
            return GestorEstadoSolicitud.EstadoSolicitudTraerTodos();
        }

    }
}
