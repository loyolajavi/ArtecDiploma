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
    public partial class frmAdquisicionGestion : DevComponents.DotNetBar.Metro.MetroForm
    {

        Adquisicion unaAdqModif;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Dependencia DepSeleccionada;
        List<Proveedor> unosProveedores = new List<Proveedor>();
        Proveedor ProvSeleccionado;
        BLLAdquisicion ManagerAdquisicion = new BLLAdquisicion();
        List<Inventario> unosInventarios = new List<Inventario>();
        List<HLPBienInventario> unosInventariosHlp = new List<HLPBienInventario>();
        //List<Inventario> InventariosAgregar = new List<Inventario>(); En vez de utilizar esta variable, uso directamente la que se encuentra dentro de unaAdqModif
        List<Inventario> InventariosAgregarBKP = new List<Inventario>();
        DataGridView GrillaBienesAAdquirir = new DataGridView();
        HLPDetallesAdquisicion unDet = new HLPDetallesAdquisicion();
        Solicitud unaSolic = new Solicitud();
        List<HLPDetallesAdquisicion> LisAUXDetalles;
        AgregarInventarioCU unAgregarInventarioCU = new AgregarInventarioCU();
        BLLTipoBien ManagerTipoBien = new BLLTipoBien();
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        Marca unaMarca;
        BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
        BLLInventario ManagerInventario = new BLLInventario();
        

        public frmAdquisicionGestion()
        {
            InitializeComponent();
        }


        public frmAdquisicionGestion(Adquisicion unaAdq)
        {
            InitializeComponent();
            unaAdqModif = unaAdq;
        }

        private void frmAdquisicionGestion_Load(object sender, EventArgs e)
        {
            try
            {
                ///Traigo Dependencias para busqueda dinámica
                BLLDependencia ManagerDependencia = new BLLDependencia();
                unasDependencias = ManagerDependencia.TraerTodos();
                ///Traigo Proveedores para busqueda dinámica
                BLLProveedor ManagerProveedor = new BLLProveedor();
                unosProveedores = ManagerProveedor.ProveedorTraerTodosActivos();

                txtIdAdquisicion.Text = unaAdqModif.IdAdquisicion.ToString();
                txtNroPartida.Text = unaAdqModif.unIdPartida.ToString();
                txtDep.Text = unaAdqModif.unaDependencia.NombreDependencia;
                txtFecha.Text = unaAdqModif.FechaAdq.ToString();
                txtFechaCompra.Text = unaAdqModif.FechaCompra.ToString();
                txtNroFactura.Text = unaAdqModif.NroFactura.ToString();
                txtNroSolicitud.Text = unaAdqModif.unIdSolicitud.ToString();
                txtProveedor.Text = unaAdqModif.ProveedorAdquisicion.AliasProv;

                unaAdqModif.unosInventariosAsoc = ManagerAdquisicion.AdquisicionInventariosAsoc(txtNroPartida.Text, txtIdAdquisicion.Text);
                InventariosAgregarBKP = unaAdqModif.unosInventariosAsoc.ToList();

                unaSolic.unosDetallesSolicitud = ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar);
                unaSolic.unosDetallesSolicitud.AddRange(ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido));
                unaSolic.unosDetallesSolicitud.AddRange(ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado));

                foreach (Inventario unInv in unaAdqModif.unosInventariosAsoc)
	            {
                    unInv.PartidaDetalleAsoc.IdPartida = unaAdqModif.unIdPartida;
                    unInv.PartidaDetalleAsoc.SolicDetalleAsociado = new SolicDetalle();
                    unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud = unaSolic.unosDetallesSolicitud.Find(X => X.unaCategoria.DescripCategoria == unInv.deBien.DescripBien).IdSolicitud;
                    unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle = unaSolic.unosDetallesSolicitud.Find(X => X.unaCategoria.DescripCategoria == unInv.deBien.DescripBien).IdSolicitudDetalle;
                    unInv.PartidaDetalleAsoc.UIDPartidaDetalle = unaAdqModif.unosInventariosAsoc.Find(X => X.deBien.DescripBien == unInv.deBien.DescripBien).PartidaDetalleAsoc.UIDPartidaDetalle;


		            HLPBienInventario unInvHlp = new HLPBienInventario();
                    unInvHlp.IdInventario = unInv.IdInventario;
                    unInvHlp.DescripBien = unInv.deBien.DescripBien;
                    unInvHlp.DescripMarca = unInv.deBien.unaMarca.DescripMarca;
                    unInvHlp.DescripModeloVersion = unInv.deBien.unModelo.DescripModeloVersion;
                    unInvHlp.SerieKey = unInv.SerieKey;
                    unInvHlp.Costo = unInv.Costo;

                    unosInventariosHlp.Add(unInvHlp);
	            }
                
                GrillaInventarios.DataSource = null;
                GrillaInventarios.DataSource = unosInventariosHlp;
                FormatearGrillaInventarios();
            }            
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAsquisicionGestion - frmAdquisicionGestion_Load");
                MessageBox.Show("Ocurrio un error al intentar cargar la pantalla de modificacion de Adquisicion, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }


        private void FormatearGrillaInventarios()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaInventarios.Columns.Contains("btnDinBorrar"))
                GrillaInventarios.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaInventarios.Columns.Add(deleteButton);

            //Formato GrillaInventarios
            GrillaInventarios.Columns["IdInventario"].Visible = false;
            GrillaInventarios.Columns["DescripBien"].HeaderText = "Bien";
            GrillaInventarios.Columns["DescripMarca"].HeaderText = "Marca";
            GrillaInventarios.Columns["DescripModeloVersion"].HeaderText = "Modelo";
            GrillaInventarios.Columns["SerieKey"].HeaderText = "Serie";
            GrillaInventarios.Columns["NombreDeposito"].Visible = false;
            GrillaInventarios.Columns["DescripEstadoInv"].Visible = false;
        }


        private void GrillaInventarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                EstadoInventario unEstadosInv = new EstadoInventario();
                try
                {
                    //Si hizo click en Quitar
                    if (e.ColumnIndex == GrillaInventarios.Columns["btnDinBorrar"].Index)
                    {
                        unEstadosInv = ManagerInventario.InventarioTraerEstadoPorIdInventario(unaAdqModif.unosInventariosAsoc[e.RowIndex].IdInventario);
                        if (unEstadosInv.IdEstadoInventario == (int)EstadoInventario.EnumEstadoInventario.Entregado)
                            MessageBox.Show("El inventario no puede ser eliminado porque ya fue asignado");
                        else
                        {
                            unaAdqModif.unosInventariosAsoc.RemoveAt(e.RowIndex);
                            //Lo mismo con el helper
                            unosInventariosHlp.RemoveAt(e.RowIndex);

                            //Regenero la grilla
                            GrillaInventarios.DataSource = null;
                            GrillaInventarios.DataSource = unosInventariosHlp;
                            FormatearGrillaInventarios();
                        }
                    }
                    
                    
                }
                catch (Exception es)
                {
                    string IdError = ServicioLog.CrearLog(es, "frmAsquisicionGestion - GrillaInventarios_CellClick");
                    MessageBox.Show("Ocurrio un error al eliminar un inventario, por favor informe del error Nro " + IdError + " del Log de Eventos");
                }
            }
        }



        private void txtDependencia_TextChanged(object sender, EventArgs e)
        {
            DepSeleccionada = null;

            if (!string.IsNullOrWhiteSpace(txtDep.Text) & txtDep.TextLength >= 3 || !string.IsNullOrWhiteSpace(txtDep.Text) & txtDep.TextLength <= 2 & Regex.IsMatch(txtDep.Text, @"\d"))
            {
                BusquedaDependencias();
            }
            else
            {
                cboDep.Visible = false;
                cboDep.DroppedDown = false;
                cboDep.DataSource = null;
            }
        }


        private void BusquedaDependencias()
        {
            List<Dependencia> res = new List<Dependencia>();
            res = (List<Dependencia>)unasDependencias.ToList();

            List<string> Palabras = new List<string>();
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtDep.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                if (res.Count == 1 && string.Equals(res.First().NombreDependencia, txtDep.Text))
                {
                    cboDep.Visible = false;
                    cboDep.DroppedDown = false;
                    cboDep.DataSource = null;
                }
                else
                {
                    cboDep.DataSource = null;
                    cboDep.DataSource = res;
                    cboDep.DisplayMember = "NombreDependencia";
                    cboDep.ValueMember = "IdDependencia";
                    cboDep.Visible = true;
                    cboDep.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                cboDep.Visible = false;
                cboDep.DroppedDown = false;
                cboDep.DataSource = null;
            }
        }


        private void cboDep_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDep.Text))
            {
                if (cboDep.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtDep.TextChanged -= new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDep.Text = cbo.GetItemText(cbo.SelectedItem);
                    DepSeleccionada = cbo.SelectedItem as Dependencia;
                    this.txtDep.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
                    txtDep.SelectionStart = txtDep.Text.Length + 1;
                }
            }
        }


        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProveedor.Text) & txtProveedor.TextLength >= 3 || !string.IsNullOrWhiteSpace(txtProveedor.Text) & txtProveedor.TextLength <= 2 & Regex.IsMatch(txtProveedor.Text, @"\d"))
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



        private void cboProovedor_SelectionChangeCommitted(object sender, EventArgs e)
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
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<Inventario> InvQuitarMod = new List<Inventario>();
            List<Inventario> InvAgregarMod = new List<Inventario>();

            //Si tienen que haber Validaciones van aca
            //if (!vldFrmAsignacionModificar.Validate())
                //return;

            //Verificar que quede al menos un inventario
            if (unaAdqModif.unosInventariosAsoc.Count == 0)
            {
                MessageBox.Show("Por favor revisar que la adquisicion posea al menos un inventario");
                //InventariosAgregar.Clear();
                //InventariosAgregar = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsignacionSelec.IdAsignacion);
                //InventariosAgregarBKP = InventariosAgregar.ToList();
                //GrillaBienesAsignados.DataSource = null;
                //GrillaBienesAsignados.DataSource = InventariosAgregar;
                //FormatearGrillaBienesAsignados();
                //flowBienesAAsignar.Visible = false;
                //flowBienesAAsignar.Controls.Clear();
                //unaAsignacionModif.unosAsigDetalles = ManagerAsignacion.AsigDetallesTraer(unaAsignacionSelec.IdAsignacion);
                //for (int i = 0; i < unaAsignacionModif.unosAsigDetalles.Count; i++)
                //{
                //    unaAsignacionModif.unosAsigDetalles[i].unInventario = InventariosAgregar[i];
                //}
                //ListaGrilla.Clear();
                return;
            }

            try
            {

                InvQuitarMod = InventariosAgregarBKP.Where(d => !unaAdqModif.unosInventariosAsoc.Any(a => a.IdInventario == d.IdInventario)).ToList();
                InvAgregarMod = unaAdqModif.unosInventariosAsoc.Where(d => !InventariosAgregarBKP.Any(a => a.IdInventario == d.IdInventario)).ToList();

                unaAdqModif.FechaAdq = DateTime.Parse(txtFecha.Text);
                unaAdqModif.FechaCompra = DateTime.Parse(txtFechaCompra.Text);
                unaAdqModif.NroFactura = txtNroFactura.Text;
                //unaAdqModif.ProveedorAdquisicion = txtProveedor.Text; VER:

                if (ManagerAdquisicion.AdquisicionModificar(unaAdqModif, InvQuitarMod, InvAgregarMod))
                {
                    unaAdqModif.unosInventariosAsoc.Clear();
                    unaAdqModif.unosInventariosAsoc = ManagerAdquisicion.AdquisicionInventariosAsoc(txtNroPartida.Text, txtIdAdquisicion.Text);
                    InventariosAgregarBKP = unaAdqModif.unosInventariosAsoc.ToList();
                    unosInventariosHlp.Clear();
                    foreach (Inventario unInv in unaAdqModif.unosInventariosAsoc)
                    {
                        HLPBienInventario unInvHlp = new HLPBienInventario();
                        unInvHlp.IdInventario = unInv.IdInventario;
                        unInvHlp.DescripBien = unInv.deBien.DescripBien;
                        unInvHlp.DescripMarca = unInv.deBien.unaMarca.DescripMarca;
                        unInvHlp.DescripModeloVersion = unInv.deBien.unModelo.DescripModeloVersion;
                        unInvHlp.SerieKey = unInv.SerieKey;
                        unInvHlp.Costo = unInv.Costo;

                        unosInventariosHlp.Add(unInvHlp);
                    }

                    GrillaInventarios.DataSource = null;
                    GrillaInventarios.DataSource = unosInventariosHlp;
                    FormatearGrillaInventarios();
                    flowBienesAAdquirir.Visible = false;
                    flowBienesAAdquirir.Controls.Clear();
                    GrillaBienesAAdquirir.DataSource = null;

                    MessageBox.Show("Modificación realizada");
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAdquisicionModificar - btnModificar_Click");
                MessageBox.Show("Ocurrio un error al intentar modificar la Asignacion, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnBienesRestantes_Click(object sender, EventArgs e)
        {
            //Traer TiposBien
            unosTipoBien = ManagerTipoBien.TraerTodos();
            unosTipoBien.Insert(0, new TipoBien { IdTipoBien = 0, DescripTipoBien = "<Seleccionar>" });
            unAgregarInventarioCU.unTipoBien.DataSource = null;
            unAgregarInventarioCU.unTipoBien.DataSource = unosTipoBien;
            unAgregarInventarioCU.unTipoBien.DisplayMember = "DescripTipoBien";
            unAgregarInventarioCU.unTipoBien.ValueMember = "IdTipoBien";

            //BLLPartidaDetalle ManagerPartidaDetalle = new BLLPartidaDetalle();
            
            flowBienesAAdquirir.Visible = false;
            flowBienesAAdquirir.Controls.Clear();
            GrillaBienesAAdquirir.DataSource = null;
            

            unaSolic.unosDetallesSolicitud = ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar);

            LisAUXDetalles = unaSolic.unosDetallesSolicitud.Select(x => new HLPDetallesAdquisicion() { DescripCategoria = x.unaCategoria.DescripCategoria, Cantidad = x.Cantidad, IdCategoria = x.unaCategoria.IdCategoria, IdSolicitudDetalle = x.IdSolicitudDetalle }).ToList();

            if (LisAUXDetalles.Count() > 0)
            {

                List<HLPDetallesAdquisicion> LisAUXCant = new List<HLPDetallesAdquisicion>();
                LisAUXCant = ManagerPartidaDetalle.InventarioAdquiridoCantPorPartDetalle(Int32.Parse(txtNroPartida.Text));
                foreach (var item2 in LisAUXDetalles)
                {
                    item2.Comprado = (from x in LisAUXCant
                                      where x.IdSolicitudDetalle == item2.IdSolicitudDetalle
                                      select x.Comprado).FirstOrDefault();
                }

                GrillaBienesAAdquirir.DataSource = null;
                GrillaBienesAAdquirir.DataSource = LisAUXDetalles;
                flowBienesAAdquirir.Controls.Add(GrillaBienesAAdquirir);
                GrillaBienesAAdquirir.CellClick += new DataGridViewCellEventHandler(this.GrillaBienesAAdquirir_CellClick);
                unAgregarInventarioCU.unBtnAgregar.Click += new EventHandler(this.unAgregarInventarioCU_unBtnAgregar_Click);
                flowBienesAAdquirir.Visible = true;
                GrillaBienesAAdquirir.AutoSize = true;
                GrillaBienesAAdquirir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                flowBienesAAdquirir.Controls.Add(unAgregarInventarioCU);
            }
        }


        protected void GrillaBienesAAdquirir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            unAgregarInventarioCU.unModelo.DataSource = null;
            unDet = LisAUXDetalles[e.RowIndex];

            //Traer Marcas asociadas al bien
            BLLMarca ManagerMarca = new BLLMarca();
            List<Marca> unasMarcasAsoc = new List<Marca>();
            unasMarcasAsoc = ManagerMarca.MarcaTraerPorIdCategoria(unDet.IdCategoria);
            unasMarcasAsoc.Insert(0, new Marca { IdMarca = 0, DescripMarca = "<Seleccionar>" });
            unAgregarInventarioCU.unaMarca.DataSource = null;
            unAgregarInventarioCU.unaMarca.DataSource = unasMarcasAsoc;
            unAgregarInventarioCU.unaMarca.DisplayMember = "DescripMarca";
            unAgregarInventarioCU.unaMarca.ValueMember = "IdMarca";

            //Preparo para traer modelos asociados a la Marca
            unAgregarInventarioCU.unaMarca.SelectionChangeCommitted += new EventHandler(this.unAgregarInventarioCU_unaMarca_SelectionChangeCommitted);

            unAgregarInventarioCU.unBien = unDet.DescripCategoria;
            TipoBien unTipoBienAux = new TipoBien();
            unTipoBienAux = ManagerTipoBien.TipoBienTraerTipoBienPorIdCategoria(unDet.IdCategoria);
            unAgregarInventarioCU.unTipoBien.SelectedValue = unTipoBienAux.IdTipoBien;
        }

        protected void unAgregarInventarioCU_unaMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Traer Modelos asociados a la Marca seleccionada
            if (unAgregarInventarioCU.unaMarca.SelectedIndex > 0)
            {
                ComboBox cbo = (ComboBox)sender;
                unaMarca = new Marca();
                unaMarca = (Marca)cbo.SelectedItem;
                BLLModelo ManagerModelo = new BLLModelo();
                List<ModeloVersion> unosModelosAsoc = new List<ModeloVersion>();
                unosModelosAsoc = ManagerModelo.ModeloTraerPorMarcaCategoria(unDet.IdCategoria, unaMarca.IdMarca);
                unosModelosAsoc.Insert(0, new ModeloVersion { IdModeloVersion = 0, DescripModeloVersion = "<Seleccionar>" });
                unAgregarInventarioCU.unModelo.DataSource = null;
                unAgregarInventarioCU.unModelo.DataSource = unosModelosAsoc;
                unAgregarInventarioCU.unModelo.DisplayMember = "DescripModeloVersion";
                unAgregarInventarioCU.unModelo.ValueMember = "IdModeloVersion";
            }
        }


        protected void unAgregarInventarioCU_unBtnAgregar_Click(object sender, EventArgs e)
        {
            HLPBienInventario unInvAgregarHLP = new HLPBienInventario();
            Inventario unInvAgregar;

            if (unAgregarInventarioCU.unaMarca != null & unAgregarInventarioCU.unModelo != null & unAgregarInventarioCU.unTipoBien != null && (int)unAgregarInventarioCU.unaMarca.SelectedValue > 0 & (int)unAgregarInventarioCU.unModelo.SelectedValue > 0 & (int)unAgregarInventarioCU.unTipoBien.SelectedValue > 0)
            {
                if ((int)unAgregarInventarioCU.unTipoBien.SelectedValue == (int)TipoBien.EnumTipoBien.Hard)
                {
                    //unBienAUX = new Hardware();
                    unInvAgregar = new XInventarioHard();
                    unInvAgregar.unTipoBien = (int)TipoBien.EnumTipoBien.Hard;
                    //unBienAUX.unInventarioAlta = new XInventarioHard();
                }
                else
                {
                    //unBienAUX = new Software();
                    unInvAgregar = new XInventarioSoft();
                    unInvAgregar.unTipoBien = (int)TipoBien.EnumTipoBien.Soft;
                    //unBienAUX.unInventarioAlta = new XInventarioSoft();
                }

                //Datos del Inventario
                unInvAgregar.SerieKey = unAgregarInventarioCU.unSerie;
                unInvAgregar.unEstado = new EstadoInventario() { IdEstadoInventario = (int)EstadoInventario.EnumEstadoInventario.Disponible };
                IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien((int)unAgregarInventarioCU.unTipoBien.SelectedValue);
                unInvAgregar.IdBienEspecif = ManagerBien.BienTraerIdPorDescripMarcaModelo(unaSolic.unosDetallesSolicitud.Where(x => x.unaCategoria.DescripCategoria == unAgregarInventarioCU.unBien).First().unaCategoria.IdCategoria, (int)unAgregarInventarioCU.unaMarca.SelectedValue, (int)unAgregarInventarioCU.unModelo.SelectedValue);
                unInvAgregar.Costo = unAgregarInventarioCU.unCosto;
                unInvAgregar.unDeposito = new Deposito() { IdDeposito = 1 };
                unInvAgregar.PartidaDetalleAsoc = new PartidaDetalle();
                unInvAgregar.PartidaDetalleAsoc.IdPartida = unaAdqModif.unIdPartida;
                unInvAgregar.PartidaDetalleAsoc.SolicDetalleAsociado = new SolicDetalle();
                unInvAgregar.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud = unaSolic.unosDetallesSolicitud.Find(X => X.unaCategoria.DescripCategoria == unAgregarInventarioCU.unBien).IdSolicitud;
                unInvAgregar.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle = unaSolic.unosDetallesSolicitud.Find(X => X.unaCategoria.DescripCategoria == unAgregarInventarioCU.unBien).IdSolicitudDetalle;
                unInvAgregar.PartidaDetalleAsoc.UIDPartidaDetalle = unaAdqModif.unosInventariosAsoc.Find(X => X.deBien.DescripBien == unAgregarInventarioCU.unBien).PartidaDetalleAsoc.UIDPartidaDetalle;

                unInvAgregarHLP.DescripBien = unAgregarInventarioCU.unBien;
                unInvAgregarHLP.DescripMarca = (unAgregarInventarioCU.unaMarca.SelectedItem as Marca).DescripMarca;
                unInvAgregarHLP.DescripModeloVersion = (unAgregarInventarioCU.unModelo.SelectedItem as ModeloVersion).DescripModeloVersion;
                unInvAgregarHLP.SerieKey = unAgregarInventarioCU.unSerie;
                unInvAgregarHLP.Costo = unAgregarInventarioCU.unCosto;

                unaAdqModif.unosInventariosAsoc.Add(unInvAgregar);
                unosInventariosHlp.Add(unInvAgregarHLP);

                //Regenero la grilla
                GrillaInventarios.DataSource = null;
                GrillaInventarios.DataSource = unosInventariosHlp;
                FormatearGrillaInventarios();
            }
            
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BLLInventario ManagerInventario = new BLLInventario();
            List<EstadoInventario> unosEstadosInv = new List<EstadoInventario>();

            try
            {
                foreach (Inventario unInven in unaAdqModif.unosInventariosAsoc)
                {
                    unosEstadosInv.Add(ManagerInventario.InventarioTraerEstadoPorIdInventario(unInven.IdInventario));
                }
                if (unosEstadosInv.Any(X => X.IdEstadoInventario == (int)EstadoInventario.EnumEstadoInventario.Entregado))
                    MessageBox.Show("La adquisición no puede ser eliminada porque contiene inventarios que ya fueron asignados");
                else
                {
                    DialogResult resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Adquisición: " + unaAdqModif.IdAdquisicion.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        if (ManagerAdquisicion.AdquisicionEliminar(unaAdqModif))
                        {
                            MessageBox.Show("Asignación: " + unaAdqModif.IdAdquisicion.ToString() + " eliminada correctamente");
                            DialogResult = DialogResult.No;
                        }
                        else
                            return;
                }

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAdquisicionGestion - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la adquisición: " + unaAdqModif.IdAdquisicion.ToString() + ", por favor informe del error Nro " + IdError + " del Log de Eventos");
            }

            
            
        }

        private void GrillaInventarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult ResFrmInventarioModif = new DialogResult();

            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            EstadoInventario unEstadoInv = new EstadoInventario();
            unEstadoInv = ManagerInventario.InventarioTraerEstadoPorIdInventario(unaAdqModif.unosInventariosAsoc[e.RowIndex].IdInventario);
            if (unEstadoInv.IdEstadoInventario == (int)EstadoInventario.EnumEstadoInventario.Entregado)
            {
                MessageBox.Show("El inventario no puede ser modificado porque ya fue asignado");
            }
            else
            {
                frmInventarioModif unFrmInventarioModif = new frmInventarioModif(unaAdqModif.unosInventariosAsoc[e.RowIndex]);
                ResFrmInventarioModif = unFrmInventarioModif.ShowDialog();

                if (ResFrmInventarioModif == DialogResult.OK)
                {
                    CargarInventariosAdquisicion();
                }
            }
        }


        private void CargarInventariosAdquisicion()
        {
            unosInventariosHlp.Clear();
            unaAdqModif.unosInventariosAsoc = ManagerAdquisicion.AdquisicionInventariosAsoc(txtNroPartida.Text, txtIdAdquisicion.Text);
            InventariosAgregarBKP = unaAdqModif.unosInventariosAsoc.ToList();

            unaSolic.unosDetallesSolicitud = ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar);
            unaSolic.unosDetallesSolicitud.AddRange(ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido));
            unaSolic.unosDetallesSolicitud.AddRange(ManagerPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(unaAdqModif.unIdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado));

            foreach (Inventario unInv in unaAdqModif.unosInventariosAsoc)
            {
                unInv.PartidaDetalleAsoc.IdPartida = unaAdqModif.unIdPartida;
                unInv.PartidaDetalleAsoc.SolicDetalleAsociado = new SolicDetalle();
                unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitud = unaSolic.unosDetallesSolicitud.Find(X => X.unaCategoria.DescripCategoria == unInv.deBien.DescripBien).IdSolicitud;
                unInv.PartidaDetalleAsoc.SolicDetalleAsociado.IdSolicitudDetalle = unaSolic.unosDetallesSolicitud.Find(X => X.unaCategoria.DescripCategoria == unInv.deBien.DescripBien).IdSolicitudDetalle;
                unInv.PartidaDetalleAsoc.UIDPartidaDetalle = unaAdqModif.unosInventariosAsoc.Find(X => X.deBien.DescripBien == unInv.deBien.DescripBien).PartidaDetalleAsoc.UIDPartidaDetalle;


                HLPBienInventario unInvHlp = new HLPBienInventario();
                unInvHlp.IdInventario = unInv.IdInventario;
                unInvHlp.DescripBien = unInv.deBien.DescripBien;
                unInvHlp.DescripMarca = unInv.deBien.unaMarca.DescripMarca;
                unInvHlp.DescripModeloVersion = unInv.deBien.unModelo.DescripModeloVersion;
                unInvHlp.SerieKey = unInv.SerieKey;
                unInvHlp.Costo = unInv.Costo;

                unosInventariosHlp.Add(unInvHlp);
            }

            GrillaInventarios.DataSource = null;
            GrillaInventarios.DataSource = unosInventariosHlp;
            FormatearGrillaInventarios();
        }

    }
}