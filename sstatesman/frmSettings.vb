'   SStatesMan - Savestate Manager for PCSX2 0.9.8
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
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Me.ClientSize.Width, 0)
        'e.Graphics.DrawLine(Pens.DarkGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)
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
        Dim badChars() As System.Char = {" ", "\", "/", "|", ":"}

        Me.cmdOk.Enabled = True
        Me.TmpSettingsFailTab2 = False

        Me.txtPCSX2AppPath.Text = Me.txtPCSX2AppPath.Text.TrimEnd(badChars)
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2AppPath.Text)) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("FFFFFF Path not found or inaccessible.", vbCrLf, _
                                                                 "FFFFFF Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True

            Me.imgPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.imgPCSX2AppPathStatus.Visible = True
            'My.Settings.SStateMan_SettingFail = True
        ElseIf Not (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Me.txtPCSX2AppPath.Text, My.Settings.PCSX2_GameDbFilename))) Then
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("FFFFFF Unable to find """, My.Settings.PCSX2_GameDbFilename, """ in the specified path.", vbCrLf, _
                                                                 "FFFFFF Game info will not be shown in SStatesMan windows.")
            Me.lblPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)

            Me.imgPCSX2AppPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.imgPCSX2AppPathStatus.Visible = True
        Else
            Me.lblPCSX2AppPathStatus.Text = System.String.Concat("Where SStatesMan will look for """, My.Settings.PCSX2_GameDbFilename, """, usually the folder where PCSX2 is installed.")
            Me.lblPCSX2AppPathStatus.BackColor = Color.Transparent

            Me.imgPCSX2AppPathStatus.Visible = False
        End If


        Me.txtPCSX2IniPath.Text = Me.txtPCSX2IniPath.Text.TrimEnd(badChars)
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2IniPath.Text)) Then
            Me.lblPCSX2IniPathStatus.Text = System.String.Concat("FFFFFF Path not found or inaccessible.", vbCrLf, _
                                                                 "FFFFFF Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True

            Me.imgPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.imgPCSX2IniPathStatus.Visible = True
            'My.Settings.SStateMan_SettingFail = True
        ElseIf Not (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Me.txtPCSX2IniPath.Text, "PCSX2_ui.ini"))) Then
            Me.lblPCSX2IniPathStatus.Text = System.String.Concat("FFFFFF Unable to find ""PCSX2_ui.ini"" in the specified path.", vbCrLf, _
                                                                 "FFFFFF It may not be the correct PCSX2 ""inis"" folder.")
            Me.lblPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)

            Me.imgPCSX2IniPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.imgPCSX2IniPathStatus.Visible = True
        Else
            Me.lblPCSX2IniPathStatus.Text = "Where SStatesMan will look PCSX2 inis, usually the ""inis"" folder inside PCSX2 user folder."
            Me.lblPCSX2IniPathStatus.BackColor = Color.Transparent

            Me.imgPCSX2IniPathStatus.Visible = False
        End If


        Me.txtPCSX2SStatePath.Text = Me.txtPCSX2SStatePath.Text.TrimEnd(badChars)
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtPCSX2SStatePath.Text)) Then
            Me.lblPCSX2SStatePathStatus.Text = System.String.Concat("FFFFFF Path not found or inaccessible.", vbCrLf, _
                                                                    "FFFFFF Please enter a valid path or press """, Me.cmdCancel.Text, """.")
            Me.lblPCSX2SStatePathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.cmdOk.Enabled = False
            Me.TmpSettingsFailTab2 = True

            Me.imgPCSX2SStatePathStatus.BackColor = Color.FromArgb(255, 255, 192, 192)
            Me.imgPCSX2SStatePathStatus.Visible = True
            'My.Settings.SStateMan_SettingFail = True
        Else
            Me.lblPCSX2SStatePathStatus.Text = System.String.Format("Where SStatesMan will look for the savestates, usually the ""{0}"" folder inside PCSX2 user folder.", My.Settings.PCSX2_SStateFolder)
            Me.lblPCSX2SStatePathStatus.BackColor = Color.Transparent

            Me.imgPCSX2SStatePathStatus.Visible = False
        End If


        Me.txtSStateManPicsPath.Text = Me.txtSStateManPicsPath.Text.TrimEnd(badChars)
        If Not (My.Computer.FileSystem.DirectoryExists(Me.txtSStateManPicsPath.Text)) Then
            Me.lblSStateManPicsPathStatus.Text = System.String.Concat("FFFFFF Path not found or inaccessible.", vbCrLf, _
                                                                      "FFFFFF Please enter a valid path.")
            Me.lblSStateManPicsPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)

            Me.imgSStateManPicsPathStatus.BackColor = Color.FromArgb(255, 255, 255, 192)
            Me.imgSStateManPicsPathStatus.Visible = True

            'Me.cmdOk.Enabled = False
            'My.Settings.SStateMan_SettingFail = True
        Else
            Me.lblSStateManPicsPathStatus.Text = System.String.Concat("Where SStatesMan will look for the game cover images.", vbCrLf, _
                                                                      "The cover image MUST be named <executable code>.jpg to work.")
            Me.lblSStateManPicsPathStatus.BackColor = Color.Transparent

            Me.imgSStateManPicsPathStatus.Visible = False
        End If




        If Me.TmpSettingsFailTab2 Then
            Me.optStettingTab2.BackColor = Color.FromArgb(255, 255, 192, 192)
        Else
            Me.optStettingTab2.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub cmdPCSX2AppPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2AppPathBrowse.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2AppPath.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2SStatePathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2SStatePathBrowse.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2SStatePath.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
        Me.SettingsCheck()
    End Sub

    Private Sub cmdPCSX2IniPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdPCSX2IniPathBrowse.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtPCSX2IniPath.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
        Me.SettingsCheck()
    End Sub

    Private Sub cmdSStateManPicsPathBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateManPicsPathBrowse.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtSStateManPicsPath.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
        Me.SettingsCheck()
    End Sub

    Private Sub optStettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStettingTab1.CheckedChanged
        If Me.optStettingTab1.Checked = True Then
            Me.panelTab2.Visible = False
            Me.panelTab1.Visible = True
        End If
    End Sub

    Private Sub optStettingTab2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStettingTab2.CheckedChanged
        If Me.optStettingTab2.Checked = True Then
            Me.panelTab1.Visible = False
            Me.panelTab2.Visible = True
        End If
    End Sub

End Class