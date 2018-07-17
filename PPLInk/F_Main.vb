Imports System.Diagnostics
Imports System.Data.SqlClient

Public Class F_Main
    Private szText As String
    Private PlayList As New PlayList

    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mySettings As New PPLInk.Settings
        Dim szConn = mySettings.ProHelpConnectionUser
        Dim szDebug = mySettings.ProHelpDebug
        Dim connection As New SqlConnection(mySettings.ProHelpConnectionString)
        Dim szVersion As String

        Try
            szVersion = PPLInk.My.Application.Deployment.CurrentVersion.ToString
        Catch
            szVersion = "1.4.0.42 Proto"
        End Try
        LblVersion.Text = szVersion
        'Z.Y.X.W - Z.Y is major/minor version; X is build number, always 0; W is VS publish number
        'Z.X.Y are set in Project Properties, W is automatic (also controlled in Prroject Properties)
        'See the end of the file for history

        If szDebug = "Yes" Then MessageBox.Show("loading")
        If szConn = "" Then
            MessageBox.Show("The settings for PowerPoint Link have not been created.  Please use the Set Up button to initialise this program",
                            "PowerPoint Link: Settings Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Try
                If szDebug = "Yes" Then MessageBox.Show("trying " & szConn)
                connection = New SqlConnection(szConn)
                T_filesTableAdapter.Connection = connection
            Catch ex As Exception
                MessageBox.Show("Connection Failure:" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace,
                                "PowerPoint Link: Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Do necessary upgrades
        Dim priorVersion = mySettings.ProHelpVersion
        Dim bUpdated As Boolean = False
        Select Case priorVersion
            Case ""
                ' Doesn't have extended length of t_files.f_altname
                Dim cmd1 As SqlCommand = New SqlCommand("use ProHelp", connection)
                Dim cmd2 As SqlCommand = New SqlCommand("Alter table t_files Alter column f_altname varchar(250)", connection)
                connection.Open()
                cmd1.ExecuteNonQuery()
                cmd2.ExecuteNonQuery()
                mySettings.ProHelpVersion = "1.4.0.36"
                mySettings.Save()
                MessageBox.Show("Upgraded length of t_files.f_altname",
                                "PowerPointLink: Automatic Upgrader", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bUpdated = True

            Case "1.4.36"
                mySettings.ProHelpVersion = "1.4.0.36"
                mySettings.Save()

            Case szVersion
                ' NOP

            Case >= "1.4.0.39"
                mySettings.ProHelpVersion = szVersion
                mySettings.Save()

            Case >= "1.4.0.36"
                Dim cmd1 As SqlCommand = New SqlCommand("use ProHelp", connection)
                Dim cmd2 As SqlCommand = New SqlCommand("update t_files set last_dt = create_dt where last_dt is null", connection)
                connection.Open()
                cmd1.ExecuteNonQuery()
                cmd2.ExecuteNonQuery()
                mySettings.ProHelpVersion = szVersion
                mySettings.Save()
                MessageBox.Show("Upgraded t_files.last_dt - never null, 1.4.0.36")
                bUpdated = True

        End Select
        If bUpdated Then
            MessageBox.Show("An upgrade was done.  PowerPoint Link must be restarted",
                                "PowerPointLink: Automatic Upgrader", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
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
                TxtSearch.Text = ""
            Case Keys.Up
                T_filesChangeSelection(-1)
            Case Keys.Down
                T_filesChangeSelection(1)
            Case Else
                Exit Sub
        End Select

        e.SuppressKeyPress = True
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
        ElseIf iChange = -1 And iRow = 0 Then
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
        Dim mySettings As New PPLInk.Settings, newSettings As PPLInk.Settings
        Dim szConn = mySettings.ProHelpConnectionUser
        Dim Result = F_SetUp.ShowDialog()
        TxtSearch.Focus()

        newSettings = New PPLInk.Settings
        If szConn <> newSettings.ProHelpConnectionUser Then
            MessageBox.Show("The database connection has been changed.  PPLink needs to close.  Please reopen it to continue",
                            "PowerPoint Link: Setup", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
        End If

        ' Has T_FILES been modified?
        If Result = DialogResult.Yes Then
            T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)
        End If
    End Sub

    Private Sub F_Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TxtSearch.Focus()
    End Sub

    Private Sub BtnAdvanced_Click(sender As Object, e As EventArgs) Handles BtnAdvanced.Click
        'KWR 20180615: Fill table is so fast, do it anyway since new structure is harder to check for changes
        'Dim Result = F_Advanced.ShowDialog()
        ' Has T_FILES been modified?
        'If Result = DialogResult.Yes Then
        '   T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)
        'End If
        F_Advanced.ShowDialog()
        T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)
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
        Try
            Process.Start(Application.StartupPath & "\PPLink Documentation.pdf")
        Catch ex As Exception
            MessageBox.Show("Can't open Help Pages" & vbCrLf & ex.Message, "Powerpoint Link: Help",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BtnLoadList_Click(sender As Object, e As EventArgs) Handles BtnLoadList.Click
        DlgLoadList.Fillqueue(LBPlayList)
        DlgLoadList.ShowDialog()
        ' returns No if a Save was done, Yes if a Load was done or Cancel
        If DlgLoadList.DialogResult = DialogResult.Yes Then
            DlgLoadList.GetList(LBPlayList)
        End If
    End Sub
End Class

'Version number
'Z.Y.X.W - Z.Y.X is major version.minor version.build; W is VS publish number
'1.4.0.42 Update File List work completed; Database modified so that no datetime fields are ever NULL
'1.4.0.37 expanded Advanced menu structure; added Edit Files and Update File List
'1.4.0.36 get version number from the deployment
'X not used below
'1.4.33 make instructions text read only; extend Import File List feature; Alternative Name field extended to 250 characters
'1.4.32 included list import and Help button to open PDF file
'1.3.28 fix bug in handling keys in search box (cleared text on arrow up or down)
'1.3.27 fix bug in table connection in DlgLoadList (tried to connect iwhen setting checkbox on load)
'1.3.26 add save and load for Play Lists
'1.2.25 experiment with PP focus
'1.2.24 add handling for up arrow, down arrow to search box and clear it after ENTER
'       add edit features to the Play List
'1.1.18 bug fix attempt in List Export when column is null - fixed in tables, not code
'1.1.17 used the actual VS publish number as the third segment 
'1.1.16 included manual setting of the version number on the main screen (used 1.1.1)
'1.1.15 included Export of file list
'1.0.14 was the last version without Advanced options 