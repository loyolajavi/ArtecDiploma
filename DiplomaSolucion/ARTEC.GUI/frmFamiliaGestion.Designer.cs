namespace ARTEC.GUI
{
    partial class frmFamiliaGestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFamiliaGestion));
            this.pnlBuscar = new DevComponents.DotNetBar.PanelEx();
            this.cboFamilia = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblFamiliaBuscar = new DevComponents.DotNetBar.LabelX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlPermisos = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblAsignados = new DevComponents.DotNetBar.LabelX();
            this.lblDisponibles = new DevComponents.DotNetBar.LabelX();
            this.btnQuitar = new DevComponents.DotNetBar.ButtonX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.treeDisponibles = new System.Windows.Forms.TreeView();
            this.treeAsignados = new System.Windows.Forms.TreeView();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.btnCrear = new DevComponents.DotNetBar.ButtonX();
            this.treeTodos = new System.Windows.Forms.TreeView();
            this.lblPermisosTodos = new DevComponents.DotNetBar.LabelX();
            this.vldFrmFamiliaGestion = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un nombre");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.pnlBuscar.SuspendLayout();
            this.pnlPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBuscar.Controls.Add(this.cboFamilia);
            this.pnlBuscar.Controls.Add(this.lblFamiliaBuscar);
            this.pnlBuscar.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBuscar.Location = new System.Drawing.Point(169, 12);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(328, 35);
            this.pnlBuscar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBuscar.Style.GradientAngle = 90;
            this.pnlBuscar.TabIndex = 78;
            // 
            // cboFamilia
            // 
            this.cboFamilia.DisplayMember = "Text";
            this.cboFamilia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilia.ForeColor = System.Drawing.Color.Black;
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.ItemHeight = 16;
            this.cboFamilia.Location = new System.Drawing.Point(115, 7);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(202, 22);
            this.cboFamilia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboFamilia.TabIndex = 63;
            this.cboFamilia.SelectionChangeCommitted += new System.EventHandler(this.cboFamilia_SelectionChangeCommitted);
            // 
            // lblFamiliaBuscar
            // 
            // 
            // 
            // 
            this.lblFamiliaBuscar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFamiliaBuscar.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamiliaBuscar.Location = new System.Drawing.Point(9, 9);
            this.lblFamiliaBuscar.Name = "lblFamiliaBuscar";
            this.lblFamiliaBuscar.Size = new System.Drawing.Size(100, 17);
            this.lblFamiliaBuscar.TabIndex = 62;
            this.lblFamiliaBuscar.Text = "lblFamiliaBuscar";
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(178, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 17);
            this.lblNombre.TabIndex = 81;
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
            this.txtNombre.Location = new System.Drawing.Point(284, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(202, 22);
            this.txtNombre.TabIndex = 80;
            this.vldFrmFamiliaGestion.SetValidator1(this.txtNombre, this.requiredFieldValidator1);
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
            this.pnlPermisos.Location = new System.Drawing.Point(12, 107);
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
            this.pnlPermisos.TabIndex = 82;
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
            // treeAsignados
            // 
            this.treeAsignados.Location = new System.Drawing.Point(351, 32);
            this.treeAsignados.Name = "treeAsignados";
            this.treeAsignados.Size = new System.Drawing.Size(209, 190);
            this.treeAsignados.TabIndex = 1;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(586, 396);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 35);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 105;
            this.btnEliminar.Text = "btnEliminar";
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(357, 396);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 35);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 104;
            this.btnModificar.Text = "btnModificar";
            // 
            // btnCrear
            // 
            this.btnCrear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrear.Location = new System.Drawing.Point(242, 396);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(87, 35);
            this.btnCrear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrear.TabIndex = 103;
            this.btnCrear.Text = "btnCrear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // treeTodos
            // 
            this.treeTodos.Location = new System.Drawing.Point(12, 490);
            this.treeTodos.Name = "treeTodos";
            this.treeTodos.Size = new System.Drawing.Size(661, 190);
            this.treeTodos.TabIndex = 7;
            // 
            // lblPermisosTodos
            // 
            // 
            // 
            // 
            this.lblPermisosTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPermisosTodos.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermisosTodos.Location = new System.Drawing.Point(275, 467);
            this.lblPermisosTodos.Name = "lblPermisosTodos";
            this.lblPermisosTodos.Size = new System.Drawing.Size(146, 17);
            this.lblPermisosTodos.TabIndex = 106;
            this.lblPermisosTodos.Text = "Detalle de Permisos";
            // 
            // vldFrmFamiliaGestion
            // 
            this.vldFrmFamiliaGestion.ContainerControl = this.btnCrear;
            this.vldFrmFamiliaGestion.ErrorProvider = this.errorProvider1;
            this.vldFrmFamiliaGestion.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Ingrese un nombre";
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
            // frmFamiliaGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 692);
            this.Controls.Add(this.lblPermisosTodos);
            this.Controls.Add(this.treeTodos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.pnlPermisos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.pnlBuscar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFamiliaGestion";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmFamiliaGestion_Load);
            this.pnlBuscar.ResumeLayout(false);
            this.pnlPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlBuscar;
        private DevComponents.DotNetBar.LabelX lblFamiliaBuscar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboFamilia;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlPermisos;
        private DevComponents.DotNetBar.LabelX lblAsignados;
        private DevComponents.DotNetBar.LabelX lblDisponibles;
        private DevComponents.DotNetBar.ButtonX btnQuitar;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private System.Windows.Forms.TreeView treeDisponibles;
        private System.Windows.Forms.TreeView treeAsignados;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.ButtonX btnCrear;
        private System.Windows.Forms.TreeView treeTodos;
        private DevComponents.DotNetBar.LabelX lblPermisosTodos;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmFamiliaGestion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
    }
}