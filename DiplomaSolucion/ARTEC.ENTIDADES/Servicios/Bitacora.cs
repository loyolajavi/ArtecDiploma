using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES.Servicios
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoLog { get; set; }
        public string Accion { get; set; }
        public string Mensaje { get; set; }



    }
}
