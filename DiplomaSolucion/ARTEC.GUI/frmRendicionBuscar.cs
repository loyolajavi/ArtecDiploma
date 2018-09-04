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
using System.Text.RegularExpressions;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmRendicionBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmRendicionBuscar _RendicionBuscarInst;
        List<Rendicion> unasRendiciones = new List<Rendicion>();
        BLLRendicion ManagerRendicion = new BLLRendicion();
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Dependencia DepSeleccionada;


        private frmRendicionBuscar()
        {
            InitializeComponent();
        }

        public static frmRendicionBuscar ObtenerInstancia()
        {
            if (_RendicionBuscarInst == null)
            {
                _RendicionBuscarInst = new frmRendicionBuscar();
            }

            return _RendicionBuscarInst;
        }


        private void frmRendicionBuscar_Load(object sender, EventArgs e)
        {
            ///Traigo Dependencias para busqueda dinámica
            BLLDependencia ManagerDependencia = new BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();
        }



        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            DepSeleccionada = null;

            if (!string.IsNullOrWhiteSpace(txtDependencia.Text) & txtDependencia.TextLength >= 3 || !string.IsNullOrWhiteSpace(txtDependencia.Text) & txtDependencia.TextLength <= 2 & Regex.IsMatch(txtDependencia.Text, @"\d"))
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
                    DepSeleccionada = cbo.SelectedItem as Dependencia;
                    this.txtDependencia.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDependencia.SelectionStart = txtDependencia.Text.Length + 1;
                }
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtResBusqueda.Visible = false;
            GrillaRendicionBuscar.Visible = true;

            try
            {
                if (!string.IsNullOrEmpty(txtNroRendicion.Text) | !string.IsNullOrEmpty(txtNroPart.Text) | !string.IsNullOrEmpty(txtNroSolic.Text) | !string.IsNullOrEmpty(txtDependencia.Text) && !txtNroRendicion.Text.Contains("%") & !txtNroPart.Text.Contains("%") & !txtNroSolic.Text.Contains("%") & !txtDependencia.Text.Contains("%") & !txtNroRendicion.Text.Contains("_") & !txtNroPart.Text.Contains("_") & !txtNroSolic.Text.Contains("_") & !txtDependencia.Text.Contains("_"))
                {
                    unasRendiciones = ManagerRendicion.RendicionBuscar(txtNroRendicion.Text, txtNroPart.Text, txtNroSolic.Text, txtDependencia.Text);

                    GrillaRendicionBuscar.DataSource = null;
                    GrillaRendicionBuscar.DataSource = unasRendiciones;
                    if (unasRendiciones.Count == 0)
                    {
                        GrillaRendicionBuscar.Visible = false;
                        txtResBusqueda.Visible = true;
                    }
                    else
                        FormatearGrillaRendicionBuscar();
                }
                else
                {
                    GrillaRendicionBuscar.DataSource = null;
                    GrillaRendicionBuscar.Visible = false;
                    txtResBusqueda.Visible = true;
                }

                //if (!string.IsNullOrEmpty(txtNroRendicion.Text) | !string.IsNullOrEmpty(txtDep.Text) | !string.IsNullOrEmpty(txtBien.Text) | !string.IsNullOrEmpty(txtFechaFin.Text) | !string.IsNullOrEmpty(txtFechaFin2.Text) | !string.IsNullOrEmpty(txtFechaInicio.Text) | !string.IsNullOrEmpty(txtFechaInicio2.Text) | (int)cboEstadoSolicitud.SelectedValue >= 0 | (int)cboAsignado.SelectedValue >= 0 | (int)cboPrioridad.SelectedValue >= 0 && !txtNroSolicitud.Text.Contains("%") & !txtDep.Text.Contains("%") & !txtBien.Text.Contains("%") & !txtNroSolicitud.Text.Contains("_") & !txtDep.Text.Contains("_") & !txtBien.Text.Contains("_"))
                //{
                //    if (!string.IsNullOrEmpty(txtNroSolicitud.Text))
                //    {
                //        unasSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
                //    }
                //    else
                //    {
                //        unasSolicitudes = ManagerSolicitud.SolicitudBuscar(txtDep.Text, (int?)cboEstadoSolicitud.SelectedValue, txtBien.Text, (int?)cboPrioridad.SelectedValue, (int?)cboAsignado.SelectedValue, (DateTime?)txtFechaInicio.Value, (DateTime?)txtFechaInicio2.Value, (DateTime?)txtFechaFin.Value, (DateTime?)txtFechaFin2.Value);
                //    }
                //    GrillaSolicitudBuscar.DataSource = null;
                //    GrillaSolicitudBuscar.DataSource = unasSolicitudes;
                //    GrillaSolicitudBuscar.Columns["Asignado"].Visible = true;
                //    if (unasSolicitudes.Count == 0)
                //    {
                //        GrillaSolicitudBuscar.Visible = false;
                //        txtResBusqueda.Visible = true;
                //    }
                //}
                
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmRendicionBuscar - btnBuscar_Click");
                MessageBox.Show("Error en la búsqueda, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }


        private void FormatearGrillaRendicionBuscar()
        {
            //Formato GrillaRendicionBuscar
            GrillaRendicionBuscar.Columns["IdRendicion"].HeaderText = "Rendición";
            GrillaRendicionBuscar.Columns["MontoGasto"].HeaderText = "Monto";
            GrillaRendicionBuscar.Columns["IdPartida"].HeaderText = "Partida";
            GrillaRendicionBuscar.Columns["FechaRen"].HeaderText = "Fecha";
        }

        private void GrillaRendicionBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult ResFrmRendicionModif = new DialogResult();

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                frmRendicionModif unFrmRendicionModif = new frmRendicionModif((Rendicion)unasRendiciones.Where(x => x.IdRendicion == (int)GrillaRendicionBuscar.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault());
                ResFrmRendicionModif = unFrmRendicionModif.ShowDialog();

                if (ResFrmRendicionModif == DialogResult.OK)
                {
                    unasRendiciones.RemoveAt(e.RowIndex);
                    GrillaRendicionBuscar.DataSource = null;
                    GrillaRendicionBuscar.DataSource = unasRendiciones;
                    if (unasRendiciones.Count == 0)
                    {
                        GrillaRendicionBuscar.Visible = false;
                        txtResBusqueda.Visible = true;
                    }
                    else
                        FormatearGrillaRendicionBuscar();
                }
            }
        }




    }
}