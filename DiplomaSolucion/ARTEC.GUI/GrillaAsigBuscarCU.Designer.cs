namespace ARTEC.GUI
{
    partial class GrillaAsigBuscarCU
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
            this.pnlTitulos = new DevComponents.DotNetBar.PanelEx();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroAsignacion = new DevComponents.DotNetBar.LabelX();
            this.lblNroSolicitud = new DevComponents.DotNetBar.LabelX();
            this.txtAsignacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.GrillaBienes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlTitulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulos
            // 
            this.pnlTitulos.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlTitulos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlTitulos.Controls.Add(this.txtNroSolicitud);
            this.pnlTitulos.Controls.Add(this.lblNroAsignacion);
            this.pnlTitulos.Controls.Add(this.lblNroSolicitud);
            this.pnlTitulos.Controls.Add(this.txtAsignacion);
            this.pnlTitulos.Controls.Add(this.txtDep);
            this.pnlTitulos.Controls.Add(this.lblDependencia);
            this.pnlTitulos.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlTitulos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulos.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulos.Name = "pnlTitulos";
            this.pnlTitulos.Size = new System.Drawing.Size(397, 56);
            this.pnlTitulos.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlTitulos.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlTitulos.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlTitulos.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.pnlTitulos.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlTitulos.Style.GradientAngle = 90;
            this.pnlTitulos.TabIndex = 0;
            // 
            // txtNroSolicitud
            // 
            this.txtNroSolicitud.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroSolicitud.Border.Class = "TextBoxBorder";
            this.txtNroSolicitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroSolicitud.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroSolicitud.ForeColor = System.Drawing.Color.Black;
            this.txtNroSolicitud.Location = new System.Drawing.Point(295, 3);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(70, 20);
            this.txtNroSolicitud.TabIndex = 59;
            // 
            // lblNroAsignacion
            // 
            // 
            // 
            // 
            this.lblNroAsignacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroAsignacion.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroAsignacion.Location = new System.Drawing.Point(3, 3);
            this.lblNroAsignacion.Name = "lblNroAsignacion";
            this.lblNroAsignacion.Size = new System.Drawing.Size(91, 22);
            this.lblNroAsignacion.TabIndex = 57;
            this.lblNroAsignacion.Text = "lblNroAsignacion";
            // 
            // lblNroSolicitud
            // 
            // 
            // 
            // 
            this.lblNroSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolicitud.Location = new System.Drawing.Point(198, 3);
            this.lblNroSolicitud.Name = "lblNroSolicitud";
            this.lblNroSolicitud.Size = new System.Drawing.Size(91, 22);
            this.lblNroSolicitud.TabIndex = 58;
            this.lblNroSolicitud.Text = "NroSolicitud";
            // 
            // txtAsignacion
            // 
            this.txtAsignacion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAsignacion.Border.Class = "TextBoxBorder";
            this.txtAsignacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAsignacion.DisabledBackColor = System.Drawing.Color.White;
            this.txtAsignacion.ForeColor = System.Drawing.Color.Black;
            this.txtAsignacion.Location = new System.Drawing.Point(100, 3);
            this.txtAsignacion.Name = "txtAsignacion";
            this.txtAsignacion.PreventEnterBeep = true;
            this.txtAsignacion.Size = new System.Drawing.Size(70, 20);
            this.txtAsignacion.TabIndex = 56;
            // 
            // txtDep
            // 
            this.txtDep.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDep.Border.Class = "TextBoxBorder";
            this.txtDep.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDep.DisabledBackColor = System.Drawing.Color.White;
            this.txtDep.ForeColor = System.Drawing.Color.Black;
            this.txtDep.Location = new System.Drawing.Point(100, 31);
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.Size = new System.Drawing.Size(265, 20);
            this.txtDep.TabIndex = 55;
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(3, 31);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 22);
            this.lblDependencia.TabIndex = 54;
            this.lblDependencia.Text = "Dependencia";
            // 
            // GrillaBienes
            // 
            this.GrillaBienes.AllowUserToAddRows = false;
            this.GrillaBienes.AllowUserToDeleteRows = false;
            this.GrillaBienes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaBienes.BackgroundColor = System.Drawing.Color.White;
            this.GrillaBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaBienes.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaBienes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrillaBienes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaBienes.Location = new System.Drawing.Point(0, 57);
            this.GrillaBienes.Name = "GrillaBienes";
            this.GrillaBienes.ReadOnly = true;
            this.GrillaBienes.Size = new System.Drawing.Size(397, 93);
            this.GrillaBienes.TabIndex = 65;
            this.GrillaBienes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaBienes_CellClick);
            // 
            // GrillaAsigBuscarCU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.GrillaBienes);
            this.Controls.Add(this.pnlTitulos);
            this.Name = "GrillaAsigBuscarCU";
            this.Size = new System.Drawing.Size(397, 150);
            this.pnlTitulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBienes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlTitulos;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDep;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.LabelX lblNroAsignacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAsignacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.LabelX lblNroSolicitud;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaBienes;
    }
}
