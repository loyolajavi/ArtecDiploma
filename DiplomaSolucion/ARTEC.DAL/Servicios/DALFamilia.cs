using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.DAL.Servicios
{
    public class DALFamilia
    {


        public void FamiliaTraerFamiliasHijas(ARTEC.ENTIDADES.Servicios.IFamPat unaFamilia)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdFamilia", unaFamilia.IdIFamPat)
			};

            SqlParameter[] parameters2 = new SqlParameter[]
			{
                new SqlParameter("@IdFamilia", unaFamilia.IdIFamPat)
			};

            try
            {
                if (unaFamilia.GetType().Name == "Familia")
                {
                    //Busco las familias que contenga la FAMILIA en revisión y llamo a Agregar de la Entidad Familia y queda guardado en el argumento, por lo que no tengo q retornar nada
                    using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaTraerFamiliasHijas", parameters))
                    {
                        List<IFamPat> unasFamiliasHijas = new List<IFamPat>();
                        unasFamiliasHijas = DALUsuario.MapearFamilias(ds);

                        foreach (IFamPat FamiliaHija in unasFamiliasHijas)
                        {
                            unaFamilia.Agregar(FamiliaHija);
                            FamiliaTraerFamiliasHijas(FamiliaHija);
                        }
                    }
                    //IDEM anterior pero con patentes.. Busco las patentes que contenga la FAMILIA en revisión y llamo a Agregar de la Entidad Familia y queda guardado en el argumento, por lo que no tengo q retornar nada
                    using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaTraerPatentes", parameters2))
                    {
                        List<IFamPat> unasPatentes = new List<IFamPat>();
                        unasPatentes = DALUsuario.MapearPatentes(ds);

                        foreach (IFamPat unaPatente in unasPatentes)
                        {
                            unaFamilia.Agregar(unaPatente);
                        }
                    }
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public List<IFamPat> PermisosTraerTodos()
        {

            List<IFamPat> unosPermisos = new List<IFamPat>();

            try
            {
                  //Traigo las familias
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliasTraerTodas"))
                {
                    List<IFamPat> unasFamilias = new List<IFamPat>();
                    unasFamilias = DALUsuario.MapearFamilias(ds);

                    if (unasFamilias != null && unasFamilias.Count() > 0)
                        unosPermisos.AddRange(unasFamilias);

                    //VER: FALTA TRAER LOS SUBPERMISOS DE LAS FAMILIAS
                }
                //Traigo las patentes
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PatentesTraerTodas"))
                {
                    List<IFamPat> unasPatentes = new List<IFamPat>();
                    unasPatentes = DALUsuario.MapearPatentes(ds);
                    if (unosPermisos != null && unosPermisos.Count() > 0)
                        unosPermisos.AddRange(unasPatentes);
                }
                return unosPermisos;

            }
            catch (Exception es)
            {
                throw;
            }
        }



        public bool FamiliaCrear(IFamPat nuevaFamilia)
        {
            SqlParameter[] parametersFamCrear = new SqlParameter[]
			{
                new SqlParameter("@NombreFamilia", nuevaFamilia.NombreIFamPat)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "FamiliaCrear", parametersFamCrear);
                int IdFamRes = Decimal.ToInt32(Resultado);
                nuevaFamilia.IdIFamPat = IdFamRes;

                if (nuevaFamilia.CantHijos > 0)
                {
                    foreach (IFamPat unPermiso in (nuevaFamilia as Familia).ElementosFamPat)
                    {
                        //Asociar Familia con Familia
                        if (unPermiso.CantHijos > 0)
                        {
                            SqlParameter[] parametersRelFamFam = new SqlParameter[]
			                {
                            new SqlParameter("@IdFamiliaPadre", nuevaFamilia.IdIFamPat),
                            new SqlParameter("@IdFamiliaHijo", unPermiso.IdIFamPat)
			                };

                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaFamiliaAsociar", parametersRelFamFam);
                        }
                        //Asociar Familia con Patente
                        else
                        {
                            SqlParameter[] parametersRelFamPat = new SqlParameter[]
			                {
                            new SqlParameter("@IdFamilia", nuevaFamilia.IdIFamPat),
                            new SqlParameter("@IdPatente", unPermiso.IdIFamPat)
			                };

                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaPatenteAsociar", parametersRelFamPat);
                        }
                    }
                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
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

        public Familia FamiliaBuscar(string NombreIFamPat)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreFamilia", NombreIFamPat)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaBuscar", parameters))
                {
                    Familia unaFam = new Familia();
                    unaFam = FRAMEWORK.Persistencia.Mapeador.MapearUno<Familia>(ds);
                    return unaFam;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool FamiliaModificar(IFamPat AModifFamilia, List<IFamPat> FamQuitarMod, List<IFamPat> FamAgregarMod)
        {
            SqlParameter[] parametersFamModif = new SqlParameter[]
			{
                new SqlParameter("@NombreFamilia", AModifFamilia.NombreIFamPat),
                new SqlParameter("@IdFamilia", AModifFamilia.IdIFamPat)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaModificar", parametersFamModif);

                //Quitar Permisos
                if (FamQuitarMod.Count > 0)
                {
                    foreach (IFamPat unPermiso in FamQuitarMod)
                    {
                        //Quitar Familia
                        if(unPermiso.CantHijos > 0)
                        {
                            SqlParameter[] parametersFamQuitar = new SqlParameter[]
			                {
                            new SqlParameter("@IdFamiliaPadre", AModifFamilia.IdIFamPat),
                            new SqlParameter("@IdFamiliaHijo", unPermiso.IdIFamPat)
			                };

                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaFamiliaDesasociar", parametersFamQuitar);
                        }
                        //Quitar Patente
                        else
                        {
                            SqlParameter[] parametersPatQuitar = new SqlParameter[]
			                {
                            new SqlParameter("@IdFamilia", AModifFamilia.IdIFamPat),
                            new SqlParameter("@IdPatente", unPermiso.IdIFamPat)
			                };

                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaPatenteDesasociar", parametersPatQuitar);
                        }
                        
                    }
                }
                //Agregar Permisos
                if (FamAgregarMod.Count > 0)
                {
                    foreach (IFamPat unPermiso in FamAgregarMod)
                    {
                        //Agregar Familia
                        if (unPermiso.CantHijos > 0)
                        {
                            SqlParameter[] parametersFamAgregar = new SqlParameter[]
			                {
                            new SqlParameter("@IdFamiliaPadre", AModifFamilia.IdIFamPat),
                            new SqlParameter("@IdFamiliaHijo", unPermiso.IdIFamPat)
			                };

                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaFamiliaAsociar", parametersFamAgregar);
                        }
                        //Agregar Patente
                        else
                        {
                            SqlParameter[] parametersPatAgregar = new SqlParameter[]
			                {
                            new SqlParameter("@IdFamilia", AModifFamilia.IdIFamPat),
                            new SqlParameter("@IdPatente", unPermiso.IdIFamPat)
			                };

                            FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaPatenteAsociar", parametersPatAgregar);
                        }
                    }
                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
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

        public List<Usuario> FamiliaUsuariosComprometidos(int IdFamilia)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", IdFamilia)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaUsuariosComprometidos", parameters))
                {
                    List<Usuario> unosUsuarios = new List<Usuario>();
                    unosUsuarios = FRAMEWORK.Persistencia.Mapeador.Mapear<Usuario>(ds);
                    return unosUsuarios;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Usuario> FamiliaUsuariosAsociados(int IdFamilia)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", IdFamilia)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaUsuariosAsociados", parameters))
                {
                    List<Usuario> unosUsuarios = new List<Usuario>();
                    unosUsuarios = FRAMEWORK.Persistencia.Mapeador.Mapear<Usuario>(ds);
                    return unosUsuarios;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool FamiliaEliminar(int IdFamilia)
        {


            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                
            //Quitar Permisos
                //Quitar Familias asociadas
                SqlParameter[] parametersFamQuitar = new SqlParameter[]
			    {
                    new SqlParameter("@IdFamiliaPadre", IdFamilia),
                    new SqlParameter("@IdFamiliaHijo", IdFamilia)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaEliminarAsocFamilias", parametersFamQuitar);
                
                //Quitar Patentes asociadas
                SqlParameter[] parametersPatQuitar = new SqlParameter[]
			    {
                    new SqlParameter("@IdFamilia", IdFamilia)
			    };

                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaEliminarAsocPatentes", parametersPatQuitar);
                
                //Eliminar Familia
                SqlParameter[] parametersFam = new SqlParameter[]
			    {
                    new SqlParameter("@IdFamilia", IdFamilia)
			    };
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "FamiliaEliminar", parametersFam);

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return true;
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
