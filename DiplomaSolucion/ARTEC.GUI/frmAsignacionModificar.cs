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
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using Novacode;
using System.Globalization;

namespace ARTEC.GUI
{
    public partial class frmAsignacionModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Asignacion unaAsignacionSelec;
        BLLAsignacion ManagerAsignacion = new BLLAsignacion();
        BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
        BLLSolicitud ManagerSolicitud = new BLLSolicitud();
        BLLTipoBien ManagerTipoBienAux = new BLLTipoBien();
        List<HLPAsignacion> HLPAsigs = new List<HLPAsignacion>();
        List<GrillaAsignacion> ListaGrilla = new List<GrillaAsignacion>();
        Solicitud unaSolic = new Solicitud();
        List<Inventario> InventariosAsignar = new List<Inventario>();
        Asignacion unaAsignacion = new Asignacion();
        int ConteoDetalles = 0;

        public frmAsignacionModificar()
        {
            InitializeComponent();
        }

        public frmAsignacionModificar(Asignacion unaAsigArg)
        {
            InitializeComponent();
            unaAsignacionSelec = unaAsigArg;
        }

        private void frmAsignacionModificar_Load(object sender, EventArgs e)
        {
            try
            {
                if (unaAsignacionSelec != null)
                {
                    txtAsignacion.Text = unaAsignacionSelec.IdAsignacion.ToString();
                    txtDep.Text = unaAsignacionSelec.unaDependencia.NombreDependencia;
                    txtNroSolicitud.Text = unaAsignacionSelec.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud.ToString();
                    txtFecha.Text = unaAsignacionSelec.Fecha.ToString();
                    GrillaBienesAsignados.DataSource = null;
                    GrillaBienesAsignados.DataSource = ManagerAsignacion.AsignacionTraerBienesAsignados(unaAsignacionSelec.IdAsignacion);
                    GrillaBienesAsignados.Columns["IdInventario"].Visible = false;
                    GrillaBienesAsignados.Columns["IdBienEspecif"].Visible = false;
                    GrillaBienesAsignados.Columns["unEstado"].Visible = false;
                    GrillaBienesAsignados.Columns["PartidaDetalleAsoc"].Visible = false;
                    GrillaBienesAsignados.Columns["Costo"].Visible = false;
                    GrillaBienesAsignados.Columns["unaAdquisicion"].Visible = false;
                    GrillaBienesAsignados.Columns["unTipoBien"].Visible = false;
                }
            }
            catch (Exception es)
            {
                throw;
            }

         

        }

        private void btnBienesRestantes_Click(object sender, EventArgs e)
        {
            flowBienesAAsignar.Visible = false;
            flowBienesAAsignar.Controls.Clear();
            ListaGrilla.Clear();

            unaSolic.unosDetallesSolicitud = ManagerSolicitud.SolicitudTraerDetalles(unaAsignacionSelec.unosAsigDetalles[0].SolicDetalleAsoc.IdSolicitud).unosDetallesSolicitud;

            foreach (SolicDetalle det in unaSolic.unosDetallesSolicitud)
            {

                BLLInventario ManagerInventario = new BLLInventario();
                IEnumerable<Bien> BienInvListosAsignar;
                BienInvListosAsignar = ManagerInventario.InventariosTraerListosParaAsignarPorSolicDetalle(det, det.unaCategoria.IdCategoria);
                if (BienInvListosAsignar != null && BienInvListosAsignar.Count() > 0)
                {
                    TipoBien unTipoBienAux = new TipoBien();
                    unTipoBienAux = ManagerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(det.unaCategoria.IdCategoria);

                    if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        det.unosBienes = BienInvListosAsignar as List<Hardware>;
                    }
                    else
                    {
                        det.unosBienes = BienInvListosAsignar as List<Software>;
                    }
                    HLPAsigs = BienInvListosAsignar.Select(x => new HLPAsignacion() { IdInventario = x.unInventarioAlta.IdInventario, Marca = x.unaMarca.DescripMarca, Modelo = x.unModelo.DescripModeloVersion, Serie = x.unInventarioAlta.SerieKey }).ToList();

                    GrillaAsignacion grillaAsig2 = new GrillaAsignacion();
                    grillaAsig2.ClickEnGrilla += new DataGridViewCellEventHandler(ClickEnGrilla_EventoManejado);
                    grillaAsig2.unaCantidad = det.Cantidad.ToString();
                    grillaAsig2.unBien = det.unaCategoria.DescripCategoria;
                    grillaAsig2.unaGrilla.DataSource = HLPAsigs;

                    ListaGrilla.Add(grillaAsig2);
                }


            }

            foreach (GrillaAsignacion gri in ListaGrilla)
            {
                flowBienesAAsignar.Controls.Add(gri);
            }
            if (flowBienesAAsignar.Controls.Count > 0)
            {
                flowBienesAAsignar.Visible = true;
            }
        }



        protected void ClickEnGrilla_EventoManejado(object sender, DataGridViewCellEventArgs e)
        {
            ////Si se hizo click en el header, salir
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //{
            //    return;
            //}

            //GrillaAsignacion GrillaActual = (GrillaAsignacion)sender;

            //if (GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGray)
            //{
            //    Inventario InvAUX;
            //    TipoBien unTipoBienLocal = new TipoBien();
            //    unTipoBienLocal = ManagerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria((unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unaCategoria.IdCategoria));
            //    if (unTipoBienLocal.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
            //        InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Hardware>)[e.RowIndex].unInventarioAlta;
            //    else
            //        InvAUX = (unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien).unosBienes as List<Software>)[e.RowIndex].unInventarioAlta;
            //    InventariosAsignar.Add(InvAUX);

            //    //Agregado para Asignacion
            //    AsigDetalle unAsigDet = new AsigDetalle();
            //    //Conteo Detalles Asig
            //    ConteoDetalles += 1;
            //    unAsigDet.IdAsigDetalle = ConteoDetalles;

            //    unAsigDet.unInventario = InvAUX;

            //    unAsigDet.SolicDetalleAsoc = unaSolic.unosDetallesSolicitud.FirstOrDefault(x => x.unaCategoria.DescripCategoria == GrillaActual.unBien);

            //    unaAsignacion.unosAsigDetalles.Add(unAsigDet);



            //    //unaAsignacion.unosAsigDetalles//VER DE PONER BIEN EL INVENTARIO Y EL CONTEODETALLES

            //    GrillaInvConfirmados.DataSource = null;
            //    GrillaInvConfirmados.DataSource = InventariosAsignar;

            //    GrillaActual.unaGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            //}

        }



    }
}