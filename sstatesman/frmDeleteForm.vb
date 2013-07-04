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

    'To avoid refreshing the lists when an operation is running, set by UI_Enabled
    Dim ListsAreRefreshed As Boolean = False

    'Current size in bytes of the selected items
    Dim lvwFiles_SelectedSize As Long = 0
    Dim lvwFiles_SelectedSizeBackup As Long = 0
    Dim lvwFiles_TotalSize As Long = 0
    Dim lvwFiles_TotalSizeBackup As Long = 0

    Friend Enum frmDelSStatesLvwColumn
        FileName
        Slot
        Version
        LastWriteDate
        Size
        Status
    End Enum

    Private Sub DeletFiles()
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
                        Else
                            File.Delete(Path.Combine(My.Settings.PCSX2_PathSState, tmpSavestate.Name))
                        End If

                        'If tmpSavestate.Backup Then
                        '    tmpGamesListItem.SavestatesBackup_SizeTot -= tmpSavestate.Length
                        'Else
                        '    tmpGamesListItem.Savestates_SizeTot -= tmpSavestate.Length
                        'End If
                        'tmpGamesListItem.Savestates.Remove(tmpSavestate.Name)

                        Me.lvwDelFilesList.Items(tmpItem.Index).SubItems(frmDelSStatesLvwColumn.Status).Text = "File deleted successfully."
                        Me.lvwDelFilesList.Items(tmpItem.Index).BackColor = Color.FromArgb(255, 192, 255, 192)
                    Catch ex As Exception
                        Me.lvwDelFilesList.Items(tmpItem.Index).SubItems(frmDelSStatesLvwColumn.Status).Text = ex.Message
                        Me.lvwDelFilesList.Items(tmpItem.Index).BackColor = Color.FromArgb(255, 255, 192, 192)
                    Finally
                        Me.lvwDelFilesList.Items(tmpItem.Index).Checked = False
                    End Try
                End If
            End If


        Next
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

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
        'Me.lvwDelFilesList.StateImageList = mdlTheme.imlLvwCheckboxes    'Assigning the imagelist to the Files listview
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

        Me.UI_Enable(False)
        Me.DelFileList_AddSavestates()
        Me.DelFileList_indexChecked()
        Me.UI_Enable(True)
        Me.UI_UpdateFileInfo()

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
        Dim lvwFiles_SelectedSize As Long = 0
        Dim lvwFiles_SelectedSizeBackup As Long = 0
        Me.lvwFiles_TotalSize = 0
        Me.lvwFiles_TotalSizeBackup = 0

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
        My.Settings.frmDel_flvw_columnwidth = New Integer() {Me.StDelLvw_FileName.Width, Me.StDelLvw_Slot.Width, _
                                                             Me.StDelLvw_Version.Width, Me.StDelLvw_LastWT.Width, _
                                                             Me.StDelLvw_Size.Width, Me.StDelLvw_Status.Width}

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Close, "Form closed.", sw.ElapsedTicks)

        '====================
        'Refreshing all lists
        '====================
        frmMain.GameList_Refresh()
    End Sub
#End Region

#Region "UI - General"
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
        Me.txtSize.Text = String.Format("{0:N2} | {1:N2} MB", Me.lvwFiles_SelectedSize / 1024 ^ 2, Me.lvwFiles_TotalSize / 1024 ^ 2)
        Me.txtSizeBackup.Text = String.Format("{0:N2} | {1:N2} MB", Me.lvwFiles_SelectedSizeBackup / 1024 ^ 2, Me.lvwFiles_TotalSizeBackup / 1024 ^ 2)

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
    Private Sub DelFileList_AddSavestates()
        Dim sw As New Stopwatch
        sw.Start()

        Me.lvwFiles_TotalSize = 0
        Me.lvwFiles_TotalSizeBackup = 0

        'clear items and group.
        Me.lvwDelFilesList.Items.Clear()
        Me.lvwDelFilesList.Groups.Clear()

        Dim tmpGameInfo As New GameInfo
        Dim tmpSListGroups As New List(Of ListViewGroup)
        Dim tmpSListItems As New List(Of ListViewItem)

        For Each tmpSerial As System.String In frmMain.checkedGames

            Dim tmpGamesListItem As New GamesList_Item
            If SSMGameList.Games.TryGetValue(tmpSerial, tmpGamesListItem) Then

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
                            If IO.File.Exists(IO.Path.Combine(My.Settings.PCSX2_PathSState, tmpSavestate.Key)) Then
                                tmpLvwSListItem.SubItems.Add("")
                                tmpLvwSListItem.Checked = True
                                If Not (tmpSavestate.Value.isBackup) Then
                                    tmpLvwSListItem.ImageIndex = 0
                                    lvwFiles_TotalSize += tmpSavestate.Value.Length
                                Else
                                    tmpLvwSListItem.ImageIndex = 1
                                    lvwFiles_TotalSizeBackup += tmpSavestate.Value.Length
                                End If
                            Else
                                tmpLvwSListItem.SubItems.Add("Error: file not found or inaccessible.")
                                tmpLvwSListItem.Checked = False
                                tmpLvwSListItem.BackColor = Color.FromArgb(255, 255, 192, 192)
                            End If

                            tmpSListItems.Add(tmpLvwSListItem)
                        End If
                    Next
                End If
            End If
        Next

        Me.lvwDelFilesList.Groups.AddRange(tmpSListGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpSListItems)
        Me.lvwDelFilesList.Items.AddRange(tmpSListItems.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} savestates.", Me.lvwDelFilesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub DelFileList_indexChecked()
        Me.lvwFiles_SelectedSize = 0
        Me.lvwFiles_SelectedSizeBackup = 0

        If Me.lvwDelFilesList.CheckedItems.Count > 0 Then
            For Each tmpLvwSListItemChecked As ListViewItem In Me.lvwDelFilesList.CheckedItems

                Dim tmpGamesListItem As New GamesList_Item
                If SSMGameList.Games.TryGetValue(Savestate.GetSerial(tmpLvwSListItemChecked.Name), tmpGamesListItem) Then
                    Dim tmpSavestate As New Savestate
                    If tmpGamesListItem.Savestates.TryGetValue(tmpLvwSListItemChecked.Name, tmpSavestate) Then
                        If tmpSavestate.isBackup Then
                            lvwFiles_SelectedSizeBackup += tmpSavestate.Length
                        Else
                            lvwFiles_SelectedSize += tmpSavestate.Length
                        End If
                    End If
                End If

            Next
        End If

    End Sub

    Private Sub cmdFileCheckAll_Click(sender As Object, e As EventArgs) Handles cmdFilesCheckAll.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwDelFilesList.Items.Count - 1
            If Me.lvwDelFilesList.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
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
            If Me.lvwDelFilesList.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
                Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked = Not (Me.lvwDelFilesList.Items.Item(lvwItemIndex).Checked)
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
                If Me.lvwDelFilesList.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
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
            If e.Item.SubItems(frmDelSStatesLvwColumn.Status).Text <> "" Then
                e.Item.Checked = False
                'System.Windows.Forms.MessageBox.Show("The file is already gone or you can't access it, quit trying.", "Stop trolling!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Me.DelFileList_indexChecked()
            Me.UI_UpdateFileInfo()
        End If
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdDelCheckedFiles_Click(sender As Object, e As EventArgs) Handles cmdFilesDeleteSelected.Click
        DeletFiles()
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

    Private Sub flpWindowBottom_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
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
        Me.flpWindowBottom.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.panelWindowTitle.BackgroundImage = currentTheme.BgImageTop
            Me.panelWindowTitle.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpWindowBottom.BackgroundImage = currentTheme.BgImageBottom
            Me.flpWindowBottom.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.panelWindowTitle.BackgroundImage = Nothing
            Me.flpWindowBottom.BackgroundImage = Nothing
        End If
        Me.Refresh()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub
#End Region

End Class