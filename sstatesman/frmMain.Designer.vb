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
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwGamesList = New System.Windows.Forms.ListView()
        Me.GamesLvw_GameTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_GameSerial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_GameRegion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_SStatesInfo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_BackupInfo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameLvw_ArrayRef = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgCover = New System.Windows.Forms.PictureBox()
        Me.lblGameList_Title = New System.Windows.Forms.Label()
        Me.txtGameList_Title = New System.Windows.Forms.TextBox()
        Me.lblGameList_Region = New System.Windows.Forms.Label()
        Me.imgFlag = New System.Windows.Forms.PictureBox()
        Me.txtGameList_Compat = New System.Windows.Forms.TextBox()
        Me.txtGameList_Region = New System.Windows.Forms.TextBox()
        Me.lblGameList_Compat = New System.Windows.Forms.Label()
        Me.lblGameList_Serial = New System.Windows.Forms.Label()
        Me.txtGameList_Serial = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowPanelGameList = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdGameSelectInvert = New System.Windows.Forms.Button()
        Me.cmdGameSelectNone = New System.Windows.Forms.Button()
        Me.cmdGameSelectAll = New System.Windows.Forms.Button()
        Me.lblGameListCheck = New System.Windows.Forms.Label()
        Me.lvwSStatesList = New System.Windows.Forms.ListView()
        Me.SStatesLvw_FileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Slot = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Backup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Version = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_DateLastWrite = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_Size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SStatesLvw_SerialRef = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSStateListSelection = New System.Windows.Forms.Label()
        Me.txtSStateListSelection = New System.Windows.Forms.TextBox()
        Me.txtSizeBackup = New System.Windows.Forms.TextBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdSStatesLvwExpand = New System.Windows.Forms.Button()
        Me.cmdSStateDelete = New System.Windows.Forms.Button()
        Me.FlowPanelSStatesList = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdSStateSelectInvert = New System.Windows.Forms.Button()
        Me.cmdSStateSelectNone = New System.Windows.Forms.Button()
        Me.cmdSStateSelectAll = New System.Windows.Forms.Button()
        Me.cmdSStateSelectBackup = New System.Windows.Forms.Button()
        Me.lblSStateListCheck = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdSStateListUtil = New System.Windows.Forms.Button()
        Me.cmdGameDbUtil = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.blWindowDescription = New System.Windows.Forms.Label()
        Me.FlowPanelSettings = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdAbout = New System.Windows.Forms.Button()
        Me.cmdSettings = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdWindowMinimize = New System.Windows.Forms.Button()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.lblWindowVersion = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.flpTab = New System.Windows.Forms.FlowLayoutPanel()
        Me.optSettingTab1 = New System.Windows.Forms.RadioButton()
        Me.optSettingTab2 = New System.Windows.Forms.RadioButton()
        Me.optSettingTab3 = New System.Windows.Forms.RadioButton()
        Me.tmrSStatesListRefresh = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.imgCover, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowPanelGameList.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowPanelSStatesList.SuspendLayout()
        Me.panelWindowTitle.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowPanelSettings.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.flpTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 79)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.MinimumSize = New System.Drawing.Size(0, 160)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.SplitContainer1.Panel1MinSize = 200
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwSStatesList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel4)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.SplitContainer1.Panel2MinSize = 120
        Me.SplitContainer1.Size = New System.Drawing.Size(624, 385)
        Me.SplitContainer1.SplitterDistance = 208
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 20
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 9
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lvwGamesList, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.imgCover, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblGameList_Title, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtGameList_Title, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblGameList_Region, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.imgFlag, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtGameList_Compat, 7, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtGameList_Region, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblGameList_Compat, 6, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblGameList_Serial, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtGameList_Serial, 5, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(8, 22)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(608, 182)
        Me.TableLayoutPanel3.TabIndex = 21
        '
        'lvwGamesList
        '
        Me.lvwGamesList.BackColor = System.Drawing.Color.White
        Me.lvwGamesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwGamesList.CheckBoxes = True
        Me.lvwGamesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.GamesLvw_GameTitle, Me.GameLvw_GameSerial, Me.GameLvw_GameRegion, Me.GameLvw_SStatesInfo, Me.GameLvw_BackupInfo, Me.GameLvw_ArrayRef})
        Me.TableLayoutPanel3.SetColumnSpan(Me.lvwGamesList, 9)
        Me.lvwGamesList.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvwGamesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwGamesList.ForeColor = System.Drawing.Color.DimGray
        Me.lvwGamesList.FullRowSelect = True
        Me.lvwGamesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwGamesList.HideSelection = False
        Me.lvwGamesList.Location = New System.Drawing.Point(0, 0)
        Me.lvwGamesList.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.lvwGamesList.MultiSelect = False
        Me.lvwGamesList.Name = "lvwGamesList"
        Me.lvwGamesList.Size = New System.Drawing.Size(608, 128)
        Me.lvwGamesList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwGamesList.TabIndex = 22
        Me.lvwGamesList.TileSize = New System.Drawing.Size(480, 96)
        Me.lvwGamesList.UseCompatibleStateImageBehavior = False
        Me.lvwGamesList.View = System.Windows.Forms.View.Details
        '
        'GamesLvw_GameTitle
        '
        Me.GamesLvw_GameTitle.Text = "Game title"
        Me.GamesLvw_GameTitle.Width = 220
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
        Me.GameLvw_SStatesInfo.Width = 110
        '
        'GameLvw_BackupInfo
        '
        Me.GameLvw_BackupInfo.Text = "Backups"
        Me.GameLvw_BackupInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GameLvw_BackupInfo.Width = 110
        '
        'GameLvw_ArrayRef
        '
        Me.GameLvw_ArrayRef.Text = "#"
        Me.GameLvw_ArrayRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.GameLvw_ArrayRef.Width = 0
        '
        'imgCover
        '
        Me.imgCover.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.imgCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgCover.Location = New System.Drawing.Point(0, 132)
        Me.imgCover.Margin = New System.Windows.Forms.Padding(0, 0, 4, 2)
        Me.imgCover.Name = "imgCover"
        Me.TableLayoutPanel3.SetRowSpan(Me.imgCover, 2)
        Me.imgCover.Size = New System.Drawing.Size(48, 48)
        Me.imgCover.TabIndex = 26
        Me.imgCover.TabStop = False
        '
        'lblGameList_Title
        '
        Me.lblGameList_Title.AutoSize = True
        Me.lblGameList_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Title.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblGameList_Title.Location = New System.Drawing.Point(64, 132)
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
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtGameList_Title, 7)
        Me.txtGameList_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Title.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Title.Location = New System.Drawing.Point(126, 132)
        Me.txtGameList_Title.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.txtGameList_Title.Name = "txtGameList_Title"
        Me.txtGameList_Title.ReadOnly = True
        Me.txtGameList_Title.Size = New System.Drawing.Size(482, 22)
        Me.txtGameList_Title.TabIndex = 24
        Me.txtGameList_Title.TabStop = False
        '
        'lblGameList_Region
        '
        Me.lblGameList_Region.AutoSize = True
        Me.lblGameList_Region.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Region.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblGameList_Region.Location = New System.Drawing.Point(64, 156)
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
        Me.imgFlag.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.imgFlag.Image = Global.sstatesman.My.Resources.Resources.Flag_0Null_30x20
        Me.imgFlag.Location = New System.Drawing.Point(228, 158)
        Me.imgFlag.Margin = New System.Windows.Forms.Padding(2)
        Me.imgFlag.Name = "imgFlag"
        Me.imgFlag.Size = New System.Drawing.Size(32, 22)
        Me.imgFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgFlag.TabIndex = 23
        Me.imgFlag.TabStop = False
        '
        'txtGameList_Compat
        '
        Me.txtGameList_Compat.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Compat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Compat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Compat.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Compat.Location = New System.Drawing.Point(473, 158)
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
        Me.txtGameList_Region.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Region.Location = New System.Drawing.Point(126, 158)
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
        Me.lblGameList_Compat.Location = New System.Drawing.Point(406, 156)
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
        Me.lblGameList_Serial.Location = New System.Drawing.Point(264, 156)
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
        Me.txtGameList_Serial.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Serial.Location = New System.Drawing.Point(302, 158)
        Me.txtGameList_Serial.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Serial.Name = "txtGameList_Serial"
        Me.txtGameList_Serial.ReadOnly = True
        Me.txtGameList_Serial.Size = New System.Drawing.Size(100, 22)
        Me.txtGameList_Serial.TabIndex = 28
        Me.txtGameList_Serial.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.FlowPanelGameList, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(8, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(608, 22)
        Me.TableLayoutPanel2.TabIndex = 31
        '
        'FlowPanelGameList
        '
        Me.FlowPanelGameList.AutoSize = True
        Me.FlowPanelGameList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowPanelGameList.Controls.Add(Me.cmdGameSelectInvert)
        Me.FlowPanelGameList.Controls.Add(Me.cmdGameSelectNone)
        Me.FlowPanelGameList.Controls.Add(Me.cmdGameSelectAll)
        Me.FlowPanelGameList.Controls.Add(Me.lblGameListCheck)
        Me.FlowPanelGameList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowPanelGameList.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowPanelGameList.Location = New System.Drawing.Point(394, 0)
        Me.FlowPanelGameList.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowPanelGameList.Name = "FlowPanelGameList"
        Me.FlowPanelGameList.Size = New System.Drawing.Size(198, 22)
        Me.FlowPanelGameList.TabIndex = 32
        Me.FlowPanelGameList.WrapContents = False
        '
        'cmdGameSelectInvert
        '
        Me.cmdGameSelectInvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameSelectInvert.AutoSize = True
        Me.cmdGameSelectInvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGameSelectInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectInvert.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGameSelectInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameSelectInvert.Location = New System.Drawing.Point(151, 0)
        Me.cmdGameSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectInvert.Name = "cmdGameSelectInvert"
        Me.cmdGameSelectInvert.Size = New System.Drawing.Size(47, 22)
        Me.cmdGameSelectInvert.TabIndex = 36
        Me.cmdGameSelectInvert.Text = "INVERT"
        Me.cmdGameSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdGameSelectNone
        '
        Me.cmdGameSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameSelectNone.AutoSize = True
        Me.cmdGameSelectNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGameSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectNone.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGameSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameSelectNone.Location = New System.Drawing.Point(110, 0)
        Me.cmdGameSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectNone.Name = "cmdGameSelectNone"
        Me.cmdGameSelectNone.Size = New System.Drawing.Size(41, 22)
        Me.cmdGameSelectNone.TabIndex = 35
        Me.cmdGameSelectNone.Text = "NONE"
        Me.cmdGameSelectNone.UseVisualStyleBackColor = False
        '
        'cmdGameSelectAll
        '
        Me.cmdGameSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameSelectAll.AutoSize = True
        Me.cmdGameSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdGameSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectAll.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdGameSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameSelectAll.Location = New System.Drawing.Point(79, 0)
        Me.cmdGameSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectAll.Name = "cmdGameSelectAll"
        Me.cmdGameSelectAll.Size = New System.Drawing.Size(31, 22)
        Me.cmdGameSelectAll.TabIndex = 34
        Me.cmdGameSelectAll.Text = "ALL"
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
        'lvwSStatesList
        '
        Me.lvwSStatesList.BackColor = System.Drawing.Color.White
        Me.lvwSStatesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwSStatesList.CheckBoxes = True
        Me.lvwSStatesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SStatesLvw_FileName, Me.SStatesLvw_Slot, Me.SStatesLvw_Backup, Me.SStatesLvw_Version, Me.SStatesLvw_DateLastWrite, Me.SStatesLvw_Size, Me.SStatesLvw_SerialRef})
        Me.lvwSStatesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSStatesList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvwSStatesList.ForeColor = System.Drawing.Color.DimGray
        Me.lvwSStatesList.FullRowSelect = True
        Me.lvwSStatesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSStatesList.Location = New System.Drawing.Point(8, 22)
        Me.lvwSStatesList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwSStatesList.MultiSelect = False
        Me.lvwSStatesList.Name = "lvwSStatesList"
        Me.lvwSStatesList.Size = New System.Drawing.Size(608, 109)
        Me.lvwSStatesList.TabIndex = 37
        Me.lvwSStatesList.UseCompatibleStateImageBehavior = False
        Me.lvwSStatesList.View = System.Windows.Forms.View.Details
        '
        'SStatesLvw_FileName
        '
        Me.SStatesLvw_FileName.Text = "Savestate file name"
        Me.SStatesLvw_FileName.Width = 220
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
        Me.SStatesLvw_Backup.Width = 40
        '
        'SStatesLvw_Version
        '
        Me.SStatesLvw_Version.Text = "Version"
        Me.SStatesLvw_Version.Width = 80
        '
        'SStatesLvw_DateLastWrite
        '
        Me.SStatesLvw_DateLastWrite.Text = "Modify date"
        Me.SStatesLvw_DateLastWrite.Width = 120
        '
        'SStatesLvw_Size
        '
        Me.SStatesLvw_Size.Text = "Size"
        Me.SStatesLvw_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SStatesLvw_Size.Width = 80
        '
        'SStatesLvw_SerialRef
        '
        Me.SStatesLvw_SerialRef.Text = "Serial"
        Me.SStatesLvw_SerialRef.Width = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.lblSStateListSelection, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSStateListSelection, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSizeBackup, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblSize, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.lblSizeBackup, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSize, 1, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(8, 131)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(608, 39)
        Me.TableLayoutPanel5.TabIndex = 48
        '
        'lblSStateListSelection
        '
        Me.lblSStateListSelection.AutoSize = True
        Me.lblSStateListSelection.Location = New System.Drawing.Point(0, 0)
        Me.lblSStateListSelection.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.lblSStateListSelection.Name = "lblSStateListSelection"
        Me.lblSStateListSelection.Size = New System.Drawing.Size(53, 13)
        Me.lblSStateListSelection.TabIndex = 49
        Me.lblSStateListSelection.Text = "selection"
        '
        'txtSStateListSelection
        '
        Me.txtSStateListSelection.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSStateListSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSStateListSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSStateListSelection.ForeColor = System.Drawing.Color.DimGray
        Me.txtSStateListSelection.Location = New System.Drawing.Point(0, 15)
        Me.txtSStateListSelection.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.txtSStateListSelection.Name = "txtSStateListSelection"
        Me.txtSStateListSelection.ReadOnly = True
        Me.txtSStateListSelection.Size = New System.Drawing.Size(128, 22)
        Me.txtSStateListSelection.TabIndex = 50
        Me.txtSStateListSelection.TabStop = False
        Me.txtSStateListSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSizeBackup
        '
        Me.txtSizeBackup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSizeBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSizeBackup.ForeColor = System.Drawing.Color.DimGray
        Me.txtSizeBackup.Location = New System.Drawing.Point(264, 15)
        Me.txtSizeBackup.Margin = New System.Windows.Forms.Padding(2)
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
        Me.lblSize.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(64, 13)
        Me.lblSize.TabIndex = 51
        Me.lblSize.Text = "sstates size"
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.AutoSize = True
        Me.lblSizeBackup.Location = New System.Drawing.Point(264, 0)
        Me.lblSizeBackup.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.txtSize.ForeColor = System.Drawing.Color.DimGray
        Me.txtSize.Location = New System.Drawing.Point(132, 15)
        Me.txtSize.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(128, 22)
        Me.txtSize.TabIndex = 52
        Me.txtSize.TabStop = False
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.cmdSStatesLvwExpand, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmdSStateDelete, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowPanelSStatesList, 2, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(8, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(608, 22)
        Me.TableLayoutPanel4.TabIndex = 38
        '
        'cmdSStatesLvwExpand
        '
        Me.cmdSStatesLvwExpand.AutoSize = True
        Me.cmdSStatesLvwExpand.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStatesLvwExpand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdSStatesLvwExpand.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStatesLvwExpand.FlatAppearance.BorderSize = 0
        Me.cmdSStatesLvwExpand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStatesLvwExpand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStatesLvwExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStatesLvwExpand.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdSStatesLvwExpand.Image = Global.sstatesman.My.Resources.Resources.Metro_ExpandTop
        Me.cmdSStatesLvwExpand.Location = New System.Drawing.Point(590, 0)
        Me.cmdSStatesLvwExpand.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStatesLvwExpand.Name = "cmdSStatesLvwExpand"
        Me.cmdSStatesLvwExpand.Size = New System.Drawing.Size(18, 22)
        Me.cmdSStatesLvwExpand.TabIndex = 47
        Me.cmdSStatesLvwExpand.UseVisualStyleBackColor = False
        '
        'cmdSStateDelete
        '
        Me.cmdSStateDelete.AutoSize = True
        Me.cmdSStateDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateDelete.FlatAppearance.BorderSize = 0
        Me.cmdSStateDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateDelete.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateDelete.Location = New System.Drawing.Point(16, 0)
        Me.cmdSStateDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateDelete.Name = "cmdSStateDelete"
        Me.cmdSStateDelete.Size = New System.Drawing.Size(91, 22)
        Me.cmdSStateDelete.TabIndex = 40
        Me.cmdSStateDelete.Text = "&DELETE CHECKED"
        Me.cmdSStateDelete.UseVisualStyleBackColor = False
        '
        'FlowPanelSStatesList
        '
        Me.FlowPanelSStatesList.AutoSize = True
        Me.FlowPanelSStatesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdSStateSelectInvert)
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdSStateSelectNone)
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdSStateSelectAll)
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdSStateSelectBackup)
        Me.FlowPanelSStatesList.Controls.Add(Me.lblSStateListCheck)
        Me.FlowPanelSStatesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowPanelSStatesList.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowPanelSStatesList.Location = New System.Drawing.Point(315, 0)
        Me.FlowPanelSStatesList.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowPanelSStatesList.Name = "FlowPanelSStatesList"
        Me.FlowPanelSStatesList.Size = New System.Drawing.Size(275, 22)
        Me.FlowPanelSStatesList.TabIndex = 41
        Me.FlowPanelSStatesList.WrapContents = False
        '
        'cmdSStateSelectInvert
        '
        Me.cmdSStateSelectInvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectInvert.AutoSize = True
        Me.cmdSStateSelectInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectInvert.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectInvert.Location = New System.Drawing.Point(228, 0)
        Me.cmdSStateSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectInvert.Name = "cmdSStateSelectInvert"
        Me.cmdSStateSelectInvert.Size = New System.Drawing.Size(47, 22)
        Me.cmdSStateSelectInvert.TabIndex = 46
        Me.cmdSStateSelectInvert.Text = "INVERT"
        Me.cmdSStateSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectNone
        '
        Me.cmdSStateSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectNone.AutoSize = True
        Me.cmdSStateSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectNone.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectNone.Location = New System.Drawing.Point(187, 0)
        Me.cmdSStateSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectNone.Name = "cmdSStateSelectNone"
        Me.cmdSStateSelectNone.Size = New System.Drawing.Size(41, 22)
        Me.cmdSStateSelectNone.TabIndex = 45
        Me.cmdSStateSelectNone.Text = "NONE"
        Me.cmdSStateSelectNone.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectAll
        '
        Me.cmdSStateSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectAll.AutoSize = True
        Me.cmdSStateSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectAll.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectAll.Location = New System.Drawing.Point(155, 0)
        Me.cmdSStateSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectAll.Name = "cmdSStateSelectAll"
        Me.cmdSStateSelectAll.Size = New System.Drawing.Size(32, 22)
        Me.cmdSStateSelectAll.TabIndex = 44
        Me.cmdSStateSelectAll.Text = "ALL"
        Me.cmdSStateSelectAll.UseVisualStyleBackColor = False
        '
        'cmdSStateSelectBackup
        '
        Me.cmdSStateSelectBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateSelectBackup.AutoSize = True
        Me.cmdSStateSelectBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateSelectBackup.FlatAppearance.BorderSize = 0
        Me.cmdSStateSelectBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateSelectBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSStateSelectBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateSelectBackup.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateSelectBackup.Location = New System.Drawing.Point(98, 0)
        Me.cmdSStateSelectBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectBackup.Name = "cmdSStateSelectBackup"
        Me.cmdSStateSelectBackup.Size = New System.Drawing.Size(57, 22)
        Me.cmdSStateSelectBackup.TabIndex = 43
        Me.cmdSStateSelectBackup.Text = "BACKUPS"
        Me.cmdSStateSelectBackup.UseVisualStyleBackColor = False
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
        'panelWindowTitle
        '
        Me.panelWindowTitle.AutoSize = True
        Me.panelWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.panelWindowTitle.Controls.Add(Me.TableLayoutPanel1)
        Me.panelWindowTitle.Controls.Add(Me.TableLayoutPanel6)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.MinimumSize = New System.Drawing.Size(0, 56)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(624, 79)
        Me.panelWindowTitle.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowPanelSettings, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.imgWindowGradientIcon, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblWindowVersion, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 56)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel3, 3)
        Me.FlowLayoutPanel3.Controls.Add(Me.cmdSStateListUtil)
        Me.FlowLayoutPanel3.Controls.Add(Me.cmdGameDbUtil)
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(485, 34)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 0, 16, 0)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(139, 22)
        Me.FlowLayoutPanel3.TabIndex = 11
        Me.FlowLayoutPanel3.WrapContents = False
        '
        'cmdSStateListUtil
        '
        Me.cmdSStateListUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateListUtil.AutoSize = True
        Me.cmdSStateListUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateListUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateListUtil.FlatAppearance.BorderSize = 0
        Me.cmdSStateListUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateListUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateListUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateListUtil.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSStateListUtil.Location = New System.Drawing.Point(54, 0)
        Me.cmdSStateListUtil.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateListUtil.Name = "cmdSStateListUtil"
        Me.cmdSStateListUtil.Size = New System.Drawing.Size(69, 22)
        Me.cmdSStateListUtil.TabIndex = 13
        Me.cmdSStateListUtil.Text = "SSTATESLIST"
        Me.cmdSStateListUtil.UseVisualStyleBackColor = False
        '
        'cmdGameDbUtil
        '
        Me.cmdGameDbUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameDbUtil.AutoSize = True
        Me.cmdGameDbUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdGameDbUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameDbUtil.FlatAppearance.BorderSize = 0
        Me.cmdGameDbUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameDbUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGameDbUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameDbUtil.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdGameDbUtil.Location = New System.Drawing.Point(0, 0)
        Me.cmdGameDbUtil.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameDbUtil.Name = "cmdGameDbUtil"
        Me.cmdGameDbUtil.Size = New System.Drawing.Size(54, 22)
        Me.cmdGameDbUtil.TabIndex = 12
        Me.cmdGameDbUtil.Text = "GAMEDB"
        Me.cmdGameDbUtil.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel2.Controls.Add(Me.lblWindowTitle)
        Me.FlowLayoutPanel2.Controls.Add(Me.blWindowDescription)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(24, 4, 0, 4)
        Me.TableLayoutPanel1.SetRowSpan(Me.FlowLayoutPanel2, 3)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(398, 52)
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
        Me.lblWindowTitle.Size = New System.Drawing.Size(122, 30)
        Me.lblWindowTitle.TabIndex = 2
        Me.lblWindowTitle.Text = "SStatesMan"
        '
        'blWindowDescription
        '
        Me.blWindowDescription.AutoSize = True
        Me.blWindowDescription.BackColor = System.Drawing.Color.Transparent
        Me.blWindowDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.blWindowDescription.Location = New System.Drawing.Point(26, 34)
        Me.blWindowDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.blWindowDescription.Name = "blWindowDescription"
        Me.blWindowDescription.Size = New System.Drawing.Size(194, 13)
        Me.blWindowDescription.TabIndex = 3
        Me.blWindowDescription.Text = "a savestate managing tool for PCSX2"
        '
        'FlowPanelSettings
        '
        Me.FlowPanelSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowPanelSettings.AutoSize = True
        Me.FlowPanelSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowPanelSettings.Controls.Add(Me.cmdAbout)
        Me.FlowPanelSettings.Controls.Add(Me.cmdSettings)
        Me.FlowPanelSettings.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowPanelSettings.Location = New System.Drawing.Point(402, 0)
        Me.FlowPanelSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowPanelSettings.Name = "FlowPanelSettings"
        Me.FlowPanelSettings.Size = New System.Drawing.Size(104, 22)
        Me.FlowPanelSettings.TabIndex = 5
        Me.FlowPanelSettings.WrapContents = False
        '
        'cmdAbout
        '
        Me.cmdAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAbout.AutoSize = True
        Me.cmdAbout.BackColor = System.Drawing.Color.Transparent
        Me.cmdAbout.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdAbout.FlatAppearance.BorderSize = 0
        Me.cmdAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAbout.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdAbout.Location = New System.Drawing.Point(58, 0)
        Me.cmdAbout.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(46, 22)
        Me.cmdAbout.TabIndex = 7
        Me.cmdAbout.Text = "ABOUT"
        Me.cmdAbout.UseVisualStyleBackColor = False
        '
        'cmdSettings
        '
        Me.cmdSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSettings.AutoSize = True
        Me.cmdSettings.BackColor = System.Drawing.Color.Transparent
        Me.cmdSettings.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSettings.FlatAppearance.BorderSize = 0
        Me.cmdSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSettings.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSettings.Location = New System.Drawing.Point(0, 0)
        Me.cmdSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(58, 22)
        Me.cmdSettings.TabIndex = 6
        Me.cmdSettings.Text = "&SETTINGS"
        Me.cmdSettings.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowMinimize)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowMaximize)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdWindowClose)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(546, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(72, 16)
        Me.FlowLayoutPanel1.TabIndex = 23
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'cmdWindowMinimize
        '
        Me.cmdWindowMinimize.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowMinimize.FlatAppearance.BorderSize = 0
        Me.cmdWindowMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdWindowMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdWindowMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowMinimize.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdWindowMinimize.Image = Global.sstatesman.My.Resources.Resources.Metro_WindowButtonMinimize
        Me.cmdWindowMinimize.Location = New System.Drawing.Point(0, 0)
        Me.cmdWindowMinimize.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowMinimize.Name = "cmdWindowMinimize"
        Me.cmdWindowMinimize.Size = New System.Drawing.Size(24, 16)
        Me.cmdWindowMinimize.TabIndex = 8
        Me.cmdWindowMinimize.UseVisualStyleBackColor = False
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
        Me.cmdWindowMaximize.Location = New System.Drawing.Point(24, 0)
        Me.cmdWindowMaximize.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowMaximize.Name = "cmdWindowMaximize"
        Me.cmdWindowMaximize.Size = New System.Drawing.Size(24, 16)
        Me.cmdWindowMaximize.TabIndex = 9
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
        Me.cmdWindowClose.Location = New System.Drawing.Point(48, 0)
        Me.cmdWindowClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWindowClose.Name = "cmdWindowClose"
        Me.cmdWindowClose.Size = New System.Drawing.Size(24, 16)
        Me.cmdWindowClose.TabIndex = 10
        Me.cmdWindowClose.UseVisualStyleBackColor = False
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientIcon.Image = Global.sstatesman.My.Resources.Resources.SSM1ico24
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(510, 0)
        Me.imgWindowGradientIcon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.TableLayoutPanel1.SetRowSpan(Me.imgWindowGradientIcon, 2)
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'lblWindowVersion
        '
        Me.lblWindowVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWindowVersion.AutoSize = True
        Me.lblWindowVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowVersion.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowVersion.Location = New System.Drawing.Point(469, 22)
        Me.lblWindowVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWindowVersion.Name = "lblWindowVersion"
        Me.lblWindowVersion.Size = New System.Drawing.Size(35, 12)
        Me.lblWindowVersion.TabIndex = 8
        Me.lblWindowVersion.Text = "version "
        Me.lblWindowVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.AutoSize = True
        Me.TableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Controls.Add(Me.cmdRefresh, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.flpTab, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 56)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(624, 23)
        Me.TableLayoutPanel6.TabIndex = 14
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
        Me.cmdRefresh.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Refresh
        Me.cmdRefresh.Location = New System.Drawing.Point(540, 0)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(68, 23)
        Me.cmdRefresh.TabIndex = 19
        Me.cmdRefresh.Text = "&REFRESH"
        Me.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'flpTab
        '
        Me.flpTab.AutoSize = True
        Me.flpTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTab.Controls.Add(Me.optSettingTab1)
        Me.flpTab.Controls.Add(Me.optSettingTab2)
        Me.flpTab.Controls.Add(Me.optSettingTab3)
        Me.flpTab.Location = New System.Drawing.Point(16, 0)
        Me.flpTab.Margin = New System.Windows.Forms.Padding(0)
        Me.flpTab.Name = "flpTab"
        Me.flpTab.Size = New System.Drawing.Size(203, 23)
        Me.flpTab.TabIndex = 15
        Me.flpTab.Visible = False
        Me.flpTab.WrapContents = False
        '
        'optSettingTab1
        '
        Me.optSettingTab1.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab1.AutoSize = True
        Me.optSettingTab1.Checked = True
        Me.optSettingTab1.FlatAppearance.BorderSize = 0
        Me.optSettingTab1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.optSettingTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab1.Location = New System.Drawing.Point(0, 0)
        Me.optSettingTab1.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab1.Name = "optSettingTab1"
        Me.optSettingTab1.Size = New System.Drawing.Size(69, 23)
        Me.optSettingTab1.TabIndex = 16
        Me.optSettingTab1.TabStop = True
        Me.optSettingTab1.Text = "savestates"
        Me.optSettingTab1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab1.UseVisualStyleBackColor = False
        '
        'optSettingTab2
        '
        Me.optSettingTab2.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab2.AutoSize = True
        Me.optSettingTab2.FlatAppearance.BorderSize = 0
        Me.optSettingTab2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.optSettingTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab2.Location = New System.Drawing.Point(69, 0)
        Me.optSettingTab2.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab2.Name = "optSettingTab2"
        Me.optSettingTab2.Size = New System.Drawing.Size(56, 23)
        Me.optSettingTab2.TabIndex = 17
        Me.optSettingTab2.Text = "storage"
        Me.optSettingTab2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab2.UseVisualStyleBackColor = False
        '
        'optSettingTab3
        '
        Me.optSettingTab3.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab3.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab3.AutoSize = True
        Me.optSettingTab3.FlatAppearance.BorderSize = 0
        Me.optSettingTab3.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.optSettingTab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab3.Location = New System.Drawing.Point(125, 0)
        Me.optSettingTab3.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab3.Name = "optSettingTab3"
        Me.optSettingTab3.Size = New System.Drawing.Size(78, 23)
        Me.optSettingTab3.TabIndex = 18
        Me.optSettingTab3.Text = "screenshots"
        Me.optSettingTab3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab3.UseVisualStyleBackColor = False
        '
        'tmrSStatesListRefresh
        '
        Me.tmrSStatesListRefresh.Interval = 5000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(624, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmMain"
        Me.Text = "SStatesman"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.imgCover, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowPanelGameList.ResumeLayout(False)
        Me.FlowPanelGameList.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowPanelSStatesList.ResumeLayout(False)
        Me.FlowPanelSStatesList.PerformLayout()
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowPanelSettings.ResumeLayout(False)
        Me.FlowPanelSettings.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.flpTab.ResumeLayout(False)
        Me.flpTab.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblGameListCheck As System.Windows.Forms.Label
    Private WithEvents lblSStateListCheck As System.Windows.Forms.Label
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Private WithEvents blWindowDescription As System.Windows.Forms.Label
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents GamesLvw_GameTitle As System.Windows.Forms.ColumnHeader
    Private WithEvents GameLvw_GameSerial As System.Windows.Forms.ColumnHeader
    Private WithEvents GameLvw_GameRegion As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_FileName As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Slot As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Backup As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_Size As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_DateLastWrite As System.Windows.Forms.ColumnHeader
    Private WithEvents GameLvw_BackupInfo As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdSStateSelectAll As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectNone As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectBackup As System.Windows.Forms.Button
    Private WithEvents GameLvw_ArrayRef As System.Windows.Forms.ColumnHeader
    Private WithEvents SStatesLvw_SerialRef As System.Windows.Forms.ColumnHeader
    Private WithEvents txtGameList_Serial As System.Windows.Forms.TextBox
    Private WithEvents txtGameList_Region As System.Windows.Forms.TextBox
    Private WithEvents txtGameList_Title As System.Windows.Forms.TextBox
    Private WithEvents lblGameList_Serial As System.Windows.Forms.Label
    Private WithEvents lblGameList_Region As System.Windows.Forms.Label
    Private WithEvents lblGameList_Title As System.Windows.Forms.Label
    Private WithEvents cmdSStateDelete As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectInvert As System.Windows.Forms.Button
    Private WithEvents cmdGameSelectInvert As System.Windows.Forms.Button
    Private WithEvents cmdGameSelectAll As System.Windows.Forms.Button
    Private WithEvents cmdGameSelectNone As System.Windows.Forms.Button
    Private WithEvents imgFlag As System.Windows.Forms.PictureBox
    Private WithEvents txtGameList_Compat As System.Windows.Forms.TextBox
    Private WithEvents lblGameList_Compat As System.Windows.Forms.Label
    Private WithEvents imgCover As System.Windows.Forms.PictureBox
    Friend WithEvents lvwGamesList As System.Windows.Forms.ListView
    Friend WithEvents lvwSStatesList As System.Windows.Forms.ListView
    Private WithEvents cmdSStatesLvwExpand As System.Windows.Forms.Button
    Private WithEvents GameLvw_SStatesInfo As System.Windows.Forms.ColumnHeader
    Protected Friend WithEvents tmrSStatesListRefresh As System.Windows.Forms.Timer
    Friend WithEvents FlowPanelSStatesList As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowPanelGameList As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowPanelSettings As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdAbout As System.Windows.Forms.Button
    Private WithEvents cmdSettings As System.Windows.Forms.Button
    Private WithEvents cmdSStateListUtil As System.Windows.Forms.Button
    Private WithEvents cmdGameDbUtil As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdWindowMinimize As System.Windows.Forms.Button
    Private WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Private WithEvents cmdWindowClose As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Private WithEvents lblWindowVersion As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblSStateListSelection As System.Windows.Forms.Label
    Private WithEvents txtSStateListSelection As System.Windows.Forms.TextBox
    Private WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents flpTab As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents optSettingTab1 As System.Windows.Forms.RadioButton
    Private WithEvents optSettingTab2 As System.Windows.Forms.RadioButton
    Private WithEvents optSettingTab3 As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents SStatesLvw_Version As System.Windows.Forms.ColumnHeader
End Class
