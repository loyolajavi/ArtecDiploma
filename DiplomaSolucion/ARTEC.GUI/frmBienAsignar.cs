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
using ARTEC.ENTIDADES.Helpers;
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
        List<HLPAsignacion> HLPAsigs = new List<HLPAsignacion>();

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

            //ESTA ESTABA ANTES DE USAR EL HLP
            //foreach (var det in unaSolic.unosDetallesSolicitud)
            //{
            //    //List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
            //    List<Hardware> LisHard = new List<Hardware>();
            //    LisHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(det);
            //    det.unosBienes = LisHard;
            //    HLPAsigs = LisHard.Select(x => new HLPAsignacion() { IdInventario = x.unInventarioAlta.IdInventario, Marca = x.unaMarca.DescripMarca, Modelo = x.unModelo.DescripModeloVersion, Serie = x.unInventarioAlta.SerieKey}).ToList();
            //}

            foreach (var det in unaSolic.unosDetallesSolicitud)
            {
                //List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
                List<Hardware> LisHard = new List<Hardware>();
                LisHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(det);
                det.unosBienes = LisHard;
                HLPAsigs = LisHard.Select(x => new HLPAsignacion() { IdInventario = x.unInventarioAlta.IdInventario, Marca = x.unaMarca.DescripMarca, Modelo = x.unModelo.DescripModeloVersion, Serie = x.unInventarioAlta.SerieKey }).ToList();

                GrillaAsignacion grillaAsig2 = new GrillaAsignacion();
                grillaAsig2.unaCantidad = det.Cantidad.ToString();
                grillaAsig2.unBien = det.unaCategoria.DescripCategoria;
                grillaAsig2.unaGrilla = HLPAsigs;

                //Button bot = new Button();
                //grillaAsig2.Controls.Add(bot);
                //grillaAsig2.Controls["bot"].Click += bot_Click;

                ListaGrilla.Add(grillaAsig2);




            }

            //ESTA ESTABA ANTES DE USAR EL HLP
            //foreach (SolicDetalle item in unaSolic.unosDetallesSolicitud)
            //{
            //    GrillaAsignacion grillaAsig2 = new GrillaAsignacion();
            //    grillaAsig2.unaCantidad = item.Cantidad.ToString();
            //    grillaAsig2.unBien = item.unaCategoria.DescripCategoria;
            //    //List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
            //    //LisInvHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(item);
            //    //item.InventariosHard = LisInvHard;
            //    grillaAsig2.unaGrilla = item.InventariosHard;
            //    ListaGrilla.Add(grillaAsig2);

            //    //grillaAsig2.Location = new System.Drawing.Point(699, 52);
            //    //this.Controls.Add(grillaAsig2);
            //}





            foreach (GrillaAsignacion gri in ListaGrilla)
            {
                flowInventarios.Controls.Add(gri);
            }


        }

        private void bot_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GrillaDetallesSolic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //TipoBien unTipoBienAux = new TipoBien();
            //BLLTipoBien managerTipoBienAux = new BLLTipoBien();
            //unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unaSolic.unosDetallesSolicitud[e.RowIndex].unaCategoria.IdCategoria);

            //if (unTipoBienAux.IdTipoBien == 1)//Hardware
            //{
            //    List<XInventarioHard> LisInvHard = new List<XInventarioHard>();
            //    LisInvHard = ManagerInventarioHard.InventarioHardTraerListosParaAsignar(unaSolic.unosDetallesSolicitud[e.RowIndex]);
            //    unaSolic.unosDetallesSolicitud[e.RowIndex].InventariosHard = LisInvHard;


            //    GrillaInvDisponibles.DataSource = null;
            //    GrillaInvDisponibles.DataSource = LisInvHard;
            //}
            //else
            //{
            //    //List<XInventarioSoft> LisInv = new List<XInventarioSoft>();
            //    //LisInvHard = ManagerInventarioSoft.InventarioSoftTraerListosParaAsignar(unaSolic.unosDetallesSolicitud[e.RowIndex]);

            //    //GrillaInvDisponibles.DataSource = null;
            //    //GrillaInvDisponibles.DataSource = LisInvHard;
            //}
        }







    }
}