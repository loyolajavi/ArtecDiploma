using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class frmUsuariosModificar : DevComponents.DotNetBar.Metro.MetroForm
    {

        BLLFamilia ManagerFamilia = new BLLFamilia();
        List<IFamPat> LisAuxAsig;
        List<IFamPat> LisAuxDisp;
        //List<IFamPat> PerAgregados = new List<IFamPat>();
        //List<IFamPat> PerQuitados = new List<IFamPat>();
        List<IFamPat> LisAuxAsigBKP = new List<IFamPat>();
        BLLUsuario ManagerUsuario = new BLLUsuario();
        Usuario unUsuario;

        public frmUsuariosModificar()
        {
            InitializeComponent();
        }

        private void frmUsuariosGestion_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    ListarPermisosDisponibles(ManagerFamilia.PermisosTraerTodos());
            //    ListarPermisosAsignados(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos);
            //}
            //catch (Exception es)
            //{
            //    string IdError = ServicioLog.CrearLog(es, "frmUsuariosGestion_Load");
            //    MessageBox.Show("Ocurrio un error en el m�dulo de Usuarios, por favor informe del error Nro " + IdError + " del Log de Eventos");
            //    this.Close();
            //}
            
        }

      
        public void ListarPermisos(List<IFamPat> PermisosVer, TreeView treePermisos)
        {
            treePermisos.Nodes.Clear();
            foreach (IFamPat item in PermisosVer)
            {
                TreeNode Padre = new TreeNode();
                Padre.Text = item.GetType().Name.ToString() + ": " + item.NombreIFamPat;
                Padre.Expand();
                treePermisos.Nodes.Add(Padre);
                if (item.CantHijos > 0)
                    ListarYAgregarSubPermisos((item as Familia).ElementosFamPat, Padre);
            }
        }


        public void ListarYAgregarSubPermisos(List<IFamPat> PermisosVer, TreeNode elNodo = null)
        {
            int I = 0;

            do
            {
                TreeNode NodoHijo = null;
                if (elNodo == null)
                {
                    elNodo = new TreeNode();
                    elNodo.Text = PermisosVer[I].GetType().Name.ToString() + ": " + PermisosVer[I].NombreIFamPat;
                }
                else
                {
                    NodoHijo = new TreeNode(PermisosVer[I].GetType().Name.ToString() + ": " + PermisosVer[I].NombreIFamPat);
                    NodoHijo.Collapse();
                    elNodo.Nodes.Add(NodoHijo);
                }
                if (PermisosVer[I].CantHijos > 0)
                    ListarYAgregarSubPermisos((PermisosVer[I] as Familia).ElementosFamPat, NodoHijo);
                I++;
            } while (I < PermisosVer.Count);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BLLUsuario ManagerUsuario = new BLLUsuario();

            try
            {
                vldNomUs.ClearFailedValidations();

                if (!string.IsNullOrEmpty(txtNomUsBuscar.Text) && !string.IsNullOrWhiteSpace(txtNomUsBuscar.Text) && ManagerUsuario.UsuarioVerificarNomUs(txtNomUsBuscar.Text.ToLower()))
                {
                    unUsuario = ManagerUsuario.UsuarioTraerDatosPorNomUs(txtNomUsBuscar.Text.ToLower());
                    txtNomUs.Text = unUsuario.NombreUsuario;
                    txtPass.Text = "******";
                    txtNombre.Text = unUsuario.Nombre;
                    txtApellido.Text = unUsuario.Apellido;
                    txtMail.Text = unUsuario.Mail;
                    txtNomUsBuscar.Clear();

                    LisAuxAsig = new List<IFamPat>();
                    LisAuxAsig = ManagerUsuario.UsuarioTraerPermisos(unUsuario.IdUsuario);
                    LisAuxAsigBKP = LisAuxAsig.ToList();
                    LisAuxDisp = new List<IFamPat>();
                    LisAuxDisp = ManagerFamilia.PermisosTraerTodos();

                    FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);

                    ListarPermisos(LisAuxDisp, treeDisponibles); 
                    ListarPermisos(LisAuxAsig, treeAsignados); 
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ingresado no existe");
                    txtNomUs.Clear();
                    txtPass.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtMail.Clear();
                    txtNomUsBuscar.Clear();
                    unUsuario = null;
                    treeAsignados.Nodes.Clear();
                    treeDisponibles.Nodes.Clear();
                }
                    
                    
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnBuscar_Click");
                MessageBox.Show("Ocurrio un error al buscar el Nombre de Usuario, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
            
        }


        public void FiltrarDisponibles(ref List<IFamPat> PerDisp, List<IFamPat> PerAsig)
        {
            PerDisp = PerDisp.Where(d => !PerAsig.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();

            foreach (IFamPat item in PerAsig)
            {
                if(item.CantHijos > 0)
                    FiltrarSubpermisos(item as Familia, ref PerDisp);
            }
        }


        public void FiltrarSubpermisos(Familia fam, ref List<IFamPat> disp)
        {
            disp = disp.Where(d => !fam.ElementosFamPat.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();
            foreach (IFamPat item in fam.ElementosFamPat)
	        {
                if (item.CantHijos > 0)
                    FiltrarSubpermisos(item as Familia, ref disp);
	        } 
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (treeDisponibles.SelectedNode == null || treeDisponibles.SelectedNode.Parent != null)
                MessageBox.Show("Por favor seleccione la Familia que contiene el permiso selecionado o la patente requerida en forma directa");
            else
            {
                LisAuxAsig.Add(LisAuxDisp[treeDisponibles.SelectedNode.Index]);
                //PerAgregados.Add(LisAuxDisp[treeDisponibles.SelectedNode.Index]);
                //LisAuxDisp.RemoveAt(treeDisponibles.SelectedNode.Index);

                LisAuxDisp = ManagerFamilia.PermisosTraerTodos();
                FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig); 
                ListarPermisos(LisAuxDisp, treeDisponibles);
                ListarPermisos(LisAuxAsig, treeAsignados); 
            }
        }



        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (treeAsignados.SelectedNode == null || treeAsignados.SelectedNode.Parent != null)
                MessageBox.Show("Por favor seleccione la Familia que contiene el permiso seleccionado o la patente a eliminar en forma directa");
            else
            {
                //LisAuxDisp.Add(LisAuxAsig[treeAsignados.SelectedNode.Index]);
                //PerQuitados.Add(LisAuxAsig[treeAsignados.SelectedNode.Index]);
                LisAuxAsig.RemoveAt(treeAsignados.SelectedNode.Index);

                LisAuxDisp = ManagerFamilia.PermisosTraerTodos();
                FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig); 
                ListarPermisos(LisAuxDisp, treeDisponibles);
                ListarPermisos(LisAuxAsig, treeAsignados);
            }

        }

        private void btnModifUsuario_Click(object sender, EventArgs e)
        {
            List<IFamPat> PerQuitar = new List<IFamPat>();
            List<IFamPat> PerAgregar = new List<IFamPat>();

            if (!vldNomUs.Validate())
                return;

                try
                {
                    //Verificar que quede al menos un permiso asignado
                    if (LisAuxAsig.Count == 0)
                    {
                        MessageBox.Show("Por favor revisar que el usuario posea al menos un permiso asignado");
                        return;
                    }
                    //NombreUsuario
                    if (unUsuario.NombreUsuario != txtNomUs.Text)
                    {
                        DialogResult resmbox = MessageBox.Show("�Est� seguro que desea modificar el Nombre de Usuario utilizado para ingresar al sistema?", "Advertencia", MessageBoxButtons.YesNo);
                        if (resmbox == DialogResult.Yes)
                        {
                            //Verificar que no existe el nombre de usuario ingresado
                            if (!ManagerUsuario.UsuarioVerificarNomUs(txtNomUs.Text))
                                //Modificar NomUs
                                ManagerUsuario.UsuarioModificarNomUs(unUsuario.IdUsuario, txtNomUs.Text);
                            else
                            {
                                MessageBox.Show("Ya existe el nombre de usuario ingresado, por favor modif�quelo");
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (txtPass.Text != "******")
                    {
                        DialogResult resmbox = MessageBox.Show("�Est� seguro que desea modificar la contrase�a del Usuario?", "Advertencia", MessageBoxButtons.YesNo);
                        if (resmbox == DialogResult.Yes)
                            ManagerUsuario.UsuarioModificarPass(unUsuario.IdUsuario, ServicioSecurizacion.AplicarHash(txtPass.Text));
                        else
                            return;
                    }

                    //Datos basicos
                    if (unUsuario.Nombre != txtNombre.Text)
                        ManagerUsuario.UsuarioModificarNombre(unUsuario.IdUsuario, txtNombre.Text);
                    if (unUsuario.Apellido != txtApellido.Text)
                        ManagerUsuario.UsuarioModificarApellido(unUsuario.IdUsuario, txtApellido.Text);
                    if (unUsuario.Mail != txtMail.Text)
                        ManagerUsuario.UsuarioModificarMail(unUsuario.IdUsuario, txtMail.Text);

                    //Permisos
                    PerQuitar = LisAuxAsigBKP.Where(d => !LisAuxAsig.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();
                    PerAgregar = LisAuxAsig.Where(d => !LisAuxAsigBKP.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();
                    if (ManagerUsuario.UsuarioModificarPermisos(PerAgregar, PerQuitar, unUsuario.IdUsuario))
                        MessageBox.Show("Modificaci�n realizada");
                }
                catch (Exception es)
                {
                    string IdError = ServicioLog.CrearLog(es, "btnModifUsuario_Click");
                    MessageBox.Show("Ocurrio un error al modificar los datos del usuario, por favor informe del error Nro " + IdError + " del Log de Eventos");
                }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            frmUsuariosCrear unFrmUsuariosCrear = new frmUsuariosCrear();
            unFrmUsuariosCrear.ShowDialog();
        }


    }
}