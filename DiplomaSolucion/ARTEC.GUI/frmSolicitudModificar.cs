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
    public partial class frmSolicitudModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        int unNroSolicitud;
        public frmSolicitudModificar(int NroSolic)
        {
            InitializeComponent();
            unNroSolicitud = NroSolic;
        }

        private void frmSolicitudModificar_Load(object sender, EventArgs e)
        {
            List<Solicitud> unaSolicitud = new List<Solicitud>();
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();

            unaSolicitud = ManagerSolicitud.SolicitudBuscar(unNroSolicitud);
        }


        
    }
}