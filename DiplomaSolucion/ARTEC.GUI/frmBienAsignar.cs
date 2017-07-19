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
        List<Inventario> InventariosAsignar = new List<Inventario>();
        Asignacion unaAsignacion = new Asignacion();
        int ConteoDetalles = 0;

        public frmBienAsignar(Solicitud unaSolicAsig)
        {
            InitializeComponent();
            unaSolic = unaSolicAsig;
        }

        private void frmBienAsignar_Load(object sender, EventArgs e)
        {
            
            txtNroSolic.Text = unaSolic.IdSolicitud.ToString();
            txtDependencia.Text = unaSolic.laDependencia.NombreDependencia;
         
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
                grillaAsig2.ClickEnGrilla += new DataGridViewCellEventHandler(ClickEnGrilla_EventoManejado);
                grillaAsig2.unaCantidad = det.Cantidad.ToString();
                grillaAsig2.unBien = det.unaCategoria.DescripCategoria;
                grillaAsig2.unaGrilla.DataSource = HLPAsigs;

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



        protected void ClickEnGrilla_EventoManejado(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            GrillaAsignacion GrillaActual = (GrillaAsignacion)sender;

            if (GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGray)
            {
                Inventario InvAUX = unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes[e.RowIndex].unInventarioAlta;
                InventariosAsignar.Add(InvAUX);

                //Agregado para Asignacion
                AsigDetalle unAsigDet = new AsigDetalle();
                //Conteo Detalles Asig
                ConteoDetalles += 1;
                unAsigDet.IdAsigDetalle = ConteoDetalles;
                
                unAsigDet.unInventario = InvAUX;

                unAsigDet.SolicDetalleAsoc = unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien);

                unaAsignacion.unosAsigDetalles.Add(unAsigDet);
                
               

                //unaAsignacion.unosAsigDetalles//VER DE PONER BIEN EL INVENTARIO Y EL CONTEODETALLES

                GrillaInvConfirmados.DataSource = null;
                GrillaInvConfirmados.DataSource = InventariosAsignar;

                GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }

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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            unaAsignacion.Fecha = DateTime.Today;
            unaAsignacion.unaDependencia = unaSolic.laDependencia;

            BLLAsignacion ManagerAsignacion = new BLLAsignacion();
            if(ManagerAsignacion.AsignacionCrear(unaAsignacion))
                MessageBox.Show("Asignacion Creada");
        }







    }
}