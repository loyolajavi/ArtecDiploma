using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

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
            
        //    if (txtRuta.Text.Length != 3)
        //    {
        //        txtRuta.Text = txtRuta.Text + "\\" + txtNombre.Text + ".bak";
        //    }
        //    else
        //    {
        //        txtRuta.Text = txtRuta.Text + txtNombre.Text + ".bak";
        //    }


        //    try
        //    {
        //        unaConexion.ConexionIniciar("Data Source=PCJAVI\\SQLExpress;Initial Catalog=PatenteFamiliaEjemplo;Integrated Security=SSPI");

        //        StringBuilder sCmd = new StringBuilder();

        //        unaConexion.Ejecutar("BACKUP DATABASE [" + txtBase.Text + "] TO DISK = N'" + txtRuta.Text + "' WITH DESCRIPTION = N'" + txtObs.Text + "', NOFORMAT, NOINIT, NAME = N'" + txtNombre.Text + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", false, IConexion.TipoRetorno.SinResultado);
        //        Interaction.MsgBox("Backup realizado");
        //        this.Close();


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        unaConexion.ConexionFinalizar();
        //    }
        }










    }
}