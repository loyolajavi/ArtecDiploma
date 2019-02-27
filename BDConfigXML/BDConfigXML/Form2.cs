using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace BDConfigXML
{
    public partial class Form2 : DevComponents.DotNetBar.OfficeForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGenerarXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validador.Validate())
                    return;

                List<ConfiguracionConexion> ListaDatosBD = new List<ConfiguracionConexion>();
                ConfiguracionConexion unDatosDB = new ConfiguracionConexion();
                ConfiguracionConexion unDatosDB2 = new ConfiguracionConexion();

                unDatosDB.DataSourceBD = "Data Source=" + txtServidor.Text + ";";
                unDatosDB.InitialCatalogBD = "Initial Catalog=" + txtBase.Text + ";";
                unDatosDB.UsuarioBD = "user Id=" + txtUsuario.Text + ";";
                unDatosDB.PasswordBD = "Password=" + txtPass.Text + ";";
                ListaDatosBD.Add(unDatosDB);

                unDatosDB2.DataSourceBD = "Data Source=" + txtServidor.Text + ";";
                unDatosDB2.InitialCatalogBD = "Initial Catalog=master;";
                unDatosDB2.UsuarioBD = "user Id=" + txtUsuario.Text + ";";
                unDatosDB2.PasswordBD = "Password=" + txtPass.Text + ";";
                ListaDatosBD.Add(unDatosDB2);

                var Resultado = ServicioSerializadorXML.Serializar(ListaDatosBD);

                using (StreamWriter sw = new StreamWriter(txtDestino.Text + "\\DatosBD.xml"))
                {
                    sw.Write(ServicioSerializadorXML.StreamAString(Resultado));
                    sw.Close();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es.Message);
            }
           
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Directorio = new FolderBrowserDialog();

            try
            {
                if (Directorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDestino.Text = Directorio.SelectedPath;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es.Message);
            }


        }
    }
}