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
using System.IO;
using ARTEC.FRAMEWORK;
using ARTEC.BLL.Servicios;
using System.Text.RegularExpressions;

namespace ARTEC.GUI
{
    public partial class frmProveedorCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        Proveedor nuevoProveedor = new Proveedor();
        List<Categoria> unasCategorias = new List<Categoria>();
        Categoria unaCat;
        Proveedor unProvBuscar;
        List<Categoria> CategoriasAgregar = new List<Categoria>();
        List<Categoria> CategoriasAgregarBKP = new List<Categoria>();
        BLLProveedor ManagerProveedor = new BLLProveedor();
        List<Proveedor> unosProveedores = new List<Proveedor>();
        List<Telefono> TelsAgregar = new List<Telefono>();
        List<Telefono> TelsAgregarBKP = new List<Telefono>();
        List<Direccion> DirAgregar = new List<Direccion>();
        List<Direccion> DirAgregarBKP = new List<Direccion>();
        List<TipoTelefono> unosTipoTelefonos = new List<TipoTelefono>();
        List<Provincia> unasProvincias = new List<Provincia>();

        public frmProveedorCrear()
        {
            InitializeComponent();

            Dictionary<string, string[]> diclblNombreEmpresa = new Dictionary<string, string[]>();
            string[] IdiomalblNombreEmpresa = { "Nombre" };
            diclblNombreEmpresa.Add("Idioma", IdiomalblNombreEmpresa);
            this.lblNombreEmpresa.Tag = diclblNombreEmpresa;

            Dictionary<string, string[]> diclblContacto = new Dictionary<string, string[]>();
            string[] IdiomalblContacto = { "Contacto" };
            diclblContacto.Add("Idioma", IdiomalblContacto);
            this.lblContacto.Tag = diclblContacto;

            Dictionary<string, string[]> diclblTelefono = new Dictionary<string, string[]>();
            string[] IdiomalblTelefono = { "Telefono" };
            diclblTelefono.Add("Idioma", IdiomalblTelefono);
            this.lblTelefono.Tag = diclblTelefono;

            Dictionary<string, string[]> diclblDireccion = new Dictionary<string, string[]>();
            string[] IdiomalblDireccion = { "Dirección" };
            diclblDireccion.Add("Idioma", IdiomalblDireccion);
            this.lblDireccion.Tag = diclblDireccion;

            Dictionary<string, string[]> diclblMailContacto = new Dictionary<string, string[]>();
            string[] IdiomalblMailContacto = { "Mail" };
            diclblMailContacto.Add("Idioma", IdiomalblMailContacto);
            this.lblMailContacto.Tag = diclblMailContacto;

            Dictionary<string, string[]> dicgpanelProductos = new Dictionary<string, string[]>();
            string[] IdiomagpanelProductos = { "Productos" };
            dicgpanelProductos.Add("Idioma", IdiomagpanelProductos);
            this.gpanelProductos.Tag = dicgpanelProductos;

            Dictionary<string, string[]> dicbtnAgregarProd = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregarProd = { "Agregar" };
            dicbtnAgregarProd.Add("Idioma", IdiomabtnAgregarProd);
            this.btnAgregarProd.Tag = dicbtnAgregarProd;

            Dictionary<string, string[]> dicbtnCrearProveedor = new Dictionary<string, string[]>();
            string[] PerbtnCrearProveedor = { "Proveedor Crear" };
            dicbtnCrearProveedor.Add("Permisos", PerbtnCrearProveedor);
            string[] IdiomabtnCrearProveedor = { "Crear Proveedor" };
            dicbtnCrearProveedor.Add("Idioma", IdiomabtnCrearProveedor);
            this.btnCrearProveedor.Tag = dicbtnCrearProveedor;

            Dictionary<string, string[]> dicbtnTelefono = new Dictionary<string, string[]>();
            string[] IdiomabtnTelefono = { "Agregar" };
            dicbtnTelefono.Add("Idioma", IdiomabtnTelefono);
            this.btnTelefono.Tag = dicbtnTelefono;

            Dictionary<string, string[]> dicbtnDireccion = new Dictionary<string, string[]>();
            string[] IdiomabtnDireccion = { "Agregar" };
            dicbtnDireccion.Add("Idioma", IdiomabtnDireccion);
            this.btnDireccion.Tag = dicbtnDireccion;

            Dictionary<string, string[]> dicpnlBuscar = new Dictionary<string, string[]>();
            string[] IdiomapnlBuscar = { "Buscar" };
            dicpnlBuscar.Add("Idioma", IdiomapnlBuscar);
            this.pnlBuscar.Tag = dicpnlBuscar;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> diclblProveedor = new Dictionary<string, string[]>();
            string[] IdiomalblProveedor = { "Proveedor" };
            diclblProveedor.Add("Idioma", IdiomalblProveedor);
            this.lblProveedor.Tag = diclblProveedor;

            Dictionary<string, string[]> diclblTipo = new Dictionary<string, string[]>();
            string[] IdiomalblTipo = { "Tipo" };
            diclblTipo.Add("Idioma", IdiomalblTipo);
            this.lblTipo.Tag = diclblTipo;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] PerbtnModificar = { "Proveedor Modificar" };
            dicbtnModificar.Add("Permisos", PerbtnModificar);
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] PerbtnEliminar = { "Proveedor Eliminar" };
            dicbtnEliminar.Add("Permisos", PerbtnEliminar);
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

            Dictionary<string, string[]> dicbtnReactivar = new Dictionary<string, string[]>();
            string[] PerbtnReactivar = { "Proveedor Reactivar" };
            dicbtnReactivar.Add("Permisos", PerbtnReactivar);
            string[] IdiomabtnReactivar = { "Reactivar" };
            dicbtnReactivar.Add("Idioma", IdiomabtnReactivar);
            this.btnReactivar.Tag = dicbtnReactivar;

            Dictionary<string, string[]> dicbtnLimpiar = new Dictionary<string, string[]>();
            string[] IdiomabtnLimpiar = { "Limpiar" };
            dicbtnLimpiar.Add("Idioma", IdiomabtnLimpiar);
            this.btnLimpiar.Tag = dicbtnLimpiar;



        }

        private void ProveedorCrear_Load(object sender, EventArgs e)
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

                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

                //Permisos para buscar
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Proveedor Buscar" }))
                {
                    this.txtProveedorBuscar.TextChanged -= new System.EventHandler(this.txtProveedorBuscar_TextChanged);
                    this.cboProveedor.SelectionChangeCommitted -= new System.EventHandler(this.cboProveedor_SelectionChangeCommitted);
                }

                btnModificar.Enabled = false;
                lblBaja.Visible = false;
                btnReactivar.Enabled = false;
                btnEliminar.Enabled = false;


                BLLCategoria ManagerCategoria = new BLLCategoria();
                unasCategorias = ManagerCategoria.CategoriaTraerTodosActivos();
                unosProveedores = ManagerProveedor.ProveedorTraerTodos();

                BLLTelefono ManagerTelefono = new BLLTelefono();
                unosTipoTelefonos = ManagerTelefono.TelefonoTipoTraerTodos();
                cboTipo.DataSource = null;
                cboTipo.DataSource = unosTipoTelefonos;
                cboTipo.DisplayMember = "DescripTipoTel";
                cboTipo.ValueMember = "IdTipoTelefono";

                BLLDireccion ManagerDireccion = new BLLDireccion();
                unasProvincias = ManagerDireccion.DireccionProvinciaTraerTodos();
                cboProvincia.DataSource = null;
                cboProvincia.DataSource = unasProvincias;
                cboProvincia.DisplayMember = "NombreProvincia";
                cboProvincia.ValueMember = "IdProvincia";



                BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - ProveedorCrear_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al cargar la pantalla de proveedores, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
           

            
        }


        //Busqueda Dinamica BIENES(CATEGORIAS)
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProducto.Text))
            {

                List<Categoria> resCat = new List<Categoria>();
                resCat = unasCategorias.ToList();


                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtProducto.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resCat = (List<Categoria>)(from cat in resCat
                                               where cat.DescripCategoria.ToLower().Contains(unaPalabra.ToLower())
                                               select cat).ToList();
                }

                if (resCat.Count > 0)
                {
                    if (resCat.Count == 1 && string.Equals(resCat.First().DescripCategoria, txtProducto.Text))
                    {
                        cboProducto.Visible = false;
                        cboProducto.DroppedDown = false;
                        cboProducto.DataSource = null;
                    }
                    else
                    {
                        cboProducto.DataSource = null;
                        cboProducto.DataSource = resCat;
                        cboProducto.DisplayMember = "DescripCategoria";
                        cboProducto.ValueMember = "IdCategoria";
                        cboProducto.Visible = true;
                        cboProducto.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboProducto.Visible = false;
                    cboProducto.DroppedDown = false;
                    cboProducto.DataSource = null;
                }
            }
            else
            {
                cboProducto.Visible = false;
                cboProducto.DroppedDown = false;
                cboProducto.DataSource = null;
            }
        }


        private void cboProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                if (cboProducto.SelectedIndex > -1)
                {
                    ComboBox cbo2 = (ComboBox)sender;
                    unaCat = new Categoria();
                    unaCat = (Categoria)cbo2.SelectedItem;
                    this.txtProducto.TextChanged -= new System.EventHandler(this.txtProducto_TextChanged);
                    txtProducto.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
                    txtProducto.SelectionStart = txtProducto.Text.Length + 1;
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                }
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            requiredFieldValidator3.Enabled = false;
            requiredFieldValidator4.Enabled = false;
            requiredFieldValidator1.Enabled = false;
            requiredFieldValidator9.Enabled = false;
            requiredFieldValidator2.Enabled = true;
            requiredFieldValidator5.Enabled = false;
            requiredFieldValidator6.Enabled = false;
            requiredFieldValidator7.Enabled = false;
            requiredFieldValidator8.Enabled = false;

            if (!vldFrmProveedorCrear.Validate())
                return;

            if (unaCat != null && !CategoriasAgregar.Contains(unaCat))
                CategoriasAgregar.Add(unaCat);

            GrillaProductos.DataSource = null;
            GrillaProductos.DataSource = CategoriasAgregar;
            GrillaProductos.Columns[0].Visible = false;
            GrillaProductos.Columns[1].HeaderText = "Productos";
            FormatearGrillaCategorias();
        }

   

        private void btnTelefono_Click(object sender, EventArgs e)
        {
            requiredFieldValidator3.Enabled = true;
            requiredFieldValidator4.Enabled = true;
            requiredFieldValidator1.Enabled = false;
            requiredFieldValidator9.Enabled = false;
            requiredFieldValidator2.Enabled = false;
            requiredFieldValidator5.Enabled = false;
            requiredFieldValidator6.Enabled = false;
            requiredFieldValidator7.Enabled = false;
            requiredFieldValidator8.Enabled = false;
            if (!vldFrmProveedorCrear.Validate())
                return;
            Telefono unTel = new Telefono();
            unTel.NroTelefono = Int32.Parse(txtNroTelefono.Text);
            unTel.CodArea = Int32.Parse(txtCodArea.Text);
            unTel.unTipoTelefono = cboTipo.SelectedItem as TipoTelefono;

            if (!TelsAgregar.Contains(unTel))
                TelsAgregar.Add(unTel);

            GrillaTelefonos.DataSource = null;
            GrillaTelefonos.DataSource = TelsAgregar;
            FormatearGrillaTelefonos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            vldFrmProveedorCrear.ClearFailedValidations();
            
            //try
            //{
            //    nuevoProveedor = null;
            //    if (!string.IsNullOrEmpty(txtCategoriaBuscar.Text) && !string.IsNullOrWhiteSpace(txtCategoriaBuscar.Text))
            //    {
            //        unaCategoria = ManagerCategoria.CategoriaBuscar(txtCategoriaBuscar.Text);
            //        if (unaCategoria != null && unaCategoria.IdCategoria > 0)
            //        {
            //            txtCategoria.Text = unaCategoria.DescripCategoria;
            //            cboTipo.SelectedValue = unaCategoria.unTipoBien.IdTipoBien;
            //            txtCategoriaBuscar.Clear();

            //            if (unaCategoria.Activo == 0)
            //            {
            //                lblBaja.Visible = true;
            //                btnReactivar.Enabled = true;
            //                btnModificar.Enabled = false;
            //                btnEliminar.Enabled = false;
            //                btnAgregar.Enabled = false;
            //                txtCategoria.Enabled = false;
            //                cboProveedor.Enabled = false;
            //                cboTipo.Enabled = false;
            //                GrillaProveedores.Enabled = false;
            //            }
            //            else
            //            {
            //                lblBaja.Visible = false;
            //                btnReactivar.Enabled = false;
            //                btnModificar.Enabled = true;
            //                btnEliminar.Enabled = true;
            //                btnAgregar.Enabled = true;
            //                txtCategoria.Enabled = true;
            //                cboProveedor.Enabled = true;
            //                cboTipo.Enabled = true;
            //                GrillaProveedores.Enabled = true;
            //            }

            //            ProvsAgregar.Clear();
            //            ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
            //            ProvsAgregarBKP = ProvsAgregar.ToList();

            //            GrillaProveedores.DataSource = null;
            //            GrillaProveedores.DataSource = ProvsAgregar;
            //            btnCrearCategoria.Enabled = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("La categoría ingresada no existe");
            //            txtCategoria.Clear();
            //            cboTipo.Refresh();
            //            cboProveedor.Refresh();
            //            GrillaProveedores.DataSource = null;
            //            unaCategoria = null;
            //            btnCrearCategoria.Enabled = true;
            //            btnModificar.Enabled = false;
            //            btnEliminar.Enabled = false;
            //            ProvsAgregar.Clear();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No ha ingresado ninguna categoría");
            //        txtCategoria.Clear();
            //        cboTipo.Refresh();
            //        cboProveedor.Refresh();
            //        GrillaProveedores.DataSource = null;
            //        unaCategoria = null;
            //        btnCrearCategoria.Enabled = true;
            //        btnModificar.Enabled = false;
            //        btnEliminar.Enabled = false;
            //        ProvsAgregar.Clear();
            //    }



            //}
            //catch (Exception es)
            //{
            //    string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - btnBuscar_Click");
            //    MessageBox.Show("Ocurrio un error al buscar la categoría, por favor informe del error Nro " + IdError + " del Log de Eventos");
            //}

        }



        //Busqueda Dinamica Proveedores
        private void txtProveedorBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProveedorBuscar.Text) & txtProveedorBuscar.TextLength >= 3 || !string.IsNullOrWhiteSpace(txtProveedorBuscar.Text) & txtProveedorBuscar.TextLength <= 2 & Regex.IsMatch(txtProveedorBuscar.Text, @"\d"))
            {

                List<Proveedor> resProv = new List<Proveedor>();
                resProv = unosProveedores.ToList();


                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtProveedorBuscar.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resProv = (List<Proveedor>)(from prov in resProv
                                               where prov.AliasProv.ToLower().Contains(unaPalabra.ToLower())
                                               select prov).ToList();
                }

                if (resProv.Count > 0)
                {
                    if (resProv.Count == 1 && string.Equals(resProv.First().AliasProv, txtProveedorBuscar.Text))
                    {
                        cboProveedor.Visible = false;
                        cboProveedor.DroppedDown = false;
                        cboProveedor.DataSource = null;
                    }
                    else
                    {
                        cboProveedor.DataSource = null;
                        cboProveedor.DataSource = resProv;
                        cboProveedor.DisplayMember = "AliasProv";
                        cboProveedor.ValueMember = "IdProveedor";
                        cboProveedor.Visible = true;
                        cboProveedor.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboProveedor.Visible = false;
                    cboProveedor.DroppedDown = false;
                    cboProveedor.DataSource = null;
                }
            }
            else
            {
                cboProveedor.Visible = false;
                cboProveedor.DroppedDown = false;
                cboProveedor.DataSource = null;
            }
        }


        private void cboProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProveedorBuscar.Text))
            {
                if (cboProveedor.SelectedIndex > -1)
                {
                    vldFrmProveedorCrear.ClearFailedValidations();
                    ComboBox cbo3 = (ComboBox)sender;
                    unProvBuscar = new Proveedor();
                    unProvBuscar = (Proveedor)cbo3.SelectedItem;
                    this.txtProveedorBuscar.TextChanged -= new System.EventHandler(this.txtProveedorBuscar_TextChanged);
                    txtProveedorBuscar.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    this.txtProveedorBuscar.TextChanged += new System.EventHandler(this.txtProveedorBuscar_TextChanged);
                    txtProveedorBuscar.SelectionStart = txtProveedorBuscar.Text.Length + 1;

                    try
                    {
                        CategoriasAgregar.Clear();
                        CategoriasAgregar = ManagerProveedor.ProveedorTraerCategorias(unProvBuscar.IdProveedor);
                        CategoriasAgregarBKP = CategoriasAgregar.ToList();
                        TelsAgregar.Clear();
                        TelsAgregar = ManagerProveedor.ProveedorTraerTelefonos(unProvBuscar.IdProveedor);
                        TelsAgregarBKP = TelsAgregar.ToList();
                        DirAgregar.Clear();
                        DirAgregar = ManagerProveedor.ProveedorTraerDirecciones(unProvBuscar.IdProveedor);
                        DirAgregarBKP = DirAgregar.ToList();

                        txtNombreEmpresa.Text = unProvBuscar.AliasProv;
                        txtContacto.Text = unProvBuscar.ContactoProv;
                        txtMailContacto.Text = unProvBuscar.MailContactoProv;
                        GrillaProductos.DataSource = null;
                        GrillaProductos.DataSource = CategoriasAgregar;
                        GrillaTelefonos.DataSource = null;
                        GrillaTelefonos.DataSource = TelsAgregar;
                        GrillaDirecciones.DataSource = null;
                        GrillaDirecciones.DataSource = DirAgregar;

                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnModificar.Enabled = true;
                        btnCrearProveedor.Enabled = false;

                        FormatearGrillaCategorias();
                        FormatearGrillaTelefonos();
                        FormatearGrillaDirecciones();

                        if (unProvBuscar.Activo == 0)
                        {
                            lblBaja.Visible = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnReactivar.Enabled = true;
                            btnEliminar.Enabled = false;
                            btnModificar.Enabled = false;
                            btnCrearProveedor.Enabled = false;
                            btnAgregarProd.Enabled = false;
                            btnTelefono.Enabled = false;
                            btnDireccion.Enabled = false;
                            txtNombreEmpresa.Enabled = false;
                            txtContacto.Enabled = false;
                            txtMailContacto.Enabled = false;
                            GrillaProductos.Enabled = false;
                            GrillaTelefonos.Enabled = false;
                            GrillaDirecciones.Enabled = false;
                        }
                        else
                        {
                            lblBaja.Visible = false;
                            btnReactivar.Enabled = false;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnEliminar.Enabled = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnModificar.Enabled = true;
                            btnCrearProveedor.Enabled = false;
                            btnAgregarProd.Enabled = true;
                            btnTelefono.Enabled = true;
                            btnDireccion.Enabled = true;
                            txtNombreEmpresa.Enabled = true;
                            txtContacto.Enabled = true;
                            txtMailContacto.Enabled = true;
                            GrillaProductos.Enabled = true;
                            GrillaTelefonos.Enabled = true;
                            GrillaDirecciones.Enabled = true;
                        }
                    }
                    catch (Exception es)
                    {
                        string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - cboProveedor_SelectionChangeCommitted");
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al buscar la categoría, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
                    }

                }
            }
        }


        private void btnCrearProveedor_Click(object sender, EventArgs e)
        {
            requiredFieldValidator1.Enabled = true;
            requiredFieldValidator9.Enabled = true;
            requiredFieldValidator2.Enabled = false;
            requiredFieldValidator3.Enabled = false;
            requiredFieldValidator4.Enabled = false;
            requiredFieldValidator5.Enabled = false;
            requiredFieldValidator6.Enabled = false;
            requiredFieldValidator7.Enabled = false;
            requiredFieldValidator8.Enabled = false;

            if (!vldFrmProveedorCrear.Validate())
                return;

            try
            {
                Proveedor ProvAux = ManagerProveedor.ProveedorBuscar(txtNombreEmpresa.Text);
                if (ProvAux != null && ProvAux.IdProveedor > 0)
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El Proveedor ingresado ya existe").Texto);
                    return;
                }

                nuevoProveedor.AliasProv = txtNombreEmpresa.Text;
                nuevoProveedor.ContactoProv = txtContacto.Text;
                nuevoProveedor.MailContactoProv = txtMailContacto.Text;
                nuevoProveedor.unasCategorias = CategoriasAgregar;
                nuevoProveedor.unosTelefonos = TelsAgregar;
                nuevoProveedor.unasDirecciones = DirAgregar;

                ManagerProveedor.ProveedorCrear(nuevoProveedor);
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Proveedor creado correctamente").Texto);

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - btnCrearProveedor_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear un proveedor, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
        }

        private void btnDireccion_Click(object sender, EventArgs e)
        {
            requiredFieldValidator3.Enabled = false;
            requiredFieldValidator4.Enabled = false;
            requiredFieldValidator1.Enabled = false;
            requiredFieldValidator9.Enabled = false;
            requiredFieldValidator2.Enabled = false;
            requiredFieldValidator5.Enabled = true;
            requiredFieldValidator6.Enabled = true;
            requiredFieldValidator7.Enabled = true;
            requiredFieldValidator8.Enabled = true;

            if (!vldFrmProveedorCrear.Validate())
                return;

            Direccion unaDir = new Direccion();
            unaDir.Calle = txtCalle.Text;
            unaDir.NumeroCalle = txtNroCalle.Text;
            unaDir.Piso = txtPiso.Text;
            unaDir.Localidad = txtLocalidad.Text;
            unaDir.unaProvincia = cboProvincia.SelectedItem as Provincia;

            if (!DirAgregar.Contains(unaDir))
                DirAgregar.Add(unaDir);

            GrillaDirecciones.DataSource = null;
            GrillaDirecciones.DataSource = DirAgregar;
            FormatearGrillaDirecciones();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<Categoria> CatQuitarMod = new List<Categoria>();
            List<Categoria> CatAgregarMod = new List<Categoria>();
            List<Telefono> TelQuitarMod = new List<Telefono>();
            List<Telefono> TelAgregarMod = new List<Telefono>();
            List<Direccion> DirQuitarMod = new List<Direccion>();
            List<Direccion> DirAgregarMod = new List<Direccion>();

            requiredFieldValidator1.Enabled = true;
            requiredFieldValidator9.Enabled = true;
            requiredFieldValidator2.Enabled = false;
            requiredFieldValidator3.Enabled = false;
            requiredFieldValidator4.Enabled = false;
            requiredFieldValidator5.Enabled = false;
            requiredFieldValidator6.Enabled = false;
            requiredFieldValidator7.Enabled = false;
            requiredFieldValidator8.Enabled = false;

            if (!vldFrmProveedorCrear.Validate())
                return;

            try
            {
                //Verificar que no existe un proveedor con el nombre ingresado en la modificacion
                Proveedor ProvAux = null;
                if (unProvBuscar.AliasProv != txtNombreEmpresa.Text)
                    ProvAux = ManagerProveedor.ProveedorBuscar(txtNombreEmpresa.Text);
                if (ProvAux != null && ProvAux.IdProveedor > 0)
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El proveedor ingresado ya existe").Texto);
                    return;
                }

                unProvBuscar.AliasProv = txtNombreEmpresa.Text;
                unProvBuscar.ContactoProv = txtContacto.Text;
                unProvBuscar.MailContactoProv = txtMailContacto.Text;

                //Categorias Modif
                CatQuitarMod = CategoriasAgregarBKP.Where(d => !CategoriasAgregar.Any(a => a.IdCategoria == d.IdCategoria)).ToList();
                CatAgregarMod = CategoriasAgregar.Where(d => !CategoriasAgregarBKP.Any(a => a.IdCategoria == d.IdCategoria)).ToList();

                //Telefonos Modif
                TelQuitarMod = TelsAgregarBKP.Where(d => !TelsAgregar.Any(a => a.IdTelefono == d.IdTelefono)).ToList();
                TelAgregarMod = TelsAgregar.Where(d => !TelsAgregarBKP.Any(a => a.IdTelefono == d.IdTelefono)).ToList();

                //Direcciones Modif
                DirQuitarMod = DirAgregarBKP.Where(d => !DirAgregar.Any(a => a.IdDireccion == d.IdDireccion)).ToList();
                DirAgregarMod = DirAgregar.Where(d => !DirAgregarBKP.Any(a => a.IdDireccion == d.IdDireccion)).ToList();

                ManagerProveedor.ProveedorModificar(unProvBuscar, CatQuitarMod, CatAgregarMod, TelQuitarMod, TelAgregarMod, DirQuitarMod, DirAgregarMod);
                CategoriasAgregar = ManagerProveedor.ProveedorTraerCategorias(unProvBuscar.IdProveedor);
                CategoriasAgregarBKP = CategoriasAgregar.ToList();
                TelsAgregar = ManagerProveedor.ProveedorTraerTelefonos(unProvBuscar.IdProveedor);
                TelsAgregarBKP = TelsAgregar.ToList();
                DirAgregar = ManagerProveedor.ProveedorTraerDirecciones(unProvBuscar.IdProveedor);
                DirAgregarBKP = DirAgregar.ToList();
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar al proveedor, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }

        }

        private void GrillaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaProductos.Columns["btnDinBorrar"].Index)
                {
                    CategoriasAgregar.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    GrillaProductos.DataSource = null;
                    GrillaProductos.DataSource = CategoriasAgregar;
                    FormatearGrillaCategorias();
                }
            }
        }


        private void FormatearGrillaCategorias()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaProductos.Columns.Contains("btnDinBorrar"))
                GrillaProductos.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaProductos.Columns.Add(deleteButton);

            //Formato Grilla Categoria
            GrillaProductos.Columns["IdCategoria"].Visible = false;
            GrillaProductos.Columns["Activo"].Visible = false;
            GrillaProductos.Columns["DescripCategoria"].HeaderText = "Nombre";
            GrillaProductos.Columns["unTipoBien"].HeaderText = "Tipo";
        }


        private void GrillaTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaTelefonos.Columns["btnDinBorrar"].Index)
                {
                    TelsAgregar.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    GrillaTelefonos.DataSource = null;
                    GrillaTelefonos.DataSource = TelsAgregar;
                    FormatearGrillaTelefonos();
                }
            }
        }


        private void FormatearGrillaTelefonos()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaTelefonos.Columns.Contains("btnDinBorrar"))
                GrillaTelefonos.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaTelefonos.Columns.Add(deleteButton);

            //Formato Grilla Telefono
            GrillaTelefonos.Columns["IdTelefono"].Visible = false;
        }


        private void GrillaDirecciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaDirecciones.Columns["btnDinBorrar"].Index)
                {
                    DirAgregar.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    GrillaDirecciones.DataSource = null;
                    GrillaDirecciones.DataSource = DirAgregar;
                    FormatearGrillaDirecciones();
                }
            }
        }


        private void FormatearGrillaDirecciones()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaDirecciones.Columns.Contains("btnDinBorrar"))
                GrillaDirecciones.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaDirecciones.Columns.Add(deleteButton);

            //Formato Grilla Direccion
            GrillaDirecciones.Columns["IdDireccion"].Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (unProvBuscar != null && !string.IsNullOrWhiteSpace(txtNombreEmpresa.Text) && unProvBuscar.IdProveedor > 0)
                {
                    DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja al Proveedor: ").Texto + unProvBuscar.AliasProv + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        ManagerProveedor.ProveedorEliminar(unProvBuscar);
                        lblBaja.Visible = true;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnReactivar.Enabled = true;
                        btnEliminar.Enabled = false;
                        btnModificar.Enabled = false;
                        btnCrearProveedor.Enabled = false;
                        btnAgregarProd.Enabled = false;
                        btnTelefono.Enabled = false;
                        btnDireccion.Enabled = false;
                        txtNombreEmpresa.Enabled = false;
                        txtContacto.Enabled = false;
                        txtMailContacto.Enabled = false;
                        GrillaProductos.Enabled = false;
                        GrillaTelefonos.Enabled = false;
                        GrillaDirecciones.Enabled = false;
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Proveedor: ").Texto + unProvBuscar.AliasProv + BLLServicioIdioma.MostrarMensaje(" dado de baja correctamente").Texto);
                    }
                }
                else
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Para dar de baja un proveedor primero debe buscarlo").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - btnEliminar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar eliminar al proveedor, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (unProvBuscar != null && !string.IsNullOrWhiteSpace(txtNombreEmpresa.Text) && unProvBuscar.IdProveedor > 0)
                {
                    ManagerProveedor.ProveedorReactivar(unProvBuscar.IdProveedor);
                    lblBaja.Visible = false;
                    btnReactivar.Enabled = false;
                    if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                    btnEliminar.Enabled = true;
                    if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModificar.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                    btnModificar.Enabled = true;
                    btnCrearProveedor.Enabled = false;
                    btnAgregarProd.Enabled = true;
                    btnTelefono.Enabled = true;
                    btnDireccion.Enabled = true;
                    txtNombreEmpresa.Enabled = true;
                    txtContacto.Enabled = true;
                    txtMailContacto.Enabled = true;
                    GrillaProductos.Enabled = true;
                    GrillaTelefonos.Enabled = true;
                    GrillaDirecciones.Enabled = true;
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Proveedor: ").Texto + unProvBuscar.AliasProv + BLLServicioIdioma.MostrarMensaje(" reactivado correctamente").Texto);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - btnReactivar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar reactivar al proveedor: ").Texto + unProvBuscar.AliasProv + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            vldFrmProveedorCrear.ClearFailedValidations();
            lblBaja.Visible = false;
            btnReactivar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnCrearProveedor.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
            btnCrearProveedor.Enabled = true;
            btnAgregarProd.Enabled = true;
            btnTelefono.Enabled = true;
            btnDireccion.Enabled = true;
            txtNombreEmpresa.Enabled = true;
            txtContacto.Enabled = true;
            txtMailContacto.Enabled = true;
            GrillaProductos.Enabled = true;
            GrillaTelefonos.Enabled = true;
            GrillaDirecciones.Enabled = true;
            txtCalle.Clear();
            txtCodArea.Clear();
            txtContacto.Clear();
            txtLocalidad.Clear();
            txtMailContacto.Clear();
            txtNombreEmpresa.Clear();
            txtNroCalle.Clear();
            txtNroTelefono.Clear();
            txtPiso.Clear();
            txtProducto.Clear();
            txtProveedorBuscar.Clear();
            cboProducto.Refresh();
            cboProveedor.Refresh();
            cboProvincia.Refresh();
            cboTipo.Refresh();
            GrillaProductos.DataSource = null;
            GrillaProductos.Columns.Clear();
            GrillaTelefonos.DataSource = null;
            GrillaTelefonos.Columns.Clear();
            GrillaDirecciones.DataSource = null;
            GrillaDirecciones.Columns.Clear();
            unProvBuscar = null;
            CategoriasAgregar.Clear();
            TelsAgregar.Clear();
            DirAgregar.Clear();
            CategoriasAgregarBKP.Clear();
            TelsAgregarBKP.Clear();
            DirAgregarBKP.Clear();
        }





    }
}