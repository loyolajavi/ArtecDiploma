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
            Pendiente = 1, Cotizado = 2, Comprar = 3, Adquirido = 4, Entregado = 5, Cancelado = 6 
        }

        public override string ToString()
        {
            return this.DescripEstadoSolicDetalle;
        }


    }
}
