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
using ARTEC.ENTIDADES.Helpers;
using System.Linq;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using System.Globalization;
using ARTEC.BLL.Servicios;
using Xceed.Words.NET;
using System.IO;

namespace ARTEC.GUI
{
    public partial class frmAsignacionModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Asignacion unaAsignacionSelec;
        BLLAsignacion ManagerAsignacion = new BLLAsignacion();
        BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
        BLLSolicitud ManagerSolicitud = new BLLSolicitud();
        BLLTipoBien ManagerTipoBienAux = new BLLTipoBien();
        List<HLPAsignacion> HLPAsigs = new List<HLPAsignacion>();
        List<GrillaAsignacion> ListaGrilla = new List<GrillaAsignacion>();
        Solicitud unaSolic = new Solicitud();
        //List<Inventario> InventariosAsignar = new List<Inventario>();
        //Asignacion unaAsignacion = new Asignacion();
        int ConteoDetalles = 0;
        List<Inventario> InventariosAgregar = new List<Inventario>();
        List<Inventario> InventariosAgregarBKP = new List<Inventario>();
        Asignacion unaAsignacionModif = new Asignacion();

        public frmAsignacionModificar()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmAsignacionModificar = new Dictionary<string, string[]>();
            string[] IdiomafrmAsignacionModificar = { "Modificar Asignación" };
            dicfrmAsignacionModificar.Add("Idioma", IdiomafrmAsignacionModificar);
            this.Tag = dicfrmAsignacionModificar;

            Dictionary<string, string[]> diclblNroAsignacion = new Dictionary<string, string[]>();
            string[] IdiomalblNroAsignacion = { "Asignación" };
            diclblNroAsignacion.Add("Idioma", IdiomalblNroAsignacion);
            this.lblNroAsignacion.Tag = diclblNroAsignacion;

            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Dependencia" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;

            Dictionary<string, string[]> diclblNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolicitud = { "Solicitud" };
            diclblNroSolicitud.Add("Idioma", IdiomalblNroSolicitud);
            this.lblNroSolicitud.Tag = diclblNroSolicitud;

            Dictionary<string, string[]> diclblFecha = new Dictionary<string, string[]>();
            string[] IdiomalblFecha = { "Fecha" };
            diclblFecha.Add("Idioma", IdiomalblFecha);
            this.lblFecha.Tag = diclblFecha;

            Dictionary<string, string[]> diclabelX2 = new Dictionary<string, string[]>();
            string[] IdiomalabelX2 = { "Bienes Asignados" };
            diclabelX2.Add("Idioma", IdiomalabelX2);
            this.labelX2.Tag = diclabelX2;

            Dictionary<string, string[]> dicbtnBienesRestantes = new Dictionary<string, string[]>();
            string[] IdiomabtnBienesRestantes = { "Bienes Restantes" };
            dicbtnBienesRestantes.Add("Idioma", IdiomabtnBienesRestantes);
            this.btnBienesRestantes.Tag = dicbtnBienesRestantes;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

        }

        public frmAsignacionModificar(Asignacion unaAsigArg)
        {
            InitializeComponent();
            unaAsignacionSelec = unaAsigArg;

            Dictionary<string, string[]> dicfrmAsignacionModificar = new Dictionary<string, string[]>();
            string[] IdiomafrmAsignacionModificar = { "Modificar Asignación" };
            dicfrmAsignacionModificar.Add("Idioma", IdiomafrmAsignacionModificar);
            this.Tag = dicfrmAsignacionModificar;

            Dictionary<string, string[]> diclblNroAsignacion = new Dictionary<string, string[]>();
            string[] IdiomalblNroAsignacion = { "Asignación" };
            diclblNroAsignacion.Add("Idioma", IdiomalblNroAsignacion);
            this.lblNroAsignacion.Tag = diclblNroAsignacion;

            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Dependencia" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;

            Dictionary<string, string[]> diclblNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolicitud = { "Solicitud" };
            diclblNroSolicitud.Add("Idioma", IdiomalblNroSolicitud);
            this.lblNroSolicitud.Tag = diclblNroSolicitud;

            Dictionary<string, string[]> diclblFecha = new Dictionary<string, string[]>();
            string[] IdiomalblFecha = { "Fecha" };
            diclblFecha.Add("Idioma", IdiomalblFecha);
            this.lblFecha.Tag = diclblFecha;

            Dictionary<string, string[]> diclabelX2 = new Dictionary<string, string[]>();
            string[] IdiomalabelX2 = { "Bienes Asignados" };
            diclabelX2.Add("Idioma", IdiomalabelX2);
            this.labelX2.Tag = diclabelX2;

            Dictionary<string, string[]> dicbtnBienesRestantes = new Dictionary<string, string[]>();
            string[] IdiomabtnBienesRestantes = { "Bienes Restantes" };
            dicbtnBienesRestantes.Add("Idioma", IdiomabtnBienesRestantes);
            this.btnBienesRestantes.Tag = dicbtnBienesRestantes;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

        }

        private void frmAsignacionModificar_Load(object sender, EventArgs e)
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

                //Idioma
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                if (unaAsignacionSelec != null)
                {
                    txtAsignacion.Text = unaAsignacionSelec.IdAsignacion.ToString();
                    txtDep.Text = unaAsignacionSelec.unaDependencia.NombreDependencia;
                    txtNroSolicitud.Text = unaAsignacionSelec.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud.ToString();
                    txtFecha.Text = unaAsignacionSelec.Fecha.ToString();
                    InventariosAgregar.Clear();
                    InventariosAgregar = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsignacionSelec.IdAsignacion);
                    InventariosAgregarBKP = InventariosAgregar.ToList();
                    GrillaBienesAsignados.DataSource = null;
                    GrillaBienesAsignados.DataSource = InventariosAgregar;
                    FormatearGrillaBienesAsignados();
                    unaAsignacionModif = unaAsignacionSelec;

                    unaAsignacionModif.unosAsigDetalles = ManagerAsignacion.AsigDetallesTraer(unaAsignacionSelec.IdAsignacion);

                    for (int i = 0; i < unaAsignacionModif.unosAsigDetalles.Count; i++)
			        {
			            unaAsignacionModif.unosAsigDetalles[i].unInventario = InventariosAgregar[i];
			        }   
                }
            }
            catch (Exception es)
            {
                throw;
            }

         

        }

        private void btnBienesRestantes_Click(object sender, EventArgs e)
        {
            flowBienesAAsignar.Visible = false;
            flowBienesAAsignar.Controls.Clear();
            ListaGrilla.Clear();

            unaSolic.unosDetallesSolicitud = ManagerSolicitud.SolicitudTraerDetalles(unaAsignacionModif.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud).unosDetallesSolicitud;

            foreach (SolicDetalle det in unaSolic.unosDetallesSolicitud)
            {

                BLLInventario ManagerInventario = new BLLInventario();
                IEnumerable<Bien> BienInvListosAsignar;
                BienInvListosAsignar = ManagerInventario.InventariosTraerListosParaAsignarPorSolicDetalle(det, det.unaCategoria.IdCategoria);
                if (BienInvListosAsignar != null && BienInvListosAsignar.Count() > 0)
                {
                    TipoBien unTipoBienAux = new TipoBien();
                    unTipoBienAux = ManagerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(det.unaCategoria.IdCategoria);

                    if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        det.unosBienes = BienInvListosAsignar as List<Hardware>;
                    }
                    else
                    {
                        det.unosBienes = BienInvListosAsignar as List<Software>;
                    }
                    HLPAsigs = BienInvListosAsignar.Select(x => new HLPAsignacion() { IdInventario = x.unInventarioAlta.IdInventario, Marca = x.unaMarca.DescripMarca, Modelo = x.unModelo.DescripModeloVersion, Serie = x.unInventarioAlta.SerieKey }).ToList();

                    GrillaAsignacion grillaAsig2 = new GrillaAsignacion();
                    grillaAsig2.ClickEnGrilla += new DataGridViewCellEventHandler(ClickEnGrilla_EventoManejado);
                    grillaAsig2.unaCantidad = det.Cantidad.ToString();
                    grillaAsig2.unBien = det.unaCategoria.DescripCategoria;
                    grillaAsig2.unaGrilla.DataSource = HLPAsigs;

                    ListaGrilla.Add(grillaAsig2);
                }


            }

            foreach (GrillaAsignacion gri in ListaGrilla)
            {
                flowBienesAAsignar.Controls.Add(gri);
            }
            if (flowBienesAAsignar.Controls.Count > 0)
            {
                flowBienesAAsignar.Visible = true;
            }
        }



        protected void ClickEnGrilla_EventoManejado(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            GrillaAsignacion GrillaActual = (GrillaAsignacion)sender;

            if (GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGray)
            {
                Inventario InvAUX;
                TipoBien unTipoBienLocal = new TipoBien();
                unTipoBienLocal = ManagerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria((unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unaCategoria.IdCategoria));
                if (unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Hardware>)[e.RowIndex].unInventarioAlta;
                else
                    InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Software>)[e.RowIndex].unInventarioAlta;
                InventariosAgregar.Add(InvAUX);

                //Agregado para Asignacion
                AsigDetalle unAsigDet = new AsigDetalle();
                //Conteo Detalles Asig
                ConteoDetalles += 1;
                unAsigDet.IdAsigDetalle = ConteoDetalles;

                unAsigDet.unInventario = InvAUX;

                unAsigDet.SolicDetalleAsoc = unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien);

                unaAsignacionModif.unosAsigDetalles.Add(unAsigDet);

                GrillaBienesAsignados.DataSource = null;
                GrillaBienesAsignados.DataSource = InventariosAgregar;
                FormatearGrillaBienesAsignados();
                GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }

        }


        private void FormatearGrillaBienesAsignados()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaBienesAsignados.Columns.Contains("btnDinBorrar"))
                GrillaBienesAsignados.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaBienesAsignados.Columns.Add(deleteButton);

            //Formato GrillaBienesAsignados
            GrillaBienesAsignados.Columns["IdInventario"].Visible = false;
            GrillaBienesAsignados.Columns["deBien"].Visible = false;
            GrillaBienesAsignados.Columns["unEstado"].Visible = false;
            GrillaBienesAsignados.Columns["PartidaDetalleAsoc"].Visible = false;
            GrillaBienesAsignados.Columns["Costo"].Visible = false;
            GrillaBienesAsignados.Columns["unaAdquisicion"].Visible = false;
            GrillaBienesAsignados.Columns["elTipoBien"].Visible = false;
        }


        private void GrillaBienesAsignados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaBienesAsignados.Columns["btnDinBorrar"].Index)
                {
                    //unaAsignacionModif.unosAsigDetalles.RemoveAll(x => x.unInventario.IdInventario == InventariosAgregar[e.RowIndex].IdInventario);
                    InventariosAgregar.RemoveAt(e.RowIndex);
                    
                    //Regenero la grilla
                    GrillaBienesAsignados.DataSource = null;
                    GrillaBienesAsignados.DataSource = InventariosAgregar;
                    FormatearGrillaBienesAsignados();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<Inventario> InvQuitarMod = new List<Inventario>();
            List<Inventario> InvAgregarMod = new List<Inventario>();

            if (!vldFrmAsignacionModificar.Validate())
                return;

            //Verificar que quede al menos un Detalle
            if (InventariosAgregar.Count == 0)
            {
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revisar que la asignación posea al menos un detalle").Texto);
                InventariosAgregar.Clear();
                InventariosAgregar = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsignacionSelec.IdAsignacion);
                InventariosAgregarBKP = InventariosAgregar.ToList();
                GrillaBienesAsignados.DataSource = null;
                GrillaBienesAsignados.DataSource = InventariosAgregar;
                FormatearGrillaBienesAsignados();
                flowBienesAAsignar.Visible = false;
                flowBienesAAsignar.Controls.Clear();
                unaAsignacionModif.unosAsigDetalles = ManagerAsignacion.AsigDetallesTraer(unaAsignacionSelec.IdAsignacion);
                for (int i = 0; i < unaAsignacionModif.unosAsigDetalles.Count; i++)
                {
                    unaAsignacionModif.unosAsigDetalles[i].unInventario = InventariosAgregar[i];
                }
                ListaGrilla.Clear();
                return;
            }

            try
            {
                
                if (!string.IsNullOrEmpty(txtFecha.Text))
                    unaAsignacionModif.Fecha = DateTime.Parse(txtFecha.Text);
                else
                    return;

                InvQuitarMod = InventariosAgregarBKP.Where(d => !InventariosAgregar.Any(a => a.IdInventario == d.IdInventario)).ToList();
                InvAgregarMod = InventariosAgregar.Where(d => !InventariosAgregarBKP.Any(a => a.IdInventario == d.IdInventario)).ToList();

                ManagerAsignacion.AsignacionModificar(unaAsignacionModif, InvQuitarMod, InvAgregarMod);
                    InventariosAgregar.Clear();
                    InventariosAgregar = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsignacionSelec.IdAsignacion);
                    InventariosAgregarBKP = InventariosAgregar.ToList();
                    GrillaBienesAsignados.DataSource = null;
                    GrillaBienesAsignados.DataSource = InventariosAgregar;
                    FormatearGrillaBienesAsignados();
                    flowBienesAAsignar.Visible = false;
                    flowBienesAAsignar.Controls.Clear();
                    unaAsignacionModif.unosAsigDetalles = ManagerAsignacion.AsigDetallesTraer(unaAsignacionSelec.IdAsignacion);
                    for (int i = 0; i < unaAsignacionModif.unosAsigDetalles.Count; i++)
                    {
                        unaAsignacionModif.unosAsigDetalles[i].unInventario = InventariosAgregar[i];
                    }   
                    ListaGrilla.Clear();


                    //Crear el documento
                    string RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Asignacion.docx";
                    if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                    {
                        using (DocX doc = DocX.Load(RutaPlantilla))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaAsignacionModif.Fecha.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", unaAsignacionModif.unaDependencia.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            var unaLista = doc.AddList("Bien: " + unaAsignacionModif.unosAsigDetalles[0].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacionModif.unosAsigDetalles[0].unInventario.SerieKey, 0, ListItemType.Bulleted, 1);
                            for (var I = 1; I == unaAsignacionModif.unosAsigDetalles.Count() - 1; I++)
                            {
                                doc.AddListItem(unaLista, "Bien: " + unaAsignacionModif.unosAsigDetalles[I].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacionModif.unosAsigDetalles[I].unInventario.SerieKey, 0);
                            }
                            doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                            doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacionModif.IdAsignacion.ToString() + ".docx");
                        }
                    }
                    else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                    {
                        RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Asignacion English.docx";
                        using (DocX doc = DocX.Load(RutaPlantilla))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaAsignacionModif.Fecha.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", unaAsignacionModif.unaDependencia.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            var unaLista = doc.AddList("Bien: " + unaAsignacionModif.unosAsigDetalles[0].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacionModif.unosAsigDetalles[0].unInventario.SerieKey, 0, ListItemType.Bulleted, 1);
                            for (var I = 1; I == unaAsignacionModif.unosAsigDetalles.Count() - 1; I++)
                            {
                                doc.AddListItem(unaLista, "Bien: " + unaAsignacionModif.unosAsigDetalles[I].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacionModif.unosAsigDetalles[I].unInventario.SerieKey, 0);
                            }
                            doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                            doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacionModif.IdAsignacion.ToString() + ".docx");
                        }
                    }

                    ////Imprimir la Asignacion
                    string NombreImpresora = "";

                    if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacionModif.IdAsignacion.ToString() + ".docx"))
                    {
                        using (PrintDialog printDialog1 = new PrintDialog())
                        {
                            if (printDialog1.ShowDialog() == DialogResult.OK)
                            {
                                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacionModif.IdAsignacion.ToString() + ".docx");
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
                    ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Modificar Asignación").Texto, BLLServicioIdioma.MostrarMensaje("Asignacion: ").Texto + unaAsignacionModif.IdAsignacion.ToString());
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada correctamente").Texto);
                    DialogResult = DialogResult.OK;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsignacionModificar - btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar la Asignacion, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                 BLLSolicitud ManagerSolicitud = new BLLSolicitud();
                 int EstadoSolic = ManagerSolicitud.SolicitudBuscar(unaAsignacionSelec.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud).FirstOrDefault().UnEstado.IdEstadoSolicitud;
                if (EstadoSolic == (int)EstadoSolicitud.EnumEstadoSolicitud.Pendiente)
                {
                    DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja la Asignación: ").Texto + unaAsignacionModif.IdAsignacion.ToString() + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        ManagerAsignacion.AsignacionEliminar(unaAsignacionModif);
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Eliminar Asignación").Texto, BLLServicioIdioma.MostrarMensaje("Asignacion: ").Texto + unaAsignacionModif.IdAsignacion.ToString());
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Asignación: ").Texto + unaAsignacionModif.IdAsignacion.ToString() + BLLServicioIdioma.MostrarMensaje(" eliminada correctamente").Texto);
                        DialogResult = DialogResult.No;
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Asignación no puede eliminarse ya que la Solicitud asociada se encuentra Finalizada o Cancelada").Texto);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsignacionModificar - btnEliminar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar eliminar la rendición: ").Texto + unaAsignacionModif.IdAsignacion.ToString() + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }


    }
}