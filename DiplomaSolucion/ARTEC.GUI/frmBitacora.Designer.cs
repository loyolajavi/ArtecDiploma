namespace ARTEC.GUI
{
    partial class frmBitacora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFechaInicio2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtFechaInicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cboTipoLog = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblTipoLog = new DevComponents.DotNetBar.LabelX();
            this.lblFechaInicio = new DevComponents.DotNetBar.LabelX();
            this.lblFechaFin = new DevComponents.DotNetBar.LabelX();
            this.txtResBusqueda = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.GrillaBuscar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFechaInicio2
            // 
            // 
            // 
            // 
            this.txtFechaInicio2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaInicio2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaInicio2.ButtonDropDown.Visible = true;
            this.txtFechaInicio2.IsPopupCalendarOpen = false;
            this.txtFechaInicio2.Location = new System.Drawing.Point(137, 43);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaInicio2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaInicio2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaInicio2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaInicio2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaInicio2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio2.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaInicio2.Name = "txtFechaInicio2";
            this.txtFechaInicio2.Size = new System.Drawing.Size(95, 22);
            this.txtFechaInicio2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaInicio2.TabIndex = 51;
            // 
            // txtFechaInicio
            // 
            // 
            // 
            // 
            this.txtFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaInicio.ButtonDropDown.Visible = true;
            this.txtFechaInicio.IsPopupCalendarOpen = false;
            this.txtFechaInicio.Location = new System.Drawing.Point(12, 43);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaInicio.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaInicio.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(102, 22);
            this.txtFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaInicio.TabIndex = 50;
            // 
            // cboTipoLog
            // 
            this.cboTipoLog.DisplayMember = "Text";
            this.cboTipoLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoLog.ForeColor = System.Drawing.Color.Black;
            this.cboTipoLog.FormattingEnabled = true;
            this.cboTipoLog.ItemHeight = 16;
            this.cboTipoLog.Location = new System.Drawing.Point(256, 43);
            this.cboTipoLog.Name = "cboTipoLog";
            this.cboTipoLog.Size = new System.Drawing.Size(121, 22);
            this.cboTipoLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoLog.TabIndex = 52;
            // 
            // lblTipoLog
            // 
            // 
            // 
            // 
            this.lblTipoLog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTipoLog.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoLog.Location = new System.Drawing.Point(256, 15);
            this.lblTipoLog.Name = "lblTipoLog";
            this.lblTipoLog.Size = new System.Drawing.Size(77, 22);
            this.lblTipoLog.TabIndex = 53;
            this.lblTipoLog.Text = "lblTipoLog";
            // 
            // lblFechaInicio
            // 
            // 
            // 
            // 
            this.lblFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaInicio.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(12, 15);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(102, 22);
            this.lblFechaInicio.TabIndex = 54;
            this.lblFechaInicio.Text = "lblFechaInicio";
            // 
            // lblFechaFin
            // 
            // 
            // 
            // 
            this.lblFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaFin.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(137, 15);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(95, 22);
            this.lblFechaFin.TabIndex = 55;
            this.lblFechaFin.Text = "lblFechaFin";
            // 
            // txtResBusqueda
            // 
            // 
            // 
            // 
            this.txtResBusqueda.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtResBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtResBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResBusqueda.Location = new System.Drawing.Point(3, 142);
            this.txtResBusqueda.Name = "txtResBusqueda";
            this.txtResBusqueda.ReadOnly = true;
            this.txtResBusqueda.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n\\viewkind4\\uc1\\pard\\la" +
    "ng11274\\ul\\b\\f0\\fs24 No hay resultados\\par\r\n}\r\n";
            this.txtResBusqueda.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResBusqueda.Size = new System.Drawing.Size(824, 372);
            this.txtResBusqueda.TabIndex = 56;
            this.txtResBusqueda.Text = "No hay resultados";
            this.txtResBusqueda.Visible = false;
            // 
            // GrillaBuscar
            // 
            this.GrillaBuscar.AllowUserToAddRows = false;
            this.GrillaBuscar.AllowUserToDeleteRows = false;
            this.GrillaBuscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrillaBuscar.BackgroundColor = System.Drawing.Color.White;
            this.GrillaBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaBuscar.DefaultCellStyle = dataGridViewCellStyle4;
            this.GrillaBuscar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GrillaBuscar.Location = new System.Drawing.Point(3, 86);
            this.GrillaBuscar.Name = "GrillaBuscar";
            this.GrillaBuscar.ReadOnly = true;
            this.GrillaBuscar.Size = new System.Drawing.Size(824, 428);
            this.GrillaBuscar.TabIndex = 57;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(396, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 58;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 584);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.GrillaBuscar);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblTipoLog);
            this.Controls.Add(this.cboTipoLog);
            this.Controls.Add(this.txtFechaInicio2);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.txtResBusqueda);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBitacora";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaBuscar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaInicio2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaInicio;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoLog;
        private DevComponents.DotNetBar.LabelX lblTipoLog;
        private DevComponents.DotNetBar.LabelX lblFechaInicio;
        private DevComponents.DotNetBar.LabelX lblFechaFin;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtResBusqueda;
        private DevComponents.DotNetBar.Controls.DataGridViewX GrillaBuscar;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
    }
}