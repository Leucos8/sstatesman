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
Partial Class frmChooseVersion
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
        Me.lblWindowProgramName = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.pnlWindowTitle = New System.Windows.Forms.Panel()
        Me.lbPCSX2exe = New System.Windows.Forms.ListBox()
        Me.lblPlease = New System.Windows.Forms.Label()
        Me.lblTroubleshoot = New System.Windows.Forms.Label()
        Me.pnlWindowContent = New System.Windows.Forms.TableLayoutPanel()
        Me.flpWindowBottom.SuspendLayout()
        Me.pnlWindowTitle.SuspendLayout()
        Me.pnlWindowContent.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblWindowProgramName.Size = New System.Drawing.Size(118, 30)
        Me.lblWindowProgramName.TabIndex = 1
        Me.lblWindowProgramName.Text = "launch PCSX2"
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
        Me.cmdOk.Location = New System.Drawing.Point(94, 6)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOk.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 24)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.BackColor = System.Drawing.Color.Gainsboro
        Me.flpWindowBottom.Controls.Add(Me.cmdCancel)
        Me.flpWindowBottom.Controls.Add(Me.cmdOk)
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 250)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4)
        Me.flpWindowBottom.Size = New System.Drawing.Size(308, 36)
        Me.flpWindowBottom.TabIndex = 9
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
        Me.cmdCancel.Location = New System.Drawing.Point(198, 6)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'pnlWindowTitle
        '
        Me.pnlWindowTitle.AutoSize = True
        Me.pnlWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.pnlWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.pnlWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlWindowTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWindowTitle.MinimumSize = New System.Drawing.Size(0, 48)
        Me.pnlWindowTitle.Name = "pnlWindowTitle"
        Me.pnlWindowTitle.Size = New System.Drawing.Size(308, 48)
        Me.pnlWindowTitle.TabIndex = 8
        '
        'lbPCSX2exe
        '
        Me.lbPCSX2exe.BackColor = System.Drawing.Color.White
        Me.lbPCSX2exe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPCSX2exe.ForeColor = System.Drawing.Color.Black
        Me.lbPCSX2exe.FormattingEnabled = True
        Me.lbPCSX2exe.Location = New System.Drawing.Point(9, 26)
        Me.lbPCSX2exe.Name = "lbPCSX2exe"
        Me.lbPCSX2exe.Size = New System.Drawing.Size(290, 102)
        Me.lbPCSX2exe.TabIndex = 10
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
        Me.lblTroubleshoot.AutoSize = True
        Me.lblTroubleshoot.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTroubleshoot.ForeColor = System.Drawing.Color.DimGray
        Me.lblTroubleshoot.Location = New System.Drawing.Point(9, 131)
        Me.lblTroubleshoot.Name = "lblTroubleshoot"
        Me.lblTroubleshoot.Size = New System.Drawing.Size(290, 65)
        Me.lblTroubleshoot.TabIndex = 13
        Me.lblTroubleshoot.Text = "If your current PCSX2 version is not listed here then:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1. check you currently co" & _
    "nfigured PCSX2 path in Settings > PCSX2 paths," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. make sure the PCSX2 executabl" & _
    "e file name starts with ""PCSX2""."
        '
        'pnlWindowContent
        '
        Me.pnlWindowContent.AutoSize = True
        Me.pnlWindowContent.ColumnCount = 1
        Me.pnlWindowContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlWindowContent.Controls.Add(Me.lblTroubleshoot, 0, 2)
        Me.pnlWindowContent.Controls.Add(Me.lbPCSX2exe, 0, 1)
        Me.pnlWindowContent.Controls.Add(Me.lblPlease, 0, 0)
        Me.pnlWindowContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWindowContent.Location = New System.Drawing.Point(0, 48)
        Me.pnlWindowContent.Name = "pnlWindowContent"
        Me.pnlWindowContent.Padding = New System.Windows.Forms.Padding(6)
        Me.pnlWindowContent.RowCount = 3
        Me.pnlWindowContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlWindowContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlWindowContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlWindowContent.Size = New System.Drawing.Size(308, 202)
        Me.pnlWindowContent.TabIndex = 13
        '
        'frmChooseVersion
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(308, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlWindowContent)
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Controls.Add(Me.pnlWindowTitle)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChooseVersion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PCSX2"
        Me.flpWindowBottom.ResumeLayout(False)
        Me.flpWindowBottom.PerformLayout()
        Me.pnlWindowTitle.ResumeLayout(False)
        Me.pnlWindowTitle.PerformLayout()
        Me.pnlWindowContent.ResumeLayout(False)
        Me.pnlWindowContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents pnlWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents lbPCSX2exe As System.Windows.Forms.ListBox
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblPlease As System.Windows.Forms.Label
    Friend WithEvents lblTroubleshoot As System.Windows.Forms.Label
    Friend WithEvents pnlWindowContent As System.Windows.Forms.TableLayoutPanel
End Class
