using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Prioridad
    {

        public Prioridad(int id, string desc)
        {
            IdPrioridad = id;
            DescripPrioridad = desc;
        }

        public Prioridad()
        {

        }

        public int IdPrioridad { get; set; }
        public string DescripPrioridad { get; set; }

        public override string ToString()
        {
            return this.DescripPrioridad;
        }
    }
}
