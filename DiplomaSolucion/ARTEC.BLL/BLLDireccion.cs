using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLDireccion
    {
        DALDireccion GestorDireccion = new DALDireccion();

        public List<Direccion> DireccionTraerTodos()
        {
            return GestorDireccion.DireccionTraerTodos();
        }

        public List<Provincia> DireccionProvinciaTraerTodos()
        {
            return GestorDireccion.DireccionProvinciaTraerTodos();
        }
    }
}
