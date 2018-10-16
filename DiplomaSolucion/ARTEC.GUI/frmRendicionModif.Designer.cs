using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class frmRendicionModif
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
            this.txtNroRendicion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroRendicion = new DevComponents.DotNetBar.LabelX();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.txtPartRef = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.flowInventariosRend = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerar = new DevComponents.DotNetBar.ButtonX();
            this.txtMontoEmpleado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtMontoOtorgado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMontoOtorgado = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtNroPart = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroPartida = new DevComponents.DotNetBar.LabelX();
            this.txtDependencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.txtNroSolic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolic = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
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
            this.txtNroRendicion.Location = new System.Drawing.Point(162, 12);
            this.txtNroRendicion.Name = "txtNroRendicion";
            this.txtNroRendicion.PreventEnterBeep = true;
            this.txtNroRendicion.Size = new System.Drawing.Size(85, 22);
            this.txtNroRendicion.TabIndex = 89;
            // 
            // lblNroRendicion
            // 
            // 
            // 
            // 
            this.lblNroRendicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroRendicion.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroRendicion.Location = new System.Drawing.Point(3, 12);
            this.lblNroRendicion.Name = "lblNroRendicion";
            this.lblNroRendicion.Size = new System.Drawing.Size(117, 22);
            this.lblNroRendicion.TabIndex = 90;
            this.lblNroRendicion.Text = "lblNroRendicion";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Location = new System.Drawing.Point(516, 597);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 88;
            this.btnEliminar.Text = "btnEliminar";

            Dictionary<string, string[]> dicbtnEliminar = new Dictionary<string, string[]>();
            string[] PerbtnEliminar = { "Rendicion Eliminar" };
            dicbtnEliminar.Add("Permisos", PerbtnEliminar);
            string[] IdiomabtnEliminar = { "Eliminar" };
            dicbtnEliminar.Add("Idioma", IdiomabtnEliminar);
            this.btnEliminar.Tag = dicbtnEliminar;

            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.txtPartRef.Location = new System.Drawing.Point(162, 124);
            this.txtPartRef.Name = "txtPartRef";
            this.txtPartRef.PreventEnterBeep = true;
            this.txtPartRef.ReadOnly = true;
            this.txtPartRef.Size = new System.Drawing.Size(85, 22);
            this.txtPartRef.TabIndex = 87;
            // 
            // flowInventariosRend
            // 
            this.flowInventariosRend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowInventariosRend.AutoScroll = true;
            this.flowInventariosRend.BackColor = System.Drawing.Color.Transparent;
            this.flowInventariosRend.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowInventariosRend.Location = new System.Drawing.Point(3, 220);
            this.flowInventariosRend.Name = "flowInventariosRend";
            this.flowInventariosRend.Size = new System.Drawing.Size(635, 357);
            this.flowInventariosRend.TabIndex = 86;
            this.flowInventariosRend.WrapContents = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerar.Location = new System.Drawing.Point(275, 597);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerar.TabIndex = 84;
            this.btnGenerar.Text = "btnGenerar";

            Dictionary<string, string[]> dicbtnGenerar = new Dictionary<string, string[]>();
            string[] PerbtnGenerar = { "Rendicion Regenerar" };
            dicbtnGenerar.Add("Permisos", PerbtnGenerar);
            string[] IdiomabtnGenerar = { "Regenerar" };
            dicbtnGenerar.Add("Idioma", IdiomabtnGenerar);
            this.btnGenerar.Tag = dicbtnGenerar;

            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
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
            this.txtMontoEmpleado.Location = new System.Drawing.Point(162, 180);
            this.txtMontoEmpleado.Name = "txtMontoEmpleado";
            this.txtMontoEmpleado.PreventEnterBeep = true;
            this.txtMontoEmpleado.ReadOnly = true;
            this.txtMontoEmpleado.Size = new System.Drawing.Size(85, 22);
            this.txtMontoEmpleado.TabIndex = 82;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(3, 180);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(139, 22);
            this.labelX3.TabIndex = 83;
            this.labelX3.Text = "lblMontoEmpleado";
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
            this.txtMontoOtorgado.Location = new System.Drawing.Point(162, 152);
            this.txtMontoOtorgado.Name = "txtMontoOtorgado";
            this.txtMontoOtorgado.PreventEnterBeep = true;
            this.txtMontoOtorgado.ReadOnly = true;
            this.txtMontoOtorgado.Size = new System.Drawing.Size(85, 22);
            this.txtMontoOtorgado.TabIndex = 80;
            // 
            // lblMontoOtorgado
            // 
            // 
            // 
            // 
            this.lblMontoOtorgado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMontoOtorgado.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoOtorgado.Location = new System.Drawing.Point(3, 152);
            this.lblMontoOtorgado.Name = "lblMontoOtorgado";
            this.lblMontoOtorgado.Size = new System.Drawing.Size(139, 22);
            this.lblMontoOtorgado.TabIndex = 81;
            this.lblMontoOtorgado.Text = "lblMontoOtorgado";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(3, 124);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(153, 22);
            this.labelX1.TabIndex = 79;
            this.labelX1.Text = "Partida Referenciada";
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
            this.txtNroPart.Location = new System.Drawing.Point(162, 40);
            this.txtNroPart.Name = "txtNroPart";
            this.txtNroPart.PreventEnterBeep = true;
            this.txtNroPart.Size = new System.Drawing.Size(85, 22);
            this.txtNroPart.TabIndex = 77;
            // 
            // lblNroPartida
            // 
            // 
            // 
            // 
            this.lblNroPartida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroPartida.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPartida.Location = new System.Drawing.Point(3, 40);
            this.lblNroPartida.Name = "lblNroPartida";
            this.lblNroPartida.Size = new System.Drawing.Size(97, 22);
            this.lblNroPartida.TabIndex = 78;
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
            this.txtDependencia.Location = new System.Drawing.Point(162, 96);
            this.txtDependencia.Name = "txtDependencia";
            this.txtDependencia.PreventEnterBeep = true;
            this.txtDependencia.ReadOnly = true;
            this.txtDependencia.Size = new System.Drawing.Size(298, 22);
            this.txtDependencia.TabIndex = 75;
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(3, 96);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(110, 22);
            this.lblDependencia.TabIndex = 76;
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
            this.txtNroSolic.Location = new System.Drawing.Point(162, 68);
            this.txtNroSolic.Name = "txtNroSolic";
            this.txtNroSolic.PreventEnterBeep = true;
            this.txtNroSolic.ReadOnly = true;
            this.txtNroSolic.Size = new System.Drawing.Size(85, 22);
            this.txtNroSolic.TabIndex = 73;
            // 
            // lblNroSolic
            // 
            // 
            // 
            // 
            this.lblNroSolic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolic.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolic.Location = new System.Drawing.Point(3, 68);
            this.lblNroSolic.Name = "lblNroSolic";
            this.lblNroSolic.Size = new System.Drawing.Size(97, 22);
            this.lblNroSolic.TabIndex = 74;
            this.lblNroSolic.Text = "lblNroSolic";
            // 
            // frmRendicionModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 630);
            this.Controls.Add(this.txtNroRendicion);
            this.Controls.Add(this.lblNroRendicion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtPartRef);
            this.Controls.Add(this.flowInventariosRend);
            this.Controls.Add(this.btnGenerar);
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
            this.Name = "frmRendicionModif";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmRendicionModif_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNroRendicion;
        private DevComponents.DotNetBar.LabelX lblNroRendicion;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPartRef;
        private System.Windows.Forms.FlowLayoutPanel flowInventariosRend;
        private DevComponents.DotNetBar.ButtonX btnGenerar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoEmpleado;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMontoOtorgado;
        private DevComponents.DotNetBar.LabelX lblMontoOtorgado;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroPart;
        private DevComponents.DotNetBar.LabelX lblNroPartida;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDependencia;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolic;
        private DevComponents.DotNetBar.LabelX lblNroSolic;
    }
}