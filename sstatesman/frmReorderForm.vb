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

    Friend Enum frmDelSStatesLvwColumn
        FileName
        Slot
        Backup
        Version
        LastWriteDate
        Size
        Status
    End Enum

#Region "Form - General"
    Private Sub UI_Enabler(pGlobalSwitch As Boolean)
        If pGlobalSwitch = True Then
            Me.ListsAreCurrentlyRefreshed = False
            Me.lvwSStatesListToReorder.EndUpdate()
        Else
            Me.ListsAreCurrentlyRefreshed = True
            Me.lvwSStatesListToReorder.BeginUpdate()
        End If
    End Sub

    Private Sub UI_Updater()

        If (Me.lvwSStatesListToReorder.Items.Count = 0) Or (Me.lvwSStatesListToReorder.SelectedItems.Count = 0) Then
            'No savestates in list
            'Me.txtSStateListSelection.Text = String.Format("{0:N0} | {1:N0}", 0, 0)
            'Me.txtSize.Text = String.Format("{0:N2} | {1:N2} MB", 0, 0)
            'Me.txtSizeBackup.Text = String.Format("{0:N2} | {1:N2} MB", 0, 0)

            Me.cmdSStateMoveUp.Enabled = False
            Me.cmdSStateMoveLast.Enabled = False
            Me.cmdSStateMoveDown.Enabled = False
            Me.cmdSStateMoveFirst.Enabled = False
            Me.cmdReorder.Enabled = False
        Else
            Me.cmdReorder.Enabled = True
            If Me.lvwSStatesListToReorder.SelectedItems.Count > 0 Then
                If Me.lvwSStatesListToReorder.SelectedItems.Item(0).Index = 0 Then
                    Me.cmdSStateMoveFirst.Enabled = False
                    Me.cmdSStateMoveUp.Enabled = False
                Else
                    Me.cmdSStateMoveFirst.Enabled = True
                    Me.cmdSStateMoveUp.Enabled = True
                End If

                If Me.lvwSStatesListToReorder.SelectedItems.Item(0).Index = (Me.lvwSStatesListToReorder.Items.Count - 1) Then
                    Me.cmdSStateMoveLast.Enabled = False
                    Me.cmdSStateMoveDown.Enabled = False
                Else
                    Me.cmdSStateMoveLast.Enabled = True
                    Me.cmdSStateMoveDown.Enabled = True
                End If


            End If
            'Me.cmdSStateMoveLast.Enabled = True

            'If Me.lvwSStatesListToDelete.CheckedItems.Count > 0 Then

            '    Me.cmdSStateMoveDown.Enabled = True

            '    If Me.lvwSStatesListToDelete.Items.Count = Me.lvwSStatesListToDelete.CheckedItems.Count Then
            '        Me.cmdSStateMoveUp.Enabled = False
            '    Else
            '        Me.cmdSStateMoveUp.Enabled = True
            '    End If

            'Else
            '    Me.cmdSStateMoveDown.Enabled = False
            '    Me.cmdSStateMoveUp.Enabled = True
            '    Me.cmdReorder.Enabled = False
            'End If
        End If
    End Sub

    Private Sub frmReorderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim imlLvwCheckboxes As New System.Windows.Forms.ImageList
        'imlLvwCheckboxes.ImageSize = New System.Drawing.Size(CInt(10 * DPIxScale + 1), CInt(10 * DPIyScale) + 1)
        'imlLvwCheckboxes.Images.Add(My.Resources.Checkbox_Unchecked_22x22)
        'imlLvwCheckboxes.Images.Add(My.Resources.Checkbox_Checked_22x22)
        'Me.lvwSStatesListToDelete.StateImageList = imlLvwCheckboxes


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
        Me.lvwSStatesList_Populate()
        'Me.lvwSStatesListToDelete_indexCheckedFiles()
        UI_Enabler(True)
        UI_Updater()

    End Sub

    Private Sub frmReorderForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwSStatesListToReorder.Items.Clear()
        Me.lvwSStatesListToReorder.Groups.Clear()

        'My.Settings.frmDel_WindowState = Me.WindowState
        'If Not (Me.WindowState = FormWindowState.Maximized Or Me.WindowState = FormWindowState.Minimized) Then
        '    My.Settings.frmDel_WindowLocation = Me.Location
        '    My.Settings.frmDel_WindowSize = Me.Size
        'End If

        'Dim columnwidtharray As Integer() = {Me.StDelLvw_FileName.Width, Me.StDelLvw_Slot.Width, Me.StDelLvw_Backup.Width,
        '                                     Me.StDelLvw_Version.Width, Me.StDelLvw_LastWT.Width, Me.StDelLvw_Size.Width, Me.StDelLvw_Status.Width}
        'My.Settings.frmDel_slvw_columnwidth = columnwidtharray

        frmMain.List_Refresher()
    End Sub

    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReorder.Click
        'SStates_Deleter()
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
        Me.lvwSStatesListToReorder.Items.Clear()
        Me.lvwSStatesListToReorder.Groups.Clear()

        If mdlMain.checkedGames.Count > 0 Then
            Dim tmpGameInfo As New mdlGameDb.GameInfo
            'Dim tmpSListGroups As New List(Of ListViewGroup)
            Dim tmpSListGroup As New ListViewGroup
            Dim tmpSListItems As New List(Of ListViewItem)


        End If
        'For Each tmpSerial As System.String In mdlMain.checkedGames

        '    Dim tmpGamesListItem As New GamesList_Item
        '    If mdlFileList.GamesList.TryGetValue(tmpSerial, tmpGamesListItem) Then

        '        'Creation of the header
        '        tmpGameInfo = PCSX2GameDb.RecordExtract(tmpSerial)
        '        Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
        '            .Header = tmpGameInfo.ToString(),
        '            .HeaderAlignment = HorizontalAlignment.Left,
        '            .Name = tmpGameInfo.Serial}

        '        tmpSListGroups.Add(tmpLvwSListGroup)


        '        If mdlFileList.GamesList(tmpSerial).Savestates.Values.Count > 0 Then
        '            For Each tmpSavestate As KeyValuePair(Of String, Savestate) In mdlFileList.GamesList(tmpSerial).Savestates

        '                Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSavestate.Key,
        '                                                                                       .Group = tmpLvwSListGroup,
        '                                                                                       .Name = tmpSavestate.Key}
        '                tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Slot.ToString,
        '                                                   tmpSavestate.Value.Backup.ToString,
        '                                                   tmpSavestate.Value.Version,
        '                                                   tmpSavestate.Value.LastWriteTime.ToString,
        '                                                   System.String.Format("{0:N2} MB", tmpSavestate.Value.Length / 1024 ^ 2)})
        '                If IO.File.Exists(IO.Path.Combine(My.Settings.PCSX2_PathSState, tmpSavestate.Key)) Then
        '                    tmpLvwSListItem.SubItems.Add("")
        '                    tmpLvwSListItem.Checked = True
        '                    'If tmpSavestate.Value.Backup = False Then
        '                    '    SStateList_TotalSize += tmpSavestate.Value.Length
        '                    'Else
        '                    '    SStateList_TotalSizeBackup += tmpSavestate.Value.Length
        '                    'End If
        '                Else
        '                    tmpLvwSListItem.SubItems.Add("Error: file not found or inaccessible.")
        '                    tmpLvwSListItem.Checked = False
        '                    tmpLvwSListItem.BackColor = Color.FromArgb(255, 255, 192, 192)
        '                End If

        '                tmpSListItems.Add(tmpLvwSListItem)
        '            Next
        '        End If
        '    End If
        'Next
        'Me.lvwSStatesListToReorder.Groups.AddRange(tmpSListGroups.ToArray)
        'Me.lvwSStatesListToReorder.Items.AddRange(tmpSListItems.ToArray)
        mdlTheme.ListAlternateColors(Me.lvwSStatesListToReorder)
    End Sub

    Private Sub lvwSStatesListToReorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwSStatesListToReorder.SelectedIndexChanged
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

End Class