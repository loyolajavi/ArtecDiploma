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
    public partial class frmFamiliaGestion : DevComponents.DotNetBar.Metro.MetroForm
    {
        BLLFamilia ManagerFamilia = new BLLFamilia();
        List<IFamPat> PermisosTodos = new List<IFamPat>();
        List<IFamPat> PermisosCbo = new List<IFamPat>();
        List<IFamPat> LisAuxAsig;
        List<IFamPat> LisAuxDisp;
        List<IFamPat> LisAuxAsigBKP = new List<IFamPat>();

        public frmFamiliaGestion()
        {
            InitializeComponent();
        }

        private void frmFamiliaGestion_Load(object sender, EventArgs e)
        {
            try
            {
                PermisosTodos = ManagerFamilia.PermisosTraerTodos();
                PermisosCbo = PermisosTodos.Where(X=>X.CantHijos > 0).ToList();
                Familia FamAux = new Familia();
                FamAux.IdIFamPat = -1;
                FamAux.NombreIFamPat = "";
                PermisosCbo.Insert(0, FamAux);
                cboFamilia.DataSource = null;
                cboFamilia.DataSource = PermisosCbo;
                cboFamilia.DisplayMember = "NombreIFamPat";
                cboFamilia.ValueMember = "IdIFamPat";
                
                LisAuxDisp = PermisosTodos.ToList();
                LisAuxAsig = new List<IFamPat>();
                ListarPermisos(PermisosTodos, treeTodos);
                ListarPermisos(LisAuxDisp, treeDisponibles);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmFamiliaGestion - frmFamiliaGestion_Load");
                MessageBox.Show("Ocurrio un error al cargar la pantalla de Familias, por favor informe del error Nro " + IdError + " del Log de Eventos");    
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

        private void cboFamilia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LisAuxAsig = new List<IFamPat>();
            LisAuxAsig = (cboFamilia.SelectedItem as Familia).ElementosFamPat.Where(x=>x.IdIFamPat > 0).ToList();
            //LisAuxAsig.Add(cboFamilia.SelectedItem as Familia);
            LisAuxAsigBKP = LisAuxAsig.ToList();
            LisAuxDisp = new List<IFamPat>();
            LisAuxDisp = PermisosTodos.ToList();
            //FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
            FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
            LisAuxDisp.Remove(cboFamilia.SelectedItem as Familia);
            ListarPermisos(LisAuxAsig, treeAsignados);
            ListarPermisos(LisAuxDisp, treeDisponibles);
            if ((cboFamilia.SelectedItem as Familia).IdIFamPat > 0)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                txtNombre.Text = (cboFamilia.SelectedItem as Familia).NombreIFamPat;
                txtNombre.ReadOnly = false;
            }
            else
            {
                btnCrear.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtNombre.Clear();
                txtNombre.ReadOnly = true;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (treeDisponibles.SelectedNode == null || treeDisponibles.SelectedNode.Parent != null)
                MessageBox.Show("Por favor seleccione la Familia que contiene el permiso selecionado o la patente requerida en forma directa");
            else
            {
                LisAuxAsig.Add(LisAuxDisp[treeDisponibles.SelectedNode.Index]);

                LisAuxDisp = PermisosTodos.ToList();
                //FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
                //ListarPermisos(LisAuxDisp, treeDisponibles);
                //ListarPermisos(LisAuxAsig, treeAsignados);
                FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
                LisAuxDisp.Remove(cboFamilia.SelectedItem as Familia);
                ListarPermisos(LisAuxAsig, treeAsignados);
                ListarPermisos(LisAuxDisp, treeDisponibles); 

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (treeAsignados.SelectedNode == null || treeAsignados.SelectedNode.Parent != null)
                MessageBox.Show("Por favor seleccione la Familia que contiene el permiso seleccionado o la patente a eliminar en forma directa");
            else
            {
                //LisAuxAsig.RemoveAt(treeAsignados.SelectedNode.Index);
                LisAuxAsig.RemoveAt(treeAsignados.SelectedNode.Index);

                LisAuxDisp = PermisosTodos.ToList();
                //FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
                //ListarPermisos(LisAuxDisp, treeDisponibles);
                //ListarPermisos((LisAuxAsig.First() as Familia).ElementosFamPat, treeAsignados);
                FiltrarDisponibles(ref LisAuxDisp, LisAuxAsig);
                LisAuxDisp.Remove(cboFamilia.SelectedItem as Familia);
                ListarPermisos(LisAuxAsig, treeAsignados);
                ListarPermisos(LisAuxDisp, treeDisponibles); 
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            IFamPat nuevaFamilia = new Familia();

            if (!vldFrmFamiliaGestion.Validate())
                return;

            //Verificar que quede al menos un permiso asignado
            if (LisAuxAsig.Count == 0)
            {
                MessageBox.Show("Por favor revisar que la Familia a crear posea al menos un permiso asignado");
                return;
            }

            try
            {
                //FamiliaBuscar en BD lo reemplazo por una consulta en Linq
                if(PermisosTodos.Any(X=>X.NombreIFamPat.ToLower() == txtNombre.Text.ToLower()))
                {
                    MessageBox.Show("La Familia ingresada ya existe");
                    return;
                }

                nuevaFamilia.NombreIFamPat = txtNombre.Text;
                (nuevaFamilia as Familia).ElementosFamPat = LisAuxAsig;

                if (ManagerFamilia.FamiliaCrear(nuevaFamilia))
                {
                    MessageBox.Show("Familia creada correctamente");

                    PermisosTodos = ManagerFamilia.PermisosTraerTodos();
                    PermisosCbo = PermisosTodos.Where(X => X.CantHijos > 0).ToList();
                    Familia FamAux = new Familia();
                    FamAux.IdIFamPat = -1;
                    FamAux.NombreIFamPat = "";
                    PermisosCbo.Insert(0, FamAux);
                    cboFamilia.DataSource = null;
                    cboFamilia.DataSource = PermisosCbo;
                    cboFamilia.DisplayMember = "NombreIFamPat";
                    cboFamilia.ValueMember = "IdIFamPat";
                    ListarPermisos(PermisosTodos, treeTodos);
                    txtNombre.Clear();
                    cboFamilia.SelectedItem = cboFamilia.Items[cboFamilia.Items.Count - 1];
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmFamiliaGestion - btnCrear_Click");
                MessageBox.Show("Ocurrio un error al intentar crear una Familia, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            IFamPat AModifFamilia = new Familia();
            List<IFamPat> FamQuitarMod = new List<IFamPat>();
            List<IFamPat> FamAgregarMod = new List<IFamPat>();

            if (!vldFrmFamiliaGestion.Validate())
                return;

            //Verificar que quede al menos un permiso asignado
            if (LisAuxAsig.Count == 0)
            {
                MessageBox.Show("Por favor revisar que la Familia a crear posea al menos un permiso asignado");
                return;
            }

            try
            {
                //Verificar que no existe una Familia con el nombre ingresado en la modificacion
                Familia FamAux2 = null;
                if ((cboFamilia.SelectedItem as Familia).NombreIFamPat != txtNombre.Text)
                    FamAux2 = ManagerFamilia.FamiliaBuscar(txtNombre.Text);
                if (FamAux2 != null && FamAux2.IdIFamPat > 0)
                {
                    MessageBox.Show("La Familia ingresada ya existe");
                    return;
                }

                AModifFamilia.IdIFamPat = (cboFamilia.SelectedItem as Familia).IdIFamPat;
                AModifFamilia.NombreIFamPat = txtNombre.Text;

                FamQuitarMod = LisAuxAsigBKP.Where(d => !LisAuxAsig.Any(a => a.IdIFamPat == d.IdIFamPat)).ToList();
                FamAgregarMod = LisAuxAsig.Where(d => !LisAuxAsigBKP.Any(a => a.IdIFamPat == d.IdIFamPat)).ToList();

                if (ManagerFamilia.FamiliaModificar(AModifFamilia, FamQuitarMod, FamAgregarMod))
                {
                    int Seleccionado = cboFamilia.SelectedIndex;
                    PermisosTodos = ManagerFamilia.PermisosTraerTodos();
                    PermisosCbo = PermisosTodos.Where(X => X.CantHijos > 0).ToList();
                    Familia FamAux = new Familia();
                    FamAux.IdIFamPat = -1;
                    FamAux.NombreIFamPat = "";
                    PermisosCbo.Insert(0, FamAux);
                    cboFamilia.DataSource = null;
                    cboFamilia.DataSource = PermisosCbo;
                    cboFamilia.DisplayMember = "NombreIFamPat";
                    cboFamilia.ValueMember = "IdIFamPat";
                    ListarPermisos(PermisosTodos, treeTodos);
                    cboFamilia.SelectedIndex = Seleccionado;
                    LisAuxAsigBKP = LisAuxAsig.ToList();
                    MessageBox.Show("Modificación realizada");
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmFamiliaGestion - btnModificar_Click");
                MessageBox.Show("Ocurrio un error al intentar modificar la Familia, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cboFamilia.SelectedItem as Familia).IdIFamPat > 0)
                {
                    DialogResult resmbox;
                    List<Usuario> UsuariosComprometidos = new List<Usuario>();
                    UsuariosComprometidos = ManagerFamilia.FamiliaUsuariosComprometidos((cboFamilia.SelectedItem as Familia).IdIFamPat);
                    if (UsuariosComprometidos.Count > 0)
                    {
                        List<string> LisUs = new List<string>();
                        foreach (Usuario unUs in UsuariosComprometidos)
	                    {
		                    LisUs.Add(unUs.NombreUsuario);
	                    }
                        string UsuariosCompString = string.Join(Environment.NewLine, LisUs);
                        resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Familia: " + (cboFamilia.SelectedItem as Familia).NombreIFamPat + "?" + "\n" + "Se deberán modificar los permisos de los siguientes usuarios: \n" + UsuariosCompString, "Advertencia", MessageBoxButtons.YesNo);
                        //Abrir ventana de modificación permisos usuarios comprometidos
                    }
                    else
                    {
                        resmbox = MessageBox.Show("¿Está seguro que desea dar de baja la Familia: " + (cboFamilia.SelectedItem as Familia).NombreIFamPat + "?", "Advertencia", MessageBoxButtons.YesNo);
                    }
                    
                    if (resmbox == DialogResult.Yes)
                    {

                        if (ManagerFamilia.FamiliaEliminar((cboFamilia.SelectedItem as Familia)))
                        {
                            //lblBaja.Visible = true;
                            //btnReactivar.Enabled = true;
                            //btnEliminar.Enabled = false;
                            //btnModificar.Enabled = false;
                            //btnCrearCategoria.Enabled = false;
                            //btnAgregar.Enabled = false;
                            //txtCategoria.Enabled = false;
                            //cboProveedor.Enabled = false;
                            //cboTipo.Enabled = false;
                            //GrillaProveedores.Enabled = false;
                            //MessageBox.Show("Categoría: " + unaCategoria.DescripCategoria + " dada de baja correctamente");
                        }
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Para dar de baja una Familia primero debe seleccionar una de la lista");
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmFamiliaGestion - btnEliminar_Click");
                MessageBox.Show("Ocurrio un error al intentar eliminar la Familia, por favor informe del error Nro " + IdError + " del Log de Eventos");
            }
        }




    }
}