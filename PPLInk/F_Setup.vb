Imports System.Data.Linq
Imports System.Data.Sql
Imports System.Windows.Input


Public Class F_SetUp
    Private Sub F_SetUp_OnLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mySettings As New PPLInk.Settings
        If mySettings.ProHelpServerUser <> "" Then
            TxtServer.Text = mySettings.ProHelpServerUser
        Else
            ' string for MS LocalDB
            TxtServer.Text = "(LocalDB)\v11.0"
        End If
        Dim szFolder As String = mySettings.ProHelpMasterFolder
        If szFolder <> "" Then
            TxtFolder.Text = szFolder.Replace("%DOCUMENTS%", My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        End If
        GroupBox1.BackColor = Color.FromArgb(255, 255, 230)
        GroupBox2.BackColor = SystemColors.Control
        GroupBox3.BackColor = SystemColors.Control
        ChkStep1.Text = "Step 1. Waiting"
        ChkStep1.Checked = False
        ChkStep2.Text = "Step 2. Waiting"
        ChkStep2.Checked = False
        ChkStep3.Text = "Step 3. Waiting"
        ChkStep3.Checked = False
        BtnTest1.Enabled = True
        BtnTest2.Enabled = False
        BtnTest3.Enabled = False
        BtnBrowse.Enabled = False
        OK_Button.Enabled = False
    End Sub

    Private Sub BtnTest1_Click(sender As Object, e As EventArgs) Handles BtnTest1.Click
        ' test the connection
        Cursor = Cursors.WaitCursor
        Dim szConn As String = "Data Source=" & TxtServer.Text & ";Integrated Security=True;Connection Timeout=5"
        Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
        Try
            connection.Open()
        Catch ex As Exception
            MessageBox.Show("Connection " & TxtServer.Text & " failed.  Please try another." & vbCrLf & "[" & ex.Message & "]",
                            "PowerPoint Link: Testing SQL Connection")
            Cursor = Cursors.Default
            Exit Sub
        End Try

        ' if successful
        Dim mySettings As New PPLInk.Settings
        mySettings.ProHelpServerUser = TxtServer.Text
        mySettings.Save()
        GroupBox1.BackColor = SystemColors.Control
        GroupBox2.BackColor = Color.FromArgb(255, 255, 230)
        ChkStep1.Text = "Step 1. Succeeded"
        ChkStep1.Checked = True
        BtnTest1.Enabled = False
        BtnTest2.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.Yes
        Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Dim response As DialogResult
        If ChkStep1.Checked = True And ChkStep2.Checked = True And ChkStep3.Checked = True Then
            Me.DialogResult = DialogResult.Yes
            Close()
        Else
            response = MessageBox.Show("PowerPoint Link cannot function unless all these settings are correct.  Are you sure you want to stop?",
                                       "PowerPoint Link: Closing Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If response = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Yes
                Close()
            Else
                Me.DialogResult = DialogResult.No
            End If
        End If
    End Sub

    Private Sub BtnTest2_Click(sender As Object, e As EventArgs) Handles BtnTest2.Click
        ' test the database
        Cursor = Cursors.WaitCursor
        Dim mySettings As New PPLInk.Settings
        Dim szConn As String = "Data Source=" & mySettings.ProHelpServerUser & ";" & mySettings.ProHelpConnectionSuffix
        Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
        Try
            connection.Open()

        Catch ex1 As Exception
            ' can't open the database
            Cursor = Cursors.Default
            MessageBox.Show("The connection failed." & vbCrLf & "[" & ex1.Message & "]" & vbCrLf & vbCrLf &
                            "Assuming that there is no ProHelp database installed and will install it now.",
                            "PowerPoint Link: Database not found", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' install it
            Cursor = Cursors.WaitCursor
            Try
                szConn = "Data Source=" & mySettings.ProHelpServerUser & ";Integrated Security=True"
                Dim DBDataContext As DataContext
                DBDataContext = New DBCreateDataContext(szConn)
                DBDataContext.CreateDatabase()
                DBDataContext.Dispose()

            Catch ex2 As Exception
                ' can't install it
                Cursor = Cursors.Default
                MessageBox.Show("There was a failure while trying to install the ProHelp database.  Please contact the application vendor" &
                                "And provide the following message:" & vbCrLf & ex2.Message,
                                "PowerPoint Link: Install failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ChkStep2.Text = "Step 2. Waiting"
                ChkStep2.Checked = False
                BtnTest3.Enabled = False
                BtnBrowse.Enabled = False
                Exit Sub
            End Try
        End Try


        ' if successful
        mySettings.ProHelpConnectionUser = szConn
        mySettings.Save()
        GroupBox2.BackColor = SystemColors.Control
        GroupBox3.BackColor = Color.FromArgb(255, 255, 230)
        ChkStep2.Text = "Step 2. Succeeded"
        ChkStep2.Checked = True
        BtnTest2.Enabled = False
        BtnTest3.Enabled = True
        BtnBrowse.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        FolderBrowserDialog1.SelectedPath = TxtFolder.Text
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TxtFolder.Text = FolderBrowserDialog1.SelectedPath
        Else
            MessageBox.Show("This feature can only be run if a folder is specified",
                            "PowerPoint Link: Playing the list", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub BtnTest3_Click(sender As Object, e As EventArgs) Handles BtnTest3.Click
        ' fill the database
        Cursor = Cursors.WaitCursor
        Dim FillForm As New F_FillTables
        Dim result As DialogResult

        If Dir(TxtFolder.Text, vbDirectory) = "" Then
            Cursor = Cursors.Default
            MessageBox.Show("Please choose a valid folder name")
            Exit Sub
        End If

        ' open Recreate and set the folder name
        FillForm.LoadFolder(TxtFolder.Text)
        result = FillForm.ShowDialog()
        If result <> DialogResult.OK Then
            Cursor = Cursors.Default
            MessageBox.Show("PowerPoint Link cannot work without the tables filled")
            Exit Sub
        End If

        ' if successful
        Dim mySettings As New PPLInk.Settings
        mySettings.ProHelpMasterFolder = TxtFolder.Text
        mySettings.Save()
        GroupBox3.BackColor = SystemColors.Control
        ChkStep3.Text = "Step 3. Succeeded"
        ChkStep3.Checked = True
        OK_Button.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub ParseKeyValue(szInput As String, szSeparator As String, ByRef szParms() As String)
        Dim iPos, iSep As Integer
        Dim iLoop As Integer = -1

        If szInput = "" Then
            ReDim szParms(0)
            Exit Sub
        End If

        iSep = szSeparator.Length

        Do
            iLoop = iLoop + 1
            iPos = szInput.IndexOf(szSeparator)
            If iPos < 0 Then
                szParms(iLoop) = szInput
                Exit Do
            End If

            szParms(iLoop) = szInput.Substring(0, iPos)
            szInput = szInput.Substring(iPos + iSep, szInput.Length - iPos - iSep)
        Loop
    End Sub

    Private Sub GetServers()
        Dim servers As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources()
        For Each dr As DataRow In servers.Rows
            MessageBox.Show(dr(0) & "\" & dr(1))
        Next

        'Dim service As sqlservice
    End Sub

    Private Sub F_SetUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult
        Dim mySettings As New PPLInk.Settings
        Dim szDebug As String = mySettings.ProHelpDebug

        Select Case Me.DialogResult
            Case DialogResult.Yes
                If szDebug = "Yes" Then MessageBox.Show("closing")
            Case DialogResult.No
                e.Cancel = True
            Case Else
                If szDebug = "Yes" Then MessageBox.Show("testing")
                If ChkStep1.Checked = True And ChkStep2.Checked = True And ChkStep3.Checked = True Then
                    If szDebug = "Yes" Then MessageBox.Show("closing")
                Else
                    result = MessageBox.Show("All steps have not been completed successsfully - PowerPoint Link might not function correctly." &
                                             vbCrLf & "Are you sure you want to close the set up?",
                                             "PowerPoint Link: Incomplete Set Up", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.No Then
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub TxtAdvice1_Click(sender As Object, e As EventArgs) Handles TxtAdvice1.Click
        F_ServerHelp.ShowDialog()
    End Sub
End Class