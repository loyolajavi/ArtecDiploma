using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class frmAdquisicionGestion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdquisicionGestion));
            this.txtIdAdquisicion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdAdquisicion = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtNroPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtFechaCompra = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblFechaCompra = new DevComponents.DotNetBar.LabelX();
            this.lblFecha = new DevComponents.DotNetBar.LabelX();
            this.txtFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtNroFactura = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroFactura = new DevComponents.DotNetBar.LabelX();
            this.GrillaInventarios = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.pnlBotones = new DevComponents.DotNetBar.PanelEx();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.flowBienesAAdquirir = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFlow = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnBienesRestantes = new DevComponents.DotNetBar.ButtonX();
            this.lblProveedor = new DevComponents.DotNetBar.LabelX();
            this.txtProveedor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboProveedor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInventarios)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlFlow.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdAdquisicion
            // 
            this.txtIdAdquisicion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIdAdquisicion.Border.Class = "TextBoxBorder";
            this.txtIdAdquisicion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdAdquisicion.DisabledBackColor = System.Drawing.Color.White;
            this.txtIdAdquisicion.ForeColor = System.Drawing.Color.Black;
            this.txtIdAdquisicion.Location = new System.Drawing.Point(133, 9);
            this.txtIdAdquisicion.Name = "txtIdAdquisicion";
            this.txtIdAdquisicion.PreventEnterBeep = true;
            this.txtIdAdquisicion.ReadOnly = true;
            this.txtIdAdquisicion.Size = new System.Drawing.Size(102, 22);
            this.txtIdAdquisicion.TabIndex = 78;
            // 
            // lblIdAdquisicion
            // 
            // 
            // 
            // 
            this.lblIdAdquisicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdAdquisicion.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdAdquisicion.Location = new System.Drawing.Point(12, 9);
            this.lblIdAdquisicion.Name = "lblIdAdquisicion";
            this.lblIdAdquisicion.Size = new System.Drawing.Size(115, 22);
            this.lblIdAdquisicion.TabIndex = 77;
            this.lblIdAdquisicion.Text = "lblIdAdquisicion";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 70);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(91, 22);
            this.labelX2.TabIndex = 74;
            this.labelX2.Text = "Dependencia";
            // 
            // txtNroPartida
            // 
            this.txtNroPartida.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroPartida.Border.Class = "TextBoxBorder";
            this.txtNroPartida.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroPartida.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroPartida.ForeColor = System.Drawing.Color.Black;
            this.txtNroPartida.Location = new System.Drawing.Point(133, 39);
            this.txtNroPartida.Name = "txtNroPartida";
            this.txtNroPartida.PreventEnterBeep = true;
            this.txtNroPartida.ReadOnly = true;
            this.txtNroPartida.Size = new System.Drawing.Size(102, 22);
            this.txtNroPartida.TabIndex = 73;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 42);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(97, 17);
            this.labelX1.TabIndex = 72;
            this.labelX1.Text = "lblNroPartida";
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
            this.txtDep.Location = new System.Drawing.Point(133, 70);
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.ReadOnly = true;
            this.txtDep.Size = new System.Drawing.Size(306, 22);
            this.txtDep.TabIndex = 75;
            this.txtDep.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(133, 70);
            this.cboDep.MaxDropDownItems = 10;
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(306, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 76;
            this.cboDep.Visible = false;
            this.cboDep.SelectionChangeCommitted += new System.EventHandler(this.cboDep_SelectionChangeCommitted);
            // 
            // txtFechaCompra
            // 
            // 
            // 
            // 
            this.txtFechaCompra.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaCompra.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaCompra.ButtonDropDown.Visible = true;
            this.txtFechaCompra.IsPopupCalendarOpen = false;
            this.txtFechaCompra.Location = new System.Drawing.Point(361, 39);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaCompra.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaCompra.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaCompra.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaCompra.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaCompra.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            this.txtFechaCompra.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaCompra.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaCompra.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(79, 22);
            this.txtFechaCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaCompra.TabIndex = 86;
            // 
            // lblFechaCompra
            // 
            // 
            // 
            // 
            this.lblFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaCompra.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Location = new System.Drawing.Point(246, 41);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(121, 17);
            this.lblFechaCompra.TabIndex = 85;
            this.lblFechaCompra.Text = "lblFechaCompra";
            // 
            // lblFecha
            // 
            // 
            // 
            // 
            this.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFecha.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(298, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(62, 22);
            this.lblFecha.TabIndex = 83;
            this.lblFecha.Text = "lblFecha";
            // 
            // txtFecha
            // 
            // 
            // 
            // 
            this.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFecha.ButtonDropDown.Visible = true;
            this.txtFecha.IsPopupCalendarOpen = false;
            this.txtFecha.Location = new System.Drawing.Point(361, 9);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFecha.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFecha.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFecha.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFecha.MonthCalendar.TodayButtonVisible = true;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(79, 22);
            this.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFecha.TabIndex = 84;
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
            this.txtNroSolicitud.Location = new System.Drawing.Point(560, 39);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.ReadOnly = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtNroSolicitud.TabIndex = 82;
            // 
            // lblNroSolicitud
            // 
            // 
            // 
            // 
            this.lblNroSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolicitud.Location = new System.Drawing.Point(457, 39);
            this.lblNroSolicitud.Name = "lblNroSolicitud";
            this.lblNroSolicitud.Size = new System.Drawing.Size(91, 22);
            this.lblNroSolicitud.TabIndex = 81;
            this.lblNroSolicitud.Text = "NroSolicitud";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroFactura.Border.Class = "TextBoxBorder";
            this.txtNroFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroFactura.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroFactura.ForeColor = System.Drawing.Color.Black;
            this.txtNroFactura.Location = new System.Drawing.Point(560, 9);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.PreventEnterBeep = true;
            this.txtNroFactura.Size = new System.Drawing.Size(102, 22);
            this.txtNroFactura.TabIndex = 79;
            // 
            // lblNroFactura
            // 
            // 
            // 
            // 
            this.lblNroFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroFactura.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFactura.Location = new System.Drawing.Point(457, 9);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(97, 22);
            this.lblNroFactura.TabIndex = 80;
            this.lblNroFactura.Text = "lblNroFactura";
            // 
            // GrillaInventarios
            // 
            this.GrillaInventarios.AllowUserToAddRows = false;
            this.GrillaInventarios.AllowUserToDeleteRows = false;
            this.GrillaInventarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaInventarios.BackgroundColor = System.Drawing.Color.White;
            this.GrillaInventarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaInventarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaInventarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaInventarios.Location = new System.Drawing.Point(12, 98);
            this.GrillaInventarios.Name = "GrillaInventarios";
            this.GrillaInventarios.ReadOnly = true;
            this.GrillaInventarios.Size = new System.Drawing.Size(649, 159);
            this.GrillaInventarios.TabIndex = 87;
            this.GrillaInventarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaInventarios_CellClick);
            this.GrillaInventarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaInventarios_CellDoubleClick);
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(12, 98);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n\\viewkind4\\uc1\\pard\\la" +
    "ng11274\\ul\\b\\f0\\fs24 No hay resultados\\par\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(649, 159);
            this.txtResBusqueda.TabIndex = 88;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // pnlBotones
            // 
            this.pnlBotones.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBotones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBotones.Controls.Add(this.btnModificar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 340);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(678, 56);
            this.pnlBotones.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBotones.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.pnlBotones.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.pnlBotones.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.pnlBotones.Style.BorderWidth = 0;
            this.pnlBotones.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBotones.Style.GradientAngle = 90;
            this.pnlBotones.TabIndex = 92;
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(311, 14);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 68;
            this.btnModificar.Tag = ((object)(resources.GetObject("btnModificar.Tag")));
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Location = new System.Drawing.Point(586, 23);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 69;
            this.btnEliminar.Tag = ((object)(resources.GetObject("btnEliminar.Tag")));
            this.btnEliminar.Text = "btnEliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // flowBienesAAdquirir
            // 
            this.flowBienesAAdquirir.AutoScroll = true;
            this.flowBienesAAdquirir.AutoSize = true;
            this.flowBienesAAdquirir.BackColor = System.Drawing.Color.Transparent;
            this.flowBienesAAdquirir.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowBienesAAdquirir.Location = new System.Drawing.Point(39, 11);
            this.flowBienesAAdquirir.MaximumSize = new System.Drawing.Size(556, 1800);
            this.flowBienesAAdquirir.Name = "flowBienesAAdquirir";
            this.flowBienesAAdquirir.Size = new System.Drawing.Size(556, 21);
            this.flowBienesAAdquirir.TabIndex = 67;
            this.flowBienesAAdquirir.Visible = false;
            this.flowBienesAAdquirir.WrapContents = false;
            // 
            // pnlFlow
            // 
            this.pnlFlow.AutoSize = true;
            this.pnlFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFlow.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlFlow.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlFlow.Controls.Add(this.flowBienesAAdquirir);
            this.pnlFlow.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlFlow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFlow.Location = new System.Drawing.Point(0, 305);
            this.pnlFlow.Name = "pnlFlow";
            this.pnlFlow.Size = new System.Drawing.Size(678, 35);
            this.pnlFlow.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlFlow.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.pnlFlow.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.pnlFlow.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlFlow.Style.BorderWidth = 0;
            this.pnlFlow.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlFlow.Style.GradientAngle = 90;
            this.pnlFlow.TabIndex = 93;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnBienesRestantes);
            this.panelEx1.Controls.Add(this.lblProveedor);
            this.panelEx1.Controls.Add(this.txtProveedor);
            this.panelEx1.Controls.Add(this.cboProveedor);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(678, 286);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 104;
            // 
            // btnBienesRestantes
            // 
            this.btnBienesRestantes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBienesRestantes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBienesRestantes.Location = new System.Drawing.Point(12, 266);
            this.btnBienesRestantes.Name = "btnBienesRestantes";
            this.btnBienesRestantes.Size = new System.Drawing.Size(102, 17);
            this.btnBienesRestantes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBienesRestantes.TabIndex = 108;
            this.btnBienesRestantes.Text = "btnBienesRestantes";
            this.btnBienesRestantes.Click += new System.EventHandler(this.btnBienesRestantes_Click);
            // 
            // lblProveedor
            // 
            // 
            // 
            // 
            this.lblProveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProveedor.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(457, 70);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(91, 22);
            this.lblProveedor.TabIndex = 108;
            this.lblProveedor.Text = "lblProveedor";
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtProveedor.Border.Class = "TextBoxBorder";
            this.txtProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProveedor.DisabledBackColor = System.Drawing.Color.White;
            this.txtProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtProveedor.Location = new System.Drawing.Point(560, 70);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.PreventEnterBeep = true;
            this.txtProveedor.Size = new System.Drawing.Size(102, 22);
            this.txtProveedor.TabIndex = 108;
            this.txtProveedor.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
            // 
            // cboProveedor
            // 
            this.cboProveedor.DisplayMember = "Text";
            this.cboProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.ForeColor = System.Drawing.Color.Black;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ItemHeight = 16;
            this.cboProveedor.Location = new System.Drawing.Point(560, 70);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(101, 22);
            this.cboProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProveedor.TabIndex = 108;
            this.cboProveedor.SelectionChangeCommitted += new System.EventHandler(this.cboProovedor_SelectionChangeCommitted);
            // 
            // frmAdquisicionGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(678, 396);
            this.Controls.Add(this.pnlFlow);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.GrillaInventarios);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.lblFechaCompra);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblNroSolicitud);
            this.Controls.Add(this.txtNroFactura);
            this.Controls.Add(this.lblNroFactura);
            this.Controls.Add(this.txtIdAdquisicion);
            this.Controls.Add(this.lblIdAdquisicion);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtNroPartida);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.cboDep);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.txtResBusqueda);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmAdquisicionGestion";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmAdquisicionGestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInventarios)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlFlow.ResumeLayout(false);
            this.pnlFlow.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtIdAdquisicion;
        private DevComponents.DotNetBar.LabelX lblIdAdquisicion;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPartida;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDep;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaCompra;
        private DevComponents.DotNetBar.LabelX lblFechaCompra;
        private DevComponents.DotNetBar.LabelX lblFecha;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFecha;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.LabelX lblNroSolicitud;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroFactura;
        private DevComponents.DotNetBar.LabelX lblNroFactura;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaInventarios;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
        private DevComponents.DotNetBar.PanelEx pnlBotones;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private System.Windows.Forms.FlowLayoutPanel flowBienesAAdquirir;
        private DevComponents.DotNetBar.PanelEx pnlFlow;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProveedor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProveedor;
        private DevComponents.DotNetBar.LabelX lblProveedor;
        private DevComponents.DotNetBar.ButtonX btnBienesRestantes;
    }
}