using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class EstadoInventario
    {

        public int IdEstadoInventario { get; set; }
        public string DescripEstadoInv { get; set; }

        public enum EnumEstadoInventario
        {
            Disponible = 1, Entregado = 2
        }
   
    }
}
