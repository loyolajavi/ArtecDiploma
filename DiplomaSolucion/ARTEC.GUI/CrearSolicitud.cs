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
using System.Linq;

namespace ARTEC.GUI
{
    public partial class CrearSolicitud : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<Dependencia> unasDependencias = new List<Dependencia>();
        Solicitud unaSolicitud;
        Dependencia unaDep;
        Categoria unaCat;
        Agente unAgen;
        List<TipoBien> unosTipoBien = new List<TipoBien>();
        List<Categoria> unasCategoriasHard;
        List<Categoria> unasCategoriasSoft;
        int AuxTipoCategoria = 1;
        List<Agente> unosAgentes;
        List<Agente> unosAgentesAsociados;
        List<EstadoSolicitud> unosEstadoSolicitud = new List<EstadoSolicitud>();
        List<Prioridad> unasPrioridades = new List<Prioridad>();
        int ContDetalles = 0;
        List<Usuario> unosUsuarios = new List<Usuario>();

        public CrearSolicitud()
        {
            InitializeComponent();
            unaSolicitud = new Solicitud();
        }

        //Agregar Detalle Click
        private void txtAgregarDetalle_Click(object sender, EventArgs e)
        {
            //FIJARME QUE SI NO ESTA ECRITO EL BIEN NO ME DEJE AGREGAR UN DETALLE
            //TMB FALTA QUE PARA PODER AGREGAR UN DETALLE PRIMERO ASOCIE USUARIOS
            if (validDependencia.Validate() && ValidDep2.Validate() && validBien.Validate())
            {
                SolicDetalle unDetalleSolicitud = new SolicDetalle();
                unDetalleSolicitud.unaCategoria = unaCat;
                if (AuxTipoCategoria == 1)
                {
                    AgregarHardware(ref unDetalleSolicitud);
                }
                else
                {
                    AgregarSoftware(ref unDetalleSolicitud);
                }


               
            }

        }


        private void AgregarHardware(ref SolicDetalle unDetSolic)
        {

            if (validCantBien.Validate())
            {
                //Conteo Detalles
                ContDetalles += 1;
                unDetSolic.IdSolicitudDetalle = ContDetalles;

                unDetSolic.Cantidad = Int32.Parse(txtCantBien.Text);
                unDetSolic.unEstado.IdEstadoSolDetalle = (int)EstadoSolDetalle.EnumEstadoSolDetalle.Pendiente;
                unDetSolic.unEstado.DescripSolDetalle = "Pendiente";
                unaSolicitud.unosDetallesSolicitud.Add(unDetSolic);

                grillaDetalles.DataSource = null;
                grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                //Formato de la grillaDetalles
                grillaDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grillaDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grillaDetalles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grillaDetalles.Columns[0].HeaderText = "Item";
                grillaDetalles.Columns[1].HeaderText = "Bien";
                grillaDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grillaDetalles.Columns[3].Width = 80;
                grillaDetalles.Columns[3].HeaderText = "Estado";
            }

           
        }


        private void AgregarSoftware(ref SolicDetalle unDetSolic)
        {
            if (validCantBien.Validate())
            {
                //Conteo Detalles
                ContDetalles += 1;
                unDetSolic.IdSolicitudDetalle = ContDetalles;

                unDetSolic.Cantidad = Int32.Parse(txtCantBien.Text);
                unDetSolic.unEstado.IdEstadoSolDetalle = (int)EstadoSolDetalle.EnumEstadoSolDetalle.Pendiente;
                unDetSolic.unEstado.DescripSolDetalle = "Pendiente";
                unDetSolic.unosAgentes = (List<Agente>)unosAgentesAsociados.ToList();
                unaSolicitud.unosDetallesSolicitud.Add(unDetSolic);

                grillaDetalles.DataSource = null;
                grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
                //Formato de la grillaDetalles
                grillaDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grillaDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grillaDetalles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grillaDetalles.Columns[0].HeaderText = "#";
                grillaDetalles.Columns[1].HeaderText = "Bien";
                grillaDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grillaDetalles.Columns[3].Width = 80;
                grillaDetalles.Columns[3].HeaderText = "Estado";
            }
        }


        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            ///Traigo Dependencias para busqueda din�mica
            BLL.BLLDependencia ManagerDependencia = new BLL.BLLDependencia();
            unasDependencias = ManagerDependencia.TraerTodos();

            ///Para poder seleccionar Hard o Soft
            BLLTipoBien ManagerTipoBien = new BLLTipoBien();
            unosTipoBien = ManagerTipoBien.TraerTodos();
            cboTipoBien.DataSource = null;
            cboTipoBien.DataSource = unosTipoBien;
            cboTipoBien.DisplayMember = "DescripTipoBien";
            cboTipoBien.ValueMember = "IdTipoBien";

            //Traigo categorias para dps filtrar por hard o soft
            BLLCategoria ManagerCategoria = new BLLCategoria();
            unasCategoriasHard = new List<Categoria>();
            unasCategoriasHard = ManagerCategoria.CategoriaTraerTodosHard();
            unasCategoriasSoft = new List<Categoria>();
            unasCategoriasSoft = ManagerCategoria.CategoriaTraerTodosSoft();

            unosAgentesAsociados = new List<Agente>();


            ///Traer Estados Solicitud
            BLLEstadoSolicitud ManagerEstadoSolicitud = new BLLEstadoSolicitud();
            unosEstadoSolicitud = ManagerEstadoSolicitud.EstadoSolicitudTraerTodos();
            cboEstadoSolicitud.DataSource = null;
            cboEstadoSolicitud.DataSource = unosEstadoSolicitud;
            cboEstadoSolicitud.DisplayMember = "DescripEstadoSolic";
            cboEstadoSolicitud.ValueMember = "IdEstadoSolicitud";


            ///Traer Prioridad
            BLLPrioridad ManagerPrioridad = new BLLPrioridad();
            unasPrioridades = ManagerPrioridad.PrioridadTraerTodos();
            cboPrioridad.DataSource = null;
            cboPrioridad.DataSource = unasPrioridades;
            cboPrioridad.DisplayMember = "DescripPrioridad";
            cboPrioridad.ValueMember = "IdPrioridad";

            //Traer UsuariosSistema
            BLLUsuario ManagerUsuario = new BLLUsuario();
            unosUsuarios = ManagerUsuario.UsuarioTraerTodos();
            cboAsignado.DataSource = null;
            cboAsignado.DataSource = unosUsuarios;
            cboAsignado.DisplayMember = "NombreUsuario";
            cboAsignado.ValueMember = "IdUsuario";

            //Cargar fecha Inicio
            txtFechaInicio.Text = DateTime.Today.ToString("d");


        }

        //Busqueda din�mica de Dependencias
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                
                if (grillaDetalles.DataSource != null)
                {
                    DialogResult resmbox = MessageBox.Show("Si cambia de Fiscal�a se eliminar�n los detalles", "Confirmar", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        grillaDetalles.DataSource = null;
                        grillaAgentesAsociados.DataSource = null;
                        unaSolicitud.unosDetallesSolicitud.Clear();
                        unosAgentesAsociados.Clear();
                        unosAgentes.Clear();//asi no me aparecen agentes cuando cambio el texto dps de elegir una dependencia
                        //Reseteo el contador de detalles
                        ContDetalles = 0;
                        BusquedaDependencias();
                    }
                    else if (resmbox == DialogResult.No)
                    {
                        textBoxX1.Text = unaDep.NombreDependencia;
                        textBoxX1.SelectionStart = textBoxX1.Text.Length + 1;
                    }
                }
                else
                {
                    BusquedaDependencias();
                }


            }
            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
            }
        }


        private void BusquedaDependencias()
        {
            List<Dependencia> res = new List<Dependencia>();
            res = (List<Dependencia>)unasDependencias.ToList();

            List<string> Palabras = new List<string>();
            Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {
                if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                {
                    comboBoxEx4.Visible = false;
                    comboBoxEx4.DroppedDown = false;
                    comboBoxEx4.DataSource = null;

                }
                else
                {
                    comboBoxEx4.DataSource = null;
                    comboBoxEx4.DataSource = res;
                    comboBoxEx4.DisplayMember = "NombreDependencia";
                    comboBoxEx4.ValueMember = "IdDependencia";
                    comboBoxEx4.Visible = true;
                    comboBoxEx4.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                comboBoxEx4.Visible = false;
                comboBoxEx4.DroppedDown = false;
                comboBoxEx4.DataSource = null;
                //unosAgentes = null;//asi no me aparecen agentes cuando cambio el texto dps de elegir una dependencia
            }
        }


        //Al seleccionar una dependencia del combo, guarda el idDependencia, el nombre y cierra el combo
        private void comboBoxEx4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                if (comboBoxEx4.SelectedIndex > -1)
                {
                    ComboBox cbo = (ComboBox)sender;
                    unaDep = new Dependencia();
                    unaDep = (Dependencia)cbo.SelectedItem;
                    textBoxX1.Text = cbo.GetItemText(cbo.SelectedItem);
                    textBoxX1.SelectionStart = textBoxX1.Text.Length + 1;

                    //Traer los agentes de la dependencia seleccionada
                    BLLDependencia managerDependenciaAg = new BLLDependencia();
                    unosAgentes = new List<Agente>();
                    unosAgentes = managerDependenciaAg.TraerAgentesDependencia(unaDep.IdDependencia);
                    //ValidDep2.Validate();//Creo q lo puedo borrar
                    txtAgente.Clear();

                }
            }
        }


        //public void prueba(){
        //    //Ejemplo de c�mo implementar una relaci�n de Agregaci�n en capas
        //    //BLLDependencia MediadorDependencia = new BLLDependencia();
        //    //unaSolicitud.laDependencia = MediadorDependencia.CrearDependencia(unaDep);
        //}



        /// <summary>
        /// Habilitar Controles seg�n Hard/Soft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTipoBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cboTipoBien.SelectedValue == 1)//Hardware
            {
                gboxAsociados.Enabled = false;
                txtCantBien.ReadOnly = false;
                lblCantidad.Enabled = true;
                txtBien.Clear();
                AuxTipoCategoria = 1;
                txtCantBien.Clear();
                txtAgente.Clear();
                unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
                grillaAgentesAsociados.DataSource = null;
            }
            if ((int)cboTipoBien.SelectedValue == 2)//Software
            {
                gboxAsociados.Enabled = true;
                txtCantBien.ReadOnly = true;
                lblCantidad.Enabled = false;
                txtBien.Clear();
                txtCantBien.Clear();
                AuxTipoCategoria = 2;
            }
        }

        //Busqueda Dinamica BIENES(CATEGORIAS)
        private void txtBien_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBien.Text))
            {

                List<Categoria> resCat = new List<Categoria>();
                //Traigo las categorias de Hard
                if (AuxTipoCategoria == 1)
                {
                    resCat = (List<Categoria>)unasCategoriasHard.ToList();
                }
                //Traigo las categorias de Soft
                else
                {
                    resCat = (List<Categoria>)unasCategoriasSoft.ToList();
                }


                List<string> Palabras = new List<string>();
                Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(txtBien.Text, ' ');

                foreach (string unaPalabra in Palabras)
                {
                    resCat = (List<Categoria>)(from cat in resCat
                                               where cat.DescripCategoria.ToLower().Contains(unaPalabra.ToLower())
                                               select cat).ToList();
                }

                if (resCat.Count > 0)
                {
                    if (resCat.Count == 1 && string.Equals(resCat.First().DescripCategoria, txtBien.Text))
                    {
                        cboBien.Visible = false;
                        cboBien.DroppedDown = false;
                        cboBien.DataSource = null;
                    }
                    else
                    {
                        cboBien.DataSource = null;
                        cboBien.DataSource = resCat;
                        cboBien.DisplayMember = "DescripCategoria";
                        cboBien.ValueMember = "IdCategoria";
                        cboBien.Visible = true;
                        cboBien.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    cboBien.Visible = false;
                    cboBien.DroppedDown = false;
                    cboBien.DataSource = null;
                }
            }
            else
            {
                cboBien.Visible = false;
                cboBien.DroppedDown = false;
                cboBien.DataSource = null;
            }
        }

        private void cboBien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBien.Text))
            {
                if (cboBien.SelectedIndex > -1)
                {
                    ComboBox cbo2 = (ComboBox)sender;
                    unaCat = new Categoria();
                    unaCat = (Categoria)cbo2.SelectedItem;

                    txtBien.Text = cbo2.GetItemText(cbo2.SelectedItem);
                    txtBien.SelectionStart = txtBien.Text.Length + 1;
                    //Es una validaci�n para cuando no se escribi� el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
                    validBien.Validate();
                }
            }
        }



        //Busqueda Dinamica Agentes por Dependencia
        private void txtAgente_TextChanged(object sender, EventArgs e)
        {
            if (ValidDep2.Validate())
            {
                if (!string.IsNullOrWhiteSpace(txtAgente.Text) & unosAgentes != null)
                {

                    List<Agente> resAgente = new List<Agente>();
                    resAgente = (List<Agente>)unosAgentes.ToList();
                    List<string> Palabras = new List<string>();
                    Palabras = Framework.Loyola.ManejaCadenas.SepararTexto(txtAgente.Text, ' ');

                    foreach (string unaPalabra in Palabras)
                    {
                        resAgente = (List<Agente>)(from cat in resAgente
                                                   where cat.ApellidoAgente.ToLower().Contains(unaPalabra.ToLower())
                                                   select cat).ToList();
                    }

                    if (resAgente.Count > 0)
                    {
                        if (resAgente.Count == 1 && string.Equals(resAgente.First().ApellidoAgente, txtAgente.Text))
                        {
                            cboAgentesAsociados.Visible = false;
                            cboAgentesAsociados.DroppedDown = false;
                            cboAgentesAsociados.DataSource = null;
                        }
                        else
                        {
                            cboAgentesAsociados.DataSource = null;
                            cboAgentesAsociados.DataSource = resAgente;
                            cboAgentesAsociados.DisplayMember = "ApellidoAgente";
                            cboAgentesAsociados.ValueMember = "IdAgente";
                            cboAgentesAsociados.Visible = true;
                            cboAgentesAsociados.DroppedDown = true;
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        cboAgentesAsociados.Visible = false;
                        cboAgentesAsociados.DroppedDown = false;
                        cboAgentesAsociados.DataSource = null;
                        unAgen = null; // GUARDA
                    }
                }
                else
                {
                    cboAgentesAsociados.Visible = false;
                    cboAgentesAsociados.DroppedDown = false;
                    cboAgentesAsociados.DataSource = null;
                }
            }


        }

        //Al seleccionar un AGENTE del combo, guarda el IdAgente, el apellido y cierra el combo
        private void cboAgentesAsociados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAgente.Text))
            {
                if (cboAgentesAsociados.SelectedIndex > -1)
                {
                    ComboBox cbo3 = (ComboBox)sender;
                    unAgen = new Agente();
                    unAgen = (Agente)cbo3.SelectedItem;

                    txtAgente.Text = cbo3.GetItemText(cbo3.SelectedItem);
                    txtAgente.SelectionStart = txtAgente.Text.Length + 1;
                }
            }
        }

        //Asociar Agentes al software ingresado
        private void btnAsociarAgente_Click(object sender, EventArgs e)
        {
            if (ValidDep2.Validate())
            {
                int CantSuma = 0;
                if (!string.IsNullOrWhiteSpace(txtCantBien.Text))
                {
                    CantSuma = Int32.Parse(txtCantBien.Text);
                }

                if (unosAgentesAsociados.Count > 0) //QUEDA CARGADO unosAgentesAsociados aun dps de cargar un hardware y volver a cargar un software GUARDA, 
                //TENGO Q PREGUNTAR CUANDO HAGA CLICK EN ASOCIAR O EN ALGUN MOMENTO; SI EL SOFT YA ESTA AGREGADO, TRAER LOS DATOS Y GUARDARLOS EN LAS VARIABLES CORRESPONDIENTES
                {

                    var resultado = unosAgentesAsociados.Where(x => x.IdAgente == unAgen.IdAgente);
                    if (resultado.Count() > 0)
                    {
                        MessageBox.Show("El agente " + unAgen.NombreAgente + " " + unAgen.ApellidoAgente + " " + "ya se encuentra asociado a este software");
                    }
                    else
                    {
                        unosAgentesAsociados.Add(unAgen);
                        CantSuma += 1;
                        txtCantBien.Text = CantSuma.ToString();
                    }
                }
                else
                {
                    unosAgentesAsociados.Add(unAgen);
                    CantSuma += 1;
                    txtCantBien.Text = CantSuma.ToString();
                }

                grillaAgentesAsociados.DataSource = null;
                grillaAgentesAsociados.DataSource = unosAgentesAsociados;
                grillaAgentesAsociados.Columns[0].Visible = false;
                grillaAgentesAsociados.Columns[3].Visible = false;
                grillaAgentesAsociados.Columns[4].Visible = false;

            }
           
        }

        private void customValidatorDependencia_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {

            if (unaDep == null)
            {
                e.IsValid = false;
            }
            else
            {
                if (string.Equals(e.ControlToValidate.Text, unaDep.NombreDependencia))
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }
            
        }

        private void grillaDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se hizo click en el header, salir
            if (e.RowIndex < 0)
            {
                return;
            }


            //Para obtener el detalle en donde se hizo click
            //MessageBox.Show(grillaDetalles.Rows.SharedRow(e.RowIndex).ToString());
            int DetalleSeleccionado = e.RowIndex + 1;
            SolicDetalle unDetSolic = new SolicDetalle();

            unDetSolic = unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado);

            txtBien.Text = unDetSolic.unaCategoria.DescripCategoria;
            txtCantBien.Text = unDetSolic.Cantidad.ToString();
            
            //Traer TIPOBIEN por IdCategoria y ponerlo en el cbobox para que quede ese seleccionado
            unaCat = unDetSolic.unaCategoria;
            List<TipoBien> unosTipoBienAux = new List<TipoBien>();
            BLLTipoBien managerTipoBienAux = new BLLTipoBien();
            unosTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);

            if (unosTipoBienAux.First().IdTipoBien == 1)
            {
                //HARDWARE
                gboxAsociados.Enabled = false;
                txtCantBien.ReadOnly = false;
                lblCantidad.Enabled = true;
                AuxTipoCategoria = 1;//HARDCODEADO
                cboTipoBien.SelectedValue = 1;//HARDCODEADO
                txtAgente.Clear();
                unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
                grillaAgentesAsociados.DataSource = null;

            }
            else
            {
                gboxAsociados.Enabled = true;
                txtCantBien.ReadOnly = true;
                lblCantidad.Enabled = false;
                AuxTipoCategoria = 2;//HARDCODEADO
                cboTipoBien.SelectedValue = 2;//HARDCODEADO
                txtAgente.Clear();
                unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
                grillaAgentesAsociados.DataSource = null;
                grillaAgentesAsociados.DataSource = unaSolicitud.unosDetallesSolicitud.First(x => x.IdSolicitudDetalle == DetalleSeleccionado).unosAgentes;
                //No mostrar columnas que no necesito de los agentes asociados
                grillaAgentesAsociados.Columns[0].Visible = false;
                grillaAgentesAsociados.Columns[3].Visible = false;
                grillaAgentesAsociados.Columns[4].Visible = false;




            }

        }

        //NOTA AL AIRE: GUARDA QUE NO VALIDA SI CANTIDAD ES 0
        private void customValidatorBien_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBien.Text))
            {
                e.IsValid = false;
            }
            else
            {
                if (string.Equals(e.ControlToValidate.Text, unaCat.DescripCategoria))
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }
        }

        private void btnCrearSolicitud_Click(object sender, EventArgs e)
        {

        }







    }
}