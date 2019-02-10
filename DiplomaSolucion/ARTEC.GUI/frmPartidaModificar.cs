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

            Dictionary<string, string[]> dicchkCaja = new Dictionary<string, string[]>();
            string[] IdiomachkCaja = { "Caja" };
            dicchkCaja.Add("Idioma", IdiomachkCaja);
            this.chkCaja.Tag = dicchkCaja;

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

            Dictionary<string, string[]> dicpnlResPartida = new Dictionary<string, string[]>();
            string[] IdiomapnlResPartida = { "Partida" };
            dicpnlResPartida.Add("Idioma", IdiomapnlResPartida);
            this.pnlResPartida.Tag = dicpnlResPartida;

            Dictionary<string, string[]> diclblMontoTotal = new Dictionary<string, string[]>();
            string[] IdiomalblMontoTotal = { "Monto Total" };
            diclblMontoTotal.Add("Idioma", IdiomalblMontoTotal);
            this.lblMontoTotal.Tag = diclblMontoTotal;

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
            chkCaja.Checked = unaPartida.Caja;

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
                    List<Cotizacion> CotizAntiguas = unManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.IdSolicitudDetalle, unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.IdSolicitud, unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.UIDSolicDetalle);
                    ListaResCotizLoc = CotizAntiguas.SkipWhile(p => ListaLocalCotiz.Any(l => p.IdCotizacion == l.IdCotizacion))
                               .ToList();
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;

                    FormatearGrillaCotiz();
                }

                
            }
        }


        private void GrillaCotizAntiguas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Guardo en BD la asociacion de la cotiz con el partDet
                if (ManagerCotizacion.CotizacionAsociarConPartidaDetalle(ListaResCotizLoc[e.RowIndex].IdCotizacion, unaPartida.unasPartidasDetalles[IndiceDetalleSeleccionado].UIDPartidaDetalle, unaPartida.IdPartida))
                {
                    //Actualizo las grillas
                    ListaLocalCotiz.Add(ListaResCotizLoc[e.RowIndex]);
                    grillaCotizaciones.DataSource = null;
                    grillaCotizaciones.DataSource = ListaLocalCotiz;
                    ListaResCotizLoc.RemoveAt(e.RowIndex);
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;
                    FormatearGrillaCotiz();
                    //Actualizo campos
                    CalcularMontoTotalPartida();
                    //txtMontoSolic.Text = ListaLocalCotiz.Sum(X => X.MontoCotizado).ToString();
                }
                else
                {
                    MessageBox.Show("Error al asociar la cotización");
                }

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
            }
            txtMontoSolic.Text = TotalAcumulado.ToString();
            ManagerPartida.PartidaModifMontoSolic(unaPartida.IdPartida, TotalAcumulado);
        }


        private void FormatearGrillaCotiz()
        {
            grillaCotizaciones.Columns["unDetalleAsociado"].Visible = false;
            grillaCotizaciones.Columns["Seleccionada"].Visible = false;
            grillaCotizaciones.Columns["unaPartidaDetalleIDs"].Visible = false;
            GrillaCotizAntiguas.Columns["unDetalleAsociado"].Visible = false;
            GrillaCotizAntiguas.Columns["Seleccionada"].Visible = false;
            GrillaCotizAntiguas.Columns["unaPartidaDetalleIDs"].Visible = false;
        }

        //Genera el documento con la partida modificada
        private void btnGenerarDocumento_Click(object sender, EventArgs e)
        {
            if (PDetallesBorrar != null && PDetallesBorrar.Count() > 0)
            {
                ManagerPartida.PartidaModifDetalles(PDetallesBorrar);

            }

            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
            {
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2.docx"))//VER: Modificar ruta
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                    ////Si se escribio una justificación
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                }
            }
            else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
            {
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2 English.docx"))
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                    CultureInfo ci = new CultureInfo("en-US");
                    doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                    //Si se escribio una justificación
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                }
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

                        if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                        {
                            using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2.docx"))//VER: Modificar ruta
                            {
                                doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                                doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                                CultureInfo ci = new CultureInfo("es-AR");
                                doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                                doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                            }
                        }
                        else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                        {
                            using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2 English.docx"))
                            {
                                doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                                doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                                CultureInfo ci = new CultureInfo("en-US");
                                doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                                doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                            }
                        }
                    }
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
            finally
            {
                DialogResult = DialogResult.Cancel;
            }
        }


        private void lblVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}