using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Rendicion
    {

        public int IdRendicion { get; set; }
        public decimal MontoGasto { get; set; }
        
        private List<Adquisicion> _unasAdquisiciones = new List<Adquisicion>();

        public List<Adquisicion> unasAdquisiciones
        {
            get { return _unasAdquisiciones; }
            set { _unasAdquisiciones = value; }
        }
        

    }
}
