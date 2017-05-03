Public Class frmPantallaPrincipal


    Private Sub AltasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltasToolStripMenuItem.Click

    End Sub


    Private Sub ResguardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResguardarToolStripMenuItem.Click

        Dim unafrmBackup As New frmBackup
        frmBackup.Show()

    End Sub

    Private Sub frmPantallaPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmLogin.Close()
    End Sub
End Class