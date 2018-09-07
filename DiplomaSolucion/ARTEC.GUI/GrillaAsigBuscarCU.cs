using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARTEC.GUI
{
    public partial class GrillaAsigBuscarCU : UserControl
    {

        public event DataGridViewCellEventHandler ClickEnGrilla;
        public event EventHandler ClickEnPanel;

        public GrillaAsigBuscarCU()
        {
            InitializeComponent();
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


    }
}
