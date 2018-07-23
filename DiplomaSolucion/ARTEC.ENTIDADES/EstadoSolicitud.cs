using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class EstadoSolicitud
    {

        public EstadoSolicitud(int id, string descrip)
        {
            IdEstadoSolicitud = id;
            DescripEstadoSolic = descrip;
        }
        public EstadoSolicitud()
        {
        }

        public int IdEstadoSolicitud { get; set; }
        public string DescripEstadoSolic { get; set; }

        public override string ToString()
        {
            return this.DescripEstadoSolic;
        }


        public enum EnumEstadoSolicitud
        {
            Pendiente = 1, Finalizado = 2, Cancelada = 3
        }





    }
}
