using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public interface IBien
    {

        int IdBien { get; set; }
        string DescripBien { get; set; }
        Categoria unaCategoria { get; set; }
        Marca unaMarca { get; set; }
        ModeloVersion unModelo { get; set; }
        List<Inventario> unosInventarios { get; set; }

    }
}
