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
    public class DALEstadoSolicDetalle
    {

        public List<EstadoSolicDetalle> EstadoSolDetallesTraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EstadoSolDetallesTraerTodos"))
            {
                List<EstadoSolicDetalle> unaLista = new List<EstadoSolicDetalle>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<EstadoSolicDetalle>(ds);
                return unaLista;
            }
        }



        public static EstadoSolicDetalle MapearEstadoUno(DataSet ds)
        {
            EstadoSolicDetalle ResEstadoSolicDetalle = new EstadoSolicDetalle();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ResEstadoSolicDetalle.IdEstadoSolicDetalle = (int)row["IdEstadoSolicDetalle"];
                    ResEstadoSolicDetalle.DescripEstadoSolicDetalle = row["DescripEstadoSolicDetalle"].ToString();
                }
                return ResEstadoSolicDetalle;
            }
            catch (Exception es)
            {

                throw;
            }
        }

    }
}
