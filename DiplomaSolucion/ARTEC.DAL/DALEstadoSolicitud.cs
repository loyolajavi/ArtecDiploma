using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.DAL
{
    public class DALEstadoSolicitud
    {

        public List<EstadoSolicitud> EstadoSolicitudTraerTodos()
        {
            //using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EstadoSolicitudTraerTodos"))
            //{
            //    List<EstadoSolicitud> unaLista = new List<EstadoSolicitud>();
            //    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<EstadoSolicitud>(ds);
            //    return unaLista;
            //}


            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", Idioma.unIdiomaActual)
            };
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EstadoSolicitudTraerTodosPorIdioma", parameters))
                {
                    List<EstadoSolicitud> unaLista = new List<EstadoSolicitud>();
                    unaLista = MapearEstadoSolicitud(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private List<EstadoSolicitud> MapearEstadoSolicitud(DataSet ds)
        {
            List<EstadoSolicitud> ResEstadoSolicituds = new List<EstadoSolicitud>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    EstadoSolicitud unEstadoSolicitud = new EstadoSolicitud();

                    unEstadoSolicitud.IdEstadoSolicitud = (int)row["IdEstadoSolicitud"];
                    unEstadoSolicitud.DescripEstadoSolic = row["DescripEstadoSolic"].ToString();
                    ResEstadoSolicituds.Add(unEstadoSolicitud);
                }
                return ResEstadoSolicituds;
            }
            catch (Exception es)
            {
                //VER:Excepciones
                throw;
            }
        }


    }
}
