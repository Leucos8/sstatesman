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
Public NotInheritable Class frmDeleteForm
    Dim statusColumnHeaderRef As ColumnHeader

    'Current size in bytes of the selected items
    Dim FileList_SelectedSize As Long = 0
    Dim FileList_SelectedSizeBackup As Long = 0
    Dim FileList_TotalSize As Long = 0
    Dim FileList_TotalSizeBackup As Long = 0

    Enum DelFileStatus
        Ready
        DeletedOk
        NotFound
        OtherError
    End Enum

#Region "Delete"
    Private Sub DeleteFiles(pPath As String)
        RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.BeginUpdate()

        For Each tmpCheckedItem As ListViewItem In Me.lvwDelFilesList.CheckedItems
            Dim tmpGamesListItem As New mdlFileList.GameListItem
            If SSMGameList.Games.TryGetValue(tmpCheckedItem.Group.Name, tmpGamesListItem) Then
                If tmpGamesListItem.GameFiles.ContainsKey(frmMain.frmMainListMode) AndAlso _
                    tmpGamesListItem.GameFiles(frmMain.frmMainListMode).Files.ContainsKey(tmpCheckedItem.Name) Then
                    Dim tmpFile As PCSX2File = tmpGamesListItem.GameFiles(frmMain.frmMainListMode).Files(tmpCheckedItem.Name)
                    Try
                        If My.Settings.SStatesMan_FileTrash = True Then
                            My.Computer.FileSystem.DeleteFile(Path.Combine(pPath, tmpFile.Name),
                                                              FileIO.UIOption.OnlyErrorDialogs,
                                                              FileIO.RecycleOption.SendToRecycleBin)
                            SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Delete, tmpCheckedItem.Text & " moved to recycle bin.")
                        Else
                            File.Delete(Path.Combine(pPath, tmpFile.Name))
                            SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Delete, tmpCheckedItem.Text & " deleted succesfully.")
                        End If

                        If tmpFile.Extension = My.Settings.PCSX2_SStateExtBackup Then
                            FileList_TotalSizeBackup -= tmpFile.Length
                        Else
                            FileList_TotalSize -= tmpFile.Length
                        End If
                        'tmpGamesListItem.Savestates.Remove(tmpSavestate.Name)

                        tmpCheckedItem.Tag = DelFileStatus.DeletedOk
                        tmpCheckedItem.SubItems(statusColumnHeaderRef.Index).Text = "File deleted successfully."
                        tmpCheckedItem.BackColor = Color.FromArgb(255, 150, 200, 130)
                    Catch ex As Exception
                        tmpCheckedItem.Tag = DelFileStatus.OtherError
                        tmpCheckedItem.SubItems(statusColumnHeaderRef.Index).Text = ex.Message
                        tmpCheckedItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                        SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, tmpCheckedItem.Text & " not deleted. " & ex.Message)
                    Finally
                        tmpCheckedItem.Checked = False
                    End Try
                Else
                    tmpCheckedItem.Tag = DelFileStatus.OtherError
                    tmpCheckedItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                    tmpCheckedItem.SubItems(statusColumnHeaderRef.Index).Text = "File information not found in list."
                    tmpCheckedItem.Checked = False
                    SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, "File information not found for " & tmpCheckedItem.Name & ".")
                End If
            Else
                tmpCheckedItem.Tag = DelFileStatus.OtherError
                tmpCheckedItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                tmpCheckedItem.SubItems(statusColumnHeaderRef.Index).Text = "Game information not found in list."
                tmpCheckedItem.Checked = False
                SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, "Game " & tmpCheckedItem.Group.Name & " not found for file " & tmpCheckedItem.Name & ".")
            End If


        Next

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()

        Me.UI_UpdateFileInfo()
    End Sub
#End Region

#Region "Form"
    Private Sub frmDeleteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "Form load start.")

        '==================
        'Window preparation
        '==================

        '-----
        'Theme
        '-----
        'Me.ApplyTheme()
        Me.flpWindowBottom.Controls.AddRange({Me.cmdCancel, Me.cmdFilesDeleteSelected})
        Me.pnlFormContent.Dock = DockStyle.Fill

        'Checked state icons
        Dim tmpLvwCheckboxes As New ImageList With {.ImageSize = mdlTheme.imlLvwCheckboxes.ImageSize}   'Cannot use imlLvwCheckboxes directly because of a bug that makes checkboxes disappear.
        tmpLvwCheckboxes.Images.AddRange({My.Resources.Checkbox_Unchecked_22x22, My.Resources.Checkbox_Checked_22x22})
        Me.lvwDelFilesList.StateImageList = tmpLvwCheckboxes    'Assigning the imagelist to the Files listview
        'Savestates, backup, and screenshot icons
        Me.lvwDelFilesList.SmallImageList = mdlTheme.imlLvwItemIcons     'Assigning the imagelist to the Files listview

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "1/3 Layout & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '---------------
        'Window settings
        '---------------

        ''Main window location, size and state
        'Me.Location = My.Settings.frmDel_WindowLocation
        'Me.Size = My.Settings.frmDel_WindowSize
        'If My.Settings.frmDel_WindowState = FormWindowState.Minimized Then
        '    My.Settings.frmDel_WindowState = FormWindowState.Normal
        'End If
        'Me.WindowState = My.Settings.frmDel_WindowState
        'Me.lastWindowState = Me.WindowState

        'If My.Settings.frmDel_flvw_columnwidth IsNot Nothing Then
        '    If My.Settings.frmDel_flvw_columnwidth.Length = Me.lvwDelFilesList.Columns.Count Then
        '        For i As Integer = 0 To Me.lvwDelFilesList.Columns.Count - 1
        '            Me.lvwDelFilesList.Columns(i).Width = My.Settings.frmDel_flvw_columnwidth(i)
        '        Next
        '    End If
        'End If

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "2/3 Saved window sizes applied.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================

        Me.UI_SwitchMode(frmMain.frmMainListMode)
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "3/3 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "All done.", sw.ElapsedTicks)
    End Sub

    Private Sub frmDeleteForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim sw As Stopwatch = Stopwatch.StartNew

        '================
        'Resetting values
        '================

        Me.lvwDelFilesList.Items.Clear()
        Me.lvwDelFilesList.Groups.Clear()
        Me.FileList_TotalSize = 0
        Me.FileList_TotalSizeBackup = 0

        '======================
        'Saving window settings
        '======================

        'State, location, and size
        My.Settings.frmDel_WindowState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            'Location and size saved only when windowstate is normal
            My.Settings.frmDel_WindowLocation = Me.Location
            My.Settings.frmDel_WindowSize = Me.Size
        End If

        'Column widths
        'My.Settings.frmDel_flvw_columnwidth = New Integer() {Me.SStatesCH_FileName.Width, Me.SStatesCH_Slot.Width, _
        '                                                     Me.SStatesCH_Version.Width, Me.SStatesCH_Modified.Width, _
        '                                                     Me.SStatesCH_Size.Width, Me.SStatesCH_Status.Width}

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Close, "Form closed.", sw.ElapsedTicks)

        '====================
        'Refreshing all lists
        '====================
        frmMain.GameList_Refresh()
    End Sub
#End Region

#Region "UI - General"
    Private Sub UI_SwitchMode(pListMode As ListMode)

        Select Case pListMode
            Case ListMode.Savestates
                Me.cmdFileCheckBackup.Visible = True
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = True
                Me.txtSizeBackup.Visible = True
            Case ListMode.Stored
                Me.cmdFileCheckBackup.Visible = False
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
            Case ListMode.Snapshots
                Me.cmdFileCheckBackup.Visible = False
                Me.lblSize.Text = "screenshots size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
        End Select

        Me.FileList_AddColumns(pListMode)

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.ListMode, String.Format("Switched to {0}.", pListMode.ToString))
        Me.DelFileList_Refresh()
    End Sub

    ''' <summary>Handles the filelist beginupdate and endupdate methods</summary>
    ''' <param name="pSwitch">True to end the update, False to begin the update</param>
    Private Sub UI_Enable(pSwitch As Boolean)
        If pSwitch Then
            AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
            Me.lvwDelFilesList.EndUpdate()
        Else
            RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
            Me.lvwDelFilesList.BeginUpdate()
        End If
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.UI_Enable, pSwitch.ToString)
    End Sub

    ''' <summary>Updates the UI status.</summary>
    Private Sub UI_UpdateFileInfo()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = String.Format("{0:N0} | {1:N0} files", Me.lvwDelFilesList.CheckedItems.Count, Me.lvwDelFilesList.Items.Count)
        Me.txtSize.Text = String.Format("{0:N2} | {1:N2} MB", Me.FileList_SelectedSize / 1024 ^ 2, Me.FileList_TotalSize / 1024 ^ 2)
        Me.txtSizeBackup.Text = String.Format("{0:N2} | {1:N2} MB", Me.FileList_SelectedSizeBackup / 1024 ^ 2, Me.FileList_TotalSizeBackup / 1024 ^ 2)

        Me.flpFileListCommands.SuspendLayout()

        If Me.lvwDelFilesList.Items.Count = 0 Then
            '================
            'No files in list
            '================

            Me.cmdFileCheckAll.Enabled = False
            Me.cmdFileCheckInvert.Enabled = False
            Me.cmdFileCheckNone.Enabled = False
            Me.cmdFileCheckBackup.Enabled = False

            Me.cmdFileCheckAll.Visible = True
            Me.cmdFileCheckInvert.Visible = True
            Me.cmdFileCheckNone.Visible = True

            Me.cmdFilesDeleteSelected.Enabled = False

            SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "No files in list. This shouldn't be happening.")
        Else
            '=================
            'Files are present
            '=================
            Me.cmdFileCheckInvert.Enabled = True

            If (Me.FileList_TotalSizeBackup = 0) Or (Me.FileList_TotalSizeBackup = Me.FileList_SelectedSizeBackup) Then
                'Backup size is zero -> no backup files in list
                'Backup size = selected backup size -> all backup are selected
                Me.cmdFileCheckBackup.Enabled = False
            Else
                Me.cmdFileCheckBackup.Enabled = True
            End If

            If Me.lvwDelFilesList.CheckedItems.Count > 0 Then
                'At least one file is checked
                Me.cmdFileCheckNone.Enabled = True

                Me.cmdFilesDeleteSelected.Enabled = True

                If Me.lvwDelFilesList.Items.Count = Me.lvwDelFilesList.CheckedItems.Count Then
                    'All files are checked
                    Me.cmdFileCheckAll.Enabled = False
                Else
                    Me.cmdFileCheckAll.Enabled = True
                End If

            Else
                'No files are checked
                Me.cmdFileCheckNone.Enabled = False
                Me.cmdFileCheckAll.Enabled = True

                Me.cmdFilesDeleteSelected.Enabled = False
            End If

            Me.cmdFileCheckAll.Visible = Me.cmdFileCheckAll.Enabled
            Me.cmdFileCheckNone.Visible = Me.cmdFileCheckNone.Enabled
        End If

        Me.flpFileListCommands.ResumeLayout()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub
#End Region

#Region "UI - FilesList"
    Private Sub DelFileList_Refresh()


        Me.DelFileList_AddFiles()

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()

        Me.DelFileList_IndexChecked()
        Me.UI_UpdateFileInfo()
    End Sub

    Private Sub DelFileList_AddFiles()
        Dim sw As New Stopwatch
        sw.Start()

        Me.FileList_TotalSize = 0
        Me.FileList_TotalSizeBackup = 0

        'clear items and groups.
        Me.lvwDelFilesList.Items.Clear()
        Me.lvwDelFilesList.Groups.Clear()

        Dim tmpGameInfo As New GameInfo
        Dim tmpListGroups As New List(Of ListViewGroup)
        Dim tmpListItems As New List(Of ListViewItem)

        For Each tmpSerial As System.String In frmMain.checkedGames

            If SSMGameList.Games.ContainsKey(tmpSerial) Then
                If SSMGameList.Games(tmpSerial).GameFiles.ContainsKey(frmMain.frmMainListMode) AndAlso _
                    SSMGameList.Games(tmpSerial).GameFiles(frmMain.frmMainListMode).Files.Count > 0 Then
                    'Creation of the header
                    tmpGameInfo = PCSX2GameDb.Extract(tmpSerial)
                    Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                        .Header = tmpGameInfo.ToString(),
                        .HeaderAlignment = HorizontalAlignment.Left,
                        .Name = tmpGameInfo.Serial}

                    tmpListGroups.Add(tmpLvwSListGroup)

                    Me.DelFileList_AddFileListItems(SSMGameList.Games(tmpSerial).GameFiles(frmMain.frmMainListMode).Files, tmpLvwSListGroup, tmpListItems)
                Else
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Checked game " & tmpSerial & " has no savestates.")
                End If

            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Game not found in list: " & tmpSerial & ".")
            End If
        Next

        Me.lvwDelFilesList.Groups.AddRange(tmpListGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpListItems)
        Me.lvwDelFilesList.Items.AddRange(tmpListItems.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} savestates.", Me.lvwDelFilesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub DelFileList_AddFileListItems(pFile As Dictionary(Of String, PCSX2File), pLvwGroup As ListViewGroup, ByRef pLwvItems As List(Of ListViewItem))

        For Each tmpFile As KeyValuePair(Of String, PCSX2File) In pFile

            If frmMain.checkedFiles(frmMain.frmMainListMode).Contains(tmpFile.Key) Then
                Dim tmpLvwItem As New System.Windows.Forms.ListViewItem With {.Text = tmpFile.Key,
                                                                                   .Group = pLvwGroup,
                                                                                   .Name = tmpFile.Key}
                tmpLvwItem.SubItems.AddRange({tmpFile.Value.Number.ToString,
                                              tmpFile.Value.ExtraInfo,
                                              tmpFile.Value.LastWriteTime.ToString,
                                              System.String.Format("{0:N2} MB", tmpFile.Value.Length / 1024 ^ 2)})

                If File.Exists(Path.Combine(SSMGameList.Folder(frmMain.frmMainListMode), tmpFile.Key)) Then
                    tmpLvwItem.SubItems.Add("")
                    tmpLvwItem.Checked = True

                    Select Case frmMain.frmMainListMode
                        Case ListMode.Savestates
                            If tmpLvwItem.Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                                tmpLvwItem.ImageIndex = 1
                                FileList_TotalSizeBackup += tmpFile.Value.Length
                            Else
                                tmpLvwItem.ImageIndex = 0
                                FileList_TotalSize += tmpFile.Value.Length
                            End If
                        Case ListMode.Stored
                            tmpLvwItem.ImageIndex = 0
                            FileList_TotalSize += tmpFile.Value.Length
                        Case ListMode.Snapshots
                            tmpLvwItem.ImageIndex = 2
                            FileList_TotalSize += tmpFile.Value.Length
                    End Select

                    tmpLvwItem.BackColor = Color.Transparent
                    tmpLvwItem.Tag = DelFileStatus.Ready
                Else
                    tmpLvwItem.SubItems.Add("File not found or inaccessible.")
                    tmpLvwItem.Checked = False
                    tmpLvwItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                    tmpLvwItem.Tag = DelFileStatus.NotFound
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "File not found: " & tmpFile.Value.Name & ".")
                End If

                pLwvItems.Add(tmpLvwItem)
            End If
        Next
    End Sub

    Private Sub FileList_AddColumns(pListMode As ListMode)
        Dim sw As Stopwatch = Stopwatch.StartNew

        Dim tmpColumnHeaders As New List(Of ColumnHeader)
        Dim tmpColumnWidths() As Integer = {0}
        Select Case pListMode
            Case ListMode.Savestates, ListMode.Stored
                tmpColumnHeaders.AddRange({New ColumnHeader With {.Name = "SStatesCH_FileName", .Text = "Savestate file name", .Width = 240}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Slot", .Text = "Slot", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Version", .Text = "Version", .Width = 80}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Modified", .Text = "Modified", .Width = 0}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Size", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                           })

                If My.Settings.frmMain_flvw_columnwidth IsNot Nothing Then
                    tmpColumnWidths = My.Settings.frmMain_flvw_columnwidth
                End If
            Case ListMode.Snapshots
                tmpColumnHeaders.AddRange({New ColumnHeader With {.Name = "SnapsCH_FileName", .Text = "Snapshot file name", .Width = 240}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Number", .Text = "Number", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Resolution", .Text = "Resolution", .Width = 80}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Modified", .Text = "Modified", .Width = 0}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Size", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                           })
        End Select
        tmpColumnHeaders.Add(New ColumnHeader With {.Name = "FileCH_Status", .Text = "Status", .Width = 140})
        statusColumnHeaderRef = tmpColumnHeaders(tmpColumnHeaders.Count - 1)

        If tmpColumnWidths.Length = tmpColumnHeaders.Count Then
            For i As Integer = 0 To tmpColumnHeaders.Count - 1
                tmpColumnHeaders(i).Width = tmpColumnWidths(i)
            Next
        End If

        RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.BeginUpdate()

        Me.lvwDelFilesList.Columns.Clear()
        Me.lvwDelFilesList.Columns.AddRange(tmpColumnHeaders.ToArray)

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.AddColumns, String.Format("Added columns to files listview for {0}.", pListMode), sw.ElapsedTicks)
    End Sub

    Private Sub DelFileList_IndexChecked()
        Me.FileList_SelectedSize = 0
        Me.FileList_SelectedSizeBackup = 0
        Select Case frmMain.frmMainListMode
            Case ListMode.Savestates
                Me.DelFileList_indexChecked2(Of Savestate)()
            Case ListMode.Stored
                Me.DelFileList_indexChecked2(Of Savestate)()
            Case ListMode.Snapshots
                Me.DelFileList_indexChecked2(Of Snapshot)()
        End Select
    End Sub

    Private Sub DelFileList_indexChecked2(Of T As {New, PCSX2File})()
        Me.FileList_SelectedSize = 0
        Me.FileList_SelectedSizeBackup = 0


        If Me.lvwDelFilesList.CheckedItems.Count > 0 Then
            For Each tmpCheckedItem As ListViewItem In Me.lvwDelFilesList.CheckedItems

                Dim tmpSerial As String = (New T With {.Name = tmpCheckedItem.Name}).GetGameSerial
                If SSMGameList.Games.ContainsKey(tmpSerial) AndAlso SSMGameList.Games(tmpSerial).GameFiles.ContainsKey(frmMain.frmMainListMode) Then
                    If SSMGameList.Games(tmpSerial).GameFiles(frmMain.frmMainListMode).Files.ContainsKey(tmpCheckedItem.Name) Then
                        If frmMain.frmMainListMode = ListMode.Savestates AndAlso _
                            SSMGameList.Games(tmpSerial).GameFiles(frmMain.frmMainListMode).Files(tmpCheckedItem.Name).Extension.Equals(My.Settings.PCSX2_SStateExtBackup) Then
                            FileList_SelectedSizeBackup += SSMGameList.Games(tmpSerial).GameFiles(frmMain.frmMainListMode).Files(tmpCheckedItem.Name).Length
                        Else
                            FileList_SelectedSize += SSMGameList.Games(tmpSerial).GameFiles(frmMain.frmMainListMode).Files(tmpCheckedItem.Name).Length
                        End If
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub cmdFileCheckAll_Click(sender As Object, e As EventArgs) Handles cmdFileCheckAll.Click
        RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            If Me.lvwDelFilesList.Items.Item(lvwItemIndex).Tag.Equals(DelFileStatus.Ready) Then
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()
    End Sub

    Private Sub cmdFileCheckNone_Click(sender As Object, e As EventArgs) Handles cmdFileCheckNone.Click
        RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()
    End Sub

    Private Sub cmdFileCheckInvert_Click(sender As Object, e As EventArgs) Handles cmdFileCheckInvert.Click
        RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            If Me.lvwDelFilesList.Items.Item(lvwItemIndex).Tag.Equals(DelFileStatus.Ready) Then
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = Not (Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked)
            Else
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()
    End Sub

    Private Sub cmdFileCheckBackup_Click(sender As Object, e As EventArgs) Handles cmdFileCheckBackup.Click
        RemoveHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.BeginUpdate()

        For lvwItemIndex As Integer = 0 To Me.lvwDelFilesList.Items.Count - 1
            If Me.lvwDelFilesList.Items.Item(lvwItemIndex).Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                If Me.lvwDelFilesList.Items.Item(lvwItemIndex).Tag.Equals(DelFileStatus.Ready) Then
                    Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = True
                End If
            Else
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwDelFilesList.ItemChecked, AddressOf Me.lvwDelFilesList_ItemChecked
        Me.lvwDelFilesList.EndUpdate()
    End Sub

    Private Sub lvwDelFilesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        If CType(sender, ListView).Items(CType(sender, ListView).Items.Count - 1) IsNot Nothing Then
            If Not (e.Item.Tag.Equals(DelFileStatus.Ready)) Then
                e.Item.Checked = False
            End If
            Me.DelFileList_indexChecked()
            Me.UI_UpdateFileInfo()
        End If
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdFilesDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmdFilesDeleteSelected.Click
        Me.DeleteFiles(SSMGameList.Folder(frmMain.frmMainListMode))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
#End Region

End Class