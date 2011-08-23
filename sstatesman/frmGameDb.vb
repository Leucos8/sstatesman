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
Public Class frmGameDb
    Private Sub ShowStatus()
        Me.StatusStrip1.Items.Item(2).Text = "Position: " & MdlGameDb.GameDb_Pos
        Me.StatusStrip1.Items.Item(1).Text = "Records: " & MdlGameDb.GameDb_Len
        On Error Resume Next
        Me.StatusStrip1.Items.Item(0).Text = "Array lenght: " & UBound(MdlGameDb.GameDb)
        If (Err.Number = 9) Or (MdlGameDb.GameDb_Len < 0) Then
            Me.StatusStrip1.Items.Item(0).Text = "Not loaded!"
            Err.Clear()
        End If

        If MdlGameDb.GameDb_Len >= 0 Then
            Me.LblSearchResults.Text = "Serial  = " & Trim(GameDb(mdlGameDb.GameDb_Pos).Serial) & vbCrLf & _
                                       "Name    = " & Trim(GameDb(mdlGameDb.GameDb_Pos).Name) & vbCrLf & _
                                       "Region  = " & Trim(GameDb(mdlGameDb.GameDb_Pos).Region) & vbCrLf & _
                                       "Compat  = " & GameDb(mdlGameDb.GameDb_Pos).Compat & vbCrLf & _
                                       "RStatus = " & GameDb(mdlGameDb.GameDb_Pos).RStatus
            Me.tsGameDbUnload.Enabled = True
            Me.tsListShow.Enabled = True
            Me.tsTxtSearchSerial.Enabled = True
            Me.tsCmdSearchSerial.Enabled = True
            Me.tsExport.Enabled = True
            If (mdlGameDb.GameDb_Pos > 0) And (mdlGameDb.GameDb_Pos < mdlGameDb.GameDb_Len) Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = True
                Me.tsRecordFirst.Enabled = True
            ElseIf mdlGameDb.GameDb_Pos <= 0 Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
            ElseIf mdlGameDb.GameDb_Pos >= mdlGameDb.GameDb_Len Then
                Me.tsRecordNext.Enabled = False
                Me.tsRecordLast.Enabled = False
                Me.tsRecordPrevious.Enabled = True
                Me.tsRecordFirst.Enabled = True
            End If
        Else
            Me.tsRecordNext.Enabled = False
            Me.tsRecordLast.Enabled = False
            Me.tsRecordPrevious.Enabled = False
            Me.tsRecordFirst.Enabled = False
            Me.tsGameDbUnload.Enabled = False
            Me.tsListShow.Enabled = False
            Me.tsTxtSearchSerial.Enabled = False
            Me.tsCmdSearchSerial.Enabled = False
            Me.tsExport.Enabled = False
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        MdlGameDb.GameDb_Pos = Me.ListBox1.SelectedIndex
        ShowStatus()
    End Sub

    Private Sub tsGameDbLoad_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbLoad.ButtonClick
        GameDb_Len = mdlGameDb.GameDb_Load3(mdlMain.PCSX2_BinPath & mdlMain.FileGameDb, GameDb, GameDb_Pos)
        ShowStatus()
    End Sub

    Private Sub LoadV1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadV1ToolStripMenuItem.Click
        GameDb_Len = mdlGameDb.GameDb_Load1(mdlMain.PCSX2_BinPath & mdlMain.FileGameDb, GameDb, GameDb_Pos)
        ShowStatus()
    End Sub

    Private Sub LoadV2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadV2ToolStripMenuItem.Click
        GameDb_Len = mdlGameDb.GameDb_Load2(mdlMain.PCSX2_BinPath & mdlMain.FileGameDb, GameDb, GameDb_Pos)
        ShowStatus()
    End Sub

    Private Sub tsGameDbUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbUnload.Click
        Me.ListBox1.Items.Clear()

        GameDb_Len = MdlGameDb.GameDb_Unload(GameDb, GameDb_Pos)

        ShowStatus()
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click
        Me.ListBox1.Items.Clear()
        Me.ListBox1.Visible = False
        For MdlGameDb.GameDb_Pos = 0 To GameDb_Len
            ListBox1.Items.Add(GameDb(GameDb_Pos).RStatus & vbTab & _
                               GameDb(GameDb_Pos).Compat & vbTab & _
                               GameDb(GameDb_Pos).Serial & vbTab & _
                               GameDb(GameDb_Pos).Region & vbTab & _
                               GameDb(GameDb_Pos).Name)
        Next GameDb_Pos
        MdlGameDb.GameDb_Pos = 0
        Me.ListBox1.Visible = True
        Me.tsListClear.Enabled = True
    End Sub

    Private Sub tsListClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListClear.Click
        Me.ListBox1.Items.Clear()
        Me.tsListClear.Enabled = False
    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Call MdlGameDb.GameDb_ExportTxt2(".\GameIndex.txt", vbTab, GameDb, GameDb_Pos, GameDb_Len)
    End Sub

    Private Sub tsTxtSearchSerial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsTxtSearchSerial.GotFocus
        If Me.tsTxtSearchSerial.Text = "Serial" Then
            Me.tsTxtSearchSerial.Text = ""
        End If
    End Sub

    Private Sub tsTxtSearchSerial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsTxtSearchSerial.LostFocus
        If Me.tsTxtSearchSerial.Text = "" Then
            Me.tsTxtSearchSerial.Text = "Serial"
        End If
    End Sub

    Private Sub tsCmdSearchSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCmdSearchSerial.Click
        Dim tmp As MdlGameDb.rGameDb
        If Not (Me.tsTxtSearchSerial.Text = "Serial") Then
            Me.tsTxtSearchSerial.Text = UCase(Me.tsTxtSearchSerial.Text)
            tmp = MdlGameDb.GameDb_SearchSerial(tsTxtSearchSerial.Text, GameDb, GameDb_Pos, GameDb_Len)
            ShowStatus()
            Me.LblSearchResults.Text = "Serial:  " & Trim(tmp.Serial) & vbCrLf & "Name:    " & Trim(tmp.Name) & vbCrLf & "Region:  " & Trim(tmp.Region) & vbCrLf & "RStatus: " & tmp.RStatus
        End If
    End Sub


    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        MdlGameDb.GameDb_Pos = 0
        ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If MdlGameDb.GameDb_Pos > 0 Then
            MdlGameDb.GameDb_Pos = MdlGameDb.GameDb_Pos - 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If MdlGameDb.GameDb_Pos < MdlGameDb.GameDb_Len Then
            MdlGameDb.GameDb_Pos = MdlGameDb.GameDb_Pos + 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        MdlGameDb.GameDb_Pos = MdlGameDb.GameDb_Len
        ShowStatus()
    End Sub

    Private Sub frmGameDb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowStatus()
    End Sub

    Private Sub LoadV3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadV3ToolStripMenuItem.Click
        GameDb_Len = mdlGameDb.GameDb_Load3(mdlMain.PCSX2_BinPath & mdlMain.FileGameDb, GameDb, GameDb_Pos)
        ShowStatus()
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Call MdlGameDb.GameDb_ExportTxt2(".\GameIndex.csv", ";", GameDb, GameDb_Pos, GameDb_Len)
    End Sub

End Class