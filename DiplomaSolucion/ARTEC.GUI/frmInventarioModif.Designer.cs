using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class frmInventarioModif
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioModif));
            this.lblSerieKey = new DevComponents.DotNetBar.LabelX();
            this.txtSerieKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblBien = new DevComponents.DotNetBar.LabelX();
            this.lblCosto = new DevComponents.DotNetBar.LabelX();
            this.txtCosto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblModelo = new DevComponents.DotNetBar.LabelX();
            this.lblMarca = new DevComponents.DotNetBar.LabelX();
            this.lblTipoBien = new DevComponents.DotNetBar.LabelX();
            this.cboModelo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboMarca = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboTipoBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.txtSerialMaster = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblSerial = new DevComponents.DotNetBar.LabelX();
            this.cboDeposito = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblDeposito = new DevComponents.DotNetBar.LabelX();
            this.vldFrmInventarioModif = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSerieKey
            // 
            // 
            // 
            // 
            this.lblSerieKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerieKey.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieKey.Location = new System.Drawing.Point(12, 66);
            this.lblSerieKey.Name = "lblSerieKey";
            this.lblSerieKey.Size = new System.Drawing.Size(91, 17);
            this.lblSerieKey.TabIndex = 58;
            this.lblSerieKey.Text = "lblSerieKey";
            // 
            // txtSerieKey
            // 
            this.txtSerieKey.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSerieKey.Border.Class = "TextBoxBorder";
            this.txtSerieKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSerieKey.DisabledBackColor = System.Drawing.Color.White;
            this.txtSerieKey.ForeColor = System.Drawing.Color.Black;
            this.txtSerieKey.Location = new System.Drawing.Point(109, 63);
            this.txtSerieKey.Name = "txtSerieKey";
            this.txtSerieKey.PreventEnterBeep = true;
            this.txtSerieKey.Size = new System.Drawing.Size(121, 22);
            this.txtSerieKey.TabIndex = 57;
            this.vldFrmInventarioModif.SetValidator1(this.txtSerieKey, this.requiredFieldValidator1);
            // 
            // lblBien
            // 
            // 
            // 
            // 
            this.lblBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(12, 12);
            this.lblBien.Name = "lblBien";
            this.lblBien.Size = new System.Drawing.Size(91, 17);
            this.lblBien.TabIndex = 54;
            this.lblBien.Text = "lblBien";
            // 
            // lblCosto
            // 
            // 
            // 
            // 
            this.lblCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCosto.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(246, 66);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(62, 17);
            this.lblCosto.TabIndex = 56;
            this.lblCosto.Text = "lblCosto";
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCosto.Border.Class = "TextBoxBorder";
            this.txtCosto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCosto.DisabledBackColor = System.Drawing.Color.White;
            this.txtCosto.ForeColor = System.Drawing.Color.Black;
            this.txtCosto.Location = new System.Drawing.Point(343, 63);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.PreventEnterBeep = true;
            this.txtCosto.Size = new System.Drawing.Size(121, 22);
            this.txtCosto.TabIndex = 55;
            this.vldFrmInventarioModif.SetValidator1(this.txtCosto, this.requiredFieldValidator2);
            this.vldFrmInventarioModif.SetValidator2(this.txtCosto, this.regularExpressionValidator1);
            // 
            // lblModelo
            // 
            // 
            // 
            // 
            this.lblModelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblModelo.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(246, 40);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(91, 17);
            this.lblModelo.TabIndex = 53;
            this.lblModelo.Text = "lblModelo";
            // 
            // lblMarca
            // 
            // 
            // 
            // 
            this.lblMarca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMarca.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(12, 40);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(91, 17);
            this.lblMarca.TabIndex = 52;
            this.lblMarca.Text = "lblMarca";
            // 
            // lblTipoBien
            // 
            // 
            // 
            // 
            this.lblTipoBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBien.Location = new System.Drawing.Point(246, 12);
            this.lblTipoBien.Name = "lblTipoBien";
            this.lblTipoBien.Size = new System.Drawing.Size(91, 17);
            this.lblTipoBien.TabIndex = 51;
            this.lblTipoBien.Text = "lblTipoBien";
            // 
            // cboModelo
            // 
            this.cboModelo.DisplayMember = "Text";
            this.cboModelo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModelo.ForeColor = System.Drawing.Color.Black;
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.ItemHeight = 16;
            this.cboModelo.Location = new System.Drawing.Point(343, 35);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(121, 22);
            this.cboModelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModelo.TabIndex = 50;
            this.cboModelo.SelectionChangeCommitted += new System.EventHandler(this.cboModelo_SelectionChangeCommitted);
            // 
            // cboMarca
            // 
            this.cboMarca.DisplayMember = "Text";
            this.cboMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarca.ForeColor = System.Drawing.Color.Black;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.ItemHeight = 16;
            this.cboMarca.Location = new System.Drawing.Point(109, 35);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 22);
            this.cboMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMarca.TabIndex = 49;
            this.cboMarca.SelectionChangeCommitted += new System.EventHandler(this.cboMarca_SelectionChangeCommitted);
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DisplayMember = "Text";
            this.cboTipoBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoBien.Enabled = false;
            this.cboTipoBien.ForeColor = System.Drawing.Color.Black;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.ItemHeight = 16;
            this.cboTipoBien.Location = new System.Drawing.Point(343, 7);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(121, 22);
            this.cboTipoBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoBien.TabIndex = 47;
            // 
            // txtBien
            // 
            this.txtBien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBien.Border.Class = "TextBoxBorder";
            this.txtBien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBien.DisabledBackColor = System.Drawing.Color.White;
            this.txtBien.ForeColor = System.Drawing.Color.Black;
            this.txtBien.Location = new System.Drawing.Point(109, 7);
            this.txtBien.Name = "txtBien";
            this.txtBien.PreventEnterBeep = true;
            this.txtBien.ReadOnly = true;
            this.txtBien.Size = new System.Drawing.Size(121, 22);
            this.txtBien.TabIndex = 48;
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Location = new System.Drawing.Point(201, 136);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 25);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 72;
            this.btnModificar.Tag = ((object)(resources.GetObject("btnModificar.Tag")));
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtSerialMaster
            // 
            this.txtSerialMaster.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSerialMaster.Border.Class = "TextBoxBorder";
            this.txtSerialMaster.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSerialMaster.DisabledBackColor = System.Drawing.Color.White;
            this.txtSerialMaster.ForeColor = System.Drawing.Color.Black;
            this.txtSerialMaster.Location = new System.Drawing.Point(109, 91);
            this.txtSerialMaster.Name = "txtSerialMaster";
            this.txtSerialMaster.PreventEnterBeep = true;
            this.txtSerialMaster.Size = new System.Drawing.Size(121, 22);
            this.txtSerialMaster.TabIndex = 73;
            // 
            // lblSerial
            // 
            // 
            // 
            // 
            this.lblSerial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerial.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Location = new System.Drawing.Point(12, 91);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(91, 17);
            this.lblSerial.TabIndex = 74;
            this.lblSerial.Text = "lblSerial";
            // 
            // cboDeposito
            // 
            this.cboDeposito.DisplayMember = "Text";
            this.cboDeposito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDeposito.ForeColor = System.Drawing.Color.Black;
            this.cboDeposito.FormattingEnabled = true;
            this.cboDeposito.ItemHeight = 16;
            this.cboDeposito.Location = new System.Drawing.Point(343, 91);
            this.cboDeposito.Name = "cboDeposito";
            this.cboDeposito.Size = new System.Drawing.Size(121, 22);
            this.cboDeposito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDeposito.TabIndex = 77;
            // 
            // lblDeposito
            // 
            // 
            // 
            // 
            this.lblDeposito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDeposito.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposito.Location = new System.Drawing.Point(246, 96);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(91, 17);
            this.lblDeposito.TabIndex = 78;
            this.lblDeposito.Text = "lblDeposito";
            // 
            // vldFrmInventarioModif
            // 
            this.vldFrmInventarioModif.ContainerControl = this.btnModificar;
            this.vldFrmInventarioModif.ErrorProvider = this.errorProvider1;
            this.vldFrmInventarioModif.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator1.ValidationExpression = "^[0-9]{1,9}$";
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
            // frmInventarioModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 171);
            this.Controls.Add(this.cboDeposito);
            this.Controls.Add(this.lblDeposito);
            this.Controls.Add(this.txtSerialMaster);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblSerieKey);
            this.Controls.Add(this.txtSerieKey);
            this.Controls.Add(this.lblBien);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblTipoBien);
            this.Controls.Add(this.cboModelo);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.cboTipoBien);
            this.Controls.Add(this.txtBien);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmInventarioModif";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmInventarioModif_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblSerieKey;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerieKey;
        private DevComponents.DotNetBar.LabelX lblBien;
        private DevComponents.DotNetBar.LabelX lblCosto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCosto;
        private DevComponents.DotNetBar.LabelX lblModelo;
        private DevComponents.DotNetBar.LabelX lblMarca;
        private DevComponents.DotNetBar.LabelX lblTipoBien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboModelo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboMarca;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoBien;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBien;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerialMaster;
        private DevComponents.DotNetBar.LabelX lblSerial;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDeposito;
        private DevComponents.DotNetBar.LabelX lblDeposito;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmInventarioModif;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
    }
}