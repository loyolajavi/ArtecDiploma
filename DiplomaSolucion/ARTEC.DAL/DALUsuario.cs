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
    public class DALUsuario
    {

        public List<Usuario> UsuarioTraerTodos()
        {
            try
            {
                using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerTodos"))
                {
                    List<Usuario> unaLista = new List<Usuario>();
                    unaLista = Mapeador.Mapear<Usuario>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }

    }
}
