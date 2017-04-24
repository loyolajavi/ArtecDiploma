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
    public class DALUsuario
    {

        public List<Usuario> UsuarioTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerTodos"))
                {
                    List<Usuario> unaLista = new List<Usuario>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Usuario>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }


        public bool UsuarioTraerPorLogin(string NomUs, string PassHash)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Us", NomUs),
                new SqlParameter("@Pass", PassHash)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerPorLogin", parameters))
                {
                    FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado = FRAMEWORK.Persistencia.Mapeador.MapearUno<Usuario>(ds);
                    if (!string.IsNullOrEmpty(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario))
                    {
                        return true;
                    }
                }
            }
            catch (Exception es)
            {
                throw;
            }
            return false;

        }


    }
}
