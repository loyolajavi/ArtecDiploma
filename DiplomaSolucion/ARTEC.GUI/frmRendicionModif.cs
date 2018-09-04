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
        }


        public frmRendicionModif(Rendicion unaRen)
        {
            InitializeComponent();
            unaRendicionSelec = unaRen;
        }

        private void frmRendicionModif_Load(object sender, EventArgs e)
        {
            try
            {
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
                    IdRendRes = ManagerRendicion.RendicionCrear(unaRendicion);
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
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmRendicionModif - btnGenerar_Click");
                MessageBox.Show("Ocurrio un error al generar la Rendici�n, por favor informe del error Nro " + IdError + " del Log de Eventos"); ;
            }
            
        }


        private void DocumentoRendicionCrear(int NroRendicion)
        {
            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Espa�ol)
            {
                //VER: FALTA CREAR PLANTILLA
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Rendicion.docx"))
                {

                    doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    //Si se escribio una justificaci�n
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogaci�n de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "PruebaRendicion1"));
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
                        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Retribucion1"));
                    }
                }
            }
            else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
            {
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Rendicion English.docx"))
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    ////Si se escribio una justificaci�n
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogaci�n de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "PruebaRendicion English"));
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
                        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Retribucion1"));
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                    DialogResult resmbox = MessageBox.Show("�Est� seguro que desea dar de baja la Rendici�n: " + unaRendicionSelec.IdRendicion.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        if (ManagerRendicion.RendicionEliminar(unaRendicionSelec))
                        {
                            MessageBox.Show("Rendicion: " + unaRendicionSelec.IdRendicion.ToString() + " eliminada correctamente");
                        }
                        else
                            return;
                    DialogResult = DialogResult.OK;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmRendicionModif - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la rendici�n: " + unaRendicionSelec.IdRendicion.ToString() + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }




    }
}