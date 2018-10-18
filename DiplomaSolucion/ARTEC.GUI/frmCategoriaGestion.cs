using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class frmCategoriaGestion : DevComponents.DotNetBar.Metro.MetroForm
    {
        BLLCategoria ManagerCategoria = new BLLCategoria();
        BLLProveedor ManagerProveedor = new BLLProveedor();
        List<Proveedor> unosProveedores = new List<Proveedor>();
        List<TipoBien> unosTiposBien = new List<TipoBien>();
        BLLTipoBien ManagerTipoBien = new BLLTipoBien();
        List<Proveedor> ProvsAgregar = new List<Proveedor>();
        Categoria unaCategoria;
        List<Proveedor> ProvsAgregarBKP = new List<Proveedor>();


        public frmCategoriaGestion()
        {
            InitializeComponent();
        }

        private void frmCategoriaGestion_Load(object sender, EventArgs e)
        {

            try
            {
                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                //Traer Proveedores
                unosProveedores = ManagerProveedor.ProveedorTraerTodosActivos();
                cboProveedor.DataSource = null;
                cboProveedor.DataSource = unosProveedores;
                cboProveedor.DisplayMember = "AliasProv";
                cboProveedor.ValueMember = "IdProveedor";

                //Traer TipoBien
                unosTiposBien = ManagerTipoBien.TraerTodos();
                cboTipo.DataSource = null;
                cboTipo.DataSource = unosTiposBien;
                cboTipo.DisplayMember = "DescripTipoBien";
                cboTipo.ValueMember = "IdTipoBien";
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            vldfrmCategoriaGestion.ClearFailedValidations();

            try
            {
                unaCategoria = null;
                if (!string.IsNullOrEmpty(txtCategoriaBuscar.Text) && !string.IsNullOrWhiteSpace(txtCategoriaBuscar.Text))
                {
                    unaCategoria = ManagerCategoria.CategoriaBuscar(txtCategoriaBuscar.Text);
                    if (unaCategoria != null && unaCategoria.IdCategoria > 0)
                    {
                        txtCategoria.Text = unaCategoria.DescripCategoria;
                        cboTipo.SelectedValue = unaCategoria.unTipoBien.IdTipoBien;
                        txtCategoriaBuscar.Clear();

                        if (unaCategoria.Activo == 0)
                        {
                            lblBaja.Visible = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnReactivar.Enabled = true;
                            btnModificar.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnAgregar.Enabled = false;
                            txtCategoria.Enabled = false;
                            cboProveedor.Enabled = false;
                            cboTipo.Enabled = false;
                            GrillaProveedores.Enabled = false;
                        }
                        else
                        {
                            lblBaja.Visible = false;
                            btnReactivar.Enabled = false;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnModificar.Enabled = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnEliminar.Enabled = true;
                            btnAgregar.Enabled = true;
                            txtCategoria.Enabled = true;
                            cboProveedor.Enabled = true;
                            cboTipo.Enabled = true;
                            GrillaProveedores.Enabled = true;
                        }

                        ProvsAgregar.Clear();
                        ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
                        ProvsAgregarBKP = ProvsAgregar.ToList();

                        GrillaProveedores.DataSource = null;
                        GrillaProveedores.DataSource = ProvsAgregar;
                        btnCrearCategoria.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("La categoría ingresada no existe");
                        txtCategoria.Clear();
                        cboTipo.Refresh();
                        cboProveedor.Refresh();
                        GrillaProveedores.DataSource = null;
                        unaCategoria = null;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnCrearCategoria.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnCrearCategoria.Enabled = true;
                        btnModificar.Enabled = false;
                        btnEliminar.Enabled = false;
                        ProvsAgregar.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("No ha ingresado ninguna categoría");
                    txtCategoria.Clear();
                    cboTipo.Refresh();
                    cboProveedor.Refresh();
                    GrillaProveedores.DataSource = null;
                    unaCategoria = null;
                    if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnCrearCategoria.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                    btnCrearCategoria.Enabled = true;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    ProvsAgregar.Clear();
                }



            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnBuscar_Click");
                MessageBox.Show("Ocurrio un error al buscar la categoría, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ProvsAgregar.Contains(cboProveedor.SelectedItem as Proveedor))
                ProvsAgregar.Add(cboProveedor.SelectedItem as Proveedor);
            GrillaProveedores.DataSource = null;
            GrillaProveedores.DataSource = ProvsAgregar;
        }


        private void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            if (!vldfrmCategoriaGestion.Validate())
                return;

            try
            {
                Categoria CatAux = ManagerCategoria.CategoriaBuscar(txtCategoria.Text);
                if (CatAux != null && CatAux.IdCategoria > 0)
                {
                    MessageBox.Show("La Categoría ingresada ya existe");
                    return;
                }
                Categoria nuevaCategoria = new Categoria();
                nuevaCategoria.DescripCategoria = txtCategoria.Text;
                nuevaCategoria.unTipoBien = cboTipo.SelectedItem as TipoBien;
                nuevaCategoria.LosProveedores = ProvsAgregar;
                if(ManagerCategoria.CategoriaCrear(nuevaCategoria))
                    MessageBox.Show("Categoría creada correctamente");

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnCrearCategoria_Click");
                MessageBox.Show("Ocurrio un error al intentar crear una categoría, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            vldfrmCategoriaGestion.ClearFailedValidations();
            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnCrearCategoria.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
            btnCrearCategoria.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            lblBaja.Visible = false;
            btnReactivar.Enabled = false;
            btnAgregar.Enabled = true;
            txtCategoria.Enabled = true;
            cboProveedor.Enabled = true;
            cboTipo.Enabled = true;
            GrillaProveedores.Enabled = true;
            txtCategoria.Clear();
            txtCategoriaBuscar.Clear();
            cboTipo.Refresh();
            cboProveedor.Refresh();
            GrillaProveedores.DataSource = null;
            unaCategoria = null;
            ProvsAgregar.Clear();
            ProvsAgregarBKP.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<Proveedor> ProvQuitarMod = new List<Proveedor>();
            List<Proveedor> ProvAgregarMod = new List<Proveedor>();

            if (!vldfrmCategoriaGestion.Validate())
                return;

            try
            {
                //Verificar que no existe una categoria con el nombre ingresado en la modificacion
                Categoria CatAux = null;
                if(unaCategoria.DescripCategoria != txtCategoria.Text)
                    CatAux = ManagerCategoria.CategoriaBuscar(txtCategoria.Text);
                if (CatAux != null && CatAux.IdCategoria > 0)
                {
                    MessageBox.Show("La Categoría ingresada ya existe");
                    return;
                }

                unaCategoria.DescripCategoria = txtCategoria.Text;
                unaCategoria.unTipoBien = cboTipo.SelectedItem as TipoBien;

                ProvQuitarMod = ProvsAgregarBKP.Where(d => !ProvsAgregar.Any(a => a.IdProveedor == d.IdProveedor)).ToList();
                ProvAgregarMod = ProvsAgregar.Where(d => !ProvsAgregarBKP.Any(a => a.IdProveedor == d.IdProveedor)).ToList();

                if (ManagerCategoria.CategoriaModificar(unaCategoria, ProvQuitarMod, ProvAgregarMod))
                {
                    ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
                    ProvsAgregarBKP = ProvsAgregar.ToList();
                    MessageBox.Show("Modificación realizada");
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnModificar_Click");
                MessageBox.Show("Ocurrio un error al intentar modificar la categoría, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                 if (unaCategoria != null && !string.IsNullOrWhiteSpace(txtCategoria.Text) && unaCategoria.IdCategoria > 0)
                {
                    DialogResult resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Categoria: " + unaCategoria.DescripCategoria + "?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        if(ManagerCategoria.CategoriaEliminar(unaCategoria))
                        {
                            lblBaja.Visible = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnReactivar.Enabled = true;
                            btnEliminar.Enabled = false;
                            btnModificar.Enabled = false;
                            btnCrearCategoria.Enabled = false;
                            btnAgregar.Enabled = false;
                            txtCategoria.Enabled = false;
                            cboProveedor.Enabled = false;
                            cboTipo.Enabled = false;
                            GrillaProveedores.Enabled = false;
                            MessageBox.Show("Categoría: " + unaCategoria.DescripCategoria + " dada de baja correctamente");
                        }
                    else
                        return;
                }
                else
                    MessageBox.Show("Para dar de baja una Categoría primero debe buscarla");
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCategoriaGestion - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la categoría, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (unaCategoria != null && !string.IsNullOrWhiteSpace(txtCategoria.Text) && unaCategoria.IdCategoria > 0)
                {
                    if (ManagerCategoria.CategoriaReactivar(unaCategoria))
                    {
                        lblBaja.Visible = false;
                        btnReactivar.Enabled = false;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnModificar.Enabled = true;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnEliminar.Enabled = true;
                        btnAgregar.Enabled = true;
                        txtCategoria.Enabled = true;
                        cboProveedor.Enabled = true;
                        cboTipo.Enabled = true;
                        GrillaProveedores.Enabled = true;
                        MessageBox.Show("Categoría: " + unaCategoria.DescripCategoria + " reactivada correctamente");
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCategoriaGestion - btnReactivar_Click");
                MessageBox.Show("Ocurrio un error al intentar reactivar la Categoría: " + unaCategoria.DescripCategoria + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }




        
    }
}