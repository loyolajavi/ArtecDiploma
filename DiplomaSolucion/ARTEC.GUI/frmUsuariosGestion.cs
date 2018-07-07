using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.BLL;
using ARTEC.BLL.Servicios;
using ARTEC.FRAMEWORK.Servicios;

namespace ARTEC.GUI
{
    public partial class frmUsuariosGestion : DevComponents.DotNetBar.Metro.MetroForm
    {

        BLLFamilia ManagerFamilia = new BLLFamilia();

        public frmUsuariosGestion()
        {
            InitializeComponent();
        }

        private void frmUsuariosGestion_Load(object sender, EventArgs e)
        {
            try
            {
                ListarPermisosDisponibles(ManagerFamilia.PermisosTraerTodos());
                ListarPermisosAsignados(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmUsuariosGestion_Load");
                MessageBox.Show("Ocurrio un error en el módulo de Usuarios, por favor informe del error Nro " + IdError + " del Log de Eventos");
                this.Close();
            }
            
        }



        public void ListarPermisosAsignados(List<IFamPat> PermisosVer)
        {
            foreach (IFamPat unPermiso in PermisosVer)
            {
                TreeNode NodoAsignados = new TreeNode(unPermiso.GetType().Name.ToString() + ": " + unPermiso.NombreIFamPat);

                if (unPermiso.CantHijos > 0)
                {
                    TreeNode[] array = new TreeNode[(unPermiso as Familia).CantHijos];
                    for (int i = 0; i < (unPermiso as Familia).CantHijos; i++)
                    {
                        TreeNode unNodeAsig = new TreeNode((unPermiso as Familia).ElementosFamPat[i].GetType().Name.ToString() + ": " + (unPermiso as Familia).ElementosFamPat[i].NombreIFamPat);
                        NodoAsignados.Nodes.Add(unNodeAsig);
                    }
                }
                treeAsignados.Nodes.Add(NodoAsignados);
            }

            //Para quitarlo de disponibles al asignar un permiso
            //treeView1.Nodes.RemoveAt(1);

            //Utilizar la indexación para agregar un objeto de tipo permiso en PermisosVer a los permisos asignados del usuario

        }

        public void ListarPermisosDisponibles(List<IFamPat> PermisosVer)
        {
            foreach (IFamPat unPermiso in PermisosVer)
            {
                TreeNode treeNode = new TreeNode(unPermiso.GetType().Name.ToString() + ": " + unPermiso.NombreIFamPat);

                if (unPermiso.CantHijos > 0)
                {
                    TreeNode[] array = new TreeNode[(unPermiso as Familia).CantHijos];
                    for (int i = 0; i < (unPermiso as Familia).CantHijos; i++)
                    {
                        TreeNode unNode = new TreeNode((unPermiso as Familia).ElementosFamPat[i].GetType().Name.ToString() + ": " + (unPermiso as Familia).ElementosFamPat[i].NombreIFamPat);
                        treeNode.Nodes.Add(unNode);
                    }
                }
                treeDisponibles.Nodes.Add(treeNode);
            }

            //Para quitarlo de disponibles al asignar un permiso
            //treeView1.Nodes.RemoveAt(1);

            //Utilizar la indexación para agregar un objeto de tipo permiso en PermisosVer a los permisos asignados del usuario

        }

        private void treePermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }



    }
}