namespace ARTEC.GUI
{
    partial class Principal
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
            this.tabsPrincipal = new System.Windows.Forms.TabControl();
            this.tabSolic = new System.Windows.Forms.TabPage();
            this.tabHomol = new System.Windows.Forms.TabPage();
            this.tabsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPrincipal
            // 
            this.tabsPrincipal.Controls.Add(this.tabSolic);
            this.tabsPrincipal.Controls.Add(this.tabHomol);
            this.tabsPrincipal.Location = new System.Drawing.Point(12, 59);
            this.tabsPrincipal.Name = "tabsPrincipal";
            this.tabsPrincipal.SelectedIndex = 0;
            this.tabsPrincipal.Size = new System.Drawing.Size(1343, 661);
            this.tabsPrincipal.TabIndex = 0;
            this.tabsPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabsPrincipal_SelectedIndexChanged);
            // 
            // tabSolic
            // 
            this.tabSolic.Location = new System.Drawing.Point(4, 22);
            this.tabSolic.Name = "tabSolic";
            this.tabSolic.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolic.Size = new System.Drawing.Size(1335, 635);
            this.tabSolic.TabIndex = 0;
            this.tabSolic.Text = "tabPage1";
            this.tabSolic.UseVisualStyleBackColor = true;
            // 
            // tabHomol
            // 
            this.tabHomol.Location = new System.Drawing.Point(4, 22);
            this.tabHomol.Name = "tabHomol";
            this.tabHomol.Padding = new System.Windows.Forms.Padding(3);
            this.tabHomol.Size = new System.Drawing.Size(1335, 635);
            this.tabHomol.TabIndex = 1;
            this.tabHomol.Text = "tabPage2";
            this.tabHomol.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 732);
            this.Controls.Add(this.tabsPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Principal";
            this.Text = "ARTEC";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tabsPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsPrincipal;
        private System.Windows.Forms.TabPage tabSolic;
        private System.Windows.Forms.TabPage tabHomol;



    }
}