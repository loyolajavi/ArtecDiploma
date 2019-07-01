using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public abstract class Bien
    {

        public int IdBien { get; set; }
        public string DescripBien { get; set; }
        public Categoria unaCategoria { get; set; }
        public Marca unaMarca { get; set; }
        public ModeloVersion unModelo { get; set; }
        public IList<Inventario> unosInventarios { get; set; }
        public Inventario unInventarioAlta { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.DescripBien))
            {
                return this.DescripBien;
            }
            return "";
        }


    }


}


