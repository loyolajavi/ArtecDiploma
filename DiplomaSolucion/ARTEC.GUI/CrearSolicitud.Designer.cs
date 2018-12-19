namespace ARTEC.GUI
{
    partial class CrearSolicitud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearSolicitud));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAgenteResp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblAgenteResponsable = new DevComponents.DotNetBar.LabelX();
            this.btnCrearSolicitud = new DevComponents.DotNetBar.ButtonX();
            this.gboxNotas = new System.Windows.Forms.GroupBox();
            this.btnNotas = new DevComponents.DotNetBar.ButtonX();
            this.GrillaNotas = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtNota = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.cboAsignado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboPrioridad = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboEstadoSolicitud = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtFechaInicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.pnlAdjuntos = new System.Windows.Forms.Panel();
            this.btnEliminarAdjunto = new DevComponents.DotNetBar.ButtonX();
            this.lstAdjuntos = new DevComponents.DotNetBar.ListBoxAdv();
            this.gboxBienes = new System.Windows.Forms.GroupBox();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.btnNuevoDetalle = new DevComponents.DotNetBar.ButtonX();
            this.gboxAsociados = new System.Windows.Forms.GroupBox();
            this.grillaAgentesAsociados = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAsociarAgente = new DevComponents.DotNetBar.ButtonX();
            this.txtAgente = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboAgentesAsociados = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboTipoBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAgregarDetalle = new DevComponents.DotNetBar.ButtonX();
            this.grillaDetalles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtCantBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCantidad = new DevComponents.DotNetBar.LabelX();
            this.txtBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.validDependencia = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.ValidDep2 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter2 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.validCantBien = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customValidtxtCantBien = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter3 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.validBien = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter4 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.validAgenteAsoc = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customtxtAgente = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter5 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.validNota = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customtxtNota = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider6 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter6 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.panel1.SuspendLayout();
            this.gboxNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).BeginInit();
            this.pnlAdjuntos.SuspendLayout();
            this.gboxBienes.SuspendLayout();
            this.gboxAsociados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgentesAsociados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider6)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cboAgenteResp);
            this.panel1.Controls.Add(this.lblAgenteResponsable);
            this.panel1.Controls.Add(this.btnCrearSolicitud);
            this.panel1.Controls.Add(this.gboxNotas);
            this.panel1.Controls.Add(this.cboAsignado);
            this.panel1.Controls.Add(this.cboPrioridad);
            this.panel1.Controls.Add(this.cboEstadoSolicitud);
            this.panel1.Controls.Add(this.labelX8);
            this.panel1.Controls.Add(this.labelX10);
            this.panel1.Controls.Add(this.labelX9);
            this.panel1.Controls.Add(this.txtFechaInicio);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.pnlAdjuntos);
            this.panel1.Controls.Add(this.gboxBienes);
            this.panel1.Controls.Add(this.lblDependencia);
            this.panel1.Controls.Add(this.textBoxX1);
            this.panel1.Controls.Add(this.comboBoxEx4);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 659);
            this.panel1.TabIndex = 3;
            // 
            // cboAgenteResp
            // 
            this.cboAgenteResp.DisplayMember = "Text";
            this.cboAgenteResp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAgenteResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenteResp.ForeColor = System.Drawing.Color.Black;
            this.cboAgenteResp.FormattingEnabled = true;
            this.cboAgenteResp.ItemHeight = 16;
            this.cboAgenteResp.Location = new System.Drawing.Point(350, 50);
            this.cboAgenteResp.Name = "cboAgenteResp";
            this.cboAgenteResp.Size = new System.Drawing.Size(161, 22);
            this.cboAgenteResp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAgenteResp.TabIndex = 25;
            // 
            // lblAgenteResponsable
            // 
            // 
            // 
            // 
            this.lblAgenteResponsable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAgenteResponsable.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgenteResponsable.Location = new System.Drawing.Point(350, 31);
            this.lblAgenteResponsable.Name = "lblAgenteResponsable";
            this.lblAgenteResponsable.Size = new System.Drawing.Size(91, 17);
            this.lblAgenteResponsable.TabIndex = 23;
            this.lblAgenteResponsable.Text = "Dependencia";
            // 
            // btnCrearSolicitud
            // 
            this.btnCrearSolicitud.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearSolicitud.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearSolicitud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearSolicitud.Location = new System.Drawing.Point(422, 633);
            this.btnCrearSolicitud.Name = "btnCrearSolicitud";
            this.btnCrearSolicitud.Size = new System.Drawing.Size(75, 23);
            this.btnCrearSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearSolicitud.TabIndex = 22;
            this.btnCrearSolicitud.Text = "Crear";
            this.btnCrearSolicitud.Click += new System.EventHandler(this.btnCrearSolicitud_Click);
            // 
            // gboxNotas
            // 
            this.gboxNotas.Controls.Add(this.btnNotas);
            this.gboxNotas.Controls.Add(this.GrillaNotas);
            this.gboxNotas.Controls.Add(this.txtNota);
            this.gboxNotas.Location = new System.Drawing.Point(15, 489);
            this.gboxNotas.Name = "gboxNotas";
            this.gboxNotas.Size = new System.Drawing.Size(928, 131);
            this.gboxNotas.TabIndex = 21;
            this.gboxNotas.TabStop = false;
            this.gboxNotas.Text = "Notas";
            // 
            // btnNotas
            // 
            this.btnNotas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNotas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNotas.Location = new System.Drawing.Point(844, 21);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(75, 27);
            this.btnNotas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNotas.TabIndex = 10;
            this.btnNotas.Text = "Agregar";
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // GrillaNotas
            // 
            this.GrillaNotas.AllowUserToOrderColumns = true;
            this.GrillaNotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaNotas.BackgroundColor = System.Drawing.Color.White;
            this.GrillaNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaNotas.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaNotas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaNotas.Location = new System.Drawing.Point(6, 54);
            this.GrillaNotas.Name = "GrillaNotas";
            this.GrillaNotas.ReadOnly = true;
            this.GrillaNotas.Size = new System.Drawing.Size(913, 71);
            this.GrillaNotas.TabIndex = 9;
            // 
            // txtNota
            // 
            // 
            // 
            // 
            this.txtNota.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtNota.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNota.Location = new System.Drawing.Point(6, 21);
            this.txtNota.MaxLength = 300;
            this.txtNota.Name = "txtNota";
            this.txtNota.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang11274{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}" +
    "}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.txtNota.Size = new System.Drawing.Size(832, 27);
            this.txtNota.TabIndex = 8;
            this.validNota.SetValidator1(this.txtNota, this.customtxtNota);
            // 
            // cboAsignado
            // 
            this.cboAsignado.DisplayMember = "Text";
            this.cboAsignado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsignado.ForeColor = System.Drawing.Color.Black;
            this.cboAsignado.FormattingEnabled = true;
            this.cboAsignado.ItemHeight = 16;
            this.cboAsignado.Location = new System.Drawing.Point(83, 444);
            this.cboAsignado.Name = "cboAsignado";
            this.cboAsignado.Size = new System.Drawing.Size(116, 22);
            this.cboAsignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAsignado.TabIndex = 19;
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.DisplayMember = "Text";
            this.cboPrioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridad.ForeColor = System.Drawing.Color.Black;
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.ItemHeight = 16;
            this.cboPrioridad.Location = new System.Drawing.Point(83, 415);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(116, 22);
            this.cboPrioridad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPrioridad.TabIndex = 18;
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.DisplayMember = "Text";
            this.cboEstadoSolicitud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboEstadoSolicitud.Enabled = false;
            this.cboEstadoSolicitud.ForeColor = System.Drawing.Color.Black;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.ItemHeight = 16;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(83, 387);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(116, 22);
            this.cboEstadoSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboEstadoSolicitud.TabIndex = 17;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(21, 389);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 14;
            this.labelX8.Text = "Estado";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(21, 443);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 16;
            this.labelX10.Text = "Asignado a";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(21, 414);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 15;
            this.labelX9.Text = "Prioridad";
            // 
            // txtFechaInicio
            // 
            // 
            // 
            // 
            this.txtFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaInicio.ButtonDropDown.Visible = true;
            this.txtFechaInicio.IsPopupCalendarOpen = false;
            this.txtFechaInicio.Location = new System.Drawing.Point(854, 50);
            this.txtFechaInicio.MaxDate = new System.DateTime(2018, 12, 4, 0, 0, 0, 0);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaInicio.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(79, 22);
            this.txtFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaInicio.TabIndex = 11;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(805, 50);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(48, 22);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Creación";
            // 
            // pnlAdjuntos
            // 
            this.pnlAdjuntos.AllowDrop = true;
            this.pnlAdjuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdjuntos.Controls.Add(this.btnEliminarAdjunto);
            this.pnlAdjuntos.Controls.Add(this.lstAdjuntos);
            this.pnlAdjuntos.Location = new System.Drawing.Point(342, 403);
            this.pnlAdjuntos.Name = "pnlAdjuntos";
            this.pnlAdjuntos.Size = new System.Drawing.Size(592, 42);
            this.pnlAdjuntos.TabIndex = 7;
            this.pnlAdjuntos.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlAdjuntos_DragDrop);
            this.pnlAdjuntos.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlAdjuntos_DragEnter);
            this.pnlAdjuntos.DragLeave += new System.EventHandler(this.pnlAdjuntos_DragLeave);
            // 
            // btnEliminarAdjunto
            // 
            this.btnEliminarAdjunto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarAdjunto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarAdjunto.Location = new System.Drawing.Point(457, 6);
            this.btnEliminarAdjunto.Name = "btnEliminarAdjunto";
            this.btnEliminarAdjunto.Size = new System.Drawing.Size(75, 27);
            this.btnEliminarAdjunto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarAdjunto.TabIndex = 11;
            this.btnEliminarAdjunto.Text = "Quitar";
            this.btnEliminarAdjunto.Click += new System.EventHandler(this.btnEliminarAdjunto_Click);
            // 
            // lstAdjuntos
            // 
            this.lstAdjuntos.AutoScroll = true;
            // 
            // 
            // 
            this.lstAdjuntos.BackgroundStyle.Class = "ListBoxAdv";
            this.lstAdjuntos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lstAdjuntos.CheckStateMember = null;
            this.lstAdjuntos.ContainerControlProcessDialogKey = true;
            this.lstAdjuntos.DragDropSupport = true;
            this.lstAdjuntos.Location = new System.Drawing.Point(7, 6);
            this.lstAdjuntos.Name = "lstAdjuntos";
            this.lstAdjuntos.Size = new System.Drawing.Size(428, 27);
            this.lstAdjuntos.TabIndex = 5;
            // 
            // gboxBienes
            // 
            this.gboxBienes.Controls.Add(this.btnNuevoDetalle);
            this.gboxBienes.Controls.Add(this.gboxAsociados);
            this.gboxBienes.Controls.Add(this.cboTipoBien);
            this.gboxBienes.Controls.Add(this.grillaDetalles);
            this.gboxBienes.Controls.Add(this.txtCantBien);
            this.gboxBienes.Controls.Add(this.lblCantidad);
            this.gboxBienes.Controls.Add(this.txtBien);
            this.gboxBienes.Controls.Add(this.cboBien);
            this.gboxBienes.Controls.Add(this.btnModificar);
            this.gboxBienes.Controls.Add(this.btnAgregarDetalle);
            this.gboxBienes.Location = new System.Drawing.Point(15, 78);
            this.gboxBienes.Name = "gboxBienes";
            this.gboxBienes.Size = new System.Drawing.Size(928, 293);
            this.gboxBienes.TabIndex = 2;
            this.gboxBienes.TabStop = false;
            this.gboxBienes.Text = "Agregar Bienes";
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(196, 255);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(97, 29);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 30;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevoDetalle
            // 
            this.btnNuevoDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNuevoDetalle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNuevoDetalle.Location = new System.Drawing.Point(152, 21);
            this.btnNuevoDetalle.Name = "btnNuevoDetalle";
            this.btnNuevoDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNuevoDetalle.TabIndex = 28;
            this.btnNuevoDetalle.Text = "btnNuevoDetalle";
            this.btnNuevoDetalle.Click += new System.EventHandler(this.btnNuevoDetalle_Click);
            // 
            // gboxAsociados
            // 
            this.gboxAsociados.Controls.Add(this.grillaAgentesAsociados);
            this.gboxAsociados.Controls.Add(this.btnAsociarAgente);
            this.gboxAsociados.Controls.Add(this.txtAgente);
            this.gboxAsociados.Controls.Add(this.labelX2);
            this.gboxAsociados.Controls.Add(this.cboAgentesAsociados);
            this.gboxAsociados.Enabled = false;
            this.gboxAsociados.Location = new System.Drawing.Point(6, 78);
            this.gboxAsociados.Name = "gboxAsociados";
            this.gboxAsociados.Size = new System.Drawing.Size(315, 171);
            this.gboxAsociados.TabIndex = 9;
            this.gboxAsociados.TabStop = false;
            this.gboxAsociados.Text = "Agentes asociados";
            // 
            // grillaAgentesAsociados
            // 
            this.grillaAgentesAsociados.BackgroundColor = System.Drawing.Color.White;
            this.grillaAgentesAsociados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grillaAgentesAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaAgentesAsociados.DefaultCellStyle = dataGridViewCellStyle2;
            this.grillaAgentesAsociados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaAgentesAsociados.Location = new System.Drawing.Point(48, 52);
            this.grillaAgentesAsociados.Name = "grillaAgentesAsociados";
            this.grillaAgentesAsociados.Size = new System.Drawing.Size(239, 113);
            this.grillaAgentesAsociados.TabIndex = 12;
            // 
            // btnAsociarAgente
            // 
            this.btnAsociarAgente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAsociarAgente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAsociarAgente.Location = new System.Drawing.Point(227, 24);
            this.btnAsociarAgente.Name = "btnAsociarAgente";
            this.btnAsociarAgente.Size = new System.Drawing.Size(60, 22);
            this.btnAsociarAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAsociarAgente.TabIndex = 11;
            this.btnAsociarAgente.Text = "Asociar";
            this.btnAsociarAgente.Click += new System.EventHandler(this.btnAsociarAgente_Click);
            // 
            // txtAgente
            // 
            this.txtAgente.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAgente.Border.Class = "TextBoxBorder";
            this.txtAgente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAgente.DisabledBackColor = System.Drawing.Color.White;
            this.txtAgente.ForeColor = System.Drawing.Color.Black;
            this.txtAgente.Location = new System.Drawing.Point(48, 24);
            this.txtAgente.Name = "txtAgente";
            this.txtAgente.PreventEnterBeep = true;
            this.txtAgente.Size = new System.Drawing.Size(173, 22);
            this.txtAgente.TabIndex = 10;
            this.validAgenteAsoc.SetValidator1(this.txtAgente, this.customtxtAgente);
            this.txtAgente.TextChanged += new System.EventHandler(this.txtAgente_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(6, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "Agente";
            // 
            // cboAgentesAsociados
            // 
            this.cboAgentesAsociados.DisplayMember = "Text";
            this.cboAgentesAsociados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAgentesAsociados.ForeColor = System.Drawing.Color.Black;
            this.cboAgentesAsociados.FormattingEnabled = true;
            this.cboAgentesAsociados.ItemHeight = 16;
            this.cboAgentesAsociados.Location = new System.Drawing.Point(48, 24);
            this.cboAgentesAsociados.Name = "cboAgentesAsociados";
            this.cboAgentesAsociados.Size = new System.Drawing.Size(173, 22);
            this.cboAgentesAsociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAgentesAsociados.TabIndex = 13;
            this.cboAgentesAsociados.SelectionChangeCommitted += new System.EventHandler(this.cboAgentesAsociados_SelectionChangeCommitted);
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DisplayMember = "Text";
            this.cboTipoBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.ForeColor = System.Drawing.Color.Black;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.ItemHeight = 16;
            this.cboTipoBien.Location = new System.Drawing.Point(6, 21);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(121, 22);
            this.cboTipoBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoBien.TabIndex = 8;
            this.cboTipoBien.SelectionChangeCommitted += new System.EventHandler(this.cboTipoBien_SelectionChangeCommitted);
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregarDetalle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(196, 255);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(97, 29);
            this.btnAgregarDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregarDetalle.TabIndex = 6;
            this.btnAgregarDetalle.Text = "Agregar";
            this.btnAgregarDetalle.Click += new System.EventHandler(this.txtAgregarDetalle_Click);
            // 
            // grillaDetalles
            // 
            this.grillaDetalles.AllowUserToAddRows = false;
            this.grillaDetalles.AllowUserToDeleteRows = false;
            this.grillaDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaDetalles.BackgroundColor = System.Drawing.Color.White;
            this.grillaDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grillaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaDetalles.DefaultCellStyle = dataGridViewCellStyle4;
            this.grillaDetalles.EnableHeadersVisualStyles = false;
            this.grillaDetalles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaDetalles.Location = new System.Drawing.Point(327, 13);
            this.grillaDetalles.Name = "grillaDetalles";
            this.grillaDetalles.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grillaDetalles.Size = new System.Drawing.Size(592, 274);
            this.grillaDetalles.TabIndex = 7;
            this.grillaDetalles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaDetalles_CellClick);
            // 
            // txtCantBien
            // 
            this.txtCantBien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCantBien.Border.Class = "TextBoxBorder";
            this.txtCantBien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCantBien.DisabledBackColor = System.Drawing.Color.White;
            this.txtCantBien.ForeColor = System.Drawing.Color.Black;
            this.txtCantBien.Location = new System.Drawing.Point(285, 49);
            this.txtCantBien.Name = "txtCantBien";
            this.txtCantBien.PreventEnterBeep = true;
            this.txtCantBien.Size = new System.Drawing.Size(36, 22);
            this.txtCantBien.TabIndex = 5;
            this.txtCantBien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.validCantBien.SetValidator1(this.txtCantBien, this.customValidtxtCantBien);
            // 
            // lblCantidad
            // 
            // 
            // 
            // 
            this.lblCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCantidad.Location = new System.Drawing.Point(233, 47);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(46, 23);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtBien
            // 
            this.txtBien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBien.Border.Class = "TextBoxBorder";
            this.txtBien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBien.DisabledBackColor = System.Drawing.Color.White;
            this.txtBien.ForeColor = System.Drawing.Color.Black;
            this.txtBien.Location = new System.Drawing.Point(6, 50);
            this.txtBien.Name = "txtBien";
            this.txtBien.PreventEnterBeep = true;
            this.txtBien.Size = new System.Drawing.Size(221, 22);
            this.txtBien.TabIndex = 3;
            this.validBien.SetValidator1(this.txtBien, this.customValidator2);
            this.txtBien.TextChanged += new System.EventHandler(this.txtBien_TextChanged);
            // 
            // cboBien
            // 
            this.cboBien.DisplayMember = "Text";
            this.cboBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBien.ForeColor = System.Drawing.Color.Black;
            this.cboBien.FormattingEnabled = true;
            this.cboBien.ItemHeight = 16;
            this.cboBien.Location = new System.Drawing.Point(6, 50);
            this.cboBien.Name = "cboBien";
            this.cboBien.Size = new System.Drawing.Size(221, 22);
            this.cboBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBien.TabIndex = 10;
            this.cboBien.SelectionChangeCommitted += new System.EventHandler(this.cboBien_SelectionChangeCommitted);
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(21, 31);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(121, 17);
            this.lblDependencia.TabIndex = 0;
            this.lblDependencia.Text = "lblDependencia";
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(21, 50);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(315, 22);
            this.textBoxX1.TabIndex = 1;
            this.ValidDep2.SetValidator1(this.textBoxX1, this.customValidator1);
            this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(21, 50);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(315, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 20;
            this.comboBoxEx4.Visible = false;
            this.comboBoxEx4.SelectionChangeCommitted += new System.EventHandler(this.comboBoxEx4_SelectionChangeCommitted);
            // 
            // validDependencia
            // 
            this.validDependencia.ContainerControl = this;
            this.validDependencia.ErrorProvider = this.errorProvider1;
            this.validDependencia.Highlighter = this.highlighter1;
            this.validDependencia.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.ValidatingEventPerControl;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // ValidDep2
            // 
            this.ValidDep2.ContainerControl = this;
            this.ValidDep2.ErrorProvider = this.errorProvider2;
            this.ValidDep2.Highlighter = this.highlighter2;
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Your error message here.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidatorDependencia_ValidateValue);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // highlighter2
            // 
            this.highlighter2.ContainerControl = this;
            // 
            // validCantBien
            // 
            this.validCantBien.ContainerControl = this;
            this.validCantBien.ErrorProvider = this.errorProvider3;
            this.validCantBien.Highlighter = this.highlighter3;
            // 
            // customValidtxtCantBien
            // 
            this.customValidtxtCantBien.ErrorMessage = "Your error message here.";
            this.customValidtxtCantBien.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidtxtCantBien.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.EventValidtxtCantBien);
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider3.Icon")));
            // 
            // highlighter3
            // 
            this.highlighter3.ContainerControl = this;
            // 
            // validBien
            // 
            this.validBien.ContainerControl = this;
            this.validBien.ErrorProvider = this.errorProvider4;
            this.validBien.Highlighter = this.highlighter4;
            // 
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "Ingrese un bien";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidatorBien_ValidateValue);
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            this.errorProvider4.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider4.Icon")));
            // 
            // highlighter4
            // 
            this.highlighter4.ContainerControl = this;
            // 
            // validAgenteAsoc
            // 
            this.validAgenteAsoc.ContainerControl = this;
            this.validAgenteAsoc.ErrorProvider = this.errorProvider5;
            this.validAgenteAsoc.Highlighter = this.highlighter5;
            // 
            // customtxtAgente
            // 
            this.customtxtAgente.ErrorMessage = "Your error message here.";
            this.customtxtAgente.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customtxtAgente.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.EventValidatetxtAgente);
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            this.errorProvider5.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider5.Icon")));
            // 
            // highlighter5
            // 
            this.highlighter5.ContainerControl = this;
            // 
            // validNota
            // 
            this.validNota.ContainerControl = this;
            this.validNota.ErrorProvider = this.errorProvider6;
            this.validNota.Highlighter = this.highlighter6;
            // 
            // customtxtNota
            // 
            this.customtxtNota.ErrorMessage = "Your error message here.";
            this.customtxtNota.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customtxtNota.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.EventValidtxtNota);
            // 
            // errorProvider6
            // 
            this.errorProvider6.ContainerControl = this;
            this.errorProvider6.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider6.Icon")));
            // 
            // highlighter6
            // 
            this.highlighter6.ContainerControl = this;
            // 
            // CrearSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 671);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CrearSolicitud";
            this.Text = "Crear Solicitud";
            this.Load += new System.EventHandler(this.CrearSolicitud_Load);
            this.panel1.ResumeLayout(false);
            this.gboxNotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).EndInit();
            this.pnlAdjuntos.ResumeLayout(false);
            this.gboxBienes.ResumeLayout(false);
            this.gboxAsociados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgentesAsociados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gboxBienes;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetalles;
        private DevComponents.DotNetBar.ButtonX btnAgregarDetalle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCantBien;
        private DevComponents.DotNetBar.LabelX lblCantidad;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBien;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private System.Windows.Forms.Panel pnlAdjuntos;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAsignado;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPrioridad;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboEstadoSolicitud;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaInicio;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtNota;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoBien;
        private System.Windows.Forms.GroupBox gboxAsociados;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAgente;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnAsociarAgente;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaAgentesAsociados;
        private System.Windows.Forms.GroupBox gboxNotas;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgentesAsociados;
        private DevComponents.DotNetBar.Validator.SuperValidator validDependencia;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.SuperValidator ValidDep2;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter2;
        private DevComponents.DotNetBar.Validator.SuperValidator validCantBien;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter3;
        private DevComponents.DotNetBar.ButtonX btnCrearSolicitud;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Validator.SuperValidator validBien;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter4;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaNotas;
        private DevComponents.DotNetBar.ButtonX btnNotas;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgenteResp;
        private DevComponents.DotNetBar.LabelX lblAgenteResponsable;
        private DevComponents.DotNetBar.ListBoxAdv lstAdjuntos;
        private DevComponents.DotNetBar.Validator.SuperValidator validAgenteAsoc;
        private System.Windows.Forms.ErrorProvider errorProvider5;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter5;
        private DevComponents.DotNetBar.Validator.CustomValidator customtxtAgente;
        private DevComponents.DotNetBar.Validator.SuperValidator validNota;
        private System.Windows.Forms.ErrorProvider errorProvider6;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter6;
        private DevComponents.DotNetBar.Validator.CustomValidator customtxtNota;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidtxtCantBien;
        private DevComponents.DotNetBar.ButtonX btnNuevoDetalle;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.ButtonX btnEliminarAdjunto;
    }
}