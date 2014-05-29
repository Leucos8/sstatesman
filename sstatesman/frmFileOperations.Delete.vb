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
Partial Public NotInheritable Class frmFileOperationsDelete
    Inherits frmFileOperations
    Dim cmdDeleteCheckAll As Button
    Dim cmdDeleteCheckNone As Button
    Dim cmdDeleteCheckInvert As Button
    Dim cmdDeleteCheckBackup As Button

    'Current size in bytes of the selected items
    Dim DeleteList_SelectedSize As Long = 0
    Dim DeleteList_SelectedSizeBackup As Long = 0
    Dim DeleteList_TotalSize As Long = 0
    Dim DeleteList_TotalSizeBackup As Long = 0

    Protected Overrides Sub UI_OperationLoad()
        MyBase.UI_OperationLoad()
        ' TODO safer call to SSMGameList.Folders
        ' If the stored folder isn't set there may be exceptions.
        Me.SourcePath = SSMGameList.Folders(frmMain.CurrentListMode)

        Me.Text = "Delete confirmation"
        Me.FormDescription = "check the files you really want to delete and press ""delete checked"" to confirm."
        Me.cmdSortReset.Visible = False
        Me.ckbSStatesManReorderBackup.Visible = False
        Me.ckbSStatesManMoveToTrash.Visible = True
        Me.ckbStoreCopy.Visible = False
        Me.lblStatus2.Visible = True

        Me.cmdDeleteCheckAll = Me.cmdCommand2
        Me.cmdDeleteCheckAll.Text = "ALL"
        Me.cmdDeleteCheckAll.Image = My.Resources.Icon_CheckAll
        AddHandler cmdDeleteCheckAll.Click, AddressOf cmdDeleteCheckAll_Click

        Me.cmdDeleteCheckNone = Me.cmdCommand3
        Me.cmdDeleteCheckNone.Text = "NONE"
        Me.cmdDeleteCheckNone.Image = My.Resources.Icon_CheckNone
        AddHandler cmdDeleteCheckNone.Click, AddressOf cmdDeleteCheckNone_Click

        Me.cmdDeleteCheckInvert = Me.cmdCommand4
        Me.cmdDeleteCheckInvert.Text = "INVERT"
        Me.cmdDeleteCheckInvert.Image = My.Resources.Icon_CheckInvert
        AddHandler cmdDeleteCheckInvert.Click, AddressOf cmdDeleteCheckInvert_Click

        Me.cmdDeleteCheckBackup = Me.cmdCommand1
        Me.cmdDeleteCheckBackup.Text = "BACKUP"
        Me.cmdDeleteCheckBackup.Image = My.Resources.Icon_CheckBackup
        AddHandler cmdDeleteCheckBackup.Click, AddressOf cmdDeleteCheckBackup_Click

        Me.cmdOperation.Text = "Delete checked".ToUpper
        AddHandler cmdOperation.Click, AddressOf cmdDelete_Click

        Select Case frmMain.CurrentListMode
            Case ListMode.Savestates
                Me.lblAction.Text = "check savestates"
                Me.cmdDeleteCheckBackup.Visible = True
                Me.lblStatus3.Visible = True
            Case ListMode.Stored
                Me.lblAction.Text = "check savestates"
                Me.cmdDeleteCheckBackup.Visible = False
                Me.lblStatus3.Visible = False
            Case ListMode.Snapshots
                Me.lblAction.Text = "check screenshots"
                Me.cmdDeleteCheckBackup.Visible = False
                Me.lblStatus3.Visible = False
        End Select

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
    End Sub

    Protected Overrides Sub UI_OperationUnload()
        MyBase.UI_OperationUnload()

        RemoveHandler cmdDeleteCheckAll.Click, AddressOf cmdDeleteCheckAll_Click
        RemoveHandler cmdDeleteCheckNone.Click, AddressOf cmdDeleteCheckNone_Click
        RemoveHandler cmdDeleteCheckInvert.Click, AddressOf cmdDeleteCheckInvert_Click
        RemoveHandler cmdDeleteCheckBackup.Click, AddressOf cmdDeleteCheckBackup_Click

        RemoveHandler cmdOperation.Click, AddressOf cmdDelete_Click
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        Me.SourceFileNames = New List(Of String)
        For Each tmpListItem As ListViewItem In Me.lvwFileList.CheckedItems
            If FileStatus.Idle.Equals(tmpListItem.Tag) Then
                Me.SourceFileNames.Add(tmpListItem.Text)
            End If
        Next

        mdlFileOperations.FileOps_DeleteFiles(Me.SourceFileNames, Me.SourcePath, Me.OperationResults, Me.OperationResultMessages, My.Settings.SStatesMan_FileTrash)
        Me.OperationDone = True

        Dim i As Integer = 0
        For Each tmpListItem As ListViewItem In Me.lvwFileList.CheckedItems
            tmpListItem.Tag = OperationResults(i)
            tmpListItem.SubItems(Me.lvwFileList.Columns.Count - 1).Text = OperationResultMessages(i)
            i += 1
            tmpListItem.Checked = False
        Next

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.EndUpdate()

        Me.DeleteList_Preview()
        frmMain.GameList_Refresh()
        Me.DeleteList_UpdateUI()
    End Sub

    Private Sub DeleteList_AddFiles()
        Dim sw As New Stopwatch
        sw.Start()

        Me.DeleteList_TotalSize = 0
        Me.DeleteList_TotalSizeBackup = 0

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
                    Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                        .Header = tmpGameInfo.ToString(),
                        .HeaderAlignment = HorizontalAlignment.Left,
                        .Name = tmpGameInfo.Serial}

                    tmpListGroups.Add(tmpLvwSListGroup)

                    Me.DeleteList_CreateListItems(SSMGameList.Games(tmpSerial).GameFiles(frmMain.CurrentListMode), tmpLvwSListGroup, tmpListItems)
                Else
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Checked game " & tmpSerial & " has no files.")
                End If

            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Game " & tmpSerial & " not found in list.")
            End If
        Next

        Me.lvwFileList.Groups.AddRange(tmpListGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpListItems)
        Me.lvwFileList.Items.AddRange(tmpListItems.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} savestates.", Me.lvwFileList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub DeleteList_CreateListItems(pFile As Dictionary(Of String, PCSX2File), pListGroup As ListViewGroup, ByRef pListItems As List(Of ListViewItem))

        For Each tmpFile As KeyValuePair(Of String, PCSX2File) In pFile

            If frmMain.checkedFiles(frmMain.CurrentListMode).Contains(tmpFile.Key) Then
                Dim tmpListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpFile.Key, _
                                                                               .Group = pListGroup, _
                                                                               .Name = tmpFile.Key}
                tmpListItem.SubItems.AddRange({tmpFile.Value.Number.ToString, _
                                               tmpFile.Value.ExtraInfo, _
                                               tmpFile.Value.LastWriteTime.ToString, _
                                               String.Format("{0:N2} MB", tmpFile.Value.Length / 1024 ^ 2)})

                If mdlMain.SafeExistFile(Path.Combine(SourcePath, tmpFile.Key)) Then
                    tmpListItem.SubItems.Add(String.Empty)
                    tmpListItem.Checked = True

                    Select Case frmMain.CurrentListMode
                        Case ListMode.Savestates
                            If tmpListItem.Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                                tmpListItem.ImageIndex = 1
                                DeleteList_TotalSizeBackup += tmpFile.Value.Length
                            Else
                                tmpListItem.ImageIndex = 0
                                DeleteList_TotalSize += tmpFile.Value.Length
                            End If
                        Case ListMode.Stored
                            tmpListItem.ImageIndex = 0
                            DeleteList_TotalSize += tmpFile.Value.Length
                        Case ListMode.Snapshots
                            tmpListItem.ImageIndex = 2
                            DeleteList_TotalSize += tmpFile.Value.Length
                    End Select

                    tmpListItem.BackColor = Color.Transparent
                    tmpListItem.Tag = FileStatus.Idle
                Else
                    tmpListItem.Tag = FileStatus.FileNotFound
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "File not found: " & tmpFile.Value.Name & ".")
                End If

                pListItems.Add(tmpListItem)
            End If
        Next
    End Sub

    Private Sub DeleteList_Preview()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If Me.lvwFileList.Items.Count > 0 Then
            RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
            Me.lvwFileList.BeginUpdate()

            For Each tmpListItem As ListViewItem In Me.lvwFileList.Items

                If FileStatus.FileDeleted.Equals(tmpListItem.Tag) Then
                    tmpListItem.SubItems(Me.lvwFileList.Columns.Count - 1).Text = "File deleted successfully."
                    tmpListItem.BackColor = Color.FromArgb(150, 200, 130)
                    tmpListItem.Checked = False
                ElseIf FileStatus.FileNotFound.Equals(tmpListItem.Tag) Then
                    tmpListItem.SubItems.Add("File not found or inaccessible.")
                    tmpListItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                    tmpListItem.Checked = False
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "File not found: " & tmpListItem.Text & ".")
                ElseIf FileStatus.OtherError.Equals(tmpListItem.Tag) Then
                    tmpListItem.BackColor = Color.FromArgb(255, 192, 192)
                    tmpListItem.Checked = False
                End If
            Next

            AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
            Me.lvwFileList.EndUpdate()
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Preview, _
                         String.Format("Preview for {0:N0} ListViewItems.", Me.lvwFileList.Items.Count), _
                         sw.ElapsedTicks)
    End Sub

    Private Sub DeleteList_IndexChecked()
        Select Case frmMain.CurrentListMode
            Case ListMode.Savestates
                Me.DeleteList_IndexChecked2(Of Savestate)()
            Case ListMode.Stored
                Me.DeleteList_IndexChecked2(Of Savestate)()
            Case ListMode.Snapshots
                Me.DeleteList_IndexChecked2(Of Snapshot)()
        End Select
    End Sub

    Private Sub DeleteList_IndexChecked2(Of T As {New, PCSX2File})()
        Me.DeleteList_SelectedSize = 0
        Me.DeleteList_SelectedSizeBackup = 0

        If Me.lvwFileList.CheckedItems.Count > 0 Then
            For Each tmpCheckedItem As ListViewItem In Me.lvwFileList.CheckedItems

                Dim tmpSerial As String = (New T With {.Name = tmpCheckedItem.Name}).GetGameSerial
                Dim tmpFD As New Dictionary(Of String, PCSX2File)
                If SSMGameList.Games.ContainsKey(tmpSerial) AndAlso SSMGameList.Games(tmpSerial).GameFiles.TryGetValue(frmMain.CurrentListMode, tmpFD) Then
                    If tmpFD.ContainsKey(tmpCheckedItem.Name) Then
                        If frmMain.CurrentListMode = ListMode.Savestates AndAlso _
                            tmpFD.Item(tmpCheckedItem.Name).Extension.Equals(My.Settings.PCSX2_SStateExtBackup) Then
                            DeleteList_SelectedSizeBackup += tmpFD.Item(tmpCheckedItem.Name).Length
                        Else
                            DeleteList_SelectedSize += tmpFD.Item(tmpCheckedItem.Name).Length
                        End If
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub DeleteList_UpdateUI()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If Me.lvwFileList.Items.Count = 0 Then
            '================
            'No files in list
            '================
            Me.lblStatus1.Text = "0 items"
            Me.lblStatus2.Text = ""
            Me.lblStatus3.Text = ""

            Me.cmdDeleteCheckAll.Enabled = False
            Me.cmdDeleteCheckInvert.Enabled = False
            Me.cmdDeleteCheckNone.Enabled = False
            Me.cmdDeleteCheckBackup.Enabled = False

            Me.cmdDeleteCheckAll.Visible = True
            Me.cmdDeleteCheckInvert.Visible = True
            Me.cmdDeleteCheckNone.Visible = True

            Me.cmdOperation.Enabled = False

            SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "No files in list. This shouldn't be happening.")
        Else
            '=================
            'Files are present
            '=================
            Me.cmdDeleteCheckInvert.Enabled = True

            If (Me.DeleteList_TotalSizeBackup = 0) Or (Me.DeleteList_TotalSizeBackup = Me.DeleteList_SelectedSizeBackup) Then
                'Backup size is zero -> no backup files in list
                'Backup size = selected backup size -> all backup are selected
                Me.cmdDeleteCheckBackup.Enabled = False
            Else
                Me.cmdDeleteCheckBackup.Enabled = True
            End If

            If Me.lvwFileList.CheckedItems.Count > 0 Then
                'At least one file is checked
                Me.lblStatus1.Text = System.String.Format("{0:N0} items ({1:N0} checked)", Me.lvwFileList.Items.Count, Me.lvwFileList.CheckedItems.Count)
                Me.lblStatus2.Text = System.String.Format("{0:N2} MB ({1:N2} MB)", Me.DeleteList_TotalSize / 1024 ^ 2, Me.DeleteList_SelectedSize / 1024 ^ 2)
                Me.lblStatus3.Text = System.String.Format("+ {0:N2} MB ({1:N2} MB)", Me.DeleteList_TotalSizeBackup / 1024 ^ 2, Me.DeleteList_SelectedSizeBackup / 1024 ^ 2)

                Me.cmdDeleteCheckNone.Enabled = True

                Me.cmdOperation.Enabled = True

                If Me.lvwFileList.Items.Count = Me.lvwFileList.CheckedItems.Count Then
                    'All files are checked
                    Me.cmdDeleteCheckAll.Enabled = False
                Else
                    Me.cmdDeleteCheckAll.Enabled = True
                End If

            Else
                'No files are checked
                Me.lblStatus1.Text = System.String.Format("{0:N0} items", Me.lvwFileList.Items.Count)
                Me.lblStatus2.Text = System.String.Format("{0:N2} MB", Me.DeleteList_TotalSize / 1024 ^ 2)
                Me.lblStatus3.Text = System.String.Format("+ {0:N2} MB", Me.DeleteList_TotalSizeBackup / 1024 ^ 2)

                Me.cmdDeleteCheckNone.Enabled = False
                Me.cmdDeleteCheckAll.Enabled = True

                Me.cmdOperation.Enabled = False
            End If

            Me.cmdDeleteCheckAll.Visible = Me.cmdDeleteCheckAll.Enabled
            Me.cmdDeleteCheckNone.Visible = Me.cmdDeleteCheckNone.Enabled
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub
#Region "List commands"
    Private Sub cmdDeleteCheckAll_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFileList.Items.Count - 1
            If Me.lvwFileList.Items.Item(lvwItemIndex).Tag.Equals(FileStatus.Idle) Then
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.DeleteList_IndexChecked()
        Me.DeleteList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

    Private Sub cmdDeleteCheckNone_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFileList.Items.Count - 1
            Me.lvwFileList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.DeleteList_IndexChecked()
        Me.DeleteList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

    Private Sub cmdDeleteCheckInvert_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFileList.Items.Count - 1
            If Me.lvwFileList.Items.Item(lvwItemIndex).Tag.Equals(FileStatus.Idle) Then
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = Not (Me.lvwFileList.Items.Item(lvwItemIndex).Checked)
            Else
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.DeleteList_IndexChecked()
        Me.DeleteList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

    Private Sub cmdDeleteCheckBackup_Click(sender As Object, e As EventArgs)
        RemoveHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.BeginUpdate()

        For lvwItemIndex As Integer = 0 To Me.lvwFileList.Items.Count - 1
            If Me.lvwFileList.Items.Item(lvwItemIndex).Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                If Me.lvwFileList.Items.Item(lvwItemIndex).Tag.Equals(FileStatus.Idle) Then
                    Me.lvwFileList.Items.Item(lvwItemIndex).Checked = True
                End If
            Else
                Me.lvwFileList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.DeleteList_IndexChecked()
        Me.DeleteList_UpdateUI()

        AddHandler Me.lvwFileList.ItemChecked, AddressOf Me.DeleteList_ItemChecked
        Me.lvwFileList.EndUpdate()
    End Sub

    Private Sub DeleteList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        If DirectCast(sender, ListView).Items(DirectCast(sender, ListView).Items.Count - 1) IsNot Nothing Then
            If Not (FileStatus.Idle.Equals(e.Item.Tag)) Then
                e.Item.Checked = False
            End If
            Me.DeleteList_IndexChecked()
            Me.DeleteList_UpdateUI()
        End If
    End Sub
#End Region
End Class