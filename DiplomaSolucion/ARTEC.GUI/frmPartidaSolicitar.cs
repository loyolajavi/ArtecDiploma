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

        private frmPartidaSolicitar()
        {
            InitializeComponent();
        }

        public static frmPartidaSolicitar ObtenerInstancia()
        {
            if (_unFrmPartidaSolicituar == null)
            {
                _unFrmPartidaSolicituar = new frmPartidaSolicitar();
            }

            return _unFrmPartidaSolicituar;
        }

        private frmPartidaSolicitar(Solicitud unaSolic)
        {
            InitializeComponent();
            unaSolicitud = unaSolic;
        }


        public static frmPartidaSolicitar ObtenerInstancia(Solicitud unaSolic)
        {
            if (_unFrmPartidaSolicituar == null)
            {
                _unFrmPartidaSolicituar = new frmPartidaSolicitar(unaSolic);
            }

            return _unFrmPartidaSolicituar;
        }
        
        //Constructor cuando se ingresa desde frmModificarSolicitud
        //public frmPartidaSolicitar(Solicitud unaSolic)
        //{
        //    InitializeComponent();
        //    unaSolicitud = unaSolic;
        //}

        //Constructor cuando se ingresa por Principal
        //public frmPartidaSolicitar()
        //{
        //    InitializeComponent();
        //}

        private void frmPartidaSolicitar_Load(object sender, EventArgs e)
        {
            if (unaSolicitud != null)
            {

                txtNroSolicitud.Text = unaSolicitud.IdSolicitud.ToString();
                txtDependencia.Text = unaSolicitud.laDependencia.NombreDependencia;
                txtNroSolicitud.ReadOnly = true;
                txtDependencia.ReadOnly = true;

                grillaSolicitudes.DataSource = null;
                grillaSolicitudes.DataSource = unaSolicitud;//NO FUNCIONA PORQUE ES UNUNICO OBJETO

                grillaSolicDetalles.DataSource = null;
                grillaSolicDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            }
        }

        private void frmPartidaSolicitar_FormClosing(object sender, FormClosingEventArgs e)
        {
            _unFrmPartidaSolicituar = null;
        }









    }
}