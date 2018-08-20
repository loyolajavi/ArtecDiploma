namespace ARTEC.GUI
{
    partial class frmDialogUsuariosComprometidos
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
            this.cboFamilia = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblFamiliaBuscar = new DevComponents.DotNetBar.LabelX();
            this.lboxUsuarios = new DevComponents.DotNetBar.ListBoxAdv();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // cboFamilia
            // 
            this.cboFamilia.DisplayMember = "Text";
            this.cboFamilia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilia.ForeColor = System.Drawing.Color.Black;
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.ItemHeight = 16;
            this.cboFamilia.Location = new System.Drawing.Point(118, 10);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(202, 22);
            this.cboFamilia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboFamilia.TabIndex = 65;
            // 
            // lblFamiliaBuscar
            // 
            this.lblFamiliaBuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblFamiliaBuscar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFamiliaBuscar.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamiliaBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblFamiliaBuscar.Location = new System.Drawing.Point(12, 12);
            this.lblFamiliaBuscar.Name = "lblFamiliaBuscar";
            this.lblFamiliaBuscar.Size = new System.Drawing.Size(100, 17);
            this.lblFamiliaBuscar.TabIndex = 64;
            this.lblFamiliaBuscar.Text = "lblFamiliaBuscar";
            // 
            // lboxUsuarios
            // 
            this.lboxUsuarios.AutoScroll = true;
            this.lboxUsuarios.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lboxUsuarios.BackgroundStyle.Class = "ListBoxAdv";
            this.lboxUsuarios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lboxUsuarios.ContainerControlProcessDialogKey = true;
            this.lboxUsuarios.DragDropSupport = true;
            this.lboxUsuarios.ForeColor = System.Drawing.Color.Black;
            this.lboxUsuarios.Location = new System.Drawing.Point(12, 43);
            this.lboxUsuarios.Name = "lboxUsuarios";
            this.lboxUsuarios.Size = new System.Drawing.Size(308, 83);
            this.lboxUsuarios.TabIndex = 66;
            this.lboxUsuarios.Text = "listBoxAdv1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Location = new System.Drawing.Point(118, 134);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 35);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 104;
            this.btnAceptar.Text = "btnAceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmDialogUsuariosComprometidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 179);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lboxUsuarios);
            this.Controls.Add(this.cboFamilia);
            this.Controls.Add(this.lblFamiliaBuscar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogUsuariosComprometidos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MetroForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblFamiliaBuscar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboFamilia;
        public DevComponents.DotNetBar.ListBoxAdv lboxUsuarios;
    }
}