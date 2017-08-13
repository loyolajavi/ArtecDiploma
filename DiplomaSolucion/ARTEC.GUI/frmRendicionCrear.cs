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
                    unaPartida = ManagerPartida.PartidaTraerPorNroPart(Int32.Parse(txtNroPart.Text));

                    if (unaPartida.IdPartida > 0)
                    {
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
                        MessageBox.Show("No se encontró la partida ingresada");
                    }
            }
        }



        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validlblNroPartida.Validate())
            {
                    unaRendicion.FechaRen = DateTime.Today;
                    //unaRendicion.IdPartida = txtpar
                    if (ManagerRendicion.RendicionTraerIdRendPorIdPartida(unaRendicion.IdPartida) == 0)
                    {
                        int IdRendRes = ManagerRendicion.RendicionCrear(unaRendicion);
                        if (IdRendRes > 0)
                            DocumentoRendicionCrear();
                    }
                    else
                    {
                        //ModificarRendicion();
                    }
                    //if (ManagerRendicion.RendicionCrear(unaRendicion))
                    //{
                    //if(ServicioIdioma.unIdiomaActual.IdIdioma == 1)//Español
                    //{
                    //    //FALTA CREAR PLANTILLA
                    //    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Rendicion.docx"))
                    //    {

                    //        doc.AddCustomProperty(new CustomProperty("PFecha", DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    //        doc.AddCustomProperty(new CustomProperty("PNroPartida", unaRendicion.IdPartida));
                    //        CultureInfo ci = new CultureInfo("es-AR");
                    //        doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", unaRendicion.MontoGasto.ToString("C2", ci)));
                    //        //Si se escribio una justificación
                    //        //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //        //{
                    //        //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //        //}
                    //        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "PruebaRendicion1"));
                    //    }
                    //}
                    ////else if (ServicioIdioma.unIdiomaActual.IdIdioma == 2)//Ingles
                    ////{
                    ////    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2 English.docx"))
                    ////    {
                    ////        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    ////        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
                    ////        CultureInfo ci = new CultureInfo("es-AR");
                    ////        doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", MontoUtilizado.ToString("C2", ci)));
                    ////        //Si se escribio una justificación
                    ////        if (!string.IsNullOrWhiteSpace(JustifAUX))
                    ////        {
                    ////            doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    ////        }
                    ////        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                    ////    }
                    ////}

                }
            }
            //else
            //{
            //    return false;
            //}
            //return true;
        //}

        


        private void DocumentoRendicionCrear()
        {
            if (ServicioIdioma.unIdiomaActual.IdIdioma == 1)//Español
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
            //else if (ServicioIdioma.unIdiomaActual.IdIdioma == 2)//Ingles
            //{
            //    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2 English.docx"))
            //    {
            //        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
            //        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
            //        CultureInfo ci = new CultureInfo("es-AR");
            //        doc.AddCustomProperty(new CustomProperty("PMontoUtilizado", MontoUtilizado.ToString("C2", ci)));
            //        //Si se escribio una justificación
            //        if (!string.IsNullOrWhiteSpace(JustifAUX))
            //        {
            //            doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
            //        }
            //        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
            //    }
            //}
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