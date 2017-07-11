﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARTEC.GUI
{
    public partial class GrillaAsignacion : UserControl
    {
        

        public GrillaAsignacion()
        {
            InitializeComponent();
        }

        public string unBien
        {
            get { return txtBien.Text; }
            set { txtBien.Text = value; }
        }

        public string unaCantidad
        {
            get { return txtCantidad.Text; }
            set { txtCantidad.Text = value; }
        }

        public object unaGrilla
        {
            get { return GrillaInventarios.DataSource; }
            set { GrillaInventarios.DataSource = value; }
        }

    }
}
