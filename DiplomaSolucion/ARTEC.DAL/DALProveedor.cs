﻿using System;
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
    public class DALProveedor
    {

        public List<Proveedor> ProveedorTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ProveedorTraerTodos"))
                {
                    List<Proveedor> unaLista = new List<Proveedor>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Proveedor>(ds);
                    return unaLista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static Proveedor MapearProveedorUno(DataSet ds)
        {
            Proveedor ResProveedor = new Proveedor();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    try
                    {
                        ResProveedor.IdProveedor = (int)row["IdProveedor"];
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ResProveedor.AliasProv = row["AliasProv"].ToString();
                    }
                    catch (Exception es)
                    {
                    }
                    try
                    {
                        ResProveedor.ContactoProv = row["ContactoProv"].ToString();
                    }
                    catch (Exception es)
                    {
                    }
                    try
                    {
                        ResProveedor.MailContactoProv = row["MailContactoProv"].ToString();
                    }
                    catch (Exception es)
                    {
                    }
                    //ResProveedor.unasCategorias;
                    //ResProveedor.unasDirecciones;
                    //ResProveedor.unosTelefonos;
                }
                return ResProveedor;
            }
            catch (Exception es)
            {

                throw;
            }
        }



        public List<Categoria> ProveedorTraerCategorias(int IdProveedor)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", IdProveedor)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ProveedorTraerCategorias", parameters))
                {
                    List<Categoria> ListaCateg = new List<Categoria>();
                    ListaCateg = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                    return ListaCateg;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Telefono> ProveedorTraerTelefonos(int IdProveedor)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", IdProveedor)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ProveedorTraerTelefonos", parameters))
                {
                    List<Telefono> ListaTel = new List<Telefono>();
                    ListaTel = FRAMEWORK.Persistencia.Mapeador.Mapear<Telefono>(ds);
                    return ListaTel;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Direccion> ProveedorTraerDirecciones(int IdProveedor)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdProveedor", IdProveedor)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ProveedorTraerDirecciones", parameters))
                {
                    List<Direccion> ListaDir = new List<Direccion>();
                    ListaDir = FRAMEWORK.Persistencia.Mapeador.Mapear<Direccion>(ds);
                    return ListaDir;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public Proveedor ProveedorBuscar(string NomProveedor)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NomProveedor", NomProveedor)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ProveedorBuscar", parameters))
                {
                    Proveedor unProv = new Proveedor();
                    unProv = FRAMEWORK.Persistencia.Mapeador.MapearUno<Proveedor>(ds);
                    return unProv;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool ProveedorCrear(Proveedor nuevoProveedor)
        {
            SqlParameter[] parametersProvCrear = new SqlParameter[]
			{
                new SqlParameter("@AliasProv", nuevoProveedor.AliasProv),
                new SqlParameter("@ContactoProv", nuevoProveedor.ContactoProv),
                new SqlParameter("@MailContactoProv", nuevoProveedor.MailContactoProv)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "ProveedorCrear", parametersProvCrear);
                int IdProvRes = Decimal.ToInt32(Resultado);
                nuevoProveedor.IdProveedor = IdProvRes;

                //Agregar Categorias
                if (nuevoProveedor.unasCategorias != null && nuevoProveedor.unasCategorias.Count > 0)
                {
                    foreach (Categoria unaCat in nuevoProveedor.unasCategorias)
                    {
                        SqlParameter[] parametersCat = new SqlParameter[]
			            {
                            new SqlParameter("@IdCategoria", unaCat.IdCategoria),
                            new SqlParameter("@IdProveedor", nuevoProveedor.IdProveedor)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CategoriaProvAsociar", parametersCat);
                    }
                }

                //Agregar Telefonos
                if (nuevoProveedor.unosTelefonos != null && nuevoProveedor.unosTelefonos.Count > 0)
                {
                    foreach (Telefono unTel in nuevoProveedor.unosTelefonos)
                    {
                        SqlParameter[] parametersTel = new SqlParameter[]
			            {
                            new SqlParameter("@CodArea", unTel.CodArea),
                            new SqlParameter("@NroTelefono", unTel.NroTelefono),
                            new SqlParameter("@IdTipoTelefono", unTel.unTipoTelefono.IdTipoTelefono)
			            };

                        var ResTel = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "TelefonoCrear", parametersTel);
                        int IdTelRes = Decimal.ToInt32(ResTel);
                        unTel.IdTelefono = IdTelRes;

                        SqlParameter[] parametersRelTel = new SqlParameter[]
			            {
                            new SqlParameter("@IdProveedor", nuevoProveedor.IdProveedor),
                            new SqlParameter("@IdTelefono", unTel.IdTelefono)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "ProveedorTelAsociar", parametersRelTel);
                    }
                }

                //Agregar Direcciones
                if (nuevoProveedor.unasDirecciones != null && nuevoProveedor.unasDirecciones.Count > 0)
                {
                    foreach (Direccion unaDire in nuevoProveedor.unasDirecciones)
                    {
                        SqlParameter[] parametersTel = new SqlParameter[]
			            {
                            new SqlParameter("@Calle", unaDire.Calle),
                            new SqlParameter("@NumeroCalle", unaDire.NumeroCalle),
                            new SqlParameter("@Piso", unaDire.Piso),
                            new SqlParameter("@Localidad", unaDire.Localidad),
                            new SqlParameter("@IdProvincia", unaDire.unaProvincia.IdProvincia)
			            };

                        var ResDir = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "DireccionCrear", parametersTel);
                        int IdDirRes = Decimal.ToInt32(ResDir);
                        unaDire.IdDireccion = IdDirRes;

                        SqlParameter[] parametersRelDire = new SqlParameter[]
			            {
                            new SqlParameter("@IdProveedor", nuevoProveedor.IdProveedor),
                            new SqlParameter("@IdDireccion", unaDire.IdDireccion),
                            
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "ProveedorDireAsociar", parametersRelDire);
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
    }
}
