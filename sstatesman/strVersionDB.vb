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
Public Structure ssVersionDB
    Public Structure rVersion
        Friend ssVersion As String
        Friend minRevision As Integer
    End Structure
    Public Property DB As List(Of rVersion)

    Public Sub Load(ByVal pVDB As String)
        If String.IsNullOrEmpty(pVDB) Then Exit Sub
        Using tmpStream As Stream = New MemoryStream(System.Text.UTF8Encoding.Default.GetBytes(pVDB.ToCharArray))
            Using tmpStreamReader As New StreamReader(tmpStream)
                DB = New List(Of rVersion)
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

    Public Sub GetRevisions(ByVal pVersion As String, ByRef pMinRevision As Integer, ByRef pMaxRevision As Integer)
        If DB.Count > 0 Then
            For i As Integer = 0 To DB.Count - 1
                If DB(i).ssVersion.ToUpper = pVersion.ToUpper Then
                    If i = 0 Then
                        'The latest
                        pMinRevision = DB(i).minRevision
                        pMaxRevision = 0
                        Exit For
                    Else
                        'Not the latest
                        pMinRevision = DB(i).minRevision
                        pMaxRevision = (DB(i - 1).minRevision - 1)
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Public Function GetRevisions(ByVal pVersion As String) As String
        Dim minRevision As Integer = 0
        Dim maxRevision As Integer = 0
        GetRevisions(pVersion, minRevision, maxRevision)
        If (minRevision > 0) And (maxRevision > 0) Then
            Return "(r" & minRevision & ">" & maxRevision & ")"
        ElseIf (minRevision > 0) And (maxRevision = 0) Then
            Return "(r" & minRevision & ">Latest)"
        Else : Return ""
        End If
    End Function
End Structure
