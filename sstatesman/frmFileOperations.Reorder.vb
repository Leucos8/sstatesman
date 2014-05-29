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
Public NotInheritable Class frmFileOperationsReorder
    Inherits frmFileOperations
    Dim MoveStep As Integer = 1
    Dim Count_Files As Integer = 0
    Dim Count_RenamePending As Integer = 0

    Const UnknownCRC As String = "00000000"
    Dim currentCRC As String = UnknownCRC
    Dim currentSerial As String = String.Empty
    Dim minSlot, maxSlot As Integer

    Dim cmdMoveFirst As Button
    Dim cmdMoveUp As Button
    Dim cmdMoveDown As Button
    Dim cmdMoveLast As Button

    Protected Overrides Sub OperationLoad()
        MyBase.OperationLoad()

        Me.SourcePath = SSMGameList.Folders(frmMain.CurrentListMode)
        Me.DestPath = Me.SourcePath

        Me.Text = "Reorder savestates"
        Me.FormDescription = "use the move buttons to reorder the list and click ""reorder"" to confirm."
        Me.cmdSortReset.Visible = True
        Me.ckbSStatesManReorderBackup.Visible = True
        Me.ckbSStatesManMoveToTrash.Visible = False
        Me.ckbStoreCopy.Visible = False
        Me.lblAction.Text = "move checked"
        Me.lblStatus2.Visible = True
        Me.lblStatus3.Visible = False

        Me.cmdMoveUp = Me.cmdCommand2
        Me.cmdMoveUp.Text = "UP"
        Me.cmdMoveUp.Image = My.Resources.Icon_OrderUp
        Me.cmdMoveUp.Visible = True

        Me.cmdMoveDown = Me.cmdCommand3
        Me.cmdMoveDown.Text = "DOWN"
        Me.cmdMoveDown.Image = My.Resources.Icon_OrderDown
        Me.cmdMoveDown.Visible = True

        Me.cmdMoveFirst = Me.cmdCommand1
        Me.cmdMoveFirst.Text = "FIRST"
        Me.cmdMoveFirst.Image = My.Resources.Icon_OrderFirst
        Me.cmdMoveFirst.Visible = True

        Me.cmdMoveLast = Me.cmdCommand4
        Me.cmdMoveLast.Text = "LAST"
        Me.cmdMoveLast.Image = My.Resources.Icon_OrderLast
        Me.cmdMoveFirst.Visible = True

        Me.cmdOperation.Text = "Reorder".ToUpper

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

        Me.OperationListFiles()
        Me.OperationListPreview()
        Me.OperationUpdateUI()
    End Sub

    Protected Overrides Sub OperationUnload()
        MyBase.OperationUnload()

        'RemoveHandler cmdMoveFirst.Click, AddressOf cmdMoveFirst_Click
        'RemoveHandler cmdMoveUp.Click, AddressOf cmdMoveUp_Click
        'RemoveHandler cmdMoveDown.Click, AddressOf cmdMoveDown_Click
        'RemoveHandler cmdMoveLast.Click, AddressOf cmdMoveLast_Click

        'RemoveHandler cmdOperation.Click, AddressOf cmdReorder_Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
    End Sub

    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOperation.Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        Me.SourceFileNames = New List(Of String)
        Me.DestFileNames = New List(Of String)
        For Each tmpListItem As ListViewItem In Me.lvwFileList.Items
            If FileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                Me.SourceFileNames.Add(tmpListItem.SubItems(FileListColumns.OldName).Text)
                Me.DestFileNames.Add(tmpListItem.SubItems(FileListColumns.NewName).Text)
            End If
        Next
        FileOps_MoveFiles(SourceFileNames, DestFileNames, SourcePath, DestPath, OperationResults, OperationResultMessages, False, False)
        Me.OperationDone = True

        Dim i As Integer = 0
        For Each tmpListItem As ListViewItem In Me.lvwFileList.Items
            If FileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                tmpListItem.Tag = OperationResults(i)
                tmpListItem.SubItems(FileListColumns.Status).Text = OperationResultMessages(i)
                i += 1
            End If
            tmpListItem.Checked = False
        Next

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.OperationListPreview()
        frmMain.GameList_Refresh()
        Me.OperationUpdateUI()
    End Sub

    Private Sub ckbSStatesManReorderBackup_CheckedChanged(sender As Object, e As EventArgs) Handles ckbSStatesManReorderBackup.CheckedChanged
        'Prevent firing during load
        If DirectCast(sender, CheckBox).IsHandleCreated Then

            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
            Me.lvwFileList.BeginUpdate()
            'Unchecking items.
            For lvwItemIndex = 0 To Me.lvwFileList.Items.Count - 1
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = False
            Next

            'MoveStep (1 = move one item each time, 2 = move two items together - savestate and backup)
            If DirectCast(sender, CheckBox).Checked Then
                Me.MoveStep = 2
            Else
                Me.MoveStep = 1
            End If

            AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
            Me.lvwFileList.EndUpdate()
            Me.OperationUpdateUI()
        End If
    End Sub

    Protected Overrides Sub OperationListFiles()
        MyBase.OperationListFiles()

        Dim sw As New Stopwatch
        sw.Start()

        'clear items and groups.
        Me.lvwFileList.Items.Clear()
        Me.lvwFileList.Groups.Clear()

        'only one game need to be checked
        If frmMain.checkedGames.Count = 1 Then
            'GameList contains the serial
            If SSMGameList.Games.ContainsKey(frmMain.checkedGames(0)) Then

                'Some info of the game checked
                Me.currentSerial = frmMain.checkedGames(0)
                Me.currentCRC = SSMGameList.Games(Me.currentSerial).GameCRC

                'Creation of the header
                Dim tmpGameInfo As New mdlGameDb.GameInfo
                tmpGameInfo = PCSX2GameDb.GetGameInfo(Me.currentSerial)
                Dim tmpListGroup As New System.Windows.Forms.ListViewGroup With {
                    .Header = tmpGameInfo.ToString(),
                    .HeaderAlignment = HorizontalAlignment.Left,
                    .Name = Me.currentSerial}

                Dim tmpLvItems As New List(Of ListViewItem)

                'Creation of the available slots
                Select Case frmMain.CurrentListMode
                    Case ListMode.Savestates
                        minSlot = My.Settings.PCSX2_SStateSlotLowerBound
                        maxSlot = My.Settings.PCSX2_SStateSlotUpperBound
                    Case ListMode.Stored
                        minSlot = My.Settings.SStatesMan_StoredSlotLowerBound
                        maxSlot = My.Settings.SStatesMan_StoredSlotUpperBound
                    Case Else
                        Me.Close()
                End Select

                'maxSlot - minSlot + 1              number of slot available, + 1 is for the first slot
                '[number of slot] * 2               in order to include backups
                '[number of slot & backup] - 1      loop starts with 0
                For i As Integer = 0 To (maxSlot - minSlot + 1) * 2 - 1
                    'minSlot + i \ 2 = current slot number
                    Dim tmpLvItem As New ListViewItem With {.Text = (minSlot + i \ 2).ToString, _
                                                            .Group = tmpListGroup, _
                                                            .Tag = FileStatus.NoFile}
                    If Not ((i Mod 2) > 0) Then
                        tmpLvItem.ImageIndex = 0
                    Else
                        tmpLvItem.ImageIndex = 1
                    End If
                    tmpLvItem.SubItems.AddRange({"-", "-", String.Empty})
                    tmpLvItems.Add(tmpLvItem)
                Next

                'Adding files
                Dim listRef As Integer = 0  'Used for list index
                For Each tmpFile As KeyValuePair(Of String, PCSX2File) In SSMGameList.Games(currentSerial).GameFiles(frmMain.CurrentListMode)
                    listRef = tmpFile.Value.Number
                    If (listRef >= minSlot) And (listRef <= maxSlot) Then
                        'Even numbers are for normal savestates
                        listRef -= minSlot  'Rebase to 0
                        listRef *= 2
                        If tmpFile.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup) Or _
                            tmpFile.Value.Name.EndsWith(My.Settings.PCSX2_SStateExtBackup & My.Settings.SStatesMan_StoredExt) Then
                            'Odd numbers are for backups
                            listRef += 1
                        End If

                        'Old name = new name, status idle
                        tmpLvItems.Item(listRef).SubItems(FileListColumns.OldName).Text = tmpFile.Value.Name
                        tmpLvItems.Item(listRef).SubItems(FileListColumns.NewName).Text = tmpFile.Value.Name
                        tmpLvItems.Item(listRef).Tag = FileStatus.Idle
                    Else
                        'This savestate has an out of bounds index, a new list item is added
                        'Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = "Other", _
                        '                                                                   .Tag = ReorderFileStatus.Idle, _
                        '                                                                   .Group = tmpListGroup, _
                        '                                                                   .ImageIndex = 0, _
                        '                                                                   .Font = New Font(Me.lvwFileList.Font, FontStyle.Bold)}
                        'tmpLvwSListItem.SubItems.AddRange({tmpFile.Value.Name, tmpFile.Value.Name, ""})
                        'tmpListItemS.Add(tmpLvwSListItem)
                        SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                         String.Format("Slot value not valid for {0}.", tmpFile.Value.Name))
                    End If
                Next

                mdlTheme.ListAlternateColors(tmpLvItems, 2)

                Me.Count_Files = SSMGameList.Games(Me.currentSerial).GameFiles(frmMain.CurrentListMode).Count

                RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
                Me.lvwFileList.BeginUpdate()

                Me.lvwFileList.Groups.Add(tmpListGroup)
                Me.lvwFileList.Items.AddRange(tmpLvItems.ToArray)

                AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
                Me.lvwFileList.EndUpdate()

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
                         String.Format("Listed {0:N0} {1}.", Me.lvwFileList.Items.Count, frmMain.CurrentListMode.ToString), sw.ElapsedTicks)
    End Sub

    Protected Overrides Sub OperationListPreview()
        MyBase.OperationListPreview()

        Dim sw As Stopwatch = Stopwatch.StartNew

        If Me.lvwFileList.Items.Count > 0 Then
            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
            Me.lvwFileList.BeginUpdate()

            Me.Count_RenamePending = 0

            For Each tmpListItem As ListViewItem In Me.lvwFileList.Items

                If FileStatus.NoFile.Equals(tmpListItem.Tag) Then
                    'Free slot, no savestate
                    tmpListItem.SubItems(FileListColumns.NewName).Text = "-"
                    tmpListItem.ForeColor = Color.DimGray
                    tmpListItem.SubItems(FileListColumns.Status).Text = String.Empty

                ElseIf FileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                    'A new filename needs to be assigned

                    tmpListItem.SubItems(FileListColumns.NewName).Text = Savestate.ToString(Savestate.GetGameSerial(tmpListItem.SubItems(FileListColumns.OldName).Text), _
                                                                                            Savestate.GetGameCRC(tmpListItem.SubItems(FileListColumns.OldName).Text), _
                                                                                            tmpListItem.Index \ 2 + minSlot, _
                                                                                            minSlot, maxSlot, _
                                                                                            CBool(tmpListItem.Index Mod 2))
                    If frmMain.CurrentListMode = ListMode.Stored Then
                        tmpListItem.SubItems(FileListColumns.NewName).Text &= My.Settings.SStatesMan_StoredExt
                    End If

                    If tmpListItem.SubItems(FileListColumns.OldName).Text = tmpListItem.SubItems(FileListColumns.NewName).Text Then
                        tmpListItem.Tag = FileStatus.Idle
                        tmpListItem.ForeColor = Me.ForeColor
                        tmpListItem.SubItems(FileListColumns.Status).Text = ""
                    Else
                        tmpListItem.ForeColor = mdlTheme.currentTheme.AccentColorDark
                        tmpListItem.SubItems(FileListColumns.Status).Text = "Rename pending."
                        Count_RenamePending += 1
                    End If

                ElseIf FileStatus.FileRenamed.Equals(tmpListItem.Tag) Then
                    tmpListItem.BackColor = Color.FromArgb(150, 200, 130)

                ElseIf FileStatus.FileAlreadyExist.Equals(tmpListItem.Tag) Then
                    tmpListItem.BackColor = Color.FromArgb(255, 255, 192)

                ElseIf FileStatus.FileNotFound.Equals(tmpListItem.Tag) Or _
                    FileStatus.OtherError.Equals(tmpListItem.Tag) Then
                    tmpListItem.BackColor = Color.FromArgb(255, 192, 192)
                End If
            Next

            AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
            Me.lvwFileList.EndUpdate()
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Preview, _
                         String.Format("Preview for {0:N0} ListViewItems.", Me.Count_RenamePending), _
                         sw.ElapsedTicks)
    End Sub

    Private Sub ReorderList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        Debug.Print(DateTime.Now & " " & New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)
        'Fixing ItemChecked firing unexpectedly.
        '=======================================
        'The first time the form is opened everything happens as expected. When AddRange is used to add the ListViewItems the ItemChecked event is 
        'fired immediatly for each item that has been added, before Form_Load is complete. 
        'Since I don't want the ItemChecked event firing during Form_Load, before using AddRange, I remove the event handler for ItemChecked, 
        'effectively preventing it from firing. After AddRange the event handler for ItemChecked is reattached.
        'The second time the form is opened something does not work in the same way. ItemChecked events are delayed after Form_Load is complete 
        '(after End Sub), meaning that the event handlers have already been reattached. But the state of the ListView control is inconsistent:
        '- if I try to access the items from another Sub or Function everything is fine.
        '- if I try to access the items (in fact only the items added after the one in e.Item are inaccessible) in the ItemChecked Sub I get a 
        '  System.NullReference exception, while accessing the Items.Count property says that all the items have been added.
        'Solution: check if the last item is nothing!
        If DirectCast(sender, ListView).Items(DirectCast(sender, ListView).Items.Count - 1) Is Nothing Then
            Exit Sub
        Else
            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked

            If Me.OperationDone Then
                e.Item.Checked = False
            Else
                'If user wants the savestate to be moved together with its backup
                If My.Settings.SStatesMan_SStateReorderBackup Then

                    Dim tmpToBeCheckedIndex As Integer = -1

                    If (e.Item.Index Mod 2) > 0 Then
                        'Backup
                        tmpToBeCheckedIndex = e.Item.Index - 1  'Will be selected the previous one, the savestate
                    Else
                        'Standard
                        tmpToBeCheckedIndex = e.Item.Index + 1  'Will be selected the next one, the backup
                    End If


                    If DirectCast(sender, ListView).Items(tmpToBeCheckedIndex) IsNot Nothing AndAlso _
                        Not (DirectCast(sender, ListView).Items(tmpToBeCheckedIndex).Checked = e.Item.Checked) Then
                        DirectCast(sender, ListView).Items(tmpToBeCheckedIndex).Checked = e.Item.Checked
                    End If


                End If
            End If
            AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked

            Me.OperationUpdateUI()
        End If
    End Sub

    Protected Overrides Sub OperationUpdateUI()
        MyBase.OperationUpdateUI()

        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.lblStatus1.Text = String.Format("{0:N0} items ({1:N0} checked)", Me.lvwFileList.Items.Count, Me.lvwFileList.CheckedItems.Count)
        Me.lblStatus2.Text = String.Format("{0:N0} file ({1:N0} active)", Me.Count_Files, Me.Count_RenamePending)

        If Me.OperationDone Or Me.lvwFileList.Items.Count = 0 Then
            '==========================================
            'No files in list or file have been renamed
            '==========================================
            Me.lblStatus1.Text = String.Empty
            Me.lblStatus2.Text = String.Empty

            Me.cmdMoveUp.Enabled = False
            Me.cmdMoveLast.Enabled = False
            Me.cmdMoveDown.Enabled = False
            Me.cmdMoveFirst.Enabled = False

            Me.cmdSortReset.Enabled = False

            Me.cmdOperation.Enabled = False
        Else
            '=================
            'Files are present
            '=================
            If Me.Count_RenamePending > 0 Then
                Me.lblStatus2.Text = String.Format("{0:N0} file ({1:N0} active)", Me.Count_Files, Me.Count_RenamePending)
                Me.cmdOperation.Enabled = True
                Me.cmdSortReset.Enabled = True
            Else
                Me.lblStatus2.Text = String.Format("{0:N0} file", Me.Count_Files)
                Me.cmdOperation.Enabled = False
                Me.cmdSortReset.Enabled = False
            End If

            If Me.lvwFileList.CheckedItems.Count > 0 Then
                Me.lblStatus1.Text = String.Format("{0:N0} items ({1:N0} checked)", Me.lvwFileList.Items.Count, Me.lvwFileList.CheckedItems.Count)
                'First item checked
                If Me.lvwFileList.Items(0).Checked Then
                    Me.cmdMoveFirst.Enabled = False
                    Me.cmdMoveUp.Enabled = False
                Else
                    Me.cmdMoveFirst.Enabled = True
                    Me.cmdMoveUp.Enabled = True
                End If

                'Move down should work as per list items.
                If Me.lvwFileList.Items(Me.lvwFileList.Items.Count - 1).Checked Then
                    Me.cmdMoveDown.Enabled = False
                Else
                    Me.cmdMoveDown.Enabled = True
                End If
                'Last file should have regular slot number.
                If Me.lvwFileList.Items((maxSlot - minSlot + 1) * 2 - 1).Checked Then
                    Me.cmdMoveLast.Enabled = False
                    If My.Settings.SStatesMan_SStateReorderBackup Then
                        Me.cmdMoveDown.Enabled = False
                    End If
                Else
                    Me.cmdMoveLast.Enabled = True
                End If


            ElseIf Me.lvwFileList.CheckedItems.Count = 0 Then
                Me.lblStatus1.Text = String.Format("{0:N0} items", Me.lvwFileList.Items.Count)
                Me.cmdMoveUp.Enabled = False
                Me.cmdMoveLast.Enabled = False
                Me.cmdMoveDown.Enabled = False
                Me.cmdMoveFirst.Enabled = False
            End If

        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub

#Region "Reorder Commands"
    ''' <summary>Moves the checked items in pListView by the amount of pStep.</summary>
    ''' <param name="pListView">ListView containing the items.</param>
    ''' <param name="pStep">How much the items will be moved.</param>
    ''' <remarks>Only some properties are moved, not everything!</remarks>
    Private Sub MoveListItems(ByRef pListView As ListView, pStep As Integer)
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
                Dim tmpOldName As String = tmpItemChecked.SubItems(FileListColumns.OldName).Text
                Dim tmpTag As FileStatus = DirectCast(tmpItemChecked.Tag, FileStatus)
                'Swapping names
                tmpItemChecked.SubItems(FileListColumns.OldName).Text = tmpItemSwapped.SubItems(FileListColumns.OldName).Text
                tmpItemSwapped.SubItems(FileListColumns.OldName).Text = tmpOldName
                'Tags
                tmpItemChecked.Tag = tmpItemSwapped.Tag
                tmpItemSwapped.Tag = tmpTag
                If FileStatus.Idle.Equals(tmpItemChecked.Tag) Then
                    tmpItemChecked.Tag = FileStatus.RenamePending
                End If
                If FileStatus.Idle.Equals(tmpItemSwapped.Tag) Then
                    tmpItemSwapped.Tag = FileStatus.RenamePending
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

    Private Sub cmdMoveUp_Click(sender As Object, e As EventArgs) Handles cmdCommand2.Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        'At least one item needs to be checked
        If Me.lvwFileList.CheckedItems.Count > 0 Then
            Me.MoveListItems(lvwFileList, -MoveStep)        'Move one position up
            Me.lvwFileList.CheckedItems(0).EnsureVisible()  'Visibility
        End If

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.OperationListPreview()
        Me.OperationUpdateUI()
    End Sub

    Private Sub cmdMoveDown_Click(sender As Object, e As EventArgs) Handles cmdCommand3.Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        'At least one item needs to be checked
        If Me.lvwFileList.CheckedItems.Count > 0 Then
            Me.MoveListItems(Me.lvwFileList, MoveStep)        'Move one position down
            Me.lvwFileList.CheckedItems(Me.lvwFileList.CheckedItems.Count - 1).EnsureVisible()  'Visibility
        End If

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.OperationListPreview()
        Me.OperationUpdateUI()
    End Sub

    Private Sub cmdMoveFirst_Click(sender As Object, e As EventArgs) Handles cmdCommand1.Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        If Me.lvwFileList.CheckedItems.Count > 0 Then
            'Me.MoveLwItems(Me.lvwFileList, -Me.lvwFileList.checkedItems.Item(0).Index)
            For i As Integer = 0 To Me.lvwFileList.CheckedItems.Item(0).Index - 1 Step MoveStep   'Need to move step by step, if not weird sorting cand happen.
                Me.MoveListItems(Me.lvwFileList, -MoveStep)
            Next
            Me.lvwFileList.Items(0).EnsureVisible()
        End If

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.OperationListPreview()
        Me.OperationUpdateUI()
    End Sub

    Private Sub cmdMoveLast_Click(sender As Object, e As EventArgs) Handles cmdCommand4.Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        If Me.lvwFileList.CheckedItems.Count > 0 Then
            'Me.MoveLwItems(Me.lvwFileList, (Me.lvwFileList.Items.Count - 1) - Me.lvwFileList.checkedItems.Item(Me.lvwFileList.checkedItems.Count - 1).Index)
            '(SStateSlotUpperBound - SStateSlotLowerBound + 1) * 2 -1 = (9 - 0 + 1) * 2 -1 = 19 Gives the index of the last standard savestate.
            'CheckedItems.Item(CheckedItems.Count - 1).Index - 1 Gives the index of the last checked item. -1 at the end is added because 
            '*last index of standard savestate* - *last checked item index* gives the number of iterations, since the loop start with i = 0
            'the max needs to be *number of iteration* - 1.
            '-2 because there are two -1.
            For i As Integer = 0 To (maxSlot - minSlot + 1) * 2 - _
                Me.lvwFileList.CheckedItems.Item(Me.lvwFileList.CheckedItems.Count - 1).Index - 2 Step MoveStep
                Me.MoveListItems(Me.lvwFileList, MoveStep)
            Next
            Me.lvwFileList.CheckedItems.Item(Me.lvwFileList.CheckedItems.Count - 1).EnsureVisible()
        End If

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.OperationListPreview()
        Me.OperationUpdateUI()
    End Sub

    Private Sub cmdSortReset_Click(sender As Object, e As EventArgs) Handles cmdSortReset.Click
        Me.OperationListFiles()
        Me.OperationListPreview()
        Me.OperationUpdateUI()
    End Sub
#End Region

End Class
