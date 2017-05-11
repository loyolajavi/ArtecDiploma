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
            unosIdiomas = ServicioIdioma.IdiomaTraerTodos();


            //Obtengo el utilizado la última vez
            ServicioIdioma.unIdiomaActual = unosIdiomas.Find(x => x.IdiomaActual == true);

            //Traduzco con el IdiomaActual
            //ServicioIdioma.Traducir(this.FindForm(), ServicioIdioma.unIdiomaActual.IdIdioma);//SOLO PROPIO FORMULARIO
            //TODOS LOS FORMULARIOS ABIERTOS
            foreach (Control unForm in Application.OpenForms)
            {
                ServicioIdioma.Traducir(unForm, ServicioIdioma.unIdiomaActual.IdIdioma);
            }
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
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CrearSolicitud unfrmCrearSolicitud = new CrearSolicitud();
            unfrmCrearSolicitud.Show();
        }




    }
}