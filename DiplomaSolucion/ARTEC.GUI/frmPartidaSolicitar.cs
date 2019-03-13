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
using System.Globalization;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL.Servicios;
using System.Diagnostics;
using System.Drawing.Printing;
using Xceed.Words.NET;

namespace ARTEC.GUI
{
    public partial class frmPartidaSolicitar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmPartidaSolicitar _unFrmPartidaSolicituar;
        public Solicitud unaSolicitud;
        Partida nuevaPartida;
        List<SolicDetalle> ListaSolicDet = new List<SolicDetalle>();
        List<Cotizacion> ListaCotiz = new List<Cotizacion>();
        int PosSolicDet = 0;
        decimal TotalAcumulado = 0;
        decimal LimitePartida;
        List<Solicitud> ListaSolicitudes;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        BLLPartida ManagerPartida = new BLLPartida();
        Partida PartidaAsociada = new Partida();
        DialogResult resmbox = DialogResult.No;

        //Constructor cuando se ingresa por Principal
        private frmPartidaSolicitar()
        {
            InitializeComponent();

            CargarTags();

            //Agrega Checkbox para seleccionar SolicDetalles
            var CheckBoxColumna = new DataGridViewCheckBoxColumn();
            CheckBoxColumna.Name = "chkBoxDetalles";
            CheckBoxColumna.TrueValue = true;
            CheckBoxColumna.FalseValue = false;
            CheckBoxColumna.HeaderText = ""; //ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
            grillaSolicDetalles.Columns.Add(CheckBoxColumna);
            //Agrega Checkbox para seleccionar Cotizaciones
            DataGridViewCheckBoxColumn chkCotizacion = new DataGridViewCheckBoxColumn();
            chkCotizacion.Name = "chkBoxCotizacion";
            chkCotizacion.HeaderText = "";
            chkCotizacion.TrueValue = true;
            chkCotizacion.FalseValue = false;
            grillaCotizaciones.Columns.Add(chkCotizacion);
        }

        //Singleton cuando se ingresa por Principal
        public static frmPartidaSolicitar ObtenerInstancia()
        {
            if (_unFrmPartidaSolicituar == null)
            {
                _unFrmPartidaSolicituar = new frmPartidaSolicitar();
            }
            return _unFrmPartidaSolicituar;
        }

        //Constructor cuando se ingresa desde frmModificarSolicitud
        private frmPartidaSolicitar(Solicitud unaSolic)
        {
            InitializeComponent();

            CargarTags();

            unaSolicitud = unaSolic;
            //Agrega Checkbox para seleccionar SolicDetalles
            var CheckBoxColumna = new DataGridViewCheckBoxColumn();
            CheckBoxColumna.Name = "chkBoxDetalles";
            CheckBoxColumna.TrueValue = true;
            CheckBoxColumna.FalseValue = false;
            CheckBoxColumna.HeaderText = ""; //ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
            grillaSolicDetalles.Columns.Add(CheckBoxColumna);
            //Agrega Checkbox para seleccionar Cotizaciones
            DataGridViewCheckBoxColumn chkCotizacion = new DataGridViewCheckBoxColumn();
            chkCotizacion.Name = "chkBoxCotizacion";
            chkCotizacion.HeaderText = "";
            chkCotizacion.TrueValue = true;
            chkCotizacion.FalseValue = false;
            grillaCotizaciones.Columns.Add(chkCotizacion);
        }

        //Singleton cuando se ingresa desde frmModificarSolicitud
        public static frmPartidaSolicitar ObtenerInstancia(Solicitud unaSolic)
        {
            if (_unFrmPartidaSolicituar == null)
            {
                _unFrmPartidaSolicituar = new frmPartidaSolicitar(unaSolic);
            }
            return _unFrmPartidaSolicituar;
        }


        private void CargarTags()
        {
            Dictionary<string, string[]> dictxtResBusqueda = new Dictionary<string, string[]>();
            string[] IdiomatxtResBusqueda = { "No hay resultados" };
            dictxtResBusqueda.Add("Idioma", IdiomatxtResBusqueda);
            this.txtResBusqueda.Tag = dictxtResBusqueda;

            Dictionary<string, string[]> dictxtNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomatxtNroSolicitud = { "Solo se aceptan números" };
            dictxtNroSolicitud.Add("Idioma", IdiomatxtNroSolicitud);
            this.txtNroSolicitud.Tag = dictxtNroSolicitud;

            Dictionary<string, string[]> dicfrmPartidaSolicitar = new Dictionary<string, string[]>();
            string[] IdiomafrmPartidaSolicitar = { "Crear Partida" };
            dicfrmPartidaSolicitar.Add("Idioma", IdiomafrmPartidaSolicitar);
            this.Tag = dicfrmPartidaSolicitar;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblIdSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblIdSolicitud = { "Solicitud" };
            diclblIdSolicitud.Add("Idioma", IdiomalblIdSolicitud);
            this.lblIdSolicitud.Tag = diclblIdSolicitud;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> diclblDetalles = new Dictionary<string, string[]>();
            string[] IdiomalblDetalles = { "Detalles" };
            diclblDetalles.Add("Idioma", IdiomalblDetalles);
            this.lblDetalles.Tag = diclblDetalles;

            Dictionary<string, string[]> diclblCotizaciones = new Dictionary<string, string[]>();
            string[] IdiomalblCotizaciones = { "Cotizaciones" };
            diclblCotizaciones.Add("Idioma", IdiomalblCotizaciones);
            this.lblCotizaciones.Tag = diclblCotizaciones;

            Dictionary<string, string[]> dicbtnGenerarPartida = new Dictionary<string, string[]>();
            string[] IdiomabtnGenerarPartida = { "Generar Partida" };
            dicbtnGenerarPartida.Add("Idioma", IdiomabtnGenerarPartida);
            this.btnGenerarPartida.Tag = dicbtnGenerarPartida;

            Dictionary<string, string[]> diclblMontoTotal = new Dictionary<string, string[]>();
            string[] IdiomalblMontoTotal = { "Monto Total" };
            diclblMontoTotal.Add("Idioma", IdiomalblMontoTotal);
            this.lblMontoTotal.Tag = diclblMontoTotal;

            Dictionary<string, string[]> dicpnlResPartida = new Dictionary<string, string[]>();
            string[] IdiomapnlResPartida = { "Resumen Partida" };
            dicpnlResPartida.Add("Idioma", IdiomapnlResPartida);
            this.pnlResPartida.Tag = dicpnlResPartida;



        }


        private void frmPartidaSolicitar_Load(object sender, EventArgs e)
        {

            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            txtMontoTotal.Text = "0";
            TraerLimitePartida();

            ///Traigo Dependencias para busqueda dinámica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

            if (unaSolicitud != null)
            {
                txtNroSolicitud.Text = unaSolicitud.IdSolicitud.ToString();
                txtDep.Text = unaSolicitud.laDependencia.NombreDependencia;

                grillaSolicitudes.DataSource = null;
                ListaSolicitudes = new List<Solicitud>();
                ListaSolicitudes.Add(unaSolicitud);
                grillaSolicitudes.DataSource = ListaSolicitudes;

                if (!cargarDetallesYCotizaciones())
                    this.Close();

            }
        }



        //Pone en null la variable del formulario para que no ocasione error al abrir de nuevo el formulario (porque tiene un singleton)
        private void frmPartidaSolicitar_FormClosing(object sender, FormClosingEventArgs e)
        {
            _unFrmPartidaSolicituar = null;
        }



        //private void grillaSolicDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void grillaSolicDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }


            else
            {
                DataGridView grillaAux = (DataGridView)sender;

                if (e.ColumnIndex == 0)
                {
                    //grillaAux.EndEdit();
                    if (grillaAux.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        var chkCell = (DataGridViewCheckBoxCell)grillaAux.Rows[e.RowIndex].Cells["chkBoxDetalles"];
                        if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = true;
                            int Cont = 1;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
                            {
                                if (Cont <= 3)
                                {
                                    Coti.Seleccionada = true;
                                }
                                else
                                {
                                    Coti.Seleccionada = false;
                                }
                                Cont += 1;
                            }
                        }
                        else //Si se destilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = false;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
                            {
                                Coti.Seleccionada = false;
                            }
                        }
                    }
                }


                ListaCotiz = (List<Cotizacion>)ListaSolicDet[e.RowIndex].unasCotizaciones;

                grillaCotizaciones.DataSource = null;
                //grillaCotizaciones.DataSource = ListaSolicDet[e.RowIndex].unasCotizaciones;
                //foreach (Cotizacion unaCot in ListaSolicDet[e.RowIndex].unasCotizaciones)
                //{
                //    grillaCotizaciones.Rows[ListaSolicDet[e.RowIndex].unasCotizaciones.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                //    grillaAux.EndEdit();
                //}
                grillaCotizaciones.DataSource = ListaCotiz;
                foreach (Cotizacion unaCot in ListaCotiz)
                {
                    grillaCotizaciones.Rows[ListaCotiz.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                    grillaAux.EndEdit();
                }
                PosSolicDet = e.RowIndex;
                CalcularMontoTotalPartida();
            }
        }


        private void grillaCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                DataGridView grillaAuxCot = (DataGridView)sender;
                //grillaAuxCot.EndEdit();
                if (grillaAuxCot.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    var chkCell = (DataGridViewCheckBoxCell)grillaAuxCot.Rows[e.RowIndex].Cells["chkBoxCotizacion"];
                    if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                        ListaSolicDet[PosSolicDet].unasCotizaciones[e.RowIndex].Seleccionada = false;
                    else //Si se destilda
                        ListaSolicDet[PosSolicDet].unasCotizaciones[e.RowIndex].Seleccionada = true;
                    
                    grillaAuxCot.BeginEdit(false);
                    grillaAuxCot.Rows[e.RowIndex].Cells["chkBoxCotizacion"].Value = ListaSolicDet[PosSolicDet].unasCotizaciones[e.RowIndex].Seleccionada;
                    grillaAuxCot.EndEdit();
                    CalcularMontoTotalPartida();
                }
            }
        }


        private void grillaSolicDetalles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridView grillaAux = (DataGridView)sender;
                if (e.ColumnIndex == 0)
                {
                    if (grillaAux.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        var chkCell = (DataGridViewCheckBoxCell)grillaAux.Rows[e.RowIndex].Cells["chkBoxDetalles"];
                        if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = true;
                            int Cont = 1;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
                            {
                                if (Cont <= 3)
                                {
                                    Coti.Seleccionada = true;
                                }
                                else
                                {
                                    Coti.Seleccionada = false;
                                }
                                Cont += 1;
                            }
                        }
                        else //Si se destilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = false;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
                            {
                                Coti.Seleccionada = false;
                            }
                        }
                    }
                }

                ListaCotiz = (List<Cotizacion>)ListaSolicDet[e.RowIndex].unasCotizaciones;

                grillaCotizaciones.DataSource = null;
                //grillaCotizaciones.DataSource = ListaSolicDet[e.RowIndex].unasCotizaciones;
                //foreach (Cotizacion unaCot in ListaSolicDet[e.RowIndex].unasCotizaciones)
                //{
                //    grillaCotizaciones.Rows[ListaSolicDet[e.RowIndex].unasCotizaciones.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                //    grillaAux.EndEdit();
                //}
                grillaCotizaciones.DataSource = ListaCotiz;
                foreach (Cotizacion unaCot in ListaCotiz)
                {
                    grillaCotizaciones.Rows[ListaCotiz.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                    grillaAux.EndEdit();
                }
                PosSolicDet = e.RowIndex;
                CalcularMontoTotalPartida();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (grillaCotizaciones != null)
            {
                foreach (Cotizacion CotAux in ListaSolicDet[0].unasCotizaciones)
                {
                    if (CotAux.Seleccionada)
                    {
                        MessageBox.Show(CotAux.IdCotizacion.ToString() + ": " + CotAux.MontoCotizado.ToString());
                    }

                }

            }
        }



        private void CalcularMontoTotalPartida()
        {
            TotalAcumulado = 0;
            foreach (SolicDetalle unDet in ListaSolicDet.Where(X => X.Seleccionado == true))
            {
                //Suma para obtener el costo total de la partida
                var unaCotizacionAUX = unDet.unasCotizaciones.FirstOrDefault(x => x.Seleccionada == true);
                if (unaCotizacionAUX != null)
                {
                    TotalAcumulado += (unDet.unasCotizaciones.FirstOrDefault(x => x.Seleccionada == true).MontoCotizado * unDet.Cantidad);
                }
                else
                {
                    TotalAcumulado += 0;
                }
            }
            txtMontoTotal.Text = TotalAcumulado.ToString();
        }



        private void TraerLimitePartida()
        {
            BLLPartida PartidaLim = new BLLPartida();
            LimitePartida = PartidaLim.TraerLimitePartida();
        }



        private void btnGenerarPartida_Click(object sender, EventArgs e)
        {
            try
            {
                if (!vldfrmPartidaSolicitarGenerarPar.Validate())
                    return;

                if (grillaCotizaciones.DataSource != null && ListaSolicDet.Any(X => X.Seleccionado == true && X.unasCotizaciones.Count(Y => Y.Seleccionada == true) > 2) && decimal.Parse(txtMontoTotal.Text) > 0 && decimal.Parse(txtMontoTotal.Text) >= TotalAcumulado)
                {
                    if (GenerarPartidaGlobal())
                    {
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Generar Partida").Texto, BLLServicioIdioma.MostrarMensaje("Partida").Texto + " " + nuevaPartida.IdPartida.ToString());
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Solicitud de Partida generada correctamente").Texto);
                        this.Close();
                    }
                        
                }
                else
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revise los detalles, sus cotizaciones, y el Monto Total").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaSolicitar - btnGenerarPartida_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Error al intentar generar la partida, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
            
        }



        private bool GenerarPartidaGlobal()
        {
            
            nuevaPartida = new Partida();
            int Cont = 1;

            nuevaPartida.FechaEnvio = DateTime.Now;
            nuevaPartida.MontoSolicitado = decimal.Parse(txtMontoTotal.Text);

            foreach (SolicDetalle unDeta in ListaSolicDet.Where(X => X.Seleccionado == true))
            {
                PartidaDetalle unaPartDetalle = new PartidaDetalle();

                unaPartDetalle.IdPartidaDetalle = Cont++;
                unaPartDetalle.SolicDetalleAsociado = unDeta;
                unaPartDetalle.SolicDetalleAsociado.unasCotizaciones = unaPartDetalle.SolicDetalleAsociado.unasCotizaciones.Where(r => r.Seleccionada == true).ToList();
                unaPartDetalle.unasCotizaciones = (List<Cotizacion>)unDeta.unasCotizaciones.Where(x => x.Seleccionada == true).ToList();

                nuevaPartida.unasPartidasDetalles.Add(unaPartDetalle);
            }

            if (ManagerPartida.PartidaCrear(nuevaPartida))
            {
                //Crear el documento
                string RutaPlantilla = AppDomain.CurrentDomain.BaseDirectory + "Plantillas\\Plantilla Elevación Partida.docx";
                if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                {
                    using (DocX doc = DocX.Load(RutaPlantilla))
                    {
                        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
                        CultureInfo ci = new CultureInfo("es-AR");
                        doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", nuevaPartida.MontoSolicitado.ToString("C2", ci)));
                        var unaLista = doc.AddList(nuevaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.Cantidad.ToString() + " " + nuevaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0, ListItemType.Bulleted, 1);
                        for (var I = 1; I == nuevaPartida.unasPartidasDetalles.Count() - 1; I++)
                        {
                            doc.AddListItem(unaLista, nuevaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.Cantidad.ToString() + " " + nuevaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0);
                        }
                        doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                        doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + nuevaPartida.IdPartida.ToString() + ".docx");
                    }
                }
                else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                {
                    RutaPlantilla = AppDomain.CurrentDomain.BaseDirectory + "Plantillas\\Plantilla Elevación Partida English.docx";
                    using (DocX doc = DocX.Load(RutaPlantilla))
                    {
                        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
                        CultureInfo ci = new CultureInfo("es-AR");
                        doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", nuevaPartida.MontoSolicitado.ToString("C2", ci)));
                        var unaLista = doc.AddList(nuevaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.Cantidad.ToString() + " " + nuevaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0, ListItemType.Bulleted, 1);
                        for (var I = 1; I == nuevaPartida.unasPartidasDetalles.Count() - 1; I++)
                        {
                            doc.AddListItem(unaLista, nuevaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.Cantidad.ToString() + " " + nuevaPartida.unasPartidasDetalles[I].SolicDetalleAsociado.unaCategoria.DescripCategoria, 0);
                        }
                        doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                        doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + nuevaPartida.IdPartida.ToString() + ".docx");
                    }
                }

                ////Imprimir la partida
                string NombreImpresora = "";
                string file = "";

                //Partida
                if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + nuevaPartida.IdPartida.ToString() + ".docx"))
                {
                    using (PrintDialog printDialog1 = new PrintDialog())
                    {
                        if (printDialog1.ShowDialog() == DialogResult.OK)
                        {
                            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Partida " + nuevaPartida.IdPartida.ToString() + ".docx");
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
                        foreach (PartidaDetalle unaPDet in nuevaPartida.unasPartidasDetalles)
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
            }
            else
            {
                return false;
            }
            return true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(500, 500, 500, 500));
        }  

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();
            ListaSolicitudes = new List<Solicitud>();
            grillaSolicitudes.DataSource = null;
            ListaSolicitudes.Clear();
            grillaSolicDetalles.DataSource = null;
            grillaCotizaciones.DataSource = null;
            ListaSolicDet.Clear();
            ListaCotiz.Clear();

            try
            {
                txtResBusqueda.Visible = false;
                grillaSolicitudes.Visible = true;
                vldFrmPartidaSolicitarBuscar.ClearFailedValidations();

                if (!string.IsNullOrEmpty(txtNroSolicitud.Text) | !string.IsNullOrEmpty(txtDep.Text))
                {
                    if (!string.IsNullOrEmpty(txtNroSolicitud.Text))
                    {
                        if (!vldFrmPartidaSolicitarBuscar.Validate())
                            return;
                        ListaSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
                        txtDep.Clear();
                    }
                    else
                    {
                        ListaSolicitudes = ManagerSolicitud.SolicitudBuscar(txtDep.Text);
                    }
                    grillaSolicitudes.DataSource = null;
                    grillaSolicitudes.DataSource = ListaSolicitudes;
                    grillaSolicitudes.Columns["Asignado"].Visible = true;
                    if (ListaSolicitudes.Count == 0)
                    {
                        grillaSolicitudes.Visible = false;
                        txtResBusqueda.Visible = true;
                    }
                }
                else
                {
                    grillaSolicitudes.DataSource = null;
                    grillaSolicitudes.Visible = false;
                    txtResBusqueda.Visible = true;
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaSolicitar - btnBuscar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Error en la búsqueda, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }



        }


        private void grillaSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            int SolicSeleccionada = e.RowIndex;

            unaSolicitud = ListaSolicitudes[SolicSeleccionada];
            //if (BuscarPartidaAsociada())
                //MessageBox.Show("Existe una partida");
            cargarDetallesYCotizaciones();

        }



        private bool cargarDetallesYCotizaciones()
        {

            grillaSolicDetalles.DataSource = null;
            grillaCotizaciones.DataSource = null;

            if (unaSolicitud != null)
            {
                BLLSolicDetalle ManagerSolicDetalles = new BLLSolicDetalle();
                unaSolicitud.unosDetallesSolicitud = ManagerSolicDetalles.SolicDetallesTraerPorNroSolicitud(unaSolicitud.IdSolicitud);
                //Me fijo si tiene detalles preparados para solicitar una partida
                //if (unaSolicitud.unosDetallesSolicitud != null)
                //{
                    ListaSolicDet = unaSolicitud.unosDetallesSolicitud.Where(x => x.unEstado.IdEstadoSolicDetalle == (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado).ToList();

                    if (ListaSolicDet != null && ListaSolicDet.Count() > 0)
                    {
                        txtNroSolicitud.Text = unaSolicitud.IdSolicitud.ToString();
                        txtDep.Text = unaSolicitud.laDependencia.NombreDependencia;
                        //txtNroSolicitud.ReadOnly = true;
                        ////txtDep.ReadOnly = true;

                        grillaSolicDetalles.DataSource = null;
                        //Carga los detallesSolic que no están finalizados
                        grillaSolicDetalles.DataSource = ListaSolicDet;

                        foreach (DataGridViewRow row in grillaSolicDetalles.Rows)
                        {
                            DataGridViewCheckBoxCell chkDet = (DataGridViewCheckBoxCell)row.Cells[0];
                            chkDet.Value = chkDet.TrueValue;
                        }

                        //Me fijo si tiene cotizaciones
                        if (ListaSolicDet.Find(R => R.unasCotizaciones != null).unasCotizaciones.Count() > 2)
                        {
                            foreach (SolicDetalle unDet in ListaSolicDet)
                            {
                                unDet.Seleccionado = true;
                                int Cont = 1;
                                //Ordena las cotizaciones de cada detalle
                                if (unDet.unasCotizaciones != null && unDet.unasCotizaciones.Count > 0)
                                {
                                    unDet.unasCotizaciones = unDet.unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList();

                                    foreach (Cotizacion unaCoti in unDet.unasCotizaciones)
                                    {
                                        if (Cont <= 3)
                                        {
                                            unaCoti.Seleccionada = true;
                                        }
                                        else
                                        {
                                            unaCoti.Seleccionada = false;
                                        }
                                        Cont += 1;
                                    }
                                    //Suma para obtener el costo total de la partida
                                    TotalAcumulado += (unDet.unasCotizaciones[0].MontoCotizado * unDet.Cantidad);
                                }

                            }
                            txtMontoTotal.Text = TotalAcumulado.ToString();
                        }
                        else
                        {
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor primero agregue 3 cotizaciones antes de generar una Partida").Texto);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Esta Solicitud no tiene detalles disponibles para solicitar una partida").Texto);
                        return false;
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Esta Solicitud no tiene detalles pendientes");//VER:IDIOMA
                //    return false;
                //}
                return true;
            }
            return false;
        }


        //Búsqueda dinámica de dependencias
        private void txtDep_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDep.Text))
            {
                BusquedaDependencias();
            }
            else
            {
                cboDep.Visible = false;
                cboDep.DroppedDown = false;
                cboDep.DataSource = null;
            }
        }


        private void BusquedaDependencias()
        {
            List<Dependencia> res = new List<Dependencia>();
            res = (List<Dependencia>)unasDependencias.ToList();

            List<string> Palabras = new List<string>();
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtDep.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                //ESTO ERA PARA QUE NO QUEDE FLASHADO EL CBOBOX AL PASAR DE MUCHOS RESULTADOS RESULTADO A UNO SOLO AL ESCRIBIR LA FISCALIA JUSTA A MANO, PERO HACIA QUE NO SE EJECUTE BIEN LO DE CARGAR LOS AGENTES
                if (res.Count == 1 && string.Equals(res.First().NombreDependencia, txtDep.Text))
                {
                    cboDep.Visible = false;
                    cboDep.DroppedDown = false;
                    cboDep.DataSource = null;

                }
                else
                {
                    cboDep.DataSource = null;
                    cboDep.DataSource = res;
                    cboDep.DisplayMember = "NombreDependencia";
                    cboDep.ValueMember = "IdDependencia";
                    cboDep.Visible = true;
                    cboDep.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                cboDep.Visible = false;
                cboDep.DroppedDown = false;
                cboDep.DataSource = null;
            }
        }


        private void comboBoxEx4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDep.Text))
            {
                if (cboDep.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtDep.TextChanged -= new System.EventHandler(this.txtDep_TextChanged);
                    txtDep.Text = cbo.GetItemText(cbo.SelectedItem);
                    this.txtDep.TextChanged += new System.EventHandler(this.txtDep_TextChanged);
                    txtDep.SelectionStart = txtDep.Text.Length + 1;
                    cboDep.DataSource = null;
                }
            }
        }



        private bool BuscarPartidaAsociada()
        {
            PartidaAsociada = ManagerPartida.PartidasBuscarPorIdSolicitud(unaSolicitud.IdSolicitud).FirstOrDefault();
            if (PartidaAsociada != null && PartidaAsociada.IdPartida > 0)
                return true;
            return false;
        }

        private void txtNroSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
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