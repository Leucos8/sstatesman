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
Partial Class frmReorderForm
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
        Me.pnlTopPanel = New System.Windows.Forms.Panel()
        Me.tlpTopPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.flpTitleBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.blWindowDescription = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.flpBottomPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.flpMainListCommands = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlWindowContent = New System.Windows.Forms.Panel()
        Me.tlpFileListStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.tlpFileListCommands = New System.Windows.Forms.TableLayoutPanel()
        Me.flpFileListCommandsFiles = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdSortReset = New System.Windows.Forms.Button()
        Me.pnlTopPanel.SuspendLayout()
        Me.tlpTopPanel.SuspendLayout()
        Me.flpTitleBar.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpBottomPanel.SuspendLayout()
        Me.flpMainListCommands.SuspendLayout()
        Me.pnlWindowContent.SuspendLayout()
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
        Me.cmdCancel.Location = New System.Drawing.Point(518, 6)
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
        Me.cmdReorder.Location = New System.Drawing.Point(414, 6)
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
        Me.lvwReorderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.StROLvw_Slot, Me.StROLvw_OldName, Me.StROLvw_NewName, Me.StROLvw_Status})
        Me.lvwReorderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwReorderList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwReorderList.ForeColor = System.Drawing.Color.Black
        Me.lvwReorderList.FullRowSelect = True
        Me.lvwReorderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwReorderList.HideSelection = False
        Me.lvwReorderList.Location = New System.Drawing.Point(8, 22)
        Me.lvwReorderList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwReorderList.Name = "lvwReorderList"
        Me.lvwReorderList.Size = New System.Drawing.Size(612, 191)
        Me.lvwReorderList.TabIndex = 10
        Me.lvwReorderList.UseCompatibleStateImageBehavior = False
        Me.lvwReorderList.View = System.Windows.Forms.View.Details
        '
        'StROLvw_Slot
        '
        Me.StROLvw_Slot.Text = "Slot"
        Me.StROLvw_Slot.Width = 40
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
        Me.StROLvw_Status.Width = 140
        '
        'cmdMoveLast
        '
        Me.cmdMoveLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveLast.AutoSize = True
        Me.cmdMoveLast.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveLast.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdMoveLast.FlatAppearance.BorderSize = 0
        Me.cmdMoveLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveLast.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveLast.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderLast_16x16
        Me.cmdMoveLast.Location = New System.Drawing.Point(246, 0)
        Me.cmdMoveLast.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveLast.Name = "cmdMoveLast"
        Me.cmdMoveLast.Size = New System.Drawing.Size(52, 22)
        Me.cmdMoveLast.TabIndex = 16
        Me.cmdMoveLast.Text = "LAST"
        Me.cmdMoveLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdMoveLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdMoveLast.UseVisualStyleBackColor = False
        '
        'cmdMoveFirst
        '
        Me.cmdMoveFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveFirst.AutoSize = True
        Me.cmdMoveFirst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveFirst.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdMoveFirst.FlatAppearance.BorderSize = 0
        Me.cmdMoveFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveFirst.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveFirst.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderFirst_16x16
        Me.cmdMoveFirst.Location = New System.Drawing.Point(86, 0)
        Me.cmdMoveFirst.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveFirst.Name = "cmdMoveFirst"
        Me.cmdMoveFirst.Size = New System.Drawing.Size(55, 22)
        Me.cmdMoveFirst.TabIndex = 13
        Me.cmdMoveFirst.Text = "FIRST"
        Me.cmdMoveFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdMoveFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdMoveFirst.UseVisualStyleBackColor = False
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveUp.AutoSize = True
        Me.cmdMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveUp.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdMoveUp.FlatAppearance.BorderSize = 0
        Me.cmdMoveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveUp.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveUp.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderUp_16x16
        Me.cmdMoveUp.Location = New System.Drawing.Point(141, 0)
        Me.cmdMoveUp.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(44, 22)
        Me.cmdMoveUp.TabIndex = 14
        Me.cmdMoveUp.Text = "UP"
        Me.cmdMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdMoveUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdMoveUp.UseVisualStyleBackColor = False
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveDown.AutoSize = True
        Me.cmdMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdMoveDown.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdMoveDown.FlatAppearance.BorderSize = 0
        Me.cmdMoveDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdMoveDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMoveDown.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdMoveDown.Image = Global.sstatesman.My.Resources.Resources.Icon_OrderDown_16x16
        Me.cmdMoveDown.Location = New System.Drawing.Point(185, 0)
        Me.cmdMoveDown.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(61, 22)
        Me.cmdMoveDown.TabIndex = 15
        Me.cmdMoveDown.Text = "DOWN"
        Me.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdMoveDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdMoveDown.UseVisualStyleBackColor = False
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
        Me.lblMove.Text = "move selected:"
        Me.lblMove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTopPanel
        '
        Me.pnlTopPanel.AutoSize = True
        Me.pnlTopPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTopPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlTopPanel.Controls.Add(Me.tlpTopPanel)
        Me.pnlTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopPanel.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.pnlTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlTopPanel.MinimumSize = New System.Drawing.Size(0, 56)
        Me.pnlTopPanel.Name = "pnlTopPanel"
        Me.pnlTopPanel.Size = New System.Drawing.Size(628, 56)
        Me.pnlTopPanel.TabIndex = 0
        '
        'tlpTopPanel
        '
        Me.tlpTopPanel.AutoSize = True
        Me.tlpTopPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTopPanel.BackColor = System.Drawing.Color.Transparent
        Me.tlpTopPanel.ColumnCount = 3
        Me.tlpTopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTopPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTopPanel.Controls.Add(Me.flpTitleBar, 0, 0)
        Me.tlpTopPanel.Controls.Add(Me.FlowLayoutPanel1, 2, 0)
        Me.tlpTopPanel.Controls.Add(Me.imgWindowGradientIcon, 1, 0)
        Me.tlpTopPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.tlpTopPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTopPanel.Name = "tlpTopPanel"
        Me.tlpTopPanel.RowCount = 3
        Me.tlpTopPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTopPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTopPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTopPanel.Size = New System.Drawing.Size(628, 56)
        Me.tlpTopPanel.TabIndex = 22
        '
        'flpTitleBar
        '
        Me.flpTitleBar.AutoSize = True
        Me.flpTitleBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTitleBar.BackColor = System.Drawing.Color.Transparent
        Me.flpTitleBar.Controls.Add(Me.lblWindowTitle)
        Me.flpTitleBar.Controls.Add(Me.blWindowDescription)
        Me.flpTitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpTitleBar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTitleBar.Location = New System.Drawing.Point(2, 2)
        Me.flpTitleBar.Margin = New System.Windows.Forms.Padding(2)
        Me.flpTitleBar.Name = "flpTitleBar"
        Me.flpTitleBar.Padding = New System.Windows.Forms.Padding(24, 4, 0, 4)
        Me.tlpTopPanel.SetRowSpan(Me.flpTitleBar, 3)
        Me.flpTitleBar.Size = New System.Drawing.Size(509, 52)
        Me.flpTitleBar.TabIndex = 1
        Me.flpTitleBar.WrapContents = False
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.lblWindowTitle.Location = New System.Drawing.Point(26, 4)
        Me.lblWindowTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(86, 30)
        Me.lblWindowTitle.TabIndex = 2
        Me.lblWindowTitle.Text = "Reorder"
        '
        'blWindowDescription
        '
        Me.blWindowDescription.AutoSize = True
        Me.blWindowDescription.BackColor = System.Drawing.Color.Transparent
        Me.blWindowDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.blWindowDescription.Location = New System.Drawing.Point(26, 34)
        Me.blWindowDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.blWindowDescription.Name = "blWindowDescription"
        Me.blWindowDescription.Size = New System.Drawing.Size(368, 13)
        Me.blWindowDescription.TabIndex = 4
        Me.blWindowDescription.Text = "use the move buttons to reorder the list and click ""reorder"" to confirm."
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowMaximize)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowClose)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(551, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(71, 20)
        Me.FlowLayoutPanel1.TabIndex = 4
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'cmdWindowMaximize
        '
        Me.cmdWindowMaximize.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowMaximize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowMaximize.FlatAppearance.BorderSize = 0
        Me.cmdWindowMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdWindowMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdWindowMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowMaximize.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowMaximize.Image = Global.sstatesman.My.Resources.Resources.Window_ButtonMaximize_12x12
        Me.cmdWindowMaximize.Location = New System.Drawing.Point(0, 0)
        Me.cmdWindowMaximize.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowMaximize.Name = "cmdWindowMaximize"
        Me.cmdWindowMaximize.Size = New System.Drawing.Size(26, 20)
        Me.cmdWindowMaximize.TabIndex = 5
        Me.cmdWindowMaximize.UseVisualStyleBackColor = False
        '
        'cmdWindowClose
        '
        Me.cmdWindowClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.cmdWindowClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowClose.FlatAppearance.BorderSize = 0
        Me.cmdWindowClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.cmdWindowClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.cmdWindowClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowClose.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowClose.Image = Global.sstatesman.My.Resources.Resources.Window_ButtonCloseW_12x12
        Me.cmdWindowClose.Location = New System.Drawing.Point(26, 0)
        Me.cmdWindowClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowClose.Name = "cmdWindowClose"
        Me.cmdWindowClose.Size = New System.Drawing.Size(45, 20)
        Me.cmdWindowClose.TabIndex = 6
        Me.cmdWindowClose.UseVisualStyleBackColor = False
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgWindowGradientIcon.Image = Global.sstatesman.My.Resources.Resources.Icon_SSM1ico_24x24
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(516, 0)
        Me.imgWindowGradientIcon.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.tlpTopPanel.SetRowSpan(Me.imgWindowGradientIcon, 2)
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'flpBottomPanel
        '
        Me.flpBottomPanel.AutoSize = True
        Me.flpBottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpBottomPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.flpBottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.flpBottomPanel.Controls.Add(Me.cmdCancel)
        Me.flpBottomPanel.Controls.Add(Me.cmdReorder)
        Me.flpBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpBottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpBottomPanel.Location = New System.Drawing.Point(0, 312)
        Me.flpBottomPanel.Name = "flpBottomPanel"
        Me.flpBottomPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.flpBottomPanel.Size = New System.Drawing.Size(628, 36)
        Me.flpBottomPanel.TabIndex = 7
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
        Me.flpMainListCommands.Location = New System.Drawing.Point(298, 0)
        Me.flpMainListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.flpMainListCommands.Name = "flpMainListCommands"
        Me.flpMainListCommands.Size = New System.Drawing.Size(298, 22)
        Me.flpMainListCommands.TabIndex = 12
        Me.flpMainListCommands.WrapContents = False
        '
        'pnlWindowContent
        '
        Me.pnlWindowContent.Controls.Add(Me.lvwReorderList)
        Me.pnlWindowContent.Controls.Add(Me.tlpFileListStatus)
        Me.pnlWindowContent.Controls.Add(Me.tlpFileListCommands)
        Me.pnlWindowContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWindowContent.Location = New System.Drawing.Point(0, 56)
        Me.pnlWindowContent.Name = "pnlWindowContent"
        Me.pnlWindowContent.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.pnlWindowContent.Size = New System.Drawing.Size(628, 256)
        Me.pnlWindowContent.TabIndex = 13
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
        Me.tlpFileListStatus.Location = New System.Drawing.Point(8, 213)
        Me.tlpFileListStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListStatus.Name = "tlpFileListStatus"
        Me.tlpFileListStatus.RowCount = 2
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.Size = New System.Drawing.Size(612, 39)
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
        Me.tlpFileListCommands.Size = New System.Drawing.Size(612, 22)
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
        Me.cmdSortReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSortReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSortReset.UseVisualStyleBackColor = False
        '
        'frmReorderForm
        '
        Me.AcceptButton = Me.cmdReorder
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(628, 348)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlWindowContent)
        Me.Controls.Add(Me.flpBottomPanel)
        Me.Controls.Add(Me.pnlTopPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSMico_v1_256x256
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "frmReorderForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reorder"
        Me.pnlTopPanel.ResumeLayout(False)
        Me.pnlTopPanel.PerformLayout()
        Me.tlpTopPanel.ResumeLayout(False)
        Me.tlpTopPanel.PerformLayout()
        Me.flpTitleBar.ResumeLayout(False)
        Me.flpTitleBar.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpBottomPanel.ResumeLayout(False)
        Me.flpBottomPanel.PerformLayout()
        Me.flpMainListCommands.ResumeLayout(False)
        Me.flpMainListCommands.PerformLayout()
        Me.pnlWindowContent.ResumeLayout(False)
        Me.pnlWindowContent.PerformLayout()
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
    Private WithEvents pnlTopPanel As System.Windows.Forms.Panel
    Friend WithEvents tlpTopPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Private WithEvents cmdWindowClose As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Friend WithEvents flpTitleBar As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Friend WithEvents flpBottomPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flpMainListCommands As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents StROLvw_NewName As System.Windows.Forms.ColumnHeader
    Private WithEvents blWindowDescription As System.Windows.Forms.Label
    Friend WithEvents pnlWindowContent As System.Windows.Forms.Panel
    Private WithEvents StROLvw_Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpFileListCommands As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flpFileListCommandsFiles As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdSortReset As System.Windows.Forms.Button
    Private WithEvents tlpFileListStatus As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblSelected As System.Windows.Forms.Label
    Private WithEvents txtSelected As System.Windows.Forms.TextBox
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents txtSize As System.Windows.Forms.TextBox
End Class
