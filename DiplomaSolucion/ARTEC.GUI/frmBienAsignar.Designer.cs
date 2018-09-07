namespace ARTEC.GUI
{
    partial class frmBienAsignar
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
            this.txtNroSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolic = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.GrillaInvConfirmados = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowInventarios = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirmar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInvConfirmados)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNroSolic
            // 
            this.txtNroSolic.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroSolic.Border.Class = "TextBoxBorder";
            this.txtNroSolic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroSolic.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroSolic.ForeColor = System.Drawing.Color.Black;
            this.txtNroSolic.Location = new System.Drawing.Point(100, 12);
            this.txtNroSolic.Name = "txtNroSolic";
            this.txtNroSolic.PreventEnterBeep = true;
            this.txtNroSolic.Size = new System.Drawing.Size(102, 22);
            this.txtNroSolic.TabIndex = 46;
            // 
            // lblNroSolic
            // 
            // 
            // 
            // 
            this.lblNroSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolic.Location = new System.Drawing.Point(12, 12);
            this.lblNroSolic.Name = "lblNroSolic";
            this.lblNroSolic.Size = new System.Drawing.Size(97, 22);
            this.lblNroSolic.TabIndex = 47;
            this.lblNroSolic.Text = "lblNroSolic";
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
            this.txtDependencia.Location = new System.Drawing.Point(332, 12);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(281, 22);
            this.txtDependencia.TabIndex = 48;
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(216, 12);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(110, 22);
            this.lblDependencia.TabIndex = 49;
            this.lblDependencia.Text = "lblDependencia";
            // 
            // GrillaInvConfirmados
            // 
            this.GrillaInvConfirmados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaInvConfirmados.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaInvConfirmados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaInvConfirmados.Location = new System.Drawing.Point(12, 342);
            this.GrillaInvConfirmados.Name = "GrillaInvConfirmados";
            this.GrillaInvConfirmados.Size = new System.Drawing.Size(599, 167);
            this.GrillaInvConfirmados.TabIndex = 52;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // flowInventarios
            // 
            this.flowInventarios.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowInventarios.AutoScroll = true;
            this.flowInventarios.BackColor = System.Drawing.Color.Transparent;
            this.flowInventarios.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowInventarios.Location = new System.Drawing.Point(12, 40);
            this.flowInventarios.Name = "flowInventarios";
            this.flowInventarios.Size = new System.Drawing.Size(599, 296);
            this.flowInventarios.TabIndex = 53;
            this.flowInventarios.WrapContents = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirmar.Location = new System.Drawing.Point(261, 523);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 30);
            this.btnConfirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirmar.TabIndex = 54;
            this.btnConfirmar.Text = "btnConfirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmBienAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 558);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.flowInventarios);
            this.Controls.Add(this.GrillaInvConfirmados);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtNroSolic);
            this.Controls.Add(this.lblNroSolic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBienAsignar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmBienAsignar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInvConfirmados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolic;
        private DevComponents.DotNetBar.LabelX lblNroSolic;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaInvConfirmados;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.FlowLayoutPanel flowInventarios;
        private DevComponents.DotNetBar.ButtonX btnConfirmar;
    }
}