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
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<Idioma> unosIdiomas = new List<Idioma>();
        


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
            unosIdiomas = ServicioIdioma.IdiomaTraerTodos();
            cboIdioma.DataSource = null;
            cboIdioma.DisplayMember = "NombreIdioma";
            cboIdioma.ValueMember = "IdIdioma";
            cboIdioma.DataSource = unosIdiomas;

            //Obtengo el idioma default
            ServicioIdioma.unIdiomaDefault = unosIdiomas.Find(x => x.ElIdiomaDefault == true);
            cboIdioma.SelectedItem = ServicioIdioma.unIdiomaDefault;

            //Dejo constancia del idioma actual en memoria
            ServicioIdioma.unIdiomaActual = ServicioIdioma.unIdiomaDefault.IdIdioma;
            
            //Traduzco con el idioma Default
            ServicioIdioma.Traducir(this.FindForm(), ServicioIdioma.unIdiomaDefault.IdIdioma);
        }



        /// <summary>
        /// Evento para modificar el idioma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ServicioIdioma.CambiarIdioma(this.FindForm(), (int)cboIdioma.SelectedValue);
        }



        /// <summary>
        /// Evento para loguear a un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (vldNombreUs.Validate() && vldtxtPass.Validate())
            {
                BLLUsuario unManagerUsuario = new BLLUsuario();

                //string pas = ServicioSecurizacion.AplicarHash("1234");
                //MessageBox.Show(pas);

                //Consulta us y pass coincidentes y loguea al usuario
                if (unManagerUsuario.UsuarioTraerPorLogin(txtNombreUsuario.Text, ServicioSecurizacion.AplicarHash(txtPass.Text)))
                {
                    //MessageBox.Show(ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ServicioIdioma.MostrarMensaje("Mensaje2").Texto);
                }

            }
        }

        private void vldtxtNombreUsuario(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void EventVldTxtPass1(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }









        





    }
}