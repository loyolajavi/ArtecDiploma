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
using System.Globalization;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.GUI
{
    public partial class frmPartidaSolicitar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static frmPartidaSolicitar _unFrmPartidaSolicituar;
        public Solicitud unaSolicitud;
        Partida nuevaPartida;
        List<SolicDetalle> ListaSolicDet = new List<SolicDetalle>();
        List<Cotizacion> ListaCotiz = new List<Cotizacion>();
        int PosSolicDet = 0;
        decimal TotalAcumulado = 0;
        decimal LimitePartida;
        List<Solicitud> ListaSolicitudes;
        List<Dependencia> unasDependencias = new List<Dependencia>();
        BLLPartida ManagerPartida = new BLLPartida();
        Partida PartidaAsociada = new Partida();
        DialogResult resmbox = DialogResult.No;

        //Constructor cuando se ingresa por Principal
        private frmPartidaSolicitar()
        {
            InitializeComponent();
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

            ///Traigo Dependencias para busqueda din�mica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

            if (unaSolicitud != null)
            {
                txtNroSolicitud.Text = unaSolicitud.IdSolicitud.ToString();
                txtDep.Text = unaSolicitud.laDependencia.NombreDependencia;

                grillaSolicitudes.DataSource = null;
                ListaSolicitudes = new List<Solicitud>();
                ListaSolicitudes.Add(unaSolicitud);
                grillaSolicitudes.DataSource = ListaSolicitudes;

                if (!cargarDetallesYCotizaciones())
                    this.Close();

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
                foreach (Cotizacion CotAux in ListaSolicDet[0].unasCotizaciones)
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
                    TotalAcumulado += (unDet.unasCotizaciones.FirstOrDefault(x => x.Seleccionada == true).MontoCotizado * unDet.Cantidad);
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
                if (GenerarPartidaGlobal(true))
                    MessageBox.Show("Pedido por Caja generado correctamente");
            }
            else
            {
                MessageBox.Show("No se puede solicitar dinero por caja si el monto es mayor a $2.000");
            }
        }

        private void btnGenerarPartida_Click(object sender, EventArgs e)
        {
            if (GenerarPartidaGlobal(false))
                MessageBox.Show("Solicitud de Partida generada correctamente");
        }



        private bool GenerarPartidaGlobal(bool PorCaja)
        {
            
            nuevaPartida = new Partida();
            int Cont = 1;
            string JustifAUX = null;

            nuevaPartida.FechaEnvio = DateTime.Now;
            nuevaPartida.MontoSolicitado = decimal.Parse(txtMontoTotal.Text);
            nuevaPartida.Caja = (PorCaja) ? true : false;

            foreach (SolicDetalle unDeta in ListaSolicDet.Where(X => X.Seleccionado == true))
            {
                PartidaDetalle unaPartDetalle = new PartidaDetalle();

                unaPartDetalle.IdPartidaDetalle = Cont++;
                unaPartDetalle.SolicDetalleAsociado = unDeta;
                unaPartDetalle.SolicDetalleAsociado.unasCotizaciones = unaPartDetalle.SolicDetalleAsociado.unasCotizaciones.Where(r => r.Seleccionada == true).ToList();
                unaPartDetalle.unasCotizaciones = (List<Cotizacion>)unDeta.unasCotizaciones.Where(x => x.Seleccionada == true).ToList();

                nuevaPartida.unasPartidasDetalles.Add(unaPartDetalle);
            }

            //Me fijo si es partida y necesita justificativo
            if (!PorCaja && decimal.Parse(txtMontoTotal.Text) <= LimitePartida)
            {
                frmDialogJustificacion unfrmDialogJustificacion = new frmDialogJustificacion();
                if (unfrmDialogJustificacion.ShowDialog(this) == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(unfrmDialogJustificacion.textBox1.Text))
                    {
                        JustifAUX = unfrmDialogJustificacion.textBox1.Text;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //Si no ingreso el justificativo salgo de la funci�n sin crear la partida en bd ni el documento
                    return false;
                }
            }
            if (ManagerPartida.PartidaCrear(nuevaPartida))
            {
                if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Espa�ol)
                {
                    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevaci�n Partida2.docx"))
                    {
                        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
                        CultureInfo ci = new CultureInfo("es-AR");
                        doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", nuevaPartida.MontoSolicitado.ToString("C2", ci)));
                        //Si se escribio una justificaci�n
                        if (!string.IsNullOrWhiteSpace(JustifAUX))
                        {
                            doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogaci�n de fondos es solicitada por este curso debido a que " + JustifAUX));
                        }
                        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                    }
                }
                else if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.English)
                {
                    using (DocX doc = DocX.Load("D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\Elevaci�n Partida2 English.docx"))
                    {
                        doc.AddCustomProperty(new CustomProperty("PFecha", nuevaPartida.FechaEnvio.ToString("dd 'de' MMMM 'de' yyyy'.'")));
                        doc.AddCustomProperty(new CustomProperty("PDependencia", unaSolicitud.laDependencia.NombreDependencia));
                        CultureInfo ci = new CultureInfo("es-AR");
                        doc.AddCustomProperty(new CustomProperty("PMontoSolicitado", nuevaPartida.MontoSolicitado.ToString("C2", ci)));
                        //Si se escribio una justificaci�n
                        if (!string.IsNullOrWhiteSpace(JustifAUX))
                        {
                            doc.AddCustomProperty(new CustomProperty("PJustificacion", "Finalmente, la presente erogaci�n de fondos es solicitada por este curso debido a que " + JustifAUX));
                        }
                        doc.SaveAs(string.Format(@"D:\\DocumentosDescargas\\uni\\Diploma\\ArtecDiploma\\Prueba Docx\\{0}.docx", "Prueba1"));
                    }
                }

            }
            else
            {
                return false;
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLSolicitud ManagerSolicitud = new BLLSolicitud();
            ListaSolicitudes = new List<Solicitud>();

            if (!string.IsNullOrEmpty(txtNroSolicitud.Text) | !string.IsNullOrEmpty(txtDep.Text))
            {
                if (!string.IsNullOrEmpty(txtNroSolicitud.Text))
                {
                    ListaSolicitudes = ManagerSolicitud.SolicitudBuscar(Int32.Parse(txtNroSolicitud.Text));
                }
                else
                {
                    ListaSolicitudes = ManagerSolicitud.SolicitudBuscar(txtDep.Text);
                }
                grillaSolicitudes.DataSource = null;
                grillaSolicitudes.DataSource = ListaSolicitudes;
                grillaSolicitudes.Columns["Asignado"].Visible = true;
            }
            else
            {
                grillaSolicitudes.DataSource = null;
            }


        }


        private void grillaSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            int SolicSeleccionada = e.RowIndex;

            unaSolicitud = ListaSolicitudes[SolicSeleccionada];
            if (BuscarPartidaAsociada())
                MessageBox.Show("Existe una partida");
            cargarDetallesYCotizaciones();

        }



        private bool cargarDetallesYCotizaciones()
        {

            grillaSolicDetalles.DataSource = null;
            grillaCotizaciones.DataSource = null;

            if (unaSolicitud != null)
            {
                BLLSolicDetalle ManagerSolicDetalles = new BLLSolicDetalle();
                unaSolicitud.unosDetallesSolicitud = ManagerSolicDetalles.SolicDetallesTraerPorNroSolicitud(unaSolicitud.IdSolicitud);
                //Me fijo si tiene detalles
                if (unaSolicitud.unosDetallesSolicitud != null)
                {
                    ListaSolicDet = unaSolicitud.unosDetallesSolicitud.Where(x => x.unEstado.IdEstadoSolicDetalle == (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Cotizado).ToList();

                    if (ListaSolicDet != null && ListaSolicDet.Count() > 0)
                    {
                        txtNroSolicitud.Text = unaSolicitud.IdSolicitud.ToString();
                        txtDep.Text = unaSolicitud.laDependencia.NombreDependencia;
                        //txtNroSolicitud.ReadOnly = true;
                        ////txtDep.ReadOnly = true;

                        grillaSolicDetalles.DataSource = null;
                        //Carga los detallesSolic que no est�n finalizados
                        grillaSolicDetalles.DataSource = ListaSolicDet;

                        foreach (DataGridViewRow row in grillaSolicDetalles.Rows)
                        {
                            DataGridViewCheckBoxCell chkDet = (DataGridViewCheckBoxCell)row.Cells[0];
                            chkDet.Value = chkDet.TrueValue;
                        }

                        //Me fijo si tiene cotizaciones
                        if (ListaSolicDet.Find(R => R.unasCotizaciones != null).unasCotizaciones.Count() > 0)
                        {
                            foreach (SolicDetalle unDet in ListaSolicDet)
                            {
                                unDet.Seleccionado = true;
                                int Cont = 1;
                                //Ordena las cotizaciones de cada detalle
                                if (unDet.unasCotizaciones != null && unDet.unasCotizaciones.Count > 0)
                                {
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
                                    TotalAcumulado += (unDet.unasCotizaciones[0].MontoCotizado * unDet.Cantidad);
                                }

                            }
                            txtMontoTotal.Text = TotalAcumulado.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Por favor primero agregue cotizaciones antes de generar una Partida");//VER:IDIOMA
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta Solicitud no tiene detalles pendientes");//VER:IDIOMA
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Esta Solicitud no tiene detalles pendientes");//VER:IDIOMA
                    return false;
                }
                return true;
            }
            return false;
        }


        //B�squeda din�mica de dependencias
        private void txtDep_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDep.Text))
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

                //ESTO ERA PARA QUE NO QUEDE FLASHADO EL CBOBOX AL PASAR DE MUCHOS RESULTADOS RESULTADO A UNO SOLO AL ESCRIBIR LA FISCALIA JUSTA A MANO, PERO HACIA QUE NO SE EJECUTE BIEN LO DE CARGAR LOS AGENTES
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
                    cboDep.Focus();
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


        private void comboBoxEx4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDep.Text))
            {
                if (cboDep.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtDep.TextChanged -= new System.EventHandler(this.txtDep_TextChanged);
                    txtDep.Text = cbo.GetItemText(cbo.SelectedItem);
                    this.txtDep.TextChanged += new System.EventHandler(this.txtDep_TextChanged);
                    txtDep.SelectionStart = txtDep.Text.Length + 1;
                    cboDep.DataSource = null;
                }
            }
        }



        private bool BuscarPartidaAsociada()
        {
            PartidaAsociada = ManagerPartida.PartidasBuscarPorIdSolicitud(unaSolicitud.IdSolicitud).FirstOrDefault();
            if (PartidaAsociada != null && PartidaAsociada.IdPartida > 0)
                return true;
            return false;
        }



    }
}