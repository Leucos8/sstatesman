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
Public Class frmDialogTemplate

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            Me.lblWindowTitle.Text = value
        End Set
    End Property

#Region "Form"
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.applyTheme()

    End Sub
#End Region

#Region "UI paint"
    Private Sub pnlTopPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlWindowTop.Paint
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

    Private Sub flpBottomPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If CType(sender, Panel).Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, CType(sender, Panel).Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, Panel).Width, 0)
        End If
    End Sub

    Protected Sub applyTheme()
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.BackColor = currentTheme.BgColor
        Me.pnlWindowTop.BackColor = currentTheme.BgColorTop
        Me.flpWindowBottom.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.pnlWindowTop.BackgroundImage = currentTheme.BgImageTop
            Me.pnlWindowTop.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpWindowBottom.BackgroundImage = currentTheme.BgImageBottom
            Me.flpWindowBottom.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.pnlWindowTop.BackgroundImage = Nothing
            Me.flpWindowBottom.BackgroundImage = Nothing
        End If
        Me.Refresh()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.AboutDialog, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub
#End Region

End Class
