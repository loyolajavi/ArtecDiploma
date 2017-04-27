Imports Framework.Loyola
Imports System.Text
Imports System.Data.SqlClient

Public Class frmBackup

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim Directorio As New FolderBrowserDialog

        If Directorio.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtRuta.Text = Directorio.SelectedPath
        End If
    End Sub

    Private Sub btnCrearBackup_Click(sender As Object, e As EventArgs) Handles btnCrearBackup.Click

        Dim unaConexion As New Conexion(Conexion.MotoresDisponibles.SqlServerClient)

        If txtRuta.Text.Length <> 3 Then
            txtRuta.Text = txtRuta.Text + "\" + txtNombre.Text + ".bak"
        Else
            txtRuta.Text = txtRuta.Text + txtNombre.Text + ".bak"
        End If


        Try
            unaConexion.ConexionIniciar("Data Source=PCJAVI\SQLExpress;Initial Catalog=PatenteFamiliaEjemplo;Integrated Security=SSPI")

            Dim sCmd As New StringBuilder

            unaConexion.Ejecutar("BACKUP DATABASE [" + txtBase.Text + "] TO DISK = N'" + txtRuta.Text + "' WITH DESCRIPTION = N'" + txtObs.Text + "', NOFORMAT, NOINIT, NAME = N'" + txtNombre.Text + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", False, IConexion.TipoRetorno.SinResultado)
            MsgBox("Backup realizado")
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            unaConexion.ConexionFinalizar()
        End Try



    End Sub


End Class