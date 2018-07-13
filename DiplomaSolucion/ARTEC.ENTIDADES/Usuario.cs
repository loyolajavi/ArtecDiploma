using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.ENTIDADES
{
    public class Usuario
    {

        public Usuario(int id, string nom, string pas)
        {
            IdUsuario = id;
            NombreUsuario = nom;
            Pass = pas;
        }

        public Usuario() { }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public int IdiomaUsuarioActual { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Mail { get; set; }
        
        private List<IFamPat> _Permisos = new List<IFamPat>();

        public List<IFamPat> Permisos
        {
            get { return _Permisos; }
            set { _Permisos = value; }
        }
        
        



        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.NombreUsuario))
            {
                return this.NombreUsuario.ToString();
            }
            return "";
        }
    }
}
