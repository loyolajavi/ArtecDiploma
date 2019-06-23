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

            Dictionary<string, string[]> dicfrmCategoriaGestion = new Dictionary<string, string[]>();
            string[] IdiomafrmCategoriaGestion = { "Categoría Gestión" };
            dicfrmCategoriaGestion.Add("Idioma", IdiomafrmCategoriaGestion);
            this.Tag = dicfrmCategoriaGestion;

            Dictionary<string, string[]> diclblCategoriaBuscar = new Dictionary<string, string[]>();
            string[] IdiomalblCategoriaBuscar = { "Categoría" };
            diclblCategoriaBuscar.Add("Idioma", IdiomalblCategoriaBuscar);
            this.lblCategoriaBuscar.Tag = diclblCategoriaBuscar;

            Dictionary<string, string[]> diclblCategoria = new Dictionary<string, string[]>();
            string[] IdiomalblCategoria = { "Categoría" };
            diclblCategoria.Add("Idioma", IdiomalblCategoria);
            this.lblCategoria.Tag = diclblCategoria;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> diclblBaja = new Dictionary<string, string[]>();
            string[] IdiomalblBaja = { "Dado de Baja" };
            diclblBaja.Add("Idioma", IdiomalblBaja);
            this.lblBaja.Tag = diclblBaja;

            Dictionary<string, string[]> dicbtnLimpiar = new Dictionary<string, string[]>();
            string[] IdiomabtnLimpiar = { "Limpiar" };
            dicbtnLimpiar.Add("Idioma", IdiomabtnLimpiar);
            this.btnLimpiar.Tag = dicbtnLimpiar;

            Dictionary<string, string[]> diclblTipo = new Dictionary<string, string[]>();
            string[] IdiomalblTipo = { "Tipo" };
            diclblTipo.Add("Idioma", IdiomalblTipo);
            this.lblTipo.Tag = diclblTipo;

            Dictionary<string, string[]> diclblProveedor = new Dictionary<string, string[]>();
            string[] IdiomalblProveedor = { "Proveedor" };
            diclblProveedor.Add("Idioma", IdiomalblProveedor);
            this.lblProveedor.Tag = diclblProveedor;

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;

            Dictionary<string, string[]> dicbtnCrearCategoria = new Dictionary<string, string[]>();
            string[] PerbtnCrearCategoria = { "Categoria Crear" };
            dicbtnCrearCategoria.Add("Permisos", PerbtnCrearCategoria);
            string[] IdiomabtnCrearCategoria = { "Crear" };
            dicbtnCrearCategoria.Add("Idioma", IdiomabtnCrearCategoria);
            this.btnCrearCategoria.Tag = dicbtnCrearCategoria;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] PerbtnModificar = { "Categoria Modificar" };
            dicbtnModificar.Add("Permisos", PerbtnModificar);
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnReactivar = new Dictionary<string, string[]>();
            string[] PerbtnReactivar = { "Categoria Reactivar" };
            dicbtnReactivar.Add("Permisos", PerbtnReactivar);
            string[] IdiomabtnReactivar = { "Reactivar" };
            dicbtnReactivar.Add("Idioma", IdiomabtnReactivar);
            this.btnReactivar.Tag = dicbtnReactivar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] PerbtnEliminar = { "Categoria Eliminar" };
            dicbtnEliminar.Add("Permisos", PerbtnEliminar);
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;


        }

        private void frmCategoriaGestion_Load(object sender, EventArgs e)
        {

            try
            {
                //Idioma
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                lblBaja.Visible = false;
                btnReactivar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;


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
            catch (Exception es)
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
                        FormatearGrillaProveedores();
                        btnCrearCategoria.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La categoría ingresada no existe").Texto);
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No ha ingresado ninguna categoría").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al buscar la categoría, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Categoría ingresada ya existe").Texto);
                    return;
                }
                Categoria nuevaCategoria = new Categoria();
                nuevaCategoria.DescripCategoria = txtCategoria.Text;
                nuevaCategoria.unTipoBien = cboTipo.SelectedItem as TipoBien;
                nuevaCategoria.LosProveedores = ProvsAgregar;
                ManagerCategoria.CategoriaCrear(nuevaCategoria);
                ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Crear Categoría").Texto, BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + nuevaCategoria.DescripCategoria);
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Categoría creada correctamente").Texto);
                btnLimpiar_Click(this, new EventArgs());

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnCrearCategoria_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear una categoría, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Categoría ingresada ya existe").Texto);
                    return;
                }

                unaCategoria.DescripCategoria = txtCategoria.Text;
                unaCategoria.unTipoBien = cboTipo.SelectedItem as TipoBien;

                ProvQuitarMod = ProvsAgregarBKP.Where(d => !ProvsAgregar.Any(a => a.IdProveedor == d.IdProveedor)).ToList();
                ProvAgregarMod = ProvsAgregar.Where(d => !ProvsAgregarBKP.Any(a => a.IdProveedor == d.IdProveedor)).ToList();

                ManagerCategoria.CategoriaModificar(unaCategoria, ProvQuitarMod, ProvAgregarMod);
                ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
                ProvsAgregarBKP = ProvsAgregar.ToList();
                ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Modificar Categoría").Texto, BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + unaCategoria.DescripCategoria);
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar la categoría, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                 if (unaCategoria != null && !string.IsNullOrWhiteSpace(txtCategoria.Text) && unaCategoria.IdCategoria > 0)
                {
                    DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja la Categoria: ").Texto + unaCategoria.DescripCategoria + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        ManagerCategoria.CategoriaEliminar(unaCategoria);
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
                        ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Eliminar Categoría").Texto, BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + unaCategoria.DescripCategoria);
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + unaCategoria.DescripCategoria + BLLServicioIdioma.MostrarMensaje(" dada de baja correctamente").Texto);
                    }
                        
                }
                else
                     MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Para dar de baja una Categoría primero debe buscarla").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCategoriaGestion - btnEliminar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar eliminar la categoría, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (unaCategoria != null && !string.IsNullOrWhiteSpace(txtCategoria.Text) && unaCategoria.IdCategoria > 0)
                {
                    ManagerCategoria.CategoriaReactivar(unaCategoria);
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
                    ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Reactivar Categoría").Texto, BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + unaCategoria.DescripCategoria);
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Categoría: ").Texto + unaCategoria.DescripCategoria + BLLServicioIdioma.MostrarMensaje(" reactivada correctamente").Texto);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCategoriaGestion - btnReactivar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar reactivar la Categoría: ").Texto + unaCategoria.DescripCategoria + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void GrillaProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Si se hizo click en el header, salir
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else
                {
                    //Si hizo click en Quitar
                    if (e.ColumnIndex == GrillaProveedores.Columns["btnDinBorrar"].Index)
                    {
                            ProvsAgregar.RemoveAt(e.RowIndex);
                            //Regenero la grilla de proveedores
                            GrillaProveedores.DataSource = null;
                            GrillaProveedores.DataSource = ProvsAgregar;
                            //AgregarBotonEliminar();
                            FormatearGrillaProveedores();
                    }
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        private void FormatearGrillaProveedores()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaProveedores.Columns.Contains("btnDinBorrar"))
                GrillaProveedores.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar el agente
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;

            Dictionary<string, string[]> dicdeleteButton = new Dictionary<string, string[]>();
            string[] PerdeleteButton = { "Proveedor Eliminar" };
            dicdeleteButton.Add("Permisos", PerdeleteButton);
            string[] IdiomadeleteButton = { "Eliminar" };
            dicdeleteButton.Add("Idioma", IdiomadeleteButton);
            deleteButton.Tag = dicdeleteButton;

            GrillaProveedores.Columns.Add(deleteButton);

            if (!string.IsNullOrEmpty(deleteButton.Name) && deleteButton.Tag != null && deleteButton.Tag.GetType() == typeof(Dictionary<string, string[]>) && (deleteButton.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
            {
                deleteButton.Visible = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((deleteButton.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
            }

            //Formato
            GrillaProveedores.Columns["IdProveedor"].Visible = false;
            GrillaProveedores.Columns["AliasProv"].HeaderText = "Nombre";
            GrillaProveedores.Columns["ContactoProv"].HeaderText = "Contacto";
            GrillaProveedores.Columns["MailContactoProv"].HeaderText = "Mail";
            GrillaProveedores.Columns["Activo"].Visible = false;
        }

        private void frmCategoriaGestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }

        
    }
}