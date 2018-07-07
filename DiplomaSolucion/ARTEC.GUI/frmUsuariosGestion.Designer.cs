namespace ARTEC.GUI
{
    partial class frmUsuariosGestion
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
            this.treeDisponibles = new System.Windows.Forms.TreeView();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.btnQuitar = new DevComponents.DotNetBar.ButtonX();
            this.lblDisponibles = new DevComponents.DotNetBar.LabelX();
            this.lblAsignados = new DevComponents.DotNetBar.LabelX();
            this.btnCrearUsuario = new DevComponents.DotNetBar.ButtonX();
            this.pnlPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeAsignados
            // 
            this.treeAsignados.Location = new System.Drawing.Point(351, 32);
            this.treeAsignados.Name = "treeAsignados";
            this.treeAsignados.Size = new System.Drawing.Size(209, 190);
            this.treeAsignados.TabIndex = 1;
            this.treeAsignados.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePermisos_AfterSelect);
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
            this.txtNomUs.Enabled = false;
            this.txtNomUs.ForeColor = System.Drawing.Color.Black;
            this.txtNomUs.Location = new System.Drawing.Point(109, 7);
            this.txtNomUs.Name = "txtNomUs";
            this.txtNomUs.PreventEnterBeep = true;
            this.txtNomUs.Size = new System.Drawing.Size(285, 22);
            this.txtNomUs.TabIndex = 63;
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
            this.txtPass.Enabled = false;
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(109, 41);
            this.txtPass.Name = "txtPass";
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(285, 22);
            this.txtPass.TabIndex = 65;
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
            this.txtNombre.Enabled = false;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(109, 75);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(285, 22);
            this.txtNombre.TabIndex = 67;
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
            this.txtApellido.Enabled = false;
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(109, 109);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PreventEnterBeep = true;
            this.txtApellido.Size = new System.Drawing.Size(285, 22);
            this.txtApellido.TabIndex = 69;
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
            this.txtMail.Enabled = false;
            this.txtMail.ForeColor = System.Drawing.Color.Black;
            this.txtMail.Location = new System.Drawing.Point(109, 143);
            this.txtMail.Name = "txtMail";
            this.txtMail.PreventEnterBeep = true;
            this.txtMail.Size = new System.Drawing.Size(285, 22);
            this.txtMail.TabIndex = 71;
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
            // treeDisponibles
            // 
            this.treeDisponibles.Location = new System.Drawing.Point(15, 32);
            this.treeDisponibles.Name = "treeDisponibles";
            this.treeDisponibles.Size = new System.Drawing.Size(209, 190);
            this.treeDisponibles.TabIndex = 2;
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
            // 
            // frmUsuariosGestion
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
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmUsuariosGestion";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmUsuariosGestion_Load);
            this.pnlPermisos.ResumeLayout(false);
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
    }
}