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
Imports Microsoft.Win32

Module mdlMain
    ''' <summary>Object that will be used to contain the PCSX2 GameDB used by SStatesMan.</summary>
    Public PCSX2GameDb As New mdlGameDb.GameDB
    Public SSMGameList As New mdlFileList.GamesList

    Friend DPIxScale As Single = 1.0F
    Friend DPIyScale As Single = 1.0F

    Public Enum LoadStatus As Byte
        StatusEmpty
        StatusLoadedOK
        StatusNotLoaded
        StatusError
    End Enum

    Public Sub FirstRun()
        My.Settings.Reset()
        PCSX2_PathAll_Detect()

        My.Settings.SStatesMan_FirstRun = False
        My.Settings.Save()
    End Sub

    Public Sub PCSX2_PathAll_Detect()
        My.Settings.SStatesMan_SettingFail = True

        My.Settings.PCSX2_PathBin = PCSX2_PathBin_Detect()
        If Directory.Exists(My.Settings.PCSX2_PathBin) Then
            My.Settings.PCSX2_PathInis = PCSX2_PathInis_Detect(My.Settings.PCSX2_PathBin)
            If Directory.Exists(My.Settings.PCSX2_PathInis) Then
                PCSX2_PathSettings_Detect(My.Settings.PCSX2_PathInis, My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps)
                If Directory.Exists(My.Settings.PCSX2_PathSState) Then
                    My.Settings.SStatesMan_SettingFail = False
                End If
            End If
        End If

    End Sub

    Public Function PCSX2_PathBin_Detect() As String
        PCSX2_PathBin_Detect = ""
        Try
            Using PCSX2_Registry As RegistryKey = Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                'OpenSubKey returns Nothing if the key doesn't exist
                If PCSX2_Registry IsNot Nothing Then
                    'I assume that the installation found in the registry is the good one
                    '                                           Install_Dir
                    PCSX2_PathBin_Detect = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathBinReg, "").ToString
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Something went wrong while detecting PCSX2 settings, make sure you have the right registry and/or directories/files permissions ." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Directory.Exists(PCSX2_PathBin_Detect) Then
            Return PCSX2_PathBin_Detect
        Else
            Return ""
        End If
    End Function

    Public Function PCSX2_PathInis_Detect(ByVal pPCSX2_PathBin As String) As String
        PCSX2_PathInis_Detect = ""
        Try
            If Directory.Exists(pPCSX2_PathBin) Then
                'Check if it is the case of a user who installed PCSX2 in usermode and then switched to portable mode
                If File.Exists(Path.Combine(pPCSX2_PathBin, "portable.ini")) Then
                    'If so the inis are in the "inis" folder of the PCSX2 binaries directory
                    Return Path.Combine(pPCSX2_PathBin, "inis")
                Else
                    'Else the registry value is checked
                    Using PCSX2_Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                        'OpenSubKey returns Nothing if the key doesn't exist
                        If PCSX2_Registry IsNot Nothing Then
                            'I assume that the installation found in the registry is the good one
                            '                                               SettingsFolder
                            PCSX2_PathInis_Detect = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathInisReg, "").ToString
                        End If
                    End Using
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Something went wrong while detecting PCSX2 settings, make sure you have the right registry and/or directories/files permissions ." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Directory.Exists(PCSX2_PathInis_Detect) Then
            Return PCSX2_PathInis_Detect
        Else
            Return ""
        End If

    End Function

    Public Sub PCSX2_PathSettings_Detect(ByVal pPCSX2_PathInis As String, ByRef pPCSX2_PathSStates_Detect As String, ByRef pPCSX2_PathSnaps_Detect As String)

        'If PCSX2_UI.ini is present in the set inis directory
        If File.Exists(Path.Combine(pPCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename)) Then
            'PCSX2_UI.ini is read and checked for the savestates folder
            Using PCSX2UI_reader As New StreamReader(Path.Combine(pPCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename))
                While Not PCSX2UI_reader.EndOfStream
                    Dim tmpLine As String = PCSX2UI_reader.ReadLine.Trim.ToLower

                    If tmpLine.StartsWith("savestates=") Then
                        Dim sTmp2 As String() = tmpLine.Split({"="c}, 2, StringSplitOptions.RemoveEmptyEntries)
                        If sTmp2.GetLength(0) > 1 Then
                            pPCSX2_PathSStates_Detect = sTmp2(1).Replace("\\", "\")
                        End If
                    ElseIf tmpLine.StartsWith("snapshots=") Then
                        Dim tmpFields As String() = tmpLine.Split({"="c}, 2, StringSplitOptions.RemoveEmptyEntries)
                        If tmpFields.GetLength(0) > 1 Then
                            pPCSX2_PathSnaps_Detect = tmpFields(1).Replace("\\", "\")
                        End If
                    End If

                End While
                PCSX2UI_reader.Close()
            End Using
        End If

        If Not (Directory.Exists(pPCSX2_PathSStates_Detect)) Then
            pPCSX2_PathSStates_Detect = ""
        End If
        If Not (Directory.Exists(pPCSX2_PathSnaps_Detect)) Then
            pPCSX2_PathSnaps_Detect = ""
        End If
    End Sub

    Public Sub PCSX2_PathAll_Check()
        If Directory.Exists(My.Settings.PCSX2_PathBin) And
            Directory.Exists(My.Settings.PCSX2_PathInis) And
            Directory.Exists(My.Settings.PCSX2_PathSState) Then
            My.Settings.SStatesMan_SettingFail = False
        Else
            My.Settings.SStatesMan_SettingFail = True
        End If
    End Sub

    Public Function assignFlag(ByVal pRegionToCheck As String, Optional ByVal pSerialToCheck As String = "") As Bitmap
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
        Return My.Resources.Flag_0Null_30x20
    End Function
End Module
