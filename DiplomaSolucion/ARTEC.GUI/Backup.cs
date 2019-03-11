using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class Backup : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Backup()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicBackUp = new Dictionary<string, string[]>();
            string[] IdiomaBackUp = { "Respaldo y Restauración de la BD" };
            dicBackUp.Add("Idioma", IdiomaBackUp);
            this.Tag = dicBackUp;

            Dictionary<string, string[]> dicbtnRespaldar = new Dictionary<string, string[]>();
            string[] IdiomabtnRespaldar = { "Respaldar" };
            dicbtnRespaldar.Add("Idioma", IdiomabtnRespaldar);
            this.btnRespaldar.Tag = dicbtnRespaldar;

            Dictionary<string, string[]> diclblNombreRespaldar = new Dictionary<string, string[]>();
            string[] IdiomalblNombreRespaldar = { "Nombre" };
            diclblNombreRespaldar.Add("Idioma", IdiomalblNombreRespaldar);
            this.lblNombreRespaldar.Tag = diclblNombreRespaldar;

            Dictionary<string, string[]> diclblDestinoRespaldar = new Dictionary<string, string[]>();
            string[] IdiomalblDestinoRespaldar = { "Destino" };
            diclblDestinoRespaldar.Add("Idioma", IdiomalblDestinoRespaldar);
            this.lblDestinoRespaldar.Tag = diclblDestinoRespaldar;

            Dictionary<string, string[]> diclblObservaciones = new Dictionary<string, string[]>();
            string[] IdiomalblObservaciones = { "Observaciones" };
            diclblObservaciones.Add("Idioma", IdiomalblObservaciones);
            this.lblObservaciones.Tag = diclblObservaciones;

            Dictionary<string, string[]> dicbtnExaminarRespaldar = new Dictionary<string, string[]>();
            string[] IdiomabtnExaminarRespaldar = { "Examinar" };
            dicbtnExaminarRespaldar.Add("Idioma", IdiomabtnExaminarRespaldar);
            this.btnExaminarRespaldar.Tag = dicbtnExaminarRespaldar;

            Dictionary<string, string[]> dicgboxRestaurar = new Dictionary<string, string[]>();
            string[] IdiomagboxRestaurar = { "Restaurar" };
            dicgboxRestaurar.Add("Idioma", IdiomagboxRestaurar);
            this.gboxRestaurar.Tag = dicgboxRestaurar;

            Dictionary<string, string[]> diclblNombreRestaurar = new Dictionary<string, string[]>();
            string[] IdiomalblNombreRestaurar = { "Nombre" };
            diclblNombreRestaurar.Add("Idioma", IdiomalblNombreRestaurar);
            this.lblNombreRestaurar.Tag = diclblNombreRestaurar;

            Dictionary<string, string[]> diclblUbicacionRestaurar = new Dictionary<string, string[]>();
            string[] IdiomalblUbicacionRestaurar = { "Ubicación" };
            diclblUbicacionRestaurar.Add("Idioma", IdiomalblUbicacionRestaurar);
            this.lblUbicacionRestaurar.Tag = diclblUbicacionRestaurar;

            Dictionary<string, string[]> dicbtnExaminarRestaurar = new Dictionary<string, string[]>();
            string[] IdiomabtnExaminarRestaurar = { "Examinar" };
            dicbtnExaminarRestaurar.Add("Idioma", IdiomabtnExaminarRestaurar);
            this.btnExaminarRestaurar.Tag = dicbtnExaminarRestaurar;

            Dictionary<string, string[]> dicbtnRestaurar = new Dictionary<string, string[]>();
            string[] IdiomabtnRestaurar = { "Restaurar" };
            dicbtnRestaurar.Add("Idioma", IdiomabtnRestaurar);
            this.btnRestaurar.Tag = dicbtnRestaurar;

            Dictionary<string, string[]> dicgboxRespaldar = new Dictionary<string, string[]>();
            string[] IdiomagboxRespaldar = { "Respaldar (Realizar BACKUP)" };
            dicgboxRespaldar.Add("Idioma", IdiomagboxRespaldar);
            this.gboxRespaldar.Tag = dicgboxRespaldar;

        }



        private void btnExaminarRespaldar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Directorio = new FolderBrowserDialog();

            if (Directorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDestino.Text = Directorio.SelectedPath;
            }
        }

        private void btnExaminarRestaurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Directorio = new OpenFileDialog();

            if (Directorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(!Directorio.CheckFileExists)
                    return;
                txtUbicacion.Text = Directorio.FileName;
            }
        }


        private void btnRespaldar_Click(object sender, EventArgs e)
        {
            try
            {
                if (vldRespaldo.Validate())
                {
                    if (ServicioBackup.Respaldar(txtNombreRespaldar.Text, txtDestino.Text, txtObservaciones.Text))
                    {
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Realizar backup").Texto, BLLServicioIdioma.MostrarMensaje("Backup realizado correctamente").Texto);
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Backup realizado correctamente").Texto);
                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No pudo realizarse el Backup").Texto);
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnRespaldar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar respaldar la base de datos, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
           
            
        }


        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (vldRestaurar.Validate())
                {
                    if (ServicioBackup.Restaurar(txtNombreRestaurar.Text, txtUbicacion.Text))
                    {
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Restaurar BD").Texto, BLLServicioIdioma.MostrarMensaje("Restauración realizada correctamente").Texto);
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Se restauró la base de datos correctamente, por favor inicie nuevamente la aplicación").Texto);
                        //Para que no aparezca el login al sistema si no se restauró la BD
                        DialogResult = DialogResult.OK;
                        //Para salir del sistema en forma limpia posteriormente a la restauración
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No pudo restaurarse la base de datos").Texto);
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnRestaurar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar restaurar la base de datos, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
        }



        private void customvldNombreRespaldo_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRespaldar.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void customvldtxtDestino_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }



        private void VldtxtNombreRestaurar(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRestaurar.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void VldtxtUbicacion(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            try
            {
                BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }












    }
}