'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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
Partial Class ucFolderPickerPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.tlpWrapper = New System.Windows.Forms.TableLayoutPanel()
        Me.flpCmds = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.cmdDetect = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.imgStatus = New System.Windows.Forms.PictureBox()
        Me.tmrCheck = New System.Windows.Forms.Timer(Me.components)
        Me.tlpWrapper.SuspendLayout()
        Me.flpCmds.SuspendLayout()
        CType(Me.imgStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpWrapper
        '
        Me.tlpWrapper.AutoSize = True
        Me.tlpWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpWrapper.ColumnCount = 3
        Me.tlpWrapper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWrapper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWrapper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWrapper.Controls.Add(Me.flpCmds, 2, 1)
        Me.tlpWrapper.Controls.Add(Me.txtPath, 0, 0)
        Me.tlpWrapper.Controls.Add(Me.lblStatus, 1, 1)
        Me.tlpWrapper.Controls.Add(Me.imgStatus, 0, 1)
        Me.tlpWrapper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpWrapper.Location = New System.Drawing.Point(0, 0)
        Me.tlpWrapper.Name = "tlpWrapper"
        Me.tlpWrapper.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.tlpWrapper.RowCount = 2
        Me.tlpWrapper.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWrapper.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWrapper.Size = New System.Drawing.Size(300, 56)
        Me.tlpWrapper.TabIndex = 0
        '
        'flpCmds
        '
        Me.flpCmds.AutoSize = True
        Me.flpCmds.Controls.Add(Me.cmdBrowse)
        Me.flpCmds.Controls.Add(Me.cmdOpen)
        Me.flpCmds.Controls.Add(Me.cmdDetect)
        Me.flpCmds.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpCmds.Location = New System.Drawing.Point(115, 26)
        Me.flpCmds.Margin = New System.Windows.Forms.Padding(0)
        Me.flpCmds.Name = "flpCmds"
        Me.flpCmds.Size = New System.Drawing.Size(177, 28)
        Me.flpCmds.TabIndex = 2
        Me.flpCmds.WrapContents = False
        '
        'cmdBrowse
        '
        Me.cmdBrowse.AutoSize = True
        Me.cmdBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdBrowse.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBrowse.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrowse.Location = New System.Drawing.Point(120, 2)
        Me.cmdBrowse.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdBrowse.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(55, 24)
        Me.cmdBrowse.TabIndex = 4
        Me.cmdBrowse.Text = "BROWSE"
        Me.cmdBrowse.UseVisualStyleBackColor = False
        '
        'cmdOpen
        '
        Me.cmdOpen.AutoSize = True
        Me.cmdOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdOpen.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOpen.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpen.Location = New System.Drawing.Point(61, 2)
        Me.cmdOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOpen.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(55, 24)
        Me.cmdOpen.TabIndex = 3
        Me.cmdOpen.Text = "OPEN"
        Me.cmdOpen.UseVisualStyleBackColor = False
        '
        'cmdDetect
        '
        Me.cmdDetect.AutoSize = True
        Me.cmdDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdDetect.BackgroundImage = Global.sstatesman.My.Resources.Resources.Button_Bg
        Me.cmdDetect.Enabled = False
        Me.cmdDetect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdDetect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdDetect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDetect.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDetect.Location = New System.Drawing.Point(2, 2)
        Me.cmdDetect.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdDetect.MinimumSize = New System.Drawing.Size(55, 0)
        Me.cmdDetect.Name = "cmdDetect"
        Me.cmdDetect.Size = New System.Drawing.Size(55, 24)
        Me.cmdDetect.TabIndex = 2
        Me.cmdDetect.Text = "DETECT"
        Me.cmdDetect.UseVisualStyleBackColor = False
        Me.cmdDetect.Visible = False
        '
        'txtPath
        '
        Me.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpWrapper.SetColumnSpan(Me.txtPath, 3)
        Me.txtPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPath.Location = New System.Drawing.Point(10, 4)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(280, 20)
        Me.txtPath.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(35, 26)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 5
        '
        'imgStatus
        '
        Me.imgStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.imgStatus.Image = Global.sstatesman.My.Resources.Resources.InfoIcon_Exclamation
        Me.imgStatus.Location = New System.Drawing.Point(8, 26)
        Me.imgStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.imgStatus.Name = "imgStatus"
        Me.imgStatus.Size = New System.Drawing.Size(24, 28)
        Me.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgStatus.TabIndex = 6
        Me.imgStatus.TabStop = False
        Me.imgStatus.Visible = False
        '
        'tmrCheck
        '
        Me.tmrCheck.Interval = 2000
        '
        'ucFolderPickerPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.tlpWrapper)
        Me.Name = "ucFolderPickerPanel"
        Me.Size = New System.Drawing.Size(300, 56)
        Me.tlpWrapper.ResumeLayout(False)
        Me.tlpWrapper.PerformLayout()
        Me.flpCmds.ResumeLayout(False)
        Me.flpCmds.PerformLayout()
        CType(Me.imgStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tlpWrapper As System.Windows.Forms.TableLayoutPanel
    Private WithEvents flpCmds As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents cmdBrowse As System.Windows.Forms.Button
    Private WithEvents cmdOpen As System.Windows.Forms.Button
    Private WithEvents cmdDetect As System.Windows.Forms.Button
    Private WithEvents txtPath As System.Windows.Forms.TextBox
    Private WithEvents lblStatus As System.Windows.Forms.Label
    Private WithEvents imgStatus As System.Windows.Forms.PictureBox
    Private WithEvents tmrCheck As System.Windows.Forms.Timer

End Class
