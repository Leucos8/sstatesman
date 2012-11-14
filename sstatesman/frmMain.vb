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

    Dim ListsAreCurrentlyRefreshed As Boolean = False
    Dim lvwGamesList_PopTime As Long
    Dim lvwSStatesList_PopTime As Long
    Dim UIUpdate_Time As Long

    Dim currentGameInfo As New GameInfo

    Dim lvwGamesList_SelectedSize As Long = 0
    Dim lvwGamesList_SelectedSizeBackup As Long = 0
    Dim lvwSStatesList_SelectedSize As Long = 0
    Dim lvwSStatesList_SelectedSizeBackup As Long = 0

    Friend Enum frmMainGamesLvwColumn
        GameTitle
        GameSerial
        GameRegion
        SStateInfo
        SStateBackupInfo
        SnapsInfo
    End Enum

    Friend Enum frmMainSStatesLvwColumn
        FileName
        Slot
        Backup
        Version
        LastWriteDate
        Size
    End Enum

    Friend Sub List_Refresher()
        Me.UI_Enabler(False, True, True)
        mdlFileList.GamesList_Status = GamesList_LoadAll(My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps, mdlFileList.GamesList)
        Me.lvwGamesList_Populate()
        Me.lvwGamesList_indexCheckedGames()
        Me.lvwSStatesList_Populate()
        Me.lvwSStatesList_indexCheckedFiles()
        Me.UI_Updater()
        Me.UI_Enabler(True, True, True)
    End Sub

    Private Sub List_RefresherGames()
        Me.lvwGamesList_indexCheckedGames()
        Me.lvwSStatesList_Populate()
        Me.lvwSStatesList_indexCheckedFiles()
        Me.UI_Updater()
    End Sub

#Region "Form - General"
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Getting DPI information
        Using gfx As Graphics = Me.CreateGraphics()
            mdlMain.DPIxScale = gfx.DpiX / 96
            If mdlMain.DPIxScale <= 0.2 Then
                mdlMain.DPIxScale = 1
            End If
            mdlMain.DPIyScale = gfx.DpiY / 96
            If mdlMain.DPIyScale <= 0.2 Then
                mdlMain.DPIyScale = 1
            End If
        End Using

        'Executes the FirstRun procedure (it tries to detect PCSX2 folders)
        If My.Settings.SStatesMan_FirstRun = True Then
            mdlMain.FirstRun()
        Else
            'Checks if there are some invalid settings
            mdlMain.PCSX2_PathAll_Check()
        End If

        If My.Settings.SStatesMan_SettingFail Then
            frmSettings.ShowDialog(Me)
        End If

        mdlTheme.currentTheme = mdlTheme.LoadTheme(CType(My.Settings.SStatesMan_Theme, eTheme))

        Me.applyTheme()
        Me.lblWindowVersion.Text = String.Concat(Me.lblWindowVersion.Text, _
                                                 My.Application.Info.Version.ToString, " ", _
                                                 My.Settings.SStatesMan_Channel) 'Add version information to the main window


        Dim imlLvwCheckboxes As New ImageList                       'Listviews checkboxes (stateimagelist)
        With imlLvwCheckboxes
            .ImageSize = New Size(CInt(10 * DPIxScale) + 1, CInt(10 * DPIyScale) + 1)   'Setting the size
            .Images.Add(My.Resources.Checkbox_Unchecked_22x22)      'Unchecked state image
            .Images.Add(My.Resources.Checkbox_Checked_22x22)          'Checked state image
        End With
        Me.lvwGamesList.StateImageList = imlLvwCheckboxes           'Assigning the imagelist to the Games listview
        Me.lvwSStatesList.StateImageList = imlLvwCheckboxes         'Assigning the imagelist to the Savestates listview


        Me.Location = My.Settings.frmMain_WindowPosition
        Me.Size = My.Settings.frmMain_WindowSize
        If My.Settings.frmMain_WindowState = FormWindowState.Minimized Then
            My.Settings.frmMain_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmMain_WindowState
        Me.SplitContainer1.SplitterDistance = My.Settings.frmMain_SplitterDistance

        If My.Settings.frmMain_glvw_columnwidth IsNot Nothing Then
            If My.Settings.frmMain_glvw_columnwidth.Length = Me.lvwGamesList.Columns.Count Then
                For i As Integer = 0 To Me.lvwGamesList.Columns.Count - 1
                    Me.lvwGamesList.Columns(i).Width = My.Settings.frmMain_glvw_columnwidth(i)
                Next
            End If
        End If

        If My.Settings.frmMain_slvw_columnwidth IsNot Nothing Then
            If My.Settings.frmMain_slvw_columnwidth.Length = Me.lvwSStatesList.Columns.Count Then
                For i As Integer = 0 To Me.lvwSStatesList.Columns.Count - 1
                    Me.lvwSStatesList.Columns(i).Width = My.Settings.frmMain_slvw_columnwidth(i)
                Next
            End If
        End If

        If My.Settings.frmMain_CoverExpanded Then
            My.Settings.frmMain_CoverExpanded = True
            Me.lblGameList_Title.Visible = False
            Me.lblGameList_Region.Visible = False
            Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 7)
            Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(2, 0))
            Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 0))
            Me.imgCover.Size = New Size(CInt(122 * DPIxScale),
                                        CInt(122 * DPIyScale))
            Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 2)
            Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 3)
        End If


        'Loading the Game database (from PCSX2 directory)
        PCSX2GameDb.Load(Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename))
        'Refreshing the games list
        Me.List_Refresher()

        'Timer auto refresh
        Me.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh


        If My.Settings.SStatesMan_SStatesListShowOnly Then
            Me.cmdSStatesLvwExpand_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.frmMain_WindowState = Me.WindowState
        If Not (Me.WindowState = FormWindowState.Maximized Or Me.WindowState = FormWindowState.Minimized) Then
            My.Settings.frmMain_WindowPosition = Me.Location
            My.Settings.frmMain_WindowSize = Me.Size
        End If
        My.Settings.frmMain_SplitterDistance = Me.SplitContainer1.SplitterDistance

        Dim columnwidtharray As Integer() = {Me.GamesLvw_GameTitle.Width, Me.GameLvw_GameSerial.Width, Me.GameLvw_GameRegion.Width,
                                             Me.GameLvw_SStatesInfo.Width, Me.GameLvw_BackupInfo.Width, Me.GameLvw_SnapsInfo.Width}
        My.Settings.frmMain_glvw_columnwidth = columnwidtharray

        columnwidtharray = {Me.SStatesLvw_FileName.Width, Me.SStatesLvw_Slot.Width, Me.SStatesLvw_Backup.Width,
                            Me.SStatesLvw_Version.Width, Me.SStatesLvw_DateLastWrite.Width, Me.SStatesLvw_Size.Width}
        My.Settings.frmMain_slvw_columnwidth = columnwidtharray

        My.Settings.Save()
    End Sub

    Private Sub UI_Enabler(ByVal pGlobal_Switch As Boolean, ByVal pGamesList_included As Boolean, ByVal pSavestatesList_included As Boolean)
        If pGlobal_Switch = True Then
            Me.ListsAreCurrentlyRefreshed = False
            If pGamesList_included Then
                Me.lvwGamesList.EndUpdate()
            End If
            If pSavestatesList_included Then
                Me.lvwSStatesList.EndUpdate()
            End If
        Else
            Me.ListsAreCurrentlyRefreshed = True
            If pGamesList_included Then
                Me.lvwGamesList.BeginUpdate()
            End If
            If pSavestatesList_included Then
                Me.lvwSStatesList.BeginUpdate()
            End If
        End If
        'mdlMain.WriteToConsole("frmMain", "UI_Enabler", String.Format("UI is {0}, GameList is {1}, SavesList is {2}.", pGlobal_Switch.ToString, pGamesList_Switch.ToString, pSavestatesList_Switch.ToString))
    End Sub

    Private Sub UI_Updater()
        Dim sw As New Stopwatch
        sw.Start()

        Me.UI_UpdaterGameInfo()
        Me.UI_UpdaterStInfo()


        sw.Stop()
        Me.UIUpdate_Time = sw.ElapsedTicks
        mdlMain.AppendToLog("Main window", "UI_Updater", "Refreshed status.", Me.UIUpdate_Time)

    End Sub

    Private Sub UI_UpdaterGameInfo()
        'Games List
        If Me.lvwGamesList.Items.Count = 0 Then
            'If there are no games these three buttons get disabled
            Me.cmdGameSelectAll.Enabled = False
            Me.cmdGameSelectInvert.Enabled = False
            Me.cmdGameSelectNone.Enabled = False

        Else
            'If there are games invert is always enabled
            Me.cmdGameSelectInvert.Enabled = True

            If Me.lvwGamesList.CheckedItems.Count > 0 Or Me.lvwGamesList.SelectedItems.Count > 0 Then

                Me.cmdGameSelectAll.Enabled = True

                If Me.lvwGamesList.CheckedItems.Count > 0 Then
                    Me.cmdGameSelectNone.Enabled = True
                Else
                    Me.cmdGameSelectNone.Enabled = False
                End If
                'If more than one game is checked
                If Me.lvwGamesList.CheckedItems.Count > 1 Then
                    'Game info
                    Me.txtGameList_Title.Text = "(multiple games selected)"
                    Me.txtGameList_Serial.Text = ""
                    Me.txtGameList_Region.Text = ""
                    Me.txtGameList_Compat.Text = ""
                    Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
                    Me.imgFlag.Image = My.Resources.Flag_0Null_30x20
                    'Cover
                    Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                    Me.imgCover.Image = My.Resources.Extra_Nocover_40x40

                    Me.imgCover.Dock = DockStyle.Fill

                    'If all the games are checked
                    If Me.lvwGamesList.Items.Count = Me.lvwGamesList.CheckedItems.Count Then
                        Me.cmdGameSelectAll.Enabled = False
                    End If
                Else

                    'Game info
                    Me.txtGameList_Title.Text = currentGameInfo.Name
                    Me.txtGameList_Serial.Text = currentGameInfo.Serial
                    Me.txtGameList_Region.Text = currentGameInfo.Region
                    Me.txtGameList_Compat.Text = currentGameInfo.CompatToText
                    Me.txtGameList_Compat.BackColor = currentGameInfo.CompatToColor(Color.WhiteSmoke)
                    Me.imgFlag.Image = mdlMain.assignFlag(currentGameInfo.Region, currentGameInfo.Serial)
                    Me.imgFlag.Size = New Size(CInt(Me.imgFlag.Image.PhysicalDimension.Width + 2 * DPIxScale),
                                               CInt(Me.imgFlag.Image.PhysicalDimension.Height + 2 * DPIyScale))

                    'Cover image
                    If Directory.Exists(My.Settings.SStatesMan_PathPics.ToLower) Then
                        Try
                            Me.imgCover.SizeMode = PictureBoxSizeMode.StretchImage
                            Me.imgCover.Load(Path.Combine(My.Settings.SStatesMan_PathPics, currentGameInfo.Serial & ".jpg"))

                            Me.imgCover.Dock = DockStyle.None
                            Me.imgCover.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
                            If My.Settings.frmMain_CoverExpanded Then
                                Me.imgCover.Size = Me.imgCover_SetSize(120, My.Settings.frmMain_CoverExpanded)
                                'Me.imgCover.Size = New Size(CInt(122 * DPIxScale),
                                '                            CInt((Me.imgCover.Image.PhysicalDimension.Height * 120 / Me.imgCover.Image.PhysicalDimension.Width + 2) * DPIyScale))
                            Else
                                Me.imgCover.Size = Me.imgCover_SetSize(46, My.Settings.frmMain_CoverExpanded)
                                'If Me.imgCover.Image.PhysicalDimension.Height > Me.imgCover.Image.PhysicalDimension.Width Then
                                '    Me.imgCover.Size = New Size(CInt((Me.imgCover.Image.PhysicalDimension.Width * 46 / Me.imgCover.Image.PhysicalDimension.Height + 2) * DPIxScale),
                                '                                CInt(48 * DPIyScale))
                                'Else
                                '    Me.imgCover.Size = New Size(CInt(48 * DPIxScale),
                                '                                CInt((Me.imgCover.Image.PhysicalDimension.Height * 46 / Me.imgCover.Image.PhysicalDimension.Width + 2) * DPIyScale))
                                'End If
                            End If
                        Catch ex As Exception
                            'No cover image found or file is corrupted
                            mdlMain.AppendToLog("Main window", "UI_Updater", String.Concat("Cover image error: ", ex.Message))
                            Me.imgCover.Image = My.Resources.Extra_Nocover_40x40
                            Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                            Me.imgCover.Dock = DockStyle.Fill
                        End Try
                    End If
                    'End cover image

                End If

            Else

                Me.txtGameList_Title.Text = ""
                Me.txtGameList_Serial.Text = ""
                Me.txtGameList_Region.Text = ""
                Me.txtGameList_Compat.Text = ""
                Me.txtGameList_Compat.BackColor = Color.WhiteSmoke
                Me.txtSize.Text = ""
                Me.txtSizeBackup.Text = ""
                Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

                Me.imgCover.Image = My.Resources.Flag_0Null_30x20
                Me.imgCover.SizeMode = PictureBoxSizeMode.Normal
                Me.imgCover.Dock = DockStyle.Fill

                Me.cmdGameSelectNone.Enabled = False
                Me.cmdGameSelectAll.Enabled = True
            End If
        End If
    End Sub

    Private Sub UI_UpdaterStInfo()
        'Savetates list
        Me.txtSStateListSelection.Text = System.String.Format("{0:N0} | {1:N0} files", Me.lvwSStatesList.CheckedItems.Count, Me.lvwSStatesList.Items.Count)
        Me.txtSize.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.lvwSStatesList_SelectedSize / 1024 ^ 2, Me.lvwGamesList_SelectedSize / 1024 ^ 2)
        Me.txtSizeBackup.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.lvwSStatesList_SelectedSizeBackup / 1024 ^ 2, Me.lvwGamesList_SelectedSizeBackup / 1024 ^ 2)

        If Me.lvwSStatesList.Items.Count = 0 Then
            'No savestates in list
            'Me.txtSStateListSelection.Text = System.String.Format("{0:N0} | {1:N0}", 0, 0)
            'Me.txtSize.Text = System.String.Format("{0:N2} | {1:N2} MB", 0, 0)
            'Me.txtSizeBackup.Text = System.String.Format("{0:N2} | {1:N2} MB", 0, 0)

            Me.cmdSStateSelectAll.Enabled = False
            Me.cmdSStateSelectInvert.Enabled = False
            Me.cmdSStateSelectNone.Enabled = False
            Me.cmdSStateSelectBackup.Enabled = False
            Me.cmdSStateDelete.Enabled = False

        Else


            Me.cmdSStateSelectInvert.Enabled = True
            Me.cmdSStateSelectBackup.Enabled = True

            If Me.lvwSStatesList.CheckedItems.Count > 0 Then

                Me.cmdSStateSelectNone.Enabled = True
                Me.cmdSStateDelete.Enabled = True

                If Me.lvwSStatesList.Items.Count = Me.lvwSStatesList.CheckedItems.Count Then
                    Me.cmdSStateSelectAll.Enabled = False
                Else
                    Me.cmdSStateSelectAll.Enabled = True
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
            If Directory.Exists(My.Settings.PCSX2_PathSState) And Not frmDeleteForm.Visible And Not frmSettings.Visible And Not Me.WindowState = FormWindowState.Minimized Then
                Dim tmpDate As DateTime = Directory.GetLastWriteTime(My.Settings.PCSX2_PathSState)
                If Not tmpDate = mdlFileList.SStates_FolderLastModified Then
                    mdlMain.AppendToLog("Main window", "Timer", "Refreshed lists.")
                    Me.List_Refresher()
                End If
            End If
        Else
            Me.tmrSStatesListRefresh.Enabled = False
        End If
    End Sub
#End Region

#Region "Form - Windowstate command buttons"
    Private Sub cmdWindowMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmdWindowMaximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            'Me.Padding = New Padding(Math.Abs(Me.Top))
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestore_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            'Me.Padding = New Padding(1)
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximize_12x12
        End If
    End Sub

    Private Sub cmdWindowClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()    'Needed for firing the FormClosing event, wich saves some settings.
        End
    End Sub

    Private Sub frmMain_ResizeBegin(sender As Object, e As System.EventArgs) Handles Me.ResizeBegin
        My.Settings.frmMain_WindowPosition = Me.Location
        My.Settings.frmMain_WindowSize = Me.Size
    End Sub

    Private Sub frmMain_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Normal Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonMaximize_12x12
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.cmdWindowMaximize.Image = My.Resources.Window_ButtonRestore_12x12
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
        Me.List_Refresher()
    End Sub

    Private Sub cmdSStateDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateDelete.Click
        frmDeleteForm.ShowDialog(Me)
    End Sub

    Private Sub cmdSStatesLvwExpand_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesLvwExpand.Click
        If Me.SplitContainer1.Panel1Collapsed Then
            Me.SplitContainer1.Panel1Collapsed = False
            Me.cmdSStatesLvwExpand.Image = My.Resources.Icon_ExpandTop_12x12
        Else
            Me.SplitContainer1.Panel1Collapsed = True
            Me.cmdSStatesLvwExpand.Image = My.Resources.Icon_ExpandBottom_12x12

            Me.cmdGameSelectAll_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub imgCover_MouseClick(sender As System.Object, e As MouseEventArgs) Handles imgCover.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If My.Settings.frmMain_CoverExpanded Then
                My.Settings.frmMain_CoverExpanded = False
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 1)
                Me.imgCover.Size = imgCover_SetSize(46, My.Settings.frmMain_CoverExpanded)
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 1))
                Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(0, 0))
                Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 9)
                Me.lblGameList_Title.Visible = True
                Me.lblGameList_Region.Visible = True
            Else
                My.Settings.frmMain_CoverExpanded = True
                Me.lblGameList_Title.Visible = False
                Me.lblGameList_Region.Visible = False
                Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 7)
                Me.TableLayoutPanel3.SetCellPosition(Me.lvwGamesList, New TableLayoutPanelCellPosition(2, 0))
                Me.TableLayoutPanel3.SetCellPosition(Me.imgCover, New TableLayoutPanelCellPosition(0, 0))
                Me.imgCover.Size = imgCover_SetSize(120, My.Settings.frmMain_CoverExpanded)
                Me.TableLayoutPanel3.SetColumnSpan(Me.imgCover, 2)
                Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 3)
            End If
        End If
    End Sub

    Private Function imgCover_SetSize(ByVal pMaxSize As Integer, ByVal pMode As Boolean) As Size
        If pMode Then
            Return New Size(CInt((pMaxSize + 2) * DPIxScale),
                            CInt((Me.imgCover.Image.PhysicalDimension.Height * pMaxSize / Me.imgCover.Image.PhysicalDimension.Width + 2) * DPIyScale))
        Else
            If Me.imgCover.Image.PhysicalDimension.Height > Me.imgCover.Image.PhysicalDimension.Width Then
                Return New Size(CInt((Me.imgCover.Image.PhysicalDimension.Width * pMaxSize / Me.imgCover.Image.PhysicalDimension.Height + 2) * DPIxScale),
                                CInt((pMaxSize + 2) * DPIyScale))
            Else
                Return New Size(CInt((pMaxSize + 2) * DPIxScale),
                                CInt((Me.imgCover.Image.PhysicalDimension.Height * pMaxSize / Me.imgCover.Image.PhysicalDimension.Width + 2) * DPIyScale))
            End If
        End If
    End Function
#End Region

#Region "UI - Gamelist management"
    Private Sub lvwGamesList_Populate()
        Dim sw As New Stopwatch
        sw.Start()

        Me.lvwGamesList.Items.Clear()
        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        Dim tmpGListItems As New List(Of ListViewItem)
        For Each tmpGListItem As KeyValuePair(Of String, mdlFileList.GamesList_Item) In mdlFileList.GamesList
            currentGameInfo = PCSX2GameDb.RecordExtract(tmpGListItem.Key)

            'Creating the listviewitem
            Dim tmpLvwGListItem As New ListViewItem With {.Text = currentGameInfo.Name, .Name = currentGameInfo.Serial}
            tmpLvwGListItem.SubItems.AddRange({currentGameInfo.Serial, currentGameInfo.Region})
            'Calculating savestates count and displaying size
            If tmpGListItem.Value.Savestates.Where(Function(filter) filter.Value.Extension.Equals(My.Settings.PCSX2_SStateExt)).Count > 0 Then
                tmpLvwGListItem.SubItems.Add(String.Format("{0:N0} × {1:N2} MB",
                                                            tmpGListItem.Value.Savestates.Where(Function(extfilter) extfilter.Value.Extension.Equals(My.Settings.PCSX2_SStateExt)).Count,
                                                            tmpGListItem.Value.Savestates_SizeTot / 1024 ^ 2))
            Else
                tmpLvwGListItem.SubItems.Add("None")
            End If

            'Calculating backups count and displaying size
            If tmpGListItem.Value.Savestates.Where(Function(filter) filter.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup)).Count > 0 Then
                tmpLvwGListItem.SubItems.Add(String.Format("{0:N0} × {1:N2} MB",
                                                            tmpGListItem.Value.Savestates.Where(Function(extfilter) extfilter.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup)).Count,
                                                            tmpGListItem.Value.SavestatesBackup_SizeTot / 1024 ^ 2))
            Else
                tmpLvwGListItem.SubItems.Add("None")
            End If

            'Calculating snapshots count and displaying size
            If tmpGListItem.Value.Snapshots.Count > 0 Then
                tmpLvwGListItem.SubItems.Add(String.Format("{0:N0} × {1:N2} MB",
                                                            tmpGListItem.Value.Snapshots.Count,
                                                            tmpGListItem.Value.Snapshots_SizeTot / 1024 ^ 2))
            Else
                tmpLvwGListItem.SubItems.Add("None")
            End If

            'If it was previously checked/selected the check/select it again
            If checkedGames.Contains(currentGameInfo.Serial) Then
                If checkedGames.Count = 1 Then
                    tmpLvwGListItem.Selected = True
                Else
                    tmpLvwGListItem.Checked = True
                End If
            End If

            'All done, the item is added
            tmpGListItems.Add(tmpLvwGListItem)

        Next

        'Addrange is faster than adding each item, even with begin/endupdate
        Me.lvwGamesList.Items.AddRange(tmpGListItems.ToArray)

        mdlTheme.ListAlternateColors(Me.lvwGamesList)
        sw.Stop()
        Me.lvwGamesList_PopTime = sw.ElapsedTicks
        mdlMain.AppendToLog("Main window", "populate game list", String.Format("Listed {0:N0} games.", Me.lvwGamesList.Items.Count), Me.lvwGamesList_PopTime)
    End Sub

    Private Sub lvwGamesList_indexCheckedGames()
        'checked games are cleared
        mdlMain.checkedGames.Clear()
        'reindexing checked games
        If Me.lvwGamesList.CheckedItems.Count > 0 Then
            For Each tmpGamesList_ItemChecked As System.Windows.Forms.ListViewItem In Me.lvwGamesList.CheckedItems
                mdlMain.checkedGames.Add(tmpGamesList_ItemChecked.Name)
            Next
        ElseIf Me.lvwGamesList.SelectedItems.Count > 0 Then
            mdlMain.checkedGames.Add(Me.lvwGamesList.SelectedItems.Item(0).Name)
        End If
    End Sub

    Private Sub cmdGameSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectAll.Click
        Me.UI_Enabler(False, True, True)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.List_RefresherGames()
        Me.UI_Enabler(True, True, True)
    End Sub

    Private Sub cmdGameSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSelectNone.Click
        Me.UI_Enabler(False, True, True)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.List_RefresherGames()
        Me.UI_Enabler(True, True, True)
    End Sub

    Private Sub cmdGameSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdGameSelectInvert.Click
        Me.UI_Enabler(False, True, True)
        For lvwItemIndex = 0 To Me.lvwGamesList.Items.Count - 1
            If Me.lvwGamesList.Items.Item(lvwItemIndex).Checked Then
                Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwGamesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.List_RefresherGames()
        Me.UI_Enabler(True, True, True)
    End Sub

    Private Sub lvwGamesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGamesList.ItemChecked
        If ListsAreCurrentlyRefreshed = False Then
            Me.UI_Enabler(False, False, True)
            Me.List_RefresherGames()
            Me.UI_Enabler(True, False, True)
        End If
    End Sub

    Private Sub lvwGamesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGamesList.SelectedIndexChanged
        If Me.lvwGamesList.CheckedItems.Count = 0 And Not (Me.lvwGamesList.SelectedItems.Count = 0) Then
            If ListsAreCurrentlyRefreshed = False Then
                Me.UI_Enabler(False, False, True)
                Me.List_RefresherGames()
                Me.UI_Enabler(True, False, True)
            End If
        End If
    End Sub
#End Region

#Region "UI - SStatesList management"
    Private Sub lvwSStatesList_Populate()
        Dim sw As New Stopwatch
        sw.Start()

        'Preparation for the update
        Me.lvwGamesList_SelectedSize = 0
        Me.lvwGamesList_SelectedSizeBackup = 0
        Me.lvwSStatesList_SelectedSize = 0
        Me.lvwSStatesList_SelectedSizeBackup = 0

        'clear items and group, lvwSStatesList refresh in fact begins here
        Me.lvwSStatesList.Items.Clear()
        Me.lvwSStatesList.Groups.Clear()

        'if more than one game is checked groups are shown
        If Me.lvwGamesList.CheckedItems.Count > 1 Then
            Me.lvwSStatesList.ShowGroups = True
        Else
            Me.lvwSStatesList.ShowGroups = False
        End If

        Dim tmpSListGroups As New List(Of ListViewGroup)
        Dim tmpSListItems As New List(Of ListViewItem)
        Dim lastSState As Integer = -1
        Dim lastSStateDate As Date = Date.MinValue


        For Each tmpSerial As System.String In mdlMain.checkedGames

            Dim tmpGamesListItem As New GamesList_Item
            If (mdlFileList.GamesList.TryGetValue(tmpSerial, tmpGamesListItem)) Then

                'Creation of the header
                currentGameInfo = PCSX2GameDb.RecordExtract(tmpSerial)
                Dim tmpLvwSListGroup As New System.Windows.Forms.ListViewGroup With {
                    .Header = currentGameInfo.ToString,
                    .HeaderAlignment = HorizontalAlignment.Left,
                    .Name = currentGameInfo.Serial}

                tmpSListGroups.Add(tmpLvwSListGroup)


                lvwGamesList_SelectedSize += mdlFileList.GamesList(currentGameInfo.Serial).Savestates_SizeTot
                lvwGamesList_SelectedSizeBackup += mdlFileList.GamesList(currentGameInfo.Serial).SavestatesBackup_SizeTot

                If (mdlFileList.GamesList(tmpSerial).Savestates.Values.Count > 0) Then
                    For Each tmpSavestate As KeyValuePair(Of String, Savestate) In mdlFileList.GamesList(tmpSerial).Savestates

                        Dim tmpLvwSListItem As New System.Windows.Forms.ListViewItem With {.Text = tmpSavestate.Key,
                                                                                           .Group = tmpLvwSListGroup,
                                                                                           .Name = tmpSavestate.Key}
                        tmpLvwSListItem.SubItems.AddRange({tmpSavestate.Value.Slot.ToString,
                                                           tmpSavestate.Value.Backup.ToString,
                                                           tmpSavestate.Value.Version,
                                                           tmpSavestate.Value.LastWriteTime.ToString,
                                                           System.String.Format("{0:N2} MB", tmpSavestate.Value.Length / 1024 ^ 2)})
                        If (checkedSavestates.Contains(tmpSavestate.Key)) Then
                            tmpLvwSListItem.Checked = True
                        End If

                        tmpSListItems.Add(tmpLvwSListItem)

                        If (tmpSavestate.Value.LastWriteTime > lastSStateDate) Then
                            lastSState = tmpSListItems.Count - 1
                            lastSStateDate = tmpSavestate.Value.LastWriteTime
                        End If
                    Next
                End If

            End If

            If (lastSState > -1) Then
                tmpSListItems.Item(lastSState).SubItems(0).ForeColor = Color.FromArgb(255, 65, 74, 100)
            End If
        Next


        Me.lvwSStatesList.Groups.AddRange(tmpSListGroups.ToArray)
        Me.lvwSStatesList.Items.AddRange(tmpSListItems.ToArray)
        mdlTheme.ListAlternateColors(Me.lvwSStatesList)

        sw.Stop()
        Me.lvwSStatesList_PopTime = sw.ElapsedTicks
        mdlMain.AppendToLog("Main window", "populate savestates list ", String.Format("Listed {0:N0} savestates.", Me.lvwSStatesList.Items.Count), Me.lvwSStatesList_PopTime)
    End Sub

    Private Sub lvwSStatesList_indexCheckedFiles()
        Me.lvwSStatesList_SelectedSize = 0
        Me.lvwSStatesList_SelectedSizeBackup = 0
        checkedSavestates.Clear()

        If Me.lvwSStatesList.CheckedItems.Count > 0 Then
            For Each tmpLvwSListItemChecked As ListViewItem In Me.lvwSStatesList.CheckedItems

                Dim tmpGameSerial As String = Savestate.GetSerial(tmpLvwSListItemChecked.Name)
                Dim tmpSavestate As Savestate = mdlFileList.GamesList(tmpGameSerial).Savestates(tmpLvwSListItemChecked.Name)
                checkedSavestates.Add(tmpSavestate.Name)

                If tmpSavestate.Backup Then
                    lvwSStatesList_SelectedSizeBackup += tmpSavestate.Length
                Else
                    lvwSStatesList_SelectedSize += tmpSavestate.Length
                End If
            Next
        End If
    End Sub

    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Me.UI_Enabler(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
        Next
        Me.lvwSStatesList_indexCheckedFiles()
        Me.UI_UpdaterStInfo()
        Me.UI_Enabler(True, False, True)
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Me.UI_Enabler(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.lvwSStatesList_indexCheckedFiles()
        Me.UI_UpdaterStInfo()
        Me.UI_Enabler(True, False, True)
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Me.UI_Enabler(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.lvwSStatesList_indexCheckedFiles()
        Me.UI_UpdaterStInfo()
        Me.UI_Enabler(True, False, True)
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UI_Enabler(False, False, True)
        For lvwItemIndex = 0 To Me.lvwSStatesList.Items.Count - 1
            If Me.lvwSStatesList.Items.Item(lvwItemIndex).SubItems(frmMainSStatesLvwColumn.Backup).Text = "True" Then
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwSStatesList.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.lvwSStatesList_indexCheckedFiles()
        Me.UI_UpdaterStInfo()
        Me.UI_Enabler(True, False, True)
    End Sub

    Private Sub lvwSStatesList_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesList.ItemChecked
        If ListsAreCurrentlyRefreshed = False Then
            Me.lvwSStatesList_indexCheckedFiles()
            Me.UI_UpdaterStInfo()
        End If
    End Sub
#End Region

#Region "Form - Tabs management"
    Private Sub optSettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab1.CheckedChanged
        If Me.optSettingTab1.Checked = True Then
            With Me.optSettingTab1
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab2
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            With Me.optSettingTab3
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
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab1
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            With Me.optSettingTab3
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
        Me.cmiPCSX2Launch.Enabled = File.Exists(Path.Combine(My.Settings.PCSX2_PathBin, "PCSX2.exe"))
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
        If Not frmGameDb.Visible Then
            frmGameDb.Show(Me)
        Else
            frmGameDb.BringToFront()
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