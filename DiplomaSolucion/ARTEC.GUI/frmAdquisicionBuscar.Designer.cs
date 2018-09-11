namespace ARTEC.GUI
{
    partial class frmAdquisicionBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdquisicionBuscar));
            this.txtNroPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtNroFactura = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroFactura = new DevComponents.DotNetBar.LabelX();
            this.lblSerieKey = new DevComponents.DotNetBar.LabelX();
            this.txtSerieKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolicitud = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblFecha = new DevComponents.DotNetBar.LabelX();
            this.txtFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtFechaCompra = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblFechaCompra = new DevComponents.DotNetBar.LabelX();
            this.txtIdAdquisicion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdAdquisicion = new DevComponents.DotNetBar.LabelX();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.GrillaAdquisicionBuscar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.vldFrmAdquisicionBuscar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator2 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator3 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator4 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator5 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator6 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAdquisicionBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.txtNroPartida.Location = new System.Drawing.Point(123, 42);
            this.txtNroPartida.Name = "txtNroPartida";
            this.txtNroPartida.PreventEnterBeep = true;
            this.txtNroPartida.Size = new System.Drawing.Size(102, 22);
            this.txtNroPartida.TabIndex = 60;
            this.vldFrmAdquisicionBuscar.SetValidator1(this.txtNroPartida, this.regularExpressionValidator3);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(2, 45);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(97, 17);
            this.labelX1.TabIndex = 59;
            this.labelX1.Text = "lblNroPartida";
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
            this.txtNroFactura.Location = new System.Drawing.Point(549, 12);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.PreventEnterBeep = true;
            this.txtNroFactura.Size = new System.Drawing.Size(102, 22);
            this.txtNroFactura.TabIndex = 57;
            this.vldFrmAdquisicionBuscar.SetValidator1(this.txtNroFactura, this.regularExpressionValidator4);
            // 
            // lblNroFactura
            // 
            // 
            // 
            // 
            this.lblNroFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroFactura.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFactura.Location = new System.Drawing.Point(446, 12);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(97, 22);
            this.lblNroFactura.TabIndex = 58;
            this.lblNroFactura.Text = "lblNroFactura";
            // 
            // lblSerieKey
            // 
            // 
            // 
            // 
            this.lblSerieKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerieKey.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieKey.Location = new System.Drawing.Point(446, 45);
            this.lblSerieKey.Name = "lblSerieKey";
            this.lblSerieKey.Size = new System.Drawing.Size(91, 17);
            this.lblSerieKey.TabIndex = 56;
            this.lblSerieKey.Text = "lblSerieKey";
            // 
            // txtSerieKey
            // 
            this.txtSerieKey.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSerieKey.Border.Class = "TextBoxBorder";
            this.txtSerieKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSerieKey.DisabledBackColor = System.Drawing.Color.White;
            this.txtSerieKey.ForeColor = System.Drawing.Color.Black;
            this.txtSerieKey.Location = new System.Drawing.Point(549, 42);
            this.txtSerieKey.Name = "txtSerieKey";
            this.txtSerieKey.PreventEnterBeep = true;
            this.txtSerieKey.Size = new System.Drawing.Size(102, 22);
            this.txtSerieKey.TabIndex = 55;
            this.vldFrmAdquisicionBuscar.SetValidator1(this.txtSerieKey, this.regularExpressionValidator5);
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
            this.txtDep.Location = new System.Drawing.Point(123, 73);
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.Size = new System.Drawing.Size(306, 22);
            this.txtDep.TabIndex = 64;
            this.vldFrmAdquisicionBuscar.SetValidator1(this.txtDep, this.regularExpressionValidator6);
            this.txtDep.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
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
            this.txtNroSolicitud.Location = new System.Drawing.Point(549, 73);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtNroSolicitud.TabIndex = 63;
            this.vldFrmAdquisicionBuscar.SetValidator1(this.txtNroSolicitud, this.regularExpressionValidator1);
            // 
            // lblNroSolicitud
            // 
            // 
            // 
            // 
            this.lblNroSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolicitud.Location = new System.Drawing.Point(446, 73);
            this.lblNroSolicitud.Name = "lblNroSolicitud";
            this.lblNroSolicitud.Size = new System.Drawing.Size(91, 22);
            this.lblNroSolicitud.TabIndex = 62;
            this.lblNroSolicitud.Text = "NroSolicitud";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(2, 73);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(91, 22);
            this.labelX2.TabIndex = 61;
            this.labelX2.Text = "Dependencia";
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(123, 73);
            this.cboDep.MaxDropDownItems = 10;
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(306, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 65;
            this.cboDep.Visible = false;
            this.cboDep.SelectionChangeCommitted += new System.EventHandler(this.cboDep_SelectionChangeCommitted);
            // 
            // lblFecha
            // 
            // 
            // 
            // 
            this.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFecha.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(287, 12);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(62, 22);
            this.lblFecha.TabIndex = 66;
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
            this.txtFecha.Location = new System.Drawing.Point(350, 12);
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
            this.txtFecha.TabIndex = 67;
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
            this.txtFechaCompra.Location = new System.Drawing.Point(350, 42);
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
            this.txtFechaCompra.TabIndex = 69;
            // 
            // lblFechaCompra
            // 
            // 
            // 
            // 
            this.lblFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaCompra.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Location = new System.Drawing.Point(235, 44);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(121, 17);
            this.lblFechaCompra.TabIndex = 68;
            this.lblFechaCompra.Text = "lblFechaCompra";
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
            this.txtIdAdquisicion.Location = new System.Drawing.Point(123, 12);
            this.txtIdAdquisicion.Name = "txtIdAdquisicion";
            this.txtIdAdquisicion.PreventEnterBeep = true;
            this.txtIdAdquisicion.Size = new System.Drawing.Size(102, 22);
            this.txtIdAdquisicion.TabIndex = 71;
            this.vldFrmAdquisicionBuscar.SetValidator1(this.txtIdAdquisicion, this.regularExpressionValidator2);
            // 
            // lblIdAdquisicion
            // 
            // 
            // 
            // 
            this.lblIdAdquisicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdAdquisicion.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdAdquisicion.Location = new System.Drawing.Point(2, 12);
            this.lblIdAdquisicion.Name = "lblIdAdquisicion";
            this.lblIdAdquisicion.Size = new System.Drawing.Size(115, 22);
            this.lblIdAdquisicion.TabIndex = 70;
            this.lblIdAdquisicion.Text = "lblIdAdquisicion";
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(123, 103);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 72;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(2, 137);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n\\viewkind4\\uc1\\pard\\la" +
    "ng11274\\ul\\b\\f0\\fs24 No hay resultados\\par\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(649, 252);
            this.txtResBusqueda.TabIndex = 73;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // GrillaAdquisicionBuscar
            // 
            this.GrillaAdquisicionBuscar.AllowUserToAddRows = false;
            this.GrillaAdquisicionBuscar.AllowUserToDeleteRows = false;
            this.GrillaAdquisicionBuscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaAdquisicionBuscar.BackgroundColor = System.Drawing.Color.White;
            this.GrillaAdquisicionBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaAdquisicionBuscar.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaAdquisicionBuscar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaAdquisicionBuscar.Location = new System.Drawing.Point(2, 137);
            this.GrillaAdquisicionBuscar.Name = "GrillaAdquisicionBuscar";
            this.GrillaAdquisicionBuscar.ReadOnly = true;
            this.GrillaAdquisicionBuscar.Size = new System.Drawing.Size(649, 252);
            this.GrillaAdquisicionBuscar.TabIndex = 74;
            // 
            // vldFrmAdquisicionBuscar
            // 
            this.vldFrmAdquisicionBuscar.ContainerControl = this.btnBuscar;
            this.vldFrmAdquisicionBuscar.ErrorProvider = this.errorProvider1;
            this.vldFrmAdquisicionBuscar.Highlighter = this.highlighter1;
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
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.EmptyValueIsValid = true;
            this.regularExpressionValidator1.ErrorMessage = "Sólo números";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator1.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.EmptyValueIsValid = true;
            this.regularExpressionValidator2.ErrorMessage = "Sólo Números";
            this.regularExpressionValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator2.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // regularExpressionValidator3
            // 
            this.regularExpressionValidator3.EmptyValueIsValid = true;
            this.regularExpressionValidator3.ErrorMessage = "Sólo Números";
            this.regularExpressionValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator3.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // regularExpressionValidator4
            // 
            this.regularExpressionValidator4.EmptyValueIsValid = true;
            this.regularExpressionValidator4.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator4.ValidationExpression = "^[a-zA-Z0-9]*$";
            // 
            // regularExpressionValidator5
            // 
            this.regularExpressionValidator5.EmptyValueIsValid = true;
            this.regularExpressionValidator5.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator5.ValidationExpression = "^[a-zA-Z0-9]*$";
            // 
            // regularExpressionValidator6
            // 
            this.regularExpressionValidator6.EmptyValueIsValid = true;
            this.regularExpressionValidator6.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator6.ValidationExpression = "^[a-zA-Z0-9 ]*$";
            // 
            // frmAdquisicionBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 396);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdAdquisicion);
            this.Controls.Add(this.lblIdAdquisicion);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.lblFechaCompra);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblNroSolicitud);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtNroPartida);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtNroFactura);
            this.Controls.Add(this.lblNroFactura);
            this.Controls.Add(this.lblSerieKey);
            this.Controls.Add(this.txtSerieKey);
            this.Controls.Add(this.txtResBusqueda);
            this.Controls.Add(this.GrillaAdquisicionBuscar);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.cboDep);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAdquisicionBuscar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmAdquisicionBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAdquisicionBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPartida;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroFactura;
        private DevComponents.DotNetBar.LabelX lblNroFactura;
        private DevComponents.DotNetBar.LabelX lblSerieKey;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerieKey;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDep;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.LabelX lblNroSolicitud;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;
        private DevComponents.DotNetBar.LabelX lblFecha;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFecha;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaCompra;
        private DevComponents.DotNetBar.LabelX lblFechaCompra;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdAdquisicion;
        private DevComponents.DotNetBar.LabelX lblIdAdquisicion;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaAdquisicionBuscar;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmAdquisicionBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator3;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator4;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator5;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator6;
    }
}