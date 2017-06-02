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

namespace ARTEC.GUI
{
    public partial class frmPartidaAsociar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Partida unaPartida = new Partida();

        public frmPartidaAsociar()
        {
            InitializeComponent();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLPartida ManagerPartida = new BLLPartida();

            if (!string.IsNullOrWhiteSpace(txtIdPartida.Text))
            {
                unaPartida = ManagerPartida.PartidaTraerPorNroPart(Int32.Parse(txtIdPartida.Text));
                grillaPartidas.DataSource = null;
                List<Partida> unasPartidas = new List<Partida>();
                unasPartidas.Add(unaPartida);
                grillaPartidas.DataSource = unasPartidas;
                //grillaPartidas.Columns[""].Visible = true;
            }
            
        }
    }
}