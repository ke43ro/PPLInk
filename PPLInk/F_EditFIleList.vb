Public Class F_EditFileList
    Private bFormOpen As Boolean = False

    Private Sub F_EditFileList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim szConn = My.Settings.ProHelpConnectionUser
        'LblVersion.Text = Me.ProductVersion

        Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
        T_filesTableAdapter.Connection = connection
        Tx_playlist_songTableAdapter1.Connection = connection
        Me.T_filesTableAdapter.FillAll(Me.ProHelpDataSet.t_files)
        Me.Tx_playlist_songTableAdapter1.Fill(Me.ProHelpDataSet.tx_playlist_song)
        bFormOpen = True
    End Sub

    Private Sub F_EditFileList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            T_filesTableAdapter.Update(ProHelpDataSet.t_files)

        Catch ex As Exception
            MessageBox.Show("Can't save changes to the table.  Send this message to the programmer." & vbCrLf & ex.Message,
                        "Powerpoint Link: Closing File Edit",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub T_filesDataGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles T_filesDataGridView.KeyDown
        Dim iFileNo, iRow, iLRow, iListNo, iRecNo, iSeqNo As Integer
        Dim result As DialogResult

        Select Case e.KeyCode
            Case Keys.Delete
                iFileNo = T_filesBindingSource.Current.Row.file_no
                Dim PlayView As DataView = ProHelpDataSet.Tables("tx_playlist_song").DefaultView
                PlayView.Sort = "file_no"
                Dim HasRows As DataRowView() = PlayView.FindRows(iFileNo)
                If HasRows.Count > 0 Then
                    'If PlayView.FindRows(iFileNo).Count > 0 Then
                    result = MessageBox.Show("This song has been used in playlists that have been saved." & vbCrLf &
                                    "Please check the options carefully:" & vbCrLf &
                                    "Press 'Yes' to delete the song record and all play lists that contain this song" & vbCrLf &
                                    "    [Will remove some history from this installation]" & vbCrLf &
                                    "Press 'No' to delete the song record and also delete just this song from all play lists" & vbCrLf &
                                    "    [Will remove this song from the history]" & vbCrLf &
                                    "Press 'Cancel' to avoid making any changes to the database",
                                    "PowerPoint Link: Deleting record #" & iFileNo,
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    Select Case result
                        Case DialogResult.Yes
                            Dim ListView As DataView = ProHelpDataSet.Tables("tx_playlist_song").DefaultView
                            ListView.Sort = "list_no"
                            ' find each playlist number then delete all the rows with that pl number
                            For Each myRow In HasRows
                                iListNo = myRow.Item("list_no")
                                Do
                                    iLRow = ListView.Find(iListNo)
                                    If iLRow < 0 Then Exit Do
                                    iRecNo = ListView.Item(iLRow)("rec_no")
                                    iSeqNo = ListView.Item(iLRow)("seq_no")
                                    iFileNo = ListView.Item(iLRow)("file_no")
                                    ListView.Delete(iLRow)
                                    Tx_playlist_songTableAdapter1.Delete(iRecNo, iListNo, iSeqNo, iFileNo)
                                Loop
                            Next
                            'ListView.Dispose()
                            ProHelpDataSet.tx_playlist_song.AcceptChanges()
                            Tx_playlist_songTableAdapter1.Update(ProHelpDataSet.tx_playlist_song)

                        Case DialogResult.No
                            Do
                                iRow = PlayView.Find(iFileNo)
                                If iRow < 0 Then Exit Do
                                iRecNo = PlayView.Item(iRow)("rec_no")
                                iListNo = PlayView.Item(iRow)("list_no")
                                iSeqNo = PlayView.Item(iRow)("seq_no")
                                PlayView.Delete(iRow)
                                Tx_playlist_songTableAdapter1.Delete(iRecNo, iListNo, iSeqNo, iFileNo)
                            Loop
                            ProHelpDataSet.tx_playlist_song.AcceptChanges()
                            Tx_playlist_songTableAdapter1.Update(ProHelpDataSet.tx_playlist_song)

                        Case DialogResult.Cancel
                            e.SuppressKeyPress = True
                    End Select
                    'Else
                    '   MessageBox.Show("no rows in playlists")
                End If

            Case Else
                Exit Sub
        End Select
    End Sub
End Class