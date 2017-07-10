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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNroSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolic = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.GrillaDetallesSolic = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.GrillaInvDisponibles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewX3 = new DevComponents.DotNetBar.Controls.DataGridViewX();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaDetallesSolic.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaDetallesSolic.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaDetallesSolic.Location = new System.Drawing.Point(12, 52);
            this.GrillaDetallesSolic.Name = "GrillaDetallesSolic";
            this.GrillaDetallesSolic.Size = new System.Drawing.Size(601, 92);
            this.GrillaDetallesSolic.TabIndex = 50;
            this.GrillaDetallesSolic.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDetallesSolic_CellClick);
            // 
            // GrillaInvDisponibles
            // 
            this.GrillaInvDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaInvDisponibles.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaInvDisponibles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaInvDisponibles.Location = new System.Drawing.Point(12, 174);
            this.GrillaInvDisponibles.Name = "GrillaInvDisponibles";
            this.GrillaInvDisponibles.Size = new System.Drawing.Size(601, 137);
            this.GrillaInvDisponibles.TabIndex = 51;
            // 
            // dataGridViewX3
            // 
            this.dataGridViewX3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX3.Location = new System.Drawing.Point(12, 342);
            this.dataGridViewX3.Name = "dataGridViewX3";
            this.dataGridViewX3.Size = new System.Drawing.Size(601, 137);
            this.dataGridViewX3.TabIndex = 52;
            // 
            // frmBienAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 519);
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
    }
}