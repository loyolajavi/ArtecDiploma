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


namespace ARTEC.GUI
{
    public partial class frmDependenciaModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        Dependencia DepModif;
        List<TipoDependencia> LisTipoDep = new List<TipoDependencia>();
        BLLDependencia ManagerDependencia = new BLLDependencia();
        List<Agente> unosAgentes;
        Agente unAgenSelect;
        List<Cargo> unosCargos = new List<Cargo>();
        List<Agente> AgentesLista = new List<Agente>();
        List<Agente> AgentesNuevos = new List<Agente>();

        public frmDependenciaModificar(Dependencia unaDep)
        {
            InitializeComponent();
            DepModif = unaDep;

        }

        private void frmDependenciaModificar_Load(object sender, EventArgs e)
        {
            txtDependencia.Text = DepModif.NombreDependencia;
            //Coloco el TipoDependencia
            LisTipoDep = ManagerDependencia.TipoDepTraerTodos();
            cboTipoDep.DataSource = null;
            cboTipoDep.DataSource = LisTipoDep;
            cboTipoDep.DisplayMember = "DescripTipoDependencia";
            cboTipoDep.ValueMember = "IdTipoDependencia";
            cboTipoDep.SelectedValue = DepModif.unTipoDep.IdTipoDependencia;
            //Coloco los agentes
            GrillaAgentesLista.DataSource = null;
            GrillaAgentesLista.DataSource = AgentesLista = DepModif.unosAgentes;
            FormatearGrillaAgentes();

            //Traer todos los agentes (para agregar)
            BLLAgente ManagerAgente = new BLLAgente();
            unosAgentes = new List<Agente>();
            unosAgentes = ManagerAgente.AgentesTraerTodos();
            //Traigo los cargos
            BLLCargo ManagerCargo = new BLLCargo();
            unosCargos = new List<Cargo>();
            unosCargos = ManagerCargo.CargosTraerTodos();
            cboCargo.DataSource = null;
            cboCargo.DataSource = unosCargos;
            cboCargo.DisplayMember = "DescripCargo";
            cboCargo.ValueMember = "IdCargo";
            
        }

        private void txtAgente_TextChanged(object sender, EventArgs e)
        {
            unAgenSelect = null;

            if (!string.IsNullOrWhiteSpace(txtAgente.Text) & unosAgentes != null)
            {

                List<Agente> resAgente = new List<Agente>();
                resAgente = (List<Agente>)unosAgentes.ToList();
                List<string> Palabras = new List<string>();
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtAgente.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resAgente = (List<Agente>)(from cat in resAgente
                                               where cat.ApellidoAgente.ToLower().Contains(unaPalabra.ToLower())
                                               select cat).ToList();
                }

                if (resAgente.Count > 0)
                {
                    if (resAgente.Count == 1 && string.Equals(resAgente.First().ApellidoAgente, txtAgente.Text))
                    {
                        cboAgentes.Visible = false;
                        cboAgentes.DroppedDown = false;
                        cboAgentes.DataSource = resAgente;
                        cboAgentes.SelectedIndex = 0;
                        cboAgentes_SelectionChangeCommitted(cboAgentes, new EventArgs());
                    }
                    else
                    {
                        cboAgentes.DataSource = null;
                        cboAgentes.DataSource = resAgente;
                        cboAgentes.DisplayMember = "ApellidoAgente";
                        cboAgentes.ValueMember = "IdAgente";
                        cboAgentes.Visible = true;
                        cboAgentes.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboAgentes.Visible = false;
                    cboAgentes.DroppedDown = false;
                    cboAgentes.DataSource = null;
                    //unAgen = null; // GUARDA
                }
            }
            else
            {
                cboAgentes.Visible = false;
                cboAgentes.DroppedDown = false;
                cboAgentes.DataSource = null;
            }
        }



        
        private void cboAgentes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAgente.Text))
            {
                if (cboAgentes.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    this.txtAgente.TextChanged -= new System.EventHandler(this.txtAgente_TextChanged);
                    txtAgente.Text = cbo.GetItemText(cbo.SelectedItem);
                    unAgenSelect = cbo.SelectedItem as Agente;
                    this.txtAgente.TextChanged += new System.EventHandler(this.txtAgente_TextChanged);
                    txtAgente.SelectionStart = txtAgente.Text.Length + 1;
                }
            }
        }

        private void btnAgregarAgente_Click(object sender, EventArgs e)
        {
            //Para prevenir que se agregue un agente que ya está en la dependencia
            if (AgentesLista.Exists(x => x.IdAgente == unAgenSelect.IdAgente))
                return;

            unAgenSelect.unCargo = cboCargo.SelectedItem as Cargo;
            unAgenSelect.unaDependencia = new Dependencia();
            unAgenSelect.unaDependencia = DepModif;
            AgentesLista.Add(unAgenSelect);
            AgentesNuevos.Add(unAgenSelect);

            GrillaAgentesLista.DataSource = null;
            GrillaAgentesLista.DataSource = AgentesLista;
            FormatearGrillaAgentes();

            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (DepModif.unTipoDep != (TipoDependencia)cboTipoDep.SelectedItem)
                ManagerDependencia.DependenciaModifTipoDep(DepModif.IdDependencia, (TipoDependencia)cboTipoDep.SelectedItem);

            if (AgentesNuevos != null)
            {
                ManagerDependencia.DependenciaAgenteAgregar(AgentesNuevos, DepModif.IdDependencia);
            }

        }


        private void FormatearGrillaAgentes()
        {
            GrillaAgentesLista.Columns["IdAgente"].Visible = false;
            GrillaAgentesLista.Columns["NombreAgente"].HeaderText = "Nombre";
            GrillaAgentesLista.Columns["ApellidoAgente"].HeaderText = "Apellido";
            GrillaAgentesLista.Columns["unCargo"].HeaderText = "Cargo";
            GrillaAgentesLista.Columns["unaDependencia"].Visible = false;
        }






    }
}