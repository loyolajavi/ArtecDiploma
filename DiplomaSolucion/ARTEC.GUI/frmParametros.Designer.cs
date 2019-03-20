namespace ARTEC.GUI
{
    partial class frmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            this.lblMail = new DevComponents.DotNetBar.LabelX();
            this.txtMail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPass = new DevComponents.DotNetBar.LabelX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.vldFrmParametros = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtPuerto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHost = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPuerto = new DevComponents.DotNetBar.LabelX();
            this.lblHost = new DevComponents.DotNetBar.LabelX();
            this.lblSSL = new DevComponents.DotNetBar.LabelX();
            this.chkSSL = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMail
            // 
            // 
            // 
            // 
            this.lblMail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMail.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(36, 24);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(81, 17);
            this.lblMail.TabIndex = 56;
            this.lblMail.Text = "lblMail";
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMail.Border.Class = "TextBoxBorder";
            this.txtMail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMail.DisabledBackColor = System.Drawing.Color.White;
            this.txtMail.ForeColor = System.Drawing.Color.Black;
            this.txtMail.Location = new System.Drawing.Point(123, 22);
            this.txtMail.Name = "txtMail";
            this.txtMail.PreventEnterBeep = true;
            this.txtMail.Size = new System.Drawing.Size(121, 22);
            this.txtMail.TabIndex = 55;
            this.vldFrmParametros.SetValidator1(this.txtMail, this.regularExpressionValidator1);
            // 
            // lblPass
            // 
            // 
            // 
            // 
            this.lblPass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPass.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(36, 59);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(81, 17);
            this.lblPass.TabIndex = 58;
            this.lblPass.Text = "lblPass";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.DisabledBackColor = System.Drawing.Color.White;
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(123, 56);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(121, 22);
            this.txtPass.TabIndex = 57;
            this.txtPass.UseSystemPasswordChar = true;
            this.vldFrmParametros.SetValidator1(this.txtPass, this.requiredFieldValidator3);
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(123, 199);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 59;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // vldFrmParametros
            // 
            this.vldFrmParametros.ContainerControl = this;
            this.vldFrmParametros.ErrorProvider = this.errorProvider1;
            this.vldFrmParametros.Highlighter = this.highlighter1;
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator1.ValidationExpression = "^([\\w\\d\\-\\.]+)@{1}(([\\w\\d\\-]{1,67})|([\\w\\d\\-]+\\.[\\w\\d\\-]{1,67}))\\.(([a-zA-Z\\d]{2," +
    "4})(\\.[a-zA-Z\\d]{2})?)$";
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
            // txtPuerto
            // 
            this.txtPuerto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPuerto.Border.Class = "TextBoxBorder";
            this.txtPuerto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPuerto.DisabledBackColor = System.Drawing.Color.White;
            this.txtPuerto.ForeColor = System.Drawing.Color.Black;
            this.txtPuerto.Location = new System.Drawing.Point(123, 91);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.PreventEnterBeep = true;
            this.txtPuerto.Size = new System.Drawing.Size(121, 22);
            this.txtPuerto.TabIndex = 63;
            this.vldFrmParametros.SetValidator1(this.txtPuerto, this.requiredFieldValidator1);
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtHost.Border.Class = "TextBoxBorder";
            this.txtHost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHost.DisabledBackColor = System.Drawing.Color.White;
            this.txtHost.ForeColor = System.Drawing.Color.Black;
            this.txtHost.Location = new System.Drawing.Point(123, 126);
            this.txtHost.Name = "txtHost";
            this.txtHost.PreventEnterBeep = true;
            this.txtHost.Size = new System.Drawing.Size(121, 22);
            this.txtHost.TabIndex = 64;
            this.vldFrmParametros.SetValidator1(this.txtHost, this.requiredFieldValidator2);
            // 
            // lblPuerto
            // 
            // 
            // 
            // 
            this.lblPuerto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPuerto.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto.Location = new System.Drawing.Point(36, 93);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(81, 17);
            this.lblPuerto.TabIndex = 60;
            this.lblPuerto.Text = "lblPuerto";
            // 
            // lblHost
            // 
            // 
            // 
            // 
            this.lblHost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblHost.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(36, 131);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(81, 17);
            this.lblHost.TabIndex = 61;
            this.lblHost.Text = "lblHost";
            // 
            // lblSSL
            // 
            // 
            // 
            // 
            this.lblSSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSSL.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSL.Location = new System.Drawing.Point(36, 165);
            this.lblSSL.Name = "lblSSL";
            this.lblSSL.Size = new System.Drawing.Size(81, 17);
            this.lblSSL.TabIndex = 62;
            this.lblSSL.Text = "lblSSL";
            // 
            // chkSSL
            // 
            // 
            // 
            // 
            this.chkSSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSSL.Location = new System.Drawing.Point(123, 159);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(100, 23);
            this.chkSSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSSL.TabIndex = 65;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // frmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 228);
            this.Controls.Add(this.chkSSL);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.lblSSL);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblPuerto);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtMail);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmParametros";
            this.Text = "MetroForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblMail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMail;
        private DevComponents.DotNetBar.LabelX lblPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmParametros;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHost;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPuerto;
        private DevComponents.DotNetBar.LabelX lblSSL;
        private DevComponents.DotNetBar.LabelX lblHost;
        private DevComponents.DotNetBar.LabelX lblPuerto;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSSL;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
    }
}