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
        Me.cmdFilesDeleteSelected = New System.Windows.Forms.Button()
        Me.lvwDelFilesList = New System.Windows.Forms.ListView()
        Me.cmdFilesCheckInvert = New System.Windows.Forms.Button()
        Me.cmdFilesCheckBackup = New System.Windows.Forms.Button()
        Me.cmdFilesCheckAll = New System.Windows.Forms.Button()
        Me.cmdFilesCheckNone = New System.Windows.Forms.Button()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSizeBackup = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.lblFileListCheck = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.tlpTopPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.flpTitleBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.blWindowDescription = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.flpBottomPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.flpFileListTop = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpFileListStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlWindowContent = New System.Windows.Forms.Panel()
        Me.panelWindowTitle.SuspendLayout()
        Me.tlpTopPanel.SuspendLayout()
        Me.flpTitleBar.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpBottomPanel.SuspendLayout()
        Me.flpFileListTop.SuspendLayout()
        Me.tlpFileListStatus.SuspendLayout()
        Me.pnlWindowContent.SuspendLayout()
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
        Me.cmdFilesDeleteSelected.Location = New System.Drawing.Point(414, 6)
        Me.cmdFilesDeleteSelected.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdFilesDeleteSelected.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdFilesDeleteSelected.Name = "cmdFilesDeleteSelected"
        Me.cmdFilesDeleteSelected.Size = New System.Drawing.Size(100, 24)
        Me.cmdFilesDeleteSelected.TabIndex = 8
        Me.cmdFilesDeleteSelected.Text = "DELETE CHECKED"
        Me.cmdFilesDeleteSelected.UseVisualStyleBackColor = False
        '
        'lvwDelFilesList
        '
        Me.lvwDelFilesList.BackColor = System.Drawing.Color.White
        Me.lvwDelFilesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDelFilesList.CheckBoxes = True
        Me.lvwDelFilesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwDelFilesList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwDelFilesList.ForeColor = System.Drawing.Color.Black
        Me.lvwDelFilesList.FullRowSelect = True
        Me.lvwDelFilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwDelFilesList.Location = New System.Drawing.Point(8, 22)
        Me.lvwDelFilesList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwDelFilesList.MultiSelect = False
        Me.lvwDelFilesList.Name = "lvwDelFilesList"
        Me.lvwDelFilesList.Size = New System.Drawing.Size(612, 195)
        Me.lvwDelFilesList.TabIndex = 10
        Me.lvwDelFilesList.UseCompatibleStateImageBehavior = False
        Me.lvwDelFilesList.View = System.Windows.Forms.View.Details
        '
        'cmdFilesCheckInvert
        '
        Me.cmdFilesCheckInvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFilesCheckInvert.AutoSize = True
        Me.cmdFilesCheckInvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesCheckInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFilesCheckInvert.FlatAppearance.BorderSize = 0
        Me.cmdFilesCheckInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesCheckInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFilesCheckInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesCheckInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesCheckInvert.Location = New System.Drawing.Point(541, 0)
        Me.cmdFilesCheckInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFilesCheckInvert.Name = "cmdFilesCheckInvert"
        Me.cmdFilesCheckInvert.Size = New System.Drawing.Size(47, 22)
        Me.cmdFilesCheckInvert.TabIndex = 16
        Me.cmdFilesCheckInvert.Text = "INVERT"
        Me.cmdFilesCheckInvert.UseVisualStyleBackColor = False
        '
        'cmdFilesCheckBackup
        '
        Me.cmdFilesCheckBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFilesCheckBackup.AutoSize = True
        Me.cmdFilesCheckBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesCheckBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFilesCheckBackup.FlatAppearance.BorderSize = 0
        Me.cmdFilesCheckBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesCheckBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFilesCheckBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesCheckBackup.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesCheckBackup.Location = New System.Drawing.Point(412, 0)
        Me.cmdFilesCheckBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFilesCheckBackup.Name = "cmdFilesCheckBackup"
        Me.cmdFilesCheckBackup.Size = New System.Drawing.Size(57, 22)
        Me.cmdFilesCheckBackup.TabIndex = 13
        Me.cmdFilesCheckBackup.Text = "BACKUPS"
        Me.cmdFilesCheckBackup.UseVisualStyleBackColor = False
        '
        'cmdFilesCheckAll
        '
        Me.cmdFilesCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFilesCheckAll.AutoSize = True
        Me.cmdFilesCheckAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesCheckAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFilesCheckAll.FlatAppearance.BorderSize = 0
        Me.cmdFilesCheckAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesCheckAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFilesCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesCheckAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesCheckAll.Location = New System.Drawing.Point(469, 0)
        Me.cmdFilesCheckAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFilesCheckAll.Name = "cmdFilesCheckAll"
        Me.cmdFilesCheckAll.Size = New System.Drawing.Size(31, 22)
        Me.cmdFilesCheckAll.TabIndex = 14
        Me.cmdFilesCheckAll.Text = "ALL"
        Me.cmdFilesCheckAll.UseVisualStyleBackColor = False
        '
        'cmdFilesCheckNone
        '
        Me.cmdFilesCheckNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFilesCheckNone.AutoSize = True
        Me.cmdFilesCheckNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesCheckNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFilesCheckNone.FlatAppearance.BorderSize = 0
        Me.cmdFilesCheckNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesCheckNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFilesCheckNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesCheckNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesCheckNone.Location = New System.Drawing.Point(500, 0)
        Me.cmdFilesCheckNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFilesCheckNone.Name = "cmdFilesCheckNone"
        Me.cmdFilesCheckNone.Size = New System.Drawing.Size(41, 22)
        Me.cmdFilesCheckNone.TabIndex = 15
        Me.cmdFilesCheckNone.Text = "NONE"
        Me.cmdFilesCheckNone.UseVisualStyleBackColor = False
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
        'lblFileListCheck
        '
        Me.lblFileListCheck.AutoSize = True
        Me.lblFileListCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFileListCheck.Location = New System.Drawing.Point(316, 0)
        Me.lblFileListCheck.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFileListCheck.Name = "lblFileListCheck"
        Me.lblFileListCheck.Size = New System.Drawing.Size(94, 22)
        Me.lblFileListCheck.TabIndex = 32
        Me.lblFileListCheck.Text = "check savestates:"
        Me.lblFileListCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.AutoSize = True
        Me.panelWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.panelWindowTitle.Controls.Add(Me.tlpTopPanel)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.panelWindowTitle.MinimumSize = New System.Drawing.Size(0, 56)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(628, 56)
        Me.panelWindowTitle.TabIndex = 0
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
        Me.lblWindowTitle.Size = New System.Drawing.Size(197, 30)
        Me.lblWindowTitle.TabIndex = 2
        Me.lblWindowTitle.Text = "Delete confirmation"
        '
        'blWindowDescription
        '
        Me.blWindowDescription.AutoSize = True
        Me.blWindowDescription.BackColor = System.Drawing.Color.Transparent
        Me.blWindowDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.blWindowDescription.Location = New System.Drawing.Point(26, 34)
        Me.blWindowDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.blWindowDescription.Name = "blWindowDescription"
        Me.blWindowDescription.Size = New System.Drawing.Size(349, 13)
        Me.blWindowDescription.TabIndex = 4
        Me.blWindowDescription.Text = "check the files you really want to delete and click ""delete checked""."
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
        Me.flpBottomPanel.Controls.Add(Me.cmdFilesDeleteSelected)
        Me.flpBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpBottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpBottomPanel.Location = New System.Drawing.Point(0, 312)
        Me.flpBottomPanel.Name = "flpBottomPanel"
        Me.flpBottomPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.flpBottomPanel.Size = New System.Drawing.Size(628, 36)
        Me.flpBottomPanel.TabIndex = 7
        '
        'flpFileListTop
        '
        Me.flpFileListTop.AutoSize = True
        Me.flpFileListTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFileListTop.Controls.Add(Me.cmdFilesCheckInvert)
        Me.flpFileListTop.Controls.Add(Me.cmdFilesCheckNone)
        Me.flpFileListTop.Controls.Add(Me.cmdFilesCheckAll)
        Me.flpFileListTop.Controls.Add(Me.cmdFilesCheckBackup)
        Me.flpFileListTop.Controls.Add(Me.lblFileListCheck)
        Me.flpFileListTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpFileListTop.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpFileListTop.Location = New System.Drawing.Point(8, 0)
        Me.flpFileListTop.Margin = New System.Windows.Forms.Padding(0)
        Me.flpFileListTop.Name = "flpFileListTop"
        Me.flpFileListTop.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.flpFileListTop.Size = New System.Drawing.Size(612, 22)
        Me.flpFileListTop.TabIndex = 12
        Me.flpFileListTop.WrapContents = False
        '
        'tlpFileListStatus
        '
        Me.tlpFileListStatus.AutoSize = True
        Me.tlpFileListStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFileListStatus.BackColor = System.Drawing.Color.White
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
        Me.tlpFileListStatus.Location = New System.Drawing.Point(8, 217)
        Me.tlpFileListStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListStatus.Name = "tlpFileListStatus"
        Me.tlpFileListStatus.RowCount = 2
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.Size = New System.Drawing.Size(612, 39)
        Me.tlpFileListStatus.TabIndex = 17
        '
        'pnlWindowContent
        '
        Me.pnlWindowContent.Controls.Add(Me.lvwDelFilesList)
        Me.pnlWindowContent.Controls.Add(Me.tlpFileListStatus)
        Me.pnlWindowContent.Controls.Add(Me.flpFileListTop)
        Me.pnlWindowContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWindowContent.Location = New System.Drawing.Point(0, 56)
        Me.pnlWindowContent.Name = "pnlWindowContent"
        Me.pnlWindowContent.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.pnlWindowContent.Size = New System.Drawing.Size(628, 256)
        Me.pnlWindowContent.TabIndex = 18
        '
        'frmDeleteForm
        '
        Me.AcceptButton = Me.cmdFilesDeleteSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(628, 348)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlWindowContent)
        Me.Controls.Add(Me.flpBottomPanel)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSMico_v1_256x256
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
        Me.tlpTopPanel.ResumeLayout(False)
        Me.tlpTopPanel.PerformLayout()
        Me.flpTitleBar.ResumeLayout(False)
        Me.flpTitleBar.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpBottomPanel.ResumeLayout(False)
        Me.flpBottomPanel.PerformLayout()
        Me.flpFileListTop.ResumeLayout(False)
        Me.flpFileListTop.PerformLayout()
        Me.tlpFileListStatus.ResumeLayout(False)
        Me.tlpFileListStatus.PerformLayout()
        Me.pnlWindowContent.ResumeLayout(False)
        Me.pnlWindowContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblFileListCheck As System.Windows.Forms.Label
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdFilesDeleteSelected As System.Windows.Forms.Button
    Private WithEvents lvwDelFilesList As System.Windows.Forms.ListView
    Private WithEvents cmdFilesCheckInvert As System.Windows.Forms.Button
    Private WithEvents cmdFilesCheckBackup As System.Windows.Forms.Button
    Private WithEvents cmdFilesCheckAll As System.Windows.Forms.Button
    Private WithEvents cmdFilesCheckNone As System.Windows.Forms.Button
    Private WithEvents txtSelected As System.Windows.Forms.TextBox
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents lblSelected As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Private WithEvents txtSize As System.Windows.Forms.TextBox
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Private WithEvents tlpTopPanel As System.Windows.Forms.TableLayoutPanel
    Private WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Private WithEvents cmdWindowClose As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Private WithEvents flpTitleBar As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Private WithEvents flpBottomPanel As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents flpFileListTop As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents tlpFileListStatus As System.Windows.Forms.TableLayoutPanel
    Private WithEvents blWindowDescription As System.Windows.Forms.Label
    Private WithEvents pnlWindowContent As System.Windows.Forms.Panel
End Class
