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

        List<TipoBien> unosTipoBien = new List<TipoBien>();
        List<Categoria> unasCategoriasHard;
        List<Categoria> unasCategoriasSoft;
        List<Categoria> unasCategorias = new List<Categoria>();
        Categoria unaCat;
        Marca unaMarca;
        List<HLPBienInventario> unosBieneshlp = new List<HLPBienInventario>();

        public frmBienRegistrar()
        {
            InitializeComponent();
        }

        private void stepItem1_Click(object sender, EventArgs e)
        {

        }

        private void stepItem2_Click(object sender, EventArgs e)
        {

        }

        private void lblIdSolicitud_Click(object sender, EventArgs e)
        {

        }

        private void txtIdSolicitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            pnlAdquisicion.Visible = false;
            pnlBienes.Visible = true;
            this.stepItem1.BackColors = new System.Drawing.Color[] {System.Drawing.Color.Transparent};
            this.stepItem2.BackColors = new System.Drawing.Color[] {System.Drawing.Color.MediumAquamarine};
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

        private void cboTipoBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                //AuxTipoCategoria = 1;
                pnlHardware.Visible = true;
                pnlSoftware.Visible = false;
                unasCategorias = unasCategoriasHard;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                //AuxTipoCategoria = 2;
                pnlSoftware.Visible = true;
                pnlHardware.Visible = false;
                unasCategorias = unasCategoriasSoft;
            }
        }

        private void txtBienCategoria_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBienCategoria.Text))
            {
                List<Categoria> res = new List<Categoria>();
                res = (List<Categoria>)unasCategorias;
                
                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtBienCategoria.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    res = (List<Categoria>)(from d in res
                                              where d.DescripCategoria.ToLower().Contains(unaPalabra.ToLower())
                                              select d).ToList();
                }

                if (res.Count > 0)
                {

                    //ESTO ERA PARA QUE NO QUEDE FLASHADO EL CBOBOX AL PASAR DE MUCHOS RESULTADOS RESULTADO A UNO SOLO AL ESCRIBIR LA FISCALIA JUSTA A MANO, PERO HACIA QUE NO SE EJECUTE BIEN LO DE CARGAR LOS AGENTES
                    //if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                    //{
                    //    //comboBoxEx4.Visible = false;
                    //    //comboBoxEx4.DroppedDown = false;
                    //    //comboBoxEx4.DataSource = null;

                    //}
                    //else
                    //{
                    cboBienCategoria.DataSource = null;
                    cboBienCategoria.DataSource = res;
                    cboBienCategoria.DisplayMember = "DescripCategoria";
                    cboBienCategoria.ValueMember = "IdCategoria";
                    cboBienCategoria.Visible = true;
                    cboBienCategoria.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                    //}
                }
                else
                {
                    cboBienCategoria.Visible = false;
                    cboBienCategoria.DroppedDown = false;
                    cboBienCategoria.DataSource = null;
                    
                }
            }
            else
            {
                cboBienCategoria.Visible = false;
                cboBienCategoria.DroppedDown = false;
                cboBienCategoria.DataSource = null;
                cboMarca.DataSource = null;
            }
        }

        private void cboBienCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBienCategoria.Text))
            {
                if (cboBienCategoria.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    unaCat = new Categoria();
                    unaCat = (Categoria)cbo.SelectedItem;
                    this.txtBienCategoria.TextChanged -= new System.EventHandler(this.txtBienCategoria_TextChanged);
                    txtBienCategoria.Text = cbo.GetItemText(cbo.SelectedItem);
                    this.txtBienCategoria.TextChanged += new System.EventHandler(this.txtBienCategoria_TextChanged);
                    txtBienCategoria.SelectionStart = txtBienCategoria.Text.Length + 1;

                    BLLMarca ManagerMarca = new BLLMarca();
                    List<Marca> unasMarcas = new List<Marca>();
                    unasMarcas = ManagerMarca.MarcaTraerPorIdCategoria(unaCat.IdCategoria, (int)cboTipoBien.SelectedValue);
                    cboMarca.DataSource = null;
                    cboMarca.DataSource = unasMarcas;
                    cboMarca.DisplayMember = "DescripMarca";
                    cboMarca.ValueMember = "IdMarca";
                    

                    //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
                    //ValidDep2.Validate();

                }
            }
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
                unosModelos = ManagerModelo.ModeloTraerPorMarcaCategoria(unaCat.IdCategoria, (int)cboTipoBien.SelectedValue, unaMarca.IdMarca);
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
            IBLLBien ManagerBien = BLLFactoryBien.CrearManagerBien((int)cboTipoBien.SelectedValue);
            //ManagerBien.BienCrear()
            //IBien unBien = FactoryBien.CrearBien((int)cboTipoBien.SelectedValue);
            IBien unBien = ManagerBien.BienInstanciar();
            Inventario unHardInven = new Inventario();
            unBien.unosInventarios.Add(unHardInven);

            HLPBienInventario unBienhlp = new HLPBienInventario();
            unBienhlp.DescripBien = txtBienCategoria.Text;
            unBienhlp.DescripEstadoInv = cboEstado.Text;
            unBienhlp.DescripMarca = cboMarca.Text;
            unBienhlp.DescripModeloVersion = cboModelo.Text;
            unBienhlp.NombreDeposito = cboDeposito.Text;
            unBienhlp.SerieKey = txtSerieKey.Text;

            GrillaBienes.DataSource = null;
            unosBieneshlp.Add(unBienhlp);
            GrillaBienes.DataSource = unosBieneshlp;


        }





    }
}