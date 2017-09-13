using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLInventario
    {

        DALInventario GestorInventario = new DALInventario();

        public List<Inventario> InventariosTraerListosParaAsignar(int IdSolicitud)
        {
            return GestorInventario.InventariosTraerListosParaAsignar(IdSolicitud);
        }


    }
}
