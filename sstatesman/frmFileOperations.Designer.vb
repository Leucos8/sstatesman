'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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
Partial Class frmFileOperations
    Inherits frmTemplate

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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdReorder = New System.Windows.Forms.Button()
        Me.lvwFileList = New System.Windows.Forms.ListView()
        Me.StROLvw_Slot = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StROLvw_OldName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StROLvw_NewName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StROLvw_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCommand1 = New System.Windows.Forms.Button()
        Me.cmdCommand2 = New System.Windows.Forms.Button()
        Me.cmdCommand3 = New System.Windows.Forms.Button()
        Me.cmdCommand4 = New System.Windows.Forms.Button()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.flpMainListCommands = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlFormContent = New System.Windows.Forms.Panel()
        Me.ckbSStatesManReorderBackup = New System.Windows.Forms.CheckBox()
        Me.tlpFileListCommands = New System.Windows.Forms.TableLayoutPanel()
        Me.flpFileListCommandsFiles = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdSortReset = New System.Windows.Forms.Button()
        Me.tlpFileListStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.flpMainListCommands.SuspendLayout()
        Me.pnlFormContent.SuspendLayout()
        Me.tlpFileListCommands.SuspendLayout()
        Me.flpFileListCommandsFiles.SuspendLayout()
        Me.tlpFileListStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlWindowTop.Size = New System.Drawing.Size(638, 46)
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
        Me.cmdCancel.Location = New System.Drawing.Point(549, 344)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "CLOSE"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdReorder
        '
        Me.cmdReorder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReorder.AutoSize = True
        Me.cmdReorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdReorder.BackColor = System.Drawing.Color.White
        Me.cmdReorder.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdReorder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdReorder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdReorder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdReorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReorder.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdReorder.Location = New System.Drawing.Point(445, 344)
        Me.cmdReorder.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdReorder.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdReorder.Name = "cmdReorder"
        Me.cmdReorder.Size = New System.Drawing.Size(100, 24)
        Me.cmdReorder.TabIndex = 8
        Me.cmdReorder.Text = "REORDER"
        Me.cmdReorder.UseVisualStyleBackColor = False
        '
        'lvwFileList
        '
        Me.lvwFileList.BackColor = System.Drawing.Color.White
        Me.lvwFileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwFileList.CheckBoxes = True
        Me.lvwFileList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.StROLvw_Slot, Me.StROLvw_OldName, Me.StROLvw_NewName, Me.StROLvw_Status})
        Me.lvwFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwFileList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwFileList.ForeColor = System.Drawing.Color.Black
        Me.lvwFileList.FullRowSelect = True
        Me.lvwFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwFileList.HideSelection = False
        Me.lvwFileList.Location = New System.Drawing.Point(8, 22)
        Me.lvwFileList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwFileList.MultiSelect = False
        Me.lvwFileList.Name = "lvwFileList"
        Me.lvwFileList.Size = New System.Drawing.Size(588, 164)
        Me.lvwFileList.TabIndex = 10
        Me.lvwFileList.UseCompatibleStateImageBehavior = False
        Me.lvwFileList.View = System.Windows.Forms.View.Details
        '
        'StROLvw_Slot
        '
        Me.StROLvw_Slot.Text = "Slot"
        '
        'StROLvw_OldName
        '
        Me.StROLvw_OldName.Text = "Old name"
        Me.StROLvw_OldName.Width = 200
        '
        'StROLvw_NewName
        '
        Me.StROLvw_NewName.Text = "New name"
        Me.StROLvw_NewName.Width = 200
        '
        'StROLvw_Status
        '
        Me.StROLvw_Status.Text = "Status"
        Me.StROLvw_Status.Width = 120
        '
        'cmdCommand1
        '
        Me.cmdCommand1.AutoSize = True
        Me.cmdCommand1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCommand1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdCommand1.FlatAppearance.BorderSize = 0
        Me.cmdCommand1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCommand1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdCommand1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCommand1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCommand1.Location = New System.Drawing.Point(43, 0)
        Me.cmdCommand1.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdCommand1.Name = "cmdCommand1"
        Me.cmdCommand1.Size = New System.Drawing.Size(37, 22)
        Me.cmdCommand1.TabIndex = 13
        Me.cmdCommand1.Text = "CMD"
        Me.cmdCommand1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdCommand2
        '
        Me.cmdCommand2.AutoSize = True
        Me.cmdCommand2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCommand2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdCommand2.FlatAppearance.BorderSize = 0
        Me.cmdCommand2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCommand2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdCommand2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCommand2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCommand2.Location = New System.Drawing.Point(80, 0)
        Me.cmdCommand2.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdCommand2.Name = "cmdCommand2"
        Me.cmdCommand2.Size = New System.Drawing.Size(37, 22)
        Me.cmdCommand2.TabIndex = 14
        Me.cmdCommand2.Text = "CMD"
        Me.cmdCommand2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdCommand3
        '
        Me.cmdCommand3.AutoSize = True
        Me.cmdCommand3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCommand3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdCommand3.FlatAppearance.BorderSize = 0
        Me.cmdCommand3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCommand3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdCommand3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCommand3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCommand3.Location = New System.Drawing.Point(117, 0)
        Me.cmdCommand3.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdCommand3.Name = "cmdCommand3"
        Me.cmdCommand3.Size = New System.Drawing.Size(37, 22)
        Me.cmdCommand3.TabIndex = 15
        Me.cmdCommand3.Text = "CMD"
        Me.cmdCommand3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdCommand4
        '
        Me.cmdCommand4.AutoSize = True
        Me.cmdCommand4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCommand4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdCommand4.FlatAppearance.BorderSize = 0
        Me.cmdCommand4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCommand4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdCommand4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCommand4.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCommand4.Location = New System.Drawing.Point(154, 0)
        Me.cmdCommand4.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdCommand4.Name = "cmdCommand4"
        Me.cmdCommand4.Size = New System.Drawing.Size(37, 22)
        Me.cmdCommand4.TabIndex = 16
        Me.cmdCommand4.Text = "CMD"
        Me.cmdCommand4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAction.Location = New System.Drawing.Point(2, 0)
        Me.lblAction.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(39, 22)
        Me.lblAction.TabIndex = 32
        Me.lblAction.Text = "action"
        Me.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flpMainListCommands
        '
        Me.flpMainListCommands.AutoSize = True
        Me.flpMainListCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpMainListCommands.Controls.Add(Me.cmdCommand4)
        Me.flpMainListCommands.Controls.Add(Me.cmdCommand3)
        Me.flpMainListCommands.Controls.Add(Me.cmdCommand2)
        Me.flpMainListCommands.Controls.Add(Me.cmdCommand1)
        Me.flpMainListCommands.Controls.Add(Me.lblAction)
        Me.flpMainListCommands.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpMainListCommands.Location = New System.Drawing.Point(381, 0)
        Me.flpMainListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.flpMainListCommands.Name = "flpMainListCommands"
        Me.flpMainListCommands.Size = New System.Drawing.Size(191, 22)
        Me.flpMainListCommands.TabIndex = 12
        Me.flpMainListCommands.WrapContents = False
        '
        'pnlFormContent
        '
        Me.pnlFormContent.Controls.Add(Me.lvwFileList)
        Me.pnlFormContent.Controls.Add(Me.ckbSStatesManReorderBackup)
        Me.pnlFormContent.Controls.Add(Me.tlpFileListCommands)
        Me.pnlFormContent.Location = New System.Drawing.Point(12, 54)
        Me.pnlFormContent.Name = "pnlFormContent"
        Me.pnlFormContent.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.pnlFormContent.Size = New System.Drawing.Size(604, 211)
        Me.pnlFormContent.TabIndex = 13
        '
        'ckbSStatesManReorderBackup
        '
        Me.ckbSStatesManReorderBackup.AutoSize = True
        Me.ckbSStatesManReorderBackup.Checked = Global.sstatesman.My.MySettings.Default.SStatesMan_SStateReorderBackup
        Me.ckbSStatesManReorderBackup.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.sstatesman.My.MySettings.Default, "SStatesMan_SStateReorderBackup", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ckbSStatesManReorderBackup.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ckbSStatesManReorderBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManReorderBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManReorderBackup.Location = New System.Drawing.Point(8, 186)
        Me.ckbSStatesManReorderBackup.Name = "ckbSStatesManReorderBackup"
        Me.ckbSStatesManReorderBackup.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ckbSStatesManReorderBackup.Size = New System.Drawing.Size(588, 21)
        Me.ckbSStatesManReorderBackup.TabIndex = 41
        Me.ckbSStatesManReorderBackup.Text = "Reorder savestates together with their backup."
        Me.ckbSStatesManReorderBackup.UseVisualStyleBackColor = False
        '
        'tlpFileListCommands
        '
        Me.tlpFileListCommands.AutoSize = True
        Me.tlpFileListCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFileListCommands.ColumnCount = 3
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListCommands.Controls.Add(Me.flpMainListCommands, 2, 0)
        Me.tlpFileListCommands.Controls.Add(Me.flpFileListCommandsFiles, 0, 0)
        Me.tlpFileListCommands.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpFileListCommands.Location = New System.Drawing.Point(8, 0)
        Me.tlpFileListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListCommands.Name = "tlpFileListCommands"
        Me.tlpFileListCommands.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.tlpFileListCommands.RowCount = 1
        Me.tlpFileListCommands.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListCommands.Size = New System.Drawing.Size(588, 22)
        Me.tlpFileListCommands.TabIndex = 39
        '
        'flpFileListCommandsFiles
        '
        Me.flpFileListCommandsFiles.AutoSize = True
        Me.flpFileListCommandsFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFileListCommandsFiles.Controls.Add(Me.cmdSortReset)
        Me.flpFileListCommandsFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFileListCommandsFiles.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpFileListCommandsFiles.Location = New System.Drawing.Point(16, 0)
        Me.flpFileListCommandsFiles.Margin = New System.Windows.Forms.Padding(0)
        Me.flpFileListCommandsFiles.Name = "flpFileListCommandsFiles"
        Me.flpFileListCommandsFiles.Size = New System.Drawing.Size(41, 22)
        Me.flpFileListCommandsFiles.TabIndex = 50
        Me.flpFileListCommandsFiles.WrapContents = False
        '
        'cmdSortReset
        '
        Me.cmdSortReset.AutoSize = True
        Me.cmdSortReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSortReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdSortReset.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSortReset.FlatAppearance.BorderSize = 0
        Me.cmdSortReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSortReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSortReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSortReset.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSortReset.Location = New System.Drawing.Point(0, 0)
        Me.cmdSortReset.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSortReset.Name = "cmdSortReset"
        Me.cmdSortReset.Size = New System.Drawing.Size(41, 22)
        Me.cmdSortReset.TabIndex = 40
        Me.cmdSortReset.Text = "&RESET"
        Me.cmdSortReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'tlpFileListStatus
        '
        Me.tlpFileListStatus.AutoSize = True
        Me.tlpFileListStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFileListStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tlpFileListStatus.ColumnCount = 4
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListStatus.Controls.Add(Me.lblSelected, 0, 0)
        Me.tlpFileListStatus.Controls.Add(Me.lblSize, 1, 0)
        Me.tlpFileListStatus.Controls.Add(Me.lblSizeBackup, 2, 0)
        Me.tlpFileListStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpFileListStatus.ForeColor = System.Drawing.Color.White
        Me.tlpFileListStatus.Location = New System.Drawing.Point(1, 329)
        Me.tlpFileListStatus.MinimumSize = New System.Drawing.Size(0, 24)
        Me.tlpFileListStatus.Name = "tlpFileListStatus"
        Me.tlpFileListStatus.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tlpFileListStatus.RowCount = 1
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.Size = New System.Drawing.Size(638, 24)
        Me.tlpFileListStatus.TabIndex = 17
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSelected.Location = New System.Drawing.Point(4, 0)
        Me.lblSelected.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(53, 24)
        Me.lblSelected.TabIndex = 18
        Me.lblSelected.Text = "selection"
        Me.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSize.Location = New System.Drawing.Point(61, 0)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(66, 24)
        Me.lblSize.TabIndex = 20
        Me.lblSize.Text = "active | files"
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.AutoSize = True
        Me.lblSizeBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSizeBackup.Location = New System.Drawing.Point(131, 0)
        Me.lblSizeBackup.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSizeBackup.Name = "lblSizeBackup"
        Me.lblSizeBackup.Size = New System.Drawing.Size(72, 24)
        Me.lblSizeBackup.TabIndex = 22
        Me.lblSizeBackup.Text = "backups size"
        Me.lblSizeBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmFileOperations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BorderColorActive = System.Drawing.Color.Empty
        Me.BorderColorInactive = System.Drawing.Color.Empty
        Me.CaptionColorActive = System.Drawing.Color.Empty
        Me.CaptionColorInactive = System.Drawing.Color.Empty
        Me.CaptionHeight = 46
        Me.ClientSize = New System.Drawing.Size(640, 360)
        Me.Controls.Add(Me.pnlFormContent)
        Me.Controls.Add(Me.tlpFileListStatus)
        Me.Controls.Add(Me.cmdReorder)
        Me.Controls.Add(Me.cmdCancel)
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "frmFileOperations"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reorder"
        Me.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.Controls.SetChildIndex(Me.cmdReorder, 0)
        Me.Controls.SetChildIndex(Me.tlpFileListStatus, 0)
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.pnlFormContent, 0)
        Me.flpMainListCommands.ResumeLayout(False)
        Me.flpMainListCommands.PerformLayout()
        Me.pnlFormContent.ResumeLayout(False)
        Me.pnlFormContent.PerformLayout()
        Me.tlpFileListCommands.ResumeLayout(False)
        Me.tlpFileListCommands.PerformLayout()
        Me.flpFileListCommandsFiles.ResumeLayout(False)
        Me.flpFileListCommandsFiles.PerformLayout()
        Me.tlpFileListStatus.ResumeLayout(False)
        Me.tlpFileListStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblAction As System.Windows.Forms.Label
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdReorder As System.Windows.Forms.Button
    Private WithEvents lvwFileList As System.Windows.Forms.ListView
    Private WithEvents StROLvw_Slot As System.Windows.Forms.ColumnHeader
    Private WithEvents StROLvw_OldName As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdCommand1 As System.Windows.Forms.Button
    Private WithEvents cmdCommand2 As System.Windows.Forms.Button
    Private WithEvents cmdCommand3 As System.Windows.Forms.Button
    Private WithEvents cmdCommand4 As System.Windows.Forms.Button
    Private WithEvents flpMainListCommands As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents StROLvw_NewName As System.Windows.Forms.ColumnHeader
    Private WithEvents pnlFormContent As System.Windows.Forms.Panel
    Private WithEvents StROLvw_Status As System.Windows.Forms.ColumnHeader
    Private WithEvents tlpFileListCommands As System.Windows.Forms.TableLayoutPanel
    Private WithEvents flpFileListCommandsFiles As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdSortReset As System.Windows.Forms.Button
    Private WithEvents tlpFileListStatus As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblSelected As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents ckbSStatesManReorderBackup As System.Windows.Forms.CheckBox
End Class
