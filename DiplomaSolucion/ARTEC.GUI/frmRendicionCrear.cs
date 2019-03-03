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
using Xceed.Words.NET;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmRendicionCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        Rendicion unaRendicion = new Rendicion();
        BLLRendicion ManagerRendicion = new BLLRendicion();
        List<GrillaRendicion> ListaMultiGrillaRendicion = new List<GrillaRendicion>();
        List<HLPInvRendicion> HLPListaInventariosRend = new List<HLPInvRendicion>();
        Partida unaPartida = new Partida();

        public frmRendicionCrear()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmRendicionCrear = new Dictionary<string, string[]>();
            string[] IdiomafrmRendicionCrear = { "Crear Rendición" };
            dicfrmRendicionCrear.Add("Idioma", IdiomafrmRendicionCrear);
            this.Tag = dicfrmRendicionCrear;

            Dictionary<string, string[]> diclblNroPartida = new Dictionary<string, string[]>();
            string[] IdiomalblNroPartida = { "Partida" };
            diclblNroPartida.Add("Idioma", IdiomalblNroPartida);
            this.lblNroPartida.Tag = diclblNroPartida;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

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

            Dictionary<string, string[]> dicbtnCrear = new Dictionary<string, string[]>();
            string[] IdiomabtnCrear = { "Crear" };
            dicbtnCrear.Add("Idioma", IdiomabtnCrear);
            this.btnCrear.Tag = dicbtnCrear;

        }

        private void frmRendicionCrear_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validlblNroPartida.Validate())
            {
                //Para que no repita la carga del flow
                ListaMultiGrillaRendicion.Clear();
                flowInventariosRend.Controls.Clear();

                //Cargar montos partida
                BLLPartida ManagerPartida = new BLLPartida();
                unaPartida = ManagerPartida.PartidaTraerPorNroPart(Int32.Parse(txtNroPart.Text)).FirstOrDefault();

                //TraerDatosSolicitud
                BLLSolicitud ManagerSolicitud = new BLLSolicitud();
                Solicitud DatosSolic;
                DatosSolic = ManagerSolicitud.SolicitudTraerIdsolNomdepPorIdPartida(Int32.Parse(txtNroPart.Text));

                if (unaPartida != null && unaPartida.IdPartida > 0)
                {
                    //Permitir Rendir sólo cuando todos los bienes de la Partida ingresada fueron adquiridos, Trae IDPartida si puede rendirse
                    bool PartidaPuedeRendirse = ManagerPartida.PartidaTraerIDSiPuedeRendirse(unaPartida.IdPartida);
                    
                    if (!string.IsNullOrEmpty(unaPartida.NroPartida))
                    {
                        if (PartidaPuedeRendirse)
                        {
                            int? RelLocal = ManagerPartida.RelPDetAdqPartidaTieneAdq(unaPartida.IdPartida);
                            if (RelLocal != null && unaPartida.IdPartida == RelLocal)
                            {
                                btnCrear.Enabled = true;


                                txtNroSolic.Text = DatosSolic.IdSolicitud.ToString();
                                txtDependencia.Text = DatosSolic.laDependencia.NombreDependencia;
                                txtPartRef.Text = unaPartida.NroPartida;


                                txtMontoOtorgado.Text = unaPartida.MontoOtorgado.ToString();


                                unaRendicion = ManagerRendicion.AdquisicionesConBienesPorIdPartida(Int32.Parse(txtNroPart.Text));
                                unaRendicion.IdPartida = Int32.Parse(txtNroPart.Text);
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
                            else
                            {
                                LimpiarFormularioRendicion();
                                MessageBox.Show("La partida no tiene detalles pendientes de rendición");
                            }
                        }
                        else
                        {
                            LimpiarFormularioRendicion();
                            MessageBox.Show("La partida ingresada aún tiene bienes pendientes de adquisición");
                        }
                    }
                    else
                    {
                        LimpiarFormularioRendicion();
                        MessageBox.Show("La partida ingresada no fue acreditada aún");
                    }
                }
                else
                {
                    LimpiarFormularioRendicion();
                    MessageBox.Show("No se encontró la partida ingresada");
                }
            }
        }


        private void LimpiarFormularioRendicion()
        {
            txtNroSolic.Clear();
            txtDependencia.Clear();
            txtPartRef.Clear();
            txtMontoEmpleado.Clear();
            txtMontoOtorgado.Clear();
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            int IdRendRes = 0;
            if (validlblNroPartida.Validate())
            {
                unaRendicion.FechaRen = DateTime.Today;
                IdRendRes = ManagerRendicion.RendicionTraerIdRendPorIdPartida(unaRendicion.IdPartida);
                if (IdRendRes == 0)
                {
                    IdRendRes = ManagerRendicion.RendicionCrear(unaRendicion, unaPartida);
                    if (IdRendRes > 0)
                        DocumentoRendicionCrear(IdRendRes);
                    //Quizas esto lo maneje desde las excepciones mas q aca
                    //MessageBox.Show("No se pudo crear la Rendicion correctamente");
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
                    }
                }
                MessageBox.Show("Rendición registrada correctamente");
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
            //Imprimir la rendición
            using (PrintDialog printDialog1 = new PrintDialog())
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(FRAMEWORK.Servicios.ManejoArchivos.obtenerRutaDocumentos() + "Rendicion " + unaRendicion.IdRendicion.ToString() + ".docx");
                    info.Arguments = "\"" + printDialog1.PrinterSettings.PrinterName + "\"";
                    info.CreateNoWindow = true;
                    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    info.UseShellExecute = true;
                    info.Verb = "PrintTo";
                    System.Diagnostics.Process.Start(info);
                }
            }
            MessageBox.Show("Rendición creada correctamente");
            this.Close();
        }



        private void EventVldLblNroPartida(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            int auxnum;
            if (string.IsNullOrWhiteSpace(txtNroPart.Text) | !(int.TryParse(txtNroPart.Text, out auxnum)))
            {
                vldIdPartida.ErrorMessage = "HOLLLLA";
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }




    }
}