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
Public Class Snapshot
    Public Property Name As String
    Public Property Extension As String
    Public Property Length As Long
    Public Property LastWriteTime As DateTime

    Public Function GetSerial() As String
        'Dim SpacePosition As Int32 = Name.IndexOf(" "c, 0)
        'If Name.ToLower.StartsWith("gsdx") Then
        '    Return "GSdX"
        If PCSX2GameDb.Records.ContainsKey(Name) Then
            Return Name
        Else
            Return "Screenshots"
        End If
    End Function

    Public Shared Function GetSerial(ByVal pFilename As String) As String
        Dim tmpSnapshot As New Snapshot With {.Name = pFilename}
        Return tmpSnapshot.GetSerial
    End Function
End Class

