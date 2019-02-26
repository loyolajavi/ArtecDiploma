using System.Collections.Generic;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartidaModificar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNroPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartida = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtIdPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdPartida = new DevComponents.DotNetBar.LabelX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblMontoSolic = new DevComponents.DotNetBar.LabelX();
            this.txtMontoSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFechaEnvio = new DevComponents.DotNetBar.LabelX();
            this.txtFechaEnvio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grillaDetallesPart = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblDetalles = new DevComponents.DotNetBar.LabelX();
            this.lblCotizaciones = new DevComponents.DotNetBar.LabelX();
            this.grillaCotizaciones = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnRegenerarPartida = new DevComponents.DotNetBar.ButtonX();
            this.GrillaCotizAntiguas = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.lblVolver = new DevComponents.DotNetBar.LabelX();
            this.btnImprimirPartida = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCotizAntiguas)).BeginInit();
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
            this.txtNroPartida.Location = new System.Drawing.Point(115, 96);
            this.txtNroPartida.Name = "txtNroPartida";
            this.txtNroPartida.PreventEnterBeep = true;
            this.txtNroPartida.ReadOnly = true;
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
            this.lblNroPartida.Location = new System.Drawing.Point(8, 101);
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
            this.txtNroSolicitud.Location = new System.Drawing.Point(115, 40);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.ReadOnly = true;
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
            this.lblIdSolicitud.Location = new System.Drawing.Point(8, 45);
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
            this.txtIdPartida.Location = new System.Drawing.Point(115, 12);
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.PreventEnterBeep = true;
            this.txtIdPartida.ReadOnly = true;
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
            this.lblIdPartida.Location = new System.Drawing.Point(8, 17);
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
            this.lblDependencia.Location = new System.Drawing.Point(8, 73);
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
            this.txtDependencia.Location = new System.Drawing.Point(115, 68);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.ReadOnly = true;
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
            this.cboDep.Location = new System.Drawing.Point(115, 68);
            this.cboDep.MaxDropDownItems = 10;
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(315, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 64;
            this.cboDep.Visible = false;
            // 
            // lblMontoSolic
            // 
            // 
            // 
            // 
            this.lblMontoSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSolic.Location = new System.Drawing.Point(134, 134);
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
            this.txtMontoSolic.Location = new System.Drawing.Point(134, 157);
            this.txtMontoSolic.Name = "txtMontoSolic";
            this.txtMontoSolic.PreventEnterBeep = true;
            this.txtMontoSolic.ReadOnly = true;
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
            this.lblFechaEnvio.Location = new System.Drawing.Point(8, 134);
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
            this.txtFechaEnvio.Location = new System.Drawing.Point(8, 157);
            this.txtFechaEnvio.Name = "txtFechaEnvio";
            this.txtFechaEnvio.PreventEnterBeep = true;
            this.txtFechaEnvio.ReadOnly = true;
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
            this.grillaDetallesPart.Location = new System.Drawing.Point(469, 33);
            this.grillaDetallesPart.Name = "grillaDetallesPart";
            this.grillaDetallesPart.ReadOnly = true;
            this.grillaDetallesPart.Size = new System.Drawing.Size(476, 124);
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
            this.lblDetalles.Location = new System.Drawing.Point(469, 10);
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
            this.lblCotizaciones.Location = new System.Drawing.Point(469, 163);
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
            this.grillaCotizaciones.Location = new System.Drawing.Point(469, 186);
            this.grillaCotizaciones.Name = "grillaCotizaciones";
            this.grillaCotizaciones.ReadOnly = true;
            this.grillaCotizaciones.Size = new System.Drawing.Size(476, 136);
            this.grillaCotizaciones.TabIndex = 78;
            this.grillaCotizaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaCotizaciones_CellClick);
            // 
            // btnRegenerarPartida
            // 
            this.btnRegenerarPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegenerarPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegenerarPartida.Location = new System.Drawing.Point(216, 242);
            this.btnRegenerarPartida.Name = "btnRegenerarPartida";
            this.btnRegenerarPartida.Size = new System.Drawing.Size(123, 37);
            this.btnRegenerarPartida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegenerarPartida.TabIndex = 82;
            this.btnRegenerarPartida.Tag = ((object)(resources.GetObject("btnRegenerarPartida.Tag")));
            this.btnRegenerarPartida.Text = "btnRegenerarPartida";
            this.btnRegenerarPartida.Click += new System.EventHandler(this.btnGenerarDocumento_Click);
            // 
            // GrillaCotizAntiguas
            // 
            this.GrillaCotizAntiguas.BackgroundColor = System.Drawing.Color.White;
            this.GrillaCotizAntiguas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaCotizAntiguas.DefaultCellStyle = dataGridViewCellStyle3;
            this.GrillaCotizAntiguas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaCotizAntiguas.Location = new System.Drawing.Point(469, 328);
            this.GrillaCotizAntiguas.Name = "GrillaCotizAntiguas";
            this.GrillaCotizAntiguas.ReadOnly = true;
            this.GrillaCotizAntiguas.Size = new System.Drawing.Size(476, 136);
            this.GrillaCotizAntiguas.TabIndex = 81;
            this.GrillaCotizAntiguas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaCotizAntiguas_CellClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Location = new System.Drawing.Point(883, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 27);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 83;
            this.btnCancelar.Tag = ((object)(resources.GetObject("btnCancelar.Tag")));
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblVolver
            // 
            // 
            // 
            // 
            this.lblVolver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblVolver.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolver.Location = new System.Drawing.Point(1, 500);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(63, 23);
            this.lblVolver.TabIndex = 84;
            this.lblVolver.Text = "lblVolver";
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            // 
            // btnImprimirPartida
            // 
            this.btnImprimirPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImprimirPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImprimirPartida.Location = new System.Drawing.Point(216, 306);
            this.btnImprimirPartida.Name = "btnImprimirPartida";
            this.btnImprimirPartida.Size = new System.Drawing.Size(123, 37);
            this.btnImprimirPartida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImprimirPartida.TabIndex = 85;
            this.btnImprimirPartida.Tag = ((object)(resources.GetObject("btnImprimirPartida.Tag")));
            this.btnImprimirPartida.Text = "btnImprimirPartida";
            this.btnImprimirPartida.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmPartidaModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 521);
            this.ControlBox = false;
            this.Controls.Add(this.btnImprimirPartida);
            this.Controls.Add(this.lblVolver);
            this.Controls.Add(this.btnRegenerarPartida);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.GrillaCotizAntiguas);
            this.Controls.Add(this.lblCotizaciones);
            this.Controls.Add(this.grillaCotizaciones);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.grillaDetallesPart);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPartidaModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmPartidaModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCotizaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCotizAntiguas)).EndInit();
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
        private DevComponents.DotNetBar.LabelX lblMontoSolic;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoSolic;
        private DevComponents.DotNetBar.LabelX lblFechaEnvio;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFechaEnvio;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetallesPart;
        private DevComponents.DotNetBar.LabelX lblDetalles;
        private DevComponents.DotNetBar.LabelX lblCotizaciones;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaCotizaciones;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaCotizAntiguas;
        private DevComponents.DotNetBar.ButtonX btnRegenerarPartida;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.LabelX lblVolver;
        private DevComponents.DotNetBar.ButtonX btnImprimirPartida;
    }
}