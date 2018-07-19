using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmBitacora : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<Bitacora> unosLogs = new List<Bitacora>();
        BLLBitacora ManagerBitacora = new BLLBitacora();


        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> TiposLogs = new List<string>();
                TiposLogs.Add("Evento");
                TiposLogs.Add("Error");
                cboTipoLog.DataSource = null;
                cboTipoLog.DataSource = TiposLogs;
            }
            catch (Exception es)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                txtResBusqueda.Visible = false;
                GrillaBuscar.Visible = true;

                unosLogs = ManagerBitacora.BitacoraVerLogs(cboTipoLog.Text, (DateTime?)txtFechaInicio.Value, (DateTime?)txtFechaFin.Value);
                GrillaBuscar.DataSource = null;
                GrillaBuscar.DataSource = unosLogs;
                if (unosLogs.Count == 0)
                {
                    txtResBusqueda.Visible = true;
                    GrillaBuscar.Visible = false;
                }
                else
                {
                    txtResBusqueda.Visible = false;
                    GrillaBuscar.Visible = true;
                }

                    
            }
            catch (Exception es)
            {
                MessageBox.Show("Error2");
                throw;
            }
            
        }




    }
}