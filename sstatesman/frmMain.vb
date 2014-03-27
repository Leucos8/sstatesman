'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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
Public NotInheritable Class frmMain
    Friend Property CurrentListMode As ListMode = ListMode.Savestates

    'Main window checked objects list
    Friend checkedGames As New List(Of String)
    Friend checkedFiles() As List(Of String) = {New List(Of String), New List(Of String), New List(Of String)}

    'Stores the current game information displayed in the game information section
    Dim currentGameInfo As New GameInfo
    Dim currentSnapshotFullname As String = String.Empty

    'Current size in bytes of the selected items
    Dim GameList_SelectedSize As Long = 0
    Dim GameList_SelectedSizeBackup As Long = 0
    Dim FileList_SelectedSize As Long = 0
    Dim FileList_SelectedSizeBackup As Long = 0

    'Default sizes for the cover image
    Friend ReadOnly Cover_SizeExpanded As New Size(120, 170)
    Friend ReadOnly Cover_SizeReduced As New Size(32, 46)

#Region "Form"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpPartialTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "Start.")
        '===========================
        'Settings, theme & resources
        '===========================

        'Getting DPI information
        'It has to be here because a form is needed
        Using gfx As Graphics = Me.CreateGraphics()
            DPIxScale = gfx.DpiX / 96
            DPIyScale = gfx.DpiY / 96
        End Using

        mdlTheme.LoadTheme(My.Settings.SStatesMan_Theme)

        If My.Settings.SStatesMan_FirstRun Then
            'Executes the FirstRun procedure (detects PCSX2 folders configuration)
            mdlMain.FirstRun()
        Else
            'Checks if there are some invalid settings
            My.Settings.SStatesMan_SettingsOK = mdlPCSX2Settings.PCSX2_PathAll_Check(My.Settings.PCSX2_PathBin, _
                                                                                     My.Settings.PCSX2_PathInis, _
                                                                                     My.Settings.PCSX2_PathSState, _
                                                                                     My.Settings.PCSX2_PathSnaps)
        End If

        If Not (My.Settings.SStatesMan_SettingsOK) Then
            frmSettings.currentTab = 1
            frmSettings.ShowDialog(Me)
        End If

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "Settings and resources.", sw.ElapsedTicks)
        sw.Restart()

        '==============
        'Loading things
        '==============

        'Loading the Game database (from PCSX2 directory)
        PCSX2GameDb.LoadDB(Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename))
        'Loading the internal savestate version database
        PCSX2StateVerDB.Load(My.Resources.ssversion)


        'Refreshing the games list
        SSMGameList.Load(My.Settings.PCSX2_PathSState, My.Settings.SStatesMan_PathStored, My.Settings.PCSX2_PathSnaps, My.Settings.SStatesMan_PathIso)


        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "GameDB and games files.", sw.ElapsedTicks)
        sw.Restart()


        '==================
        'Window preparation
        '==================

        '-----
        'Theme
        '-----
        Me.FormDescription = My.Application.Info.Description
        Me.flpWindowBottom.Visible = False
        Me.tlpWindowTop.Controls.Add(Me.flpTitleBarToolbar, 1, 0)
        Me.tlpWindowTop.Controls.Add(Me.lblWindowVersion, 1, 1)
        Me.tlpWindowTop.Controls.Add(Me.tlpTopBar, 0, 2)
        Me.tlpWindowTop.SetColumnSpan(Me.tlpTopBar, Me.tlpWindowTop.ColumnCount)
        Me.tlpTopBar.Dock = DockStyle.Fill
        Me.SplitContainer1.Dock = DockStyle.Fill

        'Add version information to the main window
        Me.lblWindowVersion.Text = String.Concat(Me.lblWindowVersion.Text, _
                                                 My.Application.Info.Version.ToString, " ", _
                                                 My.Settings.SStatesMan_Channel)


        'Checked state icons
        Me.lvwGamesList.StateImageList = mdlTheme.imlLvwCheckboxes  'Assigning the imagelist to the Games listview
        Me.lvwFilesList.StateImageList = mdlTheme.imlLvwCheckboxes  'Assigning the imagelist to the Files listview

        'ListViewItem icons
        Me.lvwGamesList.SmallImageList = mdlTheme.imlLvwItemIcons   'Assigning the imagelist to the Files listview
        Me.lvwFilesList.SmallImageList = mdlTheme.imlLvwItemIcons   'Assigning the imagelist to the Files listview

        '---------------
        'Window settings
        '---------------

        'Main window location, size and state
        Me.Location = My.Settings.frmMain_WindowLocation
        Me.ClientSize = My.Settings.frmMain_WindowSize
        If My.Settings.frmMain_WindowState = FormWindowState.Minimized Then
            My.Settings.frmMain_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmMain_WindowState
        'Splitter distance
        Me.SplitContainer1.SplitterDistance = My.Settings.frmMain_SplitterDistance



        'Games list columns size
        RemoveHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        RemoveHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.BeginUpdate()

        If My.Settings.frmMain_glvw_columnwidth IsNot Nothing Then
            If My.Settings.frmMain_glvw_columnwidth.Length = Me.lvwGamesList.Columns.Count Then
                For i As Integer = 0 To Me.lvwGamesList.Columns.Count - 1
                    Me.lvwGamesList.Columns(i).Width = My.Settings.frmMain_glvw_columnwidth(i)
                Next
            End If
        End If

        'Savestate list column size
        'If My.Settings.frmMain_slvw_columnwidth IsNot Nothing Then
        '    If My.Settings.frmMain_slvw_columnwidth.Length = Me.lvwFilesList.Columns.Count Then
        '        For i As Integer = 0 To Me.lvwFilesList.Columns.Count - 1
        '            Me.lvwFilesList.Columns(i).Width = My.Settings.frmMain_slvw_columnwidth(i)
        '        Next
        '    End If
        'End If

        'Cover image state
        If My.Settings.frmMain_CoverExpanded Then
            My.Settings.frmMain_CoverExpanded = Not (My.Settings.frmMain_CoverExpanded)
            Me.imgCover_MouseClick(Me, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
        End If

        If My.Settings.SStatesMan_SStatesListShowOnly Then
            Me.cmdSStatesLvwExpand_Click(Nothing, Nothing)
        End If

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "Main window prepared.", sw.ElapsedTicks - tmpPartialTicks)
        tmpPartialTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================

        Me.GameList_AddGames()
        Me.UI_SwitchMode(ListMode.Savestates)

        AddHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        AddHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.EndUpdate()

        'Timer auto refresh
        Me.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh

        'Me.UI_Enable(True, True)

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "Listed games/files and other things.", sw.ElapsedTicks - tmpPartialTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "Complete.", sw.ElapsedTicks)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '======================
        'Saving window settings
        '======================

        'State, location, and size
        My.Settings.frmMain_WindowState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            'Location and size saved only when windowstate is normal
            My.Settings.frmMain_WindowLocation = Me.Location
            My.Settings.frmMain_WindowSize = Me.ClientSize
        End If
        'Splitter distance
        My.Settings.frmMain_SplitterDistance = Me.SplitContainer1.SplitterDistance

        'Column widths
        My.Settings.frmMain_glvw_columnwidth = New Integer() {Me.GamesLvw_GameTitle.Width, Me.GameLvw_GameSerial.Width, Me.GameLvw_GameRegion.Width, _
                                                              Me.GameLvw_SStatesInfo.Width, Me.GameLvw_BackupInfo.Width, Me.GameLvw_SnapsInfo.Width}
        'My.Settings.frmMain_slvw_columnwidth = New Integer() {Me.SStatesLvw_FileName.Width, Me.SStatesLvw_Slot.Width, Me.SStatesLvw_Version.Width, _
        '                                                      Me.SStatesLvw_DateLastWrite.Width, Me.SStatesLvw_Size.Width}
    End Sub
#End Region

#Region "UI - General"
    Private Sub UI_SwitchMode(pListMode As ListMode)

        Select Case pListMode
            Case ListMode.Savestates
                Me.lblSStateListCheck.Text = "check savestates:"
                Me.cmdFileCheckBackup.Visible = True
                Me.cmdFilesReorder.Visible = True
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = True
                Me.txtSizeBackup.Visible = True
                Me.pnlScreenshotThumb.Visible = False
            Case ListMode.Stored
                Me.lblSStateListCheck.Text = "check savestates:"
                Me.cmdFileCheckBackup.Visible = False
                Me.cmdFilesReorder.Visible = True
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
                Me.pnlScreenshotThumb.Visible = False
            Case ListMode.Snapshots
                Me.lblSStateListCheck.Text = "check screenshots:"
                Me.cmdFileCheckBackup.Visible = False
                Me.cmdFilesReorder.Visible = False
                Me.lblSize.Text = "screenshots size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
                Me.pnlScreenshotThumb.Visible = True
        End Select

        Me.CurrentListMode = pListMode
        Me.FileList_AddColumns(pListMode)

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.ListMode, String.Format("Switched to {0}.", pListMode.ToString))
        Me.FileList_Refresh()
        'Me.UI_Enable(True)
    End Sub

    ''' <summary>Updates the UI status, game info and file info.</summary>
    Private Sub UI_Update()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.UI_UpdateGameInfo()
        Me.UI_UpdateFileInfo()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Status update done.", sw.ElapsedTicks)
    End Sub

    ''' <summary>Updates the UI game info: title, region, image cover, etc.</summary>
    Private Sub UI_UpdateGameInfo()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.tlpGameList.SuspendLayout()
        Me.tlpGameListCommands.SuspendLayout()

        If SSMGameList.Games.Count > 0 AndAlso _
            (Me.lvwGamesList.SelectedItems.Count > 0 OrElse _
             Me.lvwGamesList.CheckedItems.Count > 0) Then
            '========================
            'Game checked or selected
            '========================

            If Me.lvwGamesList.CheckedItems.Count > 0 Then
                'At least one game is checked
                Me.cmdGameSelectNone.Enabled = True
            Else
                'No games are checked
                Me.cmdGameSelectNone.Enabled = False
            End If

            If SSMGameList.Games.Count = Me.lvwGamesList.CheckedItems.Count Then
                'All the games are checked
                Me.cmdGameSelectAll.Enabled = False
            Else
                Me.cmdGameSelectAll.Enabled = True
            End If

            Me.cmdGameSelectAll.Visible = Me.cmdGameSelectAll.Enabled
            Me.cmdGameSelectNone.Visible = Me.cmdGameSelectNone.Enabled

            If Me.lvwGamesList.CheckedItems.Count > 1 Then
                '--------------------------
                'More than one game checked
                '--------------------------

                'Game info
                Me.txtGameList_Title.Text = "(multiple games selected)"
                Me.txtGameList_Serial.Text = String.Empty
                Me.txtGameList_Region.Text = String.Empty
                Me.txtGameList_Compat.Text = String.Empty
                Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
                Me.imgFlag.Image = My.Resources.Extra_ClearImage_30x20

                'Cover image
                Me.imgCover.SizeMode = PictureBoxSizeMode.Normal


                Dim tmpCover_Size As Size = Nothing
                If My.Settings.frmMain_CoverExpanded Then
                    tmpCover_Size = New Size(CInt(Cover_SizeExpanded.Width * DPIxScale), CInt(Cover_SizeExpanded.Height * DPIyScale))
                    Me.imgCover.Dock = DockStyle.Bottom
                Else
                    tmpCover_Size = New Size(CInt(Cover_SizeReduced.Height * DPIxScale), CInt(Cover_SizeReduced.Height * DPIyScale))
                    Me.imgCover.Dock = DockStyle.None
                End If
                Me.imgCover.Image = mdlCoverCache.RetrieveCover(checkedGames, My.Settings.SStatesMan_PathPics, _
                                                                tmpCover_Size, My.Settings.frmMain_CoverExpanded)
                Me.imgCover.Width = tmpCover_Size.Width + 2
                Me.imgCover.Height = tmpCover_Size.Height + 2

                'IsoFiles
                Me.cmdGamePlay.Enabled = False
                Me.cmiPCSX2Play.Enabled = False
                Me.cmiPCSX2Play.Text = "(Multiple games)"
                Me.cmiPCSX2Play.ToolTipText = String.Empty

            Else
                '---------------------------------
                'No more than one game is selected/checked
                '---------------------------------

                'Game info
                Me.txtGameList_Title.Text = currentGameInfo.Name
                Me.txtGameList_Serial.Text = currentGameInfo.Serial
                Me.txtGameList_Region.Text = currentGameInfo.Region
                Me.txtGameList_Compat.Text = currentGameInfo.CompatText
                Me.txtGameList_Compat.BackColor = currentGameInfo.CompatColor(Color.WhiteSmoke)
                Me.imgFlag.Image = mdlMain.assignFlag(currentGameInfo.Region, currentGameInfo.Serial)
                Me.imgFlag.Size = New Size(CInt(Me.imgFlag.Image.PhysicalDimension.Width * DPIxScale) + 2, _
                                           CInt(Me.imgFlag.Image.PhysicalDimension.Height * DPIyScale) + 2)

                'Cover image
                Me.imgCover.SizeMode = PictureBoxSizeMode.StretchImage

                If My.Settings.frmMain_CoverExpanded Then
                    Me.imgCover.Image = mdlCoverCache.RetrieveCover(currentGameInfo.Serial, My.Settings.SStatesMan_PathPics, My.Settings.frmMain_CoverExpanded)
                    Me.imgCover.Width = CInt(Cover_SizeExpanded.Width * DPIxScale) + 2
                    Me.imgCover.Height = CInt((Cover_SizeExpanded.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.PhysicalDimension.Width) * DPIyScale) + 2
                    Me.imgCover.Dock = DockStyle.Bottom
                Else
                    Me.imgCover.Image = mdlCoverCache.RetrieveCover(currentGameInfo.Serial, My.Settings.SStatesMan_PathPics, My.Settings.frmMain_CoverExpanded)
                    Me.imgCover.Width = CInt((Cover_SizeReduced.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.PhysicalDimension.Height) * DPIxScale) + 2
                    If Me.imgCover.Image.PhysicalDimension.Width < Me.imgCover.Image.PhysicalDimension.Height Then
                        Me.imgCover.Height = CInt(Cover_SizeReduced.Height * DPIxScale) + 2
                    Else
                        Me.imgCover.Height = CInt((Cover_SizeReduced.Height * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.PhysicalDimension.Width) * DPIyScale) + 2
                    End If
                    Me.imgCover.Dock = DockStyle.None
                End If

                'IsoFile
                If String.IsNullOrEmpty(SSMGameList.Games(currentGameInfo.Serial).GameIso) Then
                    Me.cmdGamePlay.Enabled = False
                    Me.cmiPCSX2Play.Enabled = False
                    Me.cmiPCSX2Play.Text = "(No Iso file found)"
                Else
                    Me.cmdGamePlay.Enabled = True
                    Me.cmiPCSX2Play.Enabled = True
                    Me.cmiPCSX2Play.Text = String.Format("Play {0}...", currentGameInfo.Serial)
                End If
                Me.cmiPCSX2Play.ToolTipText = SSMGameList.Games(currentGameInfo.Serial).GameIso
            End If

        Else
            '=========================
            'No games selected/checked
            '=========================

            'Game info cleared
            Me.txtGameList_Title.Text = String.Empty
            Me.txtGameList_Serial.Text = String.Empty
            Me.txtGameList_Region.Text = String.Empty
            Me.txtGameList_Compat.Text = String.Empty
            Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
            Me.imgFlag.Image = My.Resources.Extra_ClearImage_30x20

            'Cover image
            Me.imgCover.Image = My.Resources.Extra_ClearImage_30x20
            Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
            If My.Settings.frmMain_CoverExpanded Then
                Me.imgCover.Width = CInt(Cover_SizeExpanded.Width * DPIxScale) + 2
                Me.imgCover.Height = CInt(Cover_SizeExpanded.Height * DPIxScale) + 2
                Me.imgCover.Dock = DockStyle.Bottom
            Else
                Me.imgCover.Width = CInt(Cover_SizeReduced.Width * DPIyScale) + 2
                Me.imgCover.Height = CInt(Cover_SizeReduced.Height * DPIyScale) + 2
                Me.imgCover.Dock = DockStyle.None
            End If

            Me.cmdGameSelectNone.Enabled = False
            Me.cmdGameSelectNone.Visible = False

            Me.cmdGamePlay.Enabled = False
            Me.cmiPCSX2Play.Enabled = False
            Me.cmiPCSX2Play.Text = "(No game selected)"
            Me.cmiPCSX2Play.ToolTipText = String.Empty

            If SSMGameList.Games.Count = 0 Then
                '================
                'No games in list
                '================
                Me.cmdGameSelectAll.Enabled = False
                Me.cmdGameSelectInvert.Enabled = False
                Me.cmdGameSelectAll.Visible = True
                Me.cmdGameSelectNone.Visible = True

            Else
                Me.cmdGameSelectAll.Enabled = True
                Me.cmdGameSelectAll.Visible = True
                Me.cmdGameSelectInvert.Enabled = True
            End If
        End If

        Me.tlpGameListCommands.ResumeLayout()
        Me.tlpGameList.ResumeLayout()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Updated game info.", sw.ElapsedTicks)
    End Sub

    ''' <summary>Updates the UI savestate info: items selected, size.</summary>
    Private Sub UI_UpdateFileInfo()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = System.String.Format("{0:N0} | {1:N0} files", Me.lvwFilesList.CheckedItems.Count, Me.lvwFilesList.Items.Count)
        Me.txtSize.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.FileList_SelectedSize / 1024 ^ 2, Me.GameList_SelectedSize / 1024 ^ 2)
        Me.txtSizeBackup.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.FileList_SelectedSizeBackup / 1024 ^ 2, Me.GameList_SelectedSizeBackup / 1024 ^ 2)

        Me.tlpFileListCommands.SuspendLayout()

        If Me.lvwFilesList.Items.Count = 0 Then
            '================
            'No files in list
            '================
            Me.cmdFileCheckAll.Enabled = False
            Me.cmdFileCheckInvert.Enabled = False
            Me.cmdFileCheckNone.Enabled = False
            Me.cmdFileCheckBackup.Enabled = False

            Me.cmdFileCheckAll.Visible = True
            Me.cmdFileCheckInvert.Visible = True
            Me.cmdFileCheckNone.Visible = True

            Me.cmdFilesDelete.Enabled = False
            Me.cmdFilesReorder.Enabled = False

            Me.imgScreenshotThumb.Image = My.Resources.Extra_ClearImage_30x20
        Else
            '=================
            'Files are present
            '=================
            Me.cmdFileCheckInvert.Enabled = True

            If (Me.GameList_SelectedSizeBackup = 0) Or (Me.GameList_SelectedSizeBackup = Me.FileList_SelectedSizeBackup) Then
                'Backup size is zero -> no backup files in list
                'Backup size = selected backup size -> all backup are selected
                Me.cmdFileCheckBackup.Enabled = False
            Else
                Me.cmdFileCheckBackup.Enabled = True
            End If

            If Me.lvwGamesList.CheckedItems.Count > 1 Then
                'More than one game is checked
                Me.cmdFilesReorder.Enabled = False
            Else
                'A single game is checked/selected
                Me.cmdFilesReorder.Enabled = True
            End If

            If Me.lvwFilesList.CheckedItems.Count > 0 Then
                'At least one file is checked
                Me.cmdFileCheckNone.Enabled = True
                Me.cmdFilesDelete.Enabled = True

                If Me.lvwFilesList.Items.Count = Me.lvwFilesList.CheckedItems.Count Then
                    'All files are checked
                    Me.cmdFileCheckAll.Enabled = False
                Else
                    Me.cmdFileCheckAll.Enabled = True
                End If

            Else
                'No files are checked
                Me.cmdFileCheckNone.Enabled = False
                Me.cmdFileCheckAll.Enabled = True
                Me.cmdFilesDelete.Enabled = False
            End If

            Me.cmdFileCheckAll.Visible = Me.cmdFileCheckAll.Enabled
            Me.cmdFileCheckNone.Visible = Me.cmdFileCheckNone.Enabled
        End If

        Me.tlpFileListCommands.ResumeLayout()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub
#End Region

#Region "UI - Gamelist"
    Friend Sub GameList_Refresh()
        SSMGameList.Load(My.Settings.PCSX2_PathSState, My.Settings.SStatesMan_PathStored, My.Settings.PCSX2_PathSnaps, My.Settings.SStatesMan_PathIso)

        RemoveHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        RemoveHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.BeginUpdate()

        Me.GameList_AddGames()

        AddHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        AddHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.EndUpdate()

        Me.FileList_Refresh()
    End Sub

    Private Sub GameList_AddGames()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.GameList_IndexChecked()
        Me.lvwGamesList.Items.Clear()

        Dim tmpLvwItems As New List(Of ListViewItem)

        For Each tmpGameListItem As KeyValuePair(Of String, mdlFileList.GamesList.GameListItem) In SSMGameList.Games
            currentGameInfo = PCSX2GameDb.GetGameInfo(tmpGameListItem.Key)

            'Creating the listviewitem
            Dim newLvwItem As New ListViewItem With {.Text = currentGameInfo.Name, .Name = currentGameInfo.Serial}
            newLvwItem.SubItems.AddRange({currentGameInfo.Serial, currentGameInfo.Region})
            'Calculating savestates count and displaying size
            If tmpGameListItem.Value.GameFiles.ContainsKey(ListMode.Savestates) AndAlso _
                tmpGameListItem.Value.GameFiles(ListMode.Savestates).Where(Function(tmp) tmp.Value.Extension.Equals(My.Settings.PCSX2_SStateExt)).Count > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0}: {1:N2}MB", _
                                                      tmpGameListItem.Value.GameFiles(ListMode.Savestates).Where(Function(tmp) tmp.Value.Extension.Equals(My.Settings.PCSX2_SStateExt)).Count, _
                                                      tmpGameListItem.Value.GetFilesLenght(ListMode.Savestates, {My.Settings.PCSX2_SStateExt}) / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
            End If

            'Calculating backups count and displaying size
            If tmpGameListItem.Value.GameFiles.ContainsKey(ListMode.Savestates) AndAlso _
                tmpGameListItem.Value.GameFiles(ListMode.Savestates).Where(Function(tmp) tmp.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup)).Count > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0}: {1:N2}MB", _
                                                      tmpGameListItem.Value.GameFiles(ListMode.Savestates).Where(Function(tmp) tmp.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup)).Count, _
                                                      tmpGameListItem.Value.GetFilesLenght(ListMode.Savestates, {My.Settings.PCSX2_SStateExtBackup}) / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
            End If

            'Calculating stored savestates count and displaying size
            If tmpGameListItem.Value.GameFiles.ContainsKey(ListMode.Stored) AndAlso _
                tmpGameListItem.Value.GameFiles(ListMode.Stored).Count > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0}: {1:N2}MB", _
                                                      tmpGameListItem.Value.GameFiles(ListMode.Stored).Count, _
                                                      tmpGameListItem.Value.GetFilesLenght(ListMode.Stored) / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
            End If

            'Calculating snapshots count and displaying size
            If tmpGameListItem.Value.GameFiles.ContainsKey(ListMode.Snapshots) AndAlso _
                tmpGameListItem.Value.GameFiles(ListMode.Snapshots).Count > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0}: {1:N2}MB", _
                                                      tmpGameListItem.Value.GameFiles(ListMode.Snapshots).Count, _
                                                      tmpGameListItem.Value.GetFilesLenght(ListMode.Snapshots) / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
            End If

            'Icon
            If String.IsNullOrEmpty(tmpGameListItem.Value.GameIso) Then
                newLvwItem.ImageIndex = 7
            Else
                newLvwItem.ImageIndex = 8
            End If

            'If it was previously checked/selected the check/select it again
            If Me.checkedGames.Contains(currentGameInfo.Serial) Then
                If Me.checkedGames.Count = 1 Then
                    newLvwItem.Selected = True
                Else
                    newLvwItem.Checked = True
                End If
            End If

            'All done, the item is added
            tmpLvwItems.Add(newLvwItem)

        Next
        'Ordering by game name
        tmpLvwItems.Sort(AddressOf sortListViewItemsByName)
        'Alternating back colors
        mdlTheme.ListAlternateColors(tmpLvwItems)
        Me.lvwGamesList.Items.AddRange(tmpLvwItems.ToArray)
        'Addrange is faster than adding each item, even with begin/endupdate

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.GameListview, String.Format("Listed {0:N0} games.", Me.lvwGamesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub GameList_IndexChecked()
        'checked games are cleared
        Me.checkedGames.Clear()
        'reindexing checked games
        If Me.lvwGamesList.CheckedItems.Count > 0 Then
            For Each tmpGamesList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.CheckedItems
                Me.checkedGames.Add(tmpGamesList_ItemChecked.Name)
            Next
        ElseIf Me.lvwGamesList.SelectedItems.Count > 0 Then
            Me.checkedGames.Add(Me.lvwGamesList.SelectedItems.Item(0).Name)
        End If
    End Sub

    Private Sub cmdGameSelectAll_Click(sender As Object, e As EventArgs) Handles cmdGameSelectAll.Click
        RemoveHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        RemoveHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.BeginUpdate()

        For i = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(i).Checked = True
        Next

        AddHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        AddHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.EndUpdate()

        Me.FileList_Refresh()
    End Sub

    Private Sub cmdGameSelectNone_Click(sender As Object, e As EventArgs) Handles cmdGameSelectNone.Click
        RemoveHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        RemoveHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.BeginUpdate()

        For i = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(i).Checked = False
        Next

        AddHandler Me.lvwGamesList.ItemChecked, AddressOf Me.lvwGamesList_ItemChecked
        AddHandler Me.lvwGamesList.ItemSelectionChanged, AddressOf Me.lvwGamesList_ItemSelectionChanged
        Me.lvwGamesList.EndUpdate()

        Me.FileList_Refresh()
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        'SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.GameListview, "Checked games changed.")
        Me.FileList_Refresh()
    End Sub

    Private Sub lvwGamesList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs)
        'If (Me.lvwGamesList.CheckedItems.Count = 0) And ((Me.lvwGamesList.SelectedItems.Count > 0) Or (Me.lvwGamesList.Items.Count = 0)) Then
        If Me.lvwGamesList.CheckedItems.Count = 0 Then
            'SSMAppLog.Append(LogEventType.tInformation, eSrc.MainWindow, "GamesList", "Selected game changed.")
            'Me.List_RefreshFiles()
            Me.tmrSelectedItemChanged.Enabled = True
        End If
    End Sub

    Private Sub tmrSelectedItemChanged_Tick(sender As Object, e As EventArgs) Handles tmrSelectedItemChanged.Tick
        Me.tmrSelectedItemChanged.Enabled = False
        If Me.lvwGamesList.CheckedItems.Count = 0 Then
            'SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.GameListview, "Selected game changed.")
            Me.FileList_Refresh()
        End If
    End Sub
#End Region

#Region "UI - FileList"
    Private Sub FileList_Refresh()
        Me.GameList_IndexChecked()

        RemoveHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        RemoveHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.BeginUpdate()

        Me.FileList_AddFiles()

        AddHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        AddHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.EndUpdate()

        Me.FileList_IndexChecked()
        Me.UI_Update()
    End Sub

    Private Sub FileList_AddFiles()
        Dim sw As New Stopwatch
        sw.Start()

        'Preparation for the update
        Me.GameList_SelectedSize = 0
        Me.GameList_SelectedSizeBackup = 0
        Me.FileList_SelectedSize = 0
        Me.FileList_SelectedSizeBackup = 0

        'clear items and group, lvwSStatesList refresh in fact begins here
        Me.lvwFilesList.Items.Clear()
        Me.lvwFilesList.Groups.Clear()

        'if more than one game is checked groups are shown
        If Me.checkedGames.Count > 1 Then
            Me.lvwFilesList.ShowGroups = True
        Else
            Me.lvwFilesList.ShowGroups = False
        End If

        Dim tmpGroups As New List(Of ListViewGroup)
        Dim tmpLvwItems As New List(Of ListViewItem)

        For Each tmpSerial As String In Me.checkedGames

            Dim tmpGamesListItem As New mdlFileList.GamesList.GameListItem
            If SSMGameList.Games.TryGetValue(tmpSerial, tmpGamesListItem) Then
                'Creation of the header group
                currentGameInfo = PCSX2GameDb.GetGameInfo(tmpSerial)
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With { _
                    .Header = currentGameInfo.ToString, _
                    .HeaderAlignment = HorizontalAlignment.Left, _
                    .Name = currentGameInfo.Serial}

                If tmpGamesListItem.GameFiles.ContainsKey(Me.CurrentListMode) AndAlso tmpGamesListItem.GameFiles(Me.CurrentListMode).Count > 0 Then

                    tmpGroups.Add(tmpLvwSListGroup)

                    'Calculating checked games savestate size
                    Select Case Me.CurrentListMode
                        Case ListMode.Savestates
                            GameList_SelectedSize += tmpGamesListItem.GetFilesLenght(Me.CurrentListMode, {My.Settings.PCSX2_SStateExt})
                            GameList_SelectedSizeBackup += tmpGamesListItem.GetFilesLenght(Me.CurrentListMode, {My.Settings.PCSX2_SStateExtBackup})
                        Case ListMode.Stored, ListMode.Snapshots
                            GameList_SelectedSize += tmpGamesListItem.GetFilesLenght(Me.CurrentListMode)
                    End Select


                    Me.FileList_AddFileListItems(tmpGamesListItem.GameFiles(Me.CurrentListMode), tmpLvwSListGroup, tmpLvwItems)


                End If

            Else : SSMAppLog.Append(eType.LogError, eSrc.MainWindow, eSrcMethod.FileListview, String.Format("Game {0} was supposed to be checked but has not been found in the game list."))

            End If

        Next

        Me.lvwFilesList.Groups.AddRange(tmpGroups.ToArray)
        mdlTheme.ListAlternateColors(tmpLvwItems)
        Me.lvwFilesList.Items.AddRange(tmpLvwItems.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.FileListview, String.Format("Listed {0:N0} {1}.", Me.lvwFilesList.Items.Count, Me.CurrentListMode.ToString), sw.ElapsedTicks)
    End Sub

    Private Sub FileList_AddFileListItems(pFile As Dictionary(Of String, PCSX2File), pLvwGroup As ListViewGroup, ByRef pLwvItems As List(Of ListViewItem))

        Dim lastSStateIndex As Integer = -1
        Dim lastSStateDate As Date = Date.MinValue

        For Each tmpFile As KeyValuePair(Of String, PCSX2File) In pFile

            Dim tmpLvwItem As New System.Windows.Forms.ListViewItem With {.Text = tmpFile.Key, _
                                                                               .Group = pLvwGroup, _
                                                                               .Name = tmpFile.Key}
            tmpLvwItem.SubItems.AddRange({tmpFile.Value.Number.ToString, _
                                          tmpFile.Value.ExtraInfo, _
                                          tmpFile.Value.LastWriteTime.ToString, _
                                          String.Format("{0:N2} MB", tmpFile.Value.Length / 1024 ^ 2)})
            Select Case Me.CurrentListMode
                Case ListMode.Savestates
                    If tmpLvwItem.Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                        tmpLvwItem.ImageIndex = 1
                    Else
                        tmpLvwItem.ImageIndex = 0
                    End If
                Case ListMode.Stored
                    tmpLvwItem.ImageIndex = 0
                Case ListMode.Snapshots
                    tmpLvwItem.ImageIndex = 2
            End Select

            If checkedFiles(Me.CurrentListMode).Contains(tmpFile.Key) Then
                tmpLvwItem.Checked = True
            End If

            pLwvItems.Add(tmpLvwItem)

            If tmpFile.Value.LastWriteTime > lastSStateDate Then
                lastSStateIndex = pLwvItems.Count - 1
                lastSStateDate = tmpFile.Value.LastWriteTime
            End If
        Next

        If lastSStateIndex > -1 Then
            pLwvItems.Item(lastSStateIndex).ForeColor = mdlTheme.currentTheme.AccentColorDark
        End If

    End Sub

    Private Sub FileList_AddColumns(pListMode As ListMode)
        Dim sw As Stopwatch = Stopwatch.StartNew

        Dim tmpColumnHeaders As New List(Of ColumnHeader)
        Dim tmpColumnWidths() As Integer = {0}
        Select Case pListMode
            Case ListMode.Savestates, ListMode.Stored
                tmpColumnHeaders.AddRange({New ColumnHeader With {.Name = "SStatesCH_FileName", .Text = "Savestate file name", .Width = 240}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Slot", .Text = "Slot", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Version", .Text = "Version", .Width = 120}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Modified", .Text = "Modified", .Width = 120}, _
                                           New ColumnHeader With {.Name = "SStatesCH_Size", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                           })

                If My.Settings.frmMain_flvw_columnwidth IsNot Nothing Then
                    tmpColumnWidths = My.Settings.frmMain_flvw_columnwidth
                End If
            Case ListMode.Snapshots
                tmpColumnHeaders.AddRange({New ColumnHeader With {.Name = "SnapsCH_FileName", .Text = "Screenshot file name", .Width = 240}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Number", .Text = "Number", .TextAlign = HorizontalAlignment.Right, .Width = 40}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Resolution", .Text = "Resolution", .Width = 120}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Modified", .Text = "Modified", .Width = 120}, _
                                           New ColumnHeader With {.Name = "SnapsCH_Size", .Text = "Size", .TextAlign = HorizontalAlignment.Right, .Width = 80} _
                                           })
        End Select

        If tmpColumnWidths.Length = tmpColumnHeaders.Count Then
            For i As Integer = 0 To tmpColumnHeaders.Count - 1
                tmpColumnHeaders(i).Width = tmpColumnWidths(i)
            Next
        End If

        RemoveHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        RemoveHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.BeginUpdate()

        Me.lvwFilesList.Columns.Clear()
        Me.lvwFilesList.Columns.AddRange(tmpColumnHeaders.ToArray)

        AddHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        AddHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.EndUpdate()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.AddColumns, String.Format("Added columns to files listview for {0}.", pListMode), sw.ElapsedTicks)
    End Sub

    Private Sub FileList_IndexChecked()
        Me.FileList_SelectedSize = 0
        Me.FileList_SelectedSizeBackup = 0
        Select Case Me.CurrentListMode
            Case ListMode.Savestates, ListMode.Stored
                Me.FileList_IndexChecked2(Of Savestate)(Me.checkedFiles(Me.CurrentListMode))
            Case ListMode.Snapshots
                Me.FileList_IndexChecked2(Of Snapshot)(Me.checkedFiles(Me.CurrentListMode))
        End Select
    End Sub

    Private Sub FileList_IndexChecked2(Of T As {New, PCSX2File})(ByRef pIndex As List(Of String))
        pIndex.Clear()

        If Me.lvwFilesList.CheckedItems.Count > 0 Then
            For Each tmpCheckedItem As ListViewItem In Me.lvwFilesList.CheckedItems

                Dim tmpSerial As String = (New T With {.Name = tmpCheckedItem.Name}).GetGameSerial
                If SSMGameList.Games.ContainsKey(tmpSerial) AndAlso SSMGameList.Games(tmpSerial).GameFiles.ContainsKey(Me.CurrentListMode) Then
                    Dim tmpFile As PCSX2File = SSMGameList.Games(tmpSerial).GameFiles(Me.CurrentListMode).Item(tmpCheckedItem.Name)
                    pIndex.Add(tmpFile.Name)

                    If Me.CurrentListMode = ListMode.Savestates AndAlso tmpFile.Extension = My.Settings.PCSX2_SStateExtBackup Then
                        FileList_SelectedSizeBackup += tmpFile.Length
                    Else
                        FileList_SelectedSize += tmpFile.Length
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub cmdFileCheckAll_Click(sender As Object, e As EventArgs) Handles cmdFileCheckAll.Click
        RemoveHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        RemoveHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.FileList_IndexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        AddHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.EndUpdate()
    End Sub

    Private Sub cmdFileCheckNone_Click(sender As Object, e As EventArgs) Handles cmdFileCheckNone.Click
        RemoveHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        RemoveHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.FileList_IndexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        AddHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.EndUpdate()
    End Sub

    Private Sub cmdFileCheckInvert_Click(sender As Object, e As EventArgs) Handles cmdFileCheckInvert.Click
        RemoveHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        RemoveHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = Not (Me.lvwFilesList.Items.Item(lvwItemIndex).Checked)
        Next
        Me.FileList_IndexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        AddHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.EndUpdate()
    End Sub

    Private Sub cmdFileCheckBackup_Click(sender As Object, e As EventArgs) Handles cmdFileCheckBackup.Click
        RemoveHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        RemoveHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.BeginUpdate()

        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            If Me.lvwFilesList.Items.Item(lvwItemIndex).Name.EndsWith(My.Settings.PCSX2_SStateExtBackup) Then
                Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.FileList_IndexChecked()
        Me.UI_UpdateFileInfo()

        AddHandler Me.lvwFilesList.ItemChecked, AddressOf Me.lvwFilesList_ItemChecked
        AddHandler Me.lvwFilesList.SelectedIndexChanged, AddressOf Me.lvwFilesList_SelectedIndexChanged
        Me.lvwFilesList.EndUpdate()
    End Sub

    Private Sub lvwFilesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        'SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.FileListview, "Checked files changed.")
        Me.FileList_IndexChecked()
        Me.UI_UpdateFileInfo()
    End Sub

    Private Sub lvwFilesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwFilesList.SelectedIndexChanged
        If Me.CurrentListMode = ListMode.Snapshots Then
            If CType(sender, ListView).SelectedItems.Count = 1 Then

                Me.currentSnapshotFullname = Path.Combine(My.Settings.PCSX2_PathSnaps, Me.lvwFilesList.SelectedItems(0).Name)

                If bwLoadScreenshot.IsBusy = False Then
                    bwLoadScreenshot.RunWorkerAsync(Me.currentSnapshotFullname)
                ElseIf bwLoadScreenshot.WorkerSupportsCancellation Then
                    bwLoadScreenshot.CancelAsync()
                End If

                Me.FileList_IndexChecked()
                Me.UI_UpdateFileInfo()
            Else
                Me.imgScreenshotThumb.Image = My.Resources.Extra_ClearImage_30x20
            End If
        End If
    End Sub
#End Region

#Region "Form - TitleBar ToolBar"
    Private Sub cmdToolbarPCSX2_Click(sender As Object, e As EventArgs) Handles cmdToolbarPCSX2.Click
        Me.cmPCSX2.Show(Point.Add(CType(sender, Button).Parent.PointToScreen(CType(sender, Button).Location), New Size(0, CType(sender, Button).Size.Height)))
    End Sub

    Private Sub cmdToolbarConfig_Click(sender As Object, e As EventArgs) Handles cmdToolbarConfig.Click
        Me.cmConfig.Show(Point.Add(CType(sender, Button).Parent.PointToScreen(CType(sender, Button).Location), New Size(0, CType(sender, Button).Size.Height)))
    End Sub

    Private Sub cmdToolbarUser_Click(sender As Object, e As EventArgs) Handles cmdToolbarUser.Click
        Me.cmFolders.Show(Point.Add(CType(sender, Button).Parent.PointToScreen(CType(sender, Button).Location), New Size(0, CType(sender, Button).Size.Height)))
    End Sub
#End Region

#Region "Form - PCSX2 menu"
    Private Sub cmPCSX2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmPCSX2.Opening
        Me.cmiPCSX2BinFolderOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.PCSX2_PathBin)
        Me.cmiPCSX2IniFolderOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.PCSX2_PathInis)
        Me.cmiPCSX2Launch.Enabled = Me.cmiPCSX2BinFolderOpen.Enabled
        If Not (Me.cmiPCSX2BinFolderOpen.Enabled) Then
            Me.cmiPCSX2Play.Enabled = Me.cmiPCSX2BinFolderOpen.Enabled
        End If
    End Sub

    Private Sub cmiPCSX2Launch_Click(sender As Object, e As EventArgs) Handles cmiPCSX2Launch.Click
        frmPCSX2.IsoFilename = String.Empty
        frmPCSX2.ShowDialog(Me)
    End Sub

    Private Sub cmiPCSX2Play_Click(sender As Object, e As EventArgs) Handles cmiPCSX2Play.Click, cmdGamePlay.Click
        frmPCSX2.IsoFilename = Me.cmiPCSX2Play.ToolTipText
        frmPCSX2.ShowDialog(Me)
    End Sub

    Private Sub cmiPCSX2BinFolderOpen_Click(sender As Object, e As EventArgs) Handles cmiPCSX2BinFolderOpen.Click
        Me.SafeOpenFolder(My.Settings.PCSX2_PathBin, 1)
    End Sub

    Private Sub cmiPCSX2IniFolderOpen_Click(sender As Object, e As EventArgs) Handles cmiPCSX2IniFolderOpen.Click
        Me.SafeOpenFolder(My.Settings.PCSX2_PathInis, 1)
    End Sub

    Private Sub SafeOpenFolder(pPath As String, Optional pSettingTab As Integer = 0)
        Try
            If Directory.Exists(pPath) Then
                Diagnostics.Process.Start(pPath)
            Else
                MessageBox.Show(String.Format("The folder ""{0}"" does not exist, please reconfigure. ", pPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                frmSettings.currentTab = pSettingTab
                frmSettings.ShowDialog(Me)
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("The folder ""{0}"" is not accessible, please reconfigure. {1}", pPath, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            frmSettings.currentTab = pSettingTab
            frmSettings.ShowDialog(Me)
        End Try

    End Sub

    Private Sub cmiPCSX2GDE_Click(sender As Object, e As EventArgs) Handles cmiPCSX2GDE.Click
        If Not frmGameDbExplorer.Visible Then
            frmGameDbExplorer.Show(Me)
        Else
            frmGameDbExplorer.BringToFront()
        End If
    End Sub
#End Region

#Region "Form - User Folders Menu"
    Private Sub cmFolders_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmFolders.Opening
        Me.cmiFoldersSStatesOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.PCSX2_PathSState)
        Me.cmiFoldersSnapsOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.PCSX2_PathSnaps)
        Me.cmiFoldersStoredOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.SStatesMan_PathStored)
        Me.cmiFoldersIsoOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.SStatesMan_PathIso)
        Me.cmiFoldersCoverOpen.Enabled = mdlMain.SafeExistFolder(My.Settings.SStatesMan_PathPics)
    End Sub

    Private Sub cmiFoldersSStatesOpen_Click(sender As Object, e As EventArgs) Handles cmiFoldersSStatesOpen.Click
        Me.SafeOpenFolder(My.Settings.PCSX2_PathSState, 1)
    End Sub

    Private Sub cmiFoldersSnapsOpen_Click(sender As Object, e As EventArgs) Handles cmiFoldersSnapsOpen.Click
        Me.SafeOpenFolder(My.Settings.PCSX2_PathSnaps, 1)
    End Sub

    Private Sub cmiFoldersStoredOpen_Click(sender As Object, e As EventArgs) Handles cmiFoldersStoredOpen.Click
        Me.SafeOpenFolder(My.Settings.SStatesMan_PathStored, 0)
    End Sub

    Private Sub cmiFoldersIsoOpen_Click(sender As Object, e As EventArgs) Handles cmiFoldersIsoOpen.Click
        Me.SafeOpenFolder(My.Settings.SStatesMan_PathIso, 0)
    End Sub

    Private Sub cmiFoldersCoverOpen_Click(sender As Object, e As EventArgs) Handles cmiFoldersCoverOpen.Click
        Me.SafeOpenFolder(My.Settings.SStatesMan_PathPics, 0)
    End Sub
#End Region

#Region "Form - Config Menu"
    Private Sub cmiConfigSettings_Click(sender As Object, e As EventArgs) Handles cmiConfigSettings.Click
        frmSettings.ShowDialog(Me)
    End Sub

    Private Sub cmiConfigLog_Click(sender As Object, e As EventArgs) Handles cmiConfigLog.Click
        frmSettings.currentTab = 3
        frmSettings.ShowDialog(Me)
    End Sub

    Private Sub cmiConfigDevTools_Click(sender As Object, e As EventArgs) Handles cmiConfigDevTools.Click
        If Not frmSStateList.Visible Then
            frmSStateList.Show(Me)
        Else
            frmSStateList.BringToFront()
        End If
    End Sub

    Private Sub cmiConfigAbout_Click(sender As Object, e As EventArgs) Handles cmiConfigAbout.Click
        frmAbout.ShowDialog(Me)
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Me.GameList_Refresh()
    End Sub

    Private Sub cmdSStateDelete_Click(sender As Object, e As EventArgs) Handles cmdFilesDelete.Click
        frmDeleteForm.ShowDialog(Me)
    End Sub

    Private Sub cmdSStateReorder_Click(sender As Object, e As EventArgs) Handles cmdFilesReorder.Click
        frmReorderForm.ShowDialog(Me)
    End Sub

    Private Sub cmdSStatesLvwExpand_Click(sender As Object, e As EventArgs) Handles cmdExpandFilesList.Click
        If Me.SplitContainer1.Panel1Collapsed Then
            Me.SplitContainer1.Panel1Collapsed = False
            cmdExpandFilesList.Image = My.Resources.Icon_ExpandTop_12x12
        Else
            Me.SplitContainer1.Panel1Collapsed = True
            cmdExpandFilesList.Image = My.Resources.Icon_ExpandBottom_12x12

            Me.cmdGameSelectAll_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tmrSStatesListRefresh_Tick(sender As Object, e As EventArgs) Handles tmrSStatesListRefresh.Tick
        If My.Settings.SStatesMan_SStatesListAutoRefresh Then   'Setting check
            If Directory.Exists(My.Settings.PCSX2_PathSState) And _
                Not frmDeleteForm.Visible And _
                Not frmSettings.Visible And _
                Not (Me.WindowState = FormWindowState.Minimized) Then   'Directory and windows check

                If Not (Directory.GetLastWriteTime(My.Settings.PCSX2_PathSState) = SSMGameList.FoldersLastWrite(ListMode.Savestates)) Then 'Different time

                    SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Timer, "Scheduled lists refresh.")

                    Me.GameList_Refresh()

                End If
            End If
        Else
            Me.tmrSStatesListRefresh.Enabled = False
        End If
    End Sub
#End Region

#Region "Form - Tabs"
    'This common event is fired AFTER the other specific events.
    Private Sub optTabHeader_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader0.CheckedChanged, optTabHeader1.CheckedChanged, optTabHeader2.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to know 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.optTabHeader0.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader1.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader2.FlatAppearance.MouseDownBackColor = Color.White
                CType(sender, RadioButton).FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

                'Me.UI_SwitchMode(CType(CType(sender, RadioButton).Tag, ListMode))
            End If
        End If
    End Sub

    Private Sub optTabHeader0_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader0.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to know 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.UI_SwitchMode(ListMode.Savestates)
            End If
        End If
    End Sub

    Private Sub optTabHeader1_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader1.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to know 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.UI_SwitchMode(ListMode.Stored)
            End If
        End If
    End Sub

    Private Sub optTabHeader2_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader2.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to know 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.UI_SwitchMode(ListMode.Snapshots)
            End If
        End If
    End Sub

#End Region

#Region "Form - Cover image"
    Private Sub imgCover_MouseClick(sender As Object, e As MouseEventArgs) Handles imgCover.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim sw As Stopwatch = Stopwatch.StartNew

            'Move and resize the cover image

            Me.tlpGameList.SuspendLayout()
            Me.imgCover.SuspendLayout()
            Me.lvwGamesList.SuspendLayout()
            Me.lblGameList_Title.SuspendLayout()
            Me.lblGameList_Region.SuspendLayout()

            If My.Settings.frmMain_CoverExpanded Then
                Me.tlpGameList.SetRowSpan(Me.imgCover, 2)
                Me.tlpGameList.SetColumnSpan(Me.imgCover, 1)
                Me.tlpGameList.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 1))
                Me.tlpGameList.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(0, 0))
                Me.tlpGameList.SetColumnSpan(Me.lvwGamesList, 9)
            Else
                Me.tlpGameList.SetColumnSpan(Me.lvwGamesList, 7)
                Me.tlpGameList.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(2, 0))
                Me.tlpGameList.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 0))
                Me.tlpGameList.SetColumnSpan(Me.imgCover, 2)
                Me.tlpGameList.SetRowSpan(Me.imgCover, 3)
            End If
            Me.lblGameList_Title.Visible = Not (Me.lblGameList_Title.Visible)
            Me.lblGameList_Region.Visible = Not (Me.lblGameList_Region.Visible)

            My.Settings.frmMain_CoverExpanded = Not (My.Settings.frmMain_CoverExpanded)

            Me.UI_UpdateGameInfo()

            Me.lblGameList_Region.ResumeLayout()
            Me.lblGameList_Title.ResumeLayout()
            Me.lvwGamesList.ResumeLayout()
            Me.imgCover.ResumeLayout()
            Me.tlpGameList.ResumeLayout()

            sw.Start()
            SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.CoverImage, "Expanded: " & My.Settings.frmMain_CoverExpanded, sw.ElapsedTicks)
        End If
    End Sub

    Private Sub cmCover_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmCover.Opening
        If (Me.checkedGames.Count = 1) And Directory.Exists(My.Settings.SStatesMan_PathPics) Then
            If Not (Me.checkedGames(0).ToLower = "screenshots") Then
                'If screenshot "game" is selected, then disable the add cover menu item
                Me.cmiCoverAdd.Enabled = True
            Else
                Me.cmiCoverAdd.Enabled = False
            End If
        Else
            Me.cmiCoverAdd.Enabled = False
        End If
    End Sub

    Private Sub cmiCoverAdd_Click(sender As Object, e As EventArgs) Handles cmiCoverAdd.Click
        Using openDialog As New OpenFileDialog
            With openDialog
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".jpg"
                .Filter = "JPEG image file|*.jpg;*.jpeg;*.jpe|PNG image file|*.png|BMP image file|*.bmp"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                .ValidateNames = True
            End With
            If openDialog.ShowDialog(Me) = DialogResult.OK Then
                Try
                    Dim tmpImage As Image = Image.FromFile(openDialog.FileName)
                    tmpImage = mdlCoverCache.ResizeCover(tmpImage, CoverThumb_SizeLarge)
                    tmpImage.Save(Path.Combine(My.Settings.SStatesMan_PathPics, SSMGameList.Games(Me.checkedGames(0)).GetCoverFileName(Me.checkedGames(0)) & ".jpg"), Imaging.ImageFormat.Jpeg)
                    SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.CoverImage, "Converted the file """ & openDialog.FileName & """ for " & Me.checkedGames(0) & ".")
                    Me.UI_UpdateGameInfo()
                Catch ex As Exception
                    MessageBox.Show("An error has occurred while trying to convert the specified file: " & openDialog.FileName & "." & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    SSMAppLog.Append(eType.LogError, eSrc.MainWindow, eSrcMethod.CoverImage, "Conversion of the file """ & openDialog.FileName & """ failed. " & ex.Message)
                End Try
            End If
        End Using

    End Sub

    Private Sub cmiCoverOpenPicsFolder_Click(sender As Object, e As EventArgs) Handles cmiCoverOpenPicsFolder.Click
        SafeOpenFolder(My.Settings.SStatesMan_PathPics)
    End Sub
#End Region

#Region "Theme"
    Private Sub optTabHeader_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optTabHeader0.Paint, optTabHeader1.Paint, optTabHeader2.Paint
        If CType(sender, RadioButton).Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, RadioButton).Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, CType(sender, RadioButton).Height)
            e.Graphics.DrawLine(Pens.DimGray, CType(sender, RadioButton).Width - 1, 0, CType(sender, RadioButton).Width - 1, CType(sender, RadioButton).Height)
        End If
    End Sub

    Private Sub SplitContainer1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Paint
        e.Graphics.DrawLine(Pens.DimGray, 0, Me.SplitContainer1.SplitterDistance + 1, Me.SplitContainer1.Width, Me.SplitContainer1.SplitterDistance + 1)
    End Sub

    'Private Sub frmMain_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    '    If Me.Width > 8 And Me.Height > 8 Then
    '        e.Graphics.DrawRectangle(Pens.DimGray, 0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
    '    End If
    'End Sub
#End Region

#Region "Snapshot load async"
    Private Sub bwLoadScreenshot_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwLoadScreenshot.DoWork
        If e.Cancel Then
            Exit Sub
        Else
            Dim tmpSnapshotFullPath As String = Path.Combine(My.Settings.PCSX2_PathSnaps, e.Argument.ToString)
            Dim ResultImage As Image
            If File.Exists(tmpSnapshotFullPath) Then
                Try

                    Dim tmpBuff(4096) As Byte
                    Using tmpStreamReader As New FileStream(tmpSnapshotFullPath, FileMode.Open, FileAccess.Read, FileShare.Read), tmpMemoryStream As New MemoryStream()


                        Do
                            If e.Cancel Then
                                Exit Sub
                            Else
                                tmpStreamReader.Read(tmpBuff, 0, tmpBuff.Length)
                                tmpMemoryStream.Write(tmpBuff, 0, tmpBuff.Length)
                            End If
                        Loop Until tmpStreamReader.Position >= tmpStreamReader.Length
                        ResultImage = Image.FromStream(tmpMemoryStream)
                    End Using
                Catch ex As Exception
                    ResultImage = My.Resources.Extra_ClearImage_30x20
                End Try
            Else
                ResultImage = My.Resources.Extra_ClearImage_30x20
            End If

            e.Result = New Object() {ResultImage, tmpSnapshotFullPath}
        End If
    End Sub

    Private Sub bwLoadScreenshot_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoadScreenshot.RunWorkerCompleted
        Dim ConvertedResults() As Object = CType(e.Result, Object())
        If Not (e.Cancelled) Then
            Me.imgScreenshotThumb.Image = CType(ConvertedResults(0), Image)
        End If
        If (CType(ConvertedResults(1), String) <> Me.currentSnapshotFullname) AndAlso Not bwLoadScreenshot.IsBusy Then
            bwLoadScreenshot.RunWorkerAsync(Me.currentSnapshotFullname)
        End If
    End Sub
#End Region
End Class
