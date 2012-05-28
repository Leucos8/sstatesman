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
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteForm
    Inherits System.Windows.Forms.Form

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
        Me.cmdDeleteSStateSelected = New System.Windows.Forms.Button()
        Me.lvwSStatesListToDelete = New System.Windows.Forms.ListView()
        Me.SStateLvw_FileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Slot = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Backup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_SerialRef = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_ArrayRef = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdSStateSelectInvert = New System.Windows.Forms.Button()
        Me.cmdSStateSelectBackup = New System.Windows.Forms.Button()
        Me.cmdSStateSelectAll = New System.Windows.Forms.Button()
        Me.cmdSStateSelectNone = New System.Windows.Forms.Button()
        Me.txtSStateListSelection = New System.Windows.Forms.TextBox()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.lblSStateListSelection = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSizeBackup = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.lblGameListCheck = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.lblWindowProgramName = New System.Windows.Forms.Label()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientLeft = New System.Windows.Forms.PictureBox()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.panelWindowTitle.SuspendLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.Color.White
        Me.cmdCancel.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.Location = New System.Drawing.Point(520, 299)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 22)
        Me.cmdCancel.TabIndex = 18
        Me.cmdCancel.Text = "CLOSE"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdDeleteSStateSelected
        '
        Me.cmdDeleteSStateSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSStateSelected.BackColor = System.Drawing.Color.White
        Me.cmdDeleteSStateSelected.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdDeleteSStateSelected.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.cmdDeleteSStateSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdDeleteSStateSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdDeleteSStateSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDeleteSStateSelected.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdDeleteSStateSelected.Location = New System.Drawing.Point(414, 299)
        Me.cmdDeleteSStateSelected.Name = "cmdDeleteSStateSelected"
        Me.cmdDeleteSStateSelected.Size = New System.Drawing.Size(100, 22)
        Me.cmdDeleteSStateSelected.TabIndex = 17
        Me.cmdDeleteSStateSelected.Text = "DELETE CHECKED"
        Me.cmdDeleteSStateSelected.UseVisualStyleBackColor = False
        '
        'lvwSStatesListToDelete
        '
        Me.lvwSStatesListToDelete.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwSStatesListToDelete.BackColor = System.Drawing.Color.White
        Me.lvwSStatesListToDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwSStatesListToDelete.CheckBoxes = True
        Me.lvwSStatesListToDelete.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SStateLvw_FileName, Me.SStatesLvw_Slot, Me.SStatesLvw_Backup, Me.SStatesLvw_Size, Me.SStatesLvw_SerialRef, Me.SStatesLvw_ArrayRef, Me.SStatesLvw_Status})
        Me.lvwSStatesListToDelete.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwSStatesListToDelete.ForeColor = System.Drawing.Color.DimGray
        Me.lvwSStatesListToDelete.FullRowSelect = True
        Me.lvwSStatesListToDelete.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSStatesListToDelete.Location = New System.Drawing.Point(12, 96)
        Me.lvwSStatesListToDelete.MultiSelect = False
        Me.lvwSStatesListToDelete.Name = "lvwSStatesListToDelete"
        Me.lvwSStatesListToDelete.Size = New System.Drawing.Size(608, 168)
        Me.lvwSStatesListToDelete.TabIndex = 20
        Me.lvwSStatesListToDelete.UseCompatibleStateImageBehavior = False
        Me.lvwSStatesListToDelete.View = System.Windows.Forms.View.Details
        '
        'SStateLvw_FileName
        '
        Me.SStateLvw_FileName.Text = "Savestate file name"
        Me.SStateLvw_FileName.Width = 240
        '
        'SStatesLvw_Slot
        '
        Me.SStatesLvw_Slot.Text = "Slot"
        Me.SStatesLvw_Slot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SStatesLvw_Slot.Width = 40
        '
        'SStatesLvw_Backup
        '
        Me.SStatesLvw_Backup.Text = "Backup"
        '
        'SStatesLvw_Size
        '
        Me.SStatesLvw_Size.Text = "Size"
        Me.SStatesLvw_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SStatesLvw_Size.Width = 100
        '
        'SStatesLvw_SerialRef
        '
        Me.SStatesLvw_SerialRef.Text = "Serial"
        Me.SStatesLvw_SerialRef.Width = 0
        '
        'SStatesLvw_ArrayRef
        '
        Me.SStatesLvw_ArrayRef.Text = "#"
        Me.SStatesLvw_ArrayRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SStatesLvw_ArrayRef.Width = 0
        '
        'SStatesLvw_Status
        '
        Me.SStatesLvw_Status.Text = "Status"
        Me.SStatesLvw_Status.Width = 120
        '
        'cmdSStateSelectInvert
        '
        Me.cmdSStateSelectInvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectInvert.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateSelectInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectInvert.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateSelectInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectInvert.Location = New System.Drawing.Point(555, 73)
        Me.cmdSStateSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectInvert.Name = "cmdSStateSelectInvert"
        Me.cmdSStateSelectInvert.Size = New System.Drawing.Size(45, 20)
        Me.cmdSStateSelectInvert.TabIndex = 25
        Me.cmdSStateSelectInvert.Text = "INVERT"
        Me.cmdSStateSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectBackup
        '
        Me.cmdSStateSelectBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectBackup.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateSelectBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectBackup.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateSelectBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectBackup.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectBackup.Location = New System.Drawing.Point(420, 73)
        Me.cmdSStateSelectBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectBackup.Name = "cmdSStateSelectBackup"
        Me.cmdSStateSelectBackup.Size = New System.Drawing.Size(55, 20)
        Me.cmdSStateSelectBackup.TabIndex = 24
        Me.cmdSStateSelectBackup.Text = "BACKUPS"
        Me.cmdSStateSelectBackup.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectAll
        '
        Me.cmdSStateSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectAll.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectAll.Location = New System.Drawing.Point(475, 73)
        Me.cmdSStateSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectAll.Name = "cmdSStateSelectAll"
        Me.cmdSStateSelectAll.Size = New System.Drawing.Size(40, 20)
        Me.cmdSStateSelectAll.TabIndex = 22
        Me.cmdSStateSelectAll.Text = "ALL"
        Me.cmdSStateSelectAll.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectNone
        '
        Me.cmdSStateSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectNone.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectNone.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectNone.Location = New System.Drawing.Point(515, 73)
        Me.cmdSStateSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectNone.Name = "cmdSStateSelectNone"
        Me.cmdSStateSelectNone.Size = New System.Drawing.Size(40, 20)
        Me.cmdSStateSelectNone.TabIndex = 23
        Me.cmdSStateSelectNone.Text = "NONE"
        Me.cmdSStateSelectNone.UseVisualStyleBackColor = False
        '
        'txtSStateListSelection
        '
        Me.txtSStateListSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSStateListSelection.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSStateListSelection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSStateListSelection.ForeColor = System.Drawing.Color.DimGray
        Me.txtSStateListSelection.Location = New System.Drawing.Point(90, 270)
        Me.txtSStateListSelection.Name = "txtSStateListSelection"
        Me.txtSStateListSelection.ReadOnly = True
        Me.txtSStateListSelection.Size = New System.Drawing.Size(96, 15)
        Me.txtSStateListSelection.TabIndex = 31
        Me.txtSStateListSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSizeBackup.BackColor = System.Drawing.Color.Transparent
        Me.lblSizeBackup.Location = New System.Drawing.Point(414, 270)
        Me.lblSizeBackup.Name = "lblSizeBackup"
        Me.lblSizeBackup.Size = New System.Drawing.Size(72, 13)
        Me.lblSizeBackup.TabIndex = 29
        Me.lblSizeBackup.Text = "backups size"
        Me.lblSizeBackup.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSStateListSelection
        '
        Me.lblSStateListSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSStateListSelection.BackColor = System.Drawing.Color.Transparent
        Me.lblSStateListSelection.Location = New System.Drawing.Point(12, 270)
        Me.lblSStateListSelection.Name = "lblSStateListSelection"
        Me.lblSStateListSelection.Size = New System.Drawing.Size(72, 13)
        Me.lblSStateListSelection.TabIndex = 30
        Me.lblSStateListSelection.Text = "selection"
        Me.lblSStateListSelection.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSize.BackColor = System.Drawing.Color.Transparent
        Me.lblSize.Location = New System.Drawing.Point(202, 270)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(72, 13)
        Me.lblSize.TabIndex = 28
        Me.lblSize.Text = "sstates size"
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSizeBackup
        '
        Me.txtSizeBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSizeBackup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSizeBackup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSizeBackup.ForeColor = System.Drawing.Color.DimGray
        Me.txtSizeBackup.Location = New System.Drawing.Point(492, 270)
        Me.txtSizeBackup.Name = "txtSizeBackup"
        Me.txtSizeBackup.ReadOnly = True
        Me.txtSizeBackup.Size = New System.Drawing.Size(128, 15)
        Me.txtSizeBackup.TabIndex = 27
        Me.txtSizeBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSize
        '
        Me.txtSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSize.ForeColor = System.Drawing.Color.DimGray
        Me.txtSize.Location = New System.Drawing.Point(280, 270)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(128, 15)
        Me.txtSize.TabIndex = 26
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGameListCheck
        '
        Me.lblGameListCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGameListCheck.AutoSize = True
        Me.lblGameListCheck.BackColor = System.Drawing.Color.Transparent
        Me.lblGameListCheck.Location = New System.Drawing.Point(323, 76)
        Me.lblGameListCheck.Name = "lblGameListCheck"
        Me.lblGameListCheck.Size = New System.Drawing.Size(94, 13)
        Me.lblGameListCheck.TabIndex = 32
        Me.lblGameListCheck.Text = "check savestates:"
        Me.lblGameListCheck.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.BackgroundImage = Global.sstatesman.My.Resources.Resources.Bg3_1
        Me.panelWindowTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientIcon)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMaximize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowClose)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowTitle)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(632, 70)
        Me.panelWindowTitle.TabIndex = 21
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgWindowGradientIcon.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(561, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.TabIndex = 16
        Me.imgWindowGradientIcon.TabStop = False
        '
        'lblWindowProgramName
        '
        Me.lblWindowProgramName.AutoSize = True
        Me.lblWindowProgramName.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowProgramName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblWindowProgramName.Location = New System.Drawing.Point(9, 6)
        Me.lblWindowProgramName.Name = "lblWindowProgramName"
        Me.lblWindowProgramName.Size = New System.Drawing.Size(79, 13)
        Me.lblWindowProgramName.TabIndex = 15
        Me.lblWindowProgramName.Text = "SSTATESMAN"
        '
        'cmdWindowMaximize
        '
        Me.cmdWindowMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWindowMaximize.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowMaximize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdWindowMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdWindowMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowMaximize.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowMaximize.Image = Global.sstatesman.My.Resources.Resources.Metro_WindowButtonMaximize
        Me.cmdWindowMaximize.Location = New System.Drawing.Point(599, 4)
        Me.cmdWindowMaximize.Name = "cmdWindowMaximize"
        Me.cmdWindowMaximize.Size = New System.Drawing.Size(15, 15)
        Me.cmdWindowMaximize.TabIndex = 14
        Me.cmdWindowMaximize.UseVisualStyleBackColor = False
        '
        'cmdWindowClose
        '
        Me.cmdWindowClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWindowClose.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdWindowClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdWindowClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowClose.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowClose.Image = Global.sstatesman.My.Resources.Resources.Metro_WindowButtonClose
        Me.cmdWindowClose.Location = New System.Drawing.Point(613, 4)
        Me.cmdWindowClose.Name = "cmdWindowClose"
        Me.cmdWindowClose.Size = New System.Drawing.Size(15, 15)
        Me.cmdWindowClose.TabIndex = 13
        Me.cmdWindowClose.UseVisualStyleBackColor = False
        '
        'imgWindowGradientLeft
        '
        Me.imgWindowGradientLeft.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientLeft.Location = New System.Drawing.Point(0, 24)
        Me.imgWindowGradientLeft.Name = "imgWindowGradientLeft"
        Me.imgWindowGradientLeft.Size = New System.Drawing.Size(24, 40)
        Me.imgWindowGradientLeft.TabIndex = 3
        Me.imgWindowGradientLeft.TabStop = False
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblWindowTitle.Location = New System.Drawing.Point(30, 24)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(147, 21)
        Me.lblWindowTitle.TabIndex = 4
        Me.lblWindowTitle.Text = "Delete confirmation"
        '
        'frmDeleteForm
        '
        Me.AcceptButton = Me.cmdDeleteSStateSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(632, 333)
        Me.Controls.Add(Me.lblGameListCheck)
        Me.Controls.Add(Me.txtSStateListSelection)
        Me.Controls.Add(Me.lblSizeBackup)
        Me.Controls.Add(Me.lblSStateListSelection)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.txtSizeBackup)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.cmdSStateSelectInvert)
        Me.Controls.Add(Me.cmdSStateSelectBackup)
        Me.Controls.Add(Me.cmdSStateSelectAll)
        Me.Controls.Add(Me.cmdSStateSelectNone)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Controls.Add(Me.lvwSStatesListToDelete)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDeleteSStateSelected)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Icon = Global.sstatesman.My.Resources.SSM1
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 320)
        Me.Name = "frmDeleteForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delete confirmation"
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblGameListCheck As System.Windows.Forms.Label
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdDeleteSStateSelected As System.Windows.Forms.Button
    Private WithEvents lvwSStatesListToDelete As System.Windows.Forms.ListView
    Private WithEvents SStateLvw_FileName As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Slot As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Backup As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Size As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_SerialRef As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_ArrayRef As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Status As System.Windows.Forms.ColumnHeader
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Private WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Private WithEvents cmdWindowClose As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Private WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Private WithEvents cmdSStateSelectInvert As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectBackup As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectAll As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectNone As System.Windows.Forms.Button
    Private WithEvents txtSStateListSelection As System.Windows.Forms.TextBox
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents lblSStateListSelection As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Private WithEvents txtSize As System.Windows.Forms.TextBox
End Class
