using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Data;
using System.Data.SqlClient;

namespace ARTEC.DAL
{
    public class DALDireccion
    {
        public List<Direccion> DireccionTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DireccionTraerTodos"))
                {
                    List<Direccion> unaLista = new List<Direccion>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Direccion>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Provincia> DireccionProvinciaTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DireccionProvinciaTraerTodos"))
                {
                    List<Provincia> unaLista = new List<Provincia>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Provincia>(ds);
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
