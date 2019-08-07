using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class AsigDetalle
    {

        public int IdAsigDetalle { get; set; }
        //public int IdAsignacion { get; set; }
        public Asignacion AsigAsociada { get; set; }
        public Inventario unInventario { get; set; }
        public SolicDetalle SolicDetalleAsoc { get; set; }
        public Agente unAgente { get; set; }
        public string Observacion { get; set; }


    }
}
