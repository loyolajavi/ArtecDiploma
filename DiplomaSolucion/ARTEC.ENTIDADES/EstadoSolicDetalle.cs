using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class EstadoSolicDetalle
    {

        public int IdEstadoSolicDetalle { get; set; }
        public string DescripEstadoSolicDetalle { get; set; }

        public enum EnumEstadoSolicDetalle
        {
            Pendiente = 1, Cotizado = 2, Adquirido = 3, Entregado = 4, Cancelado = 5
        }

        public override string ToString()
        {
            return this.DescripEstadoSolicDetalle;
        }


    }
}
