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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNroSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolic = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.GrillaDetallesSolic = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.gridBien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrillaInvDisponibles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewX3 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowInventarios = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesSolic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInvDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX3)).BeginInit();
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
            this.txtNroSolic.Multiline = true;
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
            this.txtDependencia.Multiline = true;
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
            // GrillaDetallesSolic
            // 
            this.GrillaDetallesSolic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDetallesSolic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridBien,
            this.gridCant});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaDetallesSolic.DefaultCellStyle = dataGridViewCellStyle10;
            this.GrillaDetallesSolic.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaDetallesSolic.Location = new System.Drawing.Point(12, 52);
            this.GrillaDetallesSolic.Name = "GrillaDetallesSolic";
            this.GrillaDetallesSolic.Size = new System.Drawing.Size(601, 92);
            this.GrillaDetallesSolic.TabIndex = 50;
            this.GrillaDetallesSolic.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDetallesSolic_CellClick);
            // 
            // gridBien
            // 
            this.gridBien.HeaderText = "Bien";
            this.gridBien.Name = "gridBien";
            // 
            // gridCant
            // 
            this.gridCant.HeaderText = "Cantidad";
            this.gridCant.Name = "gridCant";
            // 
            // GrillaInvDisponibles
            // 
            this.GrillaInvDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaInvDisponibles.DefaultCellStyle = dataGridViewCellStyle11;
            this.GrillaInvDisponibles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaInvDisponibles.Location = new System.Drawing.Point(12, 174);
            this.GrillaInvDisponibles.Name = "GrillaInvDisponibles";
            this.GrillaInvDisponibles.Size = new System.Drawing.Size(601, 137);
            this.GrillaInvDisponibles.TabIndex = 51;
            // 
            // dataGridViewX3
            // 
            this.dataGridViewX3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX3.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewX3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX3.Location = new System.Drawing.Point(12, 342);
            this.dataGridViewX3.Name = "dataGridViewX3";
            this.dataGridViewX3.Size = new System.Drawing.Size(601, 137);
            this.dataGridViewX3.TabIndex = 52;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // flowInventarios
            // 
            this.flowInventarios.AutoScroll = true;
            this.flowInventarios.BackColor = System.Drawing.Color.Transparent;
            this.flowInventarios.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowInventarios.Location = new System.Drawing.Point(661, 52);
            this.flowInventarios.Name = "flowInventarios";
            this.flowInventarios.Size = new System.Drawing.Size(533, 427);
            this.flowInventarios.TabIndex = 53;
            this.flowInventarios.WrapContents = false;
            // 
            // frmBienAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 519);
            this.Controls.Add(this.flowInventarios);
            this.Controls.Add(this.dataGridViewX3);
            this.Controls.Add(this.GrillaInvDisponibles);
            this.Controls.Add(this.GrillaDetallesSolic);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtNroSolic);
            this.Controls.Add(this.lblNroSolic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmBienAsignar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmBienAsignar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDetallesSolic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInvDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolic;
        private DevComponents.DotNetBar.LabelX lblNroSolic;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaDetallesSolic;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaInvDisponibles;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridBien;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCant;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.FlowLayoutPanel flowInventarios;
    }
}