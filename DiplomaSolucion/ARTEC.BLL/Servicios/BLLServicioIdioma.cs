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
using System.ComponentModel;
using System.Reflection;
using DevComponents.DotNetBar.Validator;


namespace ARTEC.BLL.Servicios
{
    public static class BLLServicioIdioma
    {
        public static List<SuperValidator> LisAUX = new List<SuperValidator>();
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

                //Obtengo los SuperValidator
                ComponentCollection unosComponentes = GetComponents(unForm as Form);
                LisAUX.Clear();
                foreach (Component item in unosComponentes)
                {
                    if (item.GetType() == typeof(SuperValidator))
                        LisAUX.Add(item as SuperValidator);
                }

                //Coloco el texto en cada control
                foreach (Control unControl in unosControles)
                {
                    //Traducción de los msjs de validaciones
                    foreach (SuperValidator item in LisAUX)
                    {
                        if (item.GetValidator1(unControl) != null && item.GetValidator1(unControl).ErrorMessage.Length > 0)
                            if (unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Idioma"))
                            {
                                string unaClave = (unControl.Tag as Dictionary<string, string[]>)["Idioma"].First();
                                foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
                                {
                                    if (string.Equals(unaClave , unaEtiqueta.NombreControl))
                                    {
                                        item.GetValidator1(unControl).ErrorMessage = unaEtiqueta.Texto;
                                        break;
                                    }
                                }
                            }
                        if (item.GetValidator2(unControl) != null && item.GetValidator2(unControl).ErrorMessage.Length > 0)
                            if (unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Idioma"))
                            {
                                string unaClave = (unControl.Tag as Dictionary<string, string[]>)["Idioma"].ElementAt(1);
                                foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
                                {
                                    if (string.Equals(unaClave, unaEtiqueta.NombreControl))
                                    {
                                        item.GetValidator2(unControl).ErrorMessage = unaEtiqueta.Texto;
                                        break;
                                    }
                                }
                            }
                    }

                    //Traducción de los ComboBox
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.GetType().ToString() != "System.Windows.Forms.PictureBox" && unControl.GetType().ToString() != "DevComponents.DotNetBar.Controls.TextBoxX")
                    {
                        if (unControl.Name.StartsWith("cbo"))
                        {
                            CambiarIdiomaCboBox(unControl);
                        }
                        //Antes de implementar Idioma con Diccionario y Tags estaba así (ya no utilizado)
                        //else
                        //{
                        //    //unControl.Text = Idioma._EtiquetasCompartidas.Find(X => X.NombreControl == unControl.Name).Texto; esto estaba comentado incluse antes de la prueba de Diccionario
                        //    foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
                        //    {
                        //        if (string.Equals(unControl.Name, unaEtiqueta.NombreControl))
                        //        {
                        //            unControl.Text = unaEtiqueta.Texto;
                        //            break;
                        //        }
                        //    }
                        //}
                        //End Antes de implementar Idioma con Diccionario y Tags estaba así (ya no utilizado)

                        //Idioma del resto de los controles (todos en definitiva) con Diccionario y Tags
                        else if (unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Idioma"))
                        {
                            string unaClave = (unControl.Tag as Dictionary<string, string[]>)["Idioma"].First();
                            foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
                            {
                                if (string.Equals(unaClave , unaEtiqueta.NombreControl))
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


        //Para obtener los componentes de un formulario por reflection
        public static ComponentCollection GetComponents(Form frm)
        {
            List<Component> components = new List<Component>();
            FieldInfo[] fieldInfos = frm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (FieldInfo f in fieldInfos)
            {
                if (f.FieldType.BaseType == typeof(Component))
                {
                    Component c = f.GetValue(frm) as Component;
                    if (c != null)
                        components.Add(c);
                }
            }

            ComponentCollection ArrayComponentes = new ComponentCollection(components.ToArray());

            return ArrayComponentes;
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
                    //Digito Verificador
                    FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual = unIdioma;
                    long ResAcum = FRAMEWORK.Servicios.ServicioDV.DVCalcularDVH(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado);
                    if (ResAcum > 0)
                    {
                        FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.DVH = ResAcum;
                        FRAMEWORK.Servicios.ServicioDV.DVActualizarDVHIniBD(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario, FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.DVH, FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.GetType().Name, "IdUsuario");
                    }
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
            else if (unCboBox.Name == "cboEstadoInv")
            {
                CambiarIdiomacboEstadoInv(unCboBox);
            }
            else if (unCboBox.Name == "cboEstadoSolDetalle")
            {
                CambiarIdiomacboEstadoSolDetalle(unCboBox);
            }
            
           
        }

        private static void CambiarIdiomacboEstadoSolicitud(ComboBox elCboBox)
        {
            BLLEstadoSolicitud ManagerEstadoSolic = new BLLEstadoSolicitud();
            List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
            unosEstadoSolicitud = ManagerEstadoSolic.EstadoSolicitudTraerTodos();
            int seleccionado = 0;
            if (elCboBox.SelectedValue != null)
                seleccionado = (int)elCboBox.SelectedValue;
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
            int seleccionado = 0;
            if(elCboBox.SelectedValue != null)
                seleccionado = (int)elCboBox.SelectedValue;
            elCboBox.DataSource = null;
            unasPrioridades.Insert(0, new Prioridad(-1, ""));
            elCboBox.DataSource = unasPrioridades;
            elCboBox.DisplayMember = "DescripPrioridad";
            elCboBox.ValueMember = "IdPrioridad";
            elCboBox.SelectedIndex = seleccionado;
        }

        private static void CambiarIdiomacboEstadoInv(ComboBox elCboBox)
        {
            BLLEstadoInventario ManagerEstadoInventario = new BLLEstadoInventario();
            List<EstadoInventario> unosEstInven = new List<EstadoInventario>();
            unosEstInven = ManagerEstadoInventario.EstadoInvTraerTodos();
            int seleccionado = 0;
            if (elCboBox.SelectedValue != null)
                seleccionado = (int)elCboBox.SelectedValue;
            elCboBox.DataSource = null;
            //unosEstInven.Insert(0, new EstadoInventario(-1, ""));
            elCboBox.DataSource = unosEstInven;
            elCboBox.DisplayMember = "DescripEstadoInv";
            elCboBox.ValueMember = "IdEstadoInventario";
            elCboBox.SelectedValue = seleccionado;
        }

        private static void CambiarIdiomacboEstadoSolDetalle(ComboBox elCboBox)
        {
            BLLEstadoSolicDetalle ManagerEstadoSolicDetalle = new BLLEstadoSolicDetalle();
            List<EstadoSolicDetalle> unosEstSolicDetalle = new List<EstadoSolicDetalle>();
            unosEstSolicDetalle = ManagerEstadoSolicDetalle.EstadoSolDetallesTraerTodos();
            int seleccionado = 0;
            if (elCboBox.SelectedValue != null)
                seleccionado = (int)elCboBox.SelectedValue;
            elCboBox.DataSource = null;
            //unosEstInven.Insert(0, new EstadoInventario(-1, "")); //QUEDA COMENTADO PARA QUE NO TENGA UN VALOR NULL 
            elCboBox.DataSource = unosEstSolicDetalle;
            elCboBox.DisplayMember = "DescripEstadoSolicDetalle";
            elCboBox.ValueMember = "IdEstadoSolicDetalle";
            elCboBox.SelectedValue = seleccionado;
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
