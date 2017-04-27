using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Direccion
    {

        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroCalle { get; set; }
        public string Localidad { get; set; }
        public Provincia unaProvincia  { get; set; }
        public string Piso { get; set; }


    }
}
