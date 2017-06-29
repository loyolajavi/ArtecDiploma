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

                    txtProveedor.Text = cbo2.GetItemText(cbo2.SelectedItem);
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
            unaCotiz.IdCotizacion = ManagerCotizacion.CotizacionCrear(unaCotiz);
            if (unaCotiz.IdCotizacion > 0)
            {
                //unasCotizaciones = ManagerCotizacion.CotizacionTraerPorSolicitudYDetalle(unaCotiz.unDetalleAsociado.IdSolicitudDetalle, unaCotiz.unDetalleAsociado.IdSolicitud);
                unasCotizaciones.Add(unaCotiz);
                grillaProveedor.DataSource = null;
                grillaProveedor.DataSource = unasCotizaciones;
                
                //Actualiza SolicDetalles en frmModificarSolicitud por Evento
                this.EventoActualizarDetalles(unasCotizaciones);
            }
        }








    }
}