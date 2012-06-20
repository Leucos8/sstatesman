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
Public Class frmSettings

    Dim TmpSettingsFailTab2 As Boolean = False
    Dim currentSelectedTheme As mdlTheme.eTheme

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.applyTheme()

        Me.ckbFirstRun.Checked = My.Settings.SStatesMan_FirstRun2
        Me.ckb_SStatesListShowOnly.Checked = My.Settings.SStatesMan_SStatesListShowOnly
        Me.ckb_SStatesListAutoRefresh.Checked = My.Settings.SStatesMan_SStatesListAutoRefresh
        Me.ckbSStatesManMoveToTrash.Checked = My.Settings.SStatesMan_SStateTrash
        Me.ckbSStatesManVersionExtract.Checked = My.Settings.SStatesMan_SStatesVersionExtract
        Me.txtSStatesManPicsPath.Text = My.Settings.SStatesMan_PathPics

        Me.txtPCSX2AppPath.Text = My.Settings.PCSX2_PathBin
        Me.txtPCSX2IniPath.Text = My.Settings.PCSX2_PathInis
        Me.txtPCSX2SStatePath.Text = My.Settings.PCSX2_PathSState

        Me.ckbSStatesManBGImage.Checked = My.Settings.SStatesMan_ThemeImageEnabled
        Me.ckbSStatesManBGEnabled.Checked = My.Settings.SStatesMan_ThemeGradientEnabled
        Select Case My.Settings.SStatesMan_Theme
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
            Case Else
                Me.optTheme1.Checked = True
                My.Settings.SStatesMan_Theme = eTheme.squares
        End Select


        Me.SettingsCheck()


        If Not Me.pnlTab1.Dock = DockStyle.Fill Then
            Me.pnlTab1.Dock = DockStyle.Fill
            Me.pnlTab2.Dock = DockStyle.Fill
            Me.pnlTab3.Dock = DockStyle.Fill
            Me.pnlTab4.Dock = DockStyle.Fill
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
            With Me.optSettingTab4
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            Me.pnlTab1.Visible = True
            Me.pnlTab2.Visible = False
            Me.pnlTab3.Visible = False
            Me.pnlTab4.Visible = False
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
            With Me.optSettingTab4
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            Me.pnlTab2.Visible = True
            Me.pnlTab1.Visible = False
            Me.pnlTab3.Visible = False
            Me.pnlTab4.Visible = False
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
            With Me.optSettingTab4
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            Me.pnlTab3.Visible = True
            Me.pnlTab1.Visible = False
            Me.pnlTab2.Visible = False
            Me.pnlTab4.Visible = False
        End If
    End Sub

    Private Sub optSettingTab4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab4.CheckedChanged
        If Me.optSettingTab4.Checked = True Then
            With Me.optSettingTab4
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
            With Me.optSettingTab3
                '.ForeColor = Color.DarkGray
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            Me.pnlTab4.Visible = True
            Me.pnlTab1.Visible = False
            Me.pnlTab2.Visible = False
            Me.pnlTab3.Visible = False
        End If
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        My.Settings.PCSX2_PathBin = Me.txtPCSX2AppPath.Text
        My.Settings.PCSX2_PathInis = Me.txtPCSX2IniPath.Text
        My.Settings.PCSX2_PathSState = Me.txtPCSX2SStatePath.Text

        My.Settings.SStatesMan_PathPics = Me.txtSStatesManPicsPath.Text

        My.Settings.SStatesMan_FirstRun2 = Me.ckbFirstRun.Checked
        My.Settings.SStatesMan_SStatesListShowOnly = Me.ckb_SStatesListShowOnly.Checked
        My.Settings.SStatesMan_SStatesListAutoRefresh = Me.ckb_SStatesListAutoRefresh.Checked
        frmMain.tmrSStatesListRefresh.Enabled = My.Settings.SStatesMan_SStatesListAutoRefresh
        My.Settings.SStatesMan_SStateTrash = Me.ckbSStatesManMoveToTrash.Checked
        My.Settings.SStatesMan_SStatesVersionExtract = Me.ckbSStatesManVersionExtract.Checked

        'My.Settings.SStatesMan_Theme = eTheme.square
        'If Me.optTheme1.Checked Then
        '    My.Settings.SStatesMan_Theme = eTheme.square
        'ElseIf Me.optTheme2.Checked Then
        '    My.Settings.SStatesMan_Theme = eTheme.noise
        'ElseIf Me.optTheme3.Checked Then
        '    My.Settings.SStatesMan_Theme = eTheme.stripes_dark
        'ElseIf Me.optTheme4.Checked Then
        '    My.Settings.SStatesMan_Theme = eTheme.stripes_light
        'ElseIf Me.optTheme5.Checked Then
        '    My.Settings.SStatesMan_Theme = eTheme.brushedmetal
        'ElseIf Me.optTheme11.Checked Then
        '    My.Settings.SStatesMan_Theme = eTheme.PCSX2
        'End If
        My.Settings.SStatesMan_Theme = currentSelectedTheme
        My.Settings.SStatesMan_ThemeImageEnabled = Me.ckbSStatesManBGImage.Checked
        My.Settings.SStatesMan_ThemeGradientEnabled = Me.ckbSStatesManBGEnabled.Checked

        currentTheme = mdlTheme.LoadTheme(My.Settings.SStatesMan_Theme)
        frmMain.applyTheme()


        My.Settings.Save()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        If mdlMain.PCSX2_PathAll_Check Then
            My.Settings.SStatesMan_FirstRun2 = True
            End
        End If
    End Sub

    Private Sub SettingsCheck()
        Dim badChars() As System.Char = {System.Char.Parse(" "), System.Char.Parse("\"), System.Char.Parse("/"), System.Char.Parse(":")}
        Dim invalidChars() As System.Char = {System.Char.Parse(""""), System.Char.Parse("*"), System.Char.Parse("?"), System.Char.Parse("|"), System.Char.Parse("<"), System.Char.Parse(">")}

        Me.cmdOk.Enabled = True
        Me.TmpSettingsFailTab2 = False

        'PCSX2 application path
        Me.txtPCSX2AppPath.Text = Me.txtPCSX2AppPath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtPCSX2AppPath.Text = Me.txtPCSX2AppPath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (System.IO.Directory.Exists(Me.txtPCSX2AppPath.Text)) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("The specified path is not found or inaccessible.", System.Environment.NewLine, _
                                                                 "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2AppPath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2AppPathOpen.Enabled = False

            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Error
            Me.imgPCSX2AppPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True
        ElseIf Not (System.IO.File.Exists(System.IO.Path.Combine(Me.txtPCSX2AppPath.Text, My.Settings.PCSX2_GameDbFilename))) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("Unable to find """, My.Settings.PCSX2_GameDbFilename, """ in the specified path.", System.Environment.NewLine, _
                                                                 "Information about games won't be shown in SStatesMan.")
            Me.tlpPCSX2AppPath.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.cmdPCSX2AppPathOpen.Enabled = False

            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Exclamation
            Me.imgPCSX2AppPathStatus.Visible = True
        Else
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("The folder where SStatesMan will look for """, My.Settings.PCSX2_GameDbFilename, """, usually the folder where PCSX2 is installed.")
            Me.tlpPCSX2AppPath.BackColor = Color.Transparent
            Me.cmdPCSX2AppPathOpen.Enabled = True

            Me.imgPCSX2AppPathStatus.Visible = False
        End If

        'PCSX2 inis path
        Me.txtPCSX2IniPath.Text = Me.txtPCSX2IniPath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtPCSX2IniPath.Text = Me.txtPCSX2IniPath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (System.IO.Directory.Exists(Me.txtPCSX2IniPath.Text)) Then
            Me.lblPCSX2IniPathStatus.Text = System.String.Concat("The specified path is not found or inaccessible.", System.Environment.NewLine, _
                                                                 "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2IniPath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2IniPathOpen.Enabled = False

            Me.imgPCSX2IniPathStatus.Image = My.Resources.Metro_Button_Error
            Me.imgPCSX2IniPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True
        ElseIf Not (System.IO.File.Exists(System.IO.Path.Combine(Me.txtPCSX2IniPath.Text, My.Settings.PCSX2_PCSX2_uiFilename))) Then
            Me.lblPCSX2IniPathStatus.Text = System.String.Concat("Unable to find """, My.Settings.PCSX2_PCSX2_uiFilename, """ in the specified path.", System.Environment.NewLine, _
                                                                 "It may not be the correct PCSX2 ""inis"" folder.")
            Me.tlpPCSX2IniPath.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.cmdPCSX2IniPathOpen.Enabled = False

            Me.imgPCSX2IniPathStatus.Image = My.Resources.Metro_Button_Exclamation
            Me.imgPCSX2IniPathStatus.Visible = True
        Else
            Me.lblPCSX2IniPathStatus.Text = "The folder where SStatesMan will look PCSX2 inis, usually the ""inis"" folder inside PCSX2 user folder."
            Me.tlpPCSX2IniPath.BackColor = Color.Transparent
            Me.cmdPCSX2IniPathOpen.Enabled = True

            Me.imgPCSX2IniPathStatus.Visible = False
        End If

        'PCSX2 savestates path
        Me.txtPCSX2SStatePath.Text = Me.txtPCSX2SStatePath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtPCSX2SStatePath.Text = Me.txtPCSX2SStatePath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (System.IO.Directory.Exists(Me.txtPCSX2SStatePath.Text)) Then
            Me.lblPCSX2SStatePathStatus.Text = System.String.Concat("The specified path is not found or inaccessible.", System.Environment.NewLine, _
                                                                    "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.tlpPCSX2SStatePath.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdPCSX2SStatePathOpen.Enabled = False

            Me.imgPCSX2SStatePathStatus.Image = My.Resources.Metro_Button_Error
            Me.imgPCSX2SStatePathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True
        Else
            Me.lblPCSX2SStatePathStatus.Text = System.String.Format("The folder where SStatesMan will look for the savestates, usually the ""{0}"" folder inside PCSX2 user folder.", My.Settings.PCSX2_SStateFolder)
            Me.tlpPCSX2SStatePath.BackColor = Color.Transparent
            Me.cmdPCSX2SStatePathOpen.Enabled = True


            Me.imgPCSX2SStatePathStatus.Visible = False
        End If

        'SStatesMan cover pics path
        Me.txtSStatesManPicsPath.Text = Me.txtSStatesManPicsPath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtSStatesManPicsPath.Text = Me.txtSStatesManPicsPath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (System.IO.Directory.Exists(Me.txtSStatesManPicsPath.Text)) Then
            'Me.txtSStatesManPicsPath.Text = "Not set"
            'Me.lblSStatesManPicsPathStatus.Text = System.String.Concat("Path not found or inaccessible.", System.Environment.NewLine, _
            '                                                          "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblSStatesManPicsPathStatus.Text = System.String.Concat("The specified path not found or inaccessible.", System.Environment.NewLine, _
                                                                      "Please enter a valid path.")
            Me.tlpSStatesManPicsPath.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.cmdSStatesManPicsPathOpen.Enabled = False
            Me.imgSStatesManPicsPathStatus.Visible = True

            'Me.cmdOk.Enabled = False
        Else
            Me.lblSStatesManPicsPathStatus.Text = System.String.Concat("The folder where SStatesMan will look for the game covers.", System.Environment.NewLine, _
                                                                      "The image file MUST be named <executable code>.jpg to work.")
            Me.tlpSStatesManPicsPath.BackColor = Color.Transparent
            Me.cmdSStatesManPicsPathOpen.Enabled = True
            Me.imgSStatesManPicsPathStatus.Visible = False
        End If




        If Me.TmpSettingsFailTab2 Then
            Me.optSettingTab2.BackColor = Color.FromArgb(255, 255, 192, 192)
        Else
            Me.optSettingTab2.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub txtPCSX2AppPath_LostFocus(sender As Object, e As System.EventArgs) Handles txtPCSX2AppPath.LostFocus
        Me.SettingsCheck()
    End Sub

    Private Sub txtPCSX2IniPath_LostFocus(sender As Object, e As System.EventArgs) Handles txtPCSX2IniPath.LostFocus
        Me.SettingsCheck()
    End Sub

    Private Sub txtPCSX2SStatePath_LostFocus(sender As Object, e As System.EventArgs) Handles txtPCSX2SStatePath.LostFocus
        Me.SettingsCheck()
    End Sub

    Private Sub txtSStatesManPicsPath_LostFocus(sender As Object, e As System.EventArgs) Handles txtSStatesManPicsPath.LostFocus
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2AppPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathBrowse.Click
        Dim FolderPicker As New Windows.Forms.FolderBrowserDialog
        With FolderPicker
            .ShowNewFolderButton = False
            .Description = "Select your PCSX2 executable folder."
            If System.IO.Directory.Exists(Me.txtPCSX2AppPath.Text) Then
                .SelectedPath = Me.txtPCSX2AppPath.Text
            Else : .SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
            End If
        End With

        If FolderPicker.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2AppPath.Text = FolderPicker.SelectedPath
        End If
        FolderPicker.Dispose()
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2SStatePathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathBrowse.Click
        Dim FolderPicker As New Windows.Forms.FolderBrowserDialog
        With FolderPicker
            .ShowNewFolderButton = False
            .Description = "Select your PCSX2 savestates folder."
            If System.IO.Directory.Exists(Me.txtPCSX2SStatePath.Text) Then
                .SelectedPath = Me.txtPCSX2SStatePath.Text
            Else : .SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
        End With

        If FolderPicker.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2SStatePath.Text = FolderPicker.SelectedPath
        End If
        FolderPicker.Dispose()
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2IniPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathBrowse.Click
        Dim FolderPicker As New Windows.Forms.FolderBrowserDialog
        With FolderPicker
            .ShowNewFolderButton = False
            .Description = "Select your PCSX2 ""inis"" folder."
            If System.IO.Directory.Exists(Me.txtPCSX2IniPath.Text) Then
                .SelectedPath = Me.txtPCSX2IniPath.Text
            Else : .SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
        End With

        If FolderPicker.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2IniPath.Text = FolderPicker.SelectedPath
        End If
        FolderPicker.Dispose()
        Me.SettingsCheck()
    End Sub

    Private Sub cmdSStatesManPicsPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesManPicsPathBrowse.Click
        Dim FolderPicker As New Windows.Forms.FolderBrowserDialog
        With FolderPicker
            '.ShowNewFolderButton = False
            .Description = "Select your game cover images folder."
            If System.IO.Directory.Exists(Me.txtSStatesManPicsPath.Text) Then
                .SelectedPath = Me.txtSStatesManPicsPath.Text
            Else : .SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            End If
        End With

        If FolderPicker.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtSStatesManPicsPath.Text = FolderPicker.SelectedPath
        End If
        FolderPicker.Dispose()
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2AppPathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathDetect.Click
        mdlMain.PCSX2_PathBin_Detect(Me.txtPCSX2AppPath.Text)
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2IniPathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathDetect.Click
        mdlMain.PCSX2_PathInis_Detect(Me.txtPCSX2IniPath.Text)
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2SStatePathDetect_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathDetect.Click
        mdlMain.PCSX2_PathSStates_Detect(Me.txtPCSX2SStatePath.Text)
        Me.SettingsCheck()
    End Sub

    Private Sub cmdSStatesManPicsPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStatesManPicsPathOpen.Click
        If System.IO.Directory.Exists(My.Settings.SStatesMan_PathPics) Then
            System.Diagnostics.Process.Start(My.Settings.SStatesMan_PathPics)
        Else
            Me.SettingsCheck()
        End If
    End Sub

    Private Sub cmdPCSX2AppPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathOpen.Click
        If System.IO.Directory.Exists(My.Settings.PCSX2_PathBin) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathBin)
        Else
            Me.SettingsCheck()
        End If
    End Sub

    Private Sub cmdPCSX2IniPathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathOpen.Click
        If System.IO.Directory.Exists(My.Settings.PCSX2_PathInis) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathInis)
        Else
            Me.SettingsCheck()
        End If
    End Sub

    Private Sub cmdPCSX2SStatePathOpen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathOpen.Click
        If System.IO.Directory.Exists(My.Settings.PCSX2_PathSState) Then
            System.Diagnostics.Process.Start(My.Settings.PCSX2_PathSState)
        Else
            Me.SettingsCheck()
        End If
    End Sub

    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim recToolbar As New Rectangle(8 * DPIxScale, 0, 128 * DPIxScale, 8 * DPIyScale)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 0)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If (panelWindowTitle.Height > 4 * DPIyScale) And (panelWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                recToolbar = New Rectangle(0, panelWindowTitle.Height - 4 * DPIyScale, panelWindowTitle.Width, 4 * DPIyScale)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If flpWindowBottom.Height > 4 * DPIyScale Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width, 4 * DPIyScale)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, flpWindowBottom.Width, 0)
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

    Private Sub optSettingTab4_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optSettingTab4.Paint
        If Me.optSettingTab4.Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, Me.optSettingTab4.Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, Me.optSettingTab4.Height)
            e.Graphics.DrawLine(Pens.DimGray, Me.optSettingTab4.Width - 1, 0, Me.optSettingTab4.Width - 1, Me.optSettingTab4.Height)
        End If
    End Sub

    Private Sub applyTheme()
        Me.BackColor = currentTheme.BgColor
        Me.panelWindowTitle.BackColor = currentTheme.BgColorTop
        Me.flpWindowBottom.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.panelWindowTitle.BackgroundImage = currentTheme.BgImageTop
            Me.panelWindowTitle.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpWindowBottom.BackgroundImage = currentTheme.BgImageBottom
            Me.flpWindowBottom.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.panelWindowTitle.BackgroundImage = Nothing
            Me.flpWindowBottom.BackgroundImage = Nothing
        End If
        Me.Refresh()
    End Sub
#Region "Log"
    Private Sub cmdLogRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogRefresh.Click
        Me.ListView1.BeginUpdate()
        Me.ListView1.Items.Clear()
        Dim tmpListItems As New List(Of ListViewItem)
        For i As Integer = 1 To mdlMain.AppLog.Count - 1
            Dim tmpListItem As New ListViewItem With {.Text = AppLog(i).Time.ToString("H.mm.ss")}
            tmpListItem.SubItems.AddRange({String.Concat(AppLog(i).OrClass, ".", AppLog(i).OrMethod), AppLog(i).Description, String.Format("{0:N0}ms", AppLog(i).Duration)})
            tmpListItems.Add(tmpListItem)
        Next
        Me.ListView1.Items.AddRange(tmpListItems.ToArray)
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub cmdLogFilter_GameDB_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogFilter_GameDB.Click
        Me.ListView1.BeginUpdate()
        Me.ListView1.Items.Clear()
        Dim tmpListItems As New List(Of ListViewItem)
        For Each tmpLogItem As mdlMain.sLog In mdlMain.AppLog.Where(Function(tmp) tmp.OrClass = "GameDB")
            Dim tmpListItem As New ListViewItem With {.Text = tmpLogItem.Time.ToString("H.mm.ss")}
            tmpListItem.SubItems.AddRange({String.Concat(tmpLogItem.OrClass, ".", tmpLogItem.OrMethod), tmpLogItem.Description, String.Format("{0:N0}ms", tmpLogItem.Duration)})
            tmpListItems.Add(tmpListItem)
        Next
        Me.ListView1.Items.AddRange(tmpListItems.ToArray)
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub cmdLogFilter_Files_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogFilter_Files.Click
        Me.ListView1.BeginUpdate()
        Me.ListView1.Items.Clear()
        Dim tmpListItems As New List(Of ListViewItem)
        For Each tmpLogItem As mdlMain.sLog In mdlMain.AppLog.Where(Function(tmp) tmp.OrClass = "FilesList")
            Dim tmpListItem As New ListViewItem With {.Text = tmpLogItem.Time.ToString("H.mm.ss")}
            tmpListItem.SubItems.AddRange({String.Concat(tmpLogItem.OrClass, ".", tmpLogItem.OrMethod), tmpLogItem.Description, String.Format("{0:N0}ms", tmpLogItem.Duration)})
            tmpListItems.Add(tmpListItem)
        Next
        Me.ListView1.Items.AddRange(tmpListItems.ToArray)
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub cmdLogFilter_frmMain_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogFilter_frmMain.Click
        Me.ListView1.BeginUpdate()
        Me.ListView1.Items.Clear()
        Dim tmpListItems As New List(Of ListViewItem)
        For Each tmpLogItem As mdlMain.sLog In mdlMain.AppLog.Where(Function(tmp) tmp.OrClass = "frmMain")
            Dim tmpListItem As New ListViewItem With {.Text = tmpLogItem.Time.ToString("H.mm.ss")}
            tmpListItem.SubItems.AddRange({String.Concat(tmpLogItem.OrClass, ".", tmpLogItem.OrMethod), tmpLogItem.Description, String.Format("{0:N0}ms", tmpLogItem.Duration)})
            tmpListItems.Add(tmpListItem)
        Next
        Me.ListView1.Items.AddRange(tmpListItems.ToArray)
        Me.ListView1.EndUpdate()
    End Sub
#End Region

#Region "Theme options"
    Private Sub optTheme1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme1.CheckedChanged
        If optTheme1.Checked Then
            Me.currentSelectedTheme = eTheme.squares
        End If
    End Sub

    Private Sub optTheme2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme2.CheckedChanged
        If optTheme2.Checked Then
            Me.currentSelectedTheme = eTheme.noise
        End If
    End Sub

    Private Sub optTheme3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme3.CheckedChanged
        If optTheme3.Checked Then
            Me.currentSelectedTheme = eTheme.stripes_dark
        End If
    End Sub

    Private Sub optTheme4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme4.CheckedChanged
        If optTheme4.Checked Then
            Me.currentSelectedTheme = eTheme.stripes_light
        End If
    End Sub

    Private Sub optTheme5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme5.CheckedChanged
        If optTheme5.Checked Then
            Me.currentSelectedTheme = eTheme.brushedmetal
        End If
    End Sub

    Private Sub optTheme6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme6.CheckedChanged
        If optTheme6.Checked Then
            Me.currentSelectedTheme = eTheme.hexagons
        End If
    End Sub

    Private Sub optTheme11_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTheme11.CheckedChanged
        If optTheme11.Checked Then
            Me.currentSelectedTheme = eTheme.PCSX2
        End If
    End Sub
#End Region
End Class