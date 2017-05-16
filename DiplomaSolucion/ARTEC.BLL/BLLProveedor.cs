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


    }
}
