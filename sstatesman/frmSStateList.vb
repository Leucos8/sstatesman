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
    Dim SStatesList_Pos As System.Int32 = 0
    Dim mySStatesListRecord As mdlSStatesList.rSStatesList
    Private Sub ShowStatus()

        With Me.mySStatesListRecord
            .FileInfo = Nothing
            .GameIndexRef = 0
            .isBackup = False
            .isDeleted = False
            .Slot = 0
            .SStateSerial = ""
        End With

        Me.tsSStateListUnload.Enabled = False
        Me.tsExport.Enabled = False

        Me.tsRecordPrevious.Enabled = False
        Me.tsRecordFirst.Enabled = False
        Me.tsRecordNext.Enabled = False
        Me.tsRecordLast.Enabled = False

        Me.LblSearchResults.Text = ""

        Me.ToolStripStatusLabel2.Text = ""

        Select Case mdlSStatesList.SStatesList_ArrayStatus
            Case ArrayStatus.ArrayLoadedOK
                Me.mySStatesListRecord = mdlSStatesList.SStatesList(Me.SStatesList_Pos)
                Me.ToolStripStatusLabel1.Text = System.String.Format("Position: {0}", Me.SStatesList_Pos.ToString("#,##0"))
                Me.ToolStripStatusLabel2.Text = System.String.Format("Records: {0}", mdlSStatesList.SStatesList.GetLength(0).ToString("#,##0"))
                If Me.SStatesList_Pos > mdlSStatesList.SStatesList.GetLowerBound(0) Then
                    Me.tsRecordPrevious.Enabled = True
                    Me.tsRecordFirst.Enabled = True
                End If
                If Me.SStatesList_Pos < mdlSStatesList.SStatesList.GetUpperBound(0) Then
                    Me.tsRecordNext.Enabled = True
                    Me.tsRecordLast.Enabled = True
                End If
                Me.tsSStateListUnload.Enabled = True
                Me.tsExport.Enabled = True

                Me.LblSearchResults.Text = "Serial   = " & SStatesList(SStatesList_Pos).SStateSerial & System.Environment.NewLine & _
                                           "Slot     = " & SStatesList(SStatesList_Pos).Slot & System.Environment.NewLine & _
                                           "Filename = " & SStatesList(SStatesList_Pos).FileInfo.Name & System.Environment.NewLine & _
                                           "Size     = " & (SStatesList(SStatesList_Pos).FileInfo.Length / 1024 / 1024).ToString("#,##0.00 MB") & System.Environment.NewLine & _
                                           "Created  = " & SStatesList(SStatesList_Pos).FileInfo.LastWriteTime
            Case ArrayStatus.ArrayNotLoaded
                Me.ToolStripStatusLabel1.Text = "SStatesList not loaded."
            Case ArrayStatus.ErrorOccurred
                Me.ToolStripStatusLabel1.Text = "Error loading SStatesList."
            Case ArrayStatus.ArrayEmpty
                Me.ToolStripStatusLabel1.Text = "SStatesList has no records."
        End Select
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Me.SStatesList_Pos = Me.ListBox1.SelectedIndex
        Me.ShowStatus()
    End Sub


    Private Sub tsSStateListUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSStateListUnload.Click
        If System.Windows.Forms.MessageBox.Show("Warning, unloading the SStateList *will* lead to crashes." & System.Environment.NewLine & "Reloading it won't fix this mistake." & System.Environment.NewLine & "Do you wish to continue?", _
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.ListBox1.Items.Clear()
            mdlSStatesList.SStatesList_ArrayStatus = mdlSStatesList.SStatesList_Unload(SStatesList, SStatesList_Pos)
            Me.ShowStatus()
        End If
    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Call mdlSStatesList.SStatesList_ExportTxt(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SStateList.txt", vbTab, SStatesList)
        MsgBox("A dump of the array has been saved to the Desktop", MsgBoxStyle.Information, "Notice")
    End Sub

    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        If mdlSStatesList.SStatesList_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            Me.SStatesList_Pos = 0
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If mdlSStatesList.SStatesList_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            Me.SStatesList_Pos -= 1
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If mdlSStatesList.SStatesList_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            Me.SStatesList_Pos += 1
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        If mdlSStatesList.SStatesList_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            Me.SStatesList_Pos = mdlSStatesList.SStatesList.GetUpperBound(0)
        End If
        Me.ShowStatus()
    End Sub

    Private Sub frmSStateList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListBox1.Visible = False
        Me.ListBox1.Items.Clear()
        For Me.SStatesList_Pos = 0 To mdlSStatesList.SStatesList.GetUpperBound(0)
            ListBox1.Items.Add(System.String.Format("{0,-12}|{1,2}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}", _
                                                    SStatesList(SStatesList_Pos).SStateSerial, _
                                                    SStatesList(SStatesList_Pos).Slot.ToString, _
                                                    SStatesList(SStatesList_Pos).isBackup.ToString, _
                                                    SStatesList(SStatesList_Pos).FileInfo.Name, _
                                                    SStatesList(SStatesList_Pos).FileInfo.Length / 1024 ^ 2, _
                                                    SStatesList(SStatesList_Pos).FileInfo.LastWriteTime.ToString, _
                                                    SStatesList(SStatesList_Pos).FileInfo.Attributes.ToString))
        Next SStatesList_Pos
        Me.ListBox1.Visible = True
        Me.SStatesList_Pos = 0
        ShowStatus()
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Call mdlSStatesList.SStatesList_ExportTxt(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SStateList.csv", ";", SStatesList)
        System.Windows.Forms.MessageBox.Show("A dump of the array has been saved to the Desktop", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub tsSStateListLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSStateListLoad.Click
        If System.Windows.Forms.MessageBox.Show("Warning, reloading the SStateList *will* lead to crashes." & System.Environment.NewLine & "Do you wish to continue?", _
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.ListBox1.Items.Clear()
            mdlSStatesList.SStatesList_ArrayStatus = mdlSStatesList.SStatesList_Load(My.Settings.PCSX2_PathSState, _
                                                                                     mdlSStatesList.SStatesList)
            Me.ListBox1.Visible = False
            Me.ListBox1.Items.Clear()
            For Me.SStatesList_Pos = 0 To mdlSStatesList.SStatesList.GetUpperBound(0)
                ListBox1.Items.Add(System.String.Format("{0,-12}|{1,2}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}", _
                                                        SStatesList(SStatesList_Pos).SStateSerial, _
                                                        SStatesList(SStatesList_Pos).Slot.ToString, _
                                                        SStatesList(SStatesList_Pos).isBackup.ToString, _
                                                        SStatesList(SStatesList_Pos).FileInfo.Name, _
                                                        SStatesList(SStatesList_Pos).FileInfo.Length / 1024 ^ 2, _
                                                        SStatesList(SStatesList_Pos).FileInfo.LastWriteTime.ToString, _
                                                        SStatesList(SStatesList_Pos).FileInfo.Attributes.ToString))
            Next SStatesList_Pos
            Me.ListBox1.Visible = True
            Me.SStatesList_Pos = 0
            ShowStatus()
        End If
    End Sub

End Class