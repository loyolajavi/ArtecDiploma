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
                        ResProveedor.MailAlternativoProv = row["MailAlternativoProv"].ToString();
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
                    try
                    {
                        ResProveedor.RazonSocialProv = row["RazonSocialProv"].ToString();
                    }
                    catch (Exception)
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


    }
}
