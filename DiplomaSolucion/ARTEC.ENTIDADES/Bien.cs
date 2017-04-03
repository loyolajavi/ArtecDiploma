using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public abstract class Bien
    {

        int IdBien { get; set; }
        string DescripBien { get; set; }
        //TipoBien unTipoBien { get; set; }

        Categoria unaCategoria { get; set; }

        Marca unaMarca { get; set; }
        ModeloVersion unModelo { get; set; }



    }
}
