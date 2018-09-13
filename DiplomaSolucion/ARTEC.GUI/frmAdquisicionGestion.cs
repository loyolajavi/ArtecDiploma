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

namespace ARTEC.GUI
{
    public partial class frmAdquisicionGestion : DevComponents.DotNetBar.Metro.MetroForm
    {

        Adquisicion unaAdqModif;

        public frmAdquisicionGestion()
        {
            InitializeComponent();
        }


        public frmAdquisicionGestion(Adquisicion unaAdq)
        {
            InitializeComponent();
            unaAdqModif = unaAdq;
        }


    }
}