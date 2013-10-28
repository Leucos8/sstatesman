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
Partial Class frmTemplate
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
        Me.tlpWindowTop = New System.Windows.Forms.TableLayoutPanel()
        Me.flpControlBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.ControlBoxMinimize = New System.Windows.Forms.Button()
        Me.ControlBoxMaximize = New System.Windows.Forms.Button()
        Me.ControlBoxClose = New System.Windows.Forms.Button()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.flpTitleBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.lblWindowDescription = New System.Windows.Forms.Label()
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlWindowTop = New System.Windows.Forms.Panel()
        Me.tlpWindowTop.SuspendLayout()
        Me.flpControlBox.SuspendLayout()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpTitleBar.SuspendLayout()
        Me.pnlWindowTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpWindowTop
        '
        Me.tlpWindowTop.AutoSize = True
        Me.tlpWindowTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpWindowTop.BackColor = System.Drawing.Color.Transparent
        Me.tlpWindowTop.ColumnCount = 4
        Me.tlpWindowTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWindowTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWindowTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWindowTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWindowTop.Controls.Add(Me.flpControlBox, 3, 0)
        Me.tlpWindowTop.Controls.Add(Me.imgWindowGradientIcon, 2, 0)
        Me.tlpWindowTop.Controls.Add(Me.flpTitleBar, 0, 0)
        Me.tlpWindowTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpWindowTop.Location = New System.Drawing.Point(0, 0)
        Me.tlpWindowTop.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpWindowTop.MinimumSize = New System.Drawing.Size(0, 48)
        Me.tlpWindowTop.Name = "tlpWindowTop"
        Me.tlpWindowTop.RowCount = 3
        Me.tlpWindowTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWindowTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWindowTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWindowTop.Size = New System.Drawing.Size(632, 48)
        Me.tlpWindowTop.TabIndex = 4
        '
        'flpControlBox
        '
        Me.flpControlBox.AutoSize = True
        Me.flpControlBox.Controls.Add(Me.ControlBoxMinimize)
        Me.flpControlBox.Controls.Add(Me.ControlBoxMaximize)
        Me.flpControlBox.Controls.Add(Me.ControlBoxClose)
        Me.flpControlBox.Location = New System.Drawing.Point(529, 0)
        Me.flpControlBox.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.flpControlBox.Name = "flpControlBox"
        Me.flpControlBox.Size = New System.Drawing.Size(97, 20)
        Me.flpControlBox.TabIndex = 23
        Me.flpControlBox.WrapContents = False
        '
        'ControlBoxMinimize
        '
        Me.ControlBoxMinimize.BackColor = System.Drawing.Color.Transparent
        Me.ControlBoxMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ControlBoxMinimize.FlatAppearance.BorderSize = 0
        Me.ControlBoxMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ControlBoxMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ControlBoxMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ControlBoxMinimize.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ControlBoxMinimize.Image = Global.sstatesman.My.Resources.Resources.Window_ButtonMinimize
        Me.ControlBoxMinimize.Location = New System.Drawing.Point(0, 0)
        Me.ControlBoxMinimize.Margin = New System.Windows.Forms.Padding(0)
        Me.ControlBoxMinimize.Name = "ControlBoxMinimize"
        Me.ControlBoxMinimize.Size = New System.Drawing.Size(26, 20)
        Me.ControlBoxMinimize.TabIndex = 8
        Me.ControlBoxMinimize.UseVisualStyleBackColor = False
        '
        'ControlBoxMaximize
        '
        Me.ControlBoxMaximize.BackColor = System.Drawing.Color.Transparent
        Me.ControlBoxMaximize.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ControlBoxMaximize.FlatAppearance.BorderSize = 0
        Me.ControlBoxMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ControlBoxMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ControlBoxMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ControlBoxMaximize.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ControlBoxMaximize.Image = Global.sstatesman.My.Resources.Resources.Window_ButtonMaximize
        Me.ControlBoxMaximize.Location = New System.Drawing.Point(26, 0)
        Me.ControlBoxMaximize.Margin = New System.Windows.Forms.Padding(0)
        Me.ControlBoxMaximize.Name = "ControlBoxMaximize"
        Me.ControlBoxMaximize.Size = New System.Drawing.Size(26, 20)
        Me.ControlBoxMaximize.TabIndex = 9
        Me.ControlBoxMaximize.UseVisualStyleBackColor = False
        '
        'ControlBoxClose
        '
        Me.ControlBoxClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ControlBoxClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ControlBoxClose.FlatAppearance.BorderSize = 0
        Me.ControlBoxClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ControlBoxClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.ControlBoxClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ControlBoxClose.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ControlBoxClose.Image = Global.sstatesman.My.Resources.Resources.Window_ButtonCloseW
        Me.ControlBoxClose.Location = New System.Drawing.Point(52, 0)
        Me.ControlBoxClose.Margin = New System.Windows.Forms.Padding(0)
        Me.ControlBoxClose.Name = "ControlBoxClose"
        Me.ControlBoxClose.Size = New System.Drawing.Size(45, 20)
        Me.ControlBoxClose.TabIndex = 10
        Me.ControlBoxClose.UseVisualStyleBackColor = False
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.Image = Global.sstatesman.My.Resources.Resources.Icon_SSM1ico_24x24
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(493, 0)
        Me.imgWindowGradientIcon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.tlpWindowTop.SetRowSpan(Me.imgWindowGradientIcon, 2)
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'flpTitleBar
        '
        Me.flpTitleBar.AutoSize = True
        Me.flpTitleBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpTitleBar.BackColor = System.Drawing.Color.Transparent
        Me.flpTitleBar.Controls.Add(Me.lblWindowTitle)
        Me.flpTitleBar.Controls.Add(Me.lblWindowDescription)
        Me.flpTitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpTitleBar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTitleBar.Location = New System.Drawing.Point(2, 2)
        Me.flpTitleBar.Margin = New System.Windows.Forms.Padding(2)
        Me.flpTitleBar.Name = "flpTitleBar"
        Me.flpTitleBar.Padding = New System.Windows.Forms.Padding(12, 4, 0, 4)
        Me.tlpWindowTop.SetRowSpan(Me.flpTitleBar, 2)
        Me.flpTitleBar.Size = New System.Drawing.Size(485, 42)
        Me.flpTitleBar.TabIndex = 24
        Me.flpTitleBar.WrapContents = False
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(14, 4)
        Me.lblWindowTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(134, 21)
        Me.lblWindowTitle.TabIndex = 2
        Me.lblWindowTitle.Text = "WindowTitleLabel"
        '
        'lblWindowDescription
        '
        Me.lblWindowDescription.AutoSize = True
        Me.lblWindowDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblWindowDescription.Location = New System.Drawing.Point(14, 25)
        Me.lblWindowDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWindowDescription.Name = "lblWindowDescription"
        Me.lblWindowDescription.Size = New System.Drawing.Size(112, 13)
        Me.lblWindowDescription.TabIndex = 4
        Me.lblWindowDescription.Text = "FormDescriptionText"
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 466)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4, 4, 4, 2)
        Me.flpWindowBottom.Size = New System.Drawing.Size(632, 6)
        Me.flpWindowBottom.TabIndex = 8
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.AutoSize = True
        Me.pnlWindowTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlWindowTop.Controls.Add(Me.tlpWindowTop)
        Me.pnlWindowTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlWindowTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlWindowTop.Name = "pnlWindowTop"
        Me.pnlWindowTop.Size = New System.Drawing.Size(632, 48)
        Me.pnlWindowTop.TabIndex = 0
        '
        'frmTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(632, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlWindowTop)
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmTemplate"
        Me.Text = "WindowTitle"
        Me.tlpWindowTop.ResumeLayout(False)
        Me.tlpWindowTop.PerformLayout()
        Me.flpControlBox.ResumeLayout(False)
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpTitleBar.ResumeLayout(False)
        Me.flpTitleBar.PerformLayout()
        Me.pnlWindowTop.ResumeLayout(False)
        Me.pnlWindowTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents flpControlBox As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents ControlBoxClose As System.Windows.Forms.Button
    Private WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Protected WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel
    Protected WithEvents pnlWindowTop As System.Windows.Forms.Panel
    Private WithEvents flpTitleBar As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Protected WithEvents lblWindowDescription As System.Windows.Forms.Label
    Protected WithEvents ControlBoxMinimize As System.Windows.Forms.Button
    Protected WithEvents ControlBoxMaximize As System.Windows.Forms.Button
    Protected WithEvents tlpWindowTop As System.Windows.Forms.TableLayoutPanel
End Class
