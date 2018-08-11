namespace ARTEC.GUI
{
    partial class frmProveedorCrear
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedorCrear));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNombreEmpresa = new DevComponents.DotNetBar.LabelX();
            this.lblContacto = new DevComponents.DotNetBar.LabelX();
            this.lblTelefono = new DevComponents.DotNetBar.LabelX();
            this.lblDireccion = new DevComponents.DotNetBar.LabelX();
            this.lblMailContacto = new DevComponents.DotNetBar.LabelX();
            this.txtNombreEmpresa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtContacto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gpanelProductos = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.GrillaProductos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAgregarProd = new DevComponents.DotNetBar.ButtonX();
            this.txtProducto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboProducto = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnCrearProveedor = new DevComponents.DotNetBar.ButtonX();
            this.btnTelefono = new DevComponents.DotNetBar.ButtonX();
            this.btnDireccion = new DevComponents.DotNetBar.ButtonX();
            this.txtMailContacto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCalle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNroCalle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboProvincia = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtPiso = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlBuscar = new DevComponents.DotNetBar.PanelEx();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.lblProveedor = new DevComponents.DotNetBar.LabelX();
            this.txtProveedorBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboProveedor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtCodArea = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNroTelefono = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboTipo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblTipo = new DevComponents.DotNetBar.LabelX();
            this.txtLocalidad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vldFrmProveedorCrear = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator6 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator7 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator8 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.GrillaTelefonos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.GrillaDirecciones = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.gpanelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaProductos)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaTelefonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDirecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblNombreEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombreEmpresa.ForeColor = System.Drawing.Color.Black;
            this.lblNombreEmpresa.Location = new System.Drawing.Point(9, 116);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(100, 23);
            this.lblNombreEmpresa.TabIndex = 0;
            this.lblNombreEmpresa.Text = "lblNombreEmpresa";
            // 
            // lblContacto
            // 
            this.lblContacto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblContacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblContacto.ForeColor = System.Drawing.Color.Black;
            this.lblContacto.Location = new System.Drawing.Point(9, 147);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(75, 23);
            this.lblContacto.TabIndex = 2;
            this.lblContacto.Text = "lblContacto";
            // 
            // lblTelefono
            // 
            this.lblTelefono.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblTelefono.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(287, 84);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(75, 23);
            this.lblTelefono.TabIndex = 3;
            this.lblTelefono.Text = "lblTelefono";
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblDireccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblDireccion.Location = new System.Drawing.Point(287, 215);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 23);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "lblDireccion";
            // 
            // lblMailContacto
            // 
            this.lblMailContacto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblMailContacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMailContacto.ForeColor = System.Drawing.Color.Black;
            this.lblMailContacto.Location = new System.Drawing.Point(9, 176);
            this.lblMailContacto.Name = "lblMailContacto";
            this.lblMailContacto.Size = new System.Drawing.Size(86, 23);
            this.lblMailContacto.TabIndex = 5;
            this.lblMailContacto.Text = "lblMailContacto";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombreEmpresa.Border.Class = "TextBoxBorder";
            this.txtNombreEmpresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombreEmpresa.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombreEmpresa.ForeColor = System.Drawing.Color.Black;
            this.txtNombreEmpresa.Location = new System.Drawing.Point(109, 117);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.PreventEnterBeep = true;
            this.txtNombreEmpresa.Size = new System.Drawing.Size(160, 22);
            this.txtNombreEmpresa.TabIndex = 7;
            this.vldFrmProveedorCrear.SetValidator1(this.txtNombreEmpresa, this.requiredFieldValidator1);
            // 
            // txtContacto
            // 
            this.txtContacto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtContacto.Border.Class = "TextBoxBorder";
            this.txtContacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtContacto.DisabledBackColor = System.Drawing.Color.White;
            this.txtContacto.ForeColor = System.Drawing.Color.Black;
            this.txtContacto.Location = new System.Drawing.Point(109, 148);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.PreventEnterBeep = true;
            this.txtContacto.Size = new System.Drawing.Size(160, 22);
            this.txtContacto.TabIndex = 8;
            // 
            // gpanelProductos
            // 
            this.gpanelProductos.BackColor = System.Drawing.Color.White;
            this.gpanelProductos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpanelProductos.Controls.Add(this.GrillaProductos);
            this.gpanelProductos.Controls.Add(this.btnAgregarProd);
            this.gpanelProductos.Controls.Add(this.txtProducto);
            this.gpanelProductos.Controls.Add(this.cboProducto);
            this.gpanelProductos.DisabledBackColor = System.Drawing.Color.Empty;
            this.gpanelProductos.Location = new System.Drawing.Point(12, 231);
            this.gpanelProductos.Name = "gpanelProductos";
            this.gpanelProductos.Size = new System.Drawing.Size(260, 208);
            // 
            // 
            // 
            this.gpanelProductos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpanelProductos.Style.BackColorGradientAngle = 90;
            this.gpanelProductos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpanelProductos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpanelProductos.Style.BorderBottomWidth = 1;
            this.gpanelProductos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpanelProductos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpanelProductos.Style.BorderLeftWidth = 1;
            this.gpanelProductos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpanelProductos.Style.BorderRightWidth = 1;
            this.gpanelProductos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpanelProductos.Style.BorderTopWidth = 1;
            this.gpanelProductos.Style.CornerDiameter = 4;
            this.gpanelProductos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpanelProductos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpanelProductos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpanelProductos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpanelProductos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpanelProductos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpanelProductos.TabIndex = 15;
            this.gpanelProductos.Text = "gpanelProductos";
            // 
            // GrillaProductos
            // 
            this.GrillaProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GrillaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaProductos.DefaultCellStyle = dataGridViewCellStyle8;
            this.GrillaProductos.EnableHeadersVisualStyles = false;
            this.GrillaProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaProductos.Location = new System.Drawing.Point(3, 40);
            this.GrillaProductos.Name = "GrillaProductos";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.GrillaProductos.Size = new System.Drawing.Size(248, 142);
            this.GrillaProductos.TabIndex = 2;
            this.GrillaProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaProductos_CellClick);
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregarProd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregarProd.Location = new System.Drawing.Point(149, 12);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(75, 22);
            this.btnAgregarProd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregarProd.TabIndex = 1;
            this.btnAgregarProd.Text = "btnAgregarProd";
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtProducto.Border.Class = "TextBoxBorder";
            this.txtProducto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProducto.DisabledBackColor = System.Drawing.Color.White;
            this.txtProducto.ForeColor = System.Drawing.Color.Black;
            this.txtProducto.Location = new System.Drawing.Point(3, 12);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.PreventEnterBeep = true;
            this.txtProducto.Size = new System.Drawing.Size(140, 22);
            this.txtProducto.TabIndex = 0;
            this.vldFrmProveedorCrear.SetValidator1(this.txtProducto, this.requiredFieldValidator2);
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            // 
            // cboProducto
            // 
            this.cboProducto.DisplayMember = "Text";
            this.cboProducto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProducto.ForeColor = System.Drawing.Color.Black;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.ItemHeight = 16;
            this.cboProducto.Location = new System.Drawing.Point(3, 12);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(140, 22);
            this.cboProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProducto.TabIndex = 3;
            this.cboProducto.SelectionChangeCommitted += new System.EventHandler(this.cboProducto_SelectionChangeCommitted);
            // 
            // btnCrearProveedor
            // 
            this.btnCrearProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearProveedor.Location = new System.Drawing.Point(80, 530);
            this.btnCrearProveedor.Name = "btnCrearProveedor";
            this.btnCrearProveedor.Size = new System.Drawing.Size(98, 38);
            this.btnCrearProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearProveedor.TabIndex = 16;
            this.btnCrearProveedor.Text = "btnCrearProveedor";
            this.btnCrearProveedor.Click += new System.EventHandler(this.btnCrearProveedor_Click);
            // 
            // btnTelefono
            // 
            this.btnTelefono.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTelefono.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTelefono.Location = new System.Drawing.Point(407, 176);
            this.btnTelefono.Name = "btnTelefono";
            this.btnTelefono.Size = new System.Drawing.Size(58, 23);
            this.btnTelefono.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTelefono.TabIndex = 18;
            this.btnTelefono.Text = "btnTelefono";
            this.btnTelefono.Click += new System.EventHandler(this.btnTelefono_Click);
            // 
            // btnDireccion
            // 
            this.btnDireccion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDireccion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDireccion.Location = new System.Drawing.Point(407, 385);
            this.btnDireccion.Name = "btnDireccion";
            this.btnDireccion.Size = new System.Drawing.Size(58, 22);
            this.btnDireccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDireccion.TabIndex = 21;
            this.btnDireccion.Text = "btnDireccion";
            this.btnDireccion.Click += new System.EventHandler(this.btnDireccion_Click);
            // 
            // txtMailContacto
            // 
            this.txtMailContacto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMailContacto.Border.Class = "TextBoxBorder";
            this.txtMailContacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMailContacto.DisabledBackColor = System.Drawing.Color.White;
            this.txtMailContacto.ForeColor = System.Drawing.Color.Black;
            this.txtMailContacto.Location = new System.Drawing.Point(109, 176);
            this.txtMailContacto.Name = "txtMailContacto";
            this.txtMailContacto.PreventEnterBeep = true;
            this.txtMailContacto.Size = new System.Drawing.Size(160, 22);
            this.txtMailContacto.TabIndex = 23;
            // 
            // txtCalle
            // 
            this.txtCalle.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCalle.Border.Class = "TextBoxBorder";
            this.txtCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCalle.DisabledBackColor = System.Drawing.Color.White;
            this.txtCalle.ForeColor = System.Drawing.Color.Black;
            this.txtCalle.Location = new System.Drawing.Point(287, 244);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.PreventEnterBeep = true;
            this.txtCalle.Size = new System.Drawing.Size(178, 22);
            this.txtCalle.TabIndex = 27;
            this.vldFrmProveedorCrear.SetValidator1(this.txtCalle, this.requiredFieldValidator5);
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroCalle.Border.Class = "TextBoxBorder";
            this.txtNroCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroCalle.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroCalle.ForeColor = System.Drawing.Color.Black;
            this.txtNroCalle.Location = new System.Drawing.Point(287, 272);
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.PreventEnterBeep = true;
            this.txtNroCalle.Size = new System.Drawing.Size(178, 22);
            this.txtNroCalle.TabIndex = 28;
            this.vldFrmProveedorCrear.SetValidator1(this.txtNroCalle, this.requiredFieldValidator6);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DisplayMember = "Text";
            this.cboProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProvincia.ForeColor = System.Drawing.Color.Black;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.ItemHeight = 16;
            this.cboProvincia.Location = new System.Drawing.Point(287, 357);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(178, 22);
            this.cboProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProvincia.TabIndex = 29;
            // 
            // txtPiso
            // 
            this.txtPiso.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPiso.Border.Class = "TextBoxBorder";
            this.txtPiso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPiso.DisabledBackColor = System.Drawing.Color.White;
            this.txtPiso.ForeColor = System.Drawing.Color.Black;
            this.txtPiso.Location = new System.Drawing.Point(287, 301);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.PreventEnterBeep = true;
            this.txtPiso.Size = new System.Drawing.Size(178, 22);
            this.txtPiso.TabIndex = 30;
            this.vldFrmProveedorCrear.SetValidator1(this.txtPiso, this.requiredFieldValidator7);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.lblProveedor);
            this.pnlBuscar.Controls.Add(this.txtProveedorBuscar);
            this.pnlBuscar.Controls.Add(this.cboProveedor);
            this.pnlBuscar.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBuscar.Location = new System.Drawing.Point(9, 12);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(422, 35);
            this.pnlBuscar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBuscar.Style.GradientAngle = 90;
            this.pnlBuscar.TabIndex = 86;
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblProveedor
            // 
            // 
            // 
            // 
            this.lblProveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProveedor.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(9, 9);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(91, 17);
            this.lblProveedor.TabIndex = 62;
            this.lblProveedor.Text = "lblProveedor";
            // 
            // txtProveedorBuscar
            // 
            this.txtProveedorBuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtProveedorBuscar.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtProveedorBuscar.Border.BorderBottomWidth = 2;
            this.txtProveedorBuscar.Border.BorderColor = System.Drawing.Color.Black;
            this.txtProveedorBuscar.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtProveedorBuscar.Border.BorderLeftWidth = 2;
            this.txtProveedorBuscar.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtProveedorBuscar.Border.BorderRightWidth = 2;
            this.txtProveedorBuscar.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtProveedorBuscar.Border.BorderTopWidth = 2;
            this.txtProveedorBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProveedorBuscar.DisabledBackColor = System.Drawing.Color.White;
            this.txtProveedorBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtProveedorBuscar.Location = new System.Drawing.Point(106, 6);
            this.txtProveedorBuscar.Multiline = true;
            this.txtProveedorBuscar.Name = "txtProveedorBuscar";
            this.txtProveedorBuscar.PreventEnterBeep = true;
            this.txtProveedorBuscar.Size = new System.Drawing.Size(227, 22);
            this.txtProveedorBuscar.TabIndex = 0;
            this.txtProveedorBuscar.TextChanged += new System.EventHandler(this.txtProveedorBuscar_TextChanged);
            // 
            // cboProveedor
            // 
            this.cboProveedor.DisplayMember = "Text";
            this.cboProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProveedor.ForeColor = System.Drawing.Color.Black;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ItemHeight = 16;
            this.cboProveedor.Location = new System.Drawing.Point(106, 6);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(227, 22);
            this.cboProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProveedor.TabIndex = 101;
            this.cboProveedor.SelectionChangeCommitted += new System.EventHandler(this.cboProveedor_SelectionChangeCommitted);
            // 
            // txtCodArea
            // 
            this.txtCodArea.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCodArea.Border.Class = "TextBoxBorder";
            this.txtCodArea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCodArea.DisabledBackColor = System.Drawing.Color.White;
            this.txtCodArea.ForeColor = System.Drawing.Color.Black;
            this.txtCodArea.Location = new System.Drawing.Point(287, 148);
            this.txtCodArea.Name = "txtCodArea";
            this.txtCodArea.PreventEnterBeep = true;
            this.txtCodArea.Size = new System.Drawing.Size(38, 22);
            this.txtCodArea.TabIndex = 87;
            this.vldFrmProveedorCrear.SetValidator1(this.txtCodArea, this.requiredFieldValidator3);
            // 
            // txtNroTelefono
            // 
            this.txtNroTelefono.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroTelefono.Border.Class = "TextBoxBorder";
            this.txtNroTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroTelefono.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroTelefono.ForeColor = System.Drawing.Color.Black;
            this.txtNroTelefono.Location = new System.Drawing.Point(331, 148);
            this.txtNroTelefono.Name = "txtNroTelefono";
            this.txtNroTelefono.PreventEnterBeep = true;
            this.txtNroTelefono.Size = new System.Drawing.Size(134, 22);
            this.txtNroTelefono.TabIndex = 91;
            this.vldFrmProveedorCrear.SetValidator1(this.txtNroTelefono, this.requiredFieldValidator4);
            // 
            // cboTipo
            // 
            this.cboTipo.DisplayMember = "Text";
            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.ForeColor = System.Drawing.Color.Black;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.ItemHeight = 16;
            this.cboTipo.Location = new System.Drawing.Point(331, 116);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(100, 22);
            this.cboTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipo.TabIndex = 95;
            // 
            // lblTipo
            // 
            this.lblTipo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblTipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(287, 116);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(41, 23);
            this.lblTipo.TabIndex = 96;
            this.lblTipo.Text = "lblTipo";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLocalidad.Border.Class = "TextBoxBorder";
            this.txtLocalidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLocalidad.DisabledBackColor = System.Drawing.Color.White;
            this.txtLocalidad.ForeColor = System.Drawing.Color.Black;
            this.txtLocalidad.Location = new System.Drawing.Point(287, 329);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.PreventEnterBeep = true;
            this.txtLocalidad.Size = new System.Drawing.Size(178, 22);
            this.txtLocalidad.TabIndex = 97;
            this.vldFrmProveedorCrear.SetValidator1(this.txtLocalidad, this.requiredFieldValidator8);
            // 
            // vldFrmProveedorCrear
            // 
            this.vldFrmProveedorCrear.ContainerControl = this.btnCrearProveedor;
            this.vldFrmProveedorCrear.ErrorProvider = this.errorProvider1;
            this.vldFrmProveedorCrear.Highlighter = this.highlighter1;
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
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator6
            // 
            this.requiredFieldValidator6.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator7
            // 
            this.requiredFieldValidator7.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator7.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // requiredFieldValidator8
            // 
            this.requiredFieldValidator8.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator8.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // GrillaTelefonos
            // 
            this.GrillaTelefonos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaTelefonos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GrillaTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaTelefonos.DefaultCellStyle = dataGridViewCellStyle5;
            this.GrillaTelefonos.EnableHeadersVisualStyles = false;
            this.GrillaTelefonos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaTelefonos.Location = new System.Drawing.Point(471, 116);
            this.GrillaTelefonos.Name = "GrillaTelefonos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaTelefonos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GrillaTelefonos.Size = new System.Drawing.Size(373, 83);
            this.GrillaTelefonos.TabIndex = 4;
            this.GrillaTelefonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaTelefonos_CellClick);
            // 
            // GrillaDirecciones
            // 
            this.GrillaDirecciones.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaDirecciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaDirecciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaDirecciones.EnableHeadersVisualStyles = false;
            this.GrillaDirecciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaDirecciones.Location = new System.Drawing.Point(471, 244);
            this.GrillaDirecciones.Name = "GrillaDirecciones";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaDirecciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrillaDirecciones.Size = new System.Drawing.Size(373, 142);
            this.GrillaDirecciones.TabIndex = 101;
            this.GrillaDirecciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDirecciones_CellClick);
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(230, 530);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(98, 38);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 105;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // frmProveedorCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 580);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.GrillaDirecciones);
            this.Controls.Add(this.GrillaTelefonos);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.txtNroTelefono);
            this.Controls.Add(this.txtCodArea);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.txtNroCalle);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtMailContacto);
            this.Controls.Add(this.btnDireccion);
            this.Controls.Add(this.btnTelefono);
            this.Controls.Add(this.btnCrearProveedor);
            this.Controls.Add(this.gpanelProductos);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.lblMailContacto);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblNombreEmpresa);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmProveedorCrear";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.ProveedorCrear_Load);
            this.gpanelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaProductos)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaTelefonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDirecciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblNombreEmpresa;
        private DevComponents.DotNetBar.LabelX lblContacto;
        private DevComponents.DotNetBar.LabelX lblTelefono;
        private DevComponents.DotNetBar.LabelX lblDireccion;
        private DevComponents.DotNetBar.LabelX lblMailContacto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombreEmpresa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContacto;
        private DevComponents.DotNetBar.Controls.GroupPanel gpanelProductos;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaProductos;
        private DevComponents.DotNetBar.ButtonX btnAgregarProd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProducto;
        private DevComponents.DotNetBar.ButtonX btnCrearProveedor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProducto;
        private DevComponents.DotNetBar.ButtonX btnTelefono;
        private DevComponents.DotNetBar.ButtonX btnDireccion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMailContacto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCalle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroCalle;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProvincia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPiso;
        private DevComponents.DotNetBar.PanelEx pnlBuscar;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.LabelX lblProveedor;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProveedorBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCodArea;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroTelefono;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipo;
        private DevComponents.DotNetBar.LabelX lblTipo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLocalidad;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmProveedorCrear;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator8;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator7;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator6;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator5;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProveedor;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaDirecciones;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaTelefonos;
        private DevComponents.DotNetBar.ButtonX btnModificar;
    }
}