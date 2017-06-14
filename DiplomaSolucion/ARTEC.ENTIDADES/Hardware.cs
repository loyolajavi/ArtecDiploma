using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Hardware : IBien

    {



        public int IdBien { get; set; }
        public string DescripBien { get; set; }
        public Categoria unaCategoria { get; set; }
        public Marca unaMarca { get; set; }
        public ModeloVersion unModelo { get; set; }
        
        private List<Inventario>  _unosInventarios = new List<Inventario>();

        public List<Inventario>  unosInventarios
        {
            get { return _unosInventarios; }
            set { _unosInventarios = value; }
        }
        

    }
}
