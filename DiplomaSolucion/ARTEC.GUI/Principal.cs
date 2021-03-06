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
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class Principal : DevComponents.DotNetBar.Metro.MetroForm
    {


        List<Idioma> unosIdiomas = new List<Idioma>();

        public Principal()
        {
            InitializeComponent();

            //tabsPrincipal.SelectedIndexChanged += tabsPrincipal_SelectedIndexChanged;

            SolicitudBuscar frmSolicitudBuscar = new SolicitudBuscar();
            frmSolicitudBuscar.TopLevel = false;
            frmSolicitudBuscar.FormBorderStyle = FormBorderStyle.None;
            frmSolicitudBuscar.Visible = true;
            frmSolicitudBuscar.Dock = DockStyle.Fill;
            tabSolic.Controls.Add(frmSolicitudBuscar);


        }


        private void Principal_Load(object sender, EventArgs e)
        {
            //Traigo todos los idiomas
            //unosIdiomas = ServicioIdioma.IdiomaTraerTodos();


            //Obtengo el utilizado la �ltima vez
            //ServicioIdioma.unIdiomaActual = unosIdiomas.Find(x => x.IdiomaActual == true);

            //Traduzco con el IdiomaActual del usuario logueado
            ServicioIdioma.CambiarIdioma(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
            //Traigo todos los idiomas
            unosIdiomas = ServicioIdioma.IdiomaTraerTodos();
            cboIdioma.DataSource = null;
            cboIdioma.DisplayMember = "NombreIdioma";
            cboIdioma.ValueMember = "IdIdioma";
            cboIdioma.DataSource = unosIdiomas;

            //Obtengo el idioma actual del usuario para ponerlo en el cboidioma
            cboIdioma.SelectedValue = ServicioIdioma.unIdiomaActual;


            
        }

        private void tabsPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as System.Windows.Forms.TabControl).SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    SoftHomologadoBuscar frmSoftHom = SoftHomologadoBuscar.ObtenerInstancia();
                    frmSoftHom.TopLevel = false;
                    frmSoftHom.FormBorderStyle = FormBorderStyle.None;
                    frmSoftHom.Visible = true;
                    frmSoftHom.Dock = DockStyle.Fill;
                    tabHomol.Controls.Add(frmSoftHom);
                    break;
                case 2:
                    frmPartidaBuscar unFrmPartidaBuscar = frmPartidaBuscar.ObtenerInstancia();
                    unFrmPartidaBuscar.TopLevel = false;
                    unFrmPartidaBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmPartidaBuscar.Visible = true;
                    unFrmPartidaBuscar.Dock = DockStyle.Fill;
                    tabPartidas.Controls.Add(unFrmPartidaBuscar);
                    break;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CrearSolicitud unfrmCrearSolicitud = new CrearSolicitud();
            unfrmCrearSolicitud.Show();
        }

        private void btnSolicitarPartida_Click(object sender, EventArgs e)
        {
            frmPartidaSolicitar unfrmPartidaSolicitar = frmPartidaSolicitar.ObtenerInstancia();
            unfrmPartidaSolicitar.Show();
        }

        private void btnPartidaAsociar_Click(object sender, EventArgs e)
        {
            frmPartidaAsociar unfrmPartidaAsociar = new frmPartidaAsociar();
            unfrmPartidaAsociar.Show();
        }

        private void btnBienRegistrar_Click(object sender, EventArgs e)
        {
            frmBienRegistrar unfrmBienRegistrar = new frmBienRegistrar();
            unfrmBienRegistrar.Show();
        }

        private void btnRendicionCrear_Click(object sender, EventArgs e)
        {
            frmRendicionCrear unfrmRendicionCrear = new frmRendicionCrear();
            unfrmRendicionCrear.Show();
        }

        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ServicioIdioma.CambiarIdioma(this.FindForm(), (int)cboIdioma.SelectedValue))
            {
                foreach (Control unForm in Application.OpenForms)
                {
                    ServicioIdioma.Traducir(unForm, ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
                }
            }

        }




    }
}