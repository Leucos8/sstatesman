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

    Dim GamesLvw_SelectedSize As Int64 = 0
    Dim GamesLvw_SelectedSizeBackup As Int64 = 0
    Dim SStatesLvw_SelectedSize As Int64 = 0
    Dim SStatesLvw_SelectedSizeBackup As Int64 = 0

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
        LastWriteDate
        Size
        SerialRef
        ArrayRef
    End Enum


    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Dim zfi As System.IO.Packaging.ZipPackage
        'zfi.PartExists()

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


        Dim imlLvwCheckboxes As New ImageList          'Listviews checkboxes (stateimagelist)
        With imlLvwCheckboxes
            .ImageSize = New System.Drawing.Size(11, 11)        'Setting up the size
            .Images.Add(My.Resources.Metro_ChecboxUnchecked)    'Unchecked state image
            .Images.Add(My.Resources.Metro_ChecboxChecked)      'Checked state image
        End With
        Me.lvwGamesList.StateImageList = imlLvwCheckboxes                   'Assigning the imagelist to the Games listview
        Me.lvwSStatesList.StateImageList = imlLvwCheckboxes                 'Assigning the imagelist to the Savestates listview




        mdlGameDb.GameDb_Status = mdlGameDb.GameDb_Load(Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename),
                                                        mdlGameDb.GameDb)   'Loading the Game database (from PCSX2 directory)
        Me.GamesLvw_Populate()                                               'Refreshing the games list





        Me.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh


        If My.Settings.SStatesMan_SStatesListShowOnly Then
            Me.cmdSStatesLvwExpand_Click(Nothing, Nothing)
        End If



    End Sub

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
        GamesLvw_Populate()
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
        Me.SStatesLvw_Refresh()
        Me.UICheck()
        Me.UIEnabled(True)
    End Sub

    Private Sub cmdGameSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectNone.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.SStatesLvw_Refresh()
        Me.UICheck()
        Me.UIEnabled(True)
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
        Me.UIEnabled(True)
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGamesList.ItemChecked
        If WindowSkipListRefresh = False Then
            Me.SStatesLvw_Refresh()
            Me.UICheck()
        End If
    End Sub

    'SStatesList management
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
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True)
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True)
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
        Me.UIEnabled(True)
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).SubItems(frmMainSStatesLvwColumn.Backup).Text = "True" Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
        Me.UIEnabled(True)
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
            Me.UIEnabled(True)
        End If
    End Sub

    Public Sub GamesLvw_Populate()
        mdlMain.WriteToConsole("MainWindow", "GamesLvw_Populate", "Reloading the savestates and gameindex arrays, refreshing GameLvw listview.")

        Me.UIEnabled(False)

        Me.lvwGamesList.Items.Clear()
        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        mdlFileList.GamesList_Status = GamesList_LoadAll(My.Settings.PCSX2_PathSState, mdlFileList.GamesList)

        For Each GameItem As KeyValuePair(Of String, Dictionary(Of ListKeys, rFileList)) In mdlFileList.GamesList
            currentGameInfo = mdlGameDb.GameDb_RecordExtract(GameItem.Key, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)

            Dim GameLwv_ItemTmp As New ListViewItem
            GameLwv_ItemTmp.Text = currentGameInfo.Name
            GameLwv_ItemTmp.SubItems.AddRange({currentGameInfo.Serial, currentGameInfo.Region})

            Dim myFileListTmp As New mdlFileList.rFileList
            If GameItem.Value.TryGetValue(ListKeys.Savestates, myFileListTmp) Then
                GameLwv_ItemTmp.SubItems.Add(String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                                           GameItem.Value.Item(ListKeys.Savestates).InfoList.Count,
                                                           GameItem.Value.Item(ListKeys.Savestates).SizeTot / 1024 ^ 2))
            Else
                GameLwv_ItemTmp.SubItems.Add("None")
            End If

            myFileListTmp = New mdlFileList.rFileList
            If GameItem.Value.TryGetValue(ListKeys.Savestates_Backup, myFileListTmp) Then
                GameLwv_ItemTmp.SubItems.Add(String.Format("{0:#,##0} × {1:#,##0.00} MB",
                                                           GameItem.Value.Item(ListKeys.Savestates_Backup).InfoList.Count,
                                                           GameItem.Value.Item(ListKeys.Savestates_Backup).SizeTot / 1024 ^ 2))
            Else
                GameLwv_ItemTmp.SubItems.Add("None")
            End If

            Me.lvwGamesList.Items.Add(GameLwv_ItemTmp)

        Next

        'mdlSStatesList.SStatesList_Status = mdlSStatesList.SStatesList_Load(My.Settings.PCSX2_PathSState, mdlSStatesList.SStatesIndex)

        'For Each myItemTmp As KeyValuePair(Of String, mdlSStatesList.rSStatesIndex) In mdlSStatesList.SStatesIndex
        '    Dim GameList_ItemTmp As New ListViewItem
        '    currentGame = mdlGameDb.GameDb_RecordExtract(myItemTmp.Key, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)
        '    GameList_ItemTmp.Text = currentGame.Name
        '    GameList_ItemTmp.SubItems.AddRange({currentGame.Serial, currentGame.Region,
        '                                       String.Format("{0:#,##0} × {1:#,##0.00} MB", myItemTmp.Value.SStates_List.Count, myItemTmp.Value.SStates_SizeTot / 1024 ^ 2),
        '                                       String.Format("{0:#,##0} × {1:#,##0.00} MB", myItemTmp.Value.SStatesBck_List.Count, myItemTmp.Value.SStatesBck_SizeTot / 1024 ^ 2)})

        '    Me.lvwGamesList.Items.Add(GameList_ItemTmp)
        'Next

        For Each lvwItem As ListViewItem In Me.lvwGamesList.Items
            If colorswitch Then
                lvwItem.BackColor = Color.Transparent
                colorswitch = False
            Else
                lvwItem.BackColor = Color.WhiteSmoke
                colorswitch = True
            End If
        Next
        colorswitch = True

        Me.UIEnabled(True)
    End Sub

    Friend Sub GamesLvw_Update()
        'mdlMain.WriteToConsole("MainWindow", "GamesLvw_Update", "Updating GameLvw listview.")

        'Me.UIEnabled(False)
        'Dim ItemIndex As System.Int32 = 0
        'Dim ItemCount As System.Int32 = lvwGamesList.Items.Count - 1
        'If ItemCount > 0 Then
        '    Dim GamesIndexSS_Pos As System.Int32 = 0
        '    Do While ItemIndex <= ItemCount
        '        System.Int32.TryParse(lvwGamesList.Items(ItemIndex).SubItems(frmMainGamesLvwColumn_ArrayRef).Text, GamesIndexSS_Pos)
        '        If mdlGamesIndexSS.GamesIndexSS(GamesIndexSS_Pos).SStates_Count > 0 Or _
        '            mdlGamesIndexSS.GamesIndexSS(GamesIndexSS_Pos).SStates_Bck_Count > 0 Then
        '            lvwGamesList.Items(ItemIndex).SubItems(frmMainGamesLvwColumn_SStateInfo).Text = System.String.Format("{0:#,##0} × {1:#,##0.00} MB",
        '                                  mdlGamesIndexSS.GamesIndexSS(GamesIndexSS_Pos).SStates_Count, _
        '                                  mdlGamesIndexSS.GamesIndexSS(GamesIndexSS_Pos).SStates_SizeTot / 1024 ^ 2)

        '            lvwGamesList.Items(ItemIndex).SubItems(frmMainGamesLvwColumn_SStateBackupInfo).Text = System.String.Format("{0:#,##0} × {1:#,##0.00} MB",
        '                                  mdlGamesIndexSS.GamesIndexSS(GamesIndexSS_Pos).SStates_Bck_Count, _
        '                                  mdlGamesIndexSS.GamesIndexSS(GamesIndexSS_Pos).SStates_Bck_SizeTot / 1024 ^ 2)

        '            ItemIndex += 1
        '        Else
        '            lvwGamesList.Items(ItemIndex).Remove()
        '            ItemCount -= 1
        '        End If
        '    Loop
        'End If

        'For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
        '    Me.lvwGamesList.Items(lvwItemIndex).Font = Me.Font
        '    For lvwSubitemIndex = 1 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
        '        Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).ForeColor = Color.Gray
        '        Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).Font = Me.Font
        '    Next lvwSubitemIndex

        '    If colorswitch Then
        '        For lvwSubitemIndex = 0 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
        '            Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).BackColor = Color.Transparent
        '        Next lvwSubitemIndex
        '        colorswitch = False
        '    Else
        '        For lvwSubitemIndex = 0 To Me.lvwGamesList.Items(lvwItemIndex).SubItems.Count - 1
        '            Me.lvwGamesList.Items(lvwItemIndex).SubItems(lvwSubitemIndex).BackColor = Color.WhiteSmoke
        '        Next lvwSubitemIndex
        '        colorswitch = True
        '    End If
        'Next lvwItemIndex
        'colorswitch = True

        'Me.UIEnabled(True)
    End Sub

    Friend Sub SStatesLvw_Refresh()
        mdlMain.WriteToConsole("MainWindow", "SStatesLvw_Refresh", "Refreshing SStatesLvw listview.")

        Me.UIEnabled(False)

        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        mdlMain.currentFiles.Clear()

        Me.SStatesLvw_SelectedSize = 0
        Me.SStatesLvw_SelectedSizeBackup = 0
        Me.GamesLvw_SelectedSize = 0
        Me.GamesLvw_SelectedSizeBackup = 0


        'Dim myImportantListViewItems As New List(Of System.String)

        mdlMain.checkedGames.Clear()
        If Me.lvwGamesList.CheckedItems.Count > 0 Then
            For Each GameList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.CheckedItems
                mdlMain.checkedGames.Add(GameList_ItemChecked.SubItems(frmMainGamesLvwColumn.GameSerial).Text)
            Next
        ElseIf Me.lvwGamesList.SelectedItems.Count > 0 Then
            For Each GameList_ItemSelected As System.Windows.Forms.ListViewItem In Me.lvwGamesList.SelectedItems
                mdlMain.checkedGames.Add(GameList_ItemSelected.SubItems(frmMainGamesLvwColumn.GameSerial).Text)
            Next
        End If

        If Me.lvwGamesList.CheckedItems.Count > 1 Then
            Me.lvwSStatesList.ShowGroups = True
        Else
            Me.lvwSStatesList.ShowGroups = False
        End If

        For Each mySerial As System.String In mdlMain.checkedGames
            currentGameInfo = mdlGameDb.GameDb_RecordExtract(mySerial, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)

            Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup With {
                .Header = System.String.Format("{0} ({1}) [{2}]", currentGameInfo.Name, currentGameInfo.Region, currentGameInfo.Serial),
                .HeaderAlignment = HorizontalAlignment.Left,
                .Name = currentGameInfo.Serial}

            Me.lvwSStatesList.Groups.Add(SStateList_GroupTmp)

            Dim myImportantFileList As New mdlFileList.rFileList
            If mdlFileList.GamesList(currentGameInfo.Serial).TryGetValue(ListKeys.Savestates, myImportantFileList) Then
                GamesLvw_SelectedSize += myImportantFileList.SizeTot
                mdlMain.currentFiles.AddRange(myImportantFileList.InfoList.Values)

                For Each myFileInfoTmp As KeyValuePair(Of String, System.IO.FileInfo) In myImportantFileList.InfoList

                    Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem With {.Text = myFileInfoTmp.Value.Name,
                                                                                          .Group = SStateList_GroupTmp}
                    SStateList_ItemTmp.SubItems.AddRange({mdlFileList.SStates_GetSlot(myFileInfoTmp.Value.Name).ToString,
                                                          vbFalse.ToString,
                                                          myFileInfoTmp.Value.LastWriteTime.ToString,
                                                          System.String.Format("{0:#,##0.00} MB", myFileInfoTmp.Value.Length / 1024 ^ 2)})
                    If colorswitch Then
                        colorswitch = False
                    Else
                        SStateList_ItemTmp.BackColor = Color.WhiteSmoke
                        colorswitch = True
                    End If

                    Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
                Next

            End If

            myImportantFileList = New mdlFileList.rFileList
            If mdlFileList.GamesList(currentGameInfo.Serial).TryGetValue(ListKeys.Savestates_Backup, myImportantFileList) Then
                GamesLvw_SelectedSizeBackup += myImportantFileList.SizeTot
                mdlMain.currentFiles.AddRange(myImportantFileList.InfoList.Values)

                For Each myFileInfoTmp As KeyValuePair(Of String, System.IO.FileInfo) In myImportantFileList.InfoList

                    Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem With {.Text = myFileInfoTmp.Value.Name,
                                                                                          .Group = SStateList_GroupTmp}
                    SStateList_ItemTmp.SubItems.AddRange({mdlFileList.SStates_GetSlot(myFileInfoTmp.Value.Name).ToString,
                                                          vbTrue.ToString,
                                                          myFileInfoTmp.Value.LastWriteTime.ToString,
                                                          System.String.Format("{0:#,##0.00} MB", myFileInfoTmp.Value.Length / 1024 ^ 2)})
                    If colorswitch Then
                        colorswitch = False
                    Else
                        SStateList_ItemTmp.BackColor = Color.WhiteSmoke
                        colorswitch = True
                    End If

                    Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
                Next

            End If



            'GamesLvw_SelectedSize = GamesLvw_SelectedSize + mdlSStatesList.SStatesIndex(currentGame.Serial).SStates_SizeTot
            'GamesLvw_SelectedSizeBackup = GamesLvw_SelectedSizeBackup + mdlSStatesList.SStatesIndex(currentGame.Serial).SStatesBck_SizeTot

            'For Each myFileInfoTmp As System.IO.FileInfo In mdlSStatesList.SStatesIndex(currentGame.Serial).SStates_List

            '    Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem With {.Text = myFileInfoTmp.Name, .Group = SStateList_GroupTmp}
            '    SStateList_ItemTmp.SubItems.AddRange({mdlSStatesList.SStates_GetSlot(myFileInfoTmp.Name).ToString,
            '                                          mdlSStatesList.SStates_GetType(myFileInfoTmp.Extension).ToString,
            '                                          myFileInfoTmp.LastWriteTime.ToString,
            '                                          System.String.Format("{0:#,##0.00} MB", myFileInfoTmp.Length / 1024 ^ 2)})

            '    If mdlSStatesList.SStates_GetType(myFileInfoTmp.Extension) Then
            '        GamesLvw_SelectedSizeBackup = GamesLvw_SelectedSizeBackup + myFileInfoTmp.Length
            '    Else
            '        GamesLvw_SelectedSize = GamesLvw_SelectedSize + myFileInfoTmp.Length
            '    End If

            '    If colorswitch Then
            '        colorswitch = False
            '    Else
            '        SStateList_ItemTmp.BackColor = Color.WhiteSmoke
            '        colorswitch = True
            '    End If

            '    Me.lvwSStatesList.Items.Add(SStateList_ItemTmp)
            'Next
        Next

        colorswitch = True

        Me.UIEnabled(True)
    End Sub

    Private Sub SStatesLvw_SelectionChanged()
        'Me.UIEnabled(False)
        'Me.SStatesLvw_SelectedSize = 0
        'Me.SStatesLvw_SelectedSizeBackup = 0
        'If Me.lvwSStatesList.Items.Count > 0 Then
        '    For Each SStateList_ItemChecked As ListViewItem In Me.lvwSStatesList.CheckedItems
        '        If SStatesList(SStatesList_Pos).isBackup = False Then
        '            SStatesLvw_SelectedSize = SStatesLvw_SelectedSize + SStatesList(SStatesList_Pos).FileInfo.Length
        '        Else
        '            SStatesLvw_SelectedSizeBackup = SStatesLvw_SelectedSizeBackup + SStatesList(SStatesList_Pos).FileInfo.Length
        '        End If
        '    Next
        'End If
        Me.UIEnabled(True)
    End Sub

    Private Sub UIEnabled(enable As Boolean)
        If enable = True Then
            Me.WindowSkipListRefresh = False
            Me.lvwGamesList.EndUpdate()
            Me.lvwSStatesList.EndUpdate()
        Else
            Me.WindowSkipListRefresh = True
            Me.lvwGamesList.BeginUpdate()
            Me.lvwSStatesList.BeginUpdate()
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
                Me.txtGameList_Title.Text = currentGameInfo.Name
                Me.txtGameList_Serial.Text = currentGameInfo.Serial
                Me.txtGameList_Region.Text = currentGameInfo.Region
                Me.txtGameList_Compat.Text = mdlMain.assignCompatText(currentGameInfo.Compat)
                Me.txtGameList_Compat.BackColor = mdlMain.assignCompatColor(currentGameInfo.Compat, Color.WhiteSmoke)
                Me.imgFlag.Image = mdlMain.assignFlag(currentGameInfo.Region, currentGameInfo.Serial)
                Me.cmdGameSelectNone.Enabled = False

                If System.IO.File.Exists(System.IO.Path.Combine(My.Settings.SStatesMan_PathPics, currentGameInfo.Serial & ".jpg")) Then
                    Me.imgCover.SizeMode = PictureBoxSizeMode.Zoom
                    Me.imgCover.Load(System.IO.Path.Combine(My.Settings.SStatesMan_PathPics, currentGameInfo.Serial & ".jpg"))
                Else
                    Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                    Me.imgCover.Image = My.Resources.Nocover
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

    Private Sub tmrSStatesListRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSStatesListRefresh.Tick
        If My.Settings.SStatesMan_SStatesListAutoRefresh Then
            If System.IO.Directory.Exists(My.Settings.PCSX2_PathSState) And Not frmDeleteForm.Visible Then
                If Not (System.IO.Directory.GetLastWriteTime(My.Settings.PCSX2_PathSState) = mdlFileList.SStates_FolderLastModified) Then
                    Me.Enabled = False
                    GamesLvw_Populate()
                    UICheck()
                    Me.Enabled = True
                End If
            End If
        Else
            Me.tmrSStatesListRefresh.Enabled = False
        End If
    End Sub

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

    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim recToolbar As New Rectangle(0, 7, 24, 40)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.FromArgb(130, 150, 200), Color.FromArgb(65, 74, 100), 90)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If My.Settings.SStatesMan_BGEnable Then
            recToolbar = New Rectangle(0, panelWindowTitle.Height - 4, panelWindowTitle.Width, 4)
            linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
            e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        End If
        e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
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

    Private Sub imgCover_MouseClick(sender As System.Object, e As MouseEventArgs) Handles imgCover.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.TableLayoutPanel3.GetRowSpan(Me.imgCover) = 3 Then
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 1)
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 1))
                Me.imgCover.Size = New Size(48, 48)
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
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 3)
                Me.imgCover.Width = 120
            End If
        End If
    End Sub
End Class