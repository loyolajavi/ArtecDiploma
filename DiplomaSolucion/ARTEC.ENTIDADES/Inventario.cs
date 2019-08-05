using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public abstract class Inventario
    {

        public int IdInventario { get; set; }
        public int IdBienEspecif { get; set; }
        //public string SerialMaster { get; set; }
        public string SerieKey { get; set; }
        public EstadoInventario unEstado { get; set; }
        //public Deposito unDeposito { get; set; }
        public PartidaDetalle PartidaDetalleAsoc { get; set; }

        public decimal Costo { get; set; }

        public Deposito unDeposito { get; set; }
        public Adquisicion unaAdquisicion { get; set; }
        
        public TipoBien elTipoBien { get; set; }

        public Bien deBien { get; set; }
    }
  
}
