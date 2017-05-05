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

            //Obtengo el utilizado la última vez
            ServicioIdioma.unIdiomaActual = unosIdiomas.Find(x => x.IdiomaActual == true);
            cboIdioma.SelectedItem = ServicioIdioma.unIdiomaActual;

            //Traduzco con el IdiomaActual
            ServicioIdioma.Traducir(this.FindForm(), ServicioIdioma.unIdiomaActual.IdIdioma);

            //Prueba frmPrueba = new Prueba();
            //frmPrueba.Show();

        }

        /// <summary>
        /// Evento para modificar el idioma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ESTE CODIGO VA EN LOGIN
            //******************************************************************************************************************************************************//
            //ServicioIdioma.CambiarIdioma(this.FindForm(), (Idioma)cboIdioma.SelectedItem);//Cambiaba el idioma del propio formulario solamente
            //******************************************************************************************************************************************************//
            
            //ESTE CODIGO VA EN EL MENU PRINCIPAL
            //******************************************************************************************************************************************************//
            //Para cambiar el idioma de todos los formularios abiertos
            ServicioIdioma.CambiarIdioma(this.FindForm(), (Idioma)cboIdioma.SelectedItem);
            foreach (Control unForm in Application.OpenForms)
            {
                ServicioIdioma.Traducir(unForm, ServicioIdioma.unIdiomaActual.IdIdioma);
            } 
            //******************************************************************************************************************************************************//
            
            
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
                    MessageBox.Show(ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario);
                }
                else
                {
                    MessageBox.Show("El usuario y/o contraseña son incorrectos");
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









        





    }
}