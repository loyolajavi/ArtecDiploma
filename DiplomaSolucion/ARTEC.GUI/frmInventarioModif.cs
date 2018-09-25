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
using ARTEC.ENTIDADES.Helpers;
using System.Linq;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using System.Text.RegularExpressions;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmInventarioModif : DevComponents.DotNetBar.Metro.MetroForm
    {
        Inventario unInventarioModif;
        BLLTipoBien ManagerTipoBien = new BLLTipoBien();
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        BLLMarca ManagerMarca = new BLLMarca();
        List<Marca> unasMarcasAsoc = new List<Marca>();
        BLLModelo ManagerModelo = new BLLModelo();
        List<ModeloVersion> unosModelosAsoc = new List<ModeloVersion>();
        BLLCategoria ManagerCategoria = new BLLCategoria();
        int ResIdCat;
        BLLInventario ManagerInventario = new BLLInventario();
        Marca unaMarca;
        int IdBienAsociado;

        public frmInventarioModif()
        {
            InitializeComponent();
        }

        public frmInventarioModif(Inventario unInvSelec)
        {
            InitializeComponent();
            unInventarioModif = unInvSelec;
        }

        private void frmInventarioModif_Load(object sender, EventArgs e)
        {

            try
            {
                //Traer TiposBien
                unosTipoBien = ManagerTipoBien.TraerTodos();
                unosTipoBien.Insert(0, new TipoBien { IdTipoBien = 0, DescripTipoBien = "<Seleccionar>" });
                cboTipoBien.DataSource = null;
                cboTipoBien.DataSource = unosTipoBien;
                cboTipoBien.DisplayMember = "DescripTipoBien";
                cboTipoBien.ValueMember = "IdTipoBien";

                //Traer Marcas asociadas al bien
                ResIdCat = ManagerCategoria.CategoriaTraerIdCatPorIdBien(unInventarioModif.IdBienEspecif);
                unasMarcasAsoc = ManagerMarca.MarcaTraerPorIdCategoria(ResIdCat);
                unasMarcasAsoc.Insert(0, new Marca { IdMarca = 0, DescripMarca = "<Seleccionar>" });
                cboMarca.DataSource = null;
                cboMarca.DataSource = unasMarcasAsoc;
                cboMarca.DisplayMember = "DescripMarca";
                cboMarca.ValueMember = "IdMarca";


                txtBien.Text = unInventarioModif.deBien.DescripBien;
                cboTipoBien.SelectedValue = unInventarioModif.unTipoBien;
                cboMarca.SelectedValue = unInventarioModif.deBien.unaMarca.IdMarca;

                //Traer Modelos asociados a la Marca seleccionada
                unosModelosAsoc = ManagerModelo.ModeloTraerPorMarcaCategoria(ResIdCat, (int)cboMarca.SelectedValue);
                unosModelosAsoc.Insert(0, new ModeloVersion { IdModeloVersion = 0, DescripModeloVersion = "<Seleccionar>" });
                cboModelo.DataSource = null;
                cboModelo.DataSource = unosModelosAsoc;
                cboModelo.DisplayMember = "DescripModeloVersion";
                cboModelo.ValueMember = "IdModeloVersion";
                cboModelo.SelectedValue = unInventarioModif.deBien.unModelo.IdModeloVersion;

                //Obtener IdBien asociado a Marca y Modelo y Categoria
                IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien(unInventarioModif.unTipoBien);
                IdBienAsociado = ManagerBien.BienTraerIdPorDescripMarcaModelo(ResIdCat, unInventarioModif.deBien.unaMarca.IdMarca, unInventarioModif.deBien.unModelo.IdModeloVersion);
                
                txtSerieKey.Text = unInventarioModif.SerieKey;
                txtCosto.Text = unInventarioModif.Costo.ToString();


                //Traer depositos
                BLLDeposito ManagerDeposito = new BLLDeposito();
                List<Deposito> unosDepositos = new List<Deposito>();
                cboDeposito.DataSource = null;
                unosDepositos = ManagerDeposito.DepositoTraerTodos();
                cboDeposito.DataSource = unosDepositos;
                cboDeposito.DisplayMember = "NombreDeposito";
                cboDeposito.ValueMember = "IdDeposito";

                //Traer EstadosInventario
                BLLEstadoInventario ManagerEstadoInventario = new BLLEstadoInventario();
                List<EstadoInventario> unosEstadoInventario = new List<EstadoInventario>();
                cboEstadoInv.DataSource = null;
                unosEstadoInventario = ManagerEstadoInventario.EstadoInvTraerTodos();
                cboEstadoInv.DataSource = unosEstadoInventario;
                cboEstadoInv.DisplayMember = "DescripEstadoInv";
                cboEstadoInv.ValueMember = "IdEstadoInventario";


                //cboDeposito.SelectedValue = unInventarioModif.unDeposito.IdDeposito;
                //cboEstadoInv.SelectedValue = unInventarioModif.unEstado.IdEstadoInventario;

            }
            catch (Exception es)
            {
                throw;
            }
            


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!vldFrmInventarioModif.Validate())
                return;

            try
            {
                Inventario unInvModif;
                if ((int)cboTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Hard)
                {
                    unInvModif = new XInventarioHard();
                    unInvModif.unTipoBien = (int)TipoBien.EnumTipoBien.Hard;
                }
                else
                {
                    unInvModif = new XInventarioSoft();
                    unInvModif.unTipoBien = (int)TipoBien.EnumTipoBien.Soft;
                }

                unInvModif = unInventarioModif;

                unInvModif.deBien.unaMarca = cboMarca.SelectedItem as Marca;
                unInvModif.deBien.unModelo = cboModelo.SelectedItem as ModeloVersion;
                unInvModif.SerieKey = txtSerieKey.Text;
                unInvModif.Costo = decimal.Parse(txtCosto.Text);
                unInvModif.IdBienEspecif = IdBienAsociado;

                if ((int)cboMarca.SelectedValue > 0 & (int)cboModelo.SelectedValue > 0)
                {
                    if (ManagerInventario.InventarioModificar(unInvModif))
                    {
                        MessageBox.Show("Modificación realizada");
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnInventarioModif - btnModificar_Click");
                MessageBox.Show("Ocurrio un error al intentar modificar el inventario, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }

        }

        private void cboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Traer Modelos asociados a la Marca seleccionada
            if (cboMarca.SelectedIndex > 0)
            {
                ComboBox cbo = (ComboBox)sender;
                unaMarca = new Marca();
                unaMarca = (Marca)cbo.SelectedItem;
                unosModelosAsoc = ManagerModelo.ModeloTraerPorMarcaCategoria(ResIdCat, unaMarca.IdMarca);
                unosModelosAsoc.Insert(0, new ModeloVersion { IdModeloVersion = 0, DescripModeloVersion = "<Seleccionar>" });
                cboModelo.DataSource = null;
                cboModelo.DataSource = unosModelosAsoc;
                cboModelo.DisplayMember = "DescripModeloVersion";
                cboModelo.ValueMember = "IdModeloVersion";
            }
        }

        private void cboModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex > 0)
            {
                ComboBox cbo = (ComboBox)sender;
                ModeloVersion unModelo = new ModeloVersion();
                unModelo = (ModeloVersion)cbo.SelectedItem;
                //Obtener IdBien asociado a Marca y Modelo y Categoria
                IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien(unInventarioModif.unTipoBien);
                IdBienAsociado = ManagerBien.BienTraerIdPorDescripMarcaModelo(ResIdCat, (cboMarca.SelectedItem as Marca).IdMarca, unModelo.IdModeloVersion);
            }

        }




    }
}