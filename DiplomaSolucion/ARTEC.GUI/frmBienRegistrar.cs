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
using System.IO;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;


namespace ARTEC.GUI
{
    public partial class frmBienRegistrar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Adquisicion unaAdquisicion = new Adquisicion();
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        List<Categoria> unasCategoriasHard;
        List<Categoria> unasCategoriasSoft;
        List<Categoria> unasCategorias = new List<Categoria>();
        Marca unaMarca;
        List<HLPBienInventario> unosBieneshlp = new List<HLPBienInventario>();
        List<Bien> nuevosBienes = new List<Bien>();
        List<Inventario> nuevosInventarios = new List<Inventario>();
        ModeloVersion unModelo;
        Bien unBien;
        Inventario unInven;// = new Inventario();
        List<SolicDetalle> unosDetallesBienes = new List<SolicDetalle>();
        BLLTipoBien ManagerTipoBien = new BLLTipoBien();
        SolicDetalle unDetSolic;


        public frmBienRegistrar()
        {
            InitializeComponent();
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            BLLAdquisicion ManagerAdquisicion = new BLLAdquisicion();
            unaAdquisicion.NroFactura = txtNroFactura.Text;
            unaAdquisicion.FechaCompra = DateTime.Parse(txtFechaCompra.Text);
            //unaAdquisicion.ProveedorAdquisicion = (Proveedor)cboProveedor.SelectedItem;
            unaAdquisicion.FechaAdq = DateTime.Now;
            unaAdquisicion.IdTipoAdquisicion = 1;///COMPLETAR
            //unaAdquisicion.InventariosAsociados = nuevosInventarios;
            if (unaAdquisicion.BienesInventarioAsociados != null)
            {
                //SEGUIR CON LAS DAL INVENTARIO Y STORES
                ManagerAdquisicion.AdquisicionCrear(unaAdquisicion);
            }
        }



        private void btnContinuar_Click(object sender, EventArgs e)
        {
            pnlAdquisicion.Visible = false;
            pnlBienes.Visible = true;
            this.stepItem1.BackColors = new System.Drawing.Color[] { System.Drawing.Color.Transparent };
            this.stepItem2.BackColors = new System.Drawing.Color[] { System.Drawing.Color.MediumAquamarine };
            BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
            
            unosDetallesBienes = ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(Int32.Parse(txtNroPartida.Text));
            //RETORNA 0;0 en vez de 1;2 como debería, fijarme

            List<HLPDetallesAdquisicion> LisAUXDetalles = unosDetallesBienes.Select(x => new HLPDetallesAdquisicion() { DescripCategoria = x.unaCategoria.DescripCategoria, Cantidad = x.Cantidad, IdCategoria = x.unaCategoria.IdCategoria}).ToList();
            
            List<HLPDetallesAdquisicion> LisAUXCant = new List<HLPDetallesAdquisicion>();
            LisAUXCant = ManagerPartidaDetalle.InventarioAdquiridoCantPorPartDetalle(Int32.Parse(txtNroPartida.Text));

            //FIJARME Q NO PINCHE CUANDO NO HAY NINGUNO COMPRADO
            for (int i = 0; i < LisAUXCant.Count() ; i++)
            {
                LisAUXDetalles[i].Comprado = LisAUXCant[i].Comprado;
            }
            
            


            //var listaAUX = unosDetallesBienes.Select(x=>new {x.unaCategoria.DescripCategoria, x.Cantidad, x.unaCategoria.IdCategoria}).ToList();   

            GrillaDetallesBienes.DataSource = null;
            GrillaDetallesBienes.DataSource = LisAUXDetalles;

            if (LisAUXDetalles != null)
            {
                
                //TipoBien unTipoBien = ManagerTipoBien.TipoBienTraerTipoBienPorIdCategoria(listaAUX[0].IdCategoria);
                //cboTipoBien.SelectedItem = unTipoBien;
                int DetalleSeleccionado = 1;
                unDetSolic = new SolicDetalle();
                unDetSolic = unosDetallesBienes.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);

                TipoBien unTipoBien = ManagerTipoBien.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
                cboTipoBien.SelectedValue = unTipoBien.IdTipoBien;

                if ((int)cboTipoBien.SelectedValue == (int)Bien.elTipoBien.Hardware)
                {
                    unBien = new Hardware();
                    unInven = new XInventarioHard();
                }
                else//Software
                {
                    unBien = new Software();
                    unInven = new XInventarioSoft();
                }

                //txtBienCategoria.Text = listaAUX[0].DescripCategoria;

                if ((int)cboTipoBien.SelectedValue == 1)//Hardware
                {
                    pnlHardware.Visible = true;
                    pnlSoftware.Visible = false;
                }
                if ((int)cboTipoBien.SelectedValue == 2)//Software
                {
                    pnlSoftware.Visible = true;
                    pnlHardware.Visible = false;
                }


                txtBienCategoria.Text = unDetSolic.unaCategoria.DescripCategoria;

                BLLMarca ManagerMarca = new BLLMarca();
                List<Marca> unasMarcas = new List<Marca>();
                unasMarcas = ManagerMarca.MarcaTraerPorIdCategoria(unDetSolic.unaCategoria.IdCategoria, (int)cboTipoBien.SelectedValue);
                cboMarca.DataSource = null;
                cboMarca.DataSource = unasMarcas;
                cboMarca.DisplayMember = "DescripMarca";
                cboMarca.ValueMember = "IdMarca";


            }
        }



        private void frmBienRegistrar_Load(object sender, EventArgs e)
        {
            ///Para poder seleccionar Hard o Soft
            BLLTipoBien ManagerTipoBien = new BLLTipoBien();
            unosTipoBien = ManagerTipoBien.TraerTodos();
            cboTipoBien.DataSource = null;
            cboTipoBien.DataSource = unosTipoBien;
            cboTipoBien.DisplayMember = "DescripTipoBien";
            cboTipoBien.ValueMember = "IdTipoBien";

            //Traigo categorias para dps filtrar por hard o soft
            //CREO QUE QUITAR
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategoriasHard = new List<Categoria>();
            unasCategoriasHard = ManagerCategoria.CategoriaTraerTodosHard();
            unasCategoriasSoft = new List<Categoria>();
            unasCategoriasSoft = ManagerCategoria.CategoriaTraerTodosSoft();
            unasCategorias = ((int)cboTipoBien.SelectedValue == 1) ? unasCategoriasHard.ToList() : unasCategoriasSoft.ToList();

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
            cboEstado.DataSource = null;
            unosEstadoInventario = ManagerEstadoInventario.EstadoInvTraerTodos();
            cboEstado.DataSource = unosEstadoInventario;
            cboEstado.DisplayMember = "DescripEstadoInv";
            cboEstado.ValueMember = "IdEstadoInventario";
        }

   

        private void cboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex > -1)
            {
                ComboBox cbo = (ComboBox)sender;
                unaMarca = new Marca();
                unaMarca = (Marca)cbo.SelectedItem;

                BLLModelo ManagerModelo = new BLLModelo();
                List<ModeloVersion> unosModelos = new List<ModeloVersion>();
                unosModelos = ManagerModelo.ModeloTraerPorMarcaCategoria(unDetSolic.unaCategoria.IdCategoria, (int)cboTipoBien.SelectedValue, unaMarca.IdMarca);
                cboModelo.DataSource = null;
                cboModelo.DataSource = unosModelos;
                cboModelo.DisplayMember = "DescripModeloVersion";
                cboModelo.ValueMember = "IdModeloVersion";


                //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
                //ValidDep2.Validate();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {



            //Creo ManagerBien con Factory
            //IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien((int)cboTipoBien.SelectedValue);
            //ManagerBien.BienCrear()
            //IBien unBien = FactoryBien.CrearBien((int)cboTipoBien.SelectedValue);
            //Inventario unInven;// = new Inventario();
            HLPBienInventario unBienhlp = new HLPBienInventario();
            unBienhlp.DescripBien = txtBienCategoria.Text;
            unBien.unaCategoria = unDetSolic.unaCategoria;
            unBienhlp.DescripEstadoInv = cboEstado.Text;
            unInven.unEstado = (EstadoInventario)cboEstado.SelectedItem;
            unBienhlp.DescripMarca = cboMarca.Text;
            unBien.unaMarca = (Marca)cboMarca.SelectedItem;
            unBienhlp.DescripModeloVersion = cboModelo.Text;
            unBien.unModelo = (ModeloVersion)cboModelo.SelectedItem;
            unBienhlp.SerieKey = txtSerieKey.Text;
            unInven.SerieKey = txtSerieKey.Text;
            unBienhlp.NombreDeposito = cboDeposito.Text;
            unInven.unDeposito = (Deposito)cboDeposito.SelectedItem;
            //unBien.unosInventarios.Add(unInven);
            //falta homologado y tipolicencia

            unBien.unInventarioAlta = unInven;

            unaAdquisicion.BienesInventarioAsociados.Add(unBien);

            GrillaBienes.DataSource = null;
            unosBieneshlp.Add(unBienhlp);
            GrillaBienes.DataSource = unosBieneshlp;


        }



        private void cboModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboModelo.SelectedIndex > -1)
            {
                ComboBox cbo = (ComboBox)sender;
                unModelo = new ModeloVersion();
                unModelo = (ModeloVersion)cbo.SelectedItem;

                //Creo ManagerBien con Factory
                IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien((int)cboTipoBien.SelectedValue);
                
                //if ((int)cboTipoBien.SelectedValue == (int)Bien.elTipoBien.Hardware)
                //{
                //    unBien = new Hardware();
                //    unInven = new XInventarioHard();
                //}
                //else//Software
                //{
                //    unBien = new Software();
                //    unInven = new XInventarioSoft();
                //}

                unBien.unaCategoria = unDetSolic.unaCategoria;
                unBien.unaMarca = unaMarca;
                unBien.unModelo = unModelo;//(ModeloVersion)cboModelo.SelectedItem;

                unBien.IdBien = ManagerBien.BienTraerIdPorDescripMarcaModelo(unBien);


                //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
                //ValidDep2.Validate();

            }
        }


        private void GrillaDetallesBienes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            cboMarca.DataSource = null;
            cboModelo.DataSource = null;

            //Para obtener el detalle en donde se hizo click
            int DetalleSeleccionado = e.RowIndex + 1;
            unDetSolic = new SolicDetalle();

            unDetSolic = unosDetallesBienes.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);

            TipoBien unTipoBien = ManagerTipoBien.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
            cboTipoBien.SelectedValue = unTipoBien.IdTipoBien;


            if ((int)cboTipoBien.SelectedValue == (int)Bien.elTipoBien.Hardware)
            {
                unBien = new Hardware();
                unInven = new XInventarioHard();
            }
            else//Software
            {
                unBien = new Software();
                unInven = new XInventarioSoft();
            }


            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                pnlHardware.Visible = true;
                pnlSoftware.Visible = false;
                unasCategorias = unasCategoriasHard;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                pnlSoftware.Visible = true;
                pnlHardware.Visible = false;
                unasCategorias = unasCategoriasSoft;
            }

            
            txtBienCategoria.Text = unDetSolic.unaCategoria.DescripCategoria;

            BLLMarca ManagerMarca = new BLLMarca();
            List<Marca> unasMarcas = new List<Marca>();
            unasMarcas = ManagerMarca.MarcaTraerPorIdCategoria(unDetSolic.unaCategoria.IdCategoria, (int)cboTipoBien.SelectedValue);
            cboMarca.DataSource = null;
            cboMarca.DataSource = unasMarcas;
            cboMarca.DisplayMember = "DescripMarca";
            cboMarca.ValueMember = "IdMarca";


          
        }







    }
}