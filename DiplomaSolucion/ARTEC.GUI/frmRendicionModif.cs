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

namespace ARTEC.GUI
{
    public partial class frmRendicionModif : DevComponents.DotNetBar.Metro.MetroForm
    {

        Rendicion unaRendicionSelec;
        Rendicion unaRendicion = new Rendicion();
        BLLRendicion ManagerRendicion = new BLLRendicion();
        List<GrillaRendicion> ListaMultiGrillaRendicion = new List<GrillaRendicion>();
        List<HLPInvRendicion> HLPListaInventariosRend = new List<HLPInvRendicion>();
        Partida unaPartida = new Partida();

        public frmRendicionModif()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmRendicionModif = new Dictionary<string, string[]>();
            string[] IdiomafrmRendicionModif = { "Modificar Rendición" };
            dicfrmRendicionModif.Add("Idioma", IdiomafrmRendicionModif);
            this.Tag = dicfrmRendicionModif;

            Dictionary<string, string[]> diclblNroRendicion = new Dictionary<string, string[]>();
            string[] IdiomalblNroRendicion = { "Rendición" };
            diclblNroRendicion.Add("Idioma", IdiomalblNroRendicion);
            this.lblNroRendicion.Tag = diclblNroRendicion;

            Dictionary<string, string[]> diclblNroPartida = new Dictionary<string, string[]>();
            string[] IdiomalblNroPartida = { "Partida" };
            diclblNroPartida.Add("Idioma", IdiomalblNroPartida);
            this.lblNroPartida.Tag = diclblNroPartida;

            Dictionary<string, string[]> diclblNroSolic = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolic = { "Solicitud" };
            diclblNroSolic.Add("Idioma", IdiomalblNroSolic);
            this.lblNroSolic.Tag = diclblNroSolic;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Partida Referenciada" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;

            Dictionary<string, string[]> diclblMontoOtorgado = new Dictionary<string, string[]>();
            string[] IdiomalblMontoOtorgado = { "Monto Otorgado" };
            diclblMontoOtorgado.Add("Idioma", IdiomalblMontoOtorgado);
            this.lblMontoOtorgado.Tag = diclblMontoOtorgado;

            Dictionary<string, string[]> diclabelX3 = new Dictionary<string, string[]>();
            string[] IdiomalabelX3 = { "Monto Empleado" };
            diclabelX3.Add("Idioma", IdiomalabelX3);
            this.labelX3.Tag = diclabelX3;

            Dictionary<string, string[]> dicbtnGenerar = new Dictionary<string, string[]>();
            string[] IdiomabtnGenerar = { "Generar" };
            dicbtnGenerar.Add("Idioma", IdiomabtnGenerar);
            this.btnGenerar.Tag = dicbtnGenerar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

        }


        public frmRendicionModif(Rendicion unaRen)
        {
            InitializeComponent();
            unaRendicionSelec = unaRen;

            Dictionary<string, string[]> dicfrmRendicionModif = new Dictionary<string, string[]>();
            string[] IdiomafrmRendicionModif = { "Modificar Rendición" };
            dicfrmRendicionModif.Add("Idioma", IdiomafrmRendicionModif);
            this.Tag = dicfrmRendicionModif;

            Dictionary<string, string[]> diclblNroRendicion = new Dictionary<string, string[]>();
            string[] IdiomalblNroRendicion = { "Rendición" };
            diclblNroRendicion.Add("Idioma", IdiomalblNroRendicion);
            this.lblNroRendicion.Tag = diclblNroRendicion;

            Dictionary<string, string[]> diclblNroPartida = new Dictionary<string, string[]>();
            string[] IdiomalblNroPartida = { "Número de Partida" };
            diclblNroPartida.Add("Idioma", IdiomalblNroPartida);
            this.lblNroPartida.Tag = diclblNroPartida;

            Dictionary<string, string[]> diclblNroSolic = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolic = { "Solicitud" };
            diclblNroSolic.Add("Idioma", IdiomalblNroSolic);
            this.lblNroSolic.Tag = diclblNroSolic;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Partida Referenciada" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;

            Dictionary<string, string[]> diclblMontoOtorgado = new Dictionary<string, string[]>();
            string[] IdiomalblMontoOtorgado = { "Monto Otorgado" };
            diclblMontoOtorgado.Add("Idioma", IdiomalblMontoOtorgado);
            this.lblMontoOtorgado.Tag = diclblMontoOtorgado;

            Dictionary<string, string[]> diclabelX3 = new Dictionary<string, string[]>();
            string[] IdiomalabelX3 = { "Monto Empleado" };
            diclabelX3.Add("Idioma", IdiomalabelX3);
            this.labelX3.Tag = diclabelX3;

            Dictionary<string, string[]> dicbtnGenerar = new Dictionary<string, string[]>();
            string[] IdiomabtnGenerar = { "Generar" };
            dicbtnGenerar.Add("Idioma", IdiomabtnGenerar);
            this.btnGenerar.Tag = dicbtnGenerar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

        }

        private void frmRendicionModif_Load(object sender, EventArgs e)
        {
            try
            {
                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                if (unaRendicionSelec != null)
                {
                    //TraerDatosSolicitud
                    BLLSolicitud ManagerSolicitud = new BLLSolicitud();
                    Solicitud DatosSolic;
                    DatosSolic = ManagerSolicitud.SolicitudTraerIdsolNomdepPorIdPartida(unaRendicionSelec.IdPartida);
                    txtNroSolic.Text = DatosSolic.IdSolicitud.ToString();
                    txtDependencia.Text = DatosSolic.laDependencia.NombreDependencia;

                    //Cargar montos partida
                    BLLPartida ManagerPartida = new BLLPartida();
                    unaPartida = ManagerPartida.PartidaTraerPorNroPart(unaRendicionSelec.IdPartida).FirstOrDefault();

                    txtPartRef.Text = unaPartida.NroPartida;
                    txtMontoOtorgado.Text = unaPartida.MontoOtorgado.ToString();

                    txtNroRendicion.Text = unaRendicionSelec.IdRendicion.ToString();
                    txtNroPart.Text = unaRendicionSelec.IdPartida.ToString();

                    unaRendicion = ManagerRendicion.AdquisicionesConBienesPorIdPartida(unaRendicionSelec.IdPartida);
                    unaRendicion.IdPartida = unaRendicionSelec.IdPartida;
                    unaRendicion.MontoGasto = unaRendicion.unasAdquisiciones.Select(suma => suma.BienesInventarioAsociados[0].unInventarioAlta.Costo).Sum();
                    txtMontoEmpleado.Text = unaRendicion.MontoGasto.ToString();
                    //Obtengo los nros de factura por distinct
                    List<string> ListaNroFacturas = unaRendicion.unasAdquisiciones.Select(x => x.NroFactura).Distinct().ToList();


                    foreach (string fact in ListaNroFacturas)
                    {
                        GrillaRendicion MultiGrillaRendicion = new GrillaRendicion();
                        MultiGrillaRendicion.unaFactura = fact;

                        //guardo los inventarios si son de la fact
                        HLPListaInventariosRend = unaRendicion.unasAdquisiciones.Where(z => z.NroFactura == fact)
                                                                            .Select(y => new HLPInvRendicion() { DescripCategoria = y.BienesInventarioAsociados[0].unaCategoria.DescripCategoria, SerieKey = y.BienesInventarioAsociados[0].unInventarioAlta.SerieKey, Costo = y.BienesInventarioAsociados[0].unInventarioAlta.Costo }).ToList();
                        MultiGrillaRendicion.unaGrillaInv.DataSource = HLPListaInventariosRend;

                        ListaMultiGrillaRendicion.Add(MultiGrillaRendicion);
                    }

                    //Para colocar las "grillas" (control users) en el flow
                    foreach (GrillaRendicion gri in ListaMultiGrillaRendicion)
                    {
                        flowInventariosRend.Controls.Add(gri);
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmRendicionModif - frmRendicionModif_Load");
                MessageBox.Show("Ocurrio un error al cargar la pantalla de Rendiciones, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdRendRes = 0;
                unaRendicion.FechaRen = DateTime.Today;
                IdRendRes = ManagerRendicion.RendicionTraerIdRendPorIdPartida(unaRendicion.IdPartida);
                if (IdRendRes == 0)
                {
                    IdRendRes = ManagerRendicion.RendicionCrear(unaRendicion, unaPartida);
                    if (IdRendRes > 0)
                        DocumentoRendicionCrear(IdRendRes);
                }
                else
                {
                    //MessageBox.Show("La partida ingresada ya fue rendida con el Nro de Rendicion: " + IdRendRes.ToString());
                    //DialogResult resmbox = MessageBox.Show(ServicioIdioma.MostrarMensaje("Mensaje1").Texto, "Advertencia", MessageBoxButtons.YesNo);
                    DialogResult resmbox = MessageBox.Show("La partida ingresada ya fue rendida con el Nro de Rendicion: " + IdRendRes.ToString() + ". Desea actualizarla?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        unaRendicion.IdRendicion = IdRendRes;
                        ManagerRendicion.RendicionModificar(unaRendicion);
                        DocumentoRendicionCrear(IdRendRes);
                        MessageBox.Show("Rendición modificada correctamente");
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmRendicionModif - btnGenerar_Click");
                MessageBox.Show("Ocurrio un error al generar la Rendición, por favor informe del error Nro " + IdError + " del Log de Eventos"); ;
            }
            
        }


        private void DocumentoRendicionCrear(int NroRendicion)
        {
            //Crear el documento
            string RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Rendicion.docx";
            string RutaPlantillaRetribucion = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Retribucion.docx";
            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
            {
                using (DocX doc = DocX.Load(RutaPlantilla))
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    var unaLista = doc.AddList(unaRendicion.unasAdquisiciones[0].BienesInventarioAsociados[0].unaCategoria.DescripCategoria, 0, ListItemType.Bulleted, 1);
                    for (var I = 0; I == unaRendicion.unasAdquisiciones[0].BienesInventarioAsociados.Count(); I++)
                    {
                        doc.AddListItem(unaLista, unaRendicion.unasAdquisiciones[0].BienesInventarioAsociados[I].unaCategoria.DescripCategoria, 0);
                    }
                    doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                    doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Rendicion " + unaRendicion.IdRendicion.ToString() + ".docx");
                }
                if (unaPartida.MontoOtorgado < unaRendicion.MontoGasto)
                {
                    using (DocX doc = DocX.Load(RutaPlantillaRetribucion))
                    {

                        doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                        doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                        CultureInfo ci = new CultureInfo("es-AR");
                        doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                        decimal montoRetrib = unaRendicion.MontoGasto - unaPartida.MontoOtorgado;
                        doc.AddCustomProperty(new CustomProperty("PMontoRetribucion", montoRetrib.ToString("C2", ci)));
                        doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Retribucion Rendicion" + unaRendicion.IdRendicion.ToString() + ".docx");
                    }
                }
            }
            else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
            {
                RutaPlantilla = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Rendicion English.docx";
                RutaPlantillaRetribucion = FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaPlantillas() + "Plantilla Retribucion English.docx";
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Rendicion English.docx"))
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    var unaLista = doc.AddList(unaRendicion.unasAdquisiciones[0].BienesInventarioAsociados[0].unaCategoria.DescripCategoria, 0, ListItemType.Bulleted, 1);
                    for (var I = 0; I == unaRendicion.unasAdquisiciones[0].BienesInventarioAsociados.Count(); I++)
                    {
                        doc.AddListItem(unaLista, unaRendicion.unasAdquisiciones[0].BienesInventarioAsociados[I].unaCategoria.DescripCategoria, 0);
                    }
                    doc.Tables[0].Rows[0].Cells[0].InsertList(unaLista);
                    doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Rendicion " + unaRendicion.IdRendicion.ToString() + ".docx");
                }
                if (unaPartida.MontoOtorgado < unaRendicion.MontoGasto)
                {
                    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\RetribucionCajaChica.docx"))
                    {

                        doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                        doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                        CultureInfo ci = new CultureInfo("es-AR");
                        doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                        decimal montoRetrib = unaRendicion.MontoGasto - unaPartida.MontoOtorgado;
                        doc.AddCustomProperty(new CustomProperty("PMontoRetribucion", montoRetrib.ToString("C2", ci)));
                        doc.SaveAs(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Retribucion Rendicion" + unaRendicion.IdRendicion.ToString() + ".docx");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                    DialogResult resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Rendición: " + unaRendicionSelec.IdRendicion.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        if (ManagerRendicion.RendicionEliminar(unaRendicionSelec))
                        {
                            MessageBox.Show("Rendicion: " + unaRendicionSelec.IdRendicion.ToString() + " eliminada correctamente");
                            DialogResult = DialogResult.OK;
                        }
                        else
                            return;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmRendicionModif - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la rendición: " + unaRendicionSelec.IdRendicion.ToString() + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }




    }
}