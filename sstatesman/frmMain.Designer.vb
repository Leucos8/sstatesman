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
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.flpTitleBarToolbar = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdToolbarConfig = New System.Windows.Forms.Button()
        Me.cmdToolbarUser = New System.Windows.Forms.Button()
        Me.cmdToolbarPCSX2 = New System.Windows.Forms.Button()
        Me.lblWindowVersion = New System.Windows.Forms.Label()
        Me.tlpTopBar = New System.Windows.Forms.TableLayoutPanel()
        Me.flpTab = New System.Windows.Forms.FlowLayoutPanel()
        Me.optTabHeader0 = New System.Windows.Forms.RadioButton()
        Me.optTabHeader1 = New System.Windows.Forms.RadioButton()
        Me.optTabHeader2 = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.tmrSStatesListRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tlpGameList = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwGamesList = New System.Windows.Forms.ListView()
        Me.GamesLvw_GameTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_GameSerial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_GameRegion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_SStatesInfo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_BackupInfo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_Stored_Info = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_SnapsInfo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgCover = New System.Windows.Forms.PictureBox()
        Me.cmCover = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmiCoverAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiCoverOpenPicsFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblGameList_Title = New System.Windows.Forms.Label()
        Me.txtGameList_Title = New System.Windows.Forms.TextBox()
        Me.lblGameList_Region = New System.Windows.Forms.Label()
        Me.imgFlag = New System.Windows.Forms.PictureBox()
        Me.txtGameList_Compat = New System.Windows.Forms.TextBox()
        Me.txtGameList_Region = New System.Windows.Forms.TextBox()
        Me.lblGameList_Compat = New System.Windows.Forms.Label()
        Me.lblGameList_Serial = New System.Windows.Forms.Label()
        Me.txtGameList_Serial = New System.Windows.Forms.TextBox()
        Me.tlpGameListCommands = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdGamePlay = New System.Windows.Forms.Button()
        Me.flpGameListCommandsCheck = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdGameSelectInvert = New System.Windows.Forms.Button()
        Me.cmdGameSelectNone = New System.Windows.Forms.Button()
        Me.cmdGameSelectAll = New System.Windows.Forms.Button()
        Me.lblGameListCheck = New System.Windows.Forms.Label()
        Me.lvwFilesList = New System.Windows.Forms.ListView()
        Me.tlpFileListStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.txtSizeBackup = New System.Windows.Forms.TextBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.tlpFileListCommands = New System.Windows.Forms.TableLayoutPanel()
        Me.flpFileListCommandsFiles = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdFilesReorder = New System.Windows.Forms.Button()
        Me.cmdFilesDelete = New System.Windows.Forms.Button()
        Me.cmdExpandFilesList = New System.Windows.Forms.Button()
        Me.flpFileListCommandsCheck = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdFileCheckInvert = New System.Windows.Forms.Button()
        Me.cmdFileCheckNone = New System.Windows.Forms.Button()
        Me.cmdFileCheckAll = New System.Windows.Forms.Button()
        Me.cmdFileCheckBackup = New System.Windows.Forms.Button()
        Me.lblSStateListCheck = New System.Windows.Forms.Label()
        Me.pnlScreenshotThumb = New System.Windows.Forms.Panel()
        Me.imgScreenshotThumb = New System.Windows.Forms.PictureBox()
        Me.cmPCSX2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmiPCSX2Launch = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiPCSX2Play = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmiPCSX2GDE = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiPCSX2BinFolderOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiPCSX2IniFolderOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrSelectedItemChanged = New System.Windows.Forms.Timer(Me.components)
        Me.bwLoadScreenshot = New System.ComponentModel.BackgroundWorker()
        Me.cmConfig = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmiConfigSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiConfigLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiConfigDevTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmiConfigAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmFolders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmiFoldersSStatesOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiFoldersSnapsOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmiFoldersStoredOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiFoldersIsoOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiFoldersCoverOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.flpTitleBarToolbar.SuspendLayout()
        Me.tlpTopBar.SuspendLayout()
        Me.flpTab.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tlpGameList.SuspendLayout()
        CType(Me.imgCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmCover.SuspendLayout()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpGameListCommands.SuspendLayout()
        Me.flpGameListCommandsCheck.SuspendLayout()
        Me.tlpFileListStatus.SuspendLayout()
        Me.tlpFileListCommands.SuspendLayout()
        Me.flpFileListCommandsFiles.SuspendLayout()
        Me.flpFileListCommandsCheck.SuspendLayout()
        Me.pnlScreenshotThumb.SuspendLayout()
        CType(Me.imgScreenshotThumb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmPCSX2.SuspendLayout()
        Me.cmConfig.SuspendLayout()
        Me.cmFolders.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlWindowTop.Size = New System.Drawing.Size(632, 46)
        '
        'flpTitleBarToolbar
        '
        Me.flpTitleBarToolbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpTitleBarToolbar.AutoSize = True
        Me.flpTitleBarToolbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTitleBarToolbar.Controls.Add(Me.cmdToolbarConfig)
        Me.flpTitleBarToolbar.Controls.Add(Me.cmdToolbarUser)
        Me.flpTitleBarToolbar.Controls.Add(Me.cmdToolbarPCSX2)
        Me.flpTitleBarToolbar.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpTitleBarToolbar.Location = New System.Drawing.Point(420, 49)
        Me.flpTitleBarToolbar.Margin = New System.Windows.Forms.Padding(0)
        Me.flpTitleBarToolbar.Name = "flpTitleBarToolbar"
        Me.flpTitleBarToolbar.Size = New System.Drawing.Size(169, 22)
        Me.flpTitleBarToolbar.TabIndex = 5
        Me.flpTitleBarToolbar.WrapContents = False
        '
        'cmdToolbarConfig
        '
        Me.cmdToolbarConfig.AutoSize = True
        Me.cmdToolbarConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdToolbarConfig.BackColor = System.Drawing.Color.Transparent
        Me.cmdToolbarConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdToolbarConfig.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdToolbarConfig.FlatAppearance.BorderSize = 0
        Me.cmdToolbarConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdToolbarConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdToolbarConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdToolbarConfig.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdToolbarConfig.Image = Global.sstatesman.My.Resources.Resources.Button_Dropdown_6x3
        Me.cmdToolbarConfig.Location = New System.Drawing.Point(112, 0)
        Me.cmdToolbarConfig.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdToolbarConfig.Name = "cmdToolbarConfig"
        Me.cmdToolbarConfig.Size = New System.Drawing.Size(57, 22)
        Me.cmdToolbarConfig.TabIndex = 6
        Me.cmdToolbarConfig.Text = " &CONFIG"
        Me.cmdToolbarConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdToolbarConfig.UseVisualStyleBackColor = False
        '
        'cmdToolbarUser
        '
        Me.cmdToolbarUser.AutoSize = True
        Me.cmdToolbarUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdToolbarUser.BackColor = System.Drawing.Color.Transparent
        Me.cmdToolbarUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdToolbarUser.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdToolbarUser.FlatAppearance.BorderSize = 0
        Me.cmdToolbarUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdToolbarUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdToolbarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdToolbarUser.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdToolbarUser.Image = Global.sstatesman.My.Resources.Resources.Button_Dropdown_6x3
        Me.cmdToolbarUser.Location = New System.Drawing.Point(49, 0)
        Me.cmdToolbarUser.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdToolbarUser.Name = "cmdToolbarUser"
        Me.cmdToolbarUser.Size = New System.Drawing.Size(63, 22)
        Me.cmdToolbarUser.TabIndex = 13
        Me.cmdToolbarUser.Text = " &FOLDERS"
        Me.cmdToolbarUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdToolbarUser.UseVisualStyleBackColor = False
        '
        'cmdToolbarPCSX2
        '
        Me.cmdToolbarPCSX2.AutoSize = True
        Me.cmdToolbarPCSX2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdToolbarPCSX2.BackColor = System.Drawing.Color.Transparent
        Me.cmdToolbarPCSX2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdToolbarPCSX2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdToolbarPCSX2.FlatAppearance.BorderSize = 0
        Me.cmdToolbarPCSX2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdToolbarPCSX2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdToolbarPCSX2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdToolbarPCSX2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdToolbarPCSX2.Image = Global.sstatesman.My.Resources.Resources.Button_Dropdown_6x3
        Me.cmdToolbarPCSX2.Location = New System.Drawing.Point(0, 0)
        Me.cmdToolbarPCSX2.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdToolbarPCSX2.Name = "cmdToolbarPCSX2"
        Me.cmdToolbarPCSX2.Size = New System.Drawing.Size(49, 22)
        Me.cmdToolbarPCSX2.TabIndex = 12
        Me.cmdToolbarPCSX2.Text = "&PCSX2"
        Me.cmdToolbarPCSX2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdToolbarPCSX2.UseVisualStyleBackColor = False
        '
        'lblWindowVersion
        '
        Me.lblWindowVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWindowVersion.AutoSize = True
        Me.lblWindowVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowVersion.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowVersion.Location = New System.Drawing.Point(591, 49)
        Me.lblWindowVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWindowVersion.Name = "lblWindowVersion"
        Me.lblWindowVersion.Size = New System.Drawing.Size(35, 12)
        Me.lblWindowVersion.TabIndex = 8
        Me.lblWindowVersion.Text = "version "
        Me.lblWindowVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tlpTopBar
        '
        Me.tlpTopBar.AutoSize = True
        Me.tlpTopBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTopBar.BackColor = System.Drawing.Color.Transparent
        Me.tlpTopBar.ColumnCount = 3
        Me.tlpTopBar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTopBar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopBar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTopBar.Controls.Add(Me.flpTab, 0, 0)
        Me.tlpTopBar.Controls.Add(Me.FlowLayoutPanel3, 2, 0)
        Me.tlpTopBar.Location = New System.Drawing.Point(1, 49)
        Me.tlpTopBar.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTopBar.Name = "tlpTopBar"
        Me.tlpTopBar.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.tlpTopBar.RowCount = 1
        Me.tlpTopBar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopBar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tlpTopBar.Size = New System.Drawing.Size(342, 24)
        Me.tlpTopBar.TabIndex = 14
        '
        'flpTab
        '
        Me.flpTab.AutoSize = True
        Me.flpTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTab.Controls.Add(Me.optTabHeader0)
        Me.flpTab.Controls.Add(Me.optTabHeader1)
        Me.flpTab.Controls.Add(Me.optTabHeader2)
        Me.flpTab.Location = New System.Drawing.Point(16, 1)
        Me.flpTab.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.flpTab.Name = "flpTab"
        Me.flpTab.Size = New System.Drawing.Size(240, 23)
        Me.flpTab.TabIndex = 15
        Me.flpTab.WrapContents = False
        '
        'optTabHeader0
        '
        Me.optTabHeader0.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader0.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader0.AutoSize = True
        Me.optTabHeader0.Checked = True
        Me.optTabHeader0.FlatAppearance.BorderSize = 0
        Me.optTabHeader0.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader0.Location = New System.Drawing.Point(0, 0)
        Me.optTabHeader0.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader0.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader0.Name = "optTabHeader0"
        Me.optTabHeader0.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader0.TabIndex = 16
        Me.optTabHeader0.TabStop = True
        Me.optTabHeader0.Tag = "0"
        Me.optTabHeader0.Text = "savestates"
        Me.optTabHeader0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optTabHeader0.UseVisualStyleBackColor = False
        '
        'optTabHeader1
        '
        Me.optTabHeader1.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader1.AutoSize = True
        Me.optTabHeader1.FlatAppearance.BorderSize = 0
        Me.optTabHeader1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader1.Location = New System.Drawing.Point(80, 0)
        Me.optTabHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader1.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader1.Name = "optTabHeader1"
        Me.optTabHeader1.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader1.TabIndex = 17
        Me.optTabHeader1.Tag = "1"
        Me.optTabHeader1.Text = "storage"
        Me.optTabHeader1.UseVisualStyleBackColor = False
        '
        'optTabHeader2
        '
        Me.optTabHeader2.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader2.AutoSize = True
        Me.optTabHeader2.FlatAppearance.BorderSize = 0
        Me.optTabHeader2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader2.Location = New System.Drawing.Point(160, 0)
        Me.optTabHeader2.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader2.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader2.Name = "optTabHeader2"
        Me.optTabHeader2.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader2.TabIndex = 18
        Me.optTabHeader2.Tag = "2"
        Me.optTabHeader2.Text = "screenshots"
        Me.optTabHeader2.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel3.Controls.Add(Me.cmdRefresh)
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(256, 0)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(70, 23)
        Me.FlowLayoutPanel3.TabIndex = 11
        Me.FlowLayoutPanel3.WrapContents = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.AutoSize = True
        Me.cmdRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdRefresh.Image = Global.sstatesman.My.Resources.Resources.Glyph_Refresh
        Me.cmdRefresh.Location = New System.Drawing.Point(0, 1)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(70, 22)
        Me.cmdRefresh.TabIndex = 19
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'tmrSStatesListRefresh
        '
        Me.tmrSStatesListRefresh.Interval = 5000
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(15, 87)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.MinimumSize = New System.Drawing.Size(400, 360)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.SplitContainer1.Panel1.Controls.Add(Me.tlpGameList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tlpGameListCommands)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.SplitContainer1.Panel1MinSize = 200
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwFilesList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tlpFileListStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tlpFileListCommands)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlScreenshotThumb)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.SplitContainer1.Panel2MinSize = 120
        Me.SplitContainer1.Size = New System.Drawing.Size(606, 360)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 20
        '
        'tlpGameList
        '
        Me.tlpGameList.AutoSize = True
        Me.tlpGameList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpGameList.ColumnCount = 9
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGameList.Controls.Add(Me.lvwGamesList, 0, 0)
        Me.tlpGameList.Controls.Add(Me.imgCover, 0, 1)
        Me.tlpGameList.Controls.Add(Me.lblGameList_Title, 1, 1)
        Me.tlpGameList.Controls.Add(Me.txtGameList_Title, 2, 1)
        Me.tlpGameList.Controls.Add(Me.lblGameList_Region, 1, 2)
        Me.tlpGameList.Controls.Add(Me.imgFlag, 3, 2)
        Me.tlpGameList.Controls.Add(Me.txtGameList_Compat, 7, 2)
        Me.tlpGameList.Controls.Add(Me.txtGameList_Region, 2, 2)
        Me.tlpGameList.Controls.Add(Me.lblGameList_Compat, 6, 2)
        Me.tlpGameList.Controls.Add(Me.lblGameList_Serial, 4, 2)
        Me.tlpGameList.Controls.Add(Me.txtGameList_Serial, 5, 2)
        Me.tlpGameList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGameList.Location = New System.Drawing.Point(8, 22)
        Me.tlpGameList.Margin = New System.Windows.Forms.Padding(2)
        Me.tlpGameList.Name = "tlpGameList"
        Me.tlpGameList.RowCount = 3
        Me.tlpGameList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGameList.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGameList.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGameList.Size = New System.Drawing.Size(590, 174)
        Me.tlpGameList.TabIndex = 21
        '
        'lvwGamesList
        '
        Me.lvwGamesList.BackColor = System.Drawing.Color.White
        Me.lvwGamesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwGamesList.CheckBoxes = True
        Me.lvwGamesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.GamesLvw_GameTitle, Me.GameLvw_GameSerial, Me.GameLvw_GameRegion, Me.GameLvw_SStatesInfo, Me.GameLvw_BackupInfo, Me.GameLvw_Stored_Info, Me.GameLvw_SnapsInfo})
        Me.tlpGameList.SetColumnSpan(Me.lvwGamesList, 9)
        Me.lvwGamesList.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvwGamesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwGamesList.ForeColor = System.Drawing.Color.Black
        Me.lvwGamesList.FullRowSelect = True
        Me.lvwGamesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwGamesList.HideSelection = False
        Me.lvwGamesList.Location = New System.Drawing.Point(0, 0)
        Me.lvwGamesList.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.lvwGamesList.MultiSelect = False
        Me.lvwGamesList.Name = "lvwGamesList"
        Me.lvwGamesList.Size = New System.Drawing.Size(590, 120)
        Me.lvwGamesList.TabIndex = 22
        Me.lvwGamesList.TileSize = New System.Drawing.Size(480, 96)
        Me.lvwGamesList.UseCompatibleStateImageBehavior = False
        Me.lvwGamesList.View = System.Windows.Forms.View.Details
        '
        'GamesLvw_GameTitle
        '
        Me.GamesLvw_GameTitle.Text = "Game title"
        Me.GamesLvw_GameTitle.Width = 120
        '
        'GameLvw_GameSerial
        '
        Me.GameLvw_GameSerial.Text = "Serial"
        Me.GameLvw_GameSerial.Width = 80
        '
        'GameLvw_GameRegion
        '
        Me.GameLvw_GameRegion.Text = "Region"
        '
        'GameLvw_SStatesInfo
        '
        Me.GameLvw_SStatesInfo.Text = "Savestates"
        Me.GameLvw_SStatesInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GameLvw_SStatesInfo.Width = 80
        '
        'GameLvw_BackupInfo
        '
        Me.GameLvw_BackupInfo.Text = "Backups"
        Me.GameLvw_BackupInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GameLvw_BackupInfo.Width = 80
        '
        'GameLvw_Stored_Info
        '
        Me.GameLvw_Stored_Info.Text = "Stored"
        Me.GameLvw_Stored_Info.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GameLvw_Stored_Info.Width = 80
        '
        'GameLvw_SnapsInfo
        '
        Me.GameLvw_SnapsInfo.Text = "Screenshots"
        Me.GameLvw_SnapsInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GameLvw_SnapsInfo.Width = 80
        '
        'imgCover
        '
        Me.imgCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgCover.ContextMenuStrip = Me.cmCover
        Me.imgCover.Image = Global.sstatesman.My.Resources.Resources.Extra_ClearImage_30x20
        Me.imgCover.Location = New System.Drawing.Point(0, 124)
        Me.imgCover.Margin = New System.Windows.Forms.Padding(0, 0, 6, 2)
        Me.imgCover.Name = "imgCover"
        Me.tlpGameList.SetRowSpan(Me.imgCover, 2)
        Me.imgCover.Size = New System.Drawing.Size(48, 48)
        Me.imgCover.TabIndex = 26
        Me.imgCover.TabStop = False
        '
        'cmCover
        '
        Me.cmCover.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmCover.BackgroundImage = Global.sstatesman.My.Resources.Resources.BgStripesLight
        Me.cmCover.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmiCoverAdd, Me.cmiCoverOpenPicsFolder})
        Me.cmCover.Name = "cmCover"
        Me.cmCover.Size = New System.Drawing.Size(215, 48)
        Me.cmCover.Text = "Cover Image Menu"
        '
        'cmiCoverAdd
        '
        Me.cmiCoverAdd.Image = Global.sstatesman.My.Resources.Resources.Icon_Cover
        Me.cmiCoverAdd.Name = "cmiCoverAdd"
        Me.cmiCoverAdd.Size = New System.Drawing.Size(214, 22)
        Me.cmiCoverAdd.Text = "Select cover image..."
        '
        'cmiCoverOpenPicsFolder
        '
        Me.cmiCoverOpenPicsFolder.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderCover
        Me.cmiCoverOpenPicsFolder.Name = "cmiCoverOpenPicsFolder"
        Me.cmiCoverOpenPicsFolder.Size = New System.Drawing.Size(214, 22)
        Me.cmiCoverOpenPicsFolder.Text = "Open cover image folder..."
        '
        'lblGameList_Title
        '
        Me.lblGameList_Title.AutoSize = True
        Me.lblGameList_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Title.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblGameList_Title.Location = New System.Drawing.Point(66, 124)
        Me.lblGameList_Title.Margin = New System.Windows.Forms.Padding(10, 0, 4, 0)
        Me.lblGameList_Title.Name = "lblGameList_Title"
        Me.lblGameList_Title.Size = New System.Drawing.Size(58, 24)
        Me.lblGameList_Title.TabIndex = 23
        Me.lblGameList_Title.Text = "game title"
        Me.lblGameList_Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGameList_Title
        '
        Me.txtGameList_Title.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpGameList.SetColumnSpan(Me.txtGameList_Title, 7)
        Me.txtGameList_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Title.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Title.Location = New System.Drawing.Point(128, 124)
        Me.txtGameList_Title.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.txtGameList_Title.Name = "txtGameList_Title"
        Me.txtGameList_Title.ReadOnly = True
        Me.txtGameList_Title.Size = New System.Drawing.Size(462, 22)
        Me.txtGameList_Title.TabIndex = 24
        Me.txtGameList_Title.TabStop = False
        '
        'lblGameList_Region
        '
        Me.lblGameList_Region.AutoSize = True
        Me.lblGameList_Region.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Region.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblGameList_Region.Location = New System.Drawing.Point(66, 148)
        Me.lblGameList_Region.Margin = New System.Windows.Forms.Padding(10, 0, 4, 0)
        Me.lblGameList_Region.Name = "lblGameList_Region"
        Me.lblGameList_Region.Size = New System.Drawing.Size(58, 26)
        Me.lblGameList_Region.TabIndex = 25
        Me.lblGameList_Region.Text = "region"
        Me.lblGameList_Region.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgFlag
        '
        Me.imgFlag.BackColor = System.Drawing.Color.WhiteSmoke
        Me.imgFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgFlag.Dock = System.Windows.Forms.DockStyle.Top
        Me.imgFlag.Image = Global.sstatesman.My.Resources.Resources.Extra_ClearImage_30x20
        Me.imgFlag.Location = New System.Drawing.Point(230, 150)
        Me.imgFlag.Margin = New System.Windows.Forms.Padding(2)
        Me.imgFlag.Name = "imgFlag"
        Me.imgFlag.Size = New System.Drawing.Size(32, 22)
        Me.imgFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgFlag.TabIndex = 23
        Me.imgFlag.TabStop = False
        '
        'txtGameList_Compat
        '
        Me.txtGameList_Compat.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Compat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Compat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Compat.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Compat.Location = New System.Drawing.Point(475, 150)
        Me.txtGameList_Compat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Compat.Name = "txtGameList_Compat"
        Me.txtGameList_Compat.ReadOnly = True
        Me.txtGameList_Compat.Size = New System.Drawing.Size(100, 22)
        Me.txtGameList_Compat.TabIndex = 30
        Me.txtGameList_Compat.TabStop = False
        '
        'txtGameList_Region
        '
        Me.txtGameList_Region.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Region.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Region.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Region.Location = New System.Drawing.Point(128, 150)
        Me.txtGameList_Region.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.txtGameList_Region.Name = "txtGameList_Region"
        Me.txtGameList_Region.ReadOnly = True
        Me.txtGameList_Region.Size = New System.Drawing.Size(100, 22)
        Me.txtGameList_Region.TabIndex = 26
        Me.txtGameList_Region.TabStop = False
        '
        'lblGameList_Compat
        '
        Me.lblGameList_Compat.AutoSize = True
        Me.lblGameList_Compat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Compat.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblGameList_Compat.Location = New System.Drawing.Point(408, 148)
        Me.lblGameList_Compat.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameList_Compat.Name = "lblGameList_Compat"
        Me.lblGameList_Compat.Size = New System.Drawing.Size(63, 26)
        Me.lblGameList_Compat.TabIndex = 29
        Me.lblGameList_Compat.Text = "emu status"
        Me.lblGameList_Compat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGameList_Serial
        '
        Me.lblGameList_Serial.AutoSize = True
        Me.lblGameList_Serial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Serial.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblGameList_Serial.Location = New System.Drawing.Point(266, 148)
        Me.lblGameList_Serial.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameList_Serial.Name = "lblGameList_Serial"
        Me.lblGameList_Serial.Size = New System.Drawing.Size(34, 26)
        Me.lblGameList_Serial.TabIndex = 27
        Me.lblGameList_Serial.Text = "serial"
        Me.lblGameList_Serial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGameList_Serial
        '
        Me.txtGameList_Serial.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Serial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Serial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Serial.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Serial.Location = New System.Drawing.Point(304, 150)
        Me.txtGameList_Serial.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Serial.Name = "txtGameList_Serial"
        Me.txtGameList_Serial.ReadOnly = True
        Me.txtGameList_Serial.Size = New System.Drawing.Size(100, 22)
        Me.txtGameList_Serial.TabIndex = 28
        Me.txtGameList_Serial.TabStop = False
        '
        'tlpGameListCommands
        '
        Me.tlpGameListCommands.AutoSize = True
        Me.tlpGameListCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpGameListCommands.ColumnCount = 3
        Me.tlpGameListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGameListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGameListCommands.Controls.Add(Me.cmdGamePlay, 0, 0)
        Me.tlpGameListCommands.Controls.Add(Me.flpGameListCommandsCheck, 2, 0)
        Me.tlpGameListCommands.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpGameListCommands.Location = New System.Drawing.Point(8, 0)
        Me.tlpGameListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpGameListCommands.Name = "tlpGameListCommands"
        Me.tlpGameListCommands.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.tlpGameListCommands.RowCount = 1
        Me.tlpGameListCommands.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGameListCommands.Size = New System.Drawing.Size(590, 22)
        Me.tlpGameListCommands.TabIndex = 31
        '
        'cmdGamePlay
        '
        Me.cmdGamePlay.AutoSize = True
        Me.cmdGamePlay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGamePlay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGamePlay.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGamePlay.FlatAppearance.BorderSize = 0
        Me.cmdGamePlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGamePlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGamePlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGamePlay.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGamePlay.Image = Global.sstatesman.My.Resources.Resources.Icon_GamePlay
        Me.cmdGamePlay.Location = New System.Drawing.Point(16, 0)
        Me.cmdGamePlay.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGamePlay.Name = "cmdGamePlay"
        Me.cmdGamePlay.Size = New System.Drawing.Size(57, 22)
        Me.cmdGamePlay.TabIndex = 35
        Me.cmdGamePlay.Text = "PLAY..."
        Me.cmdGamePlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGamePlay.UseVisualStyleBackColor = False
        '
        'flpGameListCommandsCheck
        '
        Me.flpGameListCommandsCheck.AutoSize = True
        Me.flpGameListCommandsCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpGameListCommandsCheck.Controls.Add(Me.cmdGameSelectInvert)
        Me.flpGameListCommandsCheck.Controls.Add(Me.cmdGameSelectNone)
        Me.flpGameListCommandsCheck.Controls.Add(Me.cmdGameSelectAll)
        Me.flpGameListCommandsCheck.Controls.Add(Me.lblGameListCheck)
        Me.flpGameListCommandsCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpGameListCommandsCheck.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpGameListCommandsCheck.Location = New System.Drawing.Point(328, 0)
        Me.flpGameListCommandsCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.flpGameListCommandsCheck.Name = "flpGameListCommandsCheck"
        Me.flpGameListCommandsCheck.Size = New System.Drawing.Size(246, 22)
        Me.flpGameListCommandsCheck.TabIndex = 32
        Me.flpGameListCommandsCheck.WrapContents = False
        '
        'cmdGameSelectInvert
        '
        Me.cmdGameSelectInvert.AutoSize = True
        Me.cmdGameSelectInvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGameSelectInvert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGameSelectInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectInvert.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGameSelectInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameSelectInvert.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckInvert
        Me.cmdGameSelectInvert.Location = New System.Drawing.Point(183, 0)
        Me.cmdGameSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectInvert.Name = "cmdGameSelectInvert"
        Me.cmdGameSelectInvert.Size = New System.Drawing.Size(63, 22)
        Me.cmdGameSelectInvert.TabIndex = 36
        Me.cmdGameSelectInvert.Text = "INVERT"
        Me.cmdGameSelectInvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGameSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdGameSelectNone
        '
        Me.cmdGameSelectNone.AutoSize = True
        Me.cmdGameSelectNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGameSelectNone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGameSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectNone.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGameSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameSelectNone.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckNone
        Me.cmdGameSelectNone.Location = New System.Drawing.Point(126, 0)
        Me.cmdGameSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectNone.Name = "cmdGameSelectNone"
        Me.cmdGameSelectNone.Size = New System.Drawing.Size(57, 22)
        Me.cmdGameSelectNone.TabIndex = 35
        Me.cmdGameSelectNone.Text = "NONE"
        Me.cmdGameSelectNone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGameSelectNone.UseVisualStyleBackColor = False
        '
        'cmdGameSelectAll
        '
        Me.cmdGameSelectAll.AutoSize = True
        Me.cmdGameSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGameSelectAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGameSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectAll.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGameSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameSelectAll.Image = Global.sstatesman.My.Resources.Resources.Icon_CheckAll
        Me.cmdGameSelectAll.Location = New System.Drawing.Point(79, 0)
        Me.cmdGameSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectAll.Name = "cmdGameSelectAll"
        Me.cmdGameSelectAll.Size = New System.Drawing.Size(47, 22)
        Me.cmdGameSelectAll.TabIndex = 34
        Me.cmdGameSelectAll.Text = "ALL"
        Me.cmdGameSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGameSelectAll.UseVisualStyleBackColor = False
        '
        'lblGameListCheck
        '
        Me.lblGameListCheck.AutoSize = True
        Me.lblGameListCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameListCheck.Location = New System.Drawing.Point(2, 0)
        Me.lblGameListCheck.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameListCheck.Name = "lblGameListCheck"
        Me.lblGameListCheck.Size = New System.Drawing.Size(75, 22)
        Me.lblGameListCheck.TabIndex = 33
        Me.lblGameListCheck.Text = "check games:"
        Me.lblGameListCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvwFilesList
        '
        Me.lvwFilesList.BackColor = System.Drawing.Color.White
        Me.lvwFilesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwFilesList.CheckBoxes = True
        Me.lvwFilesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwFilesList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwFilesList.ForeColor = System.Drawing.Color.Black
        Me.lvwFilesList.FullRowSelect = True
        Me.lvwFilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwFilesList.Location = New System.Drawing.Point(8, 22)
        Me.lvwFilesList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwFilesList.MultiSelect = False
        Me.lvwFilesList.Name = "lvwFilesList"
        Me.lvwFilesList.Size = New System.Drawing.Size(390, 92)
        Me.lvwFilesList.TabIndex = 37
        Me.lvwFilesList.UseCompatibleStateImageBehavior = False
        Me.lvwFilesList.View = System.Windows.Forms.View.Details
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
        Me.tlpFileListStatus.Location = New System.Drawing.Point(8, 114)
        Me.tlpFileListStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListStatus.Name = "tlpFileListStatus"
        Me.tlpFileListStatus.RowCount = 2
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFileListStatus.Size = New System.Drawing.Size(390, 39)
        Me.tlpFileListStatus.TabIndex = 48
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(0, 0)
        Me.lblSelected.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(49, 13)
        Me.lblSelected.TabIndex = 49
        Me.lblSelected.Text = "selected"
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
        Me.txtSelected.TabIndex = 50
        Me.txtSelected.TabStop = False
        Me.txtSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtSizeBackup.TabIndex = 54
        Me.txtSizeBackup.TabStop = False
        Me.txtSizeBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(132, 0)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(81, 13)
        Me.lblSize.TabIndex = 51
        Me.lblSize.Text = "savestates size"
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.AutoSize = True
        Me.lblSizeBackup.Location = New System.Drawing.Point(264, 0)
        Me.lblSizeBackup.Margin = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.lblSizeBackup.Name = "lblSizeBackup"
        Me.lblSizeBackup.Size = New System.Drawing.Size(72, 13)
        Me.lblSizeBackup.TabIndex = 53
        Me.lblSizeBackup.Text = "backups size"
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
        Me.txtSize.TabIndex = 52
        Me.txtSize.TabStop = False
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tlpFileListCommands
        '
        Me.tlpFileListCommands.AutoSize = True
        Me.tlpFileListCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFileListCommands.ColumnCount = 4
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListCommands.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFileListCommands.Controls.Add(Me.flpFileListCommandsFiles, 0, 0)
        Me.tlpFileListCommands.Controls.Add(Me.cmdExpandFilesList, 3, 0)
        Me.tlpFileListCommands.Controls.Add(Me.flpFileListCommandsCheck, 2, 0)
        Me.tlpFileListCommands.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpFileListCommands.Location = New System.Drawing.Point(8, 0)
        Me.tlpFileListCommands.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFileListCommands.Name = "tlpFileListCommands"
        Me.tlpFileListCommands.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.tlpFileListCommands.RowCount = 1
        Me.tlpFileListCommands.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFileListCommands.Size = New System.Drawing.Size(390, 22)
        Me.tlpFileListCommands.TabIndex = 38
        '
        'flpFileListCommandsFiles
        '
        Me.flpFileListCommandsFiles.AutoSize = True
        Me.flpFileListCommandsFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFileListCommandsFiles.Controls.Add(Me.cmdFilesReorder)
        Me.flpFileListCommandsFiles.Controls.Add(Me.cmdFilesDelete)
        Me.flpFileListCommandsFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFileListCommandsFiles.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpFileListCommandsFiles.Location = New System.Drawing.Point(16, 0)
        Me.flpFileListCommandsFiles.Margin = New System.Windows.Forms.Padding(0)
        Me.flpFileListCommandsFiles.Name = "flpFileListCommandsFiles"
        Me.flpFileListCommandsFiles.Size = New System.Drawing.Size(148, 22)
        Me.flpFileListCommandsFiles.TabIndex = 50
        Me.flpFileListCommandsFiles.WrapContents = False
        '
        'cmdFilesReorder
        '
        Me.cmdFilesReorder.AutoSize = True
        Me.cmdFilesReorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesReorder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdFilesReorder.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFilesReorder.FlatAppearance.BorderSize = 0
        Me.cmdFilesReorder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesReorder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFilesReorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesReorder.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesReorder.Image = Global.sstatesman.My.Resources.Resources.Glyph_Reorder
        Me.cmdFilesReorder.Location = New System.Drawing.Point(69, 0)
        Me.cmdFilesReorder.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFilesReorder.Name = "cmdFilesReorder"
        Me.cmdFilesReorder.Size = New System.Drawing.Size(79, 22)
        Me.cmdFilesReorder.TabIndex = 49
        Me.cmdFilesReorder.Text = "RE&ORDER..."
        Me.cmdFilesReorder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFilesReorder.UseVisualStyleBackColor = False
        '
        'cmdFilesDelete
        '
        Me.cmdFilesDelete.AutoSize = True
        Me.cmdFilesDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdFilesDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdFilesDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFilesDelete.FlatAppearance.BorderSize = 0
        Me.cmdFilesDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFilesDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFilesDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilesDelete.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFilesDelete.Image = Global.sstatesman.My.Resources.Resources.Glyph_TrashCan
        Me.cmdFilesDelete.Location = New System.Drawing.Point(0, 0)
        Me.cmdFilesDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFilesDelete.Name = "cmdFilesDelete"
        Me.cmdFilesDelete.Size = New System.Drawing.Size(69, 22)
        Me.cmdFilesDelete.TabIndex = 40
        Me.cmdFilesDelete.Text = "&DELETE..."
        Me.cmdFilesDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFilesDelete.UseVisualStyleBackColor = False
        '
        'cmdExpandFilesList
        '
        Me.cmdExpandFilesList.AutoSize = True
        Me.cmdExpandFilesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdExpandFilesList.BackColor = System.Drawing.Color.Transparent
        Me.cmdExpandFilesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdExpandFilesList.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdExpandFilesList.FlatAppearance.BorderSize = 0
        Me.cmdExpandFilesList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdExpandFilesList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdExpandFilesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExpandFilesList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdExpandFilesList.Image = Global.sstatesman.My.Resources.Resources.Icon_ExpandTop_12x12
        Me.cmdExpandFilesList.Location = New System.Drawing.Point(372, 0)
        Me.cmdExpandFilesList.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdExpandFilesList.Name = "cmdExpandFilesList"
        Me.cmdExpandFilesList.Size = New System.Drawing.Size(18, 22)
        Me.cmdExpandFilesList.TabIndex = 47
        Me.cmdExpandFilesList.UseVisualStyleBackColor = False
        '
        'flpFileListCommandsCheck
        '
        Me.flpFileListCommandsCheck.AutoSize = True
        Me.flpFileListCommandsCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFileListCommandsCheck.Controls.Add(Me.cmdFileCheckInvert)
        Me.flpFileListCommandsCheck.Controls.Add(Me.cmdFileCheckNone)
        Me.flpFileListCommandsCheck.Controls.Add(Me.cmdFileCheckAll)
        Me.flpFileListCommandsCheck.Controls.Add(Me.cmdFileCheckBackup)
        Me.flpFileListCommandsCheck.Controls.Add(Me.lblSStateListCheck)
        Me.flpFileListCommandsCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFileListCommandsCheck.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpFileListCommandsCheck.Location = New System.Drawing.Point(34, 0)
        Me.flpFileListCommandsCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.flpFileListCommandsCheck.Name = "flpFileListCommandsCheck"
        Me.flpFileListCommandsCheck.Size = New System.Drawing.Size(338, 22)
        Me.flpFileListCommandsCheck.TabIndex = 41
        Me.flpFileListCommandsCheck.WrapContents = False
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
        Me.cmdFileCheckInvert.Location = New System.Drawing.Point(275, 0)
        Me.cmdFileCheckInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckInvert.Name = "cmdFileCheckInvert"
        Me.cmdFileCheckInvert.Size = New System.Drawing.Size(63, 22)
        Me.cmdFileCheckInvert.TabIndex = 46
        Me.cmdFileCheckInvert.Text = "INVERT"
        Me.cmdFileCheckInvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckInvert.UseVisualStyleBackColor = False
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
        Me.cmdFileCheckNone.Location = New System.Drawing.Point(218, 0)
        Me.cmdFileCheckNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckNone.Name = "cmdFileCheckNone"
        Me.cmdFileCheckNone.Size = New System.Drawing.Size(57, 22)
        Me.cmdFileCheckNone.TabIndex = 45
        Me.cmdFileCheckNone.Text = "NONE"
        Me.cmdFileCheckNone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckNone.UseVisualStyleBackColor = False
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
        Me.cmdFileCheckAll.Location = New System.Drawing.Point(171, 0)
        Me.cmdFileCheckAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckAll.Name = "cmdFileCheckAll"
        Me.cmdFileCheckAll.Size = New System.Drawing.Size(47, 22)
        Me.cmdFileCheckAll.TabIndex = 44
        Me.cmdFileCheckAll.Text = "ALL"
        Me.cmdFileCheckAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckAll.UseVisualStyleBackColor = False
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
        Me.cmdFileCheckBackup.Location = New System.Drawing.Point(98, 0)
        Me.cmdFileCheckBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdFileCheckBackup.Name = "cmdFileCheckBackup"
        Me.cmdFileCheckBackup.Size = New System.Drawing.Size(73, 22)
        Me.cmdFileCheckBackup.TabIndex = 43
        Me.cmdFileCheckBackup.Text = "BACKUPS"
        Me.cmdFileCheckBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFileCheckBackup.UseVisualStyleBackColor = False
        '
        'lblSStateListCheck
        '
        Me.lblSStateListCheck.AutoSize = True
        Me.lblSStateListCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSStateListCheck.Location = New System.Drawing.Point(2, 0)
        Me.lblSStateListCheck.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSStateListCheck.Name = "lblSStateListCheck"
        Me.lblSStateListCheck.Size = New System.Drawing.Size(94, 22)
        Me.lblSStateListCheck.TabIndex = 42
        Me.lblSStateListCheck.Text = "check savestates:"
        Me.lblSStateListCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlScreenshotThumb
        '
        Me.pnlScreenshotThumb.Controls.Add(Me.imgScreenshotThumb)
        Me.pnlScreenshotThumb.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlScreenshotThumb.Location = New System.Drawing.Point(398, 0)
        Me.pnlScreenshotThumb.Name = "pnlScreenshotThumb"
        Me.pnlScreenshotThumb.Padding = New System.Windows.Forms.Padding(4, 2, 0, 0)
        Me.pnlScreenshotThumb.Size = New System.Drawing.Size(200, 153)
        Me.pnlScreenshotThumb.TabIndex = 49
        '
        'imgScreenshotThumb
        '
        Me.imgScreenshotThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgScreenshotThumb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgScreenshotThumb.Location = New System.Drawing.Point(4, 2)
        Me.imgScreenshotThumb.Name = "imgScreenshotThumb"
        Me.imgScreenshotThumb.Size = New System.Drawing.Size(196, 151)
        Me.imgScreenshotThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgScreenshotThumb.TabIndex = 0
        Me.imgScreenshotThumb.TabStop = False
        '
        'cmPCSX2
        '
        Me.cmPCSX2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmPCSX2.BackgroundImage = Global.sstatesman.My.Resources.Resources.BgStripesLight
        Me.cmPCSX2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmiPCSX2Launch, Me.cmiPCSX2Play, Me.ToolStripSeparator1, Me.cmiPCSX2GDE, Me.cmiPCSX2BinFolderOpen, Me.cmiPCSX2IniFolderOpen})
        Me.cmPCSX2.Name = "cmPCSX2"
        Me.cmPCSX2.Size = New System.Drawing.Size(200, 120)
        Me.cmPCSX2.Text = "Title Toolbar PCSX2 Menu"
        '
        'cmiPCSX2Launch
        '
        Me.cmiPCSX2Launch.Image = Global.sstatesman.My.Resources.Resources.Icon_PCSX2
        Me.cmiPCSX2Launch.Name = "cmiPCSX2Launch"
        Me.cmiPCSX2Launch.Size = New System.Drawing.Size(199, 22)
        Me.cmiPCSX2Launch.Text = "Launch PCSX2..."
        '
        'cmiPCSX2Play
        '
        Me.cmiPCSX2Play.Enabled = False
        Me.cmiPCSX2Play.Image = Global.sstatesman.My.Resources.Resources.Icon_GamePlay
        Me.cmiPCSX2Play.Name = "cmiPCSX2Play"
        Me.cmiPCSX2Play.Size = New System.Drawing.Size(199, 22)
        Me.cmiPCSX2Play.Text = "Play <game>..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(196, 6)
        '
        'cmiPCSX2GDE
        '
        Me.cmiPCSX2GDE.Image = Global.sstatesman.My.Resources.Resources.Icon_GDE
        Me.cmiPCSX2GDE.Name = "cmiPCSX2GDE"
        Me.cmiPCSX2GDE.Size = New System.Drawing.Size(199, 22)
        Me.cmiPCSX2GDE.Text = "GameDB Explorer..."
        '
        'cmiPCSX2BinFolderOpen
        '
        Me.cmiPCSX2BinFolderOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderPCSX2
        Me.cmiPCSX2BinFolderOpen.Name = "cmiPCSX2BinFolderOpen"
        Me.cmiPCSX2BinFolderOpen.Size = New System.Drawing.Size(199, 22)
        Me.cmiPCSX2BinFolderOpen.Text = "Open PCSX2 folder..."
        '
        'cmiPCSX2IniFolderOpen
        '
        Me.cmiPCSX2IniFolderOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderIni
        Me.cmiPCSX2IniFolderOpen.Name = "cmiPCSX2IniFolderOpen"
        Me.cmiPCSX2IniFolderOpen.Size = New System.Drawing.Size(199, 22)
        Me.cmiPCSX2IniFolderOpen.Text = "Open PCSX2 ini folder..."
        '
        'tmrSelectedItemChanged
        '
        Me.tmrSelectedItemChanged.Interval = 20
        '
        'bwLoadScreenshot
        '
        Me.bwLoadScreenshot.WorkerSupportsCancellation = True
        '
        'cmConfig
        '
        Me.cmConfig.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmConfig.BackgroundImage = Global.sstatesman.My.Resources.Resources.BgStripesLight
        Me.cmConfig.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmiConfigSettings, Me.cmiConfigLog, Me.cmiConfigDevTools, Me.ToolStripSeparator4, Me.cmiConfigAbout})
        Me.cmConfig.Name = "cmPCSX2"
        Me.cmConfig.Size = New System.Drawing.Size(133, 98)
        Me.cmConfig.Text = "Title Toolbar Config Menu"
        '
        'cmiConfigSettings
        '
        Me.cmiConfigSettings.Image = Global.sstatesman.My.Resources.Resources.Icon_Gear
        Me.cmiConfigSettings.Name = "cmiConfigSettings"
        Me.cmiConfigSettings.Size = New System.Drawing.Size(132, 22)
        Me.cmiConfigSettings.Text = "Settings..."
        '
        'cmiConfigLog
        '
        Me.cmiConfigLog.Image = Global.sstatesman.My.Resources.Resources.Icon_Log
        Me.cmiConfigLog.Name = "cmiConfigLog"
        Me.cmiConfigLog.Size = New System.Drawing.Size(132, 22)
        Me.cmiConfigLog.Text = "Log..."
        '
        'cmiConfigDevTools
        '
        Me.cmiConfigDevTools.Image = Global.sstatesman.My.Resources.Resources.Icon_Tools
        Me.cmiConfigDevTools.Name = "cmiConfigDevTools"
        Me.cmiConfigDevTools.Size = New System.Drawing.Size(132, 22)
        Me.cmiConfigDevTools.Text = "DevTools..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(129, 6)
        '
        'cmiConfigAbout
        '
        Me.cmiConfigAbout.Image = Global.sstatesman.My.Resources.Resources.InfoIcon_Information
        Me.cmiConfigAbout.Name = "cmiConfigAbout"
        Me.cmiConfigAbout.Size = New System.Drawing.Size(132, 22)
        Me.cmiConfigAbout.Text = "About..."
        '
        'cmFolders
        '
        Me.cmFolders.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmFolders.BackgroundImage = Global.sstatesman.My.Resources.Resources.BgStripesLight
        Me.cmFolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmiFoldersSStatesOpen, Me.cmiFoldersSnapsOpen, Me.ToolStripSeparator2, Me.cmiFoldersStoredOpen, Me.cmiFoldersIsoOpen, Me.cmiFoldersCoverOpen})
        Me.cmFolders.Name = "cmPCSX2"
        Me.cmFolders.Size = New System.Drawing.Size(240, 142)
        Me.cmFolders.Text = "Title Toolbar Folders Menu"
        '
        'cmiFoldersSStatesOpen
        '
        Me.cmiFoldersSStatesOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderSStates
        Me.cmiFoldersSStatesOpen.Name = "cmiFoldersSStatesOpen"
        Me.cmiFoldersSStatesOpen.Size = New System.Drawing.Size(239, 22)
        Me.cmiFoldersSStatesOpen.Text = "Open savestates folder..."
        '
        'cmiFoldersSnapsOpen
        '
        Me.cmiFoldersSnapsOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderScreenshots
        Me.cmiFoldersSnapsOpen.Name = "cmiFoldersSnapsOpen"
        Me.cmiFoldersSnapsOpen.Size = New System.Drawing.Size(239, 22)
        Me.cmiFoldersSnapsOpen.Text = "Open screenshots folder..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(236, 6)
        '
        'cmiFoldersStoredOpen
        '
        Me.cmiFoldersStoredOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderSStates
        Me.cmiFoldersStoredOpen.Name = "cmiFoldersStoredOpen"
        Me.cmiFoldersStoredOpen.Size = New System.Drawing.Size(239, 22)
        Me.cmiFoldersStoredOpen.Text = "Open stored savestates folder..."
        '
        'cmiFoldersIsoOpen
        '
        Me.cmiFoldersIsoOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderIso
        Me.cmiFoldersIsoOpen.Name = "cmiFoldersIsoOpen"
        Me.cmiFoldersIsoOpen.Size = New System.Drawing.Size(239, 22)
        Me.cmiFoldersIsoOpen.Text = "Open game disc image folder..."
        '
        'cmiFoldersCoverOpen
        '
        Me.cmiFoldersCoverOpen.Image = Global.sstatesman.My.Resources.Resources.Icon_FolderCover
        Me.cmiFoldersCoverOpen.Name = "cmiFoldersCoverOpen"
        Me.cmiFoldersCoverOpen.Size = New System.Drawing.Size(239, 22)
        Me.cmiFoldersCoverOpen.Text = "Open cover image folder..."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(632, 472)
        Me.Controls.Add(Me.flpTitleBarToolbar)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblWindowVersion)
        Me.Controls.Add(Me.tlpTopBar)
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmMain"
        Me.Text = "SStatesMan"
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.tlpTopBar, 0)
        Me.Controls.SetChildIndex(Me.lblWindowVersion, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.flpTitleBarToolbar, 0)
        Me.flpTitleBarToolbar.ResumeLayout(False)
        Me.flpTitleBarToolbar.PerformLayout()
        Me.tlpTopBar.ResumeLayout(False)
        Me.tlpTopBar.PerformLayout()
        Me.flpTab.ResumeLayout(False)
        Me.flpTab.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tlpGameList.ResumeLayout(False)
        Me.tlpGameList.PerformLayout()
        CType(Me.imgCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmCover.ResumeLayout(False)
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpGameListCommands.ResumeLayout(False)
        Me.tlpGameListCommands.PerformLayout()
        Me.flpGameListCommandsCheck.ResumeLayout(False)
        Me.flpGameListCommandsCheck.PerformLayout()
        Me.tlpFileListStatus.ResumeLayout(False)
        Me.tlpFileListStatus.PerformLayout()
        Me.tlpFileListCommands.ResumeLayout(False)
        Me.tlpFileListCommands.PerformLayout()
        Me.flpFileListCommandsFiles.ResumeLayout(False)
        Me.flpFileListCommandsFiles.PerformLayout()
        Me.flpFileListCommandsCheck.ResumeLayout(False)
        Me.flpFileListCommandsCheck.PerformLayout()
        Me.pnlScreenshotThumb.ResumeLayout(False)
        CType(Me.imgScreenshotThumb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmPCSX2.ResumeLayout(False)
        Me.cmConfig.ResumeLayout(False)
        Me.cmFolders.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblGameListCheck As System.Windows.Forms.Label
    Private WithEvents lblSStateListCheck As System.Windows.Forms.Label
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents GamesLvw_GameTitle As System.Windows.Forms.ColumnHeader
    Private WithEvents GameLvw_GameSerial As System.Windows.Forms.ColumnHeader
    Private WithEvents GameLvw_GameRegion As System.Windows.Forms.ColumnHeader
    Private WithEvents GameLvw_BackupInfo As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdFileCheckAll As System.Windows.Forms.Button
    Private WithEvents cmdFileCheckNone As System.Windows.Forms.Button
    Private WithEvents cmdFileCheckBackup As System.Windows.Forms.Button
    Private WithEvents txtGameList_Serial As System.Windows.Forms.TextBox
    Private WithEvents txtGameList_Region As System.Windows.Forms.TextBox
    Private WithEvents txtGameList_Title As System.Windows.Forms.TextBox
    Private WithEvents lblGameList_Serial As System.Windows.Forms.Label
    Private WithEvents lblGameList_Region As System.Windows.Forms.Label
    Private WithEvents lblGameList_Title As System.Windows.Forms.Label
    Private WithEvents cmdFilesDelete As System.Windows.Forms.Button
    Private WithEvents cmdFileCheckInvert As System.Windows.Forms.Button
    Private WithEvents cmdGameSelectInvert As System.Windows.Forms.Button
    Private WithEvents cmdGameSelectAll As System.Windows.Forms.Button
    Private WithEvents cmdGameSelectNone As System.Windows.Forms.Button
    Private WithEvents imgFlag As System.Windows.Forms.PictureBox
    Private WithEvents txtGameList_Compat As System.Windows.Forms.TextBox
    Private WithEvents lblGameList_Compat As System.Windows.Forms.Label
    Private WithEvents imgCover As System.Windows.Forms.PictureBox
    Private WithEvents lvwGamesList As System.Windows.Forms.ListView
    Private WithEvents lvwFilesList As System.Windows.Forms.ListView
    Private WithEvents cmdExpandFilesList As System.Windows.Forms.Button
    Private WithEvents GameLvw_SStatesInfo As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrSStatesListRefresh As System.Windows.Forms.Timer
    Private WithEvents flpFileListCommandsCheck As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents flpGameListCommandsCheck As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents tlpGameListCommands As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpGameList As System.Windows.Forms.TableLayoutPanel
    Private WithEvents flpTitleBarToolbar As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdToolbarConfig As System.Windows.Forms.Button
    Private WithEvents cmdToolbarPCSX2 As System.Windows.Forms.Button
    Private WithEvents lblWindowVersion As System.Windows.Forms.Label
    Private WithEvents tlpFileListCommands As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tlpFileListStatus As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblSelected As System.Windows.Forms.Label
    Private WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents txtSize As System.Windows.Forms.TextBox
    Private WithEvents flpTab As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents optTabHeader0 As System.Windows.Forms.RadioButton
    Private WithEvents optTabHeader1 As System.Windows.Forms.RadioButton
    Private WithEvents optTabHeader2 As System.Windows.Forms.RadioButton
    Private WithEvents tlpTopBar As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cmdRefresh As System.Windows.Forms.Button
    Private WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmPCSX2 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiPCSX2Launch As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiPCSX2BinFolderOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmiPCSX2GDE As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents txtSelected As System.Windows.Forms.TextBox
    Private WithEvents GameLvw_SnapsInfo As System.Windows.Forms.ColumnHeader
    Private WithEvents flpFileListCommandsFiles As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdFilesReorder As System.Windows.Forms.Button
    Private WithEvents cmCover As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiCoverAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiCoverOpenPicsFolder As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tmrSelectedItemChanged As System.Windows.Forms.Timer
    Private WithEvents pnlScreenshotThumb As System.Windows.Forms.Panel
    Private WithEvents imgScreenshotThumb As System.Windows.Forms.PictureBox
    Private WithEvents bwLoadScreenshot As System.ComponentModel.BackgroundWorker
    Private WithEvents GameLvw_Stored_Info As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdToolbarUser As System.Windows.Forms.Button
    Private WithEvents cmConfig As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiConfigSettings As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiConfigAbout As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiConfigDevTools As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiConfigLog As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmFolders As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiFoldersStoredOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiFoldersCoverOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiFoldersSStatesOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiFoldersSnapsOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmiPCSX2Play As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiPCSX2IniFolderOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiFoldersIsoOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmdGamePlay As System.Windows.Forms.Button
End Class
