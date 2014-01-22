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
Public NotInheritable Class frmChooseVersion
    Dim PCSX2exe_files As List(Of FileInfo)

    Private Sub PCSX2EXE_ListCreate(ByVal pPCSX2_PathBin As String)
        lbPCSX2exe.BeginUpdate()
        lbPCSX2exe.Items.Clear()
        If Directory.Exists(pPCSX2_PathBin) Then
            Dim tmpDirectory As New DirectoryInfo(My.Settings.PCSX2_PathBin)
            Dim PCSX2exe_files As FileInfo() = tmpDirectory.GetFiles("PCSX2*.exe")
            If PCSX2exe_files.Length > 0 Then
                For i = 0 To PCSX2exe_files.Length - 1
                    lbPCSX2exe.Items.Add(PCSX2exe_files(i).Name)
                    If PCSX2exe_files(i).Name = My.Settings.SStatesMan_LastPCSX2Executable Then
                        Me.lbPCSX2exe.SetSelected(i, True)
                    End If
                Next
                If lbPCSX2exe.SelectedItems.Count = 0 Then
                    Me.lbPCSX2exe.SetSelected(0, True)
                End If
                If PCSX2exe_files.Count = 1 Then
                    PCSX2EXE_start(pPCSX2_PathBin, Me.lbPCSX2exe.Text)
                    Me.Close()
                Else
                    Me.cmdOk.Enabled = True
                End If
            Else
                lbPCSX2exe.Items.Add("No PCSX2 executables found.")
                Me.cmdOk.Enabled = False
            End If
        Else
            lbPCSX2exe.Items.Add("The specified path does not exist.")
            Me.cmdOk.Enabled = False
        End If
        lbPCSX2exe.EndUpdate()
    End Sub

    Private Sub PCSX2EXE_start(ByVal pPCSX2_PathBin As String, ByVal pPCSX2_ExeName As String)
        Dim tmpPath As String = Path.Combine(pPCSX2_PathBin, pPCSX2_ExeName)
        If File.Exists(tmpPath) Then
            Diagnostics.Process.Start(tmpPath)
            My.Settings.SStatesMan_LastPCSX2Executable = pPCSX2_ExeName
        Else
            MessageBox.Show("The specified executable does not exist. Please close this window and try again to refresh the list." & tmpPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmChooseVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.flpWindowBottom.Controls.AddRange({cmdCancel, cmdOk})
        Me.tlpFormContent.Dock = DockStyle.Fill
        Me.lblPath.Text = My.Settings.PCSX2_PathBin

        Me.PCSX2EXE_ListCreate(My.Settings.PCSX2_PathBin)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Me.PCSX2EXE_start(My.Settings.PCSX2_PathBin, Me.lbPCSX2exe.Text)
        Me.Close()
    End Sub
End Class