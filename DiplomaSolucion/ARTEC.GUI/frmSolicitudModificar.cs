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

        Solicitud unaSolicitud;
        List<Agente> unosAgentesResp;
        List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
        List<Prioridad> unasPrioridades = new List<Prioridad>();
        List<Usuario> unosUsuarios = new List<Usuario>();


        public frmSolicitudModificar(Solicitud unaSolic)
        {
            InitializeComponent();
            unaSolicitud = unaSolic;
        }

        private void frmSolicitudModificar_Load(object sender, EventArgs e)
        {
            
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();
            BLLDependencia ManagerDependenciaAg = new BLLDependencia();

            txtDependencia.Text = unaSolicitud.laDependencia.NombreDependencia;
            unosAgentesResp = new List<Agente>();
            unosAgentesResp = ManagerDependenciaAg.TraerAgentesResp(unaSolicitud.laDependencia.IdDependencia);
            cboAgenteResp.DataSource = null;
            cboAgenteResp.DataSource = unosAgentesResp;
            cboAgenteResp.DisplayMember = "ApellidoAgente";
            cboAgenteResp.ValueMember = "IdAgente";
            //cboAgenteResp.SelectedItem = unaSolicitud; //FALTA APUNTAR AL AGENTE RESPONSABLE DE LA SOLICITUD
            txtFechaInicio.Value = unaSolicitud.FechaInicio;
            txtFechaFin.Value = unaSolicitud.FechaFin;

            ///Traer Estados Solicitud
            BLLEstadoSolicitud ManagerEstadoSolicitud = new BLLEstadoSolicitud();
            unosEstadoSolicitud = ManagerEstadoSolicitud.EstadoSolicitudTraerTodos();
            cboEstadoSolicitud.DataSource = null;
            cboEstadoSolicitud.DataSource = unosEstadoSolicitud;
            cboEstadoSolicitud.DisplayMember = "DescripEstadoSolic";
            cboEstadoSolicitud.ValueMember = "IdEstadoSolicitud";
            cboEstadoSolicitud.SelectedItem = unaSolicitud.UnEstado;

            ///Traer Prioridad
            BLLPrioridad ManagerPrioridad = new BLLPrioridad();
            unasPrioridades = ManagerPrioridad.PrioridadTraerTodos();
            cboPrioridad.DataSource = null;
            cboPrioridad.DataSource = unasPrioridades;
            cboPrioridad.DisplayMember = "DescripPrioridad";
            cboPrioridad.ValueMember = "IdPrioridad";
            cboPrioridad.SelectedItem = unaSolicitud.UnaPrioridad;

            //Traer UsuariosSistema
            BLLUsuario ManagerUsuario = new BLLUsuario();
            unosUsuarios = ManagerUsuario.UsuarioTraerTodos();
            cboAsignado.DataSource = null;
            cboAsignado.DataSource = unosUsuarios;
            cboAsignado.DisplayMember = "NombreUsuario";
            cboAsignado.ValueMember = "IdUsuario";
            cboAsignado.SelectedItem = unaSolicitud.Asignado;

            grillaDetalles.DataSource = null;
            unaSolicitud.unosDetallesSolicitud = ManagerSolicitud.SolicitudTraerDetalles(unaSolicitud).unosDetallesSolicitud.ToList();
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
        }


        
    }
}