using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class EstadoSolDetalle
    {

        public int IdEstadoSolDetalle { get; set; }
        public string DescripSolDetalle { get; set; }

        public enum EnumEstadoSolDetalle
        {
            Pendiente, Solucionado, Cerrado
        }

        public override string ToString()
        {
            return this.DescripSolDetalle;
        }


    }
}
