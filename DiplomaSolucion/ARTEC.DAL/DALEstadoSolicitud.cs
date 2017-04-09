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
    public class DALEstadoSolicitud
    {

        public List<EstadoSolicitud> EstadoSolicitudTraerTodos()
        {
            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EstadoSolicitudTraerTodos"))
            {
                List<EstadoSolicitud> unaLista = new List<EstadoSolicitud>();
                unaLista = Mapeador.Mapear<EstadoSolicitud>(ds);
                return unaLista;
            }
        }

    }
}
