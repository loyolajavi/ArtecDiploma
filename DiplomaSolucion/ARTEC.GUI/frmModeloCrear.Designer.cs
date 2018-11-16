namespace ARTEC.GUI
{
    partial class frmModeloCrear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModeloCrear));
            this.btnCrear = new DevComponents.DotNetBar.ButtonX();
            this.lblModelo = new DevComponents.DotNetBar.LabelX();
            this.txtModelo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMarca = new DevComponents.DotNetBar.LabelX();
            this.txtMarca = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vldFrmModeloCrear = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrear.Location = new System.Drawing.Point(91, 81);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 29);
            this.btnCrear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrear.TabIndex = 91;
            this.btnCrear.Text = "btnCrear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lblModelo
            // 
            // 
            // 
            // 
            this.lblModelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblModelo.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(6, 49);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(79, 17);
            this.lblModelo.TabIndex = 89;
            this.lblModelo.Text = "lblModelo";
            // 
            // txtModelo
            // 
            this.txtModelo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtModelo.Border.Class = "TextBoxBorder";
            this.txtModelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtModelo.DisabledBackColor = System.Drawing.Color.White;
            this.txtModelo.ForeColor = System.Drawing.Color.Black;
            this.txtModelo.Location = new System.Drawing.Point(91, 44);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.PreventEnterBeep = true;
            this.txtModelo.Size = new System.Drawing.Size(128, 22);
            this.txtModelo.TabIndex = 90;
            this.vldFrmModeloCrear.SetValidator1(this.txtModelo, this.requiredFieldValidator1);
            // 
            // lblMarca
            // 
            // 
            // 
            // 
            this.lblMarca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMarca.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(6, 17);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(79, 17);
            this.lblMarca.TabIndex = 87;
            this.lblMarca.Text = "lblMarca";
            // 
            // txtMarca
            // 
            this.txtMarca.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMarca.Border.Class = "TextBoxBorder";
            this.txtMarca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMarca.DisabledBackColor = System.Drawing.Color.White;
            this.txtMarca.Enabled = false;
            this.txtMarca.ForeColor = System.Drawing.Color.Black;
            this.txtMarca.Location = new System.Drawing.Point(91, 12);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.PreventEnterBeep = true;
            this.txtMarca.Size = new System.Drawing.Size(128, 22);
            this.txtMarca.TabIndex = 88;
            // 
            // vldFrmModeloCrear
            // 
            this.vldFrmModeloCrear.ContainerControl = this.btnCrear;
            this.vldFrmModeloCrear.ErrorProvider = this.errorProvider1;
            this.vldFrmModeloCrear.Highlighter = this.highlighter1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // frmModeloCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 125);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtMarca);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmModeloCrear";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmModeloCrear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCrear;
        private DevComponents.DotNetBar.LabelX lblModelo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtModelo;
        private DevComponents.DotNetBar.LabelX lblMarca;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMarca;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmModeloCrear;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
    }
}