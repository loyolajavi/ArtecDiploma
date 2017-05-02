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
using System.IO;
using ARTEC.FRAMEWORK;

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
        List<Agente> unosAgentesResp;
        List<string> unosAdjuntos = new List<string>();
        List<Nota> unasNotas = new List<Nota>();



        public CrearSolicitud()
        {
            InitializeComponent();
            unaSolicitud = new Solicitud();
        }



        //Agregar Detalle Click
        private void txtAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (validDependencia.Validate() && ValidDep2.Validate() && validBien.Validate())
            {
                SolicDetalle unDetalleSolicitud = new SolicDetalle();
                unDetalleSolicitud.unaCategoria = unaCat;

                if (validCantBien.Validate())
                {
                    //Conteo Detalles
                    ContDetalles += 1;
                    unDetalleSolicitud.IdSolicitudDetalle = ContDetalles;

                    unDetalleSolicitud.Cantidad = Int32.Parse(txtCantBien.Text);
                    BLLPolitica ManagerPolitica = new BLLPolitica();
                    if (ManagerPolitica.VerificarPolitica(unaDep.IdDependencia, unDetalleSolicitud.unaCategoria.IdCategoria, unDetalleSolicitud.Cantidad))
                    {
                        AgregarDetalleConfirmado(ref unDetalleSolicitud);
                    }
                    else
                    {
                        DialogResult resmbox = MessageBox.Show("Este pedido no cumple con las políticas de Informática ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo);
                        if (resmbox == DialogResult.Yes)
                        {
                            AgregarDetalleConfirmado(ref unDetalleSolicitud);
                        }
                        else
                        {
                            //FIJARME SI HAY QUE RESETEAR ALGO
                        }
                    }
                }
            }
        }



        private void AgregarDetalleConfirmado(ref SolicDetalle unDetSolic)
        {

            if (AuxTipoCategoria == 2)//Categoria de Software
            {
                unDetSolic.unosAgentes = (List<Agente>)unosAgentesAsociados.ToList();
            }
            unDetSolic.unEstado.IdEstadoSolDetalle = (int)EstadoSolDetalle.EnumEstadoSolDetalle.Pendiente + 1;//GUARDA REVISAR ESTO en soft tmb
            unDetSolic.unEstado.DescripSolDetalle = "Pendiente";
            unaSolicitud.unosDetallesSolicitud.Add(unDetSolic);

            grillaDetalles.DataSource = null;
            grillaDetalles.DataSource = unaSolicitud.unosDetallesSolicitud;
            //Formato de la grillaDetalles
            grillaDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillaDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grillaDetalles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillaDetalles.Columns[0].HeaderText = "#";
            grillaDetalles.Columns[2].HeaderText = "Bien";
            grillaDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grillaDetalles.Columns[4].Width = 80;
            grillaDetalles.Columns[4].HeaderText = "Estado";
            grillaDetalles.Columns[1].Visible = false;
        }





        private void CrearSolicitud_Load(object sender, EventArgs e)
        {
            ///Traigo Dependencias para busqueda dinámica
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



        //Busqueda dinámica de Dependencias
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
                //AGREGAR QUE SE ELIMINEN los detalles de USUARIOS ASOCIADOS en soft AL CAMBIAR LA FISCALIA (SIN TENER DETALLES AGREGADOS)
                if (grillaDetalles.DataSource != null)
                {
                    DialogResult resmbox = MessageBox.Show("Si cambia de Fiscalía se eliminarán los detalles", "Confirmar", MessageBoxButtons.YesNo);
                    if (resmbox == DialogResult.Yes)
                    {
                        grillaDetalles.DataSource = null;
                        grillaAgentesAsociados.DataSource = null;
                        unaSolicitud.unosDetallesSolicitud.Clear();
                        unosAgentesAsociados.Clear();
                        unosAgentes.Clear();//asi no me aparecen agentes cuando cambio el texto dps de elegir una dependencia
                        //Reseteo el contador de detalles
                        ContDetalles = 0;
                        txtCantBien.Clear();
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
            Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(textBoxX1.Text, ' ');

            foreach (string unaPalabra in Palabras)
            {
                res = (List<Dependencia>)(from d in res
                                          where d.NombreDependencia.ToLower().Contains(unaPalabra.ToLower())
                                          select d).ToList();
            }

            if (res.Count > 0)
            {

                //ESTO ERA PARA QUE NO QUEDE FLASHADO EL CBOBOX AL PASAR DE MUCHOS RESULTADOS RESULTADO A UNO SOLO AL ESCRIBIR LA FISCALIA JUSTA A MANO, PERO HACIA QUE NO SE EJECUTE BIEN LO DE CARGAR LOS AGENTES
                //if (res.Count == 1 && string.Equals(res.First().NombreDependencia, textBoxX1.Text))
                //{
                //    //comboBoxEx4.Visible = false;
                //    //comboBoxEx4.DroppedDown = false;
                //    //comboBoxEx4.DataSource = null;

                //}
                //else
                //{
                    comboBoxEx4.DataSource = null;
                    comboBoxEx4.DataSource = res;
                    comboBoxEx4.DisplayMember = "NombreDependencia";
                    comboBoxEx4.ValueMember = "IdDependencia";
                    comboBoxEx4.Visible = true;
                    comboBoxEx4.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                //}
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

                    
                    unosAgentesResp = new List<Agente>();
                    unosAgentesResp = managerDependenciaAg.TraerAgentesResp(unaDep.IdDependencia);
                    cboAgenteResp.DataSource = null;
                    cboAgenteResp.DataSource = unosAgentesResp;
                    cboAgenteResp.DisplayMember = "ApellidoAgente";
                    cboAgenteResp.ValueMember = "IdAgente";
                    //Valido para que al momento de haberse emitido la advertencia y se lo ingrese correctamente, la validación de true y se vaya
                    ValidDep2.Validate();
                    txtAgente.Clear();

                }
            }
        }



        /// <summary>
        /// Habilitar Controles según Hard/Soft
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
                Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtBien.Text, ' ');

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
                    //Es una validación para cuando no se escribió el bien y se hizo click en agregar detalle, entonces dps de escribir el bien valido de nuevo para que se vaya el msj de advertencia
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
                    Palabras = FRAMEWORK.Servicios.ManejaCadenas.SepararTexto(txtAgente.Text, ' ');

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
                        //unAgen = null; // GUARDA
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
        private void btnAsociarAgente_Click(object sender, EventArgs e)//VALIDAR QUE NO DEJE AGREGARDETALLE SI NO HAY UN AGENTE ASOCIADO
        {
            if (ValidDep2.Validate())
            {
                if (validAgenteAsoc.Validate())
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
           
        }



        private void customValidatorDependencia_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxX1.Text))
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
            TipoBien unTipoBienAux = new TipoBien();
            BLLTipoBien managerTipoBienAux = new BLLTipoBien();
            unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(unDetSolic.unaCategoria.IdCategoria);

            if (unTipoBienAux.IdTipoBien == 1)
            {
                //HARDWARE
                gboxAsociados.Enabled = false;
                txtCantBien.ReadOnly = false;
                lblCantidad.Enabled = true;
                AuxTipoCategoria = 1;//HARDWARE
                cboTipoBien.SelectedValue = 1;//HARDWARE
                txtAgente.Clear();
                unAgen = null; //GUARDA, FIJARSE QUE NO HAGA NINGUN ERROR
                grillaAgentesAsociados.DataSource = null;

            }
            else
            {
                gboxAsociados.Enabled = true;
                txtCantBien.ReadOnly = true;
                lblCantidad.Enabled = false;
                AuxTipoCategoria = 2;//SOFTWARE
                cboTipoBien.SelectedValue = 2;//SOFTWARE
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


        //FIJARSE QUE NO VALIDA SI CANTIDAD ES 0
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

            if (ValidDep2.Validate())
            {

                unaSolicitud.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                //FECHA FIN VER Q SI ESTA ESCRITA
                unaSolicitud.laDependencia = unaDep;
                unaSolicitud.UnaPrioridad = (Prioridad)cboPrioridad.SelectedItem;
                unaSolicitud.Asignado = (Usuario)cboAsignado.SelectedItem;
                unaSolicitud.UnEstado = (EstadoSolicitud)cboEstadoSolicitud.SelectedItem;


                BLLSolicitud ManagerSolicitud = new BLLSolicitud();
                ManagerSolicitud.SolicitudCrear(unaSolicitud);


            }

            

        }


        //Estilo que se aplica cuando se arrastra un archivo a pnlAdjuntos
        private void pnlAdjuntos_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            pnlAdjuntos.BorderStyle = BorderStyle.Fixed3D;
        }


        //Copiar el archivo
        private void pnlAdjuntos_DragDrop(object sender, DragEventArgs e)
        {
            //Agarro la ruta de los archivos arrastrados
            string[] unArchivo = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var item in unArchivo)
            {
                //Agarro el nombre del archivo
                string NombreArchivo = Path.GetFileName(item);
                if (ValidarAdjunto(item))
                {
                    //Copio el archivo
                    FRAMEWORK.Servicios.ManejoArchivos.CopiarArchivo(item, @"D:\Se pueden borrar sin problemas\ArchivosCopiados\" + NombreArchivo);
                    pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;

                    //Añado a la grilla el nombre del archivo
                    
                    unosAdjuntos.Add(NombreArchivo);

                    lstAdjuntos.DataSource = null;
                    lstAdjuntos.DataSource = unosAdjuntos;
                    
                    //GrillaAdjuntos.Columns[0].HeaderText = "Archivos";
                    
                }
                else
                {
                    MessageBox.Show("El archivo " + "\"" + NombreArchivo + "\"" + " no tiene una extensión válida (jpg, png, bmp, pdf, txt)");
                }
            }
        }



        //Estilo que se aplica cuando se sale de pnladjuntos (en el evento de arrastrar archivos)
        private void pnlAdjuntos_DragLeave(object sender, EventArgs e)
        {
            pnlAdjuntos.BorderStyle = BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Valida si la extesión del adjunto es correcta
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ValidarAdjunto(string RutaCompletaArchivo)
        {
            string ext = Path.GetExtension(RutaCompletaArchivo).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".pdf") || (ext == ".txt"))
            {
                return true;
            }
            return false;
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            Nota unaNota = new Nota();
            unaNota.FechaNota = DateTime.Now;
            unaNota.DescripNota = txtNotas.Text;
            unasNotas.Add(unaNota);
            GrillaNotas.DataSource = null;
            GrillaNotas.DataSource = unasNotas;
            GrillaNotas.Columns[0].Visible = false;

        }

        private void EventValidatetxtAgente(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAgente.Text))
            {
                e.IsValid = false;
            }
            else
            {
                if (unAgen != null)
                {
                    if (string.Equals(e.ControlToValidate.Text, unAgen.ApellidoAgente))
                    {
                        e.IsValid = true;
                    }
                    else
                    {
                        e.IsValid = false;
                    }
                }
                else
                {
                    e.IsValid = false;
                }
            }
        }





    }
}