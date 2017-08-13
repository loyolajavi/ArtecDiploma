namespace ARTEC.GUI
{
    partial class GrillaRendicion
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFactura = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFactura = new DevComponents.DotNetBar.LabelX();
            this.GrillaInventarios = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInventarios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFactura
            // 
            this.txtFactura.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFactura.Border.Class = "TextBoxBorder";
            this.txtFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFactura.DisabledBackColor = System.Drawing.Color.White;
            this.txtFactura.ForeColor = System.Drawing.Color.Black;
            this.txtFactura.Location = new System.Drawing.Point(84, 3);
            this.txtFactura.Multiline = true;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.PreventEnterBeep = true;
            this.txtFactura.ReadOnly = true;
            this.txtFactura.Size = new System.Drawing.Size(102, 22);
            this.txtFactura.TabIndex = 50;
            // 
            // lblFactura
            // 
            // 
            // 
            // 
            this.lblFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFactura.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.Location = new System.Drawing.Point(3, 3);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(75, 22);
            this.lblFactura.TabIndex = 51;
            this.lblFactura.Text = "lblFactura";
            // 
            // GrillaInventarios
            // 
            this.GrillaInventarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaInventarios.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaInventarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaInventarios.Location = new System.Drawing.Point(3, 31);
            this.GrillaInventarios.Name = "GrillaInventarios";
            this.GrillaInventarios.ReadOnly = true;
            this.GrillaInventarios.Size = new System.Drawing.Size(500, 150);
            this.GrillaInventarios.TabIndex = 52;
            // 
            // GrillaRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrillaInventarios);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.lblFactura);
            this.Name = "GrillaRendicion";
            this.Size = new System.Drawing.Size(527, 198);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInventarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtFactura;
        private DevComponents.DotNetBar.LabelX lblFactura;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaInventarios;
    }
}
