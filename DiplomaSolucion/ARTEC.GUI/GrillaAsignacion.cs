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
    public partial class GrillaAsignacion : UserControl
    {

        public event DataGridViewCellEventHandler ClickEnGrilla;

        public GrillaAsignacion()
        {
            InitializeComponent();
        }

        public string unBien
        {
            get { return txtBien.Text; }
            set { txtBien.Text = value; }
        }

        public string unaCantidad
        {
            get { return txtCantidad.Text; }
            set { txtCantidad.Text = value; }
        }

        public DevComponents.DotNetBar.Controls.DataGridViewX unaGrilla
        {
            get { return GrillaInventarios; }
            set { GrillaInventarios = value; }
        }

        protected void GrillaInventarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ClickEnGrilla != null)
                this.ClickEnGrilla(this, e);
        }

    }
}
