namespace ARTEC.GUI
{
    partial class frmDVRecomponer
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
            this.btnRecomponerDV = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnRecomponerDV
            // 
            this.btnRecomponerDV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRecomponerDV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRecomponerDV.Location = new System.Drawing.Point(104, 32);
            this.btnRecomponerDV.Name = "btnRecomponerDV";
            this.btnRecomponerDV.Size = new System.Drawing.Size(110, 41);
            this.btnRecomponerDV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRecomponerDV.TabIndex = 0;
            this.btnRecomponerDV.Text = "btnRecomponerDV";
            this.btnRecomponerDV.Click += new System.EventHandler(this.btnRecomponerDV_Click);
            // 
            // frmDVRecomponer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 135);
            this.Controls.Add(this.btnRecomponerDV);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmDVRecomponer";
            this.Text = "MetroForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnRecomponerDV;
    }
}