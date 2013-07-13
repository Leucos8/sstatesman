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
Public Class frmSettings

    Dim tmpTab2SettingsFail As Boolean = False
    Dim currentSelectedTheme As mdlTheme.eTheme

#Region "Settings management"
    Private Sub Settings_Load()
        'General options
        Me.ckbFirstRun.Checked = My.Settings.SStatesMan_FirstRun
        Me.ckb_SStatesListShowOnly.Checked = My.Settings.SStatesMan_SStatesListShowOnly
        Me.ckb_SStatesListAutoRefresh.Checked = My.Settings.SStatesMan_SStatesListAutoRefresh
        'Savestates management
        Me.ckbSStatesManMoveToTrash.Checked = My.Settings.SStatesMan_SStateTrash
        Me.ckbSStatesManVersionExtract.Checked = My.Settings.SStatesMan_SStatesVersionExtract
        'Cover folder
        Me.txtSStatesManPicsPath.Text = My.Settings.SStatesMan_PathPics

        'PCSX2 folders
        Me.txtPCSX2AppPath.Text = My.Settings.PCSX2_PathBin
        Me.txtPCSX2IniPath.Text = My.Settings.PCSX2_PathInis
        Me.txtPCSX2SStatePath.Text = My.Settings.PCSX2_PathSState
        Me.txtPCSX2SnapsPath.Text = My.Settings.PCSX2_PathSnaps

        Me.LoadSettings_Theme()

    End Sub

    Private Sub Settings_Apply()
        'General options
        My.Settings.SStatesMan_FirstRun = Me.ckbFirstRun.Checked
        My.Settings.SStatesMan_SStatesListShowOnly = Me.ckb_SStatesListShowOnly.Checked
        My.Settings.SStatesMan_SStatesListAutoRefresh = Me.ckb_SStatesListAutoRefresh.Checked
        'Savestates management
        My.Settings.SStatesMan_SStateTrash = Me.ckbSStatesManMoveToTrash.Checked
        My.Settings.SStatesMan_SStatesVersionExtract = Me.ckbSStatesManVersionExtract.Checked
        'Cover folder
        My.Settings.SStatesMan_PathPics = Me.txtSStatesManPicsPath.Text
        'PCSX2 folders
        My.Settings.PCSX2_PathBin = Me.txtPCSX2AppPath.Text
        My.Settings.PCSX2_PathInis = Me.txtPCSX2IniPath.Text
        My.Settings.PCSX2_PathSState = Me.txtPCSX2SStatePath.Text
        My.Settings.PCSX2_PathSnaps = Me.txtPCSX2SnapsPath.Text

        'Theme
        My.Settings.SStatesMan_ThemeImageEnabled = Me.ckbSStatesManThemeImage.Checked
        My.Settings.SStatesMan_ThemeGradientEnabled = Me.ckbSStatesManThemeGradient.Checked
        My.Settings.SStatesMan_Theme = currentSelectedTheme.ToString

        My.Settings.Save()

        'Getting things ready
        mdlTheme.LoadTheme(currentSelectedTheme.ToString)

        'Me.applyTheme()

        frmMain.applyTheme2()    'Updating frMain theme
        frmMain.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh   'Enabling the timer

    End Sub

    Private Sub Settings_Check()

        Me.cmdOk.Enabled = True
        Me.cmdApply.Enabled = True
        Me.tmpTab2SettingsFail = False

        'PCSX2 application path
        Me.txtPCSX2AppPath.Text = mdlMain.TrimBadPathChars(Me.txtPCSX2AppPath.Text)
        If Not (Directory.Exists(Me.txtPCSX2AppPath.Text)) Then
            Me.lblPCSX2AppPathStatus.Text = String.Concat("The specified path is not found or inaccessible.", Environment.NewLine,
                                                          "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2AppPath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2AppPathOpen.Enabled = False

            Me.imgPCSX2AppPathStatus.Image = My.Resources.InfoIcon_Error_16x16
            Me.imgPCSX2AppPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.cmdApply.Enabled = False
            Me.tmpTab2SettingsFail = True
        ElseIf Not (File.Exists(Path.Combine(Me.txtPCSX2AppPath.Text, My.Settings.PCSX2_GameDbFilename))) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("Unable to find """, My.Settings.PCSX2_GameDbFilename, """ in the specified path.", Environment.NewLine,
                                                                 "Information about games won't be shown in SStatesMan.")
            Me.tlpPCSX2AppPath.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.cmdPCSX2AppPathOpen.Enabled = False

            Me.imgPCSX2AppPathStatus.Image = My.Resources.InfoIcon_Exclamation_16x16
            Me.imgPCSX2AppPathStatus.Visible = True
        Else
            Me.lblPCSX2AppPathStatus.Text = String.Concat("The folder where SStatesMan will look for """, My.Settings.PCSX2_GameDbFilename, """, usually the folder where PCSX2 is installed.")
            Me.tlpPCSX2AppPath.BackColor = Color.Transparent
            Me.cmdPCSX2AppPathOpen.Enabled = True

            Me.imgPCSX2AppPathStatus.Visible = False
        End If

        'PCSX2 inis path
        Me.txtPCSX2IniPath.Text = mdlMain.TrimBadPathChars(Me.txtPCSX2IniPath.Text)
        If Not (Directory.Exists(Me.txtPCSX2IniPath.Text)) Then
            Me.lblPCSX2IniPathStatus.Text = String.Concat("The specified path is not found or inaccessible.", Environment.NewLine,
                                                          "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2IniPath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2IniPathOpen.Enabled = False

            Me.imgPCSX2IniPathStatus.Image = My.Resources.InfoIcon_Error_16x16
            Me.imgPCSX2IniPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.cmdApply.Enabled = False
            Me.tmpTab2SettingsFail = True
        ElseIf Not (File.Exists(Path.Combine(Me.txtPCSX2IniPath.Text, My.Settings.PCSX2_PCSX2_uiFilename))) Then
            Me.lblPCSX2IniPathStatus.Text = String.Concat("Unable to find """, My.Settings.PCSX2_PCSX2_uiFilename, """ in the specified path.", Environment.NewLine,
                                                          "It may not be the correct PCSX2 ""inis"" folder.")
            Me.tlpPCSX2IniPath.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.cmdPCSX2IniPathOpen.Enabled = False

            Me.imgPCSX2IniPathStatus.Image = My.Resources.InfoIcon_Exclamation_16x16
            Me.imgPCSX2IniPathStatus.Visible = True
        Else
            Me.lblPCSX2IniPathStatus.Text = "The folder where SStatesMan will look PCSX2 inis, usually the ""inis"" folder inside PCSX2 user folder."
            Me.tlpPCSX2IniPath.BackColor = Color.Transparent
            Me.cmdPCSX2IniPathOpen.Enabled = True

            Me.imgPCSX2IniPathStatus.Visible = False
        End If

        'PCSX2 savestates path
        Me.txtPCSX2SStatePath.Text = mdlMain.TrimBadPathChars(Me.txtPCSX2SStatePath.Text)
        If Not (Directory.Exists(Me.txtPCSX2SStatePath.Text)) Then
            Me.lblPCSX2SStatePathStatus.Text = String.Concat("The specified path is not found or inaccessible.", Environment.NewLine,
                                                             "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2SStatePath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2SStatePathOpen.Enabled = False

            Me.imgPCSX2SStatePathStatus.Image = My.Resources.InfoIcon_Error_16x16
            Me.imgPCSX2SStatePathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.cmdApply.Enabled = False
            Me.tmpTab2SettingsFail = True
        Else
            Me.lblPCSX2SStatePathStatus.Text = String.Format("The folder where SStatesMan will look for the savestates, usually the ""{0}"" folder inside PCSX2 user folder.", My.Settings.PCSX2_SStateFolder)
            Me.tlpPCSX2SStatePath.BackColor = Color.Transparent
            Me.cmdPCSX2SStatePathOpen.Enabled = True

            Me.imgPCSX2SStatePathStatus.Visible = False
        End If

        'PCSX2 snapshots path
        Me.txtPCSX2SnapsPath.Text = mdlMain.TrimBadPathChars(Me.txtPCSX2SnapsPath.Text)
        If Not (Directory.Exists(Me.txtPCSX2SnapsPath.Text)) Then
            Me.lblPCSX2SnapsPathStatus.Text = String.Concat("The specified path is not found or inaccessible.", Environment.NewLine,
                                                             "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2SnapsPath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2SnapsPathOpen.Enabled = False

            Me.imgPCSX2SnapsPathStatus.Image = My.Resources.InfoIcon_Error_16x16
            Me.imgPCSX2SnapsPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.cmdApply.Enabled = False
            Me.tmpTab2SettingsFail = True
        Else
            Me.lblPCSX2SnapsPathStatus.Text = String.Format("The folder where SStatesMan will look for the screnshots, usually the ""{0}"" folder inside PCSX2 user folder.", My.Settings.PCSX2_SnapsFolder)
            Me.tlpPCSX2SnapsPath.BackColor = Color.Transparent
            Me.cmdPCSX2SnapsPathOpen.Enabled = True

            Me.imgPCSX2SnapsPathStatus.Visible = False
        End If

        'SStatesMan cover pics path
        Me.txtSStatesManPicsPath.Text = mdlMain.TrimBadPathChars(Me.txtSStatesManPicsPath.Text)
        If Not (Directory.Exists(Me.txtSStatesManPicsPath.Text)) Then
            'Me.txtSStatesManPicsPath.Text = "Not set"
            'Me.lblSStatesManPicsPathStatus.Text = String.Concat("Path not found or inaccessible.", Environment.NewLine,
            '                                                    "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblSStatesManPicsPathStatus.Text = String.Concat("The specified path not found or inaccessible.", Environment.NewLine,
                                                                "Please enter a valid path.")
            Me.tlpSStatesManPicsPath.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.cmdSStatesManPicsPathOpen.Enabled = False
            Me.imgSStatesManPicsPathStatus.Visible = True

            'Me.cmdOk.Enabled = False
            'Me.cmdApply.Enabled=False
        Else
            Me.lblSStatesManPicsPathStatus.Text = String.Concat("The folder where SStatesMan will look for the game covers.", Environment.NewLine,
                                                                "The image file MUST be named <executable code>.jpg to work.")
            Me.tlpSStatesManPicsPath.BackColor = Color.Transparent
            Me.cmdSStatesManPicsPathOpen.Enabled = True
            Me.imgSStatesManPicsPathStatus.Visible = False
        End If




        If Me.tmpTab2SettingsFail Then
            Me.optTabHeader1.BackColor = Color.FromArgb(255, 255, 192, 192)
        Else
            Me.optTabHeader1.BackColor = Color.Transparent
        End If

    End Sub
#End Region

#Region "Form"
    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.lvwLog.SmallImageList = imlLvwItemIcons

        Me.applyTheme()

        Me.pnlTab0.Dock = DockStyle.Fill
        Me.pnlTab1.Dock = DockStyle.Fill
        Me.pnlTab2.Dock = DockStyle.Fill
        Me.pnlTab3.Dock = DockStyle.Fill

        Me.pnlTab0.Visible = Me.optTabHeader0.Checked
        Me.pnlTab1.Visible = Me.optTabHeader1.Checked
        Me.pnlTab2.Visible = Me.optTabHeader2.Checked
        Me.pnlTab3.Visible = Me.optTabHeader3.Checked

        Me.Settings_Load()
        Me.Settings_Check()

        '===
        'Log
        '===

        'Filter menu
        If Me.cmLogFilter.Items.Count = 1 Then
            Dim tmpFilterLogMenuItems As New List(Of ToolStripMenuItem)
            'Adding a menu item for each item in the enum.
            For Each tmpItem As String In [Enum].GetNames(GetType(mdlApplicationLog.eSrc))
                Dim tmpToolStripMenuItem As New ToolStripMenuItem With {.Name = "cmi" & tmpItem, .Text = tmpItem}
                'Adding click event
                AddHandler tmpToolStripMenuItem.Click, AddressOf Me.cmiFilter_Click
                tmpFilterLogMenuItems.Add(tmpToolStripMenuItem)
            Next
            cmLogFilter.SuspendLayout()
            cmLogFilter.Items.AddRange(tmpFilterLogMenuItems.ToArray)
            cmLogFilter.ResumeLayout()
        ElseIf Me.cmLogFilter.Items.Count > 0 Then
            'If the menu is already loaded reset the filter.
            cmLogFilter.SuspendLayout()
            For Each tmpMenuItem As ToolStripMenuItem In cmLogFilter.Items
                tmpMenuItem.Checked = False
            Next
            CType(cmLogFilter.Items(0), ToolStripMenuItem).Checked = True
            cmLogFilter.ResumeLayout()
        End If

        'Log is populated.
        Me.Log_Populate(SSMAppLog.Events)
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Me.Settings_Apply()
    End Sub

    Private Sub cmdApply_Click(sender As System.Object, e As System.EventArgs) Handles cmdApply.Click
        Me.Settings_Apply()
        Me.applyTheme()
        Me.Settings_Load()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        My.Settings.SStatesMan_SettingFail = PCSX2_PathAll_Check(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_PathInis, _
                                                                 My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps)
        If My.Settings.SStatesMan_SettingFail Then
            My.Settings.SStatesMan_FirstRun = True
            End
        End If
        Me.Close()
    End Sub
#End Region

#Region "Folder panels - validating events"
    Private Sub txtPath_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPCSX2AppPath.Validating, txtPCSX2IniPath.Validating, txtPCSX2SStatePath.Validating, txtPCSX2SnapsPath.Validating
        If e.Cancel = False Then
            Me.Settings_Check()
        End If
    End Sub
#End Region

#Region "Folder panels - browser"
    Private Sub cmdPCSX2AppPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathBrowse.Click
        Dim tmpPath As String = Me.txtPCSX2AppPath.Text
        If Me.createFolderBrowser("Select your PCSX2 executable folder.", tmpPath, Environment.SpecialFolder.ProgramFiles, False) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2AppPath.Text = tmpPath
        End If
        Me.Settings_Check()
    End Sub

    Private Sub cmdPCSX2IniPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathBrowse.Click
        Dim tmpPath As String = Me.txtPCSX2IniPath.Text
        If Me.createFolderBrowser("Select your PCSX2 ""inis"" folder.", Me.txtPCSX2IniPath.Text, Environment.SpecialFolder.MyDocuments, False) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2IniPath.Text = tmpPath
        End If
        Me.Settings_Check()
    End Sub

    Private Sub cmdPCSX2SStatePathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathBrowse.Click
        Dim tmpPath As String = Me.txtPCSX2SStatePath.Text
        If Me.createFolderBrowser("Select your PCSX2 savestates folder.", Me.txtPCSX2SStatePath.Text, Environment.SpecialFolder.MyDocuments, False) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2SStatePath.Text = tmpPath
        End If
        Me.Settings_Check()
    End Sub

    Private Sub cmdPCSX2SnapsPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SnapsPathBrowse.Click
        Dim tmpPath As String = Me.txtPCSX2SnapsPath.Text
        If Me.createFolderBrowser("Select your PCSX2 screenshots folder.", Me.txtPCSX2SnapsPath.Text, Environment.SpecialFolder.MyPictures, False) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2SnapsPath.Text = tmpPath
        End If
        Me.Settings_Check()
    End Sub

    Private Sub cmdSStatesManPicsPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesManPicsPathBrowse.Click
        Dim tmpPath As String = Me.txtSStatesManPicsPath.Text
        If Me.createFolderBrowser("Select your game cover images folder.", Me.txtSStatesManPicsPath.Text, Environment.SpecialFolder.MyPictures, True) = Windows.Forms.DialogResult.OK Then
            Me.txtSStatesManPicsPath.Text = tmpPath
        End If
        Me.Settings_Check()
    End Sub

    Private Function createFolderBrowser(ByVal pDescription As String, ByRef pStartPath As String, ByVal pStartPathDefault As Environment.SpecialFolder, Optional ByVal pAllowNewFolder As Boolean = False) As Windows.Forms.DialogResult
        Using FolderBrowse As New FolderBrowserDialog With {.Description = pDescription, .ShowNewFolderButton = pAllowNewFolder}
            If Directory.Exists(pStartPath) Then
                FolderBrowse.SelectedPath = pStartPath
            Else : FolderBrowse.SelectedPath = Environment.GetFolderPath(pStartPathDefault)
            End If
            Return FolderBrowse.ShowDialog(Me)
        End Using
    End Function
#End Region

#Region "Folder panels - detect"
    Private Sub cmdPCSX2AppPathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathDetect.Click
        PCSX2_PathBin_Detect(Me.txtPCSX2AppPath.Text)
        Me.Settings_Check()
    End Sub

    Private Sub cmdPCSX2IniPathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathDetect.Click
        PCSX2_PathInis_Detect(Me.txtPCSX2AppPath.Text, Me.txtPCSX2IniPath.Text)
        Me.Settings_Check()
    End Sub

    Private Sub cmdPCSX2SStatePathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathDetect.Click
        PCSX2_PathSettings_Detect(Me.txtPCSX2IniPath.Text, Me.txtPCSX2SStatePath.Text, Nothing)
        Me.Settings_Check()
    End Sub

    Private Sub cmdPCSX2SnapsPathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SnapsPathDetect.Click
        PCSX2_PathSettings_Detect(Me.txtPCSX2IniPath.Text, Nothing, Me.txtPCSX2SnapsPath.Text)
        Me.Settings_Check()
    End Sub
#End Region

#Region "Folder panels - open"
    Private Sub cmdPCSX2AppPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathBin) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathBin)
        Else
            Me.Settings_Check()
        End If
    End Sub

    Private Sub cmdPCSX2IniPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathInis) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathInis)
        Else
            Me.Settings_Check()
        End If
    End Sub

    Private Sub cmdPCSX2SStatePathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathSState) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathSState)
        Else
            Me.Settings_Check()
        End If
    End Sub

    Private Sub cmdPCSX2SnapsPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SnapsPathOpen.Click
        If Directory.Exists(My.Settings.PCSX2_PathSnaps) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathSnaps)
        Else
            Me.Settings_Check()
        End If
    End Sub

    Private Sub cmdSStatesManPicsPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesManPicsPathOpen.Click
        If Directory.Exists(My.Settings.SStatesMan_PathPics) Then
            System.Diagnostics.Process.Start(My.Settings.SStatesMan_PathPics)
        Else
            Me.Settings_Check()
        End If
    End Sub
#End Region

#Region "Theme tab"
    Private Sub LoadSettings_Theme()
        'Theme
        Me.ckbSStatesManThemeImage.Checked = My.Settings.SStatesMan_ThemeImageEnabled
        Me.ckbSStatesManThemeGradient.Checked = My.Settings.SStatesMan_ThemeGradientEnabled

        'Dim tmpObject As Object = Me.pnlThemeOptions.Controls("optTheme" & CInt(mdlTheme.currentThemeSetting))
        'CType(tmpObject, RadioButton).Checked = True

        Select Case mdlTheme.currentThemeSetting
            Case eTheme.squares
                Me.optTheme1.Checked = True
            Case eTheme.noise
                Me.optTheme2.Checked = True
            Case eTheme.stripes_dark
                Me.optTheme3.Checked = True
            Case eTheme.stripes_light
                Me.optTheme4.Checked = True
            Case eTheme.brushedmetal
                Me.optTheme5.Checked = True
            Case eTheme.hexagons
                Me.optTheme6.Checked = True
            Case eTheme.PCSX2
                Me.optTheme11.Checked = True
        End Select

    End Sub

    Private Sub optTheme_CheckedChanged(sender As Object, e As EventArgs) Handles optTheme1.CheckedChanged, optTheme2.CheckedChanged, optTheme3.CheckedChanged, optTheme4.CheckedChanged, optTheme5.CheckedChanged, optTheme6.CheckedChanged, optTheme11.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            Dim tmpTheme As mdlTheme.eTheme
            If [Enum].TryParse(Of eTheme)(CType(sender, RadioButton).Tag.ToString, tmpTheme) Then
                Me.currentSelectedTheme = tmpTheme
            Else
                SSMAppLog.Append(eType.LogError, eSrc.SettingDialog, eSrcMethod.SettingChanged, "Unable to load the specified theme: " & CType(sender, RadioButton).Tag.ToString)
                Me.LoadSettings_Theme()
            End If
            SSMAppLog.Append(eType.LogInformation, eSrc.SettingDialog, eSrcMethod.SettingChanged, "Selected theme changed to: " & Me.currentSelectedTheme.ToString)
        End If
    End Sub
#End Region

#Region "Log tab"
    Private Sub cmdLogRefresh_Click(sender As Object, e As EventArgs) Handles cmdLogRefresh.Click
        Me.Log_Populate(SSMAppLog.Events)
    End Sub

    Private Sub cmiAll_Click(sender As Object, e As System.EventArgs) Handles cmiAll.Click
        Me.Log_Populate(SSMAppLog.Events)
    End Sub

    Private Sub cmdLogExport_Click(sender As Object, e As EventArgs) Handles cmdLogExport.Click
        Using SaveDialog As New SaveFileDialog
            With SaveDialog
                .AddExtension = True
                .CheckFileExists = False
                .CheckPathExists = True
                .DefaultExt = ".txt"
                .Filter = "Text file|*.txt|All files|*.*"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                .OverwritePrompt = True
                .ValidateNames = True
                .FileName = "SStatesMan Log"
                .Title = "Save application log..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                SSMAppLog.ExportFile(SaveDialog.FileName)
            End If

        End Using
    End Sub

    Private Sub Log_Populate(ByVal pLog As List(Of sLog))
        Me.lvwLog.BeginUpdate()
        Me.lvwLog.Items.Clear()
        Dim tmpListItems As New List(Of ListViewItem)
        For Each tmpLogItem As sLog In pLog
            Dim tmpListItem As New ListViewItem With {.Text = tmpLogItem.Time.ToString("H:mm:ss.ff"), .ImageIndex = tmpLogItem.Type + 3}
            tmpListItem.SubItems.AddRange({String.Concat(tmpLogItem.Src.ToString, " > ", tmpLogItem.SrcMethod.ToString), tmpLogItem.Description})
            If tmpLogItem.Duration = -1 Then
                tmpListItem.SubItems.Add("-")
            Else
                tmpListItem.SubItems.Add(String.Format("{0:N2}ms", tmpLogItem.Duration / Stopwatch.Frequency * 1000))
            End If
            tmpListItems.Add(tmpListItem)
        Next
        Me.lvwLog.Items.AddRange(tmpListItems.ToArray)
        Me.lvwLog.EndUpdate()
    End Sub

    Private Sub cmdLogFilter_Click(sender As Object, e As EventArgs) Handles cmdLogFilter.Click
        Me.cmLogFilter.Show(Point.Add(Me.cmdLogFilter.PointToScreen(Me.cmdLogFilter.Location), New Size(0, Me.cmdLogFilter.Size.Height)))
    End Sub

    Private Sub cmiFilter_Click(sender As Object, e As System.EventArgs)
        'Check if the sender is a ToolStripMenuItem, done because Text and Checked are used.
        If GetType(ToolStripMenuItem).Equals(sender.GetType) Then
            'Try to convert the string from the text properties in an enum value.
            Dim tmpESrc As mdlApplicationLog.eSrc
            If [Enum].TryParse(CType(sender, ToolStripMenuItem).Text, tmpESrc) Then
                'Uncheck all others menu items.
                cmLogFilter.SuspendLayout()
                For Each tmpMenuItem As ToolStripMenuItem In cmLogFilter.Items
                    tmpMenuItem.Checked = False
                Next
                'Check only the one needed
                CType(sender, ToolStripMenuItem).Checked = True
                cmLogFilter.ResumeLayout()

                'Applying the filter
                Dim tmpLog As New List(Of sLog)
                SSMAppLog.FilterByClass(tmpESrc, tmpLog)
                Me.Log_Populate(tmpLog)
            End If
        End If
    End Sub
#End Region

#Region "Form - Tabs"
    Private Sub optTabHeader_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader0.CheckedChanged, optTabHeader1.CheckedChanged, optTabHeader2.CheckedChanged, optTabHeader3.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to kwnow 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.optTabHeader0.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader1.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader2.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader3.FlatAppearance.MouseDownBackColor = Color.White

                CType(sender, RadioButton).FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

                Me.pnlTab0.Visible = Me.optTabHeader0.Checked
                Me.pnlTab1.Visible = Me.optTabHeader1.Checked
                Me.pnlTab2.Visible = Me.optTabHeader2.Checked
                Me.pnlTab3.Visible = Me.optTabHeader3.Checked
            End If
        End If
    End Sub
#End Region

#Region "Theme"
    Private Sub pnlTopPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlTopPanel.Paint
        Dim recToolbar As New Rectangle(CInt(8 * DPIxScale), 0, CInt(127 * DPIxScale) + 1, CInt(7 * DPIyScale) + 1)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 0)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If (CType(sender, Panel).Height > 4 * CInt(DPIyScale) + 1) And (CType(sender, Panel).Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                recToolbar = New Rectangle(0, CType(sender, Panel).Height - CInt(4 * DPIyScale), CType(sender, Panel).Width, CInt(3 * DPIyScale) + 1)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
                recToolbar.Y += 1
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, CType(sender, Panel).Height - 1, CType(sender, Panel).Width, CType(sender, Panel).Height - 1)
        End If
    End Sub

    Private Sub flpBottomPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpBottomPanel.Paint
        If CType(sender, Panel).Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, CType(sender, Panel).Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, Panel).Width, 0)
        End If
    End Sub

    Private Sub optTabHeader_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optTabHeader0.Paint, optTabHeader1.Paint, optTabHeader2.Paint, optTabHeader3.Paint
        If CType(sender, RadioButton).Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, RadioButton).Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, CType(sender, RadioButton).Height)
            e.Graphics.DrawLine(Pens.DimGray, CType(sender, RadioButton).Width - 1, 0, CType(sender, RadioButton).Width - 1, CType(sender, RadioButton).Height)
        End If
    End Sub

    Private Sub applyTheme()
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
    End Sub
#End Region
End Class