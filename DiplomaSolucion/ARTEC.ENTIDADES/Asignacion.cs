using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Asignacion
    {

        public int IdAsignacion { get; set; }
        public DateTime Fecha { get; set; }
        public Dependencia unaDependencia { get; set; }

        private List<AsigDetalle> _unosAsigDetalles = new List<AsigDetalle>();
        public List<AsigDetalle> unosAsigDetalles
        {
            get { return _unosAsigDetalles; }
            set { _unosAsigDetalles = value; }
        }
        

    }
}
