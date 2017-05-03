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
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem6 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem7 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem8 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.SuspendLayout();
            // 
            // metroTilePanel1
            // 
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.DragDropSupport = true;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2});
            this.metroTilePanel1.Location = new System.Drawing.Point(277, 0);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(772, 123);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            this.metroTilePanel1.ItemClick += new System.EventHandler(this.metroTilePanel1_ItemClick);
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.MultiLine = true;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTileItem5,
            this.metroTileItem6,
            this.metroTileItem7,
            this.metroTileItem8});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.Class = "MetroTileGroupTitle";
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.TitleVisible = false;
            // 
            // metroTileItem5
            // 
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem5.Text = "Crear Solicitud";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem5.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.metroTileItem5.Click += new System.EventHandler(this.metroTileItem5_Click);
            // 
            // metroTileItem6
            // 
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem6.Text = "Registrar Compra";
            this.metroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem6.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // metroTileItem7
            // 
            this.metroTileItem7.Name = "metroTileItem7";
            this.metroTileItem7.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem7.Text = "Homologar Software";
            this.metroTileItem7.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem7.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem7.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // metroTileItem8
            // 
            this.metroTileItem8.Name = "metroTileItem8";
            this.metroTileItem8.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem8.Text = "Agregar Proveedor";
            this.metroTileItem8.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem8.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem8.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 732);
            this.Controls.Add(this.metroTilePanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Principal";
            this.Text = "ARTEC";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem6;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem7;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem8;


    }
}