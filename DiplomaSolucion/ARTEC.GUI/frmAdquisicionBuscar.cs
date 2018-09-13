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
            ///Traigo Dependencias para busqueda dinámica
            BLLDependencia ManagerDependencia = new BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();
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
                    }
                    else
                    {
                        GrillaAdquisicionBuscar.DataSource = null;
                        txtResBusqueda.Visible = true;
                    }
                }
                else
                {
                    GrillaAdquisicionBuscar.DataSource = null;
                    txtResBusqueda.Visible = true;
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
                frmAdquisicionGestion unFrmAdquisicionGestion = new frmAdquisicionGestion((Adquisicion)unasAdquisiciones.Where(x => x.IdAdquisicion == (int)GrillaAdquisicionBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                ResFrmAdquisicionModif = unFrmAdquisicionGestion.ShowDialog();

                if (ResFrmAdquisicionModif == DialogResult.OK)
                {
                    unasAdquisiciones.RemoveAt(e.RowIndex);
                    GrillaAdquisicionBuscar.DataSource = null;
                    if (unasAdquisiciones.Count == 0)
                    {
                        GrillaAdquisicionBuscar.Visible = false;
                        txtResBusqueda.Visible = true;
                    }
                    else
                    {
                        GrillaAdquisicionBuscar.DataSource = unasAdquisiciones;
                        //FormatearGrillaRendicionBuscar();
                    }
                        
                }
            }
        }


    }
}