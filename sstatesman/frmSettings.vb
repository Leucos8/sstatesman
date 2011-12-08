'   SStatesMan - a savestate managing tool for PCSX2
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
Public Class frmSettings
    'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '    Get
    '        Dim param As CreateParams = MyBase.CreateParams
    '        param.ClassStyle += CS_DROPSHADOW
    '        Return param
    '    End Get
    'End Property

    Dim TmpSettingsFailTab2 As Boolean = False

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.SSM1
        Me.Size = Me.MinimumSize
        Me.panelTab2.Location = Me.panelTab1.Location

        Me.txtPCSX2AppPath.Text = My.Settings.PCSX2_PathBin
        Me.txtPCSX2IniPath.Text = My.Settings.PCSX2_PathInis
        Me.txtPCSX2SStatePath.Text = My.Settings.PCSX2_PathSState
        Me.txtSStateManPicsPath.Text = My.Settings.SStateMan_PathPics
        Me.ckbFirstRun.Checked = My.Settings.SStateMan_FirstRun2
        Me.ckbSStatesManMoveToTrash.Checked = My.Settings.SStateMan_SStateTrash
        Me.ckbSStatesManBGEnabled.Checked = Not (My.Settings.SStateMan_BGEnable)

        Me.SettingsCheck()
    End Sub

    Private Sub frmSettings_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If My.Settings.SStateMan_BGEnable Then
            Dim linGrBrush As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 150), Color.Gainsboro, Color.White)
            Dim linGrBrush2 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 150), New Point(0, Me.ClientSize.Height), Color.White, Color.Gainsboro)
            Dim linGrBrush3 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            Dim linGrBrush4 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.LightGray, Color.Transparent)
            'Dim linGrBrush5 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 12), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrush, 0, 0, Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush2, 0, CInt(Me.ClientSize.Height - 150), Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush3, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            e.Graphics.FillRectangle(linGrBrush4, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, 12)
            e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
            e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
            'e.Graphics.FillRectangle(linGrBrush5, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance, Me.ClientSize.Width, 12)

        End If
        e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, Me.ClientSize.Height)
        e.Graphics.DrawLine(Pens.DimGray, 0, 0, Me.ClientSize.Width, 0)
        e.Graphics.DrawLine(Pens.DimGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        e.Graphics.DrawLine(Pens.DimGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        My.Settings.PCSX2_PathBin = Me.txtPCSX2AppPath.Text
        My.Settings.PCSX2_PathInis = Me.txtPCSX2IniPath.Text
        My.Settings.PCSX2_PathSState = Me.txtPCSX2SStatePath.Text

        My.Settings.SStateMan_PathPics = Me.txtSStateManPicsPath.Text

        My.Settings.SStateMan_SStateTrash = Me.ckbSStatesManMoveToTrash.Checked
        My.Settings.SStateMan_FirstRun2 = Me.ckbFirstRun.Checked

        My.Settings.SStateMan_BGEnable = Not (Me.ckbSStatesManBGEnabled.Checked)
        frmMain.Refresh()

        My.Settings.SStateMan_SettingFail = False
        My.Settings.Save()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        If My.Settings.SStateMan_SettingFail = True Then
            My.Settings.SStateMan_FirstRun2 = True
            End
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

    Private Sub txtSStateManPicsPath_LostFocus(sender As Object, e As System.EventArgs) Handles txtSStateManPicsPath.LostFocus
        Me.SettingsCheck()
    End Sub

    Private Sub SettingsCheck()
        Dim badChars() As System.Char = {" ", "\", "/", ":"}
        Dim invalidChars() As System.Char = {"""", "*", "?", "|", "<", ">"}

        Me.cmdOk.Enabled = True
        Me.TmpSettingsFailTab2 = False

        Me.txtPCSX2AppPath.Text = Me.txtPCSX2AppPath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtPCSX2AppPath.Text = Me.txtPCSX2AppPath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2AppPath.Text)) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("Path not found or inaccessible.", vbCrLf, _
                                                                 "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.lblPCSX2AppPathStatus.Left = Me.imgPCSX2AppPathStatus.Left + Me.imgPCSX2AppPathStatus.Width
            Me.lblPCSX2AppPathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2AppPathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2AppPathDetect.Left) + 6)

            Me.imgPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192) 'Red
            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Error
            Me.imgPCSX2AppPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True
            'My.Settings.SStateMan_SettingFail = True
        ElseIf Not (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Me.txtPCSX2AppPath.Text, My.Settings.PCSX2_GameDbFilename))) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("Unable to find """, My.Settings.PCSX2_GameDbFilename, """ in the specified path.", vbCrLf, _
                                                                 "Game info will not be shown in SStatesMan windows.")
            Me.lblPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.lblPCSX2AppPathStatus.Left = Me.imgPCSX2AppPathStatus.Left + Me.imgPCSX2AppPathStatus.Width
            Me.lblPCSX2AppPathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2AppPathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2AppPathDetect.Left) + 6)

            Me.imgPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192) 'yellow
            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Exclamation
            Me.imgPCSX2AppPathStatus.Visible = True
        Else
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("Where SStatesMan will look for """, My.Settings.PCSX2_GameDbFilename, """, usually the folder where PCSX2 is installed.")
            Me.lblPCSX2AppPathStatus.BackColor = Color.Transparent
            Me.lblPCSX2AppPathStatus.Left = Me.imgPCSX2AppPathStatus.Left
            Me.lblPCSX2AppPathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2AppPathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2AppPathDetect.Left) + 6)

            Me.imgPCSX2AppPathStatus.Visible = False
        End If


        Me.txtPCSX2IniPath.Text = Me.txtPCSX2IniPath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtPCSX2IniPath.Text = Me.txtPCSX2IniPath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2IniPath.Text)) Then
            Me.lblPCSX2IniPathStatus.Text = System.String.Concat("Path not found or inaccessible.", vbCrLf, _
                                                                 "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.lblPCSX2IniPathStatus.Left = Me.imgPCSX2IniPathStatus.Left + Me.imgPCSX2IniPathStatus.Width
            Me.lblPCSX2IniPathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2IniPathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2IniPathDetect.Left) + 6)

            Me.imgPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Error
            Me.imgPCSX2IniPathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True
        ElseIf Not (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Me.txtPCSX2IniPath.Text, My.Settings.PCSX2_PCSX2_uiFilename))) Then
            Me.lblPCSX2IniPathStatus.Text = System.String.Concat("Unable to find """, My.Settings.PCSX2_PCSX2_uiFilename, """ in the specified path.", vbCrLf, _
                                                                 "It may not be the correct PCSX2 ""inis"" folder.")
            Me.lblPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.lblPCSX2IniPathStatus.Left = Me.imgPCSX2IniPathStatus.Left + Me.imgPCSX2IniPathStatus.Width
            Me.lblPCSX2IniPathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2IniPathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2IniPathDetect.Left) + 6)

            Me.imgPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Exclamation
            Me.imgPCSX2IniPathStatus.Visible = True
        Else
            Me.lblPCSX2IniPathStatus.Text = "Where SStatesMan will look PCSX2 inis, usually the ""inis"" folder inside PCSX2 user folder."
            Me.lblPCSX2IniPathStatus.BackColor = Color.Transparent
            Me.lblPCSX2IniPathStatus.Left = Me.imgPCSX2IniPathStatus.Left
            Me.lblPCSX2IniPathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2IniPathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2IniPathDetect.Left) + 6)

            Me.imgPCSX2IniPathStatus.Visible = False
        End If


        Me.txtPCSX2SStatePath.Text = Me.txtPCSX2SStatePath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtPCSX2SStatePath.Text = Me.txtPCSX2SStatePath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2SStatePath.Text)) Then
            Me.lblPCSX2SStatePathStatus.Text = System.String.Concat("Path not found or inaccessible.", vbCrLf, _
                                                                    "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblPCSX2SStatePathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.lblPCSX2SStatePathStatus.Left = Me.imgPCSX2SStatePathStatus.Left + Me.imgPCSX2SStatePathStatus.Width
            Me.lblPCSX2SStatePathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2SStatePathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2SStatePathDetect.Left) + 6)

            Me.imgPCSX2SStatePathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Error
            Me.imgPCSX2SStatePathStatus.Visible = True

            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True
        Else
            Me.lblPCSX2SStatePathStatus.Text = System.String.Format("Where SStatesMan will look for the savestates, usually the ""{0}"" folder inside PCSX2 user folder.", My.Settings.PCSX2_SStateFolder)
            Me.lblPCSX2SStatePathStatus.BackColor = Color.Transparent
            Me.lblPCSX2SStatePathStatus.Left = Me.imgPCSX2SStatePathStatus.Left
            Me.lblPCSX2SStatePathStatus.Width = Me.panelTab2.Width - (Me.lblPCSX2SStatePathStatus.Left + (Me.panelTab2.Width - Me.cmdPCSX2SStatePathDetect.Left) + 6)


            Me.imgPCSX2SStatePathStatus.Visible = False
        End If


        Me.txtSStateManPicsPath.Text = Me.txtSStateManPicsPath.Text.Trim(badChars)
        For i As System.Int32 = 0 To invalidChars.Length - 1
            Me.txtSStateManPicsPath.Text = Me.txtSStateManPicsPath.Text.Replace(invalidChars(i), "_")
        Next i
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtSStateManPicsPath.Text)) Then
            Me.txtSStateManPicsPath.Text = "Not set"
            'Me.lblSStateManPicsPathStatus.Text = System.String.Concat("Path not found or inaccessible.", vbCrLf, _
            '                                                          "Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblSStateManPicsPathStatus.Text = System.String.Concat("Path not found or inaccessible.", vbCrLf, _
                                                                      "Please enter a valid path.")
            Me.lblSStateManPicsPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.lblSStateManPicsPathStatus.Left = Me.imgSStateManPicsPathStatus.Left + Me.imgSStateManPicsPathStatus.Width
            Me.lblSStateManPicsPathStatus.Width = Me.panelTab1.Width - (Me.lblSStateManPicsPathStatus.Left + (Me.panelTab1.Width - Me.cmdSStateManPicsPathBrowse.Left) + 6)

            Me.imgSStateManPicsPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.imgPCSX2AppPathStatus.Image = My.Resources.Metro_Button_Exclamation
            Me.imgSStateManPicsPathStatus.Visible = True

            'Me.cmdOk.Enabled = False
        Else
            Me.lblSStateManPicsPathStatus.Text = System.String.Concat("Where SStatesMan will look for the game cover images.", vbCrLf, _
                                                                      "The cover image file MUST be named <executable code>.jpg to work.")
            Me.lblSStateManPicsPathStatus.BackColor = Color.Transparent
            Me.lblSStateManPicsPathStatus.Left = Me.imgSStateManPicsPathStatus.Left
            Me.lblSStateManPicsPathStatus.Width = Me.panelTab1.Width - (Me.lblSStateManPicsPathStatus.Left + (Me.panelTab1.Width - Me.cmdSStateManPicsPathBrowse.Left) + 6)

            Me.imgSStateManPicsPathStatus.Visible = False
        End If




        If Me.TmpSettingsFailTab2 Then
            Me.optStettingTab2.BackColor = Color.FromArgb(255, 255, 192, 192)
        Else
            Me.optStettingTab2.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub cmdPCSX2AppPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathBrowse.Click
        Dim FolderPicker As New Windows.Forms.FolderBrowserDialog
        With FolderPicker
            .ShowNewFolderButton = False
            .Description = "Select your PCSX2 executable folder."
            If My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2AppPath.Text) Then
                .SelectedPath = Me.txtPCSX2AppPath.Text
            Else : .SelectedPath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
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
            If My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2SStatePath.Text) Then
                .SelectedPath = Me.txtPCSX2SStatePath.Text
            Else : .SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
        End With

        If FolderPicker.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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
            If My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2IniPath.Text) Then
                .SelectedPath = Me.txtPCSX2IniPath.Text
            Else : .SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
        End With

        If FolderPicker.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2IniPath.Text = FolderPicker.SelectedPath
        End If
        FolderPicker.Dispose()
        Me.SettingsCheck()
    End Sub

    Private Sub cmdSStateManPicsPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateManPicsPathBrowse.Click
        Dim FolderPicker As New Windows.Forms.FolderBrowserDialog
        With FolderPicker
            '.ShowNewFolderButton = False
            .Description = "Select your game cover images folder."
            If My.Computer.FileSystem.DirectoryExists(Me.txtSStateManPicsPath.Text) Then
                .SelectedPath = Me.txtSStateManPicsPath.Text
            Else : .SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyPictures
            End If
        End With

        If FolderPicker.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtSStateManPicsPath.Text = FolderPicker.SelectedPath
        End If
        FolderPicker.Dispose()
        Me.SettingsCheck()
    End Sub

    Private Sub optStettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStettingTab1.CheckedChanged
        If Me.optStettingTab1.Checked = True Then
            Me.optStettingTab1.FlatAppearance.MouseOverBackColor = Color.Gainsboro
            Me.optStettingTab2.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            Me.panelTab2.Visible = False
            Me.panelTab1.Visible = True
        End If
    End Sub

    Private Sub optStettingTab2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStettingTab2.CheckedChanged
        If Me.optStettingTab2.Checked = True Then
            Me.optStettingTab2.FlatAppearance.MouseOverBackColor = Color.Gainsboro
            Me.optStettingTab1.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            Me.panelTab1.Visible = False
            Me.panelTab2.Visible = True
        End If
    End Sub

    Private Sub optStettingTab1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles optStettingTab1.MouseDown
        optStettingTab1.FlatAppearance.MouseOverBackColor = Color.Gainsboro
    End Sub

    Private Sub optStettingTab2_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles optStettingTab2.MouseDown
        optStettingTab2.FlatAppearance.MouseOverBackColor = Color.Gainsboro
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
End Class