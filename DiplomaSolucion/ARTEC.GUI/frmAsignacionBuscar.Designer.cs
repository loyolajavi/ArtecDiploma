namespace ARTEC.GUI
{
    partial class frmAsignacionBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionBuscar));
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.lblNroAsignacion = new DevComponents.DotNetBar.LabelX();
            this.txtDep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNroSolicitud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNroSolicitud = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtAsignacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtFechaHasta = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtFechaDesde = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblDesde = new DevComponents.DotNetBar.LabelX();
            this.lblHasta = new DevComponents.DotNetBar.LabelX();
            this.flowAsignaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.vldFrmAsignacionBuscar = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.regularExpressionValidator2 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(99, 94);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 55;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNroAsignacion
            // 
            // 
            // 
            // 
            this.lblNroAsignacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroAsignacion.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroAsignacion.Location = new System.Drawing.Point(2, 10);
            this.lblNroAsignacion.Name = "lblNroAsignacion";
            this.lblNroAsignacion.Size = new System.Drawing.Size(91, 22);
            this.lblNroAsignacion.TabIndex = 52;
            this.lblNroAsignacion.Text = "lblNroAsignacion";
            // 
            // txtDep
            // 
            this.txtDep.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDep.Border.Class = "TextBoxBorder";
            this.txtDep.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDep.DisabledBackColor = System.Drawing.Color.White;
            this.txtDep.ForeColor = System.Drawing.Color.Black;
            this.txtDep.Location = new System.Drawing.Point(99, 38);
            this.txtDep.Name = "txtDep";
            this.txtDep.PreventEnterBeep = true;
            this.txtDep.Size = new System.Drawing.Size(202, 22);
            this.txtDep.TabIndex = 53;
            // 
            // txtNroSolicitud
            // 
            this.txtNroSolicitud.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNroSolicitud.Border.Class = "TextBoxBorder";
            this.txtNroSolicitud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNroSolicitud.DisabledBackColor = System.Drawing.Color.White;
            this.txtNroSolicitud.ForeColor = System.Drawing.Color.Black;
            this.txtNroSolicitud.Location = new System.Drawing.Point(99, 66);
            this.txtNroSolicitud.Name = "txtNroSolicitud";
            this.txtNroSolicitud.PreventEnterBeep = true;
            this.txtNroSolicitud.Size = new System.Drawing.Size(202, 22);
            this.txtNroSolicitud.TabIndex = 51;
            this.vldFrmAsignacionBuscar.SetValidator1(this.txtNroSolicitud, this.regularExpressionValidator2);
            // 
            // lblNroSolicitud
            // 
            // 
            // 
            // 
            this.lblNroSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNroSolicitud.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSolicitud.Location = new System.Drawing.Point(2, 66);
            this.lblNroSolicitud.Name = "lblNroSolicitud";
            this.lblNroSolicitud.Size = new System.Drawing.Size(91, 22);
            this.lblNroSolicitud.TabIndex = 50;
            this.lblNroSolicitud.Text = "NroSolicitud";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(2, 38);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(91, 22);
            this.labelX1.TabIndex = 47;
            this.labelX1.Text = "Dependencia";
            // 
            // txtAsignacion
            // 
            this.txtAsignacion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAsignacion.Border.Class = "TextBoxBorder";
            this.txtAsignacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAsignacion.DisabledBackColor = System.Drawing.Color.White;
            this.txtAsignacion.ForeColor = System.Drawing.Color.Black;
            this.txtAsignacion.Location = new System.Drawing.Point(99, 10);
            this.txtAsignacion.Name = "txtAsignacion";
            this.txtAsignacion.PreventEnterBeep = true;
            this.txtAsignacion.Size = new System.Drawing.Size(202, 22);
            this.txtAsignacion.TabIndex = 48;
            this.vldFrmAsignacionBuscar.SetValidator1(this.txtAsignacion, this.regularExpressionValidator1);
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(99, 38);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(156, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 49;
            this.comboBoxEx4.Visible = false;
            // 
            // txtFechaHasta
            // 
            // 
            // 
            // 
            this.txtFechaHasta.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaHasta.ButtonDropDown.Visible = true;
            this.txtFechaHasta.IsPopupCalendarOpen = false;
            this.txtFechaHasta.Location = new System.Drawing.Point(393, 48);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaHasta.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaHasta.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaHasta.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaHasta.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(79, 22);
            this.txtFechaHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaHasta.TabIndex = 62;
            // 
            // txtFechaDesde
            // 
            // 
            // 
            // 
            this.txtFechaDesde.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFechaDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaDesde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFechaDesde.ButtonDropDown.Visible = true;
            this.txtFechaDesde.IsPopupCalendarOpen = false;
            this.txtFechaDesde.Location = new System.Drawing.Point(393, 10);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFechaDesde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaDesde.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFechaDesde.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFechaDesde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaDesde.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.txtFechaDesde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFechaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFechaDesde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFechaDesde.MonthCalendar.TodayButtonVisible = true;
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(79, 22);
            this.txtFechaDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFechaDesde.TabIndex = 61;
            // 
            // lblDesde
            // 
            // 
            // 
            // 
            this.lblDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDesde.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesde.Location = new System.Drawing.Point(318, 10);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(69, 22);
            this.lblDesde.TabIndex = 60;
            this.lblDesde.Text = "lblDesde";
            // 
            // lblHasta
            // 
            // 
            // 
            // 
            this.lblHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblHasta.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold);
            this.lblHasta.Location = new System.Drawing.Point(318, 48);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(69, 22);
            this.lblHasta.TabIndex = 66;
            this.lblHasta.Text = "lblHasta";
            // 
            // flowAsignaciones
            // 
            this.flowAsignaciones.AutoScroll = true;
            this.flowAsignaciones.BackColor = System.Drawing.Color.Transparent;
            this.flowAsignaciones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowAsignaciones.Location = new System.Drawing.Point(2, 123);
            this.flowAsignaciones.Name = "flowAsignaciones";
            this.flowAsignaciones.Size = new System.Drawing.Size(509, 273);
            this.flowAsignaciones.TabIndex = 67;
            this.flowAsignaciones.WrapContents = false;
            // 
            // vldFrmAsignacionBuscar
            // 
            this.vldFrmAsignacionBuscar.ContainerControl = this.btnBuscar;
            this.vldFrmAsignacionBuscar.ErrorProvider = this.errorProvider1;
            this.vldFrmAsignacionBuscar.Highlighter = this.highlighter1;
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
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.EmptyValueIsValid = true;
            this.regularExpressionValidator1.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator1.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.EmptyValueIsValid = true;
            this.regularExpressionValidator2.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.regularExpressionValidator2.ValidationExpression = "^[0-9]{1,9}$";
            // 
            // frmAsignacionBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 396);
            this.Controls.Add(this.flowAsignaciones);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.txtFechaHasta);
            this.Controls.Add(this.txtFechaDesde);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblNroAsignacion);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.txtNroSolicitud);
            this.Controls.Add(this.lblNroSolicitud);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtAsignacion);
            this.Controls.Add(this.comboBoxEx4);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAsignacionBuscar";
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.frmAsignacionBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.LabelX lblNroAsignacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDep;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNroSolicitud;
        private DevComponents.DotNetBar.LabelX lblNroSolicitud;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAsignacion;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaHasta;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFechaDesde;
        private DevComponents.DotNetBar.LabelX lblDesde;
        private DevComponents.DotNetBar.LabelX lblHasta;
        private System.Windows.Forms.FlowLayoutPanel flowAsignaciones;
        private DevComponents.DotNetBar.Validator.SuperValidator vldFrmAsignacionBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator2;
    }
}