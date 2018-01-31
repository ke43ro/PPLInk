'Imports Microsoft.Office
Imports Microsoft.Office.Interop.PowerPoint

Public Class PlayList
    Private myDataSet As New ProHelpDataSet
    Dim TFadap As New ProHelpDataSetTableAdapters.t_filesTableAdapter


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

        TFadap.Fill(myDataSet.t_files)
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
            ParseKeyValue(szFileName, "::", myParts)
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
                SSWin.Activate()
                'System.Threading.Thread.Sleep(2000)
                Do
                    If SSWin Is Nothing Then Exit Do
                    Try
                        If SSWin.Active Then System.Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        Exit Do
                    End Try
                Loop

                .Close()
            End With
        Loop

        PPPres.WindowState = PpWindowState.ppWindowMinimized
        PPPres.Quit()
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

End Class
