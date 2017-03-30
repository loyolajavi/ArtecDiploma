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
        Solicitud unaSolicitud;

        public CrearSolicitud()
        {
            InitializeComponent();
            unaSolicitud = new Solicitud();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            groupPanel1.Visible = true;
            labelX8.Location = new Point(402, 308);
        }

        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();
        }


        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                List<Dependencia> res = new List<Dependencia>();
                res = (List<Dependencia>)unasDependencias.ToList();

                List<string> Palabras = new List<string>();
                Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                        res = (List<Dependencia>)(from d in res
                                                  where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                                  select d).ToList();
                }

                if (res.Count > 0)
                {
                    if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                    {
                        comboBoxEx4.Visible = false;
                        comboBoxEx4.DroppedDown = false;
                        comboBoxEx4.DataSource = null;
                    }
                    else
                    {
                        comboBoxEx4.DataSource = null;
                        comboBoxEx4.DataSource = res;
                        comboBoxEx4.DisplayMember = "NombreDependencia";
                        comboBoxEx4.ValueMember = "IdDependencia";
                        comboBoxEx4.Visible = true;
                        comboBoxEx4.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    comboBoxEx4.Visible = false;
                    comboBoxEx4.DroppedDown = false;
                    comboBoxEx4.DataSource = null;
                }
            }
            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
            }
        }



        private void comboBoxEx4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                if (comboBoxEx4.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    Dependencia unaDep = new Dependencia();
                    unaSolicitud.laDependencia = unaDep;
                    unaSolicitud.laDependencia.IdDependencia = (int)cbo.SelectedValue;
                    textBoxX1.Text = cbo.GetItemText(cbo.SelectedItem);
                    textBoxX1.SelectionStart = textBoxX1.Text.Length + 1;
                }
            }
        }








    }
}