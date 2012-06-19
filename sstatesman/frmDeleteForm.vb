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
Public Class frmDeleteForm

    Dim WindowSkipListRefresh As Boolean = False
    Dim SStateList_TotalSizeSelected As System.Int64 = 0
    Dim SStateList_TotalSizeBackupSelected As System.Int64 = 0
    Dim SStateList_TotalSize As System.Int64 = 0
    Dim SStateList_TotalSizeBackup As System.Int64 = 0

    Friend Enum frmDelSStatesLvwColumn
        FileName = 0
        Slot = 1
        Backup = 2
        Size = 3
        Status = 4
    End Enum

    Private Sub frmDeleteForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.lvwSStatesListToDelete.Items.Clear()
        Me.lvwSStatesListToDelete.Groups.Clear()
        Me.SStateList_TotalSize = 0
        Me.SStateList_TotalSizeBackup = 0
    End Sub

    Private Sub frmDeleteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case My.Settings.SStatesMan_BGImage
            Case Theme.square
                Me.panelWindowTitle.BackgroundImage = My.Resources.BG
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.None
                Me.flpWindowBottom.BackgroundImage = Nothing
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.None
            Case Theme.noise
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgNoise
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                Me.flpWindowBottom.BackgroundImage = My.Resources.BgNoise
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.stripes
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgStripes
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                Me.flpWindowBottom.BackgroundImage = My.Resources.BgStripes
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.brushmetal
                Me.panelWindowTitle.BackgroundImage = My.Resources.BgMetalBrush
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Tile
                Me.flpWindowBottom.BackgroundImage = My.Resources.BgMetalBrush
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Tile
            Case Theme.PCSX2
                Me.panelWindowTitle.BackgroundImage = My.Resources.BG_PCSX2
                Me.panelWindowTitle.BackgroundImageLayout = ImageLayout.Stretch
                Me.flpWindowBottom.BackgroundImage = My.Resources.BG_PCSX2
                Me.flpWindowBottom.BackgroundImageLayout = ImageLayout.Stretch
            Case Else
                My.Settings.SStatesMan_BGImage = Theme.none
                Me.panelWindowTitle.BackgroundImage = Nothing
                Me.flpWindowBottom.BackgroundImage = Nothing
        End Select

        Dim imlLvwCheckboxes As New System.Windows.Forms.ImageList
        imlLvwCheckboxes.ImageSize = New System.Drawing.Size(11, 11)
        imlLvwCheckboxes.Images.Add(My.Resources.Metro_ChecboxUnchecked)
        imlLvwCheckboxes.Images.Add(My.Resources.Metro_ChecboxChecked)
        Me.lvwSStatesListToDelete.StateImageList = imlLvwCheckboxes

        UIEnabled(False)

        For Each tmpCheckedFile In mdlMain.checkedSavestates
            Dim tmpSerial As String = mdlFileList.SStates_GetSerial(tmpCheckedFile)
            Dim tmpLvwItem As New ListViewItem With {.Text = GamesList(tmpSerial).Savestates(tmpCheckedFile).Name,
                                                     .Name = GamesList(tmpSerial).Savestates(tmpCheckedFile).Name}
            tmpLvwItem.SubItems.AddRange({GamesList(tmpSerial).Savestates(tmpCheckedFile).Slot.ToString,
                                          GamesList(tmpSerial).Savestates(tmpCheckedFile).Backup.ToString,
                                          (GamesList(tmpSerial).Savestates(tmpCheckedFile).Length / 1024 ^ 2).ToString("#,##0.00 MB")
                                          })



            If colorswitch Then
                tmpLvwItem.BackColor = Color.Transparent
                colorswitch = False
            Else
                tmpLvwItem.BackColor = Color.WhiteSmoke
                colorswitch = True
            End If

            If System.IO.File.Exists(String.Concat(My.Settings.PCSX2_PathSState, "\", GamesList(tmpSerial).Savestates(tmpCheckedFile).Name)) Then
                tmpLvwItem.SubItems.Add("")
                tmpLvwItem.Checked = True
                If GamesList(tmpSerial).Savestates(tmpCheckedFile).Backup = False Then
                    SStateList_TotalSize += GamesList(tmpSerial).Savestates(tmpCheckedFile).Length
                Else
                    SStateList_TotalSizeBackup += GamesList(tmpSerial).Savestates(tmpCheckedFile).Length
                End If
            Else
                tmpLvwItem.SubItems.Add("Error: file not found or inaccessible.")
                tmpLvwItem.Checked = False
                tmpLvwItem.BackColor = Color.FromArgb(255, 255, 192, 192)
            End If
            Me.lvwSStatesListToDelete.Items.Add(tmpLvwItem)


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
            Try
                If My.Settings.SStatesMan_SStateTrash = True Then
                    My.Computer.FileSystem.DeleteFile(String.Concat(My.Settings.PCSX2_PathSState, "\", mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates(tmp.Name).Name),
                                                      FileIO.UIOption.OnlyErrorDialogs,
                                                      FileIO.RecycleOption.SendToRecycleBin)
                Else
                    System.IO.File.Delete(String.Concat(My.Settings.PCSX2_PathSState, "\", mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates(tmp.Name).Name))
                End If
                If mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates(tmp.Name).Backup Then
                    mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).SavestatesBackup_SizeTot -= mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates(tmp.Name).Length
                Else
                    mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates_SizeTot -= mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates(tmp.Name).Length
                End If
                mdlFileList.GamesList(mdlFileList.SStates_GetSerial(tmp.Name)).Savestates.Remove(tmp.Name)
                Me.lvwSStatesListToDelete.Items(tmp.Index).SubItems(frmDelSStatesLvwColumn.Status).Text = "File deleted successfully."
                Me.lvwSStatesListToDelete.Items(tmp.Index).BackColor = Color.FromArgb(255, 192, 255, 192)
            Catch ex As Exception
                Me.lvwSStatesListToDelete.Items(tmp.Index).SubItems(frmDelSStatesLvwColumn.Status).Text = ex.Message
                Me.lvwSStatesListToDelete.Items(tmp.Index).BackColor = Color.FromArgb(255, 255, 192, 192)
            Finally
                Me.lvwSStatesListToDelete.Items(tmp.Index).Checked = False
            End Try

        Next
        Me.UIEnabled(True)
        Me.UICheck()
        frmMain.lvwSStatesList_Populate()
        'frmMain.lvwGamesList_Update()
        frmMain.UI_Update()
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

    Private Sub frmDeleteForm_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Normal Then
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonMaximize
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.cmdWindowMaximize.Image = My.Resources.Metro_WindowButtonRestore
        End If
    End Sub

    'SStatesList management
    Private Sub cmdSStateSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectAll.Click
        Me.UIEnabled(False)
        For lvwItemIndex As System.Int32 = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
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
        For lvwItemIndex As System.Int32 = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
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
            ElseIf Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
                Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).Checked = True
            End If
        Next
        Me.SStatesLvw_SelectionChanged()
        Me.UICheck()
    End Sub

    Private Sub cmdSStateSelectBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSStateSelectBackup.Click
        Me.UIEnabled(False)
        For lvwItemIndex = 0 To Me.lvwSStatesListToDelete.Items.Count - 1
            If Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Backup).Text = "True" And _
               Me.lvwSStatesListToDelete.Items.Item(lvwItemIndex).SubItems(frmDelSStatesLvwColumn.Status).Text = "" Then
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
            If e.Item.SubItems(frmDelSStatesLvwColumn.Status).Text <> "" Then
                e.Item.Checked = False
                System.Windows.Forms.MessageBox.Show("The file is already gone or you can't access it, quit trying.", "Stop trolling!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            SStatesLvw_SelectionChanged()
        End If
    End Sub

    Private Sub SStatesLvw_SelectionChanged()
        'UIEnabled(False)
        'Me.SStateList_TotalSizeSelected = 0
        'Me.SStateList_TotalSizeBackupSelected = 0
        'If Me.lvwSStatesListToDelete.Items.Count > 0 Then
        '    For Each SStateList_ItemChecked As ListViewItem In Me.lvwSStatesListToDelete.CheckedItems
        '        Dim SStatesList_Pos As System.Int32 = 0
        '        System.Int32.TryParse(SStateList_ItemChecked.SubItems(frmDelSStatesLvwColumn_ArrayRef).Text, SStatesList_Pos)
        '        If SStatesList(SStatesList_Pos).isBackup = False Then
        '            SStateList_TotalSizeSelected = SStateList_TotalSizeSelected + SStatesList(SStatesList_Pos).FileInfo.Length
        '        Else
        '            SStateList_TotalSizeBackupSelected = SStateList_TotalSizeBackupSelected + SStatesList(SStatesList_Pos).FileInfo.Length
        '        End If
        '    Next
        'End If
        'UIEnabled(True)
        'UICheck()
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
            Me.txtSize.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.SStateList_TotalSizeSelected / 1024 ^ 2, Me.SStateList_TotalSize / 1024 ^ 2)
            Me.txtSizeBackup.Text = System.String.Format("{0:N2} | {1:N2} MB", Me.SStateList_TotalSizeBackupSelected / 1024 ^ 2, Me.SStateList_TotalSizeBackup / 1024 ^ 2)
            Me.txtSStateListSelection.Text = System.String.Format("{0:N0} | {1:N0}", Me.lvwSStatesListToDelete.CheckedItems.Count, Me.lvwSStatesListToDelete.Items.Count)
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

    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim rectoolbar As New Rectangle(0, 8, 24, 39)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(rectoolbar, Color.FromArgb(130, 150, 200), Color.FromArgb(65, 74, 100), 90)
        e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
        If (panelWindowTitle.Height > 4) And (panelWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_BGEnable Then
                rectoolbar = New Rectangle(0, panelWindowTitle.Height - 4, panelWindowTitle.Width, 4)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(rectoolbar, Color.Transparent, Color.DarkGray, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, rectoolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If flpWindowBottom.Width > 0 Then
            If My.Settings.SStatesMan_BGEnable Then
                Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width, 4)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, flpWindowBottom.Width, 0)
        End If
    End Sub

End Class