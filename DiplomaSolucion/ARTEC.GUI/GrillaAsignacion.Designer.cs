namespace ARTEC.GUI
{
    partial class GrillaAsignacion
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblBien = new DevComponents.DotNetBar.LabelX();
            this.txtCantidad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCantidad = new DevComponents.DotNetBar.LabelX();
            this.GrillaInventarios = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmAgregar = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.cboAgenteSoft = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInventarios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBien
            // 
            this.txtBien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBien.Border.Class = "TextBoxBorder";
            this.txtBien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBien.DisabledBackColor = System.Drawing.Color.White;
            this.txtBien.ForeColor = System.Drawing.Color.Black;
            this.txtBien.Location = new System.Drawing.Point(58, 3);
            this.txtBien.Name = "txtBien";
            this.txtBien.PreventEnterBeep = true;
            this.txtBien.Size = new System.Drawing.Size(102, 20);
            this.txtBien.TabIndex = 48;
            // 
            // lblBien
            // 
            // 
            // 
            // 
            this.lblBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(3, 3);
            this.lblBien.Name = "lblBien";
            this.lblBien.Size = new System.Drawing.Size(54, 22);
            this.lblBien.TabIndex = 49;
            this.lblBien.Text = "lblBien";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCantidad.Border.Class = "TextBoxBorder";
            this.txtCantidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCantidad.DisabledBackColor = System.Drawing.Color.White;
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(260, 3);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PreventEnterBeep = true;
            this.txtCantidad.Size = new System.Drawing.Size(35, 22);
            this.txtCantidad.TabIndex = 50;
            // 
            // lblCantidad
            // 
            // 
            // 
            // 
            this.lblCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCantidad.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(173, 3);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(81, 22);
            this.lblCantidad.TabIndex = 51;
            this.lblCantidad.Text = "lblCantidad";
            // 
            // GrillaInventarios
            // 
            this.GrillaInventarios.BackgroundColor = System.Drawing.Color.White;
            this.GrillaInventarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrillaInventarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaInventarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaInventarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaInventarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAgregar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaInventarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaInventarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrillaInventarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrillaInventarios.EnableHeadersVisualStyles = false;
            this.GrillaInventarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaInventarios.Location = new System.Drawing.Point(0, 28);
            this.GrillaInventarios.Name = "GrillaInventarios";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrillaInventarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrillaInventarios.Size = new System.Drawing.Size(563, 91);
            this.GrillaInventarios.TabIndex = 52;
            this.GrillaInventarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaInventarios_CellClick);
            // 
            // clmAgregar
            // 
            this.clmAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.clmAgregar.HeaderText = "";
            this.clmAgregar.Name = "clmAgregar";
            this.clmAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.clmAgregar.Text = "Agregar";
            this.clmAgregar.UseColumnTextForButtonValue = true;
            // 
            // cboAgenteSoft
            // 
            this.cboAgenteSoft.DisplayMember = "Text";
            this.cboAgenteSoft.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAgenteSoft.ForeColor = System.Drawing.Color.Black;
            this.cboAgenteSoft.FormattingEnabled = true;
            this.cboAgenteSoft.ItemHeight = 14;
            this.cboAgenteSoft.Location = new System.Drawing.Point(369, 3);
            this.cboAgenteSoft.Name = "cboAgenteSoft";
            this.cboAgenteSoft.Size = new System.Drawing.Size(121, 20);
            this.cboAgenteSoft.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAgenteSoft.TabIndex = 53;
            this.cboAgenteSoft.Visible = false;
            // 
            // GrillaAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cboAgenteSoft);
            this.Controls.Add(this.GrillaInventarios);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtBien);
            this.Controls.Add(this.lblBien);
            this.Name = "GrillaAsignacion";
            this.Size = new System.Drawing.Size(563, 119);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaInventarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtBien;
        private DevComponents.DotNetBar.LabelX lblBien;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCantidad;
        private DevComponents.DotNetBar.LabelX lblCantidad;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaInventarios;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn clmAgregar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgenteSoft;
    }
}
