Public Class F_Main
    Private szText As String
    Private PlayList As New PlayList

    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim PlayList As New PlayList
        Dim mySettings As New PPLInk.Settings
        Dim szConn = mySettings.ProHelpConnectionUser
        Dim szDebug = mySettings.ProHelpDebug
        LblVersion.Text = "1.2.23"     'Me.ProductVersion
        'Z.Y.X.W - Z.Y is major/minor version; X is VS publish number; W is not used
        'See the end of the file for history

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

        MyBase.WindowState = FormWindowState.Minimized
        PlayList.Run(LBPlayList.Items)
        MyBase.WindowState = FormWindowState.Normal
        TxtSearch.Text = ""
        TxtSearch.Focus()
    End Sub

    Private Sub Files_DoubleClick(sender As Object, e As EventArgs) Handles T_filesDataGridView.DoubleClick
        Dim szFName As String, szFile_no As Integer

        szFName = T_filesDataGridView.SelectedRows(0).Cells(1).Value
        szFile_no = T_filesDataGridView.SelectedRows(0).Cells(0).Value
        LBInstant.Items.Clear()
        LBInstant.Items.Add(szFile_no & "::" & szFName)
        MyBase.WindowState = FormWindowState.Minimized
        PlayList.Run(LBInstant.Items)
        MyBase.WindowState = FormWindowState.Normal
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
        Select Case e.KeyCode
            Case Keys.Enter
                PlayList_AddRecord()
            Case Keys.Up
                T_filesChangeSelection(-1)
            Case Keys.Down
                T_filesChangeSelection(1)
            Case Else
                Exit Sub
        End Select

        e.SuppressKeyPress = True
        TxtSearch.Text = ""
        TxtSearch.Focus()
    End Sub

    Sub T_filesChangeSelection(ByVal iChange As Integer)
        Dim iRow As Integer = 0
        'Dim iSelected As DataGridViewRow = T_filesDataGridView.SelectedRows(0)

        While iRow < T_filesDataGridView.RowCount
            If T_filesDataGridView.SelectedRows.Contains(T_filesDataGridView.Rows(iRow)) Then Exit While
            iRow = iRow + 1
        End While

        If iRow = T_filesDataGridView.RowCount Then
            ' no selected row
            Exit Sub
        ElseIf iChange = 1 And iRow = T_filesDataGridView.RowCount - 1 Then
            ' at end of list
            Exit Sub
        ElseIf iChange = -11 And iRow = 0 Then
            ' at beginning of list
            Exit Sub
        End If

        T_filesDataGridView.Rows(iRow + iChange).Selected = True
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

    Private Sub BtnAdvanced_Click(sender As Object, e As EventArgs) Handles BtnAdvanced.Click
        F_Advanced.ShowDialog()
    End Sub

    Private Sub LBPlayList_KeyDown(sender As Object, e As KeyEventArgs) Handles LBPlayList.KeyDown
        Dim iSelected As Integer = LBPlayList.SelectedIndex
        Dim iIndex As Integer = 0
        Dim szQueue As New Queue(Of String)

        Select Case e.KeyCode
            Case Keys.Delete
                While iIndex < LBPlayList.Items.Count
                    If iIndex <> iSelected Then szQueue.Enqueue(LBPlayList.Items(iIndex))
                    iIndex = iIndex + 1
                End While
                LBPlayList.Items.Clear()
                iIndex = 0
                While szQueue.Count > 0
                    LBPlayList.Items.Add(szQueue.Dequeue)
                End While

            Case Keys.Add
                If iSelected < LBPlayList.Items.Count - 1 Then
                    szQueue.Enqueue(LBPlayList.Items(iSelected))
                    szQueue.Enqueue(LBPlayList.Items(iSelected + 1))
                    LBPlayList.Items(iSelected + 1) = szQueue.Dequeue
                    LBPlayList.Items(iSelected) = szQueue.Dequeue
                End If

            Case Keys.Subtract
                If iSelected > 0 Then
                    szQueue.Enqueue(LBPlayList.Items(iSelected))
                    szQueue.Enqueue(LBPlayList.Items(iSelected - 1))
                    LBPlayList.Items(iSelected - 1) = szQueue.Dequeue
                    LBPlayList.Items(iSelected) = szQueue.Dequeue
                End If

            Case Else
                Exit Sub
        End Select

        e.SuppressKeyPress = True

    End Sub

    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles BtnHelp.Click

    End Sub
End Class

'Version nuber
'Z.Y.X.W - Z.Y is major/minor version; X is VS publish number
'1.2    add handling for up arrow, down arrow to search box and clear it after ENTER
'       add edit features to the Play List
'1.1.18 bug fix in List Export when column is null
'1.1.17 used the actual VS publish number as the third segment 
'1.1.16 included manual setting of the version number on the main screen (used 1.1.1)
'1.1.15 included Export of file list
'1.0.14 was the last version without Advanced options 