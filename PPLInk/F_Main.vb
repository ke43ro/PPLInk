Public Class F_Main
    Private szText As String
    Private PlayList As New PlayList

    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PlayList As New PlayList
        Dim mySettings As New PPLInk.Settings
        Dim szConn = mySettings.ProHelpConnectionUser
        Dim szDebug = mySettings.ProHelpDebug
        LblVersion.Text = Me.ProductVersion

        If szDebug = "Yes" Then MessageBox.Show("loading")
        If szConn = "" Then
            MessageBox.Show("The settings for PowerPoint Link have not been created.  Please use the Set Up button to initialise this program",
                            "PowerPoint Link: Settings Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Try
                If szDebug = "Yes" Then MessageBox.Show("trying " & szConn)
                Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
                T_filesTableAdapter.Connection = connection
            Catch ex As Exception
                MessageBox.Show("Connection Failure:" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace,
                                "PowerPoint Link: Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If szDebug = "Yes" Then MessageBox.Show("filling")
        Me.T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)
        TxtSearch.Focus()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        LBPlayList.Items.Clear()
        TxtSearch.Text = ""
    End Sub

    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles BtnPlay.Click
        If LBPlayList.Items.Count = 0 Then
            MessageBox.Show("Please add some items to the list",
                            "PowerPoint Link: Playing the list", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        PlayList.Run(LBPlayList.Items)
        TxtSearch.Text = ""
        TxtSearch.Focus()
    End Sub

    Private Sub Files_DoubleClick(sender As Object, e As EventArgs) Handles T_filesDataGridView.DoubleClick
        Dim szFName As String, szFile_no As Integer

        szFName = T_filesDataGridView.SelectedRows(0).Cells(1).Value
        szFile_no = T_filesDataGridView.SelectedRows(0).Cells(0).Value
        LBInstant.Items.Clear()
        LBInstant.Items.Add(szFile_no & "::" & szFName)
        PlayList.Run(LBInstant.Items)
        TxtSearch.Text = ""
        TxtSearch.Focus()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        PlayList_AddRecord()
        TxtSearch.Text = ""
        TxtSearch.Focus()
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        szText = TxtSearch.Text
        T_filesTableAdapter.FillByPhrase(ProHelpDataSet.t_files, szText)
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown

        If e.KeyCode <> Keys.Enter Then Exit Sub

        PlayList_AddRecord()
        e.SuppressKeyPress = True
    End Sub

    Private Sub PlayList_AddRecord()
        Dim iSongNo As Integer
        Dim szFileName As String

        '-- get file_no
        Dim bRowSel As Boolean = True

        If T_filesDataGridView.SelectedRows.Count = 0 Then
            bRowSel = False
        ElseIf T_filesDataGridView.SelectedRows(0).IsNewRow Then
            bRowSel = False
        End If

        If bRowSel = False Then
            MessageBox.Show("Please select a File from the lower table to add to this list",
                            "PowerPoint Link: Adding a file to the PlayList",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        iSongNo = T_filesDataGridView.SelectedRows(0).Cells(0).Value
        szFileName = T_filesDataGridView.SelectedRows(0).Cells(1).Value

        '-- Add the new row
        LBPlayList.Items.Add(iSongNo & "::" & szFileName)
    End Sub

    Private Sub BtnSetup_Click(sender As Object, e As EventArgs) Handles BtnSetup.Click
        F_SetUp.ShowDialog()
        TxtSearch.Focus()
    End Sub

    Private Sub F_Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TxtSearch.Focus()
    End Sub
End Class
