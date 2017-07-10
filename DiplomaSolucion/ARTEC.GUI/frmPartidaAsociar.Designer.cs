namespace ARTEC.GUI
{
    partial class frmPartidaAsociar
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
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.txtIdPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdPartida = new DevComponents.DotNetBar.LabelX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDependencia = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.grillaDetallesPart = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtNroPartAsignado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartAsignada = new DevComponents.DotNetBar.LabelX();
            this.txtMontoOtorgado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoAcreditado = new DevComponents.DotNetBar.LabelX();
            this.btnAsociar = new DevComponents.DotNetBar.ButtonX();
            this.txtIdSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtFechaEnvio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFechaEnvio = new DevComponents.DotNetBar.LabelX();
            this.gboxDetallesPartida = new System.Windows.Forms.GroupBox();
            this.lblMontoSolic = new DevComponents.DotNetBar.LabelX();
            this.txtMontoSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkCaja = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.grillaSolicitudes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).BeginInit();
            this.gboxDetallesPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(135, 89);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 22);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.txtIdPartida.Location = new System.Drawing.Point(13, 89);
            this.txtIdPartida.Multiline = true;
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.PreventEnterBeep = true;
            this.txtIdPartida.Size = new System.Drawing.Size(102, 22);
            this.txtIdPartida.TabIndex = 31;
            // 
            // lblIdPartida
            // 
            // 
            // 
            // 
            this.lblIdPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPartida.Location = new System.Drawing.Point(13, 66);
            this.lblIdPartida.Name = "lblIdPartida";
            this.lblIdPartida.Size = new System.Drawing.Size(102, 17);
            this.lblIdPartida.TabIndex = 30;
            this.lblIdPartida.Text = "lblIdPartida";
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(135, 12);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 27;
            this.lblDependencia.Text = "Dependencia";
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
            this.txtDependencia.Location = new System.Drawing.Point(135, 35);
            this.txtDependencia.Multiline = true;
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(284, 22);
            this.txtDependencia.TabIndex = 28;
            // 
            // cboDependencia
            // 
            this.cboDependencia.DisplayMember = "Text";
            this.cboDependencia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDependencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDependencia.ForeColor = System.Drawing.Color.Black;
            this.cboDependencia.FormattingEnabled = true;
            this.cboDependencia.ItemHeight = 16;
            this.cboDependencia.Location = new System.Drawing.Point(135, 35);
            this.cboDependencia.MaxDropDownItems = 10;
            this.cboDependencia.Name = "cboDependencia";
            this.cboDependencia.Size = new System.Drawing.Size(315, 22);
            this.cboDependencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDependencia.TabIndex = 29;
            this.cboDependencia.Visible = false;
            // 
            // grillaDetallesPart
            // 
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
            this.grillaDetallesPart.Location = new System.Drawing.Point(11, 86);
            this.grillaDetallesPart.Name = "grillaDetallesPart";
            this.grillaDetallesPart.Size = new System.Drawing.Size(426, 92);
            this.grillaDetallesPart.TabIndex = 34;
            // 
            // txtNroPartAsignado
            // 
            this.txtNroPartAsignado.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroPartAsignado.Border.Class = "TextBoxBorder";
            this.txtNroPartAsignado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroPartAsignado.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroPartAsignado.ForeColor = System.Drawing.Color.Black;
            this.txtNroPartAsignado.Location = new System.Drawing.Point(12, 453);
            this.txtNroPartAsignado.Multiline = true;
            this.txtNroPartAsignado.Name = "txtNroPartAsignado";
            this.txtNroPartAsignado.PreventEnterBeep = true;
            this.txtNroPartAsignado.Size = new System.Drawing.Size(102, 22);
            this.txtNroPartAsignado.TabIndex = 36;
            // 
            // lblNroPartAsignada
            // 
            // 
            // 
            // 
            this.lblNroPartAsignada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroPartAsignada.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPartAsignada.Location = new System.Drawing.Point(12, 430);
            this.lblNroPartAsignada.Name = "lblNroPartAsignada";
            this.lblNroPartAsignada.Size = new System.Drawing.Size(141, 17);
            this.lblNroPartAsignada.TabIndex = 35;
            this.lblNroPartAsignada.Text = "lblNroPartAsignada";
            // 
            // txtMontoOtorgado
            // 
            this.txtMontoOtorgado.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMontoOtorgado.Border.Class = "TextBoxBorder";
            this.txtMontoOtorgado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMontoOtorgado.DisabledBackColor = System.Drawing.Color.White;
            this.txtMontoOtorgado.ForeColor = System.Drawing.Color.Black;
            this.txtMontoOtorgado.Location = new System.Drawing.Point(166, 453);
            this.txtMontoOtorgado.Multiline = true;
            this.txtMontoOtorgado.Name = "txtMontoOtorgado";
            this.txtMontoOtorgado.PreventEnterBeep = true;
            this.txtMontoOtorgado.Size = new System.Drawing.Size(102, 22);
            this.txtMontoOtorgado.TabIndex = 38;
            // 
            // lblMontoAcreditado
            // 
            // 
            // 
            // 
            this.lblMontoAcreditado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoAcreditado.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoAcreditado.Location = new System.Drawing.Point(166, 430);
            this.lblMontoAcreditado.Name = "lblMontoAcreditado";
            this.lblMontoAcreditado.Size = new System.Drawing.Size(143, 17);
            this.lblMontoAcreditado.TabIndex = 37;
            this.lblMontoAcreditado.Text = "lblMontoAcreditado";
            // 
            // btnAsociar
            // 
            this.btnAsociar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAsociar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAsociar.Location = new System.Drawing.Point(319, 453);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(75, 23);
            this.btnAsociar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAsociar.TabIndex = 39;
            this.btnAsociar.Text = "btnAsociar";
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
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
            this.txtIdSolicitud.Location = new System.Drawing.Point(12, 35);
            this.txtIdSolicitud.Multiline = true;
            this.txtIdSolicitud.Name = "txtIdSolicitud";
            this.txtIdSolicitud.PreventEnterBeep = true;
            this.txtIdSolicitud.Size = new System.Drawing.Size(102, 22);
            this.txtIdSolicitud.TabIndex = 41;
            // 
            // lblIdSolicitud
            // 
            // 
            // 
            // 
            this.lblIdSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdSolicitud.Location = new System.Drawing.Point(13, 12);
            this.lblIdSolicitud.Name = "lblIdSolicitud";
            this.lblIdSolicitud.Size = new System.Drawing.Size(102, 17);
            this.lblIdSolicitud.TabIndex = 40;
            this.lblIdSolicitud.Text = "lblIdSolicitud";
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
            this.txtFechaEnvio.Location = new System.Drawing.Point(11, 46);
            this.txtFechaEnvio.Multiline = true;
            this.txtFechaEnvio.Name = "txtFechaEnvio";
            this.txtFechaEnvio.PreventEnterBeep = true;
            this.txtFechaEnvio.Size = new System.Drawing.Size(102, 22);
            this.txtFechaEnvio.TabIndex = 43;
            // 
            // lblFechaEnvio
            // 
            // 
            // 
            // 
            this.lblFechaEnvio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaEnvio.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEnvio.Location = new System.Drawing.Point(11, 23);
            this.lblFechaEnvio.Name = "lblFechaEnvio";
            this.lblFechaEnvio.Size = new System.Drawing.Size(102, 17);
            this.lblFechaEnvio.TabIndex = 42;
            this.lblFechaEnvio.Text = "lblFechaEnvio";
            // 
            // gboxDetallesPartida
            // 
            this.gboxDetallesPartida.Controls.Add(this.chkCaja);
            this.gboxDetallesPartida.Controls.Add(this.lblMontoSolic);
            this.gboxDetallesPartida.Controls.Add(this.txtMontoSolic);
            this.gboxDetallesPartida.Controls.Add(this.lblFechaEnvio);
            this.gboxDetallesPartida.Controls.Add(this.txtFechaEnvio);
            this.gboxDetallesPartida.Controls.Add(this.grillaDetallesPart);
            this.gboxDetallesPartida.Location = new System.Drawing.Point(2, 228);
            this.gboxDetallesPartida.Name = "gboxDetallesPartida";
            this.gboxDetallesPartida.Size = new System.Drawing.Size(448, 193);
            this.gboxDetallesPartida.TabIndex = 44;
            this.gboxDetallesPartida.TabStop = false;
            this.gboxDetallesPartida.Text = "groupBox1";
            // 
            // lblMontoSolic
            // 
            // 
            // 
            // 
            this.lblMontoSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSolic.Location = new System.Drawing.Point(137, 23);
            this.lblMontoSolic.Name = "lblMontoSolic";
            this.lblMontoSolic.Size = new System.Drawing.Size(102, 17);
            this.lblMontoSolic.TabIndex = 44;
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
            this.txtMontoSolic.Location = new System.Drawing.Point(137, 46);
            this.txtMontoSolic.Multiline = true;
            this.txtMontoSolic.Name = "txtMontoSolic";
            this.txtMontoSolic.PreventEnterBeep = true;
            this.txtMontoSolic.Size = new System.Drawing.Size(102, 22);
            this.txtMontoSolic.TabIndex = 45;
            // 
            // chkCaja
            // 
            // 
            // 
            // 
            this.chkCaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkCaja.Location = new System.Drawing.Point(261, 46);
            this.chkCaja.Name = "chkCaja";
            this.chkCaja.Size = new System.Drawing.Size(86, 22);
            this.chkCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkCaja.TabIndex = 47;
            this.chkCaja.Text = "chkCaja";
            // 
            // grillaSolicitudes
            // 
            this.grillaSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaSolicitudes.DefaultCellStyle = dataGridViewCellStyle2;
            this.grillaSolicitudes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaSolicitudes.Location = new System.Drawing.Point(12, 127);
            this.grillaSolicitudes.Name = "grillaSolicitudes";
            this.grillaSolicitudes.Size = new System.Drawing.Size(438, 81);
            this.grillaSolicitudes.TabIndex = 45;
            // 
            // frmPartidaAsociar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 491);
            this.Controls.Add(this.grillaSolicitudes);
            this.Controls.Add(this.gboxDetallesPartida);
            this.Controls.Add(this.txtIdSolicitud);
            this.Controls.Add(this.lblIdSolicitud);
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.txtMontoOtorgado);
            this.Controls.Add(this.lblMontoAcreditado);
            this.Controls.Add(this.txtNroPartAsignado);
            this.Controls.Add(this.lblNroPartAsignada);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdPartida);
            this.Controls.Add(this.lblIdPartida);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.cboDependencia);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPartidaAsociar";
            this.Text = "MetroForm";
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).EndInit();
            this.gboxDetallesPartida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdPartida;
        private DevComponents.DotNetBar.LabelX lblIdPartida;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDependencia;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetallesPart;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPartAsignado;
        private DevComponents.DotNetBar.LabelX lblNroPartAsignada;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoOtorgado;
        private DevComponents.DotNetBar.LabelX lblMontoAcreditado;
        private DevComponents.DotNetBar.ButtonX btnAsociar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdSolicitud;
        private DevComponents.DotNetBar.LabelX lblIdSolicitud;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFechaEnvio;
        private DevComponents.DotNetBar.LabelX lblFechaEnvio;
        private System.Windows.Forms.GroupBox gboxDetallesPartida;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkCaja;
        private DevComponents.DotNetBar.LabelX lblMontoSolic;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoSolic;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaSolicitudes;
    }
}