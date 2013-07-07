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
Public NotInheritable Class frmAbout

#Region "Form"
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.applyTheme()

        Me.lblVersionMain.Text = My.Application.Info.Version.ToString
        Me.lblVersionChannel.Text = My.Settings.SStatesMan_Channel

        Me.lblAuthorName.Text = My.Application.Info.CompanyName
        Me.lblCopyright.Text = My.Application.Info.Copyright

        Me.pnlTab0.Dock = DockStyle.Fill
        Me.pnlTab1.Dock = DockStyle.Fill

        Me.pnlTab0.Visible = Me.optTabHeader0.Checked
        Me.pnlTab1.Visible = Me.optTabHeader1.Checked

    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub llbPCSX2Forum_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbPCSX2Forum.LinkClicked
        System.Diagnostics.Process.Start("http://forums.pcsx2.net/Thread-SStatesMan-a-savestates-managing-tool-for-PCSX2")
    End Sub
#End Region

#Region "Form - Tabs"
    'This common event is fired AFTER the other specific events.
    Private Sub optTabHeader_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader0.CheckedChanged, optTabHeader1.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to know 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.optTabHeader0.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader1.FlatAppearance.MouseDownBackColor = Color.White
                CType(sender, RadioButton).FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

                Me.pnlTab0.Visible = Me.optTabHeader0.Checked
                Me.pnlTab1.Visible = Me.optTabHeader1.Checked

            End If
        End If
    End Sub
#End Region

#Region "UI paint"
    Private Sub pnlTopPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlTopPanel.Paint
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

    Private Sub flpBottomPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles flpBottomPanel.Paint
        If CType(sender, Panel).Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, CType(sender, Panel).Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, Panel).Width, 0)
        End If
    End Sub

    Private Sub optTabHeader_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optTabHeader0.Paint, optTabHeader1.Paint
        If CType(sender, RadioButton).Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, RadioButton).Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, CType(sender, RadioButton).Height)
            e.Graphics.DrawLine(Pens.DimGray, CType(sender, RadioButton).Width - 1, 0, CType(sender, RadioButton).Width - 1, CType(sender, RadioButton).Height)
        End If
    End Sub

    Private Sub applyTheme()
        Dim sw As Stopwatch = Stopwatch.StartNew

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

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.AboutDialog, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub
#End Region

End Class
