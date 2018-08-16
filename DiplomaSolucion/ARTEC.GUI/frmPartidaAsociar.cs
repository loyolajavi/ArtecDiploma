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
        List<Solicitud> unasSolicitudes;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        List<Partida> unaListaPartidas = new List<Partida>();

        public frmPartidaAsociar()
        {
            InitializeComponent();
        }

        private void frmPartidaAsociar_Load(object sender, EventArgs e)
        {
            ///Traigo Dependencias para busqueda dinámica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLPartida ManagerPartida = new BLLPartida();

            //Si se ingresó algun dato
            if (!string.IsNullOrWhiteSpace(txtIdPartida.Text) | !string.IsNullOrWhiteSpace(txtNroSolicitud.Text) | !string.IsNullOrWhiteSpace(txtDependencia.Text))
            {
                //Si se ingresó el IdPartida
                if (!string.IsNullOrWhiteSpace(txtIdPartida.Text))
                {
                    unaPartida = ManagerPartida.PartidaTraerPorNroPart(Int32.Parse(txtIdPartida.Text)).FirstOrDefault();
                    txtFechaEnvio.Text = unaPartida.FechaEnvio.ToString();
                    txtMontoSolic.Text = unaPartida.MontoSolicitado.ToString();
                    chkCaja.Checked = unaPartida.Caja;

                    unaListaPartidas.Clear();
                    unaListaPartidas.Add(unaPartida);
                    GrillaPartidas.DataSource = null;
                    GrillaPartidas.DataSource = unaListaPartidas;

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

                    //Limpio datos en grilla solicitud por si quedó algo antiguo
                    grillaSolicitudes.DataSource = null;
                    txtDependencia.Clear();
                    txtNroSolicitud.Clear();
                }
                //Si se ingresó NroSolicitud o Dependencia (pero no IdPartida)
                else
                {
                    unasSolicitudes = new List<Solicitud>();
                    BLLSolicitud ManagerSolicitud = new BLLSolicitud();

                    //Si se ingresó el NroSolicitud
                    if (!string.IsNullOrEmpty(txtNroSolicitud.Text))
                    {
                        unasSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
                        txtDependencia.Clear();
                    }
                    //Si se ingresó dependencia
                    else
                    {
                        unasSolicitudes = ManagerSolicitud.SolicitudBuscar(txtDependencia.Text);
                    }
                    //Carga las solicitudes encontradas
                    grillaSolicitudes.DataSource = null;
                    grillaSolicitudes.DataSource = unasSolicitudes;
                    grillaSolicitudes.Columns["Asignado"].Visible = true;
                    //Limpia las grillas que quedaron en memoria de búsqueda anterior
                    GrillaPartidas.DataSource = null;
                    grillaDetallesPart.DataSource = null;
                    txtFechaEnvio.Clear();
                    txtMontoSolic.Clear();
                    chkCaja.Checked = false;
                }
            }
            else
            {
                grillaSolicitudes.DataSource = null;
                GrillaPartidas.DataSource = null;
                grillaDetallesPart.DataSource = null;
                txtFechaEnvio.Clear();
                txtMontoSolic.Clear();
                chkCaja.Checked = false;
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

        private void grillaSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                GrillaPartidas.DataSource = null;
                grillaDetallesPart.DataSource = null;
                txtFechaEnvio.Clear();
                txtMontoSolic.Clear();
                chkCaja.Checked = false;
                unaListaPartidas = ManagerPartida.PartidasBuscarPorIdSolicitud(unasSolicitudes[e.RowIndex].IdSolicitud);
                if(unaListaPartidas.Count() > 0)
                    GrillaPartidas.DataSource = unaListaPartidas;
                else
                    MessageBox.Show("La Solicitud no posee Partidas solicitadas");
            }
        }


        //Búsqueda dinámica de dependencias
        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDependencia.Text))
            {
                BusquedaDependencias();
            }
            else
            {
                cboDep.Visible = false;
                cboDep.DroppedDown = false;
                cboDep.DataSource = null;
            }
        }


        private void BusquedaDependencias()
        {
            List<Dependencia> res = new List<Dependencia>();
            res = (List<Dependencia>)unasDependencias.ToList();

            List<string> Palabras = new List<string>();
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtDependencia.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                if (res.Count == 1 && string.Equals(res.First().NombreDependencia, txtDependencia.Text))
                {
                    cboDep.Visible = false;
                    cboDep.DroppedDown = false;
                    cboDep.DataSource = null;

                }
                else
                {
                    cboDep.DataSource = null;
                    cboDep.DataSource = res;
                    cboDep.DisplayMember = "NombreDependencia";
                    cboDep.ValueMember = "IdDependencia";
                    cboDep.Visible = true;
                    cboDep.Focus();
                    cboDep.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                cboDep.Visible = false;
                cboDep.DroppedDown = false;
                cboDep.DataSource = null;
            }
        }


        private void cboDep_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDependencia.Text))
            {
                if (cboDep.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtDependencia.TextChanged -= new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDependencia.Text = cbo.GetItemText(cbo.SelectedItem);
                    this.txtDependencia.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDependencia.SelectionStart = txtDependencia.Text.Length + 1;
                    cboDep.DataSource = null;
                }
            }
        }

        private void GrillaPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                grillaDetallesPart.DataSource = null;
                List<HLPPartidaDetalle> ListaHelperPartidaDetalle = new List<HLPPartidaDetalle>();

                unaPartida = ManagerPartida.PartidaTraerPorNroPart(unaListaPartidas[e.RowIndex].IdPartida).FirstOrDefault();
                txtFechaEnvio.Text = unaPartida.FechaEnvio.ToString();
                txtMontoSolic.Text = unaPartida.MontoSolicitado.ToString();
                chkCaja.Checked = unaPartida.Caja;


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














    }
}