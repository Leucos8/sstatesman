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
            frmGameDb.GameDbSearch_Len = frmGameDb.GameDb_Search(Me.txtSerial.Text, Me.ckbSerial.Checked, _
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
End Class