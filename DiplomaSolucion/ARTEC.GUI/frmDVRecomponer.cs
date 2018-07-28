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
    public partial class frmDVRecomponer : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDVRecomponer()
        {
            InitializeComponent();
        }

        private void btnRecomponerDV_Click(object sender, EventArgs e)
        {
            FRAMEWORK.Servicios.ServicioDV.DVRecomponer();
        }
    }
}