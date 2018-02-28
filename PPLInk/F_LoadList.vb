Public Class F_LoadList
    Private Sub T_playlistsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) 
        Me.Validate()
        Me.T_playlistsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProHelpDataSet)

    End Sub

    Private Sub F_LoadList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProHelpDataSet.t_playlists' table. You can move, or remove it, as needed.
        Me.T_playlistsTableAdapter.Fill(Me.ProHelpDataSet.t_playlists)

    End Sub
End Class