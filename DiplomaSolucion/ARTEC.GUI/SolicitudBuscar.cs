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
using ARTEC.BLL.Servicios;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.GUI
{
    public partial class SolicitudBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static SolicitudBuscar _unSolicitudBuscarInst;
        List<Solicitud> unasSolicitudes = new List<Solicitud>();
        List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
        List<Prioridad> unasPrioridades = new List<Prioridad>();
        List<Usuario> unosUsuarios = new List<Usuario>();

        public SolicitudBuscar()
        {
            InitializeComponent();
            
            //Carga de Tags

            Dictionary<string, string[]> dicFrmSolicitudBuscar = new Dictionary<string, string[]>();
            string[] PerFrmSolicitudBuscar = { "Solicitud Buscar" };
            dicFrmSolicitudBuscar.Add("Permisos", PerFrmSolicitudBuscar);
            string[] IdiomaFrmSolicitudBuscar = { "Buscar Solicitudes" };
            dicFrmSolicitudBuscar.Add("Idioma", IdiomaFrmSolicitudBuscar);
            this.Tag = dicFrmSolicitudBuscar;

            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Dependencia" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;

            Dictionary<string, string[]> diclabelX6 = new Dictionary<string, string[]>();
            string[] IdiomalabelX6 = { "Finalización" };
            diclabelX6.Add("Idioma", IdiomalabelX6);
            this.labelX6.Tag = diclabelX6;

            Dictionary<string, string[]> diclabelX5 = new Dictionary<string, string[]>();
            string[] IdiomalabelX5 = { "Creación" };
            diclabelX5.Add("Idioma", IdiomalabelX5);
            this.labelX5.Tag = diclabelX5;

            Dictionary<string, string[]> diclblNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolicitud = { "Solicitud" };
            diclblNroSolicitud.Add("Idioma", IdiomalblNroSolicitud);
            this.lblNroSolicitud.Tag = diclblNroSolicitud;

            Dictionary<string, string[]> diclabelX8 = new Dictionary<string, string[]>();
            string[] IdiomalabelX8 = { "Estado" };
            diclabelX8.Add("Idioma", IdiomalabelX8);
            this.labelX8.Tag = diclabelX8;

            Dictionary<string, string[]> diclabelX10 = new Dictionary<string, string[]>();
            string[] IdiomalabelX10 = { "Asignado a" };
            diclabelX10.Add("Idioma", IdiomalabelX10);
            this.labelX10.Tag = diclabelX10;

            Dictionary<string, string[]> diclabelX9 = new Dictionary<string, string[]>();
            string[] IdiomalabelX9 = { "Prioridad" };
            diclabelX9.Add("Idioma", IdiomalabelX9);
            this.labelX9.Tag = diclabelX9;

            Dictionary<string, string[]> diclabelX3 = new Dictionary<string, string[]>();
            string[] IdiomalabelX3 = { "Bien" };
            diclabelX3.Add("Idioma", IdiomalabelX3);
            this.labelX3.Tag = diclabelX3;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> dictxtResBusqueda = new Dictionary<string, string[]>();
            string[] IdiomatxtResBusqueda = { "No hay resultados" };
            dictxtResBusqueda.Add("Idioma", IdiomatxtResBusqueda);
            this.txtResBusqueda.Tag = dictxtResBusqueda;

            Dictionary<string, string[]> dicvld1NroSolic = new Dictionary<string, string[]>();
            string[] Idiomavld1NroSolic = { "Solo se aceptan números" };
            dicvld1NroSolic.Add("Idioma", Idiomavld1NroSolic);
            this.vld1NroSolic.Tag = dicvld1NroSolic;

            Dictionary<string, string[]> dictxtNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomatxtNroSolicitud = { "Solo se aceptan números" };
            dictxtNroSolicitud.Add("Idioma", IdiomatxtNroSolicitud);
            this.txtNroSolicitud.Tag = dictxtNroSolicitud;
            
            
        }

        public static SolicitudBuscar ObtenerInstancia()
        {
            if (_unSolicitudBuscarInst == null)
            {
                _unSolicitudBuscarInst = new SolicitudBuscar();
            }

            return _unSolicitudBuscarInst;
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!vldNroSolic.Validate())
                return;
            
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();
            txtResBusqueda.Visible = false;
            GrillaSolicitudBuscar.Visible = true;

            try
            {
                if (!string.IsNullOrEmpty(txtNroSolicitud.Text) | !string.IsNullOrEmpty(txtDep.Text) | !string.IsNullOrEmpty(txtBien.Text) | !string.IsNullOrEmpty(txtFechaFin.Text) | !string.IsNullOrEmpty(txtFechaFin2.Text) | !string.IsNullOrEmpty(txtFechaInicio.Text) | !string.IsNullOrEmpty(txtFechaInicio2.Text) | (int)cboEstadoSolicitud.SelectedValue >= 0 | (int)cboAsignado.SelectedValue >= 0 | (int)cboPrioridad.SelectedValue >= 0 && !txtNroSolicitud.Text.Contains("%") & !txtDep.Text.Contains("%") & !txtBien.Text.Contains("%") & !txtNroSolicitud.Text.Contains("_") & !txtDep.Text.Contains("_") & !txtBien.Text.Contains("_"))
                {
                    if (!string.IsNullOrEmpty(txtNroSolicitud.Text))
                    {
                        unasSolicitudes = ManagerSolicitud.SolicitudBuscarConCanceladas(Int32.Parse(txtNroSolicitud.Text));
                    }
                    else
                    {
                        unasSolicitudes = ManagerSolicitud.SolicitudBuscarConCanceladas(txtDep.Text, (int?)cboEstadoSolicitud.SelectedValue, txtBien.Text, (int?)cboPrioridad.SelectedValue, (int?)cboAsignado.SelectedValue, (DateTime?)txtFechaInicio.Value, (DateTime?)txtFechaInicio2.Value, (DateTime?)txtFechaFin.Value, (DateTime?)txtFechaFin2.Value);
                    }
                    GrillaSolicitudBuscar.DataSource = null;
                    GrillaSolicitudBuscar.DataSource = unasSolicitudes;
                    FormatearGrillaSolicitudBuscar();
                    if (unasSolicitudes.Count == 0)
                    {
                        GrillaSolicitudBuscar.Visible = false;
                        txtResBusqueda.Visible = true;
                    }
                        
                }
                else
                {
                    GrillaSolicitudBuscar.DataSource = null;
                    GrillaSolicitudBuscar.Visible = false;
                    txtResBusqueda.Visible = true;
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnBuscar_Click");
                MessageBox.Show("Error en la búsqueda, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }

            
        }


        private void FormatearGrillaSolicitudBuscar()
        {
            //Formato GrillaSolicitudBuscar
            GrillaSolicitudBuscar.Columns["IdSolicitud"].HeaderText = "Solicitud";
            GrillaSolicitudBuscar.Columns["laDependencia"].HeaderText = "Dependencia";
            GrillaSolicitudBuscar.Columns["FechaInicio"].HeaderText = "Creación";
            GrillaSolicitudBuscar.Columns["FechaFin"].HeaderText = "Finalización";
            GrillaSolicitudBuscar.Columns["UnaPrioridad"].HeaderText = "Prioridad";
            GrillaSolicitudBuscar.Columns["UnEstado"].HeaderText = "Estado";
            GrillaSolicitudBuscar.Columns["AgenteResp"].HeaderText = "Responsable";
            GrillaSolicitudBuscar.Columns["DVH"].Visible = false;
        }

        private void txtNroSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }



        private void GrillaSolicitudBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                
                //MessageBox.Show(GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value.ToString());

                frmSolicitudModificar unfrmSolicitudModificar = frmSolicitudModificar.ObtenerInstancia((Solicitud)unasSolicitudes.Where(x => x.IdSolicitud == (int)GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                unfrmSolicitudModificar.Show();
                unfrmSolicitudModificar.Focus();
                unfrmSolicitudModificar.WindowState = FormWindowState.Normal;
            }
        }



        private void SolicitudBuscar_Load(object sender, EventArgs e)
        {
            try
            {

                //Permisos Formulario
                if (this.Tag != null && this.Tag.GetType() == typeof(Dictionary<string, string[]>) && (this.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                {
                    this.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((this.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                }

                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                ///Traer Estados Solicitud
                BLLEstadoSolicitud ManagerEstadoSolicitud = new BLLEstadoSolicitud();
                unosEstadoSolicitud = ManagerEstadoSolicitud.EstadoSolicitudTraerTodos();
                cboEstadoSolicitud.DataSource = null;
                unosEstadoSolicitud.Insert(0, new EstadoSolicitud(-1, ""));
                cboEstadoSolicitud.DataSource = unosEstadoSolicitud;
                cboEstadoSolicitud.DisplayMember = "DescripEstadoSolic";
                cboEstadoSolicitud.ValueMember = "IdEstadoSolicitud";

                ///Traer Prioridad
                BLLPrioridad ManagerPrioridad = new BLLPrioridad();
                unasPrioridades = ManagerPrioridad.PrioridadTraerTodos();
                cboPrioridad.DataSource = null;
                unasPrioridades.Insert(0, new Prioridad(-1, ""));
                cboPrioridad.DataSource = unasPrioridades;
                cboPrioridad.DisplayMember = "DescripPrioridad";
                cboPrioridad.ValueMember = "IdPrioridad";

                //Traer UsuariosSistema
                BLLUsuario ManagerUsuario = new BLLUsuario();
                unosUsuarios = ManagerUsuario.UsuarioTraerTodos();
                cboAsignado.DataSource = null;
                unosUsuarios.Insert(0, new Usuario(-1, "", ""));
                cboAsignado.DataSource = unosUsuarios;
                cboAsignado.DisplayMember = "NombreUsuario";
                cboAsignado.ValueMember = "IdUsuario";
            }
            catch (Exception es1)
            {
                string IdError = ServicioLog.CrearLog(es1, "SolicitudBuscar_Load");
                MessageBox.Show("Error al cargar la pantalla de búsqueda, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }

        private void txtDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        private void vld1NroSolic_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            int elOut;
            if (Int32.TryParse(txtNroSolicitud.Text, out elOut) | string.IsNullOrEmpty(txtNroSolicitud.Text))
                e.IsValid = true;
            else
                e.IsValid = false;

        }

        









    }
}