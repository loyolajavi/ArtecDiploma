using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL;
using ARTEC.ENTIDADES;
using System.Linq;
using ARTEC.BLL.Servicios;
using System.Text.RegularExpressions;

namespace ARTEC.GUI
{
    public partial class frmAdquisicionBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static frmAdquisicionBuscar _unFrmAdquisicionBuscar;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Dependencia DepSeleccionada;
        List<Adquisicion> unasAdquisiciones = new List<Adquisicion>();
        BLLAdquisicion ManagerAdquisicion = new BLLAdquisicion();

        public frmAdquisicionBuscar()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmAdquisicionBuscar = new Dictionary<string, string[]>();
            string[] IdiomafrmAdquisicionBuscar = { "Buscar Adquisición" };
            dicfrmAdquisicionBuscar.Add("Idioma", IdiomafrmAdquisicionBuscar);
            this.Tag = dicfrmAdquisicionBuscar;

            Dictionary<string, string[]> diclblIdAdquisicion = new Dictionary<string, string[]>();
            string[] IdiomalblIdAdquisicion = { "Adquisición" };
            diclblIdAdquisicion.Add("Idioma", IdiomalblIdAdquisicion);
            this.lblIdAdquisicion.Tag = diclblIdAdquisicion;


            Dictionary<string, string[]> diclabelX1 = new Dictionary<string, string[]>();
            string[] IdiomalabelX1 = { "Partida" };
            diclabelX1.Add("Idioma", IdiomalabelX1);
            this.labelX1.Tag = diclabelX1;


            Dictionary<string, string[]> diclabelX2 = new Dictionary<string, string[]>();
            string[] IdiomalabelX2 = { "Dependencia" };
            diclabelX2.Add("Idioma", IdiomalabelX2);
            this.labelX2.Tag = diclabelX2;


            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;


            Dictionary<string, string[]> diclblFecha = new Dictionary<string, string[]>();
            string[] IdiomalblFecha = { "Fecha" };
            diclblFecha.Add("Idioma", IdiomalblFecha);
            this.lblFecha.Tag = diclblFecha;


            Dictionary<string, string[]> diclblFechaCompra = new Dictionary<string, string[]>();
            string[] IdiomalblFechaCompra = { "Fecha Compra" };
            diclblFechaCompra.Add("Idioma", IdiomalblFechaCompra);
            this.lblFechaCompra.Tag = diclblFechaCompra;

            Dictionary<string, string[]> diclblNroFactura = new Dictionary<string, string[]>();
            string[] IdiomalblNroFactura = { "Factura" };
            diclblNroFactura.Add("Idioma", IdiomalblNroFactura);
            this.lblNroFactura.Tag = diclblNroFactura;

            Dictionary<string, string[]> diclblSerieKey = new Dictionary<string, string[]>();
            string[] IdiomalblSerieKey = { "Serie" };
            diclblSerieKey.Add("Idioma", IdiomalblSerieKey);
            this.lblSerieKey.Tag = diclblSerieKey;

            Dictionary<string, string[]> diclblNroSolicitud = new Dictionary<string, string[]>();
            string[] IdiomalblNroSolicitud = { "Solicitud" };
            diclblNroSolicitud.Add("Idioma", IdiomalblNroSolicitud);
            this.lblNroSolicitud.Tag = diclblNroSolicitud;

            Dictionary<string, string[]> dictxtResBusqueda = new Dictionary<string, string[]>();
            string[] IdiomatxtResBusqueda = { "No hay resultados" };
            dictxtResBusqueda.Add("Idioma", IdiomatxtResBusqueda);
            this.txtResBusqueda.Tag = dictxtResBusqueda;

        }


        public static frmAdquisicionBuscar ObtenerInstancia()
        {
            if (_unFrmAdquisicionBuscar == null)
            {
                _unFrmAdquisicionBuscar = new frmAdquisicionBuscar();
            }

            return _unFrmAdquisicionBuscar;
        }


        private void frmAdquisicionBuscar_Load(object sender, EventArgs e)
        {
            //Permisos Formulario
            if (this.Tag != null && this.Tag.GetType() == typeof(Dictionary<string, string[]>) && (this.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
            {
                this.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((this.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
            }

            ///Traigo Dependencias para busqueda dinámica
            BLLDependencia ManagerDependencia = new BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

            //Traducir
            BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

        }

        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            DepSeleccionada = null;

            if (!string.IsNullOrWhiteSpace(txtDep.Text) & txtDep.TextLength >= 3 || !string.IsNullOrWhiteSpace(txtDep.Text) & txtDep.TextLength <= 2 & Regex.IsMatch(txtDep.Text, @"\d"))
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
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtDep.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                if (res.Count == 1 && string.Equals(res.First().NombreDependencia, txtDep.Text))
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
            if (!string.IsNullOrWhiteSpace(txtDep.Text))
            {
                if (cboDep.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtDep.TextChanged -= new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDep.Text = cbo.GetItemText(cbo.SelectedItem);
                    DepSeleccionada = cbo.SelectedItem as Dependencia;
                    this.txtDep.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDep.SelectionStart = txtDep.Text.Length + 1;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GrillaAdquisicionBuscar.DataSource = null;
            txtResBusqueda.Visible = false;

            if (!vldFrmAdquisicionBuscar.Validate())
                return;

            try
            {
                if (!string.IsNullOrEmpty(txtIdAdquisicion.Text) | !string.IsNullOrEmpty(txtNroPartida.Text) | !string.IsNullOrEmpty(txtDep.Text) | !string.IsNullOrEmpty(txtFecha.Text) | !string.IsNullOrEmpty(txtFechaCompra.Text) | !string.IsNullOrEmpty(txtNroFactura.Text) | !string.IsNullOrEmpty(txtNroSolicitud.Text))
                {
                    unasAdquisiciones = ManagerAdquisicion.AdquisicionBuscar(txtIdAdquisicion.Text, txtNroPartida.Text, txtDep.Text, (DateTime?)txtFecha.Value, (DateTime?)txtFechaCompra.Value, txtNroFactura.Text, txtNroSolicitud.Text);

                    if (unasAdquisiciones.Count > 0)
                    {
                        GrillaAdquisicionBuscar.DataSource = null;
                        GrillaAdquisicionBuscar.DataSource = unasAdquisiciones;
                        GrillaAdquisicionBuscar.BringToFront();
                    }
                    else
                    {
                        GrillaAdquisicionBuscar.DataSource = null;
                        txtResBusqueda.Visible = true;
                        txtResBusqueda.BringToFront();
                    }
                }
                else
                {
                    GrillaAdquisicionBuscar.DataSource = null;
                    txtResBusqueda.Visible = true;
                    txtResBusqueda.BringToFront();
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAdquisicionBuscar - btnBuscar_Click");
                MessageBox.Show("Error en la búsqueda, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void GrillaAdquisicionBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult ResFrmAdquisicionModif = new DialogResult();

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                int IndexAdqSelec = unasAdquisiciones.IndexOf(unasAdquisiciones.Where(x => x.IdAdquisicion == (int)GrillaAdquisicionBuscar.Rows[e.RowIndex].Cells[0].Value).First());
                int IdAdqSelec = unasAdquisiciones.Where(x => x.IdAdquisicion == (int)GrillaAdquisicionBuscar.Rows[e.RowIndex].Cells[0].Value).First().IdAdquisicion;
                frmAdquisicionGestion unFrmAdquisicionGestion = new frmAdquisicionGestion((Adquisicion)unasAdquisiciones.Where(x => x.IdAdquisicion == (int)GrillaAdquisicionBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                ResFrmAdquisicionModif = unFrmAdquisicionGestion.ShowDialog();

                if (ResFrmAdquisicionModif == DialogResult.OK)
                {
                    unasAdquisiciones[IndexAdqSelec] = ManagerAdquisicion.AdquisicionBuscar(IdAdqSelec.ToString(), "", "", DateTime.MinValue, DateTime.MinValue, "", "").First();
                    GrillaAdquisicionBuscar.DataSource = null;
                    GrillaAdquisicionBuscar.DataSource = unasAdquisiciones;
                    GrillaAdquisicionBuscar.BringToFront();
                }
                else if (ResFrmAdquisicionModif == DialogResult.No)
                {
                    unasAdquisiciones.RemoveAt(e.RowIndex);
                    GrillaAdquisicionBuscar.DataSource = null;
                    if (unasAdquisiciones.Count == 0)
                    {
                        GrillaAdquisicionBuscar.Visible = false;
                        txtResBusqueda.Visible = true;
                        txtResBusqueda.BringToFront();
                    }
                    else
                    {
                        GrillaAdquisicionBuscar.DataSource = unasAdquisiciones;
                        GrillaAdquisicionBuscar.BringToFront();
                    }
                }
            }
        }


    }
}