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
                    foreach (Cotizacion unaCoti in unDet.unasCotizaciones)
                    {   
                        unaCoti.Seleccionada = true;
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



        private void grillaSolicDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grillaSolicDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            
            else
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridView grillaAux = (DataGridView)sender;
                    grillaAux.EndEdit();
                    if (grillaAux.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        var chkCell = (DataGridViewCheckBoxCell)grillaAux.Rows[e.RowIndex].Cells["chkBoxDetalles"];
                        if ((bool)chkCell.EditedFormattedValue)//Si se tilda
                        {
                            ListaSolicDet[e.RowIndex].Seleccionado = true;
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
                            {
                                Coti.Seleccionada = true;
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

                grillaCotizaciones.DataSource = null;
                grillaCotizaciones.DataSource = ListaSolicDet[e.RowIndex].unasCotizaciones;
                foreach (Cotizacion unaCot in ListaSolicDet[e.RowIndex].unasCotizaciones)
                {
                    grillaCotizaciones.Rows[ListaSolicDet[e.RowIndex].unasCotizaciones.FindIndex(x => x.IdCotizacion == unaCot.IdCotizacion)].Cells["chkBoxCotizacion"].Value = unaCot.Seleccionada;
                }

            }
        }









    }
}