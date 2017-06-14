using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Inventario
    {

        int IdInventario { get; set; }
        int IdBienEspecif { get; set; }
        string SerialMaster { get; set; }
        string SerieKey { get; set; }
        DateTime FechaSuscrip { get; set; }
        DateTime FechaFinSuscrip { get; set; }
        int PlazoGarantia { get; set; }
        EstadoInventario unEstado { get; set; }
        Deposito unDeposito { get; set; }

    }
}
