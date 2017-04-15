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
        
        private EstadoSolDetalle _unEstado = new EstadoSolDetalle();
        public EstadoSolDetalle unEstado
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


    }
}
