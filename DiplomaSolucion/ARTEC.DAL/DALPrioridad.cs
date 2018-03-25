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
    public class DALPrioridad
    {

        public List<Prioridad> PrioridadTraerTodos()
        {
            //using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PrioridadTraerTodos"))
            //{
            //    List<Prioridad> unaLista = new List<Prioridad>();
            //    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Prioridad>(ds);
            //    return unaLista;
            //}

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", Idioma.unIdiomaActual)
            };
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PrioridadTraerTodosPorIdioma", parameters))
                {
                    List<Prioridad> unaLista = new List<Prioridad>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Prioridad>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }

        } 

    }
}
