using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK.Servicios;

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
                    //Obtener permisos (Para Autorizacion)
                    FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos = UsuarioTraerPermisos(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario);
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


        public List<IFamPat> UsuarioTraerPermisos(int IdUsuario)
        {

            Servicios.BLLFamilia ManagerFamilia = new Servicios.BLLFamilia();    

            try
            {
                //return GestorUsuario.UsuarioTraerPermisos(IdUsuario);
                List<IFamPat> unasFamilias;
                unasFamilias = GestorUsuario.UsuarioTraerPermisos(IdUsuario);
                ManagerFamilia.FamiliaTraerSubPermisos(unasFamilias);
                return unasFamilias;

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "UsuarioTraerPermisos");
                throw;
            }
        }


        //ERA PARA PROBAR QUE ME TRAJERA LAS FAMILIAS Y SUS SUBFAMILIAS Y SUBPATENTES , y LAS PATENTES
        //public void MostrarMGBox(List<IFamPat> PermisosVer) 
        //{
        //    foreach (IFamPat unPermiso in PermisosVer)
        //    {
        //        System.Windows.Forms.MessageBox.Show(unPermiso.GetType().ToString() + ": " + unPermiso.NombreIFamPat);
        //        if (unPermiso.CantHijos > 0)
        //        {
        //            MostrarMGBox((unPermiso as Familia).ElementosFamPat);
        //        }


        //    }
        //}




    }
}
