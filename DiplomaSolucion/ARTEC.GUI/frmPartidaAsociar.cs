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
using ARTEC.ENTIDADES.Helpers;

namespace ARTEC.GUI
{
    public partial class frmPartidaAsociar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Partida unaPartida = new Partida();
        BLLPartida ManagerPartida = new BLLPartida();
        //BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();

        public frmPartidaAsociar()
        {
            InitializeComponent();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLPartida ManagerPartida = new BLLPartida();

            if (!string.IsNullOrWhiteSpace(txtIdPartida.Text))
            {
                unaPartida = ManagerPartida.PartidaTraerPorNroPart(Int32.Parse(txtIdPartida.Text));
                //grillaPartidas.DataSource = null;
                //List<Partida> unasPartidas = new List<Partida>();
                //unasPartidas.Add(unaPartida);
                //grillaPartidas.DataSource = unasPartidas;
                //grillaPartidas.Columns[""].Visible = true;
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
            }
            
        }



        private void btnAsociar_Click(object sender, EventArgs e)
        {
            unaPartida.FechaAcreditacion = DateTime.Today;
            unaPartida.MontoOtorgado = decimal.Parse(txtMontoOtorgado.Text);
            unaPartida.NroPartida = txtNroPartAsignado.Text;

            if(ManagerPartida.PartidaAsociar(unaPartida))
                MessageBox.Show("Partida Asociada correctamente");
        }

        //private void grillaPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //Si se hizo click en el header, salir
        //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        List<HLPPartidaDetalle> ListaHelperPartidaDetalle = new List<HLPPartidaDetalle>();

        //        grillaDetallesPart.DataSource = null;
        //        foreach (PartidaDetalle unPartDet in unaPartida.unasPartidasDetalles)
        //        {
        //            HLPPartidaDetalle unHLPPartDetalle = new HLPPartidaDetalle();
        //            unHLPPartDetalle.IdPartidaDetalle = unPartDet.IdPartidaDetalle;
        //            unHLPPartDetalle.DescripCategoria = unPartDet.SolicDetalleAsociado.unaCategoria.DescripCategoria;
        //            unHLPPartDetalle.Cantidad = unPartDet.SolicDetalleAsociado.Cantidad;

        //            ListaHelperPartidaDetalle.Add(unHLPPartDetalle);
        //        }
        //        grillaDetallesPart.DataSource = ListaHelperPartidaDetalle;

        //    }
        //}















    }
}