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

Module mdlMain
    ''' <summary>Object that will be used to contain the PCSX2 GameDB used by SStatesMan.</summary>
    Friend PCSX2GameDb As GameDB
    Friend SSMGameList As New GamesList

    Friend PCSX2StateVerDB As ssVersionDB

    Friend SSMAppLog As New AppLog

    Friend DPIxScale As Single = 1.0F
    Friend DPIyScale As Single = 1.0F

    Friend Enum LoadStatus As Byte
        StatusEmpty
        StatusLoadedOK
        StatusNotLoaded
        StatusError
    End Enum

    Friend Sub FirstRun()
        My.Settings.Reset()
        My.Settings.SStatesMan_SettingsOK = PCSX2_PathAll_Detect()

        My.Settings.SStatesMan_FirstRun = False
        My.Settings.Save()
    End Sub

    Friend Function assignFlag(ByVal pRegionToCheck As String, Optional ByVal pSerialToCheck As String = "") As Bitmap
        'Return My.Resources.Flag_0Null_30x20
        If pRegionToCheck IsNot Nothing And pSerialToCheck IsNot Nothing Then
            pRegionToCheck = pRegionToCheck.ToUpper
            If pRegionToCheck.StartsWith("PAL") Then
                If pRegionToCheck.StartsWith("PAL-I") Then
                    Return My.Resources.Flag_Italy_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-F") Then
                    Return My.Resources.Flag_France_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-GR") Then
                    Return My.Resources.Flag_Greece_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-G") Or pRegionToCheck.StartsWith("PAL-D") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUT" Then
                        Return My.Resources.Flag_Austria_30x20
                    Else : Return My.Resources.Flag_Germany_30x20
                    End If
                    'ElseIf pRegionToCheck.StartsWith("PAL-SW") Then
                    '    Return My.Resources.Flag_Switzerland_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-S") Then
                    Return My.Resources.Flag_Spain_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-E") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUS" Then
                        Return My.Resources.Flag_Australia_30x20
                    Else : Return My.Resources.Flag_UK_30x20
                    End If
                ElseIf pRegionToCheck.StartsWith("PAL-P") Then
                    Return My.Resources.Flag_Poland_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-R") Then
                    Return My.Resources.Flag_Russia_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-N") Then
                    Return My.Resources.Flag_Netherlands_30x20
                Else
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUS" Then
                        Return My.Resources.Flag_Australia_30x20
                    Else : Return My.Resources.Flag_EU_30x20
                    End If
                End If
            ElseIf pRegionToCheck.StartsWith("NTSC") Then
                If pRegionToCheck.StartsWith("NTSC-CH") Then
                    Return My.Resources.Flag_China_30x20
                ElseIf pRegionToCheck.StartsWith("NTSC-K") Or _
                    pSerialToCheck.StartsWith("SCKA") Or _
                    pSerialToCheck.StartsWith("SLKA") Then
                    Return My.Resources.Flag_South_Korea_30x20
                ElseIf pRegionToCheck.StartsWith("NTSC-J") Or _
                    pSerialToCheck.StartsWith("SCPS") Or _
                    pSerialToCheck.StartsWith("SLPM") Or _
                    pSerialToCheck.StartsWith("SLPS") Then
                    Return My.Resources.Flag_Japan_30x20
                ElseIf ((Not (pRegionToCheck = "NTSC-UNK")) And pRegionToCheck.StartsWith("NTSC-U")) Or _
                    pSerialToCheck.StartsWith("SCUS") Or _
                    pSerialToCheck.StartsWith("SLUS") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "CAN" Then
                        Return My.Resources.Flag_Canada_30x20
                    Else : Return My.Resources.Flag_US_30x20
                    End If
                End If
            End If
        End If
        Return My.Resources.Extra_ClearImage_30x20
    End Function

    Friend Function TrimBadPathChars(ByVal pInputPath As String, Optional ByVal pTrimBadChars As Boolean = False) As String
        If (Not (pInputPath = "")) Then
            Dim badChars() As Char = {" "c, "\"c, "/"c, ":"c}
            Dim invalidChars() As Char = {""""c, "*"c, "?"c, "|"c, "<"c, ">"c}
            If pTrimBadChars Then
                pInputPath = pInputPath.Trim(badChars)
            Else
                pInputPath = pInputPath.Trim
            End If
            For Each tmpChar As Char In invalidChars
                pInputPath = pInputPath.Replace(tmpChar, "_"c)
            Next
        End If
        Return pInputPath
    End Function
End Module
