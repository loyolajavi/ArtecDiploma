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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblIdSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.grillaSolicitudes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnConfirmar = new DevComponents.DotNetBar.ButtonX();
            this.grillaSolicDetalles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblDetalles = new DevComponents.DotNetBar.LabelX();
            this.grillaCotizaciones = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblCotizaciones = new DevComponents.DotNetBar.LabelX();
            this.btnGenerarCaja = new DevComponents.DotNetBar.ButtonX();
            this.btnGenerarPartida = new DevComponents.DotNetBar.ButtonX();
            this.txtMontoTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoTotal = new DevComponents.DotNetBar.LabelX();
            this.pnlResPartida = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).BeginInit();
            this.pnlResPartida.SuspendLayout();
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
            this.txtDep.Multiline = true;
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.Size = new System.Drawing.Size(315, 22);
            this.txtDep.TabIndex = 22;
            this.txtDep.TextChanged += new System.EventHandler(this.txtDep_TextChanged);
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
            this.txtNroSolicitud.Multiline = true;
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtNroSolicitud.TabIndex = 25;
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
            this.grillaSolicitudes.BackgroundColor = System.Drawing.Color.White;
            this.grillaSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaSolicitudes.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaSolicitudes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaSolicitudes.Location = new System.Drawing.Point(12, 54);
            this.grillaSolicitudes.Name = "grillaSolicitudes";
            this.grillaSolicitudes.Size = new System.Drawing.Size(531, 116);
            this.grillaSolicitudes.TabIndex = 27;
            this.grillaSolicitudes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaSolicitudes_CellClick);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirmar.Location = new System.Drawing.Point(123, 31);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirmar.TabIndex = 28;
            this.btnConfirmar.Text = "btnConfirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // grillaSolicDetalles
            // 
            this.grillaSolicDetalles.BackgroundColor = System.Drawing.Color.White;
            this.grillaSolicDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaSolicDetalles.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.grillaCotizaciones.BackgroundColor = System.Drawing.Color.White;
            this.grillaCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaCotizaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.grillaCotizaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaCotizaciones.Location = new System.Drawing.Point(12, 380);
            this.grillaCotizaciones.Name = "grillaCotizaciones";
            this.grillaCotizaciones.Size = new System.Drawing.Size(531, 136);
            this.grillaCotizaciones.TabIndex = 31;
            this.grillaCotizaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaCotizaciones_CellContentClick);
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
            // btnGenerarCaja
            // 
            this.btnGenerarCaja.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerarCaja.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerarCaja.Location = new System.Drawing.Point(28, 78);
            this.btnGenerarCaja.Name = "btnGenerarCaja";
            this.btnGenerarCaja.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerarCaja.TabIndex = 33;
            this.btnGenerarCaja.Text = "btnGenerarCaja";
            this.btnGenerarCaja.Click += new System.EventHandler(this.btnGenerarCaja_Click);
            // 
            // btnGenerarPartida
            // 
            this.btnGenerarPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerarPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerarPartida.Location = new System.Drawing.Point(109, 78);
            this.btnGenerarPartida.Name = "btnGenerarPartida";
            this.btnGenerarPartida.Size = new System.Drawing.Size(75, 23);
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
            this.pnlResPartida.Controls.Add(this.btnConfirmar);
            this.pnlResPartida.Controls.Add(this.btnGenerarCaja);
            this.pnlResPartida.Controls.Add(this.btnGenerarPartida);
            this.pnlResPartida.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlResPartida.Location = new System.Drawing.Point(577, 26);
            this.pnlResPartida.Name = "pnlResPartida";
            this.pnlResPartida.Size = new System.Drawing.Size(211, 137);
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
            this.Controls.Add(this.grillaSolicitudes);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblIdSolicitud);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.cboDep);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmPartidaSolicitar";
            this.Text = "MetroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPartidaSolicitar_FormClosing);
            this.Load += new System.EventHandler(this.frmPartidaSolicitar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).EndInit();
            this.pnlResPartida.ResumeLayout(false);
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
        private DevComponents.DotNetBar.ButtonX btnConfirmar;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaSolicDetalles;
        private DevComponents.DotNetBar.LabelX lblDetalles;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaCotizaciones;
        private DevComponents.DotNetBar.LabelX lblCotizaciones;
        private DevComponents.DotNetBar.ButtonX btnGenerarCaja;
        private DevComponents.DotNetBar.ButtonX btnGenerarPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoTotal;
        private DevComponents.DotNetBar.LabelX lblMontoTotal;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlResPartida;
    }
}