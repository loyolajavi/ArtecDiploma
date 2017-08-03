using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Adquisicion
    {

        public int IdAdquisicion { get; set; }
        public DateTime FechaAdq { get; set; }//Fecha en que se dio de alta en sistema la Adquisicion
        public DateTime FechaCompra { get; set; }//Fecha en que se compraron los bienes
        public string NroFactura { get; set; }
        public string RutaDocumentos { get; set; }
        public decimal MontoCompra { get; set; }
        public Proveedor ProveedorAdquisicion { get; set; }

        private List<Bien> _BienesInventarioAsociados = new List<Bien>();
        public List<Bien> BienesInventarioAsociados
        {
            get { return _BienesInventarioAsociados; }
            set { _BienesInventarioAsociados = value; }
        }
        


        
    }
}
