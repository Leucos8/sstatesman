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
        Friend Length As Long
        Friend LastWriteTime As DateTime

        Friend Overridable ReadOnly Property Number As Integer
            Get
                Return -1
            End Get
        End Property
        Friend Overridable Property ExtraInfo As String = ""
        Friend Overridable Sub GetExtraInfo(pPath As String)
            ExtraInfo = ""
        End Sub

        Friend MustOverride Function GetGameSerial() As String
        Friend Overridable Function GetGameCRC() As String
            Return String.Format("{0:N8}", 0)
        End Function

        Friend Enum PCSX2FileType
            OtherFileType = 0
            PCSX2Savestate = 1
            PCSX2SavestateBackup = 2
            PCSX2Screenshot = 3
        End Enum
    End Class


    Friend Class Savestate
        Inherits sstatesman.PCSX2File

        Friend Overrides ReadOnly Property Number As Integer
            Get
                If Not (Integer.TryParse(Name.Substring(Name.IndexOf("."c, 0) + 1, 2), Number)) Then
                    Number = -1
                    'ElseIf Not ((Number >= My.Settings.PCSX2_SStateSlotLowerBound) And (Number <= My.Settings.PCSX2_SStateSlotUpperBound)) Then
                    '    Number = -1
                End If
                Return Number
            End Get
        End Property
        Friend Overrides Property ExtraInfo As String = ""

        Friend Overrides Function GetGameSerial() As String
            Return Savestate.GetGameSerial(Name)
        End Function

        Friend Overloads Shared Function GetGameSerial(pFilename As String) As String
            Dim SpacePosition As Integer = pFilename.IndexOf(" "c, 0)
            If SpacePosition > 0 Then
                Return pFilename.Remove(SpacePosition)
            Else
                Return pFilename
            End If
        End Function

        Friend Overrides Sub GetExtraInfo(pPath As String)
            If My.Settings.SStatesMan_SStatesVersionExtract Then
                Dim tmpFile As New IO.FileInfo(IO.Path.Combine(pPath, Name))
                ExtraInfo = mdlSimpleZipExtractor.ExtractFirstFile(tmpFile)
                ExtraInfo &= " " & PCSX2StateVerDB.GetRevisions(ExtraInfo)
            Else : ExtraInfo = "-"
            End If
        End Sub

        Friend Overrides Function GetGameCRC() As String
            Return Savestate.GetGameCRC(Name)
        End Function

        Friend Overloads Shared Function GetGameCRC(pFilename As String) As String
            Dim ParOPosition As Integer = pFilename.IndexOf("("c, 0)
            Dim ParCPosition As Integer = pFilename.IndexOf(")"c, 0)
            If (ParOPosition > 0) AndAlso (ParCPosition > ParOPosition) Then
                Return pFilename.Substring(ParOPosition + 1, ParCPosition - ParOPosition - 1)
            Else
                Return String.Format("N8", 0)
            End If
        End Function

        Friend Overloads Shared Function ToString(pSerial As String, pCRC As String, pSlot As Integer, pMinSlot As Integer, pMaxSlot As Integer, pSlotType As Boolean) As String
            If (pSlot >= pMinSlot) And (pSlot <= pMaxSlot) Then
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

        Friend Overrides Function GetGameSerial() As String
            Return Snapshot.GetGameSerial(Name)
        End Function

        Friend Overloads Shared Function GetGameSerial(ByVal pFilename As String) As String
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
