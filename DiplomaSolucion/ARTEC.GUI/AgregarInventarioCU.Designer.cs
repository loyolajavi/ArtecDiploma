using System.Collections.Generic;
namespace ARTEC.GUI
{
    partial class AgregarInventarioCU
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.lblSerieKey = new DevComponents.DotNetBar.LabelX();
            this.txtSerieKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.txtIdBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblBien
            // 
            // 
            // 
            // 
            this.lblBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(7, 16);
            this.lblBien.Name = "lblBien";
            this.lblBien.Size = new System.Drawing.Size(91, 17);
            this.lblBien.TabIndex = 41;
            this.lblBien.Text = "lblBien";
            // 
            // lblCosto
            // 
            // 
            // 
            // 
            this.lblCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCosto.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(241, 70);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(62, 17);
            this.lblCosto.TabIndex = 43;
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
            this.txtCosto.Location = new System.Drawing.Point(338, 67);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.PreventEnterBeep = true;
            this.txtCosto.Size = new System.Drawing.Size(121, 20);
            this.txtCosto.TabIndex = 42;
            // 
            // lblModelo
            // 
            // 
            // 
            // 
            this.lblModelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblModelo.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(241, 44);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(91, 17);
            this.lblModelo.TabIndex = 40;
            this.lblModelo.Text = "lblModelo";
            // 
            // lblMarca
            // 
            // 
            // 
            // 
            this.lblMarca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMarca.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(7, 44);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(91, 17);
            this.lblMarca.TabIndex = 39;
            this.lblMarca.Text = "lblMarca";
            // 
            // lblTipoBien
            // 
            // 
            // 
            // 
            this.lblTipoBien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoBien.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBien.Location = new System.Drawing.Point(241, 16);
            this.lblTipoBien.Name = "lblTipoBien";
            this.lblTipoBien.Size = new System.Drawing.Size(91, 17);
            this.lblTipoBien.TabIndex = 38;
            this.lblTipoBien.Text = "lblTipoBien";
            // 
            // cboModelo
            // 
            this.cboModelo.DisplayMember = "Text";
            this.cboModelo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModelo.ForeColor = System.Drawing.Color.Black;
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.ItemHeight = 16;
            this.cboModelo.Location = new System.Drawing.Point(338, 39);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(121, 22);
            this.cboModelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModelo.TabIndex = 37;
            // 
            // cboMarca
            // 
            this.cboMarca.DisplayMember = "Text";
            this.cboMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarca.ForeColor = System.Drawing.Color.Black;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.ItemHeight = 16;
            this.cboMarca.Location = new System.Drawing.Point(104, 39);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 22);
            this.cboMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMarca.TabIndex = 36;
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DisplayMember = "Text";
            this.cboTipoBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoBien.ForeColor = System.Drawing.Color.Black;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.ItemHeight = 16;
            this.cboTipoBien.Location = new System.Drawing.Point(338, 11);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(121, 22);
            this.cboTipoBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoBien.TabIndex = 34;
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
            this.txtBien.Location = new System.Drawing.Point(104, 13);
            this.txtBien.Name = "txtBien";
            this.txtBien.PreventEnterBeep = true;
            this.txtBien.ReadOnly = true;
            this.txtBien.Size = new System.Drawing.Size(121, 20);
            this.txtBien.TabIndex = 35;
            // 
            // lblSerieKey
            // 
            // 
            // 
            // 
            this.lblSerieKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerieKey.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieKey.Location = new System.Drawing.Point(7, 70);
            this.lblSerieKey.Name = "lblSerieKey";
            this.lblSerieKey.Size = new System.Drawing.Size(91, 17);
            this.lblSerieKey.TabIndex = 46;
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
            this.txtSerieKey.Location = new System.Drawing.Point(104, 67);
            this.txtSerieKey.Name = "txtSerieKey";
            this.txtSerieKey.PreventEnterBeep = true;
            this.txtSerieKey.Size = new System.Drawing.Size(121, 20);
            this.txtSerieKey.TabIndex = 45;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(104, 96);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 25);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 71;
            this.btnAgregar.Text = "btnAgregar";

            Dictionary<string, string[]> dicbtnAgregar = new Dictionary<string, string[]>();
            string[] PerbtnAgregar = { "Inventario Agregar" };
            dicbtnAgregar.Add("Permisos", PerbtnAgregar);
            string[] IdiomabtnAgregar = { "Agregar" };
            dicbtnAgregar.Add("Idioma", IdiomabtnAgregar);
            this.btnAgregar.Tag = dicbtnAgregar;

            // 
            // txtIdBien
            // 
            this.txtIdBien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIdBien.Border.Class = "TextBoxBorder";
            this.txtIdBien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdBien.DisabledBackColor = System.Drawing.Color.White;
            this.txtIdBien.ForeColor = System.Drawing.Color.Black;
            this.txtIdBien.Location = new System.Drawing.Point(338, 96);
            this.txtIdBien.Name = "txtIdBien";
            this.txtIdBien.PreventEnterBeep = true;
            this.txtIdBien.Size = new System.Drawing.Size(121, 20);
            this.txtIdBien.TabIndex = 72;
            this.txtIdBien.Visible = false;
            // 
            // AgregarInventarioCU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtIdBien);
            this.Controls.Add(this.btnAgregar);
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
            this.Name = "AgregarInventarioCU";
            this.Size = new System.Drawing.Size(465, 130);
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevComponents.DotNetBar.LabelX lblSerieKey;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerieKey;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdBien;
    }
}
