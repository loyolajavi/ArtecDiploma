namespace ARTEC.GUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pnlBotonLogin = new DevComponents.DotNetBar.PanelEx();
            this.lblSalir = new DevComponents.DotNetBar.LabelX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.pnlPass = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlPassI = new DevComponents.DotNetBar.PanelEx();
            this.pnlNombreUsuario = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNombreUsuario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlNombreUsuarioI = new DevComponents.DotNetBar.PanelEx();
            this.pnlTitulo = new DevComponents.DotNetBar.PanelEx();
            this.pnlBotonLogin.SuspendLayout();
            this.pnlPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlNombreUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonLogin
            // 
            this.pnlBotonLogin.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBotonLogin.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBotonLogin.Controls.Add(this.lblSalir);
            this.pnlBotonLogin.Controls.Add(this.btnLogin);
            this.pnlBotonLogin.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBotonLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotonLogin.Location = new System.Drawing.Point(0, 171);
            this.pnlBotonLogin.Name = "pnlBotonLogin";
            this.pnlBotonLogin.Size = new System.Drawing.Size(382, 53);
            this.pnlBotonLogin.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBotonLogin.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlBotonLogin.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBotonLogin.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBotonLogin.Style.GradientAngle = 90;
            this.pnlBotonLogin.TabIndex = 0;
            // 
            // lblSalir
            // 
            // 
            // 
            // 
            this.lblSalir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.Location = new System.Drawing.Point(354, 31);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(25, 20);
            this.lblSalir.TabIndex = 1;
            this.lblSalir.Text = "Salir";
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(149, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 36);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            // 
            // pnlPass
            // 
            this.pnlPass.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlPass.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlPass.Controls.Add(this.pictureBox2);
            this.pnlPass.Controls.Add(this.txtPass);
            this.pnlPass.Controls.Add(this.pnlPassI);
            this.pnlPass.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlPass.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPass.Location = new System.Drawing.Point(0, 111);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(382, 60);
            this.pnlPass.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlPass.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlPass.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlPass.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlPass.Style.GradientAngle = 90;
            this.pnlPass.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(39, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 32);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
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
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(70, 12);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(278, 35);
            this.txtPass.TabIndex = 17;
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // pnlPassI
            // 
            this.pnlPassI.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlPassI.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlPassI.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlPassI.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPassI.Location = new System.Drawing.Point(0, 0);
            this.pnlPassI.Name = "pnlPassI";
            this.pnlPassI.Size = new System.Drawing.Size(8, 60);
            this.pnlPassI.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlPassI.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlPassI.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlPassI.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlPassI.Style.GradientAngle = 90;
            this.pnlPassI.TabIndex = 8;
            // 
            // pnlNombreUsuario
            // 
            this.pnlNombreUsuario.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlNombreUsuario.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlNombreUsuario.Controls.Add(this.pictureBox1);
            this.pnlNombreUsuario.Controls.Add(this.txtNombreUsuario);
            this.pnlNombreUsuario.Controls.Add(this.pnlNombreUsuarioI);
            this.pnlNombreUsuario.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlNombreUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNombreUsuario.Location = new System.Drawing.Point(0, 51);
            this.pnlNombreUsuario.Name = "pnlNombreUsuario";
            this.pnlNombreUsuario.Size = new System.Drawing.Size(382, 60);
            this.pnlNombreUsuario.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlNombreUsuario.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlNombreUsuario.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlNombreUsuario.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlNombreUsuario.Style.GradientAngle = 90;
            this.pnlNombreUsuario.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(39, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 32);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombreUsuario.Border.Class = "TextBoxBorder";
            this.txtNombreUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombreUsuario.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtNombreUsuario.Location = new System.Drawing.Point(70, 12);
            this.txtNombreUsuario.Multiline = true;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.PreventEnterBeep = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(278, 36);
            this.txtNombreUsuario.TabIndex = 18;
            this.txtNombreUsuario.Enter += new System.EventHandler(this.txtNombreUsuario_Enter);
            this.txtNombreUsuario.Leave += new System.EventHandler(this.txtNombreUsuario_Leave);
            // 
            // pnlNombreUsuarioI
            // 
            this.pnlNombreUsuarioI.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlNombreUsuarioI.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlNombreUsuarioI.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlNombreUsuarioI.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNombreUsuarioI.Location = new System.Drawing.Point(0, 0);
            this.pnlNombreUsuarioI.Name = "pnlNombreUsuarioI";
            this.pnlNombreUsuarioI.Size = new System.Drawing.Size(8, 60);
            this.pnlNombreUsuarioI.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlNombreUsuarioI.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlNombreUsuarioI.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlNombreUsuarioI.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlNombreUsuarioI.Style.GradientAngle = 90;
            this.pnlNombreUsuarioI.TabIndex = 12;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.CanvasColor = System.Drawing.Color.SteelBlue;
            this.pnlTitulo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlTitulo.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTitulo.Font = new System.Drawing.Font("Nyala", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTitulo.Location = new System.Drawing.Point(0, -2);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(382, 53);
            this.pnlTitulo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlTitulo.Style.BackColor1.Color = System.Drawing.Color.SkyBlue;
            this.pnlTitulo.Style.BackColor2.Color = System.Drawing.Color.DodgerBlue;
            this.pnlTitulo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlTitulo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlTitulo.Style.ForeColor.Color = System.Drawing.Color.White;
            this.pnlTitulo.Style.GradientAngle = 90;
            this.pnlTitulo.TabIndex = 16;
            this.pnlTitulo.Text = "Ingrese a su cuenta";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 224);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlNombreUsuario);
            this.Controls.Add(this.pnlPass);
            this.Controls.Add(this.pnlBotonLogin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnlBotonLogin.ResumeLayout(false);
            this.pnlPass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlNombreUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlBotonLogin;
        private DevComponents.DotNetBar.PanelEx pnlPass;
        private DevComponents.DotNetBar.PanelEx pnlPassI;
        private DevComponents.DotNetBar.PanelEx pnlNombreUsuario;
        private DevComponents.DotNetBar.PanelEx pnlNombreUsuarioI;
        private DevComponents.DotNetBar.PanelEx pnlTitulo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombreUsuario;
        private DevComponents.DotNetBar.LabelX lblSalir;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}