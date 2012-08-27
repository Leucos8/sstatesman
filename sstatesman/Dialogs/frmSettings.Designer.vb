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
Partial Class frmSettings
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
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtSStatesManPicsPath = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSStatesManPicsPathBrowse = New System.Windows.Forms.Button()
        Me.lblSStatesManPicsPathStatus = New System.Windows.Forms.Label()
        Me.cmdPCSX2IniPathOpen = New System.Windows.Forms.Button()
        Me.cmdPCSX2IniPathDetect = New System.Windows.Forms.Button()
        Me.imgPCSX2IniPathStatus = New System.Windows.Forms.PictureBox()
        Me.lblPCSX2IniPathStatus = New System.Windows.Forms.Label()
        Me.cmdPCSX2IniPathBrowse = New System.Windows.Forms.Button()
        Me.txtPCSX2IniPath = New System.Windows.Forms.TextBox()
        Me.cmdPCSX2AppPathOpen = New System.Windows.Forms.Button()
        Me.cmdPCSX2AppPathDetect = New System.Windows.Forms.Button()
        Me.imgPCSX2AppPathStatus = New System.Windows.Forms.PictureBox()
        Me.cmdPCSX2AppPathBrowse = New System.Windows.Forms.Button()
        Me.lblPCSX2SStatePath = New System.Windows.Forms.Label()
        Me.lblPCSX2IniPath = New System.Windows.Forms.Label()
        Me.lblPCSX2AppPath = New System.Windows.Forms.Label()
        Me.txtPCSX2AppPath = New System.Windows.Forms.TextBox()
        Me.cmdSStatesManPicsPathOpen = New System.Windows.Forms.Button()
        Me.imgSStatesManPicsPathStatus = New System.Windows.Forms.PictureBox()
        Me.optSettingTab2 = New System.Windows.Forms.RadioButton()
        Me.optSettingTab1 = New System.Windows.Forms.RadioButton()
        Me.flpSStatesManPicsPath = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpPCSX2AppPath = New System.Windows.Forms.TableLayoutPanel()
        Me.flpPCSX2AppPath = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblPCSX2AppPathStatus = New System.Windows.Forms.Label()
        Me.tlpPCSX2SStatePath = New System.Windows.Forms.TableLayoutPanel()
        Me.flpPCSX2SStatePath = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdPCSX2SStatePathBrowse = New System.Windows.Forms.Button()
        Me.cmdPCSX2SStatePathOpen = New System.Windows.Forms.Button()
        Me.cmdPCSX2SStatePathDetect = New System.Windows.Forms.Button()
        Me.txtPCSX2SStatePath = New System.Windows.Forms.TextBox()
        Me.lblPCSX2SStatePathStatus = New System.Windows.Forms.Label()
        Me.imgPCSX2SStatePathStatus = New System.Windows.Forms.PictureBox()
        Me.tlpPCSX2IniPath = New System.Windows.Forms.TableLayoutPanel()
        Me.flpPCSX2IniPath = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpSStatesManPicsPath = New System.Windows.Forms.TableLayoutPanel()
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.flpTab = New System.Windows.Forms.FlowLayoutPanel()
        Me.optSettingTab3 = New System.Windows.Forms.RadioButton()
        Me.optSettingTab4 = New System.Windows.Forms.RadioButton()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlTab1 = New System.Windows.Forms.Panel()
        Me.lblSStatesManPicsPath = New System.Windows.Forms.Label()
        Me.ckbSStatesManMoveToTrash = New System.Windows.Forms.CheckBox()
        Me.ckbSStatesManVersionExtract = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckb_SStatesListAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.ckb_SStatesListShowOnly = New System.Windows.Forms.CheckBox()
        Me.ckbFirstRun = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTab2 = New System.Windows.Forms.Panel()
        Me.tlpPCSX2SnapsPath = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdPCSX2SnapsPathBrowse = New System.Windows.Forms.Button()
        Me.cmdPCSX2SnapsPathOpen = New System.Windows.Forms.Button()
        Me.cmdPCSX2SnapsPathDetect = New System.Windows.Forms.Button()
        Me.txtPCSX2SnapsPath = New System.Windows.Forms.TextBox()
        Me.lblPCSX2SnapsPathStatus = New System.Windows.Forms.Label()
        Me.imgPCSX2SnapsPathStatus = New System.Windows.Forms.PictureBox()
        Me.lblPCSX2SnapsPath = New System.Windows.Forms.Label()
        Me.pnlTab3 = New System.Windows.Forms.Panel()
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
        Me.pnlTab4 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdLogRefresh = New System.Windows.Forms.Button()
        Me.FlowPanelSStatesList = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdLogFilter_frmMain = New System.Windows.Forms.Button()
        Me.cmdLogFilter_Files = New System.Windows.Forms.Button()
        Me.cmdLogFilter_GameDB = New System.Windows.Forms.Button()
        Me.lblSStateListCheck = New System.Windows.Forms.Label()
        CType(Me.imgPCSX2IniPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgPCSX2AppPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSStatesManPicsPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpSStatesManPicsPath.SuspendLayout()
        Me.tlpPCSX2AppPath.SuspendLayout()
        Me.flpPCSX2AppPath.SuspendLayout()
        Me.tlpPCSX2SStatePath.SuspendLayout()
        Me.flpPCSX2SStatePath.SuspendLayout()
        CType(Me.imgPCSX2SStatePathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpPCSX2IniPath.SuspendLayout()
        Me.flpPCSX2IniPath.SuspendLayout()
        Me.tlpSStatesManPicsPath.SuspendLayout()
        Me.flpWindowBottom.SuspendLayout()
        Me.flpTab.SuspendLayout()
        Me.panelWindowTitle.SuspendLayout()
        Me.pnlTab1.SuspendLayout()
        Me.pnlTab2.SuspendLayout()
        Me.tlpPCSX2SnapsPath.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.imgPCSX2SnapsPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTab3.SuspendLayout()
        Me.pnlThemeOptions.SuspendLayout()
        Me.pnlTab4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowPanelSStatesList.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.AutoSize = True
        Me.cmdOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdOk.BackColor = System.Drawing.Color.White
        Me.cmdOk.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(256, 6)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOk.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 24)
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'txtSStatesManPicsPath
        '
        Me.txtSStatesManPicsPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtSStatesManPicsPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtSStatesManPicsPath.BackColor = System.Drawing.Color.White
        Me.txtSStatesManPicsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpSStatesManPicsPath.SetColumnSpan(Me.txtSStatesManPicsPath, 3)
        Me.txtSStatesManPicsPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSStatesManPicsPath.ForeColor = System.Drawing.Color.Black
        Me.txtSStatesManPicsPath.Location = New System.Drawing.Point(10, 4)
        Me.txtSStatesManPicsPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSStatesManPicsPath.Name = "txtSStatesManPicsPath"
        Me.txtSStatesManPicsPath.Size = New System.Drawing.Size(110, 22)
        Me.txtSStatesManPicsPath.TabIndex = 19
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.AutoSize = True
        Me.cmdCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCancel.BackColor = System.Drawing.Color.White
        Me.cmdCancel.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(360, 6)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdSStatesManPicsPathBrowse
        '
        Me.cmdSStatesManPicsPathBrowse.AutoSize = True
        Me.cmdSStatesManPicsPathBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSStatesManPicsPathBrowse.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdSStatesManPicsPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdSStatesManPicsPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStatesManPicsPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStatesManPicsPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStatesManPicsPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStatesManPicsPathBrowse.Location = New System.Drawing.Point(61, 2)
        Me.cmdSStatesManPicsPathBrowse.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSStatesManPicsPathBrowse.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdSStatesManPicsPathBrowse.Name = "cmdSStatesManPicsPathBrowse"
        Me.cmdSStatesManPicsPathBrowse.Size = New System.Drawing.Size(55, 24)
        Me.cmdSStatesManPicsPathBrowse.TabIndex = 22
        Me.cmdSStatesManPicsPathBrowse.Text = "BROWSE"
        Me.cmdSStatesManPicsPathBrowse.UseVisualStyleBackColor = False
        '
        'lblSStatesManPicsPathStatus
        '
        Me.lblSStatesManPicsPathStatus.AutoSize = True
        Me.lblSStatesManPicsPathStatus.Location = New System.Drawing.Point(35, 28)
        Me.lblSStatesManPicsPathStatus.Name = "lblSStatesManPicsPathStatus"
        Me.lblSStatesManPicsPathStatus.Size = New System.Drawing.Size(1, 13)
        Me.lblSStatesManPicsPathStatus.TabIndex = 20
        Me.lblSStatesManPicsPathStatus.Text = "<text>"
        '
        'cmdPCSX2IniPathOpen
        '
        Me.cmdPCSX2IniPathOpen.AutoSize = True
        Me.cmdPCSX2IniPathOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2IniPathOpen.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2IniPathOpen.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2IniPathOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2IniPathOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2IniPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2IniPathOpen.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2IniPathOpen.Location = New System.Drawing.Point(61, 2)
        Me.cmdPCSX2IniPathOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2IniPathOpen.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2IniPathOpen.Name = "cmdPCSX2IniPathOpen"
        Me.cmdPCSX2IniPathOpen.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2IniPathOpen.TabIndex = 37
        Me.cmdPCSX2IniPathOpen.Text = "OPEN"
        Me.cmdPCSX2IniPathOpen.UseVisualStyleBackColor = False
        '
        'cmdPCSX2IniPathDetect
        '
        Me.cmdPCSX2IniPathDetect.AutoSize = True
        Me.cmdPCSX2IniPathDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2IniPathDetect.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2IniPathDetect.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2IniPathDetect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2IniPathDetect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2IniPathDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2IniPathDetect.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2IniPathDetect.Location = New System.Drawing.Point(2, 2)
        Me.cmdPCSX2IniPathDetect.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2IniPathDetect.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2IniPathDetect.Name = "cmdPCSX2IniPathDetect"
        Me.cmdPCSX2IniPathDetect.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2IniPathDetect.TabIndex = 38
        Me.cmdPCSX2IniPathDetect.Text = "DETECT"
        Me.cmdPCSX2IniPathDetect.UseVisualStyleBackColor = False
        '
        'imgPCSX2IniPathStatus
        '
        Me.imgPCSX2IniPathStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgPCSX2IniPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2IniPathStatus.Location = New System.Drawing.Point(8, 28)
        Me.imgPCSX2IniPathStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.imgPCSX2IniPathStatus.Name = "imgPCSX2IniPathStatus"
        Me.imgPCSX2IniPathStatus.Size = New System.Drawing.Size(24, 28)
        Me.imgPCSX2IniPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2IniPathStatus.TabIndex = 35
        Me.imgPCSX2IniPathStatus.TabStop = False
        '
        'lblPCSX2IniPathStatus
        '
        Me.lblPCSX2IniPathStatus.AutoSize = True
        Me.lblPCSX2IniPathStatus.Location = New System.Drawing.Point(35, 28)
        Me.lblPCSX2IniPathStatus.Name = "lblPCSX2IniPathStatus"
        Me.lblPCSX2IniPathStatus.Size = New System.Drawing.Size(1, 13)
        Me.lblPCSX2IniPathStatus.TabIndex = 39
        Me.lblPCSX2IniPathStatus.Text = "<text>"
        '
        'cmdPCSX2IniPathBrowse
        '
        Me.cmdPCSX2IniPathBrowse.AutoSize = True
        Me.cmdPCSX2IniPathBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2IniPathBrowse.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2IniPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2IniPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2IniPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2IniPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2IniPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2IniPathBrowse.Location = New System.Drawing.Point(120, 2)
        Me.cmdPCSX2IniPathBrowse.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2IniPathBrowse.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2IniPathBrowse.Name = "cmdPCSX2IniPathBrowse"
        Me.cmdPCSX2IniPathBrowse.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2IniPathBrowse.TabIndex = 36
        Me.cmdPCSX2IniPathBrowse.Text = "BROWSE"
        Me.cmdPCSX2IniPathBrowse.UseVisualStyleBackColor = False
        '
        'txtPCSX2IniPath
        '
        Me.txtPCSX2IniPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2IniPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2IniPath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2IniPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPCSX2IniPath.SetColumnSpan(Me.txtPCSX2IniPath, 3)
        Me.txtPCSX2IniPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPCSX2IniPath.ForeColor = System.Drawing.Color.Black
        Me.txtPCSX2IniPath.Location = New System.Drawing.Point(10, 4)
        Me.txtPCSX2IniPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPCSX2IniPath.Name = "txtPCSX2IniPath"
        Me.txtPCSX2IniPath.Size = New System.Drawing.Size(106, 22)
        Me.txtPCSX2IniPath.TabIndex = 34
        '
        'cmdPCSX2AppPathOpen
        '
        Me.cmdPCSX2AppPathOpen.AutoSize = True
        Me.cmdPCSX2AppPathOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2AppPathOpen.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2AppPathOpen.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2AppPathOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2AppPathOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2AppPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2AppPathOpen.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2AppPathOpen.Location = New System.Drawing.Point(61, 2)
        Me.cmdPCSX2AppPathOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2AppPathOpen.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2AppPathOpen.Name = "cmdPCSX2AppPathOpen"
        Me.cmdPCSX2AppPathOpen.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2AppPathOpen.TabIndex = 30
        Me.cmdPCSX2AppPathOpen.Text = "OPEN"
        Me.cmdPCSX2AppPathOpen.UseVisualStyleBackColor = False
        '
        'cmdPCSX2AppPathDetect
        '
        Me.cmdPCSX2AppPathDetect.AutoSize = True
        Me.cmdPCSX2AppPathDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2AppPathDetect.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2AppPathDetect.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2AppPathDetect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2AppPathDetect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2AppPathDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2AppPathDetect.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2AppPathDetect.Location = New System.Drawing.Point(2, 2)
        Me.cmdPCSX2AppPathDetect.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2AppPathDetect.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2AppPathDetect.Name = "cmdPCSX2AppPathDetect"
        Me.cmdPCSX2AppPathDetect.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2AppPathDetect.TabIndex = 31
        Me.cmdPCSX2AppPathDetect.Text = "DETECT"
        Me.cmdPCSX2AppPathDetect.UseVisualStyleBackColor = False
        '
        'imgPCSX2AppPathStatus
        '
        Me.imgPCSX2AppPathStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgPCSX2AppPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2AppPathStatus.Location = New System.Drawing.Point(8, 28)
        Me.imgPCSX2AppPathStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.imgPCSX2AppPathStatus.Name = "imgPCSX2AppPathStatus"
        Me.imgPCSX2AppPathStatus.Size = New System.Drawing.Size(24, 28)
        Me.imgPCSX2AppPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2AppPathStatus.TabIndex = 26
        Me.imgPCSX2AppPathStatus.TabStop = False
        '
        'cmdPCSX2AppPathBrowse
        '
        Me.cmdPCSX2AppPathBrowse.AutoSize = True
        Me.cmdPCSX2AppPathBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2AppPathBrowse.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2AppPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2AppPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2AppPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2AppPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2AppPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2AppPathBrowse.Location = New System.Drawing.Point(120, 2)
        Me.cmdPCSX2AppPathBrowse.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2AppPathBrowse.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2AppPathBrowse.Name = "cmdPCSX2AppPathBrowse"
        Me.cmdPCSX2AppPathBrowse.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2AppPathBrowse.TabIndex = 29
        Me.cmdPCSX2AppPathBrowse.Text = "BROWSE"
        Me.cmdPCSX2AppPathBrowse.UseVisualStyleBackColor = False
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
        'txtPCSX2AppPath
        '
        Me.txtPCSX2AppPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2AppPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2AppPath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2AppPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPCSX2AppPath.SetColumnSpan(Me.txtPCSX2AppPath, 3)
        Me.txtPCSX2AppPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPCSX2AppPath.ForeColor = System.Drawing.Color.Black
        Me.txtPCSX2AppPath.Location = New System.Drawing.Point(10, 4)
        Me.txtPCSX2AppPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPCSX2AppPath.Name = "txtPCSX2AppPath"
        Me.txtPCSX2AppPath.Size = New System.Drawing.Size(106, 22)
        Me.txtPCSX2AppPath.TabIndex = 27
        '
        'cmdSStatesManPicsPathOpen
        '
        Me.cmdSStatesManPicsPathOpen.AutoSize = True
        Me.cmdSStatesManPicsPathOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSStatesManPicsPathOpen.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdSStatesManPicsPathOpen.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdSStatesManPicsPathOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStatesManPicsPathOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStatesManPicsPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStatesManPicsPathOpen.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStatesManPicsPathOpen.Location = New System.Drawing.Point(2, 2)
        Me.cmdSStatesManPicsPathOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdSStatesManPicsPathOpen.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdSStatesManPicsPathOpen.Name = "cmdSStatesManPicsPathOpen"
        Me.cmdSStatesManPicsPathOpen.Size = New System.Drawing.Size(55, 24)
        Me.cmdSStatesManPicsPathOpen.TabIndex = 23
        Me.cmdSStatesManPicsPathOpen.Text = "OPEN"
        Me.cmdSStatesManPicsPathOpen.UseVisualStyleBackColor = False
        '
        'imgSStatesManPicsPathStatus
        '
        Me.imgSStatesManPicsPathStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgSStatesManPicsPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgSStatesManPicsPathStatus.Location = New System.Drawing.Point(8, 28)
        Me.imgSStatesManPicsPathStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.imgSStatesManPicsPathStatus.Name = "imgSStatesManPicsPathStatus"
        Me.imgSStatesManPicsPathStatus.Size = New System.Drawing.Size(24, 28)
        Me.imgSStatesManPicsPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgSStatesManPicsPathStatus.TabIndex = 2
        Me.imgSStatesManPicsPathStatus.TabStop = False
        '
        'optSettingTab2
        '
        Me.optSettingTab2.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab2.AutoSize = True
        Me.optSettingTab2.BackColor = System.Drawing.Color.Transparent
        Me.optSettingTab2.FlatAppearance.BorderSize = 0
        Me.optSettingTab2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab2.Location = New System.Drawing.Point(93, 0)
        Me.optSettingTab2.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab2.Name = "optSettingTab2"
        Me.optSettingTab2.Size = New System.Drawing.Size(87, 23)
        Me.optSettingTab2.TabIndex = 7
        Me.optSettingTab2.Text = "PCSX2 folders"
        Me.optSettingTab2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab2.UseVisualStyleBackColor = False
        '
        'optSettingTab1
        '
        Me.optSettingTab1.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab1.AutoSize = True
        Me.optSettingTab1.Checked = True
        Me.optSettingTab1.FlatAppearance.BorderSize = 0
        Me.optSettingTab1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optSettingTab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.optSettingTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab1.Location = New System.Drawing.Point(16, 0)
        Me.optSettingTab1.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab1.Name = "optSettingTab1"
        Me.optSettingTab1.Size = New System.Drawing.Size(77, 23)
        Me.optSettingTab1.TabIndex = 6
        Me.optSettingTab1.TabStop = True
        Me.optSettingTab1.Text = "SStatesMan"
        Me.optSettingTab1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab1.UseVisualStyleBackColor = False
        '
        'flpSStatesManPicsPath
        '
        Me.flpSStatesManPicsPath.AutoSize = True
        Me.flpSStatesManPicsPath.Controls.Add(Me.cmdSStatesManPicsPathBrowse)
        Me.flpSStatesManPicsPath.Controls.Add(Me.cmdSStatesManPicsPathOpen)
        Me.flpSStatesManPicsPath.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpSStatesManPicsPath.Location = New System.Drawing.Point(4, 28)
        Me.flpSStatesManPicsPath.Margin = New System.Windows.Forms.Padding(0)
        Me.flpSStatesManPicsPath.Name = "flpSStatesManPicsPath"
        Me.flpSStatesManPicsPath.Size = New System.Drawing.Size(118, 28)
        Me.flpSStatesManPicsPath.TabIndex = 21
        Me.flpSStatesManPicsPath.WrapContents = False
        '
        'tlpPCSX2AppPath
        '
        Me.tlpPCSX2AppPath.AutoSize = True
        Me.tlpPCSX2AppPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPCSX2AppPath.ColumnCount = 3
        Me.tlpPCSX2AppPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2AppPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPCSX2AppPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2AppPath.Controls.Add(Me.flpPCSX2AppPath, 2, 1)
        Me.tlpPCSX2AppPath.Controls.Add(Me.imgPCSX2AppPathStatus, 0, 1)
        Me.tlpPCSX2AppPath.Controls.Add(Me.txtPCSX2AppPath, 0, 0)
        Me.tlpPCSX2AppPath.Controls.Add(Me.lblPCSX2AppPathStatus, 1, 1)
        Me.tlpPCSX2AppPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPCSX2AppPath.Location = New System.Drawing.Point(8, 27)
        Me.tlpPCSX2AppPath.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)
        Me.tlpPCSX2AppPath.Name = "tlpPCSX2AppPath"
        Me.tlpPCSX2AppPath.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.tlpPCSX2AppPath.RowCount = 2
        Me.tlpPCSX2AppPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2AppPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2AppPath.Size = New System.Drawing.Size(126, 58)
        Me.tlpPCSX2AppPath.TabIndex = 26
        '
        'flpPCSX2AppPath
        '
        Me.flpPCSX2AppPath.AutoSize = True
        Me.flpPCSX2AppPath.Controls.Add(Me.cmdPCSX2AppPathBrowse)
        Me.flpPCSX2AppPath.Controls.Add(Me.cmdPCSX2AppPathOpen)
        Me.flpPCSX2AppPath.Controls.Add(Me.cmdPCSX2AppPathDetect)
        Me.flpPCSX2AppPath.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpPCSX2AppPath.Location = New System.Drawing.Point(-59, 28)
        Me.flpPCSX2AppPath.Margin = New System.Windows.Forms.Padding(0)
        Me.flpPCSX2AppPath.Name = "flpPCSX2AppPath"
        Me.flpPCSX2AppPath.Size = New System.Drawing.Size(177, 28)
        Me.flpPCSX2AppPath.TabIndex = 28
        Me.flpPCSX2AppPath.WrapContents = False
        '
        'lblPCSX2AppPathStatus
        '
        Me.lblPCSX2AppPathStatus.AutoSize = True
        Me.lblPCSX2AppPathStatus.Location = New System.Drawing.Point(35, 28)
        Me.lblPCSX2AppPathStatus.Name = "lblPCSX2AppPathStatus"
        Me.lblPCSX2AppPathStatus.Size = New System.Drawing.Size(1, 13)
        Me.lblPCSX2AppPathStatus.TabIndex = 32
        Me.lblPCSX2AppPathStatus.Text = "<text>"
        '
        'tlpPCSX2SStatePath
        '
        Me.tlpPCSX2SStatePath.AutoSize = True
        Me.tlpPCSX2SStatePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPCSX2SStatePath.ColumnCount = 3
        Me.tlpPCSX2SStatePath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2SStatePath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPCSX2SStatePath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2SStatePath.Controls.Add(Me.flpPCSX2SStatePath, 2, 1)
        Me.tlpPCSX2SStatePath.Controls.Add(Me.txtPCSX2SStatePath, 0, 0)
        Me.tlpPCSX2SStatePath.Controls.Add(Me.lblPCSX2SStatePathStatus, 1, 1)
        Me.tlpPCSX2SStatePath.Controls.Add(Me.imgPCSX2SStatePathStatus, 0, 1)
        Me.tlpPCSX2SStatePath.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPCSX2SStatePath.Location = New System.Drawing.Point(8, 189)
        Me.tlpPCSX2SStatePath.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)
        Me.tlpPCSX2SStatePath.Name = "tlpPCSX2SStatePath"
        Me.tlpPCSX2SStatePath.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.tlpPCSX2SStatePath.RowCount = 2
        Me.tlpPCSX2SStatePath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2SStatePath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2SStatePath.Size = New System.Drawing.Size(126, 58)
        Me.tlpPCSX2SStatePath.TabIndex = 41
        '
        'flpPCSX2SStatePath
        '
        Me.flpPCSX2SStatePath.AutoSize = True
        Me.flpPCSX2SStatePath.Controls.Add(Me.cmdPCSX2SStatePathBrowse)
        Me.flpPCSX2SStatePath.Controls.Add(Me.cmdPCSX2SStatePathOpen)
        Me.flpPCSX2SStatePath.Controls.Add(Me.cmdPCSX2SStatePathDetect)
        Me.flpPCSX2SStatePath.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpPCSX2SStatePath.Location = New System.Drawing.Point(-59, 28)
        Me.flpPCSX2SStatePath.Margin = New System.Windows.Forms.Padding(0)
        Me.flpPCSX2SStatePath.Name = "flpPCSX2SStatePath"
        Me.flpPCSX2SStatePath.Size = New System.Drawing.Size(177, 28)
        Me.flpPCSX2SStatePath.TabIndex = 43
        Me.flpPCSX2SStatePath.WrapContents = False
        '
        'cmdPCSX2SStatePathBrowse
        '
        Me.cmdPCSX2SStatePathBrowse.AutoSize = True
        Me.cmdPCSX2SStatePathBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2SStatePathBrowse.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2SStatePathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2SStatePathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SStatePathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SStatePathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SStatePathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SStatePathBrowse.Location = New System.Drawing.Point(120, 2)
        Me.cmdPCSX2SStatePathBrowse.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2SStatePathBrowse.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2SStatePathBrowse.Name = "cmdPCSX2SStatePathBrowse"
        Me.cmdPCSX2SStatePathBrowse.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2SStatePathBrowse.TabIndex = 44
        Me.cmdPCSX2SStatePathBrowse.Text = "BROWSE"
        Me.cmdPCSX2SStatePathBrowse.UseVisualStyleBackColor = False
        '
        'cmdPCSX2SStatePathOpen
        '
        Me.cmdPCSX2SStatePathOpen.AutoSize = True
        Me.cmdPCSX2SStatePathOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2SStatePathOpen.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2SStatePathOpen.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2SStatePathOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SStatePathOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SStatePathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SStatePathOpen.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SStatePathOpen.Location = New System.Drawing.Point(61, 2)
        Me.cmdPCSX2SStatePathOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2SStatePathOpen.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2SStatePathOpen.Name = "cmdPCSX2SStatePathOpen"
        Me.cmdPCSX2SStatePathOpen.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2SStatePathOpen.TabIndex = 45
        Me.cmdPCSX2SStatePathOpen.Text = "OPEN"
        Me.cmdPCSX2SStatePathOpen.UseVisualStyleBackColor = False
        '
        'cmdPCSX2SStatePathDetect
        '
        Me.cmdPCSX2SStatePathDetect.AutoSize = True
        Me.cmdPCSX2SStatePathDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2SStatePathDetect.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2SStatePathDetect.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2SStatePathDetect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SStatePathDetect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SStatePathDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SStatePathDetect.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SStatePathDetect.Location = New System.Drawing.Point(2, 2)
        Me.cmdPCSX2SStatePathDetect.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2SStatePathDetect.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2SStatePathDetect.Name = "cmdPCSX2SStatePathDetect"
        Me.cmdPCSX2SStatePathDetect.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2SStatePathDetect.TabIndex = 46
        Me.cmdPCSX2SStatePathDetect.Text = "DETECT"
        Me.cmdPCSX2SStatePathDetect.UseVisualStyleBackColor = False
        '
        'txtPCSX2SStatePath
        '
        Me.txtPCSX2SStatePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2SStatePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2SStatePath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2SStatePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPCSX2SStatePath.SetColumnSpan(Me.txtPCSX2SStatePath, 3)
        Me.txtPCSX2SStatePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPCSX2SStatePath.ForeColor = System.Drawing.Color.Black
        Me.txtPCSX2SStatePath.Location = New System.Drawing.Point(10, 4)
        Me.txtPCSX2SStatePath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPCSX2SStatePath.Name = "txtPCSX2SStatePath"
        Me.txtPCSX2SStatePath.Size = New System.Drawing.Size(106, 22)
        Me.txtPCSX2SStatePath.TabIndex = 42
        '
        'lblPCSX2SStatePathStatus
        '
        Me.lblPCSX2SStatePathStatus.AutoSize = True
        Me.lblPCSX2SStatePathStatus.Location = New System.Drawing.Point(35, 28)
        Me.lblPCSX2SStatePathStatus.Name = "lblPCSX2SStatePathStatus"
        Me.lblPCSX2SStatePathStatus.Size = New System.Drawing.Size(1, 13)
        Me.lblPCSX2SStatePathStatus.TabIndex = 47
        Me.lblPCSX2SStatePathStatus.Text = "<text>"
        '
        'imgPCSX2SStatePathStatus
        '
        Me.imgPCSX2SStatePathStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgPCSX2SStatePathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2SStatePathStatus.Location = New System.Drawing.Point(8, 28)
        Me.imgPCSX2SStatePathStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.imgPCSX2SStatePathStatus.Name = "imgPCSX2SStatePathStatus"
        Me.imgPCSX2SStatePathStatus.Size = New System.Drawing.Size(24, 28)
        Me.imgPCSX2SStatePathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2SStatePathStatus.TabIndex = 36
        Me.imgPCSX2SStatePathStatus.TabStop = False
        '
        'tlpPCSX2IniPath
        '
        Me.tlpPCSX2IniPath.AutoSize = True
        Me.tlpPCSX2IniPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPCSX2IniPath.ColumnCount = 3
        Me.tlpPCSX2IniPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2IniPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPCSX2IniPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2IniPath.Controls.Add(Me.flpPCSX2IniPath, 2, 1)
        Me.tlpPCSX2IniPath.Controls.Add(Me.txtPCSX2IniPath, 0, 0)
        Me.tlpPCSX2IniPath.Controls.Add(Me.imgPCSX2IniPathStatus, 0, 1)
        Me.tlpPCSX2IniPath.Controls.Add(Me.lblPCSX2IniPathStatus, 1, 1)
        Me.tlpPCSX2IniPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPCSX2IniPath.Location = New System.Drawing.Point(8, 108)
        Me.tlpPCSX2IniPath.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)
        Me.tlpPCSX2IniPath.Name = "tlpPCSX2IniPath"
        Me.tlpPCSX2IniPath.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.tlpPCSX2IniPath.RowCount = 2
        Me.tlpPCSX2IniPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2IniPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2IniPath.Size = New System.Drawing.Size(126, 58)
        Me.tlpPCSX2IniPath.TabIndex = 30
        '
        'flpPCSX2IniPath
        '
        Me.flpPCSX2IniPath.AutoSize = True
        Me.flpPCSX2IniPath.Controls.Add(Me.cmdPCSX2IniPathBrowse)
        Me.flpPCSX2IniPath.Controls.Add(Me.cmdPCSX2IniPathOpen)
        Me.flpPCSX2IniPath.Controls.Add(Me.cmdPCSX2IniPathDetect)
        Me.flpPCSX2IniPath.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpPCSX2IniPath.Location = New System.Drawing.Point(-59, 28)
        Me.flpPCSX2IniPath.Margin = New System.Windows.Forms.Padding(0)
        Me.flpPCSX2IniPath.Name = "flpPCSX2IniPath"
        Me.flpPCSX2IniPath.Size = New System.Drawing.Size(177, 28)
        Me.flpPCSX2IniPath.TabIndex = 35
        Me.flpPCSX2IniPath.WrapContents = False
        '
        'tlpSStatesManPicsPath
        '
        Me.tlpSStatesManPicsPath.AutoSize = True
        Me.tlpSStatesManPicsPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSStatesManPicsPath.ColumnCount = 3
        Me.tlpSStatesManPicsPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSStatesManPicsPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSStatesManPicsPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSStatesManPicsPath.Controls.Add(Me.flpSStatesManPicsPath, 2, 1)
        Me.tlpSStatesManPicsPath.Controls.Add(Me.txtSStatesManPicsPath, 0, 0)
        Me.tlpSStatesManPicsPath.Controls.Add(Me.lblSStatesManPicsPathStatus, 1, 1)
        Me.tlpSStatesManPicsPath.Controls.Add(Me.imgSStatesManPicsPathStatus, 0, 1)
        Me.tlpSStatesManPicsPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpSStatesManPicsPath.Location = New System.Drawing.Point(8, 178)
        Me.tlpSStatesManPicsPath.Name = "tlpSStatesManPicsPath"
        Me.tlpSStatesManPicsPath.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.tlpSStatesManPicsPath.RowCount = 2
        Me.tlpSStatesManPicsPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSStatesManPicsPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSStatesManPicsPath.Size = New System.Drawing.Size(130, 58)
        Me.tlpSStatesManPicsPath.TabIndex = 18
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.BackColor = System.Drawing.Color.Gainsboro
        Me.flpWindowBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.flpWindowBottom.Controls.Add(Me.cmdApply)
        Me.flpWindowBottom.Controls.Add(Me.cmdCancel)
        Me.flpWindowBottom.Controls.Add(Me.cmdOk)
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 396)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4)
        Me.flpWindowBottom.Size = New System.Drawing.Size(574, 36)
        Me.flpWindowBottom.TabIndex = 0
        '
        'cmdApply
        '
        Me.cmdApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApply.AutoSize = True
        Me.cmdApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdApply.BackColor = System.Drawing.Color.White
        Me.cmdApply.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdApply.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApply.Location = New System.Drawing.Point(464, 6)
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
        Me.flpTab.Controls.Add(Me.optSettingTab1)
        Me.flpTab.Controls.Add(Me.optSettingTab2)
        Me.flpTab.Controls.Add(Me.optSettingTab3)
        Me.flpTab.Controls.Add(Me.optSettingTab4)
        Me.flpTab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpTab.Location = New System.Drawing.Point(0, 33)
        Me.flpTab.Margin = New System.Windows.Forms.Padding(0)
        Me.flpTab.Name = "flpTab"
        Me.flpTab.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.flpTab.Size = New System.Drawing.Size(574, 23)
        Me.flpTab.TabIndex = 5
        Me.flpTab.WrapContents = False
        '
        'optSettingTab3
        '
        Me.optSettingTab3.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab3.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab3.AutoSize = True
        Me.optSettingTab3.BackColor = System.Drawing.Color.Transparent
        Me.optSettingTab3.FlatAppearance.BorderSize = 0
        Me.optSettingTab3.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab3.Location = New System.Drawing.Point(180, 0)
        Me.optSettingTab3.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab3.Name = "optSettingTab3"
        Me.optSettingTab3.Size = New System.Drawing.Size(50, 23)
        Me.optSettingTab3.TabIndex = 8
        Me.optSettingTab3.Text = "Theme"
        Me.optSettingTab3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab3.UseVisualStyleBackColor = False
        '
        'optSettingTab4
        '
        Me.optSettingTab4.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab4.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab4.AutoSize = True
        Me.optSettingTab4.BackColor = System.Drawing.Color.Transparent
        Me.optSettingTab4.FlatAppearance.BorderSize = 0
        Me.optSettingTab4.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab4.Location = New System.Drawing.Point(230, 0)
        Me.optSettingTab4.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab4.Name = "optSettingTab4"
        Me.optSettingTab4.Size = New System.Drawing.Size(36, 23)
        Me.optSettingTab4.TabIndex = 9
        Me.optSettingTab4.Text = "Log"
        Me.optSettingTab4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSettingTab4.UseVisualStyleBackColor = False
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.AutoSize = True
        Me.panelWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.panelWindowTitle.Controls.Add(Me.Label4)
        Me.panelWindowTitle.Controls.Add(Me.flpTab)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.panelWindowTitle.MinimumSize = New System.Drawing.Size(0, 48)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(574, 56)
        Me.panelWindowTitle.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(8, 8, 8, 4)
        Me.Label4.Size = New System.Drawing.Size(80, 33)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "settings"
        '
        'pnlTab1
        '
        Me.pnlTab1.AutoScroll = True
        Me.pnlTab1.Controls.Add(Me.tlpSStatesManPicsPath)
        Me.pnlTab1.Controls.Add(Me.lblSStatesManPicsPath)
        Me.pnlTab1.Controls.Add(Me.ckbSStatesManMoveToTrash)
        Me.pnlTab1.Controls.Add(Me.ckbSStatesManVersionExtract)
        Me.pnlTab1.Controls.Add(Me.Label1)
        Me.pnlTab1.Controls.Add(Me.ckb_SStatesListAutoRefresh)
        Me.pnlTab1.Controls.Add(Me.ckb_SStatesListShowOnly)
        Me.pnlTab1.Controls.Add(Me.ckbFirstRun)
        Me.pnlTab1.Controls.Add(Me.Label3)
        Me.pnlTab1.Location = New System.Drawing.Point(12, 61)
        Me.pnlTab1.Name = "pnlTab1"
        Me.pnlTab1.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlTab1.Size = New System.Drawing.Size(146, 269)
        Me.pnlTab1.TabIndex = 9
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
        Me.ckbSStatesManMoveToTrash.Size = New System.Drawing.Size(130, 21)
        Me.ckbSStatesManMoveToTrash.TabIndex = 16
        Me.ckbSStatesManMoveToTrash.Text = "Move the deleted savestates to the Recycle Bin instead of deleting them permanent" & _
    "ly."
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
        Me.ckbSStatesManVersionExtract.Size = New System.Drawing.Size(130, 21)
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
        Me.Label1.Size = New System.Drawing.Size(158, 23)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Savestates management"
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
        Me.ckb_SStatesListAutoRefresh.Size = New System.Drawing.Size(130, 21)
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
        Me.ckb_SStatesListShowOnly.Size = New System.Drawing.Size(130, 21)
        Me.ckb_SStatesListShowOnly.TabIndex = 12
        Me.ckb_SStatesListShowOnly.Text = "By default hide the games list."
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
        Me.ckbFirstRun.Size = New System.Drawing.Size(130, 21)
        Me.ckbFirstRun.TabIndex = 11
        Me.ckbFirstRun.Text = "Restore SStatesMan settings to their defaults on next startup."
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
        'pnlTab2
        '
        Me.pnlTab2.AutoScroll = True
        Me.pnlTab2.Controls.Add(Me.tlpPCSX2SnapsPath)
        Me.pnlTab2.Controls.Add(Me.lblPCSX2SnapsPath)
        Me.pnlTab2.Controls.Add(Me.tlpPCSX2SStatePath)
        Me.pnlTab2.Controls.Add(Me.lblPCSX2SStatePath)
        Me.pnlTab2.Controls.Add(Me.tlpPCSX2IniPath)
        Me.pnlTab2.Controls.Add(Me.lblPCSX2IniPath)
        Me.pnlTab2.Controls.Add(Me.tlpPCSX2AppPath)
        Me.pnlTab2.Controls.Add(Me.lblPCSX2AppPath)
        Me.pnlTab2.Location = New System.Drawing.Point(164, 61)
        Me.pnlTab2.Name = "pnlTab2"
        Me.pnlTab2.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlTab2.Size = New System.Drawing.Size(142, 329)
        Me.pnlTab2.TabIndex = 24
        '
        'tlpPCSX2SnapsPath
        '
        Me.tlpPCSX2SnapsPath.AutoSize = True
        Me.tlpPCSX2SnapsPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPCSX2SnapsPath.ColumnCount = 3
        Me.tlpPCSX2SnapsPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2SnapsPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPCSX2SnapsPath.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPCSX2SnapsPath.Controls.Add(Me.FlowLayoutPanel1, 2, 1)
        Me.tlpPCSX2SnapsPath.Controls.Add(Me.txtPCSX2SnapsPath, 0, 0)
        Me.tlpPCSX2SnapsPath.Controls.Add(Me.lblPCSX2SnapsPathStatus, 1, 1)
        Me.tlpPCSX2SnapsPath.Controls.Add(Me.imgPCSX2SnapsPathStatus, 0, 1)
        Me.tlpPCSX2SnapsPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPCSX2SnapsPath.Location = New System.Drawing.Point(8, 270)
        Me.tlpPCSX2SnapsPath.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)
        Me.tlpPCSX2SnapsPath.Name = "tlpPCSX2SnapsPath"
        Me.tlpPCSX2SnapsPath.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.tlpPCSX2SnapsPath.RowCount = 2
        Me.tlpPCSX2SnapsPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2SnapsPath.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPCSX2SnapsPath.Size = New System.Drawing.Size(126, 58)
        Me.tlpPCSX2SnapsPath.TabIndex = 43
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdPCSX2SnapsPathBrowse)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdPCSX2SnapsPathOpen)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdPCSX2SnapsPathDetect)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(-59, 28)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(177, 28)
        Me.FlowLayoutPanel1.TabIndex = 43
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'cmdPCSX2SnapsPathBrowse
        '
        Me.cmdPCSX2SnapsPathBrowse.AutoSize = True
        Me.cmdPCSX2SnapsPathBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2SnapsPathBrowse.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2SnapsPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2SnapsPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SnapsPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SnapsPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SnapsPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SnapsPathBrowse.Location = New System.Drawing.Point(120, 2)
        Me.cmdPCSX2SnapsPathBrowse.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2SnapsPathBrowse.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2SnapsPathBrowse.Name = "cmdPCSX2SnapsPathBrowse"
        Me.cmdPCSX2SnapsPathBrowse.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2SnapsPathBrowse.TabIndex = 44
        Me.cmdPCSX2SnapsPathBrowse.Text = "BROWSE"
        Me.cmdPCSX2SnapsPathBrowse.UseVisualStyleBackColor = False
        '
        'cmdPCSX2SnapsPathOpen
        '
        Me.cmdPCSX2SnapsPathOpen.AutoSize = True
        Me.cmdPCSX2SnapsPathOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2SnapsPathOpen.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2SnapsPathOpen.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2SnapsPathOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SnapsPathOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SnapsPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SnapsPathOpen.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SnapsPathOpen.Location = New System.Drawing.Point(61, 2)
        Me.cmdPCSX2SnapsPathOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2SnapsPathOpen.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2SnapsPathOpen.Name = "cmdPCSX2SnapsPathOpen"
        Me.cmdPCSX2SnapsPathOpen.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2SnapsPathOpen.TabIndex = 45
        Me.cmdPCSX2SnapsPathOpen.Text = "OPEN"
        Me.cmdPCSX2SnapsPathOpen.UseVisualStyleBackColor = False
        '
        'cmdPCSX2SnapsPathDetect
        '
        Me.cmdPCSX2SnapsPathDetect.AutoSize = True
        Me.cmdPCSX2SnapsPathDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdPCSX2SnapsPathDetect.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdPCSX2SnapsPathDetect.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.cmdPCSX2SnapsPathDetect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SnapsPathDetect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SnapsPathDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SnapsPathDetect.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SnapsPathDetect.Location = New System.Drawing.Point(2, 2)
        Me.cmdPCSX2SnapsPathDetect.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPCSX2SnapsPathDetect.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdPCSX2SnapsPathDetect.Name = "cmdPCSX2SnapsPathDetect"
        Me.cmdPCSX2SnapsPathDetect.Size = New System.Drawing.Size(55, 24)
        Me.cmdPCSX2SnapsPathDetect.TabIndex = 46
        Me.cmdPCSX2SnapsPathDetect.Text = "DETECT"
        Me.cmdPCSX2SnapsPathDetect.UseVisualStyleBackColor = False
        '
        'txtPCSX2SnapsPath
        '
        Me.txtPCSX2SnapsPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2SnapsPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2SnapsPath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2SnapsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPCSX2SnapsPath.SetColumnSpan(Me.txtPCSX2SnapsPath, 3)
        Me.txtPCSX2SnapsPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPCSX2SnapsPath.ForeColor = System.Drawing.Color.Black
        Me.txtPCSX2SnapsPath.Location = New System.Drawing.Point(10, 4)
        Me.txtPCSX2SnapsPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPCSX2SnapsPath.Name = "txtPCSX2SnapsPath"
        Me.txtPCSX2SnapsPath.Size = New System.Drawing.Size(106, 22)
        Me.txtPCSX2SnapsPath.TabIndex = 42
        '
        'lblPCSX2SnapsPathStatus
        '
        Me.lblPCSX2SnapsPathStatus.AutoSize = True
        Me.lblPCSX2SnapsPathStatus.Location = New System.Drawing.Point(35, 28)
        Me.lblPCSX2SnapsPathStatus.Name = "lblPCSX2SnapsPathStatus"
        Me.lblPCSX2SnapsPathStatus.Size = New System.Drawing.Size(1, 13)
        Me.lblPCSX2SnapsPathStatus.TabIndex = 47
        Me.lblPCSX2SnapsPathStatus.Text = "<text>"
        '
        'imgPCSX2SnapsPathStatus
        '
        Me.imgPCSX2SnapsPathStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgPCSX2SnapsPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2SnapsPathStatus.Location = New System.Drawing.Point(8, 28)
        Me.imgPCSX2SnapsPathStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.imgPCSX2SnapsPathStatus.Name = "imgPCSX2SnapsPathStatus"
        Me.imgPCSX2SnapsPathStatus.Size = New System.Drawing.Size(24, 28)
        Me.imgPCSX2SnapsPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2SnapsPathStatus.TabIndex = 36
        Me.imgPCSX2SnapsPathStatus.TabStop = False
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
        'pnlTab3
        '
        Me.pnlTab3.AutoScroll = True
        Me.pnlTab3.Controls.Add(Me.ckbSStatesManThemeGradient)
        Me.pnlTab3.Controls.Add(Me.ckbSStatesManThemeImage)
        Me.pnlTab3.Controls.Add(Me.Label2)
        Me.pnlTab3.Controls.Add(Me.pnlThemeOptions)
        Me.pnlTab3.Controls.Add(Me.Label5)
        Me.pnlTab3.Location = New System.Drawing.Point(345, 61)
        Me.pnlTab3.Name = "pnlTab3"
        Me.pnlTab3.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlTab3.Size = New System.Drawing.Size(80, 269)
        Me.pnlTab3.TabIndex = 48
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
        Me.ckbSStatesManThemeGradient.Size = New System.Drawing.Size(64, 21)
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
        Me.ckbSStatesManThemeImage.Size = New System.Drawing.Size(64, 21)
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
        Me.pnlThemeOptions.Size = New System.Drawing.Size(64, 123)
        Me.pnlThemeOptions.TabIndex = 51
        '
        'optTheme11
        '
        Me.optTheme11.AutoSize = True
        Me.optTheme11.Dock = System.Windows.Forms.DockStyle.Top
        Me.optTheme11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTheme11.Location = New System.Drawing.Point(12, 104)
        Me.optTheme11.Name = "optTheme11"
        Me.optTheme11.Size = New System.Drawing.Size(40, 17)
        Me.optTheme11.TabIndex = 55
        Me.optTheme11.TabStop = True
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
        Me.optTheme6.Size = New System.Drawing.Size(40, 17)
        Me.optTheme6.TabIndex = 58
        Me.optTheme6.TabStop = True
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
        Me.optTheme5.Size = New System.Drawing.Size(40, 17)
        Me.optTheme5.TabIndex = 56
        Me.optTheme5.TabStop = True
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
        Me.optTheme4.Size = New System.Drawing.Size(40, 17)
        Me.optTheme4.TabIndex = 57
        Me.optTheme4.TabStop = True
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
        Me.optTheme3.Size = New System.Drawing.Size(40, 17)
        Me.optTheme3.TabIndex = 54
        Me.optTheme3.TabStop = True
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
        Me.optTheme2.Size = New System.Drawing.Size(40, 17)
        Me.optTheme2.TabIndex = 53
        Me.optTheme2.TabStop = True
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
        Me.optTheme1.Size = New System.Drawing.Size(40, 17)
        Me.optTheme1.TabIndex = 52
        Me.optTheme1.TabStop = True
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
        'pnlTab4
        '
        Me.pnlTab4.AutoScroll = True
        Me.pnlTab4.Controls.Add(Me.ListView1)
        Me.pnlTab4.Controls.Add(Me.TableLayoutPanel4)
        Me.pnlTab4.Location = New System.Drawing.Point(431, 61)
        Me.pnlTab4.Name = "pnlTab4"
        Me.pnlTab4.Padding = New System.Windows.Forms.Padding(8, 0, 8, 4)
        Me.pnlTab4.Size = New System.Drawing.Size(111, 269)
        Me.pnlTab4.TabIndex = 58
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.ForeColor = System.Drawing.Color.Black
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(8, 23)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(95, 242)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Origin"
        Me.ColumnHeader2.Width = 180
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Decription"
        Me.ColumnHeader3.Width = 220
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
        Me.TableLayoutPanel4.Controls.Add(Me.cmdLogRefresh, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowPanelSStatesList, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(8, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(95, 23)
        Me.TableLayoutPanel4.TabIndex = 39
        '
        'cmdLogRefresh
        '
        Me.cmdLogRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdLogRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogRefresh.FlatAppearance.BorderSize = 0
        Me.cmdLogRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogRefresh.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogRefresh.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Refresh
        Me.cmdLogRefresh.Location = New System.Drawing.Point(57, 0)
        Me.cmdLogRefresh.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.cmdLogRefresh.Name = "cmdLogRefresh"
        Me.cmdLogRefresh.Size = New System.Drawing.Size(22, 22)
        Me.cmdLogRefresh.TabIndex = 20
        Me.cmdLogRefresh.UseVisualStyleBackColor = False
        '
        'FlowPanelSStatesList
        '
        Me.FlowPanelSStatesList.AutoSize = True
        Me.FlowPanelSStatesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdLogFilter_frmMain)
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdLogFilter_Files)
        Me.FlowPanelSStatesList.Controls.Add(Me.cmdLogFilter_GameDB)
        Me.FlowPanelSStatesList.Controls.Add(Me.lblSStateListCheck)
        Me.FlowPanelSStatesList.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowPanelSStatesList.Location = New System.Drawing.Point(16, 0)
        Me.FlowPanelSStatesList.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowPanelSStatesList.Name = "FlowPanelSStatesList"
        Me.FlowPanelSStatesList.Size = New System.Drawing.Size(217, 22)
        Me.FlowPanelSStatesList.TabIndex = 48
        Me.FlowPanelSStatesList.WrapContents = False
        '
        'cmdLogFilter_frmMain
        '
        Me.cmdLogFilter_frmMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLogFilter_frmMain.AutoSize = True
        Me.cmdLogFilter_frmMain.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogFilter_frmMain.FlatAppearance.BorderSize = 0
        Me.cmdLogFilter_frmMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogFilter_frmMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogFilter_frmMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogFilter_frmMain.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogFilter_frmMain.Location = New System.Drawing.Point(133, 0)
        Me.cmdLogFilter_frmMain.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdLogFilter_frmMain.Name = "cmdLogFilter_frmMain"
        Me.cmdLogFilter_frmMain.Size = New System.Drawing.Size(84, 22)
        Me.cmdLogFilter_frmMain.TabIndex = 45
        Me.cmdLogFilter_frmMain.Text = "MAIN WINDOW"
        Me.cmdLogFilter_frmMain.UseVisualStyleBackColor = False
        '
        'cmdLogFilter_Files
        '
        Me.cmdLogFilter_Files.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLogFilter_Files.AutoSize = True
        Me.cmdLogFilter_Files.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogFilter_Files.FlatAppearance.BorderSize = 0
        Me.cmdLogFilter_Files.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogFilter_Files.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogFilter_Files.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogFilter_Files.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogFilter_Files.Location = New System.Drawing.Point(95, 0)
        Me.cmdLogFilter_Files.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdLogFilter_Files.Name = "cmdLogFilter_Files"
        Me.cmdLogFilter_Files.Size = New System.Drawing.Size(38, 22)
        Me.cmdLogFilter_Files.TabIndex = 44
        Me.cmdLogFilter_Files.Text = "FILES"
        Me.cmdLogFilter_Files.UseVisualStyleBackColor = False
        '
        'cmdLogFilter_GameDB
        '
        Me.cmdLogFilter_GameDB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLogFilter_GameDB.AutoSize = True
        Me.cmdLogFilter_GameDB.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdLogFilter_GameDB.FlatAppearance.BorderSize = 0
        Me.cmdLogFilter_GameDB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdLogFilter_GameDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdLogFilter_GameDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogFilter_GameDB.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogFilter_GameDB.Location = New System.Drawing.Point(38, 0)
        Me.cmdLogFilter_GameDB.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdLogFilter_GameDB.Name = "cmdLogFilter_GameDB"
        Me.cmdLogFilter_GameDB.Size = New System.Drawing.Size(57, 22)
        Me.cmdLogFilter_GameDB.TabIndex = 43
        Me.cmdLogFilter_GameDB.Text = "GAMEDB"
        Me.cmdLogFilter_GameDB.UseVisualStyleBackColor = False
        '
        'lblSStateListCheck
        '
        Me.lblSStateListCheck.AutoSize = True
        Me.lblSStateListCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSStateListCheck.Location = New System.Drawing.Point(2, 0)
        Me.lblSStateListCheck.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSStateListCheck.Name = "lblSStateListCheck"
        Me.lblSStateListCheck.Size = New System.Drawing.Size(34, 22)
        Me.lblSStateListCheck.TabIndex = 42
        Me.lblSStateListCheck.Text = "filter:"
        Me.lblSStateListCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(574, 432)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlTab4)
        Me.Controls.Add(Me.pnlTab3)
        Me.Controls.Add(Me.pnlTab2)
        Me.Controls.Add(Me.pnlTab1)
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        CType(Me.imgPCSX2IniPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgPCSX2AppPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSStatesManPicsPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpSStatesManPicsPath.ResumeLayout(False)
        Me.flpSStatesManPicsPath.PerformLayout()
        Me.tlpPCSX2AppPath.ResumeLayout(False)
        Me.tlpPCSX2AppPath.PerformLayout()
        Me.flpPCSX2AppPath.ResumeLayout(False)
        Me.flpPCSX2AppPath.PerformLayout()
        Me.tlpPCSX2SStatePath.ResumeLayout(False)
        Me.tlpPCSX2SStatePath.PerformLayout()
        Me.flpPCSX2SStatePath.ResumeLayout(False)
        Me.flpPCSX2SStatePath.PerformLayout()
        CType(Me.imgPCSX2SStatePathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpPCSX2IniPath.ResumeLayout(False)
        Me.tlpPCSX2IniPath.PerformLayout()
        Me.flpPCSX2IniPath.ResumeLayout(False)
        Me.flpPCSX2IniPath.PerformLayout()
        Me.tlpSStatesManPicsPath.ResumeLayout(False)
        Me.tlpSStatesManPicsPath.PerformLayout()
        Me.flpWindowBottom.ResumeLayout(False)
        Me.flpWindowBottom.PerformLayout()
        Me.flpTab.ResumeLayout(False)
        Me.flpTab.PerformLayout()
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        Me.pnlTab1.ResumeLayout(False)
        Me.pnlTab1.PerformLayout()
        Me.pnlTab2.ResumeLayout(False)
        Me.pnlTab2.PerformLayout()
        Me.tlpPCSX2SnapsPath.ResumeLayout(False)
        Me.tlpPCSX2SnapsPath.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.imgPCSX2SnapsPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTab3.ResumeLayout(False)
        Me.pnlTab3.PerformLayout()
        Me.pnlThemeOptions.ResumeLayout(False)
        Me.pnlThemeOptions.PerformLayout()
        Me.pnlTab4.ResumeLayout(False)
        Me.pnlTab4.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowPanelSStatesList.ResumeLayout(False)
        Me.FlowPanelSStatesList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtSStatesManPicsPath As System.Windows.Forms.TextBox
    Private WithEvents txtPCSX2AppPath As System.Windows.Forms.TextBox
    Private WithEvents cmdOk As System.Windows.Forms.Button
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdSStatesManPicsPathBrowse As System.Windows.Forms.Button
    Private WithEvents lblSStatesManPicsPathStatus As System.Windows.Forms.Label
    Private WithEvents optSettingTab1 As System.Windows.Forms.RadioButton
    Private WithEvents lblPCSX2IniPathStatus As System.Windows.Forms.Label
    Private WithEvents cmdPCSX2IniPathBrowse As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2AppPathBrowse As System.Windows.Forms.Button
    Private WithEvents lblPCSX2SStatePath As System.Windows.Forms.Label
    Private WithEvents lblPCSX2IniPath As System.Windows.Forms.Label
    Private WithEvents lblPCSX2AppPath As System.Windows.Forms.Label
    Private WithEvents txtPCSX2IniPath As System.Windows.Forms.TextBox
    Private WithEvents optSettingTab2 As System.Windows.Forms.RadioButton
    Private WithEvents imgSStatesManPicsPathStatus As System.Windows.Forms.PictureBox
    Private WithEvents imgPCSX2IniPathStatus As System.Windows.Forms.PictureBox
    Private WithEvents imgPCSX2AppPathStatus As System.Windows.Forms.PictureBox
    Private WithEvents cmdPCSX2AppPathDetect As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2IniPathDetect As System.Windows.Forms.Button
    Private WithEvents cmdSStatesManPicsPathOpen As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2AppPathOpen As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2IniPathOpen As System.Windows.Forms.Button
    Friend WithEvents tlpPCSX2AppPath As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblPCSX2AppPathStatus As System.Windows.Forms.Label
    Friend WithEvents tlpPCSX2IniPath As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flpPCSX2IniPath As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flpSStatesManPicsPath As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flpPCSX2AppPath As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tlpPCSX2SStatePath As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flpPCSX2SStatePath As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdPCSX2SStatePathBrowse As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2SStatePathOpen As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2SStatePathDetect As System.Windows.Forms.Button
    Private WithEvents txtPCSX2SStatePath As System.Windows.Forms.TextBox
    Private WithEvents lblPCSX2SStatePathStatus As System.Windows.Forms.Label
    Private WithEvents imgPCSX2SStatePathStatus As System.Windows.Forms.PictureBox
    Friend WithEvents flpTab As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tlpSStatesManPicsPath As System.Windows.Forms.TableLayoutPanel
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents optSettingTab3 As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTab1 As System.Windows.Forms.Panel
    Private WithEvents lblSStatesManPicsPath As System.Windows.Forms.Label
    Private WithEvents ckbSStatesManMoveToTrash As System.Windows.Forms.CheckBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ckb_SStatesListAutoRefresh As System.Windows.Forms.CheckBox
    Private WithEvents ckb_SStatesListShowOnly As System.Windows.Forms.CheckBox
    Private WithEvents ckbFirstRun As System.Windows.Forms.CheckBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlTab2 As System.Windows.Forms.Panel
    Friend WithEvents pnlTab3 As System.Windows.Forms.Panel
    Friend WithEvents pnlThemeOptions As System.Windows.Forms.Panel
    Friend WithEvents optTheme3 As System.Windows.Forms.RadioButton
    Friend WithEvents optTheme2 As System.Windows.Forms.RadioButton
    Friend WithEvents optTheme1 As System.Windows.Forms.RadioButton
    Private WithEvents ckbSStatesManThemeImage As System.Windows.Forms.CheckBox
    Private WithEvents ckbSStatesManThemeGradient As System.Windows.Forms.CheckBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optTheme11 As System.Windows.Forms.RadioButton
    Private WithEvents ckbSStatesManVersionExtract As System.Windows.Forms.CheckBox
    Friend WithEvents optTheme5 As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTab4 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Private WithEvents optSettingTab4 As System.Windows.Forms.RadioButton
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdLogRefresh As System.Windows.Forms.Button
    Friend WithEvents FlowPanelSStatesList As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdLogFilter_frmMain As System.Windows.Forms.Button
    Private WithEvents cmdLogFilter_Files As System.Windows.Forms.Button
    Private WithEvents cmdLogFilter_GameDB As System.Windows.Forms.Button
    Private WithEvents lblSStateListCheck As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents optTheme4 As System.Windows.Forms.RadioButton
    Friend WithEvents optTheme6 As System.Windows.Forms.RadioButton
    Private WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents tlpPCSX2SnapsPath As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdPCSX2SnapsPathBrowse As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2SnapsPathOpen As System.Windows.Forms.Button
    Private WithEvents cmdPCSX2SnapsPathDetect As System.Windows.Forms.Button
    Private WithEvents txtPCSX2SnapsPath As System.Windows.Forms.TextBox
    Private WithEvents lblPCSX2SnapsPathStatus As System.Windows.Forms.Label
    Private WithEvents imgPCSX2SnapsPathStatus As System.Windows.Forms.PictureBox
    Private WithEvents lblPCSX2SnapsPath As System.Windows.Forms.Label
End Class
