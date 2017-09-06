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
        //Estos son para cargar mas detalles
        SolicDetalle unDetSolic;
        List<Categoria> unasCategoriasHard;
        List<Categoria> unasCategoriasSoft;
        List<Agente> unosAgentesAsociados;
        Categoria unaCat;
        List<Agente> unosAgentes;
        Agente unAgen;
        //Estos son para cargar mas detallesFIN

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


            //Traigo categorias para dps filtrar por hard o soft
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategoriasHard = new List<Categoria>();
            unasCategoriasHard = ManagerCategoria.CategoriaTraerTodosHard();
            unasCategoriasSoft = new List<Categoria>();
            unasCategoriasSoft = ManagerCategoria.CategoriaTraerTodosSoft();

            unosAgentesAsociados = new List<Agente>();

        }


        //*************FALTA ELIMINAR EL DETALLE DE LA BD SI SE CONFIRMA EL CAMBIO
        private void grillaDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //Si hizo click en Borrar *************************BORRAR EL DETALLE DE LA BD; PARA QUE EL e.index NO QUEDE COLGADO 
            if (e.ColumnIndex == grillaDetalles.Columns["btnDinBorrar"].Index)
            {

                //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                grillaDetalles.Columns.RemoveAt(e.ColumnIndex);
                grillaDetalles.Columns.Remove("txtCotizConteo");
                grillaDetalles.Columns.Remove("btnDinCotizar");

                //elimino de la memoria el detalle
                unaSolicitud.unosDetallesSolicitud.RemoveAt(e.RowIndex);

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
                unDetSolic = new SolicDetalle();
                txtBien.ReadOnly = true;

                //VER:Al eliminar un detalle quedan mal enumerados

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
                //Además abre el frmCotizaciones
                if (e.ColumnIndex == grillaDetalles.Columns["btnDinCotizar"].Index)
                {
                    frmCotizaciones UnFrmCotizaciones = new frmCotizaciones(unaSolicitud.unosDetallesSolicitud[e.RowIndex].unasCotizaciones, unDetSolic);
                    UnFrmCotizaciones.EventoActualizarDetalles += new frmCotizaciones.DelegaActualizarSolicDetalles(ActualizarDetallesSolicitud);
                    UnFrmCotizaciones.Show();

                }
            }
        }

        public void ActualizarDetallesSolicitud(List<Cotizacion> unasCotiza)
        {
            //Actualizo las cotizaciones en el objeto instanciado en el frmSolicitudModificar
            //foreach (SolicDetalle det in unaSolicitud.unosDetallesSolicitud)
            //{
            //det[(unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle) - 1].unasCotizaciones = unasCotiza.Where(x => x.unDetalleAsociado.IdSolicitudDetalle == det.IdSolicitudDetalle).ToList();
            //}
            unaSolicitud.unosDetallesSolicitud[(unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle) - 1].unasCotizaciones = unasCotiza;


            //Actualiza el conteo de cotizaciones del detalle modificado en frmcotizaciones
            grillaDetalles.Rows[(unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle) - 1].Cells["txtCotizConteo"].Value = unaSolicitud.unosDetallesSolicitud[(unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle) - 1].unasCotizaciones.Count().ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (unaSolicitud.unosDetallesSolicitud.Where(x => x.unasCotizaciones.Count() >= 3).Count() == unaSolicitud.unosDetallesSolicitud.Count())
            {
                frmPartidaSolicitar unFrmPartidaSolicitar = frmPartidaSolicitar.ObtenerInstancia(unaSolicitud);
                unFrmPartidaSolicitar.Show();
            }
            else
            {
                MessageBox.Show("Revise que los detalles posean al menos 3 cotizaciones");
            }
        }

        private void btnBienAsignar_Click(object sender, EventArgs e)
        {

            Solicitud SolicAsignar = new Solicitud();
            SolicAsignar.AgenteResp = unaSolicitud.AgenteResp;
            SolicAsignar.Asignado = unaSolicitud.Asignado;
            SolicAsignar.FechaFin = unaSolicitud.FechaFin;
            SolicAsignar.FechaInicio = unaSolicitud.FechaInicio;
            SolicAsignar.IdSolicitud = unaSolicitud.IdSolicitud;
            SolicAsignar.laDependencia = unaSolicitud.laDependencia;
            SolicAsignar.UnaPrioridad = unaSolicitud.UnaPrioridad;
            SolicAsignar.unasNotas = unaSolicitud.unasNotas;
            SolicAsignar.UnEstado = unaSolicitud.UnEstado;

            foreach (var unDetSolic in unaSolicitud.unosDetallesSolicitud)
	        {
                //if (unDetSolic.unEstado.IdEstadoSolicDetalle == (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido)
                //{
                    SolicAsignar.unosDetallesSolicitud.Add(unDetSolic); 
                //}
	        }

            frmBienAsignar unFrmBienAsignar = new frmBienAsignar(SolicAsignar);
            unFrmBienAsignar.Show();
        }

        private void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            unDetSolic = null;
            txtBien.ReadOnly = false;
            gboxAsociados.Enabled = false;
            txtCantBien.ReadOnly = false;
            lblCantidad.Enabled = true;
            cboTipoBien.SelectedIndex = (int)Hardware.elTipoBien.Hardware-1;
            txtBien.Clear();
            AuxTipoCategoria = 1;
            txtCantBien.Clear();
            txtAgente.Clear();
            unAgen = null;
            grillaAgentesAsociados.DataSource = null;
            cboEstadoSolDetalle.SelectedIndex = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente-1;
            
        }


        /// <summary>
        /// Habilitar Controles según Hard/Soft
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboTipoBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Quita los msjs de validación
            validAgenteAsoc.ClearFailedValidations();

            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                gboxAsociados.Enabled = false;
                txtCantBien.ReadOnly = false;
                lblCantidad.Enabled = true;
                txtBien.Clear();
                AuxTipoCategoria = 1;
                txtCantBien.Clear();
                txtAgente.Clear();
                unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
                grillaAgentesAsociados.DataSource = null;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                gboxAsociados.Enabled = true;
                txtCantBien.ReadOnly = true;
                lblCantidad.Enabled = false;
                txtBien.Clear();
                txtCantBien.Clear();
                AuxTipoCategoria = 2;
            }
        }



        //Busqueda Dinamica BIENES(CATEGORIAS)
        private void txtBien_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBien.Text))
            {

                List<Categoria> resCat = new List<Categoria>();
                //Traigo las categorias de Hard
                if (AuxTipoCategoria == 1)
                {
                    resCat = (List<Categoria>)unasCategoriasHard.ToList();
                }
                //Traigo las categorias de Soft
                else
                {
                    resCat = (List<Categoria>)unasCategoriasSoft.ToList();
                }


                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtBien.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resCat = (List<Categoria>)(from cat in resCat
                                               where cat.DescripCategoria.ToLower().Contains(unaPalabra.ToLower())
                                               select cat).ToList();
                }

                if (resCat.Count > 0)
                {
                    if (resCat.Count == 1 && string.Equals(resCat.First().DescripCategoria, txtBien.Text))
                    {
                        cboBien.Visible = false;
                        cboBien.DroppedDown = false;
                        cboBien.DataSource = null;
                    }
                    else
                    {
                        cboBien.DataSource = null;
                        cboBien.DataSource = resCat;
                        cboBien.DisplayMember = "DescripCategoria";
                        cboBien.ValueMember = "IdCategoria";
                        cboBien.Visible = true;
                        cboBien.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboBien.Visible = false;
                    cboBien.DroppedDown = false;
                    cboBien.DataSource = null;
                }
            }
            else
            {
                cboBien.Visible = false;
                cboBien.DroppedDown = false;
                cboBien.DataSource = null;
            }
        }



        private void cboBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBien.Text))
            {
                if (cboBien.SelectedIndex > -1)
                {
                    ComboBox cbo2 = (ComboBox)sender;
                    unaCat = new Categoria();
                    unaCat = (Categoria)cbo2.SelectedItem;

                    txtBien.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    txtBien.SelectionStart = txtBien.Text.Length + 1;
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate();
                }
            }
        }



        //Busqueda Dinamica Agentes por Dependencia
        private void txtAgente_TextChanged(object sender, EventArgs e)
        {
            //if (ValidDep2.Validate())
            //{
                if (!string.IsNullOrWhiteSpace(txtAgente.Text) & unosAgentes != null)
                {

                    List<Agente> resAgente = new List<Agente>();
                    resAgente = (List<Agente>)unosAgentes.ToList();
                    List<string> Palabras = new List<string>();
                    Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtAgente.Text, ' ');

                    foreach (string unaPalabra in Palabras)
                    {
                        resAgente = (List<Agente>)(from cat in resAgente
                                                   where cat.ApellidoAgente.ToLower().Contains(unaPalabra.ToLower())
                                                   select cat).ToList();
                    }

                    if (resAgente.Count > 0)
                    {
                        if (resAgente.Count == 1 && string.Equals(resAgente.First().ApellidoAgente, txtAgente.Text))
                        {
                            cboAgentesAsociados.Visible = false;
                            cboAgentesAsociados.DroppedDown = false;
                            cboAgentesAsociados.DataSource = null;
                        }
                        else
                        {
                            cboAgentesAsociados.DataSource = null;
                            cboAgentesAsociados.DataSource = resAgente;
                            cboAgentesAsociados.DisplayMember = "ApellidoAgente";
                            cboAgentesAsociados.ValueMember = "IdAgente";
                            cboAgentesAsociados.Visible = true;
                            cboAgentesAsociados.DroppedDown = true;
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        cboAgentesAsociados.Visible = false;
                        cboAgentesAsociados.DroppedDown = false;
                        cboAgentesAsociados.DataSource = null;
                        //unAgen = null; // GUARDA
                    }
                }
                else
                {
                    cboAgentesAsociados.Visible = false;
                    cboAgentesAsociados.DroppedDown = false;
                    cboAgentesAsociados.DataSource = null;
                }
            //}

        }



        //Al seleccionar un AGENTE del combo, guarda el IdAgente, el apellido y cierra el combo
        private void cboAgentesAsociados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAgente.Text))
            {
                if (cboAgentesAsociados.SelectedIndex > -1)
                {
                    ComboBox cbo3 = (ComboBox)sender;
                    unAgen = new Agente();
                    unAgen = (Agente)cbo3.SelectedItem;

                    txtAgente.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    txtAgente.SelectionStart = txtAgente.Text.Length + 1;
                }
            }
        }



        //Asociar Agentes al software ingresado
        private void btnAsociarAgente_Click(object sender, EventArgs e)//VALIDAR QUE NO DEJE AGREGARDETALLE SI NO HAY UN AGENTE ASOCIADO
        {
                //if (validAgenteAsoc.Validate())
                //{
                    //int CantSuma = 0;
                    if (!string.IsNullOrWhiteSpace(txtCantBien.Text))
                    {
                        //CantSuma = Int32.Parse(txtCantBien.Text);
                    }

                    if (unosAgentesAsociados.Count > 0) //QUEDA CARGADO unosAgentesAsociados aun dps de cargar un hardware y volver a cargar un software GUARDA, 
                    //TENGO Q PREGUNTAR CUANDO HAGA CLICK EN ASOCIAR O EN ALGUN MOMENTO; SI EL SOFT YA ESTA AGREGADO, TRAER LOS DATOS Y GUARDARLOS EN LAS VARIABLES CORRESPONDIENTES
                    {

                        var resultado = unosAgentesAsociados.Where(x => x.IdAgente == unAgen.IdAgente);
                        if (resultado.Count() > 0)
                        {
                            MessageBox.Show("El agente " + unAgen.NombreAgente + " " + unAgen.ApellidoAgente + " " + "ya se encuentra asociado a este software");
                        }
                        else
                        {
                            unosAgentesAsociados.Add(unAgen);
                            //CantSuma += 1;
                            //txtCantBien.Text = CantSuma.ToString();
                            txtCantBien.Text = unosAgentesAsociados.Count().ToString();
                        }
                    }
                    else
                    {
                        unosAgentesAsociados.Add(unAgen);
                        //CantSuma += 1;
                        //txtCantBien.Text = CantSuma.ToString();
                        txtCantBien.Text = unosAgentesAsociados.Count().ToString();
                    }

                    grillaAgentesAsociados.DataSource = null;
                    grillaAgentesAsociados.DataSource = unosAgentesAsociados;
                    grillaAgentesAsociados.Columns[0].Visible = false;
                    grillaAgentesAsociados.Columns[3].Visible = false;
                    grillaAgentesAsociados.Columns[4].Visible = false;
                //}
                //Valido CantBien para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
                validCantBien.Validate();

        }

        private void EventValidTxtCantBien(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantBien.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void txtAgregarDetalle_Click(object sender, EventArgs e)
        {


        }










    }
}