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
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;

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

            Dictionary<string, string[]> dicfrmPartidaAsociar = new Dictionary<string, string[]>();
            string[] IdiomafrmPartidaAsociar = { "Asociar Partida" };
            dicfrmPartidaAsociar.Add("Idioma", IdiomafrmPartidaAsociar);
            this.Tag = dicfrmPartidaAsociar;

            Dictionary<string, string[]> diclblIdSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblIdSolicitud = { "Solicitud" };
            diclblIdSolicitud.Add("Idioma", IdiomalblIdSolicitud);
            this.lblIdSolicitud.Tag = diclblIdSolicitud;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblIdPartida = new Dictionary<string, string[]>();
            string[] IdiomalblIdPartida = { "Partida" };
            diclblIdPartida.Add("Idioma", IdiomalblIdPartida);
            this.lblIdPartida.Tag = diclblIdPartida;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> diclblGrillaPartidas = new Dictionary<string, string[]>();
            string[] IdiomalblGrillaPartidas = { "Grilla" };
            diclblGrillaPartidas.Add("Idioma", IdiomalblGrillaPartidas);
            this.lblGrillaPartidas.Tag = diclblGrillaPartidas;

            Dictionary<string, string[]> dicgboxDetallesPartida = new Dictionary<string, string[]>();
            string[] IdiomagboxDetallesPartida = { "Detalles Partida" };
            dicgboxDetallesPartida.Add("Idioma", IdiomagboxDetallesPartida);
            this.gboxDetallesPartida.Tag = dicgboxDetallesPartida;

            Dictionary<string, string[]> diclblFechaEnvio = new Dictionary<string, string[]>();
            string[] IdiomalblFechaEnvio = { "Fecha envío" };
            diclblFechaEnvio.Add("Idioma", IdiomalblFechaEnvio);
            this.lblFechaEnvio.Tag = diclblFechaEnvio;

            Dictionary<string, string[]> diclblMontoSolic = new Dictionary<string, string[]>();
            string[] IdiomalblMontoSolic = { "Monto" };
            diclblMontoSolic.Add("Idioma", IdiomalblMontoSolic);
            this.lblMontoSolic.Tag = diclblMontoSolic;

            Dictionary<string, string[]> dicchkCaja = new Dictionary<string, string[]>();
            string[] IdiomachkCaja = { "Caja" };
            dicchkCaja.Add("Idioma", IdiomachkCaja);
            this.chkCaja.Tag = dicchkCaja;

            Dictionary<string, string[]> diclblNroPartAsignada = new Dictionary<string, string[]>();
            string[] IdiomalblNroPartAsignada = { "Partida" };
            diclblNroPartAsignada.Add("Idioma", IdiomalblNroPartAsignada);
            this.lblNroPartAsignada.Tag = diclblNroPartAsignada;

            Dictionary<string, string[]> diclblMontoAcreditado = new Dictionary<string, string[]>();
            string[] IdiomalblMontoAcreditado = { "Monto" };
            diclblMontoAcreditado.Add("Idioma", IdiomalblMontoAcreditado);
            this.lblMontoAcreditado.Tag = diclblMontoAcreditado;

            Dictionary<string, string[]> dicbtnAsociar = new Dictionary<string, string[]>();
            string[] IdiomabtnAsociar = { "Asociar" };
            dicbtnAsociar.Add("Idioma", IdiomabtnAsociar);
            this.btnAsociar.Tag = dicbtnAsociar;

        }

        private void frmPartidaAsociar_Load(object sender, EventArgs e)
        {
            try
            {
                BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
                ///Traigo Dependencias para busqueda dinámica
                BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
                unasDependencias = ManagerDependencia.TraerTodos();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLPartida ManagerPartida = new BLLPartida();

            try
            {
                if (!vldFrmPartidaAsociarBuscar.Validate())
                    return;

                txtResBusqueda.Visible = false;
                txtResBusquedaPar.Visible = false;
                grillaSolicitudes.Visible = true;
                GrillaPartidas.Visible = true;

                //Si se ingresó algun dato
                if (!string.IsNullOrWhiteSpace(txtIdPartida.Text) | !string.IsNullOrWhiteSpace(txtNroSolicitud.Text) | !string.IsNullOrWhiteSpace(txtDependencia.Text))
                {
                    //Si se ingresó el IdPartida
                    if (!string.IsNullOrWhiteSpace(txtIdPartida.Text))
                    {
                        unaPartida = ManagerPartida.PartidaTraerPorNroPart(Int32.Parse(txtIdPartida.Text)).FirstOrDefault();
                        if (unaPartida != null && unaPartida.IdPartida > 0)
                        {
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
                        else
                        {
                            txtResBusqueda.Visible = true;
                            txtResBusquedaPar.Visible = true;
                            grillaSolicitudes.DataSource = null;
                            GrillaPartidas.DataSource = null;
                            GrillaPartidas.Visible = false;
                            grillaDetallesPart.DataSource = null;
                        }
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
                        if (unasSolicitudes != null && unasSolicitudes.Count > 0)
                        {
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
                        else
                        {
                            txtResBusqueda.Visible = true;
                            txtResBusquedaPar.Visible = true;
                            grillaSolicitudes.DataSource = null;
                            GrillaPartidas.DataSource = null;
                            GrillaPartidas.Visible = false;
                            grillaDetallesPart.DataSource = null;
                        }

                    }
                }
                else
                {
                    txtResBusqueda.Visible = true;
                    txtResBusquedaPar.Visible = true;
                    grillaSolicitudes.Visible = false;
                    grillaSolicitudes.DataSource = null;
                    GrillaPartidas.DataSource = null;
                    grillaDetallesPart.DataSource = null;
                    txtFechaEnvio.Clear();
                    txtMontoSolic.Clear();
                    chkCaja.Checked = false;
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaAsociar - btnBuscar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Error en la búsqueda, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }



        private void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNroPartAsignado.Text) && !string.IsNullOrWhiteSpace(txtMontoOtorgado.Text) && grillaDetallesPart.DataSource != null)
                {
                    if (!vldFrmPartidaAsociarAsoc.Validate())
                        return;
                    if(unaPartida.MontoOtorgado > 0 | !string.IsNullOrEmpty(unaPartida.NroPartida))
                    {
                        DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Partida ya está asociada con SGA con la referencia: ").Texto + unaPartida.NroPartida + BLLServicioIdioma.MostrarMensaje(", con un monto otorgado de $").Texto + unaPartida.MontoOtorgado.ToString() +
                            "\n" + BLLServicioIdioma.MostrarMensaje("¿Está seguro que quiere reemplazar la asociación existente?").Texto, BLLServicioIdioma.MostrarMensaje("Confirmación").Texto, MessageBoxButtons.YesNo);
                        if (resmbox == DialogResult.No)
                            return;
                    }
                    if (Int32.Parse(txtMontoOtorgado.Text) > 0)
                    {
                        if (Int32.Parse(txtMontoOtorgado.Text) < unaPartida.MontoSolicitado)
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El monto otorgado es menor al solicitado, por favor revíselo").Texto);
                        else
                        {
                            unaPartida.FechaAcreditacion = DateTime.Today;
                            unaPartida.MontoOtorgado = decimal.Parse(txtMontoOtorgado.Text);
                            unaPartida.NroPartida = txtNroPartAsignado.Text;

                            ManagerPartida.PartidaAsociar(unaPartida);
                            ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Asociar Partida").Texto, BLLServicioIdioma.MostrarMensaje("Partida").Texto + " " + unaPartida.IdPartida.ToString());
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Partida Asociada correctamente").Texto);
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor seleccione una Partida y complete el Nro de Partida asignada y el monto acreditado").Texto);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaAsociar - btnAsociar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Error al intentar asociar la partida, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }

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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Solicitud no posee Partidas solicitadas").Texto);
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