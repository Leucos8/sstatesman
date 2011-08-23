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
Public Class frmFileList
    Private Sub ShowStatus()
        Me.StatusStrip1.Items.Item(2).Text = "Position: " & FileList_Pos
        Me.StatusStrip1.Items.Item(1).Text = "Records: " & FileList_Len
        On Error Resume Next
        Me.StatusStrip1.Items.Item(0).Text = "Array lenght: " & UBound(FileList)
        If (Err.Number = 9) Or (FileList_Len < 0) Then
            Me.StatusStrip1.Items.Item(0).Text = "Not loaded!"
            Err.Clear()
        End If

        If mdlFileList.FileList_Len >= 0 Then
            Me.LblSearchResults.Text = "Filename = " & FileList(FileList_Pos).Name & vbCrLf & _
                                       "Size     = " & Format((FileList(FileList_Pos).Length / 1024 / 1024), "0.00 MiB") & vbCrLf & _
                                       "Created  = " & FileList(FileList_Pos).CreationTime
            Me.tsFileListUnload.Enabled = True
            Me.tsListShow.Enabled = True
            Me.tsExport.Enabled = True
            If (mdlFileList.FileList_Pos > 0) And (mdlFileList.FileList_Pos < mdlFileList.FileList_Len) Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = True
                Me.tsRecordFirst.Enabled = True
            ElseIf mdlFileList.FileList_Pos <= 0 Then
                Me.tsRecordNext.Enabled = True
                Me.tsRecordLast.Enabled = True
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
            ElseIf mdlFileList.FileList_Pos >= mdlFileList.FileList_Len Then
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
            Me.tsFileListUnload.Enabled = False
            Me.tsListShow.Enabled = False
            Me.tsExport.Enabled = False
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        mdlFileList.FileList_Pos = Me.ListBox1.SelectedIndex
        ShowStatus()
    End Sub

    Private Sub tsFileListLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFileListLoad.Click
        FileList_Len = mdlFileList.FileList_Load(mdlMain.PCSX2_UserPath & mdlMain.PCSX2_SStateDir, FileList, FileList_Pos)
        ShowStatus()
    End Sub

    Private Sub tsFileListUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFileListUnload.Click
        Me.ListBox1.Items.Clear()

        FileList_Len = mdlFileList.FileList_Unload(FileList, FileList_Pos)

        ShowStatus()
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click
        Me.ListBox1.Items.Clear()
        Me.ListBox1.Visible = False
        For mdlFileList.FileList_Pos = 0 To FileList_Len
            ListBox1.Items.Add(FileList(FileList_Pos).Name & vbTab & _
                               Format((FileList(FileList_Pos).Length / 1024 / 1024), "0.00 MiB") & vbTab & _
                               FileList(FileList_Pos).CreationTime & vbTab & _
                               FileList(FileList_Pos).Attributes)
        Next FileList_Pos
        mdlFileList.FileList_Pos = 0
        Me.ListBox1.Visible = True
        Me.tsListClear.Enabled = True
    End Sub

    Private Sub tsListClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListClear.Click
        Me.ListBox1.Items.Clear()
        Me.tsListClear.Enabled = False
    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Call mdlFileList.FileList_ExportTxt(".\FileList.txt", vbTab, FileList, FileList_Pos, FileList_Len)
    End Sub

    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        mdlFileList.FileList_Pos = 0
        ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If mdlFileList.FileList_Pos > 0 Then
            mdlFileList.FileList_Pos = mdlFileList.FileList_Pos - 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If mdlFileList.FileList_Pos < mdlFileList.FileList_Len Then
            mdlFileList.FileList_Pos = mdlFileList.FileList_Pos + 1
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        mdlFileList.FileList_Pos = mdlFileList.FileList_Len
        ShowStatus()
    End Sub

    Private Sub frmFileList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowStatus()
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Call mdlFileList.FileList_ExportTxt(".\FileList.csv", ";", FileList, FileList_Pos, FileList_Len)
    End Sub

End Class