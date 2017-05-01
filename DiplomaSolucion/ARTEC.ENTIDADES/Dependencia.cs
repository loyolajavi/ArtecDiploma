using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Dependencia
    {

        public int IdDependencia { get; set; }
        public string NombreDependencia { get; set; }
        //public List<Agente> unosAgentes { get; set; }
        public TipoDependencia unTipoDep { get; set; }


    }
}
