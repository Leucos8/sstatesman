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
Public Class Savestate
    Public Property Name As String
    Private _extension As String
    Public ReadOnly Property Extension() As String
        Get
            Dim DotPosition As Integer = Name.LastIndexOf("."c)
            If DotPosition > 0 Then
                _extension = Name.Remove(0, DotPosition)
            Else
                _extension = ""
            End If
            Return _extension
        End Get
    End Property

    Public Property Length As Long
    Public Property LastWriteTime As DateTime
    'Public Property Slot As Integer
    Private _slot As Integer
    Public ReadOnly Property Slot() As Integer
        Get
            If Not (Integer.TryParse(Name.Substring(Name.IndexOf("."c, 0) + 1, 2), _slot)) Then
                _slot = -1
            ElseIf Not ((_slot >= 0) Or (_slot <= 9)) Then
                _slot = -1
            End If
            Return _slot
        End Get
    End Property

    'Public Property Backup As Boolean
    'Private _backup As Boolean
    'Public ReadOnly Property Backup() As Boolean
    '    Get
    '        If Extension = My.Settings.PCSX2_SStateExtBackup Then
    '            _backup = True
    '        Else
    '            _backup = False
    '        End If
    '        Return _backup
    '    End Get
    'End Property

    Public Property Version As String

    Public Function GetSerial() As String
        Dim SpacePosition As Integer = Name.IndexOf(" "c, 0)
        If SpacePosition > 0 Then
            Return Name.Remove(SpacePosition)
        Else
            Return Name
        End If
    End Function

    Public Shared Function GetSerial(ByVal pFilename As String) As String
        Dim tmpSavestate As New Savestate With {.Name = pFilename}
        Return tmpSavestate.GetSerial
    End Function


    Public Function GetCRC() As String
        Dim ParOPosition As Integer = Name.IndexOf("("c, 0)
        Dim ParCPosition As Integer = Name.IndexOf(")"c, 0)
        If (ParOPosition > 0) And (ParCPosition > ParOPosition) Then
            Return Name.Substring(ParOPosition + 1, ParCPosition - ParOPosition - 1)
        Else
            Return "00000000"
        End If
    End Function

    Public Shared Function GetCRC(ByVal pFilename As String) As String
        Dim tmpSavestate As New Savestate With {.Name = pFilename}
        Return tmpSavestate.GetCRC
    End Function

    Public Function isBackup() As Boolean
        If Extension = My.Settings.PCSX2_SStateExtBackup Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function isBackup(ByVal pFilename As String) As Boolean
        Dim tmpSavestate As New Savestate With {.Name = pFilename}
        Return tmpSavestate.isBackup
    End Function
End Class
