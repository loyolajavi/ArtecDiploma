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
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.ENTIDADES.Helpers;
using System.Globalization;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL.Servicios;
using Xceed.Words.NET;
using System.IO;
using System.Drawing.Printing;

namespace ARTEC.GUI
{
    public partial class frmPartidaModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        int NroPartida;
        BLLPartida ManagerPartida = new BLLPartida();
        Partida unaPartida;
        BLLCotizacion unManagerCotizacion = new BLLCotizacion();
        List<Cotizacion> ListaResCotizLoc;
        int IndiceDetalleSeleccionado;
        List<Cotizacion> ListaLocalCotiz;
        BLLCotizacion ManagerCotizacion = new BLLCotizacion();
        Dependencia DepAsoc;
        List<PartidaDetalle> PDetallesBorrar = new List<PartidaDetalle>();
        System.Drawing.Font printFont;
        StreamReader streamToPrint;
        List<Cotizacion> CotizAntiguas;

        public frmPartidaModificar(int NroPartidaArg)
        {
            InitializeComponent();
            NroPartida = NroPartidaArg;
            ////Agrega Checkbox para seleccionar Cotizaciones
            //DataGridViewCheckBoxColumn chkCotizacion = new DataGridViewCheckBoxColumn();
            //chkCotizacion.Name = "chkBoxCotizacion";
            //chkCotizacion.HeaderText = "";
            //chkCotizacion.TrueValue = true;
            //chkCotizacion.FalseValue = false;
            //grillaCotizaciones.Columns.Add(chkCotizacion);

            Dictionary<string, string[]> diclblNroPartida = new Dictionary<string, string[]>();
            string[] IdiomalblNroPartida = { "Número de Partida" };
            diclblNroPartida.Add("Idioma", IdiomalblNroPartida);
            this.lblNroPartida.Tag = diclblNroPartida;

            Dictionary<string, string[]> diclblIdSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblIdSolicitud = { "Solicitud" };
            diclblIdSolicitud.Add("Idioma", IdiomalblIdSolicitud);
            this.lblIdSolicitud.Tag = diclblIdSolicitud;

            Dictionary<string, string[]> diclblIdPartida = new Dictionary<string, string[]>();
            string[] IdiomalblIdPartida = { "Partida" };
            diclblIdPartida.Add("Idioma", IdiomalblIdPartida);
            this.lblIdPartida.Tag = diclblIdPartida;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblMontoSolic = new Dictionary<string, string[]>();
            string[] IdiomalblMontoSolic = { "Monto Solicitado" };
            diclblMontoSolic.Add("Idioma", IdiomalblMontoSolic);
            this.lblMontoSolic.Tag = diclblMontoSolic;

            Dictionary<string, string[]> diclblFechaEnvio = new Dictionary<string, string[]>();
            string[] IdiomalblFechaEnvio = { "Fecha envío" };
            diclblFechaEnvio.Add("Idioma", IdiomalblFechaEnvio);
            this.lblFechaEnvio.Tag = diclblFechaEnvio;

            Dictionary<string, string[]> diclblDetalles = new Dictionary<string, string[]>();
            string[] IdiomalblDetalles = { "Detalles" };
            diclblDetalles.Add("Idioma", IdiomalblDetalles);
            this.lblDetalles.Tag = diclblDetalles;

            Dictionary<string, string[]> diclblCotizaciones = new Dictionary<string, string[]>();
            string[] IdiomalblCotizaciones = { "Cotizaciones" };
            diclblCotizaciones.Add("Idioma", IdiomalblCotizaciones);
            this.lblCotizaciones.Tag = diclblCotizaciones;

            Dictionary<string, string[]> dicbtnRegenerarPartida = new Dictionary<string, string[]>();
            string[] IdiomabtnRegenerarPartida = { "Generar Partida" };
            dicbtnRegenerarPartida.Add("Idioma", IdiomabtnRegenerarPartida);
            this.btnRegenerarPartida.Tag = dicbtnRegenerarPartida;

            Dictionary<string, string[]> dicbtnCancelar = new Dictionary<string, string[]>();
            string[] IdiomabtnCancelar = { "Cancelar" };
            dicbtnCancelar.Add("Idioma", IdiomabtnCancelar);
            this.btnCancelar.Tag = dicbtnCancelar;

            Dictionary<string, string[]> diclblVolver = new Dictionary<string, string[]>();
            string[] IdiomalblVolver = { "Volver" };
            diclblVolver.Add("Idioma", IdiomalblVolver);
            this.lblVolver.Tag = diclblVolver;
            

        }

        private void frmPartidaModificar_Load(object sender, EventArgs e)
        {
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

            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            unaPartida = ManagerPartida.PartidaTraerPorNroPartConCanceladas(NroPartida).FirstOrDefault();
            if (unaPartida != null && unaPartida.IdPartida > 0)
            {
                foreach (PartidaDetalle pdet in unaPartida.unasPartidasDetalles)
                {
                    pdet.unasCotizaciones = unManagerCotizacion.CotizacionTraerPorUIDPartidaDetalle(pdet.UIDPartidaDetalle, pdet.IdPartida);
                    pdet.unasCotizacionesBKP = unManagerCotizacion.CotizacionTraerPorUIDPartidaDetalle(pdet.UIDPartidaDetalle, pdet.IdPartida);
                    pdet.unasCotizacionesEnSolic = unManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(pdet.SolicDetalleAsociado.IdSolicitudDetalle, pdet.SolicDetalleAsociado.IdSolicitud, pdet.SolicDetalleAsociado.UIDSolicDetalle);
                }

                //Traigo la dependencia asociada
                BLLDependencia ManagerDependencia = new BLLDependencia();
                List<Dependencia> ListaDep = ManagerDependencia.DependenciaTraerNombrePorIDSolicitud(unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.IdSolicitud);
                if (ListaDep != null){
                    DepAsoc = ListaDep.First();
                    txtDependencia.Text = DepAsoc.NombreDependencia;
                }
            }

            txtIdPartida.Text = unaPartida.IdPartida.ToString();
            txtNroPartida.Text = !string.IsNullOrEmpty(unaPartida.NroPartida) ? unaPartida.NroPartida : "";
            txtFechaEnvio.Text = unaPartida.FechaEnvio.ToString();
            txtMontoSolic.Text = unaPartida.MontoSolicitado.ToString();
            txtNroSolicitud.Text = unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.IdSolicitud.ToString();

            List<HLPPartidaDetalle> ListaHelperPartidaDetalle = new List<HLPPartidaDetalle>();

            grillaDetallesPart.DataSource = null;
            foreach (PartidaDetalle unPartDet in unaPartida.unasPartidasDetalles)
            {
                HLPPartidaDetalle unHLPPartDetalle = new HLPPartidaDetalle();
                unHLPPartDetalle.IdPartidaDetalle = unPartDet.IdPartidaDetalle;
                unHLPPartDetalle.DescripCategoria = unPartDet.SolicDetalleAsociado.unaCategoria.DescripCategoria;
                unHLPPartDetalle.Cantidad = unPartDet.SolicDetalleAsociado.Cantidad;

                ListaHelperPartidaDetalle.Add(unHLPPartDetalle);
            }
            grillaDetallesPart.DataSource = ListaHelperPartidaDetalle;
            //Agrega boton para Borrar el detallePartida
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaDetallesPart.Columns.Add(deleteButton);
        }

        private void grillaDetallesPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                    //Si hizo click en Borrar
                    if (e.ColumnIndex == grillaDetallesPart.Columns["btnDinBorrar"].Index)
                    { 
                        //VER: COMPROBAR QUE LA PARTIDA NO ESTE ASOCIADA A UNA DE CONTRATACIONES
                        //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                        grillaDetallesPart.Columns.RemoveAt(e.ColumnIndex);

                        //Guardo en una lista los detalles a eliminar
                        PDetallesBorrar.Add(unaPartida.unasPartidasDetalles[e.RowIndex]);

                        //elimino de la memoria el detalle
                        unaPartida.unasPartidasDetalles.RemoveAt(e.RowIndex);
                        //Regenero la grilla
                        grillaDetallesPart.DataSource = null;
                        List<HLPPartidaDetalle> ListaHelperPartidaDetalle = new List<HLPPartidaDetalle>();
                        foreach (PartidaDetalle unPartDet in unaPartida.unasPartidasDetalles)
                        {
                            HLPPartidaDetalle unHLPPartDetalle = new HLPPartidaDetalle();
                            unHLPPartDetalle.IdPartidaDetalle = unPartDet.IdPartidaDetalle;
                            unHLPPartDetalle.DescripCategoria = unPartDet.SolicDetalleAsociado.unaCategoria.DescripCategoria;
                            unHLPPartDetalle.Cantidad = unPartDet.SolicDetalleAsociado.Cantidad;

                            ListaHelperPartidaDetalle.Add(unHLPPartDetalle);
                        }
                        grillaDetallesPart.DataSource = ListaHelperPartidaDetalle;
                        //Agrega boton para Borrar el detallePartida
                        var deleteButton = new DataGridViewButtonColumn();
                        deleteButton.Name = "btnDinBorrar";
                        deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                        deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                        deleteButton.UseColumnTextForButtonValue = true;
                        grillaDetallesPart.Columns.Add(deleteButton);

                        grillaCotizaciones.DataSource = null;
                        GrillaCotizAntiguas.DataSource = null;
                        //Elimina el boton de Quitar Cotiz si ya estaba agregado
                        if (grillaCotizaciones.Columns.Contains("btnDinBorrar"))
                            grillaCotizaciones.Columns.Remove("btnDinBorrar");
                        //Antiguas
                        //Elimina el boton de agergar Cotiz si ya estaba agregado
                        if (GrillaCotizAntiguas.Columns.Contains("btnDinAgregar"))
                            GrillaCotizAntiguas.Columns.Remove("btnDinAgregar");

                        CalcularMontoTotalPartida();
                    }
                else
                {
                    IndiceDetalleSeleccionado = e.RowIndex;
                    DataGridView grillaAux = (DataGridView)sender;
                    ListaLocalCotiz = (List<Cotizacion>)unaPartida.unasPartidasDetalles[e.RowIndex].unasCotizaciones;

                    grillaCotizaciones.DataSource = null;
                    grillaCotizaciones.DataSource = ListaLocalCotiz;
                    //foreach (Cotizacion unaCot in ListaLocalCotiz)
                    //{
                    //    grillaCotizaciones.Rows[ListaLocalCotiz.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                    //    grillaAux.EndEdit();
                    //}

                    //Coloco las cotizaciones antiguas (no asociadas a la partida al momento de generarla)
                    CotizAntiguas = unManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.IdSolicitudDetalle, unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.IdSolicitud, unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.UIDSolicDetalle);
                    ListaResCotizLoc = CotizAntiguas.Where(p => !ListaLocalCotiz.Any(l => p.IdCotizacion == l.IdCotizacion))
                               .ToList();
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;

                    FormatearGrillaCotiz();
                }

                
            }
        }


        private void GrillaCotizAntiguas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Si se hizo click en el header, salir
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else if (e.ColumnIndex == GrillaCotizAntiguas.Columns["btnDinAgregar"].Index)
                {
                    ////Si hizo click en Agregar
                    ListaLocalCotiz.Add(ListaResCotizLoc[e.RowIndex]);
                    //Regenero la grilla
                    grillaCotizaciones.DataSource = null;
                    grillaCotizaciones.DataSource = ListaLocalCotiz;

                    ListaResCotizLoc.RemoveAt(e.RowIndex);
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;
                    FormatearGrillaCotiz();
                    //Actualizo Monto Total
                    CalcularMontoTotalPartida();
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaModificar - GrillaCotizAntiguas_CellClick");
                MessageBox.Show("Ocurrio un error al intengar agregar una cotización, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void CalcularMontoTotalPartida()
        {
            decimal TotalAcumulado = 0;
            foreach (PartidaDetalle unDet in unaPartida.unasPartidasDetalles)
            {
                //Suma para obtener el costo total de la partida
                Cotizacion unaCotizacionAUX = unDet.unasCotizaciones.OrderBy(x => x.MontoCotizado).Take(1).FirstOrDefault();
                if (unaCotizacionAUX != null)
                {

                    TotalAcumulado += unaCotizacionAUX.MontoCotizado * unDet.SolicDetalleAsociado.Cantidad;
                }
                else
                {
                    TotalAcumulado += 0;
                }
                unaPartida.MontoSolicitado = TotalAcumulado;
            }
            txtMontoSolic.Text = TotalAcumulado.ToString();
            //ManagerPartida.PartidaModifMontoSolic(unaPartida.IdPartida, TotalAcumulado);//VER Modificaba de una el monto en BD
        }


        private void FormatearGrillaCotiz()
        {
            //Elimina el boton si ya estaba agregado
            if (grillaCotizaciones.Columns.Contains("btnDinBorrar"))
                grillaCotizaciones.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaCotizaciones.Columns.Add(deleteButton);

            //Formato GrillaCotizacion
            grillaCotizaciones.Columns["IdCotizacion"].Visible = false;
            grillaCotizaciones.Columns["MontoCotizado"].HeaderText = "Monto";
            grillaCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha";
            grillaCotizaciones.Columns["unProveedor"].HeaderText = "Proveedor";
            grillaCotizaciones.Columns["unDetalleAsociado"].Visible = false;
            grillaCotizaciones.Columns["Seleccionada"].Visible = false;
            grillaCotizaciones.Columns["unaPartidaDetalleIDs"].Visible = false;

            //Antiguas
            //Elimina el boton si ya estaba agregado
            if (GrillaCotizAntiguas.Columns.Contains("btnDinAgregar"))
                GrillaCotizAntiguas.Columns.Remove("btnDinAgregar");
            //Agrega boton para Borrar
            var AddButtonAntiguas = new DataGridViewButtonColumn();
            AddButtonAntiguas.Name = "btnDinAgregar";
            AddButtonAntiguas.HeaderText = BLLServicioIdioma.MostrarMensaje("Agregar").Texto;
            AddButtonAntiguas.Text = BLLServicioIdioma.MostrarMensaje("Agregar").Texto;
            AddButtonAntiguas.UseColumnTextForButtonValue = true;
            GrillaCotizAntiguas.Columns.Add(AddButtonAntiguas);

            //Formato GrillaCotizacionAntiguas
            GrillaCotizAntiguas.Columns["IdCotizacion"].Visible = false;
            GrillaCotizAntiguas.Columns["MontoCotizado"].HeaderText = "Monto";
            GrillaCotizAntiguas.Columns["FechaCotizacion"].HeaderText = "Fecha";
            GrillaCotizAntiguas.Columns["unProveedor"].HeaderText = "Proveedor";
            GrillaCotizAntiguas.Columns["unDetalleAsociado"].Visible = false;
            GrillaCotizAntiguas.Columns["Seleccionada"].Visible = false;
            GrillaCotizAntiguas.Columns["unaPartidaDetalleIDs"].Visible = false;
        }

        //Genera el documento con la partida modificada
        private void btnGenerarDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                //Si fue acreditada impedir la modificación
                if (unaPartida.MontoOtorgado > 0 && !string.IsNullOrEmpty(unaPartida.NroPartida))
                {
                    MessageBox.Show("La partida se encuentra acreditada, no puede modificarse");
                    return;
                }

                if (unaPartida.unasPartidasDetalles.Any(X => X.unasCotizaciones.Count < 3))
                {
                    MessageBox.Show("Cada detalle de la partida debe poseer al menos 3 cotizaciones");
                    return;
                }

                if (ManagerPartida.PartidaModifDetalles(PDetallesBorrar, unaPartida.unasPartidasDetalles, unaPartida.MontoSolicitado))
                {
                    //Crear el documento
                    string RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Elevación Partida.docx";
                    if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                    {
                        using (DocX doc = DocX.Load(RutaPlantilla))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                            var unaLista = doc.AddList(unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.Cantidad.ToString() + " " + unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0, ListItemType.Bulleted, 1);
                            for (var I = 1; I == unaPartida.unasPartidasDetalles.Count() - 1; I++)
                            {
                                doc.AddListItem(unaLista, unaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.Cantidad.ToString() + " " + unaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0);
                            }
                            doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                            doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                        }
                    }
                    else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                    {
                        RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Elevación Partida2 English.docx";
                        using (DocX doc = DocX.Load(RutaPlantilla))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                            var unaLista = doc.AddList(unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.Cantidad.ToString() + " " + unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0, ListItemType.Bulleted, 1);
                            for (var I = 1; I == unaPartida.unasPartidasDetalles.Count() - 1; I++)
                            {
                                doc.AddListItem(unaLista, unaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.Cantidad.ToString() + " " + unaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0);
                            }
                            doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                            doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                        }
                    }

                    ////Imprimir la partida
                    string NombreImpresora = "";
                    string file = "";

                    //Partida
                    if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx"))
                    {
                        using (PrintDialog printDialog1 = new PrintDialog())
                        {
                            if (printDialog1.ShowDialog() == DialogResult.OK)
                            {
                                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                                info.Arguments = "\"" + printDialog1.PrinterSettings.PrinterName + "\"";
                                NombreImpresora = printDialog1.PrinterSettings.PrinterName;
                                info.CreateNoWindow = true;
                                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                info.UseShellExecute = true;
                                info.Verb = "Printto";
                                System.Diagnostics.Process.Start(info);
                            }
                        }

                        //Cotiz
                        if (NombreImpresora != "")
                        {
                            foreach (PartidaDetalle unaPDet in unaPartida.unasPartidasDetalles)
                            {
                                foreach (Cotizacion unaCoti in unaPDet.unasCotizaciones)
                                {
                                    if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Cotizacion " + unaCoti.IdCotizacion.ToString() + ".jpg"))
                                    {
                                        file = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Cotizacion " + unaCoti.IdCotizacion.ToString() + ".jpg";
                                        using (var pd = new System.Drawing.Printing.PrintDocument())
                                        {
                                            pd.PrinterSettings.PrinterName = NombreImpresora;
                                            pd.PrintPage += (_, r) =>
                                            {
                                                var img = System.Drawing.Image.FromFile(file);
                                                // This uses a 50 pixel margin - adjust as needed
                                                r.Graphics.DrawImage(img, new Point(50, 50));
                                            };
                                            pd.Print();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Solicitud de Partida modificada correctamente");
                    this.Close();
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaModificar - btnGenerarDocumento_Click");
                MessageBox.Show("Error al intentar modificar la partida, por favor informe del error Nro " + IdError + " del Log de Eventos");                
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ////elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            //grillaDetallesPart.Columns.Remove("btnDinBorrar");
            //grillaCotizaciones.DataSource = null;
            //GrillaCotizAntiguas.DataSource = null;
            //grillaDetallesPart.DataSource = null;
            //frmPartidaModificar_Load(this, new EventArgs());
            ////Limpio los pdetalles a borrar
            //PDetallesBorrar.Clear();
            ////Actualizo campos
            //CalcularMontoTotalPartida();



            //Verificar que no existan Adquisiciones asociadas (Reutilizo la función para iniciar la creación de las rendiciones)
            BLLRendicion ManagerRendicion = new BLLRendicion();
            Rendicion unaRendicion = new Rendicion();

            try
            {
                unaRendicion = ManagerRendicion.AdquisicionesConBienesPorIdPartida(NroPartida);
                if (unaRendicion != null && unaRendicion.unasAdquisiciones != null && unaRendicion.unasAdquisiciones.Count() > 0)
                {
                    MessageBox.Show("La Partida no puede ser cancelada porque contiene Adquisiciones asociadas");
                    return;
                }
                //Verificar que no exista una Rendicion asociada
                int NroRenAsociada = ManagerRendicion.RendicionTraerIdRendPorIdPartida(NroPartida);
                if (NroRenAsociada > 0)
                {
                    MessageBox.Show("La Partida no puede ser cancelada porque contiene Rendiciones asociadas");
                    return;
                }
                DialogResult resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Partida: " + unaPartida.IdPartida.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo);
                if (resmbox == DialogResult.Yes)
                {
                    //Si fue acreditada generar documento de cancelación
                    if (unaPartida.MontoOtorgado > 0)
                    {
                        if (ManagerPartida.PartidaCancelar(unaPartida))
                        {
                            //Crear el documento
                            string RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Elevación Partida.docx";
                            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                            {
                                using (DocX doc = DocX.Load(RutaPlantilla))
                                {
                                    doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                                    doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                                    CultureInfo ci = new CultureInfo("es-AR");
                                    doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                                }
                            }
                            else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                            {
                                RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Elevación Partida2 English.docx";
                                using (DocX doc = DocX.Load(RutaPlantilla))
                                {
                                    doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                                    doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                                    CultureInfo ci = new CultureInfo("es-AR");
                                    doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                                }
                            }

                            //Imprimir el documento de cancelación de Partida
                            using (PrintDialog printDialog1 = new PrintDialog())
                            {
                                if (printDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                                    info.Arguments = "\"" + printDialog1.PrinterSettings.PrinterName + "\"";
                                    info.CreateNoWindow = true;
                                    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                    info.UseShellExecute = true;
                                    info.Verb = "PrintTo";
                                    System.Diagnostics.Process.Start(info);
                                }
                            }

                            MessageBox.Show("Partida Cancelada Correctamente");
                            //Grisear Todo
                            btnRegenerarPartida.Enabled = false;
                            btnCancelar.Enabled = false;
                            grillaDetallesPart.Enabled = false;
                            grillaCotizaciones.Enabled = false;
                            GrillaCotizAntiguas.Enabled = false;
                            //DialogResult = DialogResult.No;
                            //Cerrar formulario
                            DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {   //Cancela sin generar documento de cancelación
                        if (ManagerPartida.PartidaCancelar(unaPartida))
                        {
                            MessageBox.Show("Partida Cancelada Correctamente");
                            //Grisear Todo
                            btnRegenerarPartida.Enabled = false;
                            btnCancelar.Enabled = false;
                            grillaDetallesPart.Enabled = false;
                            grillaCotizaciones.Enabled = false;
                            GrillaCotizAntiguas.Enabled = false;
                            //DialogResult = DialogResult.No;
                            //Cerrar formulario
                            DialogResult = DialogResult.Cancel;
                        }
                    }
                }
                else
                    return;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaModificar - btnCancelar_Click");
                MessageBox.Show("Ocurrio un error al intentar cancelar la Partida: " + unaPartida.IdPartida.ToString() + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            //finally
            //{
            //    DialogResult = DialogResult.Cancel;
            //}
        }


        private void lblVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string NombreImpresora = "";
            string file = "";

            //Partida
            if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx"))
            {
                using (PrintDialog printDialog1 = new PrintDialog())
                {
                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + unaPartida.IdPartida.ToString() + ".docx");
                        info.Arguments = "\"" + printDialog1.PrinterSettings.PrinterName + "\"";
                        NombreImpresora = printDialog1.PrinterSettings.PrinterName;
                        info.CreateNoWindow = true;
                        info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        info.UseShellExecute = true;
                        info.Verb = "Printto";
                        System.Diagnostics.Process.Start(info);
                    }
                }
            }
            else
                return;

                //Cotiz
            if (NombreImpresora != "")
            {
                foreach (PartidaDetalle unaPDet in unaPartida.unasPartidasDetalles)
                {
                    foreach (Cotizacion unaCoti in unaPDet.unasCotizaciones)
                    {
                        if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Cotizacion " + unaCoti.IdCotizacion.ToString() + ".jpg"))
                        {
                            file = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaAdjuntos() + "Cotizacion " + unaCoti.IdCotizacion.ToString() + ".jpg";
                            using (var pd = new System.Drawing.Printing.PrintDocument())
                            {
                                pd.PrinterSettings.PrinterName = NombreImpresora;
                                pd.PrintPage += (_, r) =>
                                {
                                    var img = System.Drawing.Image.FromFile(file);
                                    // This uses a 50 pixel margin - adjust as needed
                                    r.Graphics.DrawImage(img, new Point(50, 50));
                                };
                                pd.Print();
                            }
                        }
                    }
                }
            }
        }

        private void grillaCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Si se hizo click en el header, salir
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else if (e.ColumnIndex == grillaCotizaciones.Columns["btnDinBorrar"].Index)
                {
                    ////Si hizo click en Quitar
                    //if (e.ColumnIndex == grillaCotizacion.Columns["btnDinBorrar"].Index)
                    //{
                    ListaLocalCotiz.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    grillaCotizaciones.DataSource = null;
                    grillaCotizaciones.DataSource = ListaLocalCotiz;
                    
                    //Coloco las cotizaciones antiguas diferencia con lo quitado (no asociadas a la partida al momento de generarla)
                    ListaResCotizLoc = CotizAntiguas.Where(p => !ListaLocalCotiz.Any(l => p.IdCotizacion == l.IdCotizacion))
                               .ToList();
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;
                    FormatearGrillaCotiz();
                    //Actualizo Monto Total
                    CalcularMontoTotalPartida();
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaModificar - grillaCotizaciones_CellClick");
                MessageBox.Show("Ocurrio un error al intengar eliminar una cotización, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }



        





    }
}