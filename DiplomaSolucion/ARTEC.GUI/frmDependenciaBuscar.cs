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
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class frmDependenciaBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmDependenciaBuscar _unfrmDependenciaBuscarInst;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Dependencia DepSeleccionada;
        BLLDependencia ManagerDependencia = new BLLDependencia();

        public frmDependenciaBuscar()
        {
            InitializeComponent();
        }

        public static frmDependenciaBuscar ObtenerInstancia()
        {
            if (_unfrmDependenciaBuscarInst == null)
            {
                _unfrmDependenciaBuscarInst = new frmDependenciaBuscar();
            }

            return _unfrmDependenciaBuscarInst;
        }

        private void frmDependenciaBuscar_Load(object sender, EventArgs e)
        {
            ///Traigo Dependencias para busqueda dinámica
            unasDependencias = ManagerDependencia.TraerTodos();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnReactivar.Enabled = false;
            lblBaja.Visible = false;
        }


        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            DepSeleccionada = null;
            txtTipoDep.Clear();
            GrillaAgentes.DataSource = null;


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
                    cboDep.DataSource = res;
                    cboDep.SelectedIndex = 0;
                    cboDep_SelectionChangeCommitted(cboDep, new EventArgs());

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
                    cboDep.DataSource = null;
                    if (DepSeleccionada.IdDependencia > 0)
                    {
                        //Coloco el TipoDependencia
                        txtTipoDep.Text = DepSeleccionada.unTipoDep.DescripTipoDependencia;
                        //Coloco los agentes
                        GrillaAgentes.DataSource = null;
                        DepSeleccionada.unosAgentes = ManagerDependencia.TraerAgentesDependencia(DepSeleccionada.IdDependencia);
                        GrillaAgentes.DataSource = DepSeleccionada.unosAgentes;
                        GrillaAgentes.Columns["IdAgente"].Visible = false;
                        GrillaAgentes.Columns["NombreAgente"].HeaderText = "Nombre";
                        GrillaAgentes.Columns["ApellidoAgente"].HeaderText = "Apellido";
                        GrillaAgentes.Columns["unCargo"].HeaderText = "Cargo";
                        GrillaAgentes.Columns["unaDependencia"].Visible = false;
                        //Si no está activa
                        if (DepSeleccionada.Activo == 0)
                        {
                            lblBaja.Visible = true;
                            btnModificar.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnReactivar.Enabled = true;
                        }
                        else
                        {
                            lblBaja.Visible = false;
                            btnModificar.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnReactivar.Enabled = false;
                        }

                    }
                    
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmDependenciaModificar unfrmDependenciaModificar = new frmDependenciaModificar(DepSeleccionada);
            //CON ESTO hago que al cerrar el formulario del showdialog (frmdependenciamodificar), 
            //voy a la funcion unfrmdependenciamodificar_formclosing y actualizo las dependencias desde la bd para ver el cambio realizado en el otro formulario
            unfrmDependenciaModificar.FormClosing += unfrmDependenciaModificar_FormClosing; 
            txtDependencia.Clear();
            DepSeleccionada = null;
            txtTipoDep.Clear();
            this.GrillaAgentes.DataSource = null;
            unfrmDependenciaModificar.ShowDialog();
            


        }

        void unfrmDependenciaModificar_FormClosing(object sender, FormClosingEventArgs e)//El nombre de esta función no tiene que ver con el evento FormClosing de frmDependenciaModificar_FormClosing, le puse mal el nombre simplemente
        {
            frmDependenciaBuscar_Load(this, new EventArgs());
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmDependenciaCrear unFrmDependenciaCrear = new frmDependenciaCrear();
            //CON ESTO hago que al cerrar el formulario del showdialog (unFrmDependenciaCrear), 
            //voy a la funcion unFrmDependenciaCrear_FormClosing y actualizo las dependencias desde la bd para ver el cambio realizado en el otro formulario
            unFrmDependenciaCrear.FormClosing += unfrmDependenciaModificar_FormClosing;
            txtDependencia.Clear();
            DepSeleccionada = null;
            txtTipoDep.Clear();
            this.GrillaAgentes.DataSource = null;
            unFrmDependenciaCrear.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepSeleccionada != null && !string.IsNullOrWhiteSpace(txtDependencia.Text) && DepSeleccionada.IdDependencia > 0)
                {
                    DialogResult resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Dependencia: " + DepSeleccionada.NombreDependencia + "?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        if (ManagerDependencia.DependenciaEliminar(DepSeleccionada))
                        {
                            lblBaja.Visible = true;
                            btnModificar.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnReactivar.Enabled = true;
                            MessageBox.Show("Dependencia: " + DepSeleccionada.NombreDependencia + " dada de baja correctamente");
                        }
                        else
                            return;
                }
                else
                    MessageBox.Show("Para dar de baja una Categoría primero debe buscarla");
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaBuscar - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la dependencia, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepSeleccionada != null && !string.IsNullOrWhiteSpace(txtDependencia.Text) && DepSeleccionada.IdDependencia > 0)
                {
                    if (ManagerDependencia.DependenciaReactivar(DepSeleccionada))
                    {
                        lblBaja.Visible = false;
                        btnModificar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnReactivar.Enabled = false;
                        MessageBox.Show("Categoría: " + DepSeleccionada.NombreDependencia + " reactivada correctamente");
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaBuscar - btnReactivar_Click");
                MessageBox.Show("Ocurrio un error al intentar reactivar la Dependencia: " + DepSeleccionada.NombreDependencia + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }






    }
}