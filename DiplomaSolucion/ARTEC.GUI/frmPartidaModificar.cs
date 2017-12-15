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
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.ENTIDADES.Helpers;
using Novacode;
using System.Globalization;

namespace ARTEC.GUI
{
    public partial class frmPartidaModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        int NroPartida;
        BLLPartida ManagerPartida = new BLLPartida();
        Partida unaPartida;
        BLLCotizacion unManagerCotizacion = new BLLCotizacion();
        List<Cotizacion> ListaResCotizLoc;
        int IndiceDetalleSeleccionado;
        List<Cotizacion> ListaLocalCotiz;
        BLLCotizacion ManagerCotizacion = new BLLCotizacion();
        Dependencia DepAsoc;
        List<PartidaDetalle> PDetallesBorrar = new List<PartidaDetalle>();

        public frmPartidaModificar(int NroPartidaArg)
        {
            InitializeComponent();
            NroPartida = NroPartidaArg;
            ////Agrega Checkbox para seleccionar Cotizaciones
            //DataGridViewCheckBoxColumn chkCotizacion = new DataGridViewCheckBoxColumn();
            //chkCotizacion.Name = "chkBoxCotizacion";
            //chkCotizacion.HeaderText = "";
            //chkCotizacion.TrueValue = true;
            //chkCotizacion.FalseValue = false;
            //grillaCotizaciones.Columns.Add(chkCotizacion);
        }

        private void frmPartidaModificar_Load(object sender, EventArgs e)
        {
            unaPartida = ManagerPartida.PartidaTraerPorNroPart(NroPartida).FirstOrDefault();
            if (unaPartida != null && unaPartida.IdPartida > 0)
            {
                foreach (PartidaDetalle pdet in unaPartida.unasPartidasDetalles)
                {
                    pdet.unasCotizaciones = unManagerCotizacion.CotizacionTraerPorUIDPartidaDetalle(pdet.UIDPartidaDetalle, pdet.IdPartida);
                }

                //Traigo la dependencia asociada
                BLLDependencia ManagerDependencia = new BLLDependencia();
                List<Dependencia> ListaDep = ManagerDependencia.DependenciaTraerNombrePorIDSolicitud(unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.IdSolicitud);
                if (ListaDep != null){
                    DepAsoc = ListaDep.First();
                    txtDependencia.Text = DepAsoc.NombreDependencia;
                }
                    



            }



            txtIdPartida.Text = unaPartida.IdPartida.ToString();
            txtNroPartida.Text = !string.IsNullOrEmpty(unaPartida.NroPartida) ? unaPartida.NroPartida : "";
            txtFechaEnvio.Text = unaPartida.FechaEnvio.ToString();
            txtMontoSolic.Text = unaPartida.MontoSolicitado.ToString();
            txtNroSolicitud.Text = unaPartida.unasPartidasDetalles[0].SolicDetalleAsociado.IdSolicitud.ToString();
            chkCaja.Checked = unaPartida.Caja;

            List<HLPPartidaDetalle> ListaHelperPartidaDetalle = new List<HLPPartidaDetalle>();

            grillaDetallesPart.DataSource = null;
            foreach (PartidaDetalle unPartDet in unaPartida.unasPartidasDetalles)
            {
                HLPPartidaDetalle unHLPPartDetalle = new HLPPartidaDetalle();
                unHLPPartDetalle.IdPartidaDetalle = unPartDet.IdPartidaDetalle;
                unHLPPartDetalle.DescripCategoria = unPartDet.SolicDetalleAsociado.unaCategoria.DescripCategoria;
                unHLPPartDetalle.Cantidad = unPartDet.SolicDetalleAsociado.Cantidad;

                ListaHelperPartidaDetalle.Add(unHLPPartDetalle);
            }
            grillaDetallesPart.DataSource = ListaHelperPartidaDetalle;
            //Agrega boton para Borrar el detallePartida
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaDetallesPart.Columns.Add(deleteButton);
        }

        private void grillaDetallesPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Borrar
                if (e.ColumnIndex == grillaDetallesPart.Columns["btnDinBorrar"].Index)
                { 
                    //VER: COMPROBAR QUE LA PARTIDA NO ESTE ASOCIADA A UNA DE CONTRATACIONES
                    //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
                    grillaDetallesPart.Columns.RemoveAt(e.ColumnIndex);

                    //Guardo en una lista los detalles a eliminar
                    PDetallesBorrar.Add(unaPartida.unasPartidasDetalles[e.RowIndex]);

                    //elimino de la memoria el detalle
                    unaPartida.unasPartidasDetalles.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    grillaDetallesPart.DataSource = null;
                    List<HLPPartidaDetalle> ListaHelperPartidaDetalle = new List<HLPPartidaDetalle>();
                    foreach (PartidaDetalle unPartDet in unaPartida.unasPartidasDetalles)
                    {
                        HLPPartidaDetalle unHLPPartDetalle = new HLPPartidaDetalle();
                        unHLPPartDetalle.IdPartidaDetalle = unPartDet.IdPartidaDetalle;
                        unHLPPartDetalle.DescripCategoria = unPartDet.SolicDetalleAsociado.unaCategoria.DescripCategoria;
                        unHLPPartDetalle.Cantidad = unPartDet.SolicDetalleAsociado.Cantidad;

                        ListaHelperPartidaDetalle.Add(unHLPPartDetalle);
                    }
                    grillaDetallesPart.DataSource = ListaHelperPartidaDetalle;
                    //Agrega boton para Borrar el detallePartida
                    var deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = "btnDinBorrar";
                    deleteButton.HeaderText = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                    deleteButton.Text = ServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
                    deleteButton.UseColumnTextForButtonValue = true;
                    grillaDetallesPart.Columns.Add(deleteButton);

                    grillaCotizaciones.DataSource = null;
                    GrillaCotizAntiguas.DataSource = null;
                    CalcularMontoTotalPartida();
                }
                else
                {
                    IndiceDetalleSeleccionado = e.RowIndex;
                    DataGridView grillaAux = (DataGridView)sender;
                    ListaLocalCotiz = (List<Cotizacion>)unaPartida.unasPartidasDetalles[e.RowIndex].unasCotizaciones;

                    grillaCotizaciones.DataSource = null;
                    grillaCotizaciones.DataSource = ListaLocalCotiz;
                    //foreach (Cotizacion unaCot in ListaLocalCotiz)
                    //{
                    //    grillaCotizaciones.Rows[ListaLocalCotiz.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                    //    grillaAux.EndEdit();
                    //}

                    //Coloco las cotizaciones antiguas (no asociadas a la partida al momento de generarla)
                    List<Cotizacion> CotizAntiguas = unManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.IdSolicitudDetalle, unaPartida.unasPartidasDetalles[e.RowIndex].SolicDetalleAsociado.IdSolicitud);
                    ListaResCotizLoc = CotizAntiguas.SkipWhile(p => ListaLocalCotiz.Any(l => p.IdCotizacion == l.IdCotizacion))
                               .ToList();
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;

                    FormatearGrillaCotiz();
                }

                
            }
        }


        private void GrillaCotizAntiguas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Guardo en BD la asociacion de la cotiz con el partDet
                if (ManagerCotizacion.CotizacionAsociarConPartidaDetalle(ListaResCotizLoc[e.RowIndex].IdCotizacion, unaPartida.unasPartidasDetalles[IndiceDetalleSeleccionado].UIDPartidaDetalle, unaPartida.IdPartida))
                {
                    //Actualizo las grillas
                    ListaLocalCotiz.Add(ListaResCotizLoc[e.RowIndex]);
                    grillaCotizaciones.DataSource = null;
                    grillaCotizaciones.DataSource = ListaLocalCotiz;
                    ListaResCotizLoc.RemoveAt(e.RowIndex);
                    GrillaCotizAntiguas.DataSource = null;
                    GrillaCotizAntiguas.DataSource = ListaResCotizLoc;
                    FormatearGrillaCotiz();
                    //Actualizo campos
                    CalcularMontoTotalPartida();
                    //txtMontoSolic.Text = ListaLocalCotiz.Sum(X => X.MontoCotizado).ToString();
                }
                else
                {
                    MessageBox.Show("Error al asociar la cotización");
                }

            }

        }

        private void CalcularMontoTotalPartida()
        {
            decimal TotalAcumulado = 0;
            foreach (PartidaDetalle unDet in unaPartida.unasPartidasDetalles)
            {
                //Suma para obtener el costo total de la partida
                Cotizacion unaCotizacionAUX = unDet.unasCotizaciones.OrderBy(x => x.MontoCotizado).Take(1).FirstOrDefault();
                if (unaCotizacionAUX != null)
                {

                    TotalAcumulado += unaCotizacionAUX.MontoCotizado * unDet.SolicDetalleAsociado.Cantidad;
                }
                else
                {
                    TotalAcumulado += 0;
                }
            }
            txtMontoSolic.Text = TotalAcumulado.ToString();
            ManagerPartida.PartidaModifMontoSolic(unaPartida.IdPartida, TotalAcumulado);
        }


        private void FormatearGrillaCotiz()
        {
            grillaCotizaciones.Columns["unDetalleAsociado"].Visible = false;
            grillaCotizaciones.Columns["Seleccionada"].Visible = false;
            grillaCotizaciones.Columns["unaPartidaDetalleIDs"].Visible = false;
            GrillaCotizAntiguas.Columns["unDetalleAsociado"].Visible = false;
            GrillaCotizAntiguas.Columns["Seleccionada"].Visible = false;
            GrillaCotizAntiguas.Columns["unaPartidaDetalleIDs"].Visible = false;
        }

        //Genera el documento con la partida modificada
        private void btnGenerarDocumento_Click(object sender, EventArgs e)
        {
            if (PDetallesBorrar != null && PDetallesBorrar.Count() > 0)
            {
                ManagerPartida.PartidaModifDetalles(PDetallesBorrar);

            }

            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)ServicioIdioma.EnumIdioma.Español)
            {
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2.docx"))//VER: Modificar ruta
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                    CultureInfo ci = new CultureInfo("es-AR");
                    doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                    ////Si se escribio una justificación
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                }
            }
            else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)ServicioIdioma.EnumIdioma.English)
            {
                using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevación Partida2 English.docx"))
                {
                    doc.AddCustomProperty(new CustomProperty("PFecha", unaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                    doc.AddCustomProperty(new CustomProperty("PDependencia", DepAsoc.NombreDependencia));
                    CultureInfo ci = new CultureInfo("en-US");
                    doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", unaPartida.MontoSolicitado.ToString("C2", ci)));
                    //Si se escribio una justificación
                    //if (!string.IsNullOrWhiteSpace(JustifAUX))
                    //{
                    //    doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogación de fondos es solicitada por este curso debido a que " + JustifAUX));
                    //}
                    doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //elimino las columnas dinámicas (sino aparecen delante de todo al regenerar la grilla)
            grillaDetallesPart.Columns.Remove("btnDinBorrar");
            grillaCotizaciones.DataSource = null;
            GrillaCotizAntiguas.DataSource = null;
            grillaDetallesPart.DataSource = null;
            frmPartidaModificar_Load(this, new EventArgs());
            //Limpio los pdetalles a borrar
            PDetallesBorrar.Clear();
            //Actualizo campos
            CalcularMontoTotalPartida();


        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(this, new EventArgs());
            this.Close();
        }




    }
}