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
        ///**************************1************************************************
        /// <summary>
        /// Evento para buscar las dependencias mientras se escribe (búsqueda dinámica)
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //private void textBoxX1_TextChanged(object sender, EventArgs e)
        //{

        //    if  (textBoxX1.Text != "" & textBoxX1.Text != " " & textBoxX1 != null)
        //    {

        //        List<Dependencia> res = new List<Dependencia>();

        //        foreach (var unaDep in unasDependencias)
        //        {
        //            res.Add(unaDep);
        //        }

        //        List<string> Palabras = new List<string>();
        //        Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

        //        foreach (string unaPalabra in Palabras)
        //        {
        //            if ((unaPalabra.ToString() == "") || (unaPalabra.ToString() == " "))
        //            {

        //            }
        //            else 
        //            {
        //                dataGridViewX1.DataSource = null;

        //                res = (from d in res
        //                       where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
        //                       select d).ToList();

        //                if (res.Count == 0)
        //                {
        //                    dataGridViewX1.DataSource = null;
        //                }
        //                else
        //                {
        //                    dataGridViewX1.DataSource = res;
        //                }

        //            }
        //        }
        //        res = null;

        //    }
        //    else
        //    {
        //        dataGridViewX1.DataSource = null;
        //    }

        //}
        ///**************************1************************************************


        ///**************************2************************************************
        //private void comboBoxEx4_TextChanged(object sender, EventArgs e)
        //{

        //    if (comboBoxEx4.SelectedIndex < 0)
        //    {

        //        if (comboBoxEx4.Text != "" & comboBoxEx4.Text != " " & comboBoxEx4 != null)
        //        {
        //            string aux = comboBoxEx4.Text;
        //            List<Dependencia> res = new List<Dependencia>();

        //            foreach (var unaDep in unasDependencias)
        //            {
        //                res.Add(unaDep);
        //            }

        //            List<string> Palabras = new List<string>();
        //            Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(comboBoxEx4.Text, ' ');

        //            foreach (string unaPalabra in Palabras)
        //            {
        //                if ((unaPalabra.ToString() == "") || (unaPalabra.ToString() == " "))
        //                {

        //                }
        //                else
        //                {
        //                    //comboBoxEx4.Items.Clear();
        //                    //comboBoxEx4.DataSource = null;

        //                    res = (List<Dependencia>)(from d in res
        //                           where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
        //                           select d).ToList();



        //                }

        //            }
        //            if (res.Count == 0)
        //            {
        //                //comboBoxEx4.Items.Clear();
        //                comboBoxEx4.DataSource = null;
        //            }
        //            else
        //            {
        //                //comboBoxEx4.DataSource = null;
        //                //foreach (Dependencia item in res)
        //                //{
        //                //    comboBoxEx4.Items.Add(item.NombreDependencia);
        //                //    comboBoxEx4.DroppedDown = true;
        //                //    Cursor.Current = Cursors.Default;
        //                //comboBoxEx4.SelectionStart = comboBoxEx4.Text.Length + 1;
        //                //}

        //                // ME FALTA AGREGAR LO Q ESCRIBO AL DATASOURCE Y YASTA
        //                res.Insert(0, new Dependencia { IdDependencia = 0, NombreDependencia = aux });
        //                comboBoxEx4.DataSource = res;
        //                comboBoxEx4.DisplayMember = "NombreDependencia";
        //                comboBoxEx4.ValueMember = "IdDependencia";
        //                comboBoxEx4.DroppedDown = true;
        //                Cursor.Current = Cursors.Default;
        //                comboBoxEx4.SelectionStart = comboBoxEx4.Text.Length + 1;
        //            }
        //            res = null;

        //        }

        //        else
        //        {
        //            //comboBoxEx4.Items.Clear();
        //            comboBoxEx4.DataSource = null;
        //        }
        //    }
        //}
        ///**************************2************************************************


        ///**************************3************************************************
        ///Con Dropdown style en dropdownList y un text box

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            //comboBoxEx4.DataSource = null;
            bool flagDep = false;
            if (textBoxX1.Text != "" & textBoxX1.Text != " " & textBoxX1 != null)
            {
                List<Dependencia> res = new List<Dependencia>();

                foreach (var unaDep in unasDependencias)
                {
                    res.Add(unaDep);
                }

                List<string> Palabras = new List<string>();
                Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    if ((unaPalabra.ToString() != "") & (unaPalabra.ToString() != " "))
                    {
                        res = (List<Dependencia>)(from d in res
                                                  where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                                  select d).ToList();
                    }
                    else
                    {
                        flagDep = true;
                    }

                }

                if (res.Count == 0 || flagDep == true)
                {
                    comboBoxEx4.Visible = false;
                    comboBoxEx4.DroppedDown = false;
                    comboBoxEx4.DataSource = null;
                }
                else if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                {
                    
                }
                else
                {
                    comboBoxEx4.DroppedDown = false;
                    comboBoxEx4.DataSource = null;
                    comboBoxEx4.DataSource = res;
                    comboBoxEx4.DisplayMember = "NombreDependencia";
                    comboBoxEx4.ValueMember = "IdDependencia";
                    comboBoxEx4.Visible = true;
                    comboBoxEx4.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
                //res = null;

            }

            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
            }
        }

        private void comboBoxEx4_Click(object sender, EventArgs e)
        {
            //if (comboBoxEx4.Items.Count > 0)
            //{
                textBoxX1.Text = comboBoxEx4.SelectedText.ToString();
            //}
        }
        ///**************************3************************************************




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