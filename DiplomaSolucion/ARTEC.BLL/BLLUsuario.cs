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
                List<IFamPat> unasFamilias;
                //Primero traigo los permisos directos que tiene usuario (Familias y Patentes)
                unasFamilias = GestorUsuario.UsuarioTraerPermisos(IdUsuario);
                //Segundo veo si aquellos permisos (1), tienen subpermisos (Familias y/o Patentes) y los agrego. La variable unasFamilias se modifica en las funciones de la BLL y DAL directamente.
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


        public bool UsuarioVerificarNomUs(string NomUs)
        {
            try
            {
                if (GestorUsuario.UsuarioVerificarNomUs(NomUs))
                    return true;
            }
            catch (Exception es)
            {
                //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                throw;
            }

            return false;

        }


        public Usuario UsuarioTraerDatosPorNomUs(string NomUs)
        {
            try
            {
                return GestorUsuario.UsuarioTraerDatosPorNomUs(NomUs);
            }
            catch (Exception es)
            {
                //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                throw;
            }


        }



        public bool UsuarioModificarPermisos(List<IFamPat> PerAgregar, List<IFamPat> PerQuitar, int IdUsuario)
        {
            try
            {
                if (PerAgregar.Count > 0)
                    GestorUsuario.UsuarioAgregarPermisos(PerAgregar, IdUsuario);
                if (PerQuitar.Count > 0)
                    GestorUsuario.UsuarioQuitarPermisos(PerQuitar, IdUsuario);
                return true;//REVISAR TRUE T FALSE
            }
            catch (Exception es)
            {
                throw;
            }
            
        }
    }
}
