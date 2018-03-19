namespace ARTEC.GUI
{
    partial class frmDependenciaModificar
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
            this.lblAgentes = new DevComponents.DotNetBar.LabelX();
            this.lblTipoDep = new DevComponents.DotNetBar.LabelX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboTipoDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAgregarAgente = new DevComponents.DotNetBar.ButtonX();
            this.txtAgente = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboCargo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblCargo = new DevComponents.DotNetBar.LabelX();
            this.cboAgentes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.GrillaAgentesLista = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnCandado = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnNuevoAgente = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAgentesLista)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAgentes
            // 
            // 
            // 
            // 
            this.lblAgentes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAgentes.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentes.Location = new System.Drawing.Point(12, 79);
            this.lblAgentes.Name = "lblAgentes";
            this.lblAgentes.Size = new System.Drawing.Size(91, 17);
            this.lblAgentes.TabIndex = 64;
            this.lblAgentes.Text = "lblAgentes";
            // 
            // lblTipoDep
            // 
            // 
            // 
            // 
            this.lblTipoDep.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoDep.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDep.Location = new System.Drawing.Point(12, 41);
            this.lblTipoDep.Name = "lblTipoDep";
            this.lblTipoDep.Size = new System.Drawing.Size(91, 17);
            this.lblTipoDep.TabIndex = 62;
            this.lblTipoDep.Text = "lblTipoDep";
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(12, 12);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 60;
            this.lblDependencia.Text = "lblDependencia";
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(198, 320);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 59;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtDependencia
            // 
            this.txtDependencia.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDependencia.Border.Class = "TextBoxBorder";
            this.txtDependencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDependencia.DisabledBackColor = System.Drawing.Color.White;
            this.txtDependencia.Enabled = false;
            this.txtDependencia.ForeColor = System.Drawing.Color.Black;
            this.txtDependencia.Location = new System.Drawing.Point(109, 7);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(285, 22);
            this.txtDependencia.TabIndex = 61;
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(109, 7);
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(285, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 66;
            // 
            // cboTipoDep
            // 
            this.cboTipoDep.DisplayMember = "Text";
            this.cboTipoDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoDep.ForeColor = System.Drawing.Color.Black;
            this.cboTipoDep.FormattingEnabled = true;
            this.cboTipoDep.ItemHeight = 16;
            this.cboTipoDep.Location = new System.Drawing.Point(109, 36);
            this.cboTipoDep.Name = "cboTipoDep";
            this.cboTipoDep.Size = new System.Drawing.Size(121, 22);
            this.cboTipoDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoDep.TabIndex = 68;
            // 
            // btnAgregarAgente
            // 
            this.btnAgregarAgente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregarAgente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregarAgente.Location = new System.Drawing.Point(198, 128);
            this.btnAgregarAgente.Name = "btnAgregarAgente";
            this.btnAgregarAgente.Size = new System.Drawing.Size(60, 22);
            this.btnAgregarAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregarAgente.TabIndex = 71;
            this.btnAgregarAgente.Text = "btnAgregarAgente";
            this.btnAgregarAgente.Click += new System.EventHandler(this.btnAgregarAgente_Click);
            // 
            // txtAgente
            // 
            this.txtAgente.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAgente.Border.Class = "TextBoxBorder";
            this.txtAgente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAgente.DisabledBackColor = System.Drawing.Color.White;
            this.txtAgente.ForeColor = System.Drawing.Color.Black;
            this.txtAgente.Location = new System.Drawing.Point(64, 100);
            this.txtAgente.Name = "txtAgente";
            this.txtAgente.PreventEnterBeep = true;
            this.txtAgente.Size = new System.Drawing.Size(194, 22);
            this.txtAgente.TabIndex = 69;
            this.txtAgente.TextChanged += new System.EventHandler(this.txtAgente_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 99);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 23);
            this.labelX2.TabIndex = 70;
            this.labelX2.Text = "Agente";
            // 
            // cboCargo
            // 
            this.cboCargo.DisplayMember = "Text";
            this.cboCargo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCargo.ForeColor = System.Drawing.Color.Black;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.ItemHeight = 16;
            this.cboCargo.Location = new System.Drawing.Point(64, 128);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(128, 22);
            this.cboCargo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCargo.TabIndex = 74;
            // 
            // lblCargo
            // 
            // 
            // 
            // 
            this.lblCargo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCargo.Location = new System.Drawing.Point(12, 128);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 23);
            this.lblCargo.TabIndex = 75;
            this.lblCargo.Text = "lblCargo";
            // 
            // cboAgentes
            // 
            this.cboAgentes.DisplayMember = "Text";
            this.cboAgentes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAgentes.ForeColor = System.Drawing.Color.Black;
            this.cboAgentes.FormattingEnabled = true;
            this.cboAgentes.ItemHeight = 16;
            this.cboAgentes.Location = new System.Drawing.Point(64, 100);
            this.cboAgentes.Name = "cboAgentes";
            this.cboAgentes.Size = new System.Drawing.Size(194, 22);
            this.cboAgentes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAgentes.TabIndex = 76;
            this.cboAgentes.SelectionChangeCommitted += new System.EventHandler(this.cboAgentes_SelectionChangeCommitted);
            // 
            // GrillaAgentesLista
            // 
            this.GrillaAgentesLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaAgentesLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaAgentesLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.GrillaAgentesLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaAgentesLista.Location = new System.Drawing.Point(2, 156);
            this.GrillaAgentesLista.Name = "GrillaAgentesLista";
            this.GrillaAgentesLista.ReadOnly = true;
            this.GrillaAgentesLista.SelectAllSignVisible = false;
            this.GrillaAgentesLista.ShowCellErrors = false;
            this.GrillaAgentesLista.ShowCellToolTips = false;
            this.GrillaAgentesLista.ShowEditingIcon = false;
            this.GrillaAgentesLista.ShowRowErrors = false;
            this.GrillaAgentesLista.Size = new System.Drawing.Size(439, 150);
            this.GrillaAgentesLista.TabIndex = 77;
            this.GrillaAgentesLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaAgentesLista_CellClick);
            // 
            // btnCandado
            // 
            this.btnCandado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCandado.BackColor = System.Drawing.Color.Transparent;
            this.btnCandado.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCandado.Image = global::ARTEC.GUI.Properties.Resources.CandadoDesb;
            this.btnCandado.Location = new System.Drawing.Point(395, 3);
            this.btnCandado.Name = "btnCandado";
            this.btnCandado.Size = new System.Drawing.Size(31, 31);
            this.btnCandado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCandado.TabIndex = 78;
            this.btnCandado.Click += new System.EventHandler(this.btnCandado_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Location = new System.Drawing.Point(368, 354);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 79;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevoAgente
            // 
            this.btnNuevoAgente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNuevoAgente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNuevoAgente.Location = new System.Drawing.Point(366, 100);
            this.btnNuevoAgente.Name = "btnNuevoAgente";
            this.btnNuevoAgente.Size = new System.Drawing.Size(75, 34);
            this.btnNuevoAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNuevoAgente.TabIndex = 84;
            this.btnNuevoAgente.Text = "Crear Nuevo Agente";
            this.btnNuevoAgente.Click += new System.EventHandler(this.btnNuevoAgente_Click);
            // 
            // frmDependenciaModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 379);
            this.Controls.Add(this.btnNuevoAgente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCandado);
            this.Controls.Add(this.GrillaAgentesLista);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.cboCargo);
            this.Controls.Add(this.btnAgregarAgente);
            this.Controls.Add(this.txtAgente);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cboTipoDep);
            this.Controls.Add(this.lblAgentes);
            this.Controls.Add(this.lblTipoDep);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.cboDep);
            this.Controls.Add(this.cboAgentes);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDependenciaModificar";
            this.Text = "MetroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDependenciaModificar_FormClosing);
            this.Load += new System.EventHandler(this.frmDependenciaModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAgentesLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblAgentes;
        private DevComponents.DotNetBar.LabelX lblTipoDep;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoDep;
        private DevComponents.DotNetBar.ButtonX btnAgregarAgente;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAgente;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCargo;
        private DevComponents.DotNetBar.LabelX lblCargo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgentes;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaAgentesLista;
        private DevComponents.DotNetBar.ButtonX btnCandado;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnNuevoAgente;
    }
}