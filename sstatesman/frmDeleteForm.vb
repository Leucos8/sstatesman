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

Public Class frmDeleteForm
    Dim lastWindowState As FormWindowState  'Needed to know if a form resize changed the windowstate
    Dim statusColumnHeaderRef As ColumnHeader

    'To avoid refreshing the lists when an operation is running, set by UI_Enabled
    Dim ListsAreRefreshed As Boolean = False

    'Current size in bytes of the selected items
    Dim Files_SelectedSize As Long = 0
    Dim Files_SelectedSizeBackup As Long = 0
    Dim Files_TotalSize As Long = 0
    Dim Files_TotalSizeBackup As Long = 0

    Enum DelFileStatus
        Ready
        DeletedOk
        NotFound
        OtherError
    End Enum

#Region "Delete"
    Private Sub DeleteSavestates()
        Me.UI_Enable(False)
        For Each tmpItem As ListViewItem In Me.lvwDelFilesList.CheckedItems
            Dim tmpGamesListItem As New mdlFileList.GamesList_Item
            Dim tmpSavestate As New Savestate
            If SSMGameList.Games.TryGetValue(tmpItem.Group.Name, tmpGamesListItem) Then
                If tmpGamesListItem.Savestates.TryGetValue(tmpItem.Name, tmpSavestate) Then
                    Try
                        If My.Settings.SStatesMan_SStateTrash = True Then
                            My.Computer.FileSystem.DeleteFile(Path.Combine(My.Settings.PCSX2_PathSState, tmpSavestate.Name),
                                                              FileIO.UIOption.OnlyErrorDialogs,
                                                              FileIO.RecycleOption.SendToRecycleBin)
                            SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Delete, tmpItem.Text & " moved to recycle bin.")
                        Else
                            File.Delete(Path.Combine(My.Settings.PCSX2_PathSState, tmpSavestate.Name))
                            SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Delete, tmpItem.Text & " deleted succesfully.")
                        End If

                        If tmpSavestate.isBackup Then
                            Files_TotalSizeBackup -= tmpSavestate.Length
                        Else
                            Files_TotalSize -= tmpSavestate.Length
                        End If
                        'tmpGamesListItem.Savestates.Remove(tmpSavestate.Name)

                        tmpItem.Tag = DelFileStatus.DeletedOk
                        tmpItem.SubItems(statusColumnHeaderRef.Index).Text = "File deleted successfully."
                        tmpItem.BackColor = Color.FromArgb(255, 192, 255, 192)
                    Catch ex As Exception
                        tmpItem.Tag = DelFileStatus.OtherError
                        tmpItem.SubItems(statusColumnHeaderRef.Index).Text = ex.Message
                        tmpItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                        SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, tmpItem.Text & " not deleted. " & ex.Message)
                    Finally
                        tmpItem.Checked = False
                    End Try
                Else
                    tmpItem.Tag = DelFileStatus.OtherError
                    tmpItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                    tmpItem.SubItems(statusColumnHeaderRef.Index).Text = "File information not found in list."
                    SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, "File information not found for " & tmpItem.Name & ".")
                End If
            Else
                tmpItem.Tag = DelFileStatus.OtherError
                tmpItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                tmpItem.SubItems(statusColumnHeaderRef.Index).Text = "Game information not found in list."
                SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, "Game " & tmpItem.Group.Name & " not found for file " & tmpItem.Name & ".")
            End If


        Next
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub DeleteSnapshots()
        Me.UI_Enable(False)
        For Each tmpItem As ListViewItem In Me.lvwDelFilesList.CheckedItems
            Dim tmpGamesListItem As New mdlFileList.GamesList_Item
            Dim tmpSnap As New Snapshot
            If SSMGameList.Games.TryGetValue(tmpItem.Group.Name, tmpGamesListItem) Then
                If tmpGamesListItem.Snapshots.TryGetValue(tmpItem.Name, tmpSnap) Then
                    Try
                        If My.Settings.SStatesMan_SStateTrash = True Then
                            My.Computer.FileSystem.DeleteFile(Path.Combine(My.Settings.PCSX2_PathSnaps, tmpSnap.Name),
                                                              FileIO.UIOption.OnlyErrorDialogs,
                                                              FileIO.RecycleOption.SendToRecycleBin)
                            SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Delete, tmpItem.Text & " moved to recycle bin.")
                        Else
                            File.Delete(Path.Combine(My.Settings.PCSX2_PathSnaps, tmpSnap.Name))
                            SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Delete, tmpItem.Text & " deleted succesfully.")
                        End If
                        Files_TotalSize -= tmpSnap.Length
                        'tmpGamesListItem.Snapshots.Remove(tmpSnap.Name)

                        tmpItem.Tag = DelFileStatus.DeletedOk
                        tmpItem.SubItems(statusColumnHeaderRef.Index).Text = "File deleted successfully."
                        tmpItem.BackColor = Color.FromArgb(255, 192, 255, 192)
                    Catch ex As Exception
                        tmpItem.Tag = DelFileStatus.OtherError
                        tmpItem.SubItems(statusColumnHeaderRef.Index).Text = ex.Message
                        tmpItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                        SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, tmpItem.Text & " not deleted. " & ex.Message)
                    Finally
                        tmpItem.Checked = False
                    End Try
                Else
                    tmpItem.Tag = DelFileStatus.OtherError
                    tmpItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                    tmpItem.SubItems(statusColumnHeaderRef.Index).Text = "File information not found in list."
                    SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, "File information not found for " & tmpItem.Name & ".")
                End If
            Else
                tmpItem.Tag = DelFileStatus.OtherError
                tmpItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                tmpItem.SubItems(statusColumnHeaderRef.Index).Text = "Game information not found in list."
                SSMAppLog.Append(eType.LogError, eSrc.DeleteWindow, eSrcMethod.Delete, "Game " & tmpItem.Group.Name & " not found for file " & tmpItem.Name & ".")
            End If


        Next
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
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
        Me.applyTheme()

        'Checked state icons
        Dim tmpLvwCheckboxes As New ImageList With {.ImageSize = mdlTheme.imlLvwCheckboxes.ImageSize}   'Cannot use imlLvwCheckboxes directly because of a bug that makes checkboxes disappear.
        tmpLvwCheckboxes.Images.AddRange({My.Resources.Checkbox_Unchecked_22x22, My.Resources.Checkbox_Checked_22x22})
        Me.lvwDelFilesList.StateImageList = tmpLvwCheckboxes    'Assigning the imagelist to the Files listview
        'Savestates, backup, and screenshot icons
        Me.lvwDelFilesList.SmallImageList = mdlTheme.imlLvwItemIcons     'Assigning the imagelist to the Files listview

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "1/3 Theme & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '---------------
        'Window settings
        '---------------

        'Main window location, size and state
        Me.Location = My.Settings.frmDel_WindowLocation
        Me.Size = My.Settings.frmDel_WindowSize
        If My.Settings.frmDel_WindowState = FormWindowState.Minimized Then
            My.Settings.frmDel_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmDel_WindowState
        Me.lastWindowState = Me.WindowState

        If My.Settings.frmDel_flvw_columnwidth IsNot Nothing Then
            If My.Settings.frmDel_flvw_columnwidth.Length = Me.lvwDelFilesList.Columns.Count Then
                For i As Integer = 0 To Me.lvwDelFilesList.Columns.Count - 1
                    Me.lvwDelFilesList.Columns(i).Width = My.Settings.frmDel_flvw_columnwidth(i)
                Next
            End If
        End If

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "2/3 Saved window sizes applied.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================

        Me.UI_SwitchMode(frmMain.currentListMode)
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
        Me.Files_TotalSize = 0
        Me.Files_TotalSizeBackup = 0

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

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Close, "Form closed.", sw.ElapsedTicks)

        '====================
        'Refreshing all lists
        '====================
        frmMain.GameList_Refresh()
    End Sub
#End Region

#Region "UI - General"
    Private Sub UI_SwitchMode(pListMode As frmMain.ListMode)
        Me.UI_Enable(False)

        Select Case pListMode
            Case frmMain.ListMode.Savestates
                Me.lblFileListCheck.Text = "check savestates:"
                Me.cmdFilesCheckBackup.Visible = True
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = True
                Me.txtSizeBackup.Visible = True
            Case frmMain.ListMode.Stored
                Me.lblFileListCheck.Text = "check savestates:"
                Me.cmdFilesCheckBackup.Visible = False
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
            Case frmMain.ListMode.Snapshots
                Me.lblFileListCheck.Text = "check screenshots:"
                Me.cmdFilesCheckBackup.Visible = False
                Me.lblSize.Text = "screenshots size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
        End Select

        Me.FileList_AddColumns(pListMode)

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.ListMode, String.Format("Switched to {0}.", pListMode.ToString))
        Me.DelFileList_Refresh()
        Me.UI_Enable(True)
    End Sub

    ''' <summary>Handles the filelist beginupdate and endupdate methods</summary>
    ''' <param name="pSwitch">True to end the update, False to begin the update</param>
    Private Sub UI_Enable(pSwitch As Boolean)
        Me.ListsAreRefreshed = Not (pSwitch)
        If pSwitch = True Then
            Me.lvwDelFilesList.EndUpdate()
        Else
            Me.lvwDelFilesList.BeginUpdate()
        End If
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.UI_Enable, pSwitch.ToString)
    End Sub

    ''' <summary>Updates the UI status.</summary>
    Private Sub UI_UpdateFileInfo()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = String.Format("{0:N0} | {1:N0} files", Me.lvwDelFilesList.CheckedItems.Count, Me.lvwDelFilesList.Items.Count)
        Me.txtSize.Text = String.Format("{0:N2} | {1:N2} MB", Me.Files_SelectedSize / 1024 ^ 2, Me.Files_TotalSize / 1024 ^ 2)
        Me.txtSizeBackup.Text = String.Format("{0:N2} | {1:N2} MB", Me.Files_SelectedSizeBackup / 1024 ^ 2, Me.Files_TotalSizeBackup / 1024 ^ 2)

        If Me.lvwDelFilesList.Items.Count = 0 Then
            '================
            'No files in list
            '================

            Me.cmdFilesCheckAll.Enabled = False
            Me.cmdFilesCheckInvert.Enabled = False
            Me.cmdFilesCheckNone.Enabled = False
            Me.cmdFilesCheckBackup.Enabled = False

            Me.cmdFilesDeleteSelected.Enabled = False
        Else
            '=================
            'Files are present
            '=================
            Me.cmdFilesCheckInvert.Enabled = True
            Me.cmdFilesCheckBackup.Enabled = True

            If Me.lvwDelFilesList.CheckedItems.Count > 0 Then
                'At least one file is checked
                Me.cmdFilesCheckNone.Enabled = True

                Me.cmdFilesDeleteSelected.Enabled = True

                If Me.lvwDelFilesList.Items.Count = Me.lvwDelFilesList.CheckedItems.Count Then
                    'All files are checked
                    Me.cmdFilesCheckAll.Enabled = False
                Else
                    Me.cmdFilesCheckAll.Enabled = True
                End If

            Else
                'No files are checked
                Me.cmdFilesCheckNone.Enabled = False
                Me.cmdFilesCheckAll.Enabled = True

                Me.cmdFilesDeleteSelected.Enabled = False
            End If
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub
#End Region

#Region "UI - FilesList"
    Private Sub DelFileList_Refresh()
        Select Case frmMain.currentListMode
            Case frmMain.ListMode.Savestates
                Me.DelFileList_AddSavestates()
            Case frmMain.ListMode.Snapshots
                Me.DelFileList_AddSnapshots()
        End Select
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()
    End Sub

    Private Sub DelFileList_AddSavestates()
        Dim sw As New Stopwatch
        sw.Start()

        Me.Files_TotalSize = 0
        Me.Files_TotalSizeBackup = 0

        'clear items and group.
        Me.lvwDelFilesList.Items.Clear()
        Me.lvwDelFilesList.Groups.Clear()

        Dim tmpGameInfo As New GameInfo
        Dim tmpSListGroups As New List(Of ListViewGroup)
        Dim tmpSListItems As New List(Of ListViewItem)

        For Each tmpSerial As System.String In frmMain.checkedGames

            If SSMGameList.Games.ContainsKey(tmpSerial) Then

                'Creation of the header
                tmpGameInfo = PCSX2GameDb.Extract(tmpSerial)
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                    .Header = tmpGameInfo.ToString(),
                    .HeaderAlignment = HorizontalAlignment.Left,
                    .Name = tmpGameInfo.Serial}

                tmpSListGroups.Add(tmpLvwSListGroup)

                If SSMGameList.Games(tmpSerial).Savestates.Values.Count > 0 Then
                    For Each tmpSavestate As KeyValuePair(Of String, Savestate) In SSMGameList.Games(tmpSerial).Savestates

                        If frmMain.checkedSavestates.Contains(tmpSavestate.Key) Then
                            Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSavestate.Key,
                                                                                               .Group = tmpLvwSListGroup,
                                                                                               .Name = tmpSavestate.Key}
                            tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Slot.ToString,
                                                               tmpSavestate.Value.Version,
                                                               tmpSavestate.Value.LastWriteTime.ToString,
                                                               System.String.Format("{0:N2} MB", tmpSavestate.Value.Length / 1024 ^ 2)})
                            If File.Exists(Path.Combine(My.Settings.PCSX2_PathSState, tmpSavestate.Key)) Then
                                tmpLvwSListItem.SubItems.Add("")
                                tmpLvwSListItem.Checked = True
                                If Not (tmpSavestate.Value.isBackup) Then
                                    tmpLvwSListItem.ImageIndex = 0
                                    Files_TotalSize += tmpSavestate.Value.Length
                                Else
                                    tmpLvwSListItem.ImageIndex = 1
                                    Files_TotalSizeBackup += tmpSavestate.Value.Length
                                End If
                                tmpLvwSListItem.BackColor = Color.Transparent
                                tmpLvwSListItem.Tag = DelFileStatus.Ready
                            Else
                                tmpLvwSListItem.SubItems.Add("File not found or inaccessible.")
                                tmpLvwSListItem.Checked = False
                                tmpLvwSListItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                                tmpLvwSListItem.Tag = DelFileStatus.NotFound
                                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "File not found: " & tmpSavestate.Value.Name & ".")
                            End If

                            tmpSListItems.Add(tmpLvwSListItem)
                        End If
                    Next
                Else
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Checked game " & tmpSerial & " has no savestates.")
                End If
            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Game not found in list: " & tmpSerial & ".")
            End If
        Next

        Me.lvwDelFilesList.Groups.AddRange(tmpSListGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpSListItems)
        Me.lvwDelFilesList.Items.AddRange(tmpSListItems.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} savestates.", Me.lvwDelFilesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub DelFileList_AddSnapshots()
        Dim sw As New Stopwatch
        sw.Start()

        Me.Files_TotalSize = 0
        Me.Files_TotalSizeBackup = 0

        'clear items and group.
        Me.lvwDelFilesList.Items.Clear()
        Me.lvwDelFilesList.Groups.Clear()

        Dim tmpGameInfo As New GameInfo
        Dim tmpSListGroups As New List(Of ListViewGroup)
        Dim tmpSListItems As New List(Of ListViewItem)

        For Each tmpSerial As System.String In frmMain.checkedGames

            If SSMGameList.Games.ContainsKey(tmpSerial) Then

                'Creation of the header
                tmpGameInfo = PCSX2GameDb.Extract(tmpSerial)
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                    .Header = tmpGameInfo.ToString(),
                    .HeaderAlignment = HorizontalAlignment.Left,
                    .Name = tmpGameInfo.Serial}

                tmpSListGroups.Add(tmpLvwSListGroup)

                If SSMGameList.Games(tmpSerial).Snapshots.Values.Count > 0 Then
                    For Each tmpSnap As KeyValuePair(Of String, Snapshot) In SSMGameList.Games(tmpSerial).Snapshots

                        If frmMain.checkedSnapshots.Contains(tmpSnap.Key) Then
                            Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSnap.Key,
                                                                                               .Group = tmpLvwSListGroup,
                                                                                               .Name = tmpSnap.Key}
                            tmpLvwSListItem.SubItems.AddRange({"Number",
                                                               "Resolution",
                                                               tmpSnap.Value.LastWriteTime.ToString,
                                                               System.String.Format("{0:N2} MB", tmpSnap.Value.Length / 1024 ^ 2)})
                            If File.Exists(Path.Combine(My.Settings.PCSX2_PathSnaps, tmpSnap.Key)) Then
                                tmpLvwSListItem.SubItems.Add("")
                                tmpLvwSListItem.Checked = True
                                tmpLvwSListItem.ImageIndex = 2
                                Files_TotalSize += tmpSnap.Value.Length
                                tmpLvwSListItem.BackColor = Color.Transparent
                                tmpLvwSListItem.Tag = DelFileStatus.Ready
                            Else
                                tmpLvwSListItem.SubItems.Add("File not found or inaccessible.")
                                tmpLvwSListItem.Checked = False
                                tmpLvwSListItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                                tmpLvwSListItem.Tag = DelFileStatus.NotFound
                                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "File not found: " & tmpSnap.Value.Name & ".")
                            End If

                            tmpSListItems.Add(tmpLvwSListItem)
                        End If
                    Next
                Else
                    SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Checked game " & tmpSerial & " has no snapshots.")
                End If
            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.DeleteWindow, eSrcMethod.List, "Game not found in list: " & tmpSerial & ".")
            End If
        Next

        Me.lvwDelFilesList.Groups.AddRange(tmpSListGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpSListItems)
        Me.lvwDelFilesList.Items.AddRange(tmpSListItems.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} snapshots.", Me.lvwDelFilesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub FileList_AddColumns(pListMode As frmMain.ListMode)
        Dim sw As Stopwatch = Stopwatch.StartNew

        Dim tmpColumnHeaders As New List(Of ColumnHeader)
        Dim tmpColumnWidths() As Integer = {0}
        Select Case pListMode
            Case frmMain.ListMode.Savestates, frmMain.ListMode.Stored
                tmpColumnHeaders.AddRange({New ColumnHeader With {.Name = "SStatesCH_FileName", .Text = "Savestate file name", .Width = 240}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Slot", .Text = "Slot", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Version", .Text = "Version", .Width = 80}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Modified", .Text = "Modified", .Width = 0}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Size", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                           })

                If My.Settings.frmMain_flvw_columnwidth IsNot Nothing Then
                    tmpColumnWidths = My.Settings.frmMain_flvw_columnwidth
                End If
            Case frmMain.ListMode.Snapshots
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

        Me.lvwDelFilesList.Columns.Clear()
        Me.lvwDelFilesList.Columns.AddRange(tmpColumnHeaders.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.AddColumns, String.Format("Added columns to files listview for {0}.", pListMode), sw.ElapsedTicks)
    End Sub

    Private Sub DelFileList_indexChecked()
        Me.Files_SelectedSize = 0
        Me.Files_SelectedSizeBackup = 0

        Select Case frmMain.currentListMode
            Case frmMain.ListMode.Savestates

                If Me.lvwDelFilesList.CheckedItems.Count > 0 Then
                    For Each tmpLvwSListItemChecked As ListViewItem In Me.lvwDelFilesList.CheckedItems

                        Dim tmpGamesListItem As New GamesList_Item
                        If SSMGameList.Games.TryGetValue(Savestate.GetSerial(tmpLvwSListItemChecked.Name), tmpGamesListItem) Then
                            Dim tmpSavestate As New Savestate
                            If tmpGamesListItem.Savestates.TryGetValue(tmpLvwSListItemChecked.Name, tmpSavestate) Then
                                If tmpSavestate.isBackup Then
                                    Files_SelectedSizeBackup += tmpSavestate.Length
                                Else
                                    Files_SelectedSize += tmpSavestate.Length
                                End If
                            End If
                        End If

                    Next
                End If

            Case frmMain.ListMode.Snapshots

                If Me.lvwDelFilesList.CheckedItems.Count > 0 Then
                    For Each tmpLvwSListItemChecked As ListViewItem In Me.lvwDelFilesList.CheckedItems

                        Dim tmpGamesListItem As New GamesList_Item
                        If SSMGameList.Games.TryGetValue(Snapshot.GetSerial(tmpLvwSListItemChecked.Name), tmpGamesListItem) Then
                            Dim tmpSnap As New Snapshot
                            If tmpGamesListItem.Snapshots.TryGetValue(tmpLvwSListItemChecked.Name, tmpSnap) Then
                                Files_SelectedSize += tmpSnap.Length
                            End If
                        End If

                    Next
                End If

        End Select
    End Sub

    Private Sub cmdFileCheckAll_Click(sender As Object, e As EventArgs) Handles cmdFilesCheckAll.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            If DelFileStatus.Ready.Equals(Me.lvwDelFilesList.Items.Item(lvwItemIndex).Tag) Then
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdFileCheckNone_Click(sender As Object, e As EventArgs) Handles cmdFilesCheckNone.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdFileCheckInvert_Click(sender As Object, e As EventArgs) Handles cmdFilesCheckInvert.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            If DelFileStatus.Ready.Equals(Me.lvwDelFilesList.Items.Item(lvwItemIndex).Tag) Then
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = Not (Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked)
            Else
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdFileCheckBackup_Click(sender As Object, e As EventArgs) Handles cmdFilesCheckBackup.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            If Savestate.isBackup(Me.lvwDelFilesList.Items.Item(lvwItemIndex).Name) Then
                If DelFileStatus.Ready.Equals(Me.lvwDelFilesList.Items.Item(lvwItemIndex).Tag) Then
                    Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = True
                End If
            Else
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.DelFileList_indexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub lvwDelFileList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwDelFilesList.ItemChecked
        If Not (ListsAreRefreshed) Then
            If Not (DelFileStatus.Ready.Equals(e.Item.Tag)) Then
                e.Item.Checked = False
            End If
            Me.DelFileList_indexChecked()
            Me.UI_UpdateFileInfo()
        End If
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdDelCheckedFiles_Click(sender As Object, e As EventArgs) Handles cmdFilesDeleteSelected.Click
        Select Case frmMain.currentListMode
            Case frmMain.ListMode.Savestates
                Me.DeleteSavestates()
            Case frmMain.ListMode.Snapshots
                Me.DeleteSnapshots()
        End Select
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
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

#Region "UI Theme"
    Private Sub panelWindowTitle_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
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
        Me.panelWindowTitle.BackColor = currentTheme.BgColorTop
        Me.flpBottomPanel.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.panelWindowTitle.BackgroundImage = currentTheme.BgImageTop
            Me.panelWindowTitle.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpBottomPanel.BackgroundImage = currentTheme.BgImageBottom
            Me.flpBottomPanel.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.panelWindowTitle.BackgroundImage = Nothing
            Me.flpBottomPanel.BackgroundImage = Nothing
        End If
        Me.Refresh()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub
#End Region

End Class