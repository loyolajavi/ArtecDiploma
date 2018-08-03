namespace ARTEC.GUI
{
    partial class frmCategoriaGestion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBuscar = new DevComponents.DotNetBar.PanelEx();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.lblCategoriaBuscar = new DevComponents.DotNetBar.LabelX();
            this.txtCategoriaBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCategoria = new DevComponents.DotNetBar.LabelX();
            this.txtCategoria = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTipo = new DevComponents.DotNetBar.LabelX();
            this.cboTipo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboProveedor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblProveedor = new DevComponents.DotNetBar.LabelX();
            this.GrillaProveedores = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnCrearCategoria = new DevComponents.DotNetBar.ButtonX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.btnLimpiar = new DevComponents.DotNetBar.ButtonX();
            this.pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.lblCategoriaBuscar);
            this.pnlBuscar.Controls.Add(this.txtCategoriaBuscar);
            this.pnlBuscar.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBuscar.Location = new System.Drawing.Point(12, 12);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(422, 35);
            this.pnlBuscar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBuscar.Style.GradientAngle = 90;
            this.pnlBuscar.TabIndex = 78;
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
            this.btnBuscar.Text = "btnBuscar";
            // 
            // lblCategoriaBuscar
            // 
            // 
            // 
            // 
            this.lblCategoriaBuscar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCategoriaBuscar.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriaBuscar.Location = new System.Drawing.Point(9, 9);
            this.lblCategoriaBuscar.Name = "lblCategoriaBuscar";
            this.lblCategoriaBuscar.Size = new System.Drawing.Size(91, 17);
            this.lblCategoriaBuscar.TabIndex = 62;
            this.lblCategoriaBuscar.Text = "lblCategoria";
            // 
            // txtCategoriaBuscar
            // 
            this.txtCategoriaBuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCategoriaBuscar.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtCategoriaBuscar.Border.BorderBottomWidth = 2;
            this.txtCategoriaBuscar.Border.BorderColor = System.Drawing.Color.Black;
            this.txtCategoriaBuscar.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtCategoriaBuscar.Border.BorderLeftWidth = 2;
            this.txtCategoriaBuscar.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtCategoriaBuscar.Border.BorderRightWidth = 2;
            this.txtCategoriaBuscar.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtCategoriaBuscar.Border.BorderTopWidth = 2;
            this.txtCategoriaBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCategoriaBuscar.DisabledBackColor = System.Drawing.Color.White;
            this.txtCategoriaBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtCategoriaBuscar.Location = new System.Drawing.Point(106, 7);
            this.txtCategoriaBuscar.Multiline = true;
            this.txtCategoriaBuscar.Name = "txtCategoriaBuscar";
            this.txtCategoriaBuscar.PreventEnterBeep = true;
            this.txtCategoriaBuscar.Size = new System.Drawing.Size(227, 20);
            this.txtCategoriaBuscar.TabIndex = 0;
            // 
            // lblCategoria
            // 
            // 
            // 
            // 
            this.lblCategoria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCategoria.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(21, 72);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(91, 17);
            this.lblCategoria.TabIndex = 81;
            this.lblCategoria.Text = "lblCategoria";
            // 
            // txtCategoria
            // 
            this.txtCategoria.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCategoria.Border.Class = "TextBoxBorder";
            this.txtCategoria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCategoria.DisabledBackColor = System.Drawing.Color.White;
            this.txtCategoria.ForeColor = System.Drawing.Color.Black;
            this.txtCategoria.Location = new System.Drawing.Point(118, 67);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.PreventEnterBeep = true;
            this.txtCategoria.Size = new System.Drawing.Size(227, 22);
            this.txtCategoria.TabIndex = 80;
            // 
            // lblTipo
            // 
            // 
            // 
            // 
            this.lblTipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipo.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(21, 107);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(91, 17);
            this.lblTipo.TabIndex = 82;
            this.lblTipo.Text = "lblTipo";
            // 
            // cboTipo
            // 
            this.cboTipo.DisplayMember = "Text";
            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.ForeColor = System.Drawing.Color.Black;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.ItemHeight = 16;
            this.cboTipo.Location = new System.Drawing.Point(118, 102);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 22);
            this.cboTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipo.TabIndex = 83;
            // 
            // cboProveedor
            // 
            this.cboProveedor.DisplayMember = "Text";
            this.cboProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProveedor.ForeColor = System.Drawing.Color.Black;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ItemHeight = 16;
            this.cboProveedor.Location = new System.Drawing.Point(118, 136);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(121, 22);
            this.cboProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProveedor.TabIndex = 88;
            // 
            // lblProveedor
            // 
            // 
            // 
            // 
            this.lblProveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProveedor.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(21, 141);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(91, 17);
            this.lblProveedor.TabIndex = 87;
            this.lblProveedor.Text = "lblProveedor";
            // 
            // GrillaProveedores
            // 
            this.GrillaProveedores.AllowUserToAddRows = false;
            this.GrillaProveedores.AllowUserToDeleteRows = false;
            this.GrillaProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaProveedores.BackgroundColor = System.Drawing.Color.White;
            this.GrillaProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaProveedores.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaProveedores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaProveedores.Location = new System.Drawing.Point(21, 174);
            this.GrillaProveedores.Name = "GrillaProveedores";
            this.GrillaProveedores.ReadOnly = true;
            this.GrillaProveedores.Size = new System.Drawing.Size(324, 186);
            this.GrillaProveedores.TabIndex = 89;
            // 
            // btnCrearCategoria
            // 
            this.btnCrearCategoria.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearCategoria.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearCategoria.Location = new System.Drawing.Point(98, 387);
            this.btnCrearCategoria.Name = "btnCrearCategoria";
            this.btnCrearCategoria.Size = new System.Drawing.Size(87, 35);
            this.btnCrearCategoria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearCategoria.TabIndex = 90;
            this.btnCrearCategoria.Text = "btnCrear";
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(202, 387);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 35);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 91;
            this.btnModificar.Text = "btnModificar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Location = new System.Drawing.Point(304, 387);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 35);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 92;
            this.btnEliminar.Text = "btnEliminar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLimpiar.Location = new System.Drawing.Point(351, 67);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 22);
            this.btnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLimpiar.TabIndex = 93;
            this.btnLimpiar.Text = "btnLimpiar";
            // 
            // frmCategoriaGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 437);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrearCategoria);
            this.Controls.Add(this.GrillaProveedores);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.pnlBuscar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCategoriaGestion";
            this.Text = "MetroForm";
            this.pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlBuscar;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.LabelX lblCategoriaBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCategoriaBuscar;
        private DevComponents.DotNetBar.LabelX lblCategoria;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCategoria;
        private DevComponents.DotNetBar.LabelX lblTipo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProveedor;
        private DevComponents.DotNetBar.LabelX lblProveedor;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaProveedores;
        private DevComponents.DotNetBar.ButtonX btnCrearCategoria;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private DevComponents.DotNetBar.ButtonX btnLimpiar;
    }
}