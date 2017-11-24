using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARTEC.ENTIDADES.Servicios;
using System.Data;
using System.Data.SqlClient;

namespace ARTEC.FRAMEWORK.Servicios
{
    public static class ServicioIdioma
    {

        public static Idioma unIdiomaDefault;
        public static List<Etiqueta> _EtiquetasCompartidas;
        public static int unIdiomaActual;
        public enum EnumIdioma
        { Español = 1, English = 2 };

        public static List<Idioma> IdiomaTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "IdiomaTraerTodos"))
                {
                    List<Idioma> unaLista = new List<Idioma>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Idioma>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static void Traducir(Control unForm, int elIdioma)
        {
            //Obtengo las etiquetas de la BD una única vez para todos los formularios y las pongo en la static variable de Etiquetas (si cambio de idioma voy a la bd de nuevo)
            if (_EtiquetasCompartidas == null)
            {
                EtiquetasTraerTodosPorIdioma(elIdioma);
            }
            
            //Obtengo todos los controles del formulario
            IEnumerable<Control> unosControles = ObtenerControles(unForm);

            //Coloco el texto en cada control
            foreach (Control unControl in unosControles)
            {
                if (!string.IsNullOrEmpty(unControl.Name) && unControl.GetType().ToString() != "System.Windows.Forms.PictureBox" && unControl.GetType().ToString() != "DevComponents.DotNetBar.Controls.TextBoxX")
                {
                    //unControl.Text = _EtiquetasCompartidas.Find(X => X.NombreControl == unControl.Name).Texto;
                    foreach (Etiqueta unaEtiqueta in _EtiquetasCompartidas)
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


        public static void EtiquetasTraerTodosPorIdioma(int elIdioma)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdIdioma", elIdioma)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EtiquetasTraerTodosPorIdioma", parameters))
                {
                    //_EtiquetasCompartidas = FRAMEWORK.Persistencia.Mapeador.Mapear<Etiqueta>(ds);
                    _EtiquetasCompartidas = MapearIdiomaEtiquetas(ds);
                    
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
                if (unIdiomaActual == unIdioma)
                    Cambiar = false;
                else
                    Cambiar = true;
            }
            else
            {
                //Si no está logueado comparo con el idioma default
                if (unIdiomaActual == unIdioma)
                    Cambiar = false;
                else
                    Cambiar = true;
            }


            if (Cambiar == true)
            {


                _EtiquetasCompartidas = null;

                //foreach (var ItemIdioma in unosIdiomas)
                //{
                //    //Cambio el estado de los idiomas
                //    if (ItemIdioma.IdIdioma == unIdioma.IdIdioma)
                //    {
                //        IdiomaActualizarIdiomaActual(ItemIdioma.IdIdioma, true);
                //    }
                //    else
                //    {
                //        IdiomaActualizarIdiomaActual(ItemIdioma.IdIdioma, false);
                //    }
                //}

                Traducir(unControlCI, unIdioma);
                ServicioIdioma.unIdiomaActual = unIdioma;
                if (FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado != null)
                {
                    IdiomaUsuarioActualModificar();
                }
                return true;
            }
            return false;
        }



        public static void IdiomaUsuarioActualModificar()
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdiomaUsuarioActual", unIdiomaActual),
                new SqlParameter("@IdUsuario", ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "IdiomaUsuarioActualModificar", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public static void IdiomaSetearDefault(Idioma unIdiomaDefault)
        {
            List<Idioma> unosIdiomas = new List<Idioma>();
            unosIdiomas = IdiomaTraerTodos();

            foreach (var ItemIdioma in unosIdiomas)
            {
                //Cambio el estado de los idiomas
                if (ItemIdioma.IdIdioma == unIdiomaDefault.IdIdioma)
                {
                    IdiomaActualizarIdiomaDefault(ItemIdioma.IdIdioma, true);
                }
                else
                {
                    IdiomaActualizarIdiomaDefault(ItemIdioma.IdIdioma, false);
                }
            }
        }



        public static void IdiomaActualizarIdiomaDefault(int elIdIdioma, bool Valor)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdIdioma", elIdIdioma),
                new SqlParameter("@ElIdiomaDefault", Valor)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "IdiomaActualizarIdiomaDefault", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }


        public static Etiqueta MostrarMensaje(string EtiquetaMensaje)
        {
            Etiqueta MensajeRetorno = new Etiqueta();

            MensajeRetorno = _EtiquetasCompartidas.Find(x => x.NombreControl == EtiquetaMensaje);
            return MensajeRetorno;
        }


        private static List<Etiqueta> MapearIdiomaEtiquetas(DataSet ds)
        {
            List<Etiqueta> ResEtiquetas = new List<Etiqueta>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Etiqueta unaEtiqueta = new Etiqueta();

                    unaEtiqueta.NombreControl = row["NombreControl"].ToString();
                    unaEtiqueta.Texto = row["Texto"].ToString();

                    ResEtiquetas.Add(unaEtiqueta);
                }
                return ResEtiquetas;
            }
            catch (Exception es)
            {
                throw;
            }
        }






    }
}
