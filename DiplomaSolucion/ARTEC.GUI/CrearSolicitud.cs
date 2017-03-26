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

namespace ARTEC.GUI
{
    public partial class CrearSolicitud : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CrearSolicitud()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            groupPanel1.Visible = true;
            labelX8.Location = new Point(402, 308);
            dataGridViewX1.Visible = true;
        }

        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            BLL.BLLDependencia prubabll = new BLL.BLLDependencia();
            dataGridViewX1.DataSource = null;
            List<Dependencia> unasDependencias = prubabll.prueba();
            dataGridViewX1.DataSource = unasDependencias;
        }




    }
}