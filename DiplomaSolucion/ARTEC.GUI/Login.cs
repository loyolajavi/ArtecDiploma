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
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtNombreUsuario_Enter(object sender, EventArgs e)
        {
            pnlNombreUsuarioI.Style.BackColor1.Color = Color.LightSkyBlue;
            pnlNombreUsuario.Style.BackColor1.Color = System.Drawing.SystemColors.ButtonFace;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            pnlPassI.Style.BackColor1.Color = Color.LightSkyBlue;
            pnlPass.Style.BackColor1.Color = System.Drawing.SystemColors.ButtonFace;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            pnlPassI.Style.BackColor1.Color = Color.White;
            pnlPass.Style.BackColor1.Color = Color.White;
        }

        private void txtNombreUsuario_Leave(object sender, EventArgs e)
        {
            pnlNombreUsuarioI.Style.BackColor1.Color = Color.White;
            pnlNombreUsuario.Style.BackColor1.Color = Color.White;
        }


    }
}