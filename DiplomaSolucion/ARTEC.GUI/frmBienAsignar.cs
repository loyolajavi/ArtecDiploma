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
using System.IO;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using System.Globalization;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL.Servicios;
using Xceed.Words.NET;

namespace ARTEC.GUI
{
    public partial class frmBienAsignar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Solicitud unaSolic = new Solicitud();
        BLLInventarioHard ManagerInventarioHard = new BLLInventarioHard();
        List<GrillaAsignacion> ListaGrilla = new List<GrillaAsignacion>();
        List<HLPAsignacion> HLPAsigs = new List<HLPAsignacion>();
        List<Inventario> InventariosAsignar = new List<Inventario>();
        BLLTipoBien managerTipoBienAux = new BLLTipoBien();
        
        Asignacion unaAsignacion = new Asignacion();
        int ConteoDetalles = 0;

        public frmBienAsignar(Solicitud unaSolicAsig)
        {
            InitializeComponent();
            unaSolic = unaSolicAsig;

            Dictionary<string, string[]> dicfrmBienAsignar = new Dictionary<string, string[]>();
            string[] IdiomafrmBienAsignar = { "Asignar Bien" };
            dicfrmBienAsignar.Add("Idioma", IdiomafrmBienAsignar);
            this.Tag = dicfrmBienAsignar;

            Dictionary<string, string[]> diclblNroSolic = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolic = { "Solicitud" };
            diclblNroSolic.Add("Idioma", IdiomalblNroSolic);
            this.lblNroSolic.Tag = diclblNroSolic;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> dicbtnConfirmar = new Dictionary<string, string[]>();
            string[] IdiomabtnConfirmar = { "Confirmar" };
            dicbtnConfirmar.Add("Idioma", IdiomabtnConfirmar);
            this.btnConfirmar.Tag = dicbtnConfirmar;
        }

        private void frmBienAsignar_Load(object sender, EventArgs e)
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
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
            
            txtNroSolic.Text = unaSolic.IdSolicitud.ToString();
            txtDependencia.Text = unaSolic.laDependencia.NombreDependencia;
         
            foreach (var det in unaSolic.unosDetallesSolicitud)
            {

                BLLInventario ManagerInventario = new BLLInventario();
                IEnumerable<Bien> BienInvListosAsignar;
                BienInvListosAsignar = ManagerInventario.InventariosTraerListosParaAsignarPorSolicDetalle(det, det.unaCategoria.IdCategoria);
                if (BienInvListosAsignar != null && BienInvListosAsignar.Count() > 0)
                {
                    TipoBien unTipoBienAux = new TipoBien();
                    unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(det.unaCategoria.IdCategoria);

                    if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        det.unosBienes = BienInvListosAsignar as List<Hardware>;
                    }
                    else
                    {
                        det.unosBienes = BienInvListosAsignar as List<Software>;
                    }
                    HLPAsigs = BienInvListosAsignar.Select(x => new HLPAsignacion() { IdInventario = x.unInventarioAlta.IdInventario, Marca = x.unaMarca.DescripMarca, Modelo = x.unModelo.DescripModeloVersion, Serie = x.unInventarioAlta.SerieKey}).ToList();

                    GrillaAsignacion grillaAsig2 = new GrillaAsignacion();
                    grillaAsig2.ClickEnGrilla += new DataGridViewCellEventHandler(ClickEnGrilla_EventoManejado);
                    grillaAsig2.unaCantidad = det.Cantidad.ToString();
                    grillaAsig2.unBien = det.unaCategoria.DescripCategoria;
                    grillaAsig2.unaGrilla.DataSource = HLPAsigs;

                    ListaGrilla.Add(grillaAsig2);
                }

                

            }

            if (ListaGrilla.Count > 0)
            {
                foreach (GrillaAsignacion gri in ListaGrilla)
                {
                    flowInventarios.Controls.Add(gri);
                }
            }
            else
            {
                MessageBox.Show("La Solicitud no posee bienes disponibles para asignar");
                this.Close();
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
                unTipoBienLocal = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria((unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unaCategoria.IdCategoria));
                if(unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Hardware>)[e.RowIndex].unInventarioAlta;
                else
                    InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Software>)[e.RowIndex].unInventarioAlta;
                InventariosAsignar.Add(InvAUX);

                //Agregado para Asignacion
                AsigDetalle unAsigDet = new AsigDetalle();
                //Conteo Detalles Asig
                ConteoDetalles += 1;
                unAsigDet.IdAsigDetalle = ConteoDetalles;
                
                unAsigDet.unInventario = InvAUX;

                unAsigDet.SolicDetalleAsoc = unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien);

                unaAsignacion.unosAsigDetalles.Add(unAsigDet);
                
               

                //unaAsignacion.unosAsigDetalles//VER DE PONER BIEN EL INVENTARIO Y EL CONTEODETALLES

                GrillaInvConfirmados.DataSource = null;
                GrillaInvConfirmados.DataSource = InventariosAsignar;

                GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }

        }




        private void GrillaDetallesSolic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //TipoBien unTipoBienAux = new TipoBien();
            //BLLTipoBien managerTipoBienAux = new BLLTipoBien();
            //unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unaSolic.unosDetallesSolicitud[e.RowIndex].unaCategoria.IdCategoria);

            //if (unTipoBienAux.IdTipoBien == 1)//Hardware
            //{
            //    List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
            //    LisInvHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(unaSolic.unosDetallesSolicitud[e.RowIndex]);
            //    unaSolic.unosDetallesSolicitud[e.RowIndex].InventariosHard = LisInvHard;


            //    GrillaInvDisponibles.DataSource = null;
            //    GrillaInvDisponibles.DataSource = LisInvHard;
            //}
            //else
            //{
            //    //List<XInventarioSoft> LisInv = new List<XInventarioSoft>();
            //    //LisInvHard = ManagerInventarioSoft.InventarioSoftTraerListosParaAsignar(unaSolic.unosDetallesSolicitud[e.RowIndex]);

            //    //GrillaInvDisponibles.DataSource = null;
            //    //GrillaInvDisponibles.DataSource = LisInvHard;
            //}
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            unaAsignacion.Fecha = DateTime.Today;
            unaAsignacion.unaDependencia = unaSolic.laDependencia;

            BLLAsignacion ManagerAsignacion = new BLLAsignacion();

            try
            {
                if (InventariosAsignar != null && InventariosAsignar.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione al menos un bien a asignar");
                    return;
                }

                if (ManagerAsignacion.AsignacionCrear(unaAsignacion, unaSolic))
                {
                    //Crear el documento
                    string RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Asignacion.docx";
                    if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
                    {
                        using (DocX doc = DocX.Load(RutaPlantilla))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaAsignacion.Fecha.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", unaAsignacion.unaDependencia.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            var unaLista = doc.AddList("Bien: " + unaAsignacion.unosAsigDetalles[0].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacion.unosAsigDetalles[0].unInventario.SerieKey, 0, ListItemType.Bulleted, 1);
                            for (var I = 1; I == unaAsignacion.unosAsigDetalles.Count() - 1; I++)
                            {
                                doc.AddListItem(unaLista, "Bien: " + unaAsignacion.unosAsigDetalles[I].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacion.unosAsigDetalles[I].unInventario.SerieKey, 0);
                            }
                            doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                            doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacion.IdAsignacion.ToString() + ".docx");
                        }
                    }
                    else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                    {
                        RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Asignacion English.docx";
                        using (DocX doc = DocX.Load(RutaPlantilla))
                        {
                            doc.AddCustomProperty(new CustomProperty("PFecha", unaAsignacion.Fecha.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                            doc.AddCustomProperty(new CustomProperty("PDependencia", unaAsignacion.unaDependencia.NombreDependencia));
                            CultureInfo ci = new CultureInfo("es-AR");
                            var unaLista = doc.AddList("Bien: " + unaAsignacion.unosAsigDetalles[0].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacion.unosAsigDetalles[0].unInventario.SerieKey, 0, ListItemType.Bulleted, 1);
                            for (var I = 1; I == unaAsignacion.unosAsigDetalles.Count() - 1; I++)
                            {
                                doc.AddListItem(unaLista, "Bien: " + unaAsignacion.unosAsigDetalles[I].unInventario.deBien.DescripBien + " - Serie: " + unaAsignacion.unosAsigDetalles[I].unInventario.SerieKey, 0);
                            }
                            doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                            doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacion.IdAsignacion.ToString() + ".docx");
                        }
                    }

                    ////Imprimir la Asignacion
                    string NombreImpresora = "";

                    if (File.Exists(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacion.IdAsignacion.ToString() + ".docx"))
                    {
                        using (PrintDialog printDialog1 = new PrintDialog())
                        {
                            if (printDialog1.ShowDialog() == DialogResult.OK)
                            {
                                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Asignacion " + unaAsignacion.IdAsignacion.ToString() + ".docx");
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
                    MessageBox.Show("Asignacion Creada correctamente");
                    this.Close();
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmBienAsignar - btnConfirmar_Click");
                MessageBox.Show("Error al crear la asignación, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
                
        }







    }
}