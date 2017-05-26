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
using System.IO;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class frmPartidaSolicitar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmPartidaSolicitar _unFrmPartidaSolicituar;
        public Solicitud unaSolicitud;
        Partida nuevaPartida = new Partida();
        List<SolicDetalle> ListaSolicDet = new List<SolicDetalle>();
        List<Cotizacion> ListaCotiz = new List<Cotizacion>();
        int PosSolicDet = 0;

        //Constructor cuando se ingresa por Principal
        private frmPartidaSolicitar()
        {
            InitializeComponent();
        }

        //Singleton cuando se ingresa por Principal
        public static frmPartidaSolicitar ObtenerInstancia()
        {
            if (_unFrmPartidaSolicituar == null)
            {
                _unFrmPartidaSolicituar = new frmPartidaSolicitar();
            }

            return _unFrmPartidaSolicituar;
        }

        //Constructor cuando se ingresa desde frmModificarSolicitud
        private frmPartidaSolicitar(Solicitud unaSolic)
        {
            InitializeComponent();
            unaSolicitud = unaSolic;
            //Agrega Checkbox para seleccionar SolicDetalles
            var CheckBoxColumna = new DataGridViewCheckBoxColumn();
            CheckBoxColumna.Name = "chkBoxDetalles";
            CheckBoxColumna.TrueValue = true;
            CheckBoxColumna.FalseValue = false;
            CheckBoxColumna.HeaderText = ""; //ServicioIdioma.MostrarMensaje("btnDinCotizar").Texto;
            grillaSolicDetalles.Columns.Add(CheckBoxColumna);
            //Agrega Checkbox para seleccionar Cotizaciones
            DataGridViewCheckBoxColumn chkCotizacion = new DataGridViewCheckBoxColumn();
            chkCotizacion.Name = "chkBoxCotizacion";
            chkCotizacion.HeaderText = "";
            chkCotizacion.TrueValue = true;
            chkCotizacion.FalseValue = false;
            grillaCotizaciones.Columns.Add(chkCotizacion);
        }

        //Singleton cuando se ingresa desde frmModificarSolicitud
        public static frmPartidaSolicitar ObtenerInstancia(Solicitud unaSolic)
        {
            if (_unFrmPartidaSolicituar == null)
            {
                _unFrmPartidaSolicituar = new frmPartidaSolicitar(unaSolic);
            }

            return _unFrmPartidaSolicituar;
        }



        private void frmPartidaSolicitar_Load(object sender, EventArgs e)
        {
            if (unaSolicitud != null)
            {

                txtNroSolicitud.Text = unaSolicitud.IdSolicitud.ToString();
                txtDependencia.Text = unaSolicitud.laDependencia.NombreDependencia;
                txtNroSolicitud.ReadOnly = true;
                txtDependencia.ReadOnly = true;

                grillaSolicitudes.DataSource = null;
                List<Solicitud> ListaAUX = new List<Solicitud>();
                ListaAUX.Add(unaSolicitud);
                grillaSolicitudes.DataSource = ListaAUX;

                grillaSolicDetalles.DataSource = null;

                //Carga los detallesSolic que no están finalizados
                grillaSolicDetalles.DataSource = ListaSolicDet = unaSolicitud.unosDetallesSolicitud.Where(x => x.unEstado.IdEstadoSolicDetalle != 2).ToList();//Distinto de Finalizado

                //********************************
                foreach (DataGridViewRow row in grillaSolicDetalles.Rows)
                {
                    DataGridViewCheckBoxCell chkDet = (DataGridViewCheckBoxCell)row.Cells[0];
                    chkDet.Value = chkDet.TrueValue;
                }
                foreach (SolicDetalle unDet in ListaSolicDet)
                {
                    unDet.Seleccionado = true;
                    int Cont = 1;
                    foreach (Cotizacion unaCoti in unDet.unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList())
                    {   
                        if (Cont <= 3)
                        {
                            unaCoti.Seleccionada = true;
                        }
                        else
                        {
                            unaCoti.Seleccionada = false;
                        }
                        Cont += 1;
                    }
                }
                //********************************




            }
        }



        //Pone en null la variable del formulario para que no ocasione error al abrir de nuevo el formulario (porque tiene un singleton)
        private void frmPartidaSolicitar_FormClosing(object sender, FormClosingEventArgs e)
        {
            _unFrmPartidaSolicituar = null;
        }



        //private void grillaSolicDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void grillaSolicDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            
            else
            {
                DataGridView grillaAux = (DataGridView)sender;

                if (e.ColumnIndex == 0)
                {
                    //grillaAux.EndEdit();
                    if (grillaAux.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        var chkCell = (DataGridViewCheckBoxCell)grillaAux.Rows[e.RowIndex].Cells["chkBoxDetalles"];
                        if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = true;
                            int Cont = 1;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList())
                            {
                                if (Cont <= 3)
                                {
                                    Coti.Seleccionada = true;
                                }
                                else
                                {
                                    Coti.Seleccionada = false;
                                }
                                Cont += 1;
                            }
                        }
                        else //Si se destilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = false;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList())
                            {
                                Coti.Seleccionada = false;
                            }
                        }
                    }
                }


                ListaCotiz = (List<Cotizacion>)ListaSolicDet[e.RowIndex].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList();
                
                grillaCotizaciones.DataSource = null;
                //grillaCotizaciones.DataSource = ListaSolicDet[e.RowIndex].unasCotizaciones;
                //foreach (Cotizacion unaCot in ListaSolicDet[e.RowIndex].unasCotizaciones)
                //{
                //    grillaCotizaciones.Rows[ListaSolicDet[e.RowIndex].unasCotizaciones.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                //    grillaAux.EndEdit();
                //}
                grillaCotizaciones.DataSource = ListaCotiz;
                foreach (Cotizacion unaCot in ListaCotiz)
                {
                    grillaCotizaciones.Rows[ListaCotiz.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                    grillaAux.EndEdit();
                }
                PosSolicDet = e.RowIndex;

            }
        }

        /// <summary>
        /// Interacción con la grilla de las Cotizaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grillaCotizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            
            if (e.ColumnIndex == 0)
            {
                DataGridView grillaAuxCot = (DataGridView)sender;
                //grillaAuxCot.EndEdit();
                if (grillaAuxCot.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    var chkCell = (DataGridViewCheckBoxCell)grillaAuxCot.Rows[e.RowIndex].Cells["chkBoxCotizacion"];
                    if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                    {
                        ListaSolicDet[PosSolicDet].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList()[e.RowIndex].Seleccionada = true;
                    }
                    else //Si se destilda
                    {
                        ListaSolicDet[PosSolicDet].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList()[e.RowIndex].Seleccionada = false;
                    }
                    grillaCotizaciones.Rows[e.RowIndex].Cells["chkBoxCotizacion"].Value = ListaSolicDet[PosSolicDet].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList()[e.RowIndex].Seleccionada;
                    grillaAuxCot.EndEdit();

                }
                
                
            }
        }

        private void grillaSolicDetalles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridView grillaAux = (DataGridView)sender;
                if (e.ColumnIndex == 0)
                {
                    if (grillaAux.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        var chkCell = (DataGridViewCheckBoxCell)grillaAux.Rows[e.RowIndex].Cells["chkBoxDetalles"];
                        if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = true;
                            int Cont = 1;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList())
                            {
                                if (Cont <= 3)
                                {
                                    Coti.Seleccionada = true;
                                }
                                else
                                {
                                    Coti.Seleccionada = false;
                                }
                                Cont += 1;
                            }
                        }
                        else //Si se destilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = false;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
                            {
                                Coti.Seleccionada = false;
                            }
                        }
                    }
                }

                ListaCotiz = (List<Cotizacion>)ListaSolicDet[e.RowIndex].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList();

                grillaCotizaciones.DataSource = null;
                //grillaCotizaciones.DataSource = ListaSolicDet[e.RowIndex].unasCotizaciones;
                //foreach (Cotizacion unaCot in ListaSolicDet[e.RowIndex].unasCotizaciones)
                //{
                //    grillaCotizaciones.Rows[ListaSolicDet[e.RowIndex].unasCotizaciones.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                //    grillaAux.EndEdit();
                //}
                grillaCotizaciones.DataSource = ListaCotiz;
                foreach (Cotizacion unaCot in ListaCotiz)
                {
                    grillaCotizaciones.Rows[ListaCotiz.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                    grillaAux.EndEdit();
                }
                PosSolicDet = e.RowIndex;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (grillaCotizaciones != null)
            {
                foreach (Cotizacion CotAux in  ListaSolicDet[0].unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList())
                {
                    if (CotAux.Seleccionada)
                    {
                        MessageBox.Show(CotAux.IdCotizacion.ToString() + ": " + CotAux.MontoCotizado.ToString());
                    }

                    
                    
                }
                
            }
        }









    }
}