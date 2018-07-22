Public Class F_Help
    Private Sub BtnAdmin_Click(sender As Object, e As EventArgs) Handles BtnAdmin.Click
        Try
            Process.Start(Application.StartupPath & "\PPLink Administrator Manual.pdf")
        Catch ex As Exception
            MessageBox.Show("Can't open Admninistrator Manual" & vbCrLf & ex.Message, "Powerpoint Link: Help",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BtnUser_Click(sender As Object, e As EventArgs) Handles BtnUser.Click
        MessageBox.Show(Application.StartupPath)

        Try
            Process.Start(Application.StartupPath & "\PPLink User Manual.pdf")
        Catch ex As Exception
            MessageBox.Show("Can't open User Manual" & vbCrLf & ex.Message, "Powerpoint Link: Help",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class