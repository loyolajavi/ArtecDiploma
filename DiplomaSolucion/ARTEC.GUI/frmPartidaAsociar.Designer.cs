namespace ARTEC.GUI
{
    partial class frmPartidaAsociar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.txtIdPartida = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIdPartida = new DevComponents.DotNetBar.LabelX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.grillaPartidas = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.grillaDetallesPart = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartAsignada = new DevComponents.DotNetBar.LabelX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoAcreditado = new DevComponents.DotNetBar.LabelX();
            this.btnAsociar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(469, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 22);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtIdPartida
            // 
            this.txtIdPartida.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIdPartida.Border.Class = "TextBoxBorder";
            this.txtIdPartida.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdPartida.DisabledBackColor = System.Drawing.Color.White;
            this.txtIdPartida.ForeColor = System.Drawing.Color.Black;
            this.txtIdPartida.Location = new System.Drawing.Point(12, 35);
            this.txtIdPartida.Multiline = true;
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.PreventEnterBeep = true;
            this.txtIdPartida.Size = new System.Drawing.Size(102, 22);
            this.txtIdPartida.TabIndex = 31;
            // 
            // lblIdPartida
            // 
            // 
            // 
            // 
            this.lblIdPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPartida.Location = new System.Drawing.Point(12, 12);
            this.lblIdPartida.Name = "lblIdPartida";
            this.lblIdPartida.Size = new System.Drawing.Size(102, 17);
            this.lblIdPartida.TabIndex = 30;
            this.lblIdPartida.Text = "lblIdPartida";
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(135, 12);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(91, 17);
            this.lblDependencia.TabIndex = 27;
            this.lblDependencia.Text = "Dependencia";
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
            this.txtDependencia.Location = new System.Drawing.Point(135, 35);
            this.txtDependencia.Multiline = true;
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.Size = new System.Drawing.Size(284, 22);
            this.txtDependencia.TabIndex = 28;
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(135, 35);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(315, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 29;
            this.comboBoxEx4.Visible = false;
            // 
            // grillaPartidas
            // 
            this.grillaPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaPartidas.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaPartidas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaPartidas.Location = new System.Drawing.Point(13, 84);
            this.grillaPartidas.Name = "grillaPartidas";
            this.grillaPartidas.Size = new System.Drawing.Size(531, 92);
            this.grillaPartidas.TabIndex = 33;
            // 
            // grillaDetallesPart
            // 
            this.grillaDetallesPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaDetallesPart.DefaultCellStyle = dataGridViewCellStyle2;
            this.grillaDetallesPart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaDetallesPart.Location = new System.Drawing.Point(13, 199);
            this.grillaDetallesPart.Name = "grillaDetallesPart";
            this.grillaDetallesPart.Size = new System.Drawing.Size(531, 92);
            this.grillaDetallesPart.TabIndex = 34;
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(148, 310);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(102, 22);
            this.textBoxX1.TabIndex = 36;
            // 
            // lblNroPartAsignada
            // 
            // 
            // 
            // 
            this.lblNroPartAsignada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroPartAsignada.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPartAsignada.Location = new System.Drawing.Point(12, 315);
            this.lblNroPartAsignada.Name = "lblNroPartAsignada";
            this.lblNroPartAsignada.Size = new System.Drawing.Size(130, 17);
            this.lblNroPartAsignada.TabIndex = 35;
            this.lblNroPartAsignada.Text = "lblNroPartAsignada";
            this.lblNroPartAsignada.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // textBoxX2
            // 
            this.textBoxX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX2.ForeColor = System.Drawing.Color.Black;
            this.textBoxX2.Location = new System.Drawing.Point(437, 310);
            this.textBoxX2.Multiline = true;
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(102, 22);
            this.textBoxX2.TabIndex = 38;
            // 
            // lblMontoAcreditado
            // 
            // 
            // 
            // 
            this.lblMontoAcreditado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoAcreditado.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoAcreditado.Location = new System.Drawing.Point(302, 315);
            this.lblMontoAcreditado.Name = "lblMontoAcreditado";
            this.lblMontoAcreditado.Size = new System.Drawing.Size(129, 17);
            this.lblMontoAcreditado.TabIndex = 37;
            this.lblMontoAcreditado.Text = "lblMontoAcreditado";
            // 
            // btnAsociar
            // 
            this.btnAsociar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAsociar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAsociar.Location = new System.Drawing.Point(229, 361);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(75, 23);
            this.btnAsociar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAsociar.TabIndex = 39;
            this.btnAsociar.Text = "btnAsociar";
            // 
            // frmPartidaAsociar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 396);
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.lblMontoAcreditado);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.lblNroPartAsignada);
            this.Controls.Add(this.grillaDetallesPart);
            this.Controls.Add(this.grillaPartidas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdPartida);
            this.Controls.Add(this.lblIdPartida);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.comboBoxEx4);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPartidaAsociar";
            this.Text = "MetroForm";
            ((System.ComponentModel.ISupportInitialize)(this.grillaPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetallesPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdPartida;
        private DevComponents.DotNetBar.LabelX lblIdPartida;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaPartidas;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetallesPart;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX lblNroPartAsignada;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.LabelX lblMontoAcreditado;
        private DevComponents.DotNetBar.ButtonX btnAsociar;
    }
}