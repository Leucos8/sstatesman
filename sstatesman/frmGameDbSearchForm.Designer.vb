'   SStatesMan - a savestate managing tool for PCSX2
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
        Me.SuspendLayout()
        '
        'ckbSerial
        '
        Me.ckbSerial.AutoSize = True
        Me.ckbSerial.Location = New System.Drawing.Point(12, 12)
        Me.ckbSerial.Name = "ckbSerial"
        Me.ckbSerial.Size = New System.Drawing.Size(101, 17)
        Me.ckbSerial.TabIndex = 0
        Me.ckbSerial.Text = "Search by serial"
        Me.ckbSerial.UseVisualStyleBackColor = True
        '
        'txtSerial
        '
        Me.txtSerial.Enabled = False
        Me.txtSerial.Location = New System.Drawing.Point(12, 35)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(160, 20)
        Me.txtSerial.TabIndex = 1
        '
        'txtGameTitle
        '
        Me.txtGameTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGameTitle.Enabled = False
        Me.txtGameTitle.Location = New System.Drawing.Point(12, 84)
        Me.txtGameTitle.Name = "txtGameTitle"
        Me.txtGameTitle.Size = New System.Drawing.Size(326, 20)
        Me.txtGameTitle.TabIndex = 3
        '
        'ckbGameTitle
        '
        Me.ckbGameTitle.AutoSize = True
        Me.ckbGameTitle.Location = New System.Drawing.Point(12, 61)
        Me.ckbGameTitle.Name = "ckbGameTitle"
        Me.ckbGameTitle.Size = New System.Drawing.Size(122, 17)
        Me.ckbGameTitle.TabIndex = 2
        Me.ckbGameTitle.Text = "Search by game title"
        Me.ckbGameTitle.UseVisualStyleBackColor = True
        '
        'txtGameRegion
        '
        Me.txtGameRegion.Enabled = False
        Me.txtGameRegion.Location = New System.Drawing.Point(12, 133)
        Me.txtGameRegion.Name = "txtGameRegion"
        Me.txtGameRegion.Size = New System.Drawing.Size(160, 20)
        Me.txtGameRegion.TabIndex = 5
        '
        'ckbGameRegion
        '
        Me.ckbGameRegion.AutoSize = True
        Me.ckbGameRegion.Location = New System.Drawing.Point(12, 110)
        Me.ckbGameRegion.Name = "ckbGameRegion"
        Me.ckbGameRegion.Size = New System.Drawing.Size(106, 17)
        Me.ckbGameRegion.TabIndex = 4
        Me.ckbGameRegion.Text = "Search by region"
        Me.ckbGameRegion.UseVisualStyleBackColor = True
        '
        'ckbGameCompat
        '
        Me.ckbGameCompat.AutoSize = True
        Me.ckbGameCompat.Location = New System.Drawing.Point(178, 110)
        Me.ckbGameCompat.Name = "ckbGameCompat"
        Me.ckbGameCompat.Size = New System.Drawing.Size(112, 17)
        Me.ckbGameCompat.TabIndex = 6
        Me.ckbGameCompat.Text = "Search by compat"
        Me.ckbGameCompat.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Enabled = False
        Me.cmdSearch.Location = New System.Drawing.Point(182, 165)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 8
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(263, 165)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cbGameCompat
        '
        Me.cbGameCompat.Enabled = False
        Me.cbGameCompat.FormattingEnabled = True
        Me.cbGameCompat.Items.AddRange(New Object() {"0: Unknown", "1: Nothing", "2: Intro", "3: Menus", "4: in-Game", "5: Playable", "6: Perfect", "Missing", "Undetected"})
        Me.cbGameCompat.Location = New System.Drawing.Point(178, 133)
        Me.cbGameCompat.Name = "cbGameCompat"
        Me.cbGameCompat.Size = New System.Drawing.Size(160, 21)
        Me.cbGameCompat.TabIndex = 10
        Me.cbGameCompat.Text = "0: Unknown"
        '
        'frmGameDbSearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 194)
        Me.Controls.Add(Me.cbGameCompat)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.ckbGameCompat)
        Me.Controls.Add(Me.txtGameRegion)
        Me.Controls.Add(Me.ckbGameRegion)
        Me.Controls.Add(Me.txtGameTitle)
        Me.Controls.Add(Me.ckbGameTitle)
        Me.Controls.Add(Me.txtSerial)
        Me.Controls.Add(Me.ckbSerial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGameDbSearchForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GameDB util - Search"
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
End Class
