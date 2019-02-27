namespace BDConfigXML
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnGenerarXML = new DevComponents.DotNetBar.ButtonX();
            this.txtServidor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUsuario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblServidor = new DevComponents.DotNetBar.LabelX();
            this.lblBase = new DevComponents.DotNetBar.LabelX();
            this.lblUsuario = new DevComponents.DotNetBar.LabelX();
            this.lblPassword = new DevComponents.DotNetBar.LabelX();
            this.txtDestino = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDestino = new DevComponents.DotNetBar.LabelX();
            this.btnExaminar = new DevComponents.DotNetBar.ButtonX();
            this.validador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarXML
            // 
            this.btnGenerarXML.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerarXML.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerarXML.Location = new System.Drawing.Point(210, 155);
            this.btnGenerarXML.Name = "btnGenerarXML";
            this.btnGenerarXML.Size = new System.Drawing.Size(83, 29);
            this.btnGenerarXML.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerarXML.TabIndex = 0;
            this.btnGenerarXML.Text = "btnGenerarXML";
            this.btnGenerarXML.Click += new System.EventHandler(this.btnGenerarXML_Click);
            // 
            // txtServidor
            // 
            // 
            // 
            // 
            this.txtServidor.Border.Class = "TextBoxBorder";
            this.txtServidor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServidor.Location = new System.Drawing.Point(114, 18);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.PreventEnterBeep = true;
            this.txtServidor.Size = new System.Drawing.Size(304, 20);
            this.txtServidor.TabIndex = 1;
            this.validador.SetValidator1(this.txtServidor, this.requiredFieldValidator4);
            // 
            // txtBase
            // 
            // 
            // 
            // 
            this.txtBase.Border.Class = "TextBoxBorder";
            this.txtBase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBase.Location = new System.Drawing.Point(114, 44);
            this.txtBase.Name = "txtBase";
            this.txtBase.PreventEnterBeep = true;
            this.txtBase.Size = new System.Drawing.Size(304, 20);
            this.txtBase.TabIndex = 2;
            this.validador.SetValidator1(this.txtBase, this.requiredFieldValidator1);
            // 
            // txtUsuario
            // 
            // 
            // 
            // 
            this.txtUsuario.Border.Class = "TextBoxBorder";
            this.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsuario.Location = new System.Drawing.Point(114, 70);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PreventEnterBeep = true;
            this.txtUsuario.Size = new System.Drawing.Size(304, 20);
            this.txtUsuario.TabIndex = 3;
            this.validador.SetValidator1(this.txtUsuario, this.requiredFieldValidator2);
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.Location = new System.Drawing.Point(114, 95);
            this.txtPass.Name = "txtPass";
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(304, 20);
            this.txtPass.TabIndex = 4;
            this.validador.SetValidator1(this.txtPass, this.requiredFieldValidator3);
            // 
            // lblServidor
            // 
            // 
            // 
            // 
            this.lblServidor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblServidor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidor.Location = new System.Drawing.Point(13, 18);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(75, 20);
            this.lblServidor.TabIndex = 5;
            this.lblServidor.Text = "Servidor";
            // 
            // lblBase
            // 
            // 
            // 
            // 
            this.lblBase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBase.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.Location = new System.Drawing.Point(13, 41);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(96, 20);
            this.lblBase.TabIndex = 6;
            this.lblBase.Text = "Base de datos";
            // 
            // lblUsuario
            // 
            // 
            // 
            // 
            this.lblUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(13, 67);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(75, 20);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblPassword
            // 
            // 
            // 
            // 
            this.lblPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(13, 95);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 20);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // txtDestino
            // 
            // 
            // 
            // 
            this.txtDestino.Border.Class = "TextBoxBorder";
            this.txtDestino.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDestino.Location = new System.Drawing.Point(114, 121);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.PreventEnterBeep = true;
            this.txtDestino.Size = new System.Drawing.Size(304, 20);
            this.txtDestino.TabIndex = 9;
            this.validador.SetValidator1(this.txtDestino, this.requiredFieldValidator5);
            // 
            // lblDestino
            // 
            // 
            // 
            // 
            this.lblDestino.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.Location = new System.Drawing.Point(13, 121);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(75, 20);
            this.lblDestino.TabIndex = 10;
            this.lblDestino.Text = "Destino";
            // 
            // btnExaminar
            // 
            this.btnExaminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExaminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExaminar.Location = new System.Drawing.Point(424, 121);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(67, 20);
            this.btnExaminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExaminar.TabIndex = 11;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // validador
            // 
            this.validador.ContainerControl = this.btnGenerarXML;
            this.validador.ErrorProvider = this.errorProvider1;
            this.validador.Highlighter = this.highlighter1;
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
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(498, 189);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.btnGenerarXML);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnGenerarXML;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServidor;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBase;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUsuario;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.LabelX lblServidor;
        private DevComponents.DotNetBar.LabelX lblBase;
        private DevComponents.DotNetBar.LabelX lblUsuario;
        private DevComponents.DotNetBar.LabelX lblPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDestino;
        private DevComponents.DotNetBar.LabelX lblDestino;
        private DevComponents.DotNetBar.ButtonX btnExaminar;
        private DevComponents.DotNetBar.Validator.SuperValidator validador;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator5;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
    }
}