using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class XInventarioHard : Inventario
    {
        public int IdInventario { get; set; }
        public int IdBienEspecif { get; set; }
        public string SerieKey { get; set; }
        public int PlazoGarantia { get; set; }
        public EstadoInventario unEstado { get; set; }
        public Deposito unDeposito { get; set; }


        
    }
}
