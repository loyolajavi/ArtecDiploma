using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Proveedor
    {

        public int IdProveedor { get; set; }
        public string RazonSocialProv { get; set; }
        public string AliasProv { get; set; }
        public string ContactoProv { get; set; }
        public string MailContactoProv { get; set; }
        public string MailAlternativoProv { get; set; }

        private List<Telefono> _unosTelefonos = new List<Telefono>();

        public List<Telefono> unosTelefonos
        {
            get { return _unosTelefonos; }
            set { _unosTelefonos = value; }
        }

        private List<Direccion> _unasDirecciones = new List<Direccion>();

        public List<Direccion> unasDirecciones
        {
            get { return _unasDirecciones; }
            set { _unasDirecciones = value; }
        }

        private List<Categoria> _unasCategorias = new List<Categoria>();

        public List<Categoria> unasCategorias
        {
            get { return _unasCategorias; }
            set { _unasCategorias = value; }
        }


        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.AliasProv))
            {
                return this.AliasProv.ToString();
            }
            return "";
        }

    }
}
