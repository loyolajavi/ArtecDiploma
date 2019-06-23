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
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class frmPartidaBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmPartidaBuscar _unFrmPartidaBuscarInst;
        Partida unaPartida = new Partida();
        BLLPartida ManagerPartida = new BLLPartida();
        List<Solicitud> unasSolicitudes;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        List<Partida> unaListaPartidas = new List<Partida>();

        public frmPartidaBuscar()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicFrmPartidaBuscar = new Dictionary<string, string[]>();
            string[] PerFrmPartidaBuscar = { "Partida Buscar" };
            dicFrmPartidaBuscar.Add("Permisos", PerFrmPartidaBuscar);
            this.Tag = dicFrmPartidaBuscar;

            Dictionary<string, string[]> dicGrillaPartidas = new Dictionary<string, string[]>();
            string[] IdiomaGrillaPartidas = { "Partidas" };
            dicGrillaPartidas.Add("Idioma", IdiomaGrillaPartidas);
            this.GrillaPartidas.Tag = dicGrillaPartidas;

            //Dictionary<string, string[]> dictxtNroSolicitud = new Dictionary<string, string[]>();
            //string[] IdiomatxtNroSolicitud = { "Solicitud" };
            //dictxtNroSolicitud.Add("Idioma", IdiomatxtNroSolicitud);
            //this.txtNroSolicitud.Tag = dictxtNroSolicitud;

            Dictionary<string, string[]> diclblIdSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblIdSolicitud = { "Solicitud" };
            diclblIdSolicitud.Add("Idioma", IdiomalblIdSolicitud);
            this.lblIdSolicitud.Tag = diclblIdSolicitud;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            //Dictionary<string, string[]> dictxtIdPartida = new Dictionary<string, string[]>();
            //string[] IdiomatxtIdPartida = { "Partida" };
            //dictxtIdPartida.Add("Idioma", IdiomatxtIdPartida);
            //this.txtIdPartida.Tag = dictxtIdPartida;

            Dictionary<string, string[]> diclblIdPartida = new Dictionary<string, string[]>();
            string[] IdiomalblIdPartida = { "Partida" };
            diclblIdPartida.Add("Idioma", IdiomalblIdPartida);
            this.lblIdPartida.Tag = diclblIdPartida;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblNroPartida = new Dictionary<string, string[]>();
            string[] IdiomalblNroPartida = { "Partida Referenciada" };
            diclblNroPartida.Add("Idioma", IdiomalblNroPartida);
            this.lblNroPartida.Tag = diclblNroPartida;

        }


        public static frmPartidaBuscar ObtenerInstancia()
        {
            if (_unFrmPartidaBuscarInst == null)
            {
                _unFrmPartidaBuscarInst = new frmPartidaBuscar();
            }

            return _unFrmPartidaBuscarInst;
        }

        private void frmPartidaBuscar_Load(object sender, EventArgs e)
        {
            //Permisos formulario
            if (this.Tag != null && this.Tag.GetType() == typeof(Dictionary<string, string[]>) && (this.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
            {
                this.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((this.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
            }

            //Idioma
            BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            ///Traigo Dependencias para busqueda dinámica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtResBusqueda.Visible = false;
            GrillaPartidas.Visible = true;

            BLLPartida ManagerPartida = new BLLPartida();

            try
            {
                if (!vldFrmPartidaBuscar.Validate())
                    return;

                //Si se ingresó algun dato
                if (!string.IsNullOrWhiteSpace(txtIdPartida.Text) | !string.IsNullOrWhiteSpace(txtNroSolicitud.Text) | !string.IsNullOrWhiteSpace(txtDependencia.Text))
                {
                    //Si se ingresó el IdPartida
                    if (!string.IsNullOrWhiteSpace(txtIdPartida.Text))
                    {
                        unaPartida = ManagerPartida.PartidaTraerPorNroPartConCanceladas(Int32.Parse(txtIdPartida.Text)).FirstOrDefault();

                        unaListaPartidas.Clear();
                        GrillaPartidas.DataSource = null;

                        if (unaPartida != null)
                        {
                            unaListaPartidas.Add(unaPartida);
                            GrillaPartidas.DataSource = unaListaPartidas;
                        }

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
                            unaListaPartidas = ManagerPartida.PartidasBuscarPorIdSolicitud(Int32.Parse(txtNroSolicitud.Text));
                            if (unaListaPartidas.Count() > 0)
                            {
                                GrillaPartidas.DataSource = null;
                                GrillaPartidas.DataSource = unaListaPartidas;
                            }
                            else
                            {
                                GrillaPartidas.DataSource = null;
                                txtResBusqueda.Visible = true;
                                GrillaPartidas.Visible = false;
                                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Solicitud no posee Partidas solicitadas").Texto);
                            }

                            txtDependencia.Clear();
                        }
                        //Si se ingresó dependencia
                        else
                        {
                            unasSolicitudes = ManagerSolicitud.SolicitudBuscar(txtDependencia.Text);
                            if (unasSolicitudes.Count() > 0)
                            {
                                unaListaPartidas.Clear();
                                foreach (Solicitud unaSolic in unasSolicitudes)
                                {
                                    List<Partida> LisPartidasLocal = new List<Partida>();
                                    LisPartidasLocal = ManagerPartida.PartidasBuscarPorIdSolicitud(unaSolic.IdSolicitud);
                                    if (LisPartidasLocal.Count() > 0)
                                        unaListaPartidas.AddRange(LisPartidasLocal);
                                }
                                if (unaListaPartidas.Count() > 0)
                                {
                                    GrillaPartidas.DataSource = null;
                                    GrillaPartidas.DataSource = unaListaPartidas;
                                }
                                else
                                {
                                    GrillaPartidas.DataSource = null;
                                    txtResBusqueda.Visible = true;
                                    GrillaPartidas.Visible = false;
                                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Solicitud no posee Partidas solicitadas").Texto);
                                }
                            }
                            else
                            {
                                GrillaPartidas.DataSource = null;
                                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La dependencia no posee solicitudes ni partidas").Texto);
                                txtResBusqueda.Visible = true;
                                GrillaPartidas.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    txtResBusqueda.Visible = true;
                    GrillaPartidas.DataSource = null;
                    GrillaPartidas.Visible = false;
                }
            }
            
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmPartidaBuscar - btnBuscar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Error en la búsqueda, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }



        }


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


        private void GrillaPartidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult ResfrmPartidaModificar = new DialogResult();

            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                frmPartidaModificar unfrmPartidaModificar = new frmPartidaModificar((int)GrillaPartidas.Rows[e.RowIndex].Cells["IdPartida"].Value);
                //((Solicitud)unasSolicitudes.Where(x => x.IdSolicitud == (int)GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                ResfrmPartidaModificar = unfrmPartidaModificar.ShowDialog();

                if (ResfrmPartidaModificar == DialogResult.Cancel)
                {
                    unaListaPartidas.Clear();
                    GrillaPartidas.DataSource = null;
                    txtDependencia.Clear();
                    txtNroSolicitud.Clear();
                }


            }
        }



        public void Recargar()
        {
            txtResBusqueda.Visible = false;
            GrillaPartidas.Visible = true;
            GrillaPartidas.DataSource = null;
            unaListaPartidas = new List<Partida>();
            frmPartidaBuscar_Load(this, new EventArgs());
        }

        private void frmPartidaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }





    }

}