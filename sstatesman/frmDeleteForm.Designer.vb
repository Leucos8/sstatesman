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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeleteForm))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdDeleteSStateSelected = New System.Windows.Forms.Button()
        Me.lvwSStatesListToDelete = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(520, 298)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 23)
        Me.cmdCancel.TabIndex = 18
        Me.cmdCancel.Text = "CLOSE"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdDeleteSStateSelected
        '
        Me.cmdDeleteSStateSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSStateSelected.BackColor = System.Drawing.Color.White
        Me.cmdDeleteSStateSelected.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.cmdDeleteSStateSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdDeleteSStateSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdDeleteSStateSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDeleteSStateSelected.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteSStateSelected.Location = New System.Drawing.Point(414, 298)
        Me.cmdDeleteSStateSelected.Name = "cmdDeleteSStateSelected"
        Me.cmdDeleteSStateSelected.Size = New System.Drawing.Size(100, 23)
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
        Me.lvwSStatesListToDelete.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader14, Me.ColumnHeader2})
        Me.lvwSStatesListToDelete.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwSStatesListToDelete.ForeColor = System.Drawing.Color.DimGray
        Me.lvwSStatesListToDelete.FullRowSelect = True
        Me.lvwSStatesListToDelete.GridLines = True
        Me.lvwSStatesListToDelete.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSStatesListToDelete.Location = New System.Drawing.Point(12, 102)
        Me.lvwSStatesListToDelete.MultiSelect = False
        Me.lvwSStatesListToDelete.Name = "lvwSStatesListToDelete"
        Me.lvwSStatesListToDelete.Size = New System.Drawing.Size(608, 150)
        Me.lvwSStatesListToDelete.TabIndex = 20
        Me.lvwSStatesListToDelete.UseCompatibleStateImageBehavior = False
        Me.lvwSStatesListToDelete.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Savestate filename"
        Me.ColumnHeader4.Width = 240
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Slot"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 40
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Backup"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Size"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Serial"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "#"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Status"
        Me.ColumnHeader2.Width = 120
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
        Me.cmdSStateSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateSelectInvert.Location = New System.Drawing.Point(555, 81)
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
        Me.cmdSStateSelectBackup.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateSelectBackup.Location = New System.Drawing.Point(420, 81)
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
        Me.cmdSStateSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateSelectAll.Location = New System.Drawing.Point(475, 81)
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
        Me.cmdSStateSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateSelectNone.Location = New System.Drawing.Point(515, 81)
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
        Me.txtSStateListSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSStateListSelection.ForeColor = System.Drawing.Color.DimGray
        Me.txtSStateListSelection.Location = New System.Drawing.Point(90, 258)
        Me.txtSStateListSelection.Name = "txtSStateListSelection"
        Me.txtSStateListSelection.ReadOnly = True
        Me.txtSStateListSelection.Size = New System.Drawing.Size(96, 22)
        Me.txtSStateListSelection.TabIndex = 31
        Me.txtSStateListSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSizeBackup.BackColor = System.Drawing.Color.Transparent
        Me.lblSizeBackup.Location = New System.Drawing.Point(414, 261)
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
        Me.lblSStateListSelection.Location = New System.Drawing.Point(12, 261)
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
        Me.lblSize.Location = New System.Drawing.Point(202, 261)
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
        Me.txtSizeBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeBackup.ForeColor = System.Drawing.Color.DimGray
        Me.txtSizeBackup.Location = New System.Drawing.Point(492, 258)
        Me.txtSizeBackup.Name = "txtSizeBackup"
        Me.txtSizeBackup.ReadOnly = True
        Me.txtSizeBackup.Size = New System.Drawing.Size(128, 22)
        Me.txtSizeBackup.TabIndex = 27
        Me.txtSizeBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSize
        '
        Me.txtSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSize.ForeColor = System.Drawing.Color.DimGray
        Me.txtSize.Location = New System.Drawing.Point(280, 258)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(128, 22)
        Me.txtSize.TabIndex = 26
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGameListCheck
        '
        Me.lblGameListCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGameListCheck.AutoSize = True
        Me.lblGameListCheck.BackColor = System.Drawing.Color.Transparent
        Me.lblGameListCheck.Location = New System.Drawing.Point(323, 84)
        Me.lblGameListCheck.Name = "lblGameListCheck"
        Me.lblGameListCheck.Size = New System.Drawing.Size(94, 13)
        Me.lblGameListCheck.TabIndex = 32
        Me.lblGameListCheck.Text = "check savestates:"
        Me.lblGameListCheck.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.BackgroundImage = Global.sstatesman.My.Resources.Resources.Bg2
        Me.panelWindowTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientIcon)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMaximize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowClose)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowTitle)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.lblWindowProgramName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cmdWindowMaximize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWindowMaximize.Image = CType(resources.GetObject("cmdWindowMaximize.Image"), System.Drawing.Image)
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
        Me.cmdWindowClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWindowClose.Image = CType(resources.GetObject("cmdWindowClose.Image"), System.Drawing.Image)
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
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(30, 24)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(197, 30)
        Me.lblWindowTitle.TabIndex = 4
        Me.lblWindowTitle.Text = "Delete confirmation"
        '
        'frmDeleteForm
        '
        Me.AcceptButton = Me.cmdDeleteSStateSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
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
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 320)
        Me.Name = "frmDeleteForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delete confirmation"
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteSStateSelected As System.Windows.Forms.Button
    Friend WithEvents lvwSStatesListToDelete As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Friend WithEvents cmdWindowClose As System.Windows.Forms.Button
    Friend WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Friend WithEvents lblWindowTitle As System.Windows.Forms.Label
    Friend WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Friend WithEvents cmdSStateSelectInvert As System.Windows.Forms.Button
    Friend WithEvents cmdSStateSelectBackup As System.Windows.Forms.Button
    Friend WithEvents cmdSStateSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSStateSelectNone As System.Windows.Forms.Button
    Friend WithEvents txtSStateListSelection As System.Windows.Forms.TextBox
    Friend WithEvents lblSizeBackup As System.Windows.Forms.Label
    Friend WithEvents lblSStateListSelection As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Private WithEvents lblGameListCheck As System.Windows.Forms.Label
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
End Class
