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
Module mdlApplicationLog
    Friend Structure sLog
        Friend Time As DateTime
        Friend OrClass As String
        Friend OrMethod As String
        Friend Description As String
        Friend Duration As Long
    End Structure
    Public Class AppLog
        Public Events As New List(Of sLog)
        Const MaxLenght As Integer = 31

        Public Sub Append(ByVal pClass As String, ByVal pMethod As String, ByVal pMessage As String, Optional pDuration As Long = -1)
            If Events.Count >= AppLog.MaxLenght Then
                Events.RemoveAt(0)
            End If
            Events.Add(New sLog With {.Time = Now, .OrClass = pClass, .OrMethod = pMethod, .Description = pMessage, .Duration = pDuration})
        End Sub

        Public Sub ExportConsole()
            If Events.Count > 0 Then
                For Each tmpLogItem As sLog In Events
                    Console.WriteLine(String.Format("[{0:HH.mm.ss}] {1}: {2} {3} {4:N1}ms.", tmpLogItem.Time, tmpLogItem.OrClass, tmpLogItem.OrMethod, tmpLogItem.Description, tmpLogItem.Duration))
                Next
            End If
        End Sub

        Public Sub ExportFile(ByVal pPath As String)
            If Events.Count > 0 Then
                Using tmpStreamWriter As IO.StreamWriter = New IO.StreamWriter(pPath)
                    tmpStreamWriter.WriteLine(String.Concat("Timestamp", vbTab, "Origin", vbTab, "Action", vbTab, "Description", vbTab, "Duration"))
                    For Each tmpLogItem As sLog In Events
                        tmpStreamWriter.WriteLine(String.Concat(tmpLogItem.Time.ToString, vbTab,
                                                                tmpLogItem.OrClass, vbTab,
                                                                tmpLogItem.OrMethod, vbTab,
                                                                tmpLogItem.Description, vbTab,
                                                                tmpLogItem.Duration))
                    Next
                End Using
            End If
        End Sub

        Public Sub FilterByClass(ByVal pPattern As String, ByRef pResults As List(Of sLog))
            If Events.Count > 0 Then
                pResults = Events.Where(Function(item) item.OrClass.ToLower.Contains(pPattern.ToLower)).ToList
            End If
        End Sub
    End Class
End Module
