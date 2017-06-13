using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLModelo
    {

        DALModelo GestorModelo = new DALModelo();

        public List<ModeloVersion> ModeloTraerPorMarcaCategoria(int Cat, int TipoBien, int laMarca)
        {
            return GestorModelo.ModeloTraerPorMarcaCategoria(Cat, TipoBien, laMarca);
        }


    }
}
