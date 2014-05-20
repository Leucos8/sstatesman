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
    Dim cmdStoreCheckAll As Button
    Dim cmdStoreCheckNone As Button
    Dim cmdStoreCheckInvert As Button
    Dim cmdStoreCheckBackup As Button

    Private Sub StoreList_FormLoad()
        Dim tmpAction As String = ""
        Select Case Me.currentOperationMode
            Case FileOperations.Store
                Me.SourcePath = SSMGameList.Folders(ListMode.Savestates)
                Me.DestPath = SSMGameList.Folders(ListMode.Stored)
                Me.Text = "Store savestates"
                tmpAction = "store"
            Case FileOperations.Restore
                Me.SourcePath = SSMGameList.Folders(ListMode.Stored)
                Me.DestPath = SSMGameList.Folders(ListMode.Savestates)
                Me.Text = "Restore savestates"
                tmpAction = "restore"
        End Select

        Me.Text = tmpAction & " savestates"
        Me.FormDescription = String.Format("check the savestates you want to {0} and press ""{0} checked"" to confirm.", tmpAction)
        Me.cmdSortReset.Visible = False
        Me.ckbSStatesManMoveToTrash.Visible = False
        Me.ckbSStatesManReorderBackup.Visible = False
        Me.ckbStoreCopy.Visible = True
        Me.lblAction.Text = "check savestates"
        Me.lblStatus2.Visible = False
        Me.lblStatus3.Visible = False

        Me.cmdStoreCheckAll = Me.cmdCommand2
        Me.cmdStoreCheckAll.Text = "ALL"
        Me.cmdStoreCheckAll.Image = My.Resources.Icon_CheckAll
        AddHandler cmdStoreCheckAll.Click, AddressOf cmdStoreCheckAll_Click

        Me.cmdStoreCheckNone = Me.cmdCommand3
        Me.cmdStoreCheckNone.Text = "NONE"
        Me.cmdStoreCheckNone.Image = My.Resources.Icon_CheckNone
        AddHandler cmdStoreCheckNone.Click, AddressOf cmdStoreCheckNone_Click

        Me.cmdStoreCheckInvert = Me.cmdCommand4
        Me.cmdStoreCheckInvert.Text = "INVERT"
        Me.cmdStoreCheckInvert.Image = My.Resources.Icon_CheckInvert
        AddHandler cmdStoreCheckInvert.Click, AddressOf cmdStoreCheckInvert_Click

        Me.cmdStoreCheckBackup = Me.cmdCommand1
        Me.cmdStoreCheckBackup.Visible = False

        Me.cmdOperation.Text = (tmpAction & " checked").ToUpper
        AddHandler cmdOperation.Click, AddressOf cmdStore_Click

        Me.lvwFileList.Columns.AddRange({New ColumnHeader With {.Name = "chSlot", .Text = "Slot"}, _
                                         New ColumnHeader With {.Name = "chOldName", .Text = "Old name", .Width = 200}, _
                                         New ColumnHeader With {.Name = "chNewName", .Text = "New name", .Width = 200}, _
                                         New ColumnHeader With {.Name = "chStatus", .Text = "Status", .Width = 160} _
                                        })

        Me.StoreList_AddFiles()
        Me.StoreList_Preview()
        Me.StoreList_UpdateUI()
    End Sub

    Private Sub StoreList_FormUnload()
        RemoveHandler cmdStoreCheckAll.Click, AddressOf cmdStoreCheckAll_Click
        RemoveHandler cmdStoreCheckNone.Click, AddressOf cmdStoreCheckNone_Click
        RemoveHandler cmdStoreCheckInvert.Click, AddressOf cmdStoreCheckInvert_Click

        RemoveHandler cmdOperation.Click, AddressOf cmdStore_Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
    End Sub

    Private Sub cmdStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.StoreList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        Me.SourceFileNames = New List(Of String)
        Me.DestFileNames = New List(Of String)
        For Each tmpListItem As ListViewItem In Me.lvwFileList.CheckedItems
            If FileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                Me.SourceFileNames.Add(tmpListItem.SubItems(FileListColumns.OldName).Text)
                Me.DestFileNames.Add(tmpListItem.SubItems(FileListColumns.NewName).Text)
            End If
        Next

        FileOps_MoveFiles(SourceFileNames, DestFileNames, SourcePath, DestPath, OperationResults, OperationResultMessages, True, My.Settings.SStatesMan_MoveStoredInsteadOfCopy)
        Me.OperationDone = True

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
                Dim tmpListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpFile.Value.Number.ToString, _
                                                                               .Group = pListGroup, _
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
                    Select Case Me.currentOperationMode
                        Case FileOperations.Store
                            tmpListItem.SubItems(FileListColumns.NewName).Text = tmpListItem.SubItems(FileListColumns.OldName).Text & My.Settings.SStatesMan_StoredExt
                        Case FileOperations.Restore
                            tmpListItem.SubItems(FileListColumns.NewName).Text = tmpListItem.SubItems(FileListColumns.OldName).Text.Remove(tmpListItem.SubItems(FileListColumns.OldName).Text.Length - My.Settings.SStatesMan_StoredExt.Length, My.Settings.SStatesMan_StoredExt.Length)
                    End Select
                    tmpListItem.ForeColor = mdlTheme.currentTheme.AccentColorDark
                    If mdlMain.SafeExistFile(Path.Combine(DestPath, tmpListItem.SubItems(FileListColumns.NewName).Text)) Then
                        tmpListItem.SubItems(FileListColumns.Status).Text &= "File already exist, will be overwritten."
                    Else
                        tmpListItem.SubItems(FileListColumns.Status).Text = "Rename pending."
                    End If
                    Count_RenamePending += 1

                ElseIf FileStatus.FileRenamed.Equals(tmpListItem.Tag) Then
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

        Me.lblStatus1.Text = String.Format("{0:N0} files ({1:N0} checked)", Me.lvwFileList.Items.Count, Me.lvwFileList.CheckedItems.Count)

        If Me.OperationDone OrElse Me.lvwFileList.Items.Count = 0 Then
            '================
            'No files in list
            '================

            Me.cmdStoreCheckAll.Enabled = False
            Me.cmdStoreCheckInvert.Enabled = False
            Me.cmdStoreCheckNone.Enabled = False

            Me.cmdStoreCheckAll.Visible = True
            Me.cmdStoreCheckInvert.Visible = True
            Me.cmdStoreCheckNone.Visible = True

            Me.cmdOperation.Enabled = False

            SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "No files in list. This shouldn't be happening.")
        Else
            '=================
            'Files are present
            '=================
            Me.cmdStoreCheckInvert.Enabled = True

            If Me.lvwFileList.CheckedItems.Count > 0 Then
                'At least one file is checked
                Me.cmdStoreCheckNone.Enabled = True

                Me.cmdOperation.Enabled = True

                If Me.lvwFileList.Items.Count = Me.lvwFileList.CheckedItems.Count Then
                    'All files are checked
                    Me.cmdStoreCheckAll.Enabled = False
                Else
                    Me.cmdStoreCheckAll.Enabled = True
                End If

            Else
                'No files are checked
                Me.cmdStoreCheckNone.Enabled = False
                Me.cmdStoreCheckAll.Enabled = True

                Me.cmdOperation.Enabled = False
            End If

            Me.cmdStoreCheckAll.Visible = Me.cmdStoreCheckAll.Enabled
            Me.cmdStoreCheckNone.Visible = Me.cmdStoreCheckNone.Enabled
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
End Class
