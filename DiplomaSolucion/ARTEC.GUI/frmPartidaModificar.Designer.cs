namespace ARTEC.GUI
{
    partial class frmPartidaModificar
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
            this.txtNroPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartida = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtIdPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdPartida = new DevComponents.DotNetBar.LabelX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chkCaja = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblMontoSolic = new DevComponents.DotNetBar.LabelX();
            this.txtMontoSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFechaEnvio = new DevComponents.DotNetBar.LabelX();
            this.txtFechaEnvio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grillaDetallesPart = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblDetalles = new DevComponents.DotNetBar.LabelX();
            this.lblCotizaciones = new DevComponents.DotNetBar.LabelX();
            this.grillaCotizaciones = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlResPartida = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtMontoTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoTotal = new DevComponents.DotNetBar.LabelX();
            this.btnGenerarCaja = new DevComponents.DotNetBar.ButtonX();
            this.btnGenerarPartida = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).BeginInit();
            this.pnlResPartida.SuspendLayout();
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
            this.txtNroPartida.Location = new System.Drawing.Point(115, 88);
            this.txtNroPartida.Name = "txtNroPartida";
            this.txtNroPartida.PreventEnterBeep = true;
            this.txtNroPartida.Size = new System.Drawing.Size(102, 22);
            this.txtNroPartida.TabIndex = 70;
            // 
            // lblNroPartida
            // 
            // 
            // 
            // 
            this.lblNroPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPartida.Location = new System.Drawing.Point(8, 93);
            this.lblNroPartida.Name = "lblNroPartida";
            this.lblNroPartida.Size = new System.Drawing.Size(91, 17);
            this.lblNroPartida.TabIndex = 69;
            this.lblNroPartida.Text = "lblNroPartida";
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
            this.txtNroSolicitud.Location = new System.Drawing.Point(115, 32);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtNroSolicitud.TabIndex = 68;
            // 
            // lblIdSolicitud
            // 
            // 
            // 
            // 
            this.lblIdSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdSolicitud.Location = new System.Drawing.Point(8, 37);
            this.lblIdSolicitud.Name = "lblIdSolicitud";
            this.lblIdSolicitud.Size = new System.Drawing.Size(102, 17);
            this.lblIdSolicitud.TabIndex = 67;
            this.lblIdSolicitud.Text = "lblIdSolicitud";
            // 
            // txtIdPartida
            // 
            this.txtIdPartida.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIdPartida.Border.Class = "TextBoxBorder";
            this.txtIdPartida.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdPartida.DisabledBackColor = System.Drawing.Color.White;
            this.txtIdPartida.ForeColor = System.Drawing.Color.Black;
            this.txtIdPartida.Location = new System.Drawing.Point(115, 4);
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.PreventEnterBeep = true;
            this.txtIdPartida.Size = new System.Drawing.Size(102, 22);
            this.txtIdPartida.TabIndex = 66;
            // 
            // lblIdPartida
            // 
            // 
            // 
            // 
            this.lblIdPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPartida.Location = new System.Drawing.Point(8, 9);
            this.lblIdPartida.Name = "lblIdPartida";
            this.lblIdPartida.Size = new System.Drawing.Size(102, 17);
            this.lblIdPartida.TabIndex = 65;
            this.lblIdPartida.Text = "lblIdPartida";
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(8, 65);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 62;
            this.lblDependencia.Text = "lblDependencia";
            // 
            // txtDependencia
            // 
            this.txtDependencia.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDependencia.Border.Class = "TextBoxBorder";
            this.txtDependencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDependencia.DisabledBackColor = System.Drawing.Color.White;
            this.txtDependencia.ForeColor = System.Drawing.Color.Black;
            this.txtDependencia.Location = new System.Drawing.Point(115, 60);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(315, 22);
            this.txtDependencia.TabIndex = 63;
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(115, 60);
            this.cboDep.MaxDropDownItems = 10;
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(315, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 64;
            this.cboDep.Visible = false;
            // 
            // chkCaja
            // 
            // 
            // 
            // 
            this.chkCaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkCaja.Location = new System.Drawing.Point(258, 149);
            this.chkCaja.Name = "chkCaja";
            this.chkCaja.Size = new System.Drawing.Size(86, 22);
            this.chkCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkCaja.TabIndex = 75;
            this.chkCaja.Text = "chkCaja";
            // 
            // lblMontoSolic
            // 
            // 
            // 
            // 
            this.lblMontoSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSolic.Location = new System.Drawing.Point(134, 126);
            this.lblMontoSolic.Name = "lblMontoSolic";
            this.lblMontoSolic.Size = new System.Drawing.Size(102, 17);
            this.lblMontoSolic.TabIndex = 73;
            this.lblMontoSolic.Text = "lblMontoSolic";
            // 
            // txtMontoSolic
            // 
            this.txtMontoSolic.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMontoSolic.Border.Class = "TextBoxBorder";
            this.txtMontoSolic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMontoSolic.DisabledBackColor = System.Drawing.Color.White;
            this.txtMontoSolic.ForeColor = System.Drawing.Color.Black;
            this.txtMontoSolic.Location = new System.Drawing.Point(134, 149);
            this.txtMontoSolic.Name = "txtMontoSolic";
            this.txtMontoSolic.PreventEnterBeep = true;
            this.txtMontoSolic.Size = new System.Drawing.Size(102, 22);
            this.txtMontoSolic.TabIndex = 74;
            // 
            // lblFechaEnvio
            // 
            // 
            // 
            // 
            this.lblFechaEnvio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaEnvio.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEnvio.Location = new System.Drawing.Point(8, 126);
            this.lblFechaEnvio.Name = "lblFechaEnvio";
            this.lblFechaEnvio.Size = new System.Drawing.Size(102, 17);
            this.lblFechaEnvio.TabIndex = 71;
            this.lblFechaEnvio.Text = "lblFechaEnvio";
            // 
            // txtFechaEnvio
            // 
            this.txtFechaEnvio.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFechaEnvio.Border.Class = "TextBoxBorder";
            this.txtFechaEnvio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaEnvio.DisabledBackColor = System.Drawing.Color.White;
            this.txtFechaEnvio.ForeColor = System.Drawing.Color.Black;
            this.txtFechaEnvio.Location = new System.Drawing.Point(8, 149);
            this.txtFechaEnvio.Name = "txtFechaEnvio";
            this.txtFechaEnvio.PreventEnterBeep = true;
            this.txtFechaEnvio.Size = new System.Drawing.Size(102, 22);
            this.txtFechaEnvio.TabIndex = 72;
            // 
            // grillaDetallesPart
            // 
            this.grillaDetallesPart.BackgroundColor = System.Drawing.Color.White;
            this.grillaDetallesPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaDetallesPart.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaDetallesPart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaDetallesPart.Location = new System.Drawing.Point(4, 200);
            this.grillaDetallesPart.Name = "grillaDetallesPart";
            this.grillaDetallesPart.Size = new System.Drawing.Size(426, 93);
            this.grillaDetallesPart.TabIndex = 76;
            this.grillaDetallesPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaDetallesPart_CellClick);
            // 
            // lblDetalles
            // 
            // 
            // 
            // 
            this.lblDetalles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDetalles.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.Location = new System.Drawing.Point(4, 177);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(102, 17);
            this.lblDetalles.TabIndex = 77;
            this.lblDetalles.Text = "lblDetalles";
            // 
            // lblCotizaciones
            // 
            // 
            // 
            // 
            this.lblCotizaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCotizaciones.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCotizaciones.Location = new System.Drawing.Point(4, 299);
            this.lblCotizaciones.Name = "lblCotizaciones";
            this.lblCotizaciones.Size = new System.Drawing.Size(102, 17);
            this.lblCotizaciones.TabIndex = 79;
            this.lblCotizaciones.Text = "lblCotizaciones";
            // 
            // grillaCotizaciones
            // 
            this.grillaCotizaciones.BackgroundColor = System.Drawing.Color.White;
            this.grillaCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaCotizaciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.grillaCotizaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaCotizaciones.Location = new System.Drawing.Point(4, 322);
            this.grillaCotizaciones.Name = "grillaCotizaciones";
            this.grillaCotizaciones.Size = new System.Drawing.Size(531, 136);
            this.grillaCotizaciones.TabIndex = 78;
            // 
            // pnlResPartida
            // 
            this.pnlResPartida.BackColor = System.Drawing.Color.White;
            this.pnlResPartida.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlResPartida.Controls.Add(this.txtMontoTotal);
            this.pnlResPartida.Controls.Add(this.lblMontoTotal);
            this.pnlResPartida.Controls.Add(this.btnGenerarCaja);
            this.pnlResPartida.Controls.Add(this.btnGenerarPartida);
            this.pnlResPartida.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlResPartida.Location = new System.Drawing.Point(465, 32);
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
            this.pnlResPartida.TabIndex = 80;
            this.pnlResPartida.Text = "pnlResPartida";
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
            // 
            // frmPartidaModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 490);
            this.Controls.Add(this.pnlResPartida);
            this.Controls.Add(this.lblCotizaciones);
            this.Controls.Add(this.grillaCotizaciones);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.grillaDetallesPart);
            this.Controls.Add(this.chkCaja);
            this.Controls.Add(this.lblMontoSolic);
            this.Controls.Add(this.txtMontoSolic);
            this.Controls.Add(this.lblFechaEnvio);
            this.Controls.Add(this.txtFechaEnvio);
            this.Controls.Add(this.txtNroPartida);
            this.Controls.Add(this.lblNroPartida);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblIdSolicitud);
            this.Controls.Add(this.txtIdPartida);
            this.Controls.Add(this.lblIdPartida);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.cboDep);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPartidaModificar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmPartidaModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).EndInit();
            this.pnlResPartida.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPartida;
        private DevComponents.DotNetBar.LabelX lblNroPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.LabelX lblIdSolicitud;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdPartida;
        private DevComponents.DotNetBar.LabelX lblIdPartida;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkCaja;
        private DevComponents.DotNetBar.LabelX lblMontoSolic;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoSolic;
        private DevComponents.DotNetBar.LabelX lblFechaEnvio;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFechaEnvio;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetallesPart;
        private DevComponents.DotNetBar.LabelX lblDetalles;
        private DevComponents.DotNetBar.LabelX lblCotizaciones;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaCotizaciones;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlResPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoTotal;
        private DevComponents.DotNetBar.LabelX lblMontoTotal;
        private DevComponents.DotNetBar.ButtonX btnGenerarCaja;
        private DevComponents.DotNetBar.ButtonX btnGenerarPartida;
    }
}