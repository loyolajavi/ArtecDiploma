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

            Dictionary<string, string[]> dicfrmBitacora = new Dictionary<string, string[]>();
            string[] IdiomafrmBitacora = { "Bitacora" };
            dicfrmBitacora.Add("Idioma", IdiomafrmBitacora);
            this.Tag = dicfrmBitacora;

            Dictionary<string, string[]> diclblFechaInicio = new Dictionary<string, string[]>();
            string[] IdiomalblFechaInicio = { "Fecha Inicio" };
            diclblFechaInicio.Add("Idioma", IdiomalblFechaInicio);
            this.lblFechaInicio.Tag = diclblFechaInicio;

            Dictionary<string, string[]> diclblFechaFin = new Dictionary<string, string[]>();
            string[] IdiomalblFechaFin = { "Fecha Fin" };
            diclblFechaFin.Add("Idioma", IdiomalblFechaFin);
            this.lblFechaFin.Tag = diclblFechaFin;

            Dictionary<string, string[]> diclblTipoLog = new Dictionary<string, string[]>();
            string[] IdiomalblTipoLog = { "Tipo Log" };
            diclblTipoLog.Add("Idioma", IdiomalblTipoLog);
            this.lblTipoLog.Tag = diclblTipoLog;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                //Idioma
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                List<string> TiposLogs = new List<string>();
                TiposLogs.Add("Evento");
                TiposLogs.Add("Error");
                cboTipoLog.DataSource = null;
                cboTipoLog.DataSource = TiposLogs;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmBitacora_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al cargar la bitácora, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al buscar en la bitácora, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
        }

        private void frmBitacora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }




    }
}