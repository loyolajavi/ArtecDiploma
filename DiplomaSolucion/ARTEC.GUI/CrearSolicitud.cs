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
using System.Linq;

namespace ARTEC.GUI
{
    public partial class CrearSolicitud : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Solicitud unaSolicitud;
        Dependencia unaDep;
        Categoria unaCat;
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        List<Categoria> unasCategoriasHard;
        List<Categoria> unasCategoriasSoft;
        int AuxTipoCategoria = 1;

        public CrearSolicitud()
        {
            InitializeComponent();
            unaSolicitud = new Solicitud();
        }

        private void txtAgregarDetalle_Click(object sender, EventArgs e)
        {
            SolicDetalle unDetalleSolicitud = new SolicDetalle();
            unDetalleSolicitud.unaCategoria.IdCategoria = unaCat.IdCategoria;
            unDetalleSolicitud.Cantidad = Int32.Parse(txtCantBien.Text);
            unDetalleSolicitud.unEstado.IdEstadoSolDetalle = (int)EstadoSolDetalle.EnumEstadoSolDetalle.Pendiente;
            unaSolicitud.unosDetallesSolicitud.Add(unDetalleSolicitud);

            grillaDetalles.DataSource = null;
            //HACER ESTO: Consultar a la BD la descrip de la categoria IdCategoria, guardarlo 
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            
        }

        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            ///Traigo Dependencias para busqueda dinámica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

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
                
        

        }


        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                List<Dependencia> res = new List<Dependencia>();
                res = (List<Dependencia>)unasDependencias.ToList();

                List<string> Palabras = new List<string>();
                Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    res = (List<Dependencia>)(from d in res
                                              where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                              select d).ToList();
                }

                if (res.Count > 0)
                {
                    if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                    {
                        comboBoxEx4.Visible = false;
                        comboBoxEx4.DroppedDown = false;
                        comboBoxEx4.DataSource = null;
                    }
                    else
                    {
                        comboBoxEx4.DataSource = null;
                        comboBoxEx4.DataSource = res;
                        comboBoxEx4.DisplayMember = "NombreDependencia";
                        comboBoxEx4.ValueMember = "IdDependencia";
                        comboBoxEx4.Visible = true;
                        comboBoxEx4.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    comboBoxEx4.Visible = false;
                    comboBoxEx4.DroppedDown = false;
                    comboBoxEx4.DataSource = null;
                }
            }
            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
            }
        }


        //Al seleccionar una dependencia del combo, guarda el idDependencia, el nombre y cierra el combo
        private void comboBoxEx4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                if (comboBoxEx4.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    unaDep = new Dependencia();
                    unaDep.IdDependencia = (int)cbo.SelectedValue;
                    textBoxX1.Text = cbo.GetItemText(cbo.SelectedItem);
                    textBoxX1.SelectionStart = textBoxX1.Text.Length + 1;
                }
            }
        }


        //public void prueba(){
        //    //Ejemplo de cómo implementar una relación de Agregación en capas
        //    //BLLDependencia MediadorDependencia = new BLLDependencia();
        //    //unaSolicitud.laDependencia = MediadorDependencia.CrearDependencia(unaDep);
        //}



        /// <summary>
        /// Habilitar Controles según Hard/Soft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTipoBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                gboxAsociados.Enabled = false;
                txtCantBien.ReadOnly = false;
                lblCantidad.Enabled = true;
                txtBien.Clear();
                AuxTipoCategoria = 1;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                gboxAsociados.Enabled = true;
                txtCantBien.ReadOnly = true;
                lblCantidad.Enabled = false;
                txtBien.Clear();
                AuxTipoCategoria = 2;
            }
        }

        //Busqueda Dinamica BIENES(CATEGORIAS)
        private void txtBien_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBien.Text))
            {
                
                List<Categoria> resCat = new List<Categoria>();
                //Traigo las categorias de Hard
                if (AuxTipoCategoria == 1)
                {
                    resCat = (List<Categoria>)unasCategoriasHard.ToList();
                }
                //Traigo las categorias de Soft
                else
                {
                    resCat = (List<Categoria>)unasCategoriasSoft.ToList();
                }
                

                List<string> Palabras = new List<string>();
                Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(txtBien.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resCat = (List<Categoria>)(from cat in resCat
                                               where cat.DescripCategoria.ToLower().Contains(unaPalabra.ToLower())
                                               select cat).ToList();
                }

                if (resCat.Count > 0)
                {
                    if (resCat.Count == 1 && string.Equals(resCat.First().DescripCategoria, txtBien.Text))
                    {
                        cboBien.Visible = false;
                        cboBien.DroppedDown = false;
                        cboBien.DataSource = null;
                    }
                    else
                    {
                        cboBien.DataSource = null;
                        cboBien.DataSource = resCat;
                        cboBien.DisplayMember = "DescripCategoria";
                        cboBien.ValueMember = "IdCategoria";
                        cboBien.Visible = true;
                        cboBien.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboBien.Visible = false;
                    cboBien.DroppedDown = false;
                    cboBien.DataSource = null;
                }
            }
            else
            {
                cboBien.Visible = false;
                cboBien.DroppedDown = false;
                cboBien.DataSource = null;
            }
        }

        private void cboBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBien.Text))
            {
                if (cboBien.SelectedIndex > -1)
                {
                    ComboBox cbo2 = (ComboBox)sender;
                    unaCat = new Categoria();
                    unaCat.IdCategoria = (int)cbo2.SelectedValue;
                    txtBien.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    txtBien.SelectionStart = txtBien.Text.Length + 1;
                }
            }
        }









    }
}