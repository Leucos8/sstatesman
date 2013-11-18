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
Module mdlFileClasses
    Friend MustInherit Class PCSX2File
        Friend Name As String
        Friend Length As Long
        Friend LastWriteTime As DateTime

        Friend ReadOnly Property Extension As String
            Get
                Dim DotPosition As Integer = Name.LastIndexOf("."c)
                If DotPosition > 0 Then
                    Return Name.Remove(0, DotPosition)
                Else
                    Return ""
                End If
            End Get
        End Property
        Friend Overridable ReadOnly Property Number As Integer
            Get
                Return -1
            End Get
        End Property
        Friend Overridable Property ExtraInfo As String = ""
    End Class


    Friend Class Savestate
        Inherits sstatesman.PCSX2File

        Friend Overrides ReadOnly Property Number As Integer
            Get
                If Not (Integer.TryParse(Name.Substring(Name.IndexOf("."c, 0) + 1, 2), Number)) Then
                    Number = -1
                ElseIf Not ((Number >= My.Settings.PCSX2_SStateSlotLowerBound) And (Number <= My.Settings.PCSX2_SStateSlotUpperBound)) Then
                    Number = -1
                End If
                Return Number
            End Get
        End Property
        Friend Overrides Property ExtraInfo As String = ""

        Friend Function GetSerial() As String
            Return Savestate.GetSerial(Name)
        End Function

        Friend Shared Function GetSerial(ByVal pFilename As String) As String
            Dim SpacePosition As Integer = pFilename.IndexOf(" "c, 0)
            If SpacePosition > 0 Then
                Return pFilename.Remove(SpacePosition)
            Else
                Return pFilename
            End If
        End Function


        Friend Function GetCRC() As String
            Return Savestate.GetCRC(Name)
        End Function

        Friend Shared Function GetCRC(ByVal pFilename As String) As String
            Dim ParOPosition As Integer = pFilename.IndexOf("("c, 0)
            Dim ParCPosition As Integer = pFilename.IndexOf(")"c, 0)
            If (ParOPosition > 0) AndAlso (ParCPosition > ParOPosition) Then
                Return pFilename.Substring(ParOPosition + 1, ParCPosition - ParOPosition - 1)
            Else
                Return String.Format("N8", 0)
            End If
        End Function

        Friend Function isBackup() As Boolean
            If Extension = My.Settings.PCSX2_SStateExtBackup Then
                Return True
            Else
                Return False
            End If
        End Function

        Friend Shared Function isBackup(ByVal pFilename As String) As Boolean
            Dim tmpSavestate As New Savestate With {.Name = pFilename}
            Return tmpSavestate.isBackup
        End Function

        Friend Overloads Shared Function ToString(pSerial As String, pCRC As String, pSlot As Integer, pSlotType As Boolean) As String
            If (pSlot >= My.Settings.PCSX2_SStateSlotLowerBound) And (pSlot <= My.Settings.PCSX2_SStateSlotUpperBound) Then
                ToString = String.Format("{0} ({1}).{2:00}{3}", pSerial, pCRC, pSlot, My.Settings.PCSX2_SStateExt)
                If pSlotType Then
                    ToString &= My.Settings.PCSX2_SStateExtBackup
                End If
                Return ToString
            Else
                Return String.Format("{0} ({1}).X{2:00}{3}", pSerial, pCRC, pSlot, My.Settings.PCSX2_SStateExt)
            End If
        End Function

    End Class

    Friend Class Snapshot
        Inherits sstatesman.PCSX2File

        Friend Overrides ReadOnly Property Number As Integer
            Get
                Return -1
            End Get
        End Property
        Friend Overrides Property ExtraInfo As String = ""

        Friend Function GetSerial() As String
            Return Snapshot.GetSerial(Name)
        End Function

        Friend Shared Function GetSerial(ByVal pFilename As String) As String
            'Dim SpacePosition As Int32 = Name.IndexOf(" "c, 0)
            'If Name.ToLower.StartsWith("gsdx") Then
            '    Return "GSdX"
            Dim SpacePosition As Integer = pFilename.IndexOf(" "c, 0)
            If SpacePosition > 0 Then
                Return pFilename.Remove(SpacePosition)
            Else
                Return "Screenshots"
            End If

        End Function
    End Class


End Module
