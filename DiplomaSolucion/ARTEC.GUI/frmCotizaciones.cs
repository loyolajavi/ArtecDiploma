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
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmCotizaciones : DevComponents.DotNetBar.Metro.MetroForm
    {
        //Delegado para actualizar DetallesSolicitud en frmSolicitudModificar
        public delegate void DelegaActualizarSolicDetalles(List<Cotizacion> unasCotiz, int IdSolDet);
        //Evento que llama al Delegado
        public event DelegaActualizarSolicDetalles EventoActualizarDetalles;

        List<Cotizacion> unasCotizaciones;
        List<Cotizacion> unasCotizacionesBKP = new List<Cotizacion>();
        List<Proveedor> unosProveedores = new List<Proveedor>();
        List<Proveedor> unosProveedoresSol = new List<Proveedor>();
        Proveedor ProvSeleccionado;
        Proveedor ProvSeleccionadoSol;
        BLLProveedor ManagerProveedor = new BLLProveedor();
        BLLCotizacion ManagerCotizacion = new BLLCotizacion();
        SolicDetalle unDetSolic = new SolicDetalle();
        List<Proveedor> ListaProv = new List<Proveedor>();
        List<string> unosAdjuntosNombre = new List<string>();
        List<string> unosAdjuntosRutas = new List<string>();
        string ext;
        string NombreArchivo;
        string RutaOrigenCompletaAdjunto;
        Dictionary<int, List<string>> DicAdjuntos = new Dictionary<int, List<string>>();
        Dictionary<int, List<string>> DicAdjuntosRutas = new Dictionary<int, List<string>>();

        public frmCotizaciones(List<Cotizacion> unasCotiz, SolicDetalle unDetSolicP)
        {
            InitializeComponent();
            unasCotizaciones = unasCotiz;
            unasCotizacionesBKP = unasCotizaciones.ToList();
            unDetSolic = unDetSolicP;

            
            Dictionary<string, string[]> dicfrmCotizaciones = new Dictionary<string, string[]>();
            string[] IdiomafrmCotizaciones = { "Cotizaciones" };
            dicfrmCotizaciones.Add("Idioma", IdiomafrmCotizaciones);
            this.Tag = dicfrmCotizaciones;

            Dictionary<string, string[]> dictabPage2 = new Dictionary<string, string[]>();
            string[] IdiomatabPage2 = { "Solicitar Cotización" };
            dictabPage2.Add("Idioma", IdiomatabPage2);
            this.tabPage2.Tag = dictabPage2;

            Dictionary<string, string[]> dictabPage1 = new Dictionary<string, string[]>();
            string[] IdiomatabPage1 = { "Agregar Cotización" };
            dictabPage1.Add("Idioma", IdiomatabPage1);
            this.tabPage1.Tag = dictabPage1;

            Dictionary<string, string[]> diclblProvSol = new Dictionary<string, string[]>();
            string[] IdiomalblProvSol = { "Proveedores" };
            diclblProvSol.Add("Idioma", IdiomalblProvSol);
            this.lblProvSol.Tag = diclblProvSol;

            Dictionary<string, string[]> dicbtnAgregarProvSol = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregarProvSol = { "Agregar Proveedor" };
            dicbtnAgregarProvSol.Add("Idioma", IdiomabtnAgregarProvSol);
            this.btnAgregarProvSol.Tag = dicbtnAgregarProvSol;

            Dictionary<string, string[]> diclblAsunto = new Dictionary<string, string[]>();
            string[] IdiomalblAsunto = { "Asunto" };
            diclblAsunto.Add("Idioma", IdiomalblAsunto);
            this.lblAsunto.Tag = diclblAsunto;

            Dictionary<string, string[]> diclblCuerpo = new Dictionary<string, string[]>();
            string[] IdiomalblCuerpo = { "Cuerpo" };
            diclblCuerpo.Add("Idioma", IdiomalblCuerpo);
            this.lblCuerpo.Tag = diclblCuerpo;

            Dictionary<string, string[]> dictxtCuerpo = new Dictionary<string, string[]>();
            string[] IdiomatxtCuerpo = { "Cuerpo" };
            dictxtCuerpo.Add("Idioma", IdiomatxtCuerpo);
            this.txtCuerpo.Tag = dictxtCuerpo;

            Dictionary<string, string[]> dicbtnSolicitar = new Dictionary<string, string[]>();
            string[] IdiomabtnSolicitar = { "Solicitar" };
            dicbtnSolicitar.Add("Idioma", IdiomabtnSolicitar);
            this.btnSolicitar.Tag = dicbtnSolicitar;

            Dictionary<string, string[]> diclblProveedor = new Dictionary<string, string[]>();
            string[] IdiomalblProveedor = { "Proveedor" };
            diclblProveedor.Add("Idioma", IdiomalblProveedor);
            this.lblProveedor.Tag = diclblProveedor;

            Dictionary<string, string[]> diclblPrecioUn = new Dictionary<string, string[]>();
            string[] IdiomalblPrecioUn = { "Precio" };
            diclblPrecioUn.Add("Idioma", IdiomalblPrecioUn);
            this.lblPrecioUn.Tag = diclblPrecioUn;

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;

            Dictionary<string, string[]> dicbtnConfirmar = new Dictionary<string, string[]>();
            string[] IdiomabtnConfirmar = { "Confirmar" };
            dicbtnConfirmar.Add("Idioma", IdiomabtnConfirmar);
            this.btnConfirmar.Tag = dicbtnConfirmar;
        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {

            try
            {
                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos
                //Obtengo todos los controles del formulario
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                grillaCotizacion.DataSource = null;

                unosProveedores = ManagerProveedor.ProveedorTraerTodosActivos();
                unosProveedoresSol = ManagerProveedor.ProveedorTraerTodosActivos();

                if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                {
                    txtCuerpo.Text = "Prueba";
                    txtAsunto.Text = "Cotización MPF";
                }
                else
                {
                    txtCuerpo.Text = "Test";
                    txtAsunto.Text = "MPF Quote";
                }

                if (unasCotizaciones.Count() > 0)
                {
                    //Agregar adjuntos cotizaciones
                    foreach (Cotizacion unaCotizacion in unasCotizaciones)
                    {
                        //Agrega el adjunto
                        if (unaCotizacion.IdCotizacion > 0)
                        {
                            string NombreAdjunto = ManagerCotizacion.ObtenerNombreAdjuntoCotiz(unaCotizacion.IdCotizacion);
                            unaCotizacion.RutaDestinoAdjunto = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + NombreAdjunto;
                            //Añado los adjuntos a los diccionarios
                            //DicAdjuntos.Add(unaCotizacion.IdCotizacion, new List<string> { NombreAdjunto });
                            //DicAdjuntosRutas.Add(unaCotizacion.IdCotizacion, new List<string> { unaCotizacion.RutaDestinoAdjunto });
                            DicAdjuntos.Add(unasCotizaciones.IndexOf(unaCotizacion), new List<string> { NombreAdjunto });
                            DicAdjuntosRutas.Add(unasCotizaciones.IndexOf(unaCotizacion), new List<string> { unaCotizacion.RutaDestinoAdjunto });
                        }
                        else
                        {
                            //Agarro el nombre del archivo
                            string NombreArchivoAux = Path.GetFileName(unaCotizacion.RutaOrigenAdjunto);
                            DicAdjuntos.Add(unasCotizaciones.IndexOf(unaCotizacion), new List<string> { NombreArchivoAux });
                            DicAdjuntosRutas.Add(unasCotizaciones.IndexOf(unaCotizacion), new List<string> { unaCotizacion.RutaOrigenAdjunto });
                        }
                    
                    }
                    grillaCotizacion.DataSource = unasCotizaciones;
                    FormatearGrillaCotizacion();
                }

                ////Añado a la gilla de adjuntos el adjunto de la primer cotización(Solo con el primero por cuestión de que es dinámico)
                //lstAdjuntos.DataSource = null;
                //lstAdjuntos.DataSource = DicAdjuntos[unasCotizaciones[0].IdCotizacion];    
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCotizaciones - frmCotizaciones_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al cargar las cotizaciones, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
            

        }



        //Busqueda Dinamica Proveedores
        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProveedor.Text))
            {

                List<Proveedor> resProv = new List<Proveedor>();
                resProv = unosProveedores;
                
                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtProveedor.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resProv = (List<Proveedor>)(from Prov in resProv
                                                where Prov.AliasProv.ToLower().Contains(unaPalabra.ToLower())
                                               select Prov).ToList();
                }

                if (resProv.Count > 0)
                {
                    if (resProv.Count == 1 && string.Equals(resProv.First().AliasProv, txtProveedor.Text))
                    {
                        cboProveedor.Visible = false;
                        cboProveedor.DroppedDown = false;
                        cboProveedor.DataSource = null;
                    }
                    else
                    {
                        cboProveedor.DataSource = null;
                        cboProveedor.DataSource = resProv;
                        cboProveedor.DisplayMember = "AliasProv";
                        cboProveedor.ValueMember = "IdProveedor";
                        cboProveedor.Visible = true;
                        cboProveedor.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboProveedor.Visible = false;
                    cboProveedor.DroppedDown = false;
                    cboProveedor.DataSource = null;
                }
            }
            else
            {
                cboProveedor.Visible = false;
                cboProveedor.DroppedDown = false;
                cboProveedor.DataSource = null;
            }
        }



        private void cboProovedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProveedor.Text))
            {
                if (cboProveedor.SelectedIndex > -1)
                {
                    ComboBox cbo2 = (ComboBox)sender;
                    ProvSeleccionado = new Proveedor();
                    ProvSeleccionado = (Proveedor)cbo2.SelectedItem;
                    this.txtProveedor.TextChanged -= new System.EventHandler(this.txtProveedor_TextChanged);
                    //txtProveedor.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    txtProveedor.Text = ProvSeleccionado.AliasProv;
                    this.txtProveedor.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
                    txtProveedor.SelectionStart = txtProveedor.Text.Length + 1;
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate();
                }
            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!vldFrmCotozacionAgreCot.Validate())
                return;

            //Verificar que haya un adjunto
            if (unosAdjuntosNombre.Count != 1)
            {
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor adjuntar la cotización").Texto);
                return;
            }

            try
            {
                if (ProvSeleccionado != null && ProvSeleccionado.IdProveedor > 0)
                {
                    if (unasCotizaciones.Any(X => X.unProveedor.IdProveedor == ProvSeleccionado.IdProveedor))
                        return;
                    Cotizacion unaCotiz = new Cotizacion();
                    unaCotiz.MontoCotizado = Decimal.Parse(txtPrecioUn.Text);
                    unaCotiz.FechaCotizacion = DateTime.Today;
                    unaCotiz.unProveedor = ProvSeleccionado;
                    unaCotiz.unDetalleAsociado = new SolicDetalle();
                    unaCotiz.unDetalleAsociado.IdSolicitud = unDetSolic.IdSolicitud;//unasCotizaciones[0].unDetalleAsociado.IdSolicitud;
                    unaCotiz.unDetalleAsociado.IdSolicitudDetalle = unDetSolic.IdSolicitudDetalle;//unasCotizaciones[0].unDetalleAsociado.IdSolicitudDetalle;
                    unaCotiz.unaPartidaDetalleIDs = new PartidaDetalle();
                    //unaCotiz.IdCotizacion = ManagerCotizacion.CotizacionCrear(unaCotiz);
                    //if (unaCotiz.IdCotizacion > 0)
                    //{
                    //unasCotizaciones = ManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(unaCotiz.unDetalleAsociado.IdSolicitudDetalle, unaCotiz.unDetalleAsociado.IdSolicitud);
                    
                    //Adjunto
                    unaCotiz.RutaOrigenAdjunto = RutaOrigenCompletaAdjunto;
                    string NombreArch = Path.GetFileName(unaCotiz.RutaOrigenAdjunto);
                    unasCotizaciones.Add(unaCotiz);
                    grillaCotizacion.DataSource = null;
                    grillaCotizacion.DataSource = unasCotizaciones;
                    //Agrega el adjunto a la lista global
                    //Agarro el nombre del archivo
                    DicAdjuntos.Add(unasCotizaciones.IndexOf(unasCotizaciones.Last()), new List<string> { NombreArch });
                    DicAdjuntosRutas.Add(unasCotizaciones.IndexOf(unasCotizaciones.Last()), new List<string> { unaCotiz.RutaOrigenAdjunto });
                    FormatearGrillaCotizacion();

                    ////Actualiza SolicDetalles en frmModificarSolicitud por Evento
                    //this.EventoActualizarDetalles(unasCotizaciones);
                    //}
                    //Blanqueo campos
                    txtProveedor.Clear();
                    ProvSeleccionado = null;
                    txtPrecioUn.Clear();
                    unosAdjuntosNombre.Clear();
                    unosAdjuntosRutas.Clear();
                    lstAdjuntos.DataSource = null;
                    lstAdjuntos.Items.Clear();
                    
                }
                
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCotizaciones - btnAgregar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intengar agregar la cotización, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }

        }



        private void txtProvSol_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProvSol.Text))
            {

                List<Proveedor> resProvSol = new List<Proveedor>();
                resProvSol = unosProveedoresSol;

                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtProvSol.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resProvSol = (List<Proveedor>)(from Prov in resProvSol
                                                where Prov.AliasProv.ToLower().Contains(unaPalabra.ToLower())
                                                select Prov).ToList();
                }

                if (resProvSol.Count > 0)
                {
                    if (resProvSol.Count == 1 && string.Equals(resProvSol.First().AliasProv, txtProvSol.Text))
                    {
                        cboProvSol.Visible = false;
                        cboProvSol.DroppedDown = false;
                        cboProvSol.DataSource = null;
                    }
                    else
                    {
                        cboProvSol.DataSource = null;
                        cboProvSol.DataSource = resProvSol;
                        cboProvSol.DisplayMember = "AliasProv";
                        cboProvSol.ValueMember = "IdProveedor";
                        cboProvSol.Visible = true;
                        cboProvSol.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboProvSol.Visible = false;
                    cboProvSol.DroppedDown = false;
                    cboProvSol.DataSource = null;
                }
            }
            else
            {
                cboProvSol.Visible = false;
                cboProvSol.DroppedDown = false;
                cboProvSol.DataSource = null;
            }
        }

        private void cboProvSol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProvSol.Text))
            {
                if (cboProvSol.SelectedIndex > -1)
                {
                    ComboBox cbo3 = (ComboBox)sender;
                    ProvSeleccionadoSol = new Proveedor();
                    ProvSeleccionadoSol = (Proveedor)cbo3.SelectedItem;
                    this.txtProvSol.TextChanged -= new System.EventHandler(this.txtProvSol_TextChanged);
                    txtProvSol.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    this.txtProvSol.TextChanged += new System.EventHandler(this.txtProvSol_TextChanged);
                    txtProvSol.SelectionStart = txtProvSol.Text.Length + 1;
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate();
                }
            }
        }

        private void btnAgregarProvSol_Click(object sender, EventArgs e)
        {
            if (!vldAgregarProv.Validate())
                return;

            if ((Proveedor)cboProvSol.SelectedItem != null && !ListaProv.Contains((Proveedor)cboProvSol.SelectedItem))
            {
                ListaProv.Add((Proveedor)cboProvSol.SelectedItem);
                GrillaProvSolic.DataSource = null;
                GrillaProvSolic.DataSource = ListaProv;
                FormatearGrillaProvSolic();
            }

            txtProvSol.Clear();
            cboProvSol.Refresh();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!vldFrmCotizacionesSolic.Validate())
                    return;
                BLL.Servicios.BLLServicioMail.CargarMailConfig();

                if (ListaProv.Count == 0)
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor ingrese al menos un Proveedor").Texto);
                    return;
                }
                foreach (Proveedor unProv in ListaProv)
                {
                    FRAMEWORK.Servicios.ServicioMail.EnviarCorreo(unProv.MailContactoProv, "MPF", txtAsunto.Text, txtCuerpo.Text);
                }
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Mails enviados correctamente").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCotizaciones - btnSolicitar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al enviar mails a los proveedores, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
            
        }


        private void FormatearGrillaProvSolic()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaProvSolic.Columns.Contains("btnDinBorrar"))
                GrillaProvSolic.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaProvSolic.Columns.Add(deleteButton);

            //Formato Grilla ProvSolic
            GrillaProvSolic.Columns["IdProveedor"].Visible = false;
            GrillaProvSolic.Columns["Activo"].Visible = false;
            GrillaProvSolic.Columns["AliasProv"].HeaderText = "Nombre";
            GrillaProvSolic.Columns["MailContactoProv"].HeaderText = "Mail";
        }

        private void GrillaProvSolic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaProvSolic.Columns["btnDinBorrar"].Index)
                {
                    ListaProv.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    GrillaProvSolic.DataSource = null;
                    GrillaProvSolic.DataSource = ListaProv;
                    FormatearGrillaProvSolic();
                }
            }
        }


        private void FormatearGrillaCotizacion()
        {
            //Elimina el boton si ya estaba agregado
            if (grillaCotizacion.Columns.Contains("btnDinBorrar"))
                grillaCotizacion.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaCotizacion.Columns.Add(deleteButton);

            //Formato GrillaCotizacion
            grillaCotizacion.Columns["IdCotizacion"].Visible = false;
            grillaCotizacion.Columns["MontoCotizado"].HeaderText = "Monto";
            grillaCotizacion.Columns["FechaCotizacion"].HeaderText = "Fecha";
            grillaCotizacion.Columns["unProveedor"].HeaderText = "Proveedor";
            grillaCotizacion.Columns["unDetalleAsociado"].Visible = false;
            grillaCotizacion.Columns["Seleccionada"].Visible = false;
            grillaCotizacion.Columns["unaPartidaDetalleIDs"].Visible = false;
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            List<Cotizacion> CotiQuitarMod = new List<Cotizacion>();
            List<Cotizacion> CotiAgregarMod = new List<Cotizacion>();

            try
            {
                CotiQuitarMod = unasCotizacionesBKP.Where(x => !unasCotizaciones.Any(y => y.IdCotizacion == x.IdCotizacion)).ToList();
                //Le agregué un && x.IdCotizacion == 0 para que el confirmar funcione al agregar una cotización, confirmar, agregar otra cotizacion, y confirmar de nuevo
                //CotiAgregarMod = unasCotizaciones.Where(x => !unasCotizacionesBKP.Any(y => y.IdCotizacion == x.IdCotizacion)).ToList();
                CotiAgregarMod = unasCotizaciones.Where(x => !unasCotizacionesBKP.Any(y => y.Equals(x))).ToList();
                //CotiAgregarMod.AddRange(unasCotizaciones.Where(X => CotiAgregarMod.Any(Y => Y.Equals(X)) && X.IdCotizacion == 0));
                    //=> X.IdCotizacion == 0));

                if (CotiQuitarMod.Count > 0 | CotiAgregarMod.Count > 0)
                {
                    //Actualiza SolicDetalles en frmModificarSolicitud por Evento
                    this.EventoActualizarDetalles(unasCotizaciones, unDetSolic.IdSolicitudDetalle);
                    this.Hide();
                }
                else
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No se encontraron modificaciones a realizar").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCotizaciones - btnConfirmar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al registrar las cotizaciones, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void grillaCotizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Si se hizo click en el header, salir
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else if (e.ColumnIndex == grillaCotizacion.Columns["btnDinBorrar"].Index)
                {
                    ////Si hizo click en Quitar
                    //if (e.ColumnIndex == grillaCotizacion.Columns["btnDinBorrar"].Index)
                    //{
                        unasCotizaciones.RemoveAt(e.RowIndex);
                        //Regenero la grilla
                        grillaCotizacion.DataSource = null;
                        grillaCotizacion.DataSource = unasCotizaciones;
                        FormatearGrillaCotizacion();
                    //}
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCotizaciones - grillaCotizacion_CellClick");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intengar eliminar una cotización, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
                RutaOrigenCompletaAdjunto = unArchivo.First();
                //Agarro el nombre del archivo
                NombreArchivo = Path.GetFileName(unArchivo.First());
                ext = Path.GetExtension(unArchivo.First().ToLower());
                if (FRAMEWORK.Servicios.ManejoArchivos.ValidarAdjunto(unArchivo.First()))
                {
                    pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;
                    
                    //Añado a la grilla el nombre del archivo
                    unosAdjuntosNombre.Add(NombreArchivo);
                    unosAdjuntosRutas.Add(unArchivo.First());




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


        private void lstAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            //if (unosAdjuntosNombre.Count > 0)
            //{
            //    using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            //    {
            //        ext = Path.GetExtension(lstAdjuntos.SelectedValue.ToString());
            //        string RutaCompletaAdjunto = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + NombreAdjunto;
            //        proc.StartInfo.FileName = RutaCompletaAdjunto;
            //        proc.Start();
            //        proc.Close();
            //    }

            //}

        }

        private void grillaCotizacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //if (DicAdjuntos[unasCotizaciones[e.RowIndex].IdCotizacion].Count > 0)
            if (DicAdjuntos[e.RowIndex].Count > 0)
            {
                using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
                {
                    string RutaCompletaAdjunto;
                    if (unasCotizaciones[e.RowIndex].IdCotizacion > 0)
                        RutaCompletaAdjunto = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + DicAdjuntos[e.RowIndex].First();
                    else
                        RutaCompletaAdjunto = unasCotizaciones[e.RowIndex].RutaOrigenAdjunto;
                    proc.StartInfo.FileName = RutaCompletaAdjunto;
                    proc.Start();
                    proc.Close();
                }

            }

        }




    }
}