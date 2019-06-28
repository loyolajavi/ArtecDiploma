using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Partida
    {

        public int IdPartida { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoOtorgado { get; set; }
        public string NroPartida { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaAcreditacion { get; set; }
        private List<PartidaDetalle> _unasPartidasDetalles = new List<PartidaDetalle>();

        public List<PartidaDetalle> unasPartidasDetalles
        {
            get { return _unasPartidasDetalles; }
            set { _unasPartidasDetalles = value; }
        }


        

        

    }
}
