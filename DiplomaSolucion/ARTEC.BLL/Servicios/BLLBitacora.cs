using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.DAL;
using ARTEC.DAL.Servicios;

namespace ARTEC.BLL.Servicios
{
    public class BLLBitacora
    {

        DALBitacora GestorBitacora = new DALBitacora();

        public List<Bitacora> BitacoraVerLogs(string unTipoLog, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                return GestorBitacora.BitacoraVerLogs(unTipoLog, fechaInicio, fechaFin);
            }
            catch (Exception es)
            {
                throw;
            }
        }

    }
}
