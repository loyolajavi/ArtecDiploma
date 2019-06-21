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
using ARTEC.BLL.Servicios;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<Idioma> unosIdiomas = new List<Idioma>();
        bool FlagSinIntegridad = false;
        


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
            try
            {
                //Traigo todos los idiomas
                unosIdiomas = BLLServicioIdioma.IdiomaTraerTodos();
                cboIdioma.DataSource = null;
                cboIdioma.DisplayMember = "NombreIdioma";
                cboIdioma.ValueMember = "IdIdioma";
                cboIdioma.DataSource = unosIdiomas;

                //Obtengo el idioma default
                Idioma.unIdiomaDefault = unosIdiomas.Find(x => x.ElIdiomaDefault == true);
                cboIdioma.SelectedItem = Idioma.unIdiomaDefault;

                //Dejo constancia del idioma actual en memoria
                Idioma.unIdiomaActual = Idioma.unIdiomaDefault.IdIdioma;

                //Traduzco con el idioma Default
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), Idioma.unIdiomaActual);

                //Verifica Integridad Base Datos
                List<bool> IntegridadDVV = ARTEC.FRAMEWORK.Servicios.ServicioDV.DVVerificarIntegridadBD();
                if (IntegridadDVV.Any(x => x.Equals(false)))
                {
                    //VER:Que pida login y que solo lo pueda hacer un usuario con permisos de Administrador
                    FlagSinIntegridad = true;
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Existen inconsistencias en la Base de Datos, solo podrá loguearse un usuario con permisos de administrador para intentar solucionarlo").Texto);
                    //DialogResult resmbox = MessageBox.Show("Existen inconsistencias en la Base de Datos ¿Desea abrir el menú para restaurar la misma? De lo contrario se redirigirá al menú para regenerar los Digitos Verificadores", "Advertencia", MessageBoxButtons.YesNo);
                    //if (resmbox == DialogResult.Yes)
                    //{
                    //    Backup unFrmBackup = new Backup();
                    //    //Solo permite loguearse al sistema si se restaura la BD
                    //    if (unFrmBackup.ShowDialog() != DialogResult.OK)
                    //        this.Close();
                    //}
                    //else
                    //{
                    //    //VER: Abrir ventana Regenerar DV
                    //}
                    
                }

                this.ActiveControl = txtNombreUsuario;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "Login_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al iniciar el sistema, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
                this.Close();
            }
        }



        /// <summary>
        /// Evento para modificar el idioma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Idioma._EtiquetasCompartidas = null;
            BLLServicioIdioma.GetBLLServicioIdiomaUnico().CambiarIdioma(this.FindForm(), (int)cboIdioma.SelectedValue);
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

                //Consulta us y pass coincidentes y loguea al usuario
                try
                {
                    
                    if (FlagSinIntegridad == false)
                    {
                        if (unManagerUsuario.UsuarioTraerPorLogin(txtNombreUsuario.Text, ServicioSecurizacion.Encriptar(ServicioSecurizacion.AplicarHash(txtPass.Text))))
                        {
                            this.Close();
                            ServicioLog.CrearLog("Login", BLLServicioIdioma.MostrarMensaje("Ingreso Correcto").Texto);
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Mensaje2").Texto);
                            ServicioLog.CrearLog("Login", BLLServicioIdioma.MostrarMensaje("Ingreso Incorrecto").Texto);
                        }
                    }
                    else
                    {
                        if (unManagerUsuario.UsuarioTraerPorLogin(txtNombreUsuario.Text, ServicioSecurizacion.Encriptar(ServicioSecurizacion.AplicarHash(txtPass.Text))))
                        {
                            if (FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos.Exists(x => x.NombreIFamPat == "Administracion Total" | x.NombreIFamPat == "Administracion Sistema"))
                            {
                                this.Close();
                                ServicioLog.CrearLog("Login", BLLServicioIdioma.MostrarMensaje("Ingreso Correcto").Texto);
                                DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Existen inconsistencias en la Base de Datos ¿Desea abrir el menú para restaurar la misma? De lo contrario se redirigirá al menú para regenerar los Digitos Verificadores").Texto, BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                                if (resmbox == DialogResult.Yes)
                                {
                                    //Backup unFrmBackup = new Backup();
                                    ////Solo permite loguearse al sistema si se restaura la BD
                                    //if (unFrmBackup.ShowDialog() != DialogResult.OK)
                                    //    this.Close();
                                    DialogResult = DialogResult.Yes;
                                }
                                else
                                {
                                    //Abre ventana para Regenerar DV
                                    DialogResult = DialogResult.No;
                                }
                            }
                            else
                                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Solo un usuario con permisos de Administración del sistema o total puede loguearse si la BD tiene inconsistencias").Texto);
                            
                        }
                        else
                        {
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Mensaje2").Texto);
                            ServicioLog.CrearLog("Login", BLLServicioIdioma.MostrarMensaje("Ingreso Incorrecto").Texto);
                        }
                        
                    }
                }
                catch (Exception es)
                {
                    string IdError = ServicioLog.CrearLog(es, "btnLogin_Click");
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error en el logueo, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" en el Log de Eventos").Texto);
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

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }











        





    }
}