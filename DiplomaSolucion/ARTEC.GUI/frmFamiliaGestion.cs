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

            Dictionary<string, string[]> dicfrmFamiliaGestion = new Dictionary<string, string[]>();
            string[] IdiomafrmFamiliaGestion = { "Gestión de Familias" };
            dicfrmFamiliaGestion.Add("Idioma", IdiomafrmFamiliaGestion);
            this.Tag = dicfrmFamiliaGestion;

            Dictionary<string, string[]> diclblFamiliaBuscar = new Dictionary<string, string[]>();
            string[] IdiomalblFamiliaBuscar = { "Familia" };
            diclblFamiliaBuscar.Add("Idioma", IdiomalblFamiliaBuscar);
            this.lblFamiliaBuscar.Tag = diclblFamiliaBuscar;

            Dictionary<string, string[]> diclblNombre = new Dictionary<string, string[]>();
            string[] IdiomalblNombre = { "Nombre" };
            diclblNombre.Add("Idioma", IdiomalblNombre);
            this.lblNombre.Tag = diclblNombre;

            Dictionary<string, string[]> dicpnlPermisos = new Dictionary<string, string[]>();
            string[] IdiomapnlPermisos = { "Permisos" };
            dicpnlPermisos.Add("Idioma", IdiomapnlPermisos);
            this.pnlPermisos.Tag = dicpnlPermisos;

            Dictionary<string, string[]> diclblDisponibles = new Dictionary<string, string[]>();
            string[] IdiomalblDisponibles = { "Disponibles" };
            diclblDisponibles.Add("Idioma", IdiomalblDisponibles);
            this.lblDisponibles.Tag = diclblDisponibles;

            Dictionary<string, string[]> diclblAsignados = new Dictionary<string, string[]>();
            string[] IdiomalblAsignados = { "Asignados" };
            diclblAsignados.Add("Idioma", IdiomalblAsignados);
            this.lblAsignados.Tag = diclblAsignados;

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;

            Dictionary<string, string[]> dicbtnQuitar = new Dictionary<string, string[]>();
            string[] IdiomabtnQuitar = { "Quitar" };
            dicbtnQuitar.Add("Idioma", IdiomabtnQuitar);
            this.btnQuitar.Tag = dicbtnQuitar;

            Dictionary<string, string[]> dicbtnCrear = new Dictionary<string, string[]>();
            string[] IdiomabtnCrear = { "Crear" };
            dicbtnCrear.Add("Idioma", IdiomabtnCrear);
            this.btnCrear.Tag = dicbtnCrear;

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

            Dictionary<string, string[]> diclblPermisosTodos = new Dictionary<string, string[]>();
            string[] IdiomalblPermisosTodos = { "Detalle de permisos" }; diclblPermisosTodos.Add("Idioma", IdiomalblPermisosTodos);
            this.lblPermisosTodos.Tag = diclblPermisosTodos;

        }

        private void frmFamiliaGestion_Load(object sender, EventArgs e)
        {
            try
            {
                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);


                //Permisos
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                    {
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                    }
                }

                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                

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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al cargar la pantalla de Familias, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);    
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
                btnAgregar.Enabled = true;
                btnQuitar.Enabled = true;
            }
            else
            {
                btnCrear.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtNombre.Clear();
                txtNombre.ReadOnly = true;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor seleccione la Familia que contiene el permiso seleccionado o la patente requerida en forma directa").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor seleccione la Familia que contiene el permiso seleccionado o la patente a eliminar en forma directa").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revisar que la Familia a crear posea al menos una patente asignada").Texto);
                return;
            }

            if (LisAuxAsig.Count == 1 && LisAuxAsig.First().CantHijos > 0)
            {
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Familia a crear no puede contener solamente una familia").Texto
);
                return;
            }

            try
            {
                //FamiliaBuscar en BD lo reemplazo por una consulta en Linq
                if(PermisosTodos.Any(X=>X.NombreIFamPat.ToLower() == txtNombre.Text.ToLower()))
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Familia ingresada ya existe").Texto);
                    return;
                }

                nuevaFamilia.NombreIFamPat = txtNombre.Text;
                (nuevaFamilia as Familia).ElementosFamPat = LisAuxAsig;

                if (ManagerFamilia.FamiliaCrear(nuevaFamilia))
                {
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Familia creada correctamente").Texto);

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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar crear una Familia, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revisar que la Familia posea al menos una patente asignada").Texto);
                return;
            }

            if (LisAuxAsig.Count == 1 && LisAuxAsig.First().CantHijos > 0)
            {
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Familia no puede contener solamente una familia").Texto);
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("La Familia ingresada ya existe").Texto);
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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada").Texto);
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmFamiliaGestion - btnModificar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar modificar la Familia, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BLLUsuario ManagerUsuario = new BLLUsuario();
            List<IFamPat> PerAgregar = new List<IFamPat>();
            List<IFamPat> PerQuitar = new List<IFamPat>();
            List<Usuario> UsuariosComprometidos = new List<Usuario>();
            List<Usuario> UsuariosConFamiliaAEliminar = new List<Usuario>();

            try
            {
                if ((cboFamilia.SelectedItem as Familia).IdIFamPat > 0)
                {
                    DialogResult resmbox;
                    UsuariosConFamiliaAEliminar = ManagerFamilia.FamiliaUsuariosAsociados((cboFamilia.SelectedItem as Familia).IdIFamPat);
                    UsuariosComprometidos = ManagerFamilia.FamiliaUsuariosComprometidos((cboFamilia.SelectedItem as Familia).IdIFamPat);
                    if (UsuariosComprometidos.Count > 0)
                    {
                        List<string> LisUs = new List<string>();
                        foreach (Usuario unUs in UsuariosComprometidos)
	                    {
		                    LisUs.Add(unUs.NombreUsuario);
	                    }
                        string UsuariosCompString = string.Join(Environment.NewLine, LisUs);
                        resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja la Familia: ").Texto + (cboFamilia.SelectedItem as Familia).NombreIFamPat + "?" + "\n" + BLLServicioIdioma.MostrarMensaje("Se deberán modificar los permisos de los siguientes usuarios: \n").Texto + UsuariosCompString, BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja la Familia: ").Texto + (cboFamilia.SelectedItem as Familia).NombreIFamPat + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    }
                    
                    if (resmbox == DialogResult.Yes)
                    {
                        PerQuitar.Add((cboFamilia.SelectedItem as Familia));
                        //Modifico los permisos de los usuarios comprometidos (que tienen como único permiso la Familia que se eliminará)
                        if (UsuariosComprometidos.Count > 0)
                        {
                            frmDialogUsuariosComprometidos unFrmDialogUsuariosComp = new frmDialogUsuariosComprometidos();
                            unFrmDialogUsuariosComp.cboFamilia.DataSource = null;
                            unFrmDialogUsuariosComp.cboFamilia.DataSource = PermisosCbo.Where(X => (X.IdIFamPat != (cboFamilia.SelectedItem as Familia).IdIFamPat) && (X.IdIFamPat > 0)).ToList();
                            unFrmDialogUsuariosComp.cboFamilia.DisplayMember = "NombreIFamPat";
                            unFrmDialogUsuariosComp.cboFamilia.ValueMember = "IdIFamPat";
                            unFrmDialogUsuariosComp.lboxUsuarios.DataSource = null;
                            unFrmDialogUsuariosComp.lboxUsuarios.DataSource = UsuariosComprometidos;
                            unFrmDialogUsuariosComp.lboxUsuarios.DisplayMember = "NombreUsuario";
                            if (unFrmDialogUsuariosComp.ShowDialog(this) == DialogResult.OK)
                            {
                                PerAgregar.Add((unFrmDialogUsuariosComp.cboFamilia.SelectedItem as Familia));
                                foreach (Usuario unUs in UsuariosComprometidos)
                                {
                                    ManagerUsuario.UsuarioModificarPermisos(PerAgregar, PerQuitar, unUs.IdUsuario);
                                }
                            }
                        }
                        //Modifico los permisos de los usuarios que no están comprometidos
                        PerAgregar.Clear(); //Limpio para que no agregue permisos a los usuarios no comprometidos
                        foreach (Usuario unUs in UsuariosConFamiliaAEliminar.Where(x => !UsuariosComprometidos.Any(y => y.IdUsuario == x.IdUsuario)).ToList())
                        {
                            ManagerUsuario.UsuarioModificarPermisos(PerAgregar, PerQuitar, unUs.IdUsuario);
                        }
                        
                        if (ManagerFamilia.FamiliaEliminar((cboFamilia.SelectedItem as Familia)))
                        {
                            PermisosTodos = ManagerFamilia.PermisosTraerTodos();
                            PermisosCbo = PermisosTodos.Where(X => X.CantHijos > 0).ToList();
                            txtNombre.Clear();
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
                            LisAuxAsigBKP = new List<IFamPat>();
                            ListarPermisos(PermisosTodos, treeTodos);
                            ListarPermisos(LisAuxDisp, treeDisponibles);
                            ListarPermisos(LisAuxAsig, treeAsignados);
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Familia eliminada correctamente").Texto);
                        }
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Para dar de baja una Familia primero debe seleccionar una de la lista").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmFamiliaGestion - btnEliminar_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar eliminar la Familia, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
        }




    }
}