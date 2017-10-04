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

namespace ARTEC.GUI
{
    public partial class ProveedorCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        Proveedor nuevoProveedor = new Proveedor();
        List<Categoria> unasCategorias = new List<Categoria>();
        Categoria unaCat;
        List<Categoria> CategoriasAsociadas = new List<Categoria>();

        public ProveedorCrear()
        {
            InitializeComponent();
        }

        private void ProveedorCrear_Load(object sender, EventArgs e)
        {
            ServicioIdioma.Traducir(this.FindForm(), ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
            
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategorias = ManagerCategoria.CategoriaTraerTodos();
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
            
            nuevoProveedor.RazonSocialProv = txtRazon.Text;
            nuevoProveedor.AliasProv = txtAlias.Text;
            nuevoProveedor.ContactoProv = txtDireccion.Text;
            //SEGUIR
        }

        private void btnTelefono_Click(object sender, EventArgs e)
        {
            Telefono unTel = new Telefono();
            
            //nuevoProveedor.unosTelefonos.Add
        }



    }
}