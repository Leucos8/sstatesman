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
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.lblWindowProgramName = New System.Windows.Forms.Label()
        Me.imgWindowGradientLeft = New System.Windows.Forms.PictureBox()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.blWindowDescription = New System.Windows.Forms.Label()
        Me.imgWindowGradientIcon = New System.Windows.Forms.PictureBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtPCSX2AppPath = New System.Windows.Forms.TextBox()
        Me.txtPCSX2UserPath = New System.Windows.Forms.TextBox()
        Me.panelWindowTitle.SuspendLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.panelWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientLeft)
        Me.panelWindowTitle.Controls.Add(Me.lblWindowTitle)
        Me.panelWindowTitle.Controls.Add(Me.blWindowDescription)
        Me.panelWindowTitle.Controls.Add(Me.imgWindowGradientIcon)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(350, 70)
        Me.panelWindowTitle.TabIndex = 14
        '
        'lblWindowProgramName
        '
        Me.lblWindowProgramName.AutoSize = True
        Me.lblWindowProgramName.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowProgramName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowProgramName.Location = New System.Drawing.Point(8, 4)
        Me.lblWindowProgramName.Name = "lblWindowProgramName"
        Me.lblWindowProgramName.Size = New System.Drawing.Size(79, 13)
        Me.lblWindowProgramName.TabIndex = 14
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
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(28, 24)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(87, 30)
        Me.lblWindowTitle.TabIndex = 4
        Me.lblWindowTitle.Text = "Settings"
        '
        'blWindowDescription
        '
        Me.blWindowDescription.AutoSize = True
        Me.blWindowDescription.BackColor = System.Drawing.Color.Transparent
        Me.blWindowDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blWindowDescription.Location = New System.Drawing.Point(30, 51)
        Me.blWindowDescription.Name = "blWindowDescription"
        Me.blWindowDescription.Size = New System.Drawing.Size(196, 13)
        Me.blWindowDescription.TabIndex = 5
        Me.blWindowDescription.Text = "here you can configure your settings"
        '
        'imgWindowGradientIcon
        '
        Me.imgWindowGradientIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgWindowGradientIcon.BackgroundImage = Global.sstatesman.My.Resources.Resources.GradientBlueDarkH
        Me.imgWindowGradientIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgWindowGradientIcon.Image = Global.sstatesman.My.Resources.Resources.Ico32tmp
        Me.imgWindowGradientIcon.Location = New System.Drawing.Point(265, 0)
        Me.imgWindowGradientIcon.Name = "imgWindowGradientIcon"
        Me.imgWindowGradientIcon.Size = New System.Drawing.Size(32, 32)
        Me.imgWindowGradientIcon.TabIndex = 6
        Me.imgWindowGradientIcon.TabStop = False
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.Color.Transparent
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(238, 135)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'txtPCSX2AppPath
        '
        Me.txtPCSX2AppPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPCSX2AppPath.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPCSX2AppPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.sstatesman.My.MySettings.Default, "PCSX2_BinPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtPCSX2AppPath.ForeColor = System.Drawing.Color.DimGray
        Me.txtPCSX2AppPath.Location = New System.Drawing.Point(12, 76)
        Me.txtPCSX2AppPath.Name = "txtPCSX2AppPath"
        Me.txtPCSX2AppPath.Size = New System.Drawing.Size(326, 22)
        Me.txtPCSX2AppPath.TabIndex = 17
        Me.txtPCSX2AppPath.Text = Global.sstatesman.My.MySettings.Default.PCSX2_BinPath
        '
        'txtPCSX2UserPath
        '
        Me.txtPCSX2UserPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPCSX2UserPath.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPCSX2UserPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.sstatesman.My.MySettings.Default, "PCSX2_UserPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtPCSX2UserPath.ForeColor = System.Drawing.Color.DimGray
        Me.txtPCSX2UserPath.Location = New System.Drawing.Point(12, 104)
        Me.txtPCSX2UserPath.Name = "txtPCSX2UserPath"
        Me.txtPCSX2UserPath.Size = New System.Drawing.Size(326, 22)
        Me.txtPCSX2UserPath.TabIndex = 18
        Me.txtPCSX2UserPath.Text = Global.sstatesman.My.MySettings.Default.PCSX2_UserPath
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.sstatesman.My.Resources.Resources.Bg2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(350, 170)
        Me.Controls.Add(Me.txtPCSX2UserPath)
        Me.Controls.Add(Me.txtPCSX2AppPath)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSettings"
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        CType(Me.imgWindowGradientLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWindowGradientIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Friend WithEvents imgWindowGradientLeft As System.Windows.Forms.PictureBox
    Friend WithEvents lblWindowTitle As System.Windows.Forms.Label
    Friend WithEvents imgWindowGradientIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtPCSX2AppPath As System.Windows.Forms.TextBox
    Friend WithEvents txtPCSX2UserPath As System.Windows.Forms.TextBox
    Friend WithEvents blWindowDescription As System.Windows.Forms.Label
End Class
