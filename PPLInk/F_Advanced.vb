Public Class F_Advanced
    Private isT_FilesUpdated As Boolean = False

    Private Sub F_Advanced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mySettings As New PPLInk.Settings
        Dim szConn = mySettings.ProHelpConnectionUser
        'LblVersion.Text = Me.ProductVersion

        Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
        T_filesTableAdapter.Connection = connection
        Me.T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)

    End Sub

    Private Sub F_Advanced_Closed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If isT_FilesUpdated Then
            Me.DialogResult = DialogResult.Yes
        Else
            Me.DialogResult = DialogResult.No
        End If
    End Sub

    Private Sub BtnListIO_Click(sender As Object, e As EventArgs) Handles BtnListIO.Click
        F_List_IO.ShowDialog()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        F_EditFileList.ShowDialog()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        F_UpdateFileList.ShowDialog()
    End Sub
End Class