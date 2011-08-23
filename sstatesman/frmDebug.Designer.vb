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
Partial Class frmDebug
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDebug))
        Me.cmdGameDbUtil = New System.Windows.Forms.Button()
        Me.cmdFileListUtil = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.cmdWindowMinimize = New System.Windows.Forms.Button()
        Me.cmdWindowMaximize = New System.Windows.Forms.Button()
        Me.cmdWindowClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientLeft = New System.Windows.Forms.PictureBox()
        Me.imgWindowGradientTop = New System.Windows.Forms.PictureBox()
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
        CType(Me.imgWindowGradientTop, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdGameDbUtil.Location = New System.Drawing.Point(310, 76)
        Me.cmdGameDbUtil.Name = "cmdGameDbUtil"
        Me.cmdGameDbUtil.Size = New System.Drawing.Size(100, 23)
        Me.cmdGameDbUtil.TabIndex = 0
        Me.cmdGameDbUtil.Text = "GAMEDB UTIL"
        Me.cmdGameDbUtil.UseVisualStyleBackColor = False
        '
        'cmdFileListUtil
        '
        Me.cmdFileListUtil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFileListUtil.BackColor = System.Drawing.Color.Transparent
        Me.cmdFileListUtil.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdFileListUtil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdFileListUtil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdFileListUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFileListUtil.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFileListUtil.Location = New System.Drawing.Point(416, 76)
        Me.cmdFileListUtil.Name = "cmdFileListUtil"
        Me.cmdFileListUtil.Size = New System.Drawing.Size(100, 23)
        Me.cmdFileListUtil.TabIndex = 1
        Me.cmdFileListUtil.Text = "FILELIST UTIL"
        Me.cmdFileListUtil.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 30)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SStatesMan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "a savestate managing tool for PCSX2"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(429, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "CONFIGURATION  |  HELP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(465, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "version 0.1.3 alpha"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMinimize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowMaximize)
        Me.panelWindowTitle.Controls.Add(Me.cmdWindowClose)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.Label1)
        Me.panelWindowTitle.Controls.Add(Me.Label2)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientTop)
        Me.panelWindowTitle.Controls.Add(Me.Label4)
        Me.panelWindowTitle.Controls.Add(Me.Label3)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(634, 70)
        Me.panelWindowTitle.TabIndex = 12
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
        Me.cmdWindowMinimize.Location = New System.Drawing.Point(587, 4)
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
        Me.cmdWindowMaximize.Location = New System.Drawing.Point(601, 4)
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
        Me.cmdWindowClose.Location = New System.Drawing.Point(615, 4)
        Me.cmdWindowClose.Name = "cmdWindowClose"
        Me.cmdWindowClose.Size = New System.Drawing.Size(15, 15)
        Me.cmdWindowClose.TabIndex = 13
        Me.cmdWindowClose.UseVisualStyleBackColor = False
        '
        'imgWindowGradientLeft
        '
        Me.imgWindowGradientLeft.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientLeft.Location = New System.Drawing.Point(0, 12)
        Me.imgWindowGradientLeft.Name = "imgWindowGradientLeft"
        Me.imgWindowGradientLeft.Size = New System.Drawing.Size(24, 48)
        Me.imgWindowGradientLeft.TabIndex = 3
        Me.imgWindowGradientLeft.TabStop = False
        '
        'imgWindowGradientTop
        '
        Me.imgWindowGradientTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgWindowGradientTop.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientTop.Image = Global.sstatesman.My.Resources.Resources.Ico32tmp
        Me.imgWindowGradientTop.Location = New System.Drawing.Point(549, 0)
        Me.imgWindowGradientTop.Name = "imgWindowGradientTop"
        Me.imgWindowGradientTop.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientTop.TabIndex = 6
        Me.imgWindowGradientTop.TabStop = False
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
        Me.cmdSStateListUtil.Location = New System.Drawing.Point(522, 76)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(610, 215)
        Me.SplitContainer1.SplitterDistance = 115
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
        Me.lvwGameList.Size = New System.Drawing.Size(610, 115)
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
        Me.lvwSStatesList.Size = New System.Drawing.Size(610, 96)
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
        'frmDebug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(634, 332)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cmdSStateListUtil)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Controls.Add(Me.cmdFileListUtil)
        Me.Controls.Add(Me.cmdGameDbUtil)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Name = "frmDebug"
        Me.Text = "frmDebug"
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWindowGradientTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdGameDbUtil As System.Windows.Forms.Button
    Friend WithEvents cmdFileListUtil As System.Windows.Forms.Button
    Friend WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgWindowGradientTop As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
End Class
