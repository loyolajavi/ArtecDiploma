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

            Dictionary<string, string[]> diclblBien = new Dictionary<string, string[]>();
            string[] IdiomalblBien = { "Bien" };
            diclblBien.Add("Idioma", IdiomalblBien);
            this.lblBien.Tag = diclblBien;

            Dictionary<string, string[]> diclblCantidad = new Dictionary<string, string[]>();
            string[] IdiomalblCantidad = { "Cantidad" };
            diclblCantidad.Add("Idioma", IdiomalblCantidad);
            this.lblCantidad.Tag = diclblCantidad;

            Dictionary<string, string[]> dicGrillaInventarios = new Dictionary<string, string[]>();
            string[] IdiomaGrillaInventarios = { "Agregar" };
            dicGrillaInventarios.Add("Idioma", IdiomaGrillaInventarios);
            this.GrillaInventarios.Tag = dicGrillaInventarios;

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


        public DevComponents.DotNetBar.Controls.ComboBoxEx cboAgentes
        {
            get { return cboAgenteSoft; }
            set { cboAgenteSoft = value; }
        }






    }
}
