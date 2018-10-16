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
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmCotizaciones : DevComponents.DotNetBar.Metro.MetroForm
    {
        //Delegado para actualizar DetallesSolicitud en frmSolicitudModificar
        public delegate void DelegaActualizarSolicDetalles(List<Cotizacion> unasCotiz, int IdSolDet);
        //Evento que llama al Delegado
        public event DelegaActualizarSolicDetalles EventoActualizarDetalles;

        List<Cotizacion> unasCotizaciones;
        List<Cotizacion> unasCotizacionesBKP = new List<Cotizacion>();
        List<Proveedor> unosProveedores = new List<Proveedor>();
        Proveedor ProvSeleccionado;
        BLLProveedor ManagerProveedor = new BLLProveedor();
        BLLCotizacion ManagerCotizacion = new BLLCotizacion();
        SolicDetalle unDetSolic = new SolicDetalle();
        List<Proveedor> ListaProv = new List<Proveedor>();

        public frmCotizaciones(List<Cotizacion> unasCotiz, SolicDetalle unDetSolicP)
        {
            InitializeComponent();
            unasCotizaciones = unasCotiz;
            unasCotizacionesBKP = unasCotizaciones.ToList();
            unDetSolic = unDetSolicP;
        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {
            //Permisos
            //Obtengo todos los controles del formulario
            IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
            foreach (Control unControl in unosControles)
            {
                if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                {
                    unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                }
            }

            grillaCotizacion.DataSource = null;
            grillaCotizacion.DataSource = unasCotizaciones;
            FormatearGrillaCotizacion();

            unosProveedores = ManagerProveedor.ProveedorTraerTodosActivos();

            if (ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual == (int)Idioma.EnumIdioma.Español)
            {
                txtCuerpo.Text = "Prueba";
                txtAsunto.Text = "Cotización MPF";
            }
            else
            {
                txtCuerpo.Text = "Test";
                txtAsunto.Text = "MPF Quote";
            }
        }



        //Busqueda Dinamica Proveedores
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
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate();
                }
            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!vldFrmCotozacionAgreCot.Validate())
                return;

            Cotizacion unaCotiz = new Cotizacion();
            unaCotiz.MontoCotizado = Decimal.Parse(txtPrecioUn.Text);
            unaCotiz.FechaCotizacion = DateTime.Today;
            unaCotiz.unProveedor = ProvSeleccionado;
            unaCotiz.unDetalleAsociado = new SolicDetalle();
            unaCotiz.unDetalleAsociado.IdSolicitud = unDetSolic.IdSolicitud;//unasCotizaciones[0].unDetalleAsociado.IdSolicitud;
            unaCotiz.unDetalleAsociado.IdSolicitudDetalle = unDetSolic.IdSolicitudDetalle;//unasCotizaciones[0].unDetalleAsociado.IdSolicitudDetalle;
            //unaCotiz.IdCotizacion = ManagerCotizacion.CotizacionCrear(unaCotiz);
            //if (unaCotiz.IdCotizacion > 0)
            //{
                //unasCotizaciones = ManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(unaCotiz.unDetalleAsociado.IdSolicitudDetalle, unaCotiz.unDetalleAsociado.IdSolicitud);
                unasCotizaciones.Add(unaCotiz);
                grillaCotizacion.DataSource = null;
                grillaCotizacion.DataSource = unasCotizaciones;
                FormatearGrillaCotizacion();

                ////Actualiza SolicDetalles en frmModificarSolicitud por Evento
                //this.EventoActualizarDetalles(unasCotizaciones);
            //}
        }



        private void txtProvSol_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProvSol.Text))
            {

                List<Proveedor> resProvSol = new List<Proveedor>();
                resProvSol = unosProveedores;

                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtProvSol.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resProvSol = (List<Proveedor>)(from Prov in resProvSol
                                                where Prov.AliasProv.ToLower().Contains(unaPalabra.ToLower())
                                                select Prov).ToList();
                }

                if (resProvSol.Count > 0)
                {
                    if (resProvSol.Count == 1 && string.Equals(resProvSol.First().AliasProv, txtProvSol.Text))
                    {
                        cboProvSol.Visible = false;
                        cboProvSol.DroppedDown = false;
                        cboProvSol.DataSource = null;
                    }
                    else
                    {
                        cboProvSol.DataSource = null;
                        cboProvSol.DataSource = resProvSol;
                        cboProvSol.DisplayMember = "AliasProv";
                        cboProvSol.ValueMember = "IdProveedor";
                        cboProvSol.Visible = true;
                        cboProvSol.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboProvSol.Visible = false;
                    cboProvSol.DroppedDown = false;
                    cboProvSol.DataSource = null;
                }
            }
            else
            {
                cboProvSol.Visible = false;
                cboProvSol.DroppedDown = false;
                cboProvSol.DataSource = null;
            }
        }

        private void cboProvSol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProvSol.Text))
            {
                if (cboProvSol.SelectedIndex > -1)
                {
                    ComboBox cbo3 = (ComboBox)sender;
                    ProvSeleccionado = new Proveedor();
                    ProvSeleccionado = (Proveedor)cbo3.SelectedItem;
                    this.txtProvSol.TextChanged -= new System.EventHandler(this.txtProvSol_TextChanged);
                    txtProvSol.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    this.txtProvSol.TextChanged += new System.EventHandler(this.txtProvSol_TextChanged);
                    txtProvSol.SelectionStart = txtProvSol.Text.Length + 1;
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    //validBien.Validate();
                }
            }
        }

        private void btnAgregarProvSol_Click(object sender, EventArgs e)
        {
            if (!vldAgregarProv.Validate())
                return;

            if ((Proveedor)cboProvSol.SelectedItem != null && !ListaProv.Contains((Proveedor)cboProvSol.SelectedItem))
            {
                ListaProv.Add((Proveedor)cboProvSol.SelectedItem);
                GrillaProvSolic.DataSource = null;
                GrillaProvSolic.DataSource = ListaProv;
                FormatearGrillaProvSolic();
            }

            txtProvSol.Clear();
            cboProvSol.Refresh();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (!vldFrmCotizacionesSolic.Validate())
                return;
            BLL.Servicios.BLLServicioMail.CargarMailConfig();

            foreach (Proveedor unProv in ListaProv)
            {
                FRAMEWORK.Servicios.ServicioMail.EnviarCorreo(unProv.MailContactoProv, unProv.AliasProv, txtAsunto.Text, txtCuerpo.Text);
            }
            
        }


        private void FormatearGrillaProvSolic()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaProvSolic.Columns.Contains("btnDinBorrar"))
                GrillaProvSolic.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaProvSolic.Columns.Add(deleteButton);

            //Formato Grilla ProvSolic
            GrillaProvSolic.Columns["IdProveedor"].Visible = false;
            GrillaProvSolic.Columns["Activo"].Visible = false;
            GrillaProvSolic.Columns["AliasProv"].HeaderText = "Nombre";
            GrillaProvSolic.Columns["MailContactoProv"].HeaderText = "Mail";
        }

        private void GrillaProvSolic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaProvSolic.Columns["btnDinBorrar"].Index)
                {
                    ListaProv.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    GrillaProvSolic.DataSource = null;
                    GrillaProvSolic.DataSource = ListaProv;
                    FormatearGrillaProvSolic();
                }
            }
        }


        private void FormatearGrillaCotizacion()
        {
            //Elimina el boton si ya estaba agregado
            if (grillaCotizacion.Columns.Contains("btnDinBorrar"))
                grillaCotizacion.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            grillaCotizacion.Columns.Add(deleteButton);

            //Formato GrillaCotizacion
            grillaCotizacion.Columns["IdCotizacion"].Visible = false;
            grillaCotizacion.Columns["MontoCotizado"].HeaderText = "Monto";
            grillaCotizacion.Columns["FechaCotizacion"].HeaderText = "Fecha";
            grillaCotizacion.Columns["unProveedor"].HeaderText = "Proveedor";
            grillaCotizacion.Columns["unDetalleAsociado"].Visible = false;
            grillaCotizacion.Columns["Seleccionada"].Visible = false;
            grillaCotizacion.Columns["unaPartidaDetalleIDs"].Visible = false;
        }


        private void grillaCotizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == grillaCotizacion.Columns["btnDinBorrar"].Index)
                {
                    unasCotizaciones.RemoveAt(e.RowIndex);
                    //Regenero la grilla
                    grillaCotizacion.DataSource = null;
                    grillaCotizacion.DataSource = unasCotizaciones;
                    FormatearGrillaCotizacion();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            List<Cotizacion> CotiQuitarMod = new List<Cotizacion>();
            List<Cotizacion> CotiAgregarMod = new List<Cotizacion>();

            try
            {
                CotiQuitarMod = unasCotizacionesBKP.Where(x => !unasCotizaciones.Any(y => y.IdCotizacion == x.IdCotizacion)).ToList();
                CotiAgregarMod = unasCotizaciones.Where(x => !unasCotizacionesBKP.Any(y => y.IdCotizacion == x.IdCotizacion)).ToList();

                if (CotiQuitarMod.Count > 0 | CotiAgregarMod.Count > 0)
                {
                    //Actualiza SolicDetalles en frmModificarSolicitud por Evento
                    this.EventoActualizarDetalles(unasCotizaciones, unDetSolic.IdSolicitudDetalle);
                    this.Close();
                }
                else
                    MessageBox.Show("No se encontraron modificaciones a realizar");
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmCotizaciones - btnConfirmar_Click");
                MessageBox.Show("Ocurrio un error al registrar las cotizaciones, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }



    }
}