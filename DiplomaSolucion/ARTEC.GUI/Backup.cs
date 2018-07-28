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
            FolderBrowserDialog Directorio = new FolderBrowserDialog();

            if (Directorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtUbicacion.Text = Directorio.SelectedPath;
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
                        MessageBox.Show("Backup realizado correctamente");
                        ServicioLog.CrearLog("Realizar backup", "Backup realizado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No pudo realizarse el Backup");
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnRespaldar_Click");
                MessageBox.Show("Ocurrio un error al intentar respaldar la base de datos, por favor informe del error Nro " + IdError + " del Log de Eventos");
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
                        MessageBox.Show("Se restauró la base de datos correctamente, por favor inicie nuevamente la aplicación");
                        ServicioLog.CrearLog("Restaurar BD", "Restauración realizada correctamente");
                        //Para que no aparezca el login al sistema si no se restauró la BD
                        DialogResult = DialogResult.OK;
                        //Para salir del sistema en forma limpia posteriormente a la restauración
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("No pudo restaurarse la base de datos");
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnRestaurar_Click");
                MessageBox.Show("Ocurrio un error al intentar restaurar la base de datos, por favor informe del error Nro " + IdError + " del Log de Eventos");
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
            BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
        }












    }
}