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
        Solicitud unaSolicitudSinModif;
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
        int ContDetalles = 0;

        List<string> unosAdjuntos = new List<string>();
        List<Nota> unasNotas = new List<Nota>();
        BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
        bool flagDetEliminado = false;
        bool flagRespInhabilitado;
        BLLDependencia ManagerDependenciaAg = new BLLDependencia();


        public frmSolicitudModificar(Solicitud unaSolic)
        {
            InitializeComponent();
            unaSolicitud = unaSolic;
        }

        private void frmSolicitudModificar_Load(object sender, EventArgs e)
        {


            BLLSolicitud ManagerSolicitud = new BLLSolicitud();
            

            txtDependencia.Text = unaSolicitud.laDependencia.NombreDependencia;
            unosAgentesResp = new List<Agente>();
            unosAgentesResp = ManagerDependenciaAg.TraerAgentesResp(unaSolicitud.laDependencia.IdDependencia);
            //Si el responsable de la solicitud ya no es parte de la dependencia
            if (!unosAgentesResp.Exists(X=>X.IdAgente == unaSolicitud.AgenteResp.IdAgente))
            {
                unosAgentesResp.Add(unaSolicitud.AgenteResp);
                flagRespInhabilitado = true;
            }
            cboAgenteResp.DataSource = null;
            cboAgenteResp.DataSource = unosAgentesResp;
            cboAgenteResp.DisplayMember = "ApellidoAgente";
            cboAgenteResp.ValueMember = "IdAgente";
            cboAgenteResp.SelectedValue = unaSolicitud.AgenteResp.IdAgente;
            if (flagRespInhabilitado)
                lblDesvinculado.Visible = true;

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

            //Traer los agentes de la dependencia seleccionada
            BLLDependencia managerDependenciaAg = new BLLDependencia();
            unosAgentes = new List<Agente>();
            unosAgentes = managerDependenciaAg.TraerAgentesDependencia(unaSolicitud.laDependencia.IdDependencia);

            //ESTE CODIGO ESTABA DUPLICADO, REVISAR QUE SE CARGUE EL AGENTE RESPONSABLE CORRECTAMETNE Y ELIMINAR ESTE CODIGO
            //unosAgentesResp = new List<Agente>();
            //unosAgentesResp = managerDependenciaAg.TraerAgentesResp(unaSolicitud.laDependencia.IdDependencia);
            //cboAgenteResp.DataSource = null;
            //cboAgenteResp.DataSource = unosAgentesResp;
            //cboAgenteResp.DisplayMember = "ApellidoAgente";
            //cboAgenteResp.ValueMember = "IdAgente";

            //Agrega los detalles
            grillaDetalles.DataSource = null;
            unaSolicitud.unosDetallesSolicitud = ManagerSolicitud.SolicitudTraerDetalles(unaSolicitud).unosDetallesSolicitud.ToList();
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            //grillaDetalles.Columns[1].Visible = false;
            //Para que el conteo empiece desde el nro de detalles que hay al agregar más detalles
            ContDetalles = unaSolicitud.unosDetallesSolicitud.Count();

            //Agrega los agentes al detalle si es un software
            foreach (SolicDetalle unDetSolicAUX in unaSolicitud.unosDetallesSolicitud)
            {
                TipoBien unTipoBienLocal;
                unTipoBienLocal = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unDetSolicAUX.unaCategoria.IdCategoria);
                if (unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Soft)
                {
                    unDetSolicAUX.unosAgentes = ManagerSolicDetalle.SolicDetallesTraerAgentesAsociados(unDetSolicAUX.IdSolicitudDetalle, unaSolicitud.IdSolicitud);
                }
            }

            //Agrega el conteo de cotizaciones por detalle
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

            //VER:Comente esto porque no lo supuestamente no lo usaba
            ////Coloca el tipo Bien segun el detalle seleccionado (el primero en este caso)
            //unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unaSolicitud.unosDetallesSolicitud[0].unaCategoria.IdCategoria);
            //if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
            //{
            //    //HARDWARE
            //    gboxAsociados.Enabled = false;
            //    txtCantBien.ReadOnly = false;
            //    lblCantidad.Enabled = true;
            //    AuxTipoCategoria = 1;//HARDWARE
            //    cboTipoBien.SelectedValue = 1;//HARDWARE
            //    txtAgente.Clear();
            //    //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
            //    grillaAgentesAsociados.DataSource = null;
            //}
            //else
            //{
            //    gboxAsociados.Enabled = true;
            //    txtCantBien.ReadOnly = true;
            //    lblCantidad.Enabled = false;
            //    AuxTipoCategoria = 2;//SOFTWARE
            //    cboTipoBien.SelectedValue = 2;//SOFTWARE
            //    txtAgente.Clear();
            //    //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
            //    grillaAgentesAsociados.DataSource = null;
            //    grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud[0].unosAgentes;//Esta puesto [0] porque si el primer detalle es un soft, ya aparece escrito en el form
            //    //No mostrar columnas que no necesito de los agentes asociados
            //    grillaAgentesAsociados.Columns[0].Visible = false;
            //    grillaAgentesAsociados.Columns[3].Visible = false;
            //    grillaAgentesAsociados.Columns[4].Visible = false;
            //}
            cboEstadoSolDetalle.SelectedValue = unaSolicitud.unosDetallesSolicitud[0].unEstado.IdEstadoSolicDetalle;


            //Traigo categorias para dps filtrar por hard o soft
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategoriasHard = new List<Categoria>();
            unasCategoriasHard = ManagerCategoria.CategoriaTraerTodosHard();
            unasCategoriasSoft = new List<Categoria>();
            unasCategoriasSoft = ManagerCategoria.CategoriaTraerTodosSoft();

            unosAgentesAsociados = new List<Agente>();

            grillaDetallesFormatoAplicar();

        }



        public void grillaDetallesFormatoAplicar()
        {
            //Formato de la grillaDetalles
            grillaDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillaDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grillaDetalles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillaDetalles.Columns[0].HeaderText = "#";
            grillaDetalles.Columns[1].Visible = false;
            grillaDetalles.Columns["unaCategoria"].HeaderText = "Bien";
            grillaDetalles.Columns["unEstado"].HeaderText = "Estado";
            //grillaDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //grillaDetalles.Columns[4].Width = 80;
            //grillaDetalles.Columns[4].HeaderText = "Estado";
            grillaDetalles.Columns["Seleccionado"].Visible = false;
            grillaDetalles.Columns["txtCotizConteo"].HeaderText = "Cotizaciones";
            grillaDetalles.Columns["UIDSolicDetalle"].Visible = false;
        }




        //*************FALTA ELIMINAR EL DETALLE DE LA BD SI SE CONFIRMA EL CAMBIO
        private void grillaDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //VER:Si hizo click en Borrar *************************BORRAR EL DETALLE DE LA BD; PARA QUE EL e.index NO QUEDE COLGADO 
            if (e.ColumnIndex == grillaDetalles.Columns["btnDinBorrar"].Index)
            {
                //Pongo el flag en true para dps regenerar los detalles en la BD
                flagDetEliminado = true;

                PartidaDetalle unaPartDet = new PartidaDetalle();
                //Compruebo que no tenga partidas asociadas
                BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
                unaPartDet = ManagerPartidaDetalle.SolicDetallePartidaDetalleAsociacionTraer(unaSolicitud.IdSolicitud, unaSolicitud.unosDetallesSolicitud[e.RowIndex].IdSolicitudDetalle);
                if (unaPartDet.IdPartida == 0)
                {
                    //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                    grillaDetalles.Columns.RemoveAt(e.ColumnIndex);
                    grillaDetalles.Columns.Remove("txtCotizConteo");
                    grillaDetalles.Columns.Remove("btnDinCotizar");

                    //Obtengo el Nro IDDetalle que se borrará
                    int NroDetBorrado = unaSolicitud.unosDetallesSolicitud[e.RowIndex].IdSolicitudDetalle;

                    //elimino de la memoria el detalle
                    unaSolicitud.unosDetallesSolicitud.RemoveAt(e.RowIndex);

                    //Conteo de detalles
                    foreach (SolicDetalle Det2 in unaSolicitud.unosDetallesSolicitud)
                    {
                        if (Det2.IdSolicitudDetalle > NroDetBorrado)
                            Det2.IdSolicitudDetalle--;
                    }
                    //Regenero la grilla
                    grillaDetalles.DataSource = null;
                    grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                    //grillaDetalles.Columns[1].Visible = false;
                    //Vuelve a agregar el conteo de cotizaciones por detalle
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

                    grillaDetallesFormatoAplicar();

                    //Limpio el formulario en donde aparecen los datos de carga de soft y hard
                    grillaAgentesAsociados.DataSource = null;
                    txtAgente.Clear();
                    cboEstadoSolDetalle.SelectedValue = 0;
                    txtBien.Clear();
                    txtCantBien.Clear();
                }
                else
                {
                    MessageBox.Show("El detalle está asociado a la Partida Nro: " + unaPartDet.IdPartida);
                }
            }
            else //si hizo click en cualquier otro lado, muestra los datos del detalle en el formulario de carga de datos
            {
                //Muestro boton modificar y oculto el de crear
                btnModificar.Visible = true;
                btnAgregarDetalle.Visible = false;
                cboTipoBien.Enabled = false;
                //Para obtener el detalle en donde se hizo click
                //MessageBox.Show(grillaDetalles.Rows.SharedRow(e.RowIndex).ToString());
                int DetalleSeleccionado = e.RowIndex + 1;
                unDetSolic = new SolicDetalle();
                txtBien.ReadOnly = true;

                unDetSolic = unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);

                txtBien.Text = unDetSolic.unaCategoria.DescripCategoria;
                unaCat = unDetSolic.unaCategoria;
                txtCantBien.Text = unDetSolic.Cantidad.ToString();

                cboEstadoSolDetalle.SelectedValue = unDetSolic.unEstado.IdEstadoSolicDetalle;

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
                    AuxTipoCategoria = (int)TipoBien.EnumTipoBien.Soft;
                    cboTipoBien.SelectedValue = (int)TipoBien.EnumTipoBien.Soft;
                    txtAgente.Clear();
                    //VER: unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERRORVER**********************************
                    grillaAgentesAsociados.DataSource = null;
                    if (unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes.Count() > 0)
                    {
                        grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes;
                    }
                    else
                    {
                        grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes = ManagerSolicDetalle.SolicDetallesTraerAgentesAsociados(DetalleSeleccionado, unaSolicitud.IdSolicitud);
                    }

                    //No mostrar columnas que no necesito de los agentes asociados VER: GUARDA CON ESTO QUE PUEDE QUE ESTE OCULTANDO COSAS QUE NO QUIERO OCULTAR
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
            //if (unaSolicitud.unosDetallesSolicitud[(unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle) - 1].unasCotizaciones.Count() > 2)
            if (unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle).FirstOrDefault().unasCotizaciones.Count() > 2)
            {
                //Actualizo el estado en la bd
                //ManagerSolicDetalle.SolicDetalleUpdateEstado(unaSolicitud.IdSolicitud, unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado);
                //Actualizo el estado en el objeto en memoria
                unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle).FirstOrDefault().unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado;
                unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle).FirstOrDefault().unEstado.DescripEstadoSolicDetalle = "Cotizado";
                //Actualizo en la grilla el estado con un objeto auxiliar porque sino, no lo hacía en tiempo real
                EstadoSolicDetalle EstadoAUX = new EstadoSolicDetalle();
                EstadoAUX.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado;
                EstadoAUX.DescripEstadoSolicDetalle = "Cotizado";
                grillaDetalles.Rows[(unasCotiza[0].unDetalleAsociado.IdSolicitudDetalle) - 1].Cells["unEstado"].Value = EstadoAUX;
            }
        }



        private void btnSoliitarPartida_Click(object sender, EventArgs e)
        {
            //if (unaSolicitud.unosDetallesSolicitud.Where(x => x.unasCotizaciones.Count() >= 3).Count() == unaSolicitud.unosDetallesSolicitud.Count())
            List<SolicDetalle> ListaDetSolicLocal = new List<SolicDetalle>();
            ListaDetSolicLocal = unaSolicitud.unosDetallesSolicitud.Where(x => x.unasCotizaciones.Count() >= 3).ToList();
            if (ListaDetSolicLocal.Count() > 0)
            {
                SolicDetalle unDetSolicLocal;
                unDetSolicLocal = ListaDetSolicLocal.FirstOrDefault(t => t.unEstado.IdEstadoSolicDetalle == (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado);
                if (unDetSolicLocal != null)
                {
                    frmPartidaSolicitar unFrmPartidaSolicitar = frmPartidaSolicitar.ObtenerInstancia(unaSolicitud);
                    unFrmPartidaSolicitar.Show();
                }
                else
                {
                    MessageBox.Show("Revise que los detalles posean al menos 3 cotizaciones y estén en estado Cotizado");
                }
            }
            else
            {
                MessageBox.Show("Revise que los detalles posean al menos 3 cotizaciones");
            }
        }



        private void btnBienAsignar_Click(object sender, EventArgs e)
        {

            BLLInventario ManagerInventario = new BLLInventario();
            if ((ManagerInventario.InventariosTraerListosParaAsignar(unaSolicitud.IdSolicitud)).Count() > 0)
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
            else
            {
                //VER: Traduccion
                MessageBox.Show("No hay bienes listos para ser entregados");
            }

        }



        private void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            validCantBien.ClearFailedValidations();
            //Muestro el boton para agregar detalles y oculto el que modifica
            btnAgregarDetalle.Visible = true;
            btnModificar.Visible = false;
            cboTipoBien.Enabled = true;
            unDetSolic = null;
            txtBien.ReadOnly = false;
            gboxAsociados.Enabled = false;
            txtCantBien.ReadOnly = false;
            lblCantidad.Enabled = true;
            cboTipoBien.SelectedIndex = (int)Hardware.elTipoBien.Hardware - 1;
            txtBien.Clear();
            AuxTipoCategoria = 1;
            txtCantBien.Clear();
            txtAgente.Clear();
            unAgen = null;
            grillaAgentesAsociados.DataSource = null;
            cboEstadoSolDetalle.SelectedIndex = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente - 1;
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
            validBien.ClearFailedValidations();
            validCantBien.ClearFailedValidations();
            txtBien.ReadOnly = false;

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
                    this.txtBien.TextChanged -= new System.EventHandler(this.txtBien_TextChanged);
                    txtBien.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    this.txtBien.TextChanged += new System.EventHandler(this.txtBien_TextChanged);
                    txtBien.SelectionStart = txtBien.Text.Length + 1;
                    TipoBien unTipoBienLocal;
                    unTipoBienLocal = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unaCat.IdCategoria);
                    if (unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        SolicDetalle unSDetLocal;
                        unSDetLocal = unaSolicitud.unosDetallesSolicitud.Find(X => X.unaCategoria.IdCategoria == unaCat.IdCategoria);
                        if (unSDetLocal != null)
                            unosAgentesAsociados = unSDetLocal.unosAgentes;
                    }
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    validBien.Validate();
                }
            }
        }



        //Busqueda Dinamica Agentes por Dependencia
        private void txtAgente_TextChanged(object sender, EventArgs e)
        {
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
                    this.txtAgente.TextChanged -= new System.EventHandler(this.txtAgente_TextChanged);
                    txtAgente.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    this.txtAgente.TextChanged += new System.EventHandler(this.txtAgente_TextChanged);
                    txtAgente.SelectionStart = txtAgente.Text.Length + 1;
                }
            }
        }



        //Asociar Agentes al software ingresado
        private void btnAsociarAgente_Click(object sender, EventArgs e)//VALIDAR QUE NO DEJE AGREGARDETALLE SI NO HAY UN AGENTE ASOCIADO
        {
            if (validAgenteAsoc.Validate())
            {
                if (unosAgentesAsociados.Count > 0) //QUEDA CARGADO unosAgentesAsociados aun dps de cargar un hardware y volver a cargar un software GUARDA, 
                {

                    var resultado = unosAgentesAsociados.Where(x => x.IdAgente == unAgen.IdAgente);
                    if (resultado.Count() > 0)
                    {
                        MessageBox.Show("El agente " + unAgen.NombreAgente + " " + unAgen.ApellidoAgente + " " + "ya se encuentra asociado a este software");
                        validCantBien.ClearFailedValidations();
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
            }
            //Valido CantBien para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
            //validCantBien.Validate();

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

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (validBien.Validate())
            {
                SolicDetalle unDetalleSolicitud = new SolicDetalle();
                unDetalleSolicitud.unaCategoria = unaCat;

                if (validCantBien.Validate() && Int32.Parse(txtCantBien.Text) > 0)
                {
                    unDetalleSolicitud.Cantidad = Int32.Parse(txtCantBien.Text);

                    //Verifica si ya hay un detalle para sumarle cantidad y así no haya Bienes repetidos en distintos detalles
                    if (unaSolicitud.unosDetallesSolicitud.Find(Z => Z.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria) != null)//SI YA HAY UN DETALLE
                    {
                        //if ((unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { Widget = o, Index = i }).Where(item => item.Widget.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).FirstOrDefault().Widget.Cantidad += unDetalleSolicitud.Cantidad) > 0) Antiguo
                        //if ((unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { Widget = o, Index = i }).FirstOrDefault(item => item.Widget.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).Widget.Cantidad += unDetalleSolicitud.Cantidad) > 0) Antiguo
                        var hhh = unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { Widget = o, Index = i }).Where(item => item.Widget.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).FirstOrDefault();
                        if (hhh != null)
                        {
                            if (AuxTipoCategoria == 2)//Tipo Software
                            {
                                //HAY QUE CONSULTAR SI EL SOFT ESTA HOMOLOGADO Y ES GRATIS
                                //SI ESTA HOMOLOGADO Y ES GRATIS, MBOX INDICANDO QUE SE AUTORIZA LA INSTALACION DIRECTAMENTE (MANDA MAIL A MESA DE AYUDA) Y PONE EL DETALLE COMO FINALIZADO

                                //Le Agrego los nuevos agentes
                                foreach (Agente unAgen in unosAgentesAsociados)
                                {
                                    hhh.Widget.unosAgentes.Add(unAgen);
                                }
                                hhh.Widget.Cantidad = hhh.Widget.unosAgentes.Count();
                            }
                            else
                            {
                                hhh.Widget.Cantidad += unDetalleSolicitud.Cantidad;
                            }
                            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                            grillaDetalles.Columns.Remove("btnDinBorrar");
                            grillaDetalles.Columns.Remove("txtCotizConteo");
                            grillaDetalles.Columns.Remove("btnDinCotizar");

                            //Regenero la grilla
                            grillaDetalles.DataSource = null;
                            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                            //grillaDetalles.Columns[1].Visible = false;
                            //Vuelve a agregar el conteo de cotizaciones por detalle
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

                            grillaDetallesFormatoAplicar();
                        }
                        else
                        {
                            AgregarDetalleConfirmado(ref unDetalleSolicitud);
                        }
                    }
                    else
                    {
                        BLLPolitica ManagerPolitica = new BLLPolitica();
                        if (ManagerPolitica.VerificarPolitica(unaSolicitud.laDependencia.IdDependencia, unDetalleSolicitud.unaCategoria.IdCategoria, unDetalleSolicitud.Cantidad))
                        {
                            AgregarDetalleConfirmado(ref unDetalleSolicitud);
                        }
                        else
                        {
                            DialogResult resmbox = MessageBox.Show(ServicioIdioma.MostrarMensaje("Mensaje1").Texto, "Advertencia", MessageBoxButtons.YesNo);
                            if (resmbox == DialogResult.Yes)
                            {
                                AgregarDetalleConfirmado(ref unDetalleSolicitud);
                            }
                            else
                            {
                                //FIJARME SI HAY QUE RESETEAR ALGO
                            }
                        }
                    }
                }
            }

        }



        private void AgregarDetalleConfirmado(ref SolicDetalle unDetSolic)
        {

            //Conteo Detalles
            ContDetalles = unaSolicitud.unosDetallesSolicitud.Count();
            unDetSolic.IdSolicitudDetalle = ++ContDetalles;

            if (AuxTipoCategoria == 2)//Categoria de Software
            {
                unDetSolic.unosAgentes = (List<Agente>)unosAgentesAsociados.ToList();
                //HAY QUE CONSULTAR SI EL SOFT ESTA HOMOLOGADO Y ES GRATIS
                //SI ESTA HOMOLOGADO Y ES GRATIS, MBOX INDICANDO QUE SE AUTORIZA LA INSTALACION DIRECTAMENTE (MANDA MAIL A MESA DE AYUDA) Y PONE EL DETALLE COMO FINALIZADO
            }
            unDetSolic.unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente;//GUARDA REVISAR ESTO en soft tmb
            unDetSolic.unEstado.DescripEstadoSolicDetalle = "Pendiente";
            unaSolicitud.unosDetallesSolicitud.Add(unDetSolic);

            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            grillaDetalles.Columns.Remove("btnDinBorrar");
            grillaDetalles.Columns.Remove("txtCotizConteo");
            grillaDetalles.Columns.Remove("btnDinCotizar");

            //Regenero la grilla
            grillaDetalles.DataSource = null;
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            //grillaDetalles.Columns[1].Visible = false;
            //Vuelve a agregar el conteo de cotizaciones por detalle
            DataGridViewTextBoxColumn ColumnaCotizacionConteo = new DataGridViewTextBoxColumn();
            ColumnaCotizacionConteo.Name = "txtCotizConteo";
            ColumnaCotizacionConteo.HeaderText = "txtCotizConteo";
            grillaDetalles.Columns.Add(ColumnaCotizacionConteo);
            foreach (DataGridViewRow item in grillaDetalles.Rows)
            {
                if (unaSolicitud.unosDetallesSolicitud[item.Index].unasCotizaciones == null)
                    unaSolicitud.unosDetallesSolicitud[item.Index].unasCotizaciones = new List<Cotizacion>();
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

            grillaDetallesFormatoAplicar();
        }



        private void EventValidTxtBien(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBien.Text))
            {
                e.IsValid = false;
            }
            else
            {
                if (unaCat != null && string.Equals(e.ControlToValidate.Text, unaCat.DescripCategoria))
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }
        }



        private void EventTxtAgenteAsoc(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAgente.Text))
            {
                e.IsValid = false;
            }
            else
            {
                if (unAgen != null)
                {
                    if (string.Equals(e.ControlToValidate.Text, unAgen.ApellidoAgente))
                    {
                        e.IsValid = true;
                    }
                    else
                    {
                        e.IsValid = false;
                    }
                }
                else
                {
                    e.IsValid = false;
                }
            }
        }



        //Estilo que se aplica cuando se arrastra un archivo a pnlAdjuntos
        private void pnlAdjuntos_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            pnlAdjuntos.BorderStyle = BorderStyle.Fixed3D;
        }


        //Copiar el archivo
        private void pnlAdjuntos_DragDrop(object sender, DragEventArgs e)
        {
            if (unosAdjuntos.Count > 2)
            {
                MessageBox.Show("No pueden adjuntarse más de 3 archivos");
            }
            else
            {
                //Agarro la ruta de los archivos arrastrados
                string[] unArchivo = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (var item in unArchivo)
                {
                    //Agarro el nombre del archivo
                    string NombreArchivo = Path.GetFileName(item);
                    if (FRAMEWORK.Servicios.ManejoArchivos.ValidarAdjunto(item))
                    {
                        //Copio el archivo
                        FRAMEWORK.Servicios.ManejoArchivos.CopiarArchivo(item, @"D:\Se pueden borrar sin problemas\ArchivosCopiados\" + NombreArchivo);
                        pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;

                        //Añado a la grilla el nombre del archivo
                        unosAdjuntos.Add(NombreArchivo);

                        lstAdjuntos.DataSource = null;
                        lstAdjuntos.DataSource = unosAdjuntos;

                        //GrillaAdjuntos.Columns[0].HeaderText = "Archivos";

                    }
                    else
                    {
                        MessageBox.Show("El archivo " + "\"" + NombreArchivo + "\"" + " no tiene una extensión válida (jpg, png, bmp, pdf, txt)");
                    }
                }
            }
        }



        //Estilo que se aplica cuando se sale de pnladjuntos (en el evento de arrastrar archivos)
        private void pnlAdjuntos_DragLeave(object sender, EventArgs e)
        {
            pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;
        }



        private void btnNotas_Click(object sender, EventArgs e)
        {
            if (validNota.Validate())
            {
                Nota unaNota = new Nota();
                unaNota.FechaNota = DateTime.Now;
                unaNota.DescripNota = txtNota.Text;
                unasNotas.Add(unaNota);
                GrillaNotas.DataSource = null;
                GrillaNotas.DataSource = unasNotas;
                GrillaNotas.Columns[0].Visible = false;
            }
        }



        private void EventValidtxtNota(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNota.Text))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (validBien.Validate())
            {
                SolicDetalle unDetalleSolicitud = new SolicDetalle();
                unDetalleSolicitud.unaCategoria = unaCat;

                if (validCantBien.Validate() && Int32.Parse(txtCantBien.Text) > 0)
                {
                    unDetalleSolicitud.Cantidad = Int32.Parse(txtCantBien.Text);

                    //Verifica si ya hay un detalle para sumarle cantidad y así no haya Bienes repetidos en distintos detalles
                    if (unaSolicitud.unosDetallesSolicitud.Find(RR => RR.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria) != null)//SI YA HAY UN DETALLE
                    {
                        var hhh = unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { Widget = o, Index = i }).Where(item => item.Widget.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).FirstOrDefault();
                        if (hhh != null)
                        {
                            if (AuxTipoCategoria == 2)//Categoria de Software
                            {
                                //Cargo los agentes que ya había (es diferente de btnAgregarDetalle_Click porque aca esta en memoria ya)
                                unDetalleSolicitud.unosAgentes = (List<Agente>)unosAgentesAsociados.ToList();
                                //HAY QUE CONSULTAR SI EL SOFT ESTA HOMOLOGADO Y ES GRATIS
                                //SI ESTA HOMOLOGADO Y ES GRATIS, MBOX INDICANDO QUE SE AUTORIZA LA INSTALACION DIRECTAMENTE (MANDA MAIL A MESA DE AYUDA) Y PONE EL DETALLE COMO FINALIZADO
                                hhh.Widget.Cantidad = unDetalleSolicitud.unosAgentes.Count();
                            }
                            else
                            {
                                hhh.Widget.Cantidad = Int32.Parse(txtCantBien.Text);
                            }
                            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                            grillaDetalles.Columns.Remove("btnDinBorrar");
                            grillaDetalles.Columns.Remove("txtCotizConteo");
                            grillaDetalles.Columns.Remove("btnDinCotizar");

                            //Regenero la grilla
                            grillaDetalles.DataSource = null;
                            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                            //grillaDetalles.Columns[1].Visible = false;
                            //Vuelve a agregar el conteo de cotizaciones por detalle
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

                            grillaDetallesFormatoAplicar();
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            grillaDetalles.Columns.Remove("btnDinBorrar");
            grillaDetalles.Columns.Remove("txtCotizConteo");
            grillaDetalles.Columns.Remove("btnDinCotizar");
            grillaDetalles.DataSource = null;
            frmSolicitudModificar_Load(this, new EventArgs());
            txtBien.Clear();
            txtCantBien.Clear();
            txtNota.Clear();
            GrillaNotas.DataSource = null;
            unosAdjuntos.Clear();
            unasNotas.Clear();
            GrillaAdjuntos.DataSource = null;
            flagDetEliminado = false;

        }

        private void btnModifSolicitud_Click(object sender, EventArgs e)
        {
            unaSolicitud.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            //***FECHA FIN VER Q SI ESTA ESCRITA
            unaSolicitud.UnaPrioridad = (Prioridad)cboPrioridad.SelectedItem;
            unaSolicitud.Asignado = (Usuario)cboAsignado.SelectedItem;
            if (cboEstadoSolicitud.SelectedIndex + 1 == (int)EstadoSolicitud.EnumEstadoSolicitud.Cerrado)
            {
                MessageBox.Show("Debe ingresar un motivo y la fecha de finalización será la de hoy");
                unaSolicitud.FechaFin = DateTime.Today;

                //VER:AGREGAR LO DEL MOTIVO
            }
            unaSolicitud.UnEstado = (EstadoSolicitud)cboEstadoSolicitud.SelectedItem;
            unaSolicitud.AgenteResp = (Agente)cboAgenteResp.SelectedItem;
            if (unasNotas.Count > 0)//PONER COUNT
            {
                unaSolicitud.unasNotas = (List<Nota>)this.unasNotas.ToList();
            }

            //VER:HACER LO DE FECHA FIN Y EL ESTADO EN FINALIZADO
            //VER:AGREGAR LOS ADJUNTOS
            //VER:AGREGAR EN EL STORE LAS NOTAS
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();

            //if (flagDetEliminado)
            //{
            //Regenerar detalles en BD
            //ManagerSolicDetalle.SolicDetalleDeletePorSolicitud(unaSolicitud.IdSolicitud);
            ManagerSolicitud.SolicitudModificarConDetallesEliminados(unaSolicitud);
            //}
            //else
            //{
            //     ManagerSolicitud.SolicitudModificarConDetallesEliminados(unaSolicitud);
            //    //Modificar datos detalles
            //}
        }

        //Para comprobar si el responsable fue desvinculado y dar aviso de ello
        private void cboAgenteResp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<Agente> unosAgentesResp2 = new List<Agente>();
            unosAgentesResp2 = ManagerDependenciaAg.TraerAgentesResp(unaSolicitud.laDependencia.IdDependencia);
            if (unosAgentesResp2.Count < unosAgentesResp.Count)
            {
                if ((cboAgenteResp.SelectedItem as Agente).IdAgente == unaSolicitud.AgenteResp.IdAgente)
                {
                    lblDesvinculado.Visible = true;
                }
                else
                {
                    lblDesvinculado.Visible = false;
                }
            }
            
        }









    }
}