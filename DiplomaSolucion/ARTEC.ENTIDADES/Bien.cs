using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public abstract class Bien : IBien
    {

        public int IdBien { get; set; }
        public string DescripBien { get; set; }
        public Categoria unaCategoria { get; set; }
        public Marca unaMarca { get; set; }
        public ModeloVersion unModelo { get; set; }
        public List<Inventario> unosInventarios { get; set; }



    }
}
