using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLProveedor
    {

        DALProveedor GestorProveedor = new DALProveedor();

        public List<Proveedor> ProveedorTraerTodos()
        {
            return GestorProveedor.ProveedorTraerTodos();
        }



        public List<Categoria> ProveedorTraerCategorias(int IdProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorTraerCategorias(IdProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Telefono> ProveedorTraerTelefonos(int IdProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorTraerTelefonos(IdProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Direccion> ProveedorTraerDirecciones(int IdProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorTraerDirecciones(IdProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public Proveedor ProveedorBuscar(string NomProveedor)
        {
            try
            {
                return GestorProveedor.ProveedorBuscar(NomProveedor);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool ProveedorCrear(Proveedor nuevoProveedor)
        {
            try
            {
                if (GestorProveedor.ProveedorCrear(nuevoProveedor))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
