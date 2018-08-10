using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLTelefono
    {
        DALTelefono GestorTelefono = new DALTelefono();

        public List<Telefono> TelefonoTraerTodos()
        {
            return GestorTelefono.TelefonoTraerTodos();
        }


        public List<TipoTelefono> TelefonoTipoTraerTodos()
        {
            return GestorTelefono.TelefonoTipoTraerTodos();
        }
    }
}
