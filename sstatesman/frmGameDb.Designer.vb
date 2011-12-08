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
Partial Class frmGameDb
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsGameDbLoad = New System.Windows.Forms.ToolStripSplitButton()
        Me.LoadV1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadV2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadV3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsGameDbUnload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsListShow = New System.Windows.Forms.ToolStripButton()
        Me.tsCmdSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsExport = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsExportTSVTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsExportCSVTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRecordLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRecordNext = New System.Windows.Forms.ToolStripButton()
        Me.tsRecordPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsRecordFirst = New System.Windows.Forms.ToolStripButton()
        Me.tsTxtSearchSerial = New System.Windows.Forms.ToolStripTextBox()
        Me.tsCmdSearchSerial = New System.Windows.Forms.ToolStripButton()
        Me.txtGameList_Compat = New System.Windows.Forms.TextBox()
        Me.lblGameList_Compat = New System.Windows.Forms.Label()
        Me.txtGameList_Serial = New System.Windows.Forms.TextBox()
        Me.txtGameList_Region = New System.Windows.Forms.TextBox()
        Me.txtGameList_Title = New System.Windows.Forms.TextBox()
        Me.lblGameList_Serial = New System.Windows.Forms.Label()
        Me.lblGameList_Region = New System.Windows.Forms.Label()
        Me.lblGameList_Title = New System.Windows.Forms.Label()
        Me.lvwGameDBList = New System.Windows.Forms.ListView()
        Me.GameInfoName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameInfoSerial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameInfoRegion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GameInfoCompat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ArrayRecordStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ArrayPosition = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgFlag = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 451)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(746, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(160, 17)
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsGameDbLoad, Me.tsGameDbUnload, Me.ToolStripSeparator1, Me.tsListShow, Me.tsCmdSearch, Me.ToolStripSeparator2, Me.tsExport, Me.ToolStripSeparator3, Me.tsRecordLast, Me.tsRecordNext, Me.tsRecordPrevious, Me.tsRecordFirst, Me.tsTxtSearchSerial, Me.tsCmdSearchSerial})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(746, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsGameDbLoad
        '
        Me.tsGameDbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsGameDbLoad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadV1ToolStripMenuItem, Me.LoadV2ToolStripMenuItem, Me.LoadV3ToolStripMenuItem})
        Me.tsGameDbLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGameDbLoad.Name = "tsGameDbLoad"
        Me.tsGameDbLoad.Size = New System.Drawing.Size(98, 22)
        Me.tsGameDbLoad.Text = "Load &GameDB"
        Me.tsGameDbLoad.ToolTipText = "Load the PCSX2 Game Database into an array."
        '
        'LoadV1ToolStripMenuItem
        '
        Me.LoadV1ToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LoadV1ToolStripMenuItem.Name = "LoadV1ToolStripMenuItem"
        Me.LoadV1ToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.LoadV1ToolStripMenuItem.Text = "Load v&1 (VB6 port)"
        '
        'LoadV2ToolStripMenuItem
        '
        Me.LoadV2ToolStripMenuItem.Name = "LoadV2ToolStripMenuItem"
        Me.LoadV2ToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.LoadV2ToolStripMenuItem.Text = "Load v&2 (VB2010 TextFieldParser)"
        '
        'LoadV3ToolStripMenuItem
        '
        Me.LoadV3ToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LoadV3ToolStripMenuItem.Name = "LoadV3ToolStripMenuItem"
        Me.LoadV3ToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.LoadV3ToolStripMenuItem.Text = "Load v&3 (VB2010 TextFileReader) "
        '
        'tsGameDbUnload
        '
        Me.tsGameDbUnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsGameDbUnload.Enabled = False
        Me.tsGameDbUnload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGameDbUnload.Name = "tsGameDbUnload"
        Me.tsGameDbUnload.Size = New System.Drawing.Size(49, 22)
        Me.tsGameDbUnload.Text = "&Unload"
        Me.tsGameDbUnload.ToolTipText = "Unload the GameDB array, freeing the memory."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsListShow
        '
        Me.tsListShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsListShow.Enabled = False
        Me.tsListShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsListShow.Name = "tsListShow"
        Me.tsListShow.Size = New System.Drawing.Size(78, 22)
        Me.tsListShow.Text = "&List GameDB"
        Me.tsListShow.ToolTipText = "Makes a list of the array."
        '
        'tsCmdSearch
        '
        Me.tsCmdSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsCmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCmdSearch.Name = "tsCmdSearch"
        Me.tsCmdSearch.Size = New System.Drawing.Size(46, 22)
        Me.tsCmdSearch.Text = "Search"
        Me.tsCmdSearch.ToolTipText = "Allows to search inside the array."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsExport
        '
        Me.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExportTSVTxt, Me.tsExportCSVTxt})
        Me.tsExport.Enabled = False
        Me.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExport.Name = "tsExport"
        Me.tsExport.Size = New System.Drawing.Size(53, 22)
        Me.tsExport.Text = "&Dump"
        Me.tsExport.ToolTipText = "Allows to dump the array contents."
        '
        'tsExportTSVTxt
        '
        Me.tsExportTSVTxt.Name = "tsExportTSVTxt"
        Me.tsExportTSVTxt.Size = New System.Drawing.Size(243, 22)
        Me.tsExportTSVTxt.Text = "Tab separated value text file"
        '
        'tsExportCSVTxt
        '
        Me.tsExportCSVTxt.Name = "tsExportCSVTxt"
        Me.tsExportCSVTxt.Size = New System.Drawing.Size(243, 22)
        Me.tsExportCSVTxt.Text = "Comma separated value text file"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsRecordLast
        '
        Me.tsRecordLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordLast.Enabled = False
        Me.tsRecordLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordLast.Name = "tsRecordLast"
        Me.tsRecordLast.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordLast.Text = "››"
        Me.tsRecordLast.ToolTipText = "Last record"
        '
        'tsRecordNext
        '
        Me.tsRecordNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordNext.Enabled = False
        Me.tsRecordNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordNext.Name = "tsRecordNext"
        Me.tsRecordNext.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordNext.Text = "›"
        Me.tsRecordNext.ToolTipText = "Next record"
        '
        'tsRecordPrevious
        '
        Me.tsRecordPrevious.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordPrevious.Enabled = False
        Me.tsRecordPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordPrevious.Name = "tsRecordPrevious"
        Me.tsRecordPrevious.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordPrevious.Text = "‹"
        Me.tsRecordPrevious.ToolTipText = "Prevoius record."
        '
        'tsRecordFirst
        '
        Me.tsRecordFirst.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordFirst.Enabled = False
        Me.tsRecordFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordFirst.Name = "tsRecordFirst"
        Me.tsRecordFirst.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordFirst.Text = "‹‹"
        Me.tsRecordFirst.ToolTipText = "First record."
        '
        'tsTxtSearchSerial
        '
        Me.tsTxtSearchSerial.Name = "tsTxtSearchSerial"
        Me.tsTxtSearchSerial.Size = New System.Drawing.Size(130, 25)
        Me.tsTxtSearchSerial.Text = "Serial"
        '
        'tsCmdSearchSerial
        '
        Me.tsCmdSearchSerial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsCmdSearchSerial.Enabled = False
        Me.tsCmdSearchSerial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCmdSearchSerial.Name = "tsCmdSearchSerial"
        Me.tsCmdSearchSerial.Size = New System.Drawing.Size(79, 22)
        Me.tsCmdSearchSerial.Text = "Quick search"
        '
        'txtGameList_Compat
        '
        Me.txtGameList_Compat.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Compat.Location = New System.Drawing.Point(450, 56)
        Me.txtGameList_Compat.Name = "txtGameList_Compat"
        Me.txtGameList_Compat.ReadOnly = True
        Me.txtGameList_Compat.Size = New System.Drawing.Size(96, 22)
        Me.txtGameList_Compat.TabIndex = 31
        '
        'lblGameList_Compat
        '
        Me.lblGameList_Compat.Location = New System.Drawing.Point(372, 59)
        Me.lblGameList_Compat.Name = "lblGameList_Compat"
        Me.lblGameList_Compat.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Compat.TabIndex = 33
        Me.lblGameList_Compat.Text = "Emu status"
        Me.lblGameList_Compat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtGameList_Serial
        '
        Me.txtGameList_Serial.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Serial.Location = New System.Drawing.Point(270, 56)
        Me.txtGameList_Serial.Name = "txtGameList_Serial"
        Me.txtGameList_Serial.ReadOnly = True
        Me.txtGameList_Serial.Size = New System.Drawing.Size(96, 22)
        Me.txtGameList_Serial.TabIndex = 30
        '
        'txtGameList_Region
        '
        Me.txtGameList_Region.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Region.Location = New System.Drawing.Point(90, 56)
        Me.txtGameList_Region.Name = "txtGameList_Region"
        Me.txtGameList_Region.ReadOnly = True
        Me.txtGameList_Region.Size = New System.Drawing.Size(96, 22)
        Me.txtGameList_Region.TabIndex = 29
        '
        'txtGameList_Title
        '
        Me.txtGameList_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGameList_Title.ForeColor = System.Drawing.Color.DimGray
        Me.txtGameList_Title.Location = New System.Drawing.Point(90, 28)
        Me.txtGameList_Title.Name = "txtGameList_Title"
        Me.txtGameList_Title.ReadOnly = True
        Me.txtGameList_Title.Size = New System.Drawing.Size(644, 22)
        Me.txtGameList_Title.TabIndex = 28
        '
        'lblGameList_Serial
        '
        Me.lblGameList_Serial.Location = New System.Drawing.Point(192, 59)
        Me.lblGameList_Serial.Name = "lblGameList_Serial"
        Me.lblGameList_Serial.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Serial.TabIndex = 27
        Me.lblGameList_Serial.Text = "Exe code"
        Me.lblGameList_Serial.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGameList_Region
        '
        Me.lblGameList_Region.Location = New System.Drawing.Point(12, 59)
        Me.lblGameList_Region.Name = "lblGameList_Region"
        Me.lblGameList_Region.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Region.TabIndex = 26
        Me.lblGameList_Region.Text = "Region"
        Me.lblGameList_Region.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGameList_Title
        '
        Me.lblGameList_Title.Location = New System.Drawing.Point(12, 31)
        Me.lblGameList_Title.Name = "lblGameList_Title"
        Me.lblGameList_Title.Size = New System.Drawing.Size(72, 13)
        Me.lblGameList_Title.TabIndex = 25
        Me.lblGameList_Title.Text = "Game title"
        Me.lblGameList_Title.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lvwGameDBList
        '
        Me.lvwGameDBList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwGameDBList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.GameInfoName, Me.GameInfoSerial, Me.GameInfoRegion, Me.GameInfoCompat, Me.ArrayRecordStatus, Me.ArrayPosition})
        Me.lvwGameDBList.FullRowSelect = True
        Me.lvwGameDBList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwGameDBList.Location = New System.Drawing.Point(12, 84)
        Me.lvwGameDBList.MultiSelect = False
        Me.lvwGameDBList.Name = "lvwGameDBList"
        Me.lvwGameDBList.Size = New System.Drawing.Size(722, 364)
        Me.lvwGameDBList.TabIndex = 34
        Me.lvwGameDBList.TileSize = New System.Drawing.Size(480, 64)
        Me.lvwGameDBList.UseCompatibleStateImageBehavior = False
        Me.lvwGameDBList.View = System.Windows.Forms.View.Details
        '
        'GameInfoName
        '
        Me.GameInfoName.DisplayIndex = 1
        Me.GameInfoName.Text = "Game title"
        Me.GameInfoName.Width = 300
        '
        'GameInfoSerial
        '
        Me.GameInfoSerial.DisplayIndex = 2
        Me.GameInfoSerial.Text = "Executable code"
        Me.GameInfoSerial.Width = 100
        '
        'GameInfoRegion
        '
        Me.GameInfoRegion.DisplayIndex = 3
        Me.GameInfoRegion.Text = "Region"
        '
        'GameInfoCompat
        '
        Me.GameInfoCompat.DisplayIndex = 4
        Me.GameInfoCompat.Text = "Emu status"
        Me.GameInfoCompat.Width = 100
        '
        'ArrayRecordStatus
        '
        Me.ArrayRecordStatus.DisplayIndex = 5
        Me.ArrayRecordStatus.Text = "Record status"
        Me.ArrayRecordStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ArrayPosition
        '
        Me.ArrayPosition.DisplayIndex = 0
        Me.ArrayPosition.Text = "#"
        Me.ArrayPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'imgFlag
        '
        Me.imgFlag.Image = Global.sstatesman.My.Resources.Resources.Flag_0Null_30x20
        Me.imgFlag.Location = New System.Drawing.Point(155, 57)
        Me.imgFlag.Name = "imgFlag"
        Me.imgFlag.Size = New System.Drawing.Size(30, 20)
        Me.imgFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgFlag.TabIndex = 32
        Me.imgFlag.TabStop = False
        Me.imgFlag.Visible = False
        '
        'frmGameDb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 473)
        Me.Controls.Add(Me.lvwGameDBList)
        Me.Controls.Add(Me.imgFlag)
        Me.Controls.Add(Me.txtGameList_Compat)
        Me.Controls.Add(Me.lblGameList_Compat)
        Me.Controls.Add(Me.txtGameList_Serial)
        Me.Controls.Add(Me.txtGameList_Region)
        Me.Controls.Add(Me.txtGameList_Title)
        Me.Controls.Add(Me.lblGameList_Serial)
        Me.Controls.Add(Me.lblGameList_Region)
        Me.Controls.Add(Me.lblGameList_Title)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmGameDb"
        Me.Text = "GameDB Util - For developer only"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents imgFlag As System.Windows.Forms.PictureBox
    Private WithEvents lblGameList_Compat As System.Windows.Forms.Label
    Private WithEvents lblGameList_Serial As System.Windows.Forms.Label
    Private WithEvents lblGameList_Region As System.Windows.Forms.Label
    Private WithEvents lblGameList_Title As System.Windows.Forms.Label
    Private WithEvents GameInfoName As System.Windows.Forms.ColumnHeader
    Private WithEvents GameInfoSerial As System.Windows.Forms.ColumnHeader
    Private WithEvents GameInfoRegion As System.Windows.Forms.ColumnHeader
    Private WithEvents GameInfoCompat As System.Windows.Forms.ColumnHeader
    Private WithEvents ArrayPosition As System.Windows.Forms.ColumnHeader
    Private WithEvents ArrayRecordStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsGameDbLoad As System.Windows.Forms.ToolStripSplitButton
    Private WithEvents LoadV1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents LoadV2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsListShow As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsExport As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsExportTSVTxt As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsGameDbUnload As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsRecordLast As System.Windows.Forms.ToolStripButton
    Private WithEvents tsRecordNext As System.Windows.Forms.ToolStripButton
    Private WithEvents tsRecordPrevious As System.Windows.Forms.ToolStripButton
    Private WithEvents tsRecordFirst As System.Windows.Forms.ToolStripButton
    Private WithEvents tsTxtSearchSerial As System.Windows.Forms.ToolStripTextBox
    Private WithEvents tsCmdSearchSerial As System.Windows.Forms.ToolStripButton
    Private WithEvents LoadV3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsExportCSVTxt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCmdSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtGameList_Compat As System.Windows.Forms.TextBox
    Friend WithEvents txtGameList_Serial As System.Windows.Forms.TextBox
    Friend WithEvents txtGameList_Region As System.Windows.Forms.TextBox
    Friend WithEvents txtGameList_Title As System.Windows.Forms.TextBox
    Friend WithEvents lvwGameDBList As System.Windows.Forms.ListView
End Class
