'   SStatesMan - Savestate Manager for PCSX2 0.9.8
'   Copyright (C) 2011 - Leucos
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

    Dim MouseBck As System.Drawing.Point
    Dim SkipListRefresh As Boolean = False
    Dim GameList_TotalSize As System.Int64 = 0
    Dim GameList_TotalSizeBackup As System.Int64 = 0
    Dim SStateList_TotalSize As System.Int64 = 0
    Dim SStateList_TotalSizeBackup As System.Int64 = 0

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me.SetStyle(ControlStyles.ResizeRedraw, True)
        If My.Settings.SStateMan_FirstRun2 = True Then
            mdlMain.FirstRun()
        End If
        Me.lblWindowVersion.Text = System.String.Format("version {0} {1}", My.Application.Info.Version.ToString, My.Settings.SStateMan_Channel)
        mdlMain.SettingsCheck()
        If My.Settings.SStateMan_SettingFail = True Then
            frmSettings.ShowDialog(Me)
        End If
        'My.Settings.Save()
        'My.Settings.SStateMan_SettingFail = False
        mdlGameDb.GameDb_Len = mdlGameDb.GameDb_Load3(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), _
                                                      mdlGameDb.GameDb, _
                                                      mdlGameDb.GameDb_Pos)
        Me.List_Load()
    End Sub

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If My.Settings.SStateMan_BGEnable Then
            Dim linGrBrush As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 150), Color.Gainsboro, Color.White)
            Dim linGrBrush2 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 150), New Point(0, Me.ClientSize.Height), Color.White, Color.Gainsboro)
            Dim linGrBrush3 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            'Dim linGrBrush4 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.LightGray, Color.Transparent)
            Dim linGrBrush5 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 12), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrush, 0, 0, Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush2, 0, CInt(Me.ClientSize.Height - 150), Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush3, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            'e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
            'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
            e.Graphics.FillRectangle(linGrBrush5, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance, Me.ClientSize.Width, 12)

        End If
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Me.ClientSize.Width, 0)
        'e.Graphics.DrawLine(Pens.DarkGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)
    End Sub

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

    Private Sub panelWindowTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelWindowTitle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MouseBck = e.Location
        End If
    End Sub

    Private Sub panelWindowTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelWindowTitle.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Top = Me.Top + e.Location.Y - MouseBck.Y
            Me.Left = Me.Left + e.Location.X - MouseBck.X
        End If
    End Sub

    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        frmAbout.ShowDialog(Me)
    End Sub

    Private Sub cmdSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSettings.Click
        frmSettings.ShowDialog(Me)
    End Sub

    Private Sub cmdGameDbUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameDbUtil.Click
        frmGameDb.Show(Me)
    End Sub

    Private Sub cmdSStateListUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateListUtil.Click
        frmSStateList.Show(Me)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        List_Load()
    End Sub

    Private Sub cmdGameSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectAll.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(tmp).Checked = True
        Next
        List_Refresh()
        SStateListSelectionChanged()
        SkipListRefresh = False
    End Sub

    Private Sub cmdGameSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectNone.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(tmp).Checked = False
        Next
        List_Refresh()
        SStateListSelectionChanged()
        SkipListRefresh = False
    End Sub

    Private Sub cmdGameSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdGameSelectInvert.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwGamesList.Items.Count - 1
            If Me.lvwGamesList.Items.Item(tmp).Checked = True Then
                Me.lvwGamesList.Items.Item(tmp).Checked = False
            Else
                Me.lvwGamesList.Items.Item(tmp).Checked = True
            End If
        Next
        List_Refresh()
        SStateListSelectionChanged()
        SkipListRefresh = False
    End Sub

    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(tmp).Checked = True
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(tmp).Checked = False
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(tmp).Checked = True Then
                Me.lvwSStatesList.Items.Item(tmp).Checked = False
            Else
                Me.lvwSStatesList.Items.Item(tmp).Checked = True
            End If
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(tmp).SubItems(2).Text = True Then
                Me.lvwSStatesList.Items.Item(tmp).Checked = True
            Else
                Me.lvwSStatesList.Items.Item(tmp).Checked = False
            End If
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateDelete.Click
        frmDeleteForm.ShowDialog(Me)
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGamesList.ItemChecked
        If SkipListRefresh = False Then
            List_Refresh()
            SStateListSelectionChanged()
        End If
    End Sub

    Private Sub lvwGamesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGamesList.SelectedIndexChanged
        If Me.lvwGamesList.CheckedItems.Count = 0 Then
            List_Refresh()
            SStateListSelectionChanged()
        End If
    End Sub

    Private Sub lvwSStatesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesList.ItemChecked
        If SkipListRefresh = False Then
            SStateListSelectionChanged()
        End If
    End Sub

    Public Sub List_Load()
        Me.UISwitch(False)
        mdlSStateList.SStateList_Len = mdlSStateList.SStateList_Load(My.Settings.PCSX2_PathSState, _
                                                                     mdlSStateList.SStateList, _
                                                                     mdlSStateList.SStateList_Pos)

        mdlSStateList.SStateGameIndex_Len = mdlSStateList.SStateGameIndex_Load(mdlSStateList.SStateList, _
                                                                               mdlSStateList.SStateList_Pos, _
                                                                               mdlSStateList.SStateList_Len, _
                                                                               mdlGameDb.GameDb, _
                                                                               mdlGameDb.GameDb_Pos, _
                                                                               mdlGameDb.GameDb_Len, _
                                                                               mdlSStateList.SStateGameIndex, _
                                                                               mdlSStateList.SStateGameIndex_Pos)
        Me.lvwGamesList.Items.Clear()
        Me.lvwSStatesList.Items.Clear()

        For mdlSStateList.SStateGameIndex_Pos = 1 To mdlSStateList.SStateGameIndex_Len Step 1
            Dim GameList_ItemTmp As New System.Windows.Forms.ListViewItem
            GameList_ItemTmp.Text = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Name
            With GameList_ItemTmp.SubItems
                .Add(mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial)
                .Add(mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Region)
                .Add(System.String.Format("{0:#,##0.00} MiB ({1:#,##0.00} MiB)", _
                                          mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal / 1024 ^ 2, _
                                          mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStatesBackup_SizeTotal / 1024 ^ 2))
                .Add(mdlSStateList.SStateGameIndex_Pos.ToString)
            End With


            Me.lvwGamesList.Items.Add(GameList_ItemTmp)
        Next SStateGameIndex_Pos

        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwGamesList.Items.Count - 1
            If colorswitch Then
                colorswitch = False
            Else
                Me.lvwGamesList.Items(tmp).BackColor = Color.WhiteSmoke
                colorswitch = True
            End If
        Next
        SkipListRefresh = False

        colorswitch = True
        UISwitch(True)
        UICheck()
    End Sub

    Public Sub List_Refresh()
        UISwitch(False)

        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()
        Me.GameList_TotalSize = 0
        Me.GameList_TotalSizeBackup = 0

        If Me.lvwGamesList.CheckedItems.Count > 0 Then

            For Each GameList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.CheckedItems
                mdlSStateList.SStateGameIndex_Pos = CInt(GameList_ItemChecked.SubItems(4).Text)
                Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup
                'If Me.lvwGamesList.CheckedItems.Count > 1 Then

                With SStateList_GroupTmp
                    .Header = System.String.Format("{0} ({1}) [{2}]", _
                                                   mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Name, _
                                                   mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Region, _
                                                   mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial)
                    .HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Left
                    .Name = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial
                End With
                Me.lvwSStatesList.Groups.Add(SStateList_GroupTmp)
                'End If
                If Me.lvwGamesList.CheckedItems.Count > 1 Then
                    Me.lvwSStatesList.ShowGroups = True
                Else
                    Me.lvwSStatesList.ShowGroups = False
                End If

                For mdlSStateList.SStateList_Pos = (mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateList_Start) _
                    To (mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateList_End)

                    If mdlSStateList.SStateList(SStateList_Pos).isDeleted = False Then
                        Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem
                        With SStateList_ItemTmp
                            .Text = mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Name
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateSlot.ToString)
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateBackup.ToString)
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.CreationTime.ToString)
                            .SubItems.Add(System.String.Format("{0:#,##0.00} MiB", _
                                                               mdlSStateList.SStateList(SStateList_Pos).FileInfo.Length / 1024 ^ 2))
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateSerial)
                            .SubItems.Add(mdlSStateList.SStateList_Pos.ToString)
                            .Group = SStateList_GroupTmp
                        End With
                        If SStateList(SStateList_Pos).SStateBackup Then
                            GameList_TotalSizeBackup = GameList_TotalSizeBackup + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        Else
                            GameList_TotalSize = GameList_TotalSize + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        End If

                        If colorswitch Then
                            colorswitch = False
                        Else
                            SStateList_ItemTmp.BackColor = Color.WhiteSmoke
                            colorswitch = True
                        End If

                        If mdlSStateList.SStateList(SStateList_Pos).isDeleted Or My.Computer.FileSystem.FileExists(mdlSStateList.SStateList(SStateList_Pos).FileInfo.FullName) = False Then
                            SStateList_ItemTmp.BackColor = Color.FromArgb(255, 255, 192, 192)
                            mdlSStateList.SStateList(SStateList_Pos).isDeleted = True
                            'mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal - mdlSStateList.SStateList(mdlSStateList.SStateGameIndex_Pos).FileInfo.Length
                        End If

                        Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
                    End If
                Next mdlSStateList.SStateList_Pos
            Next

        ElseIf Me.lvwGamesList.SelectedItems.Count > 0 Then

            For Each GameList_ItemSelected As System.Windows.Forms.ListViewItem In Me.lvwGamesList.SelectedItems
                mdlSStateList.SStateGameIndex_Pos = CInt(GameList_ItemSelected.SubItems(4).Text)

                Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup
                'If Me.lvwGamesList.CheckedItems.Count > 1 Then

                With SStateList_GroupTmp
                    .Header = System.String.Format("{0} ({1}) [{2}]", _
                                                   mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Name, _
                                                   mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Region, _
                                                   mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial)
                    .HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Left
                    .Name = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial
                End With
                Me.lvwSStatesList.Groups.Add(SStateList_GroupTmp)
                'End If
                If Me.lvwGamesList.CheckedItems.Count > 1 Then
                    Me.lvwSStatesList.ShowGroups = True
                Else
                    Me.lvwSStatesList.ShowGroups = False
                End If

                For mdlSStateList.SStateList_Pos = (mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateList_Start) _
                    To (mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateList_End)

                    If mdlSStateList.SStateList(SStateList_Pos).isDeleted = False Then
                        Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem
                        With SStateList_ItemTmp
                            .Text = mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Name
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateSlot.ToString)
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateBackup.ToString)
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.CreationTime.ToString)
                            .SubItems.Add(System.String.Format("{0:#,##0.00} MiB", _
                                                               mdlSStateList.SStateList(SStateList_Pos).FileInfo.Length / 1024 ^ 2))
                            .SubItems.Add(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateSerial)
                            .SubItems.Add(mdlSStateList.SStateList_Pos.ToString)
                            .Group = SStateList_GroupTmp
                        End With

                        If SStateList(SStateList_Pos).SStateBackup Then
                            GameList_TotalSizeBackup = GameList_TotalSizeBackup + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        Else
                            GameList_TotalSize = GameList_TotalSize + mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                        End If

                        If colorswitch Then
                            colorswitch = False
                        Else
                            SStateList_ItemTmp.BackColor = Color.WhiteSmoke
                            colorswitch = True
                        End If

                        If mdlSStateList.SStateList(SStateList_Pos).isDeleted Or My.Computer.FileSystem.FileExists(mdlSStateList.SStateList(SStateList_Pos).FileInfo.FullName) = False Then
                            SStateList_ItemTmp.BackColor = Color.FromArgb(255, 255, 192, 192)
                            'mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal - mdlSStateList.SStateList(mdlSStateList.SStateGameIndex_Pos).FileInfo.Length
                            mdlSStateList.SStateList(SStateList_Pos).isDeleted = True
                        End If

                        Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
                    End If
                Next mdlSStateList.SStateList_Pos

            Next
            Me.GameList_TotalSize = SStateGameIndex(SStateGameIndex_Pos).SStates_SizeTotal
            Me.GameList_TotalSizeBackup = SStateGameIndex(SStateGameIndex_Pos).SStatesBackup_SizeTotal
            'Else
        End If
        colorswitch = True
        UISwitch(True)
        'UICheck()
    End Sub

    Private Sub SStateListSelectionChanged()
        UISwitch(False)
        Me.SStateList_TotalSize = 0
        Me.SStateList_TotalSizeBackup = 0
        If Me.lvwSStatesList.Items.Count > 0 Then
            For Each SStateList_ItemChecked As ListViewItem In Me.lvwSStatesList.CheckedItems
                mdlSStateList.SStateList_Pos = CInt(SStateList_ItemChecked.SubItems(6).Text)
                If SStateList(SStateList_Pos).SStateBackup = False Then
                    SStateList_TotalSize = SStateList_TotalSize + SStateList(SStateList_Pos).FileInfo.Length
                Else
                    SStateList_TotalSizeBackup = SStateList_TotalSizeBackup + SStateList(SStateList_Pos).FileInfo.Length
                End If
            Next
        End If
        UISwitch(True)
        UICheck()
    End Sub

    Private Sub UISwitch(enable As Boolean)
        If enable = True Then
            Me.SkipListRefresh = False
            Me.lvwGamesList.ResumeLayout()
            Me.lvwSStatesList.ResumeLayout()
        Else
            Me.SkipListRefresh = True
            Me.lvwGamesList.SuspendLayout()
            Me.lvwSStatesList.SuspendLayout()
        End If
    End Sub

    Private Sub UICheck()
        If Me.lvwGamesList.Items.Count = 0 Then

            Me.cmdGameSelectAll.Enabled = False
            Me.cmdGameSelectInvert.Enabled = False
            Me.cmdGameSelectNone.Enabled = False

        Else
            Me.cmdGameSelectAll.Enabled = True
            Me.cmdGameSelectInvert.Enabled = True

            If Me.lvwGamesList.CheckedItems.Count > 0 Or Me.lvwGamesList.SelectedItems.Count > 0 Then

                Me.txtSize.Text = System.String.Format("{0:#,##0.00} / {1:#,##0.00} MiB", Me.SStateList_TotalSize / 1024 ^ 2, Me.GameList_TotalSize / 1024 ^ 2)
                Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} / {1:#,##0.00} MiB", Me.SStateList_TotalSizeBackup / 1024 ^ 2, Me.GameList_TotalSizeBackup / 1024 ^ 2)
                Me.txtGameList_Title.Text = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Name.ToString
                Me.txtGameList_Serial.Text = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial.ToString
                Me.txtGameList_Region.Text = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Region.ToString
                Me.txtGameList_Compat.Text = assignCompatText(mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Compat)
                Me.txtGameList_Compat.BackColor = assignCompatColor(mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Compat, Color.WhiteSmoke)
                Me.imgFlag.Visible = True
                Me.imgFlag.Image = Me.assignFlag(mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Region.ToString)
                Me.cmdGameSelectNone.Enabled = False

                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Settings.SStateMan_PathPics, mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial & ".jpg")) Then
                    Me.PictureBox1.Load(My.Computer.FileSystem.CombinePath(My.Settings.SStateMan_PathPics, mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).GameInfo.Serial & ".jpg"))
                    Me.PictureBox1.Width = Int(Me.PictureBox1.Size.Height * Me.PictureBox1.Image.PhysicalDimension.Width / Me.PictureBox1.Image.PhysicalDimension.Height)
                    Me.PictureBox1.Visible = True
                Else
                    Me.PictureBox1.Image = My.Resources.Flag_0Null_30x20
                    Me.PictureBox1.Visible = False
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
                    Me.PictureBox1.Visible = False

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

                    Me.PictureBox1.Visible = False
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

            Me.txtSize.Text = System.String.Format("{0:#,##0.00} / {1:#,##0.00} MiB", Me.SStateList_TotalSize / 1024 ^ 2, Me.GameList_TotalSize / 1024 ^ 2)
            Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} / {1:#,##0.00} MiB", Me.SStateList_TotalSizeBackup / 1024 ^ 2, Me.GameList_TotalSizeBackup / 1024 ^ 2)
            Me.txtSStateListSelection.Text = System.String.Format("{0:#,##0} / {1:#,##0} files", Me.lvwSStatesList.CheckedItems.Count, Me.lvwSStatesList.Items.Count)

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

    Private Function assignFlag(ByRef pStringToCheck As System.String) As System.Drawing.Bitmap
        If pStringToCheck.ToUpper.StartsWith("PAL") Then
            If pStringToCheck.ToUpper.StartsWith("PAL-I") Then
                assignFlag = My.Resources.Flag_Italy_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-F") Then
                assignFlag = My.Resources.Flag_France_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-Gr") Then
                assignFlag = My.Resources.Flag_Greece_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-G") Then
                If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName.ToUpper = "AUT" Then
                    assignFlag = My.Resources.Flag_Austria_30x20
                Else : assignFlag = My.Resources.Flag_Germany_30x20
                End If
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-Sw") Then
                    assignFlag = My.Resources.Flag_Switzerland_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-S") Then
                    assignFlag = My.Resources.Flag_Spain_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-E") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName.ToUpper = "AUS" Then
                        assignFlag = My.Resources.Flag_Australia_30x20
                Else : assignFlag = My.Resources.Flag_UK_30x20
                    End If
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-P") Then
                    assignFlag = My.Resources.Flag_Poland_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-R") Then
                    assignFlag = My.Resources.Flag_Russia_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("PAL-D") Then
                    assignFlag = My.Resources.Flag_Netherlands_30x20
            Else : assignFlag = My.Resources.Flag_Europe_Union_30x20
            End If
        ElseIf pStringToCheck.ToUpper.StartsWith("NTSC") Then
            If pStringToCheck.ToUpper.StartsWith("NTSC-U") Then
                If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName.ToUpper = "CAN" Then
                    assignFlag = My.Resources.Flag_Canada_30x20
                Else : assignFlag = My.Resources.Flag_US_30x20
                End If
            ElseIf pStringToCheck.ToUpper.StartsWith("NTSC-J") Or pStringToCheck.ToUpper.StartsWith("NTSC-E") Then
                assignFlag = My.Resources.Flag_Japan_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("NTSC-K") Then
                assignFlag = My.Resources.Flag_South_Korea_30x20
            ElseIf pStringToCheck.ToUpper.StartsWith("NTSC-CH") Then
                assignFlag = My.Resources.Flag_China_30x20
            Else : assignFlag = My.Resources.Flag_0Null_30x20
            End If
            Else : assignFlag = My.Resources.Flag_0Null_30x20
            End If
    End Function

    Private Function assignCompatText(ByRef pCompat As System.Byte) As System.String
        Select Case pCompat
            Case 0
                assignCompatText = "Unknown"
            Case 1
                assignCompatText = "Nothing"
            Case 2
                assignCompatText = "Intro"
            Case 3
                assignCompatText = "Menus"
            Case 4
                assignCompatText = "in-Game"
            Case 5
                assignCompatText = "Playable"
            Case 6
                assignCompatText = "Perfect"
            Case Else : assignCompatText = "Unknown"
        End Select
    End Function

    Private Function assignCompatColor(ByRef pCompat As System.Byte, ByRef pBGcolor As System.Drawing.Color) As System.Drawing.Color
        Select Case pCompat
            Case 0  'Unknown
                assignCompatColor = pBGcolor
            Case 1  'Nothing
                assignCompatColor = Color.FromArgb(255, 255, 192, 192)  'Red
            Case 2  'Intro
                assignCompatColor = Color.FromArgb(255, 255, 224, 192)  'Orange
            Case 3  'Menus
                assignCompatColor = Color.FromArgb(255, 255, 255, 192)  'Yellow
            Case 4  'in-Game
                assignCompatColor = Color.FromArgb(255, 255, 192, 255)  'Purple
            Case 5  'Playable
                assignCompatColor = Color.FromArgb(255, 192, 255, 192)  'Green
            Case 6  'Perfect
                assignCompatColor = Color.FromArgb(255, 192, 192, 255)  'Blue
            Case Else
                assignCompatColor = pBGcolor
        End Select

    End Function

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If Me.PictureBox1.Size.Height = 51 Then
            Me.PictureBox1.Location = New Point(12, Me.SplitContainer1.SplitterDistance - 174)
            Me.PictureBox1.Height = 171
            Me.PictureBox1.Width = Int(Me.PictureBox1.Size.Height * Me.PictureBox1.Image.PhysicalDimension.Width / Me.PictureBox1.Image.Height)
            'Me.PictureBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Top
            Me.lblGameList_Title.Visible = False
            Me.lblGameList_Region.Visible = False
            Me.lvwGamesList.Left = Me.txtGameList_Title.Left
            Me.lvwGamesList.Width = Me.SplitContainer1.Width - Me.txtGameList_Title.Left - 12
            Me.Button1.Visible = True
            'Me.Button1.Left = Me.PictureBox1.Size.Width - Me.Button1.Size.Width
            Me.Button1.Image = My.Resources.Metro_Reduce
        Else
            Me.PictureBox1.Location = New Point(12, Me.lvwGamesList.Size.Height + 31)
            Me.PictureBox1.Height = 51
            Me.PictureBox1.Width = Int(Me.PictureBox1.Size.Height * Me.PictureBox1.Image.PhysicalDimension.Width / Me.PictureBox1.Image.Height)
            'Me.PictureBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
            Me.lblGameList_Title.Visible = True
            Me.lblGameList_Region.Visible = True
            Me.lvwGamesList.Left = 12
            Me.lvwGamesList.Width = Me.SplitContainer1.Width - 24
            'Me.Button1.Visible = False
            Me.Button1.Image = My.Resources.Metro_Expand

        End If
        Me.cmdRefresh.Left = Me.lvwGamesList.Left + 12
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Me.PictureBox1.Size.Height = 51 Then
            Me.PictureBox1.Location = New Point(12, Me.SplitContainer1.SplitterDistance - 174)
            Me.PictureBox1.Height = 171
            Me.PictureBox1.Width = Int(Me.PictureBox1.Size.Height * Me.PictureBox1.Image.PhysicalDimension.Width / Me.PictureBox1.Image.Height)
            'Me.PictureBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Top
            Me.lblGameList_Title.Visible = False
            Me.lblGameList_Region.Visible = False
            Me.lvwGamesList.Left = Me.txtGameList_Title.Left
            Me.lvwGamesList.Width = Me.SplitContainer1.Width - Me.txtGameList_Title.Left - 12
            Me.Button1.Visible = True
            'Me.Button1.Left = Me.PictureBox1.Size.Width - Me.Button1.Size.Width
            Me.Button1.Image = My.Resources.Metro_Reduce
        Else
            Me.PictureBox1.Location = New Point(12, Me.lvwGamesList.Size.Height + 31)
            Me.PictureBox1.Height = 51
            Me.PictureBox1.Width = Int(Me.PictureBox1.Size.Height * Me.PictureBox1.Image.PhysicalDimension.Width / Me.PictureBox1.Image.Height)
            'Me.PictureBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
            Me.lblGameList_Title.Visible = True
            Me.lblGameList_Region.Visible = True
            Me.lvwGamesList.Left = 12
            Me.lvwGamesList.Width = Me.SplitContainer1.Width - 24
            'Me.Button1.Visible = False
            Me.Button1.Image = My.Resources.Metro_Expand

        End If
        Me.cmdRefresh.Left = Me.lvwGamesList.Left + 12
    End Sub
End Class