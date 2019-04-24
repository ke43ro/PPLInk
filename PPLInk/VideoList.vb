Imports Microsoft.Office.Interop.PowerPoint

Public Class VideoList
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Integer

    Public Sub Run(ByRef arPlayList As ListBox.ObjectCollection)
        Dim PPPres As Microsoft.Office.Interop.PowerPoint.Application
        Dim SSWin As SlideShowWindow
        Dim szFPath As String, i As Integer
        Dim szTemplate As String = ""

        PPPres = New Microsoft.Office.Interop.PowerPoint.Application
        PPPres.Visible = True
        PPPres.WindowState = PpWindowState.ppWindowMinimized
        Dim newPres = PPPres.Presentations.Add(True)
        Dim newWidth, newHeight As Integer
        Dim myShape As Shape

        i = -1
        Do
            i = i + 1
            If i >= arPlayList.Count Then Exit Do

            szFPath = arPlayList.Item(i)

            If Dir(szFPath) = "" Then
                MessageBox.Show("Can't find video file " & szFPath & " on the disk", "PowerPoint Link: Running a show",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Continue Do
            End If
            newPres.Slides.Add(i + 1, PpSlideLayout.ppLayoutBlank)
            Try
                myShape = newPres.Slides(i + 1).Shapes.AddMediaObject2(szFPath)
            Catch ex1 As Exception
                MessageBox.Show("Can't load video file " & szFPath & "." & vbCrLf & ex1.Message, "PowerPoint Link: Running a show",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Continue Do
            End Try

            With myShape
                .LockAspectRatio = True
                newWidth = newPres.PageSetup.SlideWidth

                .Width = newWidth

                newHeight = newPres.PageSetup.SlideHeight

                If myShape.Height > newHeight Then
                    .Height = newHeight
                    .Left = (newWidth - .Width) / 2
                Else
                    'centre vertical
                    .Top = (newHeight - .Height) / 2
                End If

                .AnimationSettings.PlaySettings.PlayOnEntry = True
                .AnimationSettings.PlaySettings.PauseAnimation = False
            End With
        Loop

        With newPres
            SSWin = .SlideShowSettings.Run()
            'System.Threading.Thread.Sleep(500)
            SSWin.Activate()
            SSWin.View.First()
            SetForegroundWindow(SSWin.HWND)
            Do
                If SSWin Is Nothing Then Exit Do
                Try
                    If SSWin.Active Then System.Threading.Thread.Sleep(1000)
                Catch ex2 As Exception
                    Exit Do
                End Try
            Loop

            ' in case the user closes Powerpoint before closing the show
            Try
                .Close()
            Catch ex As Exception

            End Try
        End With

        PPPres.WindowState = PpWindowState.ppWindowMinimized
        PPPres.Quit()
    End Sub

End Class
