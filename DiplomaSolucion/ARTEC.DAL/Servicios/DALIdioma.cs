using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK;

namespace ARTEC.DAL.Servicios
{
    public class DALIdioma
    {

        public List<Idioma> IdiomaTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "IdiomaTraerTodos"))
                //using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "IdiomaTraerTodos"))
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


        public void EtiquetasTraerTodosPorIdioma(int elIdioma)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdIdioma", elIdioma)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EtiquetasTraerTodosPorIdioma", parameters))
                {
                    Idioma._EtiquetasCompartidas = FRAMEWORK.Persistencia.Mapeador.Mapear<Etiqueta>(ds);
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public void IdiomaActualizarIdiomaActual(int elIdIdioma, bool Valor)
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

        //public List<Etiqueta> EtiquetasCompartidas
        //{
        //    get { return _EtiquetasCompartidas; }
        //    set { _EtiquetasCompartidas = value; }
        //}

        //public IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();

        //    return controls.SelectMany(ctrl => GetAll(ctrl, type))
        //                              .Concat(controls)
        //                              .Where(c => c.GetType() == type);
        //}






        //private void AddTextChangedHandler(Control parent)
        //{
        //    foreach (Control c in parent.Controls)
        //    {
        //        if (c.GetType() == typeof(TextBox))
        //        {
        //            //c.TextChanged += new EventHandler(C_TextChanged);
        //        }
        //        else
        //        {
        //            AddTextChangedHandler(c);
        //        }
        //    }
        //}


    }
}
