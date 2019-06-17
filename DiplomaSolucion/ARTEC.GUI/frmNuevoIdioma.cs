using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class frmNuevoIdioma : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmNuevoIdioma()
        {
            InitializeComponent();
        }

        private void frmNuevoIdioma_Load(object sender, EventArgs e)
        {
            GrillaTextos.DataSource = null;
            GrillaTextos.DataSource = ENTIDADES.Servicios.Idioma._EtiquetasCompartidas;
            GrillaTextos.Columns["IdIdioma"].Visible = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<ENTIDADES.Servicios.Idioma> unosIdiomas;

            try
            {
                if (ENTIDADES.Servicios.Idioma._EtiquetasCompartidas.Any(X => string.IsNullOrEmpty(X.NuevoTexto)))
                {
                    MessageBox.Show("Deben completarse todas las traducciones");
                    return;
                }

                unosIdiomas = ARTEC.BLL.Servicios.BLLServicioIdioma.IdiomaTraerTodos();

                if (unosIdiomas.Any(x => x.NombreIdioma.ToLowerInvariant() == txtNuevoIdioma.Text.ToLowerInvariant()))
                {
                    MessageBox.Show("El Idioma ingresado ya existe");
                    return;
                }

                ARTEC.BLL.Servicios.BLLServicioIdioma.CrearNuevoIdioma(txtNuevoIdioma.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception es)
            {
                string IdError = ARTEC.FRAMEWORK.Servicios.ServicioLog.CrearLog(es, "btnCrear_Click - frmNuevoIdioma");
                MessageBox.Show(ARTEC.BLL.Servicios.BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear el Idioma, por favor informe del error Nro ").Texto + IdError + ARTEC.BLL.Servicios.BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
           
        }

    }
}