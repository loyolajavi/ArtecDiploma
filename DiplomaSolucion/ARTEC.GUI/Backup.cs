using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;

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
            if (vldRespaldo.Validate())
            {
                if (ServicioBackup.Respaldar(txtNombreRespaldar.Text, txtDestino.Text, txtObservaciones.Text))
                {
                    MessageBox.Show("Backup realizado correctamente");
                }
                else
                {
                    MessageBox.Show("No pudo realizarse el Backup");
                }
            }
            
        }


        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (vldRestaurar.Validate())
            {
                if (ServicioBackup.Restaurar(txtNombreRestaurar.Text, txtUbicacion.Text))
                {
                    MessageBox.Show("Se restauró la base de datos correctamente");
                }
                else
                {
                    MessageBox.Show("No pudo restaurarse la base de datos");
                }
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












    }
}