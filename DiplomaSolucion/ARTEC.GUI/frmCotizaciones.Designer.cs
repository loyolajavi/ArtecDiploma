namespace ARTEC.GUI
{
    partial class frmCotizaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCuerpo = new DevComponents.DotNetBar.LabelX();
            this.lblAsunto = new DevComponents.DotNetBar.LabelX();
            this.txtAsunto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCuerpo = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.btnAgregarProvSol = new DevComponents.DotNetBar.ButtonX();
            this.txtProvSol = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboProvSol = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.GrillaProvSolic = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSolicitar = new DevComponents.DotNetBar.ButtonX();
            this.lblProvSol = new DevComponents.DotNetBar.LabelX();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtProveedor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPrecioUn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grillaProveedor = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.lblPrecioUn = new DevComponents.DotNetBar.LabelX();
            this.lblProveedor = new DevComponents.DotNetBar.LabelX();
            this.cboProveedor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaProvSolic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCuerpo);
            this.tabPage2.Controls.Add(this.lblAsunto);
            this.tabPage2.Controls.Add(this.txtAsunto);
            this.tabPage2.Controls.Add(this.txtCuerpo);
            this.tabPage2.Controls.Add(this.btnAgregarProvSol);
            this.tabPage2.Controls.Add(this.txtProvSol);
            this.tabPage2.Controls.Add(this.cboProvSol);
            this.tabPage2.Controls.Add(this.GrillaProvSolic);
            this.tabPage2.Controls.Add(this.btnSolicitar);
            this.tabPage2.Controls.Add(this.lblProvSol);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Solicitar Cotizaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCuerpo
            // 
            // 
            // 
            // 
            this.lblCuerpo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCuerpo.Location = new System.Drawing.Point(267, 92);
            this.lblCuerpo.Name = "lblCuerpo";
            this.lblCuerpo.Size = new System.Drawing.Size(56, 22);
            this.lblCuerpo.TabIndex = 58;
            this.lblCuerpo.Text = "lblCuerpo";
            // 
            // lblAsunto
            // 
            // 
            // 
            // 
            this.lblAsunto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAsunto.Location = new System.Drawing.Point(267, 42);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(56, 22);
            this.lblAsunto.TabIndex = 57;
            this.lblAsunto.Text = "lblAsunto";
            // 
            // txtAsunto
            // 
            this.txtAsunto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAsunto.Border.Class = "TextBoxBorder";
            this.txtAsunto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAsunto.DisabledBackColor = System.Drawing.Color.White;
            this.txtAsunto.ForeColor = System.Drawing.Color.Black;
            this.txtAsunto.Location = new System.Drawing.Point(267, 66);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.PreventEnterBeep = true;
            this.txtAsunto.Size = new System.Drawing.Size(238, 22);
            this.txtAsunto.TabIndex = 56;
            this.txtAsunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCuerpo
            // 
            // 
            // 
            // 
            this.txtCuerpo.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtCuerpo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCuerpo.Location = new System.Drawing.Point(267, 114);
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n\\viewkind4\\uc1\\pard\\la" +
    "ng11274\\f0\\fs17 txtCuerpo\\par\r\n}\r\n";
            this.txtCuerpo.Size = new System.Drawing.Size(295, 137);
            this.txtCuerpo.TabIndex = 55;
            this.txtCuerpo.Text = "txtCuerpo";
            // 
            // btnAgregarProvSol
            // 
            this.btnAgregarProvSol.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregarProvSol.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregarProvSol.Location = new System.Drawing.Point(163, 38);
            this.btnAgregarProvSol.Name = "btnAgregarProvSol";
            this.btnAgregarProvSol.Size = new System.Drawing.Size(98, 22);
            this.btnAgregarProvSol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregarProvSol.TabIndex = 53;
            this.btnAgregarProvSol.Text = "btnAgregarProvSol";
            this.btnAgregarProvSol.Click += new System.EventHandler(this.btnAgregarProvSol_Click);
            // 
            // txtProvSol
            // 
            this.txtProvSol.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtProvSol.Border.Class = "TextBoxBorder";
            this.txtProvSol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProvSol.DisabledBackColor = System.Drawing.Color.White;
            this.txtProvSol.ForeColor = System.Drawing.Color.Black;
            this.txtProvSol.Location = new System.Drawing.Point(36, 38);
            this.txtProvSol.Name = "txtProvSol";
            this.txtProvSol.PreventEnterBeep = true;
            this.txtProvSol.Size = new System.Drawing.Size(121, 22);
            this.txtProvSol.TabIndex = 52;
            this.txtProvSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProvSol.TextChanged += new System.EventHandler(this.txtProvSol_TextChanged);
            // 
            // cboProvSol
            // 
            this.cboProvSol.DisplayMember = "Text";
            this.cboProvSol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProvSol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvSol.ForeColor = System.Drawing.Color.Black;
            this.cboProvSol.FormattingEnabled = true;
            this.cboProvSol.ItemHeight = 16;
            this.cboProvSol.Location = new System.Drawing.Point(36, 38);
            this.cboProvSol.Name = "cboProvSol";
            this.cboProvSol.Size = new System.Drawing.Size(121, 22);
            this.cboProvSol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProvSol.TabIndex = 54;
            this.cboProvSol.SelectionChangeCommitted += new System.EventHandler(this.cboProvSol_SelectionChangeCommitted);
            // 
            // GrillaProvSolic
            // 
            this.GrillaProvSolic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaProvSolic.DefaultCellStyle = dataGridViewCellStyle3;
            this.GrillaProvSolic.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaProvSolic.Location = new System.Drawing.Point(36, 64);
            this.GrillaProvSolic.Name = "GrillaProvSolic";
            this.GrillaProvSolic.Size = new System.Drawing.Size(225, 187);
            this.GrillaProvSolic.TabIndex = 51;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSolicitar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSolicitar.Location = new System.Drawing.Point(229, 264);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(75, 23);
            this.btnSolicitar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSolicitar.TabIndex = 50;
            this.btnSolicitar.Text = "btnSolicitar";
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // lblProvSol
            // 
            // 
            // 
            // 
            this.lblProvSol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProvSol.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvSol.Location = new System.Drawing.Point(99, 15);
            this.lblProvSol.Name = "lblProvSol";
            this.lblProvSol.Size = new System.Drawing.Size(91, 17);
            this.lblProvSol.TabIndex = 47;
            this.lblProvSol.Text = "Proveedores";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 319);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtProveedor);
            this.tabPage1.Controls.Add(this.txtPrecioUn);
            this.tabPage1.Controls.Add(this.grillaProveedor);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Controls.Add(this.lblPrecioUn);
            this.tabPage1.Controls.Add(this.lblProveedor);
            this.tabPage1.Controls.Add(this.cboProveedor);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 293);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Agregar Cotización";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtProveedor.Border.Class = "TextBoxBorder";
            this.txtProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProveedor.DisabledBackColor = System.Drawing.Color.White;
            this.txtProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtProveedor.Location = new System.Drawing.Point(84, 6);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.PreventEnterBeep = true;
            this.txtProveedor.Size = new System.Drawing.Size(121, 22);
            this.txtProveedor.TabIndex = 67;
            this.txtProveedor.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
            // 
            // txtPrecioUn
            // 
            this.txtPrecioUn.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPrecioUn.Border.Class = "TextBoxBorder";
            this.txtPrecioUn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrecioUn.DisabledBackColor = System.Drawing.Color.White;
            this.txtPrecioUn.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioUn.Location = new System.Drawing.Point(84, 34);
            this.txtPrecioUn.Name = "txtPrecioUn";
            this.txtPrecioUn.PreventEnterBeep = true;
            this.txtPrecioUn.Size = new System.Drawing.Size(121, 22);
            this.txtPrecioUn.TabIndex = 63;
            // 
            // grillaProveedor
            // 
            this.grillaProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaProveedor.DefaultCellStyle = dataGridViewCellStyle4;
            this.grillaProveedor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaProveedor.Location = new System.Drawing.Point(7, 102);
            this.grillaProveedor.Name = "grillaProveedor";
            this.grillaProveedor.Size = new System.Drawing.Size(480, 185);
            this.grillaProveedor.TabIndex = 66;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(84, 65);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 22);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 65;
            this.btnAgregar.Text = "buttonX1";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblPrecioUn
            // 
            // 
            // 
            // 
            this.lblPrecioUn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPrecioUn.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioUn.Location = new System.Drawing.Point(9, 34);
            this.lblPrecioUn.Name = "lblPrecioUn";
            this.lblPrecioUn.Size = new System.Drawing.Size(76, 22);
            this.lblPrecioUn.TabIndex = 64;
            this.lblPrecioUn.Text = "Precio Un.";
            // 
            // lblProveedor
            // 
            // 
            // 
            // 
            this.lblProveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProveedor.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(9, 6);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(91, 22);
            this.lblProveedor.TabIndex = 62;
            this.lblProveedor.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            this.cboProveedor.DisplayMember = "Text";
            this.cboProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.ForeColor = System.Drawing.Color.Black;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ItemHeight = 16;
            this.cboProveedor.Location = new System.Drawing.Point(84, 6);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(121, 22);
            this.cboProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboProveedor.TabIndex = 61;
            this.cboProveedor.SelectionChangeCommitted += new System.EventHandler(this.cboProovedor_SelectionChangeCommitted);
            // 
            // frmCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 328);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCotizaciones";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmCotizaciones_Load);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaProvSolic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private DevComponents.DotNetBar.ButtonX btnAgregarProvSol;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProvSol;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProvSol;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaProvSolic;
        private DevComponents.DotNetBar.ButtonX btnSolicitar;
        private DevComponents.DotNetBar.LabelX lblProvSol;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProveedor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboProveedor;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrecioUn;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaProveedor;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.LabelX lblPrecioUn;
        private DevComponents.DotNetBar.LabelX lblProveedor;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtCuerpo;
        private DevComponents.DotNetBar.LabelX lblAsunto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAsunto;
        private DevComponents.DotNetBar.LabelX lblCuerpo;

    }
}