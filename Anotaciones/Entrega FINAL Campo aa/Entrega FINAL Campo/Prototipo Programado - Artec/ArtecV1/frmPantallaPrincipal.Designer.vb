<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPantallaPrincipal
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlSolicitud = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
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
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResguardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(75, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Crear Solicitud"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(75, 214)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(208, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Buscar Solicitud"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlSolicitud
        '
        Me.pnlSolicitud.Location = New System.Drawing.Point(44, 117)
        Me.pnlSolicitud.Name = "pnlSolicitud"
        Me.pnlSolicitud.Size = New System.Drawing.Size(283, 167)
        Me.pnlSolicitud.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Location = New System.Drawing.Point(44, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(283, 167)
        Me.Panel2.TabIndex = 3
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(31, 99)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(208, 40)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Buscar Partida Especial"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(31, 31)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(208, 40)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Crear Partida Especial"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 31)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(709, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolicitudesToolStripMenuItem, Me.OrdenDeCompraToolStripMenuItem, Me.InformesToolStripMenuItem, Me.AltasToolStripMenuItem, Me.BackupToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(709, 31)
        Me.MenuStrip1.TabIndex = 5
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
        Me.CrearToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
        Me.CrearToolStripMenuItem.Text = "Crear"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
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
        Me.CrearToolStripMenuItem1.Size = New System.Drawing.Size(152, 28)
        Me.CrearToolStripMenuItem1.Text = "Crear"
        '
        'SolicitarToolStripMenuItem
        '
        Me.SolicitarToolStripMenuItem.Name = "SolicitarToolStripMenuItem"
        Me.SolicitarToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
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
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(70, 27)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(376, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(283, 167)
        Me.Panel1.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(36, 97)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(208, 40)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Buscar Remito"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(36, 30)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(208, 40)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Crear Remito"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(412, 338)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(208, 40)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "Autorizar Software"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(412, 384)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(208, 40)
        Me.Button8.TabIndex = 9
        Me.Button8.Text = "Productos"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(412, 430)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(208, 40)
        Me.Button9.TabIndex = 10
        Me.Button9.Text = "Proveedores"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(376, 320)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(283, 167)
        Me.Panel3.TabIndex = 5
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
        'frmPantallaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 701)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pnlSolicitud)
        Me.Controls.Add(Me.Panel3)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPantallaPrincipal"
        Me.Text = "Artec"
        Me.Panel2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnlSolicitud As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SolicitudesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolicitarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DependenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PerfilUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolicitudesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenesDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartidasEspecialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoftwareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResguardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
