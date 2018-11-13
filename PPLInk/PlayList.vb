Imports Microsoft.Office.Interop.PowerPoint
'Imports System.IO
'Imports System.Diagnostics
'Imports System.Runtime.InteropServices

Public Class PlayList
    Private myDataSet As New ProHelpDataSet
    Private myKeyParser As New KeyParser
    Dim TFadap As New ProHelpDataSetTableAdapters.t_filesTableAdapter
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Integer

    Public Sub Run(ByRef arPlayList As ListBox.ObjectCollection)
        Dim PPPres As Microsoft.Office.Interop.PowerPoint.Application
        Dim SSWin As SlideShowWindow
        Dim szFileName, szFPath As String, i, iFileNo, iIndex As Integer
        Dim myParts() As String = {"", ""}
        Dim mySettings As New PPLInk.Settings
        Dim szConn As String = mySettings.ProHelpConnectionUser
        If szConn <> "" Then
            Dim connection As New System.Data.SqlClient.SqlConnection(szConn)
            TFadap.Connection = connection
        End If

        TFadap.FillAll(myDataSet.t_files)
        Dim filesView As DataView = myDataSet.Tables("t_files").DefaultView
        filesView.Sort = "file_no"

        PPPres = New Microsoft.Office.Interop.PowerPoint.Application
        PPPres.Visible = True
        i = -1
        Do
            i = i + 1
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

        PPPres.WindowState = PpWindowState.ppWindowMinimized
        PPPres.Quit()
    End Sub
End Class
