﻿'   SStatesMan - a savestate managing tool for PCSX2
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
Public Class frmTemplate
    Dim lastWindowState As FormWindowState  'Needed to know if a form resize changed the windowstate

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            Me.lblWindowTitle.Text = value
        End Set
    End Property

    Private _formDescription As String
    Public Property FormDescription As String
        Get
            If Me.lblWindowDescription IsNot Nothing Then
                _formDescription = Me.lblWindowDescription.Text
            Else
                _formDescription = ""
            End If
            Return _formDescription
        End Get
        Set(ByVal value As String)
            _formDescription = value
            Me.lblWindowDescription.Text = value
        End Set
    End Property

#Region "Form"
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Me.applyTheme()
    End Sub
#End Region

#Region "Form - ControlBox & Resize"
    Private Sub ControlBoxMaximize_Click(sender As Object, e As EventArgs) Handles ControlBoxMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub ControlBoxMinimize_Click(sender As Object, e As EventArgs) Handles ControlBoxMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ControlBoxClose_Click(sender As Object, e As EventArgs) Handles ControlBoxClose.Click
        Me.Close()
    End Sub

    Private Sub ControlBoxMaximize_MouseEnter(sender As Object, e As EventArgs) Handles ControlBoxMaximize.MouseEnter
        If Me.WindowState = FormWindowState.Normal Then
            CType(sender, Button).Image = My.Resources.Window_ButtonMaximizeW
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            CType(sender, Button).Image = My.Resources.Window_ButtonRestoreW
        End If
    End Sub

    Private Sub ControlBoxMaximize_MouseLeave(sender As Object, e As EventArgs) Handles ControlBoxMaximize.MouseLeave
        If Me.WindowState = FormWindowState.Normal Then
            CType(sender, Button).Image = My.Resources.Window_ButtonMaximize
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            CType(sender, Button).Image = My.Resources.Window_ButtonRestore
        End If
    End Sub

    Private Sub ControlBoxMinimize_MouseEnter(sender As Object, e As EventArgs) Handles ControlBoxMinimize.MouseEnter
        CType(sender, Button).Image = My.Resources.Window_ButtonMinimizeW
    End Sub

    Private Sub ControlBoxMinimize_MouseLeave(sender As Object, e As EventArgs) Handles ControlBoxMinimize.MouseLeave
        CType(sender, Button).Image = My.Resources.Window_ButtonMinimize
    End Sub

    Private Sub frmMain_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Not (Me.lastWindowState = Me.WindowState) Then
            If Me.WindowState = FormWindowState.Normal Then
                Me.ControlBoxMaximize.Image = My.Resources.Window_ButtonMaximize
                Me.flpControlBox.Margin = New Padding(0, 0, CInt(6 * DPIxScale), 0)
                'Me.Padding = New Padding(1)
            ElseIf Me.WindowState = FormWindowState.Maximized Then
                Me.ControlBoxMaximize.Image = My.Resources.Window_ButtonRestore
                Me.flpControlBox.Margin = New Padding(0, 0, CInt(3 * DPIxScale), 0)
                'Me.Padding = New Padding(0)
            End If
            Me.lastWindowState = Me.WindowState
        End If
    End Sub
#End Region

#Region "Theme"
    Private Sub pnlWindowTop_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlWindowTop.Paint
        Me.ApplyThemeAccent(sender, e)
        If (CType(sender, Panel).Height > CInt(4 * DPIyScale) + 1) And (CType(sender, Panel).Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim rectoolbar As New Rectangle(0, CType(sender, Panel).Height - (CInt(3 * DPIyScale) + 1), _
                                                CType(sender, Panel).Width, CInt(3 * DPIyScale) + 1)
                Dim tmpLiGrBr As New Drawing2D.LinearGradientBrush(rectoolbar, Color.Transparent, Color.DarkGray, 90)
                rectoolbar.Y += 1
                e.Graphics.FillRectangle(tmpLiGrBr, rectoolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, CType(sender, Panel).Height - 1, CType(sender, Panel).Width, CType(sender, Panel).Height - 1)
        End If
    End Sub

    Protected Friend Overridable Sub ApplyThemeAccent(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        Dim tmpRect As New Rectangle(0, Me.flpTitleBar.Padding.Top, _
                                     Me.flpTitleBar.Padding.Left, _
                                     Me.flpTitleBar.Height - (Me.flpTitleBar.Padding.Top + Me.flpTitleBar.Padding.Bottom))
        Dim tmpSBrush As New SolidBrush(currentTheme.AccentColor)
        e.Graphics.FillRectangle(tmpSBrush, tmpRect)
        If Me.imgWindowGradientIcon.Width > 0 AndAlso Me.imgWindowGradientIcon.Height > 0 Then
            tmpRect = New Rectangle(Me.imgWindowGradientIcon.Location, Me.imgWindowGradientIcon.Size)
            e.Graphics.FillRectangle(tmpSBrush, tmpRect)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If CType(sender, FlowLayoutPanel).Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, CType(sender, FlowLayoutPanel).Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, FlowLayoutPanel).Width, 0)
        End If
    End Sub

    Friend Sub applyTheme()
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
        'Me.Refresh()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.Theme, eSrcMethod.Theme, "Theme applied.", sw.ElapsedTicks)
    End Sub

    'Private Sub frmTemplate_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    '    If Me.Width > 8 And Me.Height > 8 Then
    '        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(130, 150, 200)), 0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
    '    End If
    'End Sub
#End Region

End Class