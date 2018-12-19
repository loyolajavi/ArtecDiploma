namespace ARTEC.GUI
{
    partial class frmPartidaSolicitar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartidaSolicitar));
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblIdSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.grillaSolicitudes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.grillaSolicDetalles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblDetalles = new DevComponents.DotNetBar.LabelX();
            this.grillaCotizaciones = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblCotizaciones = new DevComponents.DotNetBar.LabelX();
            this.btnGenerarPartida = new DevComponents.DotNetBar.ButtonX();
            this.txtMontoTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoTotal = new DevComponents.DotNetBar.LabelX();
            this.pnlResPartida = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.vldFrmPartidaSolicitarBuscar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.vldfrmPartidaSolicitarGenerarPar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.regularExpressionValidator2 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter2 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.vldFrmPartidaSolicitarCaja = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.regularExpressionValidator3 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter3 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).BeginInit();
            this.pnlResPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(135, 3);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 21;
            this.lblDependencia.Text = "Dependencia";
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
            this.txtDep.Location = new System.Drawing.Point(135, 26);
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.Size = new System.Drawing.Size(315, 22);
            this.txtDep.TabIndex = 22;
            this.txtDep.TextChanged += new System.EventHandler(this.txtDep_TextChanged);
            this.txtDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDep_KeyPress);
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(135, 26);
            this.cboDep.MaxDropDownItems = 10;
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(315, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 23;
            this.cboDep.Visible = false;
            this.cboDep.SelectionChangeCommitted += new System.EventHandler(this.comboBoxEx4_SelectionChangeCommitted);
            // 
            // lblIdSolicitud
            // 
            // 
            // 
            // 
            this.lblIdSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdSolicitud.Location = new System.Drawing.Point(12, 3);
            this.lblIdSolicitud.Name = "lblIdSolicitud";
            this.lblIdSolicitud.Size = new System.Drawing.Size(102, 17);
            this.lblIdSolicitud.TabIndex = 24;
            this.lblIdSolicitud.Text = "lblIdSolicitud";
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
            this.txtNroSolicitud.Location = new System.Drawing.Point(12, 26);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtNroSolicitud.TabIndex = 25;
            this.vldFrmPartidaSolicitarBuscar.SetValidator1(this.txtNroSolicitud, this.regularExpressionValidator1);
            this.txtNroSolicitud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroSolicitud_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(469, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 22);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grillaSolicitudes
            // 
            this.grillaSolicitudes.AllowUserToAddRows = false;
            this.grillaSolicitudes.AllowUserToDeleteRows = false;
            this.grillaSolicitudes.BackgroundColor = System.Drawing.Color.White;
            this.grillaSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaSolicitudes.DefaultCellStyle = dataGridViewCellStyle6;
            this.grillaSolicitudes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaSolicitudes.Location = new System.Drawing.Point(12, 54);
            this.grillaSolicitudes.Name = "grillaSolicitudes";
            this.grillaSolicitudes.ReadOnly = true;
            this.grillaSolicitudes.Size = new System.Drawing.Size(531, 116);
            this.grillaSolicitudes.TabIndex = 27;
            this.grillaSolicitudes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaSolicitudes_CellClick);
            // 
            // grillaSolicDetalles
            // 
            this.grillaSolicDetalles.AllowUserToAddRows = false;
            this.grillaSolicDetalles.AllowUserToDeleteRows = false;
            this.grillaSolicDetalles.BackgroundColor = System.Drawing.Color.White;
            this.grillaSolicDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaSolicDetalles.DefaultCellStyle = dataGridViewCellStyle5;
            this.grillaSolicDetalles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaSolicDetalles.Location = new System.Drawing.Point(12, 206);
            this.grillaSolicDetalles.Name = "grillaSolicDetalles";
            this.grillaSolicDetalles.Size = new System.Drawing.Size(531, 136);
            this.grillaSolicDetalles.TabIndex = 29;
            this.grillaSolicDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaSolicDetalles_CellContentClick);
            this.grillaSolicDetalles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaSolicDetalles_CellDoubleClick);
            // 
            // lblDetalles
            // 
            // 
            // 
            // 
            this.lblDetalles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDetalles.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.Location = new System.Drawing.Point(12, 183);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(102, 17);
            this.lblDetalles.TabIndex = 30;
            this.lblDetalles.Text = "lblDetalles";
            // 
            // grillaCotizaciones
            // 
            this.grillaCotizaciones.AllowUserToAddRows = false;
            this.grillaCotizaciones.AllowUserToDeleteRows = false;
            this.grillaCotizaciones.BackgroundColor = System.Drawing.Color.White;
            this.grillaCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaCotizaciones.DefaultCellStyle = dataGridViewCellStyle4;
            this.grillaCotizaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaCotizaciones.Location = new System.Drawing.Point(12, 380);
            this.grillaCotizaciones.Name = "grillaCotizaciones";
            this.grillaCotizaciones.Size = new System.Drawing.Size(531, 136);
            this.grillaCotizaciones.TabIndex = 31;
            this.grillaCotizaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaCotizaciones_CellClick);
            // 
            // lblCotizaciones
            // 
            // 
            // 
            // 
            this.lblCotizaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCotizaciones.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCotizaciones.Location = new System.Drawing.Point(12, 357);
            this.lblCotizaciones.Name = "lblCotizaciones";
            this.lblCotizaciones.Size = new System.Drawing.Size(102, 17);
            this.lblCotizaciones.TabIndex = 32;
            this.lblCotizaciones.Text = "lblCotizaciones";
            // 
            // btnGenerarPartida
            // 
            this.btnGenerarPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerarPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerarPartida.Location = new System.Drawing.Point(59, 32);
            this.btnGenerarPartida.Name = "btnGenerarPartida";
            this.btnGenerarPartida.Size = new System.Drawing.Size(94, 34);
            this.btnGenerarPartida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerarPartida.TabIndex = 34;
            this.btnGenerarPartida.Text = "btnGenerarPartida";
            this.btnGenerarPartida.Click += new System.EventHandler(this.btnGenerarPartida_Click);
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
            this.txtMontoTotal.Location = new System.Drawing.Point(98, 3);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.PreventEnterBeep = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(100, 22);
            this.txtMontoTotal.TabIndex = 35;
            this.vldFrmPartidaSolicitarCaja.SetValidator1(this.txtMontoTotal, this.regularExpressionValidator3);
            this.vldfrmPartidaSolicitarGenerarPar.SetValidator1(this.txtMontoTotal, this.regularExpressionValidator2);
            // 
            // lblMontoTotal
            // 
            // 
            // 
            // 
            this.lblMontoTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoTotal.Location = new System.Drawing.Point(8, 3);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(75, 23);
            this.lblMontoTotal.TabIndex = 36;
            this.lblMontoTotal.Text = "lblMontoTotal";
            // 
            // pnlResPartida
            // 
            this.pnlResPartida.BackColor = System.Drawing.Color.White;
            this.pnlResPartida.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlResPartida.Controls.Add(this.txtMontoTotal);
            this.pnlResPartida.Controls.Add(this.lblMontoTotal);
            this.pnlResPartida.Controls.Add(this.btnGenerarPartida);
            this.pnlResPartida.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlResPartida.Location = new System.Drawing.Point(571, 421);
            this.pnlResPartida.Name = "pnlResPartida";
            this.pnlResPartida.Size = new System.Drawing.Size(211, 95);
            // 
            // 
            // 
            this.pnlResPartida.Style.BackColor = System.Drawing.Color.White;
            this.pnlResPartida.Style.BackColor2 = System.Drawing.Color.White;
            this.pnlResPartida.Style.BackColorGradientAngle = 90;
            this.pnlResPartida.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlResPartida.Style.BorderBottomWidth = 1;
            this.pnlResPartida.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlResPartida.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlResPartida.Style.BorderLeftWidth = 1;
            this.pnlResPartida.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlResPartida.Style.BorderRightWidth = 1;
            this.pnlResPartida.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlResPartida.Style.BorderTopWidth = 1;
            this.pnlResPartida.Style.CornerDiameter = 4;
            this.pnlResPartida.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlResPartida.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlResPartida.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlResPartida.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlResPartida.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlResPartida.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlResPartida.TabIndex = 41;
            this.pnlResPartida.Text = "pnlResPartida";
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(12, 54);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n\\viewkind4\\uc1\\pard\\la" +
    "ng11274\\ul\\b\\f0\\fs24 No hay resultados\\par\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(531, 116);
            this.txtResBusqueda.TabIndex = 49;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // vldFrmPartidaSolicitarBuscar
            // 
            this.vldFrmPartidaSolicitarBuscar.ContainerControl = this.btnBuscar;
            this.vldFrmPartidaSolicitarBuscar.ErrorProvider = this.errorProvider1;
            this.vldFrmPartidaSolicitarBuscar.Highlighter = this.highlighter1;
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
            // vldfrmPartidaSolicitarGenerarPar
            // 
            this.vldfrmPartidaSolicitarGenerarPar.ContainerControl = this.btnGenerarPartida;
            this.vldfrmPartidaSolicitarGenerarPar.ErrorProvider = this.errorProvider2;
            this.vldfrmPartidaSolicitarGenerarPar.Highlighter = this.highlighter2;
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator2.ValidationExpression = "^[0-9]{1,9}$";
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
            // vldFrmPartidaSolicitarCaja
            // 
            this.vldFrmPartidaSolicitarCaja.ErrorProvider = this.errorProvider3;
            this.vldFrmPartidaSolicitarCaja.Highlighter = this.highlighter3;
            // 
            // regularExpressionValidator3
            // 
            this.regularExpressionValidator3.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator3.ValidationExpression = "^[0-9]{1,9}$";
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
            // frmPartidaSolicitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 523);
            this.Controls.Add(this.pnlResPartida);
            this.Controls.Add(this.lblCotizaciones);
            this.Controls.Add(this.grillaCotizaciones);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.grillaSolicDetalles);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblIdSolicitud);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.cboDep);
            this.Controls.Add(this.txtResBusqueda);
            this.Controls.Add(this.grillaSolicitudes);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPartidaSolicitar";
            this.Text = "MetroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPartidaSolicitar_FormClosing);
            this.Load += new System.EventHandler(this.frmPartidaSolicitar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).EndInit();
            this.pnlResPartida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDep;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;
        private DevComponents.DotNetBar.LabelX lblIdSolicitud;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaSolicitudes;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaSolicDetalles;
        private DevComponents.DotNetBar.LabelX lblDetalles;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaCotizaciones;
        private DevComponents.DotNetBar.LabelX lblCotizaciones;
        private DevComponents.DotNetBar.ButtonX btnGenerarPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoTotal;
        private DevComponents.DotNetBar.LabelX lblMontoTotal;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlResPartida;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmPartidaSolicitarBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.Validator.SuperValidator vldfrmPartidaSolicitarGenerarPar;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator2;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmPartidaSolicitarCaja;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter3;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator3;
    }
}