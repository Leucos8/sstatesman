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
Partial Class frmDialogTemplate
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
        Me.flpWindowBottom = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.pnlWindowTop = New System.Windows.Forms.Panel()
        Me.pnlWindowTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpWindowBottom
        '
        Me.flpWindowBottom.AutoSize = True
        Me.flpWindowBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpWindowBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpWindowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpWindowBottom.Location = New System.Drawing.Point(0, 360)
        Me.flpWindowBottom.Name = "flpWindowBottom"
        Me.flpWindowBottom.Padding = New System.Windows.Forms.Padding(4)
        Me.flpWindowBottom.Size = New System.Drawing.Size(629, 8)
        Me.flpWindowBottom.TabIndex = 5
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWindowTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindowTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblWindowTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 3)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Padding = New System.Windows.Forms.Padding(6, 6, 6, 3)
        Me.lblWindowTitle.Size = New System.Drawing.Size(168, 30)
        Me.lblWindowTitle.TabIndex = 1
        Me.lblWindowTitle.Text = "Dialog Template Title"
        '
        'pnlWindowTop
        '
        Me.pnlWindowTop.AutoSize = True
        Me.pnlWindowTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlWindowTop.Controls.Add(Me.lblWindowTitle)
        Me.pnlWindowTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlWindowTop.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.pnlWindowTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlWindowTop.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWindowTop.MinimumSize = New System.Drawing.Size(0, 26)
        Me.pnlWindowTop.Name = "pnlWindowTop"
        Me.pnlWindowTop.Size = New System.Drawing.Size(629, 30)
        Me.pnlWindowTop.TabIndex = 0
        '
        'frmDialogTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(629, 368)
        Me.ControlBox = False
        Me.Controls.Add(Me.flpWindowBottom)
        Me.Controls.Add(Me.pnlWindowTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.sstatesman.My.Resources.Resources.SSM_Icon_v2
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialogTemplate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DialogTemplate"
        Me.pnlWindowTop.ResumeLayout(False)
        Me.pnlWindowTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblWindowTitle As System.Windows.Forms.Label
    Protected WithEvents pnlWindowTop As System.Windows.Forms.Panel
    Protected WithEvents flpWindowBottom As System.Windows.Forms.FlowLayoutPanel

End Class
