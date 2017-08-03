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
    public partial class GrillaRendicion : UserControl
    {
        public GrillaRendicion()
        {
            InitializeComponent();
        }

        public string unaFactura
        {
            get { return txtFactura.Text; }
            set { txtFactura.Text = value; }
        }

        public DevComponents.DotNetBar.Controls.DataGridViewX unaGrillaInv
        {
            get { return GrillaInventarios; }
            set { GrillaInventarios = value; }
        }

    }
}
