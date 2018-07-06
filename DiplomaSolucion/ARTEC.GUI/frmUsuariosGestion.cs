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

namespace ARTEC.GUI
{
    public partial class frmUsuariosGestion : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmUsuariosGestion()
        {
            InitializeComponent();
        }

        private void frmUsuariosGestion_Load(object sender, EventArgs e)
        {
            ListarPermisos(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos);
        }



        public void ListarPermisos(List<IFamPat> PermisosVer)
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
                treeView1.Nodes.Add(treeNode);
            }

            //Para quitarlo de disponibles al asignar un permiso
            //treeView1.Nodes.RemoveAt(1);

            //Utilizar la indexación para agregar un objeto de tipo permiso en PermisosVer a los permisos asignados del usuario

        }



    }
}