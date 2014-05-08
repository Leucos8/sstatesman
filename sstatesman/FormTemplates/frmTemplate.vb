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
Public Class frmTemplate

    Private LastWS As FormWindowState = Me.WindowState
    Protected Friend HasFocus As Boolean = False

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            If Me.lblWindowTitle IsNot Nothing Then
                Me.lblWindowTitle.Text = value
            End If
        End Set
    End Property

    Public Shadows Property ControlBox As Boolean
        Get
            Return MyBase.ControlBox
        End Get
        Set(value As Boolean)
            MyBase.ControlBox = value
            If Me.flpControlBox IsNot Nothing Then
                Me.flpControlBox.Visible = value
                Me.flpControlBox.Enabled = value
            End If
        End Set
    End Property

    Public Shadows Property MinimizeBox As Boolean
        Get
            Return MyBase.MinimizeBox
        End Get
        Set(ByVal value As Boolean)
            MyBase.MinimizeBox = value
            If Me.ControlBoxMinimize IsNot Nothing Then
                Me.ControlBoxMinimize.Visible = value
                Me.ControlBoxMinimize.Enabled = value
            End If
        End Set
    End Property

    Public Shadows Property MaximizeBox As Boolean
        Get
            Return MyBase.MaximizeBox
        End Get
        Set(ByVal value As Boolean)
            MyBase.MaximizeBox = value
            If Me.ControlBoxMaximize IsNot Nothing Then
                Me.ControlBoxMaximize.Visible = value
                Me.ControlBoxMaximize.Enabled = value
            End If
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
            If Me.lblWindowDescription IsNot Nothing Then
                Me.lblWindowDescription.Text = value
            End If
        End Set
    End Property

    Private _Shown As Boolean = False
    Public ReadOnly Property IsShown As Boolean
        Get
            Return _Shown
        End Get
    End Property

    Public Event ThemeApplied(sender As Object, e As EventArgs)

#Region "Form"
    Public Sub New()
        Me.ResizeBorderThickness = New System.Drawing.Size(SystemInformation.HorizontalResizeBorderThickness, SystemInformation.VerticalResizeBorderThickness)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.flpControlBox.Margin = New Padding(0, 0, CInt(SystemInformation.VerticalResizeBorderThickness * DPIxScale), 0)
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Me.ApplyTheme()
        Me.AddHitTestingHandlers(Me)
    End Sub

    Private Sub AddHitTestingHandlers(pControl As Control)
        For Each tmpControl As Control In pControl.Controls
            If tmpControl.GetType = GetType(Label) Then
                Me.HitTestingAddControl(tmpControl)
            ElseIf tmpControl.Controls.Count > 0 Then
                Me.HitTestingAddControl(tmpControl)
                Me.AddHitTestingHandlers(tmpControl)
            End If
        Next
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        Me._Shown = True
    End Sub

    Protected Overrides Sub OnActivated(e As EventArgs)
        Me.HasFocus = True
        Me.lblWindowTitle.ForeColor = Me.ForeColor
        Me.lblWindowDescription.ForeColor = Me.ForeColor
        MyBase.OnActivated(e)
        Me.Invalidate(New Rectangle(Me.pnlWindowTop.Location, Me.pnlWindowTop.Size), True)
    End Sub

    Protected Overrides Sub OnDeactivate(e As EventArgs)
        Me.HasFocus = False
        Me.lblWindowTitle.ForeColor = Color.DimGray
        Me.lblWindowDescription.ForeColor = Color.DimGray
        MyBase.OnDeactivate(e)
        Me.Invalidate(New Rectangle(Me.pnlWindowTop.Location, Me.pnlWindowTop.Size), True)
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
            DirectCast(sender, Button).Image = My.Resources.Window_ButtonMaximizeW
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            DirectCast(sender, Button).Image = My.Resources.Window_ButtonRestoreW
        End If
    End Sub

    Private Sub ControlBoxMaximize_MouseLeave(sender As Object, e As EventArgs) Handles ControlBoxMaximize.MouseLeave
        If Me.WindowState = FormWindowState.Normal Then
            DirectCast(sender, Button).Image = My.Resources.Window_ButtonMaximize
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            DirectCast(sender, Button).Image = My.Resources.Window_ButtonRestore
        End If
    End Sub

    Private Sub ControlBoxMinimize_MouseEnter(sender As Object, e As EventArgs) Handles ControlBoxMinimize.MouseEnter
        DirectCast(sender, Button).Image = My.Resources.Window_ButtonMinimizeW
    End Sub

    Private Sub ControlBoxMinimize_MouseLeave(sender As Object, e As EventArgs) Handles ControlBoxMinimize.MouseLeave
        DirectCast(sender, Button).Image = My.Resources.Window_ButtonMinimize
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Me.WindowState = Me.LastWS Then
            Exit Sub
        Else
            Me.LastWS = Me.WindowState
            If Me.LastWS = FormWindowState.Normal Then
                Me.ControlBoxMaximize.Image = My.Resources.Window_ButtonMaximize
                Me.flpControlBox.Margin = New Padding(0, 0, CInt(SystemInformation.VerticalResizeBorderThickness * DPIxScale), 0)
            ElseIf Me.LastWS = FormWindowState.Maximized Then
                Me.ControlBoxMaximize.Image = My.Resources.Window_ButtonRestore
                Me.flpControlBox.Margin = New Padding(0, 0, CInt(3 * DPIxScale), 0)
            End If
        End If
    End Sub
#End Region

#Region "Theme"
    Private Sub pnlWindowTop_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlWindowTop.Paint
        Me.ApplyThemeAccent(sender, e)
        If (DirectCast(sender, Panel).Height > CInt(4 * DPIyScale) + 1) And (DirectCast(sender, Panel).Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim rectoolbar As New Rectangle(0, DirectCast(sender, Panel).Height - (CInt(3 * DPIyScale) + 1), _
                                                DirectCast(sender, Panel).Width, CInt(3 * DPIyScale) + 1)
                Dim tmpLiGrBr As New Drawing2D.LinearGradientBrush(rectoolbar, Color.Transparent, Color.DarkGray, 90)
                rectoolbar.Y += 1
                e.Graphics.FillRectangle(tmpLiGrBr, rectoolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, DirectCast(sender, Panel).Height - 1, DirectCast(sender, Panel).Width, DirectCast(sender, Panel).Height - 1)
        End If
    End Sub

    Protected Friend Overridable Sub ApplyThemeAccent(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        Dim tmpRect As New Rectangle(0, Me.flpTitleBar.Padding.Top, _
                                     Me.flpTitleBar.Padding.Left, _
                                     Me.flpTitleBar.Height - (Me.flpTitleBar.Padding.Top + Me.flpTitleBar.Padding.Bottom))
        Dim tmpSBrush As SolidBrush
        If Me.HasFocus Then
            tmpSBrush = New SolidBrush(currentTheme.AccentColor)
        Else
            tmpSBrush = New SolidBrush(currentTheme.AccentColorDark)
        End If
        If tmpRect.IntersectsWith(e.ClipRectangle) Then
            tmpRect.Intersect(e.ClipRectangle)
            e.Graphics.FillRectangle(tmpSBrush, tmpRect)
        End If
        tmpRect = New Rectangle(Me.imgWindowGradientIcon.Location, Me.imgWindowGradientIcon.Size)
        If tmpRect.IntersectsWith(e.ClipRectangle) Then
            tmpRect.Intersect(e.ClipRectangle)
            e.Graphics.FillRectangle(tmpSBrush, tmpRect)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If DirectCast(sender, Panel).Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, DirectCast(sender, Panel).Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, DirectCast(sender, Panel).Width, 0)
        End If
    End Sub

    Public Sub ApplyTheme()
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

        Me.ControlBoxMinimize.FlatAppearance.MouseOverBackColor = currentTheme.AccentColor
        Me.ControlBoxMinimize.FlatAppearance.MouseDownBackColor = currentTheme.AccentColorDark
        Me.ControlBoxMaximize.FlatAppearance.MouseOverBackColor = currentTheme.AccentColor
        Me.ControlBoxMaximize.FlatAppearance.MouseDownBackColor = currentTheme.AccentColorDark
        Me.CaptionHeight = Me.pnlWindowTop.Height

        Me.CaptionColorActive = currentTheme.BgColorTop
        Me.CaptionColorInactive = currentTheme.BgColorTop
        Me.BorderColorActive = currentTheme.AccentColor
        Me.BorderColorInactive = currentTheme.AccentColorDark


        Me.Refresh()

        RaiseEvent ThemeApplied(Me, New EventArgs)

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.Theme, eSrcMethod.Theme, String.Format("Theme applied to {0}.", Me.Name), sw.ElapsedTicks)
    End Sub
#End Region
End Class