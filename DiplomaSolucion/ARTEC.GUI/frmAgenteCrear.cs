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
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL.Servicios;

namespace ARTEC.GUI
{
    public partial class frmAgenteCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        int IdDependencia;
        string NombreDependencia;
        List<Cargo> unosCargos;
        BLLAgente ManagerAgente = new BLLAgente();

        public frmAgenteCrear(int IdDep, string NomDep)
        {
            InitializeComponent();
            IdDependencia = IdDep;
            NombreDependencia = NomDep;

            Dictionary<string, string[]> dicfrmAgenteCrear = new Dictionary<string, string[]>();
            string[] IdiomafrmAgenteCrear = { "Crear Agente" };
            dicfrmAgenteCrear.Add("Idioma", IdiomafrmAgenteCrear);
            this.Tag = dicfrmAgenteCrear;

            Dictionary<string, string[]> diclblNombre = new Dictionary<string, string[]>();
            string[] IdiomalblNombre = { "Nombre" };
            diclblNombre.Add("Idioma", IdiomalblNombre);
            this.lblNombre.Tag = diclblNombre;

            Dictionary<string, string[]> diclblApellido = new Dictionary<string, string[]>();
            string[] IdiomalblApellido = { "Apellido" };
            diclblApellido.Add("Idioma", IdiomalblApellido);
            this.lblApellido.Tag = diclblApellido;

            Dictionary<string, string[]> diclblCargo = new Dictionary<string, string[]>();
            string[] IdiomalblCargo = { "Cargo" };
            diclblCargo.Add("Idioma", IdiomalblCargo);
            this.lblCargo.Tag = diclblCargo;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> dicbtnCrearAgente = new Dictionary<string, string[]>();
            string[] IdiomabtnCrearAgente = { "Crear Agente" };
            dicbtnCrearAgente.Add("Idioma", IdiomabtnCrearAgente);
            this.btnCrearAgente.Tag = dicbtnCrearAgente;

        }

        private void frmAgenteCrear_Load(object sender, EventArgs e)
        {
            //Idioma
            BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);

            //Traigo los cargos
            BLLCargo ManagerCargo = new BLLCargo();
            unosCargos = new List<Cargo>();
            unosCargos = ManagerCargo.CargosTraerTodos();
            cboCargo.DataSource = null;
            cboCargo.DataSource = unosCargos;
            cboCargo.DisplayMember = "DescripCargo";
            cboCargo.ValueMember = "IdCargo";
            //Coloco la dependencia (readOnly)
            txtDependencia.Text = NombreDependencia;
        }

        private void btnCrearAgente_Click(object sender, EventArgs e)
        {
            if (!vldFrmAgenteCrear.Validate())
                return;

            Agente NuevoAgente = new Agente();

            try
            {
                NuevoAgente.NombreAgente = txtNombre.Text;
                NuevoAgente.ApellidoAgente = txtApellido.Text;
                NuevoAgente.unaDependencia = new Dependencia();
                NuevoAgente.unaDependencia.IdDependencia = IdDependencia;
                NuevoAgente.unCargo = new Cargo();
                NuevoAgente.unCargo.IdCargo = (int)cboCargo.SelectedValue;
                NuevoAgente.unCargo.DescripCargo = cboCargo.SelectedText;
                if (ManagerAgente.AgenteCrear(NuevoAgente, IdDependencia) > 0)
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Agente creado correctamente").Texto);
                DialogResult = DialogResult.OK;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAgenteCrear - btnCrearAgente_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear el Agente: ").Texto + NuevoAgente.NombreAgente + " " + NuevoAgente.ApellidoAgente + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
        }
    }
}