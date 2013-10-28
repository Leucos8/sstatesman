'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2013 - Leucos
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
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteForm
    Inherits sstatesman.frmTemplate
    'Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lvwDelFilesList = New System.Windows.Forms.ListView()
        Me.cmdFileCheckInvert = New System.Windows.Forms.Button()
        Me.cmdFileCheckBackup = New System.Windows.Forms.Button()
        Me.cmdFileCheckAll = New System.Windows.Forms.Button()
        Me.cmdFileCheckNone = New System.Windows.Forms.Button()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSizeBackup = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.flpFileListCommands = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpFileListStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlFormContent = New System.Windows.Forms.Panel()
        Me.ckbSStatesManMoveToTrash = New System.Windows.Forms.CheckBox()
        Me.cmdFilesDeleteSelected = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.flpFileListCommands.SuspendLayout()
        Me.tlpFileListStatus.SuspendLayout()
        Me.pnlFormContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlWindowTop.Size = New System.Drawing.Size(628, 46)
        '
        'lvwDelFilesList
        '
        Me.lvwDelFilesList.BackColor = System.Drawing.Color.White
        Me.lvwDelFilesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDelFilesList.CheckBoxes = True
        Me.lvwDelFilesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwDelFilesList.FullRowSelect = True
        Me.lvwDelFilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwDelFilesList.Location = New System.Drawing.Point(8, 22)
        Me.lvwDelFilesList.MultiSelect = False
        Me.lvwDelFilesList.Name = "lvwDelFilesList"
        Me.lvwDelFilesList.Size = New System.Drawing.Size(612, 221)
        Me.lvwDelFilesList.TabIndex = 10
        Me.lvwDelFilesList.UseCompatibleStateImageBehavior = False
        Me.lvwDelFilesList.View = System.Windows.Forms.View.Details
        '
        'cmdFileCheckInvert
        '
        Me.cmdFileCheckInvert.AutoSize = True
        Me.cmdFileCheckInvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFileCheckInvert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdFileCheckInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFileCheckInvert.FlatAppearance.BorderSize = 0
        Me.cmdFileCheckInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFileCheckInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFileCheckInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFileCheckInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFileCheckInvert.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckInvert
        Me.cmdFileCheckInvert.Location = New System.Drawing.Point(533, 0)
        Me.cmdFileCheckInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckInvert.Name = "cmdFileCheckInvert"
        Me.cmdFileCheckInvert.Size = New System.Drawing.Size(63, 22)
        Me.cmdFileCheckInvert.TabIndex = 16
        Me.cmdFileCheckInvert.Text = "INVERT"
        Me.cmdFileCheckInvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckInvert.UseVisualStyleBackColor = False
        '
        'cmdFileCheckBackup
        '
        Me.cmdFileCheckBackup.AutoSize = True
        Me.cmdFileCheckBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFileCheckBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdFileCheckBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFileCheckBackup.FlatAppearance.BorderSize = 0
        Me.cmdFileCheckBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFileCheckBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFileCheckBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFileCheckBackup.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFileCheckBackup.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckBackup
        Me.cmdFileCheckBackup.Location = New System.Drawing.Point(356, 0)
        Me.cmdFileCheckBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckBackup.Name = "cmdFileCheckBackup"
        Me.cmdFileCheckBackup.Size = New System.Drawing.Size(73, 22)
        Me.cmdFileCheckBackup.TabIndex = 13
        Me.cmdFileCheckBackup.Text = "BACKUPS"
        Me.cmdFileCheckBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckBackup.UseVisualStyleBackColor = False
        '
        'cmdFileCheckAll
        '
        Me.cmdFileCheckAll.AutoSize = True
        Me.cmdFileCheckAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFileCheckAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdFileCheckAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFileCheckAll.FlatAppearance.BorderSize = 0
        Me.cmdFileCheckAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFileCheckAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFileCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFileCheckAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFileCheckAll.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckAll
        Me.cmdFileCheckAll.Location = New System.Drawing.Point(429, 0)
        Me.cmdFileCheckAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckAll.Name = "cmdFileCheckAll"
        Me.cmdFileCheckAll.Size = New System.Drawing.Size(47, 22)
        Me.cmdFileCheckAll.TabIndex = 14
        Me.cmdFileCheckAll.Text = "ALL"
        Me.cmdFileCheckAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckAll.UseVisualStyleBackColor = False
        '
        'cmdFileCheckNone
        '
        Me.cmdFileCheckNone.AutoSize = True
        Me.cmdFileCheckNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFileCheckNone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdFileCheckNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFileCheckNone.FlatAppearance.BorderSize = 0
        Me.cmdFileCheckNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFileCheckNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFileCheckNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFileCheckNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFileCheckNone.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckNone
        Me.cmdFileCheckNone.Location = New System.Drawing.Point(476, 0)
        Me.cmdFileCheckNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckNone.Name = "cmdFileCheckNone"
        Me.cmdFileCheckNone.Size = New System.Drawing.Size(57, 22)
        Me.cmdFileCheckNone.TabIndex = 15
        Me.cmdFileCheckNone.Text = "NONE"
        Me.cmdFileCheckNone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckNone.UseVisualStyleBackColor = False
        '
        'txtSelected
        '
        Me.txtSelected.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSelected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSelected.ForeColor = System.Drawing.Color.Black
        Me.txtSelected.Location = New System.Drawing.Point(0, 15)
        Me.txtSelected.Margin = New System.Windows.Forms.Padding(0, 2, 4, 2)
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.ReadOnly = True
        Me.txtSelected.Size = New System.Drawing.Size(128, 22)
        Me.txtSelected.TabIndex = 19
        Me.txtSelected.TabStop = False
        Me.txtSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.AutoSize = True
        Me.lblSizeBackup.Location = New System.Drawing.Point(264, 0)
        Me.lblSizeBackup.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSizeBackup.Name = "lblSizeBackup"
        Me.lblSizeBackup.Size = New System.Drawing.Size(72, 13)
        Me.lblSizeBackup.TabIndex = 22
        Me.lblSizeBackup.Text = "backups size"
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(0, 0)
        Me.lblSelected.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(53, 13)
        Me.lblSelected.TabIndex = 18
        Me.lblSelected.Text = "selection"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(132, 0)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(81, 13)
        Me.lblSize.TabIndex = 20
        Me.lblSize.Text = "savestates size"
        '
        'txtSizeBackup
        '
        Me.txtSizeBackup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSizeBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSizeBackup.ForeColor = System.Drawing.Color.Black
        Me.txtSizeBackup.Location = New System.Drawing.Point(264, 15)
        Me.txtSizeBackup.Margin = New System.Windows.Forms.Padding(0, 2, 4, 2)
        Me.txtSizeBackup.Name = "txtSizeBackup"
        Me.txtSizeBackup.ReadOnly = True
        Me.txtSizeBackup.Size = New System.Drawing.Size(128, 22)
        Me.txtSizeBackup.TabIndex = 23
        Me.txtSizeBackup.TabStop = False
        Me.txtSizeBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSize.ForeColor = System.Drawing.Color.Black
        Me.txtSize.Location = New System.Drawing.Point(132, 15)
        Me.txtSize.Margin = New System.Windows.Forms.Padding(0, 2, 4, 2)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(128, 22)
        Me.txtSize.TabIndex = 21
        Me.txtSize.TabStop = False
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'flpFileListCommands
        '
        Me.flpFileListCommands.AutoSize = True
        Me.flpFileListCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFileListCommands.Controls.Add(Me.cmdFileCheckInvert)
        Me.flpFileListCommands.Controls.Add(Me.cmdFileCheckNone)
        Me.flpFileListCommands.Controls.Add(Me.cmdFileCheckAll)
        Me.flpFileListCommands.Controls.Add(Me.cmdFileCheckBackup)
        Me.flpFileListCommands.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpFileListCommands.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpFileListCommands.Location = New System.Drawing.Point(8, 0)
        Me.flpFileListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.flpFileListCommands.Name = "flpFileListCommands"
        Me.flpFileListCommands.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.flpFileListCommands.Size = New System.Drawing.Size(612, 22)
        Me.flpFileListCommands.TabIndex = 12
        Me.flpFileListCommands.WrapContents = False
        '
        'tlpFileListStatus
        '
        Me.tlpFileListStatus.AutoSize = True
        Me.tlpFileListStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFileListStatus.ColumnCount = 4
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListStatus.Controls.Add(Me.lblSelected, 0, 0)
        Me.tlpFileListStatus.Controls.Add(Me.txtSelected, 0, 1)
        Me.tlpFileListStatus.Controls.Add(Me.txtSizeBackup, 2, 1)
        Me.tlpFileListStatus.Controls.Add(Me.lblSize, 1, 0)
        Me.tlpFileListStatus.Controls.Add(Me.lblSizeBackup, 2, 0)
        Me.tlpFileListStatus.Controls.Add(Me.txtSize, 1, 1)
        Me.tlpFileListStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpFileListStatus.Location = New System.Drawing.Point(8, 264)
        Me.tlpFileListStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListStatus.Name = "tlpFileListStatus"
        Me.tlpFileListStatus.RowCount = 2
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.Size = New System.Drawing.Size(612, 39)
        Me.tlpFileListStatus.TabIndex = 17
        '
        'pnlFormContent
        '
        Me.pnlFormContent.Controls.Add(Me.lvwDelFilesList)
        Me.pnlFormContent.Controls.Add(Me.flpFileListCommands)
        Me.pnlFormContent.Controls.Add(Me.ckbSStatesManMoveToTrash)
        Me.pnlFormContent.Controls.Add(Me.tlpFileListStatus)
        Me.pnlFormContent.Location = New System.Drawing.Point(0, 46)
        Me.pnlFormContent.Name = "pnlFormContent"
        Me.pnlFormContent.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.pnlFormContent.Size = New System.Drawing.Size(628, 303)
        Me.pnlFormContent.TabIndex = 18
        '
        'ckbSStatesManMoveToTrash
        '
        Me.ckbSStatesManMoveToTrash.AutoSize = True
        Me.ckbSStatesManMoveToTrash.Checked = Global.sstatesman.My.MySettings.Default.SStatesMan_FileTrash
        Me.ckbSStatesManMoveToTrash.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbSStatesManMoveToTrash.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.sstatesman.My.MySettings.Default, "SStatesMan_FileTrash", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ckbSStatesManMoveToTrash.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ckbSStatesManMoveToTrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManMoveToTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManMoveToTrash.Location = New System.Drawing.Point(8, 243)
        Me.ckbSStatesManMoveToTrash.Name = "ckbSStatesManMoveToTrash"
        Me.ckbSStatesManMoveToTrash.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ckbSStatesManMoveToTrash.Size = New System.Drawing.Size(612, 21)
        Me.ckbSStatesManMoveToTrash.TabIndex = 18
        Me.ckbSStatesManMoveToTrash.Text = "Send files to the Windows Recycle Bin instead of permanently deleting them."
        Me.ckbSStatesManMoveToTrash.UseVisualStyleBackColor = False
        '
        'cmdFilesDeleteSelected
        '
        Me.cmdFilesDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFilesDeleteSelected.AutoSize = True
        Me.cmdFilesDeleteSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesDeleteSelected.BackColor = System.Drawing.Color.White
        Me.cmdFilesDeleteSelected.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdFilesDeleteSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdFilesDeleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdFilesDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesDeleteSelected.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesDeleteSelected.Location = New System.Drawing.Point(413, 406)
        Me.cmdFilesDeleteSelected.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdFilesDeleteSelected.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdFilesDeleteSelected.Name = "cmdFilesDeleteSelected"
        Me.cmdFilesDeleteSelected.Size = New System.Drawing.Size(100, 24)
        Me.cmdFilesDeleteSelected.TabIndex = 8
        Me.cmdFilesDeleteSelected.Text = "DELETE CHECKED"
        Me.cmdFilesDeleteSelected.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.AutoSize = True
        Me.cmdCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCancel.BackColor = System.Drawing.Color.White
        Me.cmdCancel.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.Location = New System.Drawing.Point(517, 406)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "CLOSE"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'frmDeleteForm
        '
        Me.AcceptButton = Me.cmdFilesDeleteSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(628, 441)
        Me.Controls.Add(Me.pnlFormContent)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdFilesDeleteSelected)
        Me.FormDescription = "check the files you really want to delete and click ""delete checked""."
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "frmDeleteForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delete confirmation"
        Me.Controls.SetChildIndex(Me.cmdFilesDeleteSelected, 0)
        Me.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.pnlFormContent, 0)
        Me.flpFileListCommands.ResumeLayout(False)
        Me.flpFileListCommands.PerformLayout()
        Me.tlpFileListStatus.ResumeLayout(False)
        Me.tlpFileListStatus.PerformLayout()
        Me.pnlFormContent.ResumeLayout(False)
        Me.pnlFormContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lvwDelFilesList As System.Windows.Forms.ListView
    Private WithEvents cmdFileCheckInvert As System.Windows.Forms.Button
    Private WithEvents cmdFileCheckBackup As System.Windows.Forms.Button
    Private WithEvents cmdFileCheckAll As System.Windows.Forms.Button
    Private WithEvents cmdFileCheckNone As System.Windows.Forms.Button
    Private WithEvents txtSelected As System.Windows.Forms.TextBox
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents lblSelected As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Private WithEvents txtSize As System.Windows.Forms.TextBox
    Private WithEvents flpFileListCommands As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents tlpFileListStatus As System.Windows.Forms.TableLayoutPanel
    Private WithEvents pnlFormContent As System.Windows.Forms.Panel
    Private WithEvents ckbSStatesManMoveToTrash As System.Windows.Forms.CheckBox
    Private WithEvents cmdFilesDeleteSelected As System.Windows.Forms.Button
    Private WithEvents cmdCancel As System.Windows.Forms.Button
End Class
