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
using System.Diagnostics;

namespace ARTEC.GUI
{
    public partial class SolicitudBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {


        List<Solicitud> unasSolicitudes = new List<Solicitud>();

        public SolicitudBuscar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            

            BLLSolicitud ManagerSolicitud = new BLLSolicitud();

            unasSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
            GrillaSolicitudBuscar.DataSource = null;
            GrillaSolicitudBuscar.DataSource = unasSolicitudes;
            GrillaSolicitudBuscar.Columns["Asignado"].Visible = true;




        }

        private void GrillaSolicitudBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                
                //MessageBox.Show(GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value.ToString());

                frmSolicitudModificar unfrmSolicitudModificar = new frmSolicitudModificar((Solicitud)unasSolicitudes.Where(x => x.IdSolicitud == (int)GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                unfrmSolicitudModificar.Show();
            }
        }
    }
}