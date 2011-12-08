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
Public Class frmSStateList
    Private Sub ShowStatus()
        Me.StatusStrip1.Items.Item(0).Text = "Position: " & (mdlSStateList.SStateList_Pos + 1).ToString("#,##0")
        If SStateList_Len < 0 Then
            Me.StatusStrip1.Items.Item(0).Text = "Not loaded!"
        End If
        Me.StatusStrip1.Items.Item(1).Text = "Records: " & (mdlSStateList.SStateList_Len + 1).ToString("#,##0")

        If mdlSStateList.SStateList_Len >= 0 Then
            Me.LblSearchResults.Text = "Serial   = " & SStateList(SStateList_Pos).SStateSerial & vbCrLf & _
                                       "Slot     = " & SStateList(SStateList_Pos).SStateSlot & vbCrLf & _
                                       "Filename = " & SStateList(SStateList_Pos).FileInfo.Name & vbCrLf & _
                                       "Size     = " & (SStateList(SStateList_Pos).FileInfo.Length / 1024 / 1024).ToString("#,##0.00 MiB") & vbCrLf & _
                                       "Created  = " & SStateList(SStateList_Pos).FileInfo.CreationTime
            Me.tsSStateListUnload.Enabled = True
            Me.tsListShow.Enabled = True
            Me.tsExport.Enabled = True
            If (mdlSStateList.SStateList_Pos > 0) And (mdlSStateList.SStateList_Pos < mdlSStateList.SStateList_Len) Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = True
                Me.tsRecordFirst.Enabled = True
            ElseIf mdlSStateList.SStateList_Pos <= 0 Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
            ElseIf mdlSStateList.SStateList_Pos >= mdlSStateList.SStateList_Len Then
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
            Me.tsSStateListUnload.Enabled = False
            Me.tsListShow.Enabled = False
            Me.tsExport.Enabled = False
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        MdlSStateList.SStateList_Pos = Me.ListBox1.SelectedIndex
        ShowStatus()
    End Sub


    Private Sub tsSStateListUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSStateListUnload.Click
        If System.Windows.Forms.MessageBox.Show("Warning, unloading the SStateList *will* lead to crashes." & vbCrLf & "Reloading it won't fix this mistake." & vbCrLf & "Do you wish to continue?", _
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.ListBox1.Items.Clear()
            SStateList_Len = mdlSStateList.SStateList_Unload(SStateList, SStateList_Pos)
            ShowStatus()
        End If
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click
        Me.ListBox1.Items.Clear()
        Me.ListBox1.Visible = False
        For MdlSStateList.SStateList_Pos = 0 To SStateList_Len
            ListBox1.Items.Add(System.String.Format("{0,-12}|{1,2}|{2,-6}|{3,-36}|{4,12:#,##0.00 MiB}|{5,20}|{6}", _
                                                    SStateList(SStateList_Pos).SStateSerial, _
                                                    SStateList(SStateList_Pos).SStateSlot.ToString, _
                                                    SStateList(SStateList_Pos).SStateBackup.ToString, _
                                                    SStateList(SStateList_Pos).FileInfo.Name, _
                                                    SStateList(SStateList_Pos).FileInfo.Length / 1024 ^ 2, _
                                                    SStateList(SStateList_Pos).FileInfo.CreationTime.ToString, _
                                                    SStateList(SStateList_Pos).FileInfo.Attributes.ToString))
        Next SStateList_Pos
        MdlSStateList.SStateList_Pos = 0
        Me.ListBox1.Visible = True
        Me.tsListClear.Enabled = True
    End Sub

    Private Sub tsListClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListClear.Click
        Me.ListBox1.Items.Clear()
        Me.tsListClear.Enabled = False
    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Call mdlSStateList.SStateList_ExportTxt(My.Computer.FileSystem.SpecialDirectories.Desktop & "\SStateList.txt", vbTab, SStateList, SStateList_Pos, SStateList_Len)
        MsgBox("A dump of the array has been saved to the Desktop", MsgBoxStyle.Information, "Notice")
    End Sub

    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        MdlSStateList.SStateList_Pos = 0
        ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If MdlSStateList.SStateList_Pos > 0 Then
            MdlSStateList.SStateList_Pos = MdlSStateList.SStateList_Pos - 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If MdlSStateList.SStateList_Pos < MdlSStateList.SStateList_Len Then
            MdlSStateList.SStateList_Pos = MdlSStateList.SStateList_Pos + 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        MdlSStateList.SStateList_Pos = MdlSStateList.SStateList_Len
        ShowStatus()
    End Sub

    Private Sub frmSStateList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowStatus()
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Call mdlSStateList.SStateList_ExportTxt(My.Computer.FileSystem.SpecialDirectories.Desktop & "\SStateList.csv", ";", SStateList, SStateList_Pos, SStateList_Len)
        MsgBox("A dump of the array has been saved to the Desktop", MsgBoxStyle.Information, "Notice")
    End Sub

    Private Sub tsSStateListLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSStateListLoad.Click
        If System.Windows.Forms.MessageBox.Show("Warning, reloading the SStateList *will* lead to crashes." & vbCrLf & "Do you wish to continue?", _
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.ListBox1.Items.Clear()
            SStateList_Len = mdlSStateList.SStateList_Load(My.Settings.PCSX2_PathSState, _
                                                           mdlSStateList.SStateList, _
                                                           mdlSStateList.SStateList_Pos)
            ShowStatus()
        End If
    End Sub

End Class