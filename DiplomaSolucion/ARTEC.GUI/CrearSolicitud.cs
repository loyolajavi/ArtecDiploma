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
    public partial class CrearSolicitud : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Solicitud unaSolicitud;
        Dependencia unaDep;
        Categoria unaCat;
        Agente unAgen;
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        List<Categoria> unasCategoriasHard;
        List<Categoria> unasCategoriasSoft;
        int AuxTipoCategoria = 1;
        List<Agente> unosAgentes;
        List<Agente> unosAgentesAsociados;
        List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
        List<Prioridad> unasPrioridades = new List<Prioridad>();
        int ContDetalles = 0;
        List<Usuario> unosUsuarios = new List<Usuario>();
        List<Agente> unosAgentesResp;
        List<string> unosAdjuntosNombre = new List<string>();
        List<string> unosAdjuntosRutas = new List<string>();
        BLLTipoBien managerTipoBienAux = new BLLTipoBien();
        SolicDetalle unDetSolic;
        BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
        BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
        int DetalleSeleccionado = 1;
        List<Nota> unasNotas = new List<Nota>();
        List<Nota> unasNotasAgregar = new List<Nota>();


        public CrearSolicitud()
        {
            InitializeComponent();
            unaSolicitud = new Solicitud();

            Dictionary<string, string[]> dicCrearSolicitud = new Dictionary<string, string[]>();
            string[] IdiomaCrearSolicitud = { "Crear Solicitud" };
            dicCrearSolicitud.Add("Idioma", IdiomaCrearSolicitud);
            this.Tag = dicCrearSolicitud;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblAgenteResponsable = new Dictionary<string, string[]>();
            string[] IdiomalblAgenteResponsable = { "Responsable" };
            diclblAgenteResponsable.Add("Idioma", IdiomalblAgenteResponsable);
            this.lblAgenteResponsable.Tag = diclblAgenteResponsable;

            Dictionary<string, string[]> diclabelX5 = new Dictionary<string, string[]>();
            string[] IdiomalabelX5 = { "Creación" };
            diclabelX5.Add("Idioma", IdiomalabelX5);
            this.labelX5.Tag = diclabelX5;

            Dictionary<string, string[]> dicgboxBienes = new Dictionary<string, string[]>();
            string[] IdiomagboxBienes = { "Agregar Bienes" };
            dicgboxBienes.Add("Idioma", IdiomagboxBienes);
            this.gboxBienes.Tag = dicgboxBienes;

            Dictionary<string, string[]> diclblCantidad = new Dictionary<string, string[]>();
            string[] IdiomalblCantidad = { "Cantidad" };
            diclblCantidad.Add("Idioma", IdiomalblCantidad);
            this.lblCantidad.Tag = diclblCantidad;

            Dictionary<string, string[]> dicgboxAsociados = new Dictionary<string, string[]>();
            string[] IdiomagboxAsociados = { "Agentes asociados" };
            dicgboxAsociados.Add("Idioma", IdiomagboxAsociados);
            this.gboxAsociados.Tag = dicgboxAsociados;

            Dictionary<string, string[]> diclabelX2 = new Dictionary<string, string[]>();
            string[] IdiomalabelX2 = { "Agente" };
            diclabelX2.Add("Idioma", IdiomalabelX2);
            this.labelX2.Tag = diclabelX2;

            Dictionary<string, string[]> dicbtnNuevoDetalle = new Dictionary<string, string[]>();
            string[] IdiomabtnNuevoDetalle = { "Nuevo Detalle" };
            dicbtnNuevoDetalle.Add("Idioma", IdiomabtnNuevoDetalle);
            this.btnNuevoDetalle.Tag = dicbtnNuevoDetalle;

            Dictionary<string, string[]> dicbtnAsociarAgente = new Dictionary<string, string[]>();
            string[] IdiomabtnAsociarAgente = { "Asociar" };
            dicbtnAsociarAgente.Add("Idioma", IdiomabtnAsociarAgente);
            this.btnAsociarAgente.Tag = dicbtnAsociarAgente;

            Dictionary<string, string[]> dictxtAgregarDetalle = new Dictionary<string, string[]>();
            string[] IdiomatxtAgregarDetalle = { "Agregar" };
            dictxtAgregarDetalle.Add("Idioma", IdiomatxtAgregarDetalle);
            this.btnAgregarDetalle.Tag = dictxtAgregarDetalle;

            Dictionary<string, string[]> dicbtnEliminarAdjunto = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminarAdjunto = { "Quitar" };
            dicbtnEliminarAdjunto.Add("Idioma", IdiomabtnEliminarAdjunto);
            this.btnEliminarAdjunto.Tag = dicbtnEliminarAdjunto;

            Dictionary<string, string[]> diclabelX8 = new Dictionary<string, string[]>();
            string[] IdiomalabelX8 = { "Estado" };
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

            Dictionary<string, string[]> dicgboxNotas = new Dictionary<string, string[]>();
            string[] IdiomagboxNotas = { "Notas" };
            dicgboxNotas.Add("Idioma", IdiomagboxNotas);
            this.gboxNotas.Tag = dicgboxNotas;

            Dictionary<string, string[]> dicbtnNotas = new Dictionary<string, string[]>();
            string[] IdiomabtnNotas = { "Agregar" };
            dicbtnNotas.Add("Idioma", IdiomabtnNotas);
            this.btnNotas.Tag = dicbtnNotas;

            Dictionary<string, string[]> dicbtnCrearSolicitud = new Dictionary<string, string[]>();
            string[] IdiomabtnCrearSolicitud = { "Crear Solicitud" };
            dicbtnCrearSolicitud.Add("Idioma", IdiomabtnCrearSolicitud);
            this.btnCrearSolicitud.Tag = dicbtnCrearSolicitud;

            Dictionary<string, string[]> dicbtnExaminar = new Dictionary<string, string[]>();
            string[] IdiomabtnExaminar = { "Examinar" };
            dicbtnExaminar.Add("Idioma", IdiomabtnExaminar);
            this.btnExaminar.Tag = dicbtnExaminar;

            

        }



        //Agregar Detalle Click
        private void txtAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (validDependencia.Validate() && ValidDep2.Validate() && validBien.Validate())
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

                            //Regenero la grilla
                            grillaDetalles.DataSource = null;
                            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;

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
            unDetSolic.unEstado.IdEstadoSolicDetalle = (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Pendiente;//GUARDA REVISAR ESTO en soft tmb
            unDetSolic.unEstado.DescripEstadoSolicDetalle = "Pendiente";
            unaSolicitud.unosDetallesSolicitud.Add(unDetSolic);

            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            if (grillaDetalles.Columns.Contains("btnDinBorrar"))
                grillaDetalles.Columns.Remove("btnDinBorrar");

            //Regenero la grilla
            grillaDetalles.DataSource = null;
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            
            //Vuelve a agregar el botón de borrar al final
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaDetalles.Columns.Add(deleteButton);

            grillaDetallesFormatoAplicar();

        }





        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            //Traducir
            BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            ///Traigo Dependencias para busqueda dinámica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

            ///Para poder seleccionar Hard o Soft
            BLLTipoBien ManagerTipoBien = new BLLTipoBien();
            unosTipoBien = ManagerTipoBien.TraerTodos();
            cboTipoBien.DataSource = null;
            cboTipoBien.DataSource = unosTipoBien;
            cboTipoBien.DisplayMember = "DescripTipoBien";
            cboTipoBien.ValueMember = "IdTipoBien";

            //Traigo categorias para dps filtrar por hard o soft
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategoriasHard = new List<Categoria>();
            unasCategoriasHard = ManagerCategoria.CategoriaTraerTodosHardActivos();
            unasCategoriasSoft = new List<Categoria>();
            unasCategoriasSoft = ManagerCategoria.CategoriaTraerTodosSoftActivos();

            unosAgentesAsociados = new List<Agente>();


            ///Traer Estados Solicitud
            BLLEstadoSolicitud ManagerEstadoSolicitud = new BLLEstadoSolicitud();
            unosEstadoSolicitud = ManagerEstadoSolicitud.EstadoSolicitudTraerTodos();
            foreach (EstadoSolicitud unEstSolic in unosEstadoSolicitud)
            {
                if (!string.IsNullOrWhiteSpace(unEstSolic.DescripEstadoSolic))
                    unEstSolic.DescripEstadoSolic = BLLServicioIdioma.MostrarMensaje(unEstSolic.DescripEstadoSolic).Texto;
            }
            cboEstadoSolicitud.DataSource = null;
            cboEstadoSolicitud.DataSource = unosEstadoSolicitud;
            cboEstadoSolicitud.DisplayMember = "DescripEstadoSolic";
            cboEstadoSolicitud.ValueMember = "IdEstadoSolicitud";



            ///Traer Prioridad
            BLLPrioridad ManagerPrioridad = new BLLPrioridad();
            unasPrioridades = ManagerPrioridad.PrioridadTraerTodos();
            cboPrioridad.DataSource = null;
            cboPrioridad.DataSource = unasPrioridades;
            cboPrioridad.DisplayMember = "DescripPrioridad";
            cboPrioridad.ValueMember = "IdPrioridad";

            //Traer UsuariosSistema
            BLLUsuario ManagerUsuario = new BLLUsuario();
            unosUsuarios = ManagerUsuario.UsuarioTraerTodosActivos();
            cboAsignado.DataSource = null;
            cboAsignado.DataSource = unosUsuarios;
            cboAsignado.DisplayMember = "NombreUsuario";
            cboAsignado.ValueMember = "IdUsuario";

            //Cargar fecha Inicio
            txtFechaInicio.MaxDate = DateTime.Today;
            txtFechaInicio.Text = DateTime.Today.ToString("d");
            

            
        }



        //Busqueda dinámica de Dependencias
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                //AGREGAR QUE SE ELIMINEN los detalles de USUARIOS ASOCIADOS en soft AL CAMBIAR LA FISCALIA (SIN TENER DETALLES AGREGADOS)
                if (grillaDetalles.DataSource != null)
                {
                    DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Si cambia de Fiscalía se eliminarán los detalles").Texto, BLLServicioIdioma.MostrarMensaje("Confirmar").Texto, MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        //Elimino los datos que hayan quedado escritos para agregar detalles
                        txtAgente.Clear();
                        txtBien.Clear();
                        cboTipoBien.Refresh();
                        grillaDetalles.DataSource = null;
                        grillaAgentesAsociados.DataSource = null;
                        unaSolicitud.unosDetallesSolicitud.Clear();
                        unosAgentesAsociados.Clear();
                        unosAgentes.Clear();//asi no me aparecen agentes cuando cambio el texto dps de elegir una dependencia
                        //Reseteo el contador de detalles
                        ContDetalles = 0;
                        txtCantBien.Clear();
                        BusquedaDependencias();
                    }
                    else if (resmbox == DialogResult.No)
                    {
                        textBoxX1.Text = unaDep.NombreDependencia;
                        textBoxX1.SelectionStart = textBoxX1.Text.Length + 1;
                    }
                }
                else
                {
                    BusquedaDependencias();
                }
            }
            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
            }
        }



        private void BusquedaDependencias()
        {
            List<Dependencia> res = new List<Dependencia>();
            res = (List<Dependencia>)unasDependencias.ToList();

            List<string> Palabras = new List<string>();
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                //ESTO ERA PARA QUE NO QUEDE FLASHADO EL CBOBOX AL PASAR DE MUCHOS RESULTADOS RESULTADO A UNO SOLO AL ESCRIBIR LA FISCALIA JUSTA A MANO, PERO HACIA QUE NO SE EJECUTE BIEN LO DE CARGAR LOS AGENTES
                //if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                //{
                //    //comboBoxEx4.Visible = false;
                //    //comboBoxEx4.DroppedDown = false;
                //    //comboBoxEx4.DataSource = null;

                //}
                //else
                //{
                comboBoxEx4.DataSource = null;
                comboBoxEx4.DataSource = res;
                comboBoxEx4.DisplayMember = "NombreDependencia";
                comboBoxEx4.ValueMember = "IdDependencia";
                comboBoxEx4.Visible = true;
                comboBoxEx4.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                //}
            }
            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
                //unosAgentes = null;//asi no me aparecen agentes cuando cambio el texto dps de elegir una dependencia
            }
        }



        //Al seleccionar una dependencia del combo, guarda el idDependencia, el nombre y cierra el combo
        private void comboBoxEx4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                if (comboBoxEx4.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    unaDep = new Dependencia();
                    unaDep = (Dependencia)cbo.SelectedItem;
                    this.textBoxX1.TextChanged -= new System.EventHandler(this.textBoxX1_TextChanged);
                    textBoxX1.Text = cbo.GetItemText(cbo.SelectedItem);
                    this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
                    textBoxX1.SelectionStart = textBoxX1.Text.Length + 1;

                    //Traer los agentes de la dependencia seleccionada
                    BLLDependencia managerDependenciaAg = new BLLDependencia();
                    unosAgentes = new List<Agente>();
                    unosAgentes = managerDependenciaAg.TraerAgentesDependencia(unaDep.IdDependencia);


                    unosAgentesResp = new List<Agente>();
                    unosAgentesResp = managerDependenciaAg.TraerAgentesResp(unaDep.IdDependencia);
                    cboAgenteResp.DataSource = null;
                    cboAgenteResp.DataSource = unosAgentesResp;
                    cboAgenteResp.DisplayMember = "ApellidoAgente";
                    cboAgenteResp.ValueMember = "IdAgente";
                    //Elimino los datos que hayan quedado escritos para agregar detalles
                    unosAgentesAsociados.Clear();
                    grillaAgentesAsociados.DataSource = null;
                    txtAgente.Clear();
                    txtBien.Clear();
                    txtCantBien.Clear();
                    cboTipoBien.Refresh();
                    //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
                    ValidDep2.Validate();
                    txtAgente.Clear();

                }
            }
        }



        /// <summary>
        /// Habilitar Controles según Hard/Soft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (ValidDep2.Validate())
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
            if (ValidDep2.Validate())
            {
                if (validAgenteAsoc.Validate())
                {
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
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El agente ").Texto + unAgen.NombreAgente + " " + unAgen.ApellidoAgente + " " + BLLServicioIdioma.MostrarMensaje("ya se encuentra asociado a este software").Texto);
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

        }



        private void customValidatorDependencia_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                e.IsValid = false;
            }
            else
            {
                if (unaDep != null && string.Equals(e.ControlToValidate.Text, unaDep.NombreDependencia))
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }

        }


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
                PartidaDetalle unaPartDet = new PartidaDetalle();
                //Compruebo que no tenga partidas asociadas
                unaPartDet = ManagerPartidaDetalle.SolicDetallePartidaDetalleAsociacionTraer(unaSolicitud.IdSolicitud, unaSolicitud.unosDetallesSolicitud[e.RowIndex].IdSolicitudDetalle, unaSolicitud.unosDetallesSolicitud[e.RowIndex].UIDSolicDetalle);
                if (unaPartDet.PartidaAsociada.IdPartida == 0)
                {
                    //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                    grillaDetalles.Columns.RemoveAt(e.ColumnIndex);

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

                    //Vuelve a agregar el botón de borrar al final
                    var deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = "btnDinBorrar";
                    deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                    deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                    deleteButton.UseColumnTextForButtonValue = true;
                    grillaDetalles.Columns.Add(deleteButton);

                    grillaDetallesFormatoAplicar();

                    //Limpio el formulario en donde aparecen los datos de carga de soft y hard
                    grillaAgentesAsociados.DataSource = null;
                    txtAgente.Clear();
                    txtBien.Clear();
                    txtCantBien.Clear();
                }
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El detalle está asociado a la Partida Nro: ").Texto + unaPartDet.PartidaAsociada.IdPartida + BLLServicioIdioma.MostrarMensaje(", no puede eliminarse").Texto);
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
                TipoBien unTipoBienAux = new TipoBien();
                BLLTipoBien managerTipoBienAux = new BLLTipoBien();
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
                    //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
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
                    //unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
                    grillaAgentesAsociados.DataSource = null;
                    if (unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes.Count() > 0)
                    {
                        grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes;
                    }
                    else
                    {
                        grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.Find(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes = ManagerSolicDetalle.SolicDetallesTraerAgentesAsociados(DetalleSeleccionado, unaSolicitud.IdSolicitud, unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado).UIDSolicDetalle);
                    }
                    //No mostrar columnas que no necesito de los agentes asociados
                    grillaAgentesAsociados.Columns[0].Visible = false;
                    grillaAgentesAsociados.Columns[3].Visible = false;
                    grillaAgentesAsociados.Columns[4].Visible = false;
                }
            }
}


        //FIJARSE QUE NO VALIDA SI CANTIDAD ES 0
        private void customValidatorBien_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void btnCrearSolicitud_Click(object sender, EventArgs e)
        {

            try
            {
                //VER:AGREGAR LOS ADJUNTOS
                //VER: Validaciones

                if (ValidDep2.Validate())
                {
                    //Verificar que haya por lo menos un SolicDetalle
                    if (unaSolicitud.unosDetallesSolicitud.Count == 0)
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revisar que la Solicitud posea al menos un detalle").Texto);
                        return;
                    }

                    //Verificar que haya un adjunto
                    if (unosAdjuntosNombre.Count != 1)
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor adjuntar el oficio de la solicitud realizada").Texto);
                        return;
                    }

                    unaSolicitud.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                    unaSolicitud.laDependencia = unaDep;
                    unaSolicitud.UnaPrioridad = (Prioridad)cboPrioridad.SelectedItem;
                    unaSolicitud.Asignado = (Usuario)cboAsignado.SelectedItem;
                    unaSolicitud.UnEstado = (EstadoSolicitud)cboEstadoSolicitud.SelectedItem;
                    unaSolicitud.AgenteResp = (Agente)cboAgenteResp.SelectedItem;
                    if (unasNotasAgregar != null)
                    {
                        unaSolicitud.unasNotas = (List<Nota>)this.unasNotasAgregar.ToList();
                    }

                    BLLSolicitud ManagerSolicitud = new BLLSolicitud();
                    string ext = Path.GetExtension(unosAdjuntosRutas.First()).ToLower();
                    ManagerSolicitud.SolicitudCrear(unaSolicitud, ext);
                    //Guardo el archivo adjunto
                    if (unosAdjuntosNombre.Count > 0)
                    {
                        FRAMEWORK.Servicios.ManejoArchivos.CopiarArchivo(unosAdjuntosRutas.First(), @FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Solicitud " + unaSolicitud.IdSolicitud.ToString() + ext);
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Crear Solicitud").Texto, BLLServicioIdioma.MostrarMensaje("Solicitud Nro ").Texto + unaSolicitud.IdSolicitud.ToString());
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Solicitud Nro ").Texto + unaSolicitud.IdSolicitud + BLLServicioIdioma.MostrarMensaje(" creada correctamente").Texto);
                        this.Close();
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnCrearSolicitud_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear la Solicitud, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
            if (unosAdjuntosNombre.Count > 0)
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
                        unosAdjuntosNombre.Add(NombreArchivo);
                        unosAdjuntosRutas.Add(item);

                        lstAdjuntos.DataSource = null;
                        lstAdjuntos.DataSource = unosAdjuntosNombre;

                        //GrillaAdjuntos.Columns[0].HeaderText = "Archivos";

                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El archivo ").Texto + "\"" + NombreArchivo + "\"" + BLLServicioIdioma.MostrarMensaje(" no tiene una extensión válida (jpg, png, bmp, pdf, txt)").Texto);
                    }
                    /// BKP/Agarro la ruta de los archivos arrastrados
                    //string[] unArchivo = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                    //foreach (var item in unArchivo)
                    //{
                    //    //Agarro el nombre del archivo
                    //    string NombreArchivo = Path.GetFileName(item);
                    //    if (FRAMEWORK.Servicios.ManejoArchivos.ValidarAdjunto(item))
                    //    {
                    //        //Copio el archivo
                    //        FRAMEWORK.Servicios.ManejoArchivos.CopiarArchivo(item, @"D:\Se pueden borrar sin problemas\ArchivosCopiados\" + NombreArchivo);
                    //        pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;

                    //        //Añado a la grilla el nombre del archivo
                    //        unosAdjuntosNombre.Add(NombreArchivo);

                    //        lstAdjuntos.DataSource = null;
                    //        lstAdjuntos.DataSource = unosAdjuntosNombre;

                    //        //GrillaAdjuntos.Columns[0].HeaderText = "Archivos";

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("El archivo " + "\"" + NombreArchivo + "\"" + " no tiene una extensión válida (jpg, png, bmp, pdf, txt)");
                    //    }
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
                unosAdjuntosNombre.Clear();
                unosAdjuntosRutas.Clear();
                lstAdjuntos.DataSource = null;
                lstAdjuntos.Items.Clear();
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

        private void FormatearNotas()
        {
            GrillaNotas.Columns["IdNota"].Visible = false;
            GrillaNotas.Columns["FechaNota"].HeaderText = BLLServicioIdioma.MostrarMensaje("Fecha").Texto;
            GrillaNotas.Columns["DescripNota"].HeaderText = BLLServicioIdioma.MostrarMensaje("Notas").Texto;
            GrillaNotas.Columns["IdUsuario"].Visible = false;
            GrillaNotas.Columns["IdSolicitud"].Visible = false;
        }




        private void EventValidatetxtAgente(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void EventValidtxtCantBien(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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
            grillaDetalles.Columns["UIDSolicDetalle"].Visible = false;
        }

private void btnModificar_Click(object sender, EventArgs e)
{
    if (!validBien.Validate())
        return;

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

private void CrearSolicitud_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode == Keys.F1)
        Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
}

    private void btnExaminar_Click(object sender, EventArgs e)
    {
        DialogResult Resultado = openFileDialog1.ShowDialog();
        string RutaOrigenCompletaAdjunto = null;
        
        if (unosAdjuntosNombre.Count > 0)
        {
            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No puede adjuntarse más de 1 archivo").Texto);
        }
        else
        {
            //Agarro la ruta del archivo
            if (Resultado == System.Windows.Forms.DialogResult.OK)
            {
                RutaOrigenCompletaAdjunto = openFileDialog1.FileName;
                //Agarro el nombre del archivo
                string NombreArchivo = Path.GetFileName(RutaOrigenCompletaAdjunto);
                if (FRAMEWORK.Servicios.ManejoArchivos.ValidarAdjunto(RutaOrigenCompletaAdjunto))
                {
                    //Añado a la grilla el nombre del archivo
                    unosAdjuntosNombre.Add(NombreArchivo);
                    unosAdjuntosRutas.Add(RutaOrigenCompletaAdjunto);
                    lstAdjuntos.DataSource = null;
                    lstAdjuntos.DataSource = unosAdjuntosNombre;
                    //GrillaAdjuntos.Columns[0].HeaderText = "Archivos";
                }
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El archivo ").Texto + "\"" + NombreArchivo + "\"" + BLLServicioIdioma.MostrarMensaje(" no tiene una extensión válida (jpg, png, bmp, pdf, txt)").Texto);
                }
            }
        }
    }






    }
}