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
    public class DALCargo
    {

        public List<Cargo> CargosTraerTodos()
        {
            //using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CargosTraerTodos"))
            //{
            //    List<Cargo> unaLista = new List<Cargo>();
            //    unaLista = MapearCargos(ds);
            //    return unaLista;
            //}

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", Idioma.unIdiomaActual)
            };
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CargosTraerTodosPorIdioma", parameters))
                {
                    List<Cargo> unaLista = new List<Cargo>();
                    unaLista = MapearCargos(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {

            }

        }

        private List<Cargo> MapearCargos(DataSet ds)
        {
            List<Cargo> ResCargos = new List<Cargo>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Cargo unCargo = new Cargo();

                    unCargo.IdCargo = (int)row["IdCargo"];
                    unCargo.DescripCargo = row["DescripCargo"].ToString();
                    ResCargos.Add(unCargo);
                }
                return ResCargos;
            }
            catch (Exception es)
            {
                //VER:Excepciones
                throw;
            }
        }


    }
}
