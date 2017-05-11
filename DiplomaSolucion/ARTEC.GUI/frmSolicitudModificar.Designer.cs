namespace ARTEC.GUI
{
    partial class frmSolicitudModificar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudModificar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAgenteResp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblAgenteResponsable = new DevComponents.DotNetBar.LabelX();
            this.btnCrearSolicitud = new DevComponents.DotNetBar.ButtonX();
            this.gboxNotas = new System.Windows.Forms.GroupBox();
            this.btnNotas = new DevComponents.DotNetBar.ButtonX();
            this.GrillaNotas = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtNota = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.txtFechaFin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cboAsignado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboPrioridad = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboEstadoSolicitud = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtFechaInicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.pnlAdjuntos = new System.Windows.Forms.Panel();
            this.lstAdjuntos = new DevComponents.DotNetBar.ListBoxAdv();
            this.GrillaAdjuntos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSeleccionarArchivo = new DevComponents.DotNetBar.ButtonX();
            this.txtNombreAdjunto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAdjuntar = new DevComponents.DotNetBar.ButtonX();
            this.gboxBienes = new System.Windows.Forms.GroupBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.gboxAsociados = new System.Windows.Forms.GroupBox();
            this.grillaAgentesAsociados = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAsociarAgente = new DevComponents.DotNetBar.ButtonX();
            this.txtAgente = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboAgentesAsociados = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboTipoBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtAgregarDetalle = new DevComponents.DotNetBar.ButtonX();
            this.grillaDetalles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtCantBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCantidad = new DevComponents.DotNetBar.LabelX();
            this.txtBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1.SuspendLayout();
            this.gboxNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).BeginInit();
            this.pnlAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAdjuntos)).BeginInit();
            this.gboxBienes.SuspendLayout();
            this.gboxAsociados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgentesAsociados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboAgenteResp);
            this.panel1.Controls.Add(this.lblAgenteResponsable);
            this.panel1.Controls.Add(this.btnCrearSolicitud);
            this.panel1.Controls.Add(this.gboxNotas);
            this.panel1.Controls.Add(this.txtFechaFin);
            this.panel1.Controls.Add(this.cboAsignado);
            this.panel1.Controls.Add(this.cboPrioridad);
            this.panel1.Controls.Add(this.cboEstadoSolicitud);
            this.panel1.Controls.Add(this.labelX8);
            this.panel1.Controls.Add(this.labelX10);
            this.panel1.Controls.Add(this.labelX9);
            this.panel1.Controls.Add(this.txtFechaInicio);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.pnlAdjuntos);
            this.panel1.Controls.Add(this.gboxBienes);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.textBoxX1);
            this.panel1.Controls.Add(this.comboBoxEx4);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 659);
            this.panel1.TabIndex = 6;
            // 
            // cboAgenteResp
            // 
            this.cboAgenteResp.DisplayMember = "Text";
            this.cboAgenteResp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAgenteResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenteResp.ForeColor = System.Drawing.Color.Black;
            this.cboAgenteResp.FormattingEnabled = true;
            this.cboAgenteResp.ItemHeight = 16;
            this.cboAgenteResp.Location = new System.Drawing.Point(350, 45);
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
            this.lblAgenteResponsable.Location = new System.Drawing.Point(350, 26);
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
            this.btnCrearSolicitud.Location = new System.Drawing.Point(425, 633);
            this.btnCrearSolicitud.Name = "btnCrearSolicitud";
            this.btnCrearSolicitud.Size = new System.Drawing.Size(75, 23);
            this.btnCrearSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearSolicitud.TabIndex = 22;
            this.btnCrearSolicitud.Text = "Modificar";
            // 
            // gboxNotas
            // 
            this.gboxNotas.Controls.Add(this.btnNotas);
            this.gboxNotas.Controls.Add(this.GrillaNotas);
            this.gboxNotas.Controls.Add(this.txtNota);
            this.gboxNotas.Location = new System.Drawing.Point(15, 484);
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
            // 
            // GrillaNotas
            // 
            this.GrillaNotas.AllowUserToOrderColumns = true;
            this.GrillaNotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            // 
            // txtFechaFin
            // 
            // 
            // 
            // 
            this.txtFechaFin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaFin.ButtonDropDown.Visible = true;
            this.txtFechaFin.IsPopupCalendarOpen = false;
            this.txtFechaFin.Location = new System.Drawing.Point(864, 45);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaFin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(79, 22);
            this.txtFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaFin.TabIndex = 12;
            // 
            // cboAsignado
            // 
            this.cboAsignado.DisplayMember = "Text";
            this.cboAsignado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAsignado.ForeColor = System.Drawing.Color.Black;
            this.cboAsignado.FormattingEnabled = true;
            this.cboAsignado.ItemHeight = 16;
            this.cboAsignado.Location = new System.Drawing.Point(141, 439);
            this.cboAsignado.Name = "cboAsignado";
            this.cboAsignado.Size = new System.Drawing.Size(167, 22);
            this.cboAsignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAsignado.TabIndex = 19;
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.DisplayMember = "Text";
            this.cboPrioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPrioridad.ForeColor = System.Drawing.Color.Black;
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.ItemHeight = 16;
            this.cboPrioridad.Location = new System.Drawing.Point(141, 409);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(167, 22);
            this.cboPrioridad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPrioridad.TabIndex = 18;
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.DisplayMember = "Text";
            this.cboEstadoSolicitud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoSolicitud.ForeColor = System.Drawing.Color.Black;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.ItemHeight = 16;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(141, 382);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(167, 22);
            this.cboEstadoSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboEstadoSolicitud.TabIndex = 17;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX8.Location = new System.Drawing.Point(21, 384);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(121, 23);
            this.labelX8.TabIndex = 14;
            this.labelX8.Text = "Estado Solicitud";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX10.Location = new System.Drawing.Point(21, 438);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(87, 23);
            this.labelX10.TabIndex = 16;
            this.labelX10.Text = "Asignado a";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX9.Location = new System.Drawing.Point(21, 409);
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
            this.txtFechaInicio.Location = new System.Drawing.Point(714, 45);
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
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(803, 45);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(65, 22);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "Finalización";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(665, 45);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(48, 22);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Creación";
            // 
            // pnlAdjuntos
            // 
            this.pnlAdjuntos.AllowDrop = true;
            this.pnlAdjuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdjuntos.Controls.Add(this.lstAdjuntos);
            this.pnlAdjuntos.Controls.Add(this.GrillaAdjuntos);
            this.pnlAdjuntos.Controls.Add(this.btnSeleccionarArchivo);
            this.pnlAdjuntos.Controls.Add(this.txtNombreAdjunto);
            this.pnlAdjuntos.Controls.Add(this.btnAdjuntar);
            this.pnlAdjuntos.Location = new System.Drawing.Point(342, 376);
            this.pnlAdjuntos.Name = "pnlAdjuntos";
            this.pnlAdjuntos.Size = new System.Drawing.Size(601, 104);
            this.pnlAdjuntos.TabIndex = 7;
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
            this.lstAdjuntos.Location = new System.Drawing.Point(9, 36);
            this.lstAdjuntos.Name = "lstAdjuntos";
            this.lstAdjuntos.Size = new System.Drawing.Size(428, 63);
            this.lstAdjuntos.TabIndex = 5;
            this.lstAdjuntos.Text = "listBoxAdv1";
            // 
            // GrillaAdjuntos
            // 
            this.GrillaAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaAdjuntos.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaAdjuntos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaAdjuntos.Location = new System.Drawing.Point(7, 35);
            this.GrillaAdjuntos.Name = "GrillaAdjuntos";
            this.GrillaAdjuntos.Size = new System.Drawing.Size(585, 65);
            this.GrillaAdjuntos.TabIndex = 4;
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeleccionarArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(9, 10);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(116, 18);
            this.btnSeleccionarArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSeleccionarArchivo.TabIndex = 2;
            this.btnSeleccionarArchivo.Text = "Seleccionar un archivo";
            // 
            // txtNombreAdjunto
            // 
            this.txtNombreAdjunto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombreAdjunto.Border.Class = "TextBoxBorder";
            this.txtNombreAdjunto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombreAdjunto.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombreAdjunto.ForeColor = System.Drawing.Color.Black;
            this.txtNombreAdjunto.Location = new System.Drawing.Point(7, 8);
            this.txtNombreAdjunto.Name = "txtNombreAdjunto";
            this.txtNombreAdjunto.PreventEnterBeep = true;
            this.txtNombreAdjunto.Size = new System.Drawing.Size(527, 22);
            this.txtNombreAdjunto.TabIndex = 3;
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdjuntar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdjuntar.Location = new System.Drawing.Point(540, 8);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(52, 23);
            this.btnAdjuntar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdjuntar.TabIndex = 1;
            this.btnAdjuntar.Text = "Adjuntar";
            // 
            // gboxBienes
            // 
            this.gboxBienes.Controls.Add(this.buttonX2);
            this.gboxBienes.Controls.Add(this.buttonX1);
            this.gboxBienes.Controls.Add(this.labelX3);
            this.gboxBienes.Controls.Add(this.comboBoxEx1);
            this.gboxBienes.Controls.Add(this.gboxAsociados);
            this.gboxBienes.Controls.Add(this.cboTipoBien);
            this.gboxBienes.Controls.Add(this.txtAgregarDetalle);
            this.gboxBienes.Controls.Add(this.grillaDetalles);
            this.gboxBienes.Controls.Add(this.txtCantBien);
            this.gboxBienes.Controls.Add(this.lblCantidad);
            this.gboxBienes.Controls.Add(this.txtBien);
            this.gboxBienes.Controls.Add(this.cboBien);
            this.gboxBienes.Controls.Add(this.buttonX3);
            this.gboxBienes.Location = new System.Drawing.Point(15, 73);
            this.gboxBienes.Name = "gboxBienes";
            this.gboxBienes.Size = new System.Drawing.Size(1053, 293);
            this.gboxBienes.TabIndex = 2;
            this.gboxBienes.TabStop = false;
            this.gboxBienes.Text = "Agregar Bienes";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(246, 21);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 28;
            this.buttonX2.Text = "Cancelar";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(152, 21);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 27;
            this.buttonX1.Text = "Editar";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(6, 260);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(52, 17);
            this.labelX3.TabIndex = 26;
            this.labelX3.Text = "Estado";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(58, 258);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(108, 22);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 26;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaAgentesAsociados.DefaultCellStyle = dataGridViewCellStyle3;
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
            // 
            // txtAgregarDetalle
            // 
            this.txtAgregarDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtAgregarDetalle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.txtAgregarDetalle.Location = new System.Drawing.Point(196, 255);
            this.txtAgregarDetalle.Name = "txtAgregarDetalle";
            this.txtAgregarDetalle.Size = new System.Drawing.Size(97, 29);
            this.txtAgregarDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtAgregarDetalle.TabIndex = 6;
            this.txtAgregarDetalle.Text = "Agregar";
            // 
            // grillaDetalles
            // 
            this.grillaDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaDetalles.BackgroundColor = System.Drawing.Color.White;
            this.grillaDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grillaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaDetalles.DefaultCellStyle = dataGridViewCellStyle5;
            this.grillaDetalles.EnableHeadersVisualStyles = false;
            this.grillaDetalles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaDetalles.Location = new System.Drawing.Point(327, 13);
            this.grillaDetalles.Name = "grillaDetalles";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grillaDetalles.Size = new System.Drawing.Size(720, 274);
            this.grillaDetalles.TabIndex = 7;
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
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(204, 255);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(86, 29);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 0;
            this.buttonX3.Text = "Confirmar";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(21, 26);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(91, 17);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Dependencia";
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
            this.textBoxX1.Location = new System.Drawing.Point(21, 45);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(315, 22);
            this.textBoxX1.TabIndex = 1;
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(21, 45);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(315, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 20;
            this.comboBoxEx4.Visible = false;
            // 
            // frmSolicitudModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 669);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmSolicitudModificar";
            this.Text = resources.GetString("$this.Text");
            this.Load += new System.EventHandler(this.frmSolicitudModificar_Load);
            this.panel1.ResumeLayout(false);
            this.gboxNotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).EndInit();
            this.pnlAdjuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAdjuntos)).EndInit();
            this.gboxBienes.ResumeLayout(false);
            this.gboxAsociados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgentesAsociados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgenteResp;
        private DevComponents.DotNetBar.LabelX lblAgenteResponsable;
        private DevComponents.DotNetBar.ButtonX btnCrearSolicitud;
        private System.Windows.Forms.GroupBox gboxNotas;
        private DevComponents.DotNetBar.ButtonX btnNotas;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaNotas;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtNota;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaFin;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAsignado;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPrioridad;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboEstadoSolicitud;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaInicio;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.Panel pnlAdjuntos;
        private DevComponents.DotNetBar.ListBoxAdv lstAdjuntos;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaAdjuntos;
        private DevComponents.DotNetBar.ButtonX btnSeleccionarArchivo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombreAdjunto;
        private DevComponents.DotNetBar.ButtonX btnAdjuntar;
        private System.Windows.Forms.GroupBox gboxBienes;
        private System.Windows.Forms.GroupBox gboxAsociados;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaAgentesAsociados;
        private DevComponents.DotNetBar.ButtonX btnAsociarAgente;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAgente;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgentesAsociados;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoBien;
        private DevComponents.DotNetBar.ButtonX txtAgregarDetalle;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetalles;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCantBien;
        private DevComponents.DotNetBar.LabelX lblCantidad;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBien;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
    }
}