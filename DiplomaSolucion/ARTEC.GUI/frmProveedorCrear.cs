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
        BLLProveedor ManagerProveedor = new BLLProveedor();
        List<Proveedor> unosProveedores = new List<Proveedor>();
        List<Telefono> TelsAgregar = new List<Telefono>();
        List<Direccion> DirAgregar = new List<Direccion>();
        List<TipoTelefono> unosTipoTelefonos = new List<TipoTelefono>();
        List<Provincia> unasProvincias = new List<Provincia>();

        public frmProveedorCrear()
        {
            InitializeComponent();
        }

        private void ProveedorCrear_Load(object sender, EventArgs e)
        {

            try
            {
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
                MessageBox.Show("Ocurrio un error al cargar la pantalla de proveedores, por favor informe del error Nro " + IdError + " del Log de Eventos");
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
                    //validBien.Validate(); //AGREGARLA
                }
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            requiredFieldValidator3.Enabled = false;
            requiredFieldValidator4.Enabled = false;
            requiredFieldValidator1.Enabled = false;
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
            
        }

   

        private void btnTelefono_Click(object sender, EventArgs e)
        {
            requiredFieldValidator3.Enabled = true;
            requiredFieldValidator4.Enabled = true;
            requiredFieldValidator1.Enabled = false;
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
                        //nuevoProveedor = unProvBuscar;
                        unProvBuscar.unasCategorias = ManagerProveedor.ProveedorTraerCategorias(unProvBuscar.IdProveedor);
                        unProvBuscar.unosTelefonos = ManagerProveedor.ProveedorTraerTelefonos(unProvBuscar.IdProveedor);
                        unProvBuscar.unasDirecciones = ManagerProveedor.ProveedorTraerDirecciones(unProvBuscar.IdProveedor);

                        txtNombreEmpresa.Text = unProvBuscar.AliasProv;
                        txtContacto.Text = unProvBuscar.ContactoProv;
                        txtMailContacto.Text = unProvBuscar.MailContactoProv;
                        GrillaProductos.DataSource = null;
                        GrillaProductos.DataSource = unProvBuscar.unasCategorias;
                        GrillaTelefonos.DataSource = null;
                        GrillaTelefonos.DataSource = unProvBuscar.unosTelefonos;
                        GrillaDirecciones.DataSource = null;
                        GrillaDirecciones.DataSource = unProvBuscar.unasDirecciones;

                        //if (unaCategoria.Activo == 0)
                        //{
                        //    lblBaja.Visible = true;
                        //    btnReactivar.Enabled = true;
                        //    btnModificar.Enabled = false;
                        //    btnEliminar.Enabled = false;
                        //    btnAgregar.Enabled = false;
                        //    txtCategoria.Enabled = false;
                        //    cboProveedor.Enabled = false;
                        //    cboTipo.Enabled = false;
                        //    GrillaProveedores.Enabled = false;
                        //}
                        //else
                        //{
                        //    lblBaja.Visible = false;
                        //    btnReactivar.Enabled = false;
                        //    btnModificar.Enabled = true;
                        //    btnEliminar.Enabled = true;
                        //    btnAgregar.Enabled = true;
                        //    txtCategoria.Enabled = true;
                        //    cboProveedor.Enabled = true;
                        //    cboTipo.Enabled = true;
                        //    GrillaProveedores.Enabled = true;
                        //}

                        //ProvsAgregar.Clear();
                        //ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
                        //ProvsAgregarBKP = ProvsAgregar.ToList();
                    }
                    catch (Exception es)
                    {
                        string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - cboProveedor_SelectionChangeCommitted");
                        MessageBox.Show("Ocurrio un error al buscar la categoría, por favor informe del error Nro " + IdError + " del Log de Eventos");
                    }

                }
            }
        }


        private void btnCrearProveedor_Click(object sender, EventArgs e)
        {
            requiredFieldValidator1.Enabled = true;
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
                    MessageBox.Show("El Proveedor ingresado ya existe");
                    return;
                }

                nuevoProveedor.AliasProv = txtNombreEmpresa.Text;
                nuevoProveedor.ContactoProv = txtContacto.Text;
                nuevoProveedor.MailContactoProv = txtMailContacto.Text;
                nuevoProveedor.unasCategorias = CategoriasAgregar;
                nuevoProveedor.unosTelefonos = TelsAgregar;
                nuevoProveedor.unasDirecciones = DirAgregar;

                if(ManagerProveedor.ProveedorCrear(nuevoProveedor))
                    MessageBox.Show("Proveedor creado correctamente");

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmProveedorCrear - btnCrearProveedor_Click");
                MessageBox.Show("Ocurrio un error al intentar crear un proveedor, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }

        private void btnDireccion_Click(object sender, EventArgs e)
        {
            requiredFieldValidator3.Enabled = false;
            requiredFieldValidator4.Enabled = false;
            requiredFieldValidator1.Enabled = false;
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
        }


    }
}