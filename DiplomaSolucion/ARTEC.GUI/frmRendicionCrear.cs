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
    public partial class frmRendicionCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        Rendicion unaRendicion = new Rendicion();
        List<GrillaRendicion> ListaMultiGrillaRendicion = new List<GrillaRendicion>();
        List<HLPInvRendicion> HLPListaInventariosRend = new List<HLPInvRendicion>();
        

        public frmRendicionCrear()
        {
            InitializeComponent();
        }

        private void frmRendicionCrear_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLRendicion ManagerRendicion = new BLLRendicion();
            unaRendicion = ManagerRendicion.AdquisicionesConBienesPorIdPartida(Int32.Parse(txtNroPart.Text));

            //Obtengo los nros de factura por distinct
            List<string> ListaNroFacturas = unaRendicion.unasAdquisiciones.Select(x => x.NroFactura).Distinct().ToList();


            foreach (string fact in ListaNroFacturas)
            {
                GrillaRendicion MultiGrillaRendicion = new GrillaRendicion();
                MultiGrillaRendicion.unaFactura = fact;

                //guardo los inventarios si son de la fact
                HLPListaInventariosRend = unaRendicion.unasAdquisiciones.Where(z => z.NroFactura == fact) 
                                                                    .Select(y => new HLPInvRendicion() { DescripCategoria = y.BienesInventarioAsociados[0].unaCategoria.DescripCategoria, SerieKey = y.BienesInventarioAsociados[0].unInventarioAlta.SerieKey, Costo = y.BienesInventarioAsociados[0].unInventarioAlta.Costo }).ToList();
                MultiGrillaRendicion.unaGrillaInv.DataSource = HLPListaInventariosRend;
                
                ListaMultiGrillaRendicion.Add(MultiGrillaRendicion);
            }

            //Para colocar las "grillas" (control users) en el flow
            foreach (GrillaRendicion gri in ListaMultiGrillaRendicion)
            {
                flowInventariosRend.Controls.Add(gri);
            }

        }





    }
}