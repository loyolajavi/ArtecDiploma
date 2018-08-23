using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;

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
            try
            {
                FRAMEWORK.Servicios.ServicioDV.DVRecomponer();
                //Abrir el login y cerrar este form
                //this.Hide();
                //Login frmLogin = new Login();
                //frmLogin.FormClosed += (s, args) => this.Close();
                //frmLogin.Show();
                this.Close();
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDVRecomponer - btnRecomponerDV_Click");
                MessageBox.Show("Ocurrio un error al intentar recomponer los D�gitos Verificadores, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }
    }
}