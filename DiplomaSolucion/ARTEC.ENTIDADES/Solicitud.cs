using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Solicitud
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Prioridad UnaPrioridad { get; set; }
        public Usuario Asignado { get; set; }
        public EstadoSolicitud UnEstado { get; set; }

        public Dependencia laDependencia { get; set; }
        private List<SolicDetalle> _unosDetallesSolicitud = new List<SolicDetalle>();
        public List<SolicDetalle> unosDetallesSolicitud
        {
            get { return _unosDetallesSolicitud; }
            set { _unosDetallesSolicitud = value; }
        }

        private List<Nota> _unasNotas = new List<Nota>();
        
        public List<Nota> unasNotas
        {
            get { return _unasNotas; }
            set { _unasNotas = value; }
        }
        

    }
}
