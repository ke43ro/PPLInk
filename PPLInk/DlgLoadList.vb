Imports System.Windows.Forms

Public Class DlgLoadList
    Private bFuture As Boolean
    Private isLoaded As Boolean = False

    Friend Sub GetList(ByRef myList As ListBox)
        For Each listItem In LstQueue.Items
            myList.Items.Add(listItem)
        Next
    End Sub

    Friend Sub Fillqueue(ByRef ListBox As ListBox)
        Dim iLoop As Integer = 0

        LstQueue.Items.Clear()

        While iLoop < ListBox.Items.Count
            LstQueue.Items.Add(ListBox.Items(iLoop))
            iLoop = iLoop + 1
        End While
    End Sub

    Private Sub Load_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Button.Click
        Dim searchView As DataView = ProHelpDataSet.Tables("tx_playlist_song").DefaultView
        Dim ListRows() As DataRowView
        Dim iListNo As Integer, bRowSel As Boolean = True

        T_playlistsTableAdapter.Update(ProHelpDataSet.t_playlists)
        If T_playlistsDataGridView.SelectedRows.Count = 0 Then
            bRowSel = False
        ElseIf T_playlistsDataGridView.SelectedRows(0).IsNewRow Then
            bRowSel = False
        End If

        If bRowSel = False Then
            MessageBox.Show("Please select a Play List from the table to load",
                            "PowerPoint Link: Loading a PlayList",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        iListNo = T_playlistsDataGridView.SelectedRows(0).Cells(0).Value

        searchView.Sort = "list_no"
        ListRows = searchView.FindRows(iListNo)
        If ListRows.Length = 0 Then
            MessageBox.Show("There are no entries yet in this Play List", "PowerPoint Link: Loading a Play List",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            MessageBox.Show("Loading " & ListRows.Length & " entries from this Play List", "PowerPoint Link: Loading a Play List",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        LstQueue.Items.Clear()
        Dim filesView As DataView = ProHelpDataSet.Tables("t_files").DefaultView
        filesView.Sort = "file_no"
        Dim filesRow() As DataRowView
        For Each Row In ListRows
            filesRow = filesView.FindRows(Row("FILE_NO"))
            LstQueue.Items.Add(Row("FILE_NO") & "::" & filesRow(0)("F_NAME"))
        Next

        DialogResult = DialogResult.Yes ' indicates a "Load"
        Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub DlgLoadList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nSongs As Integer = LstQueue.Items.Count
        Dim mySettings As New PPLInk.Settings
        Dim szConn As String = mySettings.ProHelpConnectionUser

        If szConn <> "" Then
            Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
            T_filesTableAdapter.Connection = connection
            Tx_playlist_songTableAdapter.Connection = connection
            T_playlistsTableAdapter.Connection = connection
        End If

        Me.T_filesTableAdapter.Fill(Me.ProHelpDataSet.t_files)
        Me.Tx_playlist_songTableAdapter.Fill(Me.ProHelpDataSet.tx_playlist_song)
        Me.T_playlistsTableAdapter.FillFuture(Me.ProHelpDataSet.t_playlists, today)

        TxtStatus.Text = "There are " & nSongs & " songs in the current unsaved Play List"
        bFuture = True
        ChkFuture.Checked = True
        isLoaded = True
    End Sub

    Private Sub Save_Button_Click(sender As Object, e As EventArgs) Handles Save_Button.Click
        Dim myKeyParser As New KeyParser
        'Dim key(1) As Object
        Dim szParms(1) As String
        Dim iListNo As Integer
        Dim iLoop As Integer = 0
        Dim result As DialogResult
        'Dim replace As Boolean = False
        Dim bRowSel As Boolean = True

        T_playlistsTableAdapter.Update(ProHelpDataSet.t_playlists)
        If T_playlistsDataGridView.SelectedRows.Count = 0 Then
            bRowSel = False
        ElseIf T_playlistsDataGridView.SelectedRows(0).IsNewRow Then
            bRowSel = False
        End If

        If bRowSel = False Then
            MessageBox.Show("Please select a Play List from the table to save the list",
                            "PowerPoint Link: Saving a PlayList",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        iListNo = T_playlistsDataGridView.SelectedRows(0).Cells(0).Value

        ' check whether there are any records already
        Dim searchView As DataView = ProHelpDataSet.Tables("tx_playlist_song").DefaultView
        searchView.Sort = "list_no"
        If searchView.FindRows(iListNo).Count > 0 Then
            result = MessageBox.Show("There are already records in this Play List." & vbCrLf &
                            "Do you want to replace them with the current list?", "PowerPoint Link: Saving a Play List",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If result = DialogResult.No Then Exit Sub

            For Each deleteRow In searchView.FindRows(iListNo)
                Tx_playlist_songTableAdapter.Delete(deleteRow("REC_NO"), deleteRow("LIST_NO"), deleteRow("SEQ_NO"), deleteRow("FILE_NO"))
            Next

            ProHelpDataSet.tx_playlist_song.AcceptChanges()
            Tx_playlist_songTableAdapter.Update(ProHelpDataSet.tx_playlist_song)
        End If

        'add records to tx_playlist_song(iListNo)
        While iLoop < LstQueue.Items.Count
            myKeyParser.GetKeyValues(LstQueue.Items(iLoop), "::", szParms)
            Tx_playlist_songTableAdapter.Insert(iListNo, iLoop, szParms(0))
            iLoop = iLoop + 1
        End While
        ProHelpDataSet.tx_playlist_song.AcceptChanges()

        Try
            Tx_playlist_songTableAdapter.Update(ProHelpDataSet.tx_playlist_song)
        Catch ex As Exception
            MessageBox.Show("Error updating tables:" & vbCrLf & ex.Message, "PowerPoint Link: Saving a Play List",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        DialogResult = DialogResult.No ' indicates a "Save"
        Close()
    End Sub

    Private Sub ChkFuture_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFuture.CheckedChanged
        If ChkFuture.Checked Then
            bFuture = True
        Else
            bFuture = False
        End If

        If isLoaded Then
            If bFuture Then
                T_playlistsTableAdapter.FillFuture(Me.ProHelpDataSet.t_playlists, Today)
            Else
                T_playlistsTableAdapter.Fill(Me.ProHelpDataSet.t_playlists)
            End If
        End If
    End Sub
End Class
