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

            Dictionary<string, string[]> dicfrmUsuariosModificar = new Dictionary<string, string[]>();
            string[] IdiomafrmUsuariosModificar = { "Modificar Usuarios" };
            dicfrmUsuariosModificar.Add("Idioma", IdiomafrmUsuariosModificar);
            this.Tag = dicfrmUsuariosModificar;

            Dictionary<string, string[]> diclblNomUsBuscar = new Dictionary<string, string[]>();
            string[] IdiomalblNomUsBuscar = { "Nombre Usuario" };
            diclblNomUsBuscar.Add("Idioma", IdiomalblNomUsBuscar);
            this.lblNomUsBuscar.Tag = diclblNomUsBuscar;

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            Dictionary<string, string[]> dicbtnCrearUsuario = new Dictionary<string, string[]>();
            string[] PerbtnCrearUsuario = { "Usuario Crear" };
            dicbtnCrearUsuario.Add("Permisos", PerbtnCrearUsuario);
            string[] IdiomabtnCrearUsuario = { "Crear Usuario" };
            dicbtnCrearUsuario.Add("Idioma", IdiomabtnCrearUsuario);
            this.btnCrearUsuario.Tag = dicbtnCrearUsuario;

            Dictionary<string, string[]> dicbtnReactivarUs = new Dictionary<string, string[]>();
            string[] PerbtnReactivarUs = { "Usuario Reactivar" };
            dicbtnReactivarUs.Add("Permisos", PerbtnReactivarUs);
            string[] IdiomabtnReactivarUs = { "Reactivar Usuario" };
            dicbtnReactivarUs.Add("Idioma", IdiomabtnReactivarUs);
            this.btnReactivarUs.Tag = dicbtnReactivarUs;

            Dictionary<string, string[]> dicbtnEliminarUsuario = new Dictionary<string, string[]>();
            string[] PerbtnEliminarUsuario = { "Usuario Eliminar" };
            dicbtnEliminarUsuario.Add("Permisos", PerbtnEliminarUsuario);
            string[] IdiomabtnEliminarUsuario = { "Eliminar Usuario" };
            dicbtnEliminarUsuario.Add("Idioma", IdiomabtnEliminarUsuario);
            this.btnEliminarUsuario.Tag = dicbtnEliminarUsuario;

            Dictionary<string, string[]> diclblNomUs = new Dictionary<string, string[]>();
            string[] IdiomalblNomUs = { "Nombre Usuario" };
            diclblNomUs.Add("Idioma", IdiomalblNomUs);
            this.lblNomUs.Tag = diclblNomUs;

            Dictionary<string, string[]> diclblPass = new Dictionary<string, string[]>();
            string[] IdiomalblPass = { "Contraseña" };
            diclblPass.Add("Idioma", IdiomalblPass);
            this.lblPass.Tag = diclblPass;

            Dictionary<string, string[]> diclblBaja = new Dictionary<string, string[]>();
            string[] IdiomalblBaja = { "Dado de Baja" };
            diclblBaja.Add("Idioma", IdiomalblBaja);
            this.lblBaja.Tag = diclblBaja;

            Dictionary<string, string[]> diclblNombre = new Dictionary<string, string[]>();
            string[] IdiomalblNombre = { "Nombre" };
            diclblNombre.Add("Idioma", IdiomalblNombre);
            this.lblNombre.Tag = diclblNombre;

            Dictionary<string, string[]> diclblApellido = new Dictionary<string, string[]>();
            string[] IdiomalblApellido = { "Apellido" };
            diclblApellido.Add("Idioma", IdiomalblApellido);
            this.lblApellido.Tag = diclblApellido;

            Dictionary<string, string[]> diclblMail = new Dictionary<string, string[]>();
            string[] IdiomalblMail = { "Mail" };
            diclblMail.Add("Idioma", IdiomalblMail);
            this.lblMail.Tag = diclblMail;

            Dictionary<string, string[]> dicpnlPermisos = new Dictionary<string, string[]>();
            string[] IdiomapnlPermisos = { "Permisos" };
            dicpnlPermisos.Add("Idioma", IdiomapnlPermisos);
            this.pnlPermisos.Tag = dicpnlPermisos;

            Dictionary<string, string[]> diclblDisponibles = new Dictionary<string, string[]>();
            string[] IdiomalblDisponibles = { "Disponibles" };
            diclblDisponibles.Add("Idioma", IdiomalblDisponibles);
            this.lblDisponibles.Tag = diclblDisponibles;

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;

            Dictionary<string, string[]> diclblAsignados = new Dictionary<string, string[]>();
            string[] IdiomalblAsignados = { "Asignados" };
            diclblAsignados.Add("Idioma", IdiomalblAsignados);
            this.lblAsignados.Tag = diclblAsignados;

            Dictionary<string, string[]> dicbtnQuitar = new Dictionary<string, string[]>();
            string[] IdiomabtnQuitar = { "Quitar" };
            dicbtnQuitar.Add("Idioma", IdiomabtnQuitar);
            this.btnQuitar.Tag = dicbtnQuitar;

            Dictionary<string, string[]> dicbtnModifUsuario = new Dictionary<string, string[]>();
            string[] PerbtnModifUsuario = { "Usuario Modificar" };
            dicbtnModifUsuario.Add("Permisos", PerbtnModifUsuario);
            string[] IdiomabtnModifUsuario = { "Modificar Usuario" };
            dicbtnModifUsuario.Add("Idioma", IdiomabtnModifUsuario);
            this.btnModifUsuario.Tag = dicbtnModifUsuario;

        }

        private void frmUsuariosGestion_Load(object sender, EventArgs e)
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

                lblBaja.Visible = false;
                btnReactivarUs.Enabled = false;
                btnEliminarUsuario.Enabled = false;
                btnModifUsuario.Enabled = false;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;

                //Idioma
                BLLServicioIdioma.Traducir(this.FindForm(), FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual);


            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "frmUsuariosGestion_Load");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error en el módulo de Usuarios, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
                this.Close();
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

                    if (unUsuario.Activo == 0)
                    {
                        lblBaja.Visible = true;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivarUs.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnReactivarUs.Enabled = true;
                        btnEliminarUsuario.Enabled = false;
                        btnModifUsuario.Enabled = false;
                        btnAgregar.Enabled = false;
                        btnQuitar.Enabled = false;
                        txtNomUs.Enabled = false;
                        txtPass.Enabled = false;
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtMail.Enabled = false;
                    }
                    else
                    {
                        lblBaja.Visible = false;
                        btnReactivarUs.Enabled = false;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminarUsuario.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnEliminarUsuario.Enabled = true;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModifUsuario.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                        btnModifUsuario.Enabled = true;
                        btnAgregar.Enabled = true;
                        btnQuitar.Enabled = true;
                        txtNomUs.Enabled = true;
                        txtPass.Enabled = true;
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtMail.Enabled = true;
                    }

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
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("El nombre de usuario ingresado no existe").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al buscar el Nombre de Usuario, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor seleccione la Familia que contiene el permiso selecionado o la patente requerida en forma directa").Texto);
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
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor seleccione la Familia que contiene el permiso seleccionado o la patente a eliminar en forma directa").Texto);
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
            Usuario UsModif = new Usuario();

            if (!vldNomUs.Validate())
                return;

                try
                {
                    if (unUsuario != null && unUsuario.IdUsuario > 0)
                        UsModif.IdUsuario = unUsuario.IdUsuario;
                    else
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Busque un usuario a modificar por favor").Texto);
                        return;
                    }
                        
                    //Verificar que quede al menos un permiso asignado
                    if (LisAuxAsig.Count == 0)
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Por favor revisar que el usuario posea al menos un permiso asignado").Texto);
                        return;
                    }
                    //NombreUsuario
                    if (unUsuario.NombreUsuario != txtNomUs.Text)
                    {
                        DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea modificar el Nombre de Usuario utilizado para ingresar al sistema?").Texto, BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                        if (resmbox == DialogResult.Yes)
                        {
                            //Verificar que no existe el nombre de usuario ingresado
                            if (!ManagerUsuario.UsuarioVerificarNomUs(txtNomUs.Text))
                                //Modificar NomUs
                                //ManagerUsuario.UsuarioModificarNomUs(unUsuario.IdUsuario, txtNomUs.Text);VER: QUITAR
                                UsModif.NombreUsuario = txtNomUs.Text;
                            else
                            {
                                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ya existe el nombre de usuario ingresado, por favor modifíquelo").Texto);
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
                        DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea modificar la contraseña del Usuario?").Texto, BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                        if (resmbox == DialogResult.Yes)
                            //ManagerUsuario.UsuarioModificarPass(unUsuario.IdUsuario, ServicioSecurizacion.AplicarHash(txtPass.Text));VER: QUITAR
                            UsModif.Pass = ServicioSecurizacion.Encriptar(ServicioSecurizacion.AplicarHash(txtPass.Text));
                        else
                            return;
                    }

                    //Datos basicos
                    if (unUsuario.Nombre != txtNombre.Text)
                        //ManagerUsuario.UsuarioModificarNombre(unUsuario.IdUsuario, txtNombre.Text);VER: QUITAR
                        UsModif.Nombre = txtNombre.Text;
                    if (unUsuario.Apellido != txtApellido.Text)
                        //ManagerUsuario.UsuarioModificarApellido(unUsuario.IdUsuario, txtApellido.Text);VER: QUITAR
                        UsModif.Apellido = txtApellido.Text;
                    if (unUsuario.Mail != txtMail.Text)
                        //ManagerUsuario.UsuarioModificarMail(unUsuario.IdUsuario, txtMail.Text);VER: QUITAR
                        UsModif.Mail = txtMail.Text;

                    //Permisos
                    PerQuitar = LisAuxAsigBKP.Where(d => !LisAuxAsig.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();
                    PerAgregar = LisAuxAsig.Where(d => !LisAuxAsigBKP.Any(a => a.NombreIFamPat == d.NombreIFamPat)).ToList();
                    //if (ManagerUsuario.UsuarioModificarPermisos(PerAgregar, PerQuitar, unUsuario.IdUsuario))VER: QUITAR
                    //MessageBox.Show("Modificación realizada");VER: QUITAR
                    if (ManagerUsuario.UsuarioModificar(UsModif, PerAgregar, PerQuitar, unUsuario))
                    {
                        LisAuxAsig = ManagerUsuario.UsuarioTraerPermisos(unUsuario.IdUsuario);
                        LisAuxAsigBKP = LisAuxAsig.ToList();
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Modificación realizada").Texto);
                    }
                        

                }
                catch (Exception es)
                {
                    string IdError = ServicioLog.CrearLog(es, "btnModifUsuario_Click");
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al modificar los datos del usuario, por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
                }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            frmUsuariosCrear unFrmUsuariosCrear = new frmUsuariosCrear();
            unFrmUsuariosCrear.ShowDialog();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (unUsuario != null && !string.IsNullOrWhiteSpace(unUsuario.NombreUsuario) && unUsuario.IdUsuario > 0)
                {
                    if (unUsuario.NombreUsuario == ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario)
                    {
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("No puede eliminarse a sí mismo").Texto);
                        return;
                    }
                    DialogResult resmbox = MessageBox.Show(BLLServicioIdioma.MostrarMensaje("¿Está seguro que desea dar de baja el Usuario: ").Texto + unUsuario.NombreUsuario + "?", BLLServicioIdioma.MostrarMensaje("Advertencia").Texto, MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                        if(ManagerUsuario.UsuarioEliminar(unUsuario))
                        {
                            lblBaja.Visible = true;
                            if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnReactivarUs.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                                btnReactivarUs.Enabled = true;
                            btnEliminarUsuario.Enabled = false;
                            btnModifUsuario.Enabled = false;
                            btnAgregar.Enabled = false;
                            btnQuitar.Enabled = false;
                            txtNomUs.Enabled = false;
                            txtPass.Enabled = false;
                            txtNombre.Enabled = false;
                            txtApellido.Enabled = false;
                            txtMail.Enabled = false;
                            MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Usuario: ").Texto + unUsuario.NombreUsuario + BLLServicioIdioma.MostrarMensaje(" dado de baja correctamente").Texto);
                        }
                    else
                        return;
                }
                else
                    MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Para dar de baja un usuario primero debe buscarlo").Texto);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnEliminarUsuario_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar eliminar el usuario: ").Texto + unUsuario.NombreUsuario + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }
            
        }

        private void btnReactivarUs_Click(object sender, EventArgs e)
        {
            try
            {
                if (unUsuario != null && !string.IsNullOrWhiteSpace(unUsuario.NombreUsuario) && unUsuario.IdUsuario > 0)
                {
                    if (ManagerUsuario.UsuarioReactivar(unUsuario))
                    {
                        lblBaja.Visible = false;
                        btnReactivarUs.Enabled = false;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnEliminarUsuario.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnEliminarUsuario.Enabled = true;
                        if (BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((btnModifUsuario.Tag as Dictionary<string, string[]>)["Permisos"] as string[])))
                            btnModifUsuario.Enabled = true;
                        btnAgregar.Enabled = true;
                        btnQuitar.Enabled = true;
                        txtNomUs.Enabled = true;
                        txtPass.Enabled = true;
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtMail.Enabled = true;
                        MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Usuario: ").Texto + unUsuario.NombreUsuario + BLLServicioIdioma.MostrarMensaje(" reactivado correctamente").Texto);
                    }
                }
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "btnReactivarUs_Click");
                MessageBox.Show(BLLServicioIdioma.MostrarMensaje("Ocurrio un error al intentar reactivar el usuario: ").Texto + unUsuario.NombreUsuario + BLLServicioIdioma.MostrarMensaje(", por favor informe del error Nro ").Texto + IdError + BLLServicioIdioma.MostrarMensaje(" del Log de Eventos").Texto);
            }

        }


    }
}