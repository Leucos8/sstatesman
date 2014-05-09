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
    Friend currentOperationMode As FileOperations = FileOperations.Reorder

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
            Me.flpWindowBottom.Controls.AddRange({Me.cmdCancel, Me.cmdOperation})
            Me.pnlFormContent.Dock = DockStyle.Fill

            'Savestates, backup, and screenshot icons
            Me.lvwFileList.SmallImageList = mdlTheme.imlLvwItemIcons
        End If
        'Checked state icons
        Me.lvwFileList.StateImageList = New ImageList With {.ImageSize = mdlTheme.imlLvwCheckboxes.ImageSize}        'Cannot use imlLvwCheckboxes directly because of a bug that makes checkboxes disappear.
        Me.lvwFileList.StateImageList.Images.AddRange({mdlTheme.imlLvwCheckboxes.Images(0), mdlTheme.imlLvwCheckboxes.Images(1)})

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "1/3 Layout & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '---------------
        'Window settings
        '---------------

        'Main window location, size and state
        'Me.Location = My.Settings.frmDel_WindowLocation
        Me.Size = My.Settings.frmDel_WindowSize
        If My.Settings.frmDel_WindowState = FormWindowState.Minimized Then
            My.Settings.frmDel_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmDel_WindowState

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "2/3 Saved window sizes applied.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================
        Me.UI_SwitchOperationMode(Me.currentOperationMode)



        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "3/3 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Load complete.", sw.ElapsedTicks)
    End Sub

    Private Sub frmFileOperations_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.OperationDone = False

        RemoveHandler cmdMoveFirst.Click, AddressOf cmdMoveFirst_Click
        RemoveHandler cmdMoveUp.Click, AddressOf cmdMoveUp_Click
        RemoveHandler cmdMoveDown.Click, AddressOf cmdMoveDown_Click
        RemoveHandler cmdMoveLast.Click, AddressOf cmdMoveLast_Click

        RemoveHandler cmdStoreCheckAll.Click, AddressOf cmdStoreCheckAll_Click
        RemoveHandler cmdStoreCheckNone.Click, AddressOf cmdStoreCheckNone_Click
        RemoveHandler cmdStoreCheckInvert.Click, AddressOf cmdStoreCheckInvert_Click

        RemoveHandler cmdDeleteCheckAll.Click, AddressOf cmdDeleteCheckAll_Click
        RemoveHandler cmdDeleteCheckNone.Click, AddressOf cmdDeleteCheckNone_Click
        RemoveHandler cmdDeleteCheckInvert.Click, AddressOf cmdDeleteCheckInvert_Click
        RemoveHandler cmdDeleteCheckBackup.Click, AddressOf cmdDeleteCheckBackup_Click

        RemoveHandler cmdOperation.Click, AddressOf cmdReorder_Click
        RemoveHandler cmdOperation.Click, AddressOf cmdStore_Click
        RemoveHandler cmdOperation.Click, AddressOf cmdDelete_Click

        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked

        '======================
        'Saving window settings
        '======================

        'State, location, and size
        My.Settings.frmDel_WindowState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            'Location and size saved only when windowstate is normal
            'My.Settings.frmDel_WindowLocation = Me.Location
            My.Settings.frmDel_WindowSize = Me.Size
        End If

        'Column widths
        'My.Settings.frmDel_flvw_columnwidth = New Integer() {Me.chFileName.Width, Me.chSlot.Width, _
        '                                                     Me.chVersion.Width, Me.chModified.Width, _
        '                                                     Me.chSize.Width, Me.chStatus.Width}


        Me.lvwFileList.BeginUpdate()

        Me.lvwFileList.Items.Clear()
        Me.lvwFileList.Groups.Clear()
        Me.lvwFileList.Columns.Clear()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Close, "Form closed.", sw.ElapsedTicks)

        '====================
        'Refreshing all lists
        '====================
        frmMain.GameList_Refresh()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub UI_SwitchOperationMode(pOperationMode As FileOperations)
        Me.lvwFileList.Items.Clear()
        Me.lvwFileList.Groups.Clear()
        Me.lvwFileList.Columns.Clear()

        Me.Text = pOperationMode.ToString
        Me.cmdOperation.Text = pOperationMode.ToString.ToUpper
        Me.cmdSortReset.Visible = False
        Me.ckbSStatesManReorderBackup.Visible = False
        Me.ckbSStatesManMoveToTrash.Visible = False
        Me.lblSizeBackup.Visible = True
        Me.lblSizeBackup.Visible = False

        Me.cmdDeleteCheckAll = Me.cmdCommand2
        Me.cmdDeleteCheckNone = Me.cmdCommand3
        Me.cmdDeleteCheckInvert = Me.cmdCommand4
        Me.cmdDeleteCheckBackup = Me.cmdCommand1

        Me.cmdMoveFirst = Me.cmdCommand1
        Me.cmdMoveUp = Me.cmdCommand2
        Me.cmdMoveDown = Me.cmdCommand3
        Me.cmdMoveLast = Me.cmdCommand4

        Me.cmdStoreCheckAll = Me.cmdCommand2
        Me.cmdStoreCheckNone = Me.cmdCommand3
        Me.cmdStoreCheckInvert = Me.cmdCommand4
        Me.cmdStoreCheckBackup = Me.cmdCommand1

        Select Case pOperationMode
            Case FileOperations.Delete
                Me.lblAction.Text = Me.cmdOperation.Text.ToLower & " checked"
                Me.FormDescription = String.Format("check the files you really want to {0} and press ""{0}"" to confirm.", Me.cmdOperation.Text.ToLower)
                Me.lblSize.Visible = True
                Me.lblSizeBackup.Visible = True

                Me.cmdDeleteCheckAll.Text = "ALL"
                Me.cmdDeleteCheckAll.Image = My.Resources.Icon_CheckAll
                AddHandler cmdDeleteCheckAll.Click, AddressOf cmdDeleteCheckAll_Click

                Me.cmdDeleteCheckNone.Text = "NONE"
                Me.cmdDeleteCheckNone.Image = My.Resources.Icon_CheckNone
                AddHandler cmdDeleteCheckNone.Click, AddressOf cmdDeleteCheckNone_Click

                Me.cmdDeleteCheckInvert.Text = "INVERT"
                Me.cmdDeleteCheckInvert.Image = My.Resources.Icon_CheckInvert
                AddHandler cmdDeleteCheckInvert.Click, AddressOf cmdDeleteCheckInvert_Click

                Me.cmdDeleteCheckBackup.Text = "BACKUP"
                Me.cmdDeleteCheckBackup.Image = My.Resources.Icon_CheckBackup
                AddHandler cmdDeleteCheckBackup.Click, AddressOf cmdDeleteCheckBackup_Click

                Me.cmdDeleteCheckBackup.Visible = True
                Me.ckbSStatesManMoveToTrash.Visible = True

                AddHandler cmdOperation.Click, AddressOf cmdDelete_Click
                ' TODO safer call to SSMGameList.Folders
                ' If the stored folder isn't set there may be exceptions.
                Me.SourcePath = SSMGameList.Folders(frmMain.CurrentListMode)
                Select Case frmMain.CurrentListMode
                    Case ListMode.Savestates
                        Me.cmdDeleteCheckBackup.Visible = True
                        Me.lblSize.Text = "savestates size"
                        Me.lblSizeBackup.Visible = True
                    Case ListMode.Stored
                        Me.cmdDeleteCheckBackup.Visible = False
                        Me.lblSize.Text = "savestates size"
                        Me.lblSizeBackup.Visible = False
                    Case ListMode.Snapshots
                        Me.cmdDeleteCheckBackup.Visible = False
                        Me.lblSize.Text = "screenshots size"
                        Me.lblSizeBackup.Visible = False
                End Select

                'Dim tmpColumnWidths() As Integer = {0}
                Select Case frmMain.CurrentListMode
                    Case ListMode.Savestates, ListMode.Stored
                        Me.lvwFileList.Columns.AddRange({New ColumnHeader With {.Name = "chFileName", .Text = "Savestate file name", .Width = 240}, _
                                                         New ColumnHeader With {.Name = "chSlot", .Text = "Slot", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                                         New ColumnHeader With {.Name = "chVersion", .Text = "Version", .Width = 80}, _
                                                         New ColumnHeader With {.Name = "chModified", .Text = "Modified", .Width = 0}, _
                                                         New ColumnHeader With {.Name = "chSize", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                                        })

                    Case ListMode.Snapshots
                        Me.lvwFileList.Columns.AddRange({New ColumnHeader With {.Name = "chFileName", .Text = "Snapshot file name", .Width = 240}, _
                                                         New ColumnHeader With {.Name = "chNumber", .Text = "Number", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                                         New ColumnHeader With {.Name = "chResolution", .Text = "Resolution", .Width = 80}, _
                                                         New ColumnHeader With {.Name = "chModified", .Text = "Modified", .Width = 0}, _
                                                         New ColumnHeader With {.Name = "chSize", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                                        })
                End Select
                Me.lvwFileList.Columns.Add(New ColumnHeader With {.Name = "chStatus", .Text = "Status", .Width = 140})

                Me.DeleteList_AddFiles()
                Me.DeleteList_Preview()
                Me.DeleteList_IndexChecked()
                Me.DeleteList_UpdateUI()
            Case FileOperations.Reorder
                Me.FormDescription = "use the move buttons to reorder the list and click ""reorder"" to confirm."

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

                AddHandler cmdOperation.Click, AddressOf cmdReorder_Click

                Me.SourcePath = SSMGameList.Folders(frmMain.CurrentListMode)
                Me.DestPath = Me.SourcePath

                If My.Settings.SStatesMan_SStateReorderBackup Then
                    Me.MoveStep = 2
                Else
                    Me.MoveStep = 1
                End If

                Me.lvwFileList.Columns.AddRange({New ColumnHeader With {.Name = "chSlot", .Text = "Slot"}, _
                                                 New ColumnHeader With {.Name = "chOldName", .Text = "Old name", .Width = 200}, _
                                                 New ColumnHeader With {.Name = "chNewName", .Text = "New name", .Width = 200}, _
                                                 New ColumnHeader With {.Name = "chStatus", .Text = "Status", .Width = 160} _
                                                })

                Me.ReorderList_AddFiles()
                Me.ReorderList_Preview()
                Me.ReorderList_UpdateUI()
            Case FileOperations.Store, FileOperations.Restore
                Me.lblAction.Text = Me.cmdOperation.Text.ToLower & " checked"
                Me.FormDescription = String.Format("check the savestates you want to {0} and press ""{0}"" to confirm.", Me.cmdOperation.Text.ToLower)

                Me.cmdStoreCheckAll.Text = "ALL"
                Me.cmdStoreCheckAll.Image = My.Resources.Icon_CheckAll
                AddHandler cmdStoreCheckAll.Click, AddressOf cmdStoreCheckAll_Click

                Me.cmdStoreCheckNone.Text = "NONE"
                Me.cmdStoreCheckNone.Image = My.Resources.Icon_CheckNone
                AddHandler cmdStoreCheckNone.Click, AddressOf cmdStoreCheckNone_Click

                Me.cmdStoreCheckInvert.Text = "INVERT"
                Me.cmdStoreCheckInvert.Image = My.Resources.Icon_CheckInvert
                AddHandler cmdStoreCheckInvert.Click, AddressOf cmdStoreCheckInvert_Click

                Me.cmdStoreCheckBackup.Visible = False

                AddHandler cmdOperation.Click, AddressOf cmdStore_Click
                Select Case Me.currentOperationMode
                    Case FileOperations.Store
                        Me.SourcePath = SSMGameList.Folders(ListMode.Savestates)
                        Me.DestPath = SSMGameList.Folders(ListMode.Stored)
                    Case FileOperations.Restore
                        Me.SourcePath = SSMGameList.Folders(ListMode.Stored)
                        Me.DestPath = SSMGameList.Folders(ListMode.Savestates)
                End Select

                Me.lvwFileList.Columns.AddRange({New ColumnHeader With {.Name = "chSlot", .Text = "Slot"}, _
                                                 New ColumnHeader With {.Name = "chOldName", .Text = "Old name", .Width = 200}, _
                                                 New ColumnHeader With {.Name = "chNewName", .Text = "New name", .Width = 200}, _
                                                 New ColumnHeader With {.Name = "chStatus", .Text = "Status", .Width = 160} _
                                                })

                Me.StoreList_AddFiles()
                Me.StoreList_Preview()
                Me.StoreList_UpdateUI()
            Case FileOperations.Assign
                Me.SourcePath = SSMGameList.Folders(ListMode.Snapshots)
                Me.DestPath = Me.SourcePath

                'Me.FileList_AddSlotAndFiles()
                'Me.UI_AssignPreview()
        End Select

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.ListMode, String.Format("Switched to {0} operation mode.", pOperationMode.ToString))
    End Sub

    Private Sub frmMain_ThemeApplied(sender As Object, e As EventArgs) Handles MyBase.ThemeApplied
        Me.tlpFileListStatus.BackColor = Me.BorderColorActive
    End Sub

End Class