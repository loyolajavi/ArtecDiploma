using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class SolicitudBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudBuscar));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtFechaFin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtFechaInicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lblNroSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboAsignado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboPrioridad = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboEstadoSolicitud = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.GrillaSolicitudBuscar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.vldNroSolic = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.vld1NroSolic = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider1SolicBus = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.txtFechaInicio2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtFechaFin2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaSolicitudBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1SolicBus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaFin2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(7, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(91, 22);
            this.labelX1.TabIndex = 26;
            this.labelX1.Text = "Dependencia";
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
            this.txtBien.Location = new System.Drawing.Point(104, 63);
            this.txtBien.Name = "txtBien";
            this.txtBien.PreventEnterBeep = true;
            this.txtBien.Size = new System.Drawing.Size(315, 22);
            this.txtBien.TabIndex = 27;
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(104, 35);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(315, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 28;
            this.comboBoxEx4.Visible = false;
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
            this.txtFechaFin.Location = new System.Drawing.Point(664, 63);
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
            this.txtFechaFin.TabIndex = 34;
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
            this.txtFechaInicio.Location = new System.Drawing.Point(664, 21);
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
            this.txtFechaInicio.TabIndex = 33;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX6.Location = new System.Drawing.Point(664, 44);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(91, 21);
            this.labelX6.TabIndex = 32;
            this.labelX6.Text = "Finalización";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX5.Location = new System.Drawing.Point(664, 1);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(69, 22);
            this.labelX5.TabIndex = 31;
            this.labelX5.Text = "Creación";
            // 
            // lblNroSolicitud
            // 
            // 
            // 
            // 
            this.lblNroSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolicitud.Location = new System.Drawing.Point(7, 7);
            this.lblNroSolicitud.Name = "lblNroSolicitud";
            this.lblNroSolicitud.Size = new System.Drawing.Size(91, 22);
            this.lblNroSolicitud.TabIndex = 35;
            this.lblNroSolicitud.Text = "NroSolicitud";
            // 
            // txtNroSolicitud
            // 
            this.txtNroSolicitud.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroSolicitud.Border.Class = "TextBoxBorder";
            this.txtNroSolicitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroSolicitud.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroSolicitud.ForeColor = System.Drawing.Color.Black;
            this.txtNroSolicitud.Location = new System.Drawing.Point(104, 7);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(315, 22);
            this.txtNroSolicitud.TabIndex = 36;
            this.vldNroSolic.SetValidator1(this.txtNroSolicitud, this.vld1NroSolic);
            this.txtNroSolicitud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroSolicitud_KeyPress);
            // 
            // cboAsignado
            // 
            this.cboAsignado.DisplayMember = "Text";
            this.cboAsignado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsignado.ForeColor = System.Drawing.Color.Black;
            this.cboAsignado.FormattingEnabled = true;
            this.cboAsignado.ItemHeight = 16;
            this.cboAsignado.Location = new System.Drawing.Point(524, 63);
            this.cboAsignado.Name = "cboAsignado";
            this.cboAsignado.Size = new System.Drawing.Size(116, 22);
            this.cboAsignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAsignado.TabIndex = 42;
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.DisplayMember = "Text";
            this.cboPrioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridad.ForeColor = System.Drawing.Color.Black;
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.ItemHeight = 16;
            this.cboPrioridad.Location = new System.Drawing.Point(524, 35);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(116, 22);
            this.cboPrioridad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPrioridad.TabIndex = 41;
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.DisplayMember = "Text";
            this.cboEstadoSolicitud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolicitud.ForeColor = System.Drawing.Color.Black;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.ItemHeight = 16;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(524, 7);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(116, 22);
            this.cboEstadoSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboEstadoSolicitud.TabIndex = 40;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX8.Location = new System.Drawing.Point(434, 7);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(93, 22);
            this.labelX8.TabIndex = 37;
            this.labelX8.Text = "Estado";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX10.Location = new System.Drawing.Point(434, 63);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(93, 22);
            this.labelX10.TabIndex = 39;
            this.labelX10.Text = "Asignado a";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.labelX9.Location = new System.Drawing.Point(434, 35);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(93, 22);
            this.labelX9.TabIndex = 38;
            this.labelX9.Text = "Prioridad";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(7, 63);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(91, 22);
            this.labelX3.TabIndex = 43;
            this.labelX3.Text = "Bien";
            // 
            // txtDep
            // 
            this.txtDep.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDep.Border.Class = "TextBoxBorder";
            this.txtDep.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDep.DisabledBackColor = System.Drawing.Color.White;
            this.txtDep.ForeColor = System.Drawing.Color.Black;
            this.txtDep.Location = new System.Drawing.Point(104, 35);
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.Size = new System.Drawing.Size(315, 22);
            this.txtDep.TabIndex = 44;
            this.txtDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDep_KeyPress);
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(104, 63);
            this.comboBoxEx1.MaxDropDownItems = 10;
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(315, 22);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 45;
            this.comboBoxEx1.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(104, 91);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // GrillaSolicitudBuscar
            // 
            this.GrillaSolicitudBuscar.AllowUserToAddRows = false;
            this.GrillaSolicitudBuscar.AllowUserToDeleteRows = false;
            this.GrillaSolicitudBuscar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.GrillaSolicitudBuscar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaSolicitudBuscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaSolicitudBuscar.BackgroundColor = System.Drawing.Color.White;
            this.GrillaSolicitudBuscar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GrillaSolicitudBuscar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaSolicitudBuscar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaSolicitudBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaSolicitudBuscar.DefaultCellStyle = dataGridViewCellStyle3;
            this.GrillaSolicitudBuscar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaSolicitudBuscar.Location = new System.Drawing.Point(7, 131);
            this.GrillaSolicitudBuscar.Name = "GrillaSolicitudBuscar";
            this.GrillaSolicitudBuscar.ReadOnly = true;
            this.GrillaSolicitudBuscar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaSolicitudBuscar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GrillaSolicitudBuscar.RowHeadersVisible = false;
            this.GrillaSolicitudBuscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaSolicitudBuscar.ShowCellToolTips = false;
            this.GrillaSolicitudBuscar.ShowEditingIcon = false;
            this.GrillaSolicitudBuscar.ShowRowErrors = false;
            this.GrillaSolicitudBuscar.Size = new System.Drawing.Size(882, 372);
            this.GrillaSolicitudBuscar.TabIndex = 47;
            this.GrillaSolicitudBuscar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaSolicitudBuscar_CellDoubleClick);
            // 
            // vldNroSolic
            // 
            this.vldNroSolic.ContainerControl = this;
            this.vldNroSolic.ErrorProvider = this.errorProvider1SolicBus;
            this.vldNroSolic.Highlighter = this.highlighter1;
            // 
            // vld1NroSolic
            // 
            this.vld1NroSolic.ErrorMessage = "error";
            this.vld1NroSolic.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.vld1NroSolic.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.vld1NroSolic_ValidateValue);
            // 
            // errorProvider1SolicBus
            // 
            this.errorProvider1SolicBus.ContainerControl = this;
            this.errorProvider1SolicBus.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1SolicBus.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(7, 131);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n{\\colortbl ;\\red0\\gree" +
    "n0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\cf1\\lang11274\\ul\\b\\f0\\fs24 No hay resultados\\par" +
    "\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(882, 372);
            this.txtResBusqueda.TabIndex = 48;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // txtFechaInicio2
            // 
            // 
            // 
            // 
            this.txtFechaInicio2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaInicio2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaInicio2.ButtonDropDown.Visible = true;
            this.txtFechaInicio2.IsPopupCalendarOpen = false;
            this.txtFechaInicio2.Location = new System.Drawing.Point(761, 21);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaInicio2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaInicio2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaInicio2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaInicio2.Name = "txtFechaInicio2";
            this.txtFechaInicio2.Size = new System.Drawing.Size(79, 22);
            this.txtFechaInicio2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaInicio2.TabIndex = 49;
            // 
            // txtFechaFin2
            // 
            // 
            // 
            // 
            this.txtFechaFin2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaFin2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaFin2.ButtonDropDown.Visible = true;
            this.txtFechaFin2.IsPopupCalendarOpen = false;
            this.txtFechaFin2.Location = new System.Drawing.Point(761, 63);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaFin2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaFin2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaFin2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin2.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaFin2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaFin2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaFin2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaFin2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaFin2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaFin2.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaFin2.Name = "txtFechaFin2";
            this.txtFechaFin2.Size = new System.Drawing.Size(79, 22);
            this.txtFechaFin2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaFin2.TabIndex = 50;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "Artec - Manual de Ayuda.chm";
            // 
            // SolicitudBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1265, 565);
            this.Controls.Add(this.txtFechaFin2);
            this.Controls.Add(this.txtFechaInicio2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.cboAsignado);
            this.Controls.Add(this.cboPrioridad);
            this.Controls.Add(this.cboEstadoSolicitud);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblNroSolicitud);
            this.Controls.Add(this.txtFechaFin);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtBien);
            this.Controls.Add(this.comboBoxEx4);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.txtResBusqueda);
            this.Controls.Add(this.GrillaSolicitudBuscar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.helpProvider1.SetHelpKeyword(this, "Buscar Solicitudes");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "SolicitudBuscar";
            this.helpProvider1.SetShowHelp(this, true);
            this.ShowIcon = false;
            this.Tag = ((object)(resources.GetObject("$this.Tag")));
            this.Text = "MetroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SolicitudBuscar_FormClosing);
            this.Load += new System.EventHandler(this.SolicitudBuscar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SolicitudBuscar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaSolicitudBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1SolicBus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaFin2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaFin;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaInicio;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX lblNroSolicitud;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAsignado;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPrioridad;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboEstadoSolicitud;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDep;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaSolicitudBuscar;
        private DevComponents.DotNetBar.Validator.SuperValidator vldNroSolic;
        private System.Windows.Forms.ErrorProvider errorProvider1SolicBus;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.CustomValidator vld1NroSolic;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaFin2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaInicio2;
        internal System.Windows.Forms.HelpProvider helpProvider1;
    }
}