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

namespace ARTEC.GUI
{
    public partial class frmProveedorCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        Proveedor nuevoProveedor = new Proveedor();
        List<Categoria> unasCategorias = new List<Categoria>();
        Categoria unaCat;
        Proveedor unProvBuscar;
        List<Categoria> CategoriasAsociadas = new List<Categoria>();
        BLLProveedor ManagerProveedor = new BLLProveedor();
        List<Proveedor> unosProveedores = new List<Proveedor>();

        public frmProveedorCrear()
        {
            InitializeComponent();
        }

        private void ProveedorCrear_Load(object sender, EventArgs e)
        {
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategorias = ManagerCategoria.CategoriaTraerTodosActivos();
            unosProveedores = ManagerProveedor.ProveedorTraerTodos();
            BLLServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            
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
            if (unaCat != null)
            {
                CategoriasAsociadas.Add(unaCat);
            }

            GrillaProductos.DataSource = null;
            GrillaProductos.DataSource = CategoriasAsociadas;
            GrillaProductos.Columns[0].Visible = false;
            GrillaProductos.Columns[1].HeaderText = "Productos";
            
        }

        private void btnCrearProveedor_Click(object sender, EventArgs e)
        {
            
            nuevoProveedor.AliasProv = txtNombreEmpresa.Text;
            nuevoProveedor.ContactoProv = txtContacto.Text;
            //SEGUIR
        }

        private void btnTelefono_Click(object sender, EventArgs e)
        {
            Telefono unTel = new Telefono();
            
            //nuevoProveedor.unosTelefonos.Add
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
            if (!string.IsNullOrWhiteSpace(txtProveedorBuscar.Text))
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
                    ComboBox cbo3 = (ComboBox)sender;
                    unProvBuscar = new Proveedor();
                    unProvBuscar = (Proveedor)cbo3.SelectedItem;
                    this.txtProveedorBuscar.TextChanged -= new System.EventHandler(this.txtProveedorBuscar_TextChanged);
                    txtProveedorBuscar.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    this.txtProveedorBuscar.TextChanged += new System.EventHandler(this.txtProveedorBuscar_TextChanged);
                    txtProveedorBuscar.SelectionStart = txtProveedorBuscar.Text.Length + 1;
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate(); //AGREGARLA
                }
            }
        }


    }
}