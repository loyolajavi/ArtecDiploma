using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.DAL.Servicios;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.BLL.Servicios
{
    public class BLLDV
    {

        DALDV GestorDV = new DALDV();

        public bool DVActualizarDVH(object unObjeto)
        {
            string TipoObj;
            string ClaveStr;
            string ClaveHash;

            try
            {
                TipoObj = unObjeto.GetType().Name;
                if (TipoObj == "Usuario")
                {
                    Usuario unUsuario = unObjeto as Usuario;
                    ClaveStr = unUsuario.IdUsuario.ToString() + unUsuario.NombreUsuario + unUsuario.Pass + unUsuario.IdiomaUsuarioActual.ToString() +
                               unUsuario.Nombre + unUsuario.Apellido + unUsuario.Mail + unUsuario.Activo.ToString();
                    ClaveHash = ServicioSecurizacion.AplicarHash(ClaveStr);

                    long Acum = 0;
                    foreach (char letra in ClaveHash)
                    {

                        Acum += (long)letra;
                    }

                    if (GestorDV.DVActualizarDVH(unUsuario.IdUsuario, Acum, unUsuario.GetType().Name, "IdUsuario"))
                        return true;
                }
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }



    }
}
