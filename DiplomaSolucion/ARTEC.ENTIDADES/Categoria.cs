using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Categoria
    {


        public int IdCategoria { get; set; }
        public string DescripCategoria { get; set; }

        public override String ToString()
        {
            return this.DescripCategoria;
        }

        public TipoBien unTipoBien { get; set; }

        private List<Proveedor> _LosProveedores = new List<Proveedor>();

        public List<Proveedor> LosProveedores
        {
            get { return _LosProveedores; }
            set { _LosProveedores = value; }
        }

        public int Activo { get; set; }


    }
}
