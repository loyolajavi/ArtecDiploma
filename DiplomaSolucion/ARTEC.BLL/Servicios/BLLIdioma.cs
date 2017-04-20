using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.DAL.Servicios;
using System.Windows.Forms;

namespace ARTEC.BLL.Servicios
{
    public class BLLIdioma
    {

        DALIdioma GestorIdioma = new DALIdioma();

        public void Traducir(Control unForm, int elIdioma)
        {
            DALIdioma._EtiquetasCompartidas = null;
            GestorIdioma.ObtenerEtiquetas();////FALTA FILTRAR POR EL IDIOMA EN EL STORE PROCEDURE Y ACA TMB ENVIANDO POR PARAMETRO EL IDIOMA
            IEnumerable<Control> unosControles = ObtenerControles(unForm);

            foreach (Control unControl in unosControles)
            {
                foreach (Etiqueta unaEtiqueta in DALIdioma._EtiquetasCompartidas)
                {
                    if (string.Equals(unControl.Name, unaEtiqueta.NombreControl))
                    {
                        unControl.Text = unaEtiqueta.Texto;
                    }
                }
            }
        }



        public static IEnumerable<Control> ObtenerControles(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(ObtenerControles(child));
            }

            controls.Add(parent);

            return controls;
        
        }

    }
}
