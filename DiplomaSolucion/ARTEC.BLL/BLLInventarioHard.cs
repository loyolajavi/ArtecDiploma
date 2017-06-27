using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLInventarioHard
    {

        DALInventarioHard GestorInventarioHard = new DALInventarioHard();


        public void InventarioHardCrear(Hardware unBien)
        {
            GestorInventarioHard.InventarioHardCrear(unBien);
        }

    }
}
