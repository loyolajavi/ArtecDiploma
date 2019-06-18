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
    public partial class AgregarInventarioCU : UserControl
    {

        public AgregarInventarioCU()
        {
            InitializeComponent();

            Dictionary<string, string[]> diclblBien = new Dictionary<string, string[]>();
            string[] IdiomalblBien = { "Bien" };
            diclblBien.Add("Idioma", IdiomalblBien);
            this.lblBien.Tag = diclblBien;

            Dictionary<string, string[]> diclblMarca = new Dictionary<string, string[]>();
            string[] IdiomalblMarca = { "Marca" };
            diclblMarca.Add("Idioma", IdiomalblMarca);
            this.lblMarca.Tag = diclblMarca;

            Dictionary<string, string[]> diclblTipoBien = new Dictionary<string, string[]>();
            string[] IdiomalblTipoBien = { "Tipo" };
            diclblTipoBien.Add("Idioma", IdiomalblTipoBien);
            this.lblTipoBien.Tag = diclblTipoBien;

            Dictionary<string, string[]> diclblSerieKey = new Dictionary<string, string[]>();
            string[] IdiomalblSerieKey = { "Serie" };
            diclblSerieKey.Add("Idioma", IdiomalblSerieKey);
            this.lblSerieKey.Tag = diclblSerieKey;

            Dictionary<string, string[]> diclblModelo = new Dictionary<string, string[]>();
            string[] IdiomalblModelo = { "Modelo" };
            diclblModelo.Add("Idioma", IdiomalblModelo);
            this.lblModelo.Tag = diclblModelo;

            Dictionary<string, string[]> diclblCosto = new Dictionary<string, string[]>();
            string[] IdiomalblCosto = { "Costo" };
            diclblCosto.Add("Idioma", IdiomalblCosto);
            this.lblCosto.Tag = diclblCosto;

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;
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

        public DevComponents.DotNetBar.Validator.SuperValidator unValidador
        {
            get { return vldCUAgregarInventarioCU; }
            set { vldCUAgregarInventarioCU = value; }
        }

        private void AgregarInventarioCU_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
        }





    }
}
