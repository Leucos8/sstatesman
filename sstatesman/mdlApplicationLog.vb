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
    Public AppLog As New List(Of sLog)
    Const AppLog_MaxLenght As Integer = 31

    Public Sub AppendToLog(ByVal pClass As String, ByVal pMethod As String, ByVal pMessage As String, Optional pDuration As Long = -1)
        Const AppLog_MaxLenght As Integer = 31
        If AppLog.Count >= AppLog_MaxLenght Then
            AppLog.RemoveAt(0)
        End If
        AppLog.Add(New sLog With {.Time = Now, .OrClass = pClass, .OrMethod = pMethod, .Description = pMessage, .Duration = pDuration})
        'Console.WriteLine(String.Format("[{0:HH.mm.ss}] {1}: {2} {3} {4:N1}ms.", Now, pClass, pMethod, pMessage, pDuration))
    End Sub
End Module
