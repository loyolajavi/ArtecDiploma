namespace ARTEC.GUI
{
    partial class frmRendicionBuscar
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
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.txtNroPart = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartida = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolic = new DevComponents.DotNetBar.LabelX();
            this.txtNroRendicion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroRendicion = new DevComponents.DotNetBar.LabelX();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.GrillaRendicionBuscar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboDep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaRendicionBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(138, 130);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 73;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNroPart
            // 
            this.txtNroPart.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroPart.Border.Class = "TextBoxBorder";
            this.txtNroPart.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroPart.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroPart.ForeColor = System.Drawing.Color.Black;
            this.txtNroPart.Location = new System.Drawing.Point(138, 37);
            this.txtNroPart.Name = "txtNroPart";
            this.txtNroPart.PreventEnterBeep = true;
            this.txtNroPart.Size = new System.Drawing.Size(85, 22);
            this.txtNroPart.TabIndex = 71;
            // 
            // lblNroPartida
            // 
            // 
            // 
            // 
            this.lblNroPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPartida.Location = new System.Drawing.Point(12, 37);
            this.lblNroPartida.Name = "lblNroPartida";
            this.lblNroPartida.Size = new System.Drawing.Size(97, 22);
            this.lblNroPartida.TabIndex = 72;
            this.lblNroPartida.Text = "lblNroPartida";
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
            this.txtDependencia.ForeColor = System.Drawing.Color.Black;
            this.txtDependencia.Location = new System.Drawing.Point(138, 93);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(298, 22);
            this.txtDependencia.TabIndex = 69;
            this.txtDependencia.TextChanged += new System.EventHandler(this.txtDependencia_TextChanged);
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(12, 93);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(110, 22);
            this.lblDependencia.TabIndex = 70;
            this.lblDependencia.Text = "lblDependencia";
            // 
            // txtNroSolic
            // 
            this.txtNroSolic.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroSolic.Border.Class = "TextBoxBorder";
            this.txtNroSolic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroSolic.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroSolic.ForeColor = System.Drawing.Color.Black;
            this.txtNroSolic.Location = new System.Drawing.Point(138, 65);
            this.txtNroSolic.Name = "txtNroSolic";
            this.txtNroSolic.PreventEnterBeep = true;
            this.txtNroSolic.Size = new System.Drawing.Size(85, 22);
            this.txtNroSolic.TabIndex = 67;
            // 
            // lblNroSolic
            // 
            // 
            // 
            // 
            this.lblNroSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolic.Location = new System.Drawing.Point(12, 65);
            this.lblNroSolic.Name = "lblNroSolic";
            this.lblNroSolic.Size = new System.Drawing.Size(97, 22);
            this.lblNroSolic.TabIndex = 68;
            this.lblNroSolic.Text = "lblNroSolic";
            // 
            // txtNroRendicion
            // 
            this.txtNroRendicion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroRendicion.Border.Class = "TextBoxBorder";
            this.txtNroRendicion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroRendicion.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroRendicion.ForeColor = System.Drawing.Color.Black;
            this.txtNroRendicion.Location = new System.Drawing.Point(138, 9);
            this.txtNroRendicion.Name = "txtNroRendicion";
            this.txtNroRendicion.PreventEnterBeep = true;
            this.txtNroRendicion.Size = new System.Drawing.Size(85, 22);
            this.txtNroRendicion.TabIndex = 74;
            // 
            // lblNroRendicion
            // 
            // 
            // 
            // 
            this.lblNroRendicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroRendicion.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroRendicion.Location = new System.Drawing.Point(12, 9);
            this.lblNroRendicion.Name = "lblNroRendicion";
            this.lblNroRendicion.Size = new System.Drawing.Size(120, 22);
            this.lblNroRendicion.TabIndex = 75;
            this.lblNroRendicion.Text = "lblNroRendicion";
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(12, 172);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n\\viewkind4\\uc1\\pard\\la" +
    "ng11274\\ul\\b\\f0\\fs24 No hay resultados\\par\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(739, 244);
            this.txtResBusqueda.TabIndex = 76;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // GrillaRendicionBuscar
            // 
            this.GrillaRendicionBuscar.AllowUserToAddRows = false;
            this.GrillaRendicionBuscar.AllowUserToDeleteRows = false;
            this.GrillaRendicionBuscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaRendicionBuscar.BackgroundColor = System.Drawing.Color.White;
            this.GrillaRendicionBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaRendicionBuscar.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaRendicionBuscar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaRendicionBuscar.Location = new System.Drawing.Point(12, 172);
            this.GrillaRendicionBuscar.Name = "GrillaRendicionBuscar";
            this.GrillaRendicionBuscar.ReadOnly = true;
            this.GrillaRendicionBuscar.Size = new System.Drawing.Size(739, 244);
            this.GrillaRendicionBuscar.TabIndex = 77;
            this.GrillaRendicionBuscar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaRendicionBuscar_CellDoubleClick);
            // 
            // cboDep
            // 
            this.cboDep.DisplayMember = "Text";
            this.cboDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDep.ForeColor = System.Drawing.Color.Black;
            this.cboDep.FormattingEnabled = true;
            this.cboDep.ItemHeight = 16;
            this.cboDep.Location = new System.Drawing.Point(138, 93);
            this.cboDep.Name = "cboDep";
            this.cboDep.Size = new System.Drawing.Size(298, 22);
            this.cboDep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDep.TabIndex = 78;
            this.cboDep.SelectionChangeCommitted += new System.EventHandler(this.cboDep_SelectionChangeCommitted);
            // 
            // frmRendicionBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 513);
            this.Controls.Add(this.txtNroRendicion);
            this.Controls.Add(this.lblNroRendicion);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNroPart);
            this.Controls.Add(this.lblNroPartida);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtNroSolic);
            this.Controls.Add(this.lblNroSolic);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.cboDep);
            this.Controls.Add(this.GrillaRendicionBuscar);
            this.Controls.Add(this.txtResBusqueda);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRendicionBuscar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmRendicionBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaRendicionBuscar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPart;
        private DevComponents.DotNetBar.LabelX lblNroPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolic;
        private DevComponents.DotNetBar.LabelX lblNroSolic;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroRendicion;
        private DevComponents.DotNetBar.LabelX lblNroRendicion;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaRendicionBuscar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDep;

    }
}