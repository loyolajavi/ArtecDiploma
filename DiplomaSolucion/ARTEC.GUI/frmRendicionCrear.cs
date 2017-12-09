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
using Novacode;
using System.Globalization;

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
        }

        private void frmRendicionCrear_Load(object sender, EventArgs e)
        {

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

                if (unaPartida != null && unaPartida.IdPartida > 0)
                {
                    if (!string.IsNullOrEmpty(unaPartida.NroPartida))
                    {
                        int? RelLocal = ManagerPartida.RelPDetAdqPartidaTieneAdq(unaPartida.IdPartida);
                        if (RelLocal != null && unaPartida.IdPartida == RelLocal)
                        {
                            btnCrear.Enabled = true;

                            //TraerDatosSolicitud
                            BLLSolicitud ManagerSolicitud = new BLLSolicitud();
                            Solicitud DatosSolic;
                            DatosSolic = ManagerSolicitud.SolicitudTraerIdsolNomdepPorIdPartida(Int32.Parse(txtNroPart.Text));
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
        }



        private void DocumentoRendicionCrear(int NroRendicion)
        {
            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)ServicioIdioma.EnumIdioma.Español)
            {
                //FALTA CREAR PLANTILLA
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Rendicion.docx"))
                {

                    doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    //Si se escribio una justificación
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "PruebaRendicion1"));
                }
            }
            else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)ServicioIdioma.EnumIdioma.English)
            {
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Rendicion English.docx"))
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    ////Si se escribio una justificación
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "PruebaRendicion English"));
                }
            }
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