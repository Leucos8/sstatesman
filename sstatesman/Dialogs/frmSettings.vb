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
Public Class frmSettings

    Dim TmpSettingsFailTab2 As Boolean = False
    Dim disablePaintUpdate As Boolean = False

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.ckbFirstRun.Checked = My.Settings.SStatesMan_FirstRun2
        Me.ckb_SStatesListShowOnly.Checked = My.Settings.SStatesMan_SStatesListShowOnly
        Me.ckb_SStatesListAutoRefresh.Checked = My.Settings.SStatesMan_SStatesListAutoRefresh
        Me.ckbSStatesManMoveToTrash.Checked = My.Settings.SStatesMan_SStateTrash
        Me.txtSStatesManPicsPath.Text = My.Settings.SStatesMan_PathPics

        Me.txtPCSX2AppPath.Text = My.Settings.PCSX2_PathBin
        Me.txtPCSX2IniPath.Text = My.Settings.PCSX2_PathInis
        Me.txtPCSX2SStatePath.Text = My.Settings.PCSX2_PathSState

        Select Case My.Settings.SStatesMan_BGImage
            Case Theme.square
                Me.ckbSStatesManBGImage.Checked = True
                Me.optTheme1.Checked = True
            Case Theme.noise
                Me.ckbSStatesManBGImage.Checked = True
                Me.optTheme2.Checked = True
            Case Theme.stripes
                Me.ckbSStatesManBGImage.Checked = True
                Me.optTheme3.Checked = True
            Case Theme.PCSX2
                Me.ckbSStatesManBGImage.Checked = True
                Me.optTheme11.Checked = True
            Case Else
                My.Settings.SStatesMan_BGImage = Theme.none
                Me.ckbSStatesManBGImage.Checked = False
                Me.pnlThemeOptions.Enabled = False
        End Select

        Me.ckbSStatesManBGEnabled.Checked = My.Settings.SStatesMan_BGEnable

        Me.SettingsCheck()



        Select Case My.Settings.SStatesMan_BGImage
            Case Theme.square
                Me.panelWindowTitle.BackgroundImage = My.Resources.BG
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.None
                Me.flpWindowBottom.BackgroundImage = Nothing
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.None
            Case Theme.noise
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgNoise
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                Me.flpWindowBottom.BackgroundImage = My.Resources.BgNoise
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.stripes
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgStripes
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                Me.flpWindowBottom.BackgroundImage = My.Resources.BgStripes
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.PCSX2
                Me.panelWindowTitle.BackgroundImage = My.Resources.BG_PCSX2
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Stretch
                Me.flpWindowBottom.BackgroundImage = My.Resources.BG_PCSX2
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Stretch
            Case Else
                My.Settings.SStatesMan_BGImage = Theme.none
                Me.panelWindowTitle.BackgroundImage = Nothing
                Me.flpWindowBottom.BackgroundImage = Nothing
        End Select

        If Not Me.pnlTab1.Dock = DockStyle.Fill Then
            Me.pnlTab1.Dock = DockStyle.Fill
            Me.pnlTab2.Dock = DockStyle.Fill
            Me.pnlTab3.Dock = DockStyle.Fill
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
            Me.pnlTab1.Visible = True
            Me.pnlTab2.Visible = False
            Me.pnlTab3.Visible = False
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
            Me.pnlTab2.Visible = True
            Me.pnlTab1.Visible = False
            Me.pnlTab3.Visible = False
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
            Me.pnlTab3.Visible = True
            Me.pnlTab1.Visible = False
            Me.pnlTab2.Visible = False
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

        My.Settings.SStatesMan_BGImage = Theme.none
        If Me.ckbSStatesManBGImage.Checked Then
            If Me.optTheme1.Checked Then
                My.Settings.SStatesMan_BGImage = Theme.square
            ElseIf Me.optTheme2.Checked Then
                My.Settings.SStatesMan_BGImage = Theme.noise
            ElseIf Me.optTheme3.Checked Then
                My.Settings.SStatesMan_BGImage = Theme.stripes
            ElseIf Me.optTheme11.Checked Then
                My.Settings.SStatesMan_BGImage = Theme.PCSX2
            End If
        End If

        My.Settings.SStatesMan_BGEnable = Me.ckbSStatesManBGEnabled.Checked



        Select Case My.Settings.SStatesMan_BGImage
            Case Theme.square
                frmMain.panelWindowTitle.BackgroundImage = My.Resources.BG
                frmMain.panelWindowTitle.BackgroundImageLayout = ImageLayout.None
            Case Theme.noise
                frmMain.panelWindowTitle.BackgroundImage = My.Resources.BgNoise
                frmMain.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.stripes
                frmMain.panelWindowTitle.BackgroundImage = My.Resources.BgStripes
                frmMain.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.PCSX2
                frmMain.panelWindowTitle.BackgroundImage = My.Resources.BG_PCSX2
                frmMain.panelWindowTitle.BackgroundImageLayout = ImageLayout.Stretch
            Case Else
                My.Settings.SStatesMan_BGImage = Theme.none
                frmMain.panelWindowTitle.BackgroundImage = Nothing
        End Select
        frmMain.Refresh()

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
        Dim recToolbar As New Rectangle(8, 0, 128, 8)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.FromArgb(130, 150, 200), Color.FromArgb(65, 74, 100), 0)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If My.Settings.SStatesMan_BGEnable Then
            recToolbar = New Rectangle(0, panelWindowTitle.Height - 4, panelWindowTitle.Width, 4)
            linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
            e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        End If
        e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
    End Sub

    Private Sub flpWindowBottom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If disablePaintUpdate = False Then
            If My.Settings.SStatesMan_BGEnable Then
                Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width, 4)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                'Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.FromArgb(130, 150, 200), Color.Transparent, 90)
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

    Private Sub ckbSStatesManBGImage_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbSStatesManBGImage.CheckedChanged
        Me.pnlThemeOptions.Enabled = ckbSStatesManBGImage.Checked
    End Sub
End Class