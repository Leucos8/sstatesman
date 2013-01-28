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
        Me.tsGames = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsGamesAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsGamesChecked = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSavestates = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsSavestatesAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSavestatesCurrent = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSavestatesChecked = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsStored = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsStoredAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsStoredCurrent = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsStoredChecked = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSnaps = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsSnapsAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSnapsCurrent = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSnapsSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 420)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(744, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel1.Text = "_"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsGames, Me.tsSavestates, Me.tsStored, Me.tsSnaps})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(744, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsGames
        '
        Me.tsGames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsGames.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsGamesAll, Me.tsGamesChecked})
        Me.tsGames.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGames.Name = "tsGames"
        Me.tsGames.Size = New System.Drawing.Size(59, 22)
        Me.tsGames.Text = "Games"
        '
        'tsGamesAll
        '
        Me.tsGamesAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsGamesAll.Name = "tsGamesAll"
        Me.tsGamesAll.Size = New System.Drawing.Size(120, 22)
        Me.tsGamesAll.Text = "All"
        '
        'tsGamesChecked
        '
        Me.tsGamesChecked.Name = "tsGamesChecked"
        Me.tsGamesChecked.Size = New System.Drawing.Size(120, 22)
        Me.tsGamesChecked.Text = "Checked"
        '
        'tsSavestates
        '
        Me.tsSavestates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSavestates.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSavestatesAll, Me.tsSavestatesCurrent, Me.tsSavestatesChecked})
        Me.tsSavestates.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSavestates.Name = "tsSavestates"
        Me.tsSavestates.Size = New System.Drawing.Size(77, 22)
        Me.tsSavestates.Text = "Savestates"
        Me.tsSavestates.ToolTipText = "All"
        '
        'tsSavestatesAll
        '
        Me.tsSavestatesAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsSavestatesAll.Name = "tsSavestatesAll"
        Me.tsSavestatesAll.Size = New System.Drawing.Size(120, 22)
        Me.tsSavestatesAll.Text = "All"
        '
        'tsSavestatesCurrent
        '
        Me.tsSavestatesCurrent.Name = "tsSavestatesCurrent"
        Me.tsSavestatesCurrent.Size = New System.Drawing.Size(120, 22)
        Me.tsSavestatesCurrent.Text = "Current"
        '
        'tsSavestatesChecked
        '
        Me.tsSavestatesChecked.Name = "tsSavestatesChecked"
        Me.tsSavestatesChecked.Size = New System.Drawing.Size(120, 22)
        Me.tsSavestatesChecked.Text = "Checked"
        '
        'tsStored
        '
        Me.tsStored.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsStored.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsStoredAll, Me.tsStoredCurrent, Me.tsStoredChecked})
        Me.tsStored.Enabled = False
        Me.tsStored.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsStored.Name = "tsStored"
        Me.tsStored.Size = New System.Drawing.Size(57, 22)
        Me.tsStored.Text = "Stored"
        '
        'tsStoredAll
        '
        Me.tsStoredAll.Enabled = False
        Me.tsStoredAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsStoredAll.Name = "tsStoredAll"
        Me.tsStoredAll.Size = New System.Drawing.Size(120, 22)
        Me.tsStoredAll.Text = "All"
        '
        'tsStoredCurrent
        '
        Me.tsStoredCurrent.Enabled = False
        Me.tsStoredCurrent.Name = "tsStoredCurrent"
        Me.tsStoredCurrent.Size = New System.Drawing.Size(120, 22)
        Me.tsStoredCurrent.Text = "Current"
        '
        'tsStoredChecked
        '
        Me.tsStoredChecked.Enabled = False
        Me.tsStoredChecked.Name = "tsStoredChecked"
        Me.tsStoredChecked.Size = New System.Drawing.Size(120, 22)
        Me.tsStoredChecked.Text = "Checked"
        '
        'tsSnaps
        '
        Me.tsSnaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSnaps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSnapsAll, Me.tsSnapsCurrent, Me.tsSnapsSelected})
        Me.tsSnaps.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSnaps.Name = "tsSnaps"
        Me.tsSnaps.Size = New System.Drawing.Size(86, 22)
        Me.tsSnaps.Text = "Screenshots"
        '
        'tsSnapsAll
        '
        Me.tsSnapsAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsSnapsAll.Name = "tsSnapsAll"
        Me.tsSnapsAll.Size = New System.Drawing.Size(118, 22)
        Me.tsSnapsAll.Text = "All"
        '
        'tsSnapsCurrent
        '
        Me.tsSnapsCurrent.Enabled = False
        Me.tsSnapsCurrent.Name = "tsSnapsCurrent"
        Me.tsSnapsCurrent.Size = New System.Drawing.Size(118, 22)
        Me.tsSnapsCurrent.Text = "Current"
        '
        'tsSnapsSelected
        '
        Me.tsSnapsSelected.Enabled = False
        Me.tsSnapsSelected.Name = "tsSnapsSelected"
        Me.tsSnapsSelected.Size = New System.Drawing.Size(118, 22)
        Me.tsSnapsSelected.Text = "Selected"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 6)
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
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
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(744, 442)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "frmSStateList"
        Me.Text = "Developer Tools"
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
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents tsGames As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsGamesAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsGamesChecked As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSavestates As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsSavestatesAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSavestatesCurrent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSavestatesChecked As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsStored As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsStoredAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsStoredCurrent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsStoredChecked As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSnaps As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsSnapsAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSnapsCurrent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSnapsSelected As System.Windows.Forms.ToolStripMenuItem
End Class
