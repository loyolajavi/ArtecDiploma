using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.BLL;
using ARTEC.BLL.Servicios;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.GUI
{
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<Idioma> unosIdiomas = new List<Idioma>();
        BLLIdioma ManagerIdioma = new BLLIdioma();
        


        public Login()
        {
            InitializeComponent();
        }

        private void txtNombreUsuario_Enter(object sender, EventArgs e)
        {
            pnlNombreUsuarioI.Style.BackColor1.Color = Color.LightSkyBlue;
            pnlNombreUsuario.Style.BackColor1.Color = System.Drawing.SystemColors.ButtonFace;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            pnlPassI.Style.BackColor1.Color = Color.LightSkyBlue;
            pnlPass.Style.BackColor1.Color = System.Drawing.SystemColors.ButtonFace;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            pnlPassI.Style.BackColor1.Color = Color.White;
            pnlPass.Style.BackColor1.Color = Color.White;
        }

        private void txtNombreUsuario_Leave(object sender, EventArgs e)
        {
            pnlNombreUsuarioI.Style.BackColor1.Color = Color.White;
            pnlNombreUsuario.Style.BackColor1.Color = Color.White;
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Traigo todos los idiomas
            unosIdiomas = ManagerIdioma.IdiomaTraerTodos();
            cboIdioma.DataSource = null;
            cboIdioma.DisplayMember = "NombreIdioma";
            cboIdioma.ValueMember = "IdIdioma";
            cboIdioma.DataSource = unosIdiomas;

            //Obtengo el utilizado la �ltima vez
            BLLIdioma.unIdiomaActual = unosIdiomas.Find(x => x.IdiomaActual == true);
            cboIdioma.SelectedItem = BLLIdioma.unIdiomaActual;

            //Traduzco con el IdiomaActual
            ManagerIdioma.Traducir(this.FindForm(), BLLIdioma.unIdiomaActual.IdIdioma);

        }

        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ManagerIdioma.CambiarIdioma(this.FindForm(), (Idioma)cboIdioma.SelectedItem);
        }







        





    }
}