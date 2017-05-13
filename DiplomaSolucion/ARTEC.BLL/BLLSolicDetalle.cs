using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLSolicDetalle
    {

        DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();

        public List<SolicDetalle> SolicDetallesTraerPorNroSolicitud(int NroSolic)
        {
            return GestorSolicDetalle.SolicDetallesTraerPorNroSolicitud(NroSolic);
        }

    }
}
