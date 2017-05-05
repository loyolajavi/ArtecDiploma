using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ARTEC.GUI
{
    public partial class SoftHomologadoBuscar : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static SoftHomologadoBuscar _SoftHomologadoBuscarInst;


        private SoftHomologadoBuscar()
        {
            InitializeComponent();
        }

        public static SoftHomologadoBuscar ObtenerInstancia()
        {
            if (_SoftHomologadoBuscarInst == null)
            {
                _SoftHomologadoBuscarInst = new SoftHomologadoBuscar();
            }

            return _SoftHomologadoBuscarInst;
        }
    }
}