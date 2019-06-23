using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class frmUsuariosModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuariosModificar));
            this.treeAsignados = new System.Windows.Forms.TreeView();
            this.lblNomUsBuscar = new DevComponents.DotNetBar.LabelX();
            this.txtNomUsBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
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
            this.btnModifUsuario = new DevComponents.DotNetBar.ButtonX();
            this.pnlBuscar = new DevComponents.DotNetBar.PanelEx();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.lblNomUs = new DevComponents.DotNetBar.LabelX();
            this.txtNomUs = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vldNomUs = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese una contraseņa");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Nombre");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Apellido");
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Mail");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Nombre de Usuario");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.btnCrearUsuario = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminarUsuario = new DevComponents.DotNetBar.ButtonX();
            this.lblBaja = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.btnReactivarUs = new DevComponents.DotNetBar.ButtonX();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pnlPermisos.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
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
            // lblNomUsBuscar
            // 
            // 
            // 
            // 
            this.lblNomUsBuscar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNomUsBuscar.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUsBuscar.Location = new System.Drawing.Point(9, 9);
            this.lblNomUsBuscar.Name = "lblNomUsBuscar";
            this.lblNomUsBuscar.Size = new System.Drawing.Size(91, 17);
            this.lblNomUsBuscar.TabIndex = 62;
            this.lblNomUsBuscar.Text = "lblNomUs";
            // 
            // txtNomUsBuscar
            // 
            this.txtNomUsBuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNomUsBuscar.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtNomUsBuscar.Border.BorderBottomWidth = 2;
            this.txtNomUsBuscar.Border.BorderColor = System.Drawing.Color.Black;
            this.txtNomUsBuscar.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtNomUsBuscar.Border.BorderLeftWidth = 2;
            this.txtNomUsBuscar.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtNomUsBuscar.Border.BorderRightWidth = 2;
            this.txtNomUsBuscar.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtNomUsBuscar.Border.BorderTopWidth = 2;
            this.txtNomUsBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNomUsBuscar.DisabledBackColor = System.Drawing.Color.White;
            this.txtNomUsBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtNomUsBuscar.Location = new System.Drawing.Point(106, 7);
            this.txtNomUsBuscar.Multiline = true;
            this.txtNomUsBuscar.Name = "txtNomUsBuscar";
            this.txtNomUsBuscar.PreventEnterBeep = true;
            this.txtNomUsBuscar.Size = new System.Drawing.Size(227, 20);
            this.txtNomUsBuscar.TabIndex = 0;
            // 
            // lblPass
            // 
            // 
            // 
            // 
            this.lblPass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPass.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(12, 96);
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
            this.txtPass.Location = new System.Drawing.Point(109, 91);
            this.txtPass.Name = "txtPass";
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(227, 22);
            this.txtPass.TabIndex = 1;
            this.vldNomUs.SetValidator1(this.txtPass, this.requiredFieldValidator2);
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 130);
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
            this.txtNombre.Location = new System.Drawing.Point(109, 125);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(227, 22);
            this.txtNombre.TabIndex = 2;
            this.vldNomUs.SetValidator1(this.txtNombre, this.requiredFieldValidator3);
            // 
            // lblApellido
            // 
            // 
            // 
            // 
            this.lblApellido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblApellido.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(12, 164);
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
            this.txtApellido.Location = new System.Drawing.Point(109, 159);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PreventEnterBeep = true;
            this.txtApellido.Size = new System.Drawing.Size(227, 22);
            this.txtApellido.TabIndex = 3;
            this.vldNomUs.SetValidator1(this.txtApellido, this.requiredFieldValidator4);
            // 
            // lblMail
            // 
            // 
            // 
            // 
            this.lblMail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMail.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(12, 198);
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
            this.txtMail.Location = new System.Drawing.Point(109, 193);
            this.txtMail.Name = "txtMail";
            this.txtMail.PreventEnterBeep = true;
            this.txtMail.Size = new System.Drawing.Size(227, 22);
            this.txtMail.TabIndex = 4;
            this.vldNomUs.SetValidator1(this.txtMail, this.requiredFieldValidator5);
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
            this.pnlPermisos.Location = new System.Drawing.Point(3, 229);
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
            // btnModifUsuario
            // 
            this.btnModifUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifUsuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifUsuario.Location = new System.Drawing.Point(289, 511);
            this.btnModifUsuario.Name = "btnModifUsuario";
            this.btnModifUsuario.Size = new System.Drawing.Size(88, 30);
            this.btnModifUsuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModifUsuario.TabIndex = 73;
            this.btnModifUsuario.Tag = ((object)(resources.GetObject("btnModifUsuario.Tag")));
            this.btnModifUsuario.Text = "btnModifUsuario";
            this.btnModifUsuario.Click += new System.EventHandler(this.btnModifUsuario_Click);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.lblNomUsBuscar);
            this.pnlBuscar.Controls.Add(this.txtNomUsBuscar);
            this.pnlBuscar.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBuscar.Location = new System.Drawing.Point(3, 3);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(422, 35);
            this.pnlBuscar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBuscar.Style.GradientAngle = 90;
            this.pnlBuscar.TabIndex = 74;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(339, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 78;
            this.btnBuscar.Tag = ((object)(resources.GetObject("btnBuscar.Tag")));
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNomUs
            // 
            // 
            // 
            // 
            this.lblNomUs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNomUs.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUs.Location = new System.Drawing.Point(12, 61);
            this.lblNomUs.Name = "lblNomUs";
            this.lblNomUs.Size = new System.Drawing.Size(91, 17);
            this.lblNomUs.TabIndex = 79;
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
            this.txtNomUs.Location = new System.Drawing.Point(109, 56);
            this.txtNomUs.Name = "txtNomUs";
            this.txtNomUs.PreventEnterBeep = true;
            this.txtNomUs.Size = new System.Drawing.Size(227, 22);
            this.txtNomUs.TabIndex = 78;
            this.vldNomUs.SetValidator1(this.txtNomUs, this.requiredFieldValidator1);
            // 
            // vldNomUs
            // 
            this.vldNomUs.ContainerControl = this.btnModifUsuario;
            this.vldNomUs.ErrorProvider = this.errorProvider1;
            this.vldNomUs.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Ingrese una contraseņa";
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
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Ingrese un Nombre de Usuario";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearUsuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearUsuario.Location = new System.Drawing.Point(499, 3);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(87, 35);
            this.btnCrearUsuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearUsuario.TabIndex = 83;
            this.btnCrearUsuario.Tag = ((object)(resources.GetObject("btnCrearUsuario.Tag")));
            this.btnCrearUsuario.Text = "btnCrearUsuario";
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarUsuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(499, 96);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(87, 30);
            this.btnEliminarUsuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarUsuario.TabIndex = 84;
            this.btnEliminarUsuario.Tag = ((object)(resources.GetObject("btnEliminarUsuario.Tag")));
            this.btnEliminarUsuario.Text = "btnEliminarUsuario";
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // lblBaja
            // 
            // 
            // 
            // 
            this.lblBaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaja.Location = new System.Drawing.Point(342, 56);
            this.lblBaja.Name = "lblBaja";
            this.lblBaja.Size = new System.Drawing.Size(108, 22);
            this.lblBaja.TabIndex = 89;
            this.lblBaja.Text = "<b><font size=\"+4\"><font color=\"#B02B2C\">Dado de baja</font></font></b>";
            this.lblBaja.Visible = false;
            // 
            // btnReactivarUs
            // 
            this.btnReactivarUs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReactivarUs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReactivarUs.Enabled = false;
            this.btnReactivarUs.Location = new System.Drawing.Point(499, 49);
            this.btnReactivarUs.Name = "btnReactivarUs";
            this.btnReactivarUs.Size = new System.Drawing.Size(87, 35);
            this.btnReactivarUs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReactivarUs.TabIndex = 90;
            this.btnReactivarUs.Tag = ((object)(resources.GetObject("btnReactivarUs.Tag")));
            this.btnReactivarUs.Text = "btnReactivarUs";
            this.btnReactivarUs.Click += new System.EventHandler(this.btnReactivarUs_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "Artec - Manual de Ayuda.chm";
            // 
            // frmUsuariosModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 552);
            this.Controls.Add(this.btnReactivarUs);
            this.Controls.Add(this.lblBaja);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.lblNomUs);
            this.Controls.Add(this.txtNomUs);
            this.Controls.Add(this.btnModifUsuario);
            this.Controls.Add(this.pnlPermisos);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.pnlBuscar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this, "Usuarios");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "frmUsuariosModificar";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmUsuariosGestion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuariosModificar_KeyDown);
            this.pnlPermisos.ResumeLayout(false);
            this.pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeAsignados;
        private DevComponents.DotNetBar.LabelX lblNomUsBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNomUsBuscar;
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
        private DevComponents.DotNetBar.ButtonX btnModifUsuario;
        private DevComponents.DotNetBar.PanelEx pnlBuscar;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.LabelX lblNomUs;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNomUs;
        private DevComponents.DotNetBar.Validator.SuperValidator vldNomUs;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator5;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.ButtonX btnEliminarUsuario;
        private DevComponents.DotNetBar.ButtonX btnCrearUsuario;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lblBaja;
        private DevComponents.DotNetBar.ButtonX btnReactivarUs;
        internal System.Windows.Forms.HelpProvider helpProvider1;
    }
}