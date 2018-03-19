namespace ARTEC.GUI
{
    partial class frmAgenteCrear
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
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.lblApellido = new DevComponents.DotNetBar.LabelX();
            this.lblCargo = new DevComponents.DotNetBar.LabelX();
            this.cboCargo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnCrearAgente = new DevComponents.DotNetBar.ButtonX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtApellido = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(25, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 17);
            this.lblNombre.TabIndex = 62;
            this.lblNombre.Text = "lblNombre";
            // 
            // lblApellido
            // 
            // 
            // 
            // 
            this.lblApellido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblApellido.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(25, 47);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(91, 17);
            this.lblApellido.TabIndex = 64;
            this.lblApellido.Text = "lblApellido";
            // 
            // lblCargo
            // 
            // 
            // 
            // 
            this.lblCargo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCargo.Location = new System.Drawing.Point(25, 79);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 23);
            this.lblCargo.TabIndex = 77;
            this.lblCargo.Text = "lblCargo";
            // 
            // cboCargo
            // 
            this.cboCargo.DisplayMember = "Text";
            this.cboCargo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCargo.ForeColor = System.Drawing.Color.Black;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.ItemHeight = 16;
            this.cboCargo.Location = new System.Drawing.Point(122, 79);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(128, 22);
            this.cboCargo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCargo.TabIndex = 76;
            // 
            // btnCrearAgente
            // 
            this.btnCrearAgente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearAgente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearAgente.Location = new System.Drawing.Point(122, 159);
            this.btnCrearAgente.Name = "btnCrearAgente";
            this.btnCrearAgente.Size = new System.Drawing.Size(83, 23);
            this.btnCrearAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearAgente.TabIndex = 78;
            this.btnCrearAgente.Text = "btnCrearAgente";
            this.btnCrearAgente.Click += new System.EventHandler(this.btnCrearAgente_Click);
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(25, 122);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 79;
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
            this.txtDependencia.Enabled = false;
            this.txtDependencia.ForeColor = System.Drawing.Color.Black;
            this.txtDependencia.Location = new System.Drawing.Point(122, 117);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.ReadOnly = true;
            this.txtDependencia.Size = new System.Drawing.Size(285, 22);
            this.txtDependencia.TabIndex = 80;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(118, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(289, 22);
            this.txtNombre.TabIndex = 81;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtApellido.Border.Class = "TextBoxBorder";
            this.txtApellido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApellido.DisabledBackColor = System.Drawing.Color.White;
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(118, 42);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PreventEnterBeep = true;
            this.txtApellido.Size = new System.Drawing.Size(289, 22);
            this.txtApellido.TabIndex = 82;
            // 
            // frmAgenteCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 190);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.btnCrearAgente);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.cboCargo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAgenteCrear";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmAgenteCrear_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.LabelX lblApellido;
        private DevComponents.DotNetBar.LabelX lblCargo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCargo;
        private DevComponents.DotNetBar.ButtonX btnCrearAgente;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.Controls.TextBoxX txtApellido;
    }
}