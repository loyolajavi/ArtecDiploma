using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.DAL.MotorBD;

namespace ARTEC.DAL.Servicios
{
    public class DALIdioma
    {

        public static List<Etiqueta> _EtiquetasCompartidas;
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


        public void ObtenerEtiquetas()
        {
            try
            {
                using (DataSet ds = MotorBD.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EtiquetaTraerTodos"))
                {
                    _EtiquetasCompartidas = Mapeador.Mapear<Etiqueta>(ds);
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

    }
}
