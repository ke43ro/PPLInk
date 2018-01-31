Imports System.Windows.Forms

Public Class F_FillTables
    Private nMatched As Integer, nMissing As Integer
    Private nNew As Integer, nAlready As Integer
    Private szFolder As String = ""
    Private iFilesStart, iFilesEnd
    Private filesView As DataView


    Friend Sub LoadFolder(szFolderIn As String)
        szFolder = szFolderIn
        txtFolder.Text = szFolder
    End Sub

    Private Sub BtnRun_Click(sender As Object, e As EventArgs) Handles BtnRun.Click
        If Dir(szFolder, vbDirectory) = "" Then
            MessageBox.Show("This feature can only be run if a valid folder is specified",
                        "PowerPoint Link: Finding the songs", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        BtnClose.Enabled = False

        CheckFiles()

        Dim AllDirs(30) As String, NextDir As String, i As Integer
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
                "PowerPoint Link: Finding the songs", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            GetFiles(AllDirs)
        End If


        If ProHelpDataSet.t_files.HasErrors Then
            Dim errRow As DataRow
            For Each errRow In ProHelpDataSet.t_files.GetErrors()
                MessageBox.Show(errRow.RowError)
            Next
        End If

        ProHelpDataSet.t_files.AcceptChanges()

        Try
            T_filesTableAdapter.Update(ProHelpDataSet.t_files)
        Catch ex As System.Exception
            MessageBox.Show("Error updating table:" & vbCrLf & ex.Message, "PowerPoint Link: Updating song files list",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        BtnClose.Enabled = True
        iFilesStart = T_filesBindingSource.Count
    End Sub

    Private Sub DlgRecreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mySettings As New PPLInk.Settings
        Dim szConn As String = mySettings.ProHelpConnectionUser
        If szConn <> "" Then
            Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
            T_filesTableAdapter.Connection = connection
        End If

        T_filesTableAdapter.Fill(ProHelpDataSet.t_files)
        filesView = ProHelpDataSet.Tables("t_files").DefaultView
        iFilesStart = filesView.Count
        If iFilesStart > 0 Then txtResults.Text = "There are already " & iFilesStart & " records in the table"
    End Sub

    Private Sub F_FillTables_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If iFilesEnd - iFilesStart > 0 Or nMatched > 0 Or iFilesStart > 0 Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub BtnEmpty_Click(sender As Object, e As EventArgs) Handles BtnEmpty.Click
        Dim msgResult As DialogResult _
            = MessageBox.Show("This will delete all records from the T_FILES table.  Are you sure you want to do this?",
                        "PowerPoint Link: Set Up", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If msgResult = DialogResult.No Then Exit Sub

        'Dim filesView As DataView = ProHelpDataSet.Tables("t_files").DefaultView
        Dim fViewRow As DataRowView

        txtResults.Text = txtResults.Text & vbCrLf & "Emptying Songs Table..."
        If filesView.Count() <> 0 Then
            txtResults.Text = txtResults.Text & vbCrLf & "Files record has " & filesView.Count() & " rows"
            filesView.Sort = "file_no"
            For Each fViewRow In filesView
                fViewRow.Delete()
            Next
        End If

        iFilesStart = 0
        iFilesEnd = 0
        nMatched = 0
        nMissing = 0
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub GetFiles(arPaths As Object)
        Dim szPath As String, NextFile As String    ', pNextFile As String
        Dim searchView As DataView = ProHelpDataSet.Tables("t_files").DefaultView
        Dim nNew As Integer = 0, LookUp As Integer, nAlready As Integer = 0

        txtResults.Text = txtResults.Text & vbCrLf & "Collecting New files..."
        searchView.Sort = "f_name"

        For Each szPath In arPaths
            NextFile = Dir(szPath & "\*.*", 0)
            While NextFile <> "" ' j <4
                Select Case NextFile.Substring(NextFile.Length - 4, 4)
                    Case ".ppt", "pptx", ".PPT", "PPTX"
                        LookUp = searchView.Find(NextFile)
                        If LookUp < 0 Then
                            nNew = nNew + 1
                            T_filesTableAdapter.Insert(NextFile, szPath, "", "", Now(), Nothing, "", "N")
                        Else
                            nAlready = nAlready + 1
                        End If
                End Select
                NextFile = Dir()
            End While
        Next szPath

        iFilesEnd = nNew + nAlready
        txtResults.Text = txtResults.Text & vbCrLf & "Found " & nNew & " new files; " & nAlready & " already listed"
    End Sub

    Private Sub CheckFiles()
        Dim FullName As String
        Dim fViewRow As DataRowView

        txtResults.Text = txtResults.Text & vbCrLf & "Checking File List..."
        If filesView.Count() = 0 Then
            nMatched = 0
            nMissing = 0
        Else
            txtResults.Text = txtResults.Text & vbCrLf & "Files record has " & filesView.Count() & " rows"
            filesView.Sort = "f_name, f_path"
            For Each fViewRow In filesView
                FullName = fViewRow("F_PATH") & "\" & fViewRow("F_NAME")
                If Dir(FullName) <> "" Then
                    nMatched = nMatched + 1
                    'fViewRow.Edit
                    If IsDBNull(fViewRow("LAST_ACTION")) Then
                        fViewRow("LAST_ACTION") = "MATCHED"
                        fViewRow("LAST_DT") = Now()
                    ElseIf fViewRow("LAST_ACTION") <> "MATCHED" Then
                        fViewRow("LAST_ACTION") = "MATCHED"
                        fViewRow("LAST_DT") = Now()
                    End If
                    fViewRow("INACTIVE") = "N"
                    fViewRow.EndEdit()
                Else
                    nMissing = nMissing + 1
                    If IsDBNull(fViewRow("LAST_ACTION")) Then
                        fViewRow("LAST_ACTION") = "NOT FOUND"
                        fViewRow("LAST_DT") = Now()
                    ElseIf fViewRow("LAST_ACTION") <> "NOT FOUND" Then
                        fViewRow("LAST_ACTION") = "NOT FOUND"
                        fViewRow("LAST_DT") = Now()
                    End If
                    fViewRow("INACTIVE") = "Y"
                    fViewRow.EndEdit()
                End If
            Next
        End If

        txtResults.Text = txtResults.Text & vbCrLf & "Checked Files: " & nMissing & " Missing; " & nMatched & " Matched"
    End Sub
End Class
