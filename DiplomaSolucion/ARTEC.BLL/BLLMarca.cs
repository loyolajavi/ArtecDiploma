using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLMarca
    {

        DALMarca GestorMarca = new DALMarca();

        public List<Marca> MarcaTraerPorIdCategoria(int IdCat)
        {
            return GestorMarca.MarcaTraerPorIdCategoria(IdCat);
        }
    }
}
