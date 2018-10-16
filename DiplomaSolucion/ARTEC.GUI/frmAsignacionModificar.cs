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
using Novacode;
using System.Globalization;
using ARTEC.BLL.Servicios;

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
        }

        public frmAsignacionModificar(Asignacion unaAsigArg)
        {
            InitializeComponent();
            unaAsignacionSelec = unaAsigArg;
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
            GrillaBienesAsignados.Columns["IdBienEspecif"].Visible = false;
            GrillaBienesAsignados.Columns["unEstado"].Visible = false;
            GrillaBienesAsignados.Columns["PartidaDetalleAsoc"].Visible = false;
            GrillaBienesAsignados.Columns["Costo"].Visible = false;
            GrillaBienesAsignados.Columns["unaAdquisicion"].Visible = false;
            GrillaBienesAsignados.Columns["unTipoBien"].Visible = false;
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

            //Verificar que quede al menos un permiso asignado
            if (InventariosAgregar.Count == 0)
            {
                MessageBox.Show("Por favor revisar que la asignación posea al menos un detalle");
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

                if (ManagerAsignacion.AsignacionModificar(unaAsignacionModif, InvQuitarMod, InvAgregarMod))
                {
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

                    if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)//VER SI ESTA bien el chequeo del idioma
                    {
                        using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2.docx"))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaAsignacionModif.Fecha.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", unaAsignacionModif.unaDependencia.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            //doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", nuevaPartida.MontoSolicitado.ToString("C2", ci)));
                            //Si se escribio una justificación
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
                            //doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            //doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
                            //CultureInfo ci = new CultureInfo("es-AR");
                            //doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", nuevaPartida.MontoSolicitado.ToString("C2", ci)));
                            ////Si se escribio una justificación
                            //if (!string.IsNullOrWhiteSpace(JustifAUX))
                            //{
                            //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                            //}
                            //doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                        }
                    }

                    MessageBox.Show("Modificación realizada");
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsignacionModificar - btnModificar_Click");
                MessageBox.Show("Ocurrio un error al intentar modificar la Asignacion, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Asignación: " + unaAsignacionModif.IdAsignacion.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo);
                if (resmbox == DialogResult.Yes)
                    if (ManagerAsignacion.AsignacionEliminar(unaAsignacionModif))
                    {
                        MessageBox.Show("Asignación: " + unaAsignacionModif.IdAsignacion.ToString() + " eliminada correctamente");
                        DialogResult = DialogResult.No;
                    }
                    else
                        return;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsignacionModificar - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la rendición: " + unaAsignacionModif.IdAsignacion.ToString() + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }


    }
}