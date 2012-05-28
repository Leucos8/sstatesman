﻿'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2012 - Leucos
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
Option Explicit On
Public Class frmMain

    'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '    Get
    '        Dim param As CreateParams = MyBase.CreateParams
    '        param.ClassStyle += CS_DROPSHADOW
    '        Return param
    '    End Get
    'End Property

    Dim WindowMouseBck As System.Drawing.Point
    Dim WindowSkipListRefresh As Boolean = False

    Dim GamesLvw_SelectedSize As System.Int64 = 0
    Dim GamesLvw_SelectedSizeBackup As System.Int64 = 0
    Dim SStatesLvw_SelectedSize As System.Int64 = 0
    Dim SStatesLvw_SelectedSizeBackup As System.Int64 = 0

    Friend Const frmMainGamesLvwColumn_GameTitle As System.Byte = 0
    Friend Const frmMainGamesLvwColumn_GameSerial As System.Byte = 1
    Friend Const frmMainGamesLvwColumn_GameRegion As System.Byte = 2
    Friend Const frmMainGamesLvwColumn_SStateInfo As System.Byte = 3
    Friend Const frmMainGamesLvwColumn_SStateBackupInfo As System.Byte = 4
    Friend Const frmMainGamesLvwColumn_ArrayRef As System.Byte = 5

    Friend Const frmMainSStatesLvwColumn_FileName As System.Byte = 0
    Friend Const frmMainSStatesLvwColumn_Slot As System.Byte = 1
    Friend Const frmMainSStatesLvwColumn_Backup As System.Byte = 2
    Friend Const frmMainSStatesLvwColumn_LastWriteDate As System.Byte = 3
    Friend Const frmMainSStatesLvwColumn_Size As System.Byte = 4
    Friend Const frmMainSStatesLvwColumn_SerialRef As System.Byte = 5
    Friend Const frmMainSStatesLvwColumn_ArrayRef As System.Byte = 6

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me.SetStyle(ControlStyles.ResizeRedraw, True)

        If My.Settings.SStatesMan_FirstRun2 = True Then  'Executes the FirstRun procedure (it tries to detect PCSX2 folders)
            mdlMain.FirstRun()
        End If
        My.Settings.SStatesMan_SettingFail = mdlMain.PCSX2_PathAll_Check()   'Checks if there are some invalid settings
        If My.Settings.SStatesMan_SettingFail Then                           'Show the settings dialog
            frmSettings.ShowDialog(Me)
        End If

        If My.Settings.SStatesMan_SStatesListAutoRefresh Then
            Me.tmrSStatesListRefresh.Enabled = True
        End If

        Me.lblWindowVersion.Text = System.String.Concat(Me.lblWindowVersion.Text, _
                                                        My.Application.Info.Version.ToString, " ", _
                                                        My.Settings.SStatesMan_Channel) 'Add version information to the main window

        Dim imlLvwCheckboxes As New System.Windows.Forms.ImageList          'Listviews checkboxes (stateimagelist)
        imlLvwCheckboxes.ImageSize = New System.Drawing.Size(11, 11)        'Setting up the size
        imlLvwCheckboxes.Images.Add(My.Resources.Metro_ChecboxUnchecked)    'Unchecked state image
        imlLvwCheckboxes.Images.Add(My.Resources.Metro_ChecboxChecked)      'Checked state image
        Me.lvwGamesList.StateImageList = imlLvwCheckboxes                   'Assigning the imagelist to the Games listview
        Me.lvwSStatesList.StateImageList = imlLvwCheckboxes                 'Assigning the imagelist to the Savestates listview

        mdlGameDb.GameDb_Len = mdlGameDb.GameDb_Load3(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), _
                                                      mdlGameDb.GameDb, _
                                                      mdlGameDb.GameDb_Pos) 'Loading the Game database (from PCSX2 directory)
        Me.GamesLvw_Refresh()                                                      'Refreshing the games list
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwGamesList.Clear()
        Me.lvwSStatesList.Clear()
    End Sub

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If My.Settings.SStatesMan_BGEnable Then
            Dim linGrBrushTop As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 150), Color.Gainsboro, Color.WhiteSmoke)
            Dim linGrBrushBottom As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 150), New Point(0, Me.ClientSize.Height), Color.WhiteSmoke, Color.Gainsboro)
            Dim linGrBrushToolbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            'Dim linGrBrushStatusbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.Silver, Color.Transparent)
            Dim linGrBrushSplitterbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 1), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 13), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrushTop, 0, 0, Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrushBottom, 0, CInt(Me.ClientSize.Height - 150), Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrushToolbar, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            'e.Graphics.FillRectangle(linGrBrushStatusbar, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, 12)
            If Not (Me.SplitContainer1.Panel1Collapsed Or Me.SplitContainer1.Panel2Collapsed) Then
                e.Graphics.FillRectangle(linGrBrushSplitterbar, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 1, Me.ClientSize.Width, 12)
            End If

        End If
        e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
        If Not (Me.SplitContainer1.Panel1Collapsed Or Me.SplitContainer1.Panel2Collapsed) Then
            e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.SplitContainer1.Top + Me.SplitContainer1.SplitterDistance + 1, Me.ClientSize.Width, Me.SplitContainer1.Top + Me.SplitContainer1.SplitterDistance + 1)
        End If
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Me.ClientSize.Width, 0)
        'e.Graphics.DrawLine(Pens.DarkGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)
    End Sub

    'Window
    'Window command buttons
    Private Sub cmdWindowMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmdWindowMaximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonRestore
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonMaximize
        End If
    End Sub

    Private Sub cmdWindowClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()
        End
    End Sub

    'Window movement
    Private Sub panelWindowTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelWindowTitle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then  'If it's the left mouse button click
            WindowMouseBck = e.Location                     'Save the location of the mouse pointer
        End If
    End Sub

    Private Sub panelWindowTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelWindowTitle.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then      'If it's the left mouse button click
            Me.Location = System.Drawing.Point.Add(Me.Location, System.Drawing.Point.Subtract(e.Location, WindowMouseBck))
        End If
    End Sub

    'Window dialogs buttons
    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        frmAbout.ShowDialog(Me)
    End Sub

    Private Sub cmdSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSettings.Click
        frmSettings.ShowDialog(Me)
    End Sub

    Private Sub cmdGameDbUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameDbUtil.Click
        If Not frmGameDb.Visible Then
            frmGameDb.Show(Me)
        Else
            frmGameDb.BringToFront()
        End If
    End Sub

    Private Sub cmdSStateListUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateListUtil.Click
        If Not frmSStateList.Visible Then
            frmSStateList.Show(Me)
        Else
            frmSStateList.BringToFront()
        End If
    End Sub
    'End window buttons & movement

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        GamesLvw_Refresh()
        UICheck()
    End Sub

    Private Sub cmdSStateDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateDelete.Click
        frmDeleteForm.ShowDialog(Me)
    End Sub

    'Gamelist management
    Private Sub cmdGameSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectAll.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = True
        Next
        'Me.UIEnabled(True)
        Me.SStatesLvw_Refresh()
        Me.UICheck()
    End Sub

    Private Sub cmdGameSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectNone.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
        Next
        'Me.UIEnabled(True)
        Me.SStatesLvw_Refresh()
        Me.UICheck()
    End Sub

    Private Sub cmdGameSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdGameSelectInvert.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            If Me.lvwGamesList.Items.Item(lvwItemIndex).Checked Then
                Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.SStatesLvw_Refresh()
        Me.UICheck()
    End Sub

    'SStatesList management
    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).SubItems(frmMainSStatesLvwColumn_Backup).Text = True Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGamesList.ItemChecked
        If WindowSkipListRefresh = False Then
            Me.SStatesLvw_Refresh()
            Me.UICheck()
        End If
    End Sub

    Private Sub lvwGamesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGamesList.SelectedIndexChanged
        If Me.lvwGamesList.CheckedItems.Count = 0 And Not (Me.lvwGamesList.SelectedItems.Count = 0) Then
            If WindowSkipListRefresh = False Then
                Me.SStatesLvw_Refresh()
                Me.UICheck()
            End If
        End If
    End Sub

    Private Sub lvwSStatesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesList.ItemChecked
        If WindowSkipListRefresh = False Then
            Me.SStatesLvw_SelectionChanged()
            Me.UICheck()
        End If
    End Sub

    Public Sub GamesLvw_Refresh()
        Me.UIEnabled(False)

        mdlSStatesList.SStatesList_Len = mdlSStatesList.SStatesList_Load2(My.Settings.PCSX2_PathSState, _
                                                                     mdlSStatesList.SStatesList, _
                                                                     mdlSStatesList.SStatesList_Pos)

        mdlGamesIndexSS.GamesIndexSS_Len = mdlGamesIndexSS.GameIndexSS_Load(mdlSStatesList.SStatesList, _
                                                                               mdlSStatesList.SStatesList_Pos, _
                                                                               mdlSStatesList.SStatesList_Len, _
                                                                               mdlGameDb.GameDb, _
                                                                               mdlGameDb.GameDb_Pos, _
                                                                               mdlGameDb.GameDb_Len, _
                                                                               mdlGamesIndexSS.GamesIndexSS, _
                                                                               mdlGamesIndexSS.GamesIndexSS_Pos)
        Me.lvwGamesList.Items.Clear()
        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        Dim smImageList As New ImageList
        smImageList.ImageSize = New System.Drawing.Size(72, 96)
        smImageList.Images.Add(My.Resources.Flag_0Null_30x20)
        Me.lvwGamesList.LargeImageList = smImageList


        For mdlGamesIndexSS.GamesIndexSS_Pos = 1 To mdlGamesIndexSS.GamesIndexSS_Len Step 1
            Dim GameList_ItemTmp As New System.Windows.Forms.ListViewItem
            GameList_ItemTmp.Text = mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Name
            GameList_ItemTmp.UseItemStyleForSubItems = False
            With GameList_ItemTmp.SubItems
                .Add(mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial)
                .Add(mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Region)
                .Add(System.String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Count, _
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_SizeTot / 1024 ^ 2))
                .Add(System.String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_Count, _
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_SizeTot / 1024 ^ 2))
                .Add(mdlGamesIndexSS.GamesIndexSS_Pos.ToString)
            End With

            If System.IO.File.Exists(My.Computer.FileSystem.CombinePath(My.Settings.SStatesMan_PathPics, mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial & ".jpg")) Then
                smImageList.Images.Add(System.Drawing.Bitmap.FromFile(My.Computer.FileSystem.CombinePath(My.Settings.SStatesMan_PathPics, mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial & ".jpg")))
                GameList_ItemTmp.ImageIndex = smImageList.Images.Count - 1
            Else
                GameList_ItemTmp.ImageIndex = 0
            End If


            Me.lvwGamesList.Items.Add(GameList_ItemTmp)
        Next GamesIndexSS_Pos

        'Me.lvwGamesList.LargeImageList = smImageList

        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items(lvwItemIndex).Font = Me.Font
            For lvwSubitemIndex = 1 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
                Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).ForeColor = Color.Gray
                Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).Font = Me.Font
            Next lvwSubitemIndex

            If colorswitch Then
                For lvwSubitemIndex = 0 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
                    Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).BackColor = Color.Transparent
                Next lvwSubitemIndex
                colorswitch = False
            Else
                For lvwSubitemIndex = 0 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
                    Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).BackColor = Color.WhiteSmoke
                Next lvwSubitemIndex
                colorswitch = True
            End If
        Next lvwItemIndex
        colorswitch = True

        Me.UIEnabled(True)
    End Sub

    Friend Sub GamesLvw_Update()
        Me.UIEnabled(False)
        Dim ItemIndex As System.Int32 = 0
        Dim ItemCount As System.Int32 = lvwGamesList.Items.Count - 1
        If ItemCount > 0 Then
            Do While ItemIndex <= ItemCount
                mdlGamesIndexSS.GamesIndexSS_Pos = CInt(lvwGamesList.Items(ItemIndex).SubItems(frmMainGamesLvwColumn_ArrayRef).Text)
                If mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Count > 0 Or _
                    mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_Count > 0 Then
                    lvwGamesList.Items(ItemIndex).SubItems(frmMainGamesLvwColumn_SStateInfo).Text = System.String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Count, _
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_SizeTot / 1024 ^ 2)

                    lvwGamesList.Items(ItemIndex).SubItems(frmMainGamesLvwColumn_SStateBackupInfo).Text = System.String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_Count, _
                                          mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_SizeTot / 1024 ^ 2)

                    ItemIndex += 1
                Else
                    lvwGamesList.Items(ItemIndex).Remove()
                    ItemCount -= 1
                End If
            Loop
        End If

        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items(lvwItemIndex).Font = Me.Font
            For lvwSubitemIndex = 1 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
                Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).ForeColor = Color.Gray
                Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).Font = Me.Font
            Next lvwSubitemIndex

            If colorswitch Then
                For lvwSubitemIndex = 0 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
                    Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).BackColor = Color.Transparent
                Next lvwSubitemIndex
                colorswitch = False
            Else
                For lvwSubitemIndex = 0 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
                    Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).BackColor = Color.WhiteSmoke
                Next lvwSubitemIndex
                colorswitch = True
            End If
        Next lvwItemIndex
        colorswitch = True

        Me.UIEnabled(True)
    End Sub

    Friend Sub SStatesLvw_Refresh()
        Me.UIEnabled(False)

        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()
        Me.SStatesLvw_SelectedSize = 0
        Me.SStatesLvw_SelectedSizeBackup = 0
        Me.GamesLvw_SelectedSize = 0
        Me.GamesLvw_SelectedSizeBackup = 0

        If Me.lvwGamesList.CheckedItems.Count > 0 Then

            For Each GameList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.CheckedItems
                mdlGamesIndexSS.GamesIndexSS_Pos = CInt(GameList_ItemChecked.SubItems(frmMainGamesLvwColumn_ArrayRef).Text)
                Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup

                With SStateList_GroupTmp
                    .Header = System.String.Format("{0} ({1}) [{2}]", _
                                                   mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Name, _
                                                   mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Region, _
                                                   mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial)
                    .HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Left
                    .Name = mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial
                End With
                Me.lvwSStatesList.Groups.Add(SStateList_GroupTmp)

                If Me.lvwGamesList.CheckedItems.Count > 1 Then
                    Me.lvwSStatesList.ShowGroups = True
                Else
                    Me.lvwSStatesList.ShowGroups = False
                End If

                GamesLvw_SelectedSize = GamesLvw_SelectedSize + mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_SizeTot
                GamesLvw_SelectedSizeBackup = GamesLvw_SelectedSizeBackup + mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_SizeTot

                For mdlSStatesList.SStatesList_Pos = (mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStatesList_StartPos) _
                    To (mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStatesList_EndPos)

                    If mdlSStatesList.SStatesList(SStatesList_Pos).isDeleted = False Then
                        Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem
                        With SStateList_ItemTmp
                            .Text = mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).FileInfo.Name
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).Slot.ToString)
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).isBackup.ToString)
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).FileInfo.LastWriteTime.ToString)
                            .SubItems.Add(System.String.Format("{0:#,##0.00} MB", _
                                                               mdlSStatesList.SStatesList(SStatesList_Pos).FileInfo.Length / 1024 ^ 2))
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).SStateSerial)
                            .SubItems.Add(mdlSStatesList.SStatesList_Pos.ToString)
                            .Group = SStateList_GroupTmp
                            .UseItemStyleForSubItems = False
                        End With
                        'If SStateList(SStateList_Pos).SStateBackup Then
                        '    GamesLvw_SelectedSizeBackup = GamesLvw_SelectedSizeBackup + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        'Else
                        '    GamesLvw_SelectedSize = GamesLvw_SelectedSize + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        'End If

                        If mdlSStatesList.SStatesList(SStatesList_Pos).isDeleted Or System.IO.File.Exists(mdlSStatesList.SStatesList(SStatesList_Pos).FileInfo.FullName) = False Then
                            SStateList_ItemTmp.BackColor = Color.FromArgb(255, 255, 192, 192)
                            'mdlSStateList.SStateList(SStateList_Pos).isDeleted = True
                            'mdlSStateList.GameIndexSS(mdlSStateList.GameIndexSS_Pos).SStates_SizeTot = mdlSStateList.GameIndexSS(mdlSStateList.GameIndexSS_Pos).SStates_SizeTot - mdlSStateList.SStateList(mdlSStateList.GameIndexSS_Pos).FileInfo.Length
                        End If

                        For lvwSubitemIndex = 1 To SStateList_ItemTmp.SubItems.Count - 1
                            SStateList_ItemTmp.SubItems(lvwSubitemIndex).ForeColor = Color.Gray
                        Next lvwSubitemIndex
                        If colorswitch Then
                            colorswitch = False
                        Else
                            For lvwSubitemIndex = 0 To SStateList_ItemTmp.SubItems.Count - 1
                                SStateList_ItemTmp.SubItems(lvwSubitemIndex).BackColor = Color.WhiteSmoke
                            Next lvwSubitemIndex
                            colorswitch = True
                        End If

                        Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
                    End If
                Next mdlSStatesList.SStatesList_Pos
            Next

        ElseIf Me.lvwGamesList.SelectedItems.Count > 0 Then

            For Each GameList_ItemSelected As System.Windows.Forms.ListViewItem In Me.lvwGamesList.SelectedItems
                mdlGamesIndexSS.GamesIndexSS_Pos = CInt(GameList_ItemSelected.SubItems(frmMainGamesLvwColumn_ArrayRef).Text)

                Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup
                'If Me.lvwGamesList.CheckedItems.Count > 1 Then

                With SStateList_GroupTmp
                    .Header = System.String.Format("{0} ({1}) [{2}]", _
                                                   mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Name, _
                                                   mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Region, _
                                                   mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial)
                    .HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Left
                    .Name = mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial
                End With
                Me.lvwSStatesList.Groups.Add(SStateList_GroupTmp)
                'End If
                If Me.lvwGamesList.CheckedItems.Count > 1 Then
                    Me.lvwSStatesList.ShowGroups = True
                Else
                    Me.lvwSStatesList.ShowGroups = False
                End If

                GamesLvw_SelectedSize = GamesLvw_SelectedSize + mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_SizeTot
                GamesLvw_SelectedSizeBackup = GamesLvw_SelectedSizeBackup + mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStates_Bck_SizeTot

                For mdlSStatesList.SStatesList_Pos = (mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStatesList_StartPos) _
                    To (mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).SStatesList_EndPos)

                    If mdlSStatesList.SStatesList(SStatesList_Pos).isDeleted = False Then
                        Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem
                        With SStateList_ItemTmp
                            .Text = mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).FileInfo.Name
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).Slot.ToString)
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).isBackup.ToString)
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).FileInfo.LastWriteTime.ToString)
                            .SubItems.Add(System.String.Format("{0:#,##0.00} MB", _
                                                               mdlSStatesList.SStatesList(SStatesList_Pos).FileInfo.Length / 1024 ^ 2))
                            .SubItems.Add(mdlSStatesList.SStatesList(mdlSStatesList.SStatesList_Pos).SStateSerial)
                            .SubItems.Add(mdlSStatesList.SStatesList_Pos.ToString)
                            .Group = SStateList_GroupTmp
                            .UseItemStyleForSubItems = False
                        End With

                        If mdlSStatesList.SStatesList(SStatesList_Pos).isDeleted Or System.IO.File.Exists(mdlSStatesList.SStatesList(SStatesList_Pos).FileInfo.FullName) = False Then
                            SStateList_ItemTmp.BackColor = Color.FromArgb(255, 255, 192, 192)
                            'mdlSStateList.GameIndexSS(mdlSStateList.GameIndexSS_Pos).SStates_SizeTot = mdlSStateList.GameIndexSS(mdlSStateList.GameIndexSS_Pos).SStates_SizeTot - mdlSStateList.SStateList(mdlSStateList.GameIndexSS_Pos).FileInfo.Length
                            'mdlSStateList.SStateList(SStateList_Pos).isDeleted = True
                        End If

                        'If SStateList(SStateList_Pos).SStateBackup Then
                        '    GamesLvw_SelectedSizeBackup = GamesLvw_SelectedSizeBackup + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        'Else
                        '    GamesLvw_SelectedSize = GamesLvw_SelectedSize + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        'End If

                        For lvwSubitemIndex = 1 To SStateList_ItemTmp.SubItems.Count - 1
                            SStateList_ItemTmp.SubItems(lvwSubitemIndex).ForeColor = Color.Gray
                        Next lvwSubitemIndex
                        If colorswitch Then
                            colorswitch = False
                        Else
                            For lvwSubitemIndex = 0 To SStateList_ItemTmp.SubItems.Count - 1
                                SStateList_ItemTmp.SubItems(lvwSubitemIndex).BackColor = Color.WhiteSmoke
                            Next lvwSubitemIndex
                            colorswitch = True
                        End If



                        Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
                    End If
                Next mdlSStatesList.SStatesList_Pos

            Next
            Me.GamesLvw_SelectedSize = GamesIndexSS(GamesIndexSS_Pos).SStates_SizeTot
            Me.GamesLvw_SelectedSizeBackup = GamesIndexSS(GamesIndexSS_Pos).SStates_Bck_SizeTot
            'Else

        End If
        colorswitch = True

        Me.UIEnabled(True)
    End Sub

    Private Sub SStatesLvw_SelectionChanged()
        Me.UIEnabled(False)
        Me.SStatesLvw_SelectedSize = 0
        Me.SStatesLvw_SelectedSizeBackup = 0
        If Me.lvwSStatesList.Items.Count > 0 Then
            For Each SStateList_ItemChecked As ListViewItem In Me.lvwSStatesList.CheckedItems
                mdlSStatesList.SStatesList_Pos = CInt(SStateList_ItemChecked.SubItems(frmMainSStatesLvwColumn_ArrayRef).Text)
                If SStatesList(SStatesList_Pos).isBackup = False Then
                    SStatesLvw_SelectedSize = SStatesLvw_SelectedSize + SStatesList(SStatesList_Pos).FileInfo.Length
                Else
                    SStatesLvw_SelectedSizeBackup = SStatesLvw_SelectedSizeBackup + SStatesList(SStatesList_Pos).FileInfo.Length
                End If
            Next
        End If
        Me.UIEnabled(True)
    End Sub

    Private Sub UIEnabled(enable As Boolean)
        If enable = True Then
            Me.WindowSkipListRefresh = False
            Me.lvwGamesList.ResumeLayout()
            Me.lvwSStatesList.ResumeLayout()
        Else
            Me.WindowSkipListRefresh = True
            Me.lvwGamesList.SuspendLayout()
            Me.lvwSStatesList.SuspendLayout()
        End If
    End Sub

    Friend Sub UICheck()
        If Me.lvwGamesList.Items.Count = 0 Then

            Me.cmdGameSelectAll.Enabled = False
            Me.cmdGameSelectInvert.Enabled = False
            Me.cmdGameSelectNone.Enabled = False

        Else
            Me.cmdGameSelectAll.Enabled = True
            Me.cmdGameSelectInvert.Enabled = True

            If Me.lvwGamesList.CheckedItems.Count > 0 Or Me.lvwGamesList.SelectedItems.Count > 0 Then

                Me.txtSize.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.SStatesLvw_SelectedSize / 1024 ^ 2, Me.GamesLvw_SelectedSize / 1024 ^ 2)
                Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.SStatesLvw_SelectedSizeBackup / 1024 ^ 2, Me.GamesLvw_SelectedSizeBackup / 1024 ^ 2)
                Me.txtGameList_Title.Text = mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Name
                Me.txtGameList_Serial.Text = mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial
                Me.txtGameList_Region.Text = mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Region
                Me.txtGameList_Compat.Text = mdlMain.assignCompatText(mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Compat)
                Me.txtGameList_Compat.BackColor = mdlMain.assignCompatColor(mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Compat, Color.WhiteSmoke)
                Me.imgFlag.Visible = True
                Me.imgFlag.Image = mdlMain.assignFlag(mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Region, mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial)
                Me.cmdGameSelectNone.Enabled = False

                If System.IO.File.Exists(My.Computer.FileSystem.CombinePath(My.Settings.SStatesMan_PathPics, mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial & ".jpg")) Then
                    Me.imgCover.Load(My.Computer.FileSystem.CombinePath(My.Settings.SStatesMan_PathPics, mdlGamesIndexSS.GamesIndexSS(mdlGamesIndexSS.GamesIndexSS_Pos).GameInfo.Serial & ".jpg"))
                    If Me.imgCover.Tag = "ex" Then
                        Me.imgCover.Height = 169
                        Me.imgCover.Width = Int(Me.imgCover.Size.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.Height)
                        If Me.imgCover.Width > 126 Then
                            Me.imgCover.Width = Me.txtGameList_Title.Left - 18
                            Me.imgCover.Height = Int(Me.imgCover.Size.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.Width)
                        End If
                    Else
                        Me.imgCover.Height = 51
                        Me.imgCover.Width = Int(Me.imgCover.Size.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.Height)
                        If Me.imgCover.Width > 51 Then
                            Me.imgCover.Width = 51
                            Me.imgCover.Height = Int(Me.imgCover.Size.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.Width)
                        End If
                    End If
                    Me.imgCover.Location = New Point(12, Me.SplitContainer1.Panel1.Height - Me.imgCover.Height - 5)
                    Me.imgCover.Visible = True
                Else
                    Me.imgCover.Image = My.Resources.Flag_0Null_30x20
                    Me.imgCover.Visible = False
                End If

                If Me.lvwGamesList.CheckedItems.Count > 0 Then
                    Me.cmdGameSelectNone.Enabled = True
                End If

                If Me.lvwGamesList.CheckedItems.Count > 1 Then
                    Me.txtGameList_Title.Text = "(multiple games selected)"
                    Me.txtGameList_Serial.Text = ""
                    Me.txtGameList_Region.Text = ""
                    Me.txtGameList_Compat.Text = ""
                    Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
                    Me.imgFlag.Visible = False
                    Me.imgCover.Visible = False

                    If Me.lvwGamesList.Items.Count = Me.lvwGamesList.CheckedItems.Count Then
                        Me.cmdGameSelectAll.Enabled = False
                    End If

                End If

            Else

                Me.cmdGameSelectNone.Enabled = False
                Me.cmdGameSelectAll.Enabled = True
                If Me.lvwGamesList.SelectedItems.Count = 0 Then

                    Me.txtGameList_Title.Text = ""
                    Me.txtGameList_Serial.Text = ""
                    Me.txtGameList_Region.Text = ""
                    Me.txtGameList_Compat.Text = ""
                    Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
                    Me.txtSize.Text = ""
                    Me.txtSizeBackup.Text = ""
                    Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

                    Me.imgCover.Visible = False
                End If
            End If
        End If



        If Me.lvwSStatesList.Items.Count = 0 Then

            Me.txtSize.Text = ""
            Me.txtSizeBackup.Text = ""
            Me.txtSStateListSelection.Text = ""

            Me.cmdSStateSelectAll.Enabled = False
            Me.cmdSStateSelectInvert.Enabled = False
            Me.cmdSStateSelectNone.Enabled = False
            Me.cmdSStateSelectBackup.Enabled = False
            Me.cmdSStateDelete.Enabled = False

        Else

            Me.txtSize.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.SStatesLvw_SelectedSize / 1024 ^ 2, Me.GamesLvw_SelectedSize / 1024 ^ 2)
            Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.SStatesLvw_SelectedSizeBackup / 1024 ^ 2, Me.GamesLvw_SelectedSizeBackup / 1024 ^ 2)
            Me.txtSStateListSelection.Text = System.String.Format("{0:#,##0} | {1:#,##0}", Me.lvwSStatesList.CheckedItems.Count, Me.lvwSStatesList.Items.Count)

            Me.cmdSStateSelectInvert.Enabled = True
            Me.cmdSStateSelectBackup.Enabled = True
            Me.cmdSStateSelectAll.Enabled = True

            If Me.lvwSStatesList.CheckedItems.Count > 0 Then

                Me.cmdSStateSelectNone.Enabled = True
                Me.cmdSStateDelete.Enabled = True

                If Me.lvwSStatesList.Items.Count = Me.lvwSStatesList.CheckedItems.Count Then
                    Me.cmdSStateSelectAll.Enabled = False
                End If

            Else
                Me.cmdSStateSelectNone.Enabled = False
                Me.cmdSStateSelectAll.Enabled = True
                Me.cmdSStateDelete.Enabled = False
            End If
        End If
    End Sub

    Private Sub imgCover_Click(sender As System.Object, e As System.EventArgs) Handles imgCover.Click
        If Me.imgCover.Tag = "min" Then
            Me.imgCover.Height = 169
            Me.imgCover.Width = Int(Me.imgCover.Size.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.Height)
            If Me.imgCover.Width > 126 Then
                Me.imgCover.Width = Me.txtGameList_Title.Left - 18
                Me.imgCover.Height = Int(Me.imgCover.Size.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.Width)
            End If
            Me.lblGameList_Title.Visible = False
            Me.lblGameList_Region.Visible = False
            Me.lvwGamesList.Left = Me.txtGameList_Title.Left
            Me.lvwGamesList.Width = Me.SplitContainer1.Panel1.Width - Me.txtGameList_Title.Left - 12
            Me.cmdCoverExpand.Image = My.Resources.Metro_ExpandLeft
            Me.imgCover.Tag = "ex"
        Else
            Me.imgCover.Height = 51
            Me.imgCover.Width = Int(Me.imgCover.Size.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.Height)
            If Me.imgCover.Width > 51 Then
                Me.imgCover.Width = 51
                Me.imgCover.Height = Int(Me.imgCover.Size.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.Width)
            End If
            'Me.imgCover.Location = New Point(12, Me.SplitContainer1.Panel1.Height - Me.imgCover.Height - 3)
            Me.lblGameList_Title.Visible = True
            Me.lblGameList_Region.Visible = True
            Me.lvwGamesList.Left = 12
            Me.lvwGamesList.Width = Me.SplitContainer1.Panel1.Width - 24
            Me.cmdCoverExpand.Image = My.Resources.Metro_ExpandRight
            Me.imgCover.Tag = "min"
        End If
        Me.imgCover.Location = New Point(12, Me.SplitContainer1.Panel1.Height - Me.imgCover.Height - 5)
        Me.cmdRefresh.Left = Me.lvwGamesList.Left + 12
    End Sub

    Private Sub cmdCoverExpand_Click(sender As System.Object, e As System.EventArgs) Handles cmdCoverExpand.Click
        If Me.imgCover.Tag = "min" Then
            Me.imgCover.Height = 171
            Me.imgCover.Width = Int(Me.imgCover.Size.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.Height)
            If Me.imgCover.Width > 126 Then
                Me.imgCover.Width = Me.txtGameList_Title.Left - 18
                Me.imgCover.Height = Int(Me.imgCover.Size.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.Width)
            End If
            Me.lblGameList_Title.Visible = False
            Me.lblGameList_Region.Visible = False
            Me.lvwGamesList.Left = Me.txtGameList_Title.Left
            Me.lvwGamesList.Width = Me.SplitContainer1.Panel1.Width - Me.txtGameList_Title.Left - 12
            Me.cmdCoverExpand.Image = My.Resources.Metro_ExpandLeft
            Me.imgCover.Tag = "ex"
        Else
            Me.imgCover.Height = 51
            Me.imgCover.Width = Int(Me.imgCover.Size.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.Height)
            If Me.imgCover.Width > 51 Then
                Me.imgCover.Width = 51
                Me.imgCover.Height = Int(Me.imgCover.Size.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.Width)
            End If
            'Me.imgCover.Location = New Point(12, Me.SplitContainer1.Panel1.Height - Me.imgCover.Height - 3)
            Me.lblGameList_Title.Visible = True
            Me.lblGameList_Region.Visible = True
            Me.lvwGamesList.Left = 12
            Me.lvwGamesList.Width = Me.SplitContainer1.Panel1.Width - 24
            Me.cmdCoverExpand.Image = My.Resources.Metro_ExpandRight
            Me.imgCover.Tag = "min"
        End If
        Me.imgCover.Location = New Point(12, Me.SplitContainer1.Panel1.Height - Me.imgCover.Height - 3)
        Me.cmdRefresh.Left = Me.lvwGamesList.Left + 12
    End Sub

    Private Sub cmdSStatesLvwExpand_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesLvwExpand.Click
        If Me.SplitContainer1.Panel2Collapsed Then
            Me.SplitContainer1.Panel2Collapsed = False
        Else : Me.SplitContainer1.Panel1Collapsed = True
        End If
    End Sub

    Private Sub cmdGamesLvwExpand_Click(sender As System.Object, e As System.EventArgs) Handles cmdGamesLvwExpand.Click
        If Me.SplitContainer1.Panel1Collapsed Then
            Me.SplitContainer1.Panel1Collapsed = False
        Else : Me.SplitContainer1.Panel2Collapsed = True
        End If
    End Sub

    Private Sub tmrSStatesListRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSStatesListRefresh.Tick
        If My.Settings.SStatesMan_SStatesListAutoRefresh Then
            If System.IO.Directory.Exists(My.Settings.PCSX2_PathSState) And Not frmDeleteForm.Visible Then
                If Not (System.IO.Directory.GetLastWriteTime(My.Settings.PCSX2_PathSState) = mdlSStatesList.SStates_FolderLastModified) Then
                    Me.Enabled = False
                    GamesLvw_Refresh()
                    UICheck()
                    Me.Enabled = True
                End If
            End If
        Else
            Me.tmrSStatesListRefresh.Enabled = False
        End If
    End Sub
End Class