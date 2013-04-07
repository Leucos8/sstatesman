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

    Dim ListsAreCurrentlyRefreshed As Boolean = False
    Dim SStateList_TotalSizeSelected As Long = 0
    Dim SStateList_TotalSizeBackupSelected As Long = 0
    Dim SStateList_TotalSize As Long = 0
    Dim SStateList_TotalSizeBackup As Long = 0

    Friend Enum frmDelSStatesLvwColumn
        FileName
        Slot
        Version
        LastWriteDate
        Size
        Status
    End Enum

#Region "Form - General"
    Private Sub UI_Enabler(pGlobalSwitch As Boolean)
        If pGlobalSwitch = True Then
            Me.ListsAreCurrentlyRefreshed = False
            Me.lvwSStatesListToDelete.EndUpdate()
        Else
            Me.ListsAreCurrentlyRefreshed = True
            Me.lvwSStatesListToDelete.BeginUpdate()
        End If
    End Sub

    Private Sub UI_Updater()
        Me.txtSStateListSelection.Text = String.Format("{0:N0} | {1:N0} files", Me.lvwSStatesListToDelete.CheckedItems.Count, Me.lvwSStatesListToDelete.Items.Count)
        Me.txtSize.Text = String.Format("{0:N2} | {1:N2} MB", Me.SStateList_TotalSizeSelected / 1024 ^ 2, Me.SStateList_TotalSize / 1024 ^ 2)
        Me.txtSizeBackup.Text = String.Format("{0:N2} | {1:N2} MB", Me.SStateList_TotalSizeBackupSelected / 1024 ^ 2, Me.SStateList_TotalSizeBackup / 1024 ^ 2)

        If Me.lvwSStatesListToDelete.Items.Count = 0 Then
            'No savestates in list
            'Me.txtSStateListSelection.Text = String.Format("{0:N0} | {1:N0}", 0, 0)
            'Me.txtSize.Text = String.Format("{0:N2} | {1:N2} MB", 0, 0)
            'Me.txtSizeBackup.Text = String.Format("{0:N2} | {1:N2} MB", 0, 0)

            Me.cmdSStateSelectAll.Enabled = False
            Me.cmdSStateSelectInvert.Enabled = False
            Me.cmdSStateSelectNone.Enabled = False
            Me.cmdSStateSelectBackup.Enabled = False
            Me.cmdDeleteSStateSelected.Enabled = False
        Else


            Me.cmdSStateSelectInvert.Enabled = True
            Me.cmdSStateSelectBackup.Enabled = True

            If Me.lvwSStatesListToDelete.CheckedItems.Count > 0 Then

                Me.cmdSStateSelectNone.Enabled = True
                Me.cmdDeleteSStateSelected.Enabled = True

                If Me.lvwSStatesListToDelete.Items.Count = Me.lvwSStatesListToDelete.CheckedItems.Count Then
                    Me.cmdSStateSelectAll.Enabled = False
                Else
                    Me.cmdSStateSelectAll.Enabled = True
                End If

            Else
                Me.cmdSStateSelectNone.Enabled = False
                Me.cmdSStateSelectAll.Enabled = True
                Me.cmdDeleteSStateSelected.Enabled = False
            End If
        End If
    End Sub

    Private Sub SStates_Deleter()
        Me.UI_Enabler(False)
        For Each tmpItem As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems
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

                        Me.lvwSStatesListToDelete.Items(tmpItem.Index).SubItems(frmDelSStatesLvwColumn.Status).Text = "File deleted successfully."
                        Me.lvwSStatesListToDelete.Items(tmpItem.Index).BackColor = Color.FromArgb(255, 192, 255, 192)
                    Catch ex As Exception
                        Me.lvwSStatesListToDelete.Items(tmpItem.Index).SubItems(frmDelSStatesLvwColumn.Status).Text = ex.Message
                        Me.lvwSStatesListToDelete.Items(tmpItem.Index).BackColor = Color.FromArgb(255, 255, 192, 192)
                    Finally
                        Me.lvwSStatesListToDelete.Items(tmpItem.Index).Checked = False
                    End Try
                End If
            End If


        Next
        Me.UI_Updater()
        Me.UI_Enabler(True)
    End Sub

    Private Sub frmDeleteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim imlLvwCheckboxes As New System.Windows.Forms.ImageList With {.ImageSize = New System.Drawing.Size(CInt(10 * DPIxScale + 1), CInt(10 * DPIyScale) + 1)}
        imlLvwCheckboxes.Images.Add(My.Resources.Checkbox_Unchecked_22x22)
        imlLvwCheckboxes.Images.Add(My.Resources.Checkbox_Checked_22x22)
        Me.lvwSStatesListToDelete.StateImageList = imlLvwCheckboxes

        Dim imlLvwSStatesIcons As New ImageList With {.ImageSize = New Size(CInt(15 * DPIxScale) + 1, CInt(15 * DPIyScale) + 1)}
        imlLvwSStatesIcons.Images.Add(My.Resources.Icon_Savestate_16x16)
        imlLvwSStatesIcons.Images.Add(My.Resources.Icon_SavestateBackup_16x16)
        Me.lvwSStatesListToDelete.SmallImageList = imlLvwSStatesIcons

        Me.Location = My.Settings.frmDel_WindowLocation
        Me.Size = My.Settings.frmDel_WindowSize
        If My.Settings.frmMain_WindowState = FormWindowState.Minimized Then
            My.Settings.frmMain_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmDel_WindowState

        If My.Settings.frmDel_slvw_columnwidth IsNot Nothing Then
            If My.Settings.frmDel_slvw_columnwidth.Length = Me.lvwSStatesListToDelete.Columns.Count Then
                For i As Integer = 0 To Me.lvwSStatesListToDelete.Columns.Count - 1
                    Me.lvwSStatesListToDelete.Columns(i).Width = My.Settings.frmDel_slvw_columnwidth(i)
                Next
            End If
        End If

        Me.applyTheme()

        UI_Enabler(False)
        Me.lvwSStatesList_Populate()
        Me.lvwSStatesListToDelete_indexCheckedFiles()
        UI_Enabler(True)
        UI_Updater()

    End Sub

    Private Sub frmDeleteForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwSStatesListToDelete.Items.Clear()
        Me.lvwSStatesListToDelete.Groups.Clear()
        Me.SStateList_TotalSize = 0
        Me.SStateList_TotalSizeBackup = 0


        My.Settings.frmDel_WindowState = Me.WindowState
        If Not (Me.WindowState = FormWindowState.Maximized Or Me.WindowState = FormWindowState.Minimized) Then
            My.Settings.frmDel_WindowLocation = Me.Location
            My.Settings.frmDel_WindowSize = Me.Size
        End If

        Dim columnwidtharray As Integer() = {Me.StDelLvw_FileName.Width, Me.StDelLvw_Slot.Width,
                                             Me.StDelLvw_Version.Width, Me.StDelLvw_LastWT.Width, Me.StDelLvw_Size.Width, Me.StDelLvw_Status.Width}
        My.Settings.frmDel_slvw_columnwidth = columnwidtharray

        frmMain.List_Refresher()
    End Sub

    Private Sub cmdDeleteSStateSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSStateSelected.Click
        SStates_Deleter()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "Windows state buttons"
    Private Sub cmdWindowMaximize_MouseEnter(sender As Object, e As EventArgs) Handles cmdWindowMaximize.MouseEnter
        If Me.WindowState = FormWindowState.Normal Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximizeW_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestoreW_12x12
        End If
    End Sub

    Private Sub cmdWindowMaximize_MouseLeave(sender As Object, e As EventArgs) Handles cmdWindowMaximize.MouseLeave
        If Me.WindowState = FormWindowState.Normal Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximize_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestore_12x12
        End If
    End Sub

    Private Sub cmdWindowMaximize_Click(sender As System.Object, e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestore_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximize_12x12
        End If
    End Sub

    Private Sub cmdWindowClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()
    End Sub

    Private Sub frmDeleteForm_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Normal Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximize_12x12
            Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 0, CInt(6 * DPIxScale), 0)
            'Me.Padding = New Padding(Math.Abs(Me.Top))
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestore_12x12
            Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            'Me.Padding = New Padding(1)
        End If
    End Sub
#End Region

#Region "SStatesList management"
    Private Sub lvwSStatesList_Populate()
        Me.lvwSStatesListToDelete.Items.Clear()
        Me.lvwSStatesListToDelete.Groups.Clear()

        Dim tmpGameInfo As New GameInfo
        Dim tmpSListGroups As New List(Of ListViewGroup)
        Dim tmpSListItems As New List(Of ListViewItem)

        For Each tmpSerial As System.String In frmmain.checkedGames

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
                                    SStateList_TotalSize += tmpSavestate.Value.Length
                                Else
                                    tmpLvwSListItem.ImageIndex = 1
                                    SStateList_TotalSizeBackup += tmpSavestate.Value.Length
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
        Me.lvwSStatesListToDelete.Groups.AddRange(tmpSListGroups.ToArray)
        Me.lvwSStatesListToDelete.Items.AddRange(tmpSListItems.ToArray)
        mdlTheme.ListAlternateColors(Me.lvwSStatesListToDelete)
    End Sub

    Private Sub lvwSStatesListToDelete_indexCheckedFiles()
        Me.SStateList_TotalSizeSelected = 0
        Me.SStateList_TotalSizeBackupSelected = 0

        If Me.lvwSStatesListToDelete.CheckedItems.Count > 0 Then
            For Each tmpLvwSListItemChecked As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems

                Dim tmpGamesListItem As New GamesList_Item
                If SSMGameList.Games.TryGetValue(Savestate.GetSerial(tmpLvwSListItemChecked.Name), tmpGamesListItem) Then
                    Dim tmpSavestate As New Savestate
                    If tmpGamesListItem.Savestates.TryGetValue(tmpLvwSListItemChecked.Name, tmpSavestate) Then
                        If tmpSavestate.isBackup Then
                            SStateList_TotalSizeBackupSelected += tmpSavestate.Length
                        Else
                            SStateList_TotalSizeSelected += tmpSavestate.Length
                        End If
                    End If
                End If

            Next
        End If

    End Sub

    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Me.UI_Enabler(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.lvwSStatesListToDelete_indexCheckedFiles()
        Me.UI_Updater()
        Me.UI_Enabler(True)
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Me.UI_Enabler(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.lvwSStatesListToDelete_indexCheckedFiles()
        Me.UI_Updater()
        Me.UI_Enabler(True)
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Me.UI_Enabler(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
            Else
                If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
                    Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
                End If
            End If
        Next
        Me.lvwSStatesListToDelete_indexCheckedFiles()
        Me.UI_Updater()
        Me.UI_Enabler(True)
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UI_Enabler(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Savestate.isBackup(Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Name) Then
                If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
                    Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
                End If
            Else
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.lvwSStatesListToDelete_indexCheckedFiles()
        Me.UI_Updater()
        Me.UI_Enabler(True)
    End Sub

    Private Sub lvwSStatesListToDelete_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesListToDelete.ItemChecked
        If ListsAreCurrentlyRefreshed = False Then
            If e.Item.SubItems(frmDelSStatesLvwColumn.Status).Text <> "" Then
                e.Item.Checked = False
                'System.Windows.Forms.MessageBox.Show("The file is already gone or you can't access it, quit trying.", "Stop trolling!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Me.lvwSStatesListToDelete_indexCheckedFiles()
            Me.UI_Updater()
        End If
    End Sub
#End Region

#Region "UI paint"
    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim rectoolbar As New Rectangle(0, CInt(8 * DPIyScale), CInt(23 * DPIxScale) + 1, CInt(38 * DPIyScale) + 1)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(rectoolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 90)
        e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
        If Me.imgWindowGradientIcon.Width > 0 And Me.imgWindowGradientIcon.Height > 0 Then
            rectoolbar = New Rectangle(Me.imgWindowGradientIcon.Location, Me.imgWindowGradientIcon.Size)
            linGrBrushToolbar = New Drawing2D.LinearGradientBrush(rectoolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 90)
            e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
        End If
        If (panelWindowTitle.Height > CInt(4 * DPIyScale) + 1) And (panelWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                rectoolbar = New Rectangle(0, panelWindowTitle.Height - CInt(4 * DPIyScale), panelWindowTitle.Width + 1, CInt(3 * DPIyScale) + 1)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(rectoolbar, Color.Transparent, Color.DarkGray, 90)
                rectoolbar.Y += 1
                e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If flpWindowBottom.Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, flpWindowBottom.Width, 0)
        End If
    End Sub

    Private Sub applyTheme()
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
    End Sub
#End Region

End Class