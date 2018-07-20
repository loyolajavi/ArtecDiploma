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
using ARTEC.FRAMEWORK.Servicios;

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
                string IdError = ServicioLog.CrearLog(es, "frmBitacora_Load");
                MessageBox.Show("Ocurrio un error al cargar la bitácora, por favor informe del error Nro " + IdError + " del Log de Eventos");
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
                string IdError = ServicioLog.CrearLog(es, "btnBuscar_Click - Bitacora");
                MessageBox.Show("Ocurrio un error al buscar en la bitácora, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }




    }
}