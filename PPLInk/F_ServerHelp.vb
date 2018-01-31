Imports System.Data.Sql

Public Class F_ServerHelp
    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
        Dim servers As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources()
        For Each dr As DataRow In servers.Rows
            LstServers.Items.Add(dr(0) & "\" & dr(1))
        Next

    End Sub
End Class