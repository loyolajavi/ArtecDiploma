using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;

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
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                {
                    //System.Windows.Forms.MessageBox.Show("Log de excepción en BD");
                    //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                    throw;
                }
                else
                    //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                throw;
            }
            return false;

        }


    }
}
