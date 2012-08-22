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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGameDb))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsGameDbLoad = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsLoadDefaultGameDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsLoadFromFileTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsGameDbUnload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCmdSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsListShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsExport = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsExportTSVTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsExportCSVTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsTxtSearchSerial = New System.Windows.Forms.ToolStripTextBox()
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
        Me.imgFlag = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 298)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 11, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(624, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(14, 19)
        Me.ToolStripStatusLabel2.Text = " "
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(14, 19)
        Me.ToolStripStatusLabel1.Text = " "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(14, 19)
        Me.ToolStripStatusLabel3.Text = " "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsGameDbLoad, Me.tsGameDbUnload, Me.ToolStripSeparator1, Me.tsCmdSearch, Me.tsListShow, Me.ToolStripSeparator2, Me.tsExport, Me.tsTxtSearchSerial})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(624, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip"
        '
        'tsGameDbLoad
        '
        Me.tsGameDbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsGameDbLoad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLoadDefaultGameDB, Me.tsLoadFromFileTool})
        Me.tsGameDbLoad.Image = CType(resources.GetObject("tsGameDbLoad.Image"), System.Drawing.Image)
        Me.tsGameDbLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGameDbLoad.Name = "tsGameDbLoad"
        Me.tsGameDbLoad.Size = New System.Drawing.Size(87, 22)
        Me.tsGameDbLoad.Text = "LOAD &GAMEDB"
        Me.tsGameDbLoad.ToolTipText = "Load the PCSX2 Game Database."
        '
        'tsLoadDefaultGameDB
        '
        Me.tsLoadDefaultGameDB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tsLoadDefaultGameDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsLoadDefaultGameDB.ForeColor = System.Drawing.Color.DimGray
        Me.tsLoadDefaultGameDB.Name = "tsLoadDefaultGameDB"
        Me.tsLoadDefaultGameDB.Size = New System.Drawing.Size(199, 22)
        Me.tsLoadDefaultGameDB.Text = "Load default GameDB"
        '
        'tsLoadFromFileTool
        '
        Me.tsLoadFromFileTool.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tsLoadFromFileTool.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsLoadFromFileTool.ForeColor = System.Drawing.Color.DimGray
        Me.tsLoadFromFileTool.Name = "tsLoadFromFileTool"
        Me.tsLoadFromFileTool.Size = New System.Drawing.Size(199, 22)
        Me.tsLoadFromFileTool.Text = "Load GameDB from file..."
        '
        'tsGameDbUnload
        '
        Me.tsGameDbUnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsGameDbUnload.Enabled = False
        Me.tsGameDbUnload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGameDbUnload.Name = "tsGameDbUnload"
        Me.tsGameDbUnload.Size = New System.Drawing.Size(37, 22)
        Me.tsGameDbUnload.Text = "&CLOSE"
        Me.tsGameDbUnload.ToolTipText = "Unload the Game Database. For debugging purpose only"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.DimGray
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsCmdSearch
        '
        Me.tsCmdSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsCmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCmdSearch.Name = "tsCmdSearch"
        Me.tsCmdSearch.Size = New System.Drawing.Size(44, 22)
        Me.tsCmdSearch.Text = "&SEARCH"
        Me.tsCmdSearch.ToolTipText = "Perform a search inside the game database."
        '
        'tsListShow
        '
        Me.tsListShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsListShow.Enabled = False
        Me.tsListShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsListShow.Name = "tsListShow"
        Me.tsListShow.Size = New System.Drawing.Size(74, 22)
        Me.tsListShow.Text = "&CLEAR SEARCH"
        Me.tsListShow.ToolTipText = "Clear the search results listing the full game database."
        Me.tsListShow.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.DimGray
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
        Me.tsExport.Text = "&EXPORT"
        Me.tsExport.ToolTipText = "Export the game database to a text file. The search results will be saved if sear" & _
    "ch has been performed."
        '
        'tsExportTSVTxt
        '
        Me.tsExportTSVTxt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tsExportTSVTxt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsExportTSVTxt.ForeColor = System.Drawing.Color.DimGray
        Me.tsExportTSVTxt.Name = "tsExportTSVTxt"
        Me.tsExportTSVTxt.Size = New System.Drawing.Size(223, 22)
        Me.tsExportTSVTxt.Text = "Tab-separated value file..."
        '
        'tsExportCSVTxt
        '
        Me.tsExportCSVTxt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tsExportCSVTxt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsExportCSVTxt.ForeColor = System.Drawing.Color.DimGray
        Me.tsExportCSVTxt.Name = "tsExportCSVTxt"
        Me.tsExportCSVTxt.Size = New System.Drawing.Size(223, 22)
        Me.tsExportCSVTxt.Text = "Comma-separated value file..."
        '
        'tsTxtSearchSerial
        '
        Me.tsTxtSearchSerial.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTxtSearchSerial.BackColor = System.Drawing.Color.White
        Me.tsTxtSearchSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearchSerial.ForeColor = System.Drawing.Color.DimGray
        Me.tsTxtSearchSerial.Name = "tsTxtSearchSerial"
        Me.tsTxtSearchSerial.Size = New System.Drawing.Size(105, 25)
        Me.tsTxtSearchSerial.Text = "Serial"
        '
        'txtGameList_Compat
        '
        Me.txtGameList_Compat.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Compat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Compat.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Compat.Location = New System.Drawing.Point(400, 28)
        Me.txtGameList_Compat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Compat.Name = "txtGameList_Compat"
        Me.txtGameList_Compat.ReadOnly = True
        Me.txtGameList_Compat.Size = New System.Drawing.Size(80, 22)
        Me.txtGameList_Compat.TabIndex = 12
        '
        'lblGameList_Compat
        '
        Me.lblGameList_Compat.AutoSize = True
        Me.lblGameList_Compat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Compat.Location = New System.Drawing.Point(333, 26)
        Me.lblGameList_Compat.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameList_Compat.Name = "lblGameList_Compat"
        Me.lblGameList_Compat.Size = New System.Drawing.Size(63, 26)
        Me.lblGameList_Compat.TabIndex = 11
        Me.lblGameList_Compat.Text = "Emu status"
        Me.lblGameList_Compat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGameList_Serial
        '
        Me.txtGameList_Serial.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Serial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Serial.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Serial.Location = New System.Drawing.Point(249, 28)
        Me.txtGameList_Serial.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Serial.Name = "txtGameList_Serial"
        Me.txtGameList_Serial.ReadOnly = True
        Me.txtGameList_Serial.Size = New System.Drawing.Size(80, 22)
        Me.txtGameList_Serial.TabIndex = 10
        '
        'txtGameList_Region
        '
        Me.txtGameList_Region.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameList_Region.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Region.Location = New System.Drawing.Point(73, 28)
        Me.txtGameList_Region.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Region.Name = "txtGameList_Region"
        Me.txtGameList_Region.ReadOnly = True
        Me.txtGameList_Region.Size = New System.Drawing.Size(80, 22)
        Me.txtGameList_Region.TabIndex = 8
        '
        'txtGameList_Title
        '
        Me.txtGameList_Title.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGameList_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtGameList_Title, 6)
        Me.txtGameList_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameList_Title.ForeColor = System.Drawing.Color.Black
        Me.txtGameList_Title.Location = New System.Drawing.Point(73, 2)
        Me.txtGameList_Title.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGameList_Title.Name = "txtGameList_Title"
        Me.txtGameList_Title.ReadOnly = True
        Me.txtGameList_Title.Size = New System.Drawing.Size(545, 22)
        Me.txtGameList_Title.TabIndex = 6
        '
        'lblGameList_Serial
        '
        Me.lblGameList_Serial.AutoSize = True
        Me.lblGameList_Serial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Serial.Location = New System.Drawing.Point(193, 26)
        Me.lblGameList_Serial.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameList_Serial.Name = "lblGameList_Serial"
        Me.lblGameList_Serial.Size = New System.Drawing.Size(52, 26)
        Me.lblGameList_Serial.TabIndex = 9
        Me.lblGameList_Serial.Text = "Exe code"
        Me.lblGameList_Serial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGameList_Region
        '
        Me.lblGameList_Region.AutoSize = True
        Me.lblGameList_Region.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Region.Location = New System.Drawing.Point(10, 26)
        Me.lblGameList_Region.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameList_Region.Name = "lblGameList_Region"
        Me.lblGameList_Region.Size = New System.Drawing.Size(59, 26)
        Me.lblGameList_Region.TabIndex = 7
        Me.lblGameList_Region.Text = "Region"
        Me.lblGameList_Region.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGameList_Title
        '
        Me.lblGameList_Title.AutoSize = True
        Me.lblGameList_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGameList_Title.Location = New System.Drawing.Point(10, 0)
        Me.lblGameList_Title.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGameList_Title.Name = "lblGameList_Title"
        Me.lblGameList_Title.Size = New System.Drawing.Size(59, 26)
        Me.lblGameList_Title.TabIndex = 5
        Me.lblGameList_Title.Text = "Game title"
        Me.lblGameList_Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvwGameDBList
        '
        Me.lvwGameDBList.BackColor = System.Drawing.Color.White
        Me.lvwGameDBList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.GameInfoName, Me.GameInfoSerial, Me.GameInfoRegion, Me.GameInfoCompat})
        Me.lvwGameDBList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwGameDBList.ForeColor = System.Drawing.Color.Black
        Me.lvwGameDBList.FullRowSelect = True
        Me.lvwGameDBList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwGameDBList.Location = New System.Drawing.Point(0, 77)
        Me.lvwGameDBList.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwGameDBList.MultiSelect = False
        Me.lvwGameDBList.Name = "lvwGameDBList"
        Me.lvwGameDBList.Size = New System.Drawing.Size(624, 221)
        Me.lvwGameDBList.TabIndex = 0
        Me.lvwGameDBList.TileSize = New System.Drawing.Size(480, 64)
        Me.lvwGameDBList.UseCompatibleStateImageBehavior = False
        Me.lvwGameDBList.View = System.Windows.Forms.View.Details
        '
        'GameInfoName
        '
        Me.GameInfoName.Text = "Game title"
        Me.GameInfoName.Width = 300
        '
        'GameInfoSerial
        '
        Me.GameInfoSerial.Text = "Executable code"
        Me.GameInfoSerial.Width = 120
        '
        'GameInfoRegion
        '
        Me.GameInfoRegion.Text = "Region"
        Me.GameInfoRegion.Width = 80
        '
        'GameInfoCompat
        '
        Me.GameInfoCompat.Text = "Emu status"
        Me.GameInfoCompat.Width = 80
        '
        'imgFlag
        '
        Me.imgFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgFlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgFlag.Image = Global.sstatesman.My.Resources.Resources.Flag_0Null_30x20
        Me.imgFlag.Location = New System.Drawing.Point(157, 28)
        Me.imgFlag.Margin = New System.Windows.Forms.Padding(2)
        Me.imgFlag.Name = "imgFlag"
        Me.imgFlag.Size = New System.Drawing.Size(32, 22)
        Me.imgFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgFlag.TabIndex = 32
        Me.imgFlag.TabStop = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 25)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(624, 0)
        Me.FlowLayoutPanel2.TabIndex = 36
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(624, 0)
        Me.FlowLayoutPanel1.TabIndex = 37
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.txtGameList_Compat, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGameList_Compat, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGameList_Serial, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGameList_Serial, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.imgFlag, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGameList_Region, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGameList_Region, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGameList_Title, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGameList_Title, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 52)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'frmGameDb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(624, 322)
        Me.Controls.Add(Me.lvwGameDBList)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmGameDb"
        Me.Text = "GameDB Explorer"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.imgFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
    Private WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsListShow As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsExport As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsExportTSVTxt As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsGameDbUnload As System.Windows.Forms.ToolStripButton
    Private WithEvents tsTxtSearchSerial As System.Windows.Forms.ToolStripTextBox
    Private WithEvents tsExportCSVTxt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCmdSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtGameList_Compat As System.Windows.Forms.TextBox
    Friend WithEvents txtGameList_Serial As System.Windows.Forms.TextBox
    Friend WithEvents txtGameList_Region As System.Windows.Forms.TextBox
    Friend WithEvents txtGameList_Title As System.Windows.Forms.TextBox
    Friend WithEvents lvwGameDBList As System.Windows.Forms.ListView
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents tsGameDbLoad As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsLoadDefaultGameDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsLoadFromFileTool As System.Windows.Forms.ToolStripMenuItem
End Class
