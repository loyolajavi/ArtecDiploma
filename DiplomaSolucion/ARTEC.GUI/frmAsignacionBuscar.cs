using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL;
using ARTEC.ENTIDADES;
using System.Linq;
using ARTEC.BLL.Servicios;
using System.Text.RegularExpressions;


namespace ARTEC.GUI
{
    public partial class frmAsignacionBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmAsignacionBuscar _unFrmAsignacionBuscar;
        BLLAsignacion ManagerAsignacion = new BLLAsignacion();
        List<Asignacion> unasAsignaciones = new List<Asignacion>();
        List<GrillaAsigBuscarCU> ListaGrilla = new List<GrillaAsigBuscarCU>();
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Dependencia DepSeleccionada;

        public frmAsignacionBuscar()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmAsigBuscar = new Dictionary<string, string[]>();
            string[] PerfrmAsigBuscar = { "Asignacion Buscar" };
            dicfrmAsigBuscar.Add("Permisos", PerfrmAsigBuscar);
            this.Tag = dicfrmAsigBuscar;

            Dictionary<string, string[]> diclblNroAsignacion = new Dictionary<string, string[]>();
            string[] IdiomalblNroAsignacion = { "Asignación" };
            diclblNroAsignacion.Add("Idioma", IdiomalblNroAsignacion);
            this.lblNroAsignacion.Tag = diclblNroAsignacion;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolicitud = { "Solicitud" };
            diclblNroSolicitud.Add("Idioma", IdiomalblNroSolicitud);
            this.lblNroSolicitud.Tag = diclblNroSolicitud;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> dictxtResBusqueda = new Dictionary<string, string[]>();
            string[] IdiomatxtResBusqueda = { "No hay resultados" };
            dictxtResBusqueda.Add("Idioma", IdiomatxtResBusqueda);
            this.txtResBusqueda.Tag = dictxtResBusqueda;

            Dictionary<string, string[]> diclblDesde = new Dictionary<string, string[]>();
            string[] IdiomalblDesde = { "Desde" };
            diclblDesde.Add("Idioma", IdiomalblDesde);
            this.lblDesde.Tag = diclblDesde;

            Dictionary<string, string[]> diclblHasta = new Dictionary<string, string[]>();
            string[] IdiomalblHasta = { "Hasta" };
            diclblHasta.Add("Idioma", IdiomalblHasta);
            this.lblHasta.Tag = diclblHasta;

        }

        public static frmAsignacionBuscar ObtenerInstancia()
        {
            if (_unFrmAsignacionBuscar == null)
            {
                _unFrmAsignacionBuscar = new frmAsignacionBuscar();
            }

            return _unFrmAsignacionBuscar;
        }


        private void frmAsignacionBuscar_Load(object sender, EventArgs e)
        {
            //txtFechaDesde.Text = DateTime.Today.AddDays(-31).ToString();
            //txtFechaHasta.Text = DateTime.Today.ToString();

            //Permisos
            //Permisos para habilitar formulario
            if (this.Tag != null && this.Tag.GetType() == typeof(Dictionary<string, string[]>) && (this.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
            {
                this.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((this.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
            }

            ////Permisos para Controles
            ////Obtengo todos los controles del formulario
            //IEnumerable<Control> unosTextBox = BLLServicioIdioma.ObtenerControles(this);
            //foreach (Control unControl in unosTextBox)
            //{
            //    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(string[]))
            //    {
            //        if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, this.Tag as string[]))
            //        {
            //            unControl.Enabled = false;
            //        }
            //    }
            //}

            //Idioma
            BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            ///Traigo Dependencias para busqueda dinámica
            BLLDependencia ManagerDependencia = new BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            flowAsignaciones.Controls.Clear();
            ListaGrilla.Clear();
            txtResBusqueda.Visible = false;

            if (!vldFrmAsignacionBuscar.Validate())
                return;
            
            try
            {
                if (!string.IsNullOrEmpty(txtAsignacion.Text) | !string.IsNullOrEmpty(txtDependencia.Text) | !string.IsNullOrEmpty(txtNroSolicitud.Text) | !string.IsNullOrEmpty(txtFechaDesde.Text) | !string.IsNullOrEmpty(txtFechaHasta.Text) && !txtAsignacion.Text.Contains("%") & !txtDependencia.Text.Contains("%") & !txtNroSolicitud.Text.Contains("%") & !txtAsignacion.Text.Contains("_") & !txtDependencia.Text.Contains("_") & !txtNroSolicitud.Text.Contains("_"))
                {
                    unasAsignaciones = ManagerAsignacion.AsignacionBuscar(txtAsignacion.Text, txtDependencia.Text, txtNroSolicitud.Text, (DateTime?)txtFechaDesde.Value, (DateTime?)txtFechaHasta.Value);

                    if (unasAsignaciones.Count > 0)
                    {
                        foreach (Asignacion unaAsig in unasAsignaciones)
                        {
                            GrillaAsigBuscarCU GrillaAux = new GrillaAsigBuscarCU();
                            GrillaAux.ClickEnGrilla += new DataGridViewCellEventHandler(ClickEnGrilla_EventoManejado);
                            GrillaAux.ClickEnPanel += new EventHandler(ClickEnGrilla_EventoManejado);

                            GrillaAux.IdAsignacion = unaAsig.IdAsignacion.ToString();
                            GrillaAux.NombreDependencia = unaAsig.unaDependencia.NombreDependencia;
                            GrillaAux.IdSolicitud = unaAsig.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud.ToString();
                            GrillaAux.laFecha = unaAsig.Fecha.ToString();
                            GrillaAux.unaGrilla.DataSource = null;
                            GrillaAux.unaGrilla.DataSource = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsig.IdAsignacion);
                            GrillaAux.unaGrilla.Columns["IdInventario"].Visible = false;
                            GrillaAux.unaGrilla.Columns["IdBienEspecif"].Visible = false;
                            GrillaAux.unaGrilla.Columns["unEstado"].Visible = false;
                            GrillaAux.unaGrilla.Columns["PartidaDetalleAsoc"].Visible = false;
                            GrillaAux.unaGrilla.Columns["Costo"].Visible = false;
                            GrillaAux.unaGrilla.Columns["unaAdquisicion"].Visible = false;
                            GrillaAux.unaGrilla.Columns["unTipoBien"].Visible = false;

                            ListaGrilla.Add(GrillaAux);
                        }

                        foreach (GrillaAsigBuscarCU gri in ListaGrilla)
                        {
                            flowAsignaciones.Controls.Add(gri);
                        }
                    }

                    if (flowAsignaciones.Controls.Count == 0)
                    {
                        txtResBusqueda.Visible = true;
                        flowAsignaciones.Controls.Add(txtResBusqueda);
                    }
   
                }
                else
                {
                    txtResBusqueda.Visible = true;
                    flowAsignaciones.Controls.Add(txtResBusqueda);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsignacionBuscar - btnBuscar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Error en la búsqueda, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }


        protected void ClickEnGrilla_EventoManejado(object sender, EventArgs e)
        {

            
            ////Si se hizo click en el header, salir
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //{
            //    return;
            //}

            GrillaAsigBuscarCU GrillaActual = (GrillaAsigBuscarCU)sender;
            DialogResult ResFrmAsignacionModif = new DialogResult();

            frmAsignacionModificar unFrmAsignacionModificar = new frmAsignacionModificar((Asignacion)unasAsignaciones.Where(x => x.IdAsignacion == Int32.Parse(GrillaActual.IdAsignacion)).FirstOrDefault());
            ResFrmAsignacionModif = unFrmAsignacionModificar.ShowDialog();

            if (ResFrmAsignacionModif == DialogResult.OK)
            {
                flowAsignaciones.Controls.Clear();
                ListaGrilla.Clear();
                txtResBusqueda.Visible = false;

                if (unasAsignaciones.Count > 0)
                {
                    foreach (Asignacion unaAsig in unasAsignaciones)
                    {
                        GrillaAsigBuscarCU GrillaAux = new GrillaAsigBuscarCU();
                        GrillaAux.ClickEnGrilla += new DataGridViewCellEventHandler(ClickEnGrilla_EventoManejado);
                        GrillaAux.ClickEnPanel += new EventHandler(ClickEnGrilla_EventoManejado);

                        GrillaAux.IdAsignacion = unaAsig.IdAsignacion.ToString();
                        GrillaAux.NombreDependencia = unaAsig.unaDependencia.NombreDependencia;
                        GrillaAux.IdSolicitud = unaAsig.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud.ToString();
                        GrillaAux.laFecha = unaAsig.Fecha.ToString();
                        GrillaAux.unaGrilla.DataSource = null;
                        GrillaAux.unaGrilla.DataSource = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsig.IdAsignacion);
                        GrillaAux.unaGrilla.Columns["IdInventario"].Visible = false;
                        GrillaAux.unaGrilla.Columns["IdBienEspecif"].Visible = false;
                        GrillaAux.unaGrilla.Columns["unEstado"].Visible = false;
                        GrillaAux.unaGrilla.Columns["PartidaDetalleAsoc"].Visible = false;
                        GrillaAux.unaGrilla.Columns["Costo"].Visible = false;
                        GrillaAux.unaGrilla.Columns["unaAdquisicion"].Visible = false;
                        GrillaAux.unaGrilla.Columns["unTipoBien"].Visible = false;

                        ListaGrilla.Add(GrillaAux);
                    }

                    foreach (GrillaAsigBuscarCU gri in ListaGrilla)
                    {
                        flowAsignaciones.Controls.Add(gri);
                    }
                }

                if (flowAsignaciones.Controls.Count == 0)
                {
                    txtResBusqueda.Visible = true;
                    flowAsignaciones.Controls.Add(txtResBusqueda);
                }
            }
            else if (ResFrmAsignacionModif == DialogResult.No)
            {
                flowAsignaciones.Controls.Clear();
                ListaGrilla.Clear();
                txtResBusqueda.Visible = false;
                txtAsignacion.Clear();
                txtDependencia.Clear();
                txtFechaDesde.Refresh();
                txtFechaHasta.Refresh();
                txtNroSolicitud.Clear();
            }


            //if (GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGray)
            //{
            //    Inventario InvAUX;
            //    TipoBien unTipoBienLocal = new TipoBien();
            //    unTipoBienLocal = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria((unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unaCategoria.IdCategoria));
            //    if (unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
            //        InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Hardware>)[e.RowIndex].unInventarioAlta;
            //    else
            //        InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Software>)[e.RowIndex].unInventarioAlta;
            //    InventariosAsignar.Add(InvAUX);

            //    //Agregado para Asignacion
            //    AsigDetalle unAsigDet = new AsigDetalle();
            //    //Conteo Detalles Asig
            //    ConteoDetalles += 1;
            //    unAsigDet.IdAsigDetalle = ConteoDetalles;

            //    unAsigDet.unInventario = InvAUX;

            //    unAsigDet.SolicDetalleAsoc = unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien);

            //    unaAsignacion.unosAsigDetalles.Add(unAsigDet);



            //    //unaAsignacion.unosAsigDetalles//VER DE PONER BIEN EL INVENTARIO Y EL CONTEODETALLES

            //    GrillaInvConfirmados.DataSource = null;
            //    GrillaInvConfirmados.DataSource = InventariosAsignar;

            //    GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            //}

        }



        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            DepSeleccionada = null;

            if (!string.IsNullOrWhiteSpace(txtDependencia.Text) & txtDependencia.TextLength >= 3 || !string.IsNullOrWhiteSpace(txtDependencia.Text) & txtDependencia.TextLength <= 2 & Regex.IsMatch(txtDependencia.Text, @"\d"))
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
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtDependencia.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                if (res.Count == 1 && string.Equals(res.First().NombreDependencia, txtDependencia.Text))
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


        private void cboDep_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDependencia.Text))
            {
                if (cboDep.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtDependencia.TextChanged -= new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDependencia.Text = cbo.GetItemText(cbo.SelectedItem);
                    DepSeleccionada = cbo.SelectedItem as Dependencia;
                    this.txtDependencia.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDependencia.SelectionStart = txtDependencia.Text.Length + 1;
                }
            }
        }



        public void Recargar()
        {
            flowAsignaciones.Controls.Clear();
            ListaGrilla.Clear();
            txtResBusqueda.Visible = false;
            frmAsignacionBuscar_Load(this, new EventArgs());

            //Limpiar textbox y cbobox
            List<Control> unosTextBox = this.Controls
            .OfType<TextBox>()
            .ToList<Control>();
            foreach (Control unControl in unosTextBox) unControl.Text = null;

            List<Control> unosComboBox = this.Controls
            .OfType<ComboBox>()
            .ToList<Control>();
            foreach (Control unControl in unosComboBox) if ((unControl as ComboBox).Items.Count > 0) (unControl as ComboBox).SelectedIndex = 0;
        }

        private void frmAsignacionBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }




    }
}