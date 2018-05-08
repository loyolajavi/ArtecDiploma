using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLUsuario
    {

        DALUsuario GestorUsuario = new DALUsuario();

        public List<Usuario> UsuarioTraerTodos()
        {
            return GestorUsuario.UsuarioTraerTodos();
        }


        public bool UsuarioTraerPorLogin(string NomUs, string PassHash)
        {
            try
            {
                if (GestorUsuario.UsuarioTraerPorLogin(NomUs, PassHash))
                {
                    return true;
                    
                }
            }
            catch (Exception es)
            {
                //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                throw;
            }
            
            return false;
            
        }

    }
}
