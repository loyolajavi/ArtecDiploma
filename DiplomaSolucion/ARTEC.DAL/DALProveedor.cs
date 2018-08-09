using System;
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
    }
}
