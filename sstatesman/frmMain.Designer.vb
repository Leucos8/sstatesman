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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imgFlag = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblGameListCheck = New System.Windows.Forms.Label()
        Me.txtGameList_Compat = New System.Windows.Forms.TextBox()
        Me.lblGameList_Compat = New System.Windows.Forms.Label()
        Me.cmdGameSelectInvert = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdGameSelectAll = New System.Windows.Forms.Button()
        Me.cmdGameSelectNone = New System.Windows.Forms.Button()
        Me.txtGameList_Serial = New System.Windows.Forms.TextBox()
        Me.txtGameList_Region = New System.Windows.Forms.TextBox()
        Me.txtGameList_Title = New System.Windows.Forms.TextBox()
        Me.lblGameList_Serial = New System.Windows.Forms.Label()
        Me.lblGameList_Region = New System.Windows.Forms.Label()
        Me.lblGameList_Title = New System.Windows.Forms.Label()
        Me.lvwGamesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ArrayPosition = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblSStateListCheck = New System.Windows.Forms.Label()
        Me.txtSStateListSelection = New System.Windows.Forms.TextBox()
        Me.lblSizeBackup = New System.Windows.Forms.Label()
        Me.lblSStateListSelection = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSizeBackup = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.cmdSStateSelectInvert = New System.Windows.Forms.Button()
        Me.cmdSStateDelete = New System.Windows.Forms.Button()
        Me.lvwSStatesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdSStateSelectBackup = New System.Windows.Forms.Button()
        Me.cmdSStateSelectAll = New System.Windows.Forms.Button()
        Me.cmdSStateSelectNone = New System.Windows.Forms.Button()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSettings = New System.Windows.Forms.Button()
        Me.cmdAbout = New System.Windows.Forms.Button()
        Me.cmdWindowMinimize = New System.Windows.Forms.Button()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientLeft = New System.Windows.Forms.PictureBox()
        Me.cmdSStateListUtil = New System.Windows.Forms.Button()
        Me.cmdGameDbUtil = New System.Windows.Forms.Button()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.blWindowDescription = New System.Windows.Forms.Label()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.lblWindowVersion = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelWindowTitle.SuspendLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 70)
        Me.SplitContainer1.MinimumSize = New System.Drawing.Size(0, 200)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.imgFlag)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblGameListCheck)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtGameList_Compat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblGameList_Compat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGameSelectInvert)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGameSelectAll)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdGameSelectNone)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtGameList_Serial)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtGameList_Region)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtGameList_Title)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblGameList_Serial)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblGameList_Region)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblGameList_Title)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvwGamesList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSStateListCheck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSStateListSelection)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSizeBackup)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSStateListSelection)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSize)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSizeBackup)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSize)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSStateSelectInvert)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSStateDelete)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwSStatesList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSStateSelectBackup)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSStateSelectAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSStateSelectNone)
        Me.SplitContainer1.Size = New System.Drawing.Size(632, 383)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.sstatesman.My.Resources.Resources.Flag_0Null_30x20
        Me.PictureBox1.Location = New System.Drawing.Point(12, 146)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'imgFlag
        '
        Me.imgFlag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.imgFlag.BackColor = System.Drawing.Color.Transparent
        Me.imgFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgFlag.Image = Global.sstatesman.My.Resources.Resources.Flag_0Null_30x20
        Me.imgFlag.Location = New System.Drawing.Point(206, 176)
        Me.imgFlag.Name = "imgFlag"
        Me.imgFlag.Size = New System.Drawing.Size(30, 20)
        Me.imgFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgFlag.TabIndex = 23
        Me.imgFlag.TabStop = False
        Me.imgFlag.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.sstatesman.My.Resources.Resources.Metro_Expand
        Me.Button1.Location = New System.Drawing.Point(12, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(15, 15)
        Me.Button1.TabIndex = 29
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblGameListCheck
        '
        Me.lblGameListCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGameListCheck.AutoSize = True
        Me.lblGameListCheck.Location = New System.Drawing.Point(405, 8)
        Me.lblGameListCheck.Name = "lblGameListCheck"
        Me.lblGameListCheck.Size = New System.Drawing.Size(75, 13)
        Me.lblGameListCheck.TabIndex = 27
        Me.lblGameListCheck.Text = "check games:"
        Me.lblGameListCheck.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtGameList_Compat
        '
        Me.txtGameList_Compat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGameList_Compat.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Compat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Compat.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Compat.Location = New System.Drawing.Point(501, 175)
        Me.txtGameList_Compat.Name = "txtGameList_Compat"
        Me.txtGameList_Compat.ReadOnly = True
        Me.txtGameList_Compat.Size = New System.Drawing.Size(96, 22)
        Me.txtGameList_Compat.TabIndex = 8
        '
        'lblGameList_Compat
        '
        Me.lblGameList_Compat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGameList_Compat.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameList_Compat.Location = New System.Drawing.Point(423, 178)
        Me.lblGameList_Compat.Name = "lblGameList_Compat"
        Me.lblGameList_Compat.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Compat.TabIndex = 24
        Me.lblGameList_Compat.Text = "emu status"
        Me.lblGameList_Compat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdGameSelectInvert
        '
        Me.cmdGameSelectInvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameSelectInvert.BackColor = System.Drawing.Color.Transparent
        Me.cmdGameSelectInvert.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectInvert.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGameSelectInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectInvert.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGameSelectInvert.Location = New System.Drawing.Point(563, 5)
        Me.cmdGameSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectInvert.Name = "cmdGameSelectInvert"
        Me.cmdGameSelectInvert.Size = New System.Drawing.Size(45, 20)
        Me.cmdGameSelectInvert.TabIndex = 4
        Me.cmdGameSelectInvert.Text = "INVERT"
        Me.cmdGameSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(24, 5)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 20)
        Me.cmdRefresh.TabIndex = 0
        Me.cmdRefresh.Text = "&REFRESH LIST"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'cmdGameSelectAll
        '
        Me.cmdGameSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.cmdGameSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectAll.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGameSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectAll.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGameSelectAll.Location = New System.Drawing.Point(483, 5)
        Me.cmdGameSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectAll.Name = "cmdGameSelectAll"
        Me.cmdGameSelectAll.Size = New System.Drawing.Size(40, 20)
        Me.cmdGameSelectAll.TabIndex = 2
        Me.cmdGameSelectAll.Text = "ALL"
        Me.cmdGameSelectAll.UseVisualStyleBackColor = False
        '
        'cmdGameSelectNone
        '
        Me.cmdGameSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameSelectNone.BackColor = System.Drawing.Color.Transparent
        Me.cmdGameSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameSelectNone.FlatAppearance.BorderSize = 0
        Me.cmdGameSelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameSelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGameSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameSelectNone.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGameSelectNone.Location = New System.Drawing.Point(523, 5)
        Me.cmdGameSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameSelectNone.Name = "cmdGameSelectNone"
        Me.cmdGameSelectNone.Size = New System.Drawing.Size(40, 20)
        Me.cmdGameSelectNone.TabIndex = 3
        Me.cmdGameSelectNone.Text = "NONE"
        Me.cmdGameSelectNone.UseVisualStyleBackColor = False
        '
        'txtGameList_Serial
        '
        Me.txtGameList_Serial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGameList_Serial.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Serial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Serial.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Serial.Location = New System.Drawing.Point(321, 175)
        Me.txtGameList_Serial.Name = "txtGameList_Serial"
        Me.txtGameList_Serial.ReadOnly = True
        Me.txtGameList_Serial.Size = New System.Drawing.Size(96, 22)
        Me.txtGameList_Serial.TabIndex = 7
        '
        'txtGameList_Region
        '
        Me.txtGameList_Region.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGameList_Region.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Region.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Region.Location = New System.Drawing.Point(141, 175)
        Me.txtGameList_Region.Name = "txtGameList_Region"
        Me.txtGameList_Region.ReadOnly = True
        Me.txtGameList_Region.Size = New System.Drawing.Size(96, 22)
        Me.txtGameList_Region.TabIndex = 6
        '
        'txtGameList_Title
        '
        Me.txtGameList_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGameList_Title.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Title.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Title.Location = New System.Drawing.Point(141, 147)
        Me.txtGameList_Title.Name = "txtGameList_Title"
        Me.txtGameList_Title.ReadOnly = True
        Me.txtGameList_Title.Size = New System.Drawing.Size(479, 22)
        Me.txtGameList_Title.TabIndex = 5
        '
        'lblGameList_Serial
        '
        Me.lblGameList_Serial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGameList_Serial.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameList_Serial.Location = New System.Drawing.Point(243, 178)
        Me.lblGameList_Serial.Name = "lblGameList_Serial"
        Me.lblGameList_Serial.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Serial.TabIndex = 3
        Me.lblGameList_Serial.Text = "exe code"
        Me.lblGameList_Serial.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGameList_Region
        '
        Me.lblGameList_Region.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGameList_Region.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameList_Region.Location = New System.Drawing.Point(63, 178)
        Me.lblGameList_Region.Name = "lblGameList_Region"
        Me.lblGameList_Region.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Region.TabIndex = 2
        Me.lblGameList_Region.Text = "region"
        Me.lblGameList_Region.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGameList_Title
        '
        Me.lblGameList_Title.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGameList_Title.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameList_Title.Location = New System.Drawing.Point(63, 150)
        Me.lblGameList_Title.Name = "lblGameList_Title"
        Me.lblGameList_Title.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Title.TabIndex = 1
        Me.lblGameList_Title.Text = "game title"
        Me.lblGameList_Title.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lvwGamesList
        '
        Me.lvwGamesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwGamesList.BackColor = System.Drawing.Color.White
        Me.lvwGamesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwGamesList.CheckBoxes = True
        Me.lvwGamesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader9, Me.ArrayPosition})
        Me.lvwGamesList.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvwGamesList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwGamesList.ForeColor = System.Drawing.Color.DimGray
        Me.lvwGamesList.FullRowSelect = True
        Me.lvwGamesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwGamesList.HideSelection = False
        Me.lvwGamesList.Location = New System.Drawing.Point(12, 26)
        Me.lvwGamesList.MultiSelect = False
        Me.lvwGamesList.Name = "lvwGamesList"
        Me.lvwGamesList.Size = New System.Drawing.Size(608, 115)
        Me.lvwGamesList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwGamesList.TabIndex = 1
        Me.lvwGamesList.UseCompatibleStateImageBehavior = False
        Me.lvwGamesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Game title"
        Me.ColumnHeader1.Width = 240
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Executable code"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Region"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Total Size (bck)"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 160
        '
        'ArrayPosition
        '
        Me.ArrayPosition.Text = "#"
        Me.ArrayPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ArrayPosition.Width = 0
        '
        'lblSStateListCheck
        '
        Me.lblSStateListCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSStateListCheck.AutoSize = True
        Me.lblSStateListCheck.Location = New System.Drawing.Point(328, 5)
        Me.lblSStateListCheck.Name = "lblSStateListCheck"
        Me.lblSStateListCheck.Size = New System.Drawing.Size(94, 13)
        Me.lblSStateListCheck.TabIndex = 28
        Me.lblSStateListCheck.Text = "check savestates:"
        '
        'txtSStateListSelection
        '
        Me.txtSStateListSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSStateListSelection.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSStateListSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSStateListSelection.ForeColor = System.Drawing.Color.DimGray
        Me.txtSStateListSelection.Location = New System.Drawing.Point(90, 145)
        Me.txtSStateListSelection.Name = "txtSStateListSelection"
        Me.txtSStateListSelection.ReadOnly = True
        Me.txtSStateListSelection.Size = New System.Drawing.Size(96, 22)
        Me.txtSStateListSelection.TabIndex = 15
        Me.txtSStateListSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSizeBackup
        '
        Me.lblSizeBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSizeBackup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSizeBackup.Location = New System.Drawing.Point(414, 148)
        Me.lblSizeBackup.Name = "lblSizeBackup"
        Me.lblSizeBackup.Size = New System.Drawing.Size(72, 13)
        Me.lblSizeBackup.TabIndex = 23
        Me.lblSizeBackup.Text = "backups size"
        Me.lblSizeBackup.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSStateListSelection
        '
        Me.lblSStateListSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSStateListSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSStateListSelection.Location = New System.Drawing.Point(12, 148)
        Me.lblSStateListSelection.Name = "lblSStateListSelection"
        Me.lblSStateListSelection.Size = New System.Drawing.Size(72, 13)
        Me.lblSStateListSelection.TabIndex = 23
        Me.lblSStateListSelection.Text = "selection"
        Me.lblSStateListSelection.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(202, 148)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(72, 13)
        Me.lblSize.TabIndex = 22
        Me.lblSize.Text = "sstates size"
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSizeBackup
        '
        Me.txtSizeBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSizeBackup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSizeBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeBackup.ForeColor = System.Drawing.Color.DimGray
        Me.txtSizeBackup.Location = New System.Drawing.Point(492, 145)
        Me.txtSizeBackup.Name = "txtSizeBackup"
        Me.txtSizeBackup.ReadOnly = True
        Me.txtSizeBackup.Size = New System.Drawing.Size(128, 22)
        Me.txtSizeBackup.TabIndex = 17
        Me.txtSizeBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSize
        '
        Me.txtSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSize.ForeColor = System.Drawing.Color.DimGray
        Me.txtSize.Location = New System.Drawing.Point(280, 145)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(128, 22)
        Me.txtSize.TabIndex = 16
        Me.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.cmdSStateSelectInvert.Location = New System.Drawing.Point(563, 2)
        Me.cmdSStateSelectInvert.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectInvert.Name = "cmdSStateSelectInvert"
        Me.cmdSStateSelectInvert.Size = New System.Drawing.Size(45, 20)
        Me.cmdSStateSelectInvert.TabIndex = 13
        Me.cmdSStateSelectInvert.Text = "INVERT"
        Me.cmdSStateSelectInvert.UseVisualStyleBackColor = False
        '
        'cmdSStateDelete
        '
        Me.cmdSStateDelete.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateDelete.FlatAppearance.BorderSize = 0
        Me.cmdSStateDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateDelete.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateDelete.Location = New System.Drawing.Point(24, 2)
        Me.cmdSStateDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateDelete.Name = "cmdSStateDelete"
        Me.cmdSStateDelete.Size = New System.Drawing.Size(90, 20)
        Me.cmdSStateDelete.TabIndex = 14
        Me.cmdSStateDelete.Text = "&DELETE CHECKED"
        Me.cmdSStateDelete.UseVisualStyleBackColor = False
        '
        'lvwSStatesList
        '
        Me.lvwSStatesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwSStatesList.BackColor = System.Drawing.Color.White
        Me.lvwSStatesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwSStatesList.CheckBoxes = True
        Me.lvwSStatesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader7, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvwSStatesList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwSStatesList.ForeColor = System.Drawing.Color.DimGray
        Me.lvwSStatesList.FullRowSelect = True
        Me.lvwSStatesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSStatesList.Location = New System.Drawing.Point(12, 23)
        Me.lvwSStatesList.MultiSelect = False
        Me.lvwSStatesList.Name = "lvwSStatesList"
        Me.lvwSStatesList.Size = New System.Drawing.Size(608, 116)
        Me.lvwSStatesList.TabIndex = 9
        Me.lvwSStatesList.UseCompatibleStateImageBehavior = False
        Me.lvwSStatesList.View = System.Windows.Forms.View.Details
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
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Creation date"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Size"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Serial"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "#"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader11.Width = 0
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
        Me.cmdSStateSelectBackup.Location = New System.Drawing.Point(425, 2)
        Me.cmdSStateSelectBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectBackup.Name = "cmdSStateSelectBackup"
        Me.cmdSStateSelectBackup.Size = New System.Drawing.Size(55, 20)
        Me.cmdSStateSelectBackup.TabIndex = 10
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
        Me.cmdSStateSelectAll.Location = New System.Drawing.Point(480, 2)
        Me.cmdSStateSelectAll.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectAll.Name = "cmdSStateSelectAll"
        Me.cmdSStateSelectAll.Size = New System.Drawing.Size(40, 20)
        Me.cmdSStateSelectAll.TabIndex = 11
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
        Me.cmdSStateSelectNone.Location = New System.Drawing.Point(520, 2)
        Me.cmdSStateSelectNone.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateSelectNone.Name = "cmdSStateSelectNone"
        Me.cmdSStateSelectNone.Size = New System.Drawing.Size(40, 20)
        Me.cmdSStateSelectNone.TabIndex = 12
        Me.cmdSStateSelectNone.Text = "NONE"
        Me.cmdSStateSelectNone.UseVisualStyleBackColor = False
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.BackgroundImage = Global.sstatesman.My.Resources.Resources.Bg2
        Me.panelWindowTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelWindowTitle.Controls.Add(Me.Label1)
        Me.panelWindowTitle.Controls.Add(Me.cmdSettings)
        Me.panelWindowTitle.Controls.Add(Me.cmdAbout)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMinimize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMaximize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowClose)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.cmdSStateListUtil)
        Me.panelWindowTitle.Controls.Add(Me.cmdGameDbUtil)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowTitle)
        Me.panelWindowTitle.Controls.Add(Me.blWindowDescription)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientIcon)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowVersion)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(632, 70)
        Me.panelWindowTitle.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(427, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "dev utils:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSettings
        '
        Me.cmdSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSettings.BackColor = System.Drawing.Color.Transparent
        Me.cmdSettings.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSettings.FlatAppearance.BorderSize = 0
        Me.cmdSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSettings.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSettings.Location = New System.Drawing.Point(444, -1)
        Me.cmdSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(55, 20)
        Me.cmdSettings.TabIndex = 18
        Me.cmdSettings.Text = "&SETTINGS"
        Me.cmdSettings.UseVisualStyleBackColor = False
        '
        'cmdAbout
        '
        Me.cmdAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAbout.BackColor = System.Drawing.Color.Transparent
        Me.cmdAbout.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdAbout.FlatAppearance.BorderSize = 0
        Me.cmdAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAbout.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAbout.Location = New System.Drawing.Point(499, -1)
        Me.cmdAbout.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(45, 20)
        Me.cmdAbout.TabIndex = 19
        Me.cmdAbout.Text = "ABOUT"
        Me.cmdAbout.UseVisualStyleBackColor = False
        '
        'cmdWindowMinimize
        '
        Me.cmdWindowMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWindowMinimize.BackColor = System.Drawing.Color.Transparent
        Me.cmdWindowMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdWindowMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdWindowMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdWindowMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdWindowMinimize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWindowMinimize.Image = CType(resources.GetObject("cmdWindowMinimize.Image"), System.Drawing.Image)
        Me.cmdWindowMinimize.Location = New System.Drawing.Point(585, 4)
        Me.cmdWindowMinimize.Name = "cmdWindowMinimize"
        Me.cmdWindowMinimize.Size = New System.Drawing.Size(15, 15)
        Me.cmdWindowMinimize.TabIndex = 21
        Me.cmdWindowMinimize.UseVisualStyleBackColor = False
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
        Me.cmdWindowMaximize.TabIndex = 22
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
        Me.cmdWindowClose.TabIndex = 23
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
        'cmdSStateListUtil
        '
        Me.cmdSStateListUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateListUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateListUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateListUtil.FlatAppearance.BorderSize = 0
        Me.cmdSStateListUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateListUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateListUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateListUtil.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateListUtil.Location = New System.Drawing.Point(538, 47)
        Me.cmdSStateListUtil.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSStateListUtil.Name = "cmdSStateListUtil"
        Me.cmdSStateListUtil.Size = New System.Drawing.Size(70, 20)
        Me.cmdSStateListUtil.TabIndex = 25
        Me.cmdSStateListUtil.Text = "SSTATESLIST"
        Me.cmdSStateListUtil.UseVisualStyleBackColor = False
        '
        'cmdGameDbUtil
        '
        Me.cmdGameDbUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameDbUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdGameDbUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameDbUtil.FlatAppearance.BorderSize = 0
        Me.cmdGameDbUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameDbUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGameDbUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameDbUtil.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGameDbUtil.Location = New System.Drawing.Point(483, 47)
        Me.cmdGameDbUtil.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGameDbUtil.Name = "cmdGameDbUtil"
        Me.cmdGameDbUtil.Size = New System.Drawing.Size(55, 20)
        Me.cmdGameDbUtil.TabIndex = 24
        Me.cmdGameDbUtil.Text = "GAMEDB"
        Me.cmdGameDbUtil.UseVisualStyleBackColor = False
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(30, 24)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(122, 30)
        Me.lblWindowTitle.TabIndex = 4
        Me.lblWindowTitle.Text = "SStatesMan"
        '
        'blWindowDescription
        '
        Me.blWindowDescription.AutoSize = True
        Me.blWindowDescription.BackColor = System.Drawing.Color.Transparent
        Me.blWindowDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blWindowDescription.ForeColor = System.Drawing.Color.Gray
        Me.blWindowDescription.Location = New System.Drawing.Point(30, 50)
        Me.blWindowDescription.Name = "blWindowDescription"
        Me.blWindowDescription.Size = New System.Drawing.Size(194, 13)
        Me.blWindowDescription.TabIndex = 5
        Me.blWindowDescription.Text = "a savestate managing tool for PCSX2"
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgWindowGradientIcon.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(547, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'lblWindowVersion
        '
        Me.lblWindowVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWindowVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowVersion.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowVersion.Location = New System.Drawing.Point(426, 20)
        Me.lblWindowVersion.Name = "lblWindowVersion"
        Me.lblWindowVersion.Size = New System.Drawing.Size(115, 12)
        Me.lblWindowVersion.TabIndex = 8
        Me.lblWindowVersion.Text = "version "
        Me.lblWindowVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmMain"
        Me.Text = "SStatesMan"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblGameListCheck As System.Windows.Forms.Label
    Private WithEvents lblSStateListCheck As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cmdGameDbUtil As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Private WithEvents blWindowDescription As System.Windows.Forms.Label
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Private WithEvents lblWindowVersion As System.Windows.Forms.Label
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Private WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Private WithEvents cmdWindowClose As System.Windows.Forms.Button
    Private WithEvents cmdWindowMinimize As System.Windows.Forms.Button
    Private WithEvents cmdSStateListUtil As System.Windows.Forms.Button
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdAbout As System.Windows.Forms.Button
    Private WithEvents cmdSettings As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectAll As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectNone As System.Windows.Forms.Button
    Private WithEvents cmdSStateSelectBackup As System.Windows.Forms.Button
    Private WithEvents cmdRefresh As System.Windows.Forms.Button
    Private WithEvents ArrayPosition As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
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
    Private WithEvents lblSizeBackup As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents txtSizeBackup As System.Windows.Forms.TextBox
    Private WithEvents txtSize As System.Windows.Forms.TextBox
    Private WithEvents txtSStateListSelection As System.Windows.Forms.TextBox
    Private WithEvents lblSStateListSelection As System.Windows.Forms.Label
    Private WithEvents imgFlag As System.Windows.Forms.PictureBox
    Private WithEvents txtGameList_Compat As System.Windows.Forms.TextBox
    Private WithEvents lblGameList_Compat As System.Windows.Forms.Label
    Private WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvwGamesList As System.Windows.Forms.ListView
    Friend WithEvents lvwSStatesList As System.Windows.Forms.ListView
    Private WithEvents Button1 As System.Windows.Forms.Button
End Class
