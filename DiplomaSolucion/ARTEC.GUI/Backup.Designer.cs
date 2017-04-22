namespace ARTEC.GUI
{
    partial class Backup
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
            this.gboxRespaldar = new System.Windows.Forms.GroupBox();
            this.btnRespaldar = new DevComponents.DotNetBar.ButtonX();
            this.btnExaminarRespaldar = new DevComponents.DotNetBar.ButtonX();
            this.txtObservaciones = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblObservaciones = new DevComponents.DotNetBar.LabelX();
            this.txtDestino = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNombreRespaldar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDestinoRespaldar = new DevComponents.DotNetBar.LabelX();
            this.lblNombreRespaldar = new DevComponents.DotNetBar.LabelX();
            this.gboxRestaurar = new System.Windows.Forms.GroupBox();
            this.btnRestaurar = new DevComponents.DotNetBar.ButtonX();
            this.btnExaminarRestaurar = new DevComponents.DotNetBar.ButtonX();
            this.txtUbicacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNombreRestaurar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblUbicacionRestaurar = new DevComponents.DotNetBar.LabelX();
            this.lblNombreRestaurar = new DevComponents.DotNetBar.LabelX();
            this.gboxRespaldar.SuspendLayout();
            this.gboxRestaurar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxRespaldar
            // 
            this.gboxRespaldar.Controls.Add(this.btnRespaldar);
            this.gboxRespaldar.Controls.Add(this.btnExaminarRespaldar);
            this.gboxRespaldar.Controls.Add(this.txtObservaciones);
            this.gboxRespaldar.Controls.Add(this.lblObservaciones);
            this.gboxRespaldar.Controls.Add(this.txtDestino);
            this.gboxRespaldar.Controls.Add(this.txtNombreRespaldar);
            this.gboxRespaldar.Controls.Add(this.lblDestinoRespaldar);
            this.gboxRespaldar.Controls.Add(this.lblNombreRespaldar);
            this.gboxRespaldar.Location = new System.Drawing.Point(12, 12);
            this.gboxRespaldar.Name = "gboxRespaldar";
            this.gboxRespaldar.Size = new System.Drawing.Size(503, 193);
            this.gboxRespaldar.TabIndex = 1;
            this.gboxRespaldar.TabStop = false;
            this.gboxRespaldar.Text = "Respaldar (Realizar Backup)";
            // 
            // btnRespaldar
            // 
            this.btnRespaldar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRespaldar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRespaldar.Location = new System.Drawing.Point(213, 157);
            this.btnRespaldar.Name = "btnRespaldar";
            this.btnRespaldar.Size = new System.Drawing.Size(75, 23);
            this.btnRespaldar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRespaldar.TabIndex = 2;
            this.btnRespaldar.Text = "Respaldar";
            this.btnRespaldar.Click += new System.EventHandler(this.btnRespaldar_Click);
            // 
            // btnExaminarRespaldar
            // 
            this.btnExaminarRespaldar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExaminarRespaldar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExaminarRespaldar.Location = new System.Drawing.Point(412, 57);
            this.btnExaminarRespaldar.Name = "btnExaminarRespaldar";
            this.btnExaminarRespaldar.Size = new System.Drawing.Size(75, 22);
            this.btnExaminarRespaldar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExaminarRespaldar.TabIndex = 6;
            this.btnExaminarRespaldar.Text = "Examinar";
            this.btnExaminarRespaldar.Click += new System.EventHandler(this.btnExaminarRespaldar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtObservaciones.Border.Class = "TextBoxBorder";
            this.txtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtObservaciones.DisabledBackColor = System.Drawing.Color.White;
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(90, 91);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PreventEnterBeep = true;
            this.txtObservaciones.Size = new System.Drawing.Size(316, 50);
            this.txtObservaciones.TabIndex = 5;
            // 
            // lblObservaciones
            // 
            // 
            // 
            // 
            this.lblObservaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblObservaciones.Location = new System.Drawing.Point(11, 102);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(75, 23);
            this.lblObservaciones.TabIndex = 4;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDestino.Border.Class = "TextBoxBorder";
            this.txtDestino.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDestino.DisabledBackColor = System.Drawing.Color.White;
            this.txtDestino.ForeColor = System.Drawing.Color.Black;
            this.txtDestino.Location = new System.Drawing.Point(90, 57);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.PreventEnterBeep = true;
            this.txtDestino.Size = new System.Drawing.Size(316, 22);
            this.txtDestino.TabIndex = 3;
            // 
            // txtNombreRespaldar
            // 
            this.txtNombreRespaldar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombreRespaldar.Border.Class = "TextBoxBorder";
            this.txtNombreRespaldar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombreRespaldar.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombreRespaldar.ForeColor = System.Drawing.Color.Black;
            this.txtNombreRespaldar.Location = new System.Drawing.Point(90, 22);
            this.txtNombreRespaldar.Name = "txtNombreRespaldar";
            this.txtNombreRespaldar.PreventEnterBeep = true;
            this.txtNombreRespaldar.Size = new System.Drawing.Size(158, 22);
            this.txtNombreRespaldar.TabIndex = 2;
            // 
            // lblDestinoRespaldar
            // 
            // 
            // 
            // 
            this.lblDestinoRespaldar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDestinoRespaldar.Location = new System.Drawing.Point(11, 56);
            this.lblDestinoRespaldar.Name = "lblDestinoRespaldar";
            this.lblDestinoRespaldar.Size = new System.Drawing.Size(55, 23);
            this.lblDestinoRespaldar.TabIndex = 1;
            this.lblDestinoRespaldar.Text = "Destino";
            // 
            // lblNombreRespaldar
            // 
            // 
            // 
            // 
            this.lblNombreRespaldar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombreRespaldar.Location = new System.Drawing.Point(11, 23);
            this.lblNombreRespaldar.Name = "lblNombreRespaldar";
            this.lblNombreRespaldar.Size = new System.Drawing.Size(55, 23);
            this.lblNombreRespaldar.TabIndex = 0;
            this.lblNombreRespaldar.Text = "Nombre";
            // 
            // gboxRestaurar
            // 
            this.gboxRestaurar.Controls.Add(this.btnRestaurar);
            this.gboxRestaurar.Controls.Add(this.btnExaminarRestaurar);
            this.gboxRestaurar.Controls.Add(this.txtUbicacion);
            this.gboxRestaurar.Controls.Add(this.txtNombreRestaurar);
            this.gboxRestaurar.Controls.Add(this.lblUbicacionRestaurar);
            this.gboxRestaurar.Controls.Add(this.lblNombreRestaurar);
            this.gboxRestaurar.Location = new System.Drawing.Point(12, 225);
            this.gboxRestaurar.Name = "gboxRestaurar";
            this.gboxRestaurar.Size = new System.Drawing.Size(503, 132);
            this.gboxRestaurar.TabIndex = 7;
            this.gboxRestaurar.TabStop = false;
            this.gboxRestaurar.Text = "Restaurar";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRestaurar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRestaurar.Location = new System.Drawing.Point(213, 98);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(75, 23);
            this.btnRestaurar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRestaurar.TabIndex = 2;
            this.btnRestaurar.Text = "Restaurar";
            // 
            // btnExaminarRestaurar
            // 
            this.btnExaminarRestaurar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExaminarRestaurar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExaminarRestaurar.Location = new System.Drawing.Point(412, 63);
            this.btnExaminarRestaurar.Name = "btnExaminarRestaurar";
            this.btnExaminarRestaurar.Size = new System.Drawing.Size(75, 22);
            this.btnExaminarRestaurar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExaminarRestaurar.TabIndex = 6;
            this.btnExaminarRestaurar.Text = "Examinar";
            this.btnExaminarRestaurar.Click += new System.EventHandler(this.btnExaminarRestaurar_Click);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUbicacion.Border.Class = "TextBoxBorder";
            this.txtUbicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUbicacion.DisabledBackColor = System.Drawing.Color.White;
            this.txtUbicacion.ForeColor = System.Drawing.Color.Black;
            this.txtUbicacion.Location = new System.Drawing.Point(90, 63);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.PreventEnterBeep = true;
            this.txtUbicacion.Size = new System.Drawing.Size(316, 22);
            this.txtUbicacion.TabIndex = 3;
            // 
            // txtNombreRestaurar
            // 
            this.txtNombreRestaurar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombreRestaurar.Border.Class = "TextBoxBorder";
            this.txtNombreRestaurar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombreRestaurar.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombreRestaurar.ForeColor = System.Drawing.Color.Black;
            this.txtNombreRestaurar.Location = new System.Drawing.Point(90, 30);
            this.txtNombreRestaurar.Name = "txtNombreRestaurar";
            this.txtNombreRestaurar.PreventEnterBeep = true;
            this.txtNombreRestaurar.Size = new System.Drawing.Size(158, 22);
            this.txtNombreRestaurar.TabIndex = 2;
            // 
            // lblUbicacionRestaurar
            // 
            // 
            // 
            // 
            this.lblUbicacionRestaurar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUbicacionRestaurar.Location = new System.Drawing.Point(11, 62);
            this.lblUbicacionRestaurar.Name = "lblUbicacionRestaurar";
            this.lblUbicacionRestaurar.Size = new System.Drawing.Size(75, 23);
            this.lblUbicacionRestaurar.TabIndex = 1;
            this.lblUbicacionRestaurar.Text = "Ubicación";
            // 
            // lblNombreRestaurar
            // 
            // 
            // 
            // 
            this.lblNombreRestaurar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombreRestaurar.Location = new System.Drawing.Point(11, 29);
            this.lblNombreRestaurar.Name = "lblNombreRestaurar";
            this.lblNombreRestaurar.Size = new System.Drawing.Size(103, 23);
            this.lblNombreRestaurar.TabIndex = 0;
            this.lblNombreRestaurar.Text = "Nombre";
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 379);
            this.Controls.Add(this.gboxRestaurar);
            this.Controls.Add(this.gboxRespaldar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Backup";
            this.Text = "Respaldo y Restauración de la BD";
            this.gboxRespaldar.ResumeLayout(false);
            this.gboxRestaurar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxRespaldar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDestino;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombreRespaldar;
        private DevComponents.DotNetBar.LabelX lblDestinoRespaldar;
        private DevComponents.DotNetBar.LabelX lblNombreRespaldar;
        private DevComponents.DotNetBar.ButtonX btnRespaldar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtObservaciones;
        private DevComponents.DotNetBar.LabelX lblObservaciones;
        private DevComponents.DotNetBar.ButtonX btnExaminarRespaldar;
        private System.Windows.Forms.GroupBox gboxRestaurar;
        private DevComponents.DotNetBar.ButtonX btnRestaurar;
        private DevComponents.DotNetBar.ButtonX btnExaminarRestaurar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUbicacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombreRestaurar;
        private DevComponents.DotNetBar.LabelX lblUbicacionRestaurar;
        private DevComponents.DotNetBar.LabelX lblNombreRestaurar;

    }
}