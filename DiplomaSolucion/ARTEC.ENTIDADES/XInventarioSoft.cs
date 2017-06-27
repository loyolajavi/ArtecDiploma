using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class XInventarioSoft : Inventario
    {
        public int IdInventario { get; set; }
        public int IdBienEspecif { get; set; }
        public string SerialMaster { get; set; }
        public string SerieKey { get; set; }
        public DateTime FechaSuscrip { get; set; }
        public DateTime FechaFinSuscrip { get; set; }
        public EstadoInventario unEstado { get; set; }


    }
}
