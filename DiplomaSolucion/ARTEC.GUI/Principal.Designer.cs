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
            this.tabRendiciones = new System.Windows.Forms.TabPage();
            this.tabPartidas = new System.Windows.Forms.TabPage();
            this.tabDependencia = new System.Windows.Forms.TabPage();
            this.tabAsignaciones = new System.Windows.Forms.TabPage();
            this.tabAdquisiciones = new System.Windows.Forms.TabPage();
            this.btnCrearSolicitud = new DevComponents.DotNetBar.ButtonX();
            this.btnSolicitarPartida = new DevComponents.DotNetBar.ButtonX();
            this.btnPartidaAsociar = new DevComponents.DotNetBar.ButtonX();
            this.btnBienRegistrar = new DevComponents.DotNetBar.ButtonX();
            this.btnRendicionCrear = new DevComponents.DotNetBar.ButtonX();
            this.cboIdioma = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAgentes = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnFamilias = new DevComponents.DotNetBar.ButtonX();
            this.btnBitacora = new DevComponents.DotNetBar.ButtonX();
            this.btnBackup = new DevComponents.DotNetBar.ButtonX();
            this.btnUsuarios = new DevComponents.DotNetBar.ButtonX();
            this.btnVolver = new DevComponents.DotNetBar.ButtonX();
            this.btnAvanzadas = new DevComponents.DotNetBar.ButtonX();
            this.btnCategorias = new DevComponents.DotNetBar.ButtonX();
            this.btnProveedor = new DevComponents.DotNetBar.ButtonX();
            this.tabsPrincipal.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPrincipal
            // 
            this.tabsPrincipal.Controls.Add(this.tabSolic);
            this.tabsPrincipal.Controls.Add(this.tabRendiciones);
            this.tabsPrincipal.Controls.Add(this.tabPartidas);
            this.tabsPrincipal.Controls.Add(this.tabDependencia);
            this.tabsPrincipal.Controls.Add(this.tabAsignaciones);
            this.tabsPrincipal.Controls.Add(this.tabAdquisiciones);
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
            // tabRendiciones
            // 
            this.tabRendiciones.Location = new System.Drawing.Point(4, 22);
            this.tabRendiciones.Name = "tabRendiciones";
            this.tabRendiciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabRendiciones.Size = new System.Drawing.Size(1335, 635);
            this.tabRendiciones.TabIndex = 1;
            this.tabRendiciones.Text = "tabRendiciones";
            this.tabRendiciones.UseVisualStyleBackColor = true;
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
            // tabAsignaciones
            // 
            this.tabAsignaciones.Location = new System.Drawing.Point(4, 22);
            this.tabAsignaciones.Name = "tabAsignaciones";
            this.tabAsignaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsignaciones.Size = new System.Drawing.Size(1335, 635);
            this.tabAsignaciones.TabIndex = 4;
            this.tabAsignaciones.Text = "tabAsignaciones";
            this.tabAsignaciones.UseVisualStyleBackColor = true;
            // 
            // tabAdquisiciones
            // 
            this.tabAdquisiciones.Location = new System.Drawing.Point(4, 22);
            this.tabAdquisiciones.Name = "tabAdquisiciones";
            this.tabAdquisiciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdquisiciones.Size = new System.Drawing.Size(1335, 635);
            this.tabAdquisiciones.TabIndex = 5;
            this.tabAdquisiciones.Text = "tabAdquisiciones";
            this.tabAdquisiciones.UseVisualStyleBackColor = true;
            // 
            // btnCrearSolicitud
            // 
            this.btnCrearSolicitud.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearSolicitud.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCrearSolicitud.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCrearSolicitud.CustomColorName = "Blue";
            this.btnCrearSolicitud.Location = new System.Drawing.Point(128, 13);
            this.btnCrearSolicitud.Name = "btnCrearSolicitud";
            this.btnCrearSolicitud.Size = new System.Drawing.Size(87, 40);
            this.btnCrearSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearSolicitud.TabIndex = 1;
            this.btnCrearSolicitud.Tag = new string[] { "Solicitud Crear" };
            this.btnCrearSolicitud.Text = "Solicitud Crear";
            this.btnCrearSolicitud.TextColor = System.Drawing.Color.White;
            this.btnCrearSolicitud.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnSolicitarPartida
            // 
            this.btnSolicitarPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSolicitarPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSolicitarPartida.CustomColorName = "blue";
            this.btnSolicitarPartida.Location = new System.Drawing.Point(240, 13);
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
            this.btnPartidaAsociar.Location = new System.Drawing.Point(360, 13);
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
            this.btnBienRegistrar.Location = new System.Drawing.Point(477, 13);
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
            this.btnRendicionCrear.Location = new System.Drawing.Point(593, 13);
            this.btnRendicionCrear.Name = "btnRendicionCrear";
            this.btnRendicionCrear.Size = new System.Drawing.Size(108, 40);
            this.btnRendicionCrear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRendicionCrear.TabIndex = 5;
            this.btnRendicionCrear.Tag = new string[] { "Rendicion Crear" };
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
            // btnAgentes
            // 
            this.btnAgentes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgentes.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgentes.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAgentes.CustomColorName = "Blue";
            this.btnAgentes.Location = new System.Drawing.Point(725, 13);
            this.btnAgentes.Name = "btnAgentes";
            this.btnAgentes.Size = new System.Drawing.Size(108, 40);
            this.btnAgentes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgentes.TabIndex = 7;
            this.btnAgentes.Text = "btnAgentes";
            this.btnAgentes.TextColor = System.Drawing.Color.White;
            this.btnAgentes.Click += new System.EventHandler(this.btnAgentes_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnFamilias);
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
            // btnFamilias
            // 
            this.btnFamilias.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFamilias.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnFamilias.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnFamilias.CustomColorName = "Blue";
            this.btnFamilias.Location = new System.Drawing.Point(894, 9);
            this.btnFamilias.Name = "btnFamilias";
            this.btnFamilias.Size = new System.Drawing.Size(108, 40);
            this.btnFamilias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFamilias.TabIndex = 12;
            this.btnFamilias.Text = "btnFamilias";
            this.btnFamilias.TextColor = System.Drawing.Color.White;
            this.btnFamilias.Click += new System.EventHandler(this.btnFamilias_Click);
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
            this.btnAvanzadas.Location = new System.Drawing.Point(1114, 13);
            this.btnAvanzadas.Name = "btnAvanzadas";
            this.btnAvanzadas.Size = new System.Drawing.Size(108, 40);
            this.btnAvanzadas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAvanzadas.TabIndex = 8;
            this.btnAvanzadas.Text = "btnAvanzadas";
            this.btnAvanzadas.TextColor = System.Drawing.Color.White;
            this.btnAvanzadas.Click += new System.EventHandler(this.btnAvanzadas_Click_1);
            // 
            // btnCategorias
            // 
            this.btnCategorias.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCategorias.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCategorias.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCategorias.CustomColorName = "Blue";
            this.btnCategorias.Location = new System.Drawing.Point(853, 13);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(108, 40);
            this.btnCategorias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCategorias.TabIndex = 9;
            this.btnCategorias.Text = "btnCategorias";
            this.btnCategorias.TextColor = System.Drawing.Color.White;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnProveedor.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnProveedor.CustomColorName = "Blue";
            this.btnProveedor.Location = new System.Drawing.Point(982, 13);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(108, 40);
            this.btnProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnProveedor.TabIndex = 10;
            this.btnProveedor.Text = "btnProveedor";
            this.btnProveedor.TextColor = System.Drawing.Color.White;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 732);
            this.Controls.Add(this.btnProveedor);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnAgentes);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.cboIdioma);
            this.Controls.Add(this.btnRendicionCrear);
            this.Controls.Add(this.btnBienRegistrar);
            this.Controls.Add(this.btnPartidaAsociar);
            this.Controls.Add(this.btnSolicitarPartida);
            this.Controls.Add(this.btnCrearSolicitud);
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
        private System.Windows.Forms.TabPage tabRendiciones;
        private DevComponents.DotNetBar.ButtonX btnCrearSolicitud;
        private DevComponents.DotNetBar.ButtonX btnSolicitarPartida;
        private DevComponents.DotNetBar.ButtonX btnPartidaAsociar;
        private DevComponents.DotNetBar.ButtonX btnBienRegistrar;
        private DevComponents.DotNetBar.ButtonX btnRendicionCrear;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIdioma;
        private System.Windows.Forms.TabPage tabPartidas;
        private System.Windows.Forms.TabPage tabDependencia;
        private DevComponents.DotNetBar.ButtonX btnAgentes;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnVolver;
        private DevComponents.DotNetBar.ButtonX btnAvanzadas;
        private DevComponents.DotNetBar.ButtonX btnBitacora;
        private DevComponents.DotNetBar.ButtonX btnBackup;
        private DevComponents.DotNetBar.ButtonX btnUsuarios;
        private DevComponents.DotNetBar.ButtonX btnCategorias;
        private DevComponents.DotNetBar.ButtonX btnProveedor;
        private DevComponents.DotNetBar.ButtonX btnFamilias;
        private System.Windows.Forms.TabPage tabAsignaciones;
        private System.Windows.Forms.TabPage tabAdquisiciones;



    }
}