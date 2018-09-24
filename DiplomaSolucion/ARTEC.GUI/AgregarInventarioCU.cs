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
    public partial class AgregarInventarioCU : UserControl
    {

        public AgregarInventarioCU()
        {
            InitializeComponent();
        }

        public string unBien
        {
            get { return txtBien.Text; }
            set { txtBien.Text = value; }
        }

        public string unIdBien
        {
            get { return txtIdBien.Text; }
            set { txtIdBien.Text = value; }
        }

        public DevComponents.DotNetBar.Controls.ComboBoxEx unaMarca 
        {
            get { return cboMarca; }
            set { cboMarca = value; }
        }
        public string unSerie
        {
            get { return txtSerieKey.Text; }
            set { txtSerieKey.Text = value; }
        }
        public DevComponents.DotNetBar.Controls.ComboBoxEx unTipoBien
        {
            get { return cboTipoBien; }
            set { cboTipoBien = value; }
        }
        public DevComponents.DotNetBar.Controls.ComboBoxEx  unModelo
        {
            get { return cboModelo; }
            set { cboModelo = value; }
        }
        public decimal unCosto
        {
            get { return decimal.Parse(txtCosto.Text); }
            set { txtCosto.Text = value.ToString(); }
        }

        public DevComponents.DotNetBar.ButtonX unBtnAgregar
        {
            get { return this.btnAgregar; }
        }


    }
}
