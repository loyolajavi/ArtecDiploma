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

namespace ARTEC.GUI
{
    public partial class frmSolicitudModificar : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static List<frmSolicitudModificar> _unfrmSolicitudModificarInst;
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
        BLLSolicitud ManagerSolicitud = new BLLSolicitud();

        List<string> unosAdjuntos = new List<string>();
        List<string> unosAdjuntosRutas = new List<string>();
        string NombreAdjunto;
        List<Nota> unasNotas = new List<Nota>();
        List<Nota> unasNotasAgregar = new List<Nota>();
        BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
        bool flagDetEliminado = false;
        bool flagRespInhabilitado;
        BLLDependencia ManagerDependenciaAg = new BLLDependencia();
        bool flagUsuarioInactivo;
        BLLUsuario ManagerUsuario = new BLLUsuario();
        List<SolicDetalle> unosSolicDetAgregarBKP = new List<SolicDetalle>();
        BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
        int DetalleSeleccionado = 1;
        string RutaCompletaAdjuntoGuardado;


        private frmSolicitudModificar(Solicitud unaSolic)
        {
            InitializeComponent();

            unaSolicitud = unaSolic;

            Dictionary<string, string[]> diclblSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblSolicitud = { "Solicitud" };
            diclblSolicitud.Add("Idioma", IdiomalblSolicitud);
            this.lblSolicitud.Tag = diclblSolicitud;

            Dictionary<string, string[]> dicbtnCancelar = new Dictionary<string, string[]>();
            string[] PerbtnCancelar = { "Solicitud Cancelar" };
            dicbtnCancelar.Add("Permisos", PerbtnCancelar);
            string[] IdiomabtnCancelar = { "Cancelar" };
            dicbtnCancelar.Add("Idioma", IdiomabtnCancelar);
            this.btnCancelar.Tag = dicbtnCancelar;

            Dictionary<string, string[]> dicbtnModifSolicitud = new Dictionary<string, string[]>();
            string[] PerbtnModifSolicitud = { "Solicitud Modificar" };
            dicbtnModifSolicitud.Add("Permisos", PerbtnModifSolicitud);
            string[] IdiomabtnModifSolicitud = { "Modificar" };
            dicbtnModifSolicitud.Add("Idioma", IdiomabtnModifSolicitud);
            this.btnModifSolicitud.Tag = dicbtnModifSolicitud;

            Dictionary<string, string[]> dicbtnEliminarAdjunto = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminarAdjunto = { "Quitar" };
            dicbtnEliminarAdjunto.Add("Idioma", IdiomabtnEliminarAdjunto);
            this.btnEliminarAdjunto.Tag = dicbtnEliminarAdjunto;

            Dictionary<string, string[]> dicbtnSolicitarPartida = new Dictionary<string, string[]>();
            string[] PerbtnSolicitarPartida = { "Partida Crear" };
            dicbtnSolicitarPartida.Add("Permisos", PerbtnSolicitarPartida);
            string[] IdiomabtnSolicitarPartida = { "Solicitar Partida" };
            dicbtnSolicitarPartida.Add("Idioma", IdiomabtnSolicitarPartida);
            this.btnSolicitarPartida.Tag = dicbtnSolicitarPartida;

            Dictionary<string, string[]> dicbtnBienAsignar = new Dictionary<string, string[]>();
            string[] PerbtnBienAsignar = { "Asignacion Crear" };
            dicbtnBienAsignar.Add("Permisos", PerbtnBienAsignar);
            string[] IdiomabtnBienAsignar = { "Crear Asignación" };
            dicbtnBienAsignar.Add("Idioma", IdiomabtnBienAsignar);
            this.btnBienAsignar.Tag = dicbtnBienAsignar;

            Dictionary<string, string[]> dictxtCantBien = new Dictionary<string, string[]>();
            string[] IdiomatxtCantBien = { "Ingrese la cantidad" };
            dictxtCantBien.Add("Idioma", IdiomatxtCantBien);
            this.txtCantBien.Tag = dictxtCantBien;

            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Dependencia" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;

            Dictionary<string, string[]> diclblAgenteResponsable = new Dictionary<string, string[]>();
            string[] IdiomalblAgenteResponsable = { "Responsable" };
            diclblAgenteResponsable.Add("Idioma", IdiomalblAgenteResponsable);
            this.lblAgenteResponsable.Tag = diclblAgenteResponsable;

            Dictionary<string, string[]> diclblDesvinculado = new Dictionary<string, string[]>();
            string[] IdiomalblDesvinculado = { "Desvinculado" };
            diclblDesvinculado.Add("Idioma", IdiomalblDesvinculado);
            this.lblDesvinculado.Tag = diclblDesvinculado;

            Dictionary<string, string[]> diclabelX5 = new Dictionary<string, string[]>();
            string[] IdiomalabelX5 = { "Creación" };
            diclabelX5.Add("Idioma", IdiomalabelX5);
            this.labelX5.Tag = diclabelX5;

            Dictionary<string, string[]> diclabelX6 = new Dictionary<string, string[]>();
            string[] IdiomalabelX6 = { "Finalización" };
            diclabelX6.Add("Idioma", IdiomalabelX6);
            this.labelX6.Tag = diclabelX6;

            Dictionary<string, string[]> dicgboxBienes = new Dictionary<string, string[]>();
            string[] IdiomagboxBienes = { "Agregar Bienes" };
            dicgboxBienes.Add("Idioma", IdiomagboxBienes);
            this.gboxBienes.Tag = dicgboxBienes;

            Dictionary<string, string[]> dicbtnNuevoDetalle = new Dictionary<string, string[]>();
            string[] IdiomabtnNuevoDetalle = { "Nuevo Detalle" };
            dicbtnNuevoDetalle.Add("Idioma", IdiomabtnNuevoDetalle);
            this.btnNuevoDetalle.Tag = dicbtnNuevoDetalle;

            Dictionary<string, string[]> diclblCantidad = new Dictionary<string, string[]>();
            string[] IdiomalblCantidad = { "Cantidad" };
            diclblCantidad.Add("Idioma", IdiomalblCantidad);
            this.lblCantidad.Tag = diclblCantidad;

            Dictionary<string, string[]> dicgboxAsociados = new Dictionary<string, string[]>();
            string[] IdiomagboxAsociados = { "Agentes asociados" };
            dicgboxAsociados.Add("Idioma", IdiomagboxAsociados);
            this.gboxAsociados.Tag = dicgboxAsociados;

            Dictionary<string, string[]> dictxtAgregarDetalle = new Dictionary<string, string[]>();
            string[] IdiomatxtAgregarDetalle = { "Agregar" };
            dictxtAgregarDetalle.Add("Idioma", IdiomatxtAgregarDetalle);
            this.btnAgregarDetalle.Tag = dictxtAgregarDetalle;

            Dictionary<string, string[]> diclabelX2 = new Dictionary<string, string[]>();
            string[] IdiomalabelX2 = { "Agente" };
            diclabelX2.Add("Idioma", IdiomalabelX2);
            this.labelX2.Tag = diclabelX2;

            Dictionary<string, string[]> dicbtnAsociarAgente = new Dictionary<string, string[]>();
            string[] IdiomabtnAsociarAgente = { "Asociar" };
            dicbtnAsociarAgente.Add("Idioma", IdiomabtnAsociarAgente);
            this.btnAsociarAgente.Tag = dicbtnAsociarAgente;

            Dictionary<string, string[]> diclabelX3 = new Dictionary<string, string[]>();
            string[] IdiomalabelX3 = { "Estado" };
            diclabelX3.Add("Idioma", IdiomalabelX3);
            this.labelX3.Tag = diclabelX3;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnAgregarDetalle = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregarDetalle = { "Agregar" };
            dicbtnAgregarDetalle.Add("Idioma", IdiomabtnAgregarDetalle);
            this.btnAgregarDetalle.Tag = dicbtnAgregarDetalle;

            Dictionary<string, string[]> diclabelX8 = new Dictionary<string, string[]>();
            string[] IdiomalabelX8 = { "Estado Solicitud" };
            diclabelX8.Add("Idioma", IdiomalabelX8);
            this.labelX8.Tag = diclabelX8;

            Dictionary<string, string[]> diclabelX9 = new Dictionary<string, string[]>();
            string[] IdiomalabelX9 = { "Prioridad" };
            diclabelX9.Add("Idioma", IdiomalabelX9);
            this.labelX9.Tag = diclabelX9;

            Dictionary<string, string[]> diclabelX10 = new Dictionary<string, string[]>();
            string[] IdiomalabelX10 = { "Asignado a" };
            diclabelX10.Add("Idioma", IdiomalabelX10);
            this.labelX10.Tag = diclabelX10;

            Dictionary<string, string[]> diclblInactivo = new Dictionary<string, string[]>();
            string[] IdiomalblInactivo = { "Dado de Baja" };
            diclblInactivo.Add("Idioma", IdiomalblInactivo);
            this.lblInactivo.Tag = diclblInactivo;

            Dictionary<string, string[]> dicgboxNotas = new Dictionary<string, string[]>();
            string[] IdiomagboxNotas = { "Notas" };
            dicgboxNotas.Add("Idioma", IdiomagboxNotas);
            this.gboxNotas.Tag = dicgboxNotas;

            Dictionary<string, string[]> dicbtnNotas = new Dictionary<string, string[]>();
            string[] IdiomabtnNotas = { "Agregar" };
            dicbtnNotas.Add("Idioma", IdiomabtnNotas);
            this.btnNotas.Tag = dicbtnNotas;

            
            
            

        }



        public static frmSolicitudModificar ObtenerInstancia(Solicitud unaSolic)
        {
            if (_unfrmSolicitudModificarInst == null)
            {
                _unfrmSolicitudModificarInst = new List<frmSolicitudModificar>();
                _unfrmSolicitudModificarInst.Add(new frmSolicitudModificar(unaSolic));
            }
            else
            {
                if (!_unfrmSolicitudModificarInst.Exists(X => X.unaSolicitud != null && X.unaSolicitud.IdSolicitud == unaSolic.IdSolicitud))
                    _unfrmSolicitudModificarInst.Add(new frmSolicitudModificar(unaSolic));
            }

            return _unfrmSolicitudModificarInst.First(X=>X.unaSolicitud.IdSolicitud == unaSolic.IdSolicitud);
        }

        private void frmSolicitudModificar_Load(object sender, EventArgs e)
        {
            try
            {
                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                //Traducir formulario
                BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                txtNroSolic.Text = unaSolicitud.IdSolicitud.ToString();
                BLLSolicitud ManagerSolicitud = new BLLSolicitud();

                //Traer los agentes Responsables de la dependencia
                txtDependencia.Text = unaSolicitud.laDependencia.NombreDependencia;
                unosAgentesResp = new List<Agente>();
                unosAgentesResp = ManagerDependenciaAg.TraerAgentesResp(unaSolicitud.laDependencia.IdDependencia);
                //Si el responsable de la solicitud ya no es parte de la dependencia
                if (!unosAgentesResp.Exists(X => X.IdAgente == unaSolicitud.AgenteResp.IdAgente))
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

                //Cargar fecha Inicio y Fin
                txtFechaInicio.Value = unaSolicitud.FechaInicio;
                if (unaSolicitud.FechaFin != null && unaSolicitud.FechaFin != DateTime.MinValue)
                    txtFechaFin.Value = (DateTime)unaSolicitud.FechaFin;
                txtFechaInicio.MaxDate = DateTime.Today;

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
                unosUsuarios = ManagerUsuario.UsuarioTraerTodosActivos();
                //Si el usuario asignado a la solicitud está dado de baja
                if (!unosUsuarios.Exists(x => x.IdUsuario == unaSolicitud.Asignado.IdUsuario))
                {
                    unosUsuarios.Add(unaSolicitud.Asignado);
                    flagUsuarioInactivo = true;
                }
                cboAsignado.DataSource = null;
                cboAsignado.DataSource = unosUsuarios;
                cboAsignado.DisplayMember = "NombreUsuario";
                cboAsignado.ValueMember = "IdUsuario";
                cboAsignado.SelectedValue = unaSolicitud.Asignado.IdUsuario;
                if (flagUsuarioInactivo)
                    lblInactivo.Visible = true;

                //Traer los agentes de la dependencia seleccionada
                BLLDependencia managerDependenciaAg = new BLLDependencia();
                unosAgentes = new List<Agente>();
                unosAgentes = managerDependenciaAg.TraerAgentesDependencia(unaSolicitud.laDependencia.IdDependencia);

                //Agrega los detalles
                grillaDetalles.DataSource = null;
                unaSolicitud.unosDetallesSolicitud = ManagerSolicitud.SolicitudTraerDetalles(unaSolicitud.IdSolicitud).unosDetallesSolicitud.ToList();
                grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                //grillaDetalles.Columns[1].Visible = false;
                //Para que el conteo empiece desde el nro de detalles que hay al agregar más detalles
                ContDetalles = unaSolicitud.unosDetallesSolicitud.Count();
                //Para el BKP de los SolicDetalles existentes
                //unosSolicDetAgregarBKP = unaSolicitud.unosDetallesSolicitud.ToList();

                //foreach (SolicDetalle unSDet in unaSolicitud.unosDetallesSolicitud)
                //{
                //    SolicDetalle unDet = new SolicDetalle();
                //    unDet.Cantidad = unSDet.Cantidad;
                //    int aux;
                //    aux = unSDet.IdSolicitudDetalle;
                //    unDet.IdSolicitudDetalle = aux;
                //    unDet.IdSolicitud = unSDet.IdSolicitud;
                //    unDet.Seleccionado = unSDet.Seleccionado;
                //    unDet.UIDSolicDetalle = unSDet.UIDSolicDetalle;
                //    unDet.unaCategoria = unSDet.unaCategoria;
                //    unDet.unasCotizaciones = unSDet.unasCotizaciones;
                //    unDet.unEstado = unSDet.unEstado;
                //    unDet.unosAgentes = unSDet.unosAgentes;
                //    unDet.unosBienes = unSDet.unosBienes;
                //    unosSolicDetAgregarBKP.Add(unSDet);
                //}

                foreach (SolicDetalle unSDet in unaSolicitud.unosDetallesSolicitud)
                {
                    unosSolicDetAgregarBKP.Add(unSDet.Clonar());
                }

                //Agrega los agentes al detalle si es un software
                foreach (SolicDetalle unDetSolicAUX in unaSolicitud.unosDetallesSolicitud)
                {
                    TipoBien unTipoBienLocal;
                    unTipoBienLocal = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unDetSolicAUX.unaCategoria.IdCategoria);
                    if (unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    {
                        unDetSolicAUX.unosAgentes = ManagerSolicDetalle.SolicDetallesTraerAgentesAsociados(unDetSolicAUX.IdSolicitudDetalle, unaSolicitud.IdSolicitud, unDetSolicAUX.UIDSolicDetalle);
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
                botonCotizar.HeaderText = BLLServicioIdioma.MostrarMensaje("Cotizar").Texto;
                botonCotizar.Text = BLLServicioIdioma.MostrarMensaje("Cotizar").Texto;
                botonCotizar.UseColumnTextForButtonValue = true;
                grillaDetalles.Columns.Add(botonCotizar);

                //Agrega boton para Borrar el detalle
                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "btnDinBorrar";
                deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("Eliminar").Texto;
                deleteButton.Text = BLLServicioIdioma.MostrarMensaje("Eliminar").Texto;
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
                unasCategoriasHard = ManagerCategoria.CategoriaTraerTodosHardActivos();
                unasCategoriasSoft = new List<Categoria>();
                unasCategoriasSoft = ManagerCategoria.CategoriaTraerTodosSoftActivos();

                unosAgentesAsociados = new List<Agente>();

                grillaDetallesFormatoAplicar();

                //Agrega las notas
                unasNotas = ManagerSolicitud.SolicitudTraerNotas(unaSolicitud.IdSolicitud);
                GrillaNotas.DataSource = null;
                if (unasNotas.Count > 0)
                {
                    GrillaNotas.DataSource = unasNotas;
                    FormatearNotas();
                }
                
                //Agrega el adjunto
                NombreAdjunto = ManagerSolicitud.ObtenerNombreAdjuntoSolic(unaSolicitud.IdSolicitud);
                RutaCompletaAdjuntoGuardado = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + NombreAdjunto;
                //Añado a la grilla el nombre del archivo
                unosAdjuntos.Add(NombreAdjunto);
                unosAdjuntosRutas.Add(RutaCompletaAdjuntoGuardado);

                lstAdjuntos.DataSource = null;
                lstAdjuntos.DataSource = unosAdjuntos;

                //Si está Cancelada o Finalizada inhabilito la modificación y botones
                if (unaSolicitud.UnEstado.IdEstadoSolicitud == (int)EstadoSolicitud.EnumEstadoSolicitud.Cancelada | unaSolicitud.UnEstado.IdEstadoSolicitud == (int)EstadoSolicitud.EnumEstadoSolicitud.Finalizado)
                {
                    btnAgregarDetalle.Enabled = false;
                    btnNuevoDetalle.Enabled = false;
                    btnModificar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnSolicitarPartida.Enabled = false;
                    btnBienAsignar.Enabled = false;
                    grillaDetalles.Enabled = false;
                    btnNotas.Enabled = false;
                    btnModifSolicitud.Enabled = false;
                    btnAsociarAgente.Enabled = false;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        private void FormatearNotas()
        {
            GrillaNotas.Columns["IdNota"].Visible = false;
            GrillaNotas.Columns["FechaNota"].HeaderText = BLLServicioIdioma.MostrarMensaje("Fecha").Texto;
            GrillaNotas.Columns["DescripNota"].HeaderText = BLLServicioIdioma.MostrarMensaje("Notas").Texto;
            GrillaNotas.Columns["IdUsuario"].Visible = false;
            GrillaNotas.Columns["IdSolicitud"].Visible = false;
        }

        public void grillaDetallesFormatoAplicar()
        {
            //Formato de la grillaDetalles
            grillaDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillaDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grillaDetalles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillaDetalles.Columns[0].HeaderText = "#";
            grillaDetalles.Columns[1].Visible = false;
            grillaDetalles.Columns["unaCategoria"].HeaderText = BLLServicioIdioma.MostrarMensaje("Categoría").Texto;
            grillaDetalles.Columns["unEstado"].HeaderText = BLLServicioIdioma.MostrarMensaje("Estado").Texto;
            //grillaDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //grillaDetalles.Columns[4].Width = 80;
            //grillaDetalles.Columns[4].HeaderText = "Estado";
            grillaDetalles.Columns["Seleccionado"].Visible = false;
            grillaDetalles.Columns["txtCotizConteo"].HeaderText = BLLServicioIdioma.MostrarMensaje("Cotizaciones").Texto;
            grillaDetalles.Columns["Cantidad"].HeaderText = BLLServicioIdioma.MostrarMensaje("Cantidad").Texto;
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

            //Si hizo click en Eliminar el Detalle
            if (e.ColumnIndex == grillaDetalles.Columns["btnDinBorrar"].Index)
            {
                //Pongo el flag en true para dps regenerar los detalles en la BD
                //flagDetEliminado = true;

                PartidaDetalle unaPartDet = new PartidaDetalle();
                //Compruebo que no tenga partidas asociadas
                unaPartDet = ManagerPartidaDetalle.SolicDetallePartidaDetalleAsociacionTraer(unaSolicitud.IdSolicitud, unaSolicitud.unosDetallesSolicitud[e.RowIndex].IdSolicitudDetalle, unaSolicitud.unosDetallesSolicitud[e.RowIndex].UIDSolicDetalle);
                if (unaPartDet.IdPartida == 0)
                {
                    //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                    grillaDetalles.Columns.RemoveAt(e.ColumnIndex);
                    if (grillaDetalles.Columns.Contains("txtCotizConteo"))
                        grillaDetalles.Columns.Remove("txtCotizConteo");
                    if (grillaDetalles.Columns.Contains("btnDinCotizar"))
                        grillaDetalles.Columns.Remove("btnDinCotizar");

                    //Obtengo el Nro IDDetalle que se borrará
                    int NroDetBorrado = unaSolicitud.unosDetallesSolicitud[e.RowIndex].IdSolicitudDetalle;

                    //elimino de la memoria el detalle
                    unaSolicitud.unosDetallesSolicitud.RemoveAt(e.RowIndex);

                    //Reordeno el conteo de detalles
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
                    botonCotizar.HeaderText = BLLServicioIdioma.MostrarMensaje("Cotizar").Texto;
                    botonCotizar.Text = BLLServicioIdioma.MostrarMensaje("Cotizar").Texto;
                    botonCotizar.UseColumnTextForButtonValue = true;
                    grillaDetalles.Columns.Add(botonCotizar);

                    //Vuelve a agregar el botón de borrar al final
                    var deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = "btnDinBorrar";
                    deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("Eliminar").Texto;
                    deleteButton.Text = BLLServicioIdioma.MostrarMensaje("Eliminar").Texto;
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El detalle está asociado a la Partida Nro: ").Texto + unaPartDet.IdPartida + BLLServicioIdioma.MostrarMensaje(", no puede eliminarse").Texto);
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
                DetalleSeleccionado = e.RowIndex + 1;
                unDetSolic = new SolicDetalle();
                txtBien.ReadOnly = true;

                unDetSolic = unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);

                this.txtBien.TextChanged -= new System.EventHandler(this.txtBien_TextChanged);
                txtBien.Text = unDetSolic.unaCategoria.DescripCategoria;
                this.txtBien.TextChanged += new System.EventHandler(this.txtBien_TextChanged);
                txtCantBien.Text = unDetSolic.Cantidad.ToString();

                //Traer TIPOBIEN por IdCategoria y ponerlo en el cbobox para que quede ese seleccionado
                unaCat = unDetSolic.unaCategoria;
                cboEstadoSolDetalle.SelectedValue = unDetSolic.unEstado.IdEstadoSolicDetalle;

                unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);

                if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                {
                    //HARDWARE
                    gboxAsociados.Enabled = false;
                    txtCantBien.ReadOnly = false;
                    lblCantidad.Enabled = true;
                    AuxTipoCategoria = (int)TipoBien.EnumTipoBien.Hard;
                    cboTipoBien.SelectedValue = (int)TipoBien.EnumTipoBien.Hard;
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
                    //VER: unAgen = null;
                    grillaAgentesAsociados.DataSource = null;
                    if (unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes.Count() > 0)
                    {
                        grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes;
                    }
                    else
                    {
                        grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes = ManagerSolicDetalle.SolicDetallesTraerAgentesAsociados(DetalleSeleccionado, unaSolicitud.IdSolicitud, unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado).UIDSolicDetalle);
                    }
                    //No mostrar columnas que no necesito de los agentes asociados VER: GUARDA CON ESTO QUE PUEDE QUE ESTE OCULTANDO COSAS QUE NO QUIERO OCULTAR
                    grillaAgentesAsociados.Columns[0].Visible = false;
                    grillaAgentesAsociados.Columns[3].Visible = false;
                    grillaAgentesAsociados.Columns[4].Visible = false;
                }
                //Además abre el frmCotizaciones
                if (e.ColumnIndex == grillaDetalles.Columns["btnDinCotizar"].Index)
                {
                    unDetSolic.IdSolicitud = unaSolicitud.IdSolicitud;
                    frmCotizaciones UnFrmCotizaciones = new frmCotizaciones(unaSolicitud.unosDetallesSolicitud[e.RowIndex].unasCotizaciones, unDetSolic);
                    UnFrmCotizaciones.EventoActualizarDetalles += new frmCotizaciones.DelegaActualizarSolicDetalles(ActualizarDetallesSolicitud);
                    UnFrmCotizaciones.Show();
                }
            }
        }



        public void ActualizarDetallesSolicitud(List<Cotizacion> unasCotiza, int IdSolDet)
        {
            //Actualizo las cotizaciones en el objeto instanciado en el frmSolicitudModificar
            unaSolicitud.unosDetallesSolicitud.First(X => X.IdSolicitudDetalle == IdSolDet).unasCotizaciones = unasCotiza;

            //Actualiza el conteo de cotizaciones del detalle modificado en frmcotizaciones
            grillaDetalles.Rows[IdSolDet - 1].Cells["txtCotizConteo"].Value = unaSolicitud.unosDetallesSolicitud[IdSolDet - 1].unasCotizaciones.Count().ToString();
            if (unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == IdSolDet).FirstOrDefault().unEstado.IdEstadoSolicDetalle < (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Partida)
            {
                if (unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == IdSolDet).FirstOrDefault().unasCotizaciones.Count() > 2)
                {
                    //Actualizo el estado en el objeto en memoria
                    unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == IdSolDet).FirstOrDefault().unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado;
                    unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == IdSolDet).FirstOrDefault().unEstado.DescripEstadoSolicDetalle = "Cotizado";
                    //Actualizo en la grilla el estado con un objeto auxiliar porque sino, no lo hacía en tiempo real
                    EstadoSolicDetalle EstadoAUX = new EstadoSolicDetalle();
                    EstadoAUX.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado;
                    EstadoAUX.DescripEstadoSolicDetalle = "Cotizado";
                    grillaDetalles.Rows[IdSolDet - 1].Cells["unEstado"].Value = EstadoAUX;
                }
                else
                {
                    unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == IdSolDet).FirstOrDefault().unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente;
                    unaSolicitud.unosDetallesSolicitud.Where(X => X.IdSolicitudDetalle == IdSolDet).FirstOrDefault().unEstado.DescripEstadoSolicDetalle = "Pendiente";
                    //Actualizo en la grilla el estado con un objeto auxiliar porque sino, no lo hacía en tiempo real
                    EstadoSolicDetalle EstadoAUX = new EstadoSolicDetalle();
                    EstadoAUX.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente;
                    EstadoAUX.DescripEstadoSolicDetalle = "Pendiente";
                    grillaDetalles.Rows[IdSolDet - 1].Cells["unEstado"].Value = EstadoAUX;
                }
            }
            this.BringToFront();
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Revise que los detalles posean al menos 3 cotizaciones y estén en estado Cotizado").Texto);
                }
            }
            else
            {
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Revise que los detalles posean al menos 3 cotizaciones").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No hay bienes listos para ser entregados").Texto);
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
            cboTipoBien.SelectedIndex = (int)TipoBien.EnumTipoBien.Hard - 1;
            txtBien.Clear();
            AuxTipoCategoria = 1;
            txtCantBien.Clear();
            txtAgente.Clear();
            if (unAgen != null)
                unosAgentesAsociados.Remove(unAgen);
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

            if ((int)cboTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Hard)//Hardware
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
            if ((int)cboTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Soft)//Software
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
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El agente ").Texto + unAgen.NombreAgente + " " + unAgen.ApellidoAgente + " " + BLLServicioIdioma.MostrarMensaje("ya se encuentra asociado a este software").Texto
);
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
                        //if ((unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { unSolDet = o, Index = i }).Where(item => item.unSolDet.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).FirstOrDefault().unSolDet.Cantidad += unDetalleSolicitud.Cantidad) > 0) Antiguo
                        //if ((unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { unSolDet = o, Index = i }).FirstOrDefault(item => item.unSolDet.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).unSolDet.Cantidad += unDetalleSolicitud.Cantidad) > 0) Antiguo
                        var SolDetDic = unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { unSolDet = o, Index = i }).Where(item => item.unSolDet.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).FirstOrDefault();
                        if (SolDetDic != null)
                        {
                            if (AuxTipoCategoria == 2)//Tipo Software
                            {
                                //Le Agrego los nuevos agentes
                                foreach (Agente unAgen in unosAgentesAsociados)
                                {
                                    SolDetDic.unSolDet.unosAgentes.Add(unAgen);
                                }
                                SolDetDic.unSolDet.Cantidad = SolDetDic.unSolDet.unosAgentes.Count();
                            }
                            else
                            {
                                SolDetDic.unSolDet.Cantidad += unDetalleSolicitud.Cantidad;
                            }
                            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                            if (grillaDetalles.Columns.Contains("btnDinBorrar"))
                                grillaDetalles.Columns.Remove("btnDinBorrar");
                            if (grillaDetalles.Columns.Contains("txtCotizConteo"))
                                grillaDetalles.Columns.Remove("txtCotizConteo");
                            if (grillaDetalles.Columns.Contains("btnDinCotizar"))
                                grillaDetalles.Columns.Remove("btnDinCotizar");

                            //Regenero la grilla
                            grillaDetalles.DataSource = null;
                            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
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
                            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
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
                        AgregarDetalleConfirmado(ref unDetalleSolicitud);
                    //else
                    //{
                        //BLLPolitica ManagerPolitica = new BLLPolitica();
                        //if (ManagerPolitica.VerificarPolitica(unaSolicitud.laDependencia.IdDependencia, unDetalleSolicitud.unaCategoria.IdCategoria, unDetalleSolicitud.Cantidad))
                        //{
                            //AgregarDetalleConfirmado(ref unDetalleSolicitud);
                        //}
                        //else
                        //{
                            //DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Mensaje1").Texto, BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                            //if (resmbox == DialogResult.Yes)
                            //{
                                //AgregarDetalleConfirmado(ref unDetalleSolicitud);
                            //}
                        //}
                    //}
                }
            }

}



        private void AgregarDetalleConfirmado(ref SolicDetalle unDetSolic)
        {

            //Conteo Detalles
            ContDetalles = unaSolicitud.unosDetallesSolicitud.Count();
            unDetSolic.IdSolicitudDetalle = ++ContDetalles;

            if (AuxTipoCategoria == (int)TipoBien.EnumTipoBien.Soft)
                unDetSolic.unosAgentes = (List<Agente>)unosAgentesAsociados.ToList();
            unDetSolic.unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente;
            unDetSolic.unEstado.DescripEstadoSolicDetalle = "Pendiente";
            unaSolicitud.unosDetallesSolicitud.Add(unDetSolic);

            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            if (grillaDetalles.Columns.Contains("btnDinBorrar"))
                grillaDetalles.Columns.Remove("btnDinBorrar");
            if (grillaDetalles.Columns.Contains("txtCotizConteo"))
                grillaDetalles.Columns.Remove("txtCotizConteo");
            if (grillaDetalles.Columns.Contains("btnDinCotizar"))
                grillaDetalles.Columns.Remove("btnDinCotizar");

            //Regenero la grilla
            grillaDetalles.DataSource = null;
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
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
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
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
            if (unosAdjuntos.Count > 0)
            {
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No puede adjuntarse más de 1 archivo").Texto);
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
                        pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;

                        //Añado a la grilla el nombre del archivo
                        unosAdjuntos.Add(NombreArchivo);
                        unosAdjuntosRutas.Add(item);
                        lstAdjuntos.DataSource = null;
                        lstAdjuntos.DataSource = unosAdjuntos;

                        //GrillaAdjuntos.Columns[0].HeaderText = "Archivos";

                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El archivo ").Texto + "\"" + NombreArchivo + "\"" + BLLServicioIdioma.MostrarMensaje(" no tiene una extensión válida (jpg, png, bmp, pdf, txt)").Texto);
                    }
                }
            }
        }



        //Estilo que se aplica cuando se sale de pnladjuntos (en el evento de arrastrar archivos)
        private void pnlAdjuntos_DragLeave(object sender, EventArgs e)
        {
            pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnEliminarAdjunto_Click(object sender, EventArgs e)
        {
            if (lstAdjuntos.DataSource != null)
            {
                unosAdjuntos.Clear();
                unosAdjuntosRutas.Clear();
                lstAdjuntos.DataSource = null;
                lstAdjuntos.Items.Clear();
                NombreAdjunto = null;
                RutaCompletaAdjuntoGuardado = null;
            }
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            if (validNota.Validate())
            {
                Nota unaNota = new Nota();
                unaNota.FechaNota = DateTime.Now;
                unaNota.DescripNota = txtNota.Text;
                unasNotasAgregar.Add(unaNota);
                unasNotas.Add(unaNota);
                GrillaNotas.DataSource = null;
                GrillaNotas.DataSource = unasNotas;
                FormatearNotas();
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
                 PartidaDetalle unaPartDet = new PartidaDetalle();
                //Compruebo que no tenga partidas asociadas
                 unaPartDet = ManagerPartidaDetalle.SolicDetallePartidaDetalleAsociacionTraer(unaSolicitud.IdSolicitud, DetalleSeleccionado, unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado).UIDSolicDetalle);
                if (unaPartDet.IdPartida == 0)
                {
                    SolicDetalle unDetalleSolicitud = new SolicDetalle();
                    unDetalleSolicitud.unaCategoria = unaCat;

                    if (validCantBien.Validate() && Int32.Parse(txtCantBien.Text) > 0)
                    {
                        unDetalleSolicitud.Cantidad = Int32.Parse(txtCantBien.Text);

                        //Verifica si ya hay un detalle para sumarle cantidad y así no haya Bienes repetidos en distintos detalles
                        if (unaSolicitud.unosDetallesSolicitud.Find(RR => RR.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria) != null)//SI YA HAY UN DETALLE
                        {
                            var SolDetDic = unaSolicitud.unosDetallesSolicitud.Select((o, i) => new { unSolDet = o, Index = i }).Where(item => item.unSolDet.unaCategoria.IdCategoria == unDetalleSolicitud.unaCategoria.IdCategoria).FirstOrDefault();
                            if (SolDetDic != null)
                            {
                                if (AuxTipoCategoria == 2)//Categoria de Software
                                {
                                    //Cargo los agentes que ya había (es diferente de btnAgregarDetalle_Click porque aca esta en memoria ya)
                                    unDetalleSolicitud.unosAgentes = (List<Agente>)unosAgentesAsociados.ToList();
                                    SolDetDic.unSolDet.Cantidad = unDetalleSolicitud.unosAgentes.Count();
                                }
                                else
                                {
                                    SolDetDic.unSolDet.Cantidad = Int32.Parse(txtCantBien.Text);
                                }
                                //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                                if (grillaDetalles.Columns.Contains("btnDinBorrar"))
                                    grillaDetalles.Columns.Remove("btnDinBorrar");
                                if (grillaDetalles.Columns.Contains("txtCotizConteo"))
                                    grillaDetalles.Columns.Remove("txtCotizConteo");
                                if (grillaDetalles.Columns.Contains("btnDinCotizar"))
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
                                deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                                deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                                deleteButton.UseColumnTextForButtonValue = true;
                                grillaDetalles.Columns.Add(deleteButton);

                                grillaDetallesFormatoAplicar();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El detalle está asociado a la Partida Nro: ").Texto + unaPartDet.IdPartida + BLLServicioIdioma.MostrarMensaje(", no puede modificarse").Texto);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ////elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            //grillaDetalles.Columns.Remove("btnDinBorrar");
            //grillaDetalles.Columns.Remove("txtCotizConteo");
            //grillaDetalles.Columns.Remove("btnDinCotizar");
            //grillaDetalles.DataSource = null;
            //frmSolicitudModificar_Load(this, new EventArgs());
            //txtBien.Clear();
            //txtCantBien.Clear();
            //txtNota.Clear();
            //GrillaNotas.DataSource = null;
            //unosAdjuntos.Clear();
            //unasNotas.Clear();
            //GrillaAdjuntos.DataSource = null;
            //flagDetEliminado = false;


            BLLPartida ManagerPartida = new BLLPartida();
            List<Partida> unaListaPartidas = new List<Partida>();
            try
            {
                //Verificar que no existan Partidas Asociadas (que no esten canceladas)
                unaListaPartidas = ManagerPartida.PartidasBuscarPorIdSolicitud(unaSolicitud.IdSolicitud);
                if (unaListaPartidas != null && unaListaPartidas.Count > 0)
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La solicitud no puede ser cancelada porque contiene Partidas asociadas").Texto);
                    return;
                }
                DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja la Solicitud: ").Texto + unaSolicitud.IdSolicitud.ToString() + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                if (resmbox == DialogResult.Yes)
                {
                    if (ManagerSolicitud.SolicitudCancelar(unaSolicitud))
                    {
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Eliminar Solicitud").Texto, BLLServicioIdioma.MostrarMensaje("Solicitud Nro ").Texto + unaSolicitud.IdSolicitud.ToString());
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Solicitud cancelada correctamente").Texto);
                        //Grisear todo
                        cboEstadoSolicitud.SelectedValue = (int)EstadoSolicitud.EnumEstadoSolicitud.Cancelada;
                        unaSolicitud.UnEstado = new EstadoSolicitud() { IdEstadoSolicitud = (int)EstadoSolicitud.EnumEstadoSolicitud.Cancelada, DescripEstadoSolic = "Cancelada" };
                        foreach (DataGridViewRow unDetFila in grillaDetalles.Rows)
                        {
                            EstadoSolicDetalle unEsta = new EstadoSolicDetalle();
                            unEsta.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cancelado;
                            unEsta.DescripEstadoSolicDetalle = "Cancelado";
                            unDetFila.Cells["unEstado"].Value = unEsta;
                        }
                        unaSolicitud.FechaFin = DateTime.Today;
                        txtFechaFin.Text = unaSolicitud.FechaFin.ToString();
                        //Coloca todos los detalles en Cancelado
                        foreach (SolicDetalle unSolicDet in unaSolicitud.unosDetallesSolicitud)
                        {
                            unSolicDet.unEstado = new EstadoSolicDetalle() { IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cancelado, DescripEstadoSolicDetalle = "Cancelado" };
                        }
                        btnAgregarDetalle.Enabled = false;
                        btnNuevoDetalle.Enabled = false;
                        btnModificar.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnSolicitarPartida.Enabled = false;
                        btnBienAsignar.Enabled = false;
                        grillaDetalles.Enabled = false;
                        btnNotas.Enabled = false;
                        btnModifSolicitud.Enabled = false;
                        btnAsociarAgente.Enabled = false;

                        this.Close();
                    }
                }
                else
                    return;

            }
            //catch (InvalidOperationException es)
            //{
            //    MessageBox.Show("Ocurrio un error al intentar modificar la solicitud, por favor informe del error Nro " + es.Data["IdLog"] + " del Log de Eventos");
            //}
            catch (Exception es)
            {
                string IdError;
                if (es.Data.Contains("IdLog"))
                    IdError = es.Data["IdLog"].ToString();
                else
                    IdError = ServicioLog.CrearLog(es, "frmSolicitudModificar - btnCancelar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar cancelar la Solicitud: ").Texto + unaSolicitud.IdSolicitud.ToString() + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }



        }

        /// <summary>
        /// Handles the Click event of the btnModifSolicitud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnModifSolicitud_Click(object sender, EventArgs e)
        {
            List<SolicDetalle> unosSolDetQuitarMod = new List<SolicDetalle>();
            List<SolicDetalle> unosSolDetAgregarMod = new List<SolicDetalle>();
            List<SolicDetalle> unosSolDetModifMod = new List<SolicDetalle>();

            //VER:AGREGAR LOS ADJUNTOS
            //VER: Validaciones

            try
            {
                //Verificar que quede por lo menos un SolicDetalle
                if (unaSolicitud.unosDetallesSolicitud.Count == 0)
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revisar que la Solicitud posea al menos un detalle").Texto);
                    return;
                }

                //Verificar que haya un adjunto
                if (unosAdjuntos.Count != 1)
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor adjuntar el oficio de la solicitud realizada").Texto);
                    return;
                }

                unaSolicitud.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                unaSolicitud.UnaPrioridad = (Prioridad)cboPrioridad.SelectedItem;
                unaSolicitud.Asignado = (Usuario)cboAsignado.SelectedItem;

                unaSolicitud.UnEstado = (EstadoSolicitud)cboEstadoSolicitud.SelectedItem;
                unaSolicitud.AgenteResp = (Agente)cboAgenteResp.SelectedItem;
                if (unasNotasAgregar.Count > 0)
                {
                    unaSolicitud.unasNotas = (List<Nota>)this.unasNotasAgregar.ToList();
                }

                unosSolDetQuitarMod = unosSolicDetAgregarBKP.Where(d => !unaSolicitud.unosDetallesSolicitud.Any(a => a.UIDSolicDetalle == d.UIDSolicDetalle)).ToList();
                unosSolDetAgregarMod = unaSolicitud.unosDetallesSolicitud.Where(d => !unosSolicDetAgregarBKP.Any(a => a.UIDSolicDetalle == d.UIDSolicDetalle)).ToList();
                unosSolDetModifMod = unaSolicitud.unosDetallesSolicitud.Where(d => !unosSolDetAgregarMod.Any(a => a.UIDSolicDetalle == d.UIDSolicDetalle)).ToList();

                string ext = Path.GetExtension(unosAdjuntosRutas.First()).ToLower();

                if (ManagerSolicitud.SolicitudModificar(unaSolicitud, unosSolDetQuitarMod, unosSolDetAgregarMod, unosSolDetModifMod, unosSolicDetAgregarBKP, @FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Solicitud " + unaSolicitud.IdSolicitud.ToString() + ext))
                {
                    //Guardo el archivo adjunto
                    if (unosAdjuntos.Count > 0)
                    {
                        if (RutaCompletaAdjuntoGuardado == null)
                            FRAMEWORK.Servicios.ManejoArchivos.CopiarArchivo(unosAdjuntosRutas.First(), @FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Solicitud " + unaSolicitud.IdSolicitud.ToString() + ext);
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Modificar Solicitud").Texto, BLLServicioIdioma.MostrarMensaje("Solicitud Nro ").Texto + unaSolicitud.IdSolicitud.ToString());
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada correctamente").Texto);
                    }

                }
            }
            //catch (InvalidOperationException es)
            //{
            //    MessageBox.Show("Ocurrio un error al intentar modificar la solicitud, por favor informe del error Nro " + es.Data["IdLog"] + " del Log de Eventos");
            //}
            catch (Exception es)
            {
                string IdError;
                if (es.Data.Contains("IdLog"))
                    IdError = es.Data["IdLog"].ToString();
                else
                    IdError = ServicioLog.CrearLog(es, "btnModifSolicitud_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar la solicitud, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }

           
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

        private void cboAsignado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<Usuario> unosUsuarios2 = new List<Usuario>();
            unosUsuarios2 = ManagerUsuario.UsuarioTraerTodosActivos();
            if (unosUsuarios2.Count < unosUsuarios.Count)
            {
                if ((cboAsignado.SelectedItem as Usuario).IdUsuario == unaSolicitud.Asignado.IdUsuario)
                {
                    lblInactivo.Visible = true;
                }
                else
                {
                    lblInactivo.Visible = false;
                }
            }
            
        }

        private void frmSolicitudModificar_FormClosing(object sender, FormClosingEventArgs e)
        {
            _unfrmSolicitudModificarInst.Remove(this);
        }

        private void lstAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            if (NombreAdjunto != null)
            {
                using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
                {
                    string RutaCompletaAdjunto = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + NombreAdjunto;
                    proc.StartInfo.FileName = RutaCompletaAdjunto;
                    proc.Start();
                    proc.Close();
                }
                
            }
            
        }










    }
}