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
Public Class frmDeleteForm


    Dim SkipListRefresh As Boolean = False
    Dim SStateList_TotalSizeSelected As System.Int64 = 0
    Dim SStateList_TotalSizeBackupSelected As System.Int64 = 0
    Dim SStateList_TotalSize As System.Int64 = 0
    Dim SStateList_TotalSizeBackup As System.Int64 = 0

    Private Sub frmDeleteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.SStateList_TotalSize = 0
        Me.SStateList_TotalSizeBackup = 0
        UISwitch(False)
        SkipListRefresh = True
        Me.lvwSStatesListToDelete.Groups.Clear()
        Me.lvwSStatesListToDelete.Items.Clear()
        For Each SStateList_Group As System.Windows.Forms.ListViewGroup In frmMain.lvwSStatesList.Groups
            Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup
            'If frmMain.lvwGamesList.CheckedItems.Count > 1 Then

            With SStateList_GroupTmp
                .Header = SStateList_Group.Header
                .HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Left
                .Name = SStateList_Group.Name
            End With
            Me.lvwSStatesListToDelete.Groups.Add(SStateList_GroupTmp)
            'End If
            For Each ListItemTmp As System.Windows.Forms.ListViewItem In SStateList_Group.Items
                If ListItemTmp.Checked = True Then
                    Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem
                    SStateList_Pos = CInt(ListItemTmp.SubItems(6).Text)
                    SStateList_ItemTmp.Text = mdlSStateList.SStateList(SStateList_Pos).FileInfo.Name
                    SStateList_ItemTmp.SubItems.Add(SStateList(SStateList_Pos).SStateSlot.ToString)
                    SStateList_ItemTmp.SubItems.Add(SStateList(SStateList_Pos).SStateBackup.ToString)
                    'SStateList_ItemTmp.SubItems.Add(SStateList(SStateList_Pos).FileInfo.CreationTime.ToString)
                    SStateList_ItemTmp.SubItems.Add(Format((SStateList(SStateList_Pos).FileInfo.Length / 1024 / 1024), "#,##0.00 MiB"))
                    SStateList_ItemTmp.SubItems.Add(Trim(SStateList(SStateList_Pos).SStateSerial))
                    SStateList_ItemTmp.SubItems.Add(mdlSStateList.SStateList_Pos.ToString)

                    If SStateList(SStateList_Pos).SStateBackup = False Then
                        SStateList_TotalSize = SStateList_TotalSize + SStateList(SStateList_Pos).FileInfo.Length
                    Else
                        SStateList_TotalSizeBackup = SStateList_TotalSizeBackup + SStateList(SStateList_Pos).FileInfo.Length
                    End If


                    If colorswitch = True Then
                        colorswitch = False
                    Else
                        SStateList_ItemTmp.BackColor = Color.WhiteSmoke
                        colorswitch = True
                    End If
                    If My.Computer.FileSystem.FileExists(mdlSStateList.SStateList(SStateList_Pos).FileInfo.FullName) Then
                        SStateList_ItemTmp.SubItems.Add("")
                        SStateList_ItemTmp.Checked = True
                    Else
                        SStateList_ItemTmp.SubItems.Add("Error: unable to find the file.")
                        SStateList_ItemTmp.Checked = False
                        SStateList_ItemTmp.BackColor = Color.FromArgb(255, 255, 192, 192)
                    End If

                    SStateList_ItemTmp.Group = SStateList_GroupTmp
                    Me.lvwSStatesListToDelete.Items.Add(SStateList_ItemTmp)
                End If
            Next

        Next
        SkipListRefresh = False
        colorswitch = True
        SStateListSelectionChanged()
        UISwitch(True)
        'UICheck()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdDeleteSStateSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSStateSelected.Click
        For Each tmp As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems
            mdlSStateList.SStateList_Pos = CInt(tmp.SubItems(5).Text)
            mdlSStateList.SStateGameIndex_Pos = mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).GameIndexRef
            Try
                If My.Settings.SStateMan_SStateTrash = True Then
                    My.Computer.FileSystem.DeleteFile(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.FullName, _
                                                      FileIO.UIOption.OnlyErrorDialogs, _
                                                      FileIO.RecycleOption.SendToRecycleBin)
                Else
                    My.Computer.FileSystem.DeleteFile(mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.FullName, _
                                                      FileIO.UIOption.OnlyErrorDialogs, _
                                                      FileIO.RecycleOption.DeletePermanently)
                End If
                If mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).SStateBackup Then
                    mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStatesBackup_SizeTotal = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStatesBackup_SizeTotal - mdlSStateList.SStateList(mdlSStateList.SStateGameIndex_Pos).FileInfo.Length
                Else
                    mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal - mdlSStateList.SStateList(mdlSStateList.SStateGameIndex_Pos).FileInfo.Length
                End If
                mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).isDeleted = True
                Me.lvwSStatesListToDelete.Items(tmp.Index).SubItems(6).Text = "File deleted successfully."
                Me.lvwSStatesListToDelete.Items(tmp.Index).BackColor = Color.FromArgb(255, 192, 255, 192)
            Catch Delete_ex As Exception
                Me.lvwSStatesListToDelete.Items(tmp.Index).SubItems(6).Text = Delete_ex.Message
                Me.lvwSStatesListToDelete.Items(tmp.Index).BackColor = Color.FromArgb(255, 255, 192, 192)
            Finally
                Me.lvwSStatesListToDelete.Items(tmp.Index).Checked = False
            End Try

        Next
        frmMain.List_Refresh()
    End Sub

    Private Sub frmDeleteFrom_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If My.Settings.SStateMan_BGEnable Then
            Dim linGrBrush As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 150), Color.Gainsboro, Color.White)
            Dim linGrBrush2 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 150), New Point(0, Me.ClientSize.Height), Color.White, Color.Gainsboro)
            Dim linGrBrush3 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            Dim linGrBrush4 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.LightGray, Color.Transparent)
            'Dim linGrBrush5 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 12), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrush, 0, 0, Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush2, 0, CInt(Me.ClientSize.Height - 150), Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush3, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            e.Graphics.FillRectangle(linGrBrush4, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, 12)
            'e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
            e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
            'e.Graphics.FillRectangle(linGrBrush5, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance, Me.ClientSize.Width, 12)

        End If
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Me.ClientSize.Width, 0)
        'e.Graphics.DrawLine(Pens.DarkGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)
    End Sub

    Private Sub cmdWindowMaximize_Click(sender As System.Object, e As System.EventArgs) Handles cmdWindowMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonRestore
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonMaximize
        End If
    End Sub

    Private Sub cmdWindowClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdWindowClose.Click
        Me.Close()
    End Sub


    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = True
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(tmp).SubItems(6).Text = "" Then
                Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = False
            End If
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(tmp).SubItems(6).Text = "" Then
                If Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = True Then
                    Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = False
                Else
                    Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = True
                End If
            End If
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Dim tmp As System.Int32
        SkipListRefresh = True
        For tmp = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(tmp).SubItems(6).Text = "" Then
                If CBool(Me.lvwSStatesListToDelete.Items.Item(tmp).SubItems(2).Text) = True Then
                    Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = True
                Else
                    Me.lvwSStatesListToDelete.Items.Item(tmp).Checked = False
                End If
            End If
        Next
        SkipListRefresh = False
        SStateListSelectionChanged()
    End Sub

    Private Sub lvwSStatesListToDelete_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesListToDelete.ItemChecked
        If SkipListRefresh = False Then
            If e.Item.SubItems(6).Text <> "" Then
                e.Item.Checked = False
                'MsgBox("The file is already gone or you can't access it, quit trying")
            End If
            SStateListSelectionChanged()
        End If
    End Sub

    Private Sub SStateListSelectionChanged()
        UISwitch(False)
        Me.SStateList_TotalSizeSelected = 0
        Me.SStateList_TotalSizeBackupSelected = 0
        If Me.lvwSStatesListToDelete.Items.Count > 0 Then
            For Each SStateList_ItemChecked As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems
                mdlSStateList.SStateList_Pos = CInt(SStateList_ItemChecked.SubItems(5).Text)
                If SStateList(SStateList_Pos).SStateBackup = False Then
                    SStateList_TotalSizeSelected = SStateList_TotalSizeSelected + SStateList(SStateList_Pos).FileInfo.Length
                Else
                    SStateList_TotalSizeBackupSelected = SStateList_TotalSizeBackupSelected + SStateList(SStateList_Pos).FileInfo.Length
                End If
            Next
        End If
        UISwitch(True)
        UICheck()
    End Sub

    Private Sub UISwitch(enable As Boolean)
        If enable = True Then
            Me.lvwSStatesListToDelete.ResumeLayout()
        Else
            Me.lvwSStatesListToDelete.SuspendLayout()
        End If
    End Sub

    Private Sub UICheck()
        If Me.lvwSStatesListToDelete.Items.Count = 0 Then
            Me.txtSize.Text = ""
            Me.txtSizeBackup.Text = ""
            Me.txtSStateListSelection.Text = ""
            Me.cmdSStateSelectAll.Enabled = False
            Me.cmdSStateSelectInvert.Enabled = False
            Me.cmdSStateSelectNone.Enabled = False
            Me.cmdSStateSelectBackup.Enabled = False
            Me.cmdDeleteSStateSelected.Enabled = False
        Else
            Me.txtSize.Text = System.String.Format("{0:#,##0.00} / {1:#,##0.00} MiB", Me.SStateList_TotalSizeSelected / 1024 ^ 2, Me.SStateList_TotalSize / 1024 ^ 2)
            Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} / {1:#,##0.00} MiB", Me.SStateList_TotalSizeBackupSelected / 1024 ^ 2, Me.SStateList_TotalSizeBackup / 1024 ^ 2)
            Me.txtSStateListSelection.Text = System.String.Format("{0:#,##0} / {1:#,##0} files", Me.lvwSStatesListToDelete.CheckedItems.Count, Me.lvwSStatesListToDelete.Items.Count)
            Me.cmdSStateSelectInvert.Enabled = True
            Me.cmdSStateSelectBackup.Enabled = True
            If Me.lvwSStatesListToDelete.CheckedItems.Count > 0 Then
                Me.cmdSStateSelectNone.Enabled = True
                Me.cmdSStateSelectAll.Enabled = True
                Me.cmdDeleteSStateSelected.Enabled = True
                If Me.lvwSStatesListToDelete.Items.Count = Me.lvwSStatesListToDelete.CheckedItems.Count Then
                    Me.cmdSStateSelectAll.Enabled = False
                End If
            ElseIf Me.lvwSStatesListToDelete.CheckedItems.Count = 0 Then
                Me.cmdSStateSelectNone.Enabled = False
                Me.cmdSStateSelectAll.Enabled = True
                Me.cmdDeleteSStateSelected.Enabled = False
            End If
        End If
    End Sub

End Class