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
            this.progressSteps1 = new DevComponents.DotNetBar.ProgressSteps();
            this.stepItem1 = new DevComponents.DotNetBar.StepItem();
            this.stepItem2 = new DevComponents.DotNetBar.StepItem();
            this.btnContinuar = new DevComponents.DotNetBar.ButtonX();
            this.txtIdSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFechaCompra = new DevComponents.DotNetBar.LabelX();
            this.lblNroFactura = new DevComponents.DotNetBar.LabelX();
            this.lblMontoTotal = new DevComponents.DotNetBar.LabelX();
            this.lblProveedor = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.pnlAdquisicion = new DevComponents.DotNetBar.PanelEx();
            this.pnlBienes = new DevComponents.DotNetBar.PanelEx();
            this.GrillaBienes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlHardware = new DevComponents.DotNetBar.PanelEx();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.cboDeposito = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboEstado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtSerieKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lblDeposito = new DevComponents.DotNetBar.LabelX();
            this.lblSerie = new DevComponents.DotNetBar.LabelX();
            this.lblBien = new DevComponents.DotNetBar.LabelX();
            this.lblModelo = new DevComponents.DotNetBar.LabelX();
            this.lblMarca = new DevComponents.DotNetBar.LabelX();
            this.lblTipoBien = new DevComponents.DotNetBar.LabelX();
            this.cboModelo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboMarca = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboTipoBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.pnlSoftware = new DevComponents.DotNetBar.PanelEx();
            this.dateTimeInput3 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblFinSus = new DevComponents.DotNetBar.LabelX();
            this.lblFecSus = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx7 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx8 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTipoLic = new DevComponents.DotNetBar.LabelX();
            this.lblKey = new DevComponents.DotNetBar.LabelX();
            this.lblSerial = new DevComponents.DotNetBar.LabelX();
            this.txtBienCategoria = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboBienCategoria = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnConfirmar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            this.pnlAdquisicion.SuspendLayout();
            this.pnlBienes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).BeginInit();
            this.pnlHardware.SuspendLayout();
            this.pnlSoftware.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
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
            this.progressSteps1.Location = new System.Drawing.Point(0, 465);
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
            this.btnContinuar.Location = new System.Drawing.Point(91, 177);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(96, 23);
            this.btnContinuar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnContinuar.TabIndex = 1;
            this.btnContinuar.Text = "btnContinuar";
            // 
            // txtIdSolicitud
            // 
            this.txtIdSolicitud.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIdSolicitud.Border.Class = "TextBoxBorder";
            this.txtIdSolicitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdSolicitud.DisabledBackColor = System.Drawing.Color.White;
            this.txtIdSolicitud.ForeColor = System.Drawing.Color.Black;
            this.txtIdSolicitud.Location = new System.Drawing.Point(139, 12);
            this.txtIdSolicitud.Multiline = true;
            this.txtIdSolicitud.Name = "txtIdSolicitud";
            this.txtIdSolicitud.PreventEnterBeep = true;
            this.txtIdSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtIdSolicitud.TabIndex = 43;
            this.txtIdSolicitud.TextChanged += new System.EventHandler(this.txtIdSolicitud_TextChanged);
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
            // dateTimeInput2
            // 
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(139, 48);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            this.dateTimeInput2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput2.Name = "dateTimeInput2";
            this.dateTimeInput2.Size = new System.Drawing.Size(76, 22);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 49;
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
            this.textBoxX1.Location = new System.Drawing.Point(139, 86);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(102, 22);
            this.textBoxX1.TabIndex = 50;
            // 
            // textBoxX2
            // 
            this.textBoxX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX2.ForeColor = System.Drawing.Color.Black;
            this.textBoxX2.Location = new System.Drawing.Point(139, 123);
            this.textBoxX2.Multiline = true;
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(102, 22);
            this.textBoxX2.TabIndex = 51;
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(139, 123);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(128, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 52;
            this.comboBoxEx4.Visible = false;
            // 
            // pnlAdquisicion
            // 
            this.pnlAdquisicion.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlAdquisicion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlAdquisicion.Controls.Add(this.lblMontoTotal);
            this.pnlAdquisicion.Controls.Add(this.textBoxX2);
            this.pnlAdquisicion.Controls.Add(this.comboBoxEx4);
            this.pnlAdquisicion.Controls.Add(this.textBoxX1);
            this.pnlAdquisicion.Controls.Add(this.btnContinuar);
            this.pnlAdquisicion.Controls.Add(this.dateTimeInput2);
            this.pnlAdquisicion.Controls.Add(this.txtIdSolicitud);
            this.pnlAdquisicion.Controls.Add(this.lblProveedor);
            this.pnlAdquisicion.Controls.Add(this.lblFechaCompra);
            this.pnlAdquisicion.Controls.Add(this.lblNroFactura);
            this.pnlAdquisicion.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlAdquisicion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdquisicion.Location = new System.Drawing.Point(0, 0);
            this.pnlAdquisicion.Name = "pnlAdquisicion";
            this.pnlAdquisicion.Size = new System.Drawing.Size(461, 219);
            this.pnlAdquisicion.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlAdquisicion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlAdquisicion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlAdquisicion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlAdquisicion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlAdquisicion.Style.GradientAngle = 90;
            this.pnlAdquisicion.TabIndex = 53;
            // 
            // pnlBienes
            // 
            this.pnlBienes.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBienes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBienes.Controls.Add(this.btnAgregar);
            this.pnlBienes.Controls.Add(this.pnlHardware);
            this.pnlBienes.Controls.Add(this.pnlSoftware);
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
            this.pnlBienes.Size = new System.Drawing.Size(461, 407);
            this.pnlBienes.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBienes.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBienes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBienes.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBienes.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBienes.Style.GradientAngle = 90;
            this.pnlBienes.TabIndex = 57;
            this.pnlBienes.Visible = false;
            // 
            // GrillaBienes
            // 
            this.GrillaBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaBienes.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaBienes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaBienes.Location = new System.Drawing.Point(3, 259);
            this.GrillaBienes.Name = "GrillaBienes";
            this.GrillaBienes.Size = new System.Drawing.Size(453, 142);
            this.GrillaBienes.TabIndex = 22;
            // 
            // pnlHardware
            // 
            this.pnlHardware.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlHardware.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlHardware.Controls.Add(this.cboDeposito);
            this.pnlHardware.Controls.Add(this.cboEstado);
            this.pnlHardware.Controls.Add(this.txtSerieKey);
            this.pnlHardware.Controls.Add(this.labelX3);
            this.pnlHardware.Controls.Add(this.lblDeposito);
            this.pnlHardware.Controls.Add(this.lblSerie);
            this.pnlHardware.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlHardware.Location = new System.Drawing.Point(3, 128);
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
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(128, 225);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 25;
            this.btnAgregar.Text = "btnAgregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            // cboEstado
            // 
            this.cboEstado.DisplayMember = "Text";
            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.ForeColor = System.Drawing.Color.Black;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.ItemHeight = 16;
            this.cboEstado.Location = new System.Drawing.Point(125, 59);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 22);
            this.cboEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboEstado.TabIndex = 23;
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
            // lblBien
            // 
            // 
            // 
            // 
            this.lblBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(18, 46);
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
            this.lblModelo.Location = new System.Drawing.Point(18, 105);
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
            this.lblMarca.Location = new System.Drawing.Point(18, 77);
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
            this.lblTipoBien.Location = new System.Drawing.Point(18, 16);
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
            this.cboModelo.Location = new System.Drawing.Point(128, 100);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(121, 22);
            this.cboModelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModelo.TabIndex = 13;
            // 
            // cboMarca
            // 
            this.cboMarca.DisplayMember = "Text";
            this.cboMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarca.ForeColor = System.Drawing.Color.Black;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.ItemHeight = 16;
            this.cboMarca.Location = new System.Drawing.Point(128, 72);
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
            this.cboTipoBien.Location = new System.Drawing.Point(128, 16);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(121, 22);
            this.cboTipoBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoBien.TabIndex = 0;
            this.cboTipoBien.SelectionChangeCommitted += new System.EventHandler(this.cboTipoBien_SelectionChangeCommitted);
            // 
            // pnlSoftware
            // 
            this.pnlSoftware.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlSoftware.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlSoftware.Controls.Add(this.dateTimeInput3);
            this.pnlSoftware.Controls.Add(this.dateTimeInput1);
            this.pnlSoftware.Controls.Add(this.lblFinSus);
            this.pnlSoftware.Controls.Add(this.lblFecSus);
            this.pnlSoftware.Controls.Add(this.comboBoxEx7);
            this.pnlSoftware.Controls.Add(this.comboBoxEx8);
            this.pnlSoftware.Controls.Add(this.textBoxX4);
            this.pnlSoftware.Controls.Add(this.lblTipoLic);
            this.pnlSoftware.Controls.Add(this.lblKey);
            this.pnlSoftware.Controls.Add(this.lblSerial);
            this.pnlSoftware.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlSoftware.Location = new System.Drawing.Point(3, 127);
            this.pnlSoftware.Name = "pnlSoftware";
            this.pnlSoftware.Size = new System.Drawing.Size(453, 89);
            this.pnlSoftware.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlSoftware.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlSoftware.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlSoftware.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlSoftware.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlSoftware.Style.GradientAngle = 90;
            this.pnlSoftware.TabIndex = 29;
            this.pnlSoftware.Visible = false;
            // 
            // dateTimeInput3
            // 
            // 
            // 
            // 
            this.dateTimeInput3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput3.ButtonDropDown.Visible = true;
            this.dateTimeInput3.IsPopupCalendarOpen = false;
            this.dateTimeInput3.Location = new System.Drawing.Point(360, 59);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput3.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            this.dateTimeInput3.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput3.Name = "dateTimeInput3";
            this.dateTimeInput3.Size = new System.Drawing.Size(86, 22);
            this.dateTimeInput3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput3.TabIndex = 29;
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(360, 31);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(86, 22);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 28;
            // 
            // lblFinSus
            // 
            // 
            // 
            // 
            this.lblFinSus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFinSus.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinSus.Location = new System.Drawing.Point(252, 64);
            this.lblFinSus.Name = "lblFinSus";
            this.lblFinSus.Size = new System.Drawing.Size(91, 17);
            this.lblFinSus.TabIndex = 27;
            this.lblFinSus.Text = "lblFinSus";
            // 
            // lblFecSus
            // 
            // 
            // 
            // 
            this.lblFecSus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFecSus.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecSus.Location = new System.Drawing.Point(252, 36);
            this.lblFecSus.Name = "lblFecSus";
            this.lblFecSus.Size = new System.Drawing.Size(91, 17);
            this.lblFecSus.TabIndex = 26;
            this.lblFecSus.Text = "lblFecSus";
            // 
            // comboBoxEx7
            // 
            this.comboBoxEx7.DisplayMember = "Text";
            this.comboBoxEx7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx7.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx7.FormattingEnabled = true;
            this.comboBoxEx7.ItemHeight = 16;
            this.comboBoxEx7.Location = new System.Drawing.Point(125, 31);
            this.comboBoxEx7.Name = "comboBoxEx7";
            this.comboBoxEx7.Size = new System.Drawing.Size(121, 22);
            this.comboBoxEx7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx7.TabIndex = 22;
            // 
            // comboBoxEx8
            // 
            this.comboBoxEx8.DisplayMember = "Text";
            this.comboBoxEx8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx8.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx8.FormattingEnabled = true;
            this.comboBoxEx8.ItemHeight = 16;
            this.comboBoxEx8.Location = new System.Drawing.Point(125, 59);
            this.comboBoxEx8.Name = "comboBoxEx8";
            this.comboBoxEx8.Size = new System.Drawing.Size(121, 22);
            this.comboBoxEx8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx8.TabIndex = 23;
            // 
            // textBoxX4
            // 
            this.textBoxX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX4.ForeColor = System.Drawing.Color.Black;
            this.textBoxX4.Location = new System.Drawing.Point(125, 3);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.PreventEnterBeep = true;
            this.textBoxX4.Size = new System.Drawing.Size(173, 22);
            this.textBoxX4.TabIndex = 22;
            // 
            // lblTipoLic
            // 
            // 
            // 
            // 
            this.lblTipoLic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoLic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoLic.Location = new System.Drawing.Point(15, 64);
            this.lblTipoLic.Name = "lblTipoLic";
            this.lblTipoLic.Size = new System.Drawing.Size(91, 17);
            this.lblTipoLic.TabIndex = 24;
            this.lblTipoLic.Text = "lblTipoLic";
            // 
            // lblKey
            // 
            // 
            // 
            // 
            this.lblKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKey.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(15, 36);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(91, 17);
            this.lblKey.TabIndex = 23;
            this.lblKey.Text = "lblKey";
            // 
            // lblSerial
            // 
            // 
            // 
            // 
            this.lblSerial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerial.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Location = new System.Drawing.Point(15, 8);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(91, 17);
            this.lblSerial.TabIndex = 22;
            this.lblSerial.Text = "lblSerial";
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
            this.txtBienCategoria.Location = new System.Drawing.Point(128, 44);
            this.txtBienCategoria.Name = "txtBienCategoria";
            this.txtBienCategoria.PreventEnterBeep = true;
            this.txtBienCategoria.Size = new System.Drawing.Size(173, 22);
            this.txtBienCategoria.TabIndex = 11;
            this.txtBienCategoria.TextChanged += new System.EventHandler(this.txtBienCategoria_TextChanged);
            // 
            // cboBienCategoria
            // 
            this.cboBienCategoria.DisplayMember = "Text";
            this.cboBienCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBienCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBienCategoria.ForeColor = System.Drawing.Color.Black;
            this.cboBienCategoria.FormattingEnabled = true;
            this.cboBienCategoria.ItemHeight = 16;
            this.cboBienCategoria.Location = new System.Drawing.Point(128, 44);
            this.cboBienCategoria.MaxDropDownItems = 10;
            this.cboBienCategoria.Name = "cboBienCategoria";
            this.cboBienCategoria.Size = new System.Drawing.Size(218, 22);
            this.cboBienCategoria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBienCategoria.TabIndex = 33;
            this.cboBienCategoria.Visible = false;
            this.cboBienCategoria.SelectionChangeCommitted += new System.EventHandler(this.cboBienCategoria_SelectionChangeCommitted);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirmar.Location = new System.Drawing.Point(174, 423);
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
            this.ClientSize = new System.Drawing.Size(461, 490);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.progressSteps1);
            this.Controls.Add(this.pnlBienes);
            this.Controls.Add(this.pnlAdquisicion);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmBienRegistrar";
            this.Text = "frmBienRegistrar";
            this.Load += new System.EventHandler(this.frmBienRegistrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            this.pnlAdquisicion.ResumeLayout(false);
            this.pnlBienes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).EndInit();
            this.pnlHardware.ResumeLayout(false);
            this.pnlSoftware.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ProgressSteps progressSteps1;
        private DevComponents.DotNetBar.StepItem stepItem1;
        private DevComponents.DotNetBar.StepItem stepItem2;
        private DevComponents.DotNetBar.ButtonX btnContinuar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdSolicitud;
        private DevComponents.DotNetBar.LabelX lblFechaCompra;
        private DevComponents.DotNetBar.LabelX lblNroFactura;
        private DevComponents.DotNetBar.LabelX lblMontoTotal;
        private DevComponents.DotNetBar.LabelX lblProveedor;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
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
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboEstado;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerieKey;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lblDeposito;
        private DevComponents.DotNetBar.LabelX lblSerie;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.ButtonX btnConfirmar;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaBienes;
        private DevComponents.DotNetBar.PanelEx pnlSoftware;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx8;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.LabelX lblTipoLic;
        private DevComponents.DotNetBar.LabelX lblKey;
        private DevComponents.DotNetBar.LabelX lblSerial;
        private DevComponents.DotNetBar.LabelX lblFinSus;
        private DevComponents.DotNetBar.LabelX lblFecSus;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBienCategoria;
    }
}