using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;

namespace ARTEC.DAL
{
    public class DALHardware
    {

        public List<Hardware> TraerHardware()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "HardwareTraerHardware"))
            {
                List<Hardware> unosHard = new List<Hardware>();
                unosHard = FRAMEWORK.Persistencia.Mapeador.Mapear<Hardware>(ds);
                return unosHard;
            }
        }

    }
}
