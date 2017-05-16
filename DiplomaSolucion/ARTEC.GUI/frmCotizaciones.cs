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
using System.Linq;
using System.IO;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class frmCotizaciones : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<Cotizacion> unasCotizaciones;

        public frmCotizaciones(List<Cotizacion> unasCotiz)
        {
            InitializeComponent();
            unasCotizaciones = unasCotiz;
        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {
            grillaProveedor.DataSource = null;
            grillaProveedor.DataSource = unasCotizaciones;
        }



    }
}