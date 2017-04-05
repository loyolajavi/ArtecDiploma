using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ARTEC.ENTIDADES
{
    public class FactoryBien
    {


        public static IEnumerable<Bien> CrearBienes(int unTipoBien)
        {

            if (unTipoBien == 1)
            {
                List<Hardware> unosHard = new List<Hardware>();
                return (IEnumerable<Bien>)unosHard;
            }
            else
            {
                return new List<Software>();
            }
        }

    }
}
