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
        Me.ckbFirstRun = New System.Windows.Forms.CheckBox()
        Me.ckbSStatesManMoveToTrash = New System.Windows.Forms.CheckBox()
        Me.lblSStateManPicsPath = New System.Windows.Forms.Label()
        Me.txtSStateManPicsPath = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdSStateManPicsPathBrowse = New System.Windows.Forms.Button()
        Me.ckbSStatesManBGEnabled = New System.Windows.Forms.CheckBox()
        Me.lblSStateManPicsPathStatus = New System.Windows.Forms.Label()
        Me.panelTab2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.imgPCSX2SStatePathStatus = New System.Windows.Forms.PictureBox()
        Me.imgPCSX2IniPathStatus = New System.Windows.Forms.PictureBox()
        Me.imgPCSX2AppPathStatus = New System.Windows.Forms.PictureBox()
        Me.lblPCSX2SStatePathStatus = New System.Windows.Forms.Label()
        Me.lblPCSX2IniPathStatus = New System.Windows.Forms.Label()
        Me.lblPCSX2AppPathStatus = New System.Windows.Forms.Label()
        Me.cmdPCSX2SStatePathBrowse = New System.Windows.Forms.Button()
        Me.cmdPCSX2IniPathBrowse = New System.Windows.Forms.Button()
        Me.cmdPCSX2AppPathBrowse = New System.Windows.Forms.Button()
        Me.lblPCSX2SStatePath = New System.Windows.Forms.Label()
        Me.txtPCSX2SStatePath = New System.Windows.Forms.TextBox()
        Me.lblPCSX2IniPath = New System.Windows.Forms.Label()
        Me.lblPCSX2AppPath = New System.Windows.Forms.Label()
        Me.txtPCSX2IniPath = New System.Windows.Forms.TextBox()
        Me.txtPCSX2AppPath = New System.Windows.Forms.TextBox()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.panelTab1 = New System.Windows.Forms.Panel()
        Me.imgSStateManPicsPathStatus = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.optStettingTab2 = New System.Windows.Forms.RadioButton()
        Me.optStettingTab1 = New System.Windows.Forms.RadioButton()
        Me.lblWindowProgramName = New System.Windows.Forms.Label()
        Me.imgWindowGradientLeft = New System.Windows.Forms.PictureBox()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.panelTab2.SuspendLayout()
        CType(Me.imgPCSX2SStatePathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgPCSX2IniPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgPCSX2AppPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelBottom.SuspendLayout()
        Me.panelTab1.SuspendLayout()
        CType(Me.imgSStateManPicsPathStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelWindowTitle.SuspendLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.Color.White
        Me.cmdOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.cmdOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(302, 12)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 22)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'ckbFirstRun
        '
        Me.ckbFirstRun.AutoSize = True
        Me.ckbFirstRun.BackColor = System.Drawing.Color.Transparent
        Me.ckbFirstRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbFirstRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbFirstRun.ForeColor = System.Drawing.Color.DimGray
        Me.ckbFirstRun.Location = New System.Drawing.Point(11, 252)
        Me.ckbFirstRun.Name = "ckbFirstRun"
        Me.ckbFirstRun.Size = New System.Drawing.Size(316, 17)
        Me.ckbFirstRun.TabIndex = 17
        Me.ckbFirstRun.Text = "Re-attemp to detect PCSX2 folders config on next startup"
        Me.ckbFirstRun.UseVisualStyleBackColor = False
        '
        'ckbSStatesManMoveToTrash
        '
        Me.ckbSStatesManMoveToTrash.AutoSize = True
        Me.ckbSStatesManMoveToTrash.BackColor = System.Drawing.Color.Transparent
        Me.ckbSStatesManMoveToTrash.Checked = True
        Me.ckbSStatesManMoveToTrash.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbSStatesManMoveToTrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManMoveToTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManMoveToTrash.Location = New System.Drawing.Point(11, 71)
        Me.ckbSStatesManMoveToTrash.Name = "ckbSStatesManMoveToTrash"
        Me.ckbSStatesManMoveToTrash.Size = New System.Drawing.Size(459, 17)
        Me.ckbSStatesManMoveToTrash.TabIndex = 18
        Me.ckbSStatesManMoveToTrash.Text = "Move the deleted savestates to the Recycle Bin instead of deleting them permanent" & _
    "ly"
        Me.ckbSStatesManMoveToTrash.UseVisualStyleBackColor = False
        '
        'lblSStateManPicsPath
        '
        Me.lblSStateManPicsPath.AutoSize = True
        Me.lblSStateManPicsPath.BackColor = System.Drawing.Color.Transparent
        Me.lblSStateManPicsPath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSStateManPicsPath.Location = New System.Drawing.Point(3, 91)
        Me.lblSStateManPicsPath.Name = "lblSStateManPicsPath"
        Me.lblSStateManPicsPath.Size = New System.Drawing.Size(159, 21)
        Me.lblSStateManPicsPath.TabIndex = 14
        Me.lblSStateManPicsPath.Text = "Game cover pics path"
        '
        'txtSStateManPicsPath
        '
        Me.txtSStateManPicsPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSStateManPicsPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtSStateManPicsPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtSStateManPicsPath.BackColor = System.Drawing.Color.White
        Me.txtSStateManPicsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSStateManPicsPath.ForeColor = System.Drawing.Color.DimGray
        Me.txtSStateManPicsPath.Location = New System.Drawing.Point(11, 115)
        Me.txtSStateManPicsPath.Name = "txtSStateManPicsPath"
        Me.txtSStateManPicsPath.Size = New System.Drawing.Size(469, 22)
        Me.txtSStateManPicsPath.TabIndex = 15
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.Color.White
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(408, 12)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 22)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdSStateManPicsPathBrowse
        '
        Me.cmdSStateManPicsPathBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSStateManPicsPathBrowse.BackColor = System.Drawing.Color.White
        Me.cmdSStateManPicsPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdSStateManPicsPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSStateManPicsPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdSStateManPicsPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSStateManPicsPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSStateManPicsPathBrowse.Location = New System.Drawing.Point(425, 140)
        Me.cmdSStateManPicsPathBrowse.Name = "cmdSStateManPicsPathBrowse"
        Me.cmdSStateManPicsPathBrowse.Size = New System.Drawing.Size(55, 22)
        Me.cmdSStateManPicsPathBrowse.TabIndex = 16
        Me.cmdSStateManPicsPathBrowse.Text = "BROWSE"
        Me.cmdSStateManPicsPathBrowse.UseVisualStyleBackColor = False
        '
        'ckbSStatesManBGEnabled
        '
        Me.ckbSStatesManBGEnabled.AutoSize = True
        Me.ckbSStatesManBGEnabled.BackColor = System.Drawing.Color.Transparent
        Me.ckbSStatesManBGEnabled.Checked = True
        Me.ckbSStatesManBGEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbSStatesManBGEnabled.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManBGEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManBGEnabled.Location = New System.Drawing.Point(11, 27)
        Me.ckbSStatesManBGEnabled.Name = "ckbSStatesManBGEnabled"
        Me.ckbSStatesManBGEnabled.Size = New System.Drawing.Size(347, 17)
        Me.ckbSStatesManBGEnabled.TabIndex = 19
        Me.ckbSStatesManBGEnabled.Text = "Disable windows gradient backgrounds (improve performance)"
        Me.ckbSStatesManBGEnabled.UseVisualStyleBackColor = False
        '
        'lblSStateManPicsPathStatus
        '
        Me.lblSStateManPicsPathStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSStateManPicsPathStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSStateManPicsPathStatus.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSStateManPicsPathStatus.Location = New System.Drawing.Point(11, 140)
        Me.lblSStateManPicsPathStatus.Name = "lblSStateManPicsPathStatus"
        Me.lblSStateManPicsPathStatus.Size = New System.Drawing.Size(408, 25)
        Me.lblSStateManPicsPathStatus.TabIndex = 23
        '
        'panelTab2
        '
        Me.panelTab2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelTab2.BackColor = System.Drawing.Color.Transparent
        Me.panelTab2.Controls.Add(Me.Label3)
        Me.panelTab2.Controls.Add(Me.imgPCSX2SStatePathStatus)
        Me.panelTab2.Controls.Add(Me.imgPCSX2IniPathStatus)
        Me.panelTab2.Controls.Add(Me.imgPCSX2AppPathStatus)
        Me.panelTab2.Controls.Add(Me.lblPCSX2SStatePathStatus)
        Me.panelTab2.Controls.Add(Me.lblPCSX2IniPathStatus)
        Me.panelTab2.Controls.Add(Me.lblPCSX2AppPathStatus)
        Me.panelTab2.Controls.Add(Me.cmdPCSX2SStatePathBrowse)
        Me.panelTab2.Controls.Add(Me.cmdPCSX2IniPathBrowse)
        Me.panelTab2.Controls.Add(Me.cmdPCSX2AppPathBrowse)
        Me.panelTab2.Controls.Add(Me.lblPCSX2SStatePath)
        Me.panelTab2.Controls.Add(Me.txtPCSX2SStatePath)
        Me.panelTab2.Controls.Add(Me.ckbFirstRun)
        Me.panelTab2.Controls.Add(Me.lblPCSX2IniPath)
        Me.panelTab2.Controls.Add(Me.lblPCSX2AppPath)
        Me.panelTab2.Controls.Add(Me.txtPCSX2IniPath)
        Me.panelTab2.Controls.Add(Me.txtPCSX2AppPath)
        Me.panelTab2.Location = New System.Drawing.Point(15, 252)
        Me.panelTab2.Margin = New System.Windows.Forms.Padding(6)
        Me.panelTab2.Name = "panelTab2"
        Me.panelTab2.Size = New System.Drawing.Size(493, 280)
        Me.panelTab2.TabIndex = 24
        Me.panelTab2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 21)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Options"
        '
        'imgPCSX2SStatePathStatus
        '
        Me.imgPCSX2SStatePathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2SStatePathStatus.Location = New System.Drawing.Point(11, 200)
        Me.imgPCSX2SStatePathStatus.Name = "imgPCSX2SStatePathStatus"
        Me.imgPCSX2SStatePathStatus.Size = New System.Drawing.Size(28, 25)
        Me.imgPCSX2SStatePathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2SStatePathStatus.TabIndex = 36
        Me.imgPCSX2SStatePathStatus.TabStop = False
        '
        'imgPCSX2IniPathStatus
        '
        Me.imgPCSX2IniPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2IniPathStatus.Location = New System.Drawing.Point(11, 126)
        Me.imgPCSX2IniPathStatus.Name = "imgPCSX2IniPathStatus"
        Me.imgPCSX2IniPathStatus.Size = New System.Drawing.Size(28, 25)
        Me.imgPCSX2IniPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2IniPathStatus.TabIndex = 35
        Me.imgPCSX2IniPathStatus.TabStop = False
        '
        'imgPCSX2AppPathStatus
        '
        Me.imgPCSX2AppPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgPCSX2AppPathStatus.Location = New System.Drawing.Point(11, 52)
        Me.imgPCSX2AppPathStatus.Name = "imgPCSX2AppPathStatus"
        Me.imgPCSX2AppPathStatus.Size = New System.Drawing.Size(28, 25)
        Me.imgPCSX2AppPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgPCSX2AppPathStatus.TabIndex = 26
        Me.imgPCSX2AppPathStatus.TabStop = False
        '
        'lblPCSX2SStatePathStatus
        '
        Me.lblPCSX2SStatePathStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPCSX2SStatePathStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblPCSX2SStatePathStatus.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCSX2SStatePathStatus.Location = New System.Drawing.Point(12, 200)
        Me.lblPCSX2SStatePathStatus.Name = "lblPCSX2SStatePathStatus"
        Me.lblPCSX2SStatePathStatus.Size = New System.Drawing.Size(407, 25)
        Me.lblPCSX2SStatePathStatus.TabIndex = 34
        '
        'lblPCSX2IniPathStatus
        '
        Me.lblPCSX2IniPathStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPCSX2IniPathStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblPCSX2IniPathStatus.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCSX2IniPathStatus.Location = New System.Drawing.Point(12, 126)
        Me.lblPCSX2IniPathStatus.Name = "lblPCSX2IniPathStatus"
        Me.lblPCSX2IniPathStatus.Size = New System.Drawing.Size(407, 25)
        Me.lblPCSX2IniPathStatus.TabIndex = 33
        '
        'lblPCSX2AppPathStatus
        '
        Me.lblPCSX2AppPathStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPCSX2AppPathStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblPCSX2AppPathStatus.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCSX2AppPathStatus.Location = New System.Drawing.Point(12, 52)
        Me.lblPCSX2AppPathStatus.Name = "lblPCSX2AppPathStatus"
        Me.lblPCSX2AppPathStatus.Size = New System.Drawing.Size(407, 25)
        Me.lblPCSX2AppPathStatus.TabIndex = 32
        '
        'cmdPCSX2SStatePathBrowse
        '
        Me.cmdPCSX2SStatePathBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPCSX2SStatePathBrowse.BackColor = System.Drawing.Color.White
        Me.cmdPCSX2SStatePathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdPCSX2SStatePathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2SStatePathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2SStatePathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2SStatePathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2SStatePathBrowse.Location = New System.Drawing.Point(425, 200)
        Me.cmdPCSX2SStatePathBrowse.Name = "cmdPCSX2SStatePathBrowse"
        Me.cmdPCSX2SStatePathBrowse.Size = New System.Drawing.Size(55, 22)
        Me.cmdPCSX2SStatePathBrowse.TabIndex = 31
        Me.cmdPCSX2SStatePathBrowse.Text = "BROWSE"
        Me.cmdPCSX2SStatePathBrowse.UseVisualStyleBackColor = False
        '
        'cmdPCSX2IniPathBrowse
        '
        Me.cmdPCSX2IniPathBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPCSX2IniPathBrowse.BackColor = System.Drawing.Color.White
        Me.cmdPCSX2IniPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdPCSX2IniPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2IniPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2IniPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2IniPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2IniPathBrowse.Location = New System.Drawing.Point(425, 126)
        Me.cmdPCSX2IniPathBrowse.Name = "cmdPCSX2IniPathBrowse"
        Me.cmdPCSX2IniPathBrowse.Size = New System.Drawing.Size(55, 22)
        Me.cmdPCSX2IniPathBrowse.TabIndex = 28
        Me.cmdPCSX2IniPathBrowse.Text = "BROWSE"
        Me.cmdPCSX2IniPathBrowse.UseVisualStyleBackColor = False
        '
        'cmdPCSX2AppPathBrowse
        '
        Me.cmdPCSX2AppPathBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPCSX2AppPathBrowse.BackColor = System.Drawing.Color.White
        Me.cmdPCSX2AppPathBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdPCSX2AppPathBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdPCSX2AppPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPCSX2AppPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPCSX2AppPathBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPCSX2AppPathBrowse.Location = New System.Drawing.Point(425, 52)
        Me.cmdPCSX2AppPathBrowse.Name = "cmdPCSX2AppPathBrowse"
        Me.cmdPCSX2AppPathBrowse.Size = New System.Drawing.Size(55, 22)
        Me.cmdPCSX2AppPathBrowse.TabIndex = 25
        Me.cmdPCSX2AppPathBrowse.Text = "BROWSE"
        Me.cmdPCSX2AppPathBrowse.UseVisualStyleBackColor = False
        '
        'lblPCSX2SStatePath
        '
        Me.lblPCSX2SStatePath.AutoSize = True
        Me.lblPCSX2SStatePath.BackColor = System.Drawing.Color.Transparent
        Me.lblPCSX2SStatePath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCSX2SStatePath.Location = New System.Drawing.Point(3, 151)
        Me.lblPCSX2SStatePath.Name = "lblPCSX2SStatePath"
        Me.lblPCSX2SStatePath.Size = New System.Drawing.Size(146, 21)
        Me.lblPCSX2SStatePath.TabIndex = 29
        Me.lblPCSX2SStatePath.Text = "PCSX2 SStates path"
        '
        'txtPCSX2SStatePath
        '
        Me.txtPCSX2SStatePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPCSX2SStatePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2SStatePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2SStatePath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2SStatePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPCSX2SStatePath.ForeColor = System.Drawing.Color.DimGray
        Me.txtPCSX2SStatePath.Location = New System.Drawing.Point(11, 175)
        Me.txtPCSX2SStatePath.Name = "txtPCSX2SStatePath"
        Me.txtPCSX2SStatePath.Size = New System.Drawing.Size(470, 22)
        Me.txtPCSX2SStatePath.TabIndex = 30
        '
        'lblPCSX2IniPath
        '
        Me.lblPCSX2IniPath.AutoSize = True
        Me.lblPCSX2IniPath.BackColor = System.Drawing.Color.Transparent
        Me.lblPCSX2IniPath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCSX2IniPath.Location = New System.Drawing.Point(3, 77)
        Me.lblPCSX2IniPath.Name = "lblPCSX2IniPath"
        Me.lblPCSX2IniPath.Size = New System.Drawing.Size(119, 21)
        Me.lblPCSX2IniPath.TabIndex = 26
        Me.lblPCSX2IniPath.Text = "PCSX2 inis path"
        '
        'lblPCSX2AppPath
        '
        Me.lblPCSX2AppPath.AutoSize = True
        Me.lblPCSX2AppPath.BackColor = System.Drawing.Color.Transparent
        Me.lblPCSX2AppPath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCSX2AppPath.Location = New System.Drawing.Point(3, 3)
        Me.lblPCSX2AppPath.Name = "lblPCSX2AppPath"
        Me.lblPCSX2AppPath.Size = New System.Drawing.Size(150, 21)
        Me.lblPCSX2AppPath.TabIndex = 23
        Me.lblPCSX2AppPath.Text = "PCSX2 binaries path"
        '
        'txtPCSX2IniPath
        '
        Me.txtPCSX2IniPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPCSX2IniPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2IniPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2IniPath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2IniPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPCSX2IniPath.ForeColor = System.Drawing.Color.DimGray
        Me.txtPCSX2IniPath.Location = New System.Drawing.Point(11, 101)
        Me.txtPCSX2IniPath.Name = "txtPCSX2IniPath"
        Me.txtPCSX2IniPath.Size = New System.Drawing.Size(470, 22)
        Me.txtPCSX2IniPath.TabIndex = 27
        '
        'txtPCSX2AppPath
        '
        Me.txtPCSX2AppPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPCSX2AppPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPCSX2AppPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPCSX2AppPath.BackColor = System.Drawing.Color.White
        Me.txtPCSX2AppPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPCSX2AppPath.ForeColor = System.Drawing.Color.DimGray
        Me.txtPCSX2AppPath.Location = New System.Drawing.Point(12, 27)
        Me.txtPCSX2AppPath.Name = "txtPCSX2AppPath"
        Me.txtPCSX2AppPath.Size = New System.Drawing.Size(469, 22)
        Me.txtPCSX2AppPath.TabIndex = 24
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.Transparent
        Me.panelBottom.Controls.Add(Me.cmdCancel)
        Me.panelBottom.Controls.Add(Me.cmdOk)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 544)
        Me.panelBottom.Margin = New System.Windows.Forms.Padding(6)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(520, 46)
        Me.panelBottom.TabIndex = 25
        '
        'panelTab1
        '
        Me.panelTab1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelTab1.BackColor = System.Drawing.Color.Transparent
        Me.panelTab1.Controls.Add(Me.imgSStateManPicsPathStatus)
        Me.panelTab1.Controls.Add(Me.Label2)
        Me.panelTab1.Controls.Add(Me.Label1)
        Me.panelTab1.Controls.Add(Me.lblSStateManPicsPath)
        Me.panelTab1.Controls.Add(Me.txtSStateManPicsPath)
        Me.panelTab1.Controls.Add(Me.ckbSStatesManMoveToTrash)
        Me.panelTab1.Controls.Add(Me.lblSStateManPicsPathStatus)
        Me.panelTab1.Controls.Add(Me.cmdSStateManPicsPathBrowse)
        Me.panelTab1.Controls.Add(Me.ckbSStatesManBGEnabled)
        Me.panelTab1.Location = New System.Drawing.Point(15, 76)
        Me.panelTab1.Name = "panelTab1"
        Me.panelTab1.Size = New System.Drawing.Size(493, 170)
        Me.panelTab1.TabIndex = 26
        '
        'imgSStateManPicsPathStatus
        '
        Me.imgSStateManPicsPathStatus.Image = Global.sstatesman.My.Resources.Resources.Metro_Button_Exclamation
        Me.imgSStateManPicsPathStatus.Location = New System.Drawing.Point(11, 140)
        Me.imgSStateManPicsPathStatus.Name = "imgSStateManPicsPathStatus"
        Me.imgSStateManPicsPathStatus.Size = New System.Drawing.Size(28, 25)
        Me.imgSStateManPicsPathStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgSStateManPicsPathStatus.TabIndex = 2
        Me.imgSStateManPicsPathStatus.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 21)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Theme options"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 21)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Savestates deletion"
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.BackgroundImage = Global.sstatesman.My.Resources.Resources.Bg2
        Me.panelWindowTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelWindowTitle.Controls.Add(Me.optStettingTab2)
        Me.panelWindowTitle.Controls.Add(Me.optStettingTab1)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowTitle)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(520, 70)
        Me.panelWindowTitle.TabIndex = 14
        '
        'optStettingTab2
        '
        Me.optStettingTab2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optStettingTab2.AutoSize = True
        Me.optStettingTab2.BackColor = System.Drawing.Color.Transparent
        Me.optStettingTab2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.optStettingTab2.FlatAppearance.BorderSize = 0
        Me.optStettingTab2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.optStettingTab2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optStettingTab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optStettingTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optStettingTab2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStettingTab2.Location = New System.Drawing.Point(122, 47)
        Me.optStettingTab2.Name = "optStettingTab2"
        Me.optStettingTab2.Size = New System.Drawing.Size(88, 23)
        Me.optStettingTab2.TabIndex = 27
        Me.optStettingTab2.Text = "PCSX2 PATHS"
        Me.optStettingTab2.UseVisualStyleBackColor = False
        '
        'optStettingTab1
        '
        Me.optStettingTab1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optStettingTab1.AutoSize = True
        Me.optStettingTab1.BackColor = System.Drawing.Color.Transparent
        Me.optStettingTab1.Checked = True
        Me.optStettingTab1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.optStettingTab1.FlatAppearance.BorderSize = 0
        Me.optStettingTab1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.optStettingTab1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.optStettingTab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optStettingTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optStettingTab1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStettingTab1.Location = New System.Drawing.Point(30, 47)
        Me.optStettingTab1.Name = "optStettingTab1"
        Me.optStettingTab1.Size = New System.Drawing.Size(89, 23)
        Me.optStettingTab1.TabIndex = 26
        Me.optStettingTab1.TabStop = True
        Me.optStettingTab1.Text = "SSTATESMAN"
        Me.optStettingTab1.UseVisualStyleBackColor = False
        '
        'lblWindowProgramName
        '
        Me.lblWindowProgramName.AutoSize = True
        Me.lblWindowProgramName.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowProgramName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowProgramName.Location = New System.Drawing.Point(8, 4)
        Me.lblWindowProgramName.Name = "lblWindowProgramName"
        Me.lblWindowProgramName.Size = New System.Drawing.Size(79, 13)
        Me.lblWindowProgramName.TabIndex = 2
        Me.lblWindowProgramName.Text = "SSTATESMAN"
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
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(30, 24)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(66, 21)
        Me.lblWindowTitle.TabIndex = 3
        Me.lblWindowTitle.Text = "Settings"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(520, 590)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelTab1)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelTab2)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 440)
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.panelTab2.ResumeLayout(False)
        Me.panelTab2.PerformLayout()
        CType(Me.imgPCSX2SStatePathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgPCSX2IniPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgPCSX2AppPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelBottom.ResumeLayout(False)
        Me.panelTab1.ResumeLayout(False)
        Me.panelTab1.PerformLayout()
        CType(Me.imgSStateManPicsPathStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Friend WithEvents lblWindowTitle As System.Windows.Forms.Label
    Friend WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents ckbFirstRun As System.Windows.Forms.CheckBox
    Friend WithEvents ckbSStatesManMoveToTrash As System.Windows.Forms.CheckBox
    Friend WithEvents lblSStateManPicsPath As System.Windows.Forms.Label
    Private WithEvents txtSStateManPicsPath As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdSStateManPicsPathBrowse As System.Windows.Forms.Button
    Friend WithEvents ckbSStatesManBGEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblSStateManPicsPathStatus As System.Windows.Forms.Label
    Friend WithEvents optStettingTab1 As System.Windows.Forms.RadioButton
    Friend WithEvents panelTab2 As System.Windows.Forms.Panel
    Friend WithEvents lblPCSX2SStatePathStatus As System.Windows.Forms.Label
    Friend WithEvents lblPCSX2IniPathStatus As System.Windows.Forms.Label
    Friend WithEvents lblPCSX2AppPathStatus As System.Windows.Forms.Label
    Friend WithEvents cmdPCSX2SStatePathBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdPCSX2IniPathBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdPCSX2AppPathBrowse As System.Windows.Forms.Button
    Friend WithEvents lblPCSX2SStatePath As System.Windows.Forms.Label
    Private WithEvents txtPCSX2SStatePath As System.Windows.Forms.TextBox
    Friend WithEvents lblPCSX2IniPath As System.Windows.Forms.Label
    Friend WithEvents lblPCSX2AppPath As System.Windows.Forms.Label
    Friend WithEvents txtPCSX2IniPath As System.Windows.Forms.TextBox
    Private WithEvents txtPCSX2AppPath As System.Windows.Forms.TextBox
    Friend WithEvents panelBottom As System.Windows.Forms.Panel
    Friend WithEvents optStettingTab2 As System.Windows.Forms.RadioButton
    Friend WithEvents panelTab1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgSStateManPicsPathStatus As System.Windows.Forms.PictureBox
    Friend WithEvents imgPCSX2SStatePathStatus As System.Windows.Forms.PictureBox
    Friend WithEvents imgPCSX2IniPathStatus As System.Windows.Forms.PictureBox
    Friend WithEvents imgPCSX2AppPathStatus As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
