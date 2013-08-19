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
    Dim lastWindowState As FormWindowState  'Needed to know if a form resize changed the windowstate

    Dim ListsAreRefreshed As Boolean = False

    Dim FilesRenamed As Boolean = False
    'Const StandardSlot_LowerBound As Integer = 0
    'Const StandardSlot_UpperBound As Integer = 9

    Friend Enum ReorderListColumns
        Slot
        OldName
        NewName
        Status
    End Enum

    Enum ReorderFileStatus
        FreeSlot        'No savestate
        Idle            'Current file name matches new name
        RenamePending   'Current file name is different from new name
        RenamedTmp      'Renaming phase 1 (added the .tmp extension)
        Renamed_OK      'The file has been renamed succesfully
        FileNotFound    'The file has not been found when renaming
        FileAlreadyExist 'A file with the target name already exist
        OtherError      'Another error has been encountered
    End Enum

    Private Function AddTmpExtension(pFilename As String) As String
        Const tmpExtension As String = ".tmp"
        Return pFilename & tmpExtension
    End Function

#Region "Form"
    Private Sub frmReorderForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Form load start.")

        '==================
        'Window preparation
        '==================

        '-----
        'Theme
        '-----
        Me.applyTheme()

        Me.lvwReorderList.SmallImageList = mdlTheme.imlLvwItemIcons

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "1/2 Theme & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================



        UI_Enable(False)
        Me.ReorderList_AddSavestates()
        Me.Rename_Preview()
        UI_Updater()
        UI_Enable(True)

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "2/2 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "All done.", sw.ElapsedTicks)
    End Sub

    Private Sub frmReorderForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwReorderList.Items.Clear()
        Me.lvwReorderList.Groups.Clear()

        frmMain.GameList_Refresh()
    End Sub
#End Region

#Region "UI - General"
    ''' <summary>Handles the filelist beginupdate and endupdate methods</summary>
    ''' <param name="pSwitch">True to end the update, False to begin the update</param>
    Private Sub UI_Enable(pSwitch As Boolean)
        Me.ListsAreRefreshed = Not (pSwitch)
        If pSwitch = True Then
            Me.lvwReorderList.EndUpdate()
        Else
            Me.lvwReorderList.BeginUpdate()
        End If
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.UI_Enable, pSwitch.ToString)
    End Sub

    ''' <summary>Updates the UI status.</summary>
    Private Sub UI_Updater()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If (Me.lvwReorderList.Items.Count = 0) Or FilesRenamed Then
            '==========================================
            'No files in list or file have been renamed
            '==========================================

            Me.cmdMoveUp.Enabled = False
            Me.cmdMoveLast.Enabled = False
            Me.cmdMoveDown.Enabled = False
            Me.cmdMoveFirst.Enabled = False

            Me.cmdReorder.Enabled = False
        Else
            '=================
            'Files are present
            '=================
            Me.cmdReorder.Enabled = True

            If Me.lvwReorderList.SelectedItems.Count > 0 Then
                'First item selected
                If Me.lvwReorderList.Items(0).Selected Then
                    Me.cmdMoveFirst.Enabled = False
                    Me.cmdMoveUp.Enabled = False
                Else
                    Me.cmdMoveFirst.Enabled = True
                    Me.cmdMoveUp.Enabled = True
                End If

                'Last item selected
                If Me.lvwReorderList.Items(Me.lvwReorderList.Items.Count - 1).Selected Then
                    Me.cmdMoveLast.Enabled = False
                    Me.cmdMoveDown.Enabled = False
                Else
                    Me.cmdMoveLast.Enabled = True
                    Me.cmdMoveDown.Enabled = True
                End If

            ElseIf Me.lvwReorderList.SelectedItems.Count = 0 Then
                Me.cmdMoveUp.Enabled = False
                Me.cmdMoveLast.Enabled = False
                Me.cmdMoveDown.Enabled = False
                Me.cmdMoveFirst.Enabled = False
            End If

        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReorder.Click
        Me.Rename_Execute()
        frmMain.GameList_Refresh()
        Me.UI_Enable(False)
        Me.ReorderList_AddSavestates()
        Me.Rename_Preview()
        Me.UI_Updater()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
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

#Region "UI - FileList"
    Private Sub ReorderList_AddSavestates()
        Dim sw As New Stopwatch
        sw.Start()

        'clear items and groups.
        Me.lvwReorderList.Items.Clear()
        Me.lvwReorderList.Groups.Clear()

        'only one game need to be selected
        If frmMain.checkedGames.Count = 1 Then
            'GameList contains the serial
            If SSMGameList.Games.ContainsKey(frmMain.checkedGames(0)) Then

                'Creation of the header
                Dim tmpGameInfo As New mdlGameDb.GameInfo
                tmpGameInfo = PCSX2GameDb.Extract(frmMain.checkedGames(0))
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                    .Header = tmpGameInfo.ToString(),
                    .HeaderAlignment = HorizontalAlignment.Left,
                    .Name = tmpGameInfo.Serial}

                Dim tmpSListItems As New List(Of ListViewItem)

                'Creation of the available slots, 10 x 2 = 20
                Dim currentSlot As Integer = My.Settings.PCSX2_SStateSlotLowerBound
                For i As Integer = 0 To (My.Settings.PCSX2_SStateSlotUpperBound - My.Settings.PCSX2_SStateSlotLowerBound + 1) * 2 - 1
                    Dim tmpLvwSListItem As New ListViewItem With {.Text = (My.Settings.PCSX2_SStateSlotLowerBound + i \ 2).ToString, _
                                                                  .Group = tmpLvwSListGroup, _
                                                                  .Tag = ReorderFileStatus.FreeSlot}
                    If Not ((i Mod 2) > 0) Then
                        tmpLvwSListItem.ImageIndex = 0
                        'tmpLvwSListItem.Text &= " Standard"
                    Else
                        tmpLvwSListItem.ImageIndex = 1
                        'tmpLvwSListItem.Text &= " Backup"
                    End If
                    tmpLvwSListItem.SubItems.AddRange({"-", "-", ""})
                    tmpSListItems.Add(tmpLvwSListItem)
                Next

                'Adding savestates
                For Each tmpSavestate As KeyValuePair(Of String, Savestate) In SSMGameList.Games(frmMain.checkedGames(0)).Savestates
                    Dim listRef As Integer = tmpSavestate.Value.Slot    'Used for list index
                    If (listRef >= My.Settings.PCSX2_SStateSlotLowerBound) And (listRef <= My.Settings.PCSX2_SStateSlotUpperBound) Then
                        'Even numbers are for savestates
                        listRef -= My.Settings.PCSX2_SStateSlotLowerBound
                        listRef *= 2
                        If tmpSavestate.Value.isBackup Then
                            'Odd numbers are for backups
                            listRef += 1
                        End If

                        'Old name = new name, status idle
                        tmpSListItems.Item(listRef).SubItems(ReorderListColumns.OldName).Text = tmpSavestate.Value.Name
                        tmpSListItems.Item(listRef).SubItems(ReorderListColumns.NewName).Text = tmpSavestate.Value.Name
                        tmpSListItems.Item(listRef).Tag = ReorderFileStatus.Idle
                    Else
                        'This savestate has an out of bounds index, a new list item is added
                        Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = "Other", _
                                                                                           .Tag = ReorderFileStatus.Idle, _
                                                                                           .Group = tmpLvwSListGroup, _
                                                                                           .ImageIndex = 0}
                        tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Name, tmpSavestate.Value.Name, ""})
                        tmpSListItems.Add(tmpLvwSListItem)
                        SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                         String.Format("Slot value not valid for {0}.", tmpSavestate.Value.Name))
                    End If
                Next

                mdlTheme.ListAlternateColors(tmpSListItems)

                Me.lvwReorderList.Groups.Add(tmpLvwSListGroup)
                Me.lvwReorderList.Items.AddRange(tmpSListItems.ToArray)
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
                         String.Format("Listed {0:N0} savestates.", Me.lvwReorderList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub lvwReorderLisst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwReorderList.SelectedIndexChanged
        If Not (Me.ListsAreRefreshed) Then
            Me.UI_Updater()
        End If
    End Sub

    Private Sub MoveLwItems(ByRef pListView As ListView, pStep As Integer)

        'At least one item needs to be selected
        If pListView.SelectedItems.Count > 0 Then

            Dim LowerBound, UpperBound As Integer   'Bounds for the loop that moves the items
            If pStep > 0 Then
                'pStep > 0, move down
                LowerBound = pListView.SelectedItems.Count - 1
                UpperBound = 0

                If ((pListView.Items.Count - 1) - pListView.SelectedItems.Item(pListView.SelectedItems.Count - 1).Index) < pStep Then
                    pStep = (pListView.Items.Count - 1) - pListView.SelectedItems.Item(pListView.SelectedItems.Count - 1).Index
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                     "Move ListViewItems step has been recalculated.")
                End If

            ElseIf pStep < 0 Then
                'pStep < 0, move up
                LowerBound = 0
                UpperBound = pListView.SelectedItems.Count - 1

                If pListView.SelectedItems.Item(0).Index < -pStep Then
                    pStep = -pListView.SelectedItems.Item(0).Index
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                     "Move ListViewItems step has been recalculated.")
                End If

            End If

            If pStep = 0 Then
                SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                                 "Move ListViewItems step is 0. There is no need to move ListViewItems.")
                Exit Sub
            End If

            For i As Integer = LowerBound To UpperBound Step Math.Sign(-pStep)
                'I love references! These two act like the variable used in a For Each loop
                Dim tmpItemSelected As ListViewItem = pListView.SelectedItems(i)
                Dim tmpItemSwapped As ListViewItem = pListView.Items(tmpItemSelected.Index + pStep)
                'Backing up swapped values
                Dim tmpPosition As Integer = tmpItemSelected.Index
                Dim tmpOldName As String = tmpItemSelected.SubItems(ReorderListColumns.OldName).Text
                Dim tmpTag As ReorderFileStatus = CType(tmpItemSelected.Tag, ReorderFileStatus)
                'Swapping names
                tmpItemSelected.SubItems(ReorderListColumns.OldName).Text = tmpItemSwapped.SubItems(ReorderListColumns.OldName).Text
                tmpItemSwapped.SubItems(ReorderListColumns.OldName).Text = tmpOldName
                'Tags
                tmpItemSelected.Tag = tmpItemSwapped.Tag
                tmpItemSwapped.Tag = tmpTag
                If ReorderFileStatus.Idle.Equals(tmpItemSelected.Tag) Then
                    tmpItemSelected.Tag = ReorderFileStatus.RenamePending
                End If
                If ReorderFileStatus.Idle.Equals(tmpItemSwapped.Tag) Then
                    tmpItemSwapped.Tag = ReorderFileStatus.RenamePending
                End If
                'Updated selections
                tmpItemSelected.Selected = tmpItemSwapped.Selected
                tmpItemSwapped.Selected = True

            Next

            'SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.List, _
            '                 String.Format("Moved {0:N0} savestates by {1}.", pListView.SelectedItems.Count, pStep))
        Else
            SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.List, _
                             "There are no ListViewItems selected to be moved.")
        End If

    End Sub

    Private Sub cmdMoveUp_Click(sender As Object, e As EventArgs) Handles cmdMoveUp.Click
        UI_Enable(False)

        'At least one item needs to be selected
        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            Me.MoveLwItems(lvwReorderList, -1)
            'Visibility
            Me.lvwReorderList.SelectedItems(0).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enable(True)
    End Sub

    Private Sub cmdMoveDown_Click(sender As Object, e As EventArgs) Handles cmdMoveDown.Click
        UI_Enable(False)

        'At least one item needs to be selected
        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            Me.MoveLwItems(Me.lvwReorderList, 1)
            'Visibility
            Me.lvwReorderList.SelectedItems(0).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enable(True)
    End Sub

    Private Sub cmdMoveFirst_Click(sender As Object, e As EventArgs) Handles cmdMoveFirst.Click
        UI_Enable(False)

        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            'Me.MoveLwItems(Me.lvwReorderList, -Me.lvwReorderList.SelectedItems.Item(0).Index)
            For i As Integer = 0 To Me.lvwReorderList.SelectedItems.Item(0).Index - 1
                Me.MoveLwItems(Me.lvwReorderList, -1)
            Next
            Me.lvwReorderList.Items(0).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enable(True)
    End Sub

    Private Sub cmdMoveLast_Click(sender As Object, e As EventArgs) Handles cmdMoveLast.Click
        UI_Enable(False)

        If Me.lvwReorderList.SelectedItems.Count > 0 Then
            'Me.MoveLwItems(Me.lvwReorderList, (Me.lvwReorderList.Items.Count - 1) - Me.lvwReorderList.SelectedItems.Item(Me.lvwReorderList.SelectedItems.Count - 1).Index)
            For i As Integer = 0 To (Me.lvwReorderList.Items.Count - 1) - (Me.lvwReorderList.SelectedItems.Item(Me.lvwReorderList.SelectedItems.Count - 1).Index + 1)
                Me.MoveLwItems(Me.lvwReorderList, 1)
            Next
            Me.lvwReorderList.Items(Me.lvwReorderList.Items.Count - 1).EnsureVisible()
        End If
        Rename_Preview()
        UI_Enable(True)
    End Sub
#End Region

#Region "Theme"
    Private Sub pnlTopPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlTopPanel.Paint
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
        Me.pnlTopPanel.BackColor = currentTheme.BgColorTop
        Me.flpBottomPanel.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.pnlTopPanel.BackgroundImage = currentTheme.BgImageTop
            Me.pnlTopPanel.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpBottomPanel.BackgroundImage = currentTheme.BgImageBottom
            Me.flpBottomPanel.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.pnlTopPanel.BackgroundImage = Nothing
            Me.flpBottomPanel.BackgroundImage = Nothing
        End If
        Me.Refresh()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub
#End Region

    Private Sub Rename_Preview()
        If Me.lvwReorderList.Items.Count > 0 Then
            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If tmpListItem.Tag.Equals(ReorderFileStatus.FreeSlot) Then
                    'Free slot, no savestate
                    tmpListItem.SubItems(ReorderListColumns.NewName).Text = "-"
                    tmpListItem.ForeColor = Color.DimGray
                ElseIf tmpListItem.Tag.Equals(ReorderFileStatus.RenamePending) Then
                    'Creating the new name
                    If frmMain.checkedGames.Count = 1 Then

                        tmpListItem.SubItems(ReorderListColumns.NewName).Text = Rename_NewName(frmMain.checkedGames(0), _
                                                                                               tmpListItem.Index \ 2 + My.Settings.PCSX2_SStateSlotLowerBound, _
                                                                                               CBool(tmpListItem.Index Mod 2))

                        If tmpListItem.SubItems(ReorderListColumns.OldName).Text = tmpListItem.SubItems(ReorderListColumns.NewName).Text Then
                            tmpListItem.Tag = ReorderFileStatus.Idle
                            tmpListItem.ForeColor = Me.ForeColor
                        Else
                            tmpListItem.ForeColor = mdlTheme.currentTheme.AccentColorDark
                        End If

                    Else
                        SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.Preview, _
                                         String.Format("Only one game must be selected. Reported to be selected: {0}", _
                                                       frmMain.checkedGames.Count))
                    End If
                End If
                tmpListItem.SubItems(ReorderListColumns.Status).Text = tmpListItem.Tag.ToString
            Next
        End If
    End Sub

    Private Function Rename_NewName(pSerial As String, pSlot As Integer, pSlotType As Boolean) As String
        'Game CRC
        Dim tmpCRC As String = "00000000"
        If SSMGameList.Games.ContainsKey(pSerial) Then
            tmpCRC = SSMGameList.Games(pSerial).CRC
        End If

        If (pSlot >= My.Settings.PCSX2_SStateSlotLowerBound) And (pSlot <= My.Settings.PCSX2_SStateSlotUpperBound) Then
            Rename_NewName = String.Format("{0} ({1}).{2:00}{3}", pSerial, tmpCRC, pSlot, My.Settings.PCSX2_SStateExt)
            If pSlotType Then
                Rename_NewName &= My.Settings.PCSX2_SStateExtBackup
            End If
            Return Rename_NewName
        Else
            Rename_NewName = String.Format("{0} ({1}).X{2:00}{3}", pSerial, tmpCRC, pSlot, My.Settings.PCSX2_SStateExt)
        End If

    End Function

    Private Sub Rename_Execute()
        If Me.lvwReorderList.Items.Count > 0 Then
            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If ReorderFileStatus.RenamePending.Equals(tmpListItem.Tag) Then
                    tmpListItem.Tag = Me.Rename_Execute2(1, tmpListItem.SubItems(ReorderListColumns.OldName).Text, _
                                                         Me.AddTmpExtension(tmpListItem.SubItems(ReorderListColumns.OldName).Text), _
                                                         My.Settings.PCSX2_PathSState, _
                                                         tmpListItem.SubItems(ReorderListColumns.Status).Text)
                End If
            Next

            For Each tmpListItem As ListViewItem In Me.lvwReorderList.Items
                If ReorderFileStatus.RenamedTmp.Equals(tmpListItem.Tag) Then
                    tmpListItem.Tag = Me.Rename_Execute2(2, Me.AddTmpExtension(tmpListItem.SubItems(ReorderListColumns.OldName).Text), _
                                                         tmpListItem.SubItems(ReorderListColumns.NewName).Text, _
                                                         My.Settings.PCSX2_PathSState, _
                                                         tmpListItem.SubItems(ReorderListColumns.Status).Text)
                End If
            Next
        End If
        Me.FilesRenamed = True
    End Sub

    Private Function Rename_Execute2(pPhase As Integer, pOldName As String, pNewName As String, pPath As String, Optional ByRef pResultMessage As String = "No message.") As ReorderFileStatus
        Try
            Dim tmpOldFileFullPath As String = Path.Combine(My.Settings.PCSX2_PathSState, pOldName)
            Dim tmpNewFileFullPath As String = Path.Combine(My.Settings.PCSX2_PathSState, pNewName)
            If File.Exists(tmpOldFileFullPath) Then
                If Not (File.Exists(tmpOldFileFullPath)) Then
                    File.Move(tmpOldFileFullPath, tmpNewFileFullPath)
                    SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("Phase {0}/2: File {1} renamed to {2}.", pPhase, pOldName, pNewName))
                    Return ReorderFileStatus.RenamedTmp
                Else
                    SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("Phase {0}/2: Target file {1} already exist. Renaming skipped", pPhase, pNewName))
                    Return ReorderFileStatus.FileAlreadyExist
                End If
            Else
                SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                 String.Format("Phase {0}/2: File {1} not found.", pPhase, pOldName))
                Return ReorderFileStatus.FileNotFound
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                             String.Format("Phase {0}/2: Error renaming {1} to {2}. {3}", pPhase, pOldName, pNewName, ex.Message))
            Return ReorderFileStatus.OtherError
        End Try
    End Function

End Class