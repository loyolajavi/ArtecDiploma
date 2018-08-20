﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.ENTIDADES.Servicios;

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
                    //System.Windows.Forms.MessageBox.Show("Log de excepción en BD");
                    //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                    throw;
            }
            return false;

        }



        public List<IFamPat> UsuarioTraerPermisos(int IdUsuario)
        {

            List<IFamPat> unosPermisos = new List<IFamPat>();

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario)
			};
            SqlParameter[] parameters2 = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario)
			};

            try
            {
                //Traigo las familias
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerFamilias", parameters))
                {
                    List<IFamPat> unasFamilias = new List<IFamPat>();
                    unasFamilias = MapearFamilias(ds);

                    if (unasFamilias != null && unasFamilias.Count() > 0)
                        unosPermisos.AddRange(unasFamilias);
                }
                //Traigo las patentes
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerPatentes", parameters2))
                {
                    List<IFamPat> unasPatentes = new List<IFamPat>();
                    unasPatentes = MapearPatentes(ds);
                        unosPermisos.AddRange(unasPatentes);
                }

                return unosPermisos;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<IFamPat> MapearFamilias(DataSet ds)
        {
            List<IFamPat> ResElementosFamPat = new List<IFamPat>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    IFamPat unaFamilia = new Familia();
                    unaFamilia.IdIFamPat = (int)row["IdFamilia"];
                    unaFamilia.NombreIFamPat = row["NombreFamilia"].ToString();
                    ResElementosFamPat.Add(unaFamilia);
                }
                return ResElementosFamPat;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static List<IFamPat> MapearPatentes(DataSet ds)
        {
            List<IFamPat> ResElementosFamPat = new List<IFamPat>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    IFamPat unaPatente = new Patente();
                    unaPatente.IdIFamPat = (int)row["IdPatente"];
                    unaPatente.NombreIFamPat = row["NombrePatente"].ToString();
                    ResElementosFamPat.Add(unaPatente);
                }
                return ResElementosFamPat;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public bool UsuarioVerificarNomUs(string NomUs)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Us", NomUs)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                string NomUsRes = (string) FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioVerificarNomUs", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (!string.IsNullOrEmpty(NomUsRes))
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

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Us", NomUs)
			};

            Usuario elUsuario = new Usuario();

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerDatosPorNomUs", parameters))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        elUsuario = FRAMEWORK.Persistencia.Mapeador.MapearUno<Usuario>(ds);
                        return elUsuario;
                    }
                    return elUsuario;
                }
            }
            catch (Exception es)
            {
                //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                throw;
            }

        }



        public bool UsuarioAgregarPermisos(List<IFamPat> PerAgregar, int IdUsuario)
        {
            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();

                foreach (IFamPat unPermiso in PerAgregar)
                {
                    if (unPermiso.CantHijos > 0)
                        UsuarioAgregarFamilia(unPermiso as Familia, IdUsuario);
                    else
                        UsuarioAgregarPatente(unPermiso as Patente, IdUsuario);
                }

                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public void UsuarioAgregarFamilia(Familia unaFamilia, int IdUsuario)
        {
            try
            {
                SqlParameter[] parametersFam = new SqlParameter[]
			    {
                    new SqlParameter("@IdFamilia", unaFamilia.IdIFamPat),
                    new SqlParameter("@IdUsuario", IdUsuario)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioAgregarFamilia", parametersFam);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void UsuarioAgregarPatente(Patente unaPatente, int IdUsuario)
        {
            try
            {
                SqlParameter[] parametersPat = new SqlParameter[]
			    {
                    new SqlParameter("@IdPatente", unaPatente.IdIFamPat),
                    new SqlParameter("@IdUsuario", IdUsuario)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioAgregarPatente", parametersPat);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool UsuarioQuitarPermisos(List<IFamPat> PerQuitar, int IdUsuario)
        {
            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();

                foreach (IFamPat unPermiso in PerQuitar)
                {
                    if (unPermiso.CantHijos > 0)
                        UsuarioQuitarFamilia(unPermiso as Familia, IdUsuario);
                    else
                        UsuarioQuitarPatente(unPermiso as Patente, IdUsuario);
                }

                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public void UsuarioQuitarFamilia(Familia unaFamilia, int IdUsuario)
        {
            try
            {
                SqlParameter[] parametersFam = new SqlParameter[]
			    {
                    new SqlParameter("@IdFamilia", unaFamilia.IdIFamPat),
                    new SqlParameter("@IdUsuario", IdUsuario)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioQuitarFamilia", parametersFam);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void UsuarioQuitarPatente(Patente unaPatente, int IdUsuario)
        {
            try
            {
                SqlParameter[] parametersPat = new SqlParameter[]
			    {
                    new SqlParameter("@IdPatente", unaPatente.IdIFamPat),
                    new SqlParameter("@IdUsuario", IdUsuario)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioQuitarPatente", parametersPat);
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public void UsuarioModificarNomUs(int IdUsuario, string NomUs)
        {

            SqlParameter[] parametersNomUs = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@NomUs", NomUs)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioModificarNomUs", parametersNomUs);
                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public void UsuarioModificarNombre(int IdUsuario, string Nombre)
        {
            SqlParameter[] parametersNombre = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Nombre", Nombre)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioModificarNombre", parametersNombre);
                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public void UsuarioModificarApellido(int IdUsuario, string Apellido)
        {
            SqlParameter[] parametersApellido = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Apellido", Apellido)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioModificarApellido", parametersApellido);
                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public void UsuarioModificarMail(int IdUsuario, string Mail)
        {
            SqlParameter[] parametersMail = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Mail", Mail)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioModificarMail", parametersMail);
                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }





        public void UsuarioModificarPass(int IdUsuario, string Pass)
        {
            SqlParameter[] parametersPass = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Pass", Pass)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioModificarPass", parametersPass);
                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


        public bool UsuarioCrear(Usuario unUsuario)
        {
            SqlParameter[] parametersUsCrear = new SqlParameter[]
			{
                new SqlParameter("@NomUs", unUsuario.NombreUsuario),
                new SqlParameter("@Pass", unUsuario.Pass),
                new SqlParameter("@Nombre", unUsuario.Nombre),
                new SqlParameter("@Apellido", unUsuario.Apellido),
                new SqlParameter("@Mail", unUsuario.Mail),
                new SqlParameter("@Idioma", unUsuario.IdiomaUsuarioActual),
                new SqlParameter("@Activo", unUsuario.Activo)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "UsuarioCrear", parametersUsCrear);
                int IdUsuarioRes = Decimal.ToInt32(Resultado);
                unUsuario.IdUsuario = IdUsuarioRes;

                foreach (IFamPat unPermiso in unUsuario.Permisos)
                {
                    if (unPermiso.CantHijos > 0)
                        UsuarioAgregarFamilia(unPermiso as Familia, IdUsuarioRes);
                    else
                        UsuarioAgregarPatente(unPermiso as Patente, IdUsuarioRes);
                }

                long ResAcum = ServicioDV.DVCalcularDVH(unUsuario);
                if (ResAcum > 0)
                {
                    if (ServicioDV.DVActualizarDVH(unUsuario.IdUsuario, ResAcum, unUsuario.GetType().Name, "IdUsuario"))
                    {
                        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                        return true;
                    }
                }
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
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





        public bool UsuarioEliminar(int IdUsuario, long unDVH)
        {
            SqlParameter[] parametersUsEliminar = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@DVH", unDVH)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "UsuarioEliminar", parametersUsEliminar);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (FilasAfectadas > 0)
                    return true;
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

        public bool UsuarioReactivar(int IdUsuario, long unDVH)
        {
            SqlParameter[] parametersUsReactivar = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@DVH", unDVH)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "UsuarioReactivar", parametersUsReactivar);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (FilasAfectadas > 0)
                    return true;
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


        public List<Usuario> UsuarioTraerTodosActivos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerTodosActivos"))
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


        //public bool UsuarioActualizarDVH(int IdUsuario, long Acum)
        //{

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("IdUsuario", IdUsuario),
        //        new SqlParameter("ValorAcum", Acum),
        //        new SqlParameter("NombreTabla", "Usuario")
        //    };

        //    try
        //    {
        //        FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
        //        int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "UsuarioActualizarDVH", parameters);
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
        //        if (FilasAfectadas > 0)
        //            return true;
        //        return false;
        //    }
        //    catch (Exception es)
        //    {
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
        //        throw;
        //    }
        //    finally
        //    {
        //        if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
        //            FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
        //    }
        //}



    }
}
