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
                    pdet.unasCotizaciones = unManagerCotizacion.CotizacionTraerPorIdPartidaDetalle(pdet.IdPartidaDetalle, pdet.IdPartida);
                    
                }
                
            }

           

            txtIdPartida.Text = unaPartida.IdPartida.ToString();
            txtNroPartida.Text = !string.IsNullOrEmpty(unaPartida.NroPartida) ? unaPartida.NroPartida : "";
            txtFechaEnvio.Text = unaPartida.FechaEnvio.ToString();
            txtMontoSolic.Text = unaPartida.MontoSolicitado.ToString();
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
                ListaResCotizLoc = CotizAntiguas.SkipWhile(p => ListaLocalCotiz.Any(l=> p.IdCotizacion == l.IdCotizacion))
                           .ToList();
                GrillaCotizAntiguas.DataSource = null;
                GrillaCotizAntiguas.DataSource = ListaResCotizLoc;

                FormatearGrillaCotiz();

                //PosSolicDet = e.RowIndex;
                //CalcularMontoTotalPartida();
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
                if (ManagerCotizacion.CotizacionAsociarConPartidaDetalle(ListaResCotizLoc[e.RowIndex].IdCotizacion, unaPartida.unasPartidasDetalles[IndiceDetalleSeleccionado].IdPartidaDetalle, unaPartida.IdPartida))
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




    }
}