using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Agente
    {

        public int IdAgente { get; set; }
        public string NombreAgente { get; set; }
        public string ApellidoAgente { get; set; }
        public Cargo unCargo { get; set; }
        public Dependencia unaDependencia { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.ApellidoAgente))
            {
                return this.ApellidoAgente.ToString();
            }
            return "";
        }

    }
}
