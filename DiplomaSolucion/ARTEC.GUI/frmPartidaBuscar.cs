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
                    unaPartida = ManagerPartida.PartidaTraerPorNroPartConCanceladas(Int32.Parse(txtIdPartida.Text)).FirstOrDefault();

                    unaListaPartidas.Clear();
                    unaListaPartidas.Add(unaPartida);
                    GrillaPartidas.DataSource = null;
                    GrillaPartidas.DataSource = unaListaPartidas;

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
                            MessageBox.Show("La Solicitud no posee Partidas solicitadas");
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
                                MessageBox.Show("La Solicitud no posee Partidas solicitadas");
                            }
                        }
                        else
                        {
                            GrillaPartidas.DataSource = null;
                            MessageBox.Show("La dependencia no posee solicitudes ni partidas");
                        }
                    }
                }
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

        private void GrillaPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                frmPartidaModificar unfrmPartidaModificar = new frmPartidaModificar((int)GrillaPartidas.Rows[e.RowIndex].Cells["IdPartida"].Value);
                //((Solicitud)unasSolicitudes.Where(x => x.IdSolicitud == (int)GrillaSolicitudBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                unfrmPartidaModificar.Show();

            }
        }









    }

}