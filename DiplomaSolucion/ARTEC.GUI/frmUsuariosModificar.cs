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
            //    MessageBox.Show("Ocurrio un error en el módulo de Usuarios, por favor informe del error Nro " + IdError + " del Log de Eventos");
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
            //Para quitarlo de disponibles al asignar un permiso
            //treeView1.Nodes.RemoveAt(1);

            //Utilizar la indexación para agregar un objeto de tipo permiso en PermisosVer a los permisos asignados del usuario
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
            Usuario unUsuario;

            try
            {
                if (!string.IsNullOrEmpty(txtNomUsBuscar.Text) && !string.IsNullOrWhiteSpace(txtNomUsBuscar.Text) && ManagerUsuario.UsuarioVerificarNomUs(txtNomUsBuscar.Text.ToLower()))
                {
                    unUsuario = ManagerUsuario.UsuarioTraerDatosPorNomUs(txtNomUsBuscar.Text.ToLower());
                    txtNomUs.Text = unUsuario.NombreUsuario;
                    txtPass.Text = "******";
                    txtNombre.Text = unUsuario.Nombre;
                    txtApellido.Text = unUsuario.Apellido;
                    txtMail.Text = unUsuario.Mail;
                    txtNomUsBuscar.Clear();

                    List<IFamPat> LisAuxAsig = new List<IFamPat>();
                    LisAuxAsig = ManagerUsuario.UsuarioTraerPermisos(unUsuario.IdUsuario);
                    List<IFamPat> LisAuxDisp = new List<IFamPat>();
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


    }
}