using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.DAL;
using ARTEC.DAL.Servicios;


namespace ARTEC.BLL.Servicios
{
    public static class BLLServicioIdioma
    {

        public static List<Idioma> IdiomaTraerTodos()
        {
            return DALServicioIdioma.IdiomaTraerTodos();
        }

        public static void Traducir(Control unForm, int elIdioma)
        {
            try
            {



                //Obtengo las etiquetas de la BD una única vez para todos los formularios y las pongo en la static variable de Etiquetas (si cambio de idioma voy a la bd de nuevo)
                if (Idioma._EtiquetasCompartidas == null)
                {
                    DALServicioIdioma.EtiquetasTraerTodosPorIdioma(elIdioma);
                }

                //Obtengo todos los controles del formulario
                IEnumerable<Control> unosControles = ObtenerControles(unForm);

                //Coloco el texto en cada control
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.GetType().ToString() != "System.Windows.Forms.PictureBox" && unControl.GetType().ToString() != "DevComponents.DotNetBar.Controls.TextBoxX")
                    {
                        if (unControl.Name.StartsWith("cbo"))
                        {
                            CambiarIdiomaCboBox(unControl);
                        }
                        else
                        {
                            //unControl.Text = Idioma._EtiquetasCompartidas.Find(X => X.NombreControl == unControl.Name).Texto;
                            foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
                            {
                                if (string.Equals(unControl.Name, unaEtiqueta.NombreControl))
                                {
                                    unControl.Text = unaEtiqueta.Texto;
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception es)
            {

                throw;
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


        public static bool CambiarIdioma(Control unControlCI, int unIdioma)
        {
            bool Cambiar;

            //Si está logueado
            if (FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado != null)
            {
                if (Idioma.unIdiomaActual == unIdioma)
                    Cambiar = false;
                else
                    Cambiar = true;
            }
            else
            {
                //Si no está logueado comparo con el idioma default, (unIdiomaActual tiene el valor de default)
                if (Idioma.unIdiomaActual == unIdioma)
                    Cambiar = false;
                else
                    Cambiar = true;
            }


            if (Cambiar == true)
            {
                Idioma._EtiquetasCompartidas = null;
                Idioma.unIdiomaActual = unIdioma;
                Traducir(unControlCI, Idioma.unIdiomaActual);
                if (FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado != null)
                {
                    DALServicioIdioma.IdiomaUsuarioActualModificar();
                }
                return true;
            }
            return false;
        }


        public static Etiqueta MostrarMensaje(string EtiquetaMensaje)
        {
            Etiqueta MensajeRetorno = new Etiqueta();

            MensajeRetorno = Idioma._EtiquetasCompartidas.Find(x => x.NombreControl == EtiquetaMensaje);
            return MensajeRetorno;
        }


        private static void CambiarIdiomaCboBox(Control unControl)
        {
            ComboBox unCboBox = (unControl as ComboBox);

            if (unCboBox.Name == "cboEstadoSolicitud")
            {
                CambiarIdiomacboEstadoSolicitud(unCboBox);
            }
            else if (unCboBox.Name == "cboPrioridad")
            {
                CambiarIdiomacboPrioridad(unCboBox);
            }
           
        }

        private static void CambiarIdiomacboEstadoSolicitud(ComboBox elCboBox)
        {
            BLLEstadoSolicitud ManagerEstadoSolic = new BLLEstadoSolicitud();
            List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
            unosEstadoSolicitud = ManagerEstadoSolic.EstadoSolicitudTraerTodos();
            int seleccionado = (int)elCboBox.SelectedValue;
            elCboBox.DataSource = null;
            unosEstadoSolicitud.Insert(0, new EstadoSolicitud(-1, ""));
            elCboBox.DataSource = unosEstadoSolicitud;
            elCboBox.DisplayMember = "DescripEstadoSolic";
            elCboBox.ValueMember = "IdEstadoSolicitud";
            elCboBox.SelectedValue = seleccionado;
        }

        private static void CambiarIdiomacboPrioridad(ComboBox elCboBox)
        {
            BLLPrioridad ManagerPrioridad = new BLLPrioridad();
            List<Prioridad> unasPrioridades = new List<Prioridad>();
            unasPrioridades = ManagerPrioridad.PrioridadTraerTodos();
            int seleccionado = (int)elCboBox.SelectedValue;
            elCboBox.DataSource = null;
            unasPrioridades.Insert(0, new Prioridad(-1, ""));
            elCboBox.DataSource = unasPrioridades;
            elCboBox.DisplayMember = "DescripPrioridad";
            elCboBox.ValueMember = "IdPrioridad";
            elCboBox.SelectedIndex = seleccionado;
        }


        
        

        //YA NO UTILIZADA 21/03/2018
        //public static void IdiomaSetearDefault(Idioma unIdiomaDefault)
        //{
        //    List<Idioma> unosIdiomas = new List<Idioma>();
        //    unosIdiomas = IdiomaTraerTodos();

        //    foreach (var ItemIdioma in unosIdiomas)
        //    {
        //        //Cambio el estado de los idiomas
        //        if (ItemIdioma.IdIdioma == unIdiomaDefault.IdIdioma)
        //        {
        //            IdiomaActualizarIdiomaDefault(ItemIdioma.IdIdioma, true);
        //        }
        //        else
        //        {
        //            IdiomaActualizarIdiomaDefault(ItemIdioma.IdIdioma, false);
        //        }
        //    }
        //}


    }
}
