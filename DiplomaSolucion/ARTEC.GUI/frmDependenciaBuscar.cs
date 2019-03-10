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
using ARTEC.BLL.Servicios;

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

            Dictionary<string, string[]> dicfrmDependenciaBuscar = new Dictionary<string, string[]>();
            string[] IdiomafrmDependenciaBuscar = { "Buscar Dependencia" };
            dicfrmDependenciaBuscar.Add("Idioma", IdiomafrmDependenciaBuscar);
            this.Tag = dicfrmDependenciaBuscar;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblBaja = new Dictionary<string, string[]>();
            string[] IdiomalblBaja = { "Dado de Baja" };
            diclblBaja.Add("Idioma", IdiomalblBaja);
            this.lblBaja.Tag = diclblBaja;

            Dictionary<string, string[]> diclblTipoDep = new Dictionary<string, string[]>();
            string[] IdiomalblTipoDep = { "Tipo Dependencia" };
            diclblTipoDep.Add("Idioma", IdiomalblTipoDep);
            this.lblTipoDep.Tag = diclblTipoDep;

            Dictionary<string, string[]> diclblAgentes = new Dictionary<string, string[]>();
            string[] IdiomalblAgentes = { "Agentes" };
            diclblAgentes.Add("Idioma", IdiomalblAgentes);
            this.lblAgentes.Tag = diclblAgentes;

            Dictionary<string, string[]> dicbtnCrear = new Dictionary<string, string[]>();
            string[] PerbtnCrear = { "Dependencia Crear" };
            dicbtnCrear.Add("Permisos", PerbtnCrear);
            string[] IdiomabtnCrear = { "Crear" };
            dicbtnCrear.Add("Idioma", IdiomabtnCrear);
            this.btnCrear.Tag = dicbtnCrear;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] PerbtnModificar = { "Dependencia Modificar" };
            dicbtnModificar.Add("Permisos", PerbtnModificar);
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] PerbtnEliminar = { "Dependencia Eliminar" };
            dicbtnEliminar.Add("Permisos", PerbtnEliminar);
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

            Dictionary<string, string[]> dicbtnReactivar = new Dictionary<string, string[]>();
            string[] PerbtnReactivar = { "Dependencia Reactivar" };
            dicbtnReactivar.Add("Permisos", PerbtnReactivar);
            string[] IdiomabtnReactivar = { "Reactivar" };
            dicbtnReactivar.Add("Idioma", IdiomabtnReactivar);
            this.btnReactivar.Tag = dicbtnReactivar;

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
            try
            {
                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos Formulario
                if (this.Tag != null && this.Tag.GetType() == typeof(Dictionary<string, string[]>) && (this.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                {
                    this.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((this.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                }

                //Permisos controles
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }
                ///Traigo Dependencias para busqueda dinámica
                unasDependencias = ManagerDependencia.TraerTodos();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnReactivar.Enabled = false;
                lblBaja.Visible = false;
            }
            catch (Exception)
            {
                
                throw;
            }

            
        }


        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            DepSeleccionada = null;
            txtTipoDep.Clear();
            GrillaAgentes.DataSource = null;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

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
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnReactivar.Enabled = true;
                        }
                        else
                        {
                            lblBaja.Visible = false;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnModificar.Enabled = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnEliminar.Enabled = true;
                            btnReactivar.Enabled = false;
                        }

                    }

                    
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepSeleccionada != null && DepSeleccionada.IdDependencia > 0)
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
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Primero seleccione una dependencia").Texto);
                }
                
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaBuscar - btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al abrir la modificación de la dependencia, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }

            


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
                    DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja la Dependencia: ").Texto + DepSeleccionada.NombreDependencia + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        ManagerDependencia.DependenciaEliminar(DepSeleccionada);
                        lblBaja.Visible = true;
                        btnModificar.Enabled = false;
                        btnEliminar.Enabled = false;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnReactivar.Enabled = true;
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Dependencia: ").Texto + DepSeleccionada.NombreDependencia + BLLServicioIdioma.MostrarMensaje(" dada de baja correctamente").Texto);
                }
                else
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Primero seleccione una Dependencia").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaBuscar - btnEliminar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar eliminar la dependencia, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepSeleccionada != null && !string.IsNullOrWhiteSpace(txtDependencia.Text) && DepSeleccionada.IdDependencia > 0)
                {
                    ManagerDependencia.DependenciaReactivar(DepSeleccionada);
                    lblBaja.Visible = false;
                    if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnModificar.Enabled = true;
                    if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnEliminar.Enabled = true;
                    btnReactivar.Enabled = false;
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + DepSeleccionada.NombreDependencia + BLLServicioIdioma.MostrarMensaje(" reactivada correctamente").Texto);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaBuscar - btnReactivar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar reactivar la Dependencia: ").Texto + DepSeleccionada.NombreDependencia + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }







    }
}