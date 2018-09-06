using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL;
using ARTEC.ENTIDADES;
using System.Linq;
using ARTEC.BLL.Servicios;


namespace ARTEC.GUI
{
    public partial class frmAsignacionBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmAsignacionBuscar _unFrmAsignacionBuscar;
        BLLAsignacion ManagerAsignacion = new BLLAsignacion();
        List<Asignacion> unasAsignaciones = new List<Asignacion>();
        List<GrillaAsigBuscarCU> ListaGrilla = new List<GrillaAsigBuscarCU>();

        public frmAsignacionBuscar()
        {
            InitializeComponent();
        }

        public static frmAsignacionBuscar ObtenerInstancia()
        {
            if (_unFrmAsignacionBuscar == null)
            {
                _unFrmAsignacionBuscar = new frmAsignacionBuscar();
            }

            return _unFrmAsignacionBuscar;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //txtResBusqueda.Visible = false;
            //GrillaRendicionBuscar.Visible = true;
            flowAsignaciones.Controls.Clear();
            ListaGrilla.Clear();

            if (!vldFrmAsignacionBuscar.Validate())
                return;
            
            try
            {
                if (!string.IsNullOrEmpty(txtAsignacion.Text) | !string.IsNullOrEmpty(txtDep.Text) | !string.IsNullOrEmpty(txtNroSolicitud.Text) | !string.IsNullOrEmpty(txtFechaDesde.Text) | !string.IsNullOrEmpty(txtFechaHasta.Text) && !txtAsignacion.Text.Contains("%") & !txtDep.Text.Contains("%") & !txtNroSolicitud.Text.Contains("%") & !txtAsignacion.Text.Contains("_") & !txtDep.Text.Contains("_") & !txtNroSolicitud.Text.Contains("_"))
                {
                    unasAsignaciones = ManagerAsignacion.AsignacionBuscar(txtAsignacion.Text, txtDep.Text, txtNroSolicitud.Text, (DateTime?)txtFechaDesde.Value, (DateTime?)txtFechaHasta.Value);

                    foreach (Asignacion unaAsig in unasAsignaciones)
                    {
                        GrillaAsigBuscarCU GrillaAux = new GrillaAsigBuscarCU();
                        GrillaAux.IdAsignacion = unaAsig.IdAsignacion.ToString();
                        GrillaAux.NombreDependencia = unaAsig.unaDependencia.NombreDependencia;
                        GrillaAux.IdSolicitud = unaAsig.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud.ToString();
                        GrillaAux.laFecha = unaAsig.Fecha.ToString();
                        GrillaAux.unaGrilla.DataSource = null;
                        GrillaAux.unaGrilla.DataSource = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsig.IdAsignacion);
                        GrillaAux.unaGrilla.Columns["IdInventario"].Visible = false;
                        GrillaAux.unaGrilla.Columns["IdBienEspecif"].Visible = false;
                        GrillaAux.unaGrilla.Columns["unEstado"].Visible = false;
                        GrillaAux.unaGrilla.Columns["PartidaDetalleAsoc"].Visible = false;
                        GrillaAux.unaGrilla.Columns["Costo"].Visible = false;
                        GrillaAux.unaGrilla.Columns["unaAdquisicion"].Visible = false;
                        GrillaAux.unaGrilla.Columns["unTipoBien"].Visible = false;
                        

                        ListaGrilla.Add(GrillaAux);
                    }

                    foreach (GrillaAsigBuscarCU gri in ListaGrilla)
                    {
                        flowAsignaciones.Controls.Add(gri);
                    }
                //    GrillaRendicionBuscar.DataSource = null;
                //    GrillaRendicionBuscar.DataSource = unasRendiciones;
                //    if (unasRendiciones.Count == 0)
                //    {
                //        GrillaRendicionBuscar.Visible = false;
                //        txtResBusqueda.Visible = true;
                //    }
                //    else
                //        FormatearGrillaRendicionBuscar();
                //}
                //else
                //{
                //    GrillaRendicionBuscar.DataSource = null;
                //    GrillaRendicionBuscar.Visible = false;
                //    txtResBusqueda.Visible = true;
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsignacionBuscar - btnBuscar_Click");
                MessageBox.Show("Error en la búsqueda, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void frmAsignacionBuscar_Load(object sender, EventArgs e)
        {
            txtFechaDesde.Text = DateTime.Today.AddDays(-31).ToString();
            txtFechaHasta.Text = DateTime.Today.ToString();

        }




    }
}