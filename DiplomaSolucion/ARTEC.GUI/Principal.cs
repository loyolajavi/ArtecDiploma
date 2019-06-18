using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ARTEC.BLL;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.BLL.Servicios;
using System.Linq;

namespace ARTEC.GUI
{
    public partial class Principal : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<Idioma> unosIdiomas = new List<Idioma>();

        public Principal()
        {
            InitializeComponent();

            //tabsPrincipal.SelectedIndexChanged += tabsPrincipal_SelectedIndexChanged;

            //Diccionario
            Dictionary<string, string[]> dicbtnCrearSolicitud = new Dictionary<string, string[]>();
            string[] PerbtnCrearSolicitud = { "Solicitud Crear" };
            dicbtnCrearSolicitud.Add("Permisos", PerbtnCrearSolicitud);
            string[] IdiomabtnCrearSolicitud = { "Crear Solicitud" };
            dicbtnCrearSolicitud.Add("Idioma", IdiomabtnCrearSolicitud);
            this.btnCrearSolicitud.Tag = dicbtnCrearSolicitud;

            Dictionary<string, string[]> dicbtnSolicitarPartida = new Dictionary<string, string[]>();
            string[] PerbtnSolicitarPartida = { "Partida Crear" };
            dicbtnSolicitarPartida.Add("Permisos", PerbtnSolicitarPartida);
            string[] IdiomabtnSolicitarPartida = { "Solicitar Partida" };
            dicbtnSolicitarPartida.Add("Idioma", IdiomabtnSolicitarPartida);
            this.btnSolicitarPartida.Tag = dicbtnSolicitarPartida;

            Dictionary<string, string[]> dicbtnPartidaAsociar = new Dictionary<string, string[]>();
            string[] PerbtnPartidaAsociar = { "Partida Asociar" };
            dicbtnPartidaAsociar.Add("Permisos", PerbtnPartidaAsociar);
            string[] IdiomabtnPartidaAsociar = { "Asociar Partida" };
            dicbtnPartidaAsociar.Add("Idioma", IdiomabtnPartidaAsociar);
            this.btnPartidaAsociar.Tag = dicbtnPartidaAsociar;

            Dictionary<string, string[]> dicbtnBienRegistrar = new Dictionary<string, string[]>();
            string[] PerbtnBienRegistrar = { "Adquisicion Registrar" };
            dicbtnBienRegistrar.Add("Permisos", PerbtnBienRegistrar);
            string[] IdiomabtnBienRegistrar = { "Registrar Adquisición" };
            dicbtnBienRegistrar.Add("Idioma", IdiomabtnBienRegistrar);
            this.btnBienRegistrar.Tag = dicbtnBienRegistrar;

            Dictionary<string, string[]> dicbtnRendicionCrear = new Dictionary<string, string[]>();
            string[] PerbtnRendicionCrear = { "Rendicion Crear" };
            dicbtnRendicionCrear.Add("Permisos", PerbtnRendicionCrear);
            string[] IdiomabtnRendicionCrear = { "Crear Rendición" };
            dicbtnRendicionCrear.Add("Idioma", IdiomabtnRendicionCrear);
            this.btnRendicionCrear.Tag = dicbtnRendicionCrear;

            Dictionary<string, string[]> dicbtnAgentes = new Dictionary<string, string[]>();
            string[] PerbtnAgentes = { "Agente Buscar", "Agente Modificar" };
            dicbtnAgentes.Add("Permisos", PerbtnAgentes);
            string[] IdiomabtnAgentes = { "Agentes" };
            dicbtnAgentes.Add("Idioma", IdiomabtnAgentes);
            this.btnAgentes.Tag = dicbtnAgentes;

            Dictionary<string, string[]> dicbtnFamilias = new Dictionary<string, string[]>();
            string[] PerbtnFamilias = { "Familia Buscar", "Familia Crear", "Familia Modificar", "Familia Eliminar" };
            dicbtnFamilias.Add("Permisos", PerbtnFamilias);
            string[] IdiomabtnFamilias = { "Familias" };
            dicbtnFamilias.Add("Idioma", IdiomabtnFamilias);
            this.btnFamilias.Tag = dicbtnFamilias;

            Dictionary<string, string[]> dicbtnBitacora = new Dictionary<string, string[]>();
            string[] PerbtnBitacora = { "Bitacora Buscar" };
            dicbtnBitacora.Add("Permisos", PerbtnBitacora);
            string[] IdiomabtnBitacora = { "Bitacora" };
            dicbtnBitacora.Add("Idioma", IdiomabtnBitacora);
            this.btnBitacora.Tag = dicbtnBitacora;

            Dictionary<string, string[]> dicbtnBackup = new Dictionary<string, string[]>();
            string[] PerbtnBackup = { "Backup BD", "Restore BD" };
            dicbtnBackup.Add("Permisos", PerbtnBackup);
            string[] IdiomabtnBackup = { "Backup" };
            dicbtnBackup.Add("Idioma", IdiomabtnBackup);
            this.btnBackup.Tag = dicbtnBackup;

            Dictionary<string, string[]> dicbtnUsuarios = new Dictionary<string, string[]>();
            string[] PerbtnUsuarios = { "Usuario Buscar", "Usuario Crear", "Usuario Modificar", "Usuario Eliminar", "Usuario Reactivar" };
            dicbtnUsuarios.Add("Permisos", PerbtnUsuarios);
            string[] IdiomabtnUsuarios = { "Usuarios" };
            dicbtnUsuarios.Add("Idioma", IdiomabtnUsuarios);
            this.btnUsuarios.Tag = dicbtnUsuarios;

            Dictionary<string, string[]> dicbtnVolver = new Dictionary<string, string[]>();
            string[] IdiomabtnVolver = { "Volver" };
            dicbtnVolver.Add("Idioma", IdiomabtnVolver);
            this.btnVolver.Tag = dicbtnVolver;

            Dictionary<string, string[]> dicbtnAvanzadas = new Dictionary<string, string[]>();
            string[] PerbtnAvanzadas = { "Usuario Buscar", "Usuario Crear", "Usuario Modificar", "Usuario Eliminar", "Usuario Reactivar",
                                         "Backup BD", "Restore BD", "Bitacora Buscar",
                                         "Familia Buscar", "Familia Crear", "Familia Modificar", "Familia Eliminar" };
            dicbtnAvanzadas.Add("Permisos", PerbtnAvanzadas);
            string[] IdiomabtnAvanzadas = { "Avanzadas" };
            dicbtnAvanzadas.Add("Idioma", IdiomabtnAvanzadas);
            this.btnAvanzadas.Tag = dicbtnAvanzadas;

            Dictionary<string, string[]> dicbtnCategorias = new Dictionary<string, string[]>();
            string[] PerbtnCategorias = { "Categoria Buscar", "Categoria Crear", "Categoria Modificar", "Categoria Eliminar", "Categoria Reactivar" };
            dicbtnCategorias.Add("Permisos", PerbtnCategorias);
            string[] IdiomabtnCategorias = { "Categorías" };
            dicbtnCategorias.Add("Idioma", IdiomabtnCategorias);
            this.btnCategorias.Tag = dicbtnCategorias;

            Dictionary<string, string[]> dicbtnProveedor = new Dictionary<string, string[]>();
            string[] PerbtnProveedor = { "Proveedor Buscar", "Proveedor Crear", "Proveedor Modificar", "Proveedor Eliminar", "Proveedor Reactivar" };
            dicbtnProveedor.Add("Permisos", PerbtnProveedor);
            string[] IdiomabtnProveedor = { "Proveedores" };
            dicbtnProveedor.Add("Idioma", IdiomabtnProveedor);
            this.btnProveedor.Tag = dicbtnProveedor;

            Dictionary<string, string[]> dictabSolic = new Dictionary<string, string[]>();
            string[] IdiomatabSolic = { "Solicitudes" };
            dictabSolic.Add("Idioma", IdiomatabSolic);
            this.tabSolic.Tag = dictabSolic;

            Dictionary<string, string[]> dictabRendiciones = new Dictionary<string, string[]>();
            string[] IdiomatabRendiciones = { "Rendiciones" };
            dictabRendiciones.Add("Idioma", IdiomatabRendiciones);
            this.tabRendiciones.Tag = dictabRendiciones;

            Dictionary<string, string[]> dictabPartidas = new Dictionary<string, string[]>();
            string[] IdiomatabPartidas = { "Partidas" };
            dictabPartidas.Add("Idioma", IdiomatabPartidas);
            this.tabPartidas.Tag = dictabPartidas;

            Dictionary<string, string[]> dictabDependencia = new Dictionary<string, string[]>();
            string[] IdiomatabDependencia = { "Dependencias" };
            dictabDependencia.Add("Idioma", IdiomatabDependencia);
            this.tabDependencia.Tag = dictabDependencia;

            Dictionary<string, string[]> dictabAsignaciones = new Dictionary<string, string[]>();
            string[] IdiomatabAsignaciones = { "Asignaciones" };
            dictabAsignaciones.Add("Idioma", IdiomatabAsignaciones);
            this.tabAsignaciones.Tag = dictabAsignaciones;

            Dictionary<string, string[]> dictabAdquisiciones = new Dictionary<string, string[]>();
            string[] IdiomatabAdquisiciones = { "Adquisiciones" };
            dictabAdquisiciones.Add("Idioma", IdiomatabAdquisiciones);
            this.tabAdquisiciones.Tag = dictabAdquisiciones;

            Dictionary<string, string[]> dicbtnParametros = new Dictionary<string, string[]>();
            string[] PerbtnParametros = { "Mail Modificar" };
            dicbtnParametros.Add("Permisos", PerbtnParametros);
            string[] IdiomabtnParametros = { "Configurar Mail" };
            dicbtnParametros.Add("Idioma", IdiomabtnParametros);
            this.btnParametros.Tag = dicbtnParametros;
            

            //END Diccionarios

            SolicitudBuscar frmSolicitudBuscar = new SolicitudBuscar();
            frmSolicitudBuscar.TopLevel = false;
            frmSolicitudBuscar.FormBorderStyle = FormBorderStyle.None;
            frmSolicitudBuscar.Visible = true;
            frmSolicitudBuscar.Dock = DockStyle.Fill;
            tabSolic.Controls.Add(frmSolicitudBuscar);


        }


        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                //Traduzco con el IdiomaActual del usuario logueado
                Idioma.unIdiomaActual = ServicioLogin.GetLoginUnico().UsuarioLogueado.IdiomaUsuarioActual;
                Idioma._EtiquetasCompartidas = null;
                BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(this.FindForm(), Idioma.unIdiomaActual);
                //Traigo todos los idiomas
                unosIdiomas = BLLServicioIdioma.IdiomaTraerTodos();
                cboIdioma.DataSource = null;
                cboIdioma.DisplayMember = "NombreIdioma";
                cboIdioma.ValueMember = "IdIdioma";
                cboIdioma.DataSource = unosIdiomas;

                //Obtengo el idioma actual del usuario para ponerlo en el cboidioma
                cboIdioma.SelectedValue = Idioma.unIdiomaActual;

                //Permisos
                //Permisos para Controles
                //Obtengo todos los controles del formulario
                IEnumerable<Control> unosControles = BLLServicioIdioma.ObtenerControles(this);
                foreach (Control unControl in unosControles)
                {
                    if (!string.IsNullOrEmpty(unControl.Name) && unControl.Tag != null && unControl.Tag.GetType() == typeof(Dictionary<string, string[]>) && (unControl.Tag as Dictionary<string, string[]>).ContainsKey("Permisos"))
                        unControl.Enabled = BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, ((unControl.Tag as Dictionary<string, string[]>)["Permisos"] as string[]));
                }
            }
            catch (Exception es)
            {
                throw;
            }
            
            
        }

        


        private void tabsPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as System.Windows.Forms.TabControl).SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    frmRendicionBuscar unFrmRendicionBuscar = frmRendicionBuscar.ObtenerInstancia();
                    unFrmRendicionBuscar.TopLevel = false;
                    unFrmRendicionBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmRendicionBuscar.Visible = true;
                    unFrmRendicionBuscar.Dock = DockStyle.Fill;
                    tabRendiciones.Controls.Add(unFrmRendicionBuscar);
                    break;
                case 2:
                    frmPartidaBuscar unFrmPartidaBuscar = frmPartidaBuscar.ObtenerInstancia();
                    unFrmPartidaBuscar.TopLevel = false;
                    unFrmPartidaBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmPartidaBuscar.Visible = true;
                    unFrmPartidaBuscar.Dock = DockStyle.Fill;
                    tabPartidas.Controls.Add(unFrmPartidaBuscar);
                    break;
                case 3:
                    frmDependenciaBuscar unFrmDependenciaBuscar = frmDependenciaBuscar.ObtenerInstancia();
                    unFrmDependenciaBuscar.TopLevel = false;
                    unFrmDependenciaBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmDependenciaBuscar.Visible = true;
                    unFrmDependenciaBuscar.Dock = DockStyle.Fill;
                    tabDependencia.Controls.Add(unFrmDependenciaBuscar);
                    break;
                case 4:
                    frmAsignacionBuscar unFrmAsignacionBuscar = frmAsignacionBuscar.ObtenerInstancia();
                    unFrmAsignacionBuscar.TopLevel = false;
                    unFrmAsignacionBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmAsignacionBuscar.Visible = true;
                    unFrmAsignacionBuscar.Dock = DockStyle.Fill;
                    tabAsignaciones.Controls.Add(unFrmAsignacionBuscar);
                    break;
                case 5:
                    frmAdquisicionBuscar unFrmAdquisicionBuscar = frmAdquisicionBuscar.ObtenerInstancia();
                    unFrmAdquisicionBuscar.TopLevel = false;
                    unFrmAdquisicionBuscar.FormBorderStyle = FormBorderStyle.None;
                    unFrmAdquisicionBuscar.Visible = true;
                    unFrmAdquisicionBuscar.Dock = DockStyle.Fill;
                    tabAdquisiciones.Controls.Add(unFrmAdquisicionBuscar);
                    break;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CrearSolicitud unfrmCrearSolicitud = new CrearSolicitud();
            unfrmCrearSolicitud.Show();
        }

        private void btnSolicitarPartida_Click(object sender, EventArgs e)
        {
            frmPartidaSolicitar unfrmPartidaSolicitar = frmPartidaSolicitar.ObtenerInstancia();
            unfrmPartidaSolicitar.Show();
        }

        private void btnPartidaAsociar_Click(object sender, EventArgs e)
        {
            frmPartidaAsociar unfrmPartidaAsociar = new frmPartidaAsociar();
            unfrmPartidaAsociar.Show();
        }

        private void btnBienRegistrar_Click(object sender, EventArgs e)
        {
            frmBienRegistrar unfrmBienRegistrar = new frmBienRegistrar();
            unfrmBienRegistrar.Show();
        }

        private void btnRendicionCrear_Click(object sender, EventArgs e)
        {
            frmRendicionCrear unfrmRendicionCrear = new frmRendicionCrear();
            unfrmRendicionCrear.Show();
        }

        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (BLLServicioIdioma.GetBLLServicioIdiomaUnico().CambiarIdioma(this.FindForm(), (int)cboIdioma.SelectedValue))
            {
                foreach (Control unForm in Application.OpenForms)
                {
                    BLLServicioIdioma.GetBLLServicioIdiomaUnico().Traducir(unForm, Idioma.unIdiomaActual);
                }
            }

        }


        private void btnAgentes_Click(object sender, EventArgs e)
        {
            frmAgentesGestion unFrmAgentesGestion = new frmAgentesGestion();
            unFrmAgentesGestion.Show();
        }


        private void btnAvanzadas_Click_1(object sender, EventArgs e)
        {
            panelEx1.Visible = true;
            panelEx1.BringToFront();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelEx1.Visible = false;
            panelEx1.SendToBack();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuariosModificar unFrmUsuariosGestion = new frmUsuariosModificar();
            unFrmUsuariosGestion.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup unFrmBackup = new Backup();
            unFrmBackup.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            frmBitacora unFrmBitacora = new frmBitacora();
            unFrmBitacora.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategoriaGestion unFrmCategoriaGestion = new frmCategoriaGestion();
            unFrmCategoriaGestion.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            frmProveedorCrear unFrmProveedorCrear = new frmProveedorCrear();
            unFrmProveedorCrear.Show();
        }

        private void btnFamilias_Click(object sender, EventArgs e)
        {
            frmFamiliaGestion unFrmFamiliasGestion = new frmFamiliaGestion();
            unFrmFamiliasGestion.Show();
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            frmParametros unFrmParametros = new frmParametros();
            unFrmParametros.Show();
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            frmNuevoIdioma unFrmNuevoIdioma = new frmNuevoIdioma();
            if (unFrmNuevoIdioma.ShowDialog(this) == DialogResult.OK)
            {
                //Traigo todos los idiomas
                unosIdiomas = BLLServicioIdioma.IdiomaTraerTodos();
                cboIdioma.DataSource = null;
                cboIdioma.DisplayMember = "NombreIdioma";
                cboIdioma.ValueMember = "IdIdioma";
                cboIdioma.DataSource = unosIdiomas;
            }
        }





    }
}