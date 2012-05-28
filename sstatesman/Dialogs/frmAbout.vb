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
Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Imposta il titolo del form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)

        Me.lblVersionMain.Text = String.Format("Version {0}",
                                               My.Application.Info.Version.ToString)
        Me.lblVersionChannel.Text = String.Format("Release channel: {0}", My.Settings.SStatesMan_Channel)

        Me.lblCopyright.Text = My.Application.Info.Copyright
        Me.lblAuthorName.Text = String.Concat("Created by ", My.Application.Info.CompanyName)

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


    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://forums.pcsx2.net/Thread-SStatesMan-a-savestates-managing-tool-for-PCSX2")
    End Sub

    Private Sub optSettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab1.CheckedChanged
        If Me.optSettingTab1.Checked = True Then
            With Me.optSettingTab1
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab2
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            Me.SplitContainer1.Panel2Collapsed = True
            Me.SplitContainer1.Panel1Collapsed = False
        End If
    End Sub

    Private Sub optSettingTab2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSettingTab2.CheckedChanged
        If Me.optSettingTab2.Checked = True Then
            With Me.optSettingTab2
                .FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
            End With
            With Me.optSettingTab1
                .FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                .FlatAppearance.MouseDownBackColor = Color.White
            End With
            Me.SplitContainer1.Panel1Collapsed = True
            Me.SplitContainer1.Panel2Collapsed = False
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
        If My.Settings.SStatesMan_BGEnable Then
            Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width, 4)
            Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
            e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        End If
        e.Graphics.DrawLine(Pens.DimGray, 0, 0, flpWindowBottom.Width, 0)
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
End Class
