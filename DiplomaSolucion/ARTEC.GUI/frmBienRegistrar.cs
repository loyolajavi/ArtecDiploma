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
using ARTEC.BLL.Servicios;


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
        ModeloVersion unModelo;
        Bien unBien;
        Bien unBienAUX;
        Inventario unInven;// = new Inventario();
        List<SolicDetalle> unosDetallesBienes = new List<SolicDetalle>();
        BLLTipoBien ManagerTipoBien = new BLLTipoBien();
        SolicDetalle unDetSolic;
        List<Proveedor> unosProveedores = new List<Proveedor>();
        Proveedor ProvSeleccionado;
        BLLProveedor ManagerProveedor = new BLLProveedor();
        BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
        List<HLPDetallesAdquisicion> LisAUXDetalles;
        int DetalleSeleccionado;
        BLLMarca ManagerMarca = new BLLMarca();
        List<Marca> unasMarcas = new List<Marca>();
        BLLModelo ManagerModelo = new BLLModelo();
        List<ModeloVersion> unosModelos = new List<ModeloVersion>();
        int MontoTotalAcum = 0;


        public frmBienRegistrar()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmBienRegistrar = new Dictionary<string, string[]>();
            string[] IdiomafrmBienRegistrar = { "Registrar Bien" };
            dicfrmBienRegistrar.Add("Idioma", IdiomafrmBienRegistrar);
            this.Tag = dicfrmBienRegistrar;

            Dictionary<string, string[]> diclblTipoBien = new Dictionary<string, string[]>();
            string[] IdiomalblTipoBien = { "Tipo" };
            diclblTipoBien.Add("Idioma", IdiomalblTipoBien);
            this.lblTipoBien.Tag = diclblTipoBien;

            Dictionary<string, string[]> diclblBien = new Dictionary<string, string[]>();
            string[] IdiomalblBien = { "Bien" };
            diclblBien.Add("Idioma", IdiomalblBien);
            this.lblBien.Tag = diclblBien;

            Dictionary<string, string[]> diclblMarca = new Dictionary<string, string[]>();
            string[] IdiomalblMarca = { "Marca" };
            diclblMarca.Add("Idioma", IdiomalblMarca);
            this.lblMarca.Tag = diclblMarca;

            Dictionary<string, string[]> diclblCosto = new Dictionary<string, string[]>();
            string[] IdiomalblCosto = { "Costo" };
            diclblCosto.Add("Idioma", IdiomalblCosto);
            this.lblCosto.Tag = diclblCosto;

            Dictionary<string, string[]> diclblModelo = new Dictionary<string, string[]>();
            string[] IdiomalblModelo = { "Modelo" };
            diclblModelo.Add("Idioma", IdiomalblModelo);
            this.lblModelo.Tag = diclblModelo;

            Dictionary<string, string[]> diclblSerieKey = new Dictionary<string, string[]>();
            string[] IdiomalblSerieKey = { "Serie" };
            diclblSerieKey.Add("Idioma", IdiomalblSerieKey);
            this.lblSerieKey.Tag = diclblSerieKey;

            Dictionary<string, string[]> diclblSerie = new Dictionary<string, string[]>();
            string[] IdiomalblSerie = { "Serie" };
            diclblSerie.Add("Idioma", IdiomalblSerie);
            this.lblSerie.Tag = diclblSerie;

            Dictionary<string, string[]> diclblSerial = new Dictionary<string, string[]>();
            string[] IdiomalblSerial = { "Serie" };
            diclblSerial.Add("Idioma", IdiomalblSerial);
            this.lblSerial.Tag = diclblSerial;

            Dictionary<string, string[]> diclabelX3 = new Dictionary<string, string[]>();
            string[] IdiomalabelX3 = { "Estado" };
            diclabelX3.Add("Idioma", IdiomalabelX3);
            this.labelX3.Tag = diclabelX3;

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;

            Dictionary<string, string[]> dicbtnConfirmar = new Dictionary<string, string[]>();
            string[] IdiomabtnConfirmar = { "Confirmar" };
            dicbtnConfirmar.Add("Idioma", IdiomabtnConfirmar);
            this.btnConfirmar.Tag = dicbtnConfirmar;

            Dictionary<string, string[]> diclblPartida = new Dictionary<string, string[]>();
            string[] IdiomalblPartida = { "Partida" };
            diclblPartida.Add("Idioma", IdiomalblPartida);
            this.lblPartida.Tag = diclblPartida;

            Dictionary<string, string[]> diclblFechaCompra = new Dictionary<string, string[]>();
            string[] IdiomalblFechaCompra = { "Fecha Compra" };
            diclblFechaCompra.Add("Idioma", IdiomalblFechaCompra);
            this.lblFechaCompra.Tag = diclblFechaCompra;

            Dictionary<string, string[]> diclblMontoTotal = new Dictionary<string, string[]>();
            string[] IdiomalblMontoTotal = { "Monto Total" };
            diclblMontoTotal.Add("Idioma", IdiomalblMontoTotal);
            this.lblMontoTotal.Tag = diclblMontoTotal;

            Dictionary<string, string[]> diclblProveedor = new Dictionary<string, string[]>();
            string[] IdiomalblProveedor = { "Proveedor" };
            diclblProveedor.Add("Idioma", IdiomalblProveedor);
            this.lblProveedor.Tag = diclblProveedor;

            Dictionary<string, string[]> diclblNroFactura = new Dictionary<string, string[]>();
            string[] IdiomalblNroFactura = { "Factura" };
            diclblNroFactura.Add("Idioma", IdiomalblNroFactura);
            this.lblNroFactura.Tag = diclblNroFactura;

            Dictionary<string, string[]> dicbtnCrearMarca = new Dictionary<string, string[]>();
            string[] IdiomabtnCrearMarca = { "Crear" };
            dicbtnCrearMarca.Add("Idioma", IdiomabtnCrearMarca);
            this.btnCrearMarca.Tag = dicbtnCrearMarca;

            Dictionary<string, string[]> dicbtnCrearModelo = new Dictionary<string, string[]>();
            string[] IdiomabtnCrearModelo = { "Crear" };
            dicbtnCrearModelo.Add("Idioma", IdiomabtnCrearModelo);
            this.btnCrearModelo.Tag = dicbtnCrearModelo;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> diclblDeposito = new Dictionary<string, string[]>();
            string[] IdiomalblDeposito = { "Dep�sito" };
            diclblDeposito.Add("Idioma", IdiomalblDeposito);
            this.lblDeposito.Tag = diclblDeposito;


        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!vldFrmBienRegistrarBtnConfirmar.Validate())
                return;

            try
            {
                if (unaAdquisicion.BienesInventarioAsociados != null && unaAdquisicion.BienesInventarioAsociados.Count() > 0)
                {
                    BLLAdquisicion ManagerAdquisicion = new BLLAdquisicion();
                    unaAdquisicion.NroFactura = txtNroFactura.Text;
                    unaAdquisicion.FechaCompra = DateTime.Parse(txtFechaCompra.Text);
                    unaAdquisicion.MontoCompra = decimal.Parse(txtMontoTotal.Text);
                    unaAdquisicion.ProveedorAdquisicion = ProvSeleccionado;
                    unaAdquisicion.FechaAdq = DateTime.Now;

                    ManagerAdquisicion.AdquisicionCrear(unaAdquisicion);

                    List<HLPDetallesAdquisicion> LisAUXCant = new List<HLPDetallesAdquisicion>();
                    LisAUXCant = ManagerPartidaDetalle.InventarioAdquiridoCantPorPartDetalle(Int32.Parse(txtNroPartida.Text));
                    foreach (var item2 in LisAUXDetalles)
                    {
                        item2.Comprado = (from x in LisAUXCant
                                          where x.IdSolicitudDetalle == item2.IdSolicitudDetalle
                                          select x.Comprado).FirstOrDefault();
                    }
                    GrillaDetallesBienes.DataSource = null;
                    GrillaDetallesBienes.DataSource = LisAUXDetalles;

                    //Coloca en estado Adquirido a un detalle de la solicitud cuando todos los bienes de ese detalle fueron adquiridos
                    foreach (HLPDetallesAdquisicion AuxDet in LisAUXDetalles)
                    {
                        if (AuxDet.Cantidad == AuxDet.Comprado)
                        {
                            BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
                            ManagerSolicDetalle.SolicDetalleUpdateEstado(unosDetallesBienes[0].IdSolicitud, AuxDet.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido, AuxDet.UIDSolicDetalle);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Faltan cargar los bienes adquiridos");
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmBienRegistrar - btnConfirmar_Click");
                MessageBox.Show("Ocurrio un error al intentar registrar la adquisici�n, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }

            
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!vldFrmBienRegistrarBtnBuscar.Validate())
                return;

            txtResBusqueda.Visible = false;
            GrillaDetallesBienes.Visible = true;

            BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
            unosDetallesBienes = ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(Int32.Parse(txtNroPartida.Text), EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar);

            //List<HLPDetallesAdquisicion> LisAUXDetalles 
            //LisAUXDetalles = unosDetallesBienes.Where(y => y.unEstado.IdEstadoSolicDetalle < (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido).Select(x => new HLPDetallesAdquisicion() { DescripCategoria = x.unaCategoria.DescripCategoria, Cantidad = x.Cantidad, IdCategoria = x.unaCategoria.IdCategoria, IdSolicitudDetalle = x.IdSolicitudDetalle }).ToList();
            LisAUXDetalles = unosDetallesBienes.Select(x => new HLPDetallesAdquisicion() { DescripCategoria = x.unaCategoria.DescripCategoria, Cantidad = x.Cantidad, IdCategoria = x.unaCategoria.IdCategoria, IdSolicitudDetalle = x.IdSolicitudDetalle, UIDSolicDetalle = x.UIDSolicDetalle }).ToList();

            if (LisAUXDetalles.Count() > 0)
            {

                List<HLPDetallesAdquisicion> LisAUXCant = new List<HLPDetallesAdquisicion>();
                LisAUXCant = ManagerPartidaDetalle.InventarioAdquiridoCantPorPartDetalle(Int32.Parse(txtNroPartida.Text));

                //for (int i = 0; i < LisAUXCant.Count(); i++)
                //{
                //    LisAUXDetalles[i].Comprado = LisAUXCant[i].Comprado;
                //}

                //foreach (var item2 in LisAUXDetalles)
                //{
                //    item2.Comprado = LisAUXCant[item2.IdSolicitudDetalle - 1].Comprado;
                //}

                foreach (var item2 in LisAUXDetalles)
                {
                    item2.Comprado = (from x in LisAUXCant
                                      where x.IdSolicitudDetalle == item2.IdSolicitudDetalle
                                      select x.Comprado).FirstOrDefault();
                }

                GrillaDetallesBienes.DataSource = null;
                GrillaDetallesBienes.DataSource = LisAUXDetalles;
                FormatearGrillaDetallesBienes();


                unDetSolic = new SolicDetalle();
                unDetSolic = unosDetallesBienes.FirstOrDefault();
                DetalleSeleccionado = unDetSolic.IdSolicitudDetalle;

                TipoBien unTipoBien = ManagerTipoBien.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
                cboTipoBien.SelectedValue = unTipoBien.IdTipoBien;

                if ((int)cboTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Hard)
                {
                    unBien = new Hardware();
                    unInven = new XInventarioHard();
                    unBien.unInventarioAlta = new XInventarioHard();
                }
                else
                {
                    unBien = new Software();
                    unInven = new XInventarioSoft();
                    unBien.unInventarioAlta = new XInventarioSoft();
                }

                if ((int)cboTipoBien.SelectedValue == 1)//Hardware
                {
                    //pnlHardware.Visible = true;
                    //pnlSoftware.Visible = false;
                    lblSerie.Visible = true;
                    lblDeposito.Visible = true;
                    cboDeposito.Visible = true;
                    lblSerieKey.Visible = false;
                    lblSerial.Visible = false;
                    txtSerialMaster.Visible = false;
                    //unasCategorias = unasCategoriasHard;//ESTO VA ACA??
                }
                if ((int)cboTipoBien.SelectedValue == 2)//Software
                {
                    //pnlSoftware.Visible = true;
                    //pnlHardware.Visible = false;
                    lblSerie.Visible = false;
                    lblDeposito.Visible = false;
                    cboDeposito.Visible = false;
                    lblSerieKey.Visible = true;
                    lblSerial.Visible = true;
                    txtSerialMaster.Visible = true;
                    //unasCategorias = unasCategoriasSoft;//ESTO VA ACA??
                }


                txtBienCategoria.Text = unDetSolic.unaCategoria.DescripCategoria;

                //Traer Marcas

                unasMarcas = ManagerMarca.MarcaTraerPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
                cboMarca.DataSource = null;
                cboMarca.DataSource = unasMarcas;
                cboMarca.DisplayMember = "DescripMarca";
                cboMarca.ValueMember = "IdMarca";
                unaMarca = unasMarcas.First() as Marca;

                //Traer Modelos asociadas a la marca
                unosModelos = ManagerModelo.ModeloTraerPorMarcaCategoria(unDetSolic.unaCategoria.IdCategoria, unaMarca.IdMarca);
                cboModelo.DataSource = null;
                cboModelo.DataSource = unosModelos;
                cboModelo.DisplayMember = "DescripModeloVersion";
                cboModelo.ValueMember = "IdModeloVersion";

                //unosProveedores = unosProveedores.Where(X=>X.IdProveedor == )
            }
            else
            {
                txtResBusqueda.Visible = true;
                GrillaDetallesBienes.Visible = false;
            }
        }


        private void FormatearGrillaDetallesBienes()
        {
            GrillaDetallesBienes.Columns["DescripCategoria"].HeaderText = "Bien";
            GrillaDetallesBienes.Columns["IdCategoria"].Visible = false;
            GrillaDetallesBienes.Columns["IdSolicitudDetalle"].Visible = false;
        }



        private void frmBienRegistrar_Load(object sender, EventArgs e)
        {

            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            //Cargar proveedores
            unosProveedores = ManagerProveedor.ProveedorTraerTodosActivos();

            ///Para poder seleccionar Hard o Soft
            BLLTipoBien ManagerTipoBien = new BLLTipoBien();
            unosTipoBien = ManagerTipoBien.TraerTodos();
            cboTipoBien.DataSource = null;
            cboTipoBien.DataSource = unosTipoBien;
            cboTipoBien.DisplayMember = "DescripTipoBien";
            cboTipoBien.ValueMember = "IdTipoBien";

            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                lblSerie.Visible = true;
                lblDeposito.Visible = true;
                cboDeposito.Visible = true;
                lblSerieKey.Visible = false;
                lblSerial.Visible = false;
                txtSerialMaster.Visible = false;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                lblSerie.Visible = false;
                lblDeposito.Visible = false;
                cboDeposito.Visible = false;
                lblSerieKey.Visible = true;
                lblSerial.Visible = true;
                txtSerialMaster.Visible = true;
            }

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
            cboEstadoInv.DataSource = null;
            unosEstadoInventario = ManagerEstadoInventario.EstadoInvTraerTodos();
            cboEstadoInv.DataSource = unosEstadoInventario;
            cboEstadoInv.DisplayMember = "DescripEstadoInv";
            cboEstadoInv.ValueMember = "IdEstadoInventario";

            //Cargar fecha Inicio
            txtFechaCompra.MaxDate = DateTime.Today;
            txtFechaCompra.Text = DateTime.Today.ToString("d");
        }



        private void cboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex > -1)
            {
                ComboBox cbo = (ComboBox)sender;
                unaMarca = new Marca();
                unaMarca = (Marca)cbo.SelectedItem;


                unosModelos = ManagerModelo.ModeloTraerPorMarcaCategoria(unDetSolic.unaCategoria.IdCategoria, unaMarca.IdMarca);
                cboModelo.DataSource = null;
                cboModelo.DataSource = unosModelos;
                cboModelo.DisplayMember = "DescripModeloVersion";
                cboModelo.ValueMember = "IdModeloVersion";


                //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validaci�n de true y se vaya
                //ValidDep2.Validate();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (LisAUXDetalles == null || LisAUXDetalles.Count == 0)
            {
                MessageBox.Show("Ingrese la partida asociada por favor");
                return;
            }

            if (!vldFrmBienRegistrarBtnAgregar.Validate())
                return;

            if (unDetSolic.Cantidad <= LisAUXDetalles.Where(x => x.IdSolicitudDetalle == unDetSolic.IdSolicitudDetalle).First().Comprado)//LisAUXDetalles[DetalleSeleccionado - 1].Comprado)
            {
                MessageBox.Show("Ya se compr� todo");
            }
            else
            {
                if ((int)cboTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Hard)
                {
                    unBienAUX = new Hardware();
                    unInven = new XInventarioHard();
                    unBienAUX.unInventarioAlta = new XInventarioHard();
                }
                else
                {
                    unBienAUX = new Software();
                    unInven = new XInventarioSoft();
                    unBienAUX.unInventarioAlta = new XInventarioSoft();
                }
                //Creo ManagerBien con Factory
                //IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien((int)cboTipoBien.SelectedValue);
                //ManagerBien.BienCrear()
                //IBien unBien = FactoryBien.CrearBien((int)cboTipoBien.SelectedValue);
                //Inventario unInven;// = new Inventario();
                HLPBienInventario unBienhlp = new HLPBienInventario();
                unBienhlp.DescripBien = unDetSolic.unaCategoria.DescripCategoria;
                unBienAUX.unaCategoria = unDetSolic.unaCategoria;
                unBienhlp.DescripEstadoInv = cboEstadoInv.Text;
                //unInven.unEstado = (EstadoInventario)cboEstado.SelectedItem;
                unBienAUX.unInventarioAlta.unEstado = (EstadoInventario)cboEstadoInv.SelectedItem;
                unBienhlp.DescripMarca = cboMarca.Text;
                unBienAUX.unaMarca = (Marca)cboMarca.SelectedItem;
                unBienhlp.DescripModeloVersion = cboModelo.Text;
                unBienAUX.unModelo = (ModeloVersion)cboModelo.SelectedItem;
                unBienhlp.SerieKey = txtSerieKey.Text;
                unBienhlp.Costo = decimal.Parse(txtCosto.Text);
                //unInven.SerieKey = txtSerieKey.Text;
                unBienAUX.unInventarioAlta.SerieKey = txtSerieKey.Text;
                if (unInven is XInventarioHard)
                {
                    unBienhlp.NombreDeposito = cboDeposito.Text;
                    //unInven.unDeposito = (Deposito)cboDeposito.SelectedItem;
                    (unBienAUX.unInventarioAlta as XInventarioHard).unDeposito = (Deposito)cboDeposito.SelectedItem;
                }
                if (unInven is XInventarioSoft && !string.IsNullOrEmpty(txtSerialMaster.Text))
                {
                    //FALTA MOSTRAR EL SERIAL MASTER EN LA GRILLA
                    (unBienAUX.unInventarioAlta as XInventarioSoft).SerialMaster = txtSerialMaster.Text;
                }
                //unBien.unInventarioAlta = unInven;
                unBienAUX.unInventarioAlta.PartidaDetalleAsoc = new PartidaDetalle();
                unBienAUX.unInventarioAlta.PartidaDetalleAsoc.UIDPartidaDetalle = ManagerPartidaDetalle.PartidaDetalleUIDPorIdCategoriaIdPartida(Int32.Parse(txtNroPartida.Text), unDetSolic.unaCategoria.IdCategoria);
                unBienAUX.unInventarioAlta.PartidaDetalleAsoc.IdPartida = Int32.Parse(txtNroPartida.Text);

                unBienAUX.unaCategoria = unBien.unaCategoria;
                unBienAUX.unaMarca = unBien.unaMarca;
                unBienAUX.unModelo = unBien.unModelo;
                unBienAUX.IdBien = unBien.IdBien;
                unBienAUX.unInventarioAlta.Costo = Int32.Parse(txtCosto.Text);
                MontoTotalAcum = MontoTotalAcum + Int32.Parse(txtCosto.Text);
                txtMontoTotal.Text = MontoTotalAcum.ToString();

                unaAdquisicion.BienesInventarioAsociados.Add(unBienAUX);

                GrillaBienes.DataSource = null;
                unosBieneshlp.Add(unBienhlp);
                GrillaBienes.DataSource = unosBieneshlp;
                GrillaBienes.Columns["IdInventario"].Visible = false;

            }


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

                unBien.unaCategoria = unDetSolic.unaCategoria;
                unBien.unaMarca = unaMarca;
                unBien.unModelo = unModelo;//(ModeloVersion)cboModelo.SelectedItem;

                unBien.IdBien = ManagerBien.BienTraerIdPorDescripMarcaModelo(unBien.unaCategoria.IdCategoria, unBien.unaMarca.IdMarca, unBien.unModelo.IdModeloVersion);


                //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validaci�n de true y se vaya
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
            DetalleSeleccionado = e.RowIndex + 1;
            unDetSolic = new SolicDetalle();

            //unDetSolic = unosDetallesBienes.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);
            unDetSolic = unosDetallesBienes[e.RowIndex];

            TipoBien unTipoBien = ManagerTipoBien.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
            cboTipoBien.SelectedValue = unTipoBien.IdTipoBien;


            if ((int)cboTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Hard)
            {
                unBien = new Hardware();
                unInven = new XInventarioHard();
                unBien.unInventarioAlta = new XInventarioHard();
            }
            else
            {
                unBien = new Software();
                unInven = new XInventarioSoft();
                unBien.unInventarioAlta = new XInventarioSoft();
            }


            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                //pnlHardware.Visible = true;
                //pnlSoftware.Visible = false;
                lblSerie.Visible = true;
                lblDeposito.Visible = true;
                cboDeposito.Visible = true;
                lblSerieKey.Visible = false;
                lblSerial.Visible = false;
                txtSerialMaster.Visible = false;

                unasCategorias = unasCategoriasHard;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                //pnlSoftware.Visible = true;
                //pnlHardware.Visible = false;
                lblSerie.Visible = false;
                lblDeposito.Visible = false;
                cboDeposito.Visible = false;
                lblSerieKey.Visible = true;
                lblSerial.Visible = true;
                txtSerialMaster.Visible = true;
                unasCategorias = unasCategoriasSoft;
            }


            txtBienCategoria.Text = unDetSolic.unaCategoria.DescripCategoria;

            BLLMarca ManagerMarca = new BLLMarca();
            List<Marca> unasMarcas = new List<Marca>();
            unasMarcas = ManagerMarca.MarcaTraerPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
            cboMarca.DataSource = null;
            cboMarca.DataSource = unasMarcas;
            cboMarca.DisplayMember = "DescripMarca";
            cboMarca.ValueMember = "IdMarca";



        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProveedor.Text))
            {

                List<Proveedor> resProv = new List<Proveedor>();
                resProv = unosProveedores;

                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtProveedor.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resProv = (List<Proveedor>)(from Prov in resProv
                                                where Prov.AliasProv.ToLower().Contains(unaPalabra.ToLower())
                                                select Prov).ToList();
                }

                if (resProv.Count > 0)
                {
                    if (resProv.Count == 1 && string.Equals(resProv.First().AliasProv, txtProveedor.Text))
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
            if (!string.IsNullOrWhiteSpace(txtProveedor.Text))
            {
                if (cboProveedor.SelectedIndex > -1)
                {
                    ComboBox cbo2 = (ComboBox)sender;
                    ProvSeleccionado = new Proveedor();
                    ProvSeleccionado = (Proveedor)cbo2.SelectedItem;
                    this.txtProveedor.TextChanged -= new System.EventHandler(this.txtProveedor_TextChanged);
                    txtProveedor.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    this.txtProveedor.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
                    txtProveedor.SelectionStart = txtProveedor.Text.Length + 1;
                    //Es una validaci�n para cuando no se escribi� el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate();
                }
            }
        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModelo.SelectedIndex > -1)
            {
                ComboBox cbo = (ComboBox)sender;
                unModelo = new ModeloVersion();
                unModelo = (ModeloVersion)cbo.SelectedItem;

                //Creo ManagerBien con Factory
                IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien((int)cboTipoBien.SelectedValue);

                unBien.unaCategoria = unDetSolic.unaCategoria;
                unBien.unaMarca = unaMarca;
                unBien.unModelo = unModelo;//(ModeloVersion)cboModelo.SelectedItem;

                unBien.IdBien = ManagerBien.BienTraerIdPorDescripMarcaModelo(unBien.unaCategoria.IdCategoria, unBien.unaMarca.IdMarca, unBien.unModelo.IdModeloVersion);


                //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validaci�n de true y se vaya
                //ValidDep2.Validate();

            }
        }

        private void btnCrearMarca_Click(object sender, EventArgs e)
        {
            frmMarcaCrear unFrmMarcaCrear = new frmMarcaCrear(unDetSolic.unaCategoria, (int)cboTipoBien.SelectedValue);
            unFrmMarcaCrear.EventoActualizarMarcaModelo += new frmMarcaCrear.DelegaActualizarMarcaModelo(ActualizarMarcaModelo);
            unFrmMarcaCrear.Show();
        }

        public void ActualizarMarcaModelo(Bien unNuevoBien)
        {
            //Mostrar la marca creada
            this.cboMarca.SelectionChangeCommitted -= new System.EventHandler(this.cboMarca_SelectionChangeCommitted);
            TraerMarcas();
            cboMarca.SelectedValue = unNuevoBien.unaMarca.IdMarca;
            unaMarca = unNuevoBien.unaMarca;
            this.cboMarca.SelectionChangeCommitted += new System.EventHandler(this.cboMarca_SelectionChangeCommitted);

            //Mostrar el modelo creado
            this.cboModelo.SelectionChangeCommitted -= new System.EventHandler(this.cboModelo_SelectionChangeCommitted);
            TraerModelos(unNuevoBien.unaMarca);
            cboModelo.SelectedValue = unNuevoBien.unModelo.IdModeloVersion;
            unModelo = unNuevoBien.unModelo;
            this.cboModelo.SelectionChangeCommitted += new System.EventHandler(this.cboModelo_SelectionChangeCommitted);
            
        }

        private void TraerMarcas()
        {
            try
            {
                unasMarcas = ManagerMarca.MarcaTraerPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);
                cboMarca.DataSource = null;
                cboMarca.DataSource = unasMarcas;
                cboMarca.DisplayMember = "DescripMarca";
                cboMarca.ValueMember = "IdMarca";
            }
            catch (Exception es )
            {
                string IdError = ServicioLog.CrearLog(es, "frmBienRegistrar - TraerMarcas");
                MessageBox.Show("Ocurrio un error al mostrar la marca creada, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }

        private void TraerModelos(Marca laMarca)
        {
            try
            {
                unosModelos = ManagerModelo.ModeloTraerPorMarcaCategoria(unDetSolic.unaCategoria.IdCategoria, laMarca.IdMarca);
                cboModelo.DataSource = null;
                cboModelo.DataSource = unosModelos;
                cboModelo.DisplayMember = "DescripModeloVersion";
                cboModelo.ValueMember = "IdModeloVersion";
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmBienRegistrar - TraerModelos");
                MessageBox.Show("Ocurrio un error al mostrar el modelo creado, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }

        private void btnCrearModelo_Click(object sender, EventArgs e)
        {
            frmModeloCrear unFrmMarcaCrear = new frmModeloCrear(unDetSolic.unaCategoria, (int)cboTipoBien.SelectedValue, unaMarca);
            unFrmMarcaCrear.EventoActualizarModelo += new frmModeloCrear.DelegaActualizarModelo(ActualizarModelo);
            unFrmMarcaCrear.Show();
        }


        public void ActualizarModelo(Bien unNuevoBien)
        {
            ////Mostrar la marca creada
            //this.cboMarca.SelectionChangeCommitted -= new System.EventHandler(this.cboMarca_SelectionChangeCommitted);
            //TraerMarcas();
            //cboMarca.SelectedValue = unNuevoBien.unaMarca.IdMarca;
            //unaMarca = unNuevoBien.unaMarca;
            //this.cboMarca.SelectionChangeCommitted += new System.EventHandler(this.cboMarca_SelectionChangeCommitted);

            //Mostrar el modelo creado
            this.cboModelo.SelectionChangeCommitted -= new System.EventHandler(this.cboModelo_SelectionChangeCommitted);
            TraerModelos(unNuevoBien.unaMarca);
            cboModelo.SelectedValue = unNuevoBien.unModelo.IdModeloVersion;
            unModelo = unNuevoBien.unModelo;
            this.cboModelo.SelectionChangeCommitted += new System.EventHandler(this.cboModelo_SelectionChangeCommitted);

        }






    }
}