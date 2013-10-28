﻿'   SStatesMan - a savestate managing tool for PCSX2
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
Partial Class frmReorderForm
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
        Me.lvwReorderList = New System.Windows.Forms.ListView()
        Me.StROLvw_Slot = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StROLvw_OldName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StROLvw_NewName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StROLvw_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdMoveLast = New System.Windows.Forms.Button()
        Me.cmdMoveFirst = New System.Windows.Forms.Button()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.lblMove = New System.Windows.Forms.Label()
        Me.flpMainListCommands = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlFormContent = New System.Windows.Forms.Panel()
        Me.ckbSStatesManReorderBackup = New System.Windows.Forms.CheckBox()
        Me.tlpFileListStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.tlpFileListCommands = New System.Windows.Forms.TableLayoutPanel()
        Me.flpFileListCommandsFiles = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdSortReset = New System.Windows.Forms.Button()
        Me.flpMainListCommands.SuspendLayout()
        Me.pnlFormContent.SuspendLayout()
        Me.tlpFileListStatus.SuspendLayout()
        Me.tlpFileListCommands.SuspendLayout()
        Me.flpFileListCommandsFiles.SuspendLayout()
        Me.SuspendLayout()
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
        Me.cmdCancel.Location = New System.Drawing.Point(517, 358)
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
        Me.cmdReorder.Location = New System.Drawing.Point(413, 358)
        Me.cmdReorder.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdReorder.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdReorder.Name = "cmdReorder"
        Me.cmdReorder.Size = New System.Drawing.Size(100, 24)
        Me.cmdReorder.TabIndex = 8
        Me.cmdReorder.Text = "REORDER"
        Me.cmdReorder.UseVisualStyleBackColor = False
        '
        'lvwReorderList
        '
        Me.lvwReorderList.BackColor = System.Drawing.Color.White
        Me.lvwReorderList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwReorderList.CheckBoxes = True
        Me.lvwReorderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.StROLvw_Slot, Me.StROLvw_OldName, Me.StROLvw_NewName, Me.StROLvw_Status})
        Me.lvwReorderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwReorderList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwReorderList.ForeColor = System.Drawing.Color.Black
        Me.lvwReorderList.FullRowSelect = True
        Me.lvwReorderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwReorderList.HideSelection = False
        Me.lvwReorderList.Location = New System.Drawing.Point(8, 22)
        Me.lvwReorderList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwReorderList.MultiSelect = False
        Me.lvwReorderList.Name = "lvwReorderList"
        Me.lvwReorderList.Size = New System.Drawing.Size(588, 129)
        Me.lvwReorderList.TabIndex = 10
        Me.lvwReorderList.UseCompatibleStateImageBehavior = False
        Me.lvwReorderList.View = System.Windows.Forms.View.Details
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
        'cmdMoveLast
        '
        Me.cmdMoveLast.AutoSize = True
        Me.cmdMoveLast.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveLast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMoveLast.FlatAppearance.BorderSize = 0
        Me.cmdMoveLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveLast.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveLast.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderLast
        Me.cmdMoveLast.Location = New System.Drawing.Point(246, 0)
        Me.cmdMoveLast.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveLast.Name = "cmdMoveLast"
        Me.cmdMoveLast.Size = New System.Drawing.Size(52, 22)
        Me.cmdMoveLast.TabIndex = 16
        Me.cmdMoveLast.Text = "LAST"
        Me.cmdMoveLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdMoveFirst
        '
        Me.cmdMoveFirst.AutoSize = True
        Me.cmdMoveFirst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveFirst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMoveFirst.FlatAppearance.BorderSize = 0
        Me.cmdMoveFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveFirst.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveFirst.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderFirst
        Me.cmdMoveFirst.Location = New System.Drawing.Point(86, 0)
        Me.cmdMoveFirst.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveFirst.Name = "cmdMoveFirst"
        Me.cmdMoveFirst.Size = New System.Drawing.Size(55, 22)
        Me.cmdMoveFirst.TabIndex = 13
        Me.cmdMoveFirst.Text = "FIRST"
        Me.cmdMoveFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.AutoSize = True
        Me.cmdMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMoveUp.FlatAppearance.BorderSize = 0
        Me.cmdMoveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveUp.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveUp.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderUp
        Me.cmdMoveUp.Location = New System.Drawing.Point(141, 0)
        Me.cmdMoveUp.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(44, 22)
        Me.cmdMoveUp.TabIndex = 14
        Me.cmdMoveUp.Text = "UP"
        Me.cmdMoveUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.AutoSize = True
        Me.cmdMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMoveDown.FlatAppearance.BorderSize = 0
        Me.cmdMoveDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveDown.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveDown.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderDown
        Me.cmdMoveDown.Location = New System.Drawing.Point(185, 0)
        Me.cmdMoveDown.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(61, 22)
        Me.cmdMoveDown.TabIndex = 15
        Me.cmdMoveDown.Text = "DOWN"
        Me.cmdMoveDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'lblMove
        '
        Me.lblMove.AutoSize = True
        Me.lblMove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMove.Location = New System.Drawing.Point(2, 0)
        Me.lblMove.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMove.Name = "lblMove"
        Me.lblMove.Size = New System.Drawing.Size(82, 22)
        Me.lblMove.TabIndex = 32
        Me.lblMove.Text = "move checked:"
        Me.lblMove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flpMainListCommands
        '
        Me.flpMainListCommands.AutoSize = True
        Me.flpMainListCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpMainListCommands.Controls.Add(Me.cmdMoveLast)
        Me.flpMainListCommands.Controls.Add(Me.cmdMoveDown)
        Me.flpMainListCommands.Controls.Add(Me.cmdMoveUp)
        Me.flpMainListCommands.Controls.Add(Me.cmdMoveFirst)
        Me.flpMainListCommands.Controls.Add(Me.lblMove)
        Me.flpMainListCommands.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpMainListCommands.Location = New System.Drawing.Point(274, 0)
        Me.flpMainListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.flpMainListCommands.Name = "flpMainListCommands"
        Me.flpMainListCommands.Size = New System.Drawing.Size(298, 22)
        Me.flpMainListCommands.TabIndex = 12
        Me.flpMainListCommands.WrapContents = False
        '
        'pnlFormContent
        '
        Me.pnlFormContent.Controls.Add(Me.lvwReorderList)
        Me.pnlFormContent.Controls.Add(Me.ckbSStatesManReorderBackup)
        Me.pnlFormContent.Controls.Add(Me.tlpFileListStatus)
        Me.pnlFormContent.Controls.Add(Me.tlpFileListCommands)
        Me.pnlFormContent.Location = New System.Drawing.Point(12, 54)
        Me.pnlFormContent.Name = "pnlFormContent"
        Me.pnlFormContent.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
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
        Me.ckbSStatesManReorderBackup.Location = New System.Drawing.Point(8, 151)
        Me.ckbSStatesManReorderBackup.Name = "ckbSStatesManReorderBackup"
        Me.ckbSStatesManReorderBackup.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ckbSStatesManReorderBackup.Size = New System.Drawing.Size(588, 21)
        Me.ckbSStatesManReorderBackup.TabIndex = 41
        Me.ckbSStatesManReorderBackup.Text = "Reorder savestates together with their backup."
        Me.ckbSStatesManReorderBackup.UseVisualStyleBackColor = False
        '
        'tlpFileListStatus
        '
        Me.tlpFileListStatus.AutoSize = True
        Me.tlpFileListStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFileListStatus.ColumnCount = 3
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFileListStatus.Controls.Add(Me.lblSelected, 0, 0)
        Me.tlpFileListStatus.Controls.Add(Me.txtSelected, 0, 1)
        Me.tlpFileListStatus.Controls.Add(Me.lblSize, 1, 0)
        Me.tlpFileListStatus.Controls.Add(Me.txtSize, 1, 1)
        Me.tlpFileListStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpFileListStatus.Location = New System.Drawing.Point(8, 172)
        Me.tlpFileListStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListStatus.Name = "tlpFileListStatus"
        Me.tlpFileListStatus.RowCount = 2
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.Size = New System.Drawing.Size(588, 39)
        Me.tlpFileListStatus.TabIndex = 40
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
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(132, 0)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(66, 13)
        Me.lblSize.TabIndex = 20
        Me.lblSize.Text = "active | files"
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
        'frmReorderForm
        '
        Me.AcceptButton = Me.cmdReorder
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(628, 441)
        Me.Controls.Add(Me.pnlFormContent)
        Me.FormDescription = "use the move buttons to reorder the list and click ""reorder"" to confirm."
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.Location = New System.Drawing.Point(0, 0)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "frmReorderForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reorder"
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.pnlFormContent, 0)
        Me.flpMainListCommands.ResumeLayout(False)
        Me.flpMainListCommands.PerformLayout()
        Me.pnlFormContent.ResumeLayout(False)
        Me.pnlFormContent.PerformLayout()
        Me.tlpFileListStatus.ResumeLayout(False)
        Me.tlpFileListStatus.PerformLayout()
        Me.tlpFileListCommands.ResumeLayout(False)
        Me.tlpFileListCommands.PerformLayout()
        Me.flpFileListCommandsFiles.ResumeLayout(False)
        Me.flpFileListCommandsFiles.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblMove As System.Windows.Forms.Label
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdReorder As System.Windows.Forms.Button
    Private WithEvents lvwReorderList As System.Windows.Forms.ListView
    Private WithEvents StROLvw_Slot As System.Windows.Forms.ColumnHeader
    Private WithEvents StROLvw_OldName As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdMoveLast As System.Windows.Forms.Button
    Private WithEvents cmdMoveFirst As System.Windows.Forms.Button
    Private WithEvents cmdMoveUp As System.Windows.Forms.Button
    Private WithEvents cmdMoveDown As System.Windows.Forms.Button
    Private WithEvents flpMainListCommands As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents StROLvw_NewName As System.Windows.Forms.ColumnHeader
    Private WithEvents pnlFormContent As System.Windows.Forms.Panel
    Private WithEvents StROLvw_Status As System.Windows.Forms.ColumnHeader
    Private WithEvents tlpFileListCommands As System.Windows.Forms.TableLayoutPanel
    Private WithEvents flpFileListCommandsFiles As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdSortReset As System.Windows.Forms.Button
    Private WithEvents tlpFileListStatus As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblSelected As System.Windows.Forms.Label
    Private WithEvents txtSelected As System.Windows.Forms.TextBox
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents txtSize As System.Windows.Forms.TextBox
    Private WithEvents ckbSStatesManReorderBackup As System.Windows.Forms.CheckBox
End Class
