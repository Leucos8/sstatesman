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
Partial Class frmGameDbSearchForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGameDbSearchForm))
        Me.ckbSerial = New System.Windows.Forms.CheckBox()
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me.txtGameTitle = New System.Windows.Forms.TextBox()
        Me.ckbGameTitle = New System.Windows.Forms.CheckBox()
        Me.txtGameRegion = New System.Windows.Forms.TextBox()
        Me.ckbGameRegion = New System.Windows.Forms.CheckBox()
        Me.ckbGameCompat = New System.Windows.Forms.CheckBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cbGameCompat = New System.Windows.Forms.ComboBox()
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSeatchType = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.optSeatchTypeAND = New System.Windows.Forms.RadioButton()
        Me.optSeatchTypeOR = New System.Windows.Forms.RadioButton()
        Me.panelWindowTitle = New System.Windows.Forms.Panel()
        Me.lblWindowProgramName = New System.Windows.Forms.Label()
        Me.flpWindowBottom.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.panelWindowTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'ckbSerial
        '
        Me.ckbSerial.AutoSize = True
        Me.ckbSerial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckbSerial.Enabled = False
        Me.ckbSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSerial.Location = New System.Drawing.Point(12, 8)
        Me.ckbSerial.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbSerial.Name = "ckbSerial"
        Me.ckbSerial.Size = New System.Drawing.Size(76, 22)
        Me.ckbSerial.TabIndex = 6
        Me.ckbSerial.Text = "by serial"
        Me.ckbSerial.UseVisualStyleBackColor = False
        '
        'txtSerial
        '
        Me.txtSerial.BackColor = System.Drawing.Color.White
        Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSerial.ForeColor = System.Drawing.Color.Black
        Me.txtSerial.Location = New System.Drawing.Point(96, 8)
        Me.txtSerial.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(366, 22)
        Me.txtSerial.TabIndex = 7
        '
        'txtGameTitle
        '
        Me.txtGameTitle.BackColor = System.Drawing.Color.White
        Me.txtGameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameTitle.ForeColor = System.Drawing.Color.Black
        Me.txtGameTitle.Location = New System.Drawing.Point(96, 38)
        Me.txtGameTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGameTitle.Name = "txtGameTitle"
        Me.txtGameTitle.Size = New System.Drawing.Size(366, 22)
        Me.txtGameTitle.TabIndex = 9
        '
        'ckbGameTitle
        '
        Me.ckbGameTitle.AutoSize = True
        Me.ckbGameTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckbGameTitle.Enabled = False
        Me.ckbGameTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbGameTitle.Location = New System.Drawing.Point(12, 38)
        Me.ckbGameTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbGameTitle.Name = "ckbGameTitle"
        Me.ckbGameTitle.Size = New System.Drawing.Size(76, 22)
        Me.ckbGameTitle.TabIndex = 8
        Me.ckbGameTitle.Text = "by title"
        Me.ckbGameTitle.UseVisualStyleBackColor = False
        '
        'txtGameRegion
        '
        Me.txtGameRegion.BackColor = System.Drawing.Color.White
        Me.txtGameRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGameRegion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGameRegion.ForeColor = System.Drawing.Color.Black
        Me.txtGameRegion.Location = New System.Drawing.Point(96, 68)
        Me.txtGameRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGameRegion.Name = "txtGameRegion"
        Me.txtGameRegion.Size = New System.Drawing.Size(366, 22)
        Me.txtGameRegion.TabIndex = 11
        '
        'ckbGameRegion
        '
        Me.ckbGameRegion.AutoSize = True
        Me.ckbGameRegion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckbGameRegion.Enabled = False
        Me.ckbGameRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbGameRegion.Location = New System.Drawing.Point(12, 68)
        Me.ckbGameRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbGameRegion.Name = "ckbGameRegion"
        Me.ckbGameRegion.Size = New System.Drawing.Size(76, 22)
        Me.ckbGameRegion.TabIndex = 10
        Me.ckbGameRegion.Text = "by region"
        Me.ckbGameRegion.UseVisualStyleBackColor = False
        '
        'ckbGameCompat
        '
        Me.ckbGameCompat.AutoSize = True
        Me.ckbGameCompat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckbGameCompat.Enabled = False
        Me.ckbGameCompat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbGameCompat.Location = New System.Drawing.Point(12, 98)
        Me.ckbGameCompat.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbGameCompat.Name = "ckbGameCompat"
        Me.ckbGameCompat.Size = New System.Drawing.Size(76, 21)
        Me.ckbGameCompat.TabIndex = 12
        Me.ckbGameCompat.Text = "by compat"
        Me.ckbGameCompat.UseVisualStyleBackColor = False
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.AutoSize = True
        Me.cmdSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSearch.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdSearch.Enabled = False
        Me.cmdSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSearch.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(257, 7)
        Me.cmdSearch.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(100, 24)
        Me.cmdSearch.TabIndex = 3
        Me.cmdSearch.Text = "SEARCH"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.AutoSize = True
        Me.cmdCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdCancel.BackgroundImage = Global.sstatesman.My.Resources.Resources.Metro_ButtonNormal
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(363, 7)
        Me.cmdCancel.MinimumSize = New System.Drawing.Size(100, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cbGameCompat
        '
        Me.cbGameCompat.BackColor = System.Drawing.Color.White
        Me.cbGameCompat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbGameCompat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbGameCompat.ForeColor = System.Drawing.Color.Black
        Me.cbGameCompat.FormattingEnabled = True
        Me.cbGameCompat.Items.AddRange(New Object() {"", "0: Unknown", "1: Nothing", "2: Intro", "3: Menus", "4: in-Game", "5: Playable", "6: Perfect", "Missing", "Undetected"})
        Me.cbGameCompat.Location = New System.Drawing.Point(96, 98)
        Me.cbGameCompat.Margin = New System.Windows.Forms.Padding(4)
        Me.cbGameCompat.Name = "cbGameCompat"
        Me.cbGameCompat.Size = New System.Drawing.Size(366, 21)
        Me.cbGameCompat.TabIndex = 13
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.BackColor = System.Drawing.Color.Gainsboro
        Me.flpWindowBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.flpWindowBottom.Controls.Add(Me.cmdCancel)
        Me.flpWindowBottom.Controls.Add(Me.cmdSearch)
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 194)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4)
        Me.flpWindowBottom.Size = New System.Drawing.Size(474, 38)
        Me.flpWindowBottom.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ckbSerial, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ckbGameTitle, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSerial, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGameRegion, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGameTitle, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ckbGameRegion, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ckbGameCompat, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cbGameCompat, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSeatchType, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 30)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(474, 164)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'lblSeatchType
        '
        Me.lblSeatchType.AutoSize = True
        Me.lblSeatchType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSeatchType.Location = New System.Drawing.Point(11, 123)
        Me.lblSeatchType.Name = "lblSeatchType"
        Me.lblSeatchType.Size = New System.Drawing.Size(78, 23)
        Me.lblSeatchType.TabIndex = 14
        Me.lblSeatchType.Text = "Search type"
        Me.lblSeatchType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.optSeatchTypeAND)
        Me.FlowLayoutPanel1.Controls.Add(Me.optSeatchTypeOR)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(92, 123)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(374, 23)
        Me.FlowLayoutPanel1.TabIndex = 17
        '
        'optSeatchTypeAND
        '
        Me.optSeatchTypeAND.AutoSize = True
        Me.optSeatchTypeAND.Checked = True
        Me.optSeatchTypeAND.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSeatchTypeAND.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSeatchTypeAND.Location = New System.Drawing.Point(3, 3)
        Me.optSeatchTypeAND.Name = "optSeatchTypeAND"
        Me.optSeatchTypeAND.Size = New System.Drawing.Size(49, 17)
        Me.optSeatchTypeAND.TabIndex = 15
        Me.optSeatchTypeAND.TabStop = True
        Me.optSeatchTypeAND.Text = "AND"
        Me.optSeatchTypeAND.UseVisualStyleBackColor = True
        '
        'optSeatchTypeOR
        '
        Me.optSeatchTypeOR.AutoSize = True
        Me.optSeatchTypeOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSeatchTypeOR.Location = New System.Drawing.Point(58, 3)
        Me.optSeatchTypeOR.Name = "optSeatchTypeOR"
        Me.optSeatchTypeOR.Size = New System.Drawing.Size(40, 17)
        Me.optSeatchTypeOR.TabIndex = 16
        Me.optSeatchTypeOR.Text = "OR"
        Me.optSeatchTypeOR.UseVisualStyleBackColor = True
        '
        'panelWindowTitle
        '
        Me.panelWindowTitle.AutoSize = True
        Me.panelWindowTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelWindowTitle.BackColor = System.Drawing.Color.Gainsboro
        Me.panelWindowTitle.Controls.Add(Me.lblWindowProgramName)
        Me.panelWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.panelWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.panelWindowTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.panelWindowTitle.MinimumSize = New System.Drawing.Size(0, 26)
        Me.panelWindowTitle.Name = "panelWindowTitle"
        Me.panelWindowTitle.Size = New System.Drawing.Size(474, 30)
        Me.panelWindowTitle.TabIndex = 0
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
        Me.lblWindowProgramName.Size = New System.Drawing.Size(67, 30)
        Me.lblWindowProgramName.TabIndex = 1
        Me.lblWindowProgramName.Text = "search"
        '
        'frmGameDbSearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(474, 232)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.panelWindowTitle)
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGameDbSearchForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GameDB Explorer - Search"
        Me.flpWindowBottom.ResumeLayout(False)
        Me.flpWindowBottom.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.panelWindowTitle.ResumeLayout(False)
        Me.panelWindowTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ckbSerial As System.Windows.Forms.CheckBox
    Friend WithEvents txtSerial As System.Windows.Forms.TextBox
    Friend WithEvents txtGameTitle As System.Windows.Forms.TextBox
    Friend WithEvents ckbGameTitle As System.Windows.Forms.CheckBox
    Friend WithEvents txtGameRegion As System.Windows.Forms.TextBox
    Friend WithEvents ckbGameRegion As System.Windows.Forms.CheckBox
    Friend WithEvents ckbGameCompat As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cbGameCompat As System.Windows.Forms.ComboBox
    Friend WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents panelWindowTitle As System.Windows.Forms.Panel
    Private WithEvents lblWindowProgramName As System.Windows.Forms.Label
    Friend WithEvents lblSeatchType As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents optSeatchTypeAND As System.Windows.Forms.RadioButton
    Friend WithEvents optSeatchTypeOR As System.Windows.Forms.RadioButton
End Class
