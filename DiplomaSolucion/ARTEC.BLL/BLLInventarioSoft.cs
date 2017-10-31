using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLInventarioSoft
    {

        DALInventarioSoft GestorInventarioSoft = new DALInventarioSoft();


        public void InventarioSoftCrear(Software unBien, int IdPart)
        {
            GestorInventarioSoft.InventarioSoftCrear(unBien, IdPart);
        }


        public List<Software> InventarioSoftTraerListosParaAsignar(SolicDetalle unSolicDetalle)
        {
            return GestorInventarioSoft.InventarioSoftTraerListosParaAsignar(unSolicDetalle);
        }


    }
}
