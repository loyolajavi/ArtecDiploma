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

namespace ARTEC.GUI
{
    public partial class frmCotizaciones : DevComponents.DotNetBar.Metro.MetroForm
    {
        //Delegado para actualizar DetallesSolicitud en frmSolicitudModificar
        public delegate void DelegaActualizarSolicDetalles(List<Cotizacion> unasCotizaciones);
        //Evento que llama al Delegado
        public event DelegaActualizarSolicDetalles EventoActualizarDetalles;

        List<Cotizacion> unasCotizaciones;
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
            unDetSolic = unDetSolicP;
        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {
            grillaProveedor.DataSource = null;
            grillaProveedor.DataSource = unasCotizaciones;

            unosProveedores = ManagerProveedor.ProveedorTraerTodos();

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
                grillaProveedor.DataSource = null;
                grillaProveedor.DataSource = unasCotizaciones;
                
                //Actualiza SolicDetalles en frmModificarSolicitud por Evento
                this.EventoActualizarDetalles(unasCotizaciones);
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
            ListaProv.Add((Proveedor)cboProvSol.SelectedItem);
            GrillaProvSolic.DataSource = null;
            GrillaProvSolic.DataSource = ListaProv;
            txtProvSol.Clear();
            cboProvSol.Refresh();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {

            BLL.Servicios.BLLServicioMail.CargarMailConfig();

            foreach (Proveedor unProv in ListaProv)
            {
                FRAMEWORK.Servicios.ServicioMail.EnviarCorreo(unProv.MailContactoProv, unProv.AliasProv, txtAsunto.Text, txtCuerpo.Text);
            }
            
        }






    }
}