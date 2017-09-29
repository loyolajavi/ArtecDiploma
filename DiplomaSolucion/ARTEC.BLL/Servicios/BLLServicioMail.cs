using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.DAL;
using ARTEC.DAL.Servicios;

namespace ARTEC.BLL.Servicios
{
    public class BLLServicioMail
    {

        public static void CargarMailConfig()
        {
            DALServicioMail.CargarMailConfig();
        }

    }
}
