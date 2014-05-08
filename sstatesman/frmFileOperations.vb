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
Partial Public NotInheritable Class frmFileOperations
    Friend FileListMode As FileOperations = FileOperations.Reorder

    Dim SourcePath As String = String.Empty
    Dim DestPath As String = String.Empty
    Dim SourceFileNames As New List(Of String)
    Dim DestFileNames As New List(Of String)
    Dim OperationResults As List(Of FileStatus)
    Dim OperationResultMessages As List(Of String)
    Dim OperationDone As Boolean = False

    Enum FileOperations
        Delete          'The files are deleted
        Reorder         'The savestates are renamed depending on their order
        Store           'The savestates are stored to a different directory
        Restore         'The savestates are restored in their original directory
        Assign          'The screenshots are assigned (renamed) to a game
    End Enum

    Enum FileListColumns
        Number = 0
        OldName = 1
        NewName = 2
        Status = 3
    End Enum

    Private Sub frmFileOperations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Form load start.")

        '==================
        'Window preparation
        '==================
        If Not (Me.IsShown) Then
            Me.flpWindowBottom.Controls.AddRange({Me.cmdCancel, Me.cmdReorder})
            Me.pnlFormContent.Dock = DockStyle.Fill

            'Savestates, backup, and screenshot icons
            Me.lvwFileList.SmallImageList = mdlTheme.imlLvwItemIcons
        End If
        'Checked state icons
        Me.lvwFileList.StateImageList = New ImageList With {.ImageSize = mdlTheme.imlLvwCheckboxes.ImageSize}        'Cannot use imlLvwCheckboxes directly because of a bug that makes checkboxes disappear.
        Me.lvwFileList.StateImageList.Images.AddRange({mdlTheme.imlLvwCheckboxes.Images(0), mdlTheme.imlLvwCheckboxes.Images(1)})

        Me.cmdMoveFirst = Me.cmdCommand1
        Me.cmdMoveUp = Me.cmdCommand2
        Me.cmdMoveDown = Me.cmdCommand3
        Me.cmdMoveLast = Me.cmdCommand4

        Me.cmdFileCheckAll = Me.cmdCommand2
        Me.cmdFileCheckNone = Me.cmdCommand3
        Me.cmdFileCheckInvert = Me.cmdCommand4
        Me.cmdFileCheckBackup = Me.cmdCommand1

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "1/2 Layout & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================
        If My.Settings.SStatesMan_SStateReorderBackup Then
            Me.MoveStep = 2
        Else
            Me.MoveStep = 1
        End If

        Me.UI_SwitchOperationMode(Me.FileListMode)



        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "2/2 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Load complete.", sw.ElapsedTicks)
    End Sub

    Private Sub frmFileOperations_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.OperationDone = False

        RemoveHandler cmdMoveFirst.Click, AddressOf cmdMoveFirst_Click
        RemoveHandler cmdMoveUp.Click, AddressOf cmdMoveUp_Click
        RemoveHandler cmdMoveDown.Click, AddressOf cmdMoveDown_Click
        RemoveHandler cmdMoveLast.Click, AddressOf cmdMoveLast_Click

        RemoveHandler cmdFileCheckAll.Click, AddressOf cmdStoreCheckAll_Click
        RemoveHandler cmdFileCheckNone.Click, AddressOf cmdStoreCheckNone_Click
        RemoveHandler cmdFileCheckInvert.Click, AddressOf cmdStoreCheckInvert_Click

        RemoveHandler cmdReorder.Click, AddressOf cmdReorder_Click
        RemoveHandler cmdReorder.Click, AddressOf cmdStore_Click

        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked

        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked

        Me.lvwFileList.BeginUpdate()

        Me.lvwFileList.Items.Clear()
        Me.lvwFileList.Groups.Clear()

        frmMain.GameList_Refresh()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub UI_SwitchOperationMode(pOperationMode As FileOperations)
        'Me.UI_SwitchFileMode(frmMain.CurrentListMode)

        Me.cmdReorder.Text = pOperationMode.ToString.ToUpper
        Me.lblSizeBackup.Visible = False

        Select Case pOperationMode
            Case FileOperations.Reorder
                Me.FormDescription = "use the move buttons to reorder the list and click ""reorder"" to confirm."
                Me.lblSelected.Text = "selection"
                Me.lblSize.Text = "active"
                Me.lblSize.Visible = True

                Me.cmdMoveUp.Text = "UP"
                Me.cmdMoveUp.Image = My.Resources.Icon_OrderUp
                Me.cmdMoveUp.Visible = True
                AddHandler cmdMoveUp.Click, AddressOf cmdMoveUp_Click

                Me.cmdMoveDown.Text = "DOWN"
                Me.cmdMoveDown.Image = My.Resources.Icon_OrderDown
                Me.cmdMoveDown.Visible = True
                AddHandler cmdMoveDown.Click, AddressOf cmdMoveDown_Click

                Me.cmdMoveFirst.Text = "FIRST"
                Me.cmdMoveFirst.Image = My.Resources.Icon_OrderFirst
                Me.cmdMoveFirst.Visible = True
                AddHandler cmdMoveFirst.Click, AddressOf cmdMoveFirst_Click

                Me.cmdMoveLast.Text = "LAST"
                Me.cmdMoveLast.Image = My.Resources.Icon_OrderLast
                Me.cmdMoveFirst.Visible = True
                AddHandler cmdMoveLast.Click, AddressOf cmdMoveLast_Click

                Me.ckbSStatesManReorderBackup.Visible = True
                Me.cmdSortReset.Visible = True

                AddHandler cmdReorder.Click, AddressOf cmdReorder_Click

                Me.SourcePath = SSMGameList.Folders(frmMain.CurrentListMode)
                Me.DestPath = Me.SourcePath

                Me.ReorderList_AddFiles()
                Me.ReorderList_Preview()
                Me.ReorderList_UpdateUI()
            Case FileOperations.Store, FileOperations.Restore
                Me.FormDescription = String.Format("check the savestates you want to {0} and press ""{0}"" to confirm.", Me.cmdReorder.Text.ToLower)
                Me.lblSelected.Text = "selection"
                Me.lblSize.Visible = False
                Me.lblSizeBackup.Visible = False
                Me.lblAction.Text = Me.cmdReorder.Text.ToLower & " checked"

                Me.cmdFileCheckAll.Text = "ALL"
                Me.cmdFileCheckAll.Image = My.Resources.Icon_CheckAll
                AddHandler cmdFileCheckAll.Click, AddressOf cmdStoreCheckAll_Click

                Me.cmdFileCheckNone.Text = "NONE"
                Me.cmdFileCheckNone.Image = My.Resources.Icon_CheckNone
                AddHandler cmdFileCheckNone.Click, AddressOf cmdStoreCheckNone_Click

                Me.cmdFileCheckInvert.Text = "INVERT"
                Me.cmdFileCheckInvert.Image = My.Resources.Icon_CheckInvert
                AddHandler cmdFileCheckInvert.Click, AddressOf cmdStoreCheckInvert_Click

                Me.cmdFileCheckBackup.Visible = False

                Me.ckbSStatesManReorderBackup.Visible = False
                Me.cmdSortReset.Visible = False

                AddHandler cmdReorder.Click, AddressOf cmdStore_Click
                Select Case Me.FileListMode
                    Case FileOperations.Store
                        Me.SourcePath = SSMGameList.Folders(ListMode.Savestates)
                        Me.DestPath = SSMGameList.Folders(ListMode.Stored)
                    Case FileOperations.Restore
                        Me.SourcePath = SSMGameList.Folders(ListMode.Stored)
                        Me.DestPath = SSMGameList.Folders(ListMode.Savestates)
                End Select

                Me.StoreList_AddFiles()
                Me.StoreList_Preview()
                Me.StoreList_UpdateUI()
            Case FileOperations.Assign
                Me.SourcePath = SSMGameList.Folders(ListMode.Snapshots)
                Me.DestPath = Me.SourcePath

                'Me.FileList_AddSlotAndFiles()
                'Me.UI_AssignPreview()
        End Select

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.ListMode, String.Format("Switched to {0}.", pOperationMode.ToString))
    End Sub

    Private Sub UI_SwitchFileMode(pListMode As ListMode)

        Select Case pListMode
            Case ListMode.Savestates

            Case ListMode.Stored

            Case ListMode.Snapshots

        End Select

        'Me.FileList_AddColumns(pListMode)

        'SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.ListMode, String.Format("Switched to {0}.", pListMode.ToString))
        'Me.DelFileList_Refresh()
    End Sub

    Private Sub frmMain_ThemeApplied(sender As Object, e As EventArgs) Handles MyBase.ThemeApplied
        Me.tlpFileListStatus.BackColor = Me.BorderColorActive
    End Sub

End Class