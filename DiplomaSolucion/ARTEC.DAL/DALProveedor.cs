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
    public class DALProveedor
    {

        public List<Proveedor> ProveedorTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ProveedorTraerTodos"))
                {
                    List<Proveedor> unaLista = new List<Proveedor>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Proveedor>(ds);
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
