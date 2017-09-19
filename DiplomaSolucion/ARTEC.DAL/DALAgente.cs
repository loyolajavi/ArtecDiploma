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
    public class DALAgente
    {

        public static List<Agente> MapearAgentes(DataSet ds)
        {
            List<Agente> ResAgentes = new List<Agente>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Agente unAgente = new Agente();

                       unAgente.IdAgente = (int)row["IdAgente"];
                        unAgente.NombreAgente = row["NombreAgente"].ToString();
                        unAgente.ApellidoAgente = row["ApellidoAgente"].ToString();
                    
                    //unAgente.unaDependencia = 
                    //unAgente.unCargo = 
                    ResAgentes.Add(unAgente);
                }
                return ResAgentes;
            }
            catch (Exception es)
            {
                //VER:Excepciones
                throw;
            }
        }

    }
}
