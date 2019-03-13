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

                unDatosDB.DataSourceBD = ServicioSecurizacion.Encriptar("Data Source=" + txtServidor.Text + ";");
                unDatosDB.InitialCatalogBD = ServicioSecurizacion.Encriptar("Initial Catalog=" + txtBase.Text + ";");
                unDatosDB.UsuarioBD = ServicioSecurizacion.Encriptar("user Id=" + txtUsuario.Text + ";");
                unDatosDB.PasswordBD = ServicioSecurizacion.Encriptar("Password=" + txtPass.Text + ";");
                ListaDatosBD.Add(unDatosDB);

                unDatosDB2.DataSourceBD = ServicioSecurizacion.Encriptar("Data Source=" + txtServidor.Text + ";");
                unDatosDB2.InitialCatalogBD = ServicioSecurizacion.Encriptar("Initial Catalog=master;");
                unDatosDB2.UsuarioBD = ServicioSecurizacion.Encriptar("user Id=" + txtUsuario.Text + ";");
                unDatosDB2.PasswordBD = ServicioSecurizacion.Encriptar("Password=" + txtPass.Text + ";");
                ListaDatosBD.Add(unDatosDB2);

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



       
    }
}