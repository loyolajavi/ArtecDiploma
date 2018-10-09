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
using ARTEC.BLL.Servicios;
using System.Linq;

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
            try
            {
                //Traduzco con el IdiomaActual del usuario logueado
                Idioma.unIdiomaActual = ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual;
                Idioma._EtiquetasCompartidas = null;
                BLLServicioIdioma.Traducir(this.FindForm(), Idioma.unIdiomaActual);
                //Traigo todos los idiomas
                unosIdiomas = BLLServicioIdioma.IdiomaTraerTodos();
                cboIdioma.DataSource = null;
                cboIdioma.DisplayMember = "NombreIdioma";
                cboIdioma.ValueMember = "IdIdioma";
                cboIdioma.DataSource = unosIdiomas;

                //Obtengo el idioma actual del usuario para ponerlo en el cboidioma
                cboIdioma.SelectedValue = Idioma.unIdiomaActual;

                //Permisos
                foreach (Control unControl in this.Controls)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.ToString() != "")
                    {
                        if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, unControl.Tag as string[]))
                        {
                            unControl.Visible = false;
                            unControl.Enabled = false;
                        }

                    }
                }
            }
            catch (Exception es)
            {
                throw;
            }
            
            
        }

        


        private void tabsPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as System.Windows.Forms.TabControl).SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    frmRendicionBuscar unFrmRendicionBuscar = frmRendicionBuscar.ObtenerInstancia();
                    unFrmRendicionBuscar.TopLevel = false;
                    unFrmRendicionBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmRendicionBuscar.Visible = true;
                    unFrmRendicionBuscar.Dock = DockStyle.Fill;
                    tabRendiciones.Controls.Add(unFrmRendicionBuscar);
                    break;
                case 2:
                    frmPartidaBuscar unFrmPartidaBuscar = frmPartidaBuscar.ObtenerInstancia();
                    unFrmPartidaBuscar.TopLevel = false;
                    unFrmPartidaBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmPartidaBuscar.Visible = true;
                    unFrmPartidaBuscar.Dock = DockStyle.Fill;
                    tabPartidas.Controls.Add(unFrmPartidaBuscar);
                    break;
                case 3:
                    frmDependenciaBuscar unFrmDependenciaBuscar = frmDependenciaBuscar.ObtenerInstancia();
                    unFrmDependenciaBuscar.TopLevel = false;
                    unFrmDependenciaBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmDependenciaBuscar.Visible = true;
                    unFrmDependenciaBuscar.Dock = DockStyle.Fill;
                    tabDependencia.Controls.Add(unFrmDependenciaBuscar);
                    break;
                case 4:
                    frmAsignacionBuscar unFrmAsignacionBuscar = frmAsignacionBuscar.ObtenerInstancia();
                    unFrmAsignacionBuscar.TopLevel = false;
                    unFrmAsignacionBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmAsignacionBuscar.Visible = true;
                    unFrmAsignacionBuscar.Dock = DockStyle.Fill;
                    tabAsignaciones.Controls.Add(unFrmAsignacionBuscar);
                    break;
                case 5:
                    frmAdquisicionBuscar unFrmAdquisicionBuscar = frmAdquisicionBuscar.ObtenerInstancia();
                    unFrmAdquisicionBuscar.TopLevel = false;
                    unFrmAdquisicionBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmAdquisicionBuscar.Visible = true;
                    unFrmAdquisicionBuscar.Dock = DockStyle.Fill;
                    tabAdquisiciones.Controls.Add(unFrmAdquisicionBuscar);
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
            if (BLLServicioIdioma.CambiarIdioma(this.FindForm(), (int)cboIdioma.SelectedValue))
            {
                foreach (Control unForm in Application.OpenForms)
                {
                    BLLServicioIdioma.Traducir(unForm, Idioma.unIdiomaActual);
                }
            }

        }


        private void btnAgentes_Click(object sender, EventArgs e)
        {
            frmAgentesGestion unFrmAgentesGestion = new frmAgentesGestion();
            unFrmAgentesGestion.Show();
        }


        private void btnAvanzadas_Click_1(object sender, EventArgs e)
        {
            panelEx1.Visible = true;
            panelEx1.BringToFront();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelEx1.Visible = false;
            panelEx1.SendToBack();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuariosModificar unFrmUsuariosGestion = new frmUsuariosModificar();
            unFrmUsuariosGestion.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup unFrmBackup = new Backup();
            unFrmBackup.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            frmBitacora unFrmBitacora = new frmBitacora();
            unFrmBitacora.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategoriaGestion unFrmCategoriaGestion = new frmCategoriaGestion();
            unFrmCategoriaGestion.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            frmProveedorCrear unFrmProveedorCrear = new frmProveedorCrear();
            unFrmProveedorCrear.Show();
        }

        private void btnFamilias_Click(object sender, EventArgs e)
        {
            frmFamiliaGestion unFrmFamiliasGestion = new frmFamiliaGestion();
            unFrmFamiliasGestion.Show();
        }





    }
}