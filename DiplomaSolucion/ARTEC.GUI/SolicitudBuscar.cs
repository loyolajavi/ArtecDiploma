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

        private static SolicitudBuscar _unSolicitudBuscarInst;
        List<Solicitud> unasSolicitudes = new List<Solicitud>();
        List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
        List<Prioridad> unasPrioridades = new List<Prioridad>();
        List<Usuario> unosUsuarios = new List<Usuario>();

        public SolicitudBuscar()
        {
            InitializeComponent();
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
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();

            if (!string.IsNullOrEmpty(txtNroSolicitud.Text) | !string.IsNullOrEmpty(txtDep.Text) | !string.IsNullOrEmpty(txtBien.Text) | !string.IsNullOrEmpty(txtFechaFin.Text) | !string.IsNullOrEmpty(txtFechaInicio.Text) | (int)cboEstadoSolicitud.SelectedValue >= 0 | (int)cboAsignado.SelectedValue >= 0 | (int)cboPrioridad.SelectedValue >= 0)
            {
                if (!string.IsNullOrEmpty(txtNroSolicitud.Text))
                {
                    unasSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
                }
                else
                {
                    unasSolicitudes = ManagerSolicitud.SolicitudBuscar(txtDep.Text, cboEstadoSolicitud.SelectedItem.ToString(), txtBien.Text, cboPrioridad.SelectedItem.ToString(), cboAsignado.SelectedItem.ToString());
                }
                GrillaSolicitudBuscar.DataSource = null;
                GrillaSolicitudBuscar.DataSource = unasSolicitudes;
                GrillaSolicitudBuscar.Columns["Asignado"].Visible = true;
            }
            else
            {
                GrillaSolicitudBuscar.DataSource = null;
            }
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

                frmSolicitudModificar unfrmSolicitudModificar = new frmSolicitudModificar((Solicitud)unasSolicitudes.Where(x => x.IdSolicitud == (int)GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                unfrmSolicitudModificar.Show();
            }
        }



        private void SolicitudBuscar_Load(object sender, EventArgs e)
        {
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

        private void txtDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }








    }
}