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
        List<EstadoSolicDetalle> unosEstadoSolDetalles = new List<EstadoSolicDetalle>();
        List<Prioridad> unasPrioridades = new List<Prioridad>();
        List<Usuario> unosUsuarios = new List<Usuario>();
        int AuxTipoCategoria = 1;
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        TipoBien unTipoBienAux = new TipoBien();
        BLLTipoBien managerTipoBienAux = new BLLTipoBien();


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
            cboAgenteResp.SelectedValue = unaSolicitud.AgenteResp.IdAgente; //FALTA APUNTAR AL AGENTE RESPONSABLE DE LA SOLICITUD
            txtFechaInicio.Value = unaSolicitud.FechaInicio;
            txtFechaFin.Value = unaSolicitud.FechaFin;

            ///Para poder seleccionar Hard o Soft
            BLLTipoBien ManagerTipoBien = new BLLTipoBien();
            unosTipoBien = ManagerTipoBien.TraerTodos();
            cboTipoBien.DataSource = null;
            cboTipoBien.DataSource = unosTipoBien;
            cboTipoBien.DisplayMember = "DescripTipoBien";
            cboTipoBien.ValueMember = "IdTipoBien";

            ///Traer Estados Solicitud
            BLLEstadoSolicitud ManagerEstadoSolicitud = new BLLEstadoSolicitud();
            unosEstadoSolicitud = ManagerEstadoSolicitud.EstadoSolicitudTraerTodos();
            cboEstadoSolicitud.DataSource = null;
            cboEstadoSolicitud.DataSource = unosEstadoSolicitud;
            cboEstadoSolicitud.DisplayMember = "DescripEstadoSolic";
            cboEstadoSolicitud.ValueMember = "IdEstadoSolicitud";
            cboEstadoSolicitud.SelectedValue = unaSolicitud.UnEstado.IdEstadoSolicitud;

            //Traer EstadosDetalleSolicitud
            BLLEstadoSolicDetalle ManagerEstadoSolDetalle = new BLLEstadoSolicDetalle();
            unosEstadoSolDetalles = ManagerEstadoSolDetalle.EstadoSolDetallesTraerTodos();
            cboEstadoSolDetalle.DataSource = null;
            cboEstadoSolDetalle.DataSource = unosEstadoSolDetalles;
            cboEstadoSolDetalle.DisplayMember = "DescripEstadoSolicDetalle";
            cboEstadoSolDetalle.ValueMember = "IdEstadoSolicDetalle";

            ///Traer Prioridad
            BLLPrioridad ManagerPrioridad = new BLLPrioridad();
            unasPrioridades = ManagerPrioridad.PrioridadTraerTodos();
            cboPrioridad.DataSource = null;
            cboPrioridad.DataSource = unasPrioridades;
            cboPrioridad.DisplayMember = "DescripPrioridad";
            cboPrioridad.ValueMember = "IdPrioridad";
            cboPrioridad.SelectedValue = unaSolicitud.UnaPrioridad.IdPrioridad;

            //Traer UsuariosSistema
            BLLUsuario ManagerUsuario = new BLLUsuario();
            unosUsuarios = ManagerUsuario.UsuarioTraerTodos();
            cboAsignado.DataSource = null;
            cboAsignado.DataSource = unosUsuarios;
            cboAsignado.DisplayMember = "NombreUsuario";
            cboAsignado.ValueMember = "IdUsuario";
            cboAsignado.SelectedValue = unaSolicitud.Asignado.IdUsuario;

            //Agrega los detalles
            grillaDetalles.DataSource = null;
            unaSolicitud.unosDetallesSolicitud = ManagerSolicitud.SolicitudTraerDetalles(unaSolicitud).unosDetallesSolicitud.ToList();
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            grillaDetalles.Columns[1].Visible = false;

            //Agrega el conteo de cotizaciones por detalle
            BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
            DataGridViewTextBoxColumn ColumnaCotizacionConteo = new DataGridViewTextBoxColumn();
            ColumnaCotizacionConteo.Name = "txtCotizConteo";
            ColumnaCotizacionConteo.HeaderText = "txtCotizConteo";
            grillaDetalles.Columns.Add(ColumnaCotizacionConteo);
            foreach (DataGridViewRow item in grillaDetalles.Rows)
            {
                item.Cells["txtCotizConteo"].Value = unaSolicitud.unosDetallesSolicitud[item.Index].unasCotizaciones.Count().ToString();
            }

            //Agrega boton para la gestión de cotizaciones
            var botonCotizar = new DataGridViewButtonColumn();
            botonCotizar.Name = "btnDinCotizar";
            botonCotizar.HeaderText = "Cotizar"; //ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
            botonCotizar.Text = "Cotizar";//ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
            botonCotizar.UseColumnTextForButtonValue = true;
            grillaDetalles.Columns.Add(botonCotizar);

            //Agrega boton para Borrar el detalle
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaDetalles.Columns.Add(deleteButton);

            //Coloca el tipo Bien segun el detalle seleccionado (el primero en este caso)
            unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unaSolicitud.unosDetallesSolicitud[0].unaCategoria.IdCategoria);
            if (unTipoBienAux.IdTipoBien == 1)
            {
                //HARDWARE
                gboxAsociados.Enabled = false;
                txtCantBien.ReadOnly = false;
                lblCantidad.Enabled = true;
                AuxTipoCategoria = 1;//HARDWARE
                cboTipoBien.SelectedValue = 1;//HARDWARE
                txtAgente.Clear();
                //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
                grillaAgentesAsociados.DataSource = null;
            }
            else
            {
                gboxAsociados.Enabled = true;
                txtCantBien.ReadOnly = true;
                lblCantidad.Enabled = false;
                AuxTipoCategoria = 2;//SOFTWARE
                cboTipoBien.SelectedValue = 2;//SOFTWARE
                txtAgente.Clear();
                //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
                grillaAgentesAsociados.DataSource = null;
                grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud[0].unosAgentes;
                //No mostrar columnas que no necesito de los agentes asociados
                grillaAgentesAsociados.Columns[0].Visible = false;
                grillaAgentesAsociados.Columns[3].Visible = false;
                grillaAgentesAsociados.Columns[4].Visible = false;
            }
            cboEstadoSolDetalle.SelectedValue = unaSolicitud.unosDetallesSolicitud[0].unEstado.IdEstadoSolicDetalle;

        }


        //*************FALTA ELIMINAR EL DETALLE DE LA BD SI SE CONFIRMA EL CAMBIO
        private void grillaDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0)
            {
                return;
            }

            //Si hizo click en Borrar *************************BORRAR EL DETALLE DE LA BD; PARA QUE EL e.index NO QUEDE COLGADO 
            if (e.ColumnIndex == grillaDetalles.Columns["btnDinBorrar"].Index)
            {
                //elimino de la memoria el detalle
                unaSolicitud.unosDetallesSolicitud.RemoveAt(e.RowIndex);
                //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                grillaDetalles.Columns.RemoveAt(e.ColumnIndex);
                grillaDetalles.Columns.Remove("txtCotizConteo");
                grillaDetalles.Columns.Remove("btnDinCotizar");
                //Conteo de detalles
                int NroAux = 0;
                foreach (SolicDetalle Det2 in unaSolicitud.unosDetallesSolicitud)
                {
                    Det2.IdSolicitudDetalle = NroAux + 1;
                }
                //Regenero la grilla
                grillaDetalles.DataSource = null;
                grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                grillaDetalles.Columns[1].Visible = false;
                //Vuelve a agregar el conteo de cotizaciones por detalle
                BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
                DataGridViewTextBoxColumn ColumnaCotizacionConteo = new DataGridViewTextBoxColumn();
                ColumnaCotizacionConteo.Name = "txtCotizConteo";
                ColumnaCotizacionConteo.HeaderText = "txtCotizConteo";
                grillaDetalles.Columns.Add(ColumnaCotizacionConteo);
                foreach (DataGridViewRow item in grillaDetalles.Rows)
                {
                    item.Cells["txtCotizConteo"].Value = unaSolicitud.unosDetallesSolicitud[item.Index].unasCotizaciones.Count().ToString();
                }

                //Vuelve a agregar boton para la gestión de cotizaciones
                var botonCotizar = new DataGridViewButtonColumn();
                botonCotizar.Name = "btnDinCotizar";
                botonCotizar.HeaderText = "Cotizar"; //ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
                botonCotizar.Text = "Cotizar";//ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
                botonCotizar.UseColumnTextForButtonValue = true;
                grillaDetalles.Columns.Add(botonCotizar);

                //Vuelve a agregar el botón de borrar al final
                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "btnDinBorrar";
                deleteButton.HeaderText = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                deleteButton.Text = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                deleteButton.UseColumnTextForButtonValue = true;
                grillaDetalles.Columns.Add(deleteButton);
            }
            else //si hizo click en cualquier otro lado, muestra los datos del detalle en el "formulario"
            {
                //Para obtener el detalle en donde se hizo click
                //MessageBox.Show(grillaDetalles.Rows.SharedRow(e.RowIndex).ToString());
                int DetalleSeleccionado = e.RowIndex + 1;
                SolicDetalle unDetSolic = new SolicDetalle();

                unDetSolic = unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);

                txtBien.Text = unDetSolic.unaCategoria.DescripCategoria;
                txtCantBien.Text = unDetSolic.Cantidad.ToString();

                cboEstadoSolDetalle.SelectedValue = unDetSolic.unEstado.IdEstadoSolicDetalle;

                //Traer TIPOBIEN por IdCategoria y ponerlo en el cbobox para que quede ese seleccionado
                //unaCat = unDetSolic.unaCategoria;VER**********************************
                unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);

                if (unTipoBienAux.IdTipoBien == 1)
                {
                    //HARDWARE
                    gboxAsociados.Enabled = false;
                    txtCantBien.ReadOnly = false;
                    lblCantidad.Enabled = true;
                    AuxTipoCategoria = 1;//HARDWARE
                    cboTipoBien.SelectedValue = 1;//HARDWARE
                    txtAgente.Clear();
                    //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
                    grillaAgentesAsociados.DataSource = null;
                }
                else
                {
                    gboxAsociados.Enabled = true;
                    txtCantBien.ReadOnly = true;
                    lblCantidad.Enabled = false;
                    AuxTipoCategoria = 2;//SOFTWARE
                    cboTipoBien.SelectedValue = 2;//SOFTWARE
                    txtAgente.Clear();
                    //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
                    grillaAgentesAsociados.DataSource = null;
                    grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes;
                    //No mostrar columnas que no necesito de los agentes asociados
                    grillaAgentesAsociados.Columns[0].Visible = false;
                    grillaAgentesAsociados.Columns[3].Visible = false;
                    grillaAgentesAsociados.Columns[4].Visible = false;
                }
                if (e.ColumnIndex == grillaDetalles.Columns["btnDinCotizar"].Index)
                {
                    frmCotizaciones UnFrmCotizaciones = new frmCotizaciones(unaSolicitud.unosDetallesSolicitud[e.RowIndex].unasCotizaciones);
                    UnFrmCotizaciones.Show();
                }
            }
        }



    }
}