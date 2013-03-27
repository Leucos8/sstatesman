'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2013 - Leucos
'
'   SStatesMan is free software: you can redistribute it and/or modify it under
'   the terms of the GNU Lesser General Public License as published by the Free
'   Software Foundation, either version 3 of the License, or (at your option) any
'   later version.
'
'   SStatesMan is distributed in the hope that it will be useful, but WITHOUT ANY
'   WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
'   PARTICULAR PURPOSE. See the GNU General Public License for more details.
'
'   You should have received a copy of the GNU General Public License along with 
'   SStatesMan. If not, see <http://www.gnu.org/licenses/>.
Imports System.IO
Public Class ssVersionDB
    Public Structure rVersion
        Friend ssVersion As String
        Friend minRevision As Integer
    End Structure
    Public Property DB As New List(Of rVersion)

    Public Sub Load(ByVal pVDB As String)
        If String.IsNullOrEmpty(pVDB) Then Exit Sub
        Using tmpStream As Stream = New MemoryStream(System.Text.UTF8Encoding.Default.GetBytes(pVDB.ToCharArray))
            Using tmpStreamReader As New StreamReader(tmpStream)
                While Not tmpStreamReader.EndOfStream
                    Dim tmpLine As String = tmpStreamReader.ReadLine
                    If Not (tmpLine.StartsWith("'"c)) Then
                        Dim tmpSplittedString As String() = tmpLine.Split(Char.Parse(vbTab))
                        If tmpSplittedString.Count > 1 Then
                            Dim tmpItem As New rVersion With {.ssVersion = tmpSplittedString(0)}
                            If Integer.TryParse(tmpSplittedString(1), tmpItem.minRevision) Then
                                DB.Add(tmpItem)
                            End If
                        End If
                    End If
                End While

            End Using
        End Using
    End Sub

    Public Sub GetRevisions(ByRef pVersion As String, ByVal pMinRevision As String, ByVal pMaxRevision As String)
        If DB.Count > 0 Then
            For i As Integer = 0 To DB.Count - 1
                If DB(i).ssVersion.ToUpper = pVersion.ToUpper Then
                    If i = 0 Then
                        'The latest
                        pMinRevision = DB(i).minRevision.ToString
                        pMaxRevision = "current"
                        Exit For
                    Else
                        'Not the latest
                        pMinRevision = DB(i).minRevision.ToString
                        pMaxRevision = (DB(i - 1).minRevision - 1).ToString
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub
End Class
