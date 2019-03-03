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
            Pendiente = 1, Cotizado = 2, Partida = 3, Comprar = 4, Adquirido = 5, Entregado = 6, Rendido = 7, Cancelado = 8
        }

        public override string ToString()
        {
            return this.DescripEstadoSolicDetalle;
        }


    }
}
