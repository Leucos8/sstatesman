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
Public Class frmSStateList
    Private Sub ShowStatus()
        Me.StatusStrip1.Items.Item(2).Text = System.String.Format("Position: {0:#,##0}", (mdlSStateList.SStateList_Pos + 1).ToString)
        Me.StatusStrip1.Items.Item(1).Text = System.String.Format("Records: {0:#,##0}", (mdlSStateList.SStateList_Len + 1).ToString)
        On Error Resume Next
        Me.StatusStrip1.Items.Item(0).Text = System.String.Format("Array lenght: {0:#,##0}", (mdlSStateList.SStateList.GetUpperBound(0) + 1).ToString)
        If SStateList_Len < 0 Then
            Me.StatusStrip1.Items.Item(0).Text = "Not loaded!"

        End If

        If mdlSStateList.SStateList_Len >= 0 Then
            Me.LblSearchResults.Text = "Serial   = " & SStateList(SStateList_Pos).SStateSerial & vbCrLf & _
                                       "Slot     = " & SStateList(SStateList_Pos).SStateSlot & vbCrLf & _
                                       "Filename = " & SStateList(SStateList_Pos).FileInfo.Name & vbCrLf & _
                                       "Size     = " & Format((SStateList(SStateList_Pos).FileInfo.Length / 1024 / 1024), "0.00 MiB") & vbCrLf & _
                                       "Created  = " & SStateList(SStateList_Pos).FileInfo.CreationTime
            Me.tsSStateListUnload.Enabled = True
            Me.tsListShow.Enabled = True
            Me.tsExport.Enabled = True
            If (mdlSStateList.SStateGameIndex_Pos > 0) And (mdlSStateList.SStateGameIndex_Pos < mdlSStateList.SStateGameIndex_Len) Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = True
                Me.tsRecordFirst.Enabled = True
            ElseIf mdlSStateList.SStateGameIndex_Pos <= 0 Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
            ElseIf mdlSStateList.SStateGameIndex_Pos >= mdlSStateList.SStateGameIndex_Len Then
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
        Me.ListBox1.Items.Clear()
        If MsgBox("Warning, unloading the SStateList *will* lead to crashes." & vbCrLf & "Reloading it won't fix this mistake." & vbCrLf & "Do you wish to continue?", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            SStateList_Len = mdlSStateList.SStateList_Unload(SStateList, SStateList_Pos)
        End If
        ShowStatus()
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click
        Me.ListBox1.Items.Clear()
        Me.ListBox1.Visible = False
        For MdlSStateList.SStateList_Pos = 0 To SStateList_Len
            ListBox1.Items.Add(SStateList(SStateList_Pos).SStateSerial & vbTab & _
                               SStateList(SStateList_Pos).SStateSlot & vbTab & _
                               SStateList(SStateList_Pos).SStateBackup & vbTab & _
                               SStateList(SStateList_Pos).FileInfo.Name & vbTab & _
                               Format((SStateList(SStateList_Pos).FileInfo.Length / 1024 / 1024), "0.00 MiB") & vbTab & _
                               SStateList(SStateList_Pos).FileInfo.CreationTime & vbTab & _
                               SStateList(SStateList_Pos).FileInfo.Attributes)
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
        SStateList_Len = mdlSStateList.SStateList_Load(My.Settings.PCSX2_PathSState, _
                                                       mdlSStateList.SStateList, _
                                                       mdlSStateList.SStateList_Pos)
        ShowStatus()
    End Sub

End Class