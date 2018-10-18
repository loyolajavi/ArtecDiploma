using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class frmUsuariosCrear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuariosCrear));
            this.treeAsignados = new System.Windows.Forms.TreeView();
            this.lblNomUs = new DevComponents.DotNetBar.LabelX();
            this.txtNomUs = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPass = new DevComponents.DotNetBar.LabelX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblApellido = new DevComponents.DotNetBar.LabelX();
            this.txtApellido = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMail = new DevComponents.DotNetBar.LabelX();
            this.txtMail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlPermisos = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblAsignados = new DevComponents.DotNetBar.LabelX();
            this.lblDisponibles = new DevComponents.DotNetBar.LabelX();
            this.btnQuitar = new DevComponents.DotNetBar.ButtonX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.treeDisponibles = new System.Windows.Forms.TreeView();
            this.btnCrearUsuario = new DevComponents.DotNetBar.ButtonX();
            this.vldfrmUsuarioCrear = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Nombre de Usuario");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese una contraseña");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Nombre");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Apellido");
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Mail");
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator2 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator3 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator4 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator5 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.pnlPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeAsignados
            // 
            this.treeAsignados.Location = new System.Drawing.Point(351, 32);
            this.treeAsignados.Name = "treeAsignados";
            this.treeAsignados.Size = new System.Drawing.Size(209, 190);
            this.treeAsignados.TabIndex = 1;
            // 
            // lblNomUs
            // 
            // 
            // 
            // 
            this.lblNomUs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNomUs.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUs.Location = new System.Drawing.Point(12, 12);
            this.lblNomUs.Name = "lblNomUs";
            this.lblNomUs.Size = new System.Drawing.Size(91, 17);
            this.lblNomUs.TabIndex = 62;
            this.lblNomUs.Text = "lblNomUs";
            // 
            // txtNomUs
            // 
            this.txtNomUs.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNomUs.Border.Class = "TextBoxBorder";
            this.txtNomUs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNomUs.DisabledBackColor = System.Drawing.Color.White;
            this.txtNomUs.ForeColor = System.Drawing.Color.Black;
            this.txtNomUs.Location = new System.Drawing.Point(109, 7);
            this.txtNomUs.Name = "txtNomUs";
            this.txtNomUs.PreventEnterBeep = true;
            this.txtNomUs.Size = new System.Drawing.Size(285, 22);
            this.txtNomUs.TabIndex = 63;
            this.vldfrmUsuarioCrear.SetValidator1(this.txtNomUs, this.requiredFieldValidator1);
            this.vldfrmUsuarioCrear.SetValidator2(this.txtNomUs, this.regularExpressionValidator1);
            // 
            // lblPass
            // 
            // 
            // 
            // 
            this.lblPass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPass.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(12, 46);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(91, 17);
            this.lblPass.TabIndex = 64;
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
            this.txtPass.Location = new System.Drawing.Point(109, 41);
            this.txtPass.Name = "txtPass";
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(285, 22);
            this.txtPass.TabIndex = 65;
            this.vldfrmUsuarioCrear.SetValidator1(this.txtPass, this.requiredFieldValidator2);
            this.vldfrmUsuarioCrear.SetValidator2(this.txtPass, this.regularExpressionValidator2);
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 17);
            this.lblNombre.TabIndex = 66;
            this.lblNombre.Text = "lblNombre";
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
            this.txtNombre.Location = new System.Drawing.Point(109, 75);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(285, 22);
            this.txtNombre.TabIndex = 67;
            this.vldfrmUsuarioCrear.SetValidator1(this.txtNombre, this.requiredFieldValidator3);
            this.vldfrmUsuarioCrear.SetValidator2(this.txtNombre, this.regularExpressionValidator3);
            // 
            // lblApellido
            // 
            // 
            // 
            // 
            this.lblApellido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblApellido.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(12, 114);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(91, 17);
            this.lblApellido.TabIndex = 68;
            this.lblApellido.Text = "lblApellido";
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
            this.txtApellido.Location = new System.Drawing.Point(109, 109);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PreventEnterBeep = true;
            this.txtApellido.Size = new System.Drawing.Size(285, 22);
            this.txtApellido.TabIndex = 69;
            this.vldfrmUsuarioCrear.SetValidator1(this.txtApellido, this.requiredFieldValidator4);
            this.vldfrmUsuarioCrear.SetValidator2(this.txtApellido, this.regularExpressionValidator4);
            // 
            // lblMail
            // 
            // 
            // 
            // 
            this.lblMail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMail.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(12, 148);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(91, 17);
            this.lblMail.TabIndex = 70;
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
            this.txtMail.Location = new System.Drawing.Point(109, 143);
            this.txtMail.Name = "txtMail";
            this.txtMail.PreventEnterBeep = true;
            this.txtMail.Size = new System.Drawing.Size(285, 22);
            this.txtMail.TabIndex = 71;
            this.vldfrmUsuarioCrear.SetValidator1(this.txtMail, this.requiredFieldValidator5);
            this.vldfrmUsuarioCrear.SetValidator2(this.txtMail, this.regularExpressionValidator5);
            // 
            // pnlPermisos
            // 
            this.pnlPermisos.BackColor = System.Drawing.Color.White;
            this.pnlPermisos.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlPermisos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlPermisos.Controls.Add(this.lblAsignados);
            this.pnlPermisos.Controls.Add(this.lblDisponibles);
            this.pnlPermisos.Controls.Add(this.btnQuitar);
            this.pnlPermisos.Controls.Add(this.btnAgregar);
            this.pnlPermisos.Controls.Add(this.treeDisponibles);
            this.pnlPermisos.Controls.Add(this.treeAsignados);
            this.pnlPermisos.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlPermisos.Location = new System.Drawing.Point(3, 179);
            this.pnlPermisos.Name = "pnlPermisos";
            this.pnlPermisos.Size = new System.Drawing.Size(661, 263);
            // 
            // 
            // 
            this.pnlPermisos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlPermisos.Style.BackColorGradientAngle = 90;
            this.pnlPermisos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlPermisos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlPermisos.Style.BorderBottomWidth = 1;
            this.pnlPermisos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlPermisos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlPermisos.Style.BorderLeftWidth = 1;
            this.pnlPermisos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlPermisos.Style.BorderRightWidth = 1;
            this.pnlPermisos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlPermisos.Style.BorderTopWidth = 1;
            this.pnlPermisos.Style.CornerDiameter = 4;
            this.pnlPermisos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlPermisos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlPermisos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlPermisos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlPermisos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlPermisos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlPermisos.TabIndex = 72;
            this.pnlPermisos.Text = "pnlPermisos";
            // 
            // lblAsignados
            // 
            // 
            // 
            // 
            this.lblAsignados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAsignados.Location = new System.Drawing.Point(420, 3);
            this.lblAsignados.Name = "lblAsignados";
            this.lblAsignados.Size = new System.Drawing.Size(75, 23);
            this.lblAsignados.TabIndex = 6;
            this.lblAsignados.Text = "lblAsignados";
            // 
            // lblDisponibles
            // 
            // 
            // 
            // 
            this.lblDisponibles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDisponibles.Location = new System.Drawing.Point(80, 3);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(75, 23);
            this.lblDisponibles.TabIndex = 5;
            this.lblDisponibles.Text = "lblDisponibles";
            // 
            // btnQuitar
            // 
            this.btnQuitar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuitar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuitar.Location = new System.Drawing.Point(566, 100);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "btnQuitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(230, 100);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "btnAgregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // treeDisponibles
            // 
            this.treeDisponibles.Location = new System.Drawing.Point(15, 32);
            this.treeDisponibles.Name = "treeDisponibles";
            this.treeDisponibles.Size = new System.Drawing.Size(209, 190);
            this.treeDisponibles.TabIndex = 2;
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearUsuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearUsuario.Location = new System.Drawing.Point(289, 461);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(88, 30);
            this.btnCrearUsuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearUsuario.TabIndex = 73;
            this.btnCrearUsuario.Text = "btnCrearUsuario";

            Dictionary<string, string[]> dicbtnCrear = new Dictionary<string, string[]>();
            string[] PerbtnCrear = { "Usuario Crear" };
            dicbtnCrear.Add("Permisos", PerbtnCrear);
            string[] IdiomabtnCrear = { "Crear" };
            dicbtnCrear.Add("Idioma", IdiomabtnCrear);
            this.btnCrearUsuario.Tag = dicbtnCrear;

            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // vldfrmUsuarioCrear
            // 
            this.vldfrmUsuarioCrear.ContainerControl = this.btnCrearUsuario;
            this.vldfrmUsuarioCrear.ErrorProvider = this.errorProvider1;
            this.vldfrmUsuarioCrear.Highlighter = this.highlighter1;
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
            this.requiredFieldValidator1.ErrorMessage = "Ingrese un Nombre de Usuario";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Ingrese una contraseña";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Ingrese un Nombre";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "Ingrese un Apellido";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ErrorMessage = "Ingrese un Mail";
            this.requiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.ErrorMessage = "Deben ser únicamente letras";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator1.ValidationExpression = "^[a-zA-Z]+$";
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.ErrorMessage = "La contraseña debe contener mínimo 6 caracteres minúsculas, mayúsculas y números";
            this.regularExpressionValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator2.ValidationExpression = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{6,}$";
            // 
            // regularExpressionValidator3
            // 
            this.regularExpressionValidator3.ErrorMessage = "Deben ser letras únicamente";
            this.regularExpressionValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator3.ValidationExpression = "^[a-zA-Z]+$";
            // 
            // regularExpressionValidator4
            // 
            this.regularExpressionValidator4.ErrorMessage = "Deben ser letras únicamente";
            this.regularExpressionValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator4.ValidationExpression = "^[a-zA-Z]+$";
            // 
            // regularExpressionValidator5
            // 
            this.regularExpressionValidator5.ErrorMessage = "El formato debe ser ejemplo@dominio.com.ar";
            this.regularExpressionValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator5.ValidationExpression = "^([\\w\\d\\-\\.]+)@{1}(([\\w\\d\\-]{1,67})|([\\w\\d\\-]+\\.[\\w\\d\\-]{1,67}))\\.(([a-zA-Z\\d]{2," +
    "4})(\\.[a-zA-Z\\d]{2})?)$";
            // 
            // frmUsuariosCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 500);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.pnlPermisos);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblNomUs);
            this.Controls.Add(this.txtNomUs);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmUsuariosCrear";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmUsuariosCrear_Load);
            this.pnlPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeAsignados;
        private DevComponents.DotNetBar.LabelX lblNomUs;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNomUs;
        private DevComponents.DotNetBar.LabelX lblPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX lblApellido;
        private DevComponents.DotNetBar.Controls.TextBoxX txtApellido;
        private DevComponents.DotNetBar.LabelX lblMail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMail;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlPermisos;
        private DevComponents.DotNetBar.ButtonX btnQuitar;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private System.Windows.Forms.TreeView treeDisponibles;
        private DevComponents.DotNetBar.LabelX lblAsignados;
        private DevComponents.DotNetBar.LabelX lblDisponibles;
        private DevComponents.DotNetBar.ButtonX btnCrearUsuario;
        private DevComponents.DotNetBar.Validator.SuperValidator vldfrmUsuarioCrear;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator5;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator5;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator4;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator3;
    }
}