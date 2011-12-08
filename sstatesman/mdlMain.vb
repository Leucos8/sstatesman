'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011 - Leucos
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
Option Explicit On
Module mdlMain
    Public CS_DROPSHADOW As Int32 = &H20000
    Public colorswitch As System.Boolean = True

    Public Sub FirstRun()
        'Show the warning message
        'If My.Settings.SStateMan_Channel.ToLower = "alpha" Then
        '    System.Windows.Forms.MessageBox.Show(System.String.Format("{0} version {1} {2}" & vbCrLf & _
        '                                         "This is an {3} version, for tests only. Do not redistribute." & vbCrLf & _
        '                                         "The warnings have been issued, now enjoy the application :)", _
        '                                         My.Application.Info.ProductName.ToString, _
        '                                         My.Application.Info.Version.ToString, _
        '                                         My.Settings.SStateMan_Channel, _
        '                                         My.Settings.SStateMan_Channel.ToUpper), _
        '                                         My.Application.Info.ProductName, _
        '                                         MessageBoxButtons.OK, _
        '                                         MessageBoxIcon.Information)
        'End If
        My.Settings.Reset()
        PCSX2_PathAll_Detect()

        My.Settings.SStateMan_FirstRun2 = False
        My.Settings.Save()
    End Sub

    Public Sub PCSX2_PathAll_Detect()

        My.Settings.PCSX2_PathBinSet = PCSX2_PathBin_Detect(My.Settings.PCSX2_PathBin)
        My.Settings.PCSX2_PathInisSet = PCSX2_PathInis_Detect(My.Settings.PCSX2_PathInis)
        My.Settings.PCSX2_PathSStatesSet = PCSX2_PathSStates_Detect(My.Settings.PCSX2_PathSState)

    End Sub

    Public Function PCSX2_PathBin_Detect(ByRef pResult As System.String) As System.Boolean
        pResult = "Not detected"
        PCSX2_PathBin_Detect = False

        Try
            Using PCSX2_Registry As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
                'OpenSubKey returns Nothing if the key doesn't exist
                If PCSX2_Registry IsNot Nothing Then
                    'I assume that the installation found in the registry is the good one
                    '                                                       Install_Dir
                    pResult = PCSX2_Registry.GetValue(My.Settings.PCSX2_PathBinReg, "Not detected").ToString
                End If
            End Using
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Something went wrong while detecting PCSX2 settings, make sure you have the right permissions in the registry or in the directories/files." _
                                                 & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If My.Computer.FileSystem.DirectoryExists(pResult) Then
            PCSX2_PathBin_Detect = True
        Else
            pResult = "Not detected"
        End If
    End Function

    Public Function PCSX2_PathInis_Detect(ByRef pResult As System.String) As System.Boolean
        pResult = "Not detected"
        PCSX2_PathInis_Detect = False
        Try
            If My.Settings.PCSX2_PathBinSet And My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathBin) Then
                'Check if it is the case of a user who installed PCSX2 in usermode and then switched to portable mode
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, "portable.ini")) Then
                    'If so the inis are in the "inis" folder of the PCSX2 binaries directory
                    pResult = My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, "inis")
                Else
                    'Else the registry value is checked                                 SettingsFolder
                    Using PCSX2_Registry As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(My.Settings.PCSX2_PathRegKey)
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
            System.Windows.Forms.MessageBox.Show("Something went wrong while detecting PCSX2 settings, make sure you have the right permissions in the registry or in the directories/files." _
                                                 & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If My.Computer.FileSystem.DirectoryExists(pResult) Then
            PCSX2_PathInis_Detect = True
        Else
            pResult = "Not detected"
        End If
    End Function

    Public Function PCSX2_PathSStates_Detect(ByRef pResult As System.String) As System.Boolean
        pResult = "Not detected"
        PCSX2_PathSStates_Detect = False

        If My.Settings.PCSX2_PathInisSet And My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathInis) Then
            'If PCSX2_UI.ini is present in the set inis directory
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename)) Then
                'PCSX2_UI.ini is read and checked for the savestates folder
                Using PCSX2UI_reader = My.Computer.FileSystem.OpenTextFileReader(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathInis, My.Settings.PCSX2_PCSX2_uiFilename))
                    While Not PCSX2UI_reader.EndOfStream
                        Dim sTmp1 As System.String = PCSX2UI_reader.ReadLine.Trim

                        If sTmp1 = "UseDefaultSavestates=enabled" Then
                            pResult = My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathInis.Remove(My.Settings.PCSX2_PathInis.Length - 5), My.Settings.PCSX2_SStateFolder)
                            Exit While
                        ElseIf sTmp1.StartsWith(My.Settings.PCSX2_SStateFolder) Then
                            Dim sTmp2 As System.String() = sTmp1.Split("=", 2, StringSplitOptions.RemoveEmptyEntries)
                            If sTmp2.GetLength(0) >= 2 Then
                                pResult = sTmp2(1).Replace("\\", "\")
                            End If
                        End If

                    End While
                    PCSX2UI_reader.Close()
                End Using
            End If
        End If

        If My.Computer.FileSystem.DirectoryExists(pResult) Then
            PCSX2_PathSStates_Detect = True
        Else
            pResult = "Not detected"
        End If
    End Function

    Public Function PCSX2_PathAll_Check() As System.Boolean
        If My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathBin) Then
            My.Settings.PCSX2_PathBinSet = True
        Else
            My.Settings.PCSX2_PathBin = "Not detected"
            My.Settings.PCSX2_PathBinSet = False
        End If

        If My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathInis) Then
            My.Settings.PCSX2_PathInisSet = True
        Else
            My.Settings.PCSX2_PathInis = "Not detected"
            My.Settings.PCSX2_PathInisSet = False
        End If

        If My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathSState) Then
            My.Settings.PCSX2_PathSStatesSet = True
        Else
            My.Settings.PCSX2_PathSState = "Not detected"
            My.Settings.PCSX2_PathSStatesSet = False
        End If

        If Not (My.Settings.PCSX2_PathBinSet) Or _
           Not (My.Settings.PCSX2_PathInisSet) Or _
           Not (My.Settings.PCSX2_PathSStatesSet) Then
            PCSX2_PathAll_Check = True
        Else
            PCSX2_PathAll_Check = False
        End If
    End Function

End Module
