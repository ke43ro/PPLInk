Public Class F_Advanced
    Private isT_FilesUpdated As Boolean = False
    Private mySettings As New PPLInk.Settings
    '    Private isShort As String

    Private Sub F_Advanced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim szConn = mySettings.ProHelpConnectionUser
        ''LblVersion.Text = Me.ProductVersion

        'Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
        'T_filesTableAdapter.Connection = connection
        'Me.T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files, isShort)

        ChkAutoSelectList.Checked = IIf(mySettings.ProHelpAutoShortList = "Y", True, False)
    End Sub

    Private Sub F_Advanced_Closed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'If isT_FilesUpdated Then
        '    Me.DialogResult = DialogResult.Yes
        'Else
        '    Me.DialogResult = DialogResult.No
        'End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        F_CompareWithMaster.ShowDialog()
    End Sub

    Private Sub ChkAutoSelectList_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAutoSelectList.CheckedChanged
        If ChkAutoSelectList.Checked = True Then
            mySettings.ProHelpAutoShortList = "Y"
        Else
            mySettings.ProHelpAutoShortList = "N"
        End If

        mySettings.Save()
    End Sub
End Class