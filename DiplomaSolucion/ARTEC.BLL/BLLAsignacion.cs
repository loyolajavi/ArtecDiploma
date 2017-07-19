using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLAsignacion
    {

        DALAsignacion GestorAsignacion = new DALAsignacion();

        public bool AsignacionCrear(Asignacion unaAsig)
        {

            if (GestorAsignacion.AsignacionCrear(unaAsig) > 0)
                return true;
            return false;
        }

    }
}
