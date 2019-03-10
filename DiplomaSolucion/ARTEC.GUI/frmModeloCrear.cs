using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.ENTIDADES;
using ARTEC.BLL;

namespace ARTEC.GUI
{
    public partial class frmModeloCrear : DevComponents.DotNetBar.Metro.MetroForm
    {
        Marca unaMarca;
        Categoria unaCategoria;
        int IdTipoBien;
        //Delegado para actualizar el modelo en frmBienRegistrar
        public delegate void DelegaActualizarModelo(Bien unNuevoBien);
        //Evento que llama al Delegado
        public event DelegaActualizarModelo EventoActualizarModelo;

        public frmModeloCrear(Categoria laCategoria, int elIdTipoBien, Marca laMarca)
        {
            InitializeComponent();
            unaCategoria = laCategoria;
            IdTipoBien = elIdTipoBien;
            unaMarca = laMarca;
        }

        private void frmModeloCrear_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            txtMarca.Text = unaMarca.DescripMarca;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //Marca NuevaMarca = new Marca();
            ModeloVersion NuevoModelo = new ModeloVersion();
            Bien NuevoBien;
            BLLModelo ManagerModelo = new BLLModelo();

            if (IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
            {
                NuevoBien = new Hardware();
            }
            else
            {
                NuevoBien = new Software();
            }

            try
            {
                if (!vldFrmModeloCrear.Validate())
                    return;


                //NuevaMarca.DescripMarca = txtMarca.Text;
                NuevoModelo.DescripModeloVersion = txtModelo.Text;
                NuevoBien.unaCategoria = this.unaCategoria;
                NuevoBien.unaMarca = this.unaMarca;
                NuevoBien.unModelo = NuevoModelo;
                ManagerModelo.ModeloCrear(NuevoBien, IdTipoBien);
                ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Crear Modelo").Texto, BLLServicioIdioma.MostrarMensaje("Modelo").Texto + " " + NuevoModelo.DescripModeloVersion);
                //Actualiza Modelo en frmBienRegistrar por Evento
                this.EventoActualizarModelo(NuevoBien);
                this.Close();
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmModeloCrear - btnCrear_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear el modelo, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }




    }
}