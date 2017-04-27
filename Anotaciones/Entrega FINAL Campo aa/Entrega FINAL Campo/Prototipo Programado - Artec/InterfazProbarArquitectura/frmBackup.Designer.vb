<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
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
        Me.btnCrearBackup = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCrearBackup
        '
        Me.btnCrearBackup.Location = New System.Drawing.Point(218, 215)
        Me.btnCrearBackup.Name = "btnCrearBackup"
        Me.btnCrearBackup.Size = New System.Drawing.Size(118, 23)
        Me.btnCrearBackup.TabIndex = 0
        Me.btnCrearBackup.Text = "Crear Backup"
        Me.btnCrearBackup.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Servidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre Backup"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Guardar en:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(294, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Base de Datos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Observación"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(121, 36)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.ReadOnly = True
        Me.txtServidor.Size = New System.Drawing.Size(157, 22)
        Me.txtServidor.TabIndex = 6
        Me.txtServidor.Text = "PCJAVI\SQLExpress"
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(121, 71)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(345, 22)
        Me.txtRuta.TabIndex = 7
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(121, 102)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(157, 22)
        Me.txtNombre.TabIndex = 8
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(121, 136)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(426, 58)
        Me.txtObs.TabIndex = 9
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(398, 36)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.ReadOnly = True
        Me.txtBase.Size = New System.Drawing.Size(149, 22)
        Me.txtBase.TabIndex = 10
        Me.txtBase.Text = "PatenteFamiliaEjemplo"
        '
        'btnExaminar
        '
        Me.btnExaminar.Location = New System.Drawing.Point(472, 71)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar.TabIndex = 11
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 250)
        Me.Controls.Add(Me.btnExaminar)
        Me.Controls.Add(Me.txtBase)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCrearBackup)
        Me.Name = "frmBackup"
        Me.Text = "Resguardar Base de Datos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCrearBackup As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
End Class
