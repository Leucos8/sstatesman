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

Public NotInheritable Class frmFileOperations
    Friend FileListMode As FileOperations = FileOperations.Reorder

    Dim MoveStep As Integer = 1
    Dim Count_Files As Integer = 0
    Dim Count_RenamePending As Integer = 0

    ''Current size in bytes of the selected items
    'Dim FileList_SelectedSize As Long = 0
    'Dim FileList_SelectedSizeBackup As Long = 0
    'Dim FileList_TotalSize As Long = 0
    'Dim FileList_TotalSizeBackup As Long = 0

    Const UnknownCRC As String = "00000000"
    Dim currentCRC As String = UnknownCRC
    Dim currentSerial As String = String.Empty
    Dim minSlot, maxSlot As Integer

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

    Enum FileStatus
        FreeSlot        'No savestate
        Idle            'Current file name matches new name
        RenamePending   'Current file name is different from new name
        Renamed         'The file has been renamed succesfully
        FileNotFound    'The file has not been found when renaming
        FileAlreadyExist 'A file with the target name already exist
        OtherError      'Another error has been encountered
    End Enum

    Dim cmdMoveFirst As Button
    Dim cmdMoveUp As Button
    Dim cmdMoveDown As Button
    Dim cmdMoveLast As Button

    Dim cmdFileCheckAll As Button
    Dim cmdFileCheckNone As Button
    Dim cmdFileCheckInvert As Button
    Dim cmdFileCheckBackup As Button

#Region "Files Operation Rename/Move"
    ''' <summary>Safely move (rename) multiple files.</summary>
    ''' <param name="pSourceFileName">List of the original filenames.</param>
    ''' <param name="pDestFileName">List of the target filenames.</param>
    ''' <param name="pSourcePath">Path where input files are located.</param>
    ''' <param name="pDestPath">Path where output files will be located.</param>
    ''' <param name="pResults">List of results status flag.</param>
    ''' <param name="pResultMessages">List of message detailing the result of the operation.</param>
    ''' <param name="pOverwrite">Specifies how should be handled already existing target files</param>
    Private Sub FileOp_MoveFiles(pSourceFilename As List(Of String), pDestFilename As List(Of String), _
                                 pSourcePath As String, pDestPath As String, _
                                 ByRef pResults As List(Of FileStatus), ByRef pResultMessages As List(Of String), _
                                 Optional pOverwrite As Boolean = False)
        'Two For Each loops that renames the files.
        'The first loop simply adds the ".tmp" extension to the file that needs to be renamed.
        'The second loop rename the files with their proper target filename.
        'Me.OperationDone = True means that all files have been renamed (reorder button is disabled).
        If pSourceFilename.Count > 0 AndAlso _
            pDestFilename.Count > 0 AndAlso _
            pSourceFilename.Count = pDestFilename.Count Then

            Dim tmpResult As FileStatus = FileStatus.RenamePending
            Dim tmpResultMessage As String = String.Empty
            pResults = New List(Of FileStatus)
            pResultMessages = New List(Of String)

            For i As Integer = 0 To pDestFilename.Count - 1
                Me.FileOp_MoveFile(pSourceFilename(i), Me.AddTmpExtension(pDestFilename(i)), _
                                   pSourcePath, pDestPath, tmpResult, tmpResultMessage, pOverwrite)
                pResults.Add(tmpResult)
                pResultMessages.Add(tmpResultMessage)
            Next i

            For i As Integer = 0 To pDestFilename.Count - 1
                If pResults(i) = FileStatus.Renamed Then
                    Me.FileOp_MoveFile(Me.AddTmpExtension(pDestFilename(i)), pDestFilename(i), _
                                       pDestPath, pDestPath, pResults(i), pResultMessages(i), pOverwrite)
                End If
            Next
        End If
        Me.OperationDone = True
    End Sub

    ''' <summary>Safely move (rename) a file.</summary>
    ''' <param name="pSourceFileName">Original file name.</param>
    ''' <param name="pDestFileName">Target file name.</param>
    ''' <param name="pSourcePath">Path where the input file is located.</param>
    ''' <param name="pDestPath">Path where the output file will be located.</param>
    ''' <param name="pResult">Result status flag.</param>
    ''' <param name="pResultMessage">Message detailing the result of the operation.</param>
    ''' <param name="pOverwrite">Specifies how should be handled already existing target files</param>
    Private Sub FileOp_MoveFile(pSourceFileName As String, pDestFileName As String, _
                                pSourcePath As String, pDestPath As String, _
                                ByRef pResult As FileStatus, ByRef pResultMessage As String, _
                                Optional pOverwrite As Boolean = False)
        Try
            Dim tmpSourceFileFullPath As String = Path.Combine(pSourcePath, pSourceFileName)
            Dim tmpDestFileFullPath As String = Path.Combine(pDestPath, pDestFileName)

            If File.Exists(tmpSourceFileFullPath) Then
                If Not (File.Exists(tmpDestFileFullPath)) Or pOverwrite Then
                    If File.Exists(tmpDestFileFullPath) Then
                        My.Computer.FileSystem.DeleteFile(tmpDestFileFullPath, _
                                                          FileIO.UIOption.OnlyErrorDialogs, _
                                                          FileIO.RecycleOption.SendToRecycleBin)
                    End If

                    File.Move(tmpSourceFileFullPath, tmpDestFileFullPath)
                    pResult = FileStatus.Renamed
                    pResultMessage = String.Format("File renamed successfully to {0}.", pDestFileName)
                    SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("File {0} renamed to {1}.", tmpSourceFileFullPath, tmpDestFileFullPath))
                Else
                    pResult = FileStatus.FileAlreadyExist
                    pResultMessage = String.Format("Target file {0} already exist. Renaming skipped.", pDestFileName)
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("Renaming of {0} skipped. Target file {1} already exist.", tmpSourceFileFullPath, tmpDestFileFullPath))
                End If
            Else
                pResult = FileStatus.FileNotFound
                pResultMessage = String.Format("File {0} not found.", pSourceFileName)
                SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                 String.Format("File {1} not found.", tmpSourceFileFullPath))
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pResult = FileStatus.OtherError
            pResultMessage = String.Format("Error renaming {0} to {1}. {2}", pSourceFileName, pDestFileName, ex.Message)
            SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                             String.Format("Error renaming {0} to {1}. {2}", pSourceFileName, pDestFileName, ex.Message))
        End Try
    End Sub

    Private Function AddTmpExtension(pFilename As String) As String
        Const tmpExtension As String = ".tmp"
        Return pFilename & tmpExtension
    End Function
#End Region

#Region "Reorder"
    Private Sub ReorderList_AddFiles()
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
                                                            .Tag = FileStatus.FreeSlot}
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

    Private Sub ReorderList_Preview()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If Me.lvwFileList.Items.Count > 0 Then
            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
            Me.lvwFileList.BeginUpdate()

            Me.Count_RenamePending = 0

            For Each tmpListItem As ListViewItem In Me.lvwFileList.Items

                If FileStatus.FreeSlot.Equals(tmpListItem.Tag) Then
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

                ElseIf FileStatus.Renamed.Equals(tmpListItem.Tag) Then
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
        Debug.Print(New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)
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

            Me.ReorderList_UpdateUI()
        End If
    End Sub

    ''' <summary>Updates the UI status.</summary>
    Private Sub ReorderList_UpdateUI()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = String.Format("{0:N0} | {1:N0} items", Me.lvwFileList.CheckedItems.Count, Me.lvwFileList.Items.Count)
        Me.txtSize.Text = String.Format("{0:N0} | {1:N0} files", Me.Count_RenamePending, Me.Count_Files)

        Me.flpFileListCommandsFiles.SuspendLayout()

        If Me.OperationDone Or Me.lvwFileList.Items.Count = 0 Then
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

            If Me.lvwFileList.CheckedItems.Count > 0 Then
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

    Private Sub cmdMoveUp_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        'At least one item needs to be checked
        If Me.lvwFileList.CheckedItems.Count > 0 Then
            Me.MoveListItems(lvwFileList, -MoveStep)        'Move one position up
            Me.lvwFileList.CheckedItems(0).EnsureVisible()  'Visibility
        End If

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.ReorderList_Preview()
        Me.ReorderList_UpdateUI()
    End Sub

    Private Sub cmdMoveDown_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        'At least one item needs to be checked
        If Me.lvwFileList.CheckedItems.Count > 0 Then
            Me.MoveListItems(Me.lvwFileList, MoveStep)        'Move one position down
            Me.lvwFileList.CheckedItems(Me.lvwFileList.CheckedItems.Count - 1).EnsureVisible()  'Visibility
        End If

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.ReorderList_Preview()
        Me.ReorderList_UpdateUI()
    End Sub

    Private Sub cmdMoveFirst_Click(sender As Object, e As EventArgs)
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

        Me.ReorderList_Preview()
        Me.ReorderList_UpdateUI()
    End Sub

    Private Sub cmdMoveLast_Click(sender As Object, e As EventArgs)
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

        Me.ReorderList_Preview()
        Me.ReorderList_UpdateUI()
    End Sub

    Private Sub cmdSortReset_Click(sender As Object, e As EventArgs) Handles cmdSortReset.Click
        Me.ReorderList_AddFiles()
        Me.ReorderList_Preview()
        Me.ReorderList_UpdateUI()
    End Sub
#End Region
#End Region

#Region "Store/Restore"
    Private Sub StoreList_AddFiles()
        Dim sw As New Stopwatch
        sw.Start()

        'Me.FileList_TotalSize = 0
        'Me.FileList_TotalSizeBackup = 0

        'clear items and groups.
        Me.lvwFileList.Items.Clear()
        Me.lvwFileList.Groups.Clear()

        Dim tmpGameInfo As New GameInfo
        Dim tmpListGroups As New List(Of ListViewGroup)
        Dim tmpListItems As New List(Of ListViewItem)

        For Each tmpSerial As System.String In frmMain.checkedGames

            If SSMGameList.Games.ContainsKey(tmpSerial) Then
                If SSMGameList.Games(tmpSerial).GameFiles.ContainsKey(frmMain.CurrentListMode) AndAlso _
                    SSMGameList.Games(tmpSerial).GameFiles(frmMain.CurrentListMode).Count > 0 Then
                    'Creation of the header
                    tmpGameInfo = PCSX2GameDb.GetGameInfo(tmpSerial)
                    Dim tmpListGroup As New System.Windows.Forms.ListViewGroup With {
                        .Header = tmpGameInfo.ToString(),
                        .HeaderAlignment = HorizontalAlignment.Left,
                        .Name = tmpGameInfo.Serial}

                    tmpListGroups.Add(tmpListGroup)

                    Me.StoreList_CreateListItems(SSMGameList.Games(tmpSerial).GameFiles(frmMain.CurrentListMode), tmpListGroup, tmpListItems)
                Else
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Checked game " & tmpSerial & " has no savestates.")
                End If

            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Game not found in list: " & tmpSerial & ".")
            End If
        Next

        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        Me.lvwFileList.Groups.AddRange(tmpListGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpListItems)
        Me.lvwFileList.Items.AddRange(tmpListItems.ToArray)

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.EndUpdate()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} savestates.", Me.lvwFileList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub StoreList_CreateListItems(pFile As Dictionary(Of String, PCSX2File), pListGroup As ListViewGroup, ByRef pListItems As List(Of ListViewItem))
        For Each tmpFile As KeyValuePair(Of String, PCSX2File) In pFile

            If frmMain.checkedFiles(frmMain.CurrentListMode).Contains(tmpFile.Key) Then
                Dim tmpListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpFile.Value.Number.ToString,
                                                                               .Group = pListGroup,
                                                                               .Name = tmpFile.Key}
                tmpListItem.SubItems.AddRange({tmpFile.Key, tmpFile.Key})

                If mdlMain.SafeExistFile(Path.Combine(SourcePath, tmpFile.Key)) Then
                    tmpListItem.SubItems.Add(String.Empty)
                    tmpListItem.Checked = True

                    Select Case frmMain.CurrentListMode
                        Case ListMode.Savestates
                            If tmpListItem.Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                                tmpListItem.ImageIndex = 1
                                'Me.FileList_TotalSizeBackup += tmpFile.Value.Length
                            Else
                                tmpListItem.ImageIndex = 0
                                'Me.FileList_TotalSize += tmpFile.Value.Length
                            End If
                        Case ListMode.Stored
                            tmpListItem.ImageIndex = 0
                            'Me.FileList_TotalSize += tmpFile.Value.Length
                            'Case ListMode.Snapshots
                            '    tmpListItem.ImageIndex = 2
                            '    Me.FileList_TotalSize += tmpFile.Value.Length
                    End Select

                    tmpListItem.BackColor = Color.Transparent
                    tmpListItem.Tag = FileStatus.RenamePending
                Else
                    tmpListItem.SubItems.Add("File not found or inaccessible.")
                    tmpListItem.Checked = False
                    tmpListItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                    tmpListItem.Tag = FileStatus.FileNotFound
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "File not found: " & tmpFile.Value.Name & ".")
                End If

                pListItems.Add(tmpListItem)
            End If
        Next
    End Sub

    Private Sub StoreList_Preview()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If Me.lvwFileList.Items.Count > 0 Then
            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
            Me.lvwFileList.BeginUpdate()

            Me.Count_RenamePending = 0

            For Each tmpListItem As ListViewItem In Me.lvwFileList.Items

                If FileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                    'A new filename needs to be assigned
                    Select Case Me.FileListMode
                        Case FileOperations.Store
                            tmpListItem.SubItems(FileListColumns.NewName).Text = tmpListItem.SubItems(FileListColumns.OldName).Text & My.Settings.SStatesMan_StoredExt
                        Case FileOperations.Restore
                            tmpListItem.SubItems(FileListColumns.NewName).Text = tmpListItem.SubItems(FileListColumns.OldName).Text.Remove(tmpListItem.SubItems(FileListColumns.OldName).Text.Length - My.Settings.SStatesMan_StoredExt.Length, My.Settings.SStatesMan_StoredExt.Length)
                    End Select
                    tmpListItem.ForeColor = mdlTheme.currentTheme.AccentColorDark
                    If mdlMain.SafeExistFile(Path.Combine(DestPath, tmpListItem.SubItems(FileListColumns.NewName).Text)) Then
                        tmpListItem.SubItems(FileListColumns.Status).Text &= "File already exist, will be overwritten."
                        tmpListItem.Tag = FileStatus.FileAlreadyExist
                    End If
                    tmpListItem.SubItems(FileListColumns.Status).Text = "Rename pending."
                    Count_RenamePending += 1

                ElseIf FileStatus.Renamed.Equals(tmpListItem.Tag) Then
                    tmpListItem.BackColor = Color.FromArgb(150, 200, 130)

                ElseIf FileStatus.FileNotFound.Equals(tmpListItem.Tag) Or _
                    FileStatus.OtherError.Equals(tmpListItem.Tag) Then
                    tmpListItem.BackColor = Color.FromArgb(255, 192, 192)
                End If
            Next

            AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
            Me.lvwFileList.EndUpdate()
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Preview, _
                         String.Format("Preview for {0:N0} ListViewItems.", Me.Count_RenamePending), _
                         sw.ElapsedTicks)
    End Sub

    Private Sub StoreList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        Debug.Print(New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)
        If DirectCast(sender, ListView).Items(DirectCast(sender, ListView).Items.Count - 1) IsNot Nothing Then
            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked

            If Me.OperationDone OrElse Not (FileStatus.RenamePending.Equals(e.Item.Tag)) Then
                e.Item.Checked = False
            End If

            AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked

            Me.StoreList_UpdateUI()
        End If
    End Sub

    ''' <summary>Updates the UI status.</summary>
    Private Sub StoreList_UpdateUI()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = String.Format("{0:N0} | {1:N0} files", Me.lvwFileList.CheckedItems.Count, Me.lvwFileList.Items.Count)
        'Me.txtSize.Text = String.Format("{0:N0} | {1:N0} files", Me.Count_RenamePending, Me.lvwFileList.Items.Count)

        If Me.OperationDone OrElse Me.lvwFileList.Items.Count = 0 Then
            '================
            'No files in list
            '================

            Me.cmdFileCheckAll.Enabled = False
            Me.cmdFileCheckInvert.Enabled = False
            Me.cmdFileCheckNone.Enabled = False

            Me.cmdFileCheckAll.Visible = True
            Me.cmdFileCheckInvert.Visible = True
            Me.cmdFileCheckNone.Visible = True

            Me.cmdReorder.Enabled = False

            SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "No files in list. This shouldn't be happening.")
        Else
            '=================
            'Files are present
            '=================
            Me.cmdFileCheckInvert.Enabled = True

            If Me.lvwFileList.CheckedItems.Count > 0 Then
                'At least one file is checked
                Me.cmdFileCheckNone.Enabled = True

                Me.cmdReorder.Enabled = True

                If Me.lvwFileList.Items.Count = Me.lvwFileList.CheckedItems.Count Then
                    'All files are checked
                    Me.cmdFileCheckAll.Enabled = False
                Else
                    Me.cmdFileCheckAll.Enabled = True
                End If

            Else
                'No files are checked
                Me.cmdFileCheckNone.Enabled = False
                Me.cmdFileCheckAll.Enabled = True

                Me.cmdReorder.Enabled = False
            End If

            Me.cmdFileCheckAll.Visible = Me.cmdFileCheckAll.Enabled
            Me.cmdFileCheckNone.Visible = Me.cmdFileCheckNone.Enabled
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub
#Region "Store/Restore commands"
    Private Sub cmdStoreCheckAll_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For ListItemIndex As Integer = 0 To Me.lvwFileList.Items.Count - 1
            If FileStatus.RenamePending.Equals(Me.lvwFileList.Items.Item(ListItemIndex).Tag) Then
                Me.lvwFileList.Items.Item(ListItemIndex).Checked = True
            End If
        Next
        Me.StoreList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

    Private Sub cmdStoreCheckNone_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFileList.Items.Count - 1
            Me.lvwFileList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.StoreList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

    Private Sub cmdStoreCheckInvert_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFileList.Items.Count - 1
            If FileStatus.RenamePending.Equals(Me.lvwFileList.Items.Item(lvwItemIndex).Tag) Then
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = Not (Me.lvwFileList.Items.Item(lvwItemIndex).Checked)
            Else
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.StoreList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

#End Region
#End Region

#Region "Form"
    Private Sub frmReorderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub frmReorderForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        Me.txtSizeBackup.Visible = False

        Select Case pOperationMode
            Case FileOperations.Reorder
                Me.FormDescription = "use the move buttons to reorder the list and click ""reorder"" to confirm."
                Me.lblSelected.Text = "selection"
                Me.lblSize.Text = "active"
                Me.lblSize.Visible = True
                Me.txtSize.Visible = True

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
                Me.txtSize.Visible = False
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
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
#End Region

#Region "Form - Commands"
    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.ReorderList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        Me.SourceFileNames.Clear()
        Me.DestFileNames.Clear()
        For Each tmpListItem As ListViewItem In Me.lvwFileList.Items
            If FileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                Me.SourceFileNames.Add(tmpListItem.SubItems(FileListColumns.OldName).Text)
                Me.DestFileNames.Add(tmpListItem.SubItems(FileListColumns.NewName).Text)
            End If
        Next
        Me.FileOp_MoveFiles(SourceFileNames, DestFileNames, SourcePath, DestPath, OperationResults, OperationResultMessages)

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

        Me.ReorderList_Preview()
        frmMain.GameList_Refresh()
        Me.ReorderList_UpdateUI()
    End Sub

    Private Sub cmdStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        Me.SourceFileNames.Clear()
        Me.DestFileNames.Clear()
        For Each tmpListItem As ListViewItem In Me.lvwFileList.CheckedItems
            If FileStatus.RenamePending.Equals(tmpListItem.Tag) Or FileStatus.FileAlreadyExist.Equals(tmpListItem.Tag) Then
                Me.SourceFileNames.Add(tmpListItem.SubItems(FileListColumns.OldName).Text)
                Me.DestFileNames.Add(tmpListItem.SubItems(FileListColumns.NewName).Text)
            End If
        Next

        Me.FileOp_MoveFiles(SourceFileNames, DestFileNames, SourcePath, DestPath, OperationResults, OperationResultMessages, True)

        Dim i As Integer = 0
        For Each tmpListItem As ListViewItem In Me.lvwFileList.CheckedItems
            tmpListItem.Tag = OperationResults(i)
            tmpListItem.SubItems(FileListColumns.Status).Text = OperationResultMessages(i)
            i += 1
            tmpListItem.Checked = False
        Next

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.StoreList_Preview()
        frmMain.GameList_Refresh()
        Me.StoreList_UpdateUI()
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
            Me.ReorderList_UpdateUI()
        End If
    End Sub
#End Region

End Class