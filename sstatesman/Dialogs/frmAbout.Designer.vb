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
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.OKButton = New System.Windows.Forms.Button()
        Me.flpTab = New System.Windows.Forms.FlowLayoutPanel()
        Me.optTabHeader0 = New System.Windows.Forms.RadioButton()
        Me.optTabHeader1 = New System.Windows.Forms.RadioButton()
        Me.optTabHeader2 = New System.Windows.Forms.RadioButton()
        Me.pnlTab0 = New System.Windows.Forms.Panel()
        Me.llbPCSX2net = New System.Windows.Forms.LinkLabel()
        Me.llbPCSX2Forum = New System.Windows.Forms.LinkLabel()
        Me.lblLinksTitle = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.llbAuthor = New System.Windows.Forms.LinkLabel()
        Me.lblAuthorTitle = New System.Windows.Forms.Label()
        Me.lblVersionChannel = New System.Windows.Forms.Label()
        Me.lblVersionMain = New System.Windows.Forms.Label()
        Me.lblVersionTitle = New System.Windows.Forms.Label()
        Me.pnlTab2 = New System.Windows.Forms.Panel()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.pnlTab1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.flpTab.SuspendLayout()
        Me.pnlTab0.SuspendLayout()
        Me.pnlTab2.SuspendLayout()
        Me.pnlTab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlWindowTop.Size = New System.Drawing.Size(414, 46)
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.AutoSize = True
        Me.OKButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.OKButton.BackColor = System.Drawing.Color.White
        Me.OKButton.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OKButton.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKButton.Location = New System.Drawing.Point(303, 235)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(2)
        Me.OKButton.MinimumSize = New System.Drawing.Size(100, 0)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 24)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'flpTab
        '
        Me.flpTab.AutoSize = True
        Me.flpTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTab.BackColor = System.Drawing.Color.Transparent
        Me.flpTab.Controls.Add(Me.optTabHeader0)
        Me.flpTab.Controls.Add(Me.optTabHeader1)
        Me.flpTab.Controls.Add(Me.optTabHeader2)
        Me.flpTab.Location = New System.Drawing.Point(4, 33)
        Me.flpTab.Margin = New System.Windows.Forms.Padding(0)
        Me.flpTab.Name = "flpTab"
        Me.flpTab.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.flpTab.Size = New System.Drawing.Size(272, 23)
        Me.flpTab.TabIndex = 1
        Me.flpTab.WrapContents = False
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
        Me.optTabHeader0.TabIndex = 0
        Me.optTabHeader0.TabStop = True
        Me.optTabHeader0.Text = "sstatesman"
        Me.optTabHeader0.UseVisualStyleBackColor = False
        '
        'optTabHeader1
        '
        Me.optTabHeader1.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader1.AutoSize = True
        Me.optTabHeader1.FlatAppearance.BorderSize = 0
        Me.optTabHeader1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader1.Location = New System.Drawing.Point(96, 0)
        Me.optTabHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader1.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader1.Name = "optTabHeader1"
        Me.optTabHeader1.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader1.TabIndex = 1
        Me.optTabHeader1.Text = "thanks"
        Me.optTabHeader1.UseVisualStyleBackColor = False
        '
        'optTabHeader2
        '
        Me.optTabHeader2.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.optTabHeader2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTabHeader2.AutoSize = True
        Me.optTabHeader2.FlatAppearance.BorderSize = 0
        Me.optTabHeader2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.optTabHeader2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.optTabHeader2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTabHeader2.Location = New System.Drawing.Point(176, 0)
        Me.optTabHeader2.Margin = New System.Windows.Forms.Padding(0)
        Me.optTabHeader2.MinimumSize = New System.Drawing.Size(80, 0)
        Me.optTabHeader2.Name = "optTabHeader2"
        Me.optTabHeader2.Size = New System.Drawing.Size(80, 23)
        Me.optTabHeader2.TabIndex = 2
        Me.optTabHeader2.Text = "licence"
        Me.optTabHeader2.UseVisualStyleBackColor = False
        '
        'pnlTab0
        '
        Me.pnlTab0.AutoScroll = True
        Me.pnlTab0.Controls.Add(Me.llbPCSX2net)
        Me.pnlTab0.Controls.Add(Me.llbPCSX2Forum)
        Me.pnlTab0.Controls.Add(Me.lblLinksTitle)
        Me.pnlTab0.Controls.Add(Me.lblCopyright)
        Me.pnlTab0.Controls.Add(Me.llbAuthor)
        Me.pnlTab0.Controls.Add(Me.lblAuthorTitle)
        Me.pnlTab0.Controls.Add(Me.lblVersionChannel)
        Me.pnlTab0.Controls.Add(Me.lblVersionMain)
        Me.pnlTab0.Controls.Add(Me.lblVersionTitle)
        Me.pnlTab0.Location = New System.Drawing.Point(4, 59)
        Me.pnlTab0.Name = "pnlTab0"
        Me.pnlTab0.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.pnlTab0.Size = New System.Drawing.Size(134, 172)
        Me.pnlTab0.TabIndex = 2
        '
        'llbPCSX2net
        '
        Me.llbPCSX2net.AutoSize = True
        Me.llbPCSX2net.Dock = System.Windows.Forms.DockStyle.Top
        Me.llbPCSX2net.LinkColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.llbPCSX2net.Location = New System.Drawing.Point(6, 151)
        Me.llbPCSX2net.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.llbPCSX2net.Name = "llbPCSX2net"
        Me.llbPCSX2net.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.llbPCSX2net.Size = New System.Drawing.Size(210, 17)
        Me.llbPCSX2net.TabIndex = 8
        Me.llbPCSX2net.TabStop = True
        Me.llbPCSX2net.Text = "PCSX2.net Tools > Frontends section."
        '
        'llbPCSX2Forum
        '
        Me.llbPCSX2Forum.AutoSize = True
        Me.llbPCSX2Forum.Dock = System.Windows.Forms.DockStyle.Top
        Me.llbPCSX2Forum.LinkColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.llbPCSX2Forum.Location = New System.Drawing.Point(6, 134)
        Me.llbPCSX2Forum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.llbPCSX2Forum.Name = "llbPCSX2Forum"
        Me.llbPCSX2Forum.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.llbPCSX2Forum.Size = New System.Drawing.Size(186, 17)
        Me.llbPCSX2Forum.TabIndex = 7
        Me.llbPCSX2Forum.TabStop = True
        Me.llbPCSX2Forum.Text = "Official Thread on PCSX2 Forums"
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
        Me.lblLinksTitle.TabIndex = 6
        Me.lblLinksTitle.Text = "Links"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCopyright.Location = New System.Drawing.Point(6, 96)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblCopyright.Size = New System.Drawing.Size(84, 17)
        Me.lblCopyright.TabIndex = 5
        Me.lblCopyright.Text = "<copyright>"
        '
        'llbAuthor
        '
        Me.llbAuthor.AutoSize = True
        Me.llbAuthor.Dock = System.Windows.Forms.DockStyle.Top
        Me.llbAuthor.LinkColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.llbAuthor.Location = New System.Drawing.Point(6, 79)
        Me.llbAuthor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.llbAuthor.Name = "llbAuthor"
        Me.llbAuthor.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.llbAuthor.Size = New System.Drawing.Size(70, 17)
        Me.llbAuthor.TabIndex = 4
        Me.llbAuthor.TabStop = True
        Me.llbAuthor.Text = "<author>"
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
        Me.lblAuthorTitle.TabIndex = 3
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
        Me.lblVersionChannel.Size = New System.Drawing.Size(76, 17)
        Me.lblVersionChannel.TabIndex = 2
        Me.lblVersionChannel.Text = "<channel>"
        '
        'lblVersionMain
        '
        Me.lblVersionMain.AutoSize = True
        Me.lblVersionMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersionMain.Location = New System.Drawing.Point(6, 24)
        Me.lblVersionMain.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVersionMain.Name = "lblVersionMain"
        Me.lblVersionMain.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblVersionMain.Size = New System.Drawing.Size(72, 17)
        Me.lblVersionMain.TabIndex = 1
        Me.lblVersionMain.Text = "<version>"
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
        Me.lblVersionTitle.TabIndex = 0
        Me.lblVersionTitle.Text = "Version information"
        '
        'pnlTab2
        '
        Me.pnlTab2.Controls.Add(Me.TextBoxDescription)
        Me.pnlTab2.Location = New System.Drawing.Point(246, 59)
        Me.pnlTab2.Name = "pnlTab2"
        Me.pnlTab2.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.pnlTab2.Size = New System.Drawing.Size(109, 172)
        Me.pnlTab2.TabIndex = 4
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
        Me.TextBoxDescription.Size = New System.Drawing.Size(97, 166)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'pnlTab1
        '
        Me.pnlTab1.Controls.Add(Me.TextBox1)
        Me.pnlTab1.Location = New System.Drawing.Point(144, 59)
        Me.pnlTab1.Name = "pnlTab1"
        Me.pnlTab1.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.pnlTab1.Size = New System.Drawing.Size(96, 172)
        Me.pnlTab1.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(6, 3)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(84, 166)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(414, 272)
        Me.Controls.Add(Me.pnlTab2)
        Me.Controls.Add(Me.pnlTab1)
        Me.Controls.Add(Me.pnlTab0)
        Me.Controls.Add(Me.flpTab)
        Me.Controls.Add(Me.OKButton)
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.Name = "frmAbout"
        Me.Text = "About"
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.OKButton, 0)
        Me.Controls.SetChildIndex(Me.flpTab, 0)
        Me.Controls.SetChildIndex(Me.pnlTab0, 0)
        Me.Controls.SetChildIndex(Me.pnlTab1, 0)
        Me.Controls.SetChildIndex(Me.pnlTab2, 0)
        Me.flpTab.ResumeLayout(False)
        Me.flpTab.PerformLayout()
        Me.pnlTab0.ResumeLayout(False)
        Me.pnlTab0.PerformLayout()
        Me.pnlTab2.ResumeLayout(False)
        Me.pnlTab2.PerformLayout()
        Me.pnlTab1.ResumeLayout(False)
        Me.pnlTab1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents optTabHeader0 As System.Windows.Forms.RadioButton
    Private WithEvents optTabHeader2 As System.Windows.Forms.RadioButton
    Private WithEvents OKButton As System.Windows.Forms.Button
    Private WithEvents flpTab As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents pnlTab0 As System.Windows.Forms.Panel
    Private WithEvents llbPCSX2Forum As System.Windows.Forms.LinkLabel
    Private WithEvents lblLinksTitle As System.Windows.Forms.Label
    Private WithEvents lblCopyright As System.Windows.Forms.Label
    Private WithEvents lblAuthorTitle As System.Windows.Forms.Label
    Private WithEvents lblVersionChannel As System.Windows.Forms.Label
    Private WithEvents lblVersionMain As System.Windows.Forms.Label
    Private WithEvents lblVersionTitle As System.Windows.Forms.Label
    Private WithEvents pnlTab2 As System.Windows.Forms.Panel
    Private WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Private WithEvents optTabHeader1 As System.Windows.Forms.RadioButton
    Private WithEvents pnlTab1 As System.Windows.Forms.Panel
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents llbPCSX2net As System.Windows.Forms.LinkLabel
    Private WithEvents llbAuthor As System.Windows.Forms.LinkLabel

End Class
