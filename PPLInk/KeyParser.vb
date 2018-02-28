Public Class KeyParser
    Public Sub GetKeyValues(szInput As String, szSeparator As String, ByRef szParms() As String)
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

    Public Function BuildKeyString(szSeparator As String, ByRef szParms() As String) As String
        Dim iLoop As Integer = 0
        Dim szTemp As String = ""

        If szParms.Length = 0 Then
            BuildKeyString = ""
            Exit Function
        End If

        Do
            szTemp = szTemp + szParms(iLoop)
            iLoop = iLoop + 1
            If iLoop = szParms.Length Then Exit Do
            szTemp = szTemp + szSeparator
        Loop
        BuildKeyString = szTemp
    End Function

End Class
