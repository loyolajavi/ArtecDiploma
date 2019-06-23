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
using ARTEC.BLL;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class frmAgentesGestion : DevComponents.DotNetBar.Metro.MetroForm
    {

        Agente unAgente;
        BLLAgente ManagerAgente = new BLLAgente();
        Cargo unCargoAsociado;

        public frmAgentesGestion()
        {
            InitializeComponent();

            Dictionary<string, string[]> dicfrmAgentesGestion = new Dictionary<string, string[]>();
            string[] IdiomafrmAgentesGestion = { "Gestión de Agentes" };
            dicfrmAgentesGestion.Add("Idioma", IdiomafrmAgentesGestion);
            this.Tag = dicfrmAgentesGestion;

            Dictionary<string, string[]> diclblAgenteBuscar = new Dictionary<string, string[]>();
            string[] IdiomalblAgenteBuscar = { "Agente" };
            diclblAgenteBuscar.Add("Idioma", IdiomalblAgenteBuscar);
            this.lblAgenteBuscar.Tag = diclblAgenteBuscar;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> diclblNombre = new Dictionary<string, string[]>();
            string[] IdiomalblNombre = { "Nombre" };
            diclblNombre.Add("Idioma", IdiomalblNombre);
            this.lblNombre.Tag = diclblNombre;

            Dictionary<string, string[]> diclblApellido = new Dictionary<string, string[]>();
            string[] IdiomalblApellido = { "Apellido" };
            diclblApellido.Add("Idioma", IdiomalblApellido);
            this.lblApellido.Tag = diclblApellido;

            Dictionary<string, string[]> diclblDependencia = new Dictionary<string, string[]>();
            string[] IdiomalblDependencia = { "Dependencia" };
            diclblDependencia.Add("Idioma", IdiomalblDependencia);
            this.lblDependencia.Tag = diclblDependencia;

            Dictionary<string, string[]> diclblCargo = new Dictionary<string, string[]>();
            string[] IdiomalblCargo = { "Cargo" };
            diclblCargo.Add("Idioma", IdiomalblCargo);
            this.lblCargo.Tag = diclblCargo;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            vldFrmAgentesGestion.ClearFailedValidations();

            try
            {
                unAgente = null;
                if (!string.IsNullOrEmpty(txtAgenteBuscar.Text) && !string.IsNullOrWhiteSpace(txtAgenteBuscar.Text))
                {
                    unAgente = ManagerAgente.AgenteBuscar(txtAgenteBuscar.Text);
                    if (unAgente != null && unAgente.IdAgente > 0)
                    {
                        txtNombre.Text = unAgente.NombreAgente;
                        txtApellido.Text = unAgente.ApellidoAgente;
                        GrillaAgentes.DataSource = null;
                        unAgente.UnasDependencias = ManagerAgente.AgenteTraerDependencias((int)unAgente.IdAgente);
                        GrillaAgentes.DataSource = unAgente.UnasDependencias;
                        GrillaAgentes.Columns["Activo"].Visible = false;
                        if (unAgente.UnasDependencias.Count > 0)
                        {
                            unCargoAsociado = ManagerAgente.AgenteTraerCargoPorDep(unAgente.UnasDependencias.First(), (int)unAgente.IdAgente);
                            txtCargo.Text = unCargoAsociado.DescripCargo;
                        }
                            

                        //if (unaCategoria.Activo == 0)
                        //{
                        //    lblBaja.Visible = true;
                        //    btnReactivar.Enabled = true;
                        //    btnModificar.Enabled = false;
                        //    btnEliminar.Enabled = false;
                        //    btnAgregar.Enabled = false;
                        //    txtCategoria.Enabled = false;
                        //    cboProveedor.Enabled = false;
                        //    cboTipo.Enabled = false;
                        //    GrillaAgentes.Enabled = false;
                        //}
                        //else
                        //{
                        //    lblBaja.Visible = false;
                        //    btnReactivar.Enabled = false;
                        //    btnModificar.Enabled = true;
                        //    btnEliminar.Enabled = true;
                        //    btnAgregar.Enabled = true;
                        //    txtCategoria.Enabled = true;
                        //    cboProveedor.Enabled = true;
                        //    cboTipo.Enabled = true;
                        //    GrillaAgentes.Enabled = true;
                        //}

                        //ProvsAgregar.Clear();
                        //ProvsAgregar = ManagerCategoria.CategoriaTraerProveedores(unaCategoria.IdCategoria);
                        //ProvsAgregarBKP = ProvsAgregar.ToList();

                        //GrillaAgentes.DataSource = null;
                        //GrillaAgentes.DataSource = ProvsAgregar;
                        //btnCrearCategoria.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El Agente ingresado no existe").Texto);
                        txtNombre.Clear();
                        txtApellido.Clear();
                        GrillaAgentes.DataSource = null;
                        txtCargo.Clear();
                    }
                }
                else
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor ingrese un Agente").Texto);
                    txtNombre.Clear();
                    txtApellido.Clear();
                    GrillaAgentes.DataSource = null;
                    txtCargo.Clear();
                }
            }
            catch (FormatException esr)
            {
                MessageBox.Show(esr.Message);
                string IdError = ServicioLog.CrearLog(esr, "frmAgentesGestion - btnBuscar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al buscar el agente, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (unAgente == null || string.IsNullOrEmpty(unAgente.NombreAgente))
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor busque un agente").Texto);
                    return;
                }
                    

                if (!vldFrmAgentesGestion.Validate())
                    return;

                unAgente.NombreAgente = txtNombre.Text;
                unAgente.ApellidoAgente = txtApellido.Text;

                ManagerAgente.AgenteModificar(unAgente);
                ServicioLog.CrearLog(BLLServicioIdioma.MostrarMensaje("Modificar Agente").Texto, BLLServicioIdioma.MostrarMensaje("Agente").Texto + " " + unAgente.NombreAgente + " " + unAgente.ApellidoAgente);
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAgentesGestion - btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar el agente, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void GrillaAgentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                unCargoAsociado = ManagerAgente.AgenteTraerCargoPorDep(unAgente.UnasDependencias[e.RowIndex], (int)unAgente.IdAgente);
                txtCargo.Text = unCargoAsociado.DescripCargo;
            }
        }

        private void frmAgentesGestion_Load(object sender, EventArgs e)
        {
            try
            {
                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                //Idioma
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAgentesGestion - frmAgentesGestion_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar iniciar la modificación de Agentes, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void frmAgentesGestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Help.ShowHelp(this, "Artec - Manual de Ayuda.chm", HelpNavigator.KeywordIndex);
        }



    }
}