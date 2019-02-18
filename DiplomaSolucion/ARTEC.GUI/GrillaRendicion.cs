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

            Dictionary<string, string[]> diclblFactura = new Dictionary<string, string[]>();
            string[] IdiomalblFactura = { "Factura" };
            diclblFactura.Add("Idioma", IdiomalblFactura);
            this.lblFactura.Tag = diclblFactura;
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
