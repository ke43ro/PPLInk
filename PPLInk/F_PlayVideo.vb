Public Class F_PlayVideo
    Private VideoList As New VideoList

    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            'MsgBox(path)
            ListBox1.Items.Add(path)
        Next
    End Sub

    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListBox1.KeyPress
        Dim iSelected As Integer = ListBox1.SelectedIndex
        Dim iIndex As Integer = 0
        Dim szQueue As New Queue(Of String)

        Select Case e.KeyChar
            ' Delete key doesn't generate a KeyPress
            'Case Microsoft.VisualBasic.ChrW(Keys.Delete)

            Case "+"
                If iSelected < ListBox1.Items.Count - 1 Then
                    szQueue.Enqueue(ListBox1.Items(iSelected))
                    szQueue.Enqueue(ListBox1.Items(iSelected + 1))
                    ListBox1.Items(iSelected + 1) = szQueue.Dequeue
                    ListBox1.Items(iSelected) = szQueue.Dequeue
                    ListBox1.SelectedIndex += 1
                End If

            Case "-"
                If iSelected > 0 Then
                    szQueue.Enqueue(ListBox1.Items(iSelected))
                    szQueue.Enqueue(ListBox1.Items(iSelected - 1))
                    ListBox1.Items(iSelected - 1) = szQueue.Dequeue
                    ListBox1.Items(iSelected) = szQueue.Dequeue
                    ListBox1.SelectedIndex -= 1
                End If

            Case Else
                Exit Sub
        End Select

        e.Handled = True
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        Dim iSelected As Integer = ListBox1.SelectedIndex
        Dim iIndex As Integer = 0
        Dim szQueue As New Queue(Of String)

        Select Case e.KeyCode
            ' Handle via KeyPress catches both num pad and normal plus key
            'Case Keys.Add

            ' Handle via KeyPress catches both num pad and normal minus key
            'Case Keys.Subtract

            Case Keys.Delete
                While iIndex < ListBox1.Items.Count
                    If iIndex <> iSelected Then szQueue.Enqueue(ListBox1.Items(iIndex))
                    iIndex = iIndex + 1
                End While
                ListBox1.Items.Clear()
                iIndex = 0
                While szQueue.Count > 0
                    ListBox1.Items.Add(szQueue.Dequeue)
                End While

            Case Else
                Exit Sub
        End Select

        e.SuppressKeyPress = True

    End Sub


    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles BtnPlay.Click
        If ListBox1.Items.Count = 0 Then
            MessageBox.Show("Please add some items to the list",
                            "PowerPoint Link: Playing videos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        MyBase.WindowState = FormWindowState.Minimized
        VideoList.Run(ListBox1.Items)
        MyBase.WindowState = FormWindowState.Normal

    End Sub

    Private Sub F_PlayVideo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.WindowState = FormWindowState.Normal
    End Sub
End Class