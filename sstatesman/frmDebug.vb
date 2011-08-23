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
Public Class frmDebug
    Dim MouseBck As System.Drawing.Point

    Private Sub CmdGameDbUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameDbUtil.Click
        frmGameDb.Show(Me)
    End Sub

    Private Sub CmdFindFileUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileListUtil.Click
        frmFileList.Show(Me)
    End Sub

    Private Sub FrmDebug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlGameDb.GameDb_Len = -1
    End Sub

    Private Sub cmdWindowClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()
    End Sub

    Private Sub cmdWindowMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmdWindowMaximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonRestore
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonMaximize
        End If
    End Sub

    Private Sub panelWindowTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelWindowTitle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MouseBck = e.Location
        End If
    End Sub

    Private Sub panelWindowTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelWindowTitle.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Top = Me.Top + e.Location.Y - MouseBck.Y
            Me.Left = Me.Left + e.Location.X - MouseBck.X
        End If
    End Sub

    Private Sub cmdSStateListUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateListUtil.Click
        frmSStateList.Show(Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If mdlMain.PCSX2_BinPath = "" Then
            mdlMain.PCSX2_BinPath = InputBox("PCSX2 BinPath:")
        End If
        If mdlMain.PCSX2_UserPath = "" Then
            mdlMain.PCSX2_UserPath = InputBox("PCSX2 UserPath:")
        End If

        GameDb_Len = mdlGameDb.GameDb_Load3(mdlMain.PCSX2_BinPath & mdlMain.FileGameDb, GameDb, GameDb_Pos)
        'FileList_Len = mdlFileList.FileList_Load(mdlMain.PCSX2_UserPath & mdlMain.PCSX2_SStateDir, FileList, FileList_Pos)
        'mdlSStateList.SStateList_Len = mdlSStateList.SStateList_Load(mdlFileList.FileList, mdlFileList.FileList_Pos, mdlFileList.FileList_Len, _
        '                                               mdlSStateList.SStateList, mdlSStateList.SStateList_Pos)
        mdlSStateList.SStateList_Len = mdlSStateList.SStateList_Load2(mdlMain.PCSX2_UserPath & mdlMain.PCSX2_SStateDir, _
                                                       mdlSStateList.SStateList, mdlSStateList.SStateList_Pos)

        mdlSStateList.SStateGameIndex_Len = mdlSStateList.SStateGameIndex_Load(mdlSStateList.SStateList, mdlSStateList.SStateList_Pos, mdlSStateList.SStateList_Len, _
                                                   GameDb, GameDb_Pos, GameDb_Len, _
                                                   mdlSStateList.SStateGameIndex, mdlSStateList.SStateGameIndex_Pos)
        Me.lvwGameList.Items.Clear()
        Dim iTmp As System.Int32
        For mdlSStateList.SStateGameIndex_Pos = 0 To mdlSStateList.SStateGameIndex_Len
            iTmp = SStateGameIndex_Pos
            Me.lvwGameList.Items.Add(SStateGameIndex(SStateGameIndex_Pos).GameInfo.Name)
            With Me.lvwGameList.Items(iTmp).SubItems
                .Add(SStateGameIndex(SStateGameIndex_Pos).GameInfo.Serial)
                .Add(SStateGameIndex(SStateGameIndex_Pos).GameInfo.Region)
                .Add(Format(SStateGameIndex(SStateGameIndex_Pos).SStatesTotalSize / 1024 / 1024, "0.00 Mib") & " (+" & Format(SStateGameIndex(SStateGameIndex_Pos).SStatesBackupTotalSize / 1024 / 1024, "0.00 Mib") & ")")
            End With
        Next SStateGameIndex_Pos
        SStateGameIndex_Pos = 1

    End Sub

    Private Sub lvwGameList_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwGameList.ItemActivate
        Dim iTmp As System.Int32
        Me.lvwSStatesList.Items.Clear()
        mdlSStateList.SStateGameIndex_Pos = Me.lvwGameList.SelectedItems(0).Index
        mdlSStateList.SStateListExtract_Len = mdlSStateList.SStateList_ExtractBySerial(Trim(mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial), SStateList, SStateList_Pos, SStateList_Len, SStateListExtract, SStateListExtract_Pos)
        For mdlSStateList.SStateListExtract_Pos = 0 To mdlSStateList.SStateListExtract_Len
            iTmp = SStateListExtract_Pos
            Me.lvwSStatesList.Items.Add(mdlSStateList.SStateListExtract(SStateListExtract_Pos).FileInfo.Name, iTmp)
            With Me.lvwSStatesList.Items(iTmp).SubItems
                .Add(SStateListExtract(SStateListExtract_Pos).SStateSlot)
                .Add(SStateListExtract(SStateListExtract_Pos).SStateBackup)
                .Add(Format((SStateListExtract(SStateListExtract_Pos).FileInfo.Length / 1024 / 1024), "0.00 MiB"))
                .Add(SStateListExtract(SStateListExtract_Pos).FileInfo.CreationTime)
                .Add(Trim(SStateListExtract(SStateListExtract_Pos).SStateSerial))
            End With

            'List2.AddItem aSStateList_Extract(laSStateList_ExtractPos).SStateSlot & vbTab & aSStateList_Extract(laSStateList_ExtractPos).SStateBackup & vbTab & Trim(aSStateList_Extract(laSStateList_ExtractPos).FileName) & vbTab & Format((aSStateList_Extract(laSStateList_ExtractPos).FileSize / 1024 / 1024), "0.00 MiB") & vbTab & aSStateList_Extract(laSStateList_ExtractPos).FileDateCreation
        Next mdlSStateList.SStateListExtract_Pos
        mdlSStateList.SStateListExtract_Pos = 0
    End Sub
End Class