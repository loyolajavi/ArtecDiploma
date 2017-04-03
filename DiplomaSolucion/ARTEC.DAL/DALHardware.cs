using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL.MotorBD;

namespace ARTEC.DAL
{
    public class DALHardware
    {

        public List<Hardware> TraerHardware()
        {
            using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "HardwareTraerHardware"))
            {
                List<Hardware> unosHard = new List<Hardware>();
                unosHard = Mapeador.Mapear<Hardware>(ds);
                return unosHard;
            }
        }

    }
}
