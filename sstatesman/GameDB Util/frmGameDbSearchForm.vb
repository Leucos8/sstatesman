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
    Dim searchCkbStatus As System.Byte = 0
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
            frmGameDb.SearchResultRef_Len = mdlGameDb.GameDb_Search(mdlGameDb.GameDb, mdlGameDb.GameDb_Pos, mdlGameDb.GameDb_Len, _
                                                                 frmGameDb.SearchResultRef, frmGameDb.SearchResultRef_Pos, _
                                                                 Me.txtSerial.Text, Me.ckbSerial.Checked, _
                                                                 Me.txtGameTitle.Text, Me.ckbGameTitle.Checked, _
                                                                 Me.txtGameRegion.Text, Me.ckbGameRegion.Checked, _
                                                                 ConvertedGameCompat, Me.ckbGameCompat.Checked, _
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
            Case "6: perfect" : ConvertedGameCompat = 6
            Case "missing" : ConvertedGameCompat = ""
            Case Else : ConvertedGameCompat = "0"
                Me.cbGameCompat.Text = "0: Unknown"
        End Select
    End Sub

    Private Sub frmGameDbSearchForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.txtSerial.Text = frmGameDb.txtGameList_Serial.Text
        Me.txtGameTitle.Text = frmGameDb.txtGameList_Title.Text
        Me.txtGameRegion.Text = frmGameDb.txtGameList_Region.Text
        Me.cbGameCompat.Text = frmGameDb.txtGameList_Compat.Text
        Me.UICheck()
    End Sub

    Private Sub frmGameDbSearchForm_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If My.Settings.SStatesMan_BGEnable Then
            Dim linGrBrushTop As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 75), Color.Gainsboro, Color.WhiteSmoke)
            Dim linGrBrushBottom As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 75), New Point(0, Me.ClientSize.Height), Color.WhiteSmoke, Color.Gainsboro)
            'Dim linGrBrushToolbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            Dim linGrBrushStatusbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.Silver, Color.Transparent)
            'Dim linGrBrushSplitterbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 1), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 13), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrushTop, 0, 0, Me.ClientSize.Width, 75)
            e.Graphics.FillRectangle(linGrBrushBottom, 0, CInt(Me.ClientSize.Height - 74), Me.ClientSize.Width, 75)
            'e.Graphics.FillRectangle(linGrBrushToolbar, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            e.Graphics.FillRectangle(linGrBrushStatusbar, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, 12)
            'If Not (Me.SplitContainer1.Panel1Collapsed Or Me.SplitContainer1.Panel2Collapsed) Then
            '    e.Graphics.FillRectangle(linGrBrushSplitterbar, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 1, Me.ClientSize.Width, 12)
            'End If

        End If
        'e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
        'If Not (Me.SplitContainer1.Panel1Collapsed Or Me.SplitContainer1.Panel2Collapsed) Then
        '    e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.SplitContainer1.Top + Me.SplitContainer1.SplitterDistance + 1, Me.ClientSize.Width, Me.SplitContainer1.Top + Me.SplitContainer1.SplitterDistance + 1)
        'End If
        e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Me.ClientSize.Width, 0)
        'e.Graphics.DrawLine(Pens.DarkGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)

    End Sub
End Class