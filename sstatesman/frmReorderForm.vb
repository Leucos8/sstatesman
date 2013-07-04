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

    Dim ListsAreCurrentlyRefreshed As Boolean = False
    'Dim SStateList_TotalSizeSelected As Long = 0
    'Dim SStateList_TotalSizeBackupSelected As Long = 0
    'Dim SStateList_TotalSize As Long = 0
    'Dim SStateList_TotalSizeBackup As Long = 0

    Friend Enum ReorderListColumns
        Slot
        OldName
        NewName
    End Enum

#Region "Form - General"
    Private Sub UI_Enabler(pGlobalSwitch As Boolean)
        If pGlobalSwitch = True Then
            Me.ListsAreCurrentlyRefreshed = False
            Me.lvwReorderList.EndUpdate()
        Else
            Me.ListsAreCurrentlyRefreshed = True
            Me.lvwReorderList.BeginUpdate()
        End If
    End Sub

    Private Sub UI_Updater()

        If (Me.lvwReorderList.Items.Count = 0) Then
            'No savestates in list
            Me.cmdMoveUp.Enabled = False
            Me.cmdMoveLast.Enabled = False
            Me.cmdMoveDown.Enabled = False
            Me.cmdMoveFirst.Enabled = False
            Me.cmdReorder.Enabled = False
        Else
            Me.cmdReorder.Enabled = True
            If Me.lvwReorderList.SelectedItems.Count > 0 Then
                'First item selected
                If Me.lvwReorderList.SelectedItems.Item(0).Index = 0 Then
                    Me.cmdMoveFirst.Enabled = False
                    Me.cmdMoveUp.Enabled = False
                Else
                    Me.cmdMoveFirst.Enabled = True
                    Me.cmdMoveUp.Enabled = True
                End If

                'Last item selected
                If Me.lvwReorderList.SelectedItems.Item(0).Index = (Me.lvwReorderList.Items.Count - 1) Then
                    Me.cmdMoveLast.Enabled = False
                    Me.cmdMoveDown.Enabled = False
                Else
                    Me.cmdMoveLast.Enabled = True
                    Me.cmdMoveDown.Enabled = True
                End If

            End If

        End If
    End Sub

    Private Sub frmReorderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim imlLvwSStatesIcons As New ImageList With {.ImageSize = New Size(CInt(15 * DPIxScale) + 1, CInt(15 * DPIyScale) + 1)}
        imlLvwSStatesIcons.Images.Add(My.Resources.Icon_Savestate_16x16)
        imlLvwSStatesIcons.Images.Add(My.Resources.Icon_SavestateBackup_16x16)
        Me.lvwReorderList.SmallImageList = imlLvwSStatesIcons


        'Me.Location = My.Settings.frmDel_WindowLocation
        'Me.Size = My.Settings.frmDel_WindowSize
        'If My.Settings.frmMain_WindowState = FormWindowState.Minimized Then
        '    My.Settings.frmMain_WindowState = FormWindowState.Normal
        'End If
        'Me.WindowState = My.Settings.frmDel_WindowState

        'If My.Settings.frmDel_slvw_columnwidth IsNot Nothing Then
        '    If My.Settings.frmDel_slvw_columnwidth.Length = Me.lvwSStatesListToDelete.Columns.Count Then
        '        For i As Integer = 0 To Me.lvwSStatesListToDelete.Columns.Count - 1
        '            Me.lvwSStatesListToDelete.Columns(i).Width = My.Settings.frmDel_slvw_columnwidth(i)
        '        Next
        '    End If
        'End If

        Me.applyTheme()

        UI_Enabler(False)
        Me.ReorderList_Populate()
        Me.Rename_Preview()
        'Me.lvwSStatesListToDelete_indexCheckedFiles()
        UI_Enabler(True)
        UI_Updater()

    End Sub

    Private Sub frmReorderForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwReorderList.Items.Clear()
        Me.lvwReorderList.Groups.Clear()

        'My.Settings.frmDel_WindowState = Me.WindowState
        'If Not (Me.WindowState = FormWindowState.Maximized Or Me.WindowState = FormWindowState.Minimized) Then
        '    My.Settings.frmDel_WindowLocation = Me.Location
        '    My.Settings.frmDel_WindowSize = Me.Size
        'End If

        'Dim columnwidtharray As Integer() = {Me.StDelLvw_FileName.Width, Me.StDelLvw_Slot.Width, Me.StDelLvw_Backup.Width,
        '                                     Me.StDelLvw_Version.Width, Me.StDelLvw_LastWT.Width, Me.StDelLvw_Size.Width, Me.StDelLvw_Status.Width}
        'My.Settings.frmDel_slvw_columnwidth = columnwidtharray

        frmMain.GameList_Refresh()
    End Sub

    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReorder.Click
        Rename_Execute()
        frmMain.GameList_Refresh()
        UI_Enabler(False)
        Me.ReorderList_Populate()
        Me.Rename_Preview()
        'Me.lvwSStatesListToDelete_indexCheckedFiles()
        UI_Enabler(True)
        UI_Updater()
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
    Private Sub ReorderList_Populate()
        Me.lvwReorderList.Items.Clear()
        Me.lvwReorderList.Groups.Clear()

        If (frmMain.checkedGames.Count = 1) Then
            'Dim tmpGameInfo As New mdlGameDb.GameInfo
            Dim tmpSListItems As New List(Of ListViewItem)

            'Creation of the available slots, 10 x 2 = 20
            For i As Integer = 0 To 19
                Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = (i \ 2).ToString}
                If (Not ((i Mod 2) > 0)) Then
                    tmpLvwSListItem.ImageIndex = 0
                    'tmpLvwSListItem.Text &= " Standard"
                Else
                    tmpLvwSListItem.ImageIndex = 1
                    'tmpLvwSListItem.Text &= " Backup"
                End If
                tmpLvwSListItem.SubItems.Add("-")
                tmpLvwSListItem.SubItems.Add("Free slot")
                tmpSListItems.Add(tmpLvwSListItem)
            Next

            For Each tmpSavestate As KeyValuePair(Of String, Savestate) In SSMGameList.Games(frmMain.checkedGames(0)).Savestates
                If ((tmpSavestate.Value.Slot >= 0) And (tmpSavestate.Value.Slot <= 9)) Then
                    If (Not (tmpSavestate.Value.isBackup)) Then
                        tmpSListItems.Item(tmpSavestate.Value.Slot * 2).SubItems(ReorderListColumns.OldName).Text = tmpSavestate.Value.Name
                        tmpSListItems.Item(tmpSavestate.Value.Slot * 2).SubItems(ReorderListColumns.NewName).Text = tmpSavestate.Value.Name
                    Else
                        tmpSListItems.Item(tmpSavestate.Value.Slot * 2 + 1).SubItems(ReorderListColumns.OldName).Text = tmpSavestate.Value.Name
                        tmpSListItems.Item(tmpSavestate.Value.Slot * 2 + 1).SubItems(ReorderListColumns.NewName).Text = tmpSavestate.Value.Name
                    End If
                Else
                    Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = "Other"}
                    tmpLvwSListItem.SubItems.Add(tmpSavestate.Value.Name)
                    tmpLvwSListItem.SubItems.Add("")
                    tmpSListItems.Add(tmpLvwSListItem)
                End If
            Next

            mdlTheme.ListAlternateColors(tmpSListItems)
            Me.lvwReorderList.Items.AddRange(tmpSListItems.ToArray)
        End If
    End Sub

    Private Sub lvwReorderLisst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwReorderList.SelectedIndexChanged
        Me.UI_Updater()
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

    Private Sub cmdMoveUp_Click(sender As Object, e As EventArgs) Handles cmdMoveUp.Click
        UI_Enabler(False)
        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            Dim tmpPosition As Integer = Me.lvwReorderList.SelectedItems(0).Index
            Dim tmpOldName As String = Me.lvwReorderList.SelectedItems(0).SubItems(ReorderListColumns.OldName).Text
            Me.lvwReorderList.SelectedItems(0).SubItems(ReorderListColumns.OldName).Text = Me.lvwReorderList.Items(tmpPosition - 1).SubItems(ReorderListColumns.OldName).Text
            Me.lvwReorderList.Items(tmpPosition - 1).SubItems(ReorderListColumns.OldName).Text = tmpOldName
            Me.lvwReorderList.SelectedItems(0).Selected = False
            Me.lvwReorderList.Items(tmpPosition - 1).Selected = True
            Me.lvwReorderList.Items(tmpPosition - 1).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enabler(True)
    End Sub

    Private Sub cmdMoveDown_Click(sender As Object, e As EventArgs) Handles cmdMoveDown.Click
        UI_Enabler(False)
        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            Dim tmpPosition As Integer = Me.lvwReorderList.SelectedItems(0).Index
            Dim tmpOldName As String = Me.lvwReorderList.SelectedItems(0).SubItems(ReorderListColumns.OldName).Text
            Me.lvwReorderList.SelectedItems(0).SubItems(ReorderListColumns.OldName).Text = Me.lvwReorderList.Items(tmpPosition + 1).SubItems(ReorderListColumns.OldName).Text
            Me.lvwReorderList.Items(tmpPosition + 1).SubItems(ReorderListColumns.OldName).Text = tmpOldName
            Me.lvwReorderList.SelectedItems(0).Selected = False
            Me.lvwReorderList.Items(tmpPosition + 1).Selected = True
            Me.lvwReorderList.Items(tmpPosition + 1).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enabler(True)
    End Sub

    Private Sub cmdMoveFirst_Click(sender As Object, e As EventArgs) Handles cmdMoveFirst.Click
        UI_Enabler(False)
        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            Dim tmpPosition As Integer = Me.lvwReorderList.SelectedItems(0).Index
            Dim tmpOldName As String = Me.lvwReorderList.SelectedItems(0).SubItems(ReorderListColumns.OldName).Text
            For i = tmpPosition To 1 Step -1
                Me.lvwReorderList.Items(i).SubItems(ReorderListColumns.OldName).Text = Me.lvwReorderList.Items(i - 1).SubItems(ReorderListColumns.OldName).Text
            Next
            Me.lvwReorderList.Items(tmpPosition).Selected = False
            Me.lvwReorderList.Items(0).SubItems(ReorderListColumns.OldName).Text = tmpOldName
            Me.lvwReorderList.Items(0).Selected = True
            Me.lvwReorderList.Items(0).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enabler(True)
    End Sub

    Private Sub cmdMoveLast_Click(sender As Object, e As EventArgs) Handles cmdMoveLast.Click
        UI_Enabler(False)
        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            Dim tmpPosition As Integer = Me.lvwReorderList.SelectedItems(0).Index
            Dim tmpOldName As String = Me.lvwReorderList.SelectedItems(0).SubItems(ReorderListColumns.OldName).Text
            For i = tmpPosition + 1 To Me.lvwReorderList.Items.Count - 1
                Me.lvwReorderList.Items(i - 1).SubItems(ReorderListColumns.OldName).Text = Me.lvwReorderList.Items(i).SubItems(ReorderListColumns.OldName).Text
            Next
            Me.lvwReorderList.Items(tmpPosition).Selected = False
            Me.lvwReorderList.Items(Me.lvwReorderList.Items.Count - 1).SubItems(ReorderListColumns.OldName).Text = tmpOldName
            Me.lvwReorderList.Items(Me.lvwReorderList.Items.Count - 1).Selected = True
            Me.lvwReorderList.Items(Me.lvwReorderList.Items.Count - 1).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enabler(True)
    End Sub

    Private Sub Rename_Preview()
        If Me.lvwReorderList.Items.Count > 0 Then
            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If tmpListItem.SubItems(ReorderListColumns.OldName).Text = "-" Then
                    'Free slot, no savestate
                    tmpListItem.SubItems(ReorderListColumns.NewName).Text = "Free slot"
                ElseIf Not ((tmpListItem.SubItems(ReorderListColumns.OldName).Text = tmpListItem.SubItems(ReorderListColumns.NewName).Text)) Or _
                            (tmpListItem.Text = "Other") Then
                    'Creating the new name
                    tmpListItem.SubItems(ReorderListColumns.NewName).Text = frmMain.checkedGames(0) & " (" & SSMGameList.Games(frmMain.checkedGames(0)).CRC & ")." & (tmpListItem.Index \ 2).ToString("00") & My.Settings.PCSX2_SStateExt
                    If Not (((tmpListItem.Index \ 2) >= 0) And ((tmpListItem.Index \ 2) <= 9)) Then
                        'if it is an incorrect slot
                        tmpListItem.SubItems(ReorderListColumns.NewName).Text = tmpListItem.SubItems(ReorderListColumns.NewName).Text.Insert(tmpListItem.SubItems(ReorderListColumns.NewName).Text.IndexOf("."c) + 1, "X")
                    ElseIf (tmpListItem.Index Mod 2) > 0 Then
                        'Adding backup extension if backup
                        tmpListItem.SubItems(ReorderListColumns.NewName).Text &= My.Settings.PCSX2_SStateExtBackup
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Rename_Execute()
        If Me.lvwReorderList.Items.Count > 0 Then
            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If Not ((tmpListItem.SubItems(ReorderListColumns.OldName).Text = "-") Or _
                        (tmpListItem.SubItems(ReorderListColumns.OldName).Text = tmpListItem.SubItems(ReorderListColumns.NewName).Text)) Then
                    Try
                        File.Move(Path.Combine(My.Settings.PCSX2_PathSState, tmpListItem.SubItems(ReorderListColumns.OldName).Text), _
                                  Path.Combine(My.Settings.PCSX2_PathSState, tmpListItem.SubItems(ReorderListColumns.NewName).Text & ".tmp"))
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next

            For Each tmpFileName As String In Directory.EnumerateFiles(My.Settings.PCSX2_PathSState, "*.tmp")
                Try
                    File.Move(Path.Combine(My.Settings.PCSX2_PathSState, tmpFileName), _
                              Path.Combine(My.Settings.PCSX2_PathSState, tmpFileName.Remove(tmpFileName.Length - 4)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
        End If
    End Sub
End Class