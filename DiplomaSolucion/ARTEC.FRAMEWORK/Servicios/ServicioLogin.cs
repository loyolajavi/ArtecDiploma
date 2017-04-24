using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioLogin
    {

        
        private static ServicioLogin _loginUnico;

        private ServicioLogin()
        {

        }


        public static ServicioLogin GetLoginUnico()
        {
            if (_loginUnico == null)
            {
                _loginUnico = new ServicioLogin();
            }

            return _loginUnico;
        }

        //Para tener los datos del usuarioLogueado en una única instancia
        private Usuario _usuarioLogueado;

        public Usuario UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }



    }
}
