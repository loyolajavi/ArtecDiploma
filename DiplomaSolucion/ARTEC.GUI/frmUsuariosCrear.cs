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
    public partial class frmUsuariosCrear : DevComponents.DotNetBar.Metro.MetroForm
    {

        BLLFamilia ManagerFamilia = new BLLFamilia();
        List<IFamPat> LisAuxAsig;
        List<IFamPat> LisAuxDisp;
        List<IFamPat> LisAuxAsigBKP = new List<IFamPat>();
        BLLUsuario ManagerUsuario = new BLLUsuario();
        Usuario unUsuario;

        public frmUsuariosCrear()
        {
            InitializeComponent();
        }

        private void frmUsuariosCrear_Load(object sender, EventArgs e)
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
                
                LisAuxDisp = new List<IFamPat>();
                LisAuxDisp = ManagerFamilia.PermisosTraerTodos();
                LisAuxAsig = new List<IFamPat>();
                ListarPermisos(LisAuxDisp, treeDisponibles); 

            }
            catch (Exception)
            {
                
                throw;
            }

            
            
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (!vldfrmUsuarioCrear.Validate())
                return;

            try
            {   
                //Verificar que quede al menos un permiso asignado
                if (LisAuxAsig.Count == 0)
                {
                    MessageBox.Show("Por favor revisar que el usuario posea al menos un permiso asignado");
                    return;
                }

                //Verificar que no existe el nombre de usuario ingresado
                if (!ManagerUsuario.UsuarioVerificarNomUs(txtNomUs.Text)){
                    //Crear el Usuario
                    unUsuario = new Usuario();
                    unUsuario.NombreUsuario = txtNomUs.Text;
                    unUsuario.Pass = ServicioSecurizacion.Encriptar(ServicioSecurizacion.AplicarHash(txtPass.Text));
                    unUsuario.Nombre = txtNombre.Text;
                    unUsuario.Apellido = txtApellido.Text;
                    unUsuario.Mail = txtMail.Text;
                    unUsuario.Permisos = LisAuxAsig;
                    unUsuario.IdiomaUsuarioActual = Idioma.unIdiomaActual;
                    if(ManagerUsuario.UsuarioCrear(unUsuario))
                        MessageBox.Show("Usuario creado correctamente");
                }
                else
                {
                    MessageBox.Show("Ya existe el nombre de usuario ingresado, por favor modifíquelo");
                    return;
                }

            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnCrearUsuario_Click");
                MessageBox.Show("Ocurrio un error en la creación del usuario, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
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



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (treeDisponibles.SelectedNode == null || treeDisponibles.SelectedNode.Parent != null)
                MessageBox.Show("Por favor seleccione la Familia que contiene el permiso selecionado o la patente requerida en forma directa");
            else
            {
                LisAuxAsig.Add(LisAuxDisp[treeDisponibles.SelectedNode.Index]);
                LisAuxDisp = ManagerFamilia.PermisosTraerTodos();
                FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
                ListarPermisos(LisAuxDisp, treeDisponibles);
                ListarPermisos(LisAuxAsig, treeAsignados);
            }
        }


        public void FiltrarDisponibles(ref List<IFamPat> PerDisp, List<IFamPat> PerAsig)
        {
            PerDisp = PerDisp.Where(d => !PerAsig.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();

            foreach (IFamPat item in PerAsig)
            {
                if (item.CantHijos > 0)
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (treeAsignados.SelectedNode == null || treeAsignados.SelectedNode.Parent != null)
                MessageBox.Show("Por favor seleccione la Familia que contiene el permiso seleccionado o la patente a eliminar en forma directa");
            else
            {
                LisAuxAsig.RemoveAt(treeAsignados.SelectedNode.Index);
                LisAuxDisp = ManagerFamilia.PermisosTraerTodos();
                FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
                ListarPermisos(LisAuxDisp, treeDisponibles);
                ListarPermisos(LisAuxAsig, treeAsignados);
            }
        }




    }
}