Imports System.Data.SqlClient

Public Class F_UpdateFileList
    Private connection As SqlConnection
    Private iNoFile As Integer
    Private bFoundActive, bNewSelect As Boolean
    Private mySettings As New PPLInk.Settings
    Const iInactive As Integer = 1
    Const iDeleteAll As Integer = 2
    Const iDeleteThis As Integer = 3

    Private Sub F_UpdateFileList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim szConn = mySettings.ProHelpConnectionUser

        connection = New SqlConnection(szConn)
        T_filesTableAdapter.Connection = connection
        Tx_playlist_songTableAdapter.Connection = connection
        Me.T_filesTableAdapter.FillAll(Me.ProHelpDataSet.t_files)
        Me.Tx_playlist_songTableAdapter.Fill(Me.ProHelpDataSet.tx_playlist_song)

        TxtFolder.Text = mySettings.ProHelpMasterFolder
        RBtnMakeActive.Checked = True
        RBtnMakeInactive.Checked = True
        RBtnMakeSelect.Checked = True
    End Sub


    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        FolderBrowserDialog1.SelectedPath = TxtFolder.Text
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TxtFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
        If Dir(TxtFolder.Text) = "" Then
            MessageBox.Show("I can't find folder " & TxtFolder.Text & ".  Please try again", "PowerPoint Link: Update Files List",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mySettings.ProHelpMasterFolder = TxtFolder.Text
            mySettings.Save()
        End If

    End Sub


    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim szParts(2) As String
        Dim myKeyParser As New KeyParser

        If Not CheckButtons() Then Exit Sub

        Cursor = Cursors.WaitCursor
        ListBox1.Items.Clear()

        Dim DupesReturn As String = RemoveDupes()
        myKeyParser.GetKeyValues(DupesReturn, "::", szParts)
        If szParts(0) = "0" Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        ' message for record is in szParts(1)
        DupesReturn = szParts(1)
        ListBox1.Items.Add("During deduplication, " & DupesReturn)

        If Dir(TxtFolder.Text, vbDirectory) = "" Then
            MessageBox.Show("I can't find folder " & TxtFolder.Text & ".  Please choose another.", "PowerPoint Link: Update Files List",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim T_DiskFiles = CreateTableDF()
        Dim DiskReturn As Integer = GetFiles(T_DiskFiles)
        If DiskReturn = 0 Then
            MessageBox.Show("No files were found in the specified folder structure", "PowerPoint Link: Update Files List",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cursor = Cursors.Default
            Exit Sub
        End If
        ListBox1.Items.Add(DiskReturn & " files were found on the disk")

        Dim CheckReturn As String = CheckExistingFiles(T_DiskFiles)
        myKeyParser.GetKeyValues(CheckReturn, "::", szParts)
        If szParts(0) = "0" Then
            MessageBox.Show("No file records were processed during check against the disk", "PowerPoint Link: Update Files List",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.Default
            Exit Sub
        End If
        CheckReturn = szParts(1)
        ListBox1.Items.Add(szParts(0) & " file records were processed during check of database against the disk")
        ListBox1.Items.Add(CheckReturn)

        ' check for new files
        Dim NewReturn As String = CheckNewFiles(T_DiskFiles)
        myKeyParser.GetKeyValues(NewReturn, "::", szParts)
        If szParts(0) = "0" Then
            MessageBox.Show("No new files were found on the disk", "PowerPoint Link: Update Files List",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.Default
            Exit Sub
        End If
        NewReturn = szParts(1)
        ListBox1.Items.Add(szParts(0) & " new file records were added to the database")
        ListBox1.Items.Add(NewReturn)

        Cursor = Cursors.Default
    End Sub

    Private Function CheckButtons() As Boolean
        CheckButtons = True

        If RBtnMakeInactive.Checked Then
            iNoFile = iInactive
        ElseIf RBtnDeleteAll.Checked Then
            iNoFile = iDeleteAll
        ElseIf RBtnDeleteThis.Checked Then
            iNoFile = iDeleteThis
        Else
            MessageBox.Show("Programming error: impossible state of Missing file radio buttons",
                    "PowerPoint Link: Update the File List",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
            CheckButtons = False
        End If

        If RBtnMakeActive.Checked Then
            bFoundActive = True
        ElseIf RBtnNoActive.Checked Then
            bFoundActive = False
        Else
            MessageBox.Show("Programming error: impossible state of Inactive file radio buttons",
                    "PowerPoint Link: Update the File List",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
            CheckButtons = False
        End If

        If RBtnMakeSelect.Checked Then
            bNewSelect = True
        ElseIf RBtnNoSelect.Checked Then
            bNewSelect = False
        Else
            MessageBox.Show("Programming error: impossible state of new file radio buttons",
                    "PowerPoint Link: Update the File List",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
            CheckButtons = False
        End If
    End Function

    Private Function RemoveDupes() As String
        Dim fViewRow As DataRowView
        Dim filesView As New DataView(ProHelpDataSet.t_files, "", "file_no", DataViewRowState.CurrentRows)
        Dim MatchRows As DataView
        Dim nChanges, nTotal, iFileNo, iDupFileNo As Integer
        Dim matchN, matchP As String
        Dim szF_name, szF_path, szFAltName, szSelected, szLast_Action, szInactive, szSearch As String
        Dim dtLast_Dt, dtCreate_Dt As DateTime
        Dim bChanged As Boolean

        RemoveDupes = ""
        'txtResults.Text = txtResults.Text & vbCrLf & "Emptying Songs Table..."
        nTotal = filesView.Count
        If nTotal = 0 Then
            RemoveDupes = "0::There were no records in the Files table"
            MessageBox.Show("The Files table is empty", "PowerPoint Link: Update File List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        Else
            nChanges = 0
            For Each fViewRow In filesView
                bChanged = False
                iFileNo = fViewRow.Row.Item("file_no")
                matchN = fViewRow.Row.Item("f_name")
                matchN = matchN.Replace("'", "''")
                matchP = fViewRow.Row.Item("f_path")
                MatchRows = New DataView(ProHelpDataSet.t_files, "f_name='" & matchN & "' AND f_path='" & matchP & "'",
                                         "f_name, f_path", DataViewRowState.CurrentRows)
                For Each myRow In MatchRows
                    iDupFileNo = myRow.row.item("file_no")
                    If iDupFileNo <> iFileNo Then
                        Dim vPlaylists As New DataView(ProHelpDataSet.tx_playlist_song, "file_no=" & iDupFileNo, "file_no", DataViewRowState.CurrentRows)
                        If vPlaylists.Count > 0 Then

                            Dim SQLcmd As New SqlCommand("update tx_playlist_song set file_no = " & iFileNo &
                                                                " where file_no = " & iDupFileNo, connection)
                            'connection.Open()
                            SQLcmd.ExecuteNonQuery()
                        End If
                        vPlaylists.Dispose()

                        szF_name = myRow.row.item("f_name")
                        szF_path = myRow.row.item("f_path")
                        szFAltName = myRow.row.item("f_altname")
                        szSelected = myRow.row.item("selected")
                        szLast_Action = myRow.row.item("last_action")
                        szInactive = myRow.row.item("inactive")
                        dtLast_Dt = myRow.row.item("last_dt")
                        dtCreate_Dt = myRow.row.item("create_dt")
                        szSearch = myRow.row.Item("s_search")
                        Try
                            T_filesTableAdapter.Delete(iDupFileNo, szF_name, szF_path, szFAltName, szSelected,
                                dtCreate_Dt, dtLast_Dt, szLast_Action, szInactive, szSearch)
                            bChanged = True
                            nChanges = nChanges + 1
                        Catch ex As Exception
                            MessageBox.Show("Error deleting duplicate file record " & iDupFileNo & " (duplicate of " & iFileNo & ")" & vbCrLf &
                                "LD [" & dtLast_Dt & "]; " & "CD [" & dtCreate_Dt & "]" & vbCrLf &
                                            ex.Message, "PowerPoint Link: Update File List", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Next
                If bChanged Then
                    ProHelpDataSet.t_files.AcceptChanges()
                    T_filesTableAdapter.Update(ProHelpDataSet.t_files)
                End If
                MatchRows.Dispose()
            Next
        End If

        filesView.Dispose()
        RemoveDupes = "1::There were " & nTotal & " records in the Files table.  " & nChanges & " duplicates were deleted"
    End Function


    Private Function CreateTableDF() As DataTable
        Dim myTable As New DataTable("T_DiskFiles")
        Dim keys(2) As DataColumn

        myTable.Columns.Add("f_path", Type.GetType("System.String"))
        myTable.Columns.Add("f_name", Type.GetType("System.String"))
        myTable.Columns.Add("fullpath", Type.GetType("System.String"))
        myTable.Columns.Add("status", Type.GetType("System.Int32"))
        ' status: 0=file found; 1=file matched db
        keys(0) = myTable.Columns(0)
        keys(1) = myTable.Columns(1)
        myTable.PrimaryKey = keys

        CreateTableDF = myTable
    End Function


    Private Sub ResultAddDF(myTable As DataTable, s1 As String, s2 As String, i1 As Integer)
        Dim workRow As DataRow = myTable.NewRow()
        workRow("f_path") = s1
        workRow("f_name") = s2
        workRow("fullpath") = s1 & "\" & s2
        workRow("status") = i1
        myTable.Rows.Add(workRow)
        myTable.AcceptChanges()
    End Sub


    Private Function GetFiles(T_diskfiles As DataTable) As Integer
        Dim szPath As String, NextFile As String
        Dim AllDirs(30) As String, NextDir As String, i As Integer

        'txtResults.Text = txtResults.Text & vbCrLf & "Collecting New files..."
        Dim szFolder As String = TxtFolder.Text

        GetFiles = 0
        i = 0
        NextDir = Dir(szFolder & "\*", 16)

        While NextDir <> ""
            Select Case NextDir
                Case ".", ".."
                Case Else
                    If Len(NextDir) = 1 Then
                        AllDirs(i) = szFolder & "\" & NextDir
                        i = i + 1
                    End If
            End Select
            NextDir = Dir()
        End While

        If i = 0 Then
            MessageBox.Show("There are no alpha folders here:" & vbCrLf &
                szFolder & vbCrLf & "Please locate a Parklea songs MASTERS folder",
                "PowerPoint Link: Update File List", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If

        For Each szPath In AllDirs
            NextFile = Dir(szPath & "\*.*", 0)
            While NextFile <> "" ' j <4
                Select Case NextFile.Substring(NextFile.Length - 4, 4)
                    Case ".ppt", "pptx", ".PPT", "PPTX"
                        ResultAddDF(T_diskfiles, szPath, NextFile, 0)
                End Select
                NextFile = Dir()
            End While
        Next szPath

        GetFiles = T_diskfiles.Rows.Count
    End Function

    Private Function CheckExistingFiles(T_diskfiles As DataTable) As String
        Dim DBFiles As New DataView(ProHelpDataSet.t_files, "", "f_path, f_name", DataViewRowState.CurrentRows)
        Dim DiskFiles As DataView = T_diskfiles.AsDataView
        Dim szPath, szFName As String
        Dim iRow, iLRow, iFileNo, iOFileNo, iListNo, iRecNo, iSeqNo As Integer
        Dim szFullPath As String
        Dim nInactive, nDeleteAll, nDeleteThis, nDeleteRecord, nMakeActive, nIgnoreInactive, nNoChange As Integer

        nInactive = 0
        nDeleteAll = 0
        nDeleteThis = 0
        nMakeActive = 0
        nIgnoreInactive = 0
        nNoChange = 0
        CheckExistingFiles = "0::Nothing done yet"
        DiskFiles.Sort = "fullpath"

        For Each DBFile As DataRowView In DBFiles
            szPath = DBFile.Row.Item("f_path")
            szFName = DBFile.Row.Item("f_name")
            szFullPath = szPath & "\" & szFName
            iFileNo = DBFile.Row.Item("file_no")
            iRow = DiskFiles.Find(szFullPath)
            If iRow < 0 Then
                'file is no longer on the disk - is it included in a playlist?
                Dim vPlaylists As New DataView(ProHelpDataSet.tx_playlist_song, "file_no=" & iFileNo, "file_no", DataViewRowState.CurrentRows)
                If vPlaylists.Count > 0 Then
                    ' file is included in play lists so we need to delete the entries
                    Select Case iNoFile
                        Case iInactive
                            DBFile.Row.Item("inactive") = "Y"
                            ListBox1.Items.Add(szFullPath & ": Not on disk - marked Inactive")
                            nInactive = nInactive + 1

                        Case iDeleteAll
                            Dim ListView As DataView = ProHelpDataSet.Tables("tx_playlist_song").DefaultView
                            ListView.Sort = "list_no"
                            ' find each playlist number then delete all the rows with that pl number
                            For Each myRow In vPlaylists
                                iListNo = myRow.Item("list_no")
                                Do
                                    iLRow = ListView.Find(iListNo)
                                    If iLRow < 0 Then Exit Do
                                    iRecNo = ListView.Item(iLRow)("rec_no")
                                    iSeqNo = ListView.Item(iLRow)("seq_no")
                                    iOFileNo = ListView.Item(iLRow)("file_no")
                                    ListView.Delete(iLRow)
                                    Tx_playlist_songTableAdapter.Delete(iRecNo, iListNo, iSeqNo, iOFileNo)
                                Loop
                            Next
                            ProHelpDataSet.tx_playlist_song.AcceptChanges()
                            Tx_playlist_songTableAdapter.Update(ProHelpDataSet.tx_playlist_song)
                            T_filesTableAdapter.Delete(iFileNo, szFName, szPath, DBFile.Row.Item("f_altname"), DBFile.Row.Item("selected"),
                                DBFile.Row.Item("create_dt"), DBFile.Row.Item("last_dt"), DBFile.Row.Item("last_action"), DBFile.Row.Item("inactive"),
                                    DBFile.Row.Item("s_search"))
                            ListBox1.Items.Add(szFullPath & ": Not on disk - all lists deleted")
                            nDeleteAll = nDeleteAll + 1

                        Case iDeleteThis
                            For Each myRow In vPlaylists
                                iListNo = myRow.Item("list_no")
                                iRecNo = myRow.Item("rec_no")
                                iSeqNo = myRow.Item("seq_no")
                                myRow.Delete
                                Tx_playlist_songTableAdapter.Delete(iRecNo, iListNo, iSeqNo, iFileNo)
                            Next
                            ProHelpDataSet.tx_playlist_song.AcceptChanges()
                            Tx_playlist_songTableAdapter.Update(ProHelpDataSet.tx_playlist_song)
                            T_filesTableAdapter.Delete(iFileNo, szFName, szPath, DBFile.Row.Item("f_altname"), DBFile.Row.Item("selected"),
                                DBFile.Row.Item("create_dt"), DBFile.Row.Item("last_dt"), DBFile.Row.Item("last_action"), DBFile.Row.Item("inactive"),
                                    DBFile.Row.Item("s_search"))
                            ListBox1.Items.Add(szFullPath & ": Not on disk - deleted from all lists")
                            nDeleteThis = nDeleteThis + 1

                        Case Else
                            MessageBox.Show("Programming error: Impossible state in unmatched file test",
                                    "PowerPoint Link: Update File List", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ListBox1.Items.Add(szFullPath & ": Illegal status for not found file - " & iNoFile)

                    End Select
                    vPlaylists.Dispose()
                Else
                    T_filesTableAdapter.Delete(iFileNo, szFName, szPath, DBFile.Row.Item("f_altname"), DBFile.Row.Item("selected"),
                            DBFile.Row.Item("create_dt"), DBFile.Row.Item("last_dt"),
                            DBFile.Row.Item("last_action"), DBFile.Row.Item("inactive"), DBFile.Row.Item("s_search"))
                    ListBox1.Items.Add(szFullPath & ": Not on disk or in any playlists - deleted record")
                    nDeleteRecord = nDeleteRecord + 1
                End If

            Else
                'file is matched by one on the disk - mark this as matched
                If DiskFiles.Item(iRow)("status") <> 0 Then
                    ' this has already been marked
                    MessageBox.Show("File Check error: " & szPath & "\" & szFName & " is listed twice in the database" & vbCrLf &
                                    "Second listing is at record #" & iFileNo,
                                    "PowerPoint Link: Update File List", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    DiskFiles.Item(iRow)("status") = 1
                End If

                If DBFile.Row.Item("inactive") = "Y" Then
                    'file was marked inactive but is actually on disk
                    If bFoundActive Then
                        DBFile.Row.Item("inactive") = "N"
                        nMakeActive = nMakeActive + 1
                        ListBox1.Items.Add(szFullPath & ": On disk - marked Active")
                    Else
                        ListBox1.Items.Add(szFullPath & ": On disk - but left as Inactive")
                        nIgnoreInactive = nIgnoreInactive + 1
                    End If
                Else
                    ListBox1.Items.Add(szFullPath & ": On disk, marked as active, no change necessary")
                    nNoChange = nNoChange + 1
                End If
            End If
            ProHelpDataSet.t_files.AcceptChanges()
            T_filesTableAdapter.Update(ProHelpDataSet.t_files)
        Next
        Dim iTot As Integer = nInactive + nDeleteAll + nDeleteThis + nDeleteRecord + nMakeActive + nIgnoreInactive + nNoChange
        CheckExistingFiles = iTot & "::" & nInactive & "->INACTIVE; " & nDeleteAll & "->DELETEALL; " & nDeleteThis & "->DELETETHIS;" &
            nDeleteRecord & "->DELETEREC; " & nMakeActive & "->ACTIVE; " & nIgnoreInactive & "->INACTIVE IGNORED" & nNoChange & "->NOCHANGE"
        DBFiles.Dispose()
    End Function

    Private Function CheckNewFiles(T_diskfiles As DataTable) As String
        Dim nFiles As Integer = 0
        Dim DiskFiles As DataView = T_diskfiles.AsDataView
        DiskFiles.Sort = "status"

        CheckNewFiles = "0::No new files found"
        For Each myRow In DiskFiles.FindRows(0)
            nFiles = nFiles + 1
            If bNewSelect Then
                T_filesTableAdapter.Insert(myRow.Item("f_name"), myRow.Item("f_path"), "", "Y", Now(), Now(), "New file added", "N", "")
            Else
                T_filesTableAdapter.Insert(myRow.Item("f_name"), myRow.Item("f_path"), "", "", Now(), Now(), "New file added", "N", "")
            End If
            ListBox1.Items.Add("New file found and added to the table: " & myRow.Item("f_path") & "\" & myRow.Item("f_name"))
        Next
        ProHelpDataSet.t_files.AcceptChanges()
        T_filesTableAdapter.Update(ProHelpDataSet.t_files)
        If nFiles > 0 Then CheckNewFiles = nFiles & "::New files found and added"
        DiskFiles.Dispose()
    End Function
End Class