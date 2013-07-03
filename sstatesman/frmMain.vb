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

Public Class frmMain
    Dim lastWindowState As FormWindowState
    Friend Enum ListMode
        'Iso
        Savestates
        Stored
        Snapshots
    End Enum
    Friend WindowListMode As ListMode = ListMode.Savestates

    'Main window checked objects list
    Public checkedGames As New List(Of String)
    Public checkedSavestates As New List(Of String)
    Public checkedSnapshots As New List(Of String)

    'To avoid refreshing the lists when an operation is running, set by UI_Enabled
    Dim ListsAreRefreshed As Boolean = False

    'Stores the current game information displayed in the game information section
    Dim currentGameInfo As New GameInfo

    'Current size in bytes of the selected items
    Dim lvwGames_SelectedSizeSStates As Long = 0
    Dim lvwGames_SelectedSizeBackup As Long = 0
    Dim lvwGames_SelectedSizeStored As Long = 0
    Dim lvwGames_SelectedSizeSnaps As Long = 0
    Dim lvwFiles_SelectedSizeSStates As Long = 0
    Dim lvwFiles_SelectedSizeBackup As Long = 0
    'Dim lvwFiles_SelectedSizeStored As Long = 0
    Dim lvwFiles_SelectedSizeSnaps As Long = 0

    'Default sizes for the cover image
    Friend ReadOnly imgCover_SizeExpanded As New Size(120, 170)
    Friend ReadOnly imgCover_SizeReduced As New Size(32, 46)

    Private Sub UI_SwitchMode(ByVal pListMode As ListMode)
        Me.UI_Enable(False)

        Select Case pListMode
            Case ListMode.Savestates
                Me.lblSStateListCheck.Text = "check savestates:"
                Me.cmdFilesCheckBackup.Visible = True
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = True
                Me.txtSizeBackup.Visible = True
            Case ListMode.Stored
                Me.lblSStateListCheck.Text = "check savestates:"
                Me.cmdFilesCheckBackup.Visible = False
                Me.lblSize.Text = "savestates size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
            Case ListMode.Snapshots
                Me.lblSStateListCheck.Text = "check screnshots:"
                Me.cmdFilesCheckBackup.Visible = False
                Me.lblSize.Text = "screenshots size"
                Me.lblSizeBackup.Visible = False
                Me.txtSizeBackup.Visible = False
        End Select

        Me.WindowListMode = pListMode
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.ListMode, String.Format("Switched to {0}.", pListMode.ToString))

        Me.lvwFilesList_AddColumns(pListMode)
        Me.List_RefreshFiles()
        Me.UI_Enable(True)
    End Sub

    Friend Sub List_RefreshAll()
        Me.UI_Enable(False, True)

        SSMGameList.LoadAll(My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps)

        Me.lvwGamesList_AddGames()
        Me.List_RefreshFiles()
        Me.UI_Enable(True, True)
    End Sub

    Private Sub List_RefreshFiles()

        Me.GamesList_IndexCheckedGames()
        Select Case Me.WindowListMode
            Case ListMode.Savestates
                Me.lvwFilesList_AddSavestates()
            Case ListMode.Snapshots
                Me.lvwFilesList_AddSnapshots()
        End Select
        Me.lvwFileList_IndexChecked()
        Me.UI_Update()
    End Sub

#Region "Form - General"
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "Form load start.")
        '==========================
        'General loading procedures
        '==========================

        'Getting DPI information
        'It has to be here because I need a form
        Using gfx As Graphics = Me.CreateGraphics()
            DPIxScale = gfx.DpiX / 96
            DPIyScale = gfx.DpiY / 96
        End Using

        If My.Settings.SStatesMan_FirstRun = True Then
            'Executes the FirstRun procedure (detects PCSX2 folders configuration)
            FirstRun()
        Else
            'Checks if there are some invalid settings
            PCSX2_PathAll_Check()
        End If

        If My.Settings.SStatesMan_SettingFail Then
            frmSettings.ShowDialog(Me)
        End If

        mdlTheme.LoadTheme(My.Settings.SStatesMan_Theme)

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "1/5 General loading procedures done.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '==================
        'Window preparation
        '==================

        '-----
        'Theme
        '-----
        Me.applyTheme()

        'Add version information to the main window
        Me.lblWindowVersion.Text = String.Concat(Me.lblWindowVersion.Text, _
                                                 My.Application.Info.Version.ToString, " ", _
                                                 My.Settings.SStatesMan_Channel)


        'Checked state icons
        Me.lvwGamesList.StateImageList = imlLvwCheckboxes       'Assigning the imagelist to the Games listview
        Me.lvwFilesList.StateImageList = imlLvwCheckboxes       'Assigning the imagelist to the Savestates listview

        'Savestates, backup, and screenshot icons
        Me.lvwFilesList.SmallImageList = imlLvwItemIcons        'Assigning the imagelist to the Savestates listview

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "2/5 Main window preparation done.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '---------------
        'Window settings
        '---------------

        'Main window location, size and state
        Me.Location = My.Settings.frmMain_WindowPosition
        Me.Size = My.Settings.frmMain_WindowSize
        If My.Settings.frmMain_WindowState = FormWindowState.Minimized Then
            My.Settings.frmMain_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmMain_WindowState
        Me.lastWindowState = Me.WindowState
        'Splitter distance
        Me.SplitContainer1.SplitterDistance = My.Settings.frmMain_SplitterDistance


        Me.UI_Enable(False, True)

        'Games list columns size
        If My.Settings.frmMain_glvw_columnwidth IsNot Nothing Then
            If My.Settings.frmMain_glvw_columnwidth.Length = Me.lvwGamesList.Columns.Count Then
                For i As Integer = 0 To Me.lvwGamesList.Columns.Count - 1
                    Me.lvwGamesList.Columns(i).Width = My.Settings.frmMain_glvw_columnwidth(i)
                Next
            End If
        End If

        'Savestate list column size
        If My.Settings.frmMain_slvw_columnwidth IsNot Nothing Then
            If My.Settings.frmMain_slvw_columnwidth.Length = Me.lvwFilesList.Columns.Count Then
                For i As Integer = 0 To Me.lvwFilesList.Columns.Count - 1
                    Me.lvwFilesList.Columns(i).Width = My.Settings.frmMain_slvw_columnwidth(i)
                Next
            End If
        End If

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "3/5 Main window saved sizes applied.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '==============
        'Loading things
        '==============

        'Loading the Game database (from PCSX2 directory)
        PCSX2GameDb.Load(Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename))

        'Refreshing the games list
        SSMGameList.LoadAll(My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps)

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "4/5 GameDB and Gamelist loaded.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks
        '===============================
        'Post file load form preparation
        '===============================
        Me.lvwGamesList_AddGames()
        Me.UI_Enable(True, True)
        Me.UI_SwitchMode(ListMode.Savestates)

        'Cover image state
        If My.Settings.frmMain_CoverExpanded Then
            My.Settings.frmMain_CoverExpanded = Not (My.Settings.frmMain_CoverExpanded)
            Me.imgCover_MouseClick(Me, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
        End If

        'Timer auto refresh
        Me.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh

        If My.Settings.SStatesMan_SStatesListShowOnly Then
            Me.cmdSStatesLvwExpand_Click(Nothing, Nothing)
        End If

        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "5/5 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Load, "All done.", sw.ElapsedTicks)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '======================
        'Saving window settings
        '======================

        'State, location, and size
        My.Settings.frmMain_WindowState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            'Location and size saved only when windowstate is normal
            My.Settings.frmMain_WindowPosition = Me.Location
            My.Settings.frmMain_WindowSize = Me.Size
        End If
        'Splitter distance
        My.Settings.frmMain_SplitterDistance = Me.SplitContainer1.SplitterDistance

        'Column widths
        My.Settings.frmMain_glvw_columnwidth = New Integer() {Me.GamesLvw_GameTitle.Width, Me.GameLvw_GameSerial.Width, Me.GameLvw_GameRegion.Width, _
                                                              Me.GameLvw_SStatesInfo.Width, Me.GameLvw_BackupInfo.Width, Me.GameLvw_SnapsInfo.Width}
        'My.Settings.frmMain_slvw_columnwidth = New Integer() {Me.SStatesLvw_FileName.Width, Me.SStatesLvw_Slot.Width, Me.SStatesLvw_Version.Width, _
        '                                                      Me.SStatesLvw_DateLastWrite.Width, Me.SStatesLvw_Size.Width}
    End Sub

    ''' <summary>Handles the gamelist and savestate list beginupdate and endupdate methods</summary>
    ''' <param name="pSwitch">True to end the update, False to begin the update</param>
    ''' <remarks></remarks>
    Private Sub UI_Enable(ByVal pSwitch As Boolean, Optional ByVal pGamesList_included As Boolean = False)
        Me.ListsAreRefreshed = Not (pSwitch)
        If pSwitch Then
            If pGamesList_included Then
                Me.lvwGamesList.EndUpdate()
            End If
            Me.lvwFilesList.EndUpdate()
        Else
            If pGamesList_included Then
                Me.lvwGamesList.BeginUpdate()
            End If
            Me.lvwFilesList.BeginUpdate()
        End If
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Enable, pSwitch.ToString)
    End Sub

    ''' <summary>Updates the UI status, game info and savestate info</summary>
    Private Sub UI_Update()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Status update start.")
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.UI_UpdateGameInfo()
        Me.UI_UpdateFileInfo()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Status update done.", sw.ElapsedTicks)
    End Sub

    ''' <summary>Updates the UI game info: title, region, image cover, etc.</summary>
    Private Sub UI_UpdateGameInfo()
        Dim sw As Stopwatch = Stopwatch.StartNew

        If SSMGameList.Games.Count > 0 And checkedGames.Count > 0 Then
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

            If SSMGameList.Games.Count = checkedGames.Count Then
                'All the games are checked
                Me.cmdGameSelectAll.Enabled = False
            Else
                Me.cmdGameSelectAll.Enabled = True
            End If

            If checkedGames.Count > 1 Then
                '--------------------------
                'More than one game checked
                '--------------------------

                'Game info
                Me.txtGameList_Title.Text = "(multiple games selected)"
                Me.txtGameList_Serial.Text = ""
                Me.txtGameList_Region.Text = ""
                Me.txtGameList_Compat.Text = ""
                Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
                Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

                'Cover image
                Me.imgCover.SizeMode = PictureBoxSizeMode.Normal

                If My.Settings.frmMain_CoverExpanded Then
                    Me.imgCover.Image = FetchCover(checkedGames, My.Settings.SStatesMan_PathPics, _
                                                 CInt(imgCover_SizeExpanded.Width * DPIxScale), _
                                                 CInt(imgCover_SizeExpanded.Height * DPIyScale), _
                                                 My.Settings.frmMain_CoverExpanded)
                    Me.imgCover.Width = CInt(imgCover_SizeExpanded.Width * DPIxScale) + 2
                    Me.imgCover.Height = CInt(imgCover_SizeExpanded.Height * DPIxScale) + 2
                    Me.imgCover.Dock = DockStyle.Bottom
                Else
                    Me.imgCover.Image = FetchCover(checkedGames, My.Settings.SStatesMan_PathPics, _
                                                 CInt(imgCover_SizeReduced.Height * DPIxScale), _
                                                 CInt(imgCover_SizeReduced.Height * DPIyScale), _
                                                 My.Settings.frmMain_CoverExpanded)
                    Me.imgCover.Width = CInt(imgCover_SizeReduced.Height * DPIyScale) + 2
                    Me.imgCover.Height = CInt(imgCover_SizeReduced.Height * DPIyScale) + 2
                    Me.imgCover.Dock = DockStyle.None
                End If

            Else
                '---------------------------------
                'No more than one game is selected/checked
                '---------------------------------

                'Game info
                Me.txtGameList_Title.Text = currentGameInfo.Name
                Me.txtGameList_Serial.Text = currentGameInfo.Serial
                Me.txtGameList_Region.Text = currentGameInfo.Region
                Me.txtGameList_Compat.Text = currentGameInfo.CompatToText
                Me.txtGameList_Compat.BackColor = currentGameInfo.CompatToColor(Color.WhiteSmoke)
                Me.imgFlag.Image = mdlMain.assignFlag(currentGameInfo.Region, currentGameInfo.Serial)
                Me.imgFlag.Size = New Size(CInt(Me.imgFlag.Image.PhysicalDimension.Width * DPIxScale) + 2, _
                                           CInt(Me.imgFlag.Image.PhysicalDimension.Height * DPIyScale) + 2)

                'Cover image
                Me.imgCover.SizeMode = PictureBoxSizeMode.StretchImage

                If My.Settings.frmMain_CoverExpanded Then
                    Me.imgCover.Image = mdlCoverCache.FetchCover(currentGameInfo.Serial, My.Settings.SStatesMan_PathPics, My.Settings.frmMain_CoverExpanded)
                    Me.imgCover.Width = CInt(imgCover_SizeExpanded.Width * DPIxScale) + 2
                    Me.imgCover.Height = CInt((imgCover_SizeExpanded.Width * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.PhysicalDimension.Width) * DPIyScale) + 2
                    Me.imgCover.Dock = DockStyle.Bottom
                Else
                    Me.imgCover.Image = mdlCoverCache.FetchCover(currentGameInfo.Serial, My.Settings.SStatesMan_PathPics, My.Settings.frmMain_CoverExpanded)
                    Me.imgCover.Width = CInt((imgCover_SizeReduced.Height * Me.imgCover.Image.PhysicalDimension.Width / Me.imgCover.Image.PhysicalDimension.Height) * DPIxScale) + 2
                    If Me.imgCover.Image.PhysicalDimension.Width < Me.imgCover.Image.PhysicalDimension.Height Then
                        Me.imgCover.Height = CInt(imgCover_SizeReduced.Height * DPIxScale) + 2
                    Else
                        Me.imgCover.Height = CInt((imgCover_SizeReduced.Height * Me.imgCover.Image.PhysicalDimension.Height / Me.imgCover.Image.PhysicalDimension.Width) * DPIyScale) + 2
                    End If
                    Me.imgCover.Dock = DockStyle.None
                End If
            End If

        Else
            '=========================
            'No games selected/checked
            '=========================

            'Game info cleared
            Me.txtGameList_Title.Text = ""
            Me.txtGameList_Serial.Text = ""
            Me.txtGameList_Region.Text = ""
            Me.txtGameList_Compat.Text = ""
            Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
            Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

            'Cover image
            Me.imgCover.Image = My.Resources.Flag_0Null_30x20
            Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
            If My.Settings.frmMain_CoverExpanded Then
                Me.imgCover.Width = CInt(imgCover_SizeExpanded.Width * DPIxScale) + 2
                Me.imgCover.Height = CInt(imgCover_SizeExpanded.Height * DPIxScale) + 2
                Me.imgCover.Dock = DockStyle.Bottom
            Else
                Me.imgCover.Width = CInt(imgCover_SizeReduced.Width * DPIyScale) + 2
                Me.imgCover.Height = CInt(imgCover_SizeReduced.Height * DPIyScale) + 2
                Me.imgCover.Dock = DockStyle.None
            End If

            Me.cmdGameSelectNone.Enabled = False

            If SSMGameList.Games.Count = 0 Then
                '================
                'No games in list
                '================
                Me.cmdGameSelectAll.Enabled = False
                Me.cmdGameSelectInvert.Enabled = False
            Else
                Me.cmdGameSelectAll.Enabled = True
                Me.cmdGameSelectInvert.Enabled = True
            End If
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Updated game info.", sw.ElapsedTicks)
    End Sub

    ''' <summary>Updates the UI savestate info: items selected, size.</summary>
    Private Sub UI_UpdateFileInfo()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.txtSelected.Text = System.String.Format("{0:N0} | {1:N0} files", Me.lvwFilesList.CheckedItems.Count, Me.lvwFilesList.Items.Count)
        Select Case Me.WindowListMode
            Case ListMode.Savestates
                Me.txtSize.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.lvwFiles_SelectedSizeSStates / 1024 ^ 2, Me.lvwGames_SelectedSizeSStates / 1024 ^ 2)
                Me.txtSizeBackup.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.lvwFiles_SelectedSizeBackup / 1024 ^ 2, Me.lvwGames_SelectedSizeBackup / 1024 ^ 2)
            Case ListMode.Snapshots
                Me.txtSize.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.lvwFiles_SelectedSizeSnaps / 1024 ^ 2, Me.lvwGames_SelectedSizeSnaps / 1024 ^ 2)
        End Select

        If Me.lvwFilesList.Items.Count = 0 Then
            '=====================
            'No savestates in list
            '=====================
            Me.cmdFilesCheckAll.Enabled = False
            Me.cmdFilesCheckInvert.Enabled = False
            Me.cmdFilesCheckNone.Enabled = False
            Me.cmdFilesCheckBackup.Enabled = False
            Me.cmdFilesDelete.Enabled = False
            Me.cmdFilesReorder.Enabled = False
        Else
            '======================
            'Savestates are present
            '======================
            Me.cmdFilesCheckInvert.Enabled = True
            Me.cmdFilesCheckBackup.Enabled = True

            If Me.lvwGamesList.CheckedItems.Count > 1 Then
                'More than one game is checked
                Me.cmdFilesReorder.Enabled = False
            Else
                'A single game is checked/selected
                Me.cmdFilesReorder.Enabled = True
            End If

            If Me.lvwFilesList.CheckedItems.Count > 0 Then
                'At least one savestate is checked
                Me.cmdFilesCheckNone.Enabled = True
                Me.cmdFilesDelete.Enabled = True

                If Me.lvwFilesList.Items.Count = Me.lvwFilesList.CheckedItems.Count Then
                    'All savestates are checked
                    Me.cmdFilesCheckAll.Enabled = False
                Else
                    Me.cmdFilesCheckAll.Enabled = True
                End If

            Else
                'No savestates are checked
                Me.cmdFilesCheckNone.Enabled = False
                Me.cmdFilesCheckAll.Enabled = True
                Me.cmdFilesDelete.Enabled = False
            End If
        End If

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.UI_Update, "Updated file info.", sw.ElapsedTicks)
    End Sub

    Private Sub tmrSStatesListRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSStatesListRefresh.Tick
        If My.Settings.SStatesMan_SStatesListAutoRefresh Then   'Setting check
            If Directory.Exists(My.Settings.PCSX2_PathSState) And _
                Not frmDeleteForm.Visible And _
                Not frmSettings.Visible And _
                Not (Me.WindowState = FormWindowState.Minimized) Then   'Directory and windows check

                If Not (Directory.GetLastWriteTime(My.Settings.PCSX2_PathSState) = SSMGameList.SStatesFolder_LastModified) Then 'Different time

                    SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.Timer, "Scheduled lists refresh.")

                    Me.List_RefreshAll()

                End If
            End If
        Else
            Me.tmrSStatesListRefresh.Enabled = False
        End If
    End Sub
#End Region

#Region "Form - Windowstate command buttons"
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

    Private Sub cmdWindowMinimize_MouseEnter(sender As Object, e As EventArgs) Handles cmdWindowMinimize.MouseEnter
        Me.cmdWindowMinimize.Image = My.Resources.Window_ButtonMinimizeW_12x12
    End Sub

    Private Sub cmdWindowClose_MouseLeave(sender As Object, e As EventArgs) Handles cmdWindowMinimize.MouseLeave
        Me.cmdWindowMinimize.Image = My.Resources.Window_ButtonMinimize_12x12
    End Sub

    Private Sub cmdWindowMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmdWindowMaximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub cmdWindowClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()    'Needed for firing the FormClosing event, wich saves some settings.
        'End
    End Sub

    Private Sub frmMain_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
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
            Me.UI_Enable(True, True)
        End If
    End Sub
#End Region

#Region "Form - Window dialogs buttons"
    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        frmAbout.ShowDialog(Me)
    End Sub

    Private Sub cmdSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSettings.Click
        frmSettings.ShowDialog(Me)
    End Sub

    Private Sub cmdTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTools.Click
        Me.cmPCSX2.Show(Point.Add(Me.cmdTools.PointToScreen(Me.cmdTools.Location), New Size(0, Me.cmdTools.Size.Height)))
    End Sub
#End Region

#Region "Form - Commands"
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Me.List_RefreshAll()
    End Sub

    Private Sub cmdSStateDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdFilesDelete.Click
        frmDeleteForm.ShowDialog(Me)
    End Sub

    Private Sub cmdSStateReorder_Click(sender As Object, e As EventArgs) Handles cmdFilesReorder.Click
        frmReorderForm.ShowDialog(Me)
    End Sub

    Private Sub cmdSStatesLvwExpand_Click(sender As System.Object, e As System.EventArgs) Handles cmdExpandFilesList.Click
        If Me.SplitContainer1.Panel1Collapsed Then
            Me.SplitContainer1.Panel1Collapsed = False
            Me.cmdExpandFilesList.Image = My.Resources.Icon_ExpandTop_12x12
        Else
            Me.SplitContainer1.Panel1Collapsed = True
            Me.cmdExpandFilesList.Image = My.Resources.Icon_ExpandBottom_12x12

            Me.cmdGameSelectAll_Click(Nothing, Nothing)
        End If
    End Sub
#End Region

#Region "UI - Cover image"
    Private Sub imgCover_MouseClick(sender As System.Object, e As MouseEventArgs) Handles imgCover.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then

            'Move and resize the cover image

            Me.TableLayoutPanel3.SuspendLayout()
            Me.imgCover.SuspendLayout()
            Me.lvwGamesList.SuspendLayout()
            Me.lblGameList_Title.SuspendLayout()
            Me.lblGameList_Region.SuspendLayout()

            If My.Settings.frmMain_CoverExpanded Then
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 1)
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 1))
                Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(0, 0))
                Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 9)
            Else
                Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 7)
                Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(2, 0))
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 0))
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 3)
            End If
            Me.lblGameList_Title.Visible = Not (Me.lblGameList_Title.Visible)
            Me.lblGameList_Region.Visible = Not (Me.lblGameList_Region.Visible)

            My.Settings.frmMain_CoverExpanded = Not (My.Settings.frmMain_CoverExpanded)

            Me.UI_UpdateGameInfo()

            Me.lblGameList_Region.ResumeLayout()
            Me.lblGameList_Title.ResumeLayout()
            Me.lvwGamesList.ResumeLayout()
            Me.imgCover.ResumeLayout()
            Me.TableLayoutPanel3.ResumeLayout()

        End If
    End Sub

    Private Sub cmCover_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmCover.Opening
        If (Me.checkedGames.Count() = 1) And Directory.Exists(My.Settings.SStatesMan_PathPics) Then
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
                    tmpImage = mdlCoverCache.ResizeCover(tmpImage, CoverThumb_SizeLarge.Width, CoverThumb_SizeLarge.Height)
                    tmpImage.Save(Path.Combine(My.Settings.SStatesMan_PathPics, mdlMain.TrimBadPathChars(Me.checkedGames(0)) & ".jpg"), Imaging.ImageFormat.Jpeg)
                    Me.UI_UpdateGameInfo()
                Catch ex As Exception
                    MessageBox.Show("An error has occurred while trying to convert the specified file. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using

    End Sub

    Private Sub cmiCoverOpenPicsFolder_Click(sender As Object, e As EventArgs) Handles cmiCoverOpenPicsFolder.Click
        If Directory.Exists(My.Settings.SStatesMan_PathPics) Then
            Diagnostics.Process.Start(My.Settings.SStatesMan_PathPics)
        Else
            MessageBox.Show("The specified folder does not exist. " & My.Settings.SStatesMan_PathPics & vbCrLf & "Please use the Settings dialog to set a valid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            frmSettings.ShowDialog(Me)
        End If
    End Sub

#End Region

#Region "UI - Gamelist management"
    Private Sub lvwGamesList_AddGames()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.GamesList_IndexCheckedGames()
        Me.lvwGamesList.Items.Clear()
        'Me.lvwSStatesList.Items.Clear()
        'Me.lvwSStatesList.Groups.Clear()

        Dim tmpLvwItems As New List(Of ListViewItem)

        For Each tmpGameListItem As KeyValuePair(Of String, mdlFileList.GamesList_Item) In SSMGameList.Games
            currentGameInfo = PCSX2GameDb.Extract(tmpGameListItem.Key)

            'Creating the listviewitem
            Dim newLvwItem As New ListViewItem With {.Text = currentGameInfo.Name, .Name = currentGameInfo.Serial}
            newLvwItem.SubItems.AddRange({currentGameInfo.Serial, currentGameInfo.Region})
            'Calculating savestates count and displaying size
            If tmpGameListItem.Value.Savestates_SizeTot > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0} × {1:N2} MB", _
                                                      tmpGameListItem.Value.Savestates.Where(Function(extfilter) extfilter.Value.Extension.Equals(My.Settings.PCSX2_SStateExt)).Count, _
                                                      tmpGameListItem.Value.Savestates_SizeTot / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
            End If

            'Calculating backups count and displaying size
            If tmpGameListItem.Value.SavestatesBackup_SizeTot > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0} × {1:N2} MB", _
                                                      tmpGameListItem.Value.Savestates.Where(Function(extfilter) extfilter.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup)).Count, _
                                                      tmpGameListItem.Value.SavestatesBackup_SizeTot / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
            End If

            'Calculating snapshots count and displaying size
            If tmpGameListItem.Value.Snapshots_SizeTot > 0 Then
                newLvwItem.SubItems.Add(String.Format("{0:N0} × {1:N2} MB", _
                                                      tmpGameListItem.Value.Snapshots.Count, _
                                                      tmpGameListItem.Value.Snapshots_SizeTot / 1024 ^ 2))
            Else
                newLvwItem.SubItems.Add("None")
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
        'Alternating back colors
        Me.lvwGamesList.Items.AddRange(tmpLvwItems.ToArray)
        'Addrange is faster than adding each item, even with begin/endupdate
        mdlTheme.ListAlternateColors(Me.lvwGamesList)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.List, String.Format("Listed {0:N0} games.", Me.lvwGamesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub GamesList_IndexCheckedGames()
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

    Private Sub cmdGameSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectAll.Click
        Me.UI_Enable(False, True)
        For i = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(i).Checked = True
        Next
        Me.List_RefreshFiles()
        Me.UI_Enable(True, True)
    End Sub

    Private Sub cmdGameSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectNone.Click
        Me.UI_Enable(False, True)
        For i = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(i).Checked = False
        Next
        Me.List_RefreshFiles()
        Me.UI_Enable(True, True)
    End Sub

    Private Sub cmdGameSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdGameSelectInvert.Click
        Me.UI_Enable(False, True)
        For i = 0 To Me.lvwGamesList.Items.Count - 1
            If Me.lvwGamesList.Items.Item(i).Checked Then
                Me.lvwGamesList.Items.Item(i).Checked = False
            Else
                Me.lvwGamesList.Items.Item(i).Checked = True
            End If
        Next
        Me.List_RefreshFiles()
        Me.UI_Enable(True, True)
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGamesList.ItemChecked
        If Not (ListsAreRefreshed) Then
            SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.GameListview, "Checked games changed.")
            Me.UI_Enable(False)
            Me.List_RefreshFiles()
            Me.UI_Enable(True)
        End If
    End Sub

    Private Sub lvwGamesList_SelectedIndexChanged(sender As System.Object, e As ListViewItemSelectionChangedEventArgs) Handles lvwGamesList.ItemSelectionChanged
        'If (Me.lvwGamesList.CheckedItems.Count = 0) And ((Me.lvwGamesList.SelectedItems.Count > 0) Or (Me.lvwGamesList.Items.Count = 0)) Then
        If Me.lvwGamesList.CheckedItems.Count = 0 Then
            If Not (ListsAreRefreshed) Then
                'SSMAppLog.Append(LogEventType.tInformation, eSrc.MainWindow, "GamesList", "Selected game changed.")
                'Me.UI_Enable(False)
                'Me.List_RefreshFiles()
                'Me.UI_Enable(True)
                Me.tmrSelectedItemChanged.Enabled = True
            End If
        End If
    End Sub

    Private Sub tmrSelectedItemChanged_Tick(sender As Object, e As EventArgs) Handles tmrSelectedItemChanged.Tick
        Me.tmrSelectedItemChanged.Enabled = False
        If Me.lvwGamesList.CheckedItems.Count = 0 Then
            If Not (ListsAreRefreshed) Then
                SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.GameListview, "Selected game changed.")
                Me.UI_Enable(False)
                Me.List_RefreshFiles()
                Me.UI_Enable(True)
            End If
        End If
    End Sub
#End Region

#Region "UI - FilesList management"
    Private Sub lvwFilesList_AddSavestates()
        Dim sw As New Stopwatch
        sw.Start()

        'Preparation for the update
        Me.lvwGames_SelectedSizeSStates = 0
        Me.lvwGames_SelectedSizeBackup = 0
        Me.lvwFiles_SelectedSizeSStates = 0
        Me.lvwFiles_SelectedSizeBackup = 0

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
        Dim lastSStateIndex As Integer = -1
        Dim lastSStateDate As Date = Date.MinValue

        For Each tmpSerial As String In Me.checkedGames

            Dim tmpGamesListItem As New GamesList_Item
            If (SSMGameList.Games.TryGetValue(tmpSerial, tmpGamesListItem)) Then

                'Creation of the header group
                currentGameInfo = PCSX2GameDb.Extract(tmpSerial)
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With { _
                    .Header = currentGameInfo.ToString, _
                    .HeaderAlignment = HorizontalAlignment.Left, _
                    .Name = currentGameInfo.Serial}

                tmpGroups.Add(tmpLvwSListGroup)

                'Calculating checked games savestate size
                lvwGames_SelectedSizeSStates += SSMGameList.Games(currentGameInfo.Serial).Savestates_SizeTot
                lvwGames_SelectedSizeBackup += SSMGameList.Games(currentGameInfo.Serial).SavestatesBackup_SizeTot

                If (SSMGameList.Games(tmpSerial).Savestates.Values.Count > 0) Then

                    lastSStateDate = Date.MinValue

                    For Each tmpSavestate As KeyValuePair(Of String, Savestate) In SSMGameList.Games(tmpSerial).Savestates

                        Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSavestate.Key, _
                                                                                           .Group = tmpLvwSListGroup, _
                                                                                           .Name = tmpSavestate.Key}
                        tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Slot.ToString, _
                                                           tmpSavestate.Value.Version, _
                                                           tmpSavestate.Value.LastWriteTime.ToString, _
                                                           System.String.Format("{0:N2} MB", tmpSavestate.Value.Length / 1024 ^ 2)})
                        If Not (tmpSavestate.Value.isBackup) Then
                            tmpLvwSListItem.ImageIndex = 0
                        Else
                            tmpLvwSListItem.ImageIndex = 1
                        End If

                        If (checkedSavestates.Contains(tmpSavestate.Key)) Then
                            tmpLvwSListItem.Checked = True
                        End If

                        tmpLvwItems.Add(tmpLvwSListItem)

                        If (tmpSavestate.Value.LastWriteTime > lastSStateDate) Then
                            lastSStateIndex = tmpLvwItems.Count - 1
                            lastSStateDate = tmpSavestate.Value.LastWriteTime
                        End If
                    Next
                End If

            End If

            If (lastSStateIndex > -1) Then
                tmpLvwItems.Item(lastSStateIndex).SubItems(0).ForeColor = Color.FromArgb(255, 65, 74, 100)
            End If
        Next


        Me.lvwFilesList.Groups.AddRange(tmpGroups.ToArray)
        Me.lvwFilesList.Items.AddRange(tmpLvwItems.ToArray)
        mdlTheme.ListAlternateColors(Me.lvwFilesList)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.List, String.Format("Listed {0:N0} savestates.", Me.lvwFilesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub lvwFilesList_AddSnapshots()
        Dim sw As New Stopwatch
        sw.Start()

        'Preparation for the update
        Me.lvwGames_SelectedSizeSnaps = 0
        Me.lvwFiles_SelectedSizeSnaps = 0

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
        Dim lastSnapsIndex As Integer = -1
        Dim lastSnapsDate As Date = Date.MinValue

        For Each tmpSerial As String In Me.checkedGames

            Dim tmpGamesListItem As New GamesList_Item
            If (SSMGameList.Games.TryGetValue(tmpSerial, tmpGamesListItem)) Then

                'Creation of the header group
                currentGameInfo = PCSX2GameDb.Extract(tmpSerial)
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With { _
                    .Header = currentGameInfo.ToString, _
                    .HeaderAlignment = HorizontalAlignment.Left, _
                    .Name = currentGameInfo.Serial}

                tmpGroups.Add(tmpLvwSListGroup)

                'Calculating checked games snapshots size
                lvwGames_SelectedSizeSnaps += SSMGameList.Games(currentGameInfo.Serial).Snapshots_SizeTot

                If (SSMGameList.Games(tmpSerial).Snapshots.Values.Count > 0) Then

                    lastSnapsDate = Date.MinValue

                    For Each tmpSnaps As KeyValuePair(Of String, Snapshot) In SSMGameList.Games(tmpSerial).Snapshots

                        Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSnaps.Key, _
                                                                                           .Group = tmpLvwSListGroup, _
                                                                                           .Name = tmpSnaps.Key}
                        tmpLvwSListItem.SubItems.AddRange({"00", _
                                                           "Resolution", _
                                                           tmpSnaps.Value.LastWriteTime.ToString, _
                                                           System.String.Format("{0:N2} MB", tmpSnaps.Value.Length / 1024 ^ 2)})
                        tmpLvwSListItem.ImageIndex = 2

                        If (checkedSnapshots.Contains(tmpSnaps.Key)) Then
                            tmpLvwSListItem.Checked = True
                        End If

                        tmpLvwItems.Add(tmpLvwSListItem)

                        If (tmpSnaps.Value.LastWriteTime > lastSnapsDate) Then
                            lastSnapsIndex = tmpLvwItems.Count - 1
                            lastSnapsDate = tmpSnaps.Value.LastWriteTime
                        End If
                    Next
                End If

            End If

            If (lastSnapsIndex > -1) Then
                tmpLvwItems.Item(lastSnapsIndex).SubItems(0).ForeColor = Color.FromArgb(255, 65, 74, 100)
            End If
        Next


        Me.lvwFilesList.Groups.AddRange(tmpGroups.ToArray)
        Me.lvwFilesList.Items.AddRange(tmpLvwItems.ToArray)
        mdlTheme.ListAlternateColors(Me.lvwFilesList)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.List, String.Format("Listed {0:N0} snapshots.", Me.lvwFilesList.Items.Count), sw.ElapsedTicks)
    End Sub

    Private Sub lvwFilesList_AddColumns(ByVal pListMode As ListMode)
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

                If My.Settings.frmMain_slvw_columnwidth IsNot Nothing Then
                    tmpColumnWidths = My.Settings.frmMain_slvw_columnwidth
                End If
            Case ListMode.Snapshots
                tmpColumnHeaders.AddRange({New ColumnHeader With {.Name = "SnapsCH_FileName", .Text = "Snapshot file name", .Width = 240}, _
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

        Me.lvwFilesList.Columns.Clear()
        Me.lvwFilesList.Columns.AddRange(tmpColumnHeaders.ToArray)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.AddColumns, String.Format("Added columns to files listview for {0}.", pListMode), sw.ElapsedTicks)
    End Sub

    Private Sub lvwFileList_IndexChecked()
        Select Case Me.WindowListMode
            Case ListMode.Savestates
                Me.lvwFiles_SelectedSizeSStates = 0
                Me.lvwFiles_SelectedSizeBackup = 0
                checkedSavestates.Clear()

                If Me.lvwFilesList.CheckedItems.Count > 0 Then
                    For Each tmpCheckedItem As ListViewItem In Me.lvwFilesList.CheckedItems

                        Dim tmpSerial As String = Savestate.GetSerial(tmpCheckedItem.Name)
                        Dim tmpSavestate As Savestate = SSMGameList.Games(tmpSerial).Savestates(tmpCheckedItem.Name)
                        checkedSavestates.Add(tmpSavestate.Name)

                        If tmpSavestate.isBackup Then
                            lvwFiles_SelectedSizeBackup += tmpSavestate.Length
                        Else
                            lvwFiles_SelectedSizeSStates += tmpSavestate.Length
                        End If
                    Next
                End If
            Case ListMode.Snapshots
                Me.lvwFiles_SelectedSizeSnaps = 0
                checkedSnapshots.Clear()

                If Me.lvwFilesList.CheckedItems.Count > 0 Then
                    For Each tmpCheckedItem As ListViewItem In Me.lvwFilesList.CheckedItems

                        Dim tmpSerial As String = Snapshot.GetSerial(tmpCheckedItem.Name)
                        Dim tmpSnapshot As Snapshot = SSMGameList.Games(tmpSerial).Snapshots(tmpCheckedItem.Name)
                        checkedSnapshots.Add(tmpSnapshot.Name)

                        lvwFiles_SelectedSizeSnaps += tmpSnapshot.Length
                    Next
                End If
        End Select
    End Sub

    Private Sub cmdFilesCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilesCheckAll.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.lvwFileList_IndexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdFilesCheckNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilesCheckNone.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.lvwFileList_IndexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdFilesCheckInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdFilesCheckInvert.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            If Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = True Then
                Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.lvwFileList_IndexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub cmdFilesCheckBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilesCheckBackup.Click
        Me.UI_Enable(False)
        For lvwItemIndex = 0 To Me.lvwFilesList.Items.Count - 1
            If Savestate.isBackup(Me.lvwFilesList.Items.Item(lvwItemIndex).Name) Then
                Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwFilesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.lvwFileList_IndexChecked()
        Me.UI_UpdateFileInfo()
        Me.UI_Enable(True)
    End Sub

    Private Sub lvwFilesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwFilesList.ItemChecked
        If Not (ListsAreRefreshed) Then
            SSMAppLog.Append(eType.LogInformation, eSrc.MainWindow, eSrcMethod.FileListview, "Checked files changed.")
            Me.lvwFileList_IndexChecked()
            Me.UI_UpdateFileInfo()
        End If
    End Sub
#End Region

#Region "Form - Tabs management"
    Private Sub optSettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab1.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to kwnow 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If Me.optSettingTab1.IsHandleCreated Then
            If Me.optSettingTab1.Checked = True Then
                Me.optSettingTab1.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                Me.optSettingTab2.FlatAppearance.MouseDownBackColor = Color.White
                Me.optSettingTab3.FlatAppearance.MouseDownBackColor = Color.White

                Me.UI_SwitchMode(ListMode.Savestates)
            End If
        End If
    End Sub

    Private Sub optSettingTab2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab2.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to kwnow 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If Me.optSettingTab2.IsHandleCreated Then
            If Me.optSettingTab2.Checked = True Then
                Me.optSettingTab2.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                Me.optSettingTab1.FlatAppearance.MouseDownBackColor = Color.White
                Me.optSettingTab3.FlatAppearance.MouseDownBackColor = Color.White

                Me.UI_SwitchMode(ListMode.Stored)
            End If
        End If
    End Sub

    Private Sub optSettingTab3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab3.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to kwnow 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If Me.optSettingTab3.IsHandleCreated Then
            If Me.optSettingTab3.Checked = True Then
                Me.optSettingTab3.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                Me.optSettingTab1.FlatAppearance.MouseDownBackColor = Color.White
                Me.optSettingTab2.FlatAppearance.MouseDownBackColor = Color.White

                Me.UI_SwitchMode(ListMode.Snapshots)
            End If
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
        e.Graphics.DrawLine(Pens.DimGray, 0, Me.SplitContainer1.SplitterDistance + 1, Me.SplitContainer1.Width, Me.SplitContainer1.SplitterDistance + 1)
    End Sub

    Private Sub applyTheme()
        Me.BackColor = currentTheme.BgColor
        Me.panelWindowTitle.BackColor = currentTheme.BgColorTop
        'Me.flpWindowBottom.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.panelWindowTitle.BackgroundImage = currentTheme.BgImageTop
            Me.panelWindowTitle.BackgroundImageLayout = currentTheme.BgImageTopStyle
            'Me.flpWindowBottom.BackgroundImage = currentTheme.BgImageBottom
            'Me.flpWindowBottom.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.panelWindowTitle.BackgroundImage = Nothing
            'Me.flpWindowBottom.BackgroundImage = Nothing
        End If
        Me.Refresh()
    End Sub

    Friend Sub applyTheme2()
        'Friend sub for applying theme from another form/procedure
        Me.applyTheme()
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
    '        e.Graphics.DrawLine(Pens.Black, 0, 0, Me.Width - 1, 0)
    '        e.Graphics.DrawLine(Pens.Black, 0, 0, 0, Me.Height - 1)
    '        e.Graphics.DrawLine(Pens.Black, 0, Me.Height - 1, Me.Width - 1, Me.Height - 1)
    '        e.Graphics.DrawLine(Pens.Black, Me.Width - 1, 0, Me.Width - 1, Me.Height - 1)
    '    End If
    'End Sub
#End Region

#Region "Form - Tools menu"
    Private Sub cmTools_Check()
        'Me.cmiPCSX2Launch.Enabled = File.Exists(Path.Combine(My.Settings.PCSX2_PathBin, "PCSX2.exe"))
        Me.cmiPCSX2BinFolderOpen.Enabled = Directory.Exists(My.Settings.PCSX2_PathBin)
        Me.cmiPCSX2SStatesFolderOpen.Enabled = Directory.Exists(My.Settings.PCSX2_PathSState)
        Me.cmiPCSX2SnapsFolderOpen.Enabled = Directory.Exists(My.Settings.PCSX2_PathSnaps)
    End Sub

    Private Sub cmiPCSX2Launch_Click(sender As System.Object, e As System.EventArgs) Handles cmiPCSX2Launch.Click
        'Dim tmpPath As String = Path.Combine(My.Settings.PCSX2_PathBin, "PCSX2.exe")
        'If File.Exists(tmpPath) Then
        '    Diagnostics.Process.Start(tmpPath)
        'Else
        '    MessageBox.Show("The file specified does not exist. " & tmpPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        frmChooseVersion.ShowDialog(Me)
    End Sub

    Private Sub cmiPCSX2BinFolderOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmiPCSX2BinFolderOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathBin) Then
            Diagnostics.Process.Start(My.Settings.PCSX2_PathBin)
        Else
            MessageBox.Show("The folder specified does not exist. " & My.Settings.PCSX2_PathBin, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmiPCSX2SStatesFolderOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmiPCSX2SStatesFolderOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathSState) Then
            Diagnostics.Process.Start(My.Settings.PCSX2_PathSState)
        Else
            MessageBox.Show("The folder specified does not exist. " & My.Settings.PCSX2_PathSState, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmiPCSX2SnapsFolderOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmiPCSX2SnapsFolderOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathSnaps) Then
            Diagnostics.Process.Start(My.Settings.PCSX2_PathSnaps)
        Else
            MessageBox.Show("The folder specified does not exist. " & My.Settings.PCSX2_PathSnaps, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub GameDBExplorerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GameDBExplorerToolStripMenuItem.Click
        If Not frmGameDbExplorer.Visible Then
            frmGameDbExplorer.Show(Me)
        Else
            frmGameDbExplorer.BringToFront()
        End If
    End Sub

    Private Sub DeveloperToolsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeveloperToolsToolStripMenuItem.Click
        If Not frmSStateList.Visible Then
            frmSStateList.Show(Me)
        Else
            frmSStateList.BringToFront()
        End If
    End Sub

#End Region
End Class