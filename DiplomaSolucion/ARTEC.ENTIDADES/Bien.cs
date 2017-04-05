using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public interface Bien
    {

        int IdBien { get; set; }
        string DescripBien { get; set; }

        Categoria unaCategoria { get; set; }

        Marca unaMarca { get; set; }
        ModeloVersion unModelo { get; set; }



    }
}
