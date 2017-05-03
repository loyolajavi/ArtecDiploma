<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.menuIdioma = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EspañolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InglésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnIngresar
        '
        resources.ApplyResources(Me.btnIngresar, "btnIngresar")
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'lblContraseña
        '
        resources.ApplyResources(Me.lblContraseña, "lblContraseña")
        Me.lblContraseña.Name = "lblContraseña"
        '
        'txtContraseña
        '
        resources.ApplyResources(Me.txtContraseña, "txtContraseña")
        Me.txtContraseña.Name = "txtContraseña"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuIdioma})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'menuIdioma
        '
        Me.menuIdioma.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EspañolToolStripMenuItem, Me.InglésToolStripMenuItem})
        Me.menuIdioma.Name = "menuIdioma"
        resources.ApplyResources(Me.menuIdioma, "menuIdioma")
        '
        'EspañolToolStripMenuItem
        '
        Me.EspañolToolStripMenuItem.Name = "EspañolToolStripMenuItem"
        resources.ApplyResources(Me.EspañolToolStripMenuItem, "EspañolToolStripMenuItem")
        '
        'InglésToolStripMenuItem
        '
        Me.InglésToolStripMenuItem.Name = "InglésToolStripMenuItem"
        resources.ApplyResources(Me.InglésToolStripMenuItem, "InglésToolStripMenuItem")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtUsuario
        '
        resources.ApplyResources(Me.txtUsuario, "txtUsuario")
        Me.txtUsuario.Name = "txtUsuario"
        '
        'frmLogin
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.btnIngresar)
        Me.Name = "frmLogin"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents menuIdioma As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents EspañolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InglésToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox

End Class
