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
        Me.cmdGameDbUtil = New System.Windows.Forms.Button()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.blWindowDescription = New System.Windows.Forms.Label()
        Me.lblWindowVersion = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.cmdSettings = New System.Windows.Forms.Button()
        Me.cmdAbout = New System.Windows.Forms.Button()
        Me.cmdWindowMinimize = New System.Windows.Forms.Button()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientLeft = New System.Windows.Forms.PictureBox()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.cmdSStateListUtil = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvwGameList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvwSStatesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panelWindowTitle.SuspendLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdGameDbUtil
        '
        Me.cmdGameDbUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGameDbUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdGameDbUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdGameDbUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdGameDbUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGameDbUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGameDbUtil.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGameDbUtil.Location = New System.Drawing.Point(422, 76)
        Me.cmdGameDbUtil.Name = "cmdGameDbUtil"
        Me.cmdGameDbUtil.Size = New System.Drawing.Size(100, 23)
        Me.cmdGameDbUtil.TabIndex = 0
        Me.cmdGameDbUtil.Text = "GAMEDB UTIL"
        Me.cmdGameDbUtil.UseVisualStyleBackColor = False
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(28, 20)
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
        'lblWindowVersion
        '
        Me.lblWindowVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWindowVersion.AutoSize = True
        Me.lblWindowVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowVersion.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowVersion.Location = New System.Drawing.Point(471, 20)
        Me.lblWindowVersion.Name = "lblWindowVersion"
        Me.lblWindowVersion.Size = New System.Drawing.Size(78, 12)
        Me.lblWindowVersion.TabIndex = 8
        Me.lblWindowVersion.Text = "version 0.1.2 alpha"
        Me.lblWindowVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.BackgroundImage = Global.sstatesman.My.Resources.Resources.Bg2
        Me.panelWindowTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelWindowTitle.Controls.Add(Me.cmdSettings)
        Me.panelWindowTitle.Controls.Add(Me.cmdAbout)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMinimize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMaximize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowClose)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowTitle)
        Me.panelWindowTitle.Controls.Add(Me.blWindowDescription)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientIcon)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowVersion)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(640, 70)
        Me.panelWindowTitle.TabIndex = 12
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
        Me.cmdSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSettings.Location = New System.Drawing.Point(424, 0)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(65, 20)
        Me.cmdSettings.TabIndex = 16
        Me.cmdSettings.Text = "SETTINGS"
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
        Me.cmdAbout.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAbout.Location = New System.Drawing.Point(491, 0)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(58, 20)
        Me.cmdAbout.TabIndex = 15
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
        Me.cmdWindowMinimize.Location = New System.Drawing.Point(593, 4)
        Me.cmdWindowMinimize.Name = "cmdWindowMinimize"
        Me.cmdWindowMinimize.Size = New System.Drawing.Size(15, 15)
        Me.cmdWindowMinimize.TabIndex = 15
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
        Me.cmdWindowMaximize.Location = New System.Drawing.Point(607, 4)
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
        Me.cmdWindowClose.Location = New System.Drawing.Point(621, 4)
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
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgWindowGradientIcon.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientIcon.Image = Global.sstatesman.My.Resources.Resources.Ico32tmp
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(555, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'cmdSStateListUtil
        '
        Me.cmdSStateListUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateListUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdSStateListUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSStateListUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateListUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateListUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateListUtil.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateListUtil.Location = New System.Drawing.Point(528, 76)
        Me.cmdSStateListUtil.Name = "cmdSStateListUtil"
        Me.cmdSStateListUtil.Size = New System.Drawing.Size(100, 23)
        Me.cmdSStateListUtil.TabIndex = 13
        Me.cmdSStateListUtil.Text = "SSTATELIST UTIL"
        Me.cmdSStateListUtil.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 105)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvwGameList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwSStatesList)
        Me.SplitContainer1.Size = New System.Drawing.Size(616, 283)
        Me.SplitContainer1.SplitterDistance = 120
        Me.SplitContainer1.TabIndex = 14
        '
        'lvwGameList
        '
        Me.lvwGameList.BackColor = System.Drawing.Color.White
        Me.lvwGameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwGameList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader9})
        Me.lvwGameList.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvwGameList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwGameList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwGameList.ForeColor = System.Drawing.Color.DimGray
        Me.lvwGameList.GridLines = True
        Me.lvwGameList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwGameList.Location = New System.Drawing.Point(0, 0)
        Me.lvwGameList.MultiSelect = False
        Me.lvwGameList.Name = "lvwGameList"
        Me.lvwGameList.Size = New System.Drawing.Size(616, 120)
        Me.lvwGameList.TabIndex = 0
        Me.lvwGameList.UseCompatibleStateImageBehavior = False
        Me.lvwGameList.View = System.Windows.Forms.View.Details
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
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Total Size (bck)"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 160
        '
        'lvwSStatesList
        '
        Me.lvwSStatesList.BackColor = System.Drawing.Color.White
        Me.lvwSStatesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwSStatesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvwSStatesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSStatesList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwSStatesList.ForeColor = System.Drawing.Color.DimGray
        Me.lvwSStatesList.GridLines = True
        Me.lvwSStatesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSStatesList.Location = New System.Drawing.Point(0, 0)
        Me.lvwSStatesList.MultiSelect = False
        Me.lvwSStatesList.Name = "lvwSStatesList"
        Me.lvwSStatesList.Size = New System.Drawing.Size(616, 159)
        Me.lvwSStatesList.TabIndex = 1
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
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Size"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Creation date"
        Me.ColumnHeader8.Width = 120
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "LOAD"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.sstatesman.My.Resources.Resources.BgBW
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(640, 400)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cmdSStateListUtil)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Controls.Add(Me.cmdGameDbUtil)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.Text = "SStatesMan"
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdGameDbUtil As System.Windows.Forms.Button
    Friend WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Friend WithEvents lblWindowTitle As System.Windows.Forms.Label
    Friend WithEvents blWindowDescription As System.Windows.Forms.Label
    Friend WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblWindowVersion As System.Windows.Forms.Label
    Friend WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents cmdWindowMaximize As System.Windows.Forms.Button
    Friend WithEvents cmdWindowClose As System.Windows.Forms.Button
    Friend WithEvents cmdWindowMinimize As System.Windows.Forms.Button
    Friend WithEvents cmdSStateListUtil As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lvwGameList As System.Windows.Forms.ListView
    Friend WithEvents lvwSStatesList As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdAbout As System.Windows.Forms.Button
    Friend WithEvents cmdSettings As System.Windows.Forms.Button
End Class
