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
using Novacode;
using System.Drawing;

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
        decimal TotalAcumulado = 0;
        decimal LimitePartida;

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
            txtMontoTotal.Text = "0";
            TraerLimitePartida();

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

                //Carga los detallesSolic que no est�n finalizados
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
                    //Ordena las cotizaciones de cada detalle
                    unDet.unasCotizaciones = unDet.unasCotizaciones.OrderBy(y => y.MontoCotizado).ToList();

                    foreach (Cotizacion unaCoti in unDet.unasCotizaciones)
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
                    //Suma para obtener el costo total de la partida
                    TotalAcumulado += unDet.unasCotizaciones[0].MontoCotizado;
                }
                txtMontoTotal.Text = TotalAcumulado.ToString();
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
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
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


                ListaCotiz = (List<Cotizacion>)ListaSolicDet[e.RowIndex].unasCotizaciones;
                
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
                CalcularMontoTotalPartida();
            }
        }



        /// <summary>
        /// Interacci�n con la grilla de las Cotizaciones
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
                        ListaSolicDet[PosSolicDet].unasCotizaciones[e.RowIndex].Seleccionada = true;
                    }
                    else //Si se destilda
                    {
                        ListaSolicDet[PosSolicDet].unasCotizaciones[e.RowIndex].Seleccionada = false;
                    }
                    grillaCotizaciones.Rows[e.RowIndex].Cells["chkBoxCotizacion"].Value = ListaSolicDet[PosSolicDet].unasCotizaciones[e.RowIndex].Seleccionada;
                    grillaAuxCot.EndEdit();
                    CalcularMontoTotalPartida();
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
                            foreach (Cotizacion Coti in ListaSolicDet[e.RowIndex].unasCotizaciones)
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

                ListaCotiz = (List<Cotizacion>)ListaSolicDet[e.RowIndex].unasCotizaciones;

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
                CalcularMontoTotalPartida();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (grillaCotizaciones != null)
            {
                foreach (Cotizacion CotAux in  ListaSolicDet[0].unasCotizaciones)
                {
                    if (CotAux.Seleccionada)
                    {
                        MessageBox.Show(CotAux.IdCotizacion.ToString() + ": " + CotAux.MontoCotizado.ToString());
                    }
                    
                }
                
            }
        }



        private void CalcularMontoTotalPartida()
        {
            TotalAcumulado = 0;
            foreach (SolicDetalle unDet in ListaSolicDet.Where(X => X.Seleccionado == true))
            {
                //Suma para obtener el costo total de la partida
                var unaCotizacionAUX = unDet.unasCotizaciones.FirstOrDefault(x => x.Seleccionada == true);
                if (unaCotizacionAUX != null)
                {
                    TotalAcumulado += unDet.unasCotizaciones.FirstOrDefault(x => x.Seleccionada == true).MontoCotizado;
                }
                else
                {
                    TotalAcumulado += 0;
                }
            }
            txtMontoTotal.Text = TotalAcumulado.ToString();
        }



        private void TraerLimitePartida()
        {
            BLLPartida PartidaLim = new BLLPartida();
            LimitePartida = PartidaLim.TraerLimitePartida();
        }



        private void btnGenerarCaja_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtMontoTotal.Text) <= LimitePartida)
            {
                MessageBox.Show("Pedido por Caja generado correctamente");
            }
            else
            {
                MessageBox.Show("No se puede solicitar dinero por caja si el monto es mayor a $2.000");
            }
        }

        private void btnGenerarPartida_Click(object sender, EventArgs e)
        {
            BLLPartida ManagerPartida = new BLLPartida();
            int Cont = 1;

            if (decimal.Parse(txtMontoTotal.Text) <= LimitePartida)
            {
                MessageBox.Show("Si desea solicitar una partida por un monto igual o menor a $2.000 debe ingresar el justificativo");
            }
            //Partida directa
            else
            {
                nuevaPartida.FechaEnvio = DateTime.Now;
                nuevaPartida.MontoSolicitado = decimal.Parse(txtMontoTotal.Text);
                
                foreach (SolicDetalle unDeta in ListaSolicDet.Where(X => X.Seleccionado == true))
                {
                    PartidaDetalle unaPartDetalle = new PartidaDetalle();

                    unaPartDetalle.IdPartidaDetalle = Cont++;
                    unaPartDetalle.SolicDetalleAsociado = unDeta;
                    unaPartDetalle.SolicDetalleAsociado.unasCotizaciones = unaPartDetalle.SolicDetalleAsociado.unasCotizaciones.Where(r => r.Seleccionada == true).ToList();
                    unaPartDetalle.unasCotizaciones = (List<Cotizacion>)unDeta.unasCotizaciones.Where(x => x.Seleccionada == true).ToList();

                    nuevaPartida.unasPartidasDetalles.Add(unaPartDetalle);
                }


                if (ManagerPartida.PartidaCrear(nuevaPartida))
                {
                    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevaci�n Partida2.docx"))
                    {
                        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd-MM-yy")));
                        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));

                        // Save this document as the users name followed by .docx
                        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                    }// Release this document from memory
                }
                    MessageBox.Show("Solicitud de Partida generada correctamente");
            }
        }








    }
}