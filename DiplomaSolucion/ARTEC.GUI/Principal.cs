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
    public partial class Principal : DevComponents.DotNetBar.Metro.MetroForm
    {


        List<Idioma> unosIdiomas = new List<Idioma>();

        public Principal()
        {
            InitializeComponent();
        }

        private void metroToolbar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //Traigo todos los idiomas
            unosIdiomas = ServicioIdioma.IdiomaTraerTodos();
            

            //Obtengo el utilizado la última vez
            ServicioIdioma.unIdiomaActual = unosIdiomas.Find(x => x.IdiomaActual == true);

            //Traduzco con el IdiomaActual
            ServicioIdioma.Traducir(this.FindForm(), ServicioIdioma.unIdiomaActual.IdIdioma);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            CrearSolicitud frmCrearSolicitud = new CrearSolicitud();
            frmCrearSolicitud.Show();
        }
    }
}