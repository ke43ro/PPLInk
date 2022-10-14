Imports Microsoft.Office.Interop.PowerPoint
Imports Microsoft.Office.Interop.PowerPoint.PpViewType
'Imports System.IO
'Imports System.Diagnostics
'Imports System.Runtime.InteropServices

Public Class PlayList
    Private ReadOnly myDataSet As New ProHelpDataSet
    Private ReadOnly myKeyParser As New KeyParser
    ReadOnly TFadap As New ProHelpDataSetTableAdapters.t_filesTableAdapter
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Integer

    Public Sub Run(ByRef arPlayList As ListBox.ObjectCollection)
        Dim PPPres As Microsoft.Office.Interop.PowerPoint.Application
        Dim SSWin As SlideShowWindow
        Dim szFileName, szFPath As String, i, iFileNo, iIndex As Integer
        Dim myParts() As String = {"", ""}
        Dim szConn As String = My.Settings.ProHelpConnectionUser
        If szConn <> "" Then
            Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
            TFadap.Connection = connection
        Else
            MessageBox.Show("Error opening the file list table.",
                "PowerPoint Link: Presentation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If

        TFadap.FillAll(myDataSet.t_files)
        Dim filesView As DataView = myDataSet.Tables("t_files").DefaultView
        filesView.Sort = "file_no"

        PPPres = New Microsoft.Office.Interop.PowerPoint.Application
        Try
            PPPres.Visible = True

        Catch ex As Exception
            MessageBox.Show("Error making the PowerPoint window visible. Do you have a licenced copy of MS Office?" &
                    vbCrLf & "Please contact the programmer with this message:" & vbCrLf & ex.Message & vbCrLf &
                    ex.StackTrace,
                "PowerPoint Link: Presentation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End Try

        i = -1
        Do
            i += 1
            If i >= arPlayList.Count Then Exit Do

            szFileName = arPlayList.Item(i)

            ' get file_no
            myKeyParser.GetKeyValues(szFileName, "::", myParts)
            iFileNo = myParts(0)
            szFileName = myParts(1)

            ' build path into szFN
            iIndex = filesView.Find(iFileNo)
            If iIndex < 0 Then
                MessageBox.Show("Can't find a record in the table for " & szFileName & ".  Skipping",
                                "PowerPoint Link: Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Continue Do
            Else
                szFPath = filesView(iIndex)("f_path")
            End If

            szFileName = szFPath & "\" & szFileName
            If Dir(szFileName) = "" Then
                MessageBox.Show("Can't find show file " & szFileName & " on the disk", "PowerPoint Link: Running a show",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Continue Do
            End If

            PPPres.Presentations.Open(szFileName)
            Dim iWin = PPPres.Windows.Count
            PPPres.Windows(iWin).ViewType = ppViewNormal
            With PPPres.Presentations(szFileName)
                SSWin = .SlideShowSettings.Run()
                'System.Threading.Thread.Sleep(500)
                SSWin.Activate()
                SSWin.View.First()
                SetForegroundWindow(SSWin.HWND)
                Do
                    If SSWin Is Nothing Then Exit Do
                    Try
                        If SSWin.Active Then System.Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        Exit Do
                    End Try
                Loop

                ' in case the user closes Powerpoint before closing the show
                Try
                    .Close()
                Catch ex As Exception

                End Try
            End With
        Loop

        Try
            PPPres.WindowState = PpWindowState.ppWindowMinimized
            PPPres.Quit()

        Catch ex As Exception
            MessageBox.Show("Error minimising the PowerPoint window. Do you have a licenced copy of MS Office?" &
                    vbCrLf & "Please contact the programmer with this message:" & vbCrLf & ex.Message & vbCrLf &
                    ex.StackTrace,
                "PowerPoint Link: Presentation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
End Class
