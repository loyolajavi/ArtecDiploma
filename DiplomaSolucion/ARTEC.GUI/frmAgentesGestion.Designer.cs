using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class frmAgentesGestion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentesGestion));
            this.pnlBuscar = new DevComponents.DotNetBar.PanelEx();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.lblAgenteBuscar = new DevComponents.DotNetBar.LabelX();
            this.txtAgenteBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtApellido = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblApellido = new DevComponents.DotNetBar.LabelX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.GrillaAgentes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblDependencia = new DevComponents.DotNetBar.LabelX();
            this.lblCargo = new DevComponents.DotNetBar.LabelX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.vldFrmAgentesGestion = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Apellido");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese un Nombre");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtCargo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAgentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.lblAgenteBuscar);
            this.pnlBuscar.Controls.Add(this.txtAgenteBuscar);
            this.pnlBuscar.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBuscar.Location = new System.Drawing.Point(12, 12);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(422, 35);
            this.pnlBuscar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBuscar.Style.GradientAngle = 90;
            this.pnlBuscar.TabIndex = 82;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(339, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 78;
            this.btnBuscar.Text = "btnBuscar";

            Dictionary<string, string[]> dicbtnBuscar = new Dictionary<string, string[]>();
            string[] PerbtnBuscar = { "Agente Buscar" };
            dicbtnBuscar.Add("Permisos", PerbtnBuscar);
            string[] IdiomabtnBuscar = { "Buscar" };
            dicbtnBuscar.Add("Idioma", IdiomabtnBuscar);
            this.btnBuscar.Tag = dicbtnBuscar;

            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblAgenteBuscar
            // 
            // 
            // 
            // 
            this.lblAgenteBuscar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAgenteBuscar.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgenteBuscar.Location = new System.Drawing.Point(9, 9);
            this.lblAgenteBuscar.Name = "lblAgenteBuscar";
            this.lblAgenteBuscar.Size = new System.Drawing.Size(91, 17);
            this.lblAgenteBuscar.TabIndex = 62;
            this.lblAgenteBuscar.Text = "lblAgente";
            // 
            // txtAgenteBuscar
            // 
            this.txtAgenteBuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAgenteBuscar.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtAgenteBuscar.Border.BorderBottomWidth = 2;
            this.txtAgenteBuscar.Border.BorderColor = System.Drawing.Color.Black;
            this.txtAgenteBuscar.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtAgenteBuscar.Border.BorderLeftWidth = 2;
            this.txtAgenteBuscar.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtAgenteBuscar.Border.BorderRightWidth = 2;
            this.txtAgenteBuscar.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtAgenteBuscar.Border.BorderTopWidth = 2;
            this.txtAgenteBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAgenteBuscar.DisabledBackColor = System.Drawing.Color.White;
            this.txtAgenteBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtAgenteBuscar.Location = new System.Drawing.Point(106, 7);
            this.txtAgenteBuscar.Multiline = true;
            this.txtAgenteBuscar.Name = "txtAgenteBuscar";
            this.txtAgenteBuscar.PreventEnterBeep = true;
            this.txtAgenteBuscar.Size = new System.Drawing.Size(227, 20);
            this.txtAgenteBuscar.TabIndex = 0;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtApellido.Border.Class = "TextBoxBorder";
            this.txtApellido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApellido.DisabledBackColor = System.Drawing.Color.White;
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(118, 96);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PreventEnterBeep = true;
            this.txtApellido.Size = new System.Drawing.Size(227, 22);
            this.txtApellido.TabIndex = 86;
            this.vldFrmAgentesGestion.SetValidator1(this.txtApellido, this.requiredFieldValidator2);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(118, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(227, 22);
            this.txtNombre.TabIndex = 85;
            this.vldFrmAgentesGestion.SetValidator1(this.txtNombre, this.requiredFieldValidator1);
            // 
            // lblApellido
            // 
            // 
            // 
            // 
            this.lblApellido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblApellido.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(21, 101);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(91, 17);
            this.lblApellido.TabIndex = 84;
            this.lblApellido.Text = "lblApellido";
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(21, 66);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 17);
            this.lblNombre.TabIndex = 83;
            this.lblNombre.Text = "lblNombre";
            // 
            // GrillaAgentes
            // 
            this.GrillaAgentes.AllowUserToAddRows = false;
            this.GrillaAgentes.AllowUserToDeleteRows = false;
            this.GrillaAgentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaAgentes.BackgroundColor = System.Drawing.Color.White;
            this.GrillaAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaAgentes.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaAgentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaAgentes.Location = new System.Drawing.Point(4, 159);
            this.GrillaAgentes.Name = "GrillaAgentes";
            this.GrillaAgentes.ReadOnly = true;
            this.GrillaAgentes.Size = new System.Drawing.Size(447, 84);
            this.GrillaAgentes.TabIndex = 90;
            this.GrillaAgentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaAgentes_CellClick);
            // 
            // lblDependencia
            // 
            // 
            // 
            // 
            this.lblDependencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDependencia.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependencia.Location = new System.Drawing.Point(21, 136);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(120, 17);
            this.lblDependencia.TabIndex = 91;
            this.lblDependencia.Text = "lblDependencia";
            // 
            // lblCargo
            // 
            // 
            // 
            // 
            this.lblCargo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCargo.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(21, 256);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(91, 17);
            this.lblCargo.TabIndex = 93;
            this.lblCargo.Text = "lblCargo";
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(184, 293);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 35);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 94;
            this.btnModificar.Text = "btnModificar";

            Dictionary<string, string[]> dicbtnModificar = new Dictionary<string, string[]>();
            string[] PerbtnModificar = { "Agente Modificar" };
            dicbtnModificar.Add("Permisos", PerbtnModificar);
            string[] IdiomabtnModificar = { "Modificar" };
            dicbtnModificar.Add("Idioma", IdiomabtnModificar);
            this.btnModificar.Tag = dicbtnModificar;

            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // vldFrmAgentesGestion
            // 
            this.vldFrmAgentesGestion.ContainerControl = this.btnModificar;
            this.vldFrmAgentesGestion.ErrorProvider = this.errorProvider1;
            this.vldFrmAgentesGestion.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Ingrese un Apellido";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Ingrese un Nombre";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // txtCargo
            // 
            this.txtCargo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCargo.Border.Class = "TextBoxBorder";
            this.txtCargo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCargo.DisabledBackColor = System.Drawing.Color.White;
            this.txtCargo.ForeColor = System.Drawing.Color.Black;
            this.txtCargo.Location = new System.Drawing.Point(118, 251);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.PreventEnterBeep = true;
            this.txtCargo.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(227, 22);
            this.txtCargo.TabIndex = 95;
            // 
            // frmAgentesGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 339);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblDependencia);
            this.Controls.Add(this.GrillaAgentes);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pnlBuscar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAgentesGestion";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmAgentesGestion_Load);
            this.pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAgentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlBuscar;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.LabelX lblAgenteBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAgenteBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtApellido;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX lblApellido;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaAgentes;
        private DevComponents.DotNetBar.LabelX lblDependencia;
        private DevComponents.DotNetBar.LabelX lblCargo;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmAgentesGestion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCargo;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
    }
}