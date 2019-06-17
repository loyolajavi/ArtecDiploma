namespace ARTEC.GUI
{
    partial class frmNuevoIdioma
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrillaTextos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnCrear = new DevComponents.DotNetBar.ButtonX();
            this.lblIdioma = new DevComponents.DotNetBar.LabelX();
            this.txtNuevoIdioma = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaTextos)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaTextos
            // 
            this.GrillaTextos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaTextos.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaTextos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaTextos.Location = new System.Drawing.Point(12, 53);
            this.GrillaTextos.Name = "GrillaTextos";
            this.GrillaTextos.Size = new System.Drawing.Size(529, 341);
            this.GrillaTextos.TabIndex = 0;
            // 
            // btnCrear
            // 
            this.btnCrear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrear.Location = new System.Drawing.Point(235, 411);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lblIdioma
            // 
            // 
            // 
            // 
            this.lblIdioma.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdioma.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdioma.Location = new System.Drawing.Point(12, 13);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(72, 17);
            this.lblIdioma.TabIndex = 64;
            this.lblIdioma.Text = "Idioma";
            // 
            // txtNuevoIdioma
            // 
            this.txtNuevoIdioma.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNuevoIdioma.Border.Class = "TextBoxBorder";
            this.txtNuevoIdioma.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNuevoIdioma.DisabledBackColor = System.Drawing.Color.White;
            this.txtNuevoIdioma.ForeColor = System.Drawing.Color.Black;
            this.txtNuevoIdioma.Location = new System.Drawing.Point(90, 11);
            this.txtNuevoIdioma.Name = "txtNuevoIdioma";
            this.txtNuevoIdioma.PreventEnterBeep = true;
            this.txtNuevoIdioma.Size = new System.Drawing.Size(285, 22);
            this.txtNuevoIdioma.TabIndex = 65;
            // 
            // frmNuevoIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 446);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.txtNuevoIdioma);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.GrillaTextos);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNuevoIdioma";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmNuevoIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaTextos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaTextos;
        private DevComponents.DotNetBar.ButtonX btnCrear;
        private DevComponents.DotNetBar.LabelX lblIdioma;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNuevoIdioma;
    }
}