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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblSearchResults = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSStateListLoad = New System.Windows.Forms.ToolStripButton()
        Me.tsSStateListUnload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsListShow = New System.Windows.Forms.ToolStripButton()
        Me.tsListClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsExport = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsExportTSVTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsExportCSVTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsRecordLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRecordNext = New System.Windows.Forms.ToolStripButton()
        Me.tsRecordPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsRecordFirst = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 11
        Me.ListBox1.Location = New System.Drawing.Point(14, 106)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(720, 323)
        Me.ListBox1.TabIndex = 6
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 451)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(746, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'LblSearchResults
        '
        Me.LblSearchResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSearchResults.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSearchResults.Location = New System.Drawing.Point(12, 35)
        Me.LblSearchResults.Name = "LblSearchResults"
        Me.LblSearchResults.Size = New System.Drawing.Size(722, 62)
        Me.LblSearchResults.TabIndex = 12
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSStateListLoad, Me.tsSStateListUnload, Me.ToolStripSeparator1, Me.tsListShow, Me.tsListClear, Me.ToolStripSeparator2, Me.tsExport, Me.tsRecordLast, Me.tsRecordNext, Me.tsRecordPrevious, Me.tsRecordFirst})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(746, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSStateListLoad
        '
        Me.tsSStateListLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSStateListLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSStateListLoad.Name = "tsSStateListLoad"
        Me.tsSStateListLoad.Size = New System.Drawing.Size(90, 22)
        Me.tsSStateListLoad.Text = "Load SStateList"
        '
        'tsSStateListUnload
        '
        Me.tsSStateListUnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSStateListUnload.Enabled = False
        Me.tsSStateListUnload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSStateListUnload.Name = "tsSStateListUnload"
        Me.tsSStateListUnload.Size = New System.Drawing.Size(49, 22)
        Me.tsSStateListUnload.Text = "Unload"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsListShow
        '
        Me.tsListShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsListShow.Enabled = False
        Me.tsListShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsListShow.Name = "tsListShow"
        Me.tsListShow.Size = New System.Drawing.Size(29, 22)
        Me.tsListShow.Text = "List"
        '
        'tsListClear
        '
        Me.tsListClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsListClear.Enabled = False
        Me.tsListClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsListClear.Name = "tsListClear"
        Me.tsListClear.Size = New System.Drawing.Size(38, 22)
        Me.tsListClear.Text = "Clear"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsExport
        '
        Me.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExportTSVTxt, Me.tsExportCSVTxt})
        Me.tsExport.Enabled = False
        Me.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExport.Name = "tsExport"
        Me.tsExport.Size = New System.Drawing.Size(53, 22)
        Me.tsExport.Text = "Export"
        '
        'tsExportTSVTxt
        '
        Me.tsExportTSVTxt.Name = "tsExportTSVTxt"
        Me.tsExportTSVTxt.Size = New System.Drawing.Size(243, 22)
        Me.tsExportTSVTxt.Text = "Tab separated value text file"
        '
        'tsExportCSVTxt
        '
        Me.tsExportCSVTxt.Name = "tsExportCSVTxt"
        Me.tsExportCSVTxt.Size = New System.Drawing.Size(243, 22)
        Me.tsExportCSVTxt.Text = "Comma separated value text file"
        '
        'tsRecordLast
        '
        Me.tsRecordLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordLast.Enabled = False
        Me.tsRecordLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordLast.Name = "tsRecordLast"
        Me.tsRecordLast.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordLast.Text = "››"
        '
        'tsRecordNext
        '
        Me.tsRecordNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordNext.Enabled = False
        Me.tsRecordNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordNext.Name = "tsRecordNext"
        Me.tsRecordNext.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordNext.Text = "›"
        '
        'tsRecordPrevious
        '
        Me.tsRecordPrevious.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordPrevious.Enabled = False
        Me.tsRecordPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordPrevious.Name = "tsRecordPrevious"
        Me.tsRecordPrevious.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordPrevious.Text = "‹"
        '
        'tsRecordFirst
        '
        Me.tsRecordFirst.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRecordFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRecordFirst.Enabled = False
        Me.tsRecordFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRecordFirst.Name = "tsRecordFirst"
        Me.tsRecordFirst.Size = New System.Drawing.Size(23, 22)
        Me.tsRecordFirst.Text = "‹‹"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 6)
        '
        'frmSStateList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 473)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.LblSearchResults)
        Me.Name = "frmSStateList"
        Me.Text = "SStateList Util - For developer only"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblSearchResults As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsListShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsListClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExport As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsExportTSVTxt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSStateListUnload As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsRecordLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsExportCSVTxt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSStateListLoad As System.Windows.Forms.ToolStripButton
End Class
