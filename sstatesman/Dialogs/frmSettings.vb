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
Public NotInheritable Class frmSettings

    Friend currentTab As Integer = 0
    Dim tmpTab2SettingsFail As Boolean = False
    Dim currentSelectedTheme As mdlTheme.eTheme
    Dim GameListNeedRefresh As Boolean = False

#Region "Settings management"
    Private Sub Settings_Load()
        'General options
        Me.ckbFirstRun.Checked = My.Settings.SStatesMan_FirstRun
        Me.ckb_SStatesListShowOnly.Checked = My.Settings.SStatesMan_SStatesListShowOnly
        Me.ckb_SStatesListAutoRefresh.Checked = My.Settings.SStatesMan_SStatesListAutoRefresh
        'Savestates management
        Me.ckbSStatesManMoveToTrash.Checked = My.Settings.SStatesMan_FileTrash
        Me.ckbSStatesManVersionExtract.Checked = My.Settings.SStatesMan_SStatesVersionExtract
        'SStatesMan folders
        Me.fppSStatesManPicsPath.Text = My.Settings.SStatesMan_PathPics
        Me.fppSStatesManStoredPath.Text = My.Settings.SStatesMan_PathStored
        Me.fppSStatesManIsoPath.Text = My.Settings.SStatesMan_PathIso

        'PCSX2 folders
        Me.fppPCSX2AppPath.Text = My.Settings.PCSX2_PathBin
        Me.fppPCSX2IniPath.Text = My.Settings.PCSX2_PathInis
        Me.fppPCSX2SStatePath.Text = My.Settings.PCSX2_PathSState
        Me.fppPCSX2SnapsPath.Text = My.Settings.PCSX2_PathSnaps

        Me.Settings_LoadTheme()

        SSMAppLog.Append(eType.LogInformation, eSrc.SettingDialog, eSrcMethod.Load, "Settings loaded.")
    End Sub

    Private Sub Settings_Apply()

        If Not (My.Settings.PCSX2_PathSState = Me.fppPCSX2SStatePath.Text And _
                My.Settings.PCSX2_PathSnaps = Me.fppPCSX2SnapsPath.Text And _
                My.Settings.SStatesMan_PathPics = Me.fppSStatesManPicsPath.Text And _
                My.Settings.SStatesMan_PathStored = Me.fppSStatesManStoredPath.Text And _
                My.Settings.SStatesMan_PathIso = Me.fppSStatesManIsoPath.Text) Then
            GameListNeedRefresh = True
        Else
            GameListNeedRefresh = False
        End If

        'General options
        My.Settings.SStatesMan_FirstRun = Me.ckbFirstRun.Checked
        My.Settings.SStatesMan_SStatesListShowOnly = Me.ckb_SStatesListShowOnly.Checked
        My.Settings.SStatesMan_SStatesListAutoRefresh = Me.ckb_SStatesListAutoRefresh.Checked
        'Savestates management
        My.Settings.SStatesMan_FileTrash = Me.ckbSStatesManMoveToTrash.Checked
        My.Settings.SStatesMan_SStatesVersionExtract = Me.ckbSStatesManVersionExtract.Checked
        'SStatesMan folders
        My.Settings.SStatesMan_PathPics = Me.fppSStatesManPicsPath.Text
        My.Settings.SStatesMan_PathStored = Me.fppSStatesManStoredPath.Text
        My.Settings.SStatesMan_PathIso = Me.fppSStatesManIsoPath.Text

        'PCSX2 folders
        My.Settings.PCSX2_PathBin = Me.fppPCSX2AppPath.Text
        My.Settings.PCSX2_PathInis = Me.fppPCSX2IniPath.Text
        My.Settings.PCSX2_PathSState = Me.fppPCSX2SStatePath.Text
        My.Settings.PCSX2_PathSnaps = Me.fppPCSX2SnapsPath.Text

        'Theme
        My.Settings.SStatesMan_ThemeImageEnabled = Me.ckbSStatesManThemeImage.Checked
        My.Settings.SStatesMan_ThemeGradientEnabled = Me.ckbSStatesManThemeGradient.Checked
        My.Settings.SStatesMan_Theme = currentSelectedTheme.ToString

        My.Settings.Save()

        'Getting things ready
        mdlTheme.LoadTheme(currentSelectedTheme.ToString)

        'Me.applyTheme()

        'frmMain
        If frmMain.IsShown Then
            frmMain.applyTheme()    'Updating frmMain theme
            If Me.GameListNeedRefresh Then
                frmMain.GameList_Refresh()
                GameListNeedRefresh = False
            End If
            frmMain.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh   'Enabling the timer
        End If

        SSMAppLog.Append(eType.LogInformation, eSrc.SettingDialog, eSrcMethod.Load, "Settings applied.")
    End Sub

    Private Sub Settings_Check()


        If fppPCSX2AppPath.State = ucFolderPickerPanel.eDescState.StateError Or _
           fppPCSX2IniPath.State = ucFolderPickerPanel.eDescState.StateError Or _
           fppPCSX2SStatePath.State = ucFolderPickerPanel.eDescState.StateError Or _
           fppPCSX2SnapsPath.State = ucFolderPickerPanel.eDescState.StateError Then

            Me.cmdOk.Enabled = False
            Me.cmdApply.Enabled = False
            Me.tmpTab2SettingsFail = True
            Me.optTabHeader1.BackColor = Color.FromArgb(255, 255, 192, 192)

        Else

            Me.cmdOk.Enabled = True
            Me.cmdApply.Enabled = True
            Me.tmpTab2SettingsFail = False
            Me.optTabHeader1.BackColor = Color.Transparent

        End If
        SSMAppLog.Append(eType.LogInformation, eSrc.SettingDialog, eSrcMethod.Load, "Settings checked.")
    End Sub
#End Region

#Region "Form"
    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.pnlWindowTop.Controls.Add(Me.flpTab)
        Me.flpTab.Dock = DockStyle.Bottom
        Me.flpWindowBottom.Controls.AddRange({cmdApply, cmdCancel, cmdOk})

        Me.pnlTab0.Dock = DockStyle.Fill
        Me.pnlTab1.Dock = DockStyle.Fill
        Me.pnlTab2.Dock = DockStyle.Fill
        Me.pnlTab3.Dock = DockStyle.Fill

        Select Case currentTab
            Case 0
                Me.optTabHeader0.Checked = True
            Case 1
                Me.optTabHeader1.Checked = True
            Case 2
                Me.optTabHeader2.Checked = True
            Case 3
                Me.optTabHeader3.Checked = True
            Case Else
                Me.optTabHeader0.Checked = True
        End Select

        Me.pnlTab0.Visible = Me.optTabHeader0.Checked
        Me.pnlTab1.Visible = Me.optTabHeader1.Checked
        Me.pnlTab2.Visible = Me.optTabHeader2.Checked
        Me.pnlTab3.Visible = Me.optTabHeader3.Checked

        Me.fppMessagesSetup()

        Me.Settings_Load()
        Me.Settings_Check()

        '===
        'Log
        '===
        Me.lvwLog.SmallImageList = imlLvwItemIcons

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
        My.Settings.SStatesMan_SettingsOK = PCSX2_PathAll_Check(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_PathInis, _
                                                                 My.Settings.PCSX2_PathSState, My.Settings.PCSX2_PathSnaps)
        If Not (My.Settings.SStatesMan_SettingsOK) Then
            MessageBox.Show("Not all the required settings for SStatesMan to work are valid. SStatesMan will now be closed.", "SStatesMan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            My.Settings.SStatesMan_FirstRun = True
            End
        End If

        Me.Close()
    End Sub
#End Region

#Region "Theme tab"
    Private Sub Settings_LoadTheme()
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
                Me.Settings_LoadTheme()
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
    Private Sub optTabHeader_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optTabHeader0.Paint, optTabHeader1.Paint, optTabHeader2.Paint, optTabHeader3.Paint
        If CType(sender, RadioButton).Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, RadioButton).Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, CType(sender, RadioButton).Height)
            e.Graphics.DrawLine(Pens.DimGray, CType(sender, RadioButton).Width - 1, 0, CType(sender, RadioButton).Width - 1, CType(sender, RadioButton).Height)
        End If
    End Sub
#End Region

#Region "Folder Picker Panels"
    'This sub will set the description message for each FolderPickerPanels in the settings dialog.
    Private Sub fppMessagesSetup()
        Me.fppPCSX2AppPath.DescriptionInfo = String.Concat("The folder where PCSX2 is installed. ", My.Application.Info.Title, " will try to load ", My.Settings.PCSX2_GameDbFilename, " from this location.")
        Me.fppPCSX2AppPath.DescriptionWarning = String.Concat("Unable to find """, My.Settings.PCSX2_GameDbFilename, """ in the specified path.", Environment.NewLine, "Game information (title, region, etc.) won't be shown.")
        Me.fppPCSX2AppPath.DescriptionError = String.Concat("Path not found or inaccessible.", Environment.NewLine, "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
        Me.fppPCSX2AppPath.FBDDescription = "Select your PCSX2 application folder."

        Me.fppPCSX2IniPath.DescriptionInfo = String.Concat("The folder where ", My.Application.Info.Title, " will look for your PCSX2 configuration files, usually the ""inis"" folder inside PCSX2 user folder.")
        Me.fppPCSX2IniPath.DescriptionWarning = String.Concat("Unable to find """, My.Settings.PCSX2_PCSX2_uiFilename, """ in the specified path.", Environment.NewLine, "Maybe it's not the correct PCSX2 ""inis"" folder?")
        Me.fppPCSX2IniPath.DescriptionError = String.Concat("Path not found or inaccessible.", Environment.NewLine, "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
        Me.fppPCSX2IniPath.FBDDescription = "Select your PCSX2 ""inis"" folder."

        Me.fppPCSX2SStatePath.DescriptionInfo = String.Concat("The folder where ", My.Application.Info.Title, " will look for your savestates files, usually the """, My.Settings.PCSX2_SStateFolder, """ folder inside your PCSX2 user folder.")
        Me.fppPCSX2SStatePath.DescriptionError = String.Concat("The specified path is not found or inaccessible.", Environment.NewLine, "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
        Me.fppPCSX2SStatePath.FBDDescription = "Select your PCSX2 savestates folder."

        Me.fppPCSX2SnapsPath.DescriptionInfo = String.Concat("The folder where ", My.Application.Info.Title, " will look for your screenshots files, usually the """, My.Settings.PCSX2_SnapsFolder, """ folder inside your PCSX2 user folder.")
        Me.fppPCSX2SnapsPath.DescriptionError = String.Concat("Path not found or inaccessible.", Environment.NewLine, "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
        Me.fppPCSX2SnapsPath.FBDDescription = "Select your PCSX2 screenshots folder."

        Me.fppSStatesManPicsPath.DescriptionInfo = String.Concat("The folder where ", My.Application.Info.Title, " will try to load game covers from.", Environment.NewLine, "The image files MUST be named <executable code>.jpg for each game.")
        Me.fppSStatesManPicsPath.DescriptionWarning = String.Concat("Path not found or inaccessible.", Environment.NewLine, "Please enter a valid path.")
        Me.fppSStatesManPicsPath.FBDDescription = "Select your game cover images folder."

        Me.fppSStatesManStoredPath.DescriptionInfo = String.Concat("The folder where ", My.Application.Info.Title, " will move the savestates you want to keep safe so that they aren't overwritten by PCSX2.")
        Me.fppSStatesManStoredPath.DescriptionWarning = String.Concat("Path not found or inaccessible.", Environment.NewLine, "Please enter a valid path.")
        Me.fppSStatesManStoredPath.FBDDescription = "Select where your stored savestates will be moved."

        Me.fppSStatesManIsoPath.DescriptionInfo = String.Concat("The folder where ", My.Application.Info.Title, " will look for your game disc image files.", Environment.NewLine, "Valid filenames examples: ""SLES-#####.iso"", ""GameName [SLES-#####].iso"".")
        Me.fppSStatesManIsoPath.DescriptionWarning = String.Concat("Path not found or inaccessible.", Environment.NewLine, "Please enter a valid path.")
        Me.fppSStatesManIsoPath.FBDDescription = "Select your game iso image files folder."
    End Sub

    'Detect button
    Private Sub fppPCSX2AppPath_DetectFolder(sender As Object, e As EventArgs) Handles fppPCSX2AppPath.DetectFolder
        PCSX2_PathBin_Detect(CType(sender, ucFolderPickerPanel).Text)
    End Sub

    Private Sub fppPCSX2IniPath_DetectFolder(sender As Object, e As EventArgs) Handles fppPCSX2IniPath.DetectFolder
        PCSX2_PathInis_Detect(Me.fppPCSX2AppPath.Text, CType(sender, ucFolderPickerPanel).Text)
    End Sub

    Private Sub fppPCSX2SStateSnapsPath_DetectFolder(sender As Object, e As EventArgs) _
        Handles fppPCSX2SStatePath.DetectFolder, fppPCSX2SnapsPath.DetectFolder

        PCSX2_PathSettings_Detect(Me.fppPCSX2AppPath.Text, Me.fppPCSX2IniPath.Text, Me.fppPCSX2SStatePath.Text, Me.fppPCSX2SnapsPath.Text)
    End Sub

    'These subs provide a custom setting check o determine the FolderPickerPanel state: error, warning, idle
    Private Sub fppPCSX2AppPath_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) _
        Handles fppPCSX2AppPath.Validating

        Try
            If Not (Directory.Exists(CType(sender, ucFolderPickerPanel).Text)) Then
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateError
            ElseIf Not (File.Exists(Path.Combine(CType(sender, ucFolderPickerPanel).Text, My.Settings.PCSX2_GameDbFilename))) Then
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateWarning
            Else
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateIdle
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateError
        End Try
    End Sub

    Private Sub fppPCSX2IniPath_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) _
        Handles fppPCSX2IniPath.Validating

        Try
            If Not (Directory.Exists(CType(sender, ucFolderPickerPanel).Text)) Then
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateError
            ElseIf Not (File.Exists(Path.Combine(CType(sender, ucFolderPickerPanel).Text, My.Settings.PCSX2_PCSX2_uiFilename))) Then
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateWarning
            Else
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateIdle
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateError
        End Try
    End Sub

    Private Sub fppPCSX2SStatesSnapsPath_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) _
        Handles fppPCSX2SStatePath.Validating, fppPCSX2SnapsPath.Validating
        Try
            If Not (Directory.Exists(CType(sender, ucFolderPickerPanel).Text)) Then
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateError
            Else
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateIdle
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateError
        End Try
    End Sub

    Private Sub fppSStatesManPath_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) _
        Handles fppSStatesManPicsPath.Validating, fppSStatesManStoredPath.Validating, fppSStatesManIsoPath.Validating
        Try
            If Not (Directory.Exists(CType(sender, ucFolderPickerPanel).Text)) Then
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateWarning
            Else
                CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateIdle
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CType(sender, ucFolderPickerPanel).State = ucFolderPickerPanel.eDescState.StateIdle
        End Try
    End Sub

    Private Sub fpp_Validated(sender As Object, e As EventArgs) _
        Handles fppPCSX2AppPath.Validated, fppPCSX2IniPath.Validated, fppPCSX2SStatePath.Validated, _
        fppPCSX2SnapsPath.Validated, fppSStatesManPicsPath.Validated, fppSStatesManStoredPath.Validated, _
        fppSStatesManIsoPath.Validated

        Me.Settings_Check()
    End Sub
#End Region
End Class