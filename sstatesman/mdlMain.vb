'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2012 - Leucos
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

    Friend checkedGames As New List(Of String)
    Friend checkedSavestates As New List(Of String)
    Public DPIxScale As Single = 1.0
    Public DPIyScale As Single = 1.0

    Public Enum LoadStatus As Byte
        StatusEmpty
        StatusLoadedOK
        StatusNotLoaded
        StatusError
    End Enum

    Friend Structure sLog
        Friend Time As DateTime
        Friend OrClass As String
        Friend OrMethod As String
        Friend Description As String
        Friend Duration As Double
    End Structure
    Public AppLog As New List(Of sLog)

    Public Sub FirstRun()
        'Show the warning message
        'If My.Settings.SStatesMan_Channel.ToLower = "alpha" Then
        '    System.Windows.Forms.MessageBox.Show(System.String.Format("{0} version {1} {2}" & System.Environment.NewLine &
        '                                         "This is an {3} version, for tests only. Do not redistribute." & System.Environment.NewLine &
        '                                         "The warnings have been issued, now enjoy the application :)",
        '                                         My.Application.Info.ProductName.ToString,
        '                                         My.Application.Info.Version.ToString,
        '                                         My.Settings.SStatesMan_Channel,
        '                                         My.Settings.SStatesMan_Channel.ToUpper),
        '                                         My.Application.Info.ProductName,
        '                                         MessageBoxButtons.OK,
        '                                         MessageBoxIcon.Information)
        'End If
        My.Settings.Reset()
        PCSX2_PathAll_Detect()

        My.Settings.SStatesMan_FirstRun2 = False
        My.Settings.Save()
    End Sub

    Public Sub PCSX2_PathAll_Detect()

        My.Settings.PCSX2_PathBinSet = PCSX2_PathBin_Detect(My.Settings.PCSX2_PathBin)
        My.Settings.PCSX2_PathInisSet = PCSX2_PathInis_Detect(My.Settings.PCSX2_PathInis)
        My.Settings.PCSX2_PathSStatesSet = PCSX2_PathSStates_Detect(My.Settings.PCSX2_PathSState)

    End Sub

    Public Function PCSX2_PathBin_Detect(ByRef pResult As String) As Boolean
        pResult = "Not detected"
        PCSX2_PathBin_Detect = False

        Try
            Using PCSX2_Registry As RegistryKey = Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                'OpenSubKey returns Nothing if the key doesn't exist
                If PCSX2_Registry IsNot Nothing Then
                    'I assume that the installation found in the registry is the good one
                    '                                                   Install_Dir
                    pResult = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathBinReg, "Not detected").ToString
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Something went wrong while detecting PCSX2 settings, make sure you have the right permissions in the registry or in the directories/files." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Directory.Exists(pResult) Then
            PCSX2_PathBin_Detect = True
        Else
            pResult = "Not detected"
        End If
    End Function

    Public Function PCSX2_PathInis_Detect(ByRef pResult As String) As Boolean
        pResult = "Not detected"
        PCSX2_PathInis_Detect = False
        Try
            If My.Settings.PCSX2_PathBinSet And System.IO.Directory.Exists(My.Settings.PCSX2_PathBin) Then
                'Check if it is the case of a user who installed PCSX2 in usermode and then switched to portable mode
                If System.IO.File.Exists(System.IO.Path.Combine(My.Settings.PCSX2_PathBin, "portable.ini")) Then
                    'If so the inis are in the "inis" folder of the PCSX2 binaries directory
                    pResult = System.IO.Path.Combine(My.Settings.PCSX2_PathBin, "inis")
                Else
                    'Else the registry value is checked                                 SettingsFolder
                    Using PCSX2_Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                        'OpenSubKey returns Nothing if the key doesn't exist
                        If PCSX2_Registry IsNot Nothing Then
                            'I assume that the installation found in the registry is the good one
                            '                                                       Install_Dir
                            pResult = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathInisReg, "Not detected").ToString
                        End If
                    End Using
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Something went wrong while detecting PCSX2 settings, make sure you have the right permissions in the registry or in the directories/files." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Directory.Exists(pResult) Then
            PCSX2_PathInis_Detect = True
        Else
            pResult = "Not detected"
        End If
    End Function

    Public Function PCSX2_PathSStates_Detect(ByRef pResult As String) As Boolean
        pResult = "Not detected"
        PCSX2_PathSStates_Detect = False

        If My.Settings.PCSX2_PathInisSet And System.IO.Directory.Exists(My.Settings.PCSX2_PathInis) Then
            'If PCSX2_UI.ini is present in the set inis directory
            If System.IO.File.Exists(Path.Combine(My.Settings.PCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename)) Then
                'PCSX2_UI.ini is read and checked for the savestates folder
                Using PCSX2UI_reader As New StreamReader(Path.Combine(My.Settings.PCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename))
                    While Not PCSX2UI_reader.EndOfStream
                        Dim sTmp1 As String = PCSX2UI_reader.ReadLine.Trim.ToLower

                        If sTmp1 = "usedefaultsavestates=enabled" Then
                            pResult = Path.Combine(My.Settings.PCSX2_PathInis.Remove(My.Settings.PCSX2_PathInis.Length - 5), My.Settings.PCSX2_SStateFolder)
                            Exit While
                        ElseIf sTmp1.StartsWith("savestates=") Then
                            Dim sTmp2 As String() = sTmp1.Split({"="c}, 2, StringSplitOptions.RemoveEmptyEntries)
                            If sTmp2.GetLength(0) >= 2 Then
                                pResult = sTmp2(1).Replace("\\", "\")
                            End If
                        End If

                    End While
                    PCSX2UI_reader.Close()
                End Using
            End If
        End If

        If System.IO.Directory.Exists(pResult) Then
            PCSX2_PathSStates_Detect = True
        Else
            pResult = "Not detected"
        End If
    End Function

    Public Function PCSX2_PathAll_Check() As System.Boolean
        If Directory.Exists(My.Settings.PCSX2_PathBin) Then
            My.Settings.PCSX2_PathBinSet = True
        Else
            My.Settings.PCSX2_PathBin = "Not detected"
            My.Settings.PCSX2_PathBinSet = False
        End If

        If Directory.Exists(My.Settings.PCSX2_PathInis) Then
            My.Settings.PCSX2_PathInisSet = True
        Else
            My.Settings.PCSX2_PathInis = "Not detected"
            My.Settings.PCSX2_PathInisSet = False
        End If

        If Directory.Exists(My.Settings.PCSX2_PathSState) Then
            My.Settings.PCSX2_PathSStatesSet = True
        Else
            My.Settings.PCSX2_PathSState = "Not detected"
            My.Settings.PCSX2_PathSStatesSet = False
        End If

        If (My.Settings.PCSX2_PathBinSet = False) Or _
           (My.Settings.PCSX2_PathInisSet = False) Or _
           (My.Settings.PCSX2_PathSStatesSet = False) Then
            PCSX2_PathAll_Check = True
        Else
            PCSX2_PathAll_Check = False
        End If
    End Function

    Public Function assignFlag(ByVal pRegionToCheck As String, Optional ByVal pSerialToCheck As String = "") As Bitmap
        assignFlag = My.Resources.Flag_0Null_30x20
        If pRegionToCheck IsNot Nothing And pSerialToCheck IsNot Nothing Then
            pRegionToCheck = pRegionToCheck.ToUpper
            If pRegionToCheck.StartsWith("PAL") Then
                If pRegionToCheck.StartsWith("PAL-I") Then
                    assignFlag = My.Resources.Flag_Italy_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-F") Then
                    assignFlag = My.Resources.Flag_France_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-GR") Then
                    assignFlag = My.Resources.Flag_Greece_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-G") Or pRegionToCheck.StartsWith("PAL-D") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUT" Then
                        assignFlag = My.Resources.Flag_Austria_30x20
                    Else : assignFlag = My.Resources.Flag_Germany_30x20
                    End If
                    'ElseIf pRegionToCheck.StartsWith("PAL-SW") Then
                    '    assignFlag = My.Resources.Flag_Switzerland_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-S") Then
                    assignFlag = My.Resources.Flag_Spain_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-E") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUS" Then
                        assignFlag = My.Resources.Flag_Australia_30x20
                    Else : assignFlag = My.Resources.Flag_UK_30x20
                    End If
                ElseIf pRegionToCheck.StartsWith("PAL-P") Then
                    assignFlag = My.Resources.Flag_Poland_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-R") Then
                    assignFlag = My.Resources.Flag_Russia_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-N") Then
                    assignFlag = My.Resources.Flag_Netherlands_30x20
                Else
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUS" Then
                        assignFlag = My.Resources.Flag_Australia_30x20
                    Else : assignFlag = My.Resources.Flag_Europe_Union_30x20
                    End If
                End If
            ElseIf pRegionToCheck.StartsWith("NTSC") Then
                If pRegionToCheck.StartsWith("NTSC-CH") Then
                    assignFlag = My.Resources.Flag_China_30x20
                ElseIf pRegionToCheck.StartsWith("NTSC-K") Or _
                    pSerialToCheck.StartsWith("SCKA") Or _
                    pSerialToCheck.StartsWith("SLKA") Then
                    assignFlag = My.Resources.Flag_South_Korea_30x20
                ElseIf pRegionToCheck.StartsWith("NTSC-J") Or _
                    pSerialToCheck.StartsWith("SCPS") Or _
                    pSerialToCheck.StartsWith("SLPM") Or _
                    pSerialToCheck.StartsWith("SLPS") Then
                    assignFlag = My.Resources.Flag_Japan_30x20
                ElseIf ((Not (pRegionToCheck = "NTSC-UNK")) And pRegionToCheck.StartsWith("NTSC-U")) Or _
                    pSerialToCheck.StartsWith("SCUS") Or _
                    pSerialToCheck.StartsWith("SLUS") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "CAN" Then
                        assignFlag = My.Resources.Flag_Canada_30x20
                    Else : assignFlag = My.Resources.Flag_US_30x20
                    End If
                End If
            End If
        End If
    End Function

    Public Function assignCompatText(ByVal pCompat As System.String) As System.String
        Select Case pCompat
            Case "0" : assignCompatText = "Unknown"
            Case "1" : assignCompatText = "Nothing"
            Case "2" : assignCompatText = "Intro"
            Case "3" : assignCompatText = "Menus"
            Case "4" : assignCompatText = "in-Game"
            Case "5" : assignCompatText = "Playable"
            Case "6" : assignCompatText = "Perfect"
            Case "" : assignCompatText = "Missing"
            Case Else : assignCompatText = "Undetected"
        End Select
    End Function

    Public Function assignCompatColor(ByVal pCompat As String, ByVal pBGcolor As Color) As Color
        Select Case pCompat
            Case "0" : assignCompatColor = pBGcolor  'Unknown
            Case "1" : assignCompatColor = Color.FromArgb(255, 255, 192, 192)  'Nothing:    Red
            Case "2" : assignCompatColor = Color.FromArgb(255, 255, 224, 192)  'Intro:      Orange
            Case "3" : assignCompatColor = Color.FromArgb(255, 255, 255, 192)  'Menus:      Yellow
            Case "4" : assignCompatColor = Color.FromArgb(255, 255, 192, 255)  'in-Game:    Purple
            Case "5" : assignCompatColor = Color.FromArgb(255, 192, 255, 192)  'Playable:   Green
            Case "6" : assignCompatColor = Color.FromArgb(255, 192, 192, 255)  'Perfect:    Blue
            Case Else : assignCompatColor = pBGcolor
        End Select
    End Function

    Public Sub AppendToLog(ByVal pClass As String, ByVal pMethod As String, ByVal pText As String, Optional pDuration As Double = -1)
        Const AppLog_MaxLenght As Integer = 31
        If AppLog.Count >= AppLog_MaxLenght Then
            AppLog.RemoveAt(0)
        End If
        AppLog.Add(New sLog With {.Time = Now, .OrClass = pClass, .OrMethod = pMethod, .Description = pText, .Duration = pDuration})

        Console.WriteLine(String.Format("[{0:HH.mm.ss}] {1}.{2} {3}", Now, pClass, pMethod, pText))
    End Sub

End Module
