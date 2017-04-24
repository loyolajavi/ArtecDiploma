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
    public class DALCategoria
    {

        /// <summary>
        /// Traer todas las categorías que sean Hardware
        /// </summary>
        /// <returns></returns>
        public List<Categoria> CategoriaTraerTodosHard()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodosHard"))
                {
                    List<Categoria> unasCategorias = new List<Categoria>();
                    unasCategorias = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                    return unasCategorias;
                }
            }
            catch (Exception es)
            {
                throw;
            }
           
        }


        public List<Categoria> CategoriaTraerTodosSoft()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodosSoft"))
            {
                List<Categoria> unasCategorias = new List<Categoria>();
                unasCategorias = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                return unasCategorias;
            }
        }


        public List<Categoria> CategoriaTraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodos"))
            {
                List<Categoria> unasCategorias = new List<Categoria>();
                unasCategorias = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                return unasCategorias;
            }
        }





    }
}
