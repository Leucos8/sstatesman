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
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lblAuthorName = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblVersionMain = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.flpTab = New System.Windows.Forms.FlowLayoutPanel()
        Me.optSettingTab1 = New System.Windows.Forms.RadioButton()
        Me.optSettingTab2 = New System.Windows.Forms.RadioButton()
        Me.lblWindowProgramName = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblLinksTitle = New System.Windows.Forms.Label()
        Me.lblAuthorTitle = New System.Windows.Forms.Label()
        Me.lblVersionChannel = New System.Windows.Forms.Label()
        Me.lblVersionTitle = New System.Windows.Forms.Label()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.flpWindowBottom.SuspendLayout()
        Me.flpTab.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.panelWindowTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 134)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.LinkLabel1.Size = New System.Drawing.Size(186, 17)
        Me.LinkLabel1.TabIndex = 15
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Official Thread on PCSX2 Forums"
        '
        'lblAuthorName
        '
        Me.lblAuthorName.AutoSize = True
        Me.lblAuthorName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAuthorName.Location = New System.Drawing.Point(6, 79)
        Me.lblAuthorName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAuthorName.Name = "lblAuthorName"
        Me.lblAuthorName.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblAuthorName.Size = New System.Drawing.Size(110, 17)
        Me.lblAuthorName.TabIndex = 12
        Me.lblAuthorName.Text = "<Author's name>"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCopyright.Location = New System.Drawing.Point(6, 96)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblCopyright.Size = New System.Drawing.Size(86, 17)
        Me.lblCopyright.TabIndex = 13
        Me.lblCopyright.Text = "<Copyright>"
        '
        'lblVersionMain
        '
        Me.lblVersionMain.AutoSize = True
        Me.lblVersionMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersionMain.Location = New System.Drawing.Point(6, 24)
        Me.lblVersionMain.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVersionMain.Name = "lblVersionMain"
        Me.lblVersionMain.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblVersionMain.Size = New System.Drawing.Size(105, 17)
        Me.lblVersionMain.TabIndex = 9
        Me.lblVersionMain.Text = "<Major version>"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.ForeColor = System.Drawing.Color.Black
        Me.TextBoxDescription.Location = New System.Drawing.Point(6, 3)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(196, 177)
        Me.TextBoxDescription.TabIndex = 16
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.AutoSize = True
        Me.OKButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.OKButton.BackColor = System.Drawing.Color.White
        Me.OKButton.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OKButton.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKButton.Location = New System.Drawing.Point(304, 6)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(2)
        Me.OKButton.MinimumSize = New System.Drawing.Size(100, 0)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 24)
        Me.OKButton.TabIndex = 6
        Me.OKButton.Text = "&OK"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.BackColor = System.Drawing.Color.Gainsboro
        Me.flpWindowBottom.Controls.Add(Me.OKButton)
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 236)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4)
        Me.flpWindowBottom.Size = New System.Drawing.Size(414, 36)
        Me.flpWindowBottom.TabIndex = 5
        '
        'flpTab
        '
        Me.flpTab.AutoSize = True
        Me.flpTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTab.BackColor = System.Drawing.Color.Transparent
        Me.flpTab.Controls.Add(Me.optSettingTab1)
        Me.flpTab.Controls.Add(Me.optSettingTab2)
        Me.flpTab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpTab.Location = New System.Drawing.Point(0, 30)
        Me.flpTab.Margin = New System.Windows.Forms.Padding(0)
        Me.flpTab.Name = "flpTab"
        Me.flpTab.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.flpTab.Size = New System.Drawing.Size(414, 23)
        Me.flpTab.TabIndex = 2
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
        Me.optSettingTab1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optSettingTab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.optSettingTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab1.Location = New System.Drawing.Point(16, 0)
        Me.optSettingTab1.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab1.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optSettingTab1.Name = "optSettingTab1"
        Me.optSettingTab1.Size = New System.Drawing.Size(80, 23)
        Me.optSettingTab1.TabIndex = 3
        Me.optSettingTab1.TabStop = True
        Me.optSettingTab1.Text = "sstatesman"
        Me.optSettingTab1.UseVisualStyleBackColor = False
        '
        'optSettingTab2
        '
        Me.optSettingTab2.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optSettingTab2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSettingTab2.AutoSize = True
        Me.optSettingTab2.FlatAppearance.BorderSize = 0
        Me.optSettingTab2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optSettingTab2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optSettingTab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.optSettingTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSettingTab2.Location = New System.Drawing.Point(96, 0)
        Me.optSettingTab2.Margin = New System.Windows.Forms.Padding(0)
        Me.optSettingTab2.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optSettingTab2.Name = "optSettingTab2"
        Me.optSettingTab2.Size = New System.Drawing.Size(80, 23)
        Me.optSettingTab2.TabIndex = 4
        Me.optSettingTab2.Text = "licence"
        Me.optSettingTab2.UseVisualStyleBackColor = False
        '
        'lblWindowProgramName
        '
        Me.lblWindowProgramName.AutoSize = True
        Me.lblWindowProgramName.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowProgramName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWindowProgramName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowProgramName.Location = New System.Drawing.Point(0, 0)
        Me.lblWindowProgramName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 3)
        Me.lblWindowProgramName.Name = "lblWindowProgramName"
        Me.lblWindowProgramName.Padding = New System.Windows.Forms.Padding(6, 6, 6, 3)
        Me.lblWindowProgramName.Size = New System.Drawing.Size(62, 30)
        Me.lblWindowProgramName.TabIndex = 1
        Me.lblWindowProgramName.Text = "about"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 53)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.LinkLabel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblLinksTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCopyright)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAuthorName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAuthorTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblVersionChannel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblVersionMain)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblVersionTitle)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxDescription)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.SplitContainer1.Size = New System.Drawing.Size(414, 183)
        Me.SplitContainer1.SplitterDistance = 203
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 7
        '
        'lblLinksTitle
        '
        Me.lblLinksTitle.AutoSize = True
        Me.lblLinksTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLinksTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinksTitle.Location = New System.Drawing.Point(6, 113)
        Me.lblLinksTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLinksTitle.Name = "lblLinksTitle"
        Me.lblLinksTitle.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblLinksTitle.Size = New System.Drawing.Size(36, 21)
        Me.lblLinksTitle.TabIndex = 14
        Me.lblLinksTitle.Text = "Links"
        '
        'lblAuthorTitle
        '
        Me.lblAuthorTitle.AutoSize = True
        Me.lblAuthorTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAuthorTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthorTitle.Location = New System.Drawing.Point(6, 58)
        Me.lblAuthorTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAuthorTitle.Name = "lblAuthorTitle"
        Me.lblAuthorTitle.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblAuthorTitle.Size = New System.Drawing.Size(47, 21)
        Me.lblAuthorTitle.TabIndex = 11
        Me.lblAuthorTitle.Text = "Author"
        '
        'lblVersionChannel
        '
        Me.lblVersionChannel.AutoSize = True
        Me.lblVersionChannel.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersionChannel.Location = New System.Drawing.Point(6, 41)
        Me.lblVersionChannel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVersionChannel.Name = "lblVersionChannel"
        Me.lblVersionChannel.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblVersionChannel.Size = New System.Drawing.Size(118, 17)
        Me.lblVersionChannel.TabIndex = 10
        Me.lblVersionChannel.Text = "<Release channel>"
        '
        'lblVersionTitle
        '
        Me.lblVersionTitle.AutoSize = True
        Me.lblVersionTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersionTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionTitle.Location = New System.Drawing.Point(6, 3)
        Me.lblVersionTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVersionTitle.Name = "lblVersionTitle"
        Me.lblVersionTitle.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblVersionTitle.Size = New System.Drawing.Size(123, 21)
        Me.lblVersionTitle.TabIndex = 8
        Me.lblVersionTitle.Text = "Version information"
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.AutoSize = True
        Me.panelWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.panelWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.panelWindowTitle.Controls.Add(Me.flpTab)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.panelWindowTitle.MinimumSize = New System.Drawing.Size(0, 26)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(414, 53)
        Me.panelWindowTitle.TabIndex = 0
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(414, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSMico_v1_256x256
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.flpWindowBottom.ResumeLayout(False)
        Me.flpWindowBottom.PerformLayout()
        Me.flpTab.ResumeLayout(False)
        Me.flpTab.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthorName As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblVersionMain As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flpTab As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents optSettingTab1 As System.Windows.Forms.RadioButton
    Private WithEvents optSettingTab2 As System.Windows.Forms.RadioButton
    Private WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblVersionTitle As System.Windows.Forms.Label
    Friend WithEvents lblVersionChannel As System.Windows.Forms.Label
    Friend WithEvents lblLinksTitle As System.Windows.Forms.Label
    Friend WithEvents lblAuthorTitle As System.Windows.Forms.Label
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel

End Class
