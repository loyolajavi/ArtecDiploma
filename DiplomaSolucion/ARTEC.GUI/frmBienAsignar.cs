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
    public partial class frmBienAsignar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Solicitud unaSolic = new Solicitud();
        BLLInventarioHard ManagerInventarioHard = new BLLInventarioHard();
        List<GrillaAsignacion> ListaGrilla = new List<GrillaAsignacion>();

        public frmBienAsignar(Solicitud unaSolicAsig)
        {
            InitializeComponent();
            unaSolic = unaSolicAsig;
        }

        private void frmBienAsignar_Load(object sender, EventArgs e)
        {
            txtNroSolic.Text = unaSolic.IdSolicitud.ToString();
            txtDependencia.Text = unaSolic.laDependencia.NombreDependencia;
            GrillaDetallesSolic.DataSource = null;
            GrillaDetallesSolic.DataSource = unaSolic.unosDetallesSolicitud;


            foreach (var det in unaSolic.unosDetallesSolicitud)
            {
                List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
                LisInvHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(det);
                det.InventariosHard = LisInvHard;
            }
            

            foreach (SolicDetalle item in unaSolic.unosDetallesSolicitud)
            {
                GrillaAsignacion grillaAsig2 = new GrillaAsignacion();
                grillaAsig2.unaCantidad = item.Cantidad.ToString();
                grillaAsig2.unBien = item.unaCategoria.DescripCategoria;
                //List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
                //LisInvHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(item);
                //item.InventariosHard = LisInvHard;
                grillaAsig2.unaGrilla = item.InventariosHard;
                ListaGrilla.Add(grillaAsig2);

                //grillaAsig2.Location = new System.Drawing.Point(699, 52);
                //this.Controls.Add(grillaAsig2);
            }


            foreach (GrillaAsignacion gri in ListaGrilla)
            {
                flowInventarios.Controls.Add(gri);
            }


        }

        private void GrillaDetallesSolic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            TipoBien unTipoBienAux = new TipoBien();
            BLLTipoBien managerTipoBienAux = new BLLTipoBien();
            unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unaSolic.unosDetallesSolicitud[e.RowIndex].unaCategoria.IdCategoria);

            if (unTipoBienAux.IdTipoBien == 1)//Hardware
            {
                List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
                LisInvHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(unaSolic.unosDetallesSolicitud[e.RowIndex]);
                unaSolic.unosDetallesSolicitud[e.RowIndex].InventariosHard = LisInvHard;


                GrillaInvDisponibles.DataSource = null;
                GrillaInvDisponibles.DataSource = LisInvHard;
            }
            else
            {
                //List<XInventarioSoft> LisInv = new List<XInventarioSoft>();
                //LisInvHard = ManagerInventarioSoft.InventarioSoftTraerListosParaAsignar(unaSolic.unosDetallesSolicitud[e.RowIndex]);

                //GrillaInvDisponibles.DataSource = null;
                //GrillaInvDisponibles.DataSource = LisInvHard;
            }
        }








    }
}