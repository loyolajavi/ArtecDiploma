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
using System.Reflection;
using ARTEC.BLL.Servicios;


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
        List<int> AgentesAQuitar = new List<int>();
        List<int> AgentesAQuitarIndex = new List<int>();
        List<Agente> AgentesListaBKP = new List<Agente>();
        bool Modificacion = false;

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
            //Resguardo
            AgentesListaBKP = AgentesLista.Where(X=>X.IdAgente > 0).ToList() as List<Agente>;

            //AgregarBotonEliminar();
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
            {
                MessageBox.Show("Atención: El agente ya se encuentra en la dependencia");
                return;
            }
                

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
            if (txtDependencia.Enabled)
                ManagerDependencia.DependenciaModifNombre(txtDependencia.Text, DepModif.IdDependencia);

            if (DepModif.unTipoDep.IdTipoDependencia != (cboTipoDep.SelectedItem as TipoDependencia).IdTipoDependencia)
            {
                ManagerDependencia.DependenciaModifTipoDep(DepModif.IdDependencia, (TipoDependencia)cboTipoDep.SelectedItem);
                DepModif.unTipoDep = (TipoDependencia)cboTipoDep.SelectedItem;
            }
                
                

            if (AgentesNuevos != null && AgentesNuevos.Count > 0)
            {
                ManagerDependencia.DependenciaAgenteAgregar(AgentesNuevos, DepModif.IdDependencia);
                AgentesNuevos.Clear();
            }

            if (AgentesAQuitar != null && AgentesAQuitar.Count > 0)
            {
                ManagerDependencia.DependenciaAgentesQuitarLista(AgentesAQuitar, DepModif.IdDependencia);

                //Regenero la lista de agentes para regenerar la grilla
                foreach (int unAgID in AgentesAQuitar)
                {
                    AgentesLista.RemoveAll(X => X.IdAgente == unAgID);                    
                }

                //Limpio los agentesquitar
                AgentesAQuitar.Clear();
                AgentesAQuitarIndex.Clear();
            }

            //Regenero la grilla
            GrillaAgentesLista.DataSource = null;
            //AgentesLista = ManagerDependencia.TraerAgentesDependencia(DepModif.IdDependencia);
            GrillaAgentesLista.DataSource = AgentesLista;
            FormatearGrillaAgentes();
            AgentesListaBKP = AgentesLista.Where(X => X.IdAgente > 0).ToList() as List<Agente>;

            Modificacion = true;

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
            
            //Para grisear los que se quitarán de la BD
            foreach (int indice in AgentesAQuitarIndex)
            {
                GrillaAgentesLista.Rows[indice].DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void btnCandado_Click(object sender, EventArgs e)
        {
            if (!txtDependencia.Enabled)
            {
                txtDependencia.Enabled = true;
                btnCandado.Image = ARTEC.GUI.Properties.Resources.CandadoBloc;
            }
            else
            {
                txtDependencia.Enabled = false;
                btnCandado.Image = ARTEC.GUI.Properties.Resources.CandadoDesb;
                txtDependencia.Text = DepModif.NombreDependencia;
            }
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
                    if ((unAg = AgentesNuevos.SingleOrDefault(X => X.IdAgente == (int)GrillaAgentesLista.Rows[e.RowIndex].Cells["IdAgente"].Value)) != null)
                    {
                        //Lo elimino de la memoria solamente
                        AgentesNuevos.Remove(unAg);
                        AgentesLista.Remove(unAg);
                        //Regenero la grilla de agentes
                        GrillaAgentesLista.DataSource = null;
                        GrillaAgentesLista.DataSource = AgentesLista;
                        //AgregarBotonEliminar();
                        FormatearGrillaAgentes();
                    }
                    //Si es un agente que esta en BD y se lo quiere quitar de la dependencia
                    else
                    {
                        //Guardo en una lista de int los que se van a eliminar
                        AgentesAQuitar.Add((int)GrillaAgentesLista.Rows[e.RowIndex].Cells["IdAgente"].Value);
                        //Agarro los indices para grisear los q se borrarán en BD
                        AgentesAQuitarIndex.Add(GrillaAgentesLista.Rows[e.RowIndex].Index);

                        //Regenero la grilla de agentes
                        GrillaAgentesLista.DataSource = null;
                        GrillaAgentesLista.DataSource = AgentesLista;
                        FormatearGrillaAgentes();
                        
                        
                    }
                    
                    
                    
                  
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AgentesAQuitar.Clear();
            AgentesAQuitarIndex.Clear();
            AgentesLista.Clear();
            AgentesNuevos.Clear();
            //Resguardo, lo levanto
            DepModif.unosAgentes = AgentesListaBKP.ToList();
            frmDependenciaModificar_Load(sender, new EventArgs());
            txtDependencia.Enabled = false;
            btnCandado.Image = ARTEC.GUI.Properties.Resources.CandadoDesb;
            txtAgente.Clear();
            unAgenSelect = null;
            
        }


        private void frmDependenciaModificar_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Para verificar si hay filas de la grilla por eliminar
            bool flagColorGris = false;
            foreach (int indice in AgentesAQuitarIndex)
            {
                if (GrillaAgentesLista.Rows[indice].DefaultCellStyle.BackColor == System.Drawing.Color.Gray)
                {
                    flagColorGris = true;
                    break;
                }
            }

            //Si hay cambios no persistidos consulta si desea salir sin guardar
            if (txtDependencia.Enabled || DepModif.unTipoDep.IdTipoDependencia != (cboTipoDep.SelectedItem as TipoDependencia).IdTipoDependencia
            || flagColorGris || AgentesNuevos != null && AgentesNuevos.Count > 0)
            {
                //VER: Grabar Msj en BD y utilizar servicioidioma.mostrarmensaje("").texto
                DialogResult resmbox = MessageBox.Show("Hay cambios no persistidos ¿Desea salir sin guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                e.Cancel = (resmbox == DialogResult.No);
            }
        }

        private void btnNuevoAgente_Click(object sender, EventArgs e)
        {
            frmAgenteCrear unfrmAgenteCrear = new frmAgenteCrear(DepModif.IdDependencia, DepModif.NombreDependencia);
            //CON ESTO hago que al cerrar el formulario del showdialog (frmAgenteCrear), 
            //voy a la funcion unfrmdependenciamodificar_formclosing y actualizo las dependencias desde la bd para ver el cambio realizado en el otro formulario
            unfrmAgenteCrear.FormClosing += unfrmAgenteCrear_FormClosing;
            unfrmAgenteCrear.ShowDialog();
        }

        private void unfrmAgenteCrear_FormClosing(object sender, FormClosingEventArgs e)
        {
            AgentesLista.Add(ManagerDependencia.TraerAgentesDependencia(DepModif.IdDependencia).Last());
            //Regenero la grilla de agentes, agregando a AgentesListaBKP el nuevo agente creado en la bd, para que si se hace click en cancelar, no lo quite de la grilla
            GrillaAgentesLista.DataSource = null;
            GrillaAgentesLista.DataSource = AgentesLista;
            AgentesListaBKP.Add(AgentesLista.Last());
            FormatearGrillaAgentes();
        }




        




    }
}