using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARTEC.GUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Creo el form del login y pregunto si el resultado de DialogResult es OK (que lo coloco en ese estado si el login fue correcto) para que se cierre el form del login y se abra el principal al loguearse
            Login unFrmLogin = new Login();
            DialogResult Res = unFrmLogin.ShowDialog();
            if (Res == DialogResult.OK)
                Application.Run(new Principal());
            else if (Res == DialogResult.Yes)
                Application.Run(new Backup());
            else if (Res == DialogResult.No)
                Application.Run(new frmDVRecomponer());

        }
    }
}
