using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL.Servicios;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class frmParametros : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmParametros()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!vldFrmParametros.Validate())
                return;

            BLLServicioMail ManagerServicioMail = new BLLServicioMail();
            try
            {
                FRAMEWORK.Servicios.ServicioMail.remitente = txtMail.Text;
                FRAMEWORK.Servicios.ServicioMail.remps = ServicioSecurizacion.Encriptar(txtPass.Text);
                FRAMEWORK.Servicios.ServicioMail.Puerto = Int32.Parse(txtPuerto.Text);
                FRAMEWORK.Servicios.ServicioMail.Host = txtHost.Text;
                if (chkSSL.Checked)
                    FRAMEWORK.Servicios.ServicioMail.ssl = true;
                else
                    FRAMEWORK.Servicios.ServicioMail.ssl = false;
                ManagerServicioMail.ModificarMailConfig(FRAMEWORK.Servicios.ServicioMail.remitente, FRAMEWORK.Servicios.ServicioMail.remps, FRAMEWORK.Servicios.ServicioMail.Puerto, FRAMEWORK.Servicios.ServicioMail.Host, FRAMEWORK.Servicios.ServicioMail.ssl);
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada correctamente").Texto);
                this.Close();
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmParametros - btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar la configuración de mail, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }


        }


    }
}