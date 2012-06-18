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
Partial Class frmSStateList
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsShowGameList = New System.Windows.Forms.ToolStripButton()
        Me.tsShowGameChecked = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsShowSavestatesAll = New System.Windows.Forms.ToolStripButton()
        Me.tsShowSavestatesCurrent = New System.Windows.Forms.ToolStripButton()
        Me.tsShowSavestatesChecked = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tsShowSavestatesUIList = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.tsShowSavestatesUIListChecked = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 420)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(744, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel1.Text = "_"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.tsShowGameList, Me.tsShowGameChecked, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.tsShowSavestatesAll, Me.tsShowSavestatesCurrent, Me.tsShowSavestatesChecked, Me.ToolStripSeparator1, Me.ToolStripLabel3, Me.tsShowSavestatesUIList, Me.ToolStripButton2, Me.tsShowSavestatesUIListChecked})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(744, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel2.Text = "Games:"
        '
        'tsShowGameList
        '
        Me.tsShowGameList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowGameList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowGameList.Name = "tsShowGameList"
        Me.tsShowGameList.Size = New System.Drawing.Size(25, 22)
        Me.tsShowGameList.Text = "All"
        '
        'tsShowGameChecked
        '
        Me.tsShowGameChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowGameChecked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowGameChecked.Name = "tsShowGameChecked"
        Me.tsShowGameChecked.Size = New System.Drawing.Size(57, 22)
        Me.tsShowGameChecked.Text = "Checked"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabel1.Text = "Savestates:"
        '
        'tsShowSavestatesAll
        '
        Me.tsShowSavestatesAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowSavestatesAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowSavestatesAll.Name = "tsShowSavestatesAll"
        Me.tsShowSavestatesAll.Size = New System.Drawing.Size(25, 22)
        Me.tsShowSavestatesAll.Text = "All"
        Me.tsShowSavestatesAll.ToolTipText = "All"
        '
        'tsShowSavestatesCurrent
        '
        Me.tsShowSavestatesCurrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowSavestatesCurrent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowSavestatesCurrent.Name = "tsShowSavestatesCurrent"
        Me.tsShowSavestatesCurrent.Size = New System.Drawing.Size(51, 22)
        Me.tsShowSavestatesCurrent.Text = "Current"
        '
        'tsShowSavestatesChecked
        '
        Me.tsShowSavestatesChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowSavestatesChecked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowSavestatesChecked.Name = "tsShowSavestatesChecked"
        Me.tsShowSavestatesChecked.Size = New System.Drawing.Size(57, 22)
        Me.tsShowSavestatesChecked.Text = "Checked"
        Me.tsShowSavestatesChecked.ToolTipText = "Checked"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel3.Text = "Stored:"
        '
        'tsShowSavestatesUIList
        '
        Me.tsShowSavestatesUIList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowSavestatesUIList.Enabled = False
        Me.tsShowSavestatesUIList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowSavestatesUIList.Name = "tsShowSavestatesUIList"
        Me.tsShowSavestatesUIList.Size = New System.Drawing.Size(25, 22)
        Me.tsShowSavestatesUIList.Text = "All"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripButton2.Text = "Current"
        '
        'tsShowSavestatesUIListChecked
        '
        Me.tsShowSavestatesUIListChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsShowSavestatesUIListChecked.Enabled = False
        Me.tsShowSavestatesUIListChecked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowSavestatesUIListChecked.Name = "tsShowSavestatesUIListChecked"
        Me.tsShowSavestatesUIListChecked.Size = New System.Drawing.Size(57, 22)
        Me.tsShowSavestatesUIListChecked.Text = "Checked"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 6)
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(0, 25)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(744, 395)
        Me.ListView1.TabIndex = 18
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'frmSStateList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(744, 442)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmSStateList"
        Me.Text = "SStateList Util - For developer only"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsShowSavestatesChecked As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsShowSavestatesAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsShowGameList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsShowSavestatesCurrent As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsShowSavestatesUIList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsShowSavestatesUIListChecked As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents tsShowGameChecked As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
End Class
