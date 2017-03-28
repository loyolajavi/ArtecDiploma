using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.BLL;
using ARTEC.ENTIDADES;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class CrearSolicitud : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<Dependencia> unasDependencias = new List<Dependencia>();

        public CrearSolicitud()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            groupPanel1.Visible = true;
            labelX8.Location = new Point(402, 308);
        }

        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            //dataGridViewX1.DataSource = null;
            //List<Dependencia> unasDependencias = prubabll.prueba();
            //dataGridViewX1.DataSource = unasDependencias;
            unasDependencias = ManagerDependencia.TraerTodos();





        }


        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            
            if  (textBoxX1.Text != "" & textBoxX1.Text != " " & textBoxX1 != null)
            {
                dataGridViewX1.DataSource = null;

                var res = (from d in unasDependencias
                           where d.NombreDependencia.ToLower().Contains(textBoxX1.Text.ToLower())
                           select d).ToList();

                if (res.Count == 0)
                {
                    dataGridViewX1.DataSource = null;
                }
                else
                {
                    dataGridViewX1.DataSource = res;
                }
                res = null;
            }
            else
            {
                dataGridViewX1.DataSource = null;
            }
            
        }


        //Por ahi tengo que pasar esto al autocompelte de string, para que funcione el mouse (hay q revisar eso), y dps para obtener el valor, agarro el string, lo busco en el objeto usado para linq y ahí agarro el id.

//ESTO ES OTRA FORMA DE HACER LO QUE HICE ARRIBA
//Try a simpler method without Linq:

//using (var GC = new GroundCommanderEntities())            
//{                    
//    foreach (var Current in GC.IMF_Extensions)
//    {
//        if (Current.Description.Contains(Search_txt.Text))
//        {
//            Coll.Add(Current.Description);
//        }
//    }
//}



    }
}