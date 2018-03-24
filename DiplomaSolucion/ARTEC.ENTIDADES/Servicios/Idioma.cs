using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES.Servicios
{
    public class Idioma
    {

        public int IdIdioma { get; set; }
        public string NombreIdioma { get; set; }
        public bool ElIdiomaDefault { get; set; }

        public static Idioma unIdiomaDefault;
        public static List<Etiqueta> _EtiquetasCompartidas;
        public static int unIdiomaActual;
        public enum EnumIdioma
        { Español = 1, English = 2 };
    }
}
