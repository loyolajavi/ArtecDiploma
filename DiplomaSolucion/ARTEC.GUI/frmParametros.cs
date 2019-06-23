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
            
            Dictionary<string, string[]> dicfrmParametros = new Dictionary<string, string[]>();
            string[] IdiomafrmParametros = { "Configurar Mail" };
            dicfrmParametros.Add("Idioma", IdiomafrmParametros);
            this.Tag = dicfrmParametros;

            Dictionary<string, string[]> diclblMail = new Dictionary<string, string[]>();
            string[] IdiomalblMail = { "Mail" };
            diclblMail.Add("Idioma", IdiomalblMail);
            this.lblMail.Tag = diclblMail;

            Dictionary<string, string[]> diclblPass = new Dictionary<string, string[]>();
            string[] IdiomalblPass = { "Contraseña" };
            diclblPass.Add("Idioma", IdiomalblPass);
            this.lblPass.Tag = diclblPass;

            Dictionary<string, string[]> diclblPuerto = new Dictionary<string, string[]>();
            string[] IdiomalblPuerto = { "Puerto" };
            diclblPuerto.Add("Idioma", IdiomalblPuerto);
            this.lblPuerto.Tag = diclblPuerto;

            Dictionary<string, string[]> diclblHost = new Dictionary<string, string[]>();
            string[] IdiomalblHost = { "Host" };
            diclblHost.Add("Idioma", IdiomalblHost);
            this.lblHost.Tag = diclblHost;

            Dictionary<string, string[]> diclblSSL = new Dictionary<string, string[]>();
            string[] IdiomalblSSL = { "SSL" };
            diclblSSL.Add("Idioma", IdiomalblSSL);
            this.lblSSL.Tag = diclblSSL;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] PerbtnModificar = { "Mail Modificar" };
            dicbtnModificar.Add("Permisos", PerbtnModificar);
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

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

        private void frmParametros_Load(object sender, EventArgs e)
        {
            try
            {
                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                //Idioma
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmParametros_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al configurar el mail, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
           
        }

        private void frmParametros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }


    }
}