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
            //Traer Proveedores
            unosProveedores = ManagerProveedor.ProveedorTraerTodos();
            cboProveedor.DataSource = null;
            cboProveedor.DataSource = unosProveedores;
            cboProveedor.DisplayMember = "RazonSocialProv";
            cboProveedor.ValueMember = "IdProveedor";

            //Traer TipoBien
            unosTiposBien = ManagerTipoBien.TraerTodos();
            cboTipo.DataSource = null;
            cboTipo.DataSource = unosTiposBien;
            cboTipo.DisplayMember = "DescripTipoBien";
            cboTipo.ValueMember = "IdTipoBien";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            vldfrmCategoriaGestion.ClearFailedValidations();

            try
            {
                unaCategoria = null;
                unaCategoria = ManagerCategoria.CategoriaBuscar(txtCategoriaBuscar.Text);
                if (!string.IsNullOrEmpty(txtCategoriaBuscar.Text) && !string.IsNullOrWhiteSpace(txtCategoriaBuscar.Text) && unaCategoria != null && unaCategoria.IdCategoria > 0)
                {
                    txtCategoria.Text = unaCategoria.DescripCategoria;
                    cboTipo.SelectedValue = unaCategoria.unTipoBien.IdTipoBien;
                    txtCategoriaBuscar.Clear();

                    //VER: Agregar este codigo al programar Eliminar Categoria
                    //if (unaCategoria.Activo == 0)
                    //{

                    //}
                    //else
                    //{

                    //}

                    ProvsAgregar.Clear();
                    ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
                    ProvsAgregarBKP = ProvsAgregar.ToList();

                    GrillaProveedores.DataSource = null;
                    GrillaProveedores.DataSource = ProvsAgregar;
                    btnCrearCategoria.Enabled = false;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("La categoría ingresada no existe");
                    txtCategoria.Clear();
                    cboTipo.Refresh();
                    cboProveedor.Refresh();
                    GrillaProveedores.DataSource = null;
                    unaCategoria = null;
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
            btnCrearCategoria.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
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

            //Verificar que no existe una categoria con el nombre ingresado en la modificacion
            Categoria CatAux = ManagerCategoria.CategoriaBuscar(txtCategoria.Text);
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




        
    }
}