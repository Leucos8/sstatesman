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
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowPanelGameList = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.panelWindowTitle.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpWindowBottom.SuspendLayout()
        Me.FlowPanelGameList.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.AutoSize = True
        Me.cmdCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCancel.BackColor = System.Drawing.Color.White
        Me.cmdCancel.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.Location = New System.Drawing.Point(514, 6)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "CLOSE"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdDeleteSStateSelected
        '
        Me.cmdDeleteSStateSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSStateSelected.AutoSize = True
        Me.cmdDeleteSStateSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdDeleteSStateSelected.BackColor = System.Drawing.Color.White
        Me.cmdDeleteSStateSelected.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdDeleteSStateSelected.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdDeleteSStateSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdDeleteSStateSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdDeleteSStateSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDeleteSStateSelected.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdDeleteSStateSelected.Location = New System.Drawing.Point(410, 6)
        Me.cmdDeleteSStateSelected.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdDeleteSStateSelected.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdDeleteSStateSelected.Name = "cmdDeleteSStateSelected"
        Me.cmdDeleteSStateSelected.Size = New System.Drawing.Size(100, 24)
        Me.cmdDeleteSStateSelected.TabIndex = 8
        Me.cmdDeleteSStateSelected.Text = "DELETE CHECKED"
        Me.cmdDeleteSStateSelected.UseVisualStyleBackColor = False
        '
        'lvwSStatesListToDelete
        '
        Me.lvwSStatesListToDelete.BackColor = System.Drawing.Color.White
        Me.lvwSStatesListToDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwSStatesListToDelete.CheckBoxes = True
        Me.lvwSStatesListToDelete.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SStateLvw_FileName, Me.SStatesLvw_Slot, Me.SStatesLvw_Backup, Me.SStatesLvw_Size, Me.SStatesLvw_SerialRef, Me.SStatesLvw_ArrayRef, Me.SStatesLvw_Status})
        Me.lvwSStatesListToDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSStatesListToDelete.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwSStatesListToDelete.ForeColor = System.Drawing.Color.DimGray
        Me.lvwSStatesListToDelete.FullRowSelect = True
        Me.lvwSStatesListToDelete.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSStatesListToDelete.Location = New System.Drawing.Point(0, 78)
        Me.lvwSStatesListToDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwSStatesListToDelete.MultiSelect = False
        Me.lvwSStatesListToDelete.Name = "lvwSStatesListToDelete"
        Me.lvwSStatesListToDelete.Size = New System.Drawing.Size(624, 191)
        Me.lvwSStatesListToDelete.TabIndex = 10
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
        Me.cmdSStateSelectInvert.AutoSize = True
        Me.cmdSStateSelectInvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSStateSelectInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectInvert.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectInvert.Location = New System.Drawing.Point(553, 0)
        Me.cmdSStateSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectInvert.Name = "cmdSStateSelectInvert"
        Me.cmdSStateSelectInvert.Size = New System.Drawing.Size(47, 22)
        Me.cmdSStateSelectInvert.TabIndex = 16
        Me.cmdSStateSelectInvert.Text = "INVERT"
        Me.cmdSStateSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectBackup
        '
        Me.cmdSStateSelectBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectBackup.AutoSize = True
        Me.cmdSStateSelectBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSStateSelectBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectBackup.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectBackup.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectBackup.Location = New System.Drawing.Point(424, 0)
        Me.cmdSStateSelectBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectBackup.Name = "cmdSStateSelectBackup"
        Me.cmdSStateSelectBackup.Size = New System.Drawing.Size(57, 22)
        Me.cmdSStateSelectBackup.TabIndex = 13
        Me.cmdSStateSelectBackup.Text = "BACKUPS"
        Me.cmdSStateSelectBackup.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectAll
        '
        Me.cmdSStateSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectAll.AutoSize = True
        Me.cmdSStateSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSStateSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectAll.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectAll.Location = New System.Drawing.Point(481, 0)
        Me.cmdSStateSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectAll.Name = "cmdSStateSelectAll"
        Me.cmdSStateSelectAll.Size = New System.Drawing.Size(31, 22)
        Me.cmdSStateSelectAll.TabIndex = 14
        Me.cmdSStateSelectAll.Text = "ALL"
        Me.cmdSStateSelectAll.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectNone
        '
        Me.cmdSStateSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectNone.AutoSize = True
        Me.cmdSStateSelectNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSStateSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectNone.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectNone.Location = New System.Drawing.Point(512, 0)
        Me.cmdSStateSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectNone.Name = "cmdSStateSelectNone"
        Me.cmdSStateSelectNone.Size = New System.Drawing.Size(41, 22)
        Me.cmdSStateSelectNone.TabIndex = 15
        Me.cmdSStateSelectNone.Text = "NONE"
        Me.cmdSStateSelectNone.UseVisualStyleBackColor = False
        '
        'txtSStateListSelection
        '
        Me.txtSStateListSelection.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSStateListSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSStateListSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSStateListSelection.ForeColor = System.Drawing.Color.DimGray
        Me.txtSStateListSelection.Location = New System.Drawing.Point(2, 15)
        Me.txtSStateListSelection.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSStateListSelection.Name = "txtSStateListSelection"
        Me.txtSStateListSelection.ReadOnly = True
        Me.txtSStateListSelection.Size = New System.Drawing.Size(128, 22)
        Me.txtSStateListSelection.TabIndex = 19
        Me.txtSStateListSelection.TabStop = False
        Me.txtSStateListSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.AutoSize = True
        Me.lblSizeBackup.Location = New System.Drawing.Point(266, 0)
        Me.lblSizeBackup.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSizeBackup.Name = "lblSizeBackup"
        Me.lblSizeBackup.Size = New System.Drawing.Size(72, 13)
        Me.lblSizeBackup.TabIndex = 22
        Me.lblSizeBackup.Text = "backups size"
        '
        'lblSStateListSelection
        '
        Me.lblSStateListSelection.AutoSize = True
        Me.lblSStateListSelection.Location = New System.Drawing.Point(2, 0)
        Me.lblSStateListSelection.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSStateListSelection.Name = "lblSStateListSelection"
        Me.lblSStateListSelection.Size = New System.Drawing.Size(53, 13)
        Me.lblSStateListSelection.TabIndex = 18
        Me.lblSStateListSelection.Text = "selection"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(134, 0)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(64, 13)
        Me.lblSize.TabIndex = 20
        Me.lblSize.Text = "sstates size"
        '
        'txtSizeBackup
        '
        Me.txtSizeBackup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSizeBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSizeBackup.ForeColor = System.Drawing.Color.DimGray
        Me.txtSizeBackup.Location = New System.Drawing.Point(266, 15)
        Me.txtSizeBackup.Margin = New System.Windows.Forms.Padding(2)
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
        Me.txtSize.ForeColor = System.Drawing.Color.DimGray
        Me.txtSize.Location = New System.Drawing.Point(134, 15)
        Me.txtSize.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(128, 22)
        Me.txtSize.TabIndex = 21
        Me.txtSize.TabStop = False
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGameListCheck
        '
        Me.lblGameListCheck.AutoSize = True
        Me.lblGameListCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameListCheck.Location = New System.Drawing.Point(328, 0)
        Me.lblGameListCheck.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameListCheck.Name = "lblGameListCheck"
        Me.lblGameListCheck.Size = New System.Drawing.Size(94, 22)
        Me.lblGameListCheck.TabIndex = 32
        Me.lblGameListCheck.Text = "check savestates:"
        Me.lblGameListCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.AutoSize = True
        Me.panelWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.panelWindowTitle.Controls.Add(Me.TableLayoutPanel1)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.panelWindowTitle.MinimumSize = New System.Drawing.Size(0, 56)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(624, 56)
        Me.panelWindowTitle.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel2.Controls.Add(Me.lblWindowTitle)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(24, 4, 0, 4)
        Me.TableLayoutPanel1.SetRowSpan(Me.FlowLayoutPanel2, 3)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(528, 52)
        Me.FlowLayoutPanel2.TabIndex = 1
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.lblWindowTitle.Location = New System.Drawing.Point(26, 4)
        Me.lblWindowTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(197, 30)
        Me.lblWindowTitle.TabIndex = 2
        Me.lblWindowTitle.Text = "Delete confirmation"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.imgWindowGradientIcon, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 56)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowMaximize)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowClose)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(570, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(48, 16)
        Me.FlowLayoutPanel1.TabIndex = 4
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'cmdWindowMaximize
        '
        Me.cmdWindowMaximize.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowMaximize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowMaximize.FlatAppearance.BorderSize = 0
        Me.cmdWindowMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdWindowMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdWindowMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowMaximize.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowMaximize.Image = Global.sstatesman.My.Resources.Resources.Metro_WindowButtonMaximize
        Me.cmdWindowMaximize.Location = New System.Drawing.Point(0, 0)
        Me.cmdWindowMaximize.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowMaximize.Name = "cmdWindowMaximize"
        Me.cmdWindowMaximize.Size = New System.Drawing.Size(24, 16)
        Me.cmdWindowMaximize.TabIndex = 5
        Me.cmdWindowMaximize.UseVisualStyleBackColor = False
        '
        'cmdWindowClose
        '
        Me.cmdWindowClose.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowClose.FlatAppearance.BorderSize = 0
        Me.cmdWindowClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdWindowClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdWindowClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowClose.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowClose.Image = Global.sstatesman.My.Resources.Resources.Metro_WindowButtonClose
        Me.cmdWindowClose.Location = New System.Drawing.Point(24, 0)
        Me.cmdWindowClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowClose.Name = "cmdWindowClose"
        Me.cmdWindowClose.Size = New System.Drawing.Size(24, 16)
        Me.cmdWindowClose.TabIndex = 6
        Me.cmdWindowClose.UseVisualStyleBackColor = False
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgWindowGradientIcon.Image = Global.sstatesman.My.Resources.Resources.SSM1ico24
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(535, 0)
        Me.imgWindowGradientIcon.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.TableLayoutPanel1.SetRowSpan(Me.imgWindowGradientIcon, 2)
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.BackColor = System.Drawing.Color.Gainsboro
        Me.flpWindowBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.flpWindowBottom.Controls.Add(Me.cmdCancel)
        Me.flpWindowBottom.Controls.Add(Me.cmdDeleteSStateSelected)
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 308)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4)
        Me.flpWindowBottom.Size = New System.Drawing.Size(624, 36)
        Me.flpWindowBottom.TabIndex = 7
        '
        'FlowPanelGameList
        '
        Me.FlowPanelGameList.AutoSize = True
        Me.FlowPanelGameList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowPanelGameList.Controls.Add(Me.cmdSStateSelectInvert)
        Me.FlowPanelGameList.Controls.Add(Me.cmdSStateSelectNone)
        Me.FlowPanelGameList.Controls.Add(Me.cmdSStateSelectAll)
        Me.FlowPanelGameList.Controls.Add(Me.cmdSStateSelectBackup)
        Me.FlowPanelGameList.Controls.Add(Me.lblGameListCheck)
        Me.FlowPanelGameList.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowPanelGameList.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowPanelGameList.Location = New System.Drawing.Point(0, 56)
        Me.FlowPanelGameList.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowPanelGameList.Name = "FlowPanelGameList"
        Me.FlowPanelGameList.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.FlowPanelGameList.Size = New System.Drawing.Size(624, 22)
        Me.FlowPanelGameList.TabIndex = 12
        Me.FlowPanelGameList.WrapContents = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblSStateListSelection, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSStateListSelection, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSizeBackup, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSize, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSizeBackup, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSize, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 269)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(624, 39)
        Me.TableLayoutPanel2.TabIndex = 17
        '
        'frmDeleteForm
        '
        Me.AcceptButton = Me.cmdDeleteSStateSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(624, 344)
        Me.ControlBox = False
        Me.Controls.Add(Me.lvwSStatesListToDelete)
        Me.Controls.Add(Me.FlowPanelGameList)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "frmDeleteForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delete confirmation"
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpWindowBottom.ResumeLayout(False)
        Me.flpWindowBottom.PerformLayout()
        Me.FlowPanelGameList.ResumeLayout(False)
        Me.FlowPanelGameList.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblGameListCheck As System.Windows.Forms.Label
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
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Private WithEvents cmdWindowClose As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Friend WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowPanelGameList As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class
