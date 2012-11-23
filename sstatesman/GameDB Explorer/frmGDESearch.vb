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
Public Class frmGDESearch
    Dim ConvertedGameCompat As System.String = ""

    Private Sub UI_Check()
        If Me.ckbSerial.Checked Or
            Me.ckbGameTitle.Checked Or
            Me.ckbGameRegion.Checked Or
            Me.ckbGameCompat.Checked Then

            Me.cmdSearch.Enabled = True

        Else : Me.cmdSearch.Enabled = False
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearch.Click
        If Me.optSeatchTypeAND.Checked Then
            PCSX2GameDb.Search(frmGameDbExplorer.SearchResultRef,
                                   Me.txtSerial.Text,
                                   Me.txtGameTitle.Text,
                                   Me.txtGameRegion.Text,
                                   ConvertedGameCompat,
                                   0)
        Else
            PCSX2GameDb.Search(frmGameDbExplorer.SearchResultRef,
                                   Me.txtSerial.Text,
                                   Me.txtGameTitle.Text,
                                   Me.txtGameRegion.Text,
                                   ConvertedGameCompat,
                                   1)
        End If
        frmGameDbExplorer.SearchIsActive = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtSerial_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerial.TextChanged
        'Me.txtSerial.Text = Me.txtSerial.Text.Trim
        If Me.txtSerial.Text.Length > 0 Then
            Me.ckbSerial.Checked = True
        Else
            Me.ckbSerial.Checked = False
        End If
        Me.UI_Check()
    End Sub

    Private Sub txtGameTitle_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGameTitle.TextChanged
        'Me.txtGameTitle.Text = Me.txtGameTitle.Text.Trim
        If Me.txtGameTitle.Text.Length > 0 Then
            Me.ckbGameTitle.Checked = True
        Else
            Me.ckbGameTitle.Checked = False
        End If
        Me.UI_Check()
    End Sub

    Private Sub txtGameRegion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGameRegion.TextChanged
        'Me.txtGameRegion.Text = Me.txtGameRegion.Text.Trim
        If Me.txtGameRegion.Text.Length > 0 Then
            Me.ckbGameRegion.Checked = True
        Else
            Me.ckbGameRegion.Checked = False
        End If
        Me.UI_Check()
    End Sub

    Private Sub cbGameCompat_TextChanged(sender As System.Object, e As System.EventArgs) Handles cbGameCompat.TextChanged
        'Me.cbGameCompat.Text = Me.txtGameRegion.Text.Trim
        If Me.cbGameCompat.Text.Length > 0 Then
            Me.ckbGameCompat.Checked = True
        Else
            Me.ckbGameCompat.Checked = False
        End If
        Me.UI_Check()
    End Sub

    Private Sub cbGameCompat_Validated(sender As Object, e As System.EventArgs) Handles cbGameCompat.Validated
        Me.ckbGameCompat.Checked = True
        Me.cbGameCompat.Text = Me.cbGameCompat.Text.Trim
        Select Case Me.cbGameCompat.Text.ToLower
            Case "0: unknown" : ConvertedGameCompat = "0"
            Case "1: nothing" : ConvertedGameCompat = "1"
            Case "2: intro" : ConvertedGameCompat = "2"
            Case "3: menus" : ConvertedGameCompat = "3"
            Case "4: in-game" : ConvertedGameCompat = "4"
            Case "5: playable" : ConvertedGameCompat = "5"
            Case "6: perfect" : ConvertedGameCompat = "6"
            Case "missing" : ConvertedGameCompat = ""
            Case Else : ConvertedGameCompat = ""
                Me.cbGameCompat.Text = ""
                Me.ckbGameCompat.Checked = False
        End Select
        Me.UI_Check()
    End Sub

    Private Sub frmGameDbSearchForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.applyTheme()

        Me.UI_Check()
    End Sub

#Region "UI Paint"
    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim recToolbar As New Rectangle(CInt(8 * DPIxScale), 0, CInt(127 * DPIxScale) + 1, CInt(7 * DPIyScale) + 1)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 0)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If (panelWindowTitle.Height > 4 * CInt(DPIyScale) + 1) And (panelWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                recToolbar = New Rectangle(0, panelWindowTitle.Height - CInt(4 * DPIyScale), panelWindowTitle.Width, CInt(3 * DPIyScale) + 1)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
                recToolbar.Y += 1
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If flpWindowBottom.Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, flpWindowBottom.Width, 0)
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
#End Region

End Class