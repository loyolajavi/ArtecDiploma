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
    public partial class SolicitudBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SolicitudBuscar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            List<Solicitud> unasSolicitudes = new List<Solicitud>();

            BLLSolicitud ManagerSolicitud = new BLLSolicitud();

            unasSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
            GrillaSolicitudBuscar.DataSource = null;
            GrillaSolicitudBuscar.DataSource = unasSolicitudes;
            GrillaSolicitudBuscar.Columns["Asignado"].Visible = false;
            
        }
    }
}