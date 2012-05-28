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
Public Class frmDeleteForm

    Dim WindowSkipListRefresh As Boolean = False
    Dim SStateList_TotalSizeSelected As System.Int64 = 0
    Dim SStateList_TotalSizeBackupSelected As System.Int64 = 0
    Dim SStateList_TotalSize As System.Int64 = 0
    Dim SStateList_TotalSizeBackup As System.Int64 = 0

    Friend Const frmDelSStatesLvwColumn_FileName As System.Byte = 0
    Friend Const frmDelSStatesLvwColumn_Slot As System.Byte = 1
    Friend Const frmDelSStatesLvwColumn_Backup As System.Byte = 2
    Friend Const frmDelSStatesLvwColumn_Size As System.Byte = 3
    Friend Const frmDelSStatesLvwColumn_SerialRef As System.Byte = 4
    Friend Const frmDelSStatesLvwColumn_ArrayRef As System.Byte = 5
    Friend Const frmDelSStatesLvwColumn_Status As System.Byte = 6

    Private Sub frmDeleteForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwSStatesListToDelete.Items.Clear()
        Me.lvwSStatesListToDelete.Groups.Clear()
        Me.SStateList_TotalSize = 0
        Me.SStateList_TotalSizeBackup = 0
    End Sub

    Private Sub frmDeleteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim imlLvwCheckboxes As New System.Windows.Forms.ImageList
        imlLvwCheckboxes.ImageSize = New System.Drawing.Size(11, 11)
        imlLvwCheckboxes.Images.Add(My.Resources.Metro_ChecboxUnchecked)
        imlLvwCheckboxes.Images.Add(My.Resources.Metro_ChecboxChecked)
        Me.lvwSStatesListToDelete.StateImageList = imlLvwCheckboxes


        UIEnabled(False)

        For Each SStateList_Group As System.Windows.Forms.ListViewGroup In frmMain.lvwSStatesList.Groups
            Dim SStateList_GroupTmp As New System.Windows.Forms.ListViewGroup

            With SStateList_GroupTmp
                .Header = SStateList_Group.Header
                .HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Left
                .Name = SStateList_Group.Name
            End With
            Me.lvwSStatesListToDelete.Groups.Add(SStateList_GroupTmp)

            For Each ListItemTmp As System.Windows.Forms.ListViewItem In SStateList_Group.Items
                If ListItemTmp.Checked = True Then
                    Dim SStateList_ItemTmp As New System.Windows.Forms.ListViewItem
                    SStateList_Pos = CInt(ListItemTmp.SubItems(frmMain.frmMainSStatesLvwColumn_ArrayRef).Text)
                    SStateList_ItemTmp.Text = mdlSStateList.SStateList(SStateList_Pos).FileInfo.Name
                    SStateList_ItemTmp.SubItems.Add(SStateList(SStateList_Pos).SStateSlot.ToString)
                    SStateList_ItemTmp.SubItems.Add(SStateList(SStateList_Pos).SStateBackup.ToString)
                    SStateList_ItemTmp.SubItems.Add(Format((SStateList(SStateList_Pos).FileInfo.Length / 1024 / 1024), "#,##0.00 MiB"))
                    SStateList_ItemTmp.SubItems.Add(Trim(SStateList(SStateList_Pos).SStateSerial))
                    SStateList_ItemTmp.SubItems.Add(mdlSStateList.SStateList_Pos.ToString)

                    If SStateList(SStateList_Pos).SStateBackup = False Then
                        SStateList_TotalSize = SStateList_TotalSize + SStateList(SStateList_Pos).FileInfo.Length
                    Else
                        SStateList_TotalSizeBackup = SStateList_TotalSizeBackup + SStateList(SStateList_Pos).FileInfo.Length
                    End If

                    For lvwSubitemIndex = 1 To SStateList_ItemTmp.SubItems.Count - 1
                        SStateList_ItemTmp.SubItems(lvwSubitemIndex).ForeColor = Color.Gray
                    Next lvwSubitemIndex

                    If colorswitch Then
                        colorswitch = False
                    Else
                        For lvwSubitemIndex = 0 To SStateList_ItemTmp.SubItems.Count - 1
                            SStateList_ItemTmp.SubItems(lvwSubitemIndex).BackColor = Color.WhiteSmoke
                        Next lvwSubitemIndex
                        colorswitch = True
                    End If

                    If My.Computer.FileSystem.FileExists(mdlSStateList.SStateList(SStateList_Pos).FileInfo.FullName) Then
                        SStateList_ItemTmp.SubItems.Add("")
                        SStateList_ItemTmp.Checked = True
                        If SStateList(SStateList_Pos).SStateBackup = False Then
                            SStateList_TotalSizeSelected = SStateList_TotalSizeSelected + SStateList(SStateList_Pos).FileInfo.Length
                        Else
                            SStateList_TotalSizeBackupSelected = SStateList_TotalSizeBackupSelected + SStateList(SStateList_Pos).FileInfo.Length
                        End If
                    Else
                        SStateList_ItemTmp.SubItems.Add("Error: file not found or inaccessible.")
                        SStateList_ItemTmp.Checked = False
                        SStateList_ItemTmp.BackColor = Color.FromArgb(255, 255, 192, 192)
                    End If

                    SStateList_ItemTmp.Group = SStateList_GroupTmp
                    Me.lvwSStatesListToDelete.Items.Add(SStateList_ItemTmp)
                End If
            Next

        Next

        colorswitch = True
        UIEnabled(True)
        UICheck()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdDeleteSStateSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSStateSelected.Click
        Me.UIEnabled(False)
        For Each tmp As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems
            mdlSStateList.SStateList_Pos = CInt(tmp.SubItems(frmDelSStatesLvwColumn_ArrayRef).Text)
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
                    mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStatesBackup_SizeTotal = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStatesBackup_SizeTotal - mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                    mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateListBackup_Count = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateListBackup_Count - 1
                Else
                    mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStates_SizeTotal - mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).FileInfo.Length
                    mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateList_Count = mdlSStateList.SStateGameIndex(mdlSStateList.SStateGameIndex_Pos).SStateList_Count - 1
                End If
                mdlSStateList.SStateList(mdlSStateList.SStateList_Pos).isDeleted = True
                Me.lvwSStatesListToDelete.Items(tmp.Index).SubItems(frmDelSStatesLvwColumn_Status).Text = "File deleted successfully."
                Me.lvwSStatesListToDelete.Items(tmp.Index).BackColor = Color.FromArgb(255, 192, 255, 192)
            Catch ex As Exception
                Me.lvwSStatesListToDelete.Items(tmp.Index).SubItems(frmDelSStatesLvwColumn_Status).Text = ex.Message
                Me.lvwSStatesListToDelete.Items(tmp.Index).BackColor = Color.FromArgb(255, 255, 192, 192)
            Finally
                Me.lvwSStatesListToDelete.Items(tmp.Index).Checked = False
            End Try

        Next
        Me.UIEnabled(True)
        Me.UICheck()
        frmMain.SStatesLvw_Refresh()
        frmMain.GamesLvw_Update()
        frmMain.UICheck()
    End Sub

    Private Sub frmDeleteFrom_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If My.Settings.SStateMan_BGEnable Then
            Dim linGrBrushTop As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 150), Color.Gainsboro, Color.WhiteSmoke)
            Dim linGrBrushBottom As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 150), New Point(0, Me.ClientSize.Height), Color.WhiteSmoke, Color.Gainsboro)
            Dim linGrBrushToolbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            Dim linGrBrushStatusbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.Silver, Color.Transparent)
            'Dim linGrBrushSplitterbar As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 1), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 13), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrushTop, 0, 0, Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrushBottom, 0, CInt(Me.ClientSize.Height - 150), Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrushToolbar, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            e.Graphics.FillRectangle(linGrBrushStatusbar, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, 12)
            'If Not (Me.SplitContainer1.Panel1Collapsed Or Me.SplitContainer1.Panel2Collapsed) Then
            '    e.Graphics.FillRectangle(linGrBrushSplitterbar, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 1, Me.ClientSize.Width, 12)
            'End If

        End If
        e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
        'If Not (Me.SplitContainer1.Panel1Collapsed Or Me.SplitContainer1.Panel2Collapsed) Then
        '    e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.SplitContainer1.Top + Me.SplitContainer1.SplitterDistance + 1, Me.ClientSize.Width, Me.SplitContainer1.Top + Me.SplitContainer1.SplitterDistance + 1)
        'End If
        e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
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

    'SStatesList management
    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn_Status).Text = "" Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectNone.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectInvert_Click(sender As System.Object, e As System.EventArgs) Handles cmdSStateSelectInvert.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
            ElseIf Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn_Status).Text = "" Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn_Backup).Text = True And _
               Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn_Status).Text = "" Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
            Else
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = False
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub lvwSStatesListToDelete_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwSStatesListToDelete.ItemChecked
        If WindowSkipListRefresh = False Then
            If e.Item.SubItems(frmDelSStatesLvwColumn_Status).Text <> "" Then
                e.Item.Checked = False
                MsgBox("The file is already gone or you can't access it, quit trying.", MsgBoxStyle.Exclamation, "Stop trolling!")
            End If
            SStatesLvw_SelectionChanged()
        End If
    End Sub

    Private Sub SStatesLvw_SelectionChanged()
        UIEnabled(False)
        Me.SStateList_TotalSizeSelected = 0
        Me.SStateList_TotalSizeBackupSelected = 0
        If Me.lvwSStatesListToDelete.Items.Count > 0 Then
            For Each SStateList_ItemChecked As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems
                mdlSStateList.SStateList_Pos = CInt(SStateList_ItemChecked.SubItems(frmDelSStatesLvwColumn_ArrayRef).Text)
                If SStateList(SStateList_Pos).SStateBackup = False Then
                    SStateList_TotalSizeSelected = SStateList_TotalSizeSelected + SStateList(SStateList_Pos).FileInfo.Length
                Else
                    SStateList_TotalSizeBackupSelected = SStateList_TotalSizeBackupSelected + SStateList(SStateList_Pos).FileInfo.Length
                End If
            Next
        End If
        UIEnabled(True)
        UICheck()
    End Sub

    Private Sub UIEnabled(enable As Boolean)
        If enable = True Then
            Me.WindowSkipListRefresh = False
            Me.lvwSStatesListToDelete.ResumeLayout()
        Else
            Me.WindowSkipListRefresh = True
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
            Me.txtSize.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MiB", Me.SStateList_TotalSizeSelected / 1024 ^ 2, Me.SStateList_TotalSize / 1024 ^ 2)
            Me.txtSizeBackup.Text = System.String.Format("{0:#,##0.00} | {1:#,##0.00} MiB", Me.SStateList_TotalSizeBackupSelected / 1024 ^ 2, Me.SStateList_TotalSizeBackup / 1024 ^ 2)
            Me.txtSStateListSelection.Text = System.String.Format("{0:#,##0} | {1:#,##0}", Me.lvwSStatesListToDelete.CheckedItems.Count, Me.lvwSStatesListToDelete.Items.Count)
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

    Private Sub frmDeleteForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class