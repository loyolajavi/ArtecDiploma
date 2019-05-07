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
            txtUsuario.Enabled = true;
            txtPass.Enabled = true;
        }

        private void btnGenerarXML_Click(object sender, EventArgs e)
        {
            try
            {
                

                List<ConfiguracionConexion> ListaDatosBD = new List<ConfiguracionConexion>();
                ConfiguracionConexion unDatosDB = new ConfiguracionConexion();
                ConfiguracionConexion unDatosDB2 = new ConfiguracionConexion();

                //Artec
                unDatosDB.DataSourceBD = ServicioSecurizacion.Encriptar("Data Source=" + txtServidor.Text + ";");
                unDatosDB.InitialCatalogBD = ServicioSecurizacion.Encriptar("Initial Catalog=" + txtBase.Text + ";");

                //Backup
                unDatosDB2.DataSourceBD = ServicioSecurizacion.Encriptar("Data Source=" + txtServidor.Text + ";");
                unDatosDB2.InitialCatalogBD = ServicioSecurizacion.Encriptar("Initial Catalog=master;");

                //Si está tildado SSO
                if (cboxSSPI.Checked)
                {
                    requiredFieldValidator2.IsEmptyStringValid = true;
                    requiredFieldValidator3.IsEmptyStringValid = true;
                    

                    //Artec
                    unDatosDB.UsuarioBD = "";
                    unDatosDB.PasswordBD = "";
                    unDatosDB.SSPI = ServicioSecurizacion.Encriptar("Integrated Security=SSPI;");
                    ListaDatosBD.Add(unDatosDB);

                    //Backup    
                    unDatosDB2.UsuarioBD = "";
                    unDatosDB2.PasswordBD = "";
                    unDatosDB2.SSPI = ServicioSecurizacion.Encriptar("Integrated Security=SSPI;");
                    ListaDatosBD.Add(unDatosDB2);
                }
                else
                {
                    requiredFieldValidator2.IsEmptyStringValid = false;
                    requiredFieldValidator3.IsEmptyStringValid = false;
                    //Artec
                    unDatosDB.UsuarioBD = ServicioSecurizacion.Encriptar("user Id=" + txtUsuario.Text + ";");
                    unDatosDB.PasswordBD = ServicioSecurizacion.Encriptar("Password=" + txtPass.Text + ";");
                    unDatosDB.SSPI = "";
                    ListaDatosBD.Add(unDatosDB);

                    //Backup
                    unDatosDB2.UsuarioBD = ServicioSecurizacion.Encriptar("user Id=" + txtUsuario.Text + ";");
                    unDatosDB2.PasswordBD = ServicioSecurizacion.Encriptar("Password=" + txtPass.Text + ";");
                    unDatosDB2.SSPI = "";
                    ListaDatosBD.Add(unDatosDB2);
                }

                if (!validador.Validate())
                    return;

                var Resultado = ServicioSerializadorXML.Serializar(ListaDatosBD);

                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "DatosBD.xml"))
                {
                    sw.Write(ServicioSerializadorXML.StreamAString(Resultado));
                    sw.Close();
                }
                MessageBox.Show("Archivo de conexión a Base de datos creado correctamente");
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es.Message);
            }
           
        }


        private void cboxSSPI_CheckValueChanged(object sender, EventArgs e)
        {
            if (cboxSSPI.Checked)
            {
                txtUsuario.Enabled = false;
                txtPass.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPass.Enabled = true;
            }
        }



       
    }
}