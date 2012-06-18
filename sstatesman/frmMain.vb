'   SStatesMan - a savestate managing tool for PCSX2
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
Imports System.IO

Public Class frmMain

    Dim WindowSkipListRefresh As Boolean = False

    Dim currentGameInfo As New GameTitle

    Dim lvwGamesList_SelectedSize As Int64 = 0
    Dim lvwGamesList_SelectedSizeBackup As Int64 = 0
    Dim lvwSStatesList_SelectedSize As Int64 = 0
    Dim lvwSStatesList_SelectedSizeBackup As Int64 = 0

    Friend Enum frmMainGamesLvwColumn
        GameTitle
        GameSerial
        GameRegion
        SStateInfo
        SStateBackupInfo
        ArrayRef
    End Enum

    Friend Enum frmMainSStatesLvwColumn
        FileName
        Slot
        Backup
        Version
        LastWriteDate
        Size
        SerialRef
    End Enum


    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If My.Settings.SStatesMan_FirstRun2 = True Then  'Executes the FirstRun procedure (it tries to detect PCSX2 folders)
            mdlMain.FirstRun()
        End If

        'Checks if there are some invalid settings

        If mdlMain.PCSX2_PathAll_Check() Then                           'Show the settings dialog
            frmSettings.ShowDialog(Me)
        End If


        Me.lblWindowVersion.Text = String.Concat(Me.lblWindowVersion.Text, _
                                                 My.Application.Info.Version.ToString, " ", _
                                                 My.Settings.SStatesMan_Channel) 'Add version information to the main window

        Select Case My.Settings.SStatesMan_BGImage
            Case Theme.square
                Me.panelWindowTitle.BackgroundImage = My.Resources.BG
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.None
                'Me.flpWindowBottom.BackgroundImage = Nothing
                'Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.None
            Case Theme.noise
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgNoise
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                'Me.flpWindowBottom.BackgroundImage = My.Resources.BgNoise
                'Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.stripes
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgStripes
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                'Me.flpWindowBottom.BackgroundImage = My.Resources.BgStripes
                'Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.brushmetal
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgMetalBrush
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                'Me.flpWindowBottom.BackgroundImage = My.Resources.BgMetalBrush
                'Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.PCSX2
                Me.panelWindowTitle.BackgroundImage = My.Resources.BG_PCSX2
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Stretch
                'Me.flpWindowBottom.BackgroundImage = My.Resources.BG_PCSX2
                'Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Stretch
            Case Else
                My.Settings.SStatesMan_BGImage = Theme.none
                Me.panelWindowTitle.BackgroundImage = Nothing
                'Me.flpWindowBottom.BackgroundImage = Nothing
        End Select


        Dim imlLvwCheckboxes As New ImageList                   'Listviews checkboxes (stateimagelist)
        With imlLvwCheckboxes
            .ImageSize = New System.Drawing.Size(11, 11)        'Setting up the size
            .Images.Add(My.Resources.Metro_ChecboxUnchecked)    'Unchecked state image
            .Images.Add(My.Resources.Metro_ChecboxChecked)      'Checked state image
        End With
        Me.lvwGamesList.StateImageList = imlLvwCheckboxes       'Assigning the imagelist to the Games listview
        Me.lvwSStatesList.StateImageList = imlLvwCheckboxes     'Assigning the imagelist to the Savestates listview




        'Loading the Game database (from PCSX2 directory)
        mdlGameDb.GameDb_Status = mdlGameDb.GameDb_Load(Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), mdlGameDb.GameDb)
        'Scanning savestates
        mdlFileList.GamesList_Status = GamesList_LoadAll(My.Settings.PCSX2_PathSState, mdlFileList.GamesList)
        'Refreshing the games list
        Me.lvwGamesList_Populate()




        'Timer auto refresh
        Me.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh


        If My.Settings.SStatesMan_SStatesListShowOnly Then
            Me.cmdSStatesLvwExpand_Click(Nothing, Nothing)
        End If



    End Sub

#Region "Window command buttons"
    Private Sub cmdWindowMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmdWindowMaximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            'Me.Padding = New System.Windows.Forms.Padding(System.Math.Abs(Me.Top))
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonRestore
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            'Me.Padding = New System.Windows.Forms.Padding(1)
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonMaximize
        End If
    End Sub

    Private Sub cmdWindowClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()
        End
    End Sub

    Private Sub frmMain_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Normal Then
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonMaximize
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonRestore
        End If
    End Sub

#End Region

#Region "Window dialogs buttons"
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
#End Region

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        mdlFileList.GamesList_Status = GamesList_LoadAll(My.Settings.PCSX2_PathSState, mdlFileList.GamesList)
        lvwGamesList_Populate()
        UICheck()
    End Sub

    Private Sub cmdSStateDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateDelete.Click
        frmDeleteForm.ShowDialog(Me)
    End Sub

#Region "Gamelist management"

    Private Sub cmdGameSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectAll.Click
        Me.UIEnabled(False, True, True)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.lvwSStatesList_Populate()
        Me.UICheck()
        Me.UIEnabled(True, True, True)
    End Sub

    Private Sub cmdGameSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectNone.Click
        Me.UIEnabled(False, True, True)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.lvwSStatesList_Populate()
        Me.UICheck()
        Me.UIEnabled(True, True, True)
    End Sub

    Private Sub cmdGameSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdGameSelectInvert.Click
        Me.UIEnabled(False, True, True)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            If Me.lvwGamesList.Items.Item(lvwItemIndex).Checked Then
                Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.lvwSStatesList_Populate()
        Me.UICheck()
        Me.UIEnabled(True, True, True)
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGamesList.ItemChecked
        If WindowSkipListRefresh = False Then
            Me.lvwSStatesList_Populate()
            Me.UICheck()
        End If
    End Sub
#End Region

#Region "SStatesList management"
    Private Sub cmdSStatesLvwExpand_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesLvwExpand.Click
        If Me.SplitContainer1.Panel1Collapsed Then
            Me.SplitContainer1.Panel1Collapsed = False
            Me.cmdSStatesLvwExpand.Image = My.Resources.Metro_ExpandTop
        Else
            Me.SplitContainer1.Panel1Collapsed = True
            Me.cmdSStatesLvwExpand.Image = My.Resources.Metro_ExpandBottom

            Me.cmdGameSelectAll_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Me.UIEnabled(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.lvwSStatesList_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True, False, True)
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Me.UIEnabled(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.lvwSStatesList_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True, False, True)
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Me.UIEnabled(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.lvwSStatesList_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True, False, True)
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UIEnabled(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).SubItems(frmMainSStatesLvwColumn.Backup).Text = "True" Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.lvwSStatesList_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True, False, True)
    End Sub

    Private Sub lvwGamesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGamesList.SelectedIndexChanged
        If Me.lvwGamesList.CheckedItems.Count = 0 And Not (Me.lvwGamesList.SelectedItems.Count = 0) Then
            If WindowSkipListRefresh = False Then
                Me.lvwSStatesList_Populate()
                Me.UICheck()
            End If
        End If
    End Sub

    Private Sub lvwSStatesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesList.ItemChecked
        If WindowSkipListRefresh = False Then
            Me.lvwSStatesList_SelectionChanged()
            Me.UICheck()
            Me.UIEnabled(True, False, True)
        End If
    End Sub
#End Region

    Public Sub lvwGamesList_Populate()
        mdlMain.WriteToConsole("MainWindow", "lvwGamesList_Populate", "Refreshing lvwGamesList listview.")

        Me.UIEnabled(False, True, True)

        Me.lvwGamesList.Items.Clear()
        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        'I must move this line in another procedure
        'mdlFileList.GamesList_Status = GamesList_LoadAll(My.Settings.PCSX2_PathSState, mdlFileList.GamesList)

        For Each tmpGListItem As KeyValuePair(Of String, mdlFileList.GamesList_Item) In mdlFileList.GamesList
            currentGameInfo = mdlGameDb.GameDb_RecordExtract(tmpGListItem.Key, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)

            'Creating the listviewitem
            Dim tmpLvwGListItem As New ListViewItem With {.Text = currentGameInfo.Name, .Name = currentGameInfo.Serial}
            tmpLvwGListItem.SubItems.AddRange({currentGameInfo.Serial, currentGameInfo.Region})
            'Calculating savestates count and displaying size
            If tmpGListItem.Value.Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Count > 0 Then
                tmpLvwGListItem.SubItems.Add(String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                                            tmpGListItem.Value.Savestates.Where(Function(extfilter) extfilter.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Count,
                                                            tmpGListItem.Value.Savestates_SizeTot / 1024 ^ 2))
            Else
                tmpLvwGListItem.SubItems.Add("None")
            End If

            'Calculating backups count and displaying size
            If tmpGListItem.Value.Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Count > 0 Then
                tmpLvwGListItem.SubItems.Add(String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                                            tmpGListItem.Value.Savestates.Where(Function(extfilter) extfilter.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Count,
                                                            tmpGListItem.Value.SavestatesBackup_SizeTot / 1024 ^ 2))
            Else
                tmpLvwGListItem.SubItems.Add("None")
            End If

            'If it was previously checked the check it again
            If checkedGames.Contains(currentGameInfo.Serial) Then
                tmpLvwGListItem.Checked = True
            End If

            'All done, the item is added
            Me.lvwGamesList.Items.Add(tmpLvwGListItem)

        Next

        'item back color
        'done here because the games are sorted by title instead of serials
        For Each tmpLvwGListItem As ListViewItem In Me.lvwGamesList.Items
            If colorswitch Then
                tmpLvwGListItem.BackColor = Color.Transparent
                colorswitch = False
            Else
                tmpLvwGListItem.BackColor = Color.WhiteSmoke
                colorswitch = True
            End If
        Next
        colorswitch = True
        Me.lvwSStatesList_Populate()

        Me.UIEnabled(True, True, True)
    End Sub

    Friend Sub lvwGamesList_Update()
        mdlMain.WriteToConsole("MainWindow", "GamesLvw_Update", "Updating GameLvw listview.")

        Me.UIEnabled(False, True, True)

        For Each tmpGame In checkedGames
            If GamesList(tmpGame).Savestates.Count > 0 Then
                If GamesList(tmpGame).Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Count > 0 Then
                    lvwGamesList.Items(tmpGame).SubItems(frmMainGamesLvwColumn.SStateInfo).Text = String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                                                                                  GamesList(tmpGame).Savestates.Where(Function(extfilter) extfilter.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Count,
                                                                                                  GamesList(tmpGame).Savestates_SizeTot / 1024 ^ 2)
                Else
                    lvwGamesList.Items(tmpGame).SubItems(frmMainGamesLvwColumn.SStateInfo).Text = "None"
                End If

                If GamesList(tmpGame).Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Count > 0 Then
                    lvwGamesList.Items(tmpGame).SubItems(frmMainGamesLvwColumn.SStateBackupInfo).Text = String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                                                                                         GamesList(tmpGame).Savestates.Where(Function(extfilter) extfilter.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Count,
                                                                                                         GamesList(tmpGame).SavestatesBackup_SizeTot / 1024 ^ 2)
                Else
                    lvwGamesList.Items(tmpGame).SubItems(frmMainGamesLvwColumn.SStateBackupInfo).Text = "None"
                End If
            Else
                lvwGamesList.Items(tmpGame).Remove()
                checkedGames.Remove(tmpGame)
                GamesList.Remove(tmpGame)
            End If
        Next

        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            If colorswitch Then
                Me.lvwGamesList.Items(lvwItemIndex).BackColor = Color.Transparent
                colorswitch = False
            Else
                Me.lvwGamesList.Items(lvwItemIndex).BackColor = Color.WhiteSmoke
                colorswitch = True
            End If
        Next lvwItemIndex
        colorswitch = True

        Me.UIEnabled(True, True, True)
    End Sub

    Friend Sub lvwSStatesList_Populate()
        mdlMain.WriteToConsole("MainWindow", "lvwSStatesList_Populate", "Refreshing lvwSStatesLvw listview.")

        Me.UIEnabled(False, False, True)

        'Preparation for the update
        Me.lvwGamesList_SelectedSize = 0
        Me.lvwGamesList_SelectedSizeBackup = 0
        Me.lvwSStatesList_SelectedSize = 0
        Me.lvwSStatesList_SelectedSizeBackup = 0
        'mdlMain.currentFiles.Clear()


        'checked games are cleared, they are reindexed
        mdlMain.checkedGames.Clear()
        'reindexing checked games
        If Me.lvwGamesList.CheckedItems.Count > 0 Then
            For Each tmpGamesList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.CheckedItems
                mdlMain.checkedGames.Add(tmpGamesList_ItemChecked.Name)
            Next
        ElseIf Me.lvwGamesList.SelectedItems.Count > 0 Then
            For Each tmpGamesList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.SelectedItems
                mdlMain.checkedGames.Add(tmpGamesList_ItemChecked.Name)
            Next
        End If

        'clear items and group, lvwSStatesList refresh in fact begins here
        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        'if more than one game is checked groups are shown
        If Me.lvwGamesList.CheckedItems.Count > 1 Then
            Me.lvwSStatesList.ShowGroups = True
        Else
            Me.lvwSStatesList.ShowGroups = False
        End If

        For Each mySerial As System.String In mdlMain.checkedGames

            'Creation of the header
            currentGameInfo = mdlGameDb.GameDb_RecordExtract(mySerial, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)
            Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                .Header = System.String.Format("{0} ({1}) [{2}]", currentGameInfo.Name, currentGameInfo.Region, currentGameInfo.Serial),
                .HeaderAlignment = HorizontalAlignment.Left,
                .Name = currentGameInfo.Serial}

            Me.lvwSStatesList.Groups.Add(tmpLvwSListGroup)

            '
            Dim tmpGamesListItem As New GamesList_Item
            tmpGamesListItem = mdlFileList.GamesList(currentGameInfo.Serial)

            lvwGamesList_SelectedSize += mdlFileList.GamesList(currentGameInfo.Serial).Savestates_SizeTot
            lvwGamesList_SelectedSizeBackup += mdlFileList.GamesList(currentGameInfo.Serial).SavestatesBackup_SizeTot

            For Each tmpSavestate As KeyValuePair(Of String, Savestate) In mdlFileList.GamesList(currentGameInfo.Serial).Savestates

                Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSavestate.Value.Name,
                                                                                   .Group = tmpLvwSListGroup,
                                                                                   .Name = tmpSavestate.Value.Name}
                tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Slot.ToString,
                                                   tmpSavestate.Value.Backup.ToString,
                                                   tmpSavestate.Value.Version,
                                                   tmpSavestate.Value.LastWriteTime.ToString,
                                                   System.String.Format("{0:#,##0.00} MB", tmpSavestate.Value.Length / 1024 ^ 2), mySerial})
                If checkedSavestates.Contains(tmpSavestate.Key) Then
                    tmpLvwSListItem.Checked = True
                End If
                'adding to currentFiles
                'currentFiles.Add(tmpSavestate.Key)

                'Backcolor
                If colorswitch Then
                    colorswitch = False
                Else
                    tmpLvwSListItem.BackColor = Color.WhiteSmoke
                    colorswitch = True
                End If

                Me.lvwSStatesList.Items.Add(tmpLvwSListItem)
            Next


        Next

        colorswitch = True

        Me.UIEnabled(True, False, True)
    End Sub

    Private Sub lvwSStatesList_SelectionChanged()
        'Me.UIEnabled(False, False, True)

        Me.lvwSStatesList_SelectedSize = 0
        Me.lvwSStatesList_SelectedSizeBackup = 0
        checkedSavestates.Clear()

        If Me.lvwSStatesList.CheckedItems.Count > 0 Then
            For Each tmpLvwSListItemChecked As ListViewItem In Me.lvwSStatesList.CheckedItems

                Dim tmpGameSerial As String = mdlFileList.SStates_GetSerial(tmpLvwSListItemChecked.Name)
                Dim tmpSavestate As Savestate = mdlFileList.GamesList(tmpGameSerial).Savestates(tmpLvwSListItemChecked.Name)
                checkedSavestates.Add(tmpSavestate.Name)

                If tmpSavestate.Backup Then
                    lvwSStatesList_SelectedSizeBackup += tmpSavestate.Length
                Else
                    lvwSStatesList_SelectedSize += tmpSavestate.Length
                End If
            Next
        End If
        'Me.UIEnabled(True, False, True)
    End Sub

    Private Sub UIEnabled(ByVal enable As Boolean, ByVal GamesList As Boolean, ByVal SavestatesList As Boolean)
        If enable = True Then
            Me.WindowSkipListRefresh = False
            If GamesList Then
                Me.lvwGamesList.EndUpdate()
            End If
            If SavestatesList Then
                Me.lvwSStatesList.EndUpdate()
            End If
        Else
            Me.WindowSkipListRefresh = True
            If GamesList Then
                Me.lvwGamesList.BeginUpdate()
            End If
            If SavestatesList Then
                Me.lvwSStatesList.BeginUpdate()
            End If
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

                Me.txtSize.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.lvwSStatesList_SelectedSize / 1024 ^ 2, Me.lvwGamesList_SelectedSize / 1024 ^ 2)
                Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.lvwSStatesList_SelectedSizeBackup / 1024 ^ 2, Me.lvwGamesList_SelectedSizeBackup / 1024 ^ 2)
                Me.txtGameList_Title.Text = currentGameInfo.Name
                Me.txtGameList_Serial.Text = currentGameInfo.Serial
                Me.txtGameList_Region.Text = currentGameInfo.Region
                Me.txtGameList_Compat.Text = mdlMain.assignCompatText(currentGameInfo.Compat)
                Me.txtGameList_Compat.BackColor = mdlMain.assignCompatColor(currentGameInfo.Compat, Color.WhiteSmoke)
                Me.imgFlag.Image = mdlMain.assignFlag(currentGameInfo.Region, currentGameInfo.Serial)
                Me.imgFlag.Width = Me.imgFlag.Image.PhysicalDimension.Width + 2
                Me.imgFlag.Height = Me.imgFlag.Image.PhysicalDimension.Height + 2
                Me.cmdGameSelectNone.Enabled = False

                If System.IO.File.Exists(System.IO.Path.Combine(My.Settings.SStatesMan_PathPics, currentGameInfo.Serial & ".jpg")) Then
                    Me.imgCover.SizeMode = PictureBoxSizeMode.StretchImage
                    Me.imgCover.Load(System.IO.Path.Combine(My.Settings.SStatesMan_PathPics, currentGameInfo.Serial & ".jpg"))
                    If Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 3 Then
                        Me.imgCover.Height = Me.imgCover.Image.PhysicalDimension.Height * 118 \ Me.imgCover.Image.PhysicalDimension.Width + 2
                    ElseIf Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 2 Then
                        Me.imgCover.Width = Me.imgCover.Image.PhysicalDimension.Width * 46 \ Me.imgCover.Image.PhysicalDimension.Height + 2
                    End If
                Else
                    Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                    Me.imgCover.Image = My.Resources.Nocover
                    If Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 3 Then
                        Me.imgCover.Height = 48
                    ElseIf Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 2 Then
                        Me.imgCover.Width = 48
                    End If
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
                    Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

                    Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                    Me.imgCover.Image = My.Resources.Flag_0Null_30x20

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

                    Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                    Me.imgCover.Image = My.Resources.Flag_0Null_30x20
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

            Me.txtSize.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.lvwSStatesList_SelectedSize / 1024 ^ 2, Me.lvwGamesList_SelectedSize / 1024 ^ 2)
            Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MB", Me.lvwSStatesList_SelectedSizeBackup / 1024 ^ 2, Me.lvwGamesList_SelectedSizeBackup / 1024 ^ 2)
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

    Private Sub tmrSStatesListRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSStatesListRefresh.Tick
        If My.Settings.SStatesMan_SStatesListAutoRefresh Then
            If System.IO.Directory.Exists(My.Settings.PCSX2_PathSState) And Not frmDeleteForm.Visible And Not frmSettings.Visible And Not Me.WindowState = FormWindowState.Minimized Then
                Dim tmpDate As System.DateTime = System.IO.Directory.GetLastWriteTime(My.Settings.PCSX2_PathSState)
                If Not tmpDate = mdlFileList.SStates_FolderLastModified Then
                    mdlMain.WriteToConsole("MainWindow", "Timer", "Refresh...")
                    mdlFileList.SStates_FolderLastModified = tmpDate
                    Me.Enabled = False
                    lvwGamesList_Populate()
                    UICheck()
                    Me.Enabled = True
                End If
            End If
        Else
            Me.tmrSStatesListRefresh.Enabled = False
        End If
    End Sub
#Region "Tabs"
    Private Sub optSettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab1.CheckedChanged
        If Me.optSettingTab1.Checked = True Then
            With Me.optSettingTab1
                '.ForeColor = Me.flpTab.ForeColor
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab2
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            With Me.optSettingTab3
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            'Me.pnlTab1.Visible = True
            'Me.pnlTab2.Visible = False
            'Me.pnlTab3.Visible = False
        End If
    End Sub

    Private Sub optSettingTab2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab2.CheckedChanged
        If Me.optSettingTab2.Checked = True Then
            With Me.optSettingTab2
                '.ForeColor = Me.flpTab.ForeColor
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab1
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            With Me.optSettingTab3
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            'Me.pnlTab2.Visible = True
            'Me.pnlTab1.Visible = False
            'Me.pnlTab3.Visible = False
        End If
    End Sub

    Private Sub optSettingTab3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab3.CheckedChanged
        If Me.optSettingTab3.Checked = True Then
            With Me.optSettingTab3
                '.ForeColor = Me.flpTab.ForeColor
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab1
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            With Me.optSettingTab2
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            'Me.pnlTab3.Visible = True
            'Me.pnlTab1.Visible = False
            'Me.pnlTab2.Visible = False
        End If
    End Sub
#End Region

#Region "UI paint"
    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim rectoolbar As New Rectangle(0, 8, 24, 39)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(rectoolbar, Color.FromArgb(130, 150, 200), Color.FromArgb(65, 74, 100), 90)
        e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
        If (panelWindowTitle.Height > 4) And (panelWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_BGEnable Then
                rectoolbar = New Rectangle(0, panelWindowTitle.Height - 4, panelWindowTitle.Width, 4)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(rectoolbar, Color.Transparent, Color.DarkGray, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
        End If
    End Sub

    Private Sub optSettingTab1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optSettingTab1.Paint
        If Me.optSettingTab1.Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, Me.optSettingTab1.Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, Me.optSettingTab1.Height)
            e.Graphics.DrawLine(Pens.DimGray, Me.optSettingTab1.Width - 1, 0, Me.optSettingTab1.Width - 1, Me.optSettingTab1.Height)
        End If
    End Sub

    Private Sub optSettingTab2_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optSettingTab2.Paint
        If Me.optSettingTab2.Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, Me.optSettingTab2.Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, Me.optSettingTab2.Height)
            e.Graphics.DrawLine(Pens.DimGray, Me.optSettingTab2.Width - 1, 0, Me.optSettingTab2.Width - 1, Me.optSettingTab2.Height)
        End If
    End Sub


    Private Sub optSettingTab3_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optSettingTab3.Paint
        If Me.optSettingTab3.Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, Me.optSettingTab3.Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, Me.optSettingTab3.Height)
            e.Graphics.DrawLine(Pens.DimGray, Me.optSettingTab3.Width - 1, 0, Me.optSettingTab3.Width - 1, Me.optSettingTab3.Height)
        End If
    End Sub

    Private Sub SplitContainer1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Paint
        e.Graphics.DrawLine(Pens.DarkGray, 0, Me.SplitContainer1.SplitterDistance + 1, Me.SplitContainer1.Width, Me.SplitContainer1.SplitterDistance + 1)
    End Sub

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    If (m.Msg = &H83) Then
    '        Dim point As New Point(m.LParam.ToInt32)
    '        m.Result = New IntPtr(-1)
    '        Return
    '    End If

    '    MyBase.WndProc(m)
    'End Sub

    'Private Sub frmMain_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    '    If Me.Width > 0 And Me.Height > 0 Then
    '        e.Graphics.DrawLine(Pens.DimGray, 0, 0, Me.Width - 1, 0)
    '        e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, Me.Height - 1)
    '        e.Graphics.DrawLine(Pens.DimGray, 0, Me.Height - 1, Me.Width - 1, Me.Height - 1)
    '        e.Graphics.DrawLine(Pens.DimGray, Me.Width - 1, 0, Me.Width - 1, Me.Height - 1)
    '    End If
    'End Sub
#End Region
    Private Sub imgCover_MouseClick(sender As System.Object, e As MouseEventArgs) Handles imgCover.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 3 Then
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 1)
                Me.imgCover.Size = New Size(48, 48)
                Me.imgCover.Width = Me.imgCover.Image.PhysicalDimension.Width * (Me.imgCover.Height - 2) \ Me.imgCover.Image.PhysicalDimension.Height + 2
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 1))
                Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(0, 0))
                Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 9)
                Me.lblGameList_Title.Visible = True
                Me.lblGameList_Region.Visible = True
            ElseIf Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 2 Then
                Me.lblGameList_Title.Visible = False
                Me.lblGameList_Region.Visible = False
                Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 7)
                Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(2, 0))
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 0))
                Me.imgCover.Width = 120
                Me.imgCover.Height = Me.imgCover.Image.PhysicalDimension.Height * 118 \ Me.imgCover.Image.PhysicalDimension.Width + 2
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 3)
            End If
        End If
    End Sub
End Class