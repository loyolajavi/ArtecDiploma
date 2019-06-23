namespace ARTEC.GUI
{
    partial class frmRendicionCrear
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRendicionCrear));
            this.txtNroSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolic = new DevComponents.DotNetBar.LabelX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtNroPart = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartida = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtMontoOtorgado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoOtorgado = new DevComponents.DotNetBar.LabelX();
            this.txtMontoEmpleado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnCrear = new DevComponents.DotNetBar.ButtonX();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.flowInventariosRend = new System.Windows.Forms.FlowLayoutPanel();
            this.validlblNroPartida = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.vldIdPartida = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.vldNroSolic = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.vldTXTDependencia = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.VLDTXTMontoOtorgado = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.vldTXTMontoEmpleado = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.txtPartRef = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.txtNroSolic.Location = new System.Drawing.Point(106, 55);
            this.txtNroSolic.Name = "txtNroSolic";
            this.txtNroSolic.PreventEnterBeep = true;
            this.txtNroSolic.ReadOnly = true;
            this.txtNroSolic.Size = new System.Drawing.Size(85, 22);
            this.txtNroSolic.TabIndex = 48;
            // 
            // lblNroSolic
            // 
            // 
            // 
            // 
            this.lblNroSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolic.Location = new System.Drawing.Point(3, 55);
            this.lblNroSolic.Name = "lblNroSolic";
            this.lblNroSolic.Size = new System.Drawing.Size(97, 22);
            this.lblNroSolic.TabIndex = 49;
            this.lblNroSolic.Text = "lblNroSolic";
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(213, 55);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(110, 22);
            this.lblDependencia.TabIndex = 51;
            this.lblDependencia.Text = "lblDependencia";
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
            this.txtNroPart.Location = new System.Drawing.Point(106, 12);
            this.txtNroPart.Name = "txtNroPart";
            this.txtNroPart.PreventEnterBeep = true;
            this.txtNroPart.Size = new System.Drawing.Size(85, 22);
            this.txtNroPart.TabIndex = 52;
            this.validlblNroPartida.SetValidator1(this.txtNroPart, this.vldIdPartida);
            // 
            // lblNroPartida
            // 
            // 
            // 
            // 
            this.lblNroPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPartida.Location = new System.Drawing.Point(3, 12);
            this.lblNroPartida.Name = "lblNroPartida";
            this.lblNroPartida.Size = new System.Drawing.Size(97, 22);
            this.lblNroPartida.TabIndex = 53;
            this.lblNroPartida.Text = "lblNroPartida";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(3, 106);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(153, 22);
            this.labelX1.TabIndex = 55;
            this.labelX1.Text = "Partida Referenciada";
            // 
            // txtMontoOtorgado
            // 
            this.txtMontoOtorgado.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMontoOtorgado.Border.Class = "TextBoxBorder";
            this.txtMontoOtorgado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMontoOtorgado.DisabledBackColor = System.Drawing.Color.White;
            this.txtMontoOtorgado.ForeColor = System.Drawing.Color.Black;
            this.txtMontoOtorgado.Location = new System.Drawing.Point(162, 134);
            this.txtMontoOtorgado.Name = "txtMontoOtorgado";
            this.txtMontoOtorgado.PreventEnterBeep = true;
            this.txtMontoOtorgado.ReadOnly = true;
            this.txtMontoOtorgado.Size = new System.Drawing.Size(85, 22);
            this.txtMontoOtorgado.TabIndex = 56;
            // 
            // lblMontoOtorgado
            // 
            // 
            // 
            // 
            this.lblMontoOtorgado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoOtorgado.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoOtorgado.Location = new System.Drawing.Point(3, 134);
            this.lblMontoOtorgado.Name = "lblMontoOtorgado";
            this.lblMontoOtorgado.Size = new System.Drawing.Size(139, 22);
            this.lblMontoOtorgado.TabIndex = 57;
            this.lblMontoOtorgado.Text = "lblMontoOtorgado";
            // 
            // txtMontoEmpleado
            // 
            this.txtMontoEmpleado.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMontoEmpleado.Border.Class = "TextBoxBorder";
            this.txtMontoEmpleado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMontoEmpleado.DisabledBackColor = System.Drawing.Color.White;
            this.txtMontoEmpleado.ForeColor = System.Drawing.Color.Black;
            this.txtMontoEmpleado.Location = new System.Drawing.Point(162, 162);
            this.txtMontoEmpleado.Name = "txtMontoEmpleado";
            this.txtMontoEmpleado.PreventEnterBeep = true;
            this.txtMontoEmpleado.ReadOnly = true;
            this.txtMontoEmpleado.Size = new System.Drawing.Size(85, 22);
            this.txtMontoEmpleado.TabIndex = 58;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(3, 162);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(139, 22);
            this.labelX3.TabIndex = 59;
            this.labelX3.Text = "lblMontoEmpleado";
            // 
            // btnCrear
            // 
            this.btnCrear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrear.Enabled = false;
            this.btnCrear.Location = new System.Drawing.Point(275, 564);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrear.TabIndex = 65;
            this.btnCrear.Text = "btnCrear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(213, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 66;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // flowInventariosRend
            // 
            this.flowInventariosRend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowInventariosRend.AutoScroll = true;
            this.flowInventariosRend.BackColor = System.Drawing.Color.Transparent;
            this.flowInventariosRend.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowInventariosRend.Location = new System.Drawing.Point(3, 190);
            this.flowInventariosRend.Name = "flowInventariosRend";
            this.flowInventariosRend.Size = new System.Drawing.Size(635, 357);
            this.flowInventariosRend.TabIndex = 67;
            this.flowInventariosRend.WrapContents = false;
            // 
            // validlblNroPartida
            // 
            this.validlblNroPartida.ContainerControl = this;
            this.validlblNroPartida.ErrorProvider = this.errorProvider1;
            this.validlblNroPartida.Highlighter = this.highlighter1;
            this.validlblNroPartida.CustomValidatorValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.EventVldLblNroPartida);
            // 
            // vldIdPartida
            // 
            this.vldIdPartida.ErrorMessage = "Ingrese un Nro de Partida, deben ser sólo números";
            this.vldIdPartida.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // vldNroSolic
            // 
            this.vldNroSolic.ErrorMessage = "Ingrese Nro Solicitud";
            this.vldNroSolic.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Blue;
            // 
            // vldTXTDependencia
            // 
            this.vldTXTDependencia.ErrorMessage = "Your error message here.";
            this.vldTXTDependencia.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // VLDTXTMontoOtorgado
            // 
            this.VLDTXTMontoOtorgado.ErrorMessage = "Your error message here.";
            this.VLDTXTMontoOtorgado.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Orange;
            // 
            // vldTXTMontoEmpleado
            // 
            this.vldTXTMontoEmpleado.ErrorMessage = "Your error message here.";
            this.vldTXTMontoEmpleado.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green;
            // 
            // txtPartRef
            // 
            this.txtPartRef.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPartRef.Border.Class = "TextBoxBorder";
            this.txtPartRef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPartRef.DisabledBackColor = System.Drawing.Color.White;
            this.txtPartRef.ForeColor = System.Drawing.Color.Black;
            this.txtPartRef.Location = new System.Drawing.Point(162, 106);
            this.txtPartRef.Name = "txtPartRef";
            this.txtPartRef.PreventEnterBeep = true;
            this.txtPartRef.ReadOnly = true;
            this.txtPartRef.Size = new System.Drawing.Size(85, 22);
            this.txtPartRef.TabIndex = 68;
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
            this.txtDependencia.Location = new System.Drawing.Point(330, 55);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.ReadOnly = true;
            this.txtDependencia.Size = new System.Drawing.Size(298, 22);
            this.txtDependencia.TabIndex = 50;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "Artec - Manual de Ayuda.chm";
            // 
            // frmRendicionCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 597);
            this.Controls.Add(this.txtPartRef);
            this.Controls.Add(this.flowInventariosRend);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtMontoEmpleado);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtMontoOtorgado);
            this.Controls.Add(this.lblMontoOtorgado);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtNroPart);
            this.Controls.Add(this.lblNroPartida);
            this.Controls.Add(this.txtDependencia);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.txtNroSolic);
            this.Controls.Add(this.lblNroSolic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this, "Crear Rendición");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "frmRendicionCrear";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmRendicionCrear_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRendicionCrear_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolic;
        private DevComponents.DotNetBar.LabelX lblNroSolic;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPart;
        private DevComponents.DotNetBar.LabelX lblNroPartida;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoOtorgado;
        private DevComponents.DotNetBar.LabelX lblMontoOtorgado;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoEmpleado;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnCrear;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private System.Windows.Forms.FlowLayoutPanel flowInventariosRend;
        private DevComponents.DotNetBar.Validator.SuperValidator validlblNroPartida;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.CustomValidator vldNroSolic;
        private DevComponents.DotNetBar.Validator.CustomValidator vldTXTMontoEmpleado;
        private DevComponents.DotNetBar.Validator.CustomValidator VLDTXTMontoOtorgado;
        private DevComponents.DotNetBar.Validator.CustomValidator vldTXTDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPartRef;
        private DevComponents.DotNetBar.Validator.CustomValidator vldIdPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        internal System.Windows.Forms.HelpProvider helpProvider1;
    }
}