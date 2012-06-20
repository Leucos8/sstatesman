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
Public Class frmGameDbSearchForm
    Dim searchCkbStatus As System.Int32 = 0
    Dim ConvertedGameCompat As System.String = ""

    Private Sub UICheck()
        If searchCkbStatus > 0 Then
            Me.cmdSearch.Enabled = True
        Else : Me.cmdSearch.Enabled = False
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearch.Click
        If Me.ckbSerial.Checked And Me.txtSerial.Text = "" Then
            Me.ckbSerial.Checked = False
        End If
        If Me.ckbGameTitle.Checked And Me.txtGameTitle.Text = "" Then
            Me.ckbGameTitle.Checked = False
        End If
        If Me.ckbGameRegion.Checked And Me.txtGameRegion.Text = "" Then
            Me.ckbGameRegion.Checked = False
        End If
        If searchCkbStatus > 0 Then
            frmGameDb.SearchResultRef_ArrayStatus = mdlGameDb.GameDb_Search(mdlGameDb.GameDb,
                                                                            frmGameDb.SearchResultRef,
                                                                            Me.txtSerial.Text, Me.ckbSerial.Checked,
                                                                            Me.txtGameTitle.Text, Me.ckbGameTitle.Checked,
                                                                            Me.txtGameRegion.Text, Me.ckbGameRegion.Checked,
                                                                            ConvertedGameCompat, Me.ckbGameCompat.Checked,
                                                                            0)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.UICheck()
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Sub ckbSerial_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbSerial.CheckedChanged
        If Me.ckbSerial.Checked Then
            searchCkbStatus += 1
            Me.txtSerial.Enabled = True
        Else
            Me.txtSerial.Enabled = False
            searchCkbStatus -= 1
        End If
        Me.UICheck()
    End Sub

    Private Sub ckbGameTitle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbGameTitle.CheckedChanged
        If Me.ckbGameTitle.Checked Then
            searchCkbStatus += 1
            Me.txtGameTitle.Enabled = True
        Else
            Me.txtGameTitle.Enabled = False
            searchCkbStatus -= 1
        End If
        Me.UICheck()
    End Sub

    Private Sub ckbGameRegion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbGameRegion.CheckedChanged
        If Me.ckbGameRegion.Checked Then
            searchCkbStatus += 1
            Me.txtGameRegion.Enabled = True
        Else
            Me.txtGameRegion.Enabled = False
            searchCkbStatus -= 1
        End If
        Me.UICheck()
    End Sub

    Private Sub ckbGameCompat_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbGameCompat.CheckedChanged
        If Me.ckbGameCompat.Checked Then
            searchCkbStatus += 1
            Me.cbGameCompat.Enabled = True
        Else
            Me.cbGameCompat.Enabled = False
            searchCkbStatus -= 1
        End If
        Me.UICheck()
    End Sub

    Private Sub cbGameCompat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbGameCompat.Validating
        Select Case Me.cbGameCompat.Text.ToLower
            Case "0: unknown" : ConvertedGameCompat = "0"
            Case "1: nothing" : ConvertedGameCompat = "1"
            Case "2: intro" : ConvertedGameCompat = "2"
            Case "3: menus" : ConvertedGameCompat = "3"
            Case "4: in-game" : ConvertedGameCompat = "4"
            Case "5: playable" : ConvertedGameCompat = "5"
            Case "6: perfect" : ConvertedGameCompat = "6"
            Case "missing" : ConvertedGameCompat = ""
            Case Else : ConvertedGameCompat = "0"
                Me.cbGameCompat.Text = "0: Unknown"
        End Select
    End Sub

    Private Sub frmGameDbSearchForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.applyTheme()

        Me.UICheck()
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
End Class