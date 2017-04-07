namespace ARTEC.GUI
{
    partial class CrearSolicitud
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearSolicitud));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gboxNotas = new System.Windows.Forms.GroupBox();
            this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.comboBoxEx3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gboxBienes = new System.Windows.Forms.GroupBox();
            this.gboxAsociados = new System.Windows.Forms.GroupBox();
            this.grillaAgentesAsociados = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAsociarAgente = new DevComponents.DotNetBar.ButtonX();
            this.txtAgente = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboTipoBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtAgregarDetalle = new DevComponents.DotNetBar.ButtonX();
            this.grillaDetalles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtCantBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCantidad = new DevComponents.DotNetBar.LabelX();
            this.txtBien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboBien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboAgentesAsociados = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.validDependencia = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Ingrese una Dependencia");
            this.ValidDep2 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter2 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.panel1.SuspendLayout();
            this.gboxNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            this.panel2.SuspendLayout();
            this.gboxBienes.SuspendLayout();
            this.gboxAsociados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgentesAsociados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gboxNotas);
            this.panel1.Controls.Add(this.dateTimeInput2);
            this.panel1.Controls.Add(this.comboBoxEx3);
            this.panel1.Controls.Add(this.comboBoxEx2);
            this.panel1.Controls.Add(this.comboBoxEx1);
            this.panel1.Controls.Add(this.labelX8);
            this.panel1.Controls.Add(this.labelX10);
            this.panel1.Controls.Add(this.labelX9);
            this.panel1.Controls.Add(this.dateTimeInput1);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.gboxBienes);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.textBoxX1);
            this.panel1.Controls.Add(this.comboBoxEx4);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 659);
            this.panel1.TabIndex = 3;
            // 
            // gboxNotas
            // 
            this.gboxNotas.Controls.Add(this.richTextBoxEx1);
            this.gboxNotas.Location = new System.Drawing.Point(15, 489);
            this.gboxNotas.Name = "gboxNotas";
            this.gboxNotas.Size = new System.Drawing.Size(928, 131);
            this.gboxNotas.TabIndex = 21;
            this.gboxNotas.TabStop = false;
            this.gboxNotas.Text = "Notas";
            // 
            // richTextBoxEx1
            // 
            // 
            // 
            // 
            this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxEx1.Location = new System.Drawing.Point(6, 21);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang11274{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}" +
    "}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.richTextBoxEx1.Size = new System.Drawing.Size(913, 104);
            this.richTextBoxEx1.TabIndex = 8;
            // 
            // dateTimeInput2
            // 
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(878, 50);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.dateTimeInput2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput2.Name = "dateTimeInput2";
            this.dateTimeInput2.Size = new System.Drawing.Size(65, 22);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 12;
            // 
            // comboBoxEx3
            // 
            this.comboBoxEx3.DisplayMember = "Text";
            this.comboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx3.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx3.FormattingEnabled = true;
            this.comboBoxEx3.ItemHeight = 16;
            this.comboBoxEx3.Location = new System.Drawing.Point(450, 449);
            this.comboBoxEx3.Name = "comboBoxEx3";
            this.comboBoxEx3.Size = new System.Drawing.Size(116, 22);
            this.comboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx3.TabIndex = 19;
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.DisplayMember = "Text";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.ItemHeight = 16;
            this.comboBoxEx2.Location = new System.Drawing.Point(450, 420);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(116, 22);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 18;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(450, 392);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(116, 22);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 17;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(369, 394);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 14;
            this.labelX8.Text = "Estado";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(369, 448);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 16;
            this.labelX10.Text = "Asignado a";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(369, 419);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 15;
            this.labelX9.Text = "Prioridad";
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(746, 50);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(65, 22);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 11;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(817, 50);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(65, 22);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "Finalización";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(692, 50);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(48, 22);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Creación";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonX3);
            this.panel2.Controls.Add(this.textBoxX4);
            this.panel2.Location = new System.Drawing.Point(15, 379);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 104);
            this.panel2.TabIndex = 7;
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(6, 13);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(52, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 1;
            this.buttonX3.Text = "Adjuntar";
            // 
            // textBoxX4
            // 
            this.textBoxX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX4.ForeColor = System.Drawing.Color.Black;
            this.textBoxX4.Location = new System.Drawing.Point(64, 13);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.PreventEnterBeep = true;
            this.textBoxX4.Size = new System.Drawing.Size(265, 22);
            this.textBoxX4.TabIndex = 0;
            // 
            // gboxBienes
            // 
            this.gboxBienes.Controls.Add(this.gboxAsociados);
            this.gboxBienes.Controls.Add(this.cboTipoBien);
            this.gboxBienes.Controls.Add(this.txtAgregarDetalle);
            this.gboxBienes.Controls.Add(this.grillaDetalles);
            this.gboxBienes.Controls.Add(this.txtCantBien);
            this.gboxBienes.Controls.Add(this.lblCantidad);
            this.gboxBienes.Controls.Add(this.txtBien);
            this.gboxBienes.Controls.Add(this.cboBien);
            this.gboxBienes.Location = new System.Drawing.Point(15, 78);
            this.gboxBienes.Name = "gboxBienes";
            this.gboxBienes.Size = new System.Drawing.Size(928, 293);
            this.gboxBienes.TabIndex = 2;
            this.gboxBienes.TabStop = false;
            this.gboxBienes.Text = "Agregar Bienes";
            // 
            // gboxAsociados
            // 
            this.gboxAsociados.Controls.Add(this.grillaAgentesAsociados);
            this.gboxAsociados.Controls.Add(this.btnAsociarAgente);
            this.gboxAsociados.Controls.Add(this.txtAgente);
            this.gboxAsociados.Controls.Add(this.labelX2);
            this.gboxAsociados.Controls.Add(this.cboAgentesAsociados);
            this.gboxAsociados.Enabled = false;
            this.gboxAsociados.Location = new System.Drawing.Point(6, 78);
            this.gboxAsociados.Name = "gboxAsociados";
            this.gboxAsociados.Size = new System.Drawing.Size(315, 171);
            this.gboxAsociados.TabIndex = 9;
            this.gboxAsociados.TabStop = false;
            this.gboxAsociados.Text = "Agentes asociados";
            // 
            // grillaAgentesAsociados
            // 
            this.grillaAgentesAsociados.BackgroundColor = System.Drawing.Color.White;
            this.grillaAgentesAsociados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grillaAgentesAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaAgentesAsociados.DefaultCellStyle = dataGridViewCellStyle13;
            this.grillaAgentesAsociados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaAgentesAsociados.Location = new System.Drawing.Point(48, 52);
            this.grillaAgentesAsociados.Name = "grillaAgentesAsociados";
            this.grillaAgentesAsociados.Size = new System.Drawing.Size(239, 113);
            this.grillaAgentesAsociados.TabIndex = 12;
            // 
            // btnAsociarAgente
            // 
            this.btnAsociarAgente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAsociarAgente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAsociarAgente.Location = new System.Drawing.Point(227, 24);
            this.btnAsociarAgente.Name = "btnAsociarAgente";
            this.btnAsociarAgente.Size = new System.Drawing.Size(60, 22);
            this.btnAsociarAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAsociarAgente.TabIndex = 11;
            this.btnAsociarAgente.Text = "Asociar";
            // 
            // txtAgente
            // 
            this.txtAgente.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAgente.Border.Class = "TextBoxBorder";
            this.txtAgente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAgente.DisabledBackColor = System.Drawing.Color.White;
            this.txtAgente.ForeColor = System.Drawing.Color.Black;
            this.txtAgente.Location = new System.Drawing.Point(48, 24);
            this.txtAgente.Name = "txtAgente";
            this.txtAgente.PreventEnterBeep = true;
            this.txtAgente.Size = new System.Drawing.Size(173, 22);
            this.txtAgente.TabIndex = 10;
            this.txtAgente.TextChanged += new System.EventHandler(this.txtAgente_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(6, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "Agente";
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DisplayMember = "Text";
            this.cboTipoBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.ForeColor = System.Drawing.Color.Black;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.ItemHeight = 16;
            this.cboTipoBien.Location = new System.Drawing.Point(6, 21);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(121, 22);
            this.cboTipoBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTipoBien.TabIndex = 8;
            this.cboTipoBien.SelectionChangeCommitted += new System.EventHandler(this.cboTipoBien_SelectionChangeCommitted);
            // 
            // txtAgregarDetalle
            // 
            this.txtAgregarDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtAgregarDetalle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.txtAgregarDetalle.Location = new System.Drawing.Point(102, 255);
            this.txtAgregarDetalle.Name = "txtAgregarDetalle";
            this.txtAgregarDetalle.Size = new System.Drawing.Size(97, 29);
            this.txtAgregarDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtAgregarDetalle.TabIndex = 6;
            this.txtAgregarDetalle.Text = "Agregar";
            this.txtAgregarDetalle.Click += new System.EventHandler(this.txtAgregarDetalle_Click);
            // 
            // grillaDetalles
            // 
            this.grillaDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaDetalles.BackgroundColor = System.Drawing.Color.White;
            this.grillaDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.grillaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaDetalles.DefaultCellStyle = dataGridViewCellStyle15;
            this.grillaDetalles.EnableHeadersVisualStyles = false;
            this.grillaDetalles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grillaDetalles.Location = new System.Drawing.Point(327, 13);
            this.grillaDetalles.Name = "grillaDetalles";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.grillaDetalles.Size = new System.Drawing.Size(592, 274);
            this.grillaDetalles.TabIndex = 7;
            // 
            // txtCantBien
            // 
            this.txtCantBien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCantBien.Border.Class = "TextBoxBorder";
            this.txtCantBien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCantBien.DisabledBackColor = System.Drawing.Color.White;
            this.txtCantBien.ForeColor = System.Drawing.Color.Black;
            this.txtCantBien.Location = new System.Drawing.Point(285, 49);
            this.txtCantBien.Name = "txtCantBien";
            this.txtCantBien.PreventEnterBeep = true;
            this.txtCantBien.Size = new System.Drawing.Size(36, 22);
            this.txtCantBien.TabIndex = 5;
            this.txtCantBien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCantidad
            // 
            // 
            // 
            // 
            this.lblCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCantidad.Location = new System.Drawing.Point(233, 47);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(46, 23);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
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
            this.txtBien.Location = new System.Drawing.Point(6, 50);
            this.txtBien.Name = "txtBien";
            this.txtBien.PreventEnterBeep = true;
            this.txtBien.Size = new System.Drawing.Size(221, 22);
            this.txtBien.TabIndex = 3;
            this.txtBien.TextChanged += new System.EventHandler(this.txtBien_TextChanged);
            // 
            // cboBien
            // 
            this.cboBien.DisplayMember = "Text";
            this.cboBien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBien.ForeColor = System.Drawing.Color.Black;
            this.cboBien.FormattingEnabled = true;
            this.cboBien.ItemHeight = 16;
            this.cboBien.Location = new System.Drawing.Point(6, 50);
            this.cboBien.Name = "cboBien";
            this.cboBien.Size = new System.Drawing.Size(221, 22);
            this.cboBien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBien.TabIndex = 10;
            this.cboBien.SelectionChangeCommitted += new System.EventHandler(this.cboBien_SelectionChangeCommitted);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 25);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Dependencia";
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(15, 50);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(321, 22);
            this.textBoxX1.TabIndex = 1;
            this.ValidDep2.SetValidator1(this.textBoxX1, this.customValidator1);
            this.validDependencia.SetValidator1(this.textBoxX1, this.requiredFieldValidator2);
            this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 16;
            this.comboBoxEx4.Location = new System.Drawing.Point(15, 50);
            this.comboBoxEx4.MaxDropDownItems = 10;
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(321, 22);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 20;
            this.comboBoxEx4.Visible = false;
            this.comboBoxEx4.SelectionChangeCommitted += new System.EventHandler(this.comboBoxEx4_SelectionChangeCommitted);
            // 
            // cboAgentesAsociados
            // 
            this.cboAgentesAsociados.DisplayMember = "Text";
            this.cboAgentesAsociados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAgentesAsociados.ForeColor = System.Drawing.Color.Black;
            this.cboAgentesAsociados.FormattingEnabled = true;
            this.cboAgentesAsociados.ItemHeight = 16;
            this.cboAgentesAsociados.Location = new System.Drawing.Point(48, 24);
            this.cboAgentesAsociados.Name = "cboAgentesAsociados";
            this.cboAgentesAsociados.Size = new System.Drawing.Size(173, 22);
            this.cboAgentesAsociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboAgentesAsociados.TabIndex = 13;
            this.cboAgentesAsociados.SelectionChangeCommitted += new System.EventHandler(this.cboAgentesAsociados_SelectionChangeCommitted);
            // 
            // validDependencia
            // 
            this.validDependencia.ContainerControl = this;
            this.validDependencia.ErrorProvider = this.errorProvider1;
            this.validDependencia.Highlighter = this.highlighter1;
            this.validDependencia.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.ValidatingEventPerControl;
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
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Ingrese una Dependencia";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // ValidDep2
            // 
            this.ValidDep2.ContainerControl = this;
            this.ValidDep2.ErrorProvider = this.errorProvider2;
            this.ValidDep2.Highlighter = this.highlighter2;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // highlighter2
            // 
            this.highlighter2.ContainerControl = this;
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "No son iguales";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator1_ValidateValue);
            // 
            // CrearSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 717);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CrearSolicitud";
            this.Text = "Crear Solicitud";
            this.Load += new System.EventHandler(this.CrearSolicitud_Load);
            this.panel1.ResumeLayout(false);
            this.gboxNotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.gboxBienes.ResumeLayout(false);
            this.gboxAsociados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgentesAsociados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gboxBienes;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaDetalles;
        private DevComponents.DotNetBar.ButtonX txtAgregarDetalle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCantBien;
        private DevComponents.DotNetBar.LabelX lblCantidad;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBien;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipoBien;
        private System.Windows.Forms.GroupBox gboxAsociados;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAgente;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnAsociarAgente;
        private DevComponents.DotNetBar.Controls.DataGridViewX grillaAgentesAsociados;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.GroupBox gboxNotas;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAgentesAsociados;
        private DevComponents.DotNetBar.Validator.SuperValidator validDependencia;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.SuperValidator ValidDep2;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter2;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
    }
}