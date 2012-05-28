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
Public Class frmSStateList
    Private Sub ShowStatus()
        Me.StatusStrip1.Items.Item(0).Text = "Position: " & (mdlSStatesList.SStatesList_Pos + 1).ToString("#,##0")
        If SStatesList_Len < 0 Then
            Me.StatusStrip1.Items.Item(0).Text = "Not loaded!"
        End If
        Me.StatusStrip1.Items.Item(1).Text = "Records: " & (mdlSStatesList.SStatesList_Len + 1).ToString("#,##0")

        If mdlSStatesList.SStatesList_Len >= 0 Then
            Me.LblSearchResults.Text = "Serial   = " & SStatesList(SStatesList_Pos).SStateSerial & vbCrLf & _
                                       "Slot     = " & SStatesList(SStatesList_Pos).Slot & vbCrLf & _
                                       "Filename = " & SStatesList(SStatesList_Pos).FileInfo.Name & vbCrLf & _
                                       "Size     = " & (SStatesList(SStatesList_Pos).FileInfo.Length / 1024 / 1024).ToString("#,##0.00 MB") & vbCrLf & _
                                       "Created  = " & SStatesList(SStatesList_Pos).FileInfo.LastWriteTime
            Me.tsSStateListUnload.Enabled = True
            Me.tsListShow.Enabled = True
            Me.tsExport.Enabled = True
            If (mdlSStatesList.SStatesList_Pos > 0) And (mdlSStatesList.SStatesList_Pos < mdlSStatesList.SStatesList_Len) Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = True
                Me.tsRecordFirst.Enabled = True
            ElseIf mdlSStatesList.SStatesList_Pos <= 0 Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
            ElseIf mdlSStatesList.SStatesList_Pos >= mdlSStatesList.SStatesList_Len Then
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
        mdlSStatesList.SStatesList_Pos = Me.ListBox1.SelectedIndex
        ShowStatus()
    End Sub


    Private Sub tsSStateListUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSStateListUnload.Click
        If System.Windows.Forms.MessageBox.Show("Warning, unloading the SStateList *will* lead to crashes." & vbCrLf & "Reloading it won't fix this mistake." & vbCrLf & "Do you wish to continue?", _
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.ListBox1.Items.Clear()
            SStatesList_Len = mdlSStatesList.SStatesList_Unload(SStatesList, SStatesList_Pos)
            ShowStatus()
        End If
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click
        Me.ListBox1.Items.Clear()
        Me.ListBox1.Visible = False
        For mdlSStatesList.SStatesList_Pos = 0 To SStatesList_Len
            ListBox1.Items.Add(System.String.Format("{0,-12}|{1,2}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}", _
                                                    SStatesList(SStatesList_Pos).SStateSerial, _
                                                    SStatesList(SStatesList_Pos).Slot.ToString, _
                                                    SStatesList(SStatesList_Pos).isBackup.ToString, _
                                                    SStatesList(SStatesList_Pos).FileInfo.Name, _
                                                    SStatesList(SStatesList_Pos).FileInfo.Length / 1024 ^ 2, _
                                                    SStatesList(SStatesList_Pos).FileInfo.LastWriteTime.ToString, _
                                                    SStatesList(SStatesList_Pos).FileInfo.Attributes.ToString))
        Next SStatesList_Pos
        mdlSStatesList.SStatesList_Pos = 0
        Me.ListBox1.Visible = True
        Me.tsListClear.Enabled = True
    End Sub

    Private Sub tsListClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListClear.Click
        Me.ListBox1.Items.Clear()
        Me.tsListClear.Enabled = False
    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Call mdlSStatesList.SStatesList_ExportTxt(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SStateList.txt", vbTab, SStatesList, SStatesList_Pos, SStatesList_Len)
        MsgBox("A dump of the array has been saved to the Desktop", MsgBoxStyle.Information, "Notice")
    End Sub

    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        mdlSStatesList.SStatesList_Pos = 0
        ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If mdlSStatesList.SStatesList_Pos > 0 Then
            mdlSStatesList.SStatesList_Pos = mdlSStatesList.SStatesList_Pos - 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If mdlSStatesList.SStatesList_Pos < mdlSStatesList.SStatesList_Len Then
            mdlSStatesList.SStatesList_Pos = mdlSStatesList.SStatesList_Pos + 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        mdlSStatesList.SStatesList_Pos = mdlSStatesList.SStatesList_Len
        ShowStatus()
    End Sub

    Private Sub frmSStateList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowStatus()
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Call mdlSStatesList.SStatesList_ExportTxt(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SStateList.csv", ";", SStatesList, SStatesList_Pos, SStatesList_Len)
        System.Windows.Forms.MessageBox.Show("A dump of the array has been saved to the Desktop", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub tsSStateListLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSStateListLoad.Click
        If System.Windows.Forms.MessageBox.Show("Warning, reloading the SStateList *will* lead to crashes." & vbCrLf & "Do you wish to continue?", _
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.ListBox1.Items.Clear()
            SStatesList_Len = mdlSStatesList.SStatesList_Load(My.Settings.PCSX2_PathSState, _
                                                           mdlSStatesList.SStatesList, _
                                                           mdlSStatesList.SStatesList_Pos)
            ShowStatus()
        End If
    End Sub

End Class