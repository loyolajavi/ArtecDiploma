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
    public class ServicioIdioma
    {

        public static Idioma unIdiomaActual;
        public static List<Etiqueta> _EtiquetasCompartidas;

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
                foreach (Etiqueta unaEtiqueta in _EtiquetasCompartidas)
                {
                    if (string.Equals(unControl.Name, unaEtiqueta.NombreControl))
                    {
                        unControl.Text = unaEtiqueta.Texto;
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
                    _EtiquetasCompartidas = FRAMEWORK.Persistencia.Mapeador.Mapear<Etiqueta>(ds);
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



        public static void CambiarIdioma(Control unControlCI, Idioma unIdioma)
        {

            //if (unIdioma.IdIdioma != ServicioIdioma.unIdiomaActual.IdIdioma)
            //{
                List<Idioma> unosIdiomas = new List<Idioma>();
                unosIdiomas = IdiomaTraerTodos();

                _EtiquetasCompartidas = null;

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
                ServicioIdioma.unIdiomaActual = unIdioma;
                
            //}
        }


        public static void IdiomaActualizarIdiomaActual(int elIdIdioma, bool Valor)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdIdioma", elIdIdioma),
                new SqlParameter("@IdiomaActual", Valor)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "IdiomaActualizarIdiomaActual", parameters);
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


    }
}
