namespace ARTEC.GUI
{
    partial class frmBienRegistrar
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
            this.progressSteps1 = new DevComponents.DotNetBar.ProgressSteps();
            this.stepItem1 = new DevComponents.DotNetBar.StepItem();
            this.stepItem2 = new DevComponents.DotNetBar.StepItem();
            this.btnContinuar = new DevComponents.DotNetBar.ButtonX();
            this.txtNroFactura = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFechaCompra = new DevComponents.DotNetBar.LabelX();
            this.lblNroFactura = new DevComponents.DotNetBar.LabelX();
            this.lblMontoTotal = new DevComponents.DotNetBar.LabelX();
            this.lblProveedor = new DevComponents.DotNetBar.LabelX();
            this.txtFechaCompra = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtMontoTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtProveedor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboProveedor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.pnlAdquisicion = new DevComponents.DotNetBar.PanelEx();
            this.txtNroPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pnlBienes = new DevComponents.DotNetBar.PanelEx();
            this.lblCosto = new DevComponents.DotNetBar.LabelX();
            this.GrillaDetallesBienes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtCosto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.pnlHardware = new DevComponents.DotNetBar.PanelEx();
            this.lblSerieKey = new DevComponents.DotNetBar.LabelX();
            this.cboDeposito = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtSerialMaster = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboEstadoInv = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtSerieKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblSerial = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lblDeposito = new DevComponents.DotNetBar.LabelX();
            this.lblSerie = new DevComponents.DotNetBar.LabelX();
            this.GrillaBienes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblBien = new DevComponents.DotNetBar.LabelX();
            this.lblModelo = new DevComponents.DotNetBar.LabelX();
            this.lblMarca = new DevComponents.DotNetBar.LabelX();
            this.lblTipoBien = new DevComponents.DotNetBar.LabelX();
            this.cboModelo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboMarca = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboTipoBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtBienCategoria = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboBienCategoria = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnConfirmar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).BeginInit();
            this.pnlAdquisicion.SuspendLayout();
            this.pnlBienes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesBienes)).BeginInit();
            this.pnlHardware.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).BeginInit();
            this.SuspendLayout();
            // 
            // progressSteps1
            // 
            // 
            // 
            // 
            this.progressSteps1.BackgroundStyle.Class = "ProgressSteps";
            this.progressSteps1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressSteps1.ContainerControlProcessDialogKey = true;
            this.progressSteps1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stepItem1,
            this.stepItem2});
            this.progressSteps1.Location = new System.Drawing.Point(3, 600);
            this.progressSteps1.Name = "progressSteps1";
            this.progressSteps1.Size = new System.Drawing.Size(163, 26);
            this.progressSteps1.TabIndex = 0;
            // 
            // stepItem1
            // 
            this.stepItem1.BackColors = new System.Drawing.Color[] {
        System.Drawing.Color.MediumAquamarine};
            this.stepItem1.Name = "stepItem1";
            this.stepItem1.SymbolSize = 13F;
            this.stepItem1.Text = "Datos Adquisición";
            // 
            // stepItem2
            // 
            this.stepItem2.Name = "stepItem2";
            this.stepItem2.SymbolSize = 13F;
            this.stepItem2.Text = " Bienes ";
            // 
            // btnContinuar
            // 
            this.btnContinuar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnContinuar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnContinuar.Location = new System.Drawing.Point(189, 556);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(96, 23);
            this.btnContinuar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnContinuar.TabIndex = 1;
            this.btnContinuar.Text = "btnContinuar";
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
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
            this.txtNroFactura.Location = new System.Drawing.Point(139, 12);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.PreventEnterBeep = true;
            this.txtNroFactura.Size = new System.Drawing.Size(102, 22);
            this.txtNroFactura.TabIndex = 43;
            // 
            // lblFechaCompra
            // 
            // 
            // 
            // 
            this.lblFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaCompra.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Location = new System.Drawing.Point(12, 53);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(121, 17);
            this.lblFechaCompra.TabIndex = 44;
            this.lblFechaCompra.Text = "lblFechaCompra";
            // 
            // lblNroFactura
            // 
            // 
            // 
            // 
            this.lblNroFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroFactura.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFactura.Location = new System.Drawing.Point(12, 12);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(97, 22);
            this.lblNroFactura.TabIndex = 45;
            this.lblNroFactura.Text = "lblNroFactura";
            // 
            // lblMontoTotal
            // 
            // 
            // 
            // 
            this.lblMontoTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoTotal.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(12, 91);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(108, 17);
            this.lblMontoTotal.TabIndex = 46;
            this.lblMontoTotal.Text = "lblMontoTotal";
            // 
            // lblProveedor
            // 
            // 
            // 
            // 
            this.lblProveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProveedor.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(12, 128);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(97, 17);
            this.lblProveedor.TabIndex = 47;
            this.lblProveedor.Text = "lblProveedor";
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
            this.txtFechaCompra.Location = new System.Drawing.Point(139, 48);
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
            this.txtFechaCompra.Size = new System.Drawing.Size(76, 22);
            this.txtFechaCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaCompra.TabIndex = 49;
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMontoTotal.Border.Class = "TextBoxBorder";
            this.txtMontoTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMontoTotal.DisabledBackColor = System.Drawing.Color.White;
            this.txtMontoTotal.ForeColor = System.Drawing.Color.Black;
            this.txtMontoTotal.Location = new System.Drawing.Point(139, 86);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.PreventEnterBeep = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(102, 22);
            this.txtMontoTotal.TabIndex = 50;
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
            this.txtProveedor.Location = new System.Drawing.Point(139, 123);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.PreventEnterBeep = true;
            this.txtProveedor.Size = new System.Drawing.Size(102, 22);
            this.txtProveedor.TabIndex = 51;
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
            this.cboProveedor.Location = new System.Drawing.Point(139, 123);
            this.cboProveedor.MaxDropDownItems = 10;
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(102, 22);
            this.cboProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProveedor.TabIndex = 52;
            this.cboProveedor.SelectionChangeCommitted += new System.EventHandler(this.cboProveedor_SelectionChangeCommitted);
            // 
            // pnlAdquisicion
            // 
            this.pnlAdquisicion.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlAdquisicion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlAdquisicion.Controls.Add(this.txtNroPartida);
            this.pnlAdquisicion.Controls.Add(this.labelX1);
            this.pnlAdquisicion.Controls.Add(this.lblMontoTotal);
            this.pnlAdquisicion.Controls.Add(this.txtProveedor);
            this.pnlAdquisicion.Controls.Add(this.cboProveedor);
            this.pnlAdquisicion.Controls.Add(this.txtMontoTotal);
            this.pnlAdquisicion.Controls.Add(this.txtFechaCompra);
            this.pnlAdquisicion.Controls.Add(this.txtNroFactura);
            this.pnlAdquisicion.Controls.Add(this.lblProveedor);
            this.pnlAdquisicion.Controls.Add(this.lblFechaCompra);
            this.pnlAdquisicion.Controls.Add(this.lblNroFactura);
            this.pnlAdquisicion.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlAdquisicion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdquisicion.Location = new System.Drawing.Point(0, 0);
            this.pnlAdquisicion.Name = "pnlAdquisicion";
            this.pnlAdquisicion.Size = new System.Drawing.Size(551, 208);
            this.pnlAdquisicion.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlAdquisicion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlAdquisicion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlAdquisicion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlAdquisicion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlAdquisicion.Style.GradientAngle = 90;
            this.pnlAdquisicion.TabIndex = 53;
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
            this.txtNroPartida.Location = new System.Drawing.Point(139, 158);
            this.txtNroPartida.Name = "txtNroPartida";
            this.txtNroPartida.PreventEnterBeep = true;
            this.txtNroPartida.Size = new System.Drawing.Size(102, 22);
            this.txtNroPartida.TabIndex = 54;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 163);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(97, 17);
            this.labelX1.TabIndex = 53;
            this.labelX1.Text = "lblNroPartida";
            // 
            // pnlBienes
            // 
            this.pnlBienes.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBienes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBienes.Controls.Add(this.lblCosto);
            this.pnlBienes.Controls.Add(this.GrillaDetallesBienes);
            this.pnlBienes.Controls.Add(this.txtCosto);
            this.pnlBienes.Controls.Add(this.btnAgregar);
            this.pnlBienes.Controls.Add(this.pnlHardware);
            this.pnlBienes.Controls.Add(this.GrillaBienes);
            this.pnlBienes.Controls.Add(this.lblBien);
            this.pnlBienes.Controls.Add(this.lblModelo);
            this.pnlBienes.Controls.Add(this.lblMarca);
            this.pnlBienes.Controls.Add(this.lblTipoBien);
            this.pnlBienes.Controls.Add(this.cboModelo);
            this.pnlBienes.Controls.Add(this.cboMarca);
            this.pnlBienes.Controls.Add(this.cboTipoBien);
            this.pnlBienes.Controls.Add(this.txtBienCategoria);
            this.pnlBienes.Controls.Add(this.cboBienCategoria);
            this.pnlBienes.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBienes.Location = new System.Drawing.Point(0, 0);
            this.pnlBienes.Name = "pnlBienes";
            this.pnlBienes.Size = new System.Drawing.Size(539, 550);
            this.pnlBienes.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBienes.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBienes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBienes.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBienes.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBienes.Style.GradientAngle = 90;
            this.pnlBienes.TabIndex = 57;
            this.pnlBienes.Visible = false;
            // 
            // lblCosto
            // 
            // 
            // 
            // 
            this.lblCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCosto.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(268, 214);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(62, 17);
            this.lblCosto.TabIndex = 27;
            this.lblCosto.Text = "lblCosto";
            // 
            // GrillaDetallesBienes
            // 
            this.GrillaDetallesBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaDetallesBienes.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaDetallesBienes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaDetallesBienes.Location = new System.Drawing.Point(18, 21);
            this.GrillaDetallesBienes.Name = "GrillaDetallesBienes";
            this.GrillaDetallesBienes.Size = new System.Drawing.Size(438, 101);
            this.GrillaDetallesBienes.TabIndex = 34;
            this.GrillaDetallesBienes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDetallesBienes_CellClick);
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCosto.Border.Class = "TextBoxBorder";
            this.txtCosto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCosto.DisabledBackColor = System.Drawing.Color.White;
            this.txtCosto.ForeColor = System.Drawing.Color.Black;
            this.txtCosto.Location = new System.Drawing.Point(336, 209);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.PreventEnterBeep = true;
            this.txtCosto.Size = new System.Drawing.Size(111, 22);
            this.txtCosto.TabIndex = 26;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(128, 362);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 25;
            this.btnAgregar.Text = "btnAgregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlHardware
            // 
            this.pnlHardware.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlHardware.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlHardware.Controls.Add(this.lblSerieKey);
            this.pnlHardware.Controls.Add(this.cboDeposito);
            this.pnlHardware.Controls.Add(this.txtSerialMaster);
            this.pnlHardware.Controls.Add(this.cboEstadoInv);
            this.pnlHardware.Controls.Add(this.txtSerieKey);
            this.pnlHardware.Controls.Add(this.lblSerial);
            this.pnlHardware.Controls.Add(this.labelX3);
            this.pnlHardware.Controls.Add(this.lblDeposito);
            this.pnlHardware.Controls.Add(this.lblSerie);
            this.pnlHardware.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlHardware.Location = new System.Drawing.Point(3, 265);
            this.pnlHardware.Name = "pnlHardware";
            this.pnlHardware.Size = new System.Drawing.Size(306, 88);
            this.pnlHardware.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlHardware.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlHardware.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlHardware.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlHardware.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlHardware.Style.GradientAngle = 90;
            this.pnlHardware.TabIndex = 18;
            // 
            // lblSerieKey
            // 
            // 
            // 
            // 
            this.lblSerieKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerieKey.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieKey.Location = new System.Drawing.Point(15, 8);
            this.lblSerieKey.Name = "lblSerieKey";
            this.lblSerieKey.Size = new System.Drawing.Size(91, 17);
            this.lblSerieKey.TabIndex = 25;
            this.lblSerieKey.Text = "lblSerieKey";
            // 
            // cboDeposito
            // 
            this.cboDeposito.DisplayMember = "Text";
            this.cboDeposito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDeposito.ForeColor = System.Drawing.Color.Black;
            this.cboDeposito.FormattingEnabled = true;
            this.cboDeposito.ItemHeight = 16;
            this.cboDeposito.Location = new System.Drawing.Point(125, 31);
            this.cboDeposito.Name = "cboDeposito";
            this.cboDeposito.Size = new System.Drawing.Size(121, 22);
            this.cboDeposito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDeposito.TabIndex = 22;
            // 
            // txtSerialMaster
            // 
            this.txtSerialMaster.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSerialMaster.Border.Class = "TextBoxBorder";
            this.txtSerialMaster.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSerialMaster.DisabledBackColor = System.Drawing.Color.White;
            this.txtSerialMaster.ForeColor = System.Drawing.Color.Black;
            this.txtSerialMaster.Location = new System.Drawing.Point(125, 31);
            this.txtSerialMaster.Name = "txtSerialMaster";
            this.txtSerialMaster.PreventEnterBeep = true;
            this.txtSerialMaster.Size = new System.Drawing.Size(173, 22);
            this.txtSerialMaster.TabIndex = 22;
            // 
            // cboEstadoInv
            // 
            this.cboEstadoInv.DisplayMember = "Text";
            this.cboEstadoInv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoInv.ForeColor = System.Drawing.Color.Black;
            this.cboEstadoInv.FormattingEnabled = true;
            this.cboEstadoInv.ItemHeight = 16;
            this.cboEstadoInv.Location = new System.Drawing.Point(125, 59);
            this.cboEstadoInv.Name = "cboEstadoInv";
            this.cboEstadoInv.Size = new System.Drawing.Size(121, 22);
            this.cboEstadoInv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboEstadoInv.TabIndex = 23;
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
            this.txtSerieKey.Location = new System.Drawing.Point(125, 3);
            this.txtSerieKey.Name = "txtSerieKey";
            this.txtSerieKey.PreventEnterBeep = true;
            this.txtSerieKey.Size = new System.Drawing.Size(173, 22);
            this.txtSerieKey.TabIndex = 22;
            // 
            // lblSerial
            // 
            // 
            // 
            // 
            this.lblSerial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerial.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Location = new System.Drawing.Point(15, 36);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(91, 17);
            this.lblSerial.TabIndex = 22;
            this.lblSerial.Text = "lblSerial";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(15, 64);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(91, 17);
            this.labelX3.TabIndex = 24;
            this.labelX3.Text = "lblEstado";
            // 
            // lblDeposito
            // 
            // 
            // 
            // 
            this.lblDeposito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDeposito.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposito.Location = new System.Drawing.Point(15, 36);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(91, 17);
            this.lblDeposito.TabIndex = 23;
            this.lblDeposito.Text = "lblDeposito";
            // 
            // lblSerie
            // 
            // 
            // 
            // 
            this.lblSerie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerie.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(15, 8);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(91, 17);
            this.lblSerie.TabIndex = 22;
            this.lblSerie.Text = "lblSerie";
            // 
            // GrillaBienes
            // 
            this.GrillaBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaBienes.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaBienes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaBienes.Location = new System.Drawing.Point(3, 396);
            this.GrillaBienes.Name = "GrillaBienes";
            this.GrillaBienes.Size = new System.Drawing.Size(453, 142);
            this.GrillaBienes.TabIndex = 22;
            // 
            // lblBien
            // 
            // 
            // 
            // 
            this.lblBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(18, 183);
            this.lblBien.Name = "lblBien";
            this.lblBien.Size = new System.Drawing.Size(91, 17);
            this.lblBien.TabIndex = 17;
            this.lblBien.Text = "lblBien";
            // 
            // lblModelo
            // 
            // 
            // 
            // 
            this.lblModelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblModelo.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(18, 242);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(91, 17);
            this.lblModelo.TabIndex = 16;
            this.lblModelo.Text = "lblModelo";
            // 
            // lblMarca
            // 
            // 
            // 
            // 
            this.lblMarca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMarca.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(18, 214);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(91, 17);
            this.lblMarca.TabIndex = 15;
            this.lblMarca.Text = "lblMarca";
            // 
            // lblTipoBien
            // 
            // 
            // 
            // 
            this.lblTipoBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBien.Location = new System.Drawing.Point(18, 153);
            this.lblTipoBien.Name = "lblTipoBien";
            this.lblTipoBien.Size = new System.Drawing.Size(91, 17);
            this.lblTipoBien.TabIndex = 14;
            this.lblTipoBien.Text = "lblTipoBien";
            // 
            // cboModelo
            // 
            this.cboModelo.DisplayMember = "Text";
            this.cboModelo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModelo.ForeColor = System.Drawing.Color.Black;
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.ItemHeight = 16;
            this.cboModelo.Location = new System.Drawing.Point(128, 237);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(121, 22);
            this.cboModelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModelo.TabIndex = 13;
            this.cboModelo.SelectedIndexChanged += new System.EventHandler(this.cboModelo_SelectedIndexChanged);
            this.cboModelo.SelectionChangeCommitted += new System.EventHandler(this.cboModelo_SelectionChangeCommitted);
            // 
            // cboMarca
            // 
            this.cboMarca.DisplayMember = "Text";
            this.cboMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarca.ForeColor = System.Drawing.Color.Black;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.ItemHeight = 16;
            this.cboMarca.Location = new System.Drawing.Point(128, 209);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 22);
            this.cboMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMarca.TabIndex = 12;
            this.cboMarca.SelectionChangeCommitted += new System.EventHandler(this.cboMarca_SelectionChangeCommitted);
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DisplayMember = "Text";
            this.cboTipoBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoBien.ForeColor = System.Drawing.Color.Black;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.ItemHeight = 16;
            this.cboTipoBien.Location = new System.Drawing.Point(128, 153);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(121, 22);
            this.cboTipoBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoBien.TabIndex = 0;
            // 
            // txtBienCategoria
            // 
            this.txtBienCategoria.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBienCategoria.Border.Class = "TextBoxBorder";
            this.txtBienCategoria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBienCategoria.DisabledBackColor = System.Drawing.Color.White;
            this.txtBienCategoria.ForeColor = System.Drawing.Color.Black;
            this.txtBienCategoria.Location = new System.Drawing.Point(128, 181);
            this.txtBienCategoria.Name = "txtBienCategoria";
            this.txtBienCategoria.PreventEnterBeep = true;
            this.txtBienCategoria.Size = new System.Drawing.Size(173, 22);
            this.txtBienCategoria.TabIndex = 11;
            // 
            // cboBienCategoria
            // 
            this.cboBienCategoria.DisplayMember = "Text";
            this.cboBienCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBienCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBienCategoria.ForeColor = System.Drawing.Color.Black;
            this.cboBienCategoria.FormattingEnabled = true;
            this.cboBienCategoria.ItemHeight = 16;
            this.cboBienCategoria.Location = new System.Drawing.Point(128, 181);
            this.cboBienCategoria.MaxDropDownItems = 10;
            this.cboBienCategoria.Name = "cboBienCategoria";
            this.cboBienCategoria.Size = new System.Drawing.Size(218, 22);
            this.cboBienCategoria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBienCategoria.TabIndex = 33;
            this.cboBienCategoria.Visible = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirmar.Location = new System.Drawing.Point(192, 556);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirmar.TabIndex = 23;
            this.btnConfirmar.Text = "btnConfirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmBienRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 628);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.progressSteps1);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.pnlBienes);
            this.Controls.Add(this.pnlAdquisicion);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBienRegistrar";
            this.Text = "frmBienRegistrar";
            this.Load += new System.EventHandler(this.frmBienRegistrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).EndInit();
            this.pnlAdquisicion.ResumeLayout(false);
            this.pnlBienes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesBienes)).EndInit();
            this.pnlHardware.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ProgressSteps progressSteps1;
        private DevComponents.DotNetBar.StepItem stepItem1;
        private DevComponents.DotNetBar.StepItem stepItem2;
        private DevComponents.DotNetBar.ButtonX btnContinuar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroFactura;
        private DevComponents.DotNetBar.LabelX lblFechaCompra;
        private DevComponents.DotNetBar.LabelX lblNroFactura;
        private DevComponents.DotNetBar.LabelX lblMontoTotal;
        private DevComponents.DotNetBar.LabelX lblProveedor;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaCompra;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoTotal;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProveedor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProveedor;
        private DevComponents.DotNetBar.PanelEx pnlAdquisicion;
        private DevComponents.DotNetBar.PanelEx pnlBienes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoBien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboModelo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboMarca;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBienCategoria;
        private DevComponents.DotNetBar.LabelX lblBien;
        private DevComponents.DotNetBar.LabelX lblModelo;
        private DevComponents.DotNetBar.LabelX lblMarca;
        private DevComponents.DotNetBar.LabelX lblTipoBien;
        private DevComponents.DotNetBar.PanelEx pnlHardware;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDeposito;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboEstadoInv;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerieKey;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lblDeposito;
        private DevComponents.DotNetBar.LabelX lblSerie;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.ButtonX btnConfirmar;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaBienes;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerialMaster;
        private DevComponents.DotNetBar.LabelX lblSerial;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBienCategoria;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPartida;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaDetallesBienes;
        private DevComponents.DotNetBar.LabelX lblSerieKey;
        private DevComponents.DotNetBar.LabelX lblCosto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCosto;
    }
}