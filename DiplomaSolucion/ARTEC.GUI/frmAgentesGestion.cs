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
                        MessageBox.Show("El Agente ingresado no existe");
                        txtNombre.Clear();
                        txtApellido.Clear();
                        GrillaAgentes.DataSource = null;
                        txtCargo.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un Agente");
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
                MessageBox.Show("Ocurrio un error al buscar el agente, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!vldFrmAgentesGestion.Validate())
                return;

            try
            {
                unAgente.NombreAgente = txtNombre.Text;
                unAgente.ApellidoAgente = txtApellido.Text;

                if (ManagerAgente.AgenteModificar(unAgente))
                {
                    MessageBox.Show("Modificación realizada");
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmAgentesGestion - btnModificar_Click");
                MessageBox.Show("Ocurrio un error al intentar modificar el agente, por favor informe del error Nro " + IdError + " del Log de Eventos");
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



    }
}