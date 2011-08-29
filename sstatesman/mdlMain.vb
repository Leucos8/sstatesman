'   SStatesMan - Savestate Manager for PCSX2 0.9.8
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
        If My.Settings.SStateMan_Channel.ToLower = "alpha" Then
            MsgBox(System.String.Format("{0} version {1} {2}" & vbCrLf & _
                                        "This is an {3} version, for tests only. Do not redistribute." & vbCrLf & _
                                        "It *will* crash, hang and other not so funny things could happen." & vbCrLf & _
                                        "The warnings have been issued, now enjoy the application :)", _
                                        My.Application.Info.ProductName.ToString, _
                                        My.Application.Info.Version.ToString, _
                                        My.Settings.SStateMan_Channel, _
                                        My.Settings.SStateMan_Channel.ToUpper), _
                    MsgBoxStyle.Exclamation, My.Application.Info.ProductName)
        End If

        If Not (My.Computer.Registry.GetValue(System.String.Concat(My.Computer.Registry.CurrentUser.Name, My.Settings.PCSX2_PathRegKey), _
                                              My.Settings.PCSX2_PathBinReg, _
                                              Microsoft.Win32.RegistryValueOptions.None) = "") Then

            My.Settings.PCSX2_PathBin = My.Computer.Registry.GetValue(System.String.Concat(My.Computer.Registry.CurrentUser.Name, My.Settings.PCSX2_PathRegKey), _
                                                                      My.Settings.PCSX2_PathBinReg, _
                                                                      Microsoft.Win32.RegistryValueOptions.None)

            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, "portable.ini")) Then
                My.Settings.PCSX2_PathInis = My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, "inis")

            Else
                My.Settings.PCSX2_PathInis = My.Computer.Registry.GetValue(My.Computer.Registry.CurrentUser.Name & My.Settings.PCSX2_PathRegKey, _
                                                                           My.Settings.PCSX2_PathInisReg, _
                                                                           Microsoft.Win32.RegistryValueOptions.None)
            End If
            My.Settings.PCSX2_PathSState = My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathInis.Remove(My.Settings.PCSX2_PathInis.Length - 5), My.Settings.PCSX2_SStateFolder)
            'My.Settings.SStateMan_PathPics = My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathInis.TrimEnd("\inis"), My.Settings.SStateMan_PicsFolder)
        End If

        My.Settings.Save()
        My.Settings.SStateMan_FirstRun2 = False
    End Sub

    Public Sub SettingsCheck()
        If Not (My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathBin)) Or _
           Not (My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathInis)) Or _
           Not (My.Computer.FileSystem.DirectoryExists(My.Settings.PCSX2_PathSState)) Then
            My.Settings.SStateMan_SettingFail = True
        Else
            My.Settings.SStateMan_SettingFail = False
        End If
    End Sub

End Module
