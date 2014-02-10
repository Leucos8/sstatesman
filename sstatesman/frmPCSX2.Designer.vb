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
Partial Class frmPCSX2
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
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lbPCSX2Bin = New System.Windows.Forms.ListBox()
        Me.lblPlease = New System.Windows.Forms.Label()
        Me.lblTroubleshoot = New System.Windows.Forms.Label()
        Me.tlpFormContent = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSStatesManPathIso = New System.Windows.Forms.TextBox()
        Me.lblIsoPath = New System.Windows.Forms.Label()
        Me.txtPCSX2PathBin = New System.Windows.Forms.TextBox()
        Me.tlpFormContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlWindowTop.Size = New System.Drawing.Size(404, 46)
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.AutoSize = True
        Me.cmdOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdOk.BackColor = System.Drawing.Color.White
        Me.cmdOk.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Enabled = False
        Me.cmdOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(185, 286)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOk.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 24)
        Me.cmdOk.TabIndex = 6
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
        Me.cmdCancel.Location = New System.Drawing.Point(293, 286)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lbPCSX2Bin
        '
        Me.lbPCSX2Bin.BackColor = System.Drawing.Color.White
        Me.lbPCSX2Bin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPCSX2Bin.ForeColor = System.Drawing.Color.Black
        Me.lbPCSX2Bin.FormattingEnabled = True
        Me.lbPCSX2Bin.Location = New System.Drawing.Point(9, 26)
        Me.lbPCSX2Bin.Name = "lbPCSX2Bin"
        Me.lbPCSX2Bin.Size = New System.Drawing.Size(302, 96)
        Me.lbPCSX2Bin.TabIndex = 10
        '
        'lblPlease
        '
        Me.lblPlease.AutoSize = True
        Me.lblPlease.Location = New System.Drawing.Point(9, 6)
        Me.lblPlease.Name = "lblPlease"
        Me.lblPlease.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblPlease.Size = New System.Drawing.Size(253, 17)
        Me.lblPlease.TabIndex = 12
        Me.lblPlease.Text = "Select which version of PCSX2 you want to start."
        '
        'lblTroubleshoot
        '
        Me.lblTroubleshoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTroubleshoot.ForeColor = System.Drawing.Color.DimGray
        Me.lblTroubleshoot.Location = New System.Drawing.Point(9, 153)
        Me.lblTroubleshoot.Name = "lblTroubleshoot"
        Me.lblTroubleshoot.Size = New System.Drawing.Size(302, 23)
        Me.lblTroubleshoot.TabIndex = 13
        Me.lblTroubleshoot.Text = "You can change the configured PCSX2 path in Config > Settings > PCSX2 paths tab. " & _
    "In order to be listed here, PCSX2 executables must have a filename starting with" & _
    " ""PCSX2""."
        '
        'tlpFormContent
        '
        Me.tlpFormContent.AutoSize = True
        Me.tlpFormContent.ColumnCount = 1
        Me.tlpFormContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFormContent.Controls.Add(Me.txtSStatesManPathIso, 0, 5)
        Me.tlpFormContent.Controls.Add(Me.lblIsoPath, 0, 4)
        Me.tlpFormContent.Controls.Add(Me.lblTroubleshoot, 0, 3)
        Me.tlpFormContent.Controls.Add(Me.lbPCSX2Bin, 0, 1)
        Me.tlpFormContent.Controls.Add(Me.lblPlease, 0, 0)
        Me.tlpFormContent.Controls.Add(Me.txtPCSX2PathBin, 0, 2)
        Me.tlpFormContent.Location = New System.Drawing.Point(11, 52)
        Me.tlpFormContent.Name = "tlpFormContent"
        Me.tlpFormContent.Padding = New System.Windows.Forms.Padding(6)
        Me.tlpFormContent.RowCount = 6
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFormContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFormContent.Size = New System.Drawing.Size(320, 231)
        Me.tlpFormContent.TabIndex = 13
        '
        'txtSStatesManPathIso
        '
        Me.txtSStatesManPathIso.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSStatesManPathIso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSStatesManPathIso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSStatesManPathIso.Location = New System.Drawing.Point(9, 200)
        Me.txtSStatesManPathIso.Name = "txtSStatesManPathIso"
        Me.txtSStatesManPathIso.Size = New System.Drawing.Size(302, 22)
        Me.txtSStatesManPathIso.TabIndex = 17
        '
        'lblIsoPath
        '
        Me.lblIsoPath.AutoSize = True
        Me.lblIsoPath.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIsoPath.Location = New System.Drawing.Point(9, 176)
        Me.lblIsoPath.Name = "lblIsoPath"
        Me.lblIsoPath.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblIsoPath.Size = New System.Drawing.Size(123, 21)
        Me.lblIsoPath.TabIndex = 15
        Me.lblIsoPath.Text = "Disc image file path"
        '
        'txtPCSX2PathBin
        '
        Me.txtPCSX2PathBin.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPCSX2PathBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPCSX2PathBin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPCSX2PathBin.Location = New System.Drawing.Point(9, 128)
        Me.txtPCSX2PathBin.Name = "txtPCSX2PathBin"
        Me.txtPCSX2PathBin.Size = New System.Drawing.Size(302, 22)
        Me.txtPCSX2PathBin.TabIndex = 16
        '
        'frmPCSX2
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoSize = True
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(404, 321)
        Me.Controls.Add(Me.tlpFormContent)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmPCSX2"
        Me.Text = "Launch PCSX2"
        Me.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.pnlWindowTop, 0)
        Me.Controls.SetChildIndex(Me.tlpFormContent, 0)
        Me.tlpFormContent.ResumeLayout(False)
        Me.tlpFormContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cmdOk As System.Windows.Forms.Button
    Private WithEvents lbPCSX2Bin As System.Windows.Forms.ListBox
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents lblPlease As System.Windows.Forms.Label
    Private WithEvents lblTroubleshoot As System.Windows.Forms.Label
    Private WithEvents tlpFormContent As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblIsoPath As System.Windows.Forms.Label
    Private WithEvents txtPCSX2PathBin As System.Windows.Forms.TextBox
    Private WithEvents txtSStatesManPathIso As System.Windows.Forms.TextBox
End Class
