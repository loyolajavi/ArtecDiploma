<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudBuscar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SolicitudesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitudesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartidasEspecialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DependenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerfilUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoftwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResguardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(529, 231)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 58)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "Seleccionar Solicitud"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 165)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 23)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Buscar Solicitud"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 215)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(508, 91)
        Me.DataGridView1.TabIndex = 38
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(106, 122)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(415, 22)
        Me.TextBox3.TabIndex = 37
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(106, 88)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(173, 22)
        Me.TextBox2.TabIndex = 36
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(106, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Dependencia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Usuario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Nro Solicitud"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolicitudesToolStripMenuItem, Me.OrdenDeCompraToolStripMenuItem, Me.InformesToolStripMenuItem, Me.AltasToolStripMenuItem, Me.BackupToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(662, 31)
        Me.MenuStrip1.TabIndex = 41
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SolicitudesToolStripMenuItem
        '
        Me.SolicitudesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearToolStripMenuItem, Me.BuscarToolStripMenuItem})
        Me.SolicitudesToolStripMenuItem.Name = "SolicitudesToolStripMenuItem"
        Me.SolicitudesToolStripMenuItem.Size = New System.Drawing.Size(103, 27)
        Me.SolicitudesToolStripMenuItem.Text = "Solicitudes"
        '
        'CrearToolStripMenuItem
        '
        Me.CrearToolStripMenuItem.Name = "CrearToolStripMenuItem"
        Me.CrearToolStripMenuItem.Size = New System.Drawing.Size(130, 28)
        Me.CrearToolStripMenuItem.Text = "Crear"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(130, 28)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'OrdenDeCompraToolStripMenuItem
        '
        Me.OrdenDeCompraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearToolStripMenuItem1, Me.SolicitarToolStripMenuItem})
        Me.OrdenDeCompraToolStripMenuItem.Name = "OrdenDeCompraToolStripMenuItem"
        Me.OrdenDeCompraToolStripMenuItem.Size = New System.Drawing.Size(141, 27)
        Me.OrdenDeCompraToolStripMenuItem.Text = "Partida Especial"
        '
        'CrearToolStripMenuItem1
        '
        Me.CrearToolStripMenuItem1.Name = "CrearToolStripMenuItem1"
        Me.CrearToolStripMenuItem1.Size = New System.Drawing.Size(130, 28)
        Me.CrearToolStripMenuItem1.Text = "Crear"
        '
        'SolicitarToolStripMenuItem
        '
        Me.SolicitarToolStripMenuItem.Name = "SolicitarToolStripMenuItem"
        Me.SolicitarToolStripMenuItem.Size = New System.Drawing.Size(130, 28)
        Me.SolicitarToolStripMenuItem.Text = "Buscar"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolicitudesToolStripMenuItem1, Me.OrdenesDeCompraToolStripMenuItem, Me.PartidasEspecialesToolStripMenuItem, Me.ProductosToolStripMenuItem})
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(89, 27)
        Me.InformesToolStripMenuItem.Text = "Informes"
        '
        'SolicitudesToolStripMenuItem1
        '
        Me.SolicitudesToolStripMenuItem1.Name = "SolicitudesToolStripMenuItem1"
        Me.SolicitudesToolStripMenuItem1.Size = New System.Drawing.Size(230, 28)
        Me.SolicitudesToolStripMenuItem1.Text = "Solicitudes"
        '
        'OrdenesDeCompraToolStripMenuItem
        '
        Me.OrdenesDeCompraToolStripMenuItem.Name = "OrdenesDeCompraToolStripMenuItem"
        Me.OrdenesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(230, 28)
        Me.OrdenesDeCompraToolStripMenuItem.Text = "Remitos"
        '
        'PartidasEspecialesToolStripMenuItem
        '
        Me.PartidasEspecialesToolStripMenuItem.Name = "PartidasEspecialesToolStripMenuItem"
        Me.PartidasEspecialesToolStripMenuItem.Size = New System.Drawing.Size(230, 28)
        Me.PartidasEspecialesToolStripMenuItem.Text = "Partidas Especiales"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(230, 28)
        Me.ProductosToolStripMenuItem.Text = "Productos/Software"
        '
        'AltasToolStripMenuItem
        '
        Me.AltasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProveedoresToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.DependenciasToolStripMenuItem, Me.PerfilUsuarioToolStripMenuItem, Me.SoftwareToolStripMenuItem, Me.ProductoToolStripMenuItem})
        Me.AltasToolStripMenuItem.Name = "AltasToolStripMenuItem"
        Me.AltasToolStripMenuItem.Size = New System.Drawing.Size(65, 27)
        Me.AltasToolStripMenuItem.Text = "ABMs"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(187, 28)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(187, 28)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'DependenciasToolStripMenuItem
        '
        Me.DependenciasToolStripMenuItem.Name = "DependenciasToolStripMenuItem"
        Me.DependenciasToolStripMenuItem.Size = New System.Drawing.Size(187, 28)
        Me.DependenciasToolStripMenuItem.Text = "Dependencias"
        '
        'PerfilUsuarioToolStripMenuItem
        '
        Me.PerfilUsuarioToolStripMenuItem.Name = "PerfilUsuarioToolStripMenuItem"
        Me.PerfilUsuarioToolStripMenuItem.Size = New System.Drawing.Size(187, 28)
        Me.PerfilUsuarioToolStripMenuItem.Text = "Perfil Usuario"
        '
        'SoftwareToolStripMenuItem
        '
        Me.SoftwareToolStripMenuItem.Name = "SoftwareToolStripMenuItem"
        Me.SoftwareToolStripMenuItem.Size = New System.Drawing.Size(187, 28)
        Me.SoftwareToolStripMenuItem.Text = "Software"
        '
        'ProductoToolStripMenuItem
        '
        Me.ProductoToolStripMenuItem.Name = "ProductoToolStripMenuItem"
        Me.ProductoToolStripMenuItem.Size = New System.Drawing.Size(187, 28)
        Me.ProductoToolStripMenuItem.Text = "Producto"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResguardarToolStripMenuItem})
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(77, 27)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'ResguardarToolStripMenuItem
        '
        Me.ResguardarToolStripMenuItem.Name = "ResguardarToolStripMenuItem"
        Me.ResguardarToolStripMenuItem.Size = New System.Drawing.Size(166, 28)
        Me.ResguardarToolStripMenuItem.Text = "Resguardar"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(70, 27)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(15, 353)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(634, 270)
        Me.DataGridView2.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 334)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 16)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Datos Solicitud"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(52, 642)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 53)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "Crear Partida Especial"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(193, 642)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(119, 53)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "Crear Remito"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(333, 642)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(119, 53)
        Me.Button5.TabIndex = 46
        Me.Button5.Text = "Modificar Solicitud"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(473, 642)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(119, 53)
        Me.Button6.TabIndex = 47
        Me.Button6.Text = "Autorizar Software"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'frmSolicitudBuscar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 716)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSolicitudBuscar"
        Me.Text = "Buscar Solicitud"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SolicitudesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolicitarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolicitudesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenesDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartidasEspecialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DependenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PerfilUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoftwareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResguardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
