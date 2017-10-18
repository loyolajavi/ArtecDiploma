using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class SolicDetalle
    {

        public int IdSolicitudDetalle { get; set; }
        public int IdSolicitud { get; set; }
        
        private Categoria _unaCategoria = new Categoria();
        public Categoria unaCategoria
        {
            get { return _unaCategoria; }
            set { _unaCategoria = value; }
        }
        public int Cantidad { get; set; }
        
        private EstadoSolicDetalle _unEstado = new EstadoSolicDetalle();
        public EstadoSolicDetalle unEstado
        {
            get { return _unEstado; }
            set { _unEstado = value; }
        }

        private List<Agente> _unosAgentes = new List<Agente>();
        public List<Agente> unosAgentes
        {
            get { return _unosAgentes; }
            set { _unosAgentes = value; }
        }


        private List<Cotizacion> _unasCotizaciones;

        public List<Cotizacion> unasCotizaciones
        {
            get { return _unasCotizaciones; }
            set { _unasCotizaciones = value; }
        }

        public bool Seleccionado { get; set; }

        //PRUEBA
        private List<XInventarioHard> _InventariosHard = new List<XInventarioHard>();

        public List<XInventarioHard> InventariosHard
        {
            get { return _InventariosHard; }
            set { _InventariosHard = value; }
        }

        private List<Hardware> _unosBienes = new List<Hardware>();

        public List<Hardware> unosBienes
        {
            get { return _unosBienes; }
            set { _unosBienes = value; }
        }


        public int UIDSolicDetalle { get; set; }



    }
}
