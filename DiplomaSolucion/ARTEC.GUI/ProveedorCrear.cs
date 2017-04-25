using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class ProveedorCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        

        public ProveedorCrear()
        {
            InitializeComponent();
        }

        private void ProveedorCrear_Load(object sender, EventArgs e)
        {
            ServicioIdioma.Traducir(this.FindForm(), ServicioIdioma.unIdiomaActual.IdIdioma);
        }



    }
}