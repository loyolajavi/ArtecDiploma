using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Agente
    {

        public int? IdAgente { get; set; }
        public string NombreAgente { get; set; }
        public string ApellidoAgente { get; set; }
        public Cargo unCargo { get; set; }
        public Dependencia unaDependencia { get; set; }

        private List<Dependencia> _unasDependencias = new List<Dependencia>();

        public List<Dependencia> UnasDependencias
        {
            get { return _unasDependencias; }
            set { _unasDependencias = value; }
        }
        

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
