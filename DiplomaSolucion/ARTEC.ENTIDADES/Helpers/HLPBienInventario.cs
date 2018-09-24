using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES.Helpers
{
    public class HLPBienInventario
    {
        public int IdInventario { get; set; }
        public string DescripBien { get; set; }
        public string DescripMarca { get; set; }
        public string DescripModeloVersion { get; set; }
        public string SerieKey { get; set; }
        public string NombreDeposito { get; set; }
        public string DescripEstadoInv { get; set; }
        public decimal Costo { get; set; }


    }
}
