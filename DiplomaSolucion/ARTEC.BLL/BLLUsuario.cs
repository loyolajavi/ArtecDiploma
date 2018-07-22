using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.BLL.Servicios;
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


        public List<Usuario> UsuarioTraerTodosActivos()
        {
            return GestorUsuario.UsuarioTraerTodosActivos();
        }


        public bool UsuarioTraerPorLogin(string NomUs, string PassHash)
        {
            try
            {
                if (GestorUsuario.UsuarioTraerDatosPorNomUs(NomUs).Activo == 0)
                {
                    return false;
                }

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
                return true;
            }
            catch (Exception es)
            {
                throw;
            }
            
        }

        public void UsuarioModificarNomUs(int IdUsuario, string NomUs)
        {
            try
            {
                GestorUsuario.UsuarioModificarNomUs(IdUsuario, NomUs);
            }
            catch (Exception es)
            {
                
                throw;
            }
        }

        public void UsuarioModificarNombre(int IdUsuario, string Nombre)
        {
            try
            {
                GestorUsuario.UsuarioModificarNombre(IdUsuario, Nombre);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void UsuarioModificarApellido(int IdUsuario, string Apellido)
        {
            try
            {
                GestorUsuario.UsuarioModificarApellido(IdUsuario, Apellido);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void UsuarioModificarMail(int IdUsuario, string Mail)
        {
            try
            {
                GestorUsuario.UsuarioModificarMail(IdUsuario, Mail);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void UsuarioModificarPass(int IdUsuario, string Pass)
        {
            try
            {
                GestorUsuario.UsuarioModificarPass(IdUsuario, Pass);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool UsuarioCrear(Usuario unUsuario)
        {
            try
            {
                unUsuario.Activo = 1;
                if (GestorUsuario.UsuarioCrear(unUsuario))
                        return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool UsuarioEliminar(Usuario unUsuario)
        {
            try
            {
                unUsuario.Activo = 0;
                long ResAcum = FRAMEWORK.Servicios.ServicioDV.DVCalcularDVH(unUsuario);
                if (ResAcum > 0)
                {
                    unUsuario.DVH = ResAcum;
                    if (GestorUsuario.UsuarioEliminar(unUsuario.IdUsuario, unUsuario.DVH))
                        return true;
                }
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool UsuarioReactivar(Usuario unUsuario)
        {
            try
            {
                unUsuario.Activo = 1;
                 long ResAcum = FRAMEWORK.Servicios.ServicioDV.DVCalcularDVH(unUsuario);
                 if (ResAcum > 0)
                 {
                     unUsuario.DVH = ResAcum;
                     if (GestorUsuario.UsuarioReactivar(unUsuario.IdUsuario, unUsuario.DVH))
                         return true;
                 }
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public bool UsuarioModificar(Usuario UsModif, List<IFamPat> PerAgregar, List<IFamPat> PerQuitar, Usuario unUsuarioDVH)
        {

            int flag = 0;

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();

                //NombreUsuario
                if (UsModif.NombreUsuario != null && !string.IsNullOrEmpty(UsModif.NombreUsuario))
                {
                    UsuarioModificarNomUs(UsModif.IdUsuario, UsModif.NombreUsuario);
                    unUsuarioDVH.NombreUsuario = UsModif.NombreUsuario;
                    flag = 1;
                }
                    
                //Pass
                if (UsModif.Pass != null && !string.IsNullOrEmpty(UsModif.Pass))
                {
                    UsuarioModificarPass(UsModif.IdUsuario, UsModif.Pass);
                    unUsuarioDVH.Pass = UsModif.Pass;
                    flag = 1;
                }
                    
                //Nombre
                if (UsModif.Nombre != null && !string.IsNullOrEmpty(UsModif.Nombre))
                {
                    UsuarioModificarNombre(UsModif.IdUsuario, UsModif.Nombre);
                    unUsuarioDVH.Nombre = UsModif.Nombre;
                    flag = 1;
                }
                    
                //Apellido
                if (UsModif.Apellido != null && !string.IsNullOrEmpty(UsModif.Apellido))
                {
                    UsuarioModificarApellido(UsModif.IdUsuario, UsModif.Apellido);
                    unUsuarioDVH.Apellido = UsModif.Apellido;
                    flag = 1;
                }
                    
                //Mail
                if (UsModif.Mail != null && !string.IsNullOrEmpty(UsModif.Mail))
                {
                    UsuarioModificarMail(UsModif.IdUsuario, UsModif.Mail);
                    unUsuarioDVH.Mail = UsModif.Mail;
                    flag = 1;
                }
                    
                //Permisos
                if (PerAgregar.Count > 0)
                {
                    GestorUsuario.UsuarioAgregarPermisos(PerAgregar, UsModif.IdUsuario);
                    flag = 1;
                }
                if (PerQuitar.Count > 0)
                {
                    GestorUsuario.UsuarioQuitarPermisos(PerQuitar, UsModif.IdUsuario);
                    flag = 1;
                }
                
                //DVH
                if (flag == 1)
                {
                    long ResAcum = FRAMEWORK.Servicios.ServicioDV.DVCalcularDVH(unUsuarioDVH);
                    if (ResAcum > 0)
                    {
                        unUsuarioDVH.DVH = ResAcum;
                        if (FRAMEWORK.Servicios.ServicioDV.DVActualizarDVH(unUsuarioDVH.IdUsuario, unUsuarioDVH.DVH, unUsuarioDVH.GetType().Name, "IdUsuario"))
                        {
                            FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }


        }




    }
}
