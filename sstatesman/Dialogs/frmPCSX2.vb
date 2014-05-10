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
Public NotInheritable Class frmPCSX2
    Dim PCSX2BinPathValid As Boolean = False
    Friend IsoFilename As String = ""
    Dim IsoPathValid As Boolean = False
    Dim IsoFilenameValid As Boolean = False

    Dim PCSX2exe_files As List(Of FileInfo)

    Private Sub PCSX2Bin_ListCreate(pPCSX2_PathBin As String, Optional pLastSelectedExe As String = "")
        Me.lbPCSX2Bin.BeginUpdate()

        Try
            If Directory.Exists(pPCSX2_PathBin) Then
                Dim tmpDI As New DirectoryInfo(My.Settings.PCSX2_PathBin)
                Dim tmpFI As IEnumerable(Of FileInfo) = tmpDI.EnumerateFiles("PCSX2*.exe")
                If tmpFI.Count > 0 Then
                    For i As Integer = 0 To tmpFI.Count - 1
                        lbPCSX2Bin.Items.Add(tmpFI(i).Name)
                        If tmpFI(i).Name = pLastSelectedExe Then
                            Me.lbPCSX2Bin.SetSelected(i, True)
                        End If
                    Next
                    If Me.lbPCSX2Bin.Items.Count > 1 Then
                        If Not (Me.lbPCSX2Bin.SelectedItems.Count > 0) Then
                            Me.lbPCSX2Bin.SetSelected(0, True)
                        End If
                        Me.cmdOk.Enabled = True
                    End If
                Else
                    Me.UI_Status("No PCSX2 executable found")
                    Me.cmdOk.Enabled = False
                End If
            Else
                Me.UI_Update()
            End If
        Catch ex As Exception
            Me.UI_Status(ex.Message)
            Me.UI_Update()
            Me.cmdOk.Enabled = False
        End Try

        Me.lbPCSX2Bin.EndUpdate()
    End Sub

    Private Sub PCSX2Bin_TestLaunch(pPCSX2_PathBin As String, pPCSX2_ExeName As String, _
                                    pISO_Path As String, pISO_Filename As String, _
                                    Optional ByRef pProcess As Process = Nothing)
        If Me.lbPCSX2Bin.Items.Count = 1 Then
            Me.lbPCSX2Bin.SetSelected(0, True)
            Me.PCSX2Bin_Launch(pPCSX2_PathBin, Me.lbPCSX2Bin.Text, pISO_Path, pISO_Filename, pProcess)
            If pProcess IsNot Nothing Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub PCSX2Bin_Launch(pPCSX2_PathBin As String, pPCSX2_ExeName As String, _
                                pIso_Path As String, pIso_Filename As String, _
                                Optional ByRef pProcess As Process = Nothing)
        Dim tmpPath As String = Path.Combine(pPCSX2_PathBin, pPCSX2_ExeName)
        Dim tmpArgs As String = """" & Path.Combine(pIso_Path, pIso_Filename) & """"
        If mdlMain.SafeExistFile(tmpPath) Then
            If IsoFilename = "" Then
                pProcess = Process.Start(tmpPath)
            Else
                pProcess = Process.Start(tmpPath, tmpArgs)
            End If
            My.Settings.SStatesMan_LastPCSX2Executable = pPCSX2_ExeName
        Else
            Me.UI_Status("Unable to find " & tmpPath & ".")
            Me.cmdOk.Enabled = False
        End If
    End Sub

    Private Sub UI_Update()
        'PCSX2 binaries path.
        Me.txtPCSX2PathBin.Text = My.Settings.PCSX2_PathBin

        Me.PCSX2BinPathValid = mdlMain.SafeExistFolder(My.Settings.PCSX2_PathBin)

        'Status for PCSX2 binaries path.
        If Me.PCSX2BinPathValid Then
            Me.txtPCSX2PathBin.BackColor = currentTheme.BgColor
        Else
            Me.txtPCSX2PathBin.BackColor = Color.FromArgb(255, 192, 192)
        End If

        'If user has pressed Play.
        If Not (Me.IsoFilename = "") Then

            'Iso path and filename.
            Me.txtSStatesManPathIso.Text = Path.Combine(My.Settings.SStatesMan_PathIso, Me.IsoFilename)
            Me.txtSStatesManPathIso.Visible = True
            Me.lblIsoPath.Visible = True

            'Check iso path.
            Me.IsoPathValid = mdlMain.SafeExistFolder(My.Settings.SStatesMan_PathIso)
            If Me.IsoPathValid Then
                'Check iso filename if path is valid.
                Me.IsoFilenameValid = mdlMain.SafeExistFile(Path.Combine(My.Settings.SStatesMan_PathIso, Me.IsoFilename))
                'Status for Iso filename check.
                If Me.IsoFilenameValid Then
                    Me.txtSStatesManPathIso.BackColor = currentTheme.BgColor
                Else
                    Me.txtSStatesManPathIso.BackColor = Color.FromArgb(255, 192, 192)
                End If
            Else
                'Status for Iso path check.
                Me.txtSStatesManPathIso.BackColor = Color.FromArgb(255, 192, 192)
                Me.IsoFilenameValid = False
            End If
        Else
            'User wants to start PCSX2 only.
            Me.txtSStatesManPathIso.Visible = False
            Me.lblIsoPath.Visible = False
            Me.IsoPathValid = True
            Me.IsoFilenameValid = True
        End If
        'If everything is fine OK button is enabled.
        Me.cmdOk.Enabled = Me.PCSX2BinPathValid And Me.IsoPathValid And Me.IsoFilenameValid
    End Sub

    Private Sub UI_Status(pMessage As String)
        Me.lbPCSX2Bin.Visible = False
        Me.tlpFormContent.Controls.Add(lblStatus, 0, 1)
        Me.lblStatus.Dock = DockStyle.Fill
        Me.lblStatus.Text = pMessage
        Me.lblStatus.Visible = True
    End Sub

    Private Sub frmPCSX2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.flpWindowBottom.Controls.AddRange({Me.cmdCancel, Me.cmdOk})
        Me.tlpFormContent.Dock = DockStyle.Fill
        Me.lblTroubleshoot.MaximumSize = Me.tlpFormContent.Size
        Me.lblTroubleshoot.AutoSize = True

        Me.lbPCSX2Bin.BeginUpdate()
        Me.lbPCSX2Bin.Items.Clear()
        Me.lbPCSX2Bin.EndUpdate()

        Me.UI_Update()
        'PCSX2 is already running.
        If mdlMain.PCSX2exe_process Is Nothing OrElse mdlMain.PCSX2exe_process.HasExited Then
            If Me.cmdOk.Enabled Then
                Me.PCSX2Bin_ListCreate(My.Settings.PCSX2_PathBin, My.Settings.SStatesMan_LastPCSX2Executable)
                Me.PCSX2Bin_TestLaunch(My.Settings.PCSX2_PathBin, My.Settings.SStatesMan_LastPCSX2Executable, My.Settings.SStatesMan_PathIso, Me.IsoFilename, PCSX2exe_process)
            Else
                Me.UI_Status("Some settings are not valid. Please close this window.")
            End If
        Else
            Me.UI_Status("An instance of PCSX2 is already running.")
            Me.cmdOk.Enabled = False
        End If
    End Sub

    Private Sub frmPCSX2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not (Me.PCSX2BinPathValid) Then
            frmSettings.currentTab = 1
            frmSettings.ShowDialog(frmMain)
        ElseIf Not (Me.IsoPathValid) Then
            frmSettings.currentTab = 0
            frmSettings.ShowDialog(frmMain)
        ElseIf Not (Me.IsoFilenameValid) Then
            frmMain.GameList_Refresh()
        End If
        Me.lblStatus.Visible = False
        Me.lbPCSX2Bin.Visible = True
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Me.PCSX2Bin_Launch(My.Settings.PCSX2_PathBin, Me.lbPCSX2Bin.Text, My.Settings.SStatesMan_PathIso, Me.IsoFilename, mdlMain.PCSX2exe_process)
        If PCSX2exe_process IsNot Nothing Then
            Me.Close()
        End If
    End Sub
End Class