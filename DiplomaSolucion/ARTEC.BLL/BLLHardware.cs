using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLHardware
    {

        DALHardware GestorHardware = new DALHardware();

        public List<Hardware> TraerHardware()
        {
            return GestorHardware.TraerHardware();
        }

    }
}
