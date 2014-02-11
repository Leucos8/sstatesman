'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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
Module mdlPCSX2Settings
    ''' <summary>Detect all the PCSX2 paths: where binaries are located, inis, savestates and screenshots directory.</summary>
    ''' <returns>Boolean value. True: all path are detected, false: at least one path has not been detected.</returns>
    Friend Function PCSX2_PathAll_Detect() As Boolean
        If PCSX2_PathBin_Detect(My.Settings.PCSX2_PathBin) And _
            PCSX2_PathInis_Detect(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_PathInis) And _
            PCSX2_PathSettings_Detect(My.Settings.PCSX2_PathInis, My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps) Then
            Return True
        Else : Return False
        End If
    End Function

    ''' <summary>Checks if all the parameters are valid paths.</summary>
    ''' <param name="pPathBin">PCSX2 executable path.</param>
    ''' <param name="pPathInis">PCSX2 inis directory path.</param>
    ''' <param name="pPathSStates">PCSX2 savestates directory path.</param>
    ''' <param name="pPathSnaps">PCSX2 screenshots directory path.</param>
    ''' <returns>Boolean value. True: all paths are valid, false: at least one path is not valid.</returns>
    Friend Function PCSX2_PathAll_Check(pPathBin As String, pPathInis As String, pPathSStates As String, pPathSnaps As String) As Boolean
        Try
            If Directory.Exists(pPathBin) And Directory.Exists(pPathInis) And _
                Directory.Exists(pPathSStates) And Directory.Exists(pPathSnaps) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SSMAppLog.Append(eType.LogError, eSrc.Settings, eSrcMethod.SettingsLoaded, "Error while checking PCSX2 folder settings. " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>Detects PCSX2 executable path.</summary>
    ''' <param name="pReturnPath">Out parameter that returns the detected path. Returns empty string if detection fails.</param>
    ''' <returns>Boolean value. True: path is detected and valid, false: path is not valid.</returns>
    Friend Function PCSX2_PathBin_Detect(ByRef pReturnPath As String) As Boolean
        Try
            Using PCSX2_Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                'OpenSubKey returns Nothing if the key doesn't exist
                If PCSX2_Registry IsNot Nothing Then
                    'I assume that the installation found in the registry is the good one
                    '                                     Install_Dir
                    pReturnPath = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathBinReg, "").ToString
                    SSMAppLog.Append(eType.LogInformation, eSrc.Settings, eSrcMethod.Detect, "PCSX2 bin path detected: " & pReturnPath)
                    Return Directory.Exists(pReturnPath)
                Else
                    pReturnPath = ""
                    SSMAppLog.Append(eType.LogWarning, eSrc.Settings, eSrcMethod.Detect, "PCSX2 registry key not found.")
                    Return False
                End If
            End Using
        Catch ex As Exception
            pReturnPath = ""
            SSMAppLog.Append(eType.LogError, eSrc.Settings, eSrcMethod.Detect, "PCSX2 bin path detection failed. " & ex.Message)
            Return False
        End Try

    End Function

    ''' <summary>Detects PCSX2 inis path.</summary>
    ''' <param name="pPCSX2_PathBin">PCSX2 executable path, required for checking if PCSX2 is in portable mode.</param>
    ''' <param name="pReturnPath">Out parameter that returns the detected path. Returns empty string if detection fails.</param>
    ''' <returns>Boolean value. True: path is detected and valid, false: path is not valid.</returns>
    Friend Function PCSX2_PathInis_Detect(pPCSX2_PathBin As String, ByRef pReturnPath As String) As Boolean
        Try
            'Check if it is the case of a user who installed PCSX2 in usermode and then switched to portable mode
            If File.Exists(Path.Combine(pPCSX2_PathBin, "portable.ini")) Then
                'If so the inis are in the "inis" folder of the PCSX2 binaries directory
                pReturnPath = Path.Combine(pPCSX2_PathBin, "inis")
                SSMAppLog.Append(eType.LogInformation, eSrc.Settings, eSrcMethod.Detect, "PCSX2 inis path detected in portable mode: " & pReturnPath)
                Return Directory.Exists(pReturnPath)
            Else
                'Else the registry value is checked
                Using PCSX2_Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                    'OpenSubKey returns Nothing if the key doesn't exist
                    If PCSX2_Registry IsNot Nothing Then
                        'I assume that the installation found in the registry is the good one
                        '                                     SettingsFolder
                        pReturnPath = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathInisReg, "").ToString
                        SSMAppLog.Append(eType.LogInformation, eSrc.Settings, eSrcMethod.Detect, "PCSX2 inis path detected in user mode: " & pReturnPath)
                        Return Directory.Exists(pReturnPath)
                    Else
                        pReturnPath = ""
                        SSMAppLog.Append(eType.LogWarning, eSrc.Settings, eSrcMethod.Detect, "PCSX2 registry key not found.")
                        Return False
                    End If
                End Using
            End If
        Catch ex As Exception
            pReturnPath = ""
            SSMAppLog.Append(eType.LogError, eSrc.Settings, eSrcMethod.Detect, "PCSX2 bin path detection failed. " & ex.Message)
            Return False
        End Try

    End Function

    ''' <summary>Detects PCSX2 savestates and screenshots paths.</summary>
    ''' <param name="pPCSX2_PathInis">PCSX2 inis path, where PCSX2_ui.ini will be looked up.</param>
    ''' <param name="pReturnPathSStates">Out parameter that returns the detected path. Returns empty string if detection fails.</param>
    ''' <param name="pReturnPathSnaps">Out parameter that returns the detected path. Returns empty string if detection fails.</param>
    ''' <returns>Boolean value. True: both paths are detected and valid, false: one path is not valid.</returns>
    Friend Function PCSX2_PathSettings_Detect(ByVal pPCSX2_PathInis As String, ByRef pReturnPathSStates As String, ByRef pReturnPathSnaps As String) As Boolean
        pReturnPathSStates = ""
        pReturnPathSnaps = ""
        Try

            'If PCSX2_UI.ini is present in the set inis directory
            If File.Exists(Path.Combine(pPCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename)) Then
                'PCSX2_UI.ini is read and checked for the savestates folder
                Using PCSX2UI_reader As New StreamReader(Path.Combine(pPCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename))
                    While Not PCSX2UI_reader.EndOfStream
                        Dim tmpLine As String = PCSX2UI_reader.ReadLine.Trim.ToLower

                        If tmpLine.StartsWith("savestates=") Then
                            Dim tmpStrings As String() = tmpLine.Split({"="c}, 2, StringSplitOptions.RemoveEmptyEntries)
                            pReturnPathSStates = tmpStrings(1).Replace("\\", "\")
                            SSMAppLog.Append(eType.LogInformation, eSrc.Settings, eSrcMethod.Detect, "PCSX2 savestates path detected: " & pReturnPathSStates)
                        ElseIf tmpLine.StartsWith("snapshots=") Then
                            Dim tmpStrings As String() = tmpLine.Split({"="c}, 2, StringSplitOptions.RemoveEmptyEntries)
                            pReturnPathSnaps = tmpStrings(1).Replace("\\", "\")
                            SSMAppLog.Append(eType.LogInformation, eSrc.Settings, eSrcMethod.Detect, "PCSX2 sceenshots path detected: " & pReturnPathSnaps)
                        End If

                    End While
                    PCSX2UI_reader.Close()
                End Using
                Return Directory.Exists(pReturnPathSStates) And Directory.Exists(pReturnPathSnaps)
            Else
                pReturnPathSStates = ""
                pReturnPathSnaps = ""
                SSMAppLog.Append(eType.LogWarning, eSrc.Settings, eSrcMethod.Detect, "PCSX2_ui.ini not found.")
                Return False
            End If
        Catch ex As Exception
            pReturnPathSStates = ""
            pReturnPathSnaps = ""
            SSMAppLog.Append(eType.LogError, eSrc.Settings, eSrcMethod.Detect, "PCSX2 savestate or screenshots path detection failed. " & ex.Message)
            Return False
        End Try

    End Function
End Module
