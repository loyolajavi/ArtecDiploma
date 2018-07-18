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
            this.tabPartidas = new System.Windows.Forms.TabPage();
            this.tabDependencia = new System.Windows.Forms.TabPage();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSolicitarPartida = new DevComponents.DotNetBar.ButtonX();
            this.btnPartidaAsociar = new DevComponents.DotNetBar.ButtonX();
            this.btnBienRegistrar = new DevComponents.DotNetBar.ButtonX();
            this.btnRendicionCrear = new DevComponents.DotNetBar.ButtonX();
            this.cboIdioma = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnBienes = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnBitacora = new DevComponents.DotNetBar.ButtonX();
            this.btnBackup = new DevComponents.DotNetBar.ButtonX();
            this.btnUsuarios = new DevComponents.DotNetBar.ButtonX();
            this.btnVolver = new DevComponents.DotNetBar.ButtonX();
            this.btnAvanzadas = new DevComponents.DotNetBar.ButtonX();
            this.tabsPrincipal.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPrincipal
            // 
            this.tabsPrincipal.Controls.Add(this.tabSolic);
            this.tabsPrincipal.Controls.Add(this.tabHomol);
            this.tabsPrincipal.Controls.Add(this.tabPartidas);
            this.tabsPrincipal.Controls.Add(this.tabDependencia);
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
            this.tabSolic.Text = "Solicitudes";
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
            // tabPartidas
            // 
            this.tabPartidas.Location = new System.Drawing.Point(4, 22);
            this.tabPartidas.Name = "tabPartidas";
            this.tabPartidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPartidas.Size = new System.Drawing.Size(1335, 635);
            this.tabPartidas.TabIndex = 2;
            this.tabPartidas.Text = "tabPartidas";
            this.tabPartidas.UseVisualStyleBackColor = true;
            // 
            // tabDependencia
            // 
            this.tabDependencia.Location = new System.Drawing.Point(4, 22);
            this.tabDependencia.Name = "tabDependencia";
            this.tabDependencia.Padding = new System.Windows.Forms.Padding(3);
            this.tabDependencia.Size = new System.Drawing.Size(1335, 635);
            this.tabDependencia.TabIndex = 3;
            this.tabDependencia.Text = "tabDependencia";
            this.tabDependencia.UseVisualStyleBackColor = true;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX1.CustomColorName = "Blue";
            this.buttonX1.Location = new System.Drawing.Point(380, 13);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(87, 40);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "Crear Solicitud";
            this.buttonX1.TextColor = System.Drawing.Color.White;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnSolicitarPartida
            // 
            this.btnSolicitarPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSolicitarPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSolicitarPartida.CustomColorName = "blue";
            this.btnSolicitarPartida.Location = new System.Drawing.Point(492, 13);
            this.btnSolicitarPartida.Name = "btnSolicitarPartida";
            this.btnSolicitarPartida.Size = new System.Drawing.Size(87, 40);
            this.btnSolicitarPartida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSolicitarPartida.TabIndex = 2;
            this.btnSolicitarPartida.Text = "btnSolicitarPartida";
            this.btnSolicitarPartida.Click += new System.EventHandler(this.btnSolicitarPartida_Click);
            // 
            // btnPartidaAsociar
            // 
            this.btnPartidaAsociar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPartidaAsociar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPartidaAsociar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnPartidaAsociar.CustomColorName = "Blue";
            this.btnPartidaAsociar.Location = new System.Drawing.Point(612, 13);
            this.btnPartidaAsociar.Name = "btnPartidaAsociar";
            this.btnPartidaAsociar.Size = new System.Drawing.Size(87, 40);
            this.btnPartidaAsociar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPartidaAsociar.TabIndex = 3;
            this.btnPartidaAsociar.Text = "btnPartidaAsociar";
            this.btnPartidaAsociar.TextColor = System.Drawing.Color.White;
            this.btnPartidaAsociar.Click += new System.EventHandler(this.btnPartidaAsociar_Click);
            // 
            // btnBienRegistrar
            // 
            this.btnBienRegistrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBienRegistrar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBienRegistrar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnBienRegistrar.CustomColorName = "Blue";
            this.btnBienRegistrar.Location = new System.Drawing.Point(729, 13);
            this.btnBienRegistrar.Name = "btnBienRegistrar";
            this.btnBienRegistrar.Size = new System.Drawing.Size(87, 40);
            this.btnBienRegistrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBienRegistrar.TabIndex = 4;
            this.btnBienRegistrar.Text = "btnBienRegistrar";
            this.btnBienRegistrar.TextColor = System.Drawing.Color.White;
            this.btnBienRegistrar.Click += new System.EventHandler(this.btnBienRegistrar_Click);
            // 
            // btnRendicionCrear
            // 
            this.btnRendicionCrear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRendicionCrear.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRendicionCrear.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnRendicionCrear.CustomColorName = "Blue";
            this.btnRendicionCrear.Location = new System.Drawing.Point(845, 13);
            this.btnRendicionCrear.Name = "btnRendicionCrear";
            this.btnRendicionCrear.Size = new System.Drawing.Size(108, 40);
            this.btnRendicionCrear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRendicionCrear.TabIndex = 5;
            this.btnRendicionCrear.Text = "btnRendicionCrear";
            this.btnRendicionCrear.TextColor = System.Drawing.Color.White;
            this.btnRendicionCrear.Click += new System.EventHandler(this.btnRendicionCrear_Click);
            // 
            // cboIdioma
            // 
            this.cboIdioma.DisplayMember = "Text";
            this.cboIdioma.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboIdioma.ForeColor = System.Drawing.Color.Black;
            this.cboIdioma.FormattingEnabled = true;
            this.cboIdioma.ItemHeight = 16;
            this.cboIdioma.Location = new System.Drawing.Point(1230, 53);
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(121, 22);
            this.cboIdioma.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboIdioma.TabIndex = 6;
            this.cboIdioma.SelectionChangeCommitted += new System.EventHandler(this.cboIdioma_SelectionChangeCommitted);
            // 
            // btnBienes
            // 
            this.btnBienes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBienes.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBienes.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnBienes.CustomColorName = "Blue";
            this.btnBienes.Location = new System.Drawing.Point(977, 13);
            this.btnBienes.Name = "btnBienes";
            this.btnBienes.Size = new System.Drawing.Size(108, 40);
            this.btnBienes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBienes.TabIndex = 7;
            this.btnBienes.Text = "btnBienes";
            this.btnBienes.TextColor = System.Drawing.Color.White;
            this.btnBienes.Click += new System.EventHandler(this.btnBienesCat_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnBitacora);
            this.panelEx1.Controls.Add(this.btnBackup);
            this.panelEx1.Controls.Add(this.btnUsuarios);
            this.panelEx1.Controls.Add(this.btnVolver);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(12, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1212, 52);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 8;
            this.panelEx1.Text = "panelEx1";
            this.panelEx1.Visible = false;
            // 
            // btnBitacora
            // 
            this.btnBitacora.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBitacora.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBitacora.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnBitacora.CustomColorName = "Blue";
            this.btnBitacora.Location = new System.Drawing.Point(751, 9);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(108, 40);
            this.btnBitacora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBitacora.TabIndex = 11;
            this.btnBitacora.Text = "btnBitacora";
            this.btnBitacora.TextColor = System.Drawing.Color.White;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBackup.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBackup.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnBackup.CustomColorName = "Blue";
            this.btnBackup.Location = new System.Drawing.Point(600, 9);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(108, 40);
            this.btnBackup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBackup.TabIndex = 10;
            this.btnBackup.Text = "btnBackup";
            this.btnBackup.TextColor = System.Drawing.Color.White;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUsuarios.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUsuarios.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnUsuarios.CustomColorName = "Blue";
            this.btnUsuarios.Location = new System.Drawing.Point(456, 9);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(108, 40);
            this.btnUsuarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUsuarios.TabIndex = 9;
            this.btnUsuarios.Text = "btnUsuarios";
            this.btnUsuarios.TextColor = System.Drawing.Color.White;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVolver.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVolver.Location = new System.Drawing.Point(22, 16);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "btnVolver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAvanzadas
            // 
            this.btnAvanzadas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAvanzadas.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAvanzadas.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAvanzadas.CustomColorName = "Blue";
            this.btnAvanzadas.Location = new System.Drawing.Point(1111, 13);
            this.btnAvanzadas.Name = "btnAvanzadas";
            this.btnAvanzadas.Size = new System.Drawing.Size(108, 40);
            this.btnAvanzadas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAvanzadas.TabIndex = 8;
            this.btnAvanzadas.Text = "btnAvanzadas";
            this.btnAvanzadas.TextColor = System.Drawing.Color.White;
            this.btnAvanzadas.Click += new System.EventHandler(this.btnAvanzadas_Click_1);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 732);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.btnBienes);
            this.Controls.Add(this.cboIdioma);
            this.Controls.Add(this.btnRendicionCrear);
            this.Controls.Add(this.btnBienRegistrar);
            this.Controls.Add(this.btnPartidaAsociar);
            this.Controls.Add(this.btnSolicitarPartida);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.tabsPrincipal);
            this.Controls.Add(this.btnAvanzadas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARTEC";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tabsPrincipal.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsPrincipal;
        private System.Windows.Forms.TabPage tabSolic;
        private System.Windows.Forms.TabPage tabHomol;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnSolicitarPartida;
        private DevComponents.DotNetBar.ButtonX btnPartidaAsociar;
        private DevComponents.DotNetBar.ButtonX btnBienRegistrar;
        private DevComponents.DotNetBar.ButtonX btnRendicionCrear;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIdioma;
        private System.Windows.Forms.TabPage tabPartidas;
        private System.Windows.Forms.TabPage tabDependencia;
        private DevComponents.DotNetBar.ButtonX btnBienes;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnVolver;
        private DevComponents.DotNetBar.ButtonX btnAvanzadas;
        private DevComponents.DotNetBar.ButtonX btnBitacora;
        private DevComponents.DotNetBar.ButtonX btnBackup;
        private DevComponents.DotNetBar.ButtonX btnUsuarios;



    }
}