using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public interface IBLLBien
    {

        //IBien BienInstanciar();
        int BienTraerIdPorDescripMarcaModelo(int IdCat, int IdMarca, int IdModelo);

    }
}
