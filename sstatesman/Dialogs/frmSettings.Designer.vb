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
Partial Class frmSettings
    Inherits frmDialogTemplate

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
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblPCSX2SStatePath = New System.Windows.Forms.Label()
        Me.lblPCSX2IniPath = New System.Windows.Forms.Label()
        Me.lblPCSX2AppPath = New System.Windows.Forms.Label()
        Me.optTabHeader1 = New System.Windows.Forms.RadioButton()
        Me.optTabHeader0 = New System.Windows.Forms.RadioButton()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.flpTab = New System.Windows.Forms.FlowLayoutPanel()
        Me.optTabHeader2 = New System.Windows.Forms.RadioButton()
        Me.optTabHeader3 = New System.Windows.Forms.RadioButton()
        Me.pnlTab0 = New System.Windows.Forms.Panel()
        Me.fppSStatesManStoredPath = New sstatesman.ucFolderPickerPanel()
        Me.lblSStatesManStoredPath = New System.Windows.Forms.Label()
        Me.fppSStatesManPicsPath = New sstatesman.ucFolderPickerPanel()
        Me.lblSStatesManPicsPath = New System.Windows.Forms.Label()
        Me.ckbSStatesManMoveToTrash = New System.Windows.Forms.CheckBox()
        Me.ckbSStatesManVersionExtract = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckb_SStatesListAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.ckb_SStatesListShowOnly = New System.Windows.Forms.CheckBox()
        Me.ckbFirstRun = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTab1 = New System.Windows.Forms.Panel()
        Me.fppPCSX2SnapsPath = New sstatesman.ucFolderPickerPanel()
        Me.lblPCSX2SnapsPath = New System.Windows.Forms.Label()
        Me.fppPCSX2SStatePath = New sstatesman.ucFolderPickerPanel()
        Me.fppPCSX2IniPath = New sstatesman.ucFolderPickerPanel()
        Me.fppPCSX2AppPath = New sstatesman.ucFolderPickerPanel()
        Me.pnlTab2 = New System.Windows.Forms.Panel()
        Me.ckbSStatesManThemeGradient = New System.Windows.Forms.CheckBox()
        Me.ckbSStatesManThemeImage = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlThemeOptions = New System.Windows.Forms.Panel()
        Me.optTheme11 = New System.Windows.Forms.RadioButton()
        Me.optTheme6 = New System.Windows.Forms.RadioButton()
        Me.optTheme5 = New System.Windows.Forms.RadioButton()
        Me.optTheme4 = New System.Windows.Forms.RadioButton()
        Me.optTheme3 = New System.Windows.Forms.RadioButton()
        Me.optTheme2 = New System.Windows.Forms.RadioButton()
        Me.optTheme1 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlTab3 = New System.Windows.Forms.Panel()
        Me.lvwLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowPanelSStatesList = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdLogFilter = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdLogRefresh = New System.Windows.Forms.Button()
        Me.cmdLogExport = New System.Windows.Forms.Button()
        Me.cmLogFilter = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmiAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.flpTab.SuspendLayout()
        Me.pnlTab0.SuspendLayout()
        Me.pnlTab1.SuspendLayout()
        Me.pnlTab2.SuspendLayout()
        Me.pnlThemeOptions.SuspendLayout()
        Me.pnlTab3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowPanelSStatesList.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.cmLogFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlWindowTop.Size = New System.Drawing.Size(574, 46)
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.AutoSize = True
        Me.cmdOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdOk.BackColor = System.Drawing.Color.White
        Me.cmdOk.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(255, 397)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOk.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 24)
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = False
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
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(359, 397)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblPCSX2SStatePath
        '
        Me.lblPCSX2SStatePath.AutoSize = True
        Me.lblPCSX2SStatePath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPCSX2SStatePath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPCSX2SStatePath.Location = New System.Drawing.Point(8, 166)
        Me.lblPCSX2SStatePath.Name = "lblPCSX2SStatePath"
        Me.lblPCSX2SStatePath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblPCSX2SStatePath.Size = New System.Drawing.Size(112, 23)
        Me.lblPCSX2SStatePath.TabIndex = 40
        Me.lblPCSX2SStatePath.Text = "Savestates folder"
        '
        'lblPCSX2IniPath
        '
        Me.lblPCSX2IniPath.AutoSize = True
        Me.lblPCSX2IniPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPCSX2IniPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPCSX2IniPath.Location = New System.Drawing.Point(8, 85)
        Me.lblPCSX2IniPath.Name = "lblPCSX2IniPath"
        Me.lblPCSX2IniPath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblPCSX2IniPath.Size = New System.Drawing.Size(90, 23)
        Me.lblPCSX2IniPath.TabIndex = 33
        Me.lblPCSX2IniPath.Text = "Ini files folder"
        '
        'lblPCSX2AppPath
        '
        Me.lblPCSX2AppPath.AutoSize = True
        Me.lblPCSX2AppPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPCSX2AppPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPCSX2AppPath.Location = New System.Drawing.Point(8, 4)
        Me.lblPCSX2AppPath.Name = "lblPCSX2AppPath"
        Me.lblPCSX2AppPath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblPCSX2AppPath.Size = New System.Drawing.Size(101, 23)
        Me.lblPCSX2AppPath.TabIndex = 25
        Me.lblPCSX2AppPath.Text = "Program folder"
        '
        'optTabHeader1
        '
        Me.optTabHeader1.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader1.AutoSize = True
        Me.optTabHeader1.BackColor = System.Drawing.Color.Transparent
        Me.optTabHeader1.FlatAppearance.BorderSize = 0
        Me.optTabHeader1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader1.Location = New System.Drawing.Point(96, 0)
        Me.optTabHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader1.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader1.Name = "optTabHeader1"
        Me.optTabHeader1.Size = New System.Drawing.Size(87, 23)
        Me.optTabHeader1.TabIndex = 7
        Me.optTabHeader1.Text = "PCSX2 folders"
        Me.optTabHeader1.UseVisualStyleBackColor = False
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
        Me.optTabHeader0.Location = New System.Drawing.Point(16, 0)
        Me.optTabHeader0.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader0.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader0.Name = "optTabHeader0"
        Me.optTabHeader0.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader0.TabIndex = 6
        Me.optTabHeader0.TabStop = True
        Me.optTabHeader0.Text = "SStatesMan"
        Me.optTabHeader0.UseVisualStyleBackColor = False
        '
        'cmdApply
        '
        Me.cmdApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApply.AutoSize = True
        Me.cmdApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdApply.BackColor = System.Drawing.Color.White
        Me.cmdApply.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdApply.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApply.Location = New System.Drawing.Point(463, 397)
        Me.cmdApply.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdApply.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(100, 24)
        Me.cmdApply.TabIndex = 3
        Me.cmdApply.Text = "&APPLY"
        Me.cmdApply.UseVisualStyleBackColor = False
        '
        'flpTab
        '
        Me.flpTab.AutoSize = True
        Me.flpTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTab.BackColor = System.Drawing.Color.Transparent
        Me.flpTab.Controls.Add(Me.optTabHeader0)
        Me.flpTab.Controls.Add(Me.optTabHeader1)
        Me.flpTab.Controls.Add(Me.optTabHeader2)
        Me.flpTab.Controls.Add(Me.optTabHeader3)
        Me.flpTab.Location = New System.Drawing.Point(4, 49)
        Me.flpTab.Margin = New System.Windows.Forms.Padding(0)
        Me.flpTab.Name = "flpTab"
        Me.flpTab.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.flpTab.Size = New System.Drawing.Size(359, 23)
        Me.flpTab.TabIndex = 5
        Me.flpTab.WrapContents = False
        '
        'optTabHeader2
        '
        Me.optTabHeader2.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader2.AutoSize = True
        Me.optTabHeader2.BackColor = System.Drawing.Color.Transparent
        Me.optTabHeader2.FlatAppearance.BorderSize = 0
        Me.optTabHeader2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader2.Location = New System.Drawing.Point(183, 0)
        Me.optTabHeader2.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader2.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader2.Name = "optTabHeader2"
        Me.optTabHeader2.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader2.TabIndex = 8
        Me.optTabHeader2.Text = "Theme"
        Me.optTabHeader2.UseVisualStyleBackColor = False
        '
        'optTabHeader3
        '
        Me.optTabHeader3.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader3.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader3.AutoSize = True
        Me.optTabHeader3.BackColor = System.Drawing.Color.Transparent
        Me.optTabHeader3.FlatAppearance.BorderSize = 0
        Me.optTabHeader3.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader3.Location = New System.Drawing.Point(263, 0)
        Me.optTabHeader3.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader3.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader3.Name = "optTabHeader3"
        Me.optTabHeader3.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader3.TabIndex = 9
        Me.optTabHeader3.Text = "Log"
        Me.optTabHeader3.UseVisualStyleBackColor = False
        '
        'pnlTab0
        '
        Me.pnlTab0.AutoScroll = True
        Me.pnlTab0.Controls.Add(Me.fppSStatesManStoredPath)
        Me.pnlTab0.Controls.Add(Me.lblSStatesManStoredPath)
        Me.pnlTab0.Controls.Add(Me.fppSStatesManPicsPath)
        Me.pnlTab0.Controls.Add(Me.lblSStatesManPicsPath)
        Me.pnlTab0.Controls.Add(Me.ckbSStatesManMoveToTrash)
        Me.pnlTab0.Controls.Add(Me.ckbSStatesManVersionExtract)
        Me.pnlTab0.Controls.Add(Me.Label1)
        Me.pnlTab0.Controls.Add(Me.ckb_SStatesListAutoRefresh)
        Me.pnlTab0.Controls.Add(Me.ckb_SStatesListShowOnly)
        Me.pnlTab0.Controls.Add(Me.ckbFirstRun)
        Me.pnlTab0.Controls.Add(Me.Label3)
        Me.pnlTab0.Location = New System.Drawing.Point(4, 75)
        Me.pnlTab0.Name = "pnlTab0"
        Me.pnlTab0.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlTab0.Size = New System.Drawing.Size(170, 317)
        Me.pnlTab0.TabIndex = 9
        '
        'fppSStatesManStoredPath
        '
        Me.fppSStatesManStoredPath.AutoSize = True
        Me.fppSStatesManStoredPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fppSStatesManStoredPath.DescriptionError = "ErrorText"
        Me.fppSStatesManStoredPath.DescriptionInfo = "InfoText"
        Me.fppSStatesManStoredPath.DescriptionWarning = "WarningText"
        Me.fppSStatesManStoredPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.fppSStatesManStoredPath.FBDDefaultPath = System.Environment.SpecialFolder.MyDocuments
        Me.fppSStatesManStoredPath.FBDDescription = "BrowserTip"
        Me.fppSStatesManStoredPath.FBDShowNewFolderButton = True
        Me.fppSStatesManStoredPath.Location = New System.Drawing.Point(8, 259)
        Me.fppSStatesManStoredPath.Name = "fppSStatesManStoredPath"
        Me.fppSStatesManStoredPath.ShowDetectButton = False
        Me.fppSStatesManStoredPath.Size = New System.Drawing.Size(154, 58)
        Me.fppSStatesManStoredPath.State = sstatesman.ucFolderPickerPanel.eDescState.StateIdle
        Me.fppSStatesManStoredPath.TabIndex = 61
        '
        'lblSStatesManStoredPath
        '
        Me.lblSStatesManStoredPath.AutoSize = True
        Me.lblSStatesManStoredPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSStatesManStoredPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSStatesManStoredPath.Location = New System.Drawing.Point(8, 236)
        Me.lblSStatesManStoredPath.Name = "lblSStatesManStoredPath"
        Me.lblSStatesManStoredPath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblSStatesManStoredPath.Size = New System.Drawing.Size(155, 23)
        Me.lblSStatesManStoredPath.TabIndex = 60
        Me.lblSStatesManStoredPath.Text = "Stored savestates folder"
        '
        'fppSStatesManPicsPath
        '
        Me.fppSStatesManPicsPath.AutoSize = True
        Me.fppSStatesManPicsPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fppSStatesManPicsPath.DescriptionError = "ErrorText"
        Me.fppSStatesManPicsPath.DescriptionInfo = "InfoText"
        Me.fppSStatesManPicsPath.DescriptionWarning = "WarningText"
        Me.fppSStatesManPicsPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.fppSStatesManPicsPath.FBDDefaultPath = System.Environment.SpecialFolder.MyPictures
        Me.fppSStatesManPicsPath.FBDDescription = "BrowserTip"
        Me.fppSStatesManPicsPath.FBDShowNewFolderButton = True
        Me.fppSStatesManPicsPath.Location = New System.Drawing.Point(8, 178)
        Me.fppSStatesManPicsPath.Name = "fppSStatesManPicsPath"
        Me.fppSStatesManPicsPath.ShowDetectButton = False
        Me.fppSStatesManPicsPath.Size = New System.Drawing.Size(154, 58)
        Me.fppSStatesManPicsPath.State = sstatesman.ucFolderPickerPanel.eDescState.StateIdle
        Me.fppSStatesManPicsPath.TabIndex = 59
        '
        'lblSStatesManPicsPath
        '
        Me.lblSStatesManPicsPath.AutoSize = True
        Me.lblSStatesManPicsPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSStatesManPicsPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSStatesManPicsPath.Location = New System.Drawing.Point(8, 155)
        Me.lblSStatesManPicsPath.Name = "lblSStatesManPicsPath"
        Me.lblSStatesManPicsPath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblSStatesManPicsPath.Size = New System.Drawing.Size(189, 23)
        Me.lblSStatesManPicsPath.TabIndex = 17
        Me.lblSStatesManPicsPath.Text = "Game cover image files folder"
        '
        'ckbSStatesManMoveToTrash
        '
        Me.ckbSStatesManMoveToTrash.AutoSize = True
        Me.ckbSStatesManMoveToTrash.Checked = True
        Me.ckbSStatesManMoveToTrash.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbSStatesManMoveToTrash.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckbSStatesManMoveToTrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManMoveToTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManMoveToTrash.Location = New System.Drawing.Point(8, 134)
        Me.ckbSStatesManMoveToTrash.Name = "ckbSStatesManMoveToTrash"
        Me.ckbSStatesManMoveToTrash.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckbSStatesManMoveToTrash.Size = New System.Drawing.Size(154, 21)
        Me.ckbSStatesManMoveToTrash.TabIndex = 16
        Me.ckbSStatesManMoveToTrash.Text = "Send files to the Windows Recycle Bin instead of permanently deleting them."
        Me.ckbSStatesManMoveToTrash.UseVisualStyleBackColor = False
        '
        'ckbSStatesManVersionExtract
        '
        Me.ckbSStatesManVersionExtract.AutoSize = True
        Me.ckbSStatesManVersionExtract.Checked = True
        Me.ckbSStatesManVersionExtract.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbSStatesManVersionExtract.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckbSStatesManVersionExtract.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManVersionExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManVersionExtract.Location = New System.Drawing.Point(8, 113)
        Me.ckbSStatesManVersionExtract.Name = "ckbSStatesManVersionExtract"
        Me.ckbSStatesManVersionExtract.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckbSStatesManVersionExtract.Size = New System.Drawing.Size(154, 21)
        Me.ckbSStatesManVersionExtract.TabIndex = 15
        Me.ckbSStatesManVersionExtract.Text = "Extract savestates version. (experimental)"
        Me.ckbSStatesManVersionExtract.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Label1.Size = New System.Drawing.Size(120, 23)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Files management"
        '
        'ckb_SStatesListAutoRefresh
        '
        Me.ckb_SStatesListAutoRefresh.AutoSize = True
        Me.ckb_SStatesListAutoRefresh.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckb_SStatesListAutoRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckb_SStatesListAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckb_SStatesListAutoRefresh.Location = New System.Drawing.Point(8, 69)
        Me.ckb_SStatesListAutoRefresh.Name = "ckb_SStatesListAutoRefresh"
        Me.ckb_SStatesListAutoRefresh.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckb_SStatesListAutoRefresh.Size = New System.Drawing.Size(154, 21)
        Me.ckb_SStatesListAutoRefresh.TabIndex = 13
        Me.ckb_SStatesListAutoRefresh.Text = "Automatically refresh the savestates list."
        Me.ckb_SStatesListAutoRefresh.UseVisualStyleBackColor = False
        '
        'ckb_SStatesListShowOnly
        '
        Me.ckb_SStatesListShowOnly.AutoSize = True
        Me.ckb_SStatesListShowOnly.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckb_SStatesListShowOnly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckb_SStatesListShowOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckb_SStatesListShowOnly.Location = New System.Drawing.Point(8, 48)
        Me.ckb_SStatesListShowOnly.Name = "ckb_SStatesListShowOnly"
        Me.ckb_SStatesListShowOnly.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckb_SStatesListShowOnly.Size = New System.Drawing.Size(154, 21)
        Me.ckb_SStatesListShowOnly.TabIndex = 12
        Me.ckb_SStatesListShowOnly.Text = "Use a single list for files only (hides the game info and game list)."
        Me.ckb_SStatesListShowOnly.UseVisualStyleBackColor = False
        '
        'ckbFirstRun
        '
        Me.ckbFirstRun.AutoSize = True
        Me.ckbFirstRun.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckbFirstRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbFirstRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbFirstRun.Location = New System.Drawing.Point(8, 27)
        Me.ckbFirstRun.Name = "ckbFirstRun"
        Me.ckbFirstRun.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckbFirstRun.Size = New System.Drawing.Size(154, 21)
        Me.ckbFirstRun.TabIndex = 11
        Me.ckbFirstRun.Text = "Reset SStatesMan settings to their defaults on next startup."
        Me.ckbFirstRun.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Label3.Size = New System.Drawing.Size(106, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "General options"
        '
        'pnlTab1
        '
        Me.pnlTab1.AutoScroll = True
        Me.pnlTab1.Controls.Add(Me.fppPCSX2SnapsPath)
        Me.pnlTab1.Controls.Add(Me.lblPCSX2SnapsPath)
        Me.pnlTab1.Controls.Add(Me.fppPCSX2SStatePath)
        Me.pnlTab1.Controls.Add(Me.lblPCSX2SStatePath)
        Me.pnlTab1.Controls.Add(Me.fppPCSX2IniPath)
        Me.pnlTab1.Controls.Add(Me.lblPCSX2IniPath)
        Me.pnlTab1.Controls.Add(Me.fppPCSX2AppPath)
        Me.pnlTab1.Controls.Add(Me.lblPCSX2AppPath)
        Me.pnlTab1.Location = New System.Drawing.Point(180, 75)
        Me.pnlTab1.Name = "pnlTab1"
        Me.pnlTab1.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlTab1.Size = New System.Drawing.Size(173, 317)
        Me.pnlTab1.TabIndex = 24
        '
        'fppPCSX2SnapsPath
        '
        Me.fppPCSX2SnapsPath.AutoSize = True
        Me.fppPCSX2SnapsPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fppPCSX2SnapsPath.DescriptionError = "ErrorText"
        Me.fppPCSX2SnapsPath.DescriptionInfo = "InfoText"
        Me.fppPCSX2SnapsPath.DescriptionWarning = "WarningText"
        Me.fppPCSX2SnapsPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.fppPCSX2SnapsPath.FBDDefaultPath = System.Environment.SpecialFolder.MyDocuments
        Me.fppPCSX2SnapsPath.FBDDescription = "BrowserTip"
        Me.fppPCSX2SnapsPath.FBDShowNewFolderButton = False
        Me.fppPCSX2SnapsPath.Location = New System.Drawing.Point(8, 270)
        Me.fppPCSX2SnapsPath.Name = "fppPCSX2SnapsPath"
        Me.fppPCSX2SnapsPath.ShowDetectButton = True
        Me.fppPCSX2SnapsPath.Size = New System.Drawing.Size(140, 58)
        Me.fppPCSX2SnapsPath.State = sstatesman.ucFolderPickerPanel.eDescState.StateIdle
        Me.fppPCSX2SnapsPath.TabIndex = 59
        '
        'lblPCSX2SnapsPath
        '
        Me.lblPCSX2SnapsPath.AutoSize = True
        Me.lblPCSX2SnapsPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPCSX2SnapsPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPCSX2SnapsPath.Location = New System.Drawing.Point(8, 247)
        Me.lblPCSX2SnapsPath.Name = "lblPCSX2SnapsPath"
        Me.lblPCSX2SnapsPath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblPCSX2SnapsPath.Size = New System.Drawing.Size(121, 23)
        Me.lblPCSX2SnapsPath.TabIndex = 42
        Me.lblPCSX2SnapsPath.Text = "Screenshots folder"
        '
        'fppPCSX2SStatePath
        '
        Me.fppPCSX2SStatePath.AutoSize = True
        Me.fppPCSX2SStatePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fppPCSX2SStatePath.DescriptionError = "ErrorText"
        Me.fppPCSX2SStatePath.DescriptionInfo = "InfoText"
        Me.fppPCSX2SStatePath.DescriptionWarning = "WarningText"
        Me.fppPCSX2SStatePath.Dock = System.Windows.Forms.DockStyle.Top
        Me.fppPCSX2SStatePath.FBDDefaultPath = System.Environment.SpecialFolder.MyDocuments
        Me.fppPCSX2SStatePath.FBDDescription = "BrowserTip"
        Me.fppPCSX2SStatePath.FBDShowNewFolderButton = False
        Me.fppPCSX2SStatePath.Location = New System.Drawing.Point(8, 189)
        Me.fppPCSX2SStatePath.Name = "fppPCSX2SStatePath"
        Me.fppPCSX2SStatePath.ShowDetectButton = True
        Me.fppPCSX2SStatePath.Size = New System.Drawing.Size(140, 58)
        Me.fppPCSX2SStatePath.State = sstatesman.ucFolderPickerPanel.eDescState.StateIdle
        Me.fppPCSX2SStatePath.TabIndex = 59
        '
        'fppPCSX2IniPath
        '
        Me.fppPCSX2IniPath.AutoSize = True
        Me.fppPCSX2IniPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fppPCSX2IniPath.DescriptionError = "ErrorText"
        Me.fppPCSX2IniPath.DescriptionInfo = "InfoText"
        Me.fppPCSX2IniPath.DescriptionWarning = "WarningText"
        Me.fppPCSX2IniPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.fppPCSX2IniPath.FBDDefaultPath = System.Environment.SpecialFolder.MyDocuments
        Me.fppPCSX2IniPath.FBDDescription = "BrowserTip"
        Me.fppPCSX2IniPath.FBDShowNewFolderButton = False
        Me.fppPCSX2IniPath.Location = New System.Drawing.Point(8, 108)
        Me.fppPCSX2IniPath.Name = "fppPCSX2IniPath"
        Me.fppPCSX2IniPath.ShowDetectButton = True
        Me.fppPCSX2IniPath.Size = New System.Drawing.Size(140, 58)
        Me.fppPCSX2IniPath.State = sstatesman.ucFolderPickerPanel.eDescState.StateIdle
        Me.fppPCSX2IniPath.TabIndex = 59
        '
        'fppPCSX2AppPath
        '
        Me.fppPCSX2AppPath.AutoSize = True
        Me.fppPCSX2AppPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fppPCSX2AppPath.DescriptionError = "ErrorText"
        Me.fppPCSX2AppPath.DescriptionInfo = "InfoText"
        Me.fppPCSX2AppPath.DescriptionWarning = "WarningText"
        Me.fppPCSX2AppPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.fppPCSX2AppPath.FBDDefaultPath = System.Environment.SpecialFolder.ProgramFiles
        Me.fppPCSX2AppPath.FBDDescription = "Select your PCSX2 executable folder."
        Me.fppPCSX2AppPath.FBDShowNewFolderButton = False
        Me.fppPCSX2AppPath.Location = New System.Drawing.Point(8, 27)
        Me.fppPCSX2AppPath.Name = "fppPCSX2AppPath"
        Me.fppPCSX2AppPath.ShowDetectButton = True
        Me.fppPCSX2AppPath.Size = New System.Drawing.Size(140, 58)
        Me.fppPCSX2AppPath.State = sstatesman.ucFolderPickerPanel.eDescState.StateIdle
        Me.fppPCSX2AppPath.TabIndex = 59
        '
        'pnlTab2
        '
        Me.pnlTab2.AutoScroll = True
        Me.pnlTab2.Controls.Add(Me.ckbSStatesManThemeGradient)
        Me.pnlTab2.Controls.Add(Me.ckbSStatesManThemeImage)
        Me.pnlTab2.Controls.Add(Me.Label2)
        Me.pnlTab2.Controls.Add(Me.pnlThemeOptions)
        Me.pnlTab2.Controls.Add(Me.Label5)
        Me.pnlTab2.Location = New System.Drawing.Point(359, 75)
        Me.pnlTab2.Name = "pnlTab2"
        Me.pnlTab2.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlTab2.Size = New System.Drawing.Size(98, 317)
        Me.pnlTab2.TabIndex = 48
        '
        'ckbSStatesManThemeGradient
        '
        Me.ckbSStatesManThemeGradient.AutoSize = True
        Me.ckbSStatesManThemeGradient.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckbSStatesManThemeGradient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManThemeGradient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManThemeGradient.Location = New System.Drawing.Point(8, 194)
        Me.ckbSStatesManThemeGradient.Name = "ckbSStatesManThemeGradient"
        Me.ckbSStatesManThemeGradient.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckbSStatesManThemeGradient.Size = New System.Drawing.Size(82, 21)
        Me.ckbSStatesManThemeGradient.TabIndex = 57
        Me.ckbSStatesManThemeGradient.Text = "Enable windows gradient backgrounds."
        Me.ckbSStatesManThemeGradient.UseVisualStyleBackColor = False
        '
        'ckbSStatesManThemeImage
        '
        Me.ckbSStatesManThemeImage.AutoSize = True
        Me.ckbSStatesManThemeImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.ckbSStatesManThemeImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManThemeImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManThemeImage.Location = New System.Drawing.Point(8, 173)
        Me.ckbSStatesManThemeImage.Name = "ckbSStatesManThemeImage"
        Me.ckbSStatesManThemeImage.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.ckbSStatesManThemeImage.Size = New System.Drawing.Size(82, 21)
        Me.ckbSStatesManThemeImage.TabIndex = 50
        Me.ckbSStatesManThemeImage.Text = "Enable windows background image."
        Me.ckbSStatesManThemeImage.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Label2.Size = New System.Drawing.Size(95, 23)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Other options"
        '
        'pnlThemeOptions
        '
        Me.pnlThemeOptions.AutoSize = True
        Me.pnlThemeOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlThemeOptions.Controls.Add(Me.optTheme11)
        Me.pnlThemeOptions.Controls.Add(Me.optTheme6)
        Me.pnlThemeOptions.Controls.Add(Me.optTheme5)
        Me.pnlThemeOptions.Controls.Add(Me.optTheme4)
        Me.pnlThemeOptions.Controls.Add(Me.optTheme3)
        Me.pnlThemeOptions.Controls.Add(Me.optTheme2)
        Me.pnlThemeOptions.Controls.Add(Me.optTheme1)
        Me.pnlThemeOptions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlThemeOptions.Location = New System.Drawing.Point(8, 27)
        Me.pnlThemeOptions.Name = "pnlThemeOptions"
        Me.pnlThemeOptions.Padding = New System.Windows.Forms.Padding(12, 2, 12, 2)
        Me.pnlThemeOptions.Size = New System.Drawing.Size(82, 123)
        Me.pnlThemeOptions.TabIndex = 51
        '
        'optTheme11
        '
        Me.optTheme11.AutoSize = True
        Me.optTheme11.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme11.Location = New System.Drawing.Point(12, 104)
        Me.optTheme11.Name = "optTheme11"
        Me.optTheme11.Size = New System.Drawing.Size(58, 17)
        Me.optTheme11.TabIndex = 55
        Me.optTheme11.TabStop = True
        Me.optTheme11.Tag = "PCSX2"
        Me.optTheme11.Text = "PCSX2"
        Me.optTheme11.UseVisualStyleBackColor = True
        '
        'optTheme6
        '
        Me.optTheme6.AutoSize = True
        Me.optTheme6.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme6.Location = New System.Drawing.Point(12, 87)
        Me.optTheme6.Name = "optTheme6"
        Me.optTheme6.Size = New System.Drawing.Size(58, 17)
        Me.optTheme6.TabIndex = 58
        Me.optTheme6.TabStop = True
        Me.optTheme6.Tag = "hexagons"
        Me.optTheme6.Text = "Hexagons"
        Me.optTheme6.UseVisualStyleBackColor = True
        '
        'optTheme5
        '
        Me.optTheme5.AutoSize = True
        Me.optTheme5.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme5.Location = New System.Drawing.Point(12, 70)
        Me.optTheme5.Name = "optTheme5"
        Me.optTheme5.Size = New System.Drawing.Size(58, 17)
        Me.optTheme5.TabIndex = 56
        Me.optTheme5.TabStop = True
        Me.optTheme5.Tag = "brushedmetal"
        Me.optTheme5.Text = "Brushed metal"
        Me.optTheme5.UseVisualStyleBackColor = True
        '
        'optTheme4
        '
        Me.optTheme4.AutoSize = True
        Me.optTheme4.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme4.Location = New System.Drawing.Point(12, 53)
        Me.optTheme4.Name = "optTheme4"
        Me.optTheme4.Size = New System.Drawing.Size(58, 17)
        Me.optTheme4.TabIndex = 57
        Me.optTheme4.TabStop = True
        Me.optTheme4.Tag = "stripes_light"
        Me.optTheme4.Text = "Light stripes"
        Me.optTheme4.UseVisualStyleBackColor = True
        '
        'optTheme3
        '
        Me.optTheme3.AutoSize = True
        Me.optTheme3.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme3.Location = New System.Drawing.Point(12, 36)
        Me.optTheme3.Name = "optTheme3"
        Me.optTheme3.Size = New System.Drawing.Size(58, 17)
        Me.optTheme3.TabIndex = 54
        Me.optTheme3.TabStop = True
        Me.optTheme3.Tag = "stripes_dark"
        Me.optTheme3.Text = "Dark stripes"
        Me.optTheme3.UseVisualStyleBackColor = True
        '
        'optTheme2
        '
        Me.optTheme2.AutoSize = True
        Me.optTheme2.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme2.Location = New System.Drawing.Point(12, 19)
        Me.optTheme2.Name = "optTheme2"
        Me.optTheme2.Size = New System.Drawing.Size(58, 17)
        Me.optTheme2.TabIndex = 53
        Me.optTheme2.TabStop = True
        Me.optTheme2.Tag = "noise"
        Me.optTheme2.Text = "Noise"
        Me.optTheme2.UseVisualStyleBackColor = True
        '
        'optTheme1
        '
        Me.optTheme1.AutoSize = True
        Me.optTheme1.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTheme1.Location = New System.Drawing.Point(12, 2)
        Me.optTheme1.Name = "optTheme1"
        Me.optTheme1.Size = New System.Drawing.Size(58, 17)
        Me.optTheme1.TabIndex = 52
        Me.optTheme1.TabStop = True
        Me.optTheme1.Tag = "squares"
        Me.optTheme1.Text = "Squares"
        Me.optTheme1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Label5.Size = New System.Drawing.Size(38, 23)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Style"
        '
        'pnlTab3
        '
        Me.pnlTab3.AutoScroll = True
        Me.pnlTab3.Controls.Add(Me.lvwLog)
        Me.pnlTab3.Controls.Add(Me.TableLayoutPanel4)
        Me.pnlTab3.Location = New System.Drawing.Point(463, 75)
        Me.pnlTab3.Name = "pnlTab3"
        Me.pnlTab3.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.pnlTab3.Size = New System.Drawing.Size(99, 317)
        Me.pnlTab3.TabIndex = 58
        '
        'lvwLog
        '
        Me.lvwLog.BackColor = System.Drawing.Color.White
        Me.lvwLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvwLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwLog.ForeColor = System.Drawing.Color.Black
        Me.lvwLog.FullRowSelect = True
        Me.lvwLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwLog.Location = New System.Drawing.Point(8, 23)
        Me.lvwLog.Margin = New System.Windows.Forms.Padding(0)
        Me.lvwLog.Name = "lvwLog"
        Me.lvwLog.Size = New System.Drawing.Size(83, 290)
        Me.lvwLog.TabIndex = 0
        Me.lvwLog.UseCompatibleStateImageBehavior = False
        Me.lvwLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Source"
        Me.ColumnHeader2.Width = 180
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Action"
        Me.ColumnHeader3.Width = 190
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Duration"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 70
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.FlowPanelSStatesList, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(8, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(83, 23)
        Me.TableLayoutPanel4.TabIndex = 39
        '
        'FlowPanelSStatesList
        '
        Me.FlowPanelSStatesList.AutoSize = True
        Me.FlowPanelSStatesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdLogFilter)
        Me.FlowPanelSStatesList.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowPanelSStatesList.Location = New System.Drawing.Point(-20, 0)
        Me.FlowPanelSStatesList.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowPanelSStatesList.Name = "FlowPanelSStatesList"
        Me.FlowPanelSStatesList.Size = New System.Drawing.Size(87, 22)
        Me.FlowPanelSStatesList.TabIndex = 48
        Me.FlowPanelSStatesList.WrapContents = False
        '
        'cmdLogFilter
        '
        Me.cmdLogFilter.AutoSize = True
        Me.cmdLogFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdLogFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdLogFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogFilter.FlatAppearance.BorderSize = 0
        Me.cmdLogFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogFilter.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogFilter.Image = Global.sstatesman.My.Resources.Resources.Button_Dropdown_6x3
        Me.cmdLogFilter.Location = New System.Drawing.Point(0, 0)
        Me.cmdLogFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdLogFilter.Name = "cmdLogFilter"
        Me.cmdLogFilter.Size = New System.Drawing.Size(87, 22)
        Me.cmdLogFilter.TabIndex = 43
        Me.cmdLogFilter.Text = "SOURCE FILTER"
        Me.cmdLogFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdLogFilter.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdLogRefresh)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdLogExport)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(16, 0)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(120, 23)
        Me.FlowLayoutPanel2.TabIndex = 49
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'cmdLogRefresh
        '
        Me.cmdLogRefresh.AutoSize = True
        Me.cmdLogRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdLogRefresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdLogRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogRefresh.FlatAppearance.BorderSize = 0
        Me.cmdLogRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogRefresh.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogRefresh.Image = Global.sstatesman.My.Resources.Resources.Glyph_Refresh
        Me.cmdLogRefresh.Location = New System.Drawing.Point(0, 0)
        Me.cmdLogRefresh.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.cmdLogRefresh.Name = "cmdLogRefresh"
        Me.cmdLogRefresh.Size = New System.Drawing.Size(70, 22)
        Me.cmdLogRefresh.TabIndex = 20
        Me.cmdLogRefresh.Text = "REFRESH"
        Me.cmdLogRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdLogRefresh.UseVisualStyleBackColor = False
        '
        'cmdLogExport
        '
        Me.cmdLogExport.AutoSize = True
        Me.cmdLogExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdLogExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdLogExport.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogExport.FlatAppearance.BorderSize = 0
        Me.cmdLogExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogExport.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogExport.Location = New System.Drawing.Point(70, 0)
        Me.cmdLogExport.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.cmdLogExport.Name = "cmdLogExport"
        Me.cmdLogExport.Size = New System.Drawing.Size(50, 22)
        Me.cmdLogExport.TabIndex = 21
        Me.cmdLogExport.Text = "EXPORT"
        Me.cmdLogExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdLogExport.UseVisualStyleBackColor = False
        '
        'cmLogFilter
        '
        Me.cmLogFilter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmLogFilter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmiAll})
        Me.cmLogFilter.Name = "cmLogFilter"
        Me.cmLogFilter.Size = New System.Drawing.Size(97, 26)
        '
        'cmiAll
        '
        Me.cmiAll.Checked = True
        Me.cmiAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmiAll.Name = "cmiAll"
        Me.cmiAll.Size = New System.Drawing.Size(96, 22)
        Me.cmiAll.Text = "(All)"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(574, 432)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.flpTab)
        Me.Controls.Add(Me.pnlTab0)
        Me.Controls.Add(Me.pnlTab3)
        Me.Controls.Add(Me.pnlTab2)
        Me.Controls.Add(Me.pnlTab1)
        Me.DoubleBuffered = True
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.pnlTab1, 0)
        Me.Controls.SetChildIndex(Me.pnlTab2, 0)
        Me.Controls.SetChildIndex(Me.pnlTab3, 0)
        Me.Controls.SetChildIndex(Me.pnlTab0, 0)
        Me.Controls.SetChildIndex(Me.flpTab, 0)
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.Controls.SetChildIndex(Me.cmdApply, 0)
        Me.flpTab.ResumeLayout(False)
        Me.flpTab.PerformLayout()
        Me.pnlTab0.ResumeLayout(False)
        Me.pnlTab0.PerformLayout()
        Me.pnlTab1.ResumeLayout(False)
        Me.pnlTab1.PerformLayout()
        Me.pnlTab2.ResumeLayout(False)
        Me.pnlTab2.PerformLayout()
        Me.pnlThemeOptions.ResumeLayout(False)
        Me.pnlThemeOptions.PerformLayout()
        Me.pnlTab3.ResumeLayout(False)
        Me.pnlTab3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowPanelSStatesList.ResumeLayout(False)
        Me.FlowPanelSStatesList.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.cmLogFilter.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cmdOk As System.Windows.Forms.Button
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents optTabHeader0 As System.Windows.Forms.RadioButton
    Private WithEvents lblPCSX2SStatePath As System.Windows.Forms.Label
    Private WithEvents lblPCSX2IniPath As System.Windows.Forms.Label
    Private WithEvents lblPCSX2AppPath As System.Windows.Forms.Label
    Private WithEvents optTabHeader1 As System.Windows.Forms.RadioButton
    Private WithEvents flpTab As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents optTabHeader2 As System.Windows.Forms.RadioButton
    Private WithEvents pnlTab0 As System.Windows.Forms.Panel
    Private WithEvents lblSStatesManPicsPath As System.Windows.Forms.Label
    Private WithEvents ckbSStatesManMoveToTrash As System.Windows.Forms.CheckBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ckb_SStatesListAutoRefresh As System.Windows.Forms.CheckBox
    Private WithEvents ckb_SStatesListShowOnly As System.Windows.Forms.CheckBox
    Private WithEvents ckbFirstRun As System.Windows.Forms.CheckBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents pnlTab1 As System.Windows.Forms.Panel
    Private WithEvents pnlTab2 As System.Windows.Forms.Panel
    Private WithEvents pnlThemeOptions As System.Windows.Forms.Panel
    Private WithEvents optTheme3 As System.Windows.Forms.RadioButton
    Private WithEvents optTheme2 As System.Windows.Forms.RadioButton
    Private WithEvents optTheme1 As System.Windows.Forms.RadioButton
    Private WithEvents ckbSStatesManThemeImage As System.Windows.Forms.CheckBox
    Private WithEvents ckbSStatesManThemeGradient As System.Windows.Forms.CheckBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents optTheme11 As System.Windows.Forms.RadioButton
    Private WithEvents ckbSStatesManVersionExtract As System.Windows.Forms.CheckBox
    Private WithEvents optTheme5 As System.Windows.Forms.RadioButton
    Private WithEvents pnlTab3 As System.Windows.Forms.Panel
    Private WithEvents lvwLog As System.Windows.Forms.ListView
    Private WithEvents optTabHeader3 As System.Windows.Forms.RadioButton
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdLogRefresh As System.Windows.Forms.Button
    Private WithEvents FlowPanelSStatesList As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdLogFilter As System.Windows.Forms.Button
    Private WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents optTheme4 As System.Windows.Forms.RadioButton
    Private WithEvents optTheme6 As System.Windows.Forms.RadioButton
    Private WithEvents cmdApply As System.Windows.Forms.Button
    Private WithEvents lblPCSX2SnapsPath As System.Windows.Forms.Label
    Private WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdLogExport As System.Windows.Forms.Button
    Private WithEvents cmLogFilter As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents fppSStatesManStoredPath As sstatesman.ucFolderPickerPanel
    Private WithEvents lblSStatesManStoredPath As System.Windows.Forms.Label
    Private WithEvents fppPCSX2AppPath As sstatesman.ucFolderPickerPanel
    Private WithEvents fppPCSX2IniPath As sstatesman.ucFolderPickerPanel
    Private WithEvents fppPCSX2SStatePath As sstatesman.ucFolderPickerPanel
    Private WithEvents fppPCSX2SnapsPath As sstatesman.ucFolderPickerPanel
    Private WithEvents fppSStatesManPicsPath As sstatesman.ucFolderPickerPanel
End Class
