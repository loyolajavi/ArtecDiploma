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
        }

        private void frmAgenteCrear_Load(object sender, EventArgs e)
        {
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
            Agente NuevoAgente = new Agente();
            NuevoAgente.NombreAgente = txtNombre.Text;
            NuevoAgente.ApellidoAgente = txtApellido.Text;
            NuevoAgente.unaDependencia = new Dependencia();
            NuevoAgente.unaDependencia.IdDependencia = IdDependencia;
            NuevoAgente.unCargo = new Cargo();
            NuevoAgente.unCargo.IdCargo = (int)cboCargo.SelectedValue;
            NuevoAgente.unCargo.DescripCargo = cboCargo.SelectedText;
            if (ManagerAgente.AgenteCrear(NuevoAgente, IdDependencia) > 0)
                MessageBox.Show("Agente creado correctamente");
            this.Close();
        }
    }
}