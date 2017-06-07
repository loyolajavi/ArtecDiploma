using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ARTEC.GUI
{
    public partial class frmBienRegistrar : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmBienRegistrar()
        {
            InitializeComponent();
        }

        private void stepItem1_Click(object sender, EventArgs e)
        {

        }

        private void stepItem2_Click(object sender, EventArgs e)
        {

        }

        private void lblIdSolicitud_Click(object sender, EventArgs e)
        {

        }

        private void txtIdSolicitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            pnlAdquisicion.Visible = false;
            pnlBienes.Visible = true;
            this.stepItem1.BackColors = new System.Drawing.Color[] {System.Drawing.Color.Transparent};
            this.stepItem2.BackColors = new System.Drawing.Color[] {System.Drawing.Color.MediumAquamarine};
        }





    }
}