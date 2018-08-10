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
    public class DALTelefono
    {
        public List<Telefono> TelefonoTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "TelefonoTraerTodos"))
                {
                    List<Telefono> unaLista = new List<Telefono>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Telefono>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<TipoTelefono> TelefonoTipoTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "TelefonoTipoTraerTodos"))
                {
                    List<TipoTelefono> unaLista = new List<TipoTelefono>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<TipoTelefono>(ds);
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
