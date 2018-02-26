Public Class F_Advanced
    Private iFilesStart, iFilesEnd As Integer
    Private filesView As DataView

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim fViewRow As DataRowView
        Dim filePath, fileName, szF_name, szF_path, szF_altname, szSelected, szInactive As String
        Dim iRandom As New Random

        filesView = ProHelpDataSet.Tables("t_files").DefaultView
        'iFilesStart = filesView.Count
        'If iFilesStart > 0 Then txtResults.Text = "There are already " & iFilesStart & " records in the table"

        'txtResults.Text = txtResults.Text & vbCrLf & "Emptying Songs Table..."
        If filesView.Count() = 0 Then
            MessageBox.Show("There are no files in the table", "PowerPoint Link Export",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            filesView.Sort = "f_name"
            fileName = "PPLink" & iRandom.Next & ".txt"
            'txtResults.Text = txtResults.Text & vbCrLf & "Files record has " & filesView.Count() & " rows"
            Try
                filePath = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, fileName)
                My.Computer.FileSystem.WriteAllText(filePath,
                    "F_name" & vbTab & "F_Path" & vbTab & "F_altname" & vbTab & "Selected" & vbTab & "Inactive" & vbCrLf,
                     False)
            Catch fileException As Exception
                MessageBox.Show("Failed to create file " & filePath, "PowerPoint Link Export",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            MessageBox.Show("This will write " & filesView.Count & " lines to a file " & filePath & " in Documents",
                            "PowerPoint Link Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            For Each fViewRow In filesView
                szF_name = fViewRow("F_NAME")
                szF_path = fViewRow("F_PATH")
                'Try
                szF_altname = IIf(fViewRow("F_ALTNAME") Is Nothing, "", fViewRow("F_ALTNAME"))
                szSelected = IIf(fViewRow("SELECTED") Is Nothing, "", fViewRow("SELECTED"))
                szInactive = IIf(fViewRow("INACTIVE") Is Nothing, "", fViewRow("INACTIVE"))
                My.Computer.FileSystem.WriteAllText(filePath,
                    szF_name & vbTab & szF_path & vbTab & szF_altname & vbTab & szSelected & vbTab & szInactive & vbCrLf,
                    True)
                'Catch convException As Exception
                'MessageBox.Show("Conversion failure at " & fViewRow("FILE_NO") & "; " & fViewRow("F_NAME") _
                '                    & "[" & szF_altname & "]" & "[" & szSelected & "]" & "[" & szInactive & "]")
                'End Try
            Next
            MessageBox.Show("File creation complete", "PowerPoint Link Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub F_Advanced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mySettings As New PPLInk.Settings
        Dim szConn = mySettings.ProHelpConnectionUser
        'LblVersion.Text = Me.ProductVersion

        Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
        T_filesTableAdapter.Connection = connection
        Me.T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)

    End Sub
End Class