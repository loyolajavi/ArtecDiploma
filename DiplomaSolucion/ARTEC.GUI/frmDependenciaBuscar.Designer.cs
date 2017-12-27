namespace ARTEC.GUI
{
    partial class frmDependenciaBuscar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTipoDep = new DevComponents.DotNetBar.LabelX();
            this.txtTipoDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblAgentes = new DevComponents.DotNetBar.LabelX();
            this.GrillaAgentes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAgentes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(195, 285);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 0;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(12, 23);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 51;
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
            this.txtDependencia.Location = new System.Drawing.Point(109, 18);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(315, 22);
            this.txtDependencia.TabIndex = 52;
            this.txtDependencia.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
            // 
            // lblTipoDep
            // 
            // 
            // 
            // 
            this.lblTipoDep.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoDep.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDep.Location = new System.Drawing.Point(12, 52);
            this.lblTipoDep.Name = "lblTipoDep";
            this.lblTipoDep.Size = new System.Drawing.Size(91, 17);
            this.lblTipoDep.TabIndex = 53;
            this.lblTipoDep.Text = "lblTipoDep";
            // 
            // txtTipoDep
            // 
            this.txtTipoDep.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTipoDep.Border.Class = "TextBoxBorder";
            this.txtTipoDep.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTipoDep.DisabledBackColor = System.Drawing.Color.White;
            this.txtTipoDep.ForeColor = System.Drawing.Color.Black;
            this.txtTipoDep.Location = new System.Drawing.Point(109, 47);
            this.txtTipoDep.Name = "txtTipoDep";
            this.txtTipoDep.PreventEnterBeep = true;
            this.txtTipoDep.Size = new System.Drawing.Size(315, 22);
            this.txtTipoDep.TabIndex = 54;
            // 
            // lblAgentes
            // 
            // 
            // 
            // 
            this.lblAgentes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAgentes.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentes.Location = new System.Drawing.Point(12, 90);
            this.lblAgentes.Name = "lblAgentes";
            this.lblAgentes.Size = new System.Drawing.Size(91, 17);
            this.lblAgentes.TabIndex = 55;
            this.lblAgentes.Text = "lblAgentes";
            // 
            // GrillaAgentes
            // 
            this.GrillaAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaAgentes.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaAgentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaAgentes.Location = new System.Drawing.Point(12, 113);
            this.GrillaAgentes.Name = "GrillaAgentes";
            this.GrillaAgentes.Size = new System.Drawing.Size(422, 150);
            this.GrillaAgentes.TabIndex = 56;
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(109, 18);
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(315, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 57;
            this.cboDep.SelectionChangeCommitted += new System.EventHandler(this.cboDep_SelectionChangeCommitted);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Location = new System.Drawing.Point(359, 285);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 58;
            this.btnEliminar.Text = "btnEliminar";
            // 
            // frmDependenciaBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 315);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.GrillaAgentes);
            this.Controls.Add(this.lblAgentes);
            this.Controls.Add(this.txtTipoDep);
            this.Controls.Add(this.lblTipoDep);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.cboDep);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDependenciaBuscar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmDependenciaBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAgentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.LabelX lblTipoDep;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTipoDep;
        private DevComponents.DotNetBar.LabelX lblAgentes;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaAgentes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
    }
}