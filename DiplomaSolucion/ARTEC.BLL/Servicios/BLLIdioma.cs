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
        public static Idioma unIdiomaActual;
        public List<Idioma> unosIdiomas = new List<Idioma>();

        public List<Idioma> IdiomaTraerTodos()
        {
            return GestorIdioma.IdiomaTraerTodos();
        }


        public void Traducir(Control unForm, int elIdioma)
        {
            Idioma._EtiquetasCompartidas = null;
            //Obtengo las etiquetas y las pongo en la static variable de Etiquetas
            GestorIdioma.EtiquetasTraerTodosPorIdioma(elIdioma);
            //Obtengo todos los controles del formulario
            IEnumerable<Control> unosControles = ObtenerControles(unForm);

            //Coloco el texto en cada control
            foreach (Control unControl in unosControles)
            {
                foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
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



        public void CambiarIdioma(Control unControlCI, Idioma unIdioma)
        {
            
            if (unIdioma.IdIdioma != BLLIdioma.unIdiomaActual.IdIdioma)
            {
                unosIdiomas = IdiomaTraerTodos();

                foreach (var ItemIdioma in unosIdiomas)
                {
                    //Cambio el estado de los idiomas
                    if (ItemIdioma.IdIdioma == unIdioma.IdIdioma)
                    {
                        IdiomaActualizarIdiomaActual(ItemIdioma.IdIdioma, true);
                    }
                    else
                    {
                        IdiomaActualizarIdiomaActual(ItemIdioma.IdIdioma, false);
                    }
                }

                Traducir(unControlCI, unIdioma.IdIdioma);
                BLLIdioma.unIdiomaActual = unIdioma;
            }
        }


        public void IdiomaActualizarIdiomaActual(int elIdIdioma, bool Valor)
        {
            GestorIdioma.IdiomaActualizarIdiomaActual(elIdIdioma, Valor);
        }


    }
}
