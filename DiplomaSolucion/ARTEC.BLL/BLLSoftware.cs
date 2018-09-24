using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    class BLLSoftware : IBLLBien
    {

        DALSoftware GestorSoftware = new DALSoftware();

        ////Factory
        //IBien IBLLBien.BienInstanciar()
        //{
        //    return new Software();
        //}


        public int BienTraerIdPorDescripMarcaModelo(int IdCat, int IdMarca, int IdModelo)
        {
            return GestorSoftware.BienTraerIdPorDescripMarcaModelo(IdCat, IdMarca, IdModelo);
        }




    }
}
