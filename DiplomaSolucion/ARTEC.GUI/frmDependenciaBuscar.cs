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

        void unfrmDependenciaModificar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDependenciaBuscar_Load(this, new EventArgs());
        }






    }
}