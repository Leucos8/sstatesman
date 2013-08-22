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

Public Class frmReorderForm
    Dim lastWindowState As FormWindowState  'Needed to know if a form resize changed the windowstate

    Dim LastChecked As Integer = -1
    'Dim FilesRenamed As Boolean = False
    Dim RenamePhase As Integer = 0
    Dim MoveStep As Integer = 1

    Dim currentSerial As String = ""
    Dim currentCRC As String = "00000000"

    Dim Count_Files As Integer = 0
    Dim Count_RenamePending As Integer = 0

    Enum ReorderListColumns
        Slot
        OldName
        NewName
        Status
    End Enum

    Enum ReorderFileStatus
        FreeSlot        'No savestate
        Idle            'Current file name matches new name
        RenamePending   'Current file name is different from new name
        Renamed         'The file has been renamed succesfully
        FileNotFound    'The file has not been found when renaming
        FileAlreadyExist 'A file with the target name already exist
        OtherError      'Another error has been encountered
    End Enum

#Region "Reorder"
    Private Sub Rename_Execute()
        'Two For Each loops that renames the files.
        'The first loop (Me.RenamePhase = 1) simply adds the ".tmp" extension to the file that needs to be renamed.
        'The second loop (Me.RenamePhase = 2) rename the files with their proper target filename.
        'Me.RenamePhase = 3 means that all files have been renamed (reorder button is disabled).
        If Me.lvwReorderList.Items.Count > 0 Then

            Me.RenamePhase = 1

            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If tmpListItem.Tag.Equals(ReorderFileStatus.RenamePending) Then
                    tmpListItem.Tag = Me.Rename_Move(tmpListItem.SubItems(ReorderListColumns.OldName).Text, _
                                                     Me.AddTmpExtension(tmpListItem.SubItems(ReorderListColumns.OldName).Text), _
                                                     My.Settings.PCSX2_PathSState, _
                                                     tmpListItem.SubItems(ReorderListColumns.Status).Text)
                End If
            Next

            Me.RenamePhase = 2

            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If tmpListItem.Tag.Equals(ReorderFileStatus.Renamed) Then
                    tmpListItem.Tag = Me.Rename_Move(Me.AddTmpExtension(tmpListItem.SubItems(ReorderListColumns.OldName).Text), _
                                                     tmpListItem.SubItems(ReorderListColumns.NewName).Text, _
                                                     My.Settings.PCSX2_PathSState, _
                                                     tmpListItem.SubItems(ReorderListColumns.Status).Text)
                End If
            Next
        End If
        Me.RenamePhase = 3
    End Sub

    ''' <summary>Safely move (rename) the files.</summary>
    ''' <param name="pSourceFileName">Filename of the original file.</param>
    ''' <param name="pDestFileName">Filename of the target file.</param>
    ''' <param name="pPath">Path where both input files are located.</param>
    ''' <param name="pResultMessage">Out parameter that gives a message detailing the result of the operation.</param>
    ''' <returns>Result status flag.</returns>
    Private Function Rename_Move(pSourceFileName As String, pDestFileName As String, pPath As String, _
                                 ByRef pResultMessage As String) As ReorderFileStatus
        Try
            Dim tmpSourceFileFullPath As String = Path.Combine(pPath, pSourceFileName)
            Dim tmpDestFileFullPath As String = Path.Combine(pPath, pDestFileName)

            If File.Exists(tmpSourceFileFullPath) Then
                If Not (File.Exists(tmpDestFileFullPath)) Then
                    File.Move(tmpSourceFileFullPath, tmpDestFileFullPath)
                    pResultMessage = String.Format("File renamed to {0} successfully.", pDestFileName)
                    SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("{0}/2 File {1} renamed to {2}.", RenamePhase, pSourceFileName, pDestFileName))
                    Return ReorderFileStatus.Renamed
                Else
                    pResultMessage = String.Format("Target file {0} already exist. Renaming skipped", pDestFileName)
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("{0}/2 Target file {1} already exist. Renaming skipped", RenamePhase, pDestFileName))
                    Return ReorderFileStatus.FileAlreadyExist
                End If
            Else
                pResultMessage = String.Format("File {0} not found.", pSourceFileName)
                SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                 String.Format("{0}/2 File {1} not found.", RenamePhase, pSourceFileName))
                Return ReorderFileStatus.FileNotFound
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pResultMessage = String.Format("Error renaming {0} to {1}. {2}", pSourceFileName, pDestFileName, ex.Message)
            SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                             String.Format("{0}/2 Error renaming {1} to {2}. {3}", RenamePhase, pSourceFileName, pDestFileName, ex.Message))
            Return ReorderFileStatus.OtherError
        End Try
    End Function

    Private Function AddTmpExtension(pFilename As String) As String
        Const tmpExtension As String = ".tmp"
        Return pFilename & tmpExtension
    End Function
#End Region

#Region "Form"
    Private Sub frmReorderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Form load start.")

        '==================
        'Window preparation
        '==================

        '-----
        'Theme
        '-----
        Me.applyTheme()

        'Checked state icons
        Dim tmpLvwCheckboxes As New ImageList With {.ImageSize = mdlTheme.imlLvwCheckboxes.ImageSize}   'Cannot use imlLvwCheckboxes directly because of a bug that makes checkboxes disappear.
        tmpLvwCheckboxes.Images.AddRange({My.Resources.Checkbox_Unchecked_22x22, My.Resources.Checkbox_Checked_22x22})
        Me.lvwReorderList.StateImageList = tmpLvwCheckboxes    'Assigning the imagelist to the Files listview
        'Savestates, backup, and screenshot icons
        Me.lvwReorderList.SmallImageList = mdlTheme.imlLvwItemIcons

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "1/2 Theme & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================

        If My.Settings.SStatesMan_SStateReorderBackup Then
            Me.MoveStep = 2
        Else
            Me.MoveStep = 1
        End If

        Me.UI_Enable(False)
        Me.ReorderList_AddSavestates()
        Me.UI_RenamePreview()
        Me.UI_Updater()
        Me.UI_Enable(True)

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "2/2 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "All done.", sw.ElapsedTicks)
    End Sub

    Private Sub frmReorderForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.UI_Enable(False)
        Me.RenamePhase = 0
        Me.LastChecked = -1

        Me.lvwReorderList.Items.Clear()
        Me.lvwReorderList.Groups.Clear()
        Me.UI_Enable(True)

        frmMain.GameList_Refresh()
    End Sub
#End Region

#Region "UI - General"
    ''' <summary>Handles the filelist beginupdate and endupdate methods</summary>
    ''' <param name="pSwitch">True to end the update, False to begin the update</param>
    Private Sub UI_Enable(pSwitch As Boolean)
        If pSwitch Then
            AddHandler Me.lvwReorderList.ItemChecked, AddressOf Me.lvwReorderLisst_ItemChecked
            Me.lvwReorderList.EndUpdate()
        Else
            RemoveHandler Me.lvwReorderList.ItemChecked, AddressOf Me.lvwReorderLisst_ItemChecked
            Me.lvwReorderList.BeginUpdate()
        End If
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.UI_Enable, pSwitch.ToString)
    End Sub

    ''' <summary>Updates the UI status.</summary>
    Private Sub UI_Updater()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = String.Format("{0:N0} | {1:N0} items", Me.lvwReorderList.CheckedItems.Count, Me.lvwReorderList.Items.Count)
        Me.txtSize.Text = String.Format("{0:N0} | {1:N0} files", Me.Count_RenamePending, Me.Count_Files)

        Me.flpFileListCommandsFiles.SuspendLayout()

        If (Me.lvwReorderList.Items.Count = 0) Or Me.RenamePhase = 3 Then
            '==========================================
            'No files in list or file have been renamed
            '==========================================

            Me.cmdMoveUp.Enabled = False
            Me.cmdMoveLast.Enabled = False
            Me.cmdMoveDown.Enabled = False
            Me.cmdMoveFirst.Enabled = False

            Me.cmdSortReset.Enabled = False

            Me.cmdReorder.Enabled = False
        Else
            '=================
            'Files are present
            '=================
            If Me.Count_RenamePending > 0 Then
                Me.cmdReorder.Enabled = True
                Me.cmdSortReset.Enabled = True
            Else
                Me.cmdReorder.Enabled = False
                Me.cmdSortReset.Enabled = False
            End If

            If Me.lvwReorderList.CheckedItems.Count > 0 Then
                'First item checked
                If Me.lvwReorderList.Items(0).Checked Then
                    Me.cmdMoveFirst.Enabled = False
                    Me.cmdMoveUp.Enabled = False
                Else
                    Me.cmdMoveFirst.Enabled = True
                    Me.cmdMoveUp.Enabled = True
                End If

                'Move down should work as per list items.
                If Me.lvwReorderList.Items(Me.lvwReorderList.Items.Count - 1).Checked Then
                    Me.cmdMoveDown.Enabled = False
                Else
                    Me.cmdMoveDown.Enabled = True
                End If
                'Last file should have regular slot number.
                If Me.lvwReorderList.Items((My.Settings.PCSX2_SStateSlotUpperBound - My.Settings.PCSX2_SStateSlotLowerBound + 1) * 2 - 1).Checked Then
                    Me.cmdMoveLast.Enabled = False
                    If My.Settings.SStatesMan_SStateReorderBackup Then
                        Me.cmdMoveDown.Enabled = False
                    End If
                Else
                    Me.cmdMoveLast.Enabled = True
                End If


            ElseIf Me.lvwReorderList.CheckedItems.Count = 0 Then
                Me.cmdMoveUp.Enabled = False
                Me.cmdMoveLast.Enabled = False
                Me.cmdMoveDown.Enabled = False
                Me.cmdMoveFirst.Enabled = False
            End If

        End If

        Me.flpFileListCommandsFiles.ResumeLayout()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub

    Private Sub UI_RenamePreview()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If Me.lvwReorderList.Items.Count > 0 Then

            Count_RenamePending = 0

            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items

                If tmpListItem.Tag.Equals(ReorderFileStatus.FreeSlot) Then
                    'Free slot, no savestate
                    tmpListItem.SubItems(ReorderListColumns.NewName).Text = "-"
                    tmpListItem.ForeColor = Color.DimGray
                    tmpListItem.SubItems(ReorderListColumns.Status).Text = ""

                ElseIf tmpListItem.Tag.Equals(ReorderFileStatus.RenamePending) Then
                    'A new filename needs to be assigned

                    tmpListItem.SubItems(ReorderListColumns.NewName).Text = Savestate.CreateFileName(currentSerial, currentCRC, _
                                                                                                     tmpListItem.Index \ 2 + My.Settings.PCSX2_SStateSlotLowerBound, _
                                                                                                     CBool(tmpListItem.Index Mod 2))

                    If tmpListItem.SubItems(ReorderListColumns.OldName).Text = tmpListItem.SubItems(ReorderListColumns.NewName).Text Then
                        tmpListItem.Tag = ReorderFileStatus.Idle
                        tmpListItem.ForeColor = Me.ForeColor
                        tmpListItem.SubItems(ReorderListColumns.Status).Text = ""
                    Else
                        tmpListItem.ForeColor = mdlTheme.currentTheme.AccentColorDark
                        tmpListItem.SubItems(ReorderListColumns.Status).Text = "Rename pending."
                        Count_RenamePending += 1
                    End If

                ElseIf tmpListItem.Tag.Equals(ReorderFileStatus.Renamed) Then
                    tmpListItem.BackColor = Color.FromArgb(150, 200, 130)

                ElseIf tmpListItem.Tag.Equals(ReorderFileStatus.FileAlreadyExist) Then
                    tmpListItem.BackColor = Color.FromArgb(255, 255, 192)

                ElseIf tmpListItem.Tag.Equals(ReorderFileStatus.FileNotFound) Or _
                    tmpListItem.Tag.Equals(ReorderFileStatus.OtherError) Then
                    'There was an error
                    tmpListItem.BackColor = Color.FromArgb(255, 192, 192)
                End If
                'tmpListItem.SubItems(ReorderListColumns.Status).Text = tmpListItem.Tag.ToString
            Next
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Preview, _
                         String.Format("Preview for {0:N0} ListViewItems.", Me.Count_RenamePending), _
                         sw.ElapsedMilliseconds)
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReorder.Click
        Me.UI_Enable(False)
        Me.Rename_Execute()
        Me.UI_RenamePreview()
        frmMain.GameList_Refresh()
        'Me.ReorderList_AddSavestates()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ckbSStatesManReorderBackup_CheckedChanged(sender As Object, e As EventArgs) Handles ckbSStatesManReorderBackup.CheckedChanged
        'Prevent firing during load
        If CType(sender, CheckBox).IsHandleCreated Then
            'UI disabled
            Me.UI_Enable(False)
            'Unchecking items.
            For lvwItemIndex = 0 To Me.lvwReorderList.Items.Count - 1
                Me.lvwReorderList.Items.Item(lvwItemIndex).Checked = False
            Next

            'MoveStep (1 = move one item each time, 2 = move two items together - savestate and backup)
            If CType(sender, CheckBox).Checked Then
                Me.MoveStep = 2
            Else
                Me.MoveStep = 1
            End If
            'UI enabled
            Me.UI_Enable(True)

        End If
    End Sub
#End Region

#Region "Form - ControlBox & Resize"
    Private Sub cmdWindowMaximize_MouseEnter(sender As Object, e As EventArgs) Handles cmdWindowMaximize.MouseEnter
        If Me.WindowState = FormWindowState.Normal Then
            CType(sender, Button).Image = My.Resources.Window_ButtonMaximizeW_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            CType(sender, Button).Image = My.Resources.Window_ButtonRestoreW_12x12
        End If
    End Sub

    Private Sub cmdWindowMaximize_MouseLeave(sender As Object, e As EventArgs) Handles cmdWindowMaximize.MouseLeave
        If Me.WindowState = FormWindowState.Normal Then
            CType(sender, Button).Image = My.Resources.Window_ButtonMaximize_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            CType(sender, Button).Image = My.Resources.Window_ButtonRestore_12x12
        End If
    End Sub

    Private Sub cmdWindowMaximize_Click(sender As Object, e As EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub cmdWindowClose_Click(sender As Object, e As EventArgs) Handles cmdWindowClose.Click
        Me.Close()
    End Sub

    Private Sub frmDeleteForm_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Not (Me.lastWindowState = Me.WindowState) Then
            If Me.WindowState = FormWindowState.Normal Then
                Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximize_12x12
                Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 0, CInt(6 * DPIxScale), 0)
                'Me.Padding = New Padding(1)
            ElseIf Me.WindowState = FormWindowState.Maximized Then
                Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestore_12x12
                Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 0, CInt(3 * DPIxScale), 0)
                'Me.Padding = New Padding(0)
            End If
            Me.lastWindowState = Me.WindowState
        End If
    End Sub
#End Region

#Region "UI - FileList"
    Private Sub ReorderList_AddSavestates()
        Dim sw As New Stopwatch
        sw.Start()

        'clear items and groups.
        Me.lvwReorderList.Items.Clear()
        Me.lvwReorderList.Groups.Clear()

        'only one game need to be checked
        If frmMain.checkedGames.Count = 1 Then
            'GameList contains the serial
            If SSMGameList.Games.ContainsKey(frmMain.checkedGames(0)) Then

                'Some info of the game checked
                currentSerial = frmMain.checkedGames(0)
                currentCRC = SSMGameList.Games(currentSerial).CRC

                'Creation of the header
                Dim tmpGameInfo As New mdlGameDb.GameInfo
                tmpGameInfo = PCSX2GameDb.Extract(frmMain.checkedGames(0))
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                    .Header = tmpGameInfo.ToString(),
                    .HeaderAlignment = HorizontalAlignment.Left,
                    .Name = tmpGameInfo.Serial}

                Dim tmpSListItems As New List(Of ListViewItem)

                'Creation of the available slots, 10 x 2 = 20
                Dim currentSlot As Integer = My.Settings.PCSX2_SStateSlotLowerBound
                For i As Integer = 0 To (My.Settings.PCSX2_SStateSlotUpperBound - My.Settings.PCSX2_SStateSlotLowerBound + 1) * 2 - 1
                    Dim tmpLvwSListItem As New ListViewItem With {.Text = (My.Settings.PCSX2_SStateSlotLowerBound + i \ 2).ToString, _
                                                                  .Group = tmpLvwSListGroup, _
                                                                  .Tag = ReorderFileStatus.FreeSlot}
                    If Not ((i Mod 2) > 0) Then
                        tmpLvwSListItem.ImageIndex = 0
                        'tmpLvwSListItem.Text &= " Standard"
                    Else
                        tmpLvwSListItem.ImageIndex = 1
                        'tmpLvwSListItem.Text &= " Backup"
                    End If
                    tmpLvwSListItem.SubItems.AddRange({"-", "-", ""})
                    tmpSListItems.Add(tmpLvwSListItem)
                Next

                'Adding savestates
                For Each tmpSavestate As KeyValuePair(Of String, Savestate) In SSMGameList.Games(frmMain.checkedGames(0)).Savestates
                    Dim listRef As Integer = tmpSavestate.Value.Slot    'Used for list index
                    If (listRef >= My.Settings.PCSX2_SStateSlotLowerBound) And (listRef <= My.Settings.PCSX2_SStateSlotUpperBound) Then
                        'Even numbers are for savestates
                        listRef -= My.Settings.PCSX2_SStateSlotLowerBound
                        listRef *= 2
                        If tmpSavestate.Value.isBackup Then
                            'Odd numbers are for backups
                            listRef += 1
                        End If

                        'Old name = new name, status idle
                        tmpSListItems.Item(listRef).SubItems(ReorderListColumns.OldName).Text = tmpSavestate.Value.Name
                        tmpSListItems.Item(listRef).SubItems(ReorderListColumns.NewName).Text = tmpSavestate.Value.Name
                        tmpSListItems.Item(listRef).Tag = ReorderFileStatus.Idle
                    Else
                        'This savestate has an out of bounds index, a new list item is added
                        Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = "Other", _
                                                                                           .Tag = ReorderFileStatus.Idle, _
                                                                                           .Group = tmpLvwSListGroup, _
                                                                                           .ImageIndex = 0, _
                                                                                           .Font = New Font(Me.lvwReorderList.Font, FontStyle.Bold)}
                        tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Name, tmpSavestate.Value.Name, ""})
                        tmpSListItems.Add(tmpLvwSListItem)
                        SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                         String.Format("Slot value not valid for {0}.", tmpSavestate.Value.Name))
                    End If
                Next

                mdlTheme.ListAlternateColors(tmpSListItems)

                Count_Files = SSMGameList.Games(frmMain.checkedGames(0)).Savestates.Count

                Me.lvwReorderList.Groups.Add(tmpLvwSListGroup)
                Me.lvwReorderList.Items.AddRange(tmpSListItems.ToArray)
            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                 String.Format("Game {0} not found in list.", frmMain.checkedGames(0)))
            End If
        Else
            SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                             String.Format("Only one game need to be checked when renaming. {0} games were checked.", frmMain.checkedGames.Count))
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.FileListview, _
                         String.Format("Listed {0:N0} savestates.", Me.lvwReorderList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub lvwReorderLisst_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        'Fixing ItemChecked firing unexpectedly.
        '=======================================
        'The first time the form is opened everything happens as expected. When AddRange is used to add the ListViewItems the ItemChecked event is 
        'fired immediatly for each item that has been added, before Form_Load is complete. 
        'Since I do not want ItemChecked firing during Form_Load, before using AddRange, UI_Enable is called and removes the event handler for 
        'ItemChecked, effectively preventing it from firing. After AddRange UI_Enable is called again in Form_Load and the event handler
        'for ItemChecked is reattached.
        'The second time the form is opened something does not work in the same way. ItemChecked events are delayed after Form_Load is complete 
        '(after End Sub), meaning that UI_Enabled has been already called twice and has already reattached the event handler. But the state of the
        'ListView control is inconsistent:
        '- if I try to access the items from another Sub or Function everything is fine.
        '- if I try to access the items (in fact only the items added after the one in e.Item are inaccessible) in the ItemChecked Sub I get a 
        '  System.NullReference exception, while accessing the Items.Count property says that all the items have been added.
        If CType(sender, ListView).Items(CType(sender, ListView).Items.Count - 1) IsNot Nothing Then

            If My.Settings.SStatesMan_SStateReorderBackup Then

                If (e.Item.Index \ 2 + My.Settings.PCSX2_SStateSlotLowerBound >= My.Settings.PCSX2_SStateSlotLowerBound) AndAlso _
                    (e.Item.Index \ 2 + My.Settings.PCSX2_SStateSlotLowerBound <= My.Settings.PCSX2_SStateSlotUpperBound) Then

                    If LastChecked = e.Item.Index Then
                        LastChecked = -1
                    Else
                        If (e.Item.Index Mod 2) > 0 Then
                            'Backup
                            LastChecked = e.Item.Index - 1  'Will be selected the previous one, the savestate
                        Else
                            'Standard
                            LastChecked = e.Item.Index + 1  'Will be selected the next one, the backup
                        End If
                        'Stupid ItemChecked event is firing long after adding items and causes a SystemNullReference exception.
                        If CType(sender, ListView).Items(LastChecked) IsNot Nothing Then
                            CType(sender, ListView).Items(LastChecked).Checked = e.Item.Checked
                        End If
                    End If

                Else
                    LastChecked = e.Item.Index
                    e.Item.Checked = False
                End If

            End If

            Me.UI_Updater()
        End If
    End Sub

    ''' <summary>Moves the checked items in pListView by the amount of pStep.</summary>
    ''' <param name="pListView">ListView containing the items.</param>
    ''' <param name="pStep">How much the items will be moved.</param>
    ''' <remarks>Only some properties are moved, not everything!</remarks>
    Private Sub MoveLwItems(ByRef pListView As ListView, pStep As Integer)

        'At least one item needs to be selected
        If pListView.CheckedItems.Count > 0 Then

            Dim LowerBound, UpperBound As Integer   'Bounds used in the For loop that loops throurough all the checked items.
            If pStep > 0 Then                                                                                 '------------- 
                'pStep > 0, move down
                'Since items will be moved down, the checked items will be swapped backwards:first item swapped is the last one
                '(index = pListView.CheckedItems.Count - 1), last item swapped is the first one (index = 0)
                LowerBound = pListView.CheckedItems.Count - 1
                UpperBound = 0

                'pStep must not exceed the difference between the last pListView item index and the last checked item index,
                'because it would move the items outside the ListView (obviously throwing a OutOfRange exception).
                If ((pListView.Items.Count - 1) - pListView.CheckedItems.Item(pListView.CheckedItems.Count - 1).Index) < pStep Then
                    pStep = (pListView.Items.Count - 1) - pListView.CheckedItems.Item(pListView.CheckedItems.Count - 1).Index
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                     String.Format("Move step has been recalculated: {0}.", pStep))
                End If

            ElseIf pStep < 0 Then
                'pStep < 0, move up
                'Since items will be moved up, the checked items will be swapped in their right order: first item swapped is the 
                'first one (index = 0), last item swapped is the last one (pListView.CheckedItems.Count - 1)
                LowerBound = 0
                UpperBound = pListView.CheckedItems.Count - 1

                'pStep must not exceed the first checked item index, because it would move the items outside the ListView 
                '(obviously throwing a OutOfRange exception).
                '"-pStep" is used because when moving up pStep is negative, while all the indexes are positive.
                If pListView.CheckedItems.Item(0).Index < -pStep Then
                    pStep = -pListView.CheckedItems.Item(0).Index
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                     String.Format("Move step has been recalculated: {0}.", pStep))
                End If

            End If

            'If pStep is 0 then there is no need to move items.
            If pStep = 0 Then
                SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                 "Move ListViewItems step is 0. There is no need to move ListViewItems.")
                Exit Sub
            End If

            'This For loop cycles all checked items, swapping them relatively to pStep (negative pStep means previous items, positive
            'means successive items.
            '"Step Math.Sign(-pStep)" is used to give the direction of the loop.
            For i As Integer = LowerBound To UpperBound Step Math.Sign(-pStep)
                'I love references! These two act like the variable used in a For Each loop
                Dim tmpItemChecked As ListViewItem = pListView.CheckedItems(i)
                Dim tmpItemSwapped As ListViewItem = pListView.Items(tmpItemChecked.Index + pStep)
                'Backing up swapped values
                Dim tmpPosition As Integer = tmpItemChecked.Index
                Dim tmpOldName As String = tmpItemChecked.SubItems(ReorderListColumns.OldName).Text
                Dim tmpTag As ReorderFileStatus = CType(tmpItemChecked.Tag, ReorderFileStatus)
                'Swapping names
                tmpItemChecked.SubItems(ReorderListColumns.OldName).Text = tmpItemSwapped.SubItems(ReorderListColumns.OldName).Text
                tmpItemSwapped.SubItems(ReorderListColumns.OldName).Text = tmpOldName
                'Tags
                tmpItemChecked.Tag = tmpItemSwapped.Tag
                tmpItemSwapped.Tag = tmpTag
                If tmpItemChecked.Tag.Equals(ReorderFileStatus.Idle) Then
                    tmpItemChecked.Tag = ReorderFileStatus.RenamePending
                End If
                If tmpItemSwapped.Tag.Equals(ReorderFileStatus.Idle) Then
                    tmpItemSwapped.Tag = ReorderFileStatus.RenamePending
                End If
                'Updated selections
                tmpItemChecked.Checked = tmpItemSwapped.Checked
                tmpItemSwapped.Checked = True

            Next

            'SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.List, _
            '                 String.Format("Moved {0:N0} savestates by {1}.", pListView.CheckedItems.Count, pStep))
        Else
            SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                             "There are no ListViewItems checked to be moved.")
        End If

    End Sub

    Private Sub cmdMoveUp_Click(sender As Object, e As EventArgs) Handles cmdMoveUp.Click
        Me.UI_Enable(False)
        'At least one item needs to be checked
        If Me.lvwReorderList.CheckedItems.Count > 0 Then
            Me.MoveLwItems(lvwReorderList, -MoveStep)           'Move one position up
            Me.lvwReorderList.CheckedItems(0).EnsureVisible()  'Visibility
        End If
        Me.UI_RenamePreview()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdMoveDown_Click(sender As Object, e As EventArgs) Handles cmdMoveDown.Click
        Me.UI_Enable(False)
        'At least one item needs to be checked
        If Me.lvwReorderList.CheckedItems.Count > 0 Then
            Me.MoveLwItems(Me.lvwReorderList, MoveStep)        'Move one position down
            Me.lvwReorderList.CheckedItems(Me.lvwReorderList.CheckedItems.Count - 1).EnsureVisible()  'Visibility
        End If
        Me.UI_RenamePreview()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdMoveFirst_Click(sender As Object, e As EventArgs) Handles cmdMoveFirst.Click
        Me.UI_Enable(False)
        If Me.lvwReorderList.CheckedItems.Count > 0 Then
            'Me.MoveLwItems(Me.lvwReorderList, -Me.lvwReorderList.checkedItems.Item(0).Index)
            For i As Integer = 0 To Me.lvwReorderList.CheckedItems.Item(0).Index - 1 Step MoveStep   'Need to move step by step, if not weird sorting cand happen.
                Me.MoveLwItems(Me.lvwReorderList, -MoveStep)
            Next
            Me.lvwReorderList.Items(0).EnsureVisible()
        End If
        Me.UI_RenamePreview()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdMoveLast_Click(sender As Object, e As EventArgs) Handles cmdMoveLast.Click
        Me.UI_Enable(False)
        If Me.lvwReorderList.CheckedItems.Count > 0 Then
            'Me.MoveLwItems(Me.lvwReorderList, (Me.lvwReorderList.Items.Count - 1) - Me.lvwReorderList.checkedItems.Item(Me.lvwReorderList.checkedItems.Count - 1).Index)
            '(SStateSlotUpperBound - SStateSlotLowerBound + 1) * 2 -1 = (9 - 0 + 1) * 2 -1 = 19 Gives the index of the last standard savestate.
            'CheckedItems.Item(CheckedItems.Count - 1).Index - 1 Gives the index of the last checked item. -1 at the end is added because 
            '*last index of standard savestate* - *last checked item index* gives the number of iterations, since the loop start with i = 0
            'the max needs to be *number of iteration* - 1.
            '-2 because there are two -1.
            For i As Integer = 0 To (My.Settings.PCSX2_SStateSlotUpperBound - My.Settings.PCSX2_SStateSlotLowerBound + 1) * 2 - _
                Me.lvwReorderList.CheckedItems.Item(Me.lvwReorderList.CheckedItems.Count - 1).Index - 2 Step MoveStep
                Me.MoveLwItems(Me.lvwReorderList, MoveStep)
            Next
            Me.lvwReorderList.CheckedItems.Item(Me.lvwReorderList.CheckedItems.Count - 1).EnsureVisible()
        End If
        Me.UI_RenamePreview()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdSortReset_Click(sender As Object, e As EventArgs) Handles cmdSortReset.Click
        Me.UI_Enable(False)
        Me.ReorderList_AddSavestates()
        Me.UI_RenamePreview()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub
#End Region

#Region "Theme"
    Private Sub pnlTopPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlTopPanel.Paint
        Dim rectoolbar As New Rectangle(0, CInt(8 * DPIyScale), CInt(23 * DPIxScale) + 1, CInt(38 * DPIyScale) + 1)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(rectoolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 90)
        e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
        If Me.imgWindowGradientIcon.Width > 0 And Me.imgWindowGradientIcon.Height > 0 Then
            rectoolbar = New Rectangle(Me.imgWindowGradientIcon.Location, Me.imgWindowGradientIcon.Size)
            linGrBrushToolbar = New Drawing2D.LinearGradientBrush(rectoolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 90)
            e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
        End If
        If (CType(sender, Panel).Height > CInt(4 * DPIyScale) + 1) And (CType(sender, Panel).Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                rectoolbar = New Rectangle(0, CType(sender, Panel).Height - CInt(4 * DPIyScale), CType(sender, Panel).Width + 1, CInt(3 * DPIyScale) + 1)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(rectoolbar, Color.Transparent, Color.DarkGray, 90)
                rectoolbar.Y += 1
                e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, CType(sender, Panel).Height - 1, CType(sender, Panel).Width, CType(sender, Panel).Height - 1)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles flpBottomPanel.Paint
        If CType(sender, FlowLayoutPanel).Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, CType(sender, FlowLayoutPanel).Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, FlowLayoutPanel).Width, 0)
        End If
    End Sub

    Private Sub applyTheme()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.BackColor = currentTheme.BgColor
        Me.pnlTopPanel.BackColor = currentTheme.BgColorTop
        Me.flpBottomPanel.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.pnlTopPanel.BackgroundImage = currentTheme.BgImageTop
            Me.pnlTopPanel.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpBottomPanel.BackgroundImage = currentTheme.BgImageBottom
            Me.flpBottomPanel.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.pnlTopPanel.BackgroundImage = Nothing
            Me.flpBottomPanel.BackgroundImage = Nothing
        End If
        Me.Refresh()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub
#End Region

End Class