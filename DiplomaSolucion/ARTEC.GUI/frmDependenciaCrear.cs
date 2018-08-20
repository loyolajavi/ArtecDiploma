using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using System.Linq;
using ARTEC.BLL;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class frmDependenciaCrear : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<TipoDependencia> LisTipoDep = new List<TipoDependencia>();
        BLLDependencia ManagerDependencia = new BLLDependencia();
        List<Cargo> unosCargos;
        List<Agente> unosAgentes;
        Agente unAgenSelect;
        List<Agente> AgentesLista = new List<Agente>();
        Dependencia nuevaDependencia;

        public frmDependenciaCrear()
        {
            InitializeComponent();
        }

        private void frmDependenciaCrear_Load(object sender, EventArgs e)
        {
            try
            {
                //Traer TipoDependencias
                LisTipoDep = ManagerDependencia.TipoDepTraerTodos();
                cboTipoDep.DataSource = null;
                cboTipoDep.DataSource = LisTipoDep;
                cboTipoDep.DisplayMember = "DescripTipoDependencia";
                cboTipoDep.ValueMember = "IdTipoDependencia";

                //Traer los cargos
                BLLCargo ManagerCargo = new BLLCargo();
                unosCargos = new List<Cargo>();
                unosCargos = ManagerCargo.CargosTraerTodos();
                cboCargo.DataSource = null;
                cboCargo.DataSource = unosCargos;
                cboCargo.DisplayMember = "DescripCargo";
                cboCargo.ValueMember = "IdCargo";

                //Traer todos los agentes (para agregar)
                BLLAgente ManagerAgente = new BLLAgente();
                unosAgentes = new List<Agente>();
                unosAgentes = ManagerAgente.AgentesTraerTodos();
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaCrear - frmDependenciaCrear_Load");
                MessageBox.Show("Ocurrio un error al cargar la pantalla para crear Dependencias, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            requiredFieldValidator2.Enabled = false;
            if (!vldfrmDependenciaCrear.Validate())
                return;

            if (AgentesLista != null && AgentesLista.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un Agente para crear la Dependencia");
                return;
            }

            try
            {
                Dependencia DepAux = ManagerDependencia.DependenciaBuscar(txtDependencia.Text);
                if (DepAux != null && DepAux.IdDependencia > 0)
                {
                    MessageBox.Show("La Dependencia ingresada ya existe");
                    return;
                }
                nuevaDependencia = new Dependencia();
                nuevaDependencia.NombreDependencia = txtDependencia.Text;
                nuevaDependencia.unTipoDep = cboTipoDep.SelectedItem as TipoDependencia;
                nuevaDependencia.unosAgentes = AgentesLista;
                if (ManagerDependencia.DependenciaCrear(nuevaDependencia))
                    MessageBox.Show("Dependencia creada correctamente");
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmDependenciaCrear - btnDependenciaCrear_Click");
                MessageBox.Show("Ocurrio un error al intentar crear una Dependencia, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnAgregarAgente_Click(object sender, EventArgs e)
        {
            requiredFieldValidator2.Enabled = true;
            if (!vldfrmDependenciaCrear.Validate())
                return;

            //Para prevenir que se agregue un agente que ya está en la dependencia
            if (AgentesLista.Exists(x => x.IdAgente == unAgenSelect.IdAgente))
            {
                MessageBox.Show("El agente ya se encuentra en la dependencia");
                return;
            }

            unAgenSelect.unCargo = cboCargo.SelectedItem as Cargo;
            AgentesLista.Add(unAgenSelect);
            GrillaAgentesLista.DataSource = null;
            GrillaAgentesLista.DataSource = AgentesLista;
            FormatearGrillaAgentes();


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


        private void FormatearGrillaAgentes()
        {
            //Elimina el boton si ya estaba agregado
            if (GrillaAgentesLista.Columns.Contains("btnDinBorrar"))
                GrillaAgentesLista.Columns.Remove("btnDinBorrar");
            //Agrega boton para Borrar el agente
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDinBorrar";
            deleteButton.HeaderText = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.Text = BLLServicioIdioma.MostrarMensaje("btnDinBorrar").Texto;
            deleteButton.UseColumnTextForButtonValue = true;
            GrillaAgentesLista.Columns.Add(deleteButton);

            //Formato
            GrillaAgentesLista.Columns["IdAgente"].Visible = false;
            GrillaAgentesLista.Columns["NombreAgente"].HeaderText = "Nombre";
            GrillaAgentesLista.Columns["ApellidoAgente"].HeaderText = "Apellido";
            GrillaAgentesLista.Columns["unCargo"].HeaderText = "Cargo";
            GrillaAgentesLista.Columns["unaDependencia"].Visible = false;
        }


        private void GrillaAgentesLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                //Si hizo click en Quitar
                if (e.ColumnIndex == GrillaAgentesLista.Columns["btnDinBorrar"].Index)
                {
                    //Si se quiere quitar un agente q esta en memoria y no en bd
                    Agente unAg = new Agente();
                    if ((unAg = AgentesLista.SingleOrDefault(X => X.IdAgente == (int)GrillaAgentesLista.Rows[e.RowIndex].Cells["IdAgente"].Value)) != null)
                    {
                        AgentesLista.Remove(unAg);
                        GrillaAgentesLista.DataSource = null;
                        GrillaAgentesLista.DataSource = AgentesLista;
                        FormatearGrillaAgentes();
                    }
                }
            }
        }

        


    }
}