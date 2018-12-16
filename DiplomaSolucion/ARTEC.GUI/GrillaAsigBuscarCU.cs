using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class GrillaAsigBuscarCU : UserControl
    {

        public event DataGridViewCellEventHandler ClickEnGrilla;
        public event EventHandler ClickEnPanel;

        public GrillaAsigBuscarCU()
        {
            InitializeComponent();
            Dictionary<string, string[]> diclblNroAsignacion = new Dictionary<string, string[]>();
            string[] IdiomalblNroAsignacion = { "Asignación" };
            diclblNroAsignacion.Add("Idioma", IdiomalblNroAsignacion);
            this.lblNroAsignacion.Tag = diclblNroAsignacion;

            Dictionary<string, string[]> diclblNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolicitud = { "Solicitud" };
            diclblNroSolicitud.Add("Idioma", IdiomalblNroSolicitud);
            this.lblNroSolicitud.Tag = diclblNroSolicitud;

            Dictionary<string, string[]> diclblFecha = new Dictionary<string, string[]>();
            string[] IdiomalblFecha = { "Fecha" };
            diclblFecha.Add("Idioma", IdiomalblFecha);
            this.lblFecha.Tag = diclblFecha;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;
        }


        public string IdSolicitud
        {
            get { return txtNroSolicitud.Text; }
            set { txtNroSolicitud.Text = value; }
        }

        public string IdAsignacion
        {
            get { return txtAsignacion.Text; }
            set { txtAsignacion.Text = value; }
        }

        public string NombreDependencia
        {
            get { return txtDep.Text; }
            set { txtDep.Text = value; }
        }

        public DevComponents.DotNetBar.Controls.DataGridViewX unaGrilla
        {
            get { return GrillaBienes; }
            set { GrillaBienes = value; }
        }


        public string laFecha
        {
            get { return txtFecha.Text; }
            set { txtFecha.Text = value; }
        }


        private void GrillaBienes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ClickEnGrilla != null)
                this.ClickEnGrilla(this, e);
        }


        private void pnlTitulos_CellDoubleClick(object sender, EventArgs e)
        {
            if (this.ClickEnPanel != null)
                this.ClickEnPanel(this, e);
        }

        private void GrillaAsigBuscarCU_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
        }


    }
}
