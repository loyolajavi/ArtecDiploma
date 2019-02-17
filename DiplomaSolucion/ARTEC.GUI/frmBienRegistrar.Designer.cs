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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBienRegistrar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
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
            this.lblPartida = new DevComponents.DotNetBar.LabelX();
            this.GrillaDetallesBienes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.pnlBienes = new DevComponents.DotNetBar.PanelEx();
            this.btnCrearModelo = new DevComponents.DotNetBar.ButtonX();
            this.btnCrearMarca = new DevComponents.DotNetBar.ButtonX();
            this.lblCosto = new DevComponents.DotNetBar.LabelX();
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
            this.vldFrmBienRegistrarBtnBuscar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.vldFrmBienRegistrarBtnAgregar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.regularExpressionValidator2 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter2 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.vldFrmBienRegistrarBtnConfirmar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.regularExpressionValidator3 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter3 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).BeginInit();
            this.pnlAdquisicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesBienes)).BeginInit();
            this.pnlBienes.SuspendLayout();
            this.pnlHardware.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(253, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 22);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.txtNroFactura.Location = new System.Drawing.Point(139, 148);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.PreventEnterBeep = true;
            this.txtNroFactura.Size = new System.Drawing.Size(102, 22);
            this.txtNroFactura.TabIndex = 43;
            this.vldFrmBienRegistrarBtnConfirmar.SetValidator1(this.txtNroFactura, this.requiredFieldValidator4);
            // 
            // lblFechaCompra
            // 
            // 
            // 
            // 
            this.lblFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaCompra.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Location = new System.Drawing.Point(12, 46);
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
            this.lblNroFactura.Location = new System.Drawing.Point(12, 148);
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
            this.lblMontoTotal.Location = new System.Drawing.Point(12, 80);
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
            this.lblProveedor.Location = new System.Drawing.Point(12, 116);
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
            this.txtFechaCompra.Location = new System.Drawing.Point(139, 41);
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
            this.txtFechaCompra.Size = new System.Drawing.Size(102, 22);
            this.txtFechaCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaCompra.TabIndex = 49;
            this.vldFrmBienRegistrarBtnConfirmar.SetValidator1(this.txtFechaCompra, this.requiredFieldValidator2);
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
            this.txtMontoTotal.Location = new System.Drawing.Point(139, 75);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.PreventEnterBeep = true;
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(102, 22);
            this.txtMontoTotal.TabIndex = 50;
            this.vldFrmBienRegistrarBtnConfirmar.SetValidator1(this.txtMontoTotal, this.regularExpressionValidator3);
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
            this.txtProveedor.Location = new System.Drawing.Point(139, 111);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.PreventEnterBeep = true;
            this.txtProveedor.Size = new System.Drawing.Size(102, 22);
            this.txtProveedor.TabIndex = 51;
            this.vldFrmBienRegistrarBtnConfirmar.SetValidator1(this.txtProveedor, this.requiredFieldValidator3);
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
            this.cboProveedor.Location = new System.Drawing.Point(139, 111);
            this.cboProveedor.MaxDropDownItems = 10;
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(102, 22);
            this.cboProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProveedor.TabIndex = 52;
            this.cboProveedor.SelectionChangeCommitted += new System.EventHandler(this.cboProveedor_SelectionChangeCommitted);
            // 
            // pnlAdquisicion
            // 
            this.pnlAdquisicion.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlAdquisicion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.pnlAdquisicion.Controls.Add(this.txtNroPartida);
            this.pnlAdquisicion.Controls.Add(this.btnBuscar);
            this.pnlAdquisicion.Controls.Add(this.lblPartida);
            this.pnlAdquisicion.Controls.Add(this.lblMontoTotal);
            this.pnlAdquisicion.Controls.Add(this.txtProveedor);
            this.pnlAdquisicion.Controls.Add(this.cboProveedor);
            this.pnlAdquisicion.Controls.Add(this.txtMontoTotal);
            this.pnlAdquisicion.Controls.Add(this.txtFechaCompra);
            this.pnlAdquisicion.Controls.Add(this.txtNroFactura);
            this.pnlAdquisicion.Controls.Add(this.lblProveedor);
            this.pnlAdquisicion.Controls.Add(this.lblFechaCompra);
            this.pnlAdquisicion.Controls.Add(this.lblNroFactura);
            this.pnlAdquisicion.Controls.Add(this.GrillaDetallesBienes);
            this.pnlAdquisicion.Controls.Add(this.txtResBusqueda);
            this.pnlAdquisicion.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlAdquisicion.Location = new System.Drawing.Point(0, 0);
            this.pnlAdquisicion.Name = "pnlAdquisicion";
            this.pnlAdquisicion.Size = new System.Drawing.Size(499, 441);
            this.pnlAdquisicion.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlAdquisicion.Style.BackColor1.Color = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlAdquisicion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlAdquisicion.Style.BorderColor.Color = System.Drawing.SystemColors.HotTrack;
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
            this.txtNroPartida.Location = new System.Drawing.Point(139, 7);
            this.txtNroPartida.Name = "txtNroPartida";
            this.txtNroPartida.PreventEnterBeep = true;
            this.txtNroPartida.Size = new System.Drawing.Size(102, 22);
            this.txtNroPartida.TabIndex = 54;
            this.vldFrmBienRegistrarBtnBuscar.SetValidator1(this.txtNroPartida, this.regularExpressionValidator1);
            // 
            // lblPartida
            // 
            // 
            // 
            // 
            this.lblPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartida.Location = new System.Drawing.Point(12, 12);
            this.lblPartida.Name = "lblPartida";
            this.lblPartida.Size = new System.Drawing.Size(97, 17);
            this.lblPartida.TabIndex = 53;
            this.lblPartida.Text = "lblNroPartida";
            // 
            // GrillaDetallesBienes
            // 
            this.GrillaDetallesBienes.BackgroundColor = System.Drawing.Color.White;
            this.GrillaDetallesBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaDetallesBienes.DefaultCellStyle = dataGridViewCellStyle6;
            this.GrillaDetallesBienes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaDetallesBienes.Location = new System.Drawing.Point(12, 189);
            this.GrillaDetallesBienes.Name = "GrillaDetallesBienes";
            this.GrillaDetallesBienes.Size = new System.Drawing.Size(474, 101);
            this.GrillaDetallesBienes.TabIndex = 34;
            this.GrillaDetallesBienes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDetallesBienes_CellClick);
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(12, 189);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n{\\colortbl ;\\red0\\gree" +
    "n0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\cf1\\lang11274\\ul\\b\\f0\\fs24 No hay resultados\\par" +
    "\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(474, 101);
            this.txtResBusqueda.TabIndex = 55;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // pnlBienes
            // 
            this.pnlBienes.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlBienes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.pnlBienes.Controls.Add(this.btnCrearModelo);
            this.pnlBienes.Controls.Add(this.btnCrearMarca);
            this.pnlBienes.Controls.Add(this.lblCosto);
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
            this.pnlBienes.Location = new System.Drawing.Point(518, 0);
            this.pnlBienes.Name = "pnlBienes";
            this.pnlBienes.Size = new System.Drawing.Size(539, 441);
            this.pnlBienes.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBienes.Style.BackColor1.Color = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlBienes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBienes.Style.BorderColor.Color = System.Drawing.SystemColors.HotTrack;
            this.pnlBienes.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBienes.Style.GradientAngle = 90;
            this.pnlBienes.TabIndex = 57;
            // 
            // btnCrearModelo
            // 
            this.btnCrearModelo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearModelo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearModelo.Location = new System.Drawing.Point(265, 98);
            this.btnCrearModelo.Name = "btnCrearModelo";
            this.btnCrearModelo.Size = new System.Drawing.Size(87, 20);
            this.btnCrearModelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearModelo.TabIndex = 85;
            this.btnCrearModelo.Tag = ((object)(resources.GetObject("btnCrearModelo.Tag")));
            this.btnCrearModelo.Text = "btnCrearModelo";
            this.btnCrearModelo.Click += new System.EventHandler(this.btnCrearModelo_Click);
            // 
            // btnCrearMarca
            // 
            this.btnCrearMarca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearMarca.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearMarca.Location = new System.Drawing.Point(265, 70);
            this.btnCrearMarca.Name = "btnCrearMarca";
            this.btnCrearMarca.Size = new System.Drawing.Size(87, 20);
            this.btnCrearMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearMarca.TabIndex = 84;
            this.btnCrearMarca.Tag = ((object)(resources.GetObject("btnCrearMarca.Tag")));
            this.btnCrearMarca.Text = "btnCrearMarca";
            this.btnCrearMarca.Click += new System.EventHandler(this.btnCrearMarca_Click);
            // 
            // lblCosto
            // 
            // 
            // 
            // 
            this.lblCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCosto.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(28, 130);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(62, 17);
            this.lblCosto.TabIndex = 27;
            this.lblCosto.Text = "lblCosto";
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
            this.txtCosto.Location = new System.Drawing.Point(138, 127);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.PreventEnterBeep = true;
            this.txtCosto.Size = new System.Drawing.Size(111, 22);
            this.txtCosto.TabIndex = 26;
            this.vldFrmBienRegistrarBtnAgregar.SetValidator1(this.txtCosto, this.regularExpressionValidator2);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(138, 250);
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
            this.pnlHardware.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
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
            this.pnlHardware.Location = new System.Drawing.Point(13, 153);
            this.pnlHardware.Name = "pnlHardware";
            this.pnlHardware.Size = new System.Drawing.Size(306, 88);
            this.pnlHardware.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlHardware.Style.BackColor1.Color = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.vldFrmBienRegistrarBtnAgregar.SetValidator1(this.txtSerieKey, this.requiredFieldValidator1);
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
            this.GrillaBienes.BackgroundColor = System.Drawing.Color.White;
            this.GrillaBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaBienes.DefaultCellStyle = dataGridViewCellStyle5;
            this.GrillaBienes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaBienes.Location = new System.Drawing.Point(13, 284);
            this.GrillaBienes.Name = "GrillaBienes";
            this.GrillaBienes.Size = new System.Drawing.Size(511, 142);
            this.GrillaBienes.TabIndex = 22;
            // 
            // lblBien
            // 
            // 
            // 
            // 
            this.lblBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(28, 42);
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
            this.lblModelo.Location = new System.Drawing.Point(28, 101);
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
            this.lblMarca.Location = new System.Drawing.Point(28, 73);
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
            this.lblTipoBien.Location = new System.Drawing.Point(28, 12);
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
            this.cboModelo.Location = new System.Drawing.Point(138, 96);
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
            this.cboMarca.Location = new System.Drawing.Point(138, 68);
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
            this.cboTipoBien.Location = new System.Drawing.Point(138, 12);
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
            this.txtBienCategoria.Location = new System.Drawing.Point(138, 40);
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
            this.cboBienCategoria.Location = new System.Drawing.Point(138, 40);
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
            this.btnConfirmar.Location = new System.Drawing.Point(754, 447);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 39);
            this.btnConfirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirmar.TabIndex = 23;
            this.btnConfirmar.Text = "btnConfirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // vldFrmBienRegistrarBtnBuscar
            // 
            this.vldFrmBienRegistrarBtnBuscar.ContainerControl = this.btnBuscar;
            this.vldFrmBienRegistrarBtnBuscar.ErrorProvider = this.errorProvider1;
            this.vldFrmBienRegistrarBtnBuscar.Highlighter = this.highlighter1;
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator1.ValidationExpression = "^[0-9]{1,9}$";
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
            // vldFrmBienRegistrarBtnAgregar
            // 
            this.vldFrmBienRegistrarBtnAgregar.ContainerControl = this.btnAgregar;
            this.vldFrmBienRegistrarBtnAgregar.ErrorProvider = this.errorProvider2;
            this.vldFrmBienRegistrarBtnAgregar.Highlighter = this.highlighter2;
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator2.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // vldFrmBienRegistrarBtnConfirmar
            // 
            this.vldFrmBienRegistrarBtnConfirmar.ContainerControl = this.btnConfirmar;
            this.vldFrmBienRegistrarBtnConfirmar.ErrorProvider = this.errorProvider3;
            this.vldFrmBienRegistrarBtnConfirmar.Highlighter = this.highlighter3;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // regularExpressionValidator3
            // 
            this.regularExpressionValidator3.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator3.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // frmBienRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 490);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.pnlBienes);
            this.Controls.Add(this.pnlAdquisicion);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmBienRegistrar";
            this.ShowIcon = false;
            this.Text = "frmBienRegistrar";
            this.Load += new System.EventHandler(this.frmBienRegistrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaCompra)).EndInit();
            this.pnlAdquisicion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesBienes)).EndInit();
            this.pnlBienes.ResumeLayout(false);
            this.pnlHardware.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnBuscar;
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
        private DevComponents.DotNetBar.LabelX lblPartida;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaDetallesBienes;
        private DevComponents.DotNetBar.LabelX lblSerieKey;
        private DevComponents.DotNetBar.LabelX lblCosto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCosto;
        private DevComponents.DotNetBar.ButtonX btnCrearModelo;
        private DevComponents.DotNetBar.ButtonX btnCrearMarca;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmBienRegistrarBtnBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmBienRegistrarBtnAgregar;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmBienRegistrarBtnConfirmar;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
    }
}