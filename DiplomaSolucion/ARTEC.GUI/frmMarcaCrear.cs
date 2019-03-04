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
    public partial class frmMarcaCrear : DevComponents.DotNetBar.Metro.MetroForm
    {
        Categoria unaCategoria;
        int IdTipoBien;
        //Delegado para actualizar la marca y el modelo en frmBienRegistrar
        public delegate void DelegaActualizarMarcaModelo(Bien unNuevoBien);
        //Evento que llama al Delegado
        public event DelegaActualizarMarcaModelo EventoActualizarMarcaModelo;

        public frmMarcaCrear(Categoria laCategoria, int elIdTipoBien)
        {
            InitializeComponent();
            unaCategoria = laCategoria;
            IdTipoBien = elIdTipoBien;
        }

        private void frmMarcaCrear_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Marca NuevaMarca = new Marca();
            ModeloVersion NuevoModelo = new ModeloVersion();
            Bien NuevoBien;
            BLLMarca ManagerMarca = new BLLMarca();

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
                if (!vldFrmMarcaCrear.Validate())
                    return;

                
                NuevaMarca.DescripMarca = txtMarca.Text;
                NuevoModelo.DescripModeloVersion = txtModelo.Text;
                NuevoBien.unaCategoria = this.unaCategoria;
                NuevoBien.unaMarca = NuevaMarca;
                NuevoBien.unModelo = NuevoModelo;
                ManagerMarca.MarcaCrear(NuevoBien, IdTipoBien);
                //Actualiza Marca y Modelo en frmBienRegistrar por Evento
                this.EventoActualizarMarcaModelo(NuevoBien);
                this.Close();
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmMarcaCrear - btnCrear_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear la marca, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }




    }
}