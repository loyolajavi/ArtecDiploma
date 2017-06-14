using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLFactoryBien
    {

        public static IBLLBien CrearManagerBien(int unTipoBien)
        {
            if (unTipoBien == 1)//Hardware
            {
                return new BLLHardware();
            }
            else
            {
                return new BLLSoftware();
            }
        }

    }
}
