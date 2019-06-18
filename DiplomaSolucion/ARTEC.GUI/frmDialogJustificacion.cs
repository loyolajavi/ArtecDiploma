using ARTEC.BLL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARTEC.GUI
{
    public partial class frmDialogJustificacion : Form
    {
        public frmDialogJustificacion()
        {
            InitializeComponent();

            Dictionary<string, string[]> diclabel1 = new Dictionary<string, string[]>();
            string[] Idiomalabel1 = { "Justificación" };
            diclabel1.Add("Idioma", Idiomalabel1);
            this.label1.Tag = diclabel1;

            Dictionary<string, string[]> dicbutton1 = new Dictionary<string, string[]>();
            string[] Idiomabutton1 = { "Aceptar" };
            dicbutton1.Add("Idioma", Idiomabutton1);
            this.button1.Tag = dicbutton1;

            Dictionary<string, string[]> dicbutton2 = new Dictionary<string, string[]>();
            string[] Idiomabutton2 = { "Cancelar" };
            dicbutton2.Add("Idioma", Idiomabutton2);
            this.button2.Tag = dicbutton2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmDialogJustificacion_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

        }
    }
}
